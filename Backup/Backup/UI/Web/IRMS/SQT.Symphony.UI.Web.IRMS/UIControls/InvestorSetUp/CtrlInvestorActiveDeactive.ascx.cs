using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.Configuration;
using System.IO;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.InvestorSetUp
{
    public partial class CtrlInvestorActiveDeactive : System.Web.UI.UserControl
    {
        #region Variable

        public bool IsMessage = false;

        public Guid CompanyID
        {
            get
            {
                return ViewState["CompanyID"] != null ? new Guid(Convert.ToString(ViewState["CompanyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["CompanyID"] = value;
            }
        }

        public int SelectedRowIndex
        {
            get
            {
                return ViewState["SelectedRowIndex"] != null ? Convert.ToInt32(ViewState["SelectedRowIndex"]) : -1;
            }
            set
            {
                ViewState["SelectedRowIndex"] = value;
            }
        }
        public string StatusAction
        {
            get
            {
                return ViewState["StatusAction"] != null ? Convert.ToString(ViewState["StatusAction"]) : "";
            }
            set
            {
                ViewState["StatusAction"] = value;
            }
        }
        public string InvestorFullName
        {
            get
            {
                return ViewState["InvestorFullName"] != null ? Convert.ToString(ViewState["InvestorFullName"]) : "";
            }
            set
            {
                ViewState["InvestorFullName"] = value;
            }
        }
        #endregion Variable

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RoleRightJoinBLL.GetAccessString("InvestorSetUp.aspx", new Guid(Convert.ToString(Session["UserID"]))) == "NO")
                Response.Redirect("~/Applications/AccessDenied.aspx");
            LoadAccess();

            if (!IsPostBack)
            {
                LoadDefaultValue();
            }
        }

        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            DataView DV = RoleRightJoinBLL.GetIUDVAccess("InvestorSetUp.aspx", new Guid(Convert.ToString(Session["UserID"])));
            if (DV.Count > 0)
            {
                ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
                ViewState["Edit"] = Convert.ToBoolean(DV[0]["IsUpdate"]);
                ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            }
            else
                Response.Redirect("~/Applications/AccessDenied.aspx");
        }
        /// <summary>
        /// Load Default Value
        /// </summary>
        private void LoadDefaultValue()
        {
            try
            {
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Grid Event
        /// </summary>
        private void BindGrid()
        {
            Investor GetInv = new Investor();
            string InvestorName, Location, FirmName;

            if (hfSelectedAlphabet.Value.ToString() != string.Empty)
            {
                if (hfSelectedAlphabet.Value.ToString() != "ALL")
                    InvestorName = hfSelectedAlphabet.Value.ToString();
                else
                    InvestorName = null;

                hfSelectedAlphabet.Value = string.Empty;
            }
            else
            {
                if (txtSInvestorName.Text.Trim() != "")
                    InvestorName = txtSInvestorName.Text.Trim();
                else
                    InvestorName = null;
            }

            if (!txtSLocation.Text.Trim().Equals(""))
                Location = txtSLocation.Text.Trim();
            else
                Location = null;

            FirmName = null;

            DataSet Dst = InvestorBLL.SelectAllInvestorsForActiveInActive(InvestorName, Location, FirmName, ddlSStatus.SelectedValue.ToString(), this.CompanyID);
            grdInvestorList.DataSource = Dst.Tables[0];
            grdInvestorList.DataBind();

            litInvestorsCount.Text = "(" + Convert.ToString(Dst.Tables[0].Rows.Count) + ")";
        }

        private string MobileNo(string strMobileNo)
        {
            string strPhNo = "";

            string[] words = strMobileNo.Split('-');

            if (words.Length > 1)
            {
                if (words[0] != "")
                    strPhNo = Convert.ToString(words[0]);

                if (words[1] != "")
                {
                    if (strPhNo != "")
                        strPhNo = strPhNo + "-" + words[1];
                    else
                        strPhNo = words[1];
                }
            }

            return strPhNo;
        }

        private bool SendActivateEmail(User objUser)
        {
            try
            {
                bool isEmailSent = false;
                if (Session["PropertyConfigurationInfo"] != null)
                {
                    DataSet dsTemplate = SQT.Symphony.BusinessLogic.IRMS.BLL.EMailTmpltsBLL.GetDataByTitle("Investor Activation");
                    if (dsTemplate != null && dsTemplate.Tables.Count > 0 && dsTemplate.Tables[0].Rows.Count > 0)
                    {
                        PropertyConfiguration Prj = (PropertyConfiguration)(Session["PropertyConfigurationInfo"]);
                        string strHTML = Convert.ToString(dsTemplate.Tables[0].Rows[0]["Body"]); // File.ReadAllText(Server.MapPath("~/EmailTemplates/ActivateInvestor.htm"));

                        strHTML = strHTML.Replace("$FULLNAME$", this.InvestorFullName);
                        strHTML = strHTML.Replace("$PASSWORD$", objUser.Password);
                        strHTML = strHTML.Replace("$USERNAME$", objUser.UserName);
                        strHTML = strHTML.Replace("$COMPANYCONTACTNO$", Convert.ToString(Session["CompanyContactNo"]));
                        strHTML = strHTML.Replace("$COMPANYEMAIL$", Convert.ToString(Prj.PrimoryEmail));

                        isEmailSent = SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), objUser.UserName, "Investor Log in activation", strHTML);
                        if (isEmailSent)
                        {
                            SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), Convert.ToString(ConfigurationManager.AppSettings["IRManagerEmailID"]), "Investor Log in activation", strHTML);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please set Company email configuration");
                }
                return isEmailSent;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString() + " Once Send Email");
                return false;
            }
        }

        private void SendDeActivateEmail(User objUser)
        {
            try
            {
                if (Session["PropertyConfigurationInfo"] != null)
                {
                    DataSet dsTemplate = SQT.Symphony.BusinessLogic.IRMS.BLL.EMailTmpltsBLL.GetDataByTitle("Investor Deactivation");
                    if (dsTemplate != null && dsTemplate.Tables.Count > 0 && dsTemplate.Tables[0].Rows.Count > 0)
                    {
                        PropertyConfiguration Prj = (PropertyConfiguration)(Session["PropertyConfigurationInfo"]);
                        string strHTML = Convert.ToString(dsTemplate.Tables[0].Rows[0]["Body"]); // File.ReadAllText(Server.MapPath("~/EmailTemplates/Deactivate.htm"));

                        strHTML = strHTML.Replace("$FULLNAME$", this.InvestorFullName);
                        strHTML = strHTML.Replace("$PASSWORD$", objUser.Password);
                        strHTML = strHTML.Replace("$USERNAME$", objUser.UserName);
                        strHTML = strHTML.Replace("$COMPANYCONTACTNO$", Convert.ToString(Session["CompanyContactNo"]));
                        strHTML = strHTML.Replace("$COMPANYEMAIL$", Convert.ToString(Prj.PrimoryEmail));

                        SQT.Symphony.UI.Web.IRMS.SentMail.SendMail(Convert.ToString(Prj.PrimoryDomainName), Convert.ToString(Prj.UserName), Convert.ToString(Prj.Password), Convert.ToString(Prj.SmtpAddress), objUser.UserName, "Investor Log in deactivation", strHTML);
                    }
                }
                else
                {
                    MessageBox.Show("Please set Company email configuration");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString() + " Once Send Email");
            }
        }
        #endregion Private Method

        #region Control Event
        /// <summary>
        /// Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnPrintInvList_Click(object seder, EventArgs e)
        {
            if (grdInvestorList.Rows.Count > 0)
            {
                if (hfSelectedAlphabet.Value.ToString() != string.Empty)
                {
                    if (hfSelectedAlphabet.Value.ToString() != "ALL")
                        Session["InvestorNameToPrint"] = hfSelectedAlphabet.Value.ToString();
                    else
                        Session["InvestorNameToPrint"] = null;

                    hfSelectedAlphabet.Value = string.Empty;
                }
                else
                {
                    if (txtSInvestorName.Text.Trim() != "")
                        Session["InvestorNameToPrint"] = txtSInvestorName.Text.Trim();
                    else
                        Session["InvestorNameToPrint"] = null;
                }

                if (!txtSLocation.Text.Trim().Equals(""))
                    Session["LocationToPrint"] = txtSLocation.Text.Trim();
                else
                    Session["LocationToPrint"] = null;

                Session["StatusToPrint"] = ddlSStatus.SelectedValue.ToString();
                Session["CompanyIDForPrint"] = this.CompanyID;
                Session["GridInvPageIndex"] = grdInvestorList.PageIndex;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnInvestorListPrint();", true);

            }
        }
        protected void lnkAlphabet_OnClick(object sender, EventArgs e)
        {
            try
            {
                txtSInvestorName.Text = txtSLocation.Text = string.Empty;

                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void rdblInvestorStatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList rdblList = (RadioButtonList)sender;
            GridViewRow row = (GridViewRow)((rdblList).NamingContainer);
            this.SelectedRowIndex = Convert.ToInt32(row.RowIndex);

            this.InvestorFullName = ((Label)row.FindControl("lblGvFullName")).Text;
            if (rdblList.SelectedValue.ToString() == "0")
            {
                lblAskConfirmation.ForeColor = System.Drawing.Color.Red;
                lblAskConfirmation.Text = "Are you sure you want to <b>DEACTIVATE</b> this Investor?";
                this.StatusAction = "DEACTIVATE";

            }
            else
            {
                lblAskConfirmation.ForeColor = System.Drawing.Color.Black;
                lblAskConfirmation.Text = "Are you sure you want to <b>ACTIVATE</b> this Investor?";
                this.StatusAction = "ACTIVATE";
            }
            mpeAskConfirmation.Show();
        }
        #endregion Button Event

        #region Grid Event
        /// <summary>
        /// Grid Row Command Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdInvestorList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("RESENDACTMAIL"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    this.SelectedRowIndex = Convert.ToInt32(row.RowIndex);

                    this.InvestorFullName = ((Label)row.FindControl("lblGvFullName")).Text;

                    lblAskConfirmation.ForeColor = System.Drawing.Color.Black;
                    lblAskConfirmation.Text = "Are you sure you want to resend activation mail to this Investor?";
                    this.StatusAction = "REACTIVATE";

                    mpeAskConfirmation.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdInvestorList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Literal litMobileNo = (Literal)e.Row.FindControl("litMobileNo");
                    string strMobileNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNo"));

                    if (litMobileNo != null)
                    {
                        if (Convert.ToString(strMobileNo) != "")
                            litMobileNo.Text = Convert.ToString(MobileNo(strMobileNo));
                        else
                            litMobileNo.Text = "";
                    }

                    RadioButtonList rdbl = (RadioButtonList)e.Row.FindControl("rdblInvestorStatus");

                    if (DataBinder.Eval(e.Row.DataItem, "UserName") != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UserName")) != string.Empty)
                    {
                        if (DataBinder.Eval(e.Row.DataItem, "IsActive") != null && Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsActive")))
                        {
                            rdbl.SelectedValue = "1";
                            ((LinkButton)e.Row.FindControl("lnkResendActivationMail")).Visible = true;
                        }
                        else
                            rdbl.SelectedValue = "0";
                    }
                    else
                        rdbl.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void grdInvestorList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdInvestorList.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        #endregion Grid Event

        #region Popup Button Event
        /// <summary>
        /// Ok Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedRowIndex != -1)
                {
                    Guid usrID = new Guid(Convert.ToString(grdInvestorList.DataKeys[this.SelectedRowIndex]["UserID"]));
                    User invUser = UserBLL.GetByPrimaryKey(usrID);
                    User OldinvUser = UserBLL.GetByPrimaryKey(usrID);

                    if (this.StatusAction == "ACTIVATE" || this.StatusAction == "REACTIVATE")
                    {
                        invUser.IsActive = true;
                        UserBLL.Update(invUser);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", OldinvUser.ToString(), invUser.ToString(), "usr_User");

                        bool blYes = SendActivateEmail(invUser);

                        IsMessage = true;
                        if (blYes)
                        {
                            if (this.StatusAction == "ACTIVATE")
                                lblInvestorMsg.Text = "Investor activated successfully.";
                            else if (this.StatusAction == "REACTIVATE")
                                lblInvestorMsg.Text = "Investor activation mail resent successfully.";
                        }
                        else
                            lblInvestorMsg.Text = "System fail to sent activation email.";
                    }
                    else
                    {
                        invUser.IsActive = false;
                        UserBLL.Update(invUser);
                        ActionLogBLL.Save(new Guid(Convert.ToString(Session["UserID"])), "Update", OldinvUser.ToString(), invUser.ToString(), "usr_User");

                        IsMessage = true;
                        lblInvestorMsg.Text = "Investor deactivated successfully.";

                        ////SendDeActivateEmail(invUser);  Not to send deactivation email, If to send in future, just uncomment this and make isActive=1 in emailTemplate table.
                    }

                    mpeAskConfirmation.Hide();
                }

                grdInvestorList.PageIndex = 0;
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Cancel Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNo_Click(object sender, EventArgs e)
        {
            try
            {
                RadioButtonList rdbl = (RadioButtonList)grdInvestorList.Rows[this.SelectedRowIndex].FindControl("rdblInvestorStatus");

                if (this.StatusAction.ToUpper() == "ACTIVATE")
                    rdbl.SelectedValue = "0";
                else if (this.StatusAction.ToUpper() == "DEACTIVATE")
                    rdbl.SelectedValue = "1";
                else if (this.StatusAction.ToUpper() == "REACTIVATE")
                    rdbl.SelectedValue = "1";

                mpeAskConfirmation.Hide();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Popup Button Event
    }
}