using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.IO;
using System.Data;

namespace SQT.Symphony.UI.Web.Configuration
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetPageLables();
                mvResetPassword.ActiveViewIndex = 0;
            }
        }
        #endregion

        #region Control events
        protected void btnGo_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (Request["key"] != null)
                {
                    SQT.Symphony.BusinessLogic.Configuration.DTO.User objUser = new User();
                    objUser.UserName = txtEmail.Text.Trim();
                    objUser.PasswordKey = Convert.ToString(Request["key"]);
                    objUser.IsActive = true;
                    objUser.IsBlock = false;
                    List<User> lstUser = UserBLL.GetAll(objUser);
                    if (lstUser.Count > 0)
                    {
                        mvResetPassword.ActiveViewIndex = 1;
                    }
                    else
                        MessageBox.Show(clsCommon.GetGlobalResourceText("ResetPassword", "lblMsgNoUserFound", "No user found with this Email."));
                }
                else
                    MessageBox.Show(clsCommon.GetGlobalResourceText("ResetPassword", "lblMsgPasswordKeyNotFound", "Password key not found."));
            }
            catch (Exception ex)
            {
                MessageBox.Show(clsCommon.GetGlobalResourceText("ResetPassword", "lblMsgErrorMessage", "Sorry for inconvenience, we can't process your request."));
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Index.aspx");
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (Request["key"] != null)
                {
                    SQT.Symphony.BusinessLogic.Configuration.DTO.User objUser = new User();
                    objUser.UserName = txtEmail.Text.Trim();
                    objUser.PasswordKey = Convert.ToString(Request["key"]);
                    objUser.IsActive = true;
                    objUser.IsBlock = false;
                    List<User> lstUser = UserBLL.GetAll(objUser);
                    if (lstUser.Count > 0)
                    {
                        SQT.Symphony.BusinessLogic.Configuration.DTO.User usrUser = lstUser[0];
                        usrUser.PasswordKey = Guid.NewGuid().ToString().Substring(0, 25);
                        usrUser.Password = txtPassword.Text.Trim();
                        UserBLL.Update(usrUser);

                        Guid? companyID = null;
                        Guid? propertyID = null;

                        if (Convert.ToString(usrUser.CompanyID) != string.Empty)
                            companyID = new Guid(Convert.ToString(usrUser.CompanyID));

                        //If user has propertyID, then....
                        if (Convert.ToString(usrUser.PropertyID) != string.Empty && Convert.ToString(usrUser.PropertyID) != Guid.Empty.ToString())
                            propertyID = new Guid(Convert.ToString(usrUser.PropertyID));
                        else
                        {
                            //Company Administrator has no PropertyID, So to use default property's ids.
                            propertyID = new Guid("BBB0707B-AB26-4B6D-A5B5-C33B4A774ABC");
                            companyID = new Guid("AAA0707A-2C6A-4C39-896C-B3025CF8BD16");
                        }

                        //Get Email Template info. First table contains Email template and second table contains it's Email Configuration info.
                        DataSet dsSearchEmailTemplate = EMailTemplatesBLL.GetDataByProperty(propertyID, companyID, "Reset Password");
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
                                PropertyConfiguration ObjPrtConfig = PropertyConfigurationBLL.GetByCmpnAndPrpt(companyID, propertyID);
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
                                strHTML = strHTML.Replace("$USERDISPLAYNAME$", usrUser.UserDisplayName);
                                SentMail.SendMail(strPrimoryDomainName, strUserName, strPassword, strSmtpAddress, txtEmail.Text.Trim(), clsCommon.GetGlobalResourceText("CommonMessage", "lblResetPasswordEmailSubject", "Notification of Reset password"), strHTML);
                            }
                            else
                                MessageBox.Show(clsCommon.GetGlobalResourceText("ResetPassword", "lblMsgErrorMessage", "Sorry for inconvenience, we can't process your request."));

                            mvResetPassword.ActiveViewIndex = 2;
                        }
                        else
                            MessageBox.Show(clsCommon.GetGlobalResourceText("ForgotPassword", "lblMsgSystemCantSendMail", "Sorry for inconvenience, system can't send mail. Please try again later."));
                    }
                    else
                        MessageBox.Show(clsCommon.GetGlobalResourceText("ResetPassword", "lblMsgNoUserFound", "No user found with this Email."));
                }
                else
                    MessageBox.Show(clsCommon.GetGlobalResourceText("ResetPassword", "lblMsgPasswordKeyNotFound", "Password key not found."));
            }
            catch (Exception ex)
            {
                MessageBox.Show(clsCommon.GetGlobalResourceText("ResetPassword", "lblMsgErrorMessage", "Sorry for inconvenience, we can't process your request."));
            }
        }

        protected void btnCancelSave_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Index.aspx");
        }

        protected void btnOK_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Index.aspx");
        }

        #endregion

        #region Private Method
        private void SetPageLables()
        {
            ltrPageTitle.Text = clsCommon.GetGlobalResourceText("RestPassword", "lblPageTitle", "Uniworld | Reset Password");
            ltrMainHeader.Text = clsCommon.GetGlobalResourceText("RestPassword", "lblMainHeader", "RESET PASSWORD");
            ltrEmail.Text = clsCommon.GetGlobalResourceText("RestPassword", "lblEmail", "Email");
            btnGo.Text = clsCommon.GetGlobalResourceText("RestPassword", "lblBtnSubmitEmail", "Submit");
            ltrNewPassword.Text = clsCommon.GetGlobalResourceText("RestPassword", "lblNewPassword", "New Password");
            ltrConfirmPassword.Text = clsCommon.GetGlobalResourceText("RestPassword", "lblConfirmPassword", "Confirm Password");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancel.Text = btnCancelSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            ltrMsgPasswordResetSuccessfully.Text = clsCommon.GetGlobalResourceText("RestPassword", "lblMsgPasswordResetSuccessfully", "Password reset successfully.");
            btnGoToLogin.Text = clsCommon.GetGlobalResourceText("RestPassword", "lblBtnOKAfterResetPassword", "OK");
        }
        #endregion
    }
}