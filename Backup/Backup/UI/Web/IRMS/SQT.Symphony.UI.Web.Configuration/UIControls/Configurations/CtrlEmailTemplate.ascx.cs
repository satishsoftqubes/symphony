using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlEmailTemplate : System.Web.UI.UserControl
    {
        #region Variable & Property

        public Guid EmailTemplateID
        {
            get
            {
                return ViewState["EmailTemplateID"] != null ? new Guid(Convert.ToString(ViewState["EmailTemplateID"])) : Guid.Empty;
            }
            set
            {
                ViewState["EmailTemplateID"] = value;
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
        public bool IsPopupMessage = false;
        public bool IsListMessage = false;
        public bool IsDuplicateRecord = false;
        public bool IsAddNew = false;
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
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "EMAILTEMPALTESETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            //btnAddTopEmailTemplate.Visible = btnAddEmailTemplate.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        /// <summary>
        /// Bind Data Here
        /// </summary>
        private void BindData()
        {
            try
            {
                SetPageLables();
                BindActionType();
                BindEmailConfiguration();
                BindGrid();

                mvEmailTemplate.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);           
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Email Configurations
        /// </summary>
        private void BindEmailConfiguration()
        {
            ddlEmailConfiguration.Items.Clear();
            EmailConfig GetEmalCnfg = new EmailConfig();
            GetEmalCnfg.CompanyID = clsSession.CompanyID;
            GetEmalCnfg.PropertyID = clsSession.PropertyID;
            GetEmalCnfg.IsActive = true;
            List<EmailConfig> LstConfig = EmailConfigBLL.GetAll(GetEmalCnfg);
            if (LstConfig.Count > 0)
            {
                LstConfig.Sort((EmailConfig r1, EmailConfig r2) => r1.PrimoryDomainName.CompareTo(r2.PrimoryDomainName));
                ddlEmailConfiguration.DataSource = LstConfig;
                ddlEmailConfiguration.DataTextField = "PrimoryDomainName";
                ddlEmailConfiguration.DataValueField = "EmailConfigID";
                ddlEmailConfiguration.DataBind();
                ddlEmailConfiguration.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlEmailConfiguration.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        /// <summary>
        /// Bind Action Type Here
        /// </summary>
        private void BindActionType()
        {
            ddlActionType.Items.Clear();
            ProjectTerm GetUserType = new ProjectTerm();
            GetUserType.CompanyID = clsSession.CompanyID;
            GetUserType.PropertyID = clsSession.PropertyID;
            GetUserType.Category = "EMAILTEMPLATEACTIONTYPE";
            GetUserType.IsActive = true;
            List<ProjectTerm> LstUserType = ProjectTermBLL.GetAll(GetUserType);
            if (LstUserType.Count > 0)
            {
                LstUserType.Sort((ProjectTerm r1, ProjectTerm r2) => r1.DisplayTerm.CompareTo(r2.DisplayTerm));
                ddlActionType.DataSource = LstUserType;
                ddlActionType.DataTextField = "DisplayTerm";
                ddlActionType.DataValueField = "TermID";
                ddlActionType.DataBind();
                ddlActionType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlActionType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
        }
        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            EMailTemplates objEml = new EMailTemplates();
            if (!txtSTitle.Text.Trim().Equals(""))
                objEml.Title = txtSTitle.Text.Trim();
            else
                objEml.Title = null;
            objEml.PropertyID = clsSession.PropertyID;
            objEml.CompanyID = clsSession.CompanyID;
            objEml.IsActive = true;
            DataSet lstEmailConfig = EMailTemplatesBLL.SearchData(objEml);
            DataView Dv = new DataView(lstEmailConfig.Tables[0]);
            Dv.Sort = "Title ASC";
            gvEmailTemplateList.DataSource = lstEmailConfig;
            gvEmailTemplateList.DataBind();

        }
        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            ltrEmailLatterHeading.Text = clsCommon.GetGlobalResourceText("EmailTemplate", "ltrEmailLatterHeading", "Email Notification Template");
            litSTitle.Text = clsCommon.GetGlobalResourceText("EmailTemplate", "litSTitle", "Title");
            //btnAddTopEmailTemplate.Text = clsCommon.GetGlobalResourceText("EmailTemplate", "btnAddTopEmailTemplate", "Add New");
            //btnAddEmailTemplate.Text = clsCommon.GetGlobalResourceText("EmailTemplate", "btnAddEmailTemplate", "Add New");
            litEmailConfiguration.Text = clsCommon.GetGlobalResourceText("EmailTemplate", "litEmailConfiguration", "Email Configuration");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("EmailTemplate", "lblHeaderConfirmDeletePopup", "Email Template");

            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnBackToList.Text = clsCommon.GetGlobalResourceText("Common", "lblbtnBackToList", "Back to List");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");

            btnSearchBlock.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");

            ltrNewsLatterList.Text = clsCommon.GetGlobalResourceText("EmailTemplate", "ltrNewsLatterList", "Email Notification Template List");
            //Form Label
            ltrTitle.Text = clsCommon.GetGlobalResourceText("EmailTemplate", "ltrTitle", "Title");
            ltrActionType.Text = clsCommon.GetGlobalResourceText("EmailTemplate", "ltrActionType", "ActionType");
            ltrBody.Text = clsCommon.GetGlobalResourceText("EmailTemplate", "ltrBody", "Details");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
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
                dr["NameColumn"] = clsSession.CompanyName ;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName ;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblCommunicationSetup", "Communication Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            if (this.EmailTemplateID != Guid.Empty || mvEmailTemplate.ActiveViewIndex == 1)
            {
                DataRow dr3 = dt.NewRow();
                dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblEmailTemplates", "Email Notification Template");
                dr3["Link"] = "~/GUI/Configurations/EmailTempaltes.aspx";
                dt.Rows.Add(dr3);

                DataRow dr5 = dt.NewRow();
                dr5["NameColumn"] = txtTitle.Text.Trim() == string.Empty ? clsCommon.GetGlobalResourceText("BreadCrumb", "lblNewEmailTemplate", "New Email Notification Template") : txtTitle.Text.Trim();
                dr5["Link"] = "";
                dt.Rows.Add(dr5);
            }
            else
            {
                DataRow dr3 = dt.NewRow();
                dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblEmailTemplates", "Email Notification Template");
                dr3["Link"] = "";
                dt.Rows.Add(dr3);
            }

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void SaveAndUpdateCurrency()
        {
            EMailTemplates IsEmal = new EMailTemplates();
            IsEmal.Title = txtTitle.Text.Trim();
            IsEmal.ActionType_TermID = new Guid(ddlActionType.SelectedValue.ToString());
            IsEmal.IsActive = true;
            IsEmal.PropertyID = clsSession.PropertyID;
            IsEmal.CompanyID = clsSession.CompanyID;
            List<EMailTemplates> LstEmal = null;
            LstEmal = EMailTemplatesBLL.GetAll(IsEmal);

            if (LstEmal.Count > 0)
            {
                if (this.EmailTemplateID != Guid.Empty)
                {
                    if (Convert.ToString(LstEmal[0].EmailTemplateID) != Convert.ToString(this.EmailTemplateID.ToString()))
                    {
                        IsDuplicateRecord = IsPopupMessage = true;
                        ltrSuccessfully.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        return;
                    }
                }
                else
                {
                    IsDuplicateRecord = IsPopupMessage = true;
                    ltrSuccessfully.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                    return;

                }
            }
            if (this.EmailTemplateID != Guid.Empty)
            {
                EMailTemplates objUpd = new EMailTemplates();
                EMailTemplates objOldCurr = new EMailTemplates();
                objUpd = EMailTemplatesBLL.GetByPrimaryKey(this.EmailTemplateID);
                objOldCurr = EMailTemplatesBLL.GetByPrimaryKey(this.EmailTemplateID);
                objUpd.CompanyID = clsSession.CompanyID;
                objUpd.PropertyID = clsSession.PropertyID;
                objUpd.Title = txtTitle.Text.Trim();
                objUpd.ActionType_TermID = new Guid(ddlActionType.SelectedValue.ToString());

                if (ddlEmailConfiguration.SelectedIndex != 0)
                    objUpd.EMailConfigID = new Guid(ddlEmailConfiguration.SelectedValue.ToString());
                else
                    objUpd.EMailConfigID = null;

                objUpd.Body = ckBody.Text;
                objUpd.IsActive = true;
                objUpd.UpdatedBy = clsSession.UserID;
                objUpd.UpdatedOn = DateTime.Now.Date;
                EMailTemplatesBLL.Update(objUpd);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldCurr.ToString(), objUpd.ToString(), "mst_EMailTemplates");
                IsPopupMessage = true;
                ltrSuccessfully.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
            }
            else
            {
                EMailTemplates objIns = new EMailTemplates();
                objIns.CompanyID = clsSession.CompanyID;
                objIns.PropertyID = clsSession.PropertyID;
                objIns.Title = objIns.Header = txtTitle.Text.Trim();
                objIns.ActionType_TermID = new Guid(Convert.ToString(ddlActionType.SelectedValue));

                if (ddlEmailConfiguration.SelectedIndex != 0)
                    objIns.EMailConfigID = new Guid(ddlEmailConfiguration.SelectedValue.ToString());
                
                objIns.Body = ckBody.Text;
                objIns.IsActive = true;
                objIns.UpdatedBy = clsSession.UserID;
                objIns.UpdatedOn = DateTime.Now.Date;
                EMailTemplatesBLL.Save(objIns);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objIns.ToString(), objIns.ToString(), "mst_EMailTemplates");
                IsPopupMessage = true;
                ltrSuccessfully.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

            }
            BindGrid();
        }

        private void ClearControl()
        {
            IsDuplicateRecord = false;
            this.EmailTemplateID = Guid.Empty;
            txtTitle.Text = ckBody.Text = "";
            ddlActionType.SelectedValue = ddlEmailConfiguration.SelectedValue =  Guid.Empty.ToString();
        }

        private void ClearSearchControl()
        {
            txtSTitle.Text = "";
        }

        #endregion Private Method

        #region Grid Event
        /// <summary>
        /// Grid Row Data Bound Event
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as GridViewRowEventArgs</param>
        protected void gvEmailTemplateList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                
                //((LinkButton)e.Row.FindControl("lnkDelete")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                //((LinkButton)e.Row.FindControl("lnkDelete")).OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EmailTemplateID")));

                //LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                if (this.UserRights.Substring(2, 1) == "1")
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                else
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                //lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                //lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Label)e.Row.FindControl("lblGvHrdNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                ((Literal)e.Row.FindControl("lblGvHdrEditView")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                ((Literal)e.Row.FindControl("ltrGvHdrAction")).Text = clsCommon.GetGlobalResourceText("EmailTemplate", "ltrGvHdrAction", "Action Type");
                ((Literal)e.Row.FindControl("ltrGvHdrTitleInti")).Text = clsCommon.GetGlobalResourceText("EmailTemplate", "ltrGvHdrTitleInti", "Title");
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }
        }
        /// <summary>
        /// Grid Row Command Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as GridViewCommandEventArgs</param>
        protected void gvEmailTemplateList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("EDITDATA"))
            {
                btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
                mvEmailTemplate.ActiveViewIndex = 1;
                this.EmailTemplateID = new Guid(Convert.ToString(e.CommandArgument));
                EMailTemplates objEmla = new EMailTemplates();
                objEmla = EMailTemplatesBLL.GetByPrimaryKey(this.EmailTemplateID);
                if (objEmla != null)
                {
                    txtTitle.Text = objEmla.Title;
                    if(objEmla.EMailConfigID != null)
                        ddlEmailConfiguration.SelectedIndex = ddlEmailConfiguration.Items.FindByValue(Convert.ToString(objEmla.EMailConfigID)) != null ? ddlEmailConfiguration.Items.IndexOf(ddlEmailConfiguration.Items.FindByValue(Convert.ToString(objEmla.EMailConfigID))) : 0;
                    if (objEmla.ActionType_TermID!= null)
                        ddlActionType.SelectedIndex = ddlActionType.Items.FindByValue(Convert.ToString(objEmla.ActionType_TermID)) != null ? ddlActionType.Items.IndexOf(ddlActionType.Items.FindByValue(Convert.ToString(objEmla.ActionType_TermID))) : 0;
                    ckBody.Text = objEmla.Body;
                }

                BindBreadCrumb();
                UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                uPnlBreadCrumb.Update();
            }
            //else if (e.CommandName.ToUpper().Equals("DELETEDATA"))
            //{
            //    this.EmailTemplateID = new Guid(Convert.ToString(e.CommandArgument));
            //    mpeConfirmDelete.Show();
            //}
        }

        #endregion Grid Event

        #region Button Event
        /// <summary>
        /// Add New Currency Value
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e a EventArgs</param>
        protected void btnAddTopEmailTemplate_Click(object sender, EventArgs e)
        {
            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
            ClearControl();            
            mvEmailTemplate.ActiveViewIndex = 1;
            BindBreadCrumb();
            UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
            uPnlBreadCrumb.Update();
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
                    {
                        //ClearControl(); // Remove clear control after updating b'cas now system will not add Templates, Only update it.
                        BindBreadCrumb();
                        UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
                        uPnlBreadCrumb.Update();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }
        /// <summary>
        /// Cancel Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //ClearControl();
            //mvEmailTemplate.ActiveViewIndex = 0;
            //BindBreadCrumb();
            //UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
            //uPnlBreadCrumb.Update();
        }

        protected void btnBackToList_Click(object sender, EventArgs e)
        {
            ClearControl();
            mvEmailTemplate.ActiveViewIndex = 0;
            BindBreadCrumb();
            UpdatePanel uPnlBreadCrumb = (UpdatePanel)this.Page.Master.FindControl("uPnlBreadCrumb");
            uPnlBreadCrumb.Update();
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
                    EMailTemplates objDelete = new EMailTemplates();
                    objDelete = EMailTemplatesBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));
                    EMailTemplatesBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_EMailTemplates");
                    IsListMessage = true;
                    ltrListMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    ClearControl();
                }
                BindGrid();
                mpeConfirmDelete.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion Button Event
    }
}