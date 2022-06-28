using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlEmailConfiguration : System.Web.UI.UserControl
    {
        #region Variable & Property

        public Guid EmailConfigID
        {
            get
            {
                return ViewState["EmailConfigID"] != null ? new Guid(Convert.ToString(ViewState["EmailConfigID"])) : Guid.Empty;
            }
            set
            {
                ViewState["EmailConfigID"] = value;
            }

        }
        public string UserRights
        {
            get
            {
                return ViewState["UserRights"] != null ? Convert.ToString(ViewState["UserRights"]) : string.Empty;
            }
            set
            {
                ViewState["UserRights"] = value;
            }
        }


        //Property to save CompanyID
        public Guid PropertyConfigurationID
        {
            get
            {
                return ViewState["PropertyConfigurationID"] != null ? new Guid(Convert.ToString(ViewState["PropertyConfigurationID"])) : Guid.Empty;
            }
            set
            {
                ViewState["PropertyConfigurationID"] = value;
            }
        }
        public bool IsMessage = false;
        public bool IsPopupMessage = false;
        public bool IsListMessage = false;
        public bool IsDuplicateRecord = false;

        #endregion Variable & Property

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                CheckUserAuthorization();
                BindData();
                BindBreadCrumb();
            }
        }

        #endregion Form Load

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "EMAILCONFIGURATION.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnSMTPOK.Visible = this.UserRights.Substring(2, 1) == "1";
            btnAddTopEmailConfig.Visible = btnAddBottomEmailConfig.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        /// <summary>
        /// Bind Data Here
        /// </summary>
        private void BindData()
        {
            try
            {
                SetPageLables();
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            EmailConfig objEml = new EmailConfig();
            if (!txtPrimaryDomainName.Text.Trim().Equals(""))
                objEml.PrimoryDomainName = txtPrimaryDomainName.Text.Trim();
            else
                objEml.PrimoryDomainName = null;
            if (!txtSPrimaryEmail.Text.Trim().Equals(""))
                objEml.PrimoryEmail = txtSPrimaryEmail.Text.Trim();
            else
                objEml.PrimoryEmail = null;
            objEml.PropertyID = clsSession.PropertyID;
            objEml.CompanyID = clsSession.CompanyID;
            objEml.IsActive = true;

            List<EmailConfig> lstEmailConfig = EmailConfigBLL.GetAll(objEml);

            gvEmailConfigList.DataSource = lstEmailConfig;
            gvEmailConfigList.DataBind();

        }
        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            ltrMainHeading.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrMainHeading", "Email Configuration");
            ltrPrimaryDomainName.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrPrimaryDomainName", "Primary Domain Name");
            ltrSPrimaryEmail.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrSPrimaryEmail", "Primary Email");
            btnAddTopEmailConfig.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            btnAddBottomEmailConfig.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");

            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");

            btnSaveAndExit.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSaveAndClose", "Save And Close");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "lblHeaderConfirmDeletePopup", "Emial Configuration");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");

            //List Header

            ltrEmailConfigList.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrEmailConfigList", "Email Configuration List");
            //Form Label
            ltrSMTPSetpHeading.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrSMTPSetpHeading", "Email Configuration");
            ltrSMTPAddress.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrSMTPAddress", "SMTP Address");
            ltrSMTPPOT.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrSMTPPOT", "SMTP Pot");
            ltrPOP3Server.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrPOP3Server", "POP3 Server");
            ltrPOP3OutGoingServer.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrPOP3OutGoingServer", "Outgoing Server");
            ltrUserName.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrUserName", "User Name");
            ltrPassword.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrPassword", "Password");
            ltrPrimaryEmail.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrPrimaryEmail", "Primary Email");
            ltrPrimaryDomain.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrPrimaryDomain", "Primary Domain");
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");

            // System SMTP Email Setup


            ltrSMTPEmailSetup.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrSMTPEmailSetup", "System EMail Setup");
            //ltrSMTPEmailDescription.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrSMTPEmailDescription", "Sending Email require you to setup SMTP Email information");
            ltrSysSMTPSetpHeading.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrSMTPSetupHeading", "SMTP Setup");
            ltrSysSMTPAddress.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrSMTPAddress", "SMTP Address");
            ltrSysDNSName.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrDNSName", "DNS Name");
            ltrSysPOP3Server.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrPOP3Server", "POP3 Server");
            ltrSysPOP3OutGoingServer.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrPOP3OutGoingServer", "Outgoing Server");
            ltrSysUserName.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrUserName", "User Name");
            ltrSysPassword.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrPassword", "Password");
            ltrSysPrimaryEmail.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrPrimaryEmail", "Primary Email");
            ltrSysPrimaryDomain.Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrPrimaryDomain", "Primary Domain");

            litGeneralMandartoryFiledMessageForSMTP.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");           
            btnSMTPOK.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnSMTPCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            lnkbtnSMTPEmail.Text = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
        
        
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

            if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            {
                DataRow dr = dt.NewRow();
                dr["NameColumn"] = clsSession.CompanyName;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblCommunicationSetup", "Communication Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblEmailConfiguration", "Email Configuration");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void SaveAndUpdateCurrency()
        {
            EmailConfig IsEmal = new EmailConfig();
            IsEmal.PrimoryDomainName = txtPrimaryDomain.Text.Trim();
            IsEmal.PrimoryEmail = txtPrimaryEmail.Text.Trim();
            IsEmal.IsActive = true;
            IsEmal.PropertyID = clsSession.PropertyID;
            IsEmal.CompanyID = clsSession.CompanyID;
            List<EmailConfig> LstEmal = null;
            LstEmal = EmailConfigBLL.GetAll(IsEmal);

            if (LstEmal.Count > 0)
            {
                if (this.EmailConfigID != Guid.Empty)
                {
                    if (Convert.ToString(LstEmal[0].EmailConfigID) != Convert.ToString(this.EmailConfigID.ToString()))
                    {
                        IsDuplicateRecord = IsPopupMessage = true;
                        ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        mpeEmailConfiguration.Show();
                        return;
                    }
                }
                else
                {
                    IsDuplicateRecord = IsPopupMessage = true;
                    ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                    mpeEmailConfiguration.Show();
                    return;

                }
            }
            if (this.EmailConfigID != Guid.Empty)
            {
                EmailConfig objUpd = new EmailConfig();
                EmailConfig objOldCurr = new EmailConfig();
                objUpd = EmailConfigBLL.GetByPrimaryKey(this.EmailConfigID);
                objOldCurr = EmailConfigBLL.GetByPrimaryKey(this.EmailConfigID);
                objUpd.CompanyID = clsSession.CompanyID;
                objUpd.PropertyID = clsSession.PropertyID;
                objUpd.PrimoryEmail = txtPrimaryEmail.Text;
                objUpd.PrimoryDomainName = txtPrimaryDomain.Text;
                objUpd.SMTPHost = txtSMTPAddress.Text;
                objUpd.SMTPPort = txtSMTPPOT.Text;
                objUpd.POP3InServer = txtPOP3Server.Text;
                objUpd.POP3OutGoingServer = txtPOP3OutGoingServer.Text;
                objUpd.UserName = txtUserName.Text;
                objUpd.Password = txtPassword.Text;
                objUpd.IsActive = true;
                objUpd.UpdatedBy = clsSession.UserID;
                objUpd.UpdatedOn = DateTime.Now.Date;
                EmailConfigBLL.Update(objUpd);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldCurr.ToString(), objUpd.ToString(), "mst_EmailConfig");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
            }
            else
            {
                EmailConfig objIns = new EmailConfig();
                objIns.CompanyID = clsSession.CompanyID;
                objIns.PropertyID = clsSession.PropertyID;
                objIns.PrimoryEmail = txtPrimaryEmail.Text;
                objIns.PrimoryDomainName = txtPrimaryDomain.Text;
                objIns.SMTPHost = txtSMTPAddress.Text;
                objIns.SMTPPort = txtSMTPPOT.Text;
                objIns.POP3InServer = txtPOP3Server.Text;
                objIns.POP3OutGoingServer = txtPOP3OutGoingServer.Text;
                objIns.UserName = txtUserName.Text;
                objIns.Password = txtPassword.Text;
                objIns.IsActive = true;
                objIns.UpdatedBy = clsSession.UserID;
                objIns.UpdatedOn = DateTime.Now.Date;
                EmailConfigBLL.Save(objIns);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objIns.ToString(), objIns.ToString(), "mst_EmailConfig");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

            }
            BindGrid();
        }

        private void ClearControl()
        {
            IsDuplicateRecord = false;
            this.EmailConfigID = Guid.Empty;
            txtPrimaryEmail.Text = txtPrimaryDomain.Text = txtSMTPAddress.Text = txtSMTPPOT.Text = txtPOP3Server.Text = txtPOP3OutGoingServer.Text = txtUserName.Text = txtPassword.Text = "";
            txtPassword.Attributes.Add("value", string.Empty);
        }

        private void ClearSearchControl()
        {
            txtPrimaryDomainName.Text = txtSPrimaryEmail.Text = "";
        }

        #endregion Private Method

        #region Grid Event
        /// <summary>
        /// Grid Row Data Bound Event
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as GridViewRowEventArgs</param>
        protected void gvEmailConfigList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                ((LinkButton)e.Row.FindControl("lnkDelete")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                ((LinkButton)e.Row.FindControl("lnkDelete")).OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EmailConfigID")));

                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                if (this.UserRights.Substring(2, 1) == "1")
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                else
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Literal)e.Row.FindControl("lblGvHdrEditView")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                ((Literal)e.Row.FindControl("ltrGvHdrPrimaryDomain")).Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrGvHdrPrimaryDomain", "Primary Domain Name");
                ((Literal)e.Row.FindControl("ltrGvHdrPrimaryEmail")).Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrGvHdrPrimaryEmail", "Primary Email");
                ((Literal)e.Row.FindControl("ltrGvHdrSMTPHost")).Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "ltrGvHdrSMTPHost", "SMTP Host");
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("EmailConfiguration", "lblNoRecordFound", "No any record found.");
            }
        }
        /// <summary>
        /// Grid Row Command Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as GridViewCommandEventArgs</param>
        protected void gvEmailConfigList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("EDITDATA"))
            {
                btnSave.Visible = btnSaveAndExit.Visible = this.UserRights.Substring(2, 1) == "1";
                ClearControl();
                mpeEmailConfiguration.Show();
                this.EmailConfigID = new Guid(Convert.ToString(e.CommandArgument));
                EmailConfig objEmla = new EmailConfig();
                objEmla = EmailConfigBLL.GetByPrimaryKey(this.EmailConfigID);
                if (objEmla != null)
                {
                    txtPrimaryEmail.Text = objEmla.PrimoryEmail;
                    txtPrimaryDomain.Text = objEmla.PrimoryDomainName;
                    txtSMTPAddress.Text = objEmla.SMTPHost;
                    txtSMTPPOT.Text = objEmla.SMTPPort;
                    txtPOP3Server.Text = objEmla.POP3InServer;
                    txtPOP3OutGoingServer.Text = objEmla.POP3OutGoingServer;
                    txtUserName.Text = objEmla.UserName;
                    txtPassword.Text = objEmla.Password;
                    txtPassword.Attributes.Add("value", objEmla.Password);
                }
            }
            else if (e.CommandName.ToUpper().Equals("DELETEDATA"))
            {
                ClearControl();
                this.EmailConfigID = new Guid(Convert.ToString(e.CommandArgument));
                mpeConfirmDelete.Show();
            }
        }

        #endregion Grid Event

        #region Button Event
        /// <summary>
        /// Add New Currency Value
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e a EventArgs</param>
        protected void btnAddTopEmailConfig_Click(object sender, EventArgs e)
        {
            btnSave.Visible = btnSaveAndExit.Visible = this.UserRights.Substring(1, 1) == "1";
            ClearControl();
            mpeEmailConfiguration.Show();
        }

        /// <summary>
        /// SAve Email Configuration
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateCurrency();
                    if (!IsDuplicateRecord)
                        ClearControl();
                    mpeEmailConfiguration.Show();
                }
                catch (Exception ex)
                {
                    mpeEmailConfiguration.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }
        /// <summary>
        /// Save And Exit Email Configuration
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnSaveAndExit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateCurrency();
                    if (!IsDuplicateRecord)
                    {
                        mpeEmailConfiguration.Hide();
                        IsListMessage = true;

                        if (this.EmailConfigID != Guid.Empty)
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                        else
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                        ClearControl();
                    }
                }
                catch (Exception ex)
                {
                    mpeEmailConfiguration.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }
        /// <summary>
        /// Search Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void imgbtnClearSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearSearchControl();
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Popup Yes Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e"></param>
        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    mpeEmailConfiguration.Hide();
                    EmailConfig objDelete = new EmailConfig();
                    objDelete = EmailConfigBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    EmailConfigBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_EmailConfig");
                    IsListMessage = true;
                    ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    ClearControl();
                }
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Button Event

        #region SMTP Email Setup Click Event
        /// <summary>
        /// Configure Email Option Here
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as EventArgs</param>
        protected void lnkbtnSMTPEmail_Click(object sender, EventArgs e)
        {
            SMTPSetup.Show();
            if (clsSession.CompanyID != Guid.Empty && clsSession.PropertyID != Guid.Empty)
            {
                PropertyConfiguration GetData = new PropertyConfiguration();
                GetData.CompanyID = clsSession.CompanyID;
                GetData.PropertyID = clsSession.PropertyID;
                GetData.IsActive = true;
                List<PropertyConfiguration> LstData = PropertyConfigurationBLL.GetAll(GetData);
                if (LstData.Count == 1)
                {
                    this.PropertyConfigurationID = LstData[0].PropertyConfigurationID;
                    txtSysSMTPAddress.Text = LstData[0].SmtpAddress;
                    txtSysDNSName.Text = LstData[0].DNSName;
                    txtSysPOP3Server.Text = LstData[0].POP3InServer;
                    txtSysPOP3OutGoingServer.Text = LstData[0].POP3OutGoingServer;
                    txtSysUserName.Text = LstData[0].UserName;
                    txtSysPassword.Text = LstData[0].Password;
                    txtSysPassword.Attributes.Add("value", LstData[0].Password);
                    txtSysPrimaryEmail.Text = LstData[0].PrimoryEmail;
                    txtSysPrimaryDomain.Text = LstData[0].PrimoryDomainName;
                }
            }
        }


        protected void btnSMTPOK_Click(object sender, EventArgs e)
        {
            if (this.PropertyConfigurationID != Guid.Empty)
            {
                //Update Record
                PropertyConfiguration Updt = PropertyConfigurationBLL.GetByPrimaryKey(this.PropertyConfigurationID);
                Updt.SmtpAddress = txtSysSMTPAddress.Text.Trim();
                Updt.DNSName = txtSysDNSName.Text.Trim();
                Updt.POP3InServer = txtSysPOP3Server.Text.Trim();
                Updt.POP3OutGoingServer = txtSysPOP3OutGoingServer.Text.Trim();
                Updt.UserName = txtSysUserName.Text.Trim();
                Updt.Password = txtSysPassword.Text.Trim();
                Updt.PrimoryEmail = txtSysPrimaryEmail.Text.Trim();
                Updt.PrimoryDomainName = txtSysPrimaryDomain.Text.Trim();
                PropertyConfigurationBLL.Update(Updt);
            }
            //IsMessage = true;
            IsListMessage = true;
            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
            SMTPSetup.Hide();
        }

        protected void btnSMTPCancel_Click(object sender, EventArgs e)
        {
            SMTPSetup.Hide();
        }
        #endregion SMTP Email Setup Click Event
    }
}