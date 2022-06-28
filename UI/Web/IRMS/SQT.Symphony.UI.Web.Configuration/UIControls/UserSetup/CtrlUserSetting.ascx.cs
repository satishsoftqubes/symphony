using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.IO;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.UserSetup
{
    public partial class CtrlUserSetting : System.Web.UI.UserControl
    {
        #region Property and Variables
        public bool IsFeedbackMessage = false;
        public bool IsWrongPassword = false;
        #endregion

        #region Form Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                BindBreadCrumb();
            }
        }

        #endregion Form Load

        #region Private Method
        private void BindData()
        {
            try
            {
                SetPageLables();
                User objUser = UserBLL.GetByPrimaryKey(clsSession.UserID);
                lblDisplayName.Text = txtDisplayName.Text = Convert.ToString(objUser.UserDisplayName);

                string strPwd = string.Empty;
                for (int i = 0; i < objUser.Password.Length; i++)
                {
                    strPwd = strPwd + "*";
                }

                lblPassword.Text = strPwd;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            //DataRow dr2 = dt.NewRow();
            //dr2["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblDashboard", "Dashboard");
            //dr2["Link"] = "";
            //dt.Rows.Add(dr2);

            //if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["NameColumn"] = clsSession.CompanyName ;
            //    dr["Link"] = "~/GUI/Property/CompanyList.aspx";
            //    dt.Rows.Add(dr);
            //}

            //DataRow dr1 = dt.NewRow();
            //dr1["NameColumn"] = clsSession.PropertyName ;
            //dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            //dt.Rows.Add(dr1);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblUserSetting", "User Setting");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Send Email To Investor Creation
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        private void ChangePasswordEmail(string FullName, string UserName, string Password)
        {
            try
            {
                Guid? companyID = null;
                Guid? propertyID = null;

                DataSet dsSearchEmailTemplate = new DataSet();

                //Get Email Template info. First table contains Email template and second table contains it's Email Configuration info.
                if (clsSession.UserType.ToUpper() == "SUPERADMIN" || clsSession.UserType.ToUpper() == "ADMINISTRATOR")
                    dsSearchEmailTemplate = EMailTemplatesBLL.GetDataByProperty(new Guid("BBB0707B-AB26-4B6D-A5B5-C33B4A774ABC"), new Guid("AAA0707A-2C6A-4C39-896C-B3025CF8BD16"), "Change Password");
                else
                    dsSearchEmailTemplate = EMailTemplatesBLL.GetDataByProperty(clsSession.PropertyID, clsSession.CompanyID, "Change Password");

                if (dsSearchEmailTemplate != null && dsSearchEmailTemplate.Tables.Count > 0)
                {
                    string strPrimoryDomainName = string.Empty;
                    string strUserName = string.Empty;
                    string strPassword = string.Empty;
                    string strSmtpAddress = string.Empty;

                    //If second table cotains data, then use this SMTP detail.
                    if (dsSearchEmailTemplate.Tables.Count > 1 && dsSearchEmailTemplate.Tables[1].Rows.Count > 0)
                    {
                        strPrimoryDomainName = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["PrimoryDomainName"]);
                        strUserName = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["UserName"]);
                        strPassword = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["Password"]);
                        strSmtpAddress = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["SMTPHost"]);
                    }
                    else
                    {
                        // else use Property's default smtp detail.
                        PropertyConfiguration ObjPrtConfig = new PropertyConfiguration();

                        if (clsSession.UserType.ToUpper() == "SUPERADMIN" || clsSession.UserType.ToUpper() == "ADMINISTRATOR")
                            ObjPrtConfig = PropertyConfigurationBLL.GetByCmpnAndPrpt(new Guid("AAA0707A-2C6A-4C39-896C-B3025CF8BD16"), new Guid("BBB0707B-AB26-4B6D-A5B5-C33B4A774ABC"));
                        else
                            ObjPrtConfig = PropertyConfigurationBLL.GetByCmpnAndPrpt(companyID, propertyID);

                        if (ObjPrtConfig != null)
                        {
                            strPrimoryDomainName = Convert.ToString(ObjPrtConfig.PrimoryDomainName);
                            strUserName = Convert.ToString(ObjPrtConfig.UserName);
                            strPassword = Convert.ToString(ObjPrtConfig.Password);
                            strSmtpAddress = Convert.ToString(ObjPrtConfig.SmtpAddress);
                        }
                        else
                        {
                            MessageBox.Show(clsCommon.GetGlobalResourceText("ForgotPassword", "lblMsgSystemCantSendMail", "Sorry for inconvenience, system can't send mail. Please try again later."));
                            return;
                        }
                    }

                    //if smtp(either from template's Email config or from property's email config) exist, then send mail.
                    if (strPrimoryDomainName != string.Empty && strUserName != string.Empty && strPassword != string.Empty && strSmtpAddress != string.Empty)
                    {
                        string strHTML = Convert.ToString(dsSearchEmailTemplate.Tables[0].Rows[0]["Body"]);
                        strHTML = strHTML.Replace("$FULLNAME$", FullName);
                        strHTML = strHTML.Replace("$PASSWORD$", Password);
                        SentMail.SendMail(strPrimoryDomainName, strUserName, strPassword, strSmtpAddress, UserName, clsCommon.GetGlobalResourceText("CommonMessage", "lblPasswordChangeEmailSubject", "Password Change Notification"), strHTML);
                    }
                    else
                        MessageBox.Show(clsCommon.GetGlobalResourceText("ForgotPassword", "lblMsgErrorMessage", "Sorry for inconvenience, we can't process your request."));
                }
                else
                    MessageBox.Show(clsCommon.GetGlobalResourceText("ForgotPassword", "lblMsgSystemCantSendMail", "Sorry for inconvenience, system can't send mail. Please try again later."));
            }
            catch (Exception ex)
            {
                MessageBox.Show(clsCommon.GetGlobalResourceText("ResetPassword", "lblMsgErrorMessage", "Sorry for inconvenience, we can't process your request."));
            }
        }
        private void SetPageLables()
        {
            ltrMainHeader.Text = clsCommon.GetGlobalResourceText("UserSettings", "lblMainHeader", "SETTING");
            lblHeaderChangeDisplayName.Text = clsCommon.GetGlobalResourceText("UserSettings", "lblHeaderChangeDisplayName", "Change Display Name");
            ltrDisplayName.Text = clsCommon.GetGlobalResourceText("UserSettings", "lblDisplayName", "Display Name");
            lnkChangeDisplayName.Text = clsCommon.GetGlobalResourceText("UserSettings", "lblBtnChangeDisplayName", "Change");
            lblHeaderChangePassword.Text = clsCommon.GetGlobalResourceText("UserSettings", "lblHeaderChangePassword", "Change Password");
            ltrPassword.Text = clsCommon.GetGlobalResourceText("UserSettings", "lblPassword", "Password");
            lnkChangePassword.Text = clsCommon.GetGlobalResourceText("UserSettings", "lblBtnChangePassword", "Change");
            ltrHeaderChangeDisplayName.Text = clsCommon.GetGlobalResourceText("UserSettings", "lblPopupHeaderChangeDisplayName", "Change Display Name");
            ltrUserDisplayName.Text = clsCommon.GetGlobalResourceText("UserSettings", "lblDisplayName", "Display Name");
            btnSaveDisplayName.Text = btnSavePassword.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnUpdate", "Update");
            btnCancelChangeDisplayName.Text = btnCancelChangePassword.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            ltrHeaderChangePassword.Text = clsCommon.GetGlobalResourceText("UserSettings", "lblPopupHeaderChangePassword", "Change Password");
            ltrCurrentPassword.Text = clsCommon.GetGlobalResourceText("UserSettings", "lblCurrentPassword", "Current Password");
            ltrNewPassword.Text = clsCommon.GetGlobalResourceText("UserSettings", "lblNewPassword", "New Password");
            ltrRepeatPassword.Text = clsCommon.GetGlobalResourceText("UserSettings", "lblRepeatPassword", "Repeat Password");
            cmpvRepeatPassword.Text = clsCommon.GetGlobalResourceText("UserSettings", "lblMsgNewAndRepeatPwdShouldbeSame", "Repeat Password should be same as New Password.");
            litGeneralMandartoryFiledMessageForDisplayName.Text = litGeneralMandartoryFiledMessageForPassword.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
        }
        #endregion

        #region Control Events
        protected void btnSaveDisplayName_Click(object sender, EventArgs e)
        {
            try
            {
                User objUser = UserBLL.GetByPrimaryKey(clsSession.UserID);
                objUser.UserDisplayName = txtDisplayName.Text.Trim();
                UserBLL.Update(objUser);

                //Label lblUserDisplayName = (Label)this.Page.Master.FindControl("lblUserDisplayName");
                clsSession.DisplayName = lblDisplayName.Text = txtDisplayName.Text.Trim();
                IsFeedbackMessage = true;
                ltrMsgFeedback.Text = clsCommon.GetGlobalResourceText("UserSettings", "lblMsgDisplayNameUpdatedSuccessfully", "Display name updated successfully.");
                mpeChangeDisplayName.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        protected void btnSavePassword_Click(object sender, EventArgs e)
        {
            try
            {
                User objUser = UserBLL.GetByPrimaryKey(clsSession.UserID);
                if (objUser.Password != txtCurrentPassword.Text.Trim())
                {
                    IsWrongPassword = true;
                    ltrMsgWrongPassword.Text = clsCommon.GetGlobalResourceText("UserSettings", "lblMsgInvalidCurrentPassword", "Invalid Current Password.");
                    mpeChangePassword.Show();
                    return;
                }
                else
                {
                    objUser.Password = txtNewPassword.Text.Trim();
                    UserBLL.Update(objUser);

                    ChangePasswordEmail(objUser.UserDisplayName, objUser.UserName, objUser.Password);

                    string strPwd = string.Empty;
                    for (int i = 0; i < txtNewPassword.Text.Trim().Length; i++)
                    {
                        strPwd = strPwd + "*";
                    }

                    lblPassword.Text = strPwd;

                    IsFeedbackMessage = true;
                    ltrMsgFeedback.Text = clsCommon.GetGlobalResourceText("UserSettings", "lblMsgPasswordChangedSuccessfully", "Password changed successfully.");
                    mpeChangePassword.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
        #endregion
    }
}