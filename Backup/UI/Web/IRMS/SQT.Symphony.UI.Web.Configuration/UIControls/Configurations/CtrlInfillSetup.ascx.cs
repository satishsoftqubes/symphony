using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlInfillSetup : System.Web.UI.UserControl
    {
        #region Property and Variables

        /// <summary>
        /// Get or Set TermID
        /// </summary>
        public Guid TermID
        {
            get
            {
                return ViewState["TermID"] != null ? new Guid(Convert.ToString(ViewState["TermID"])) : Guid.Empty;
            }
            set
            {
                ViewState["TermID"] = value;
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
        public bool Message = false;
        public bool ListMessage = false;
        public bool IsDuplicateRecord = false;
        public int RowCount = 0;

        #endregion Property and Variables

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
                LoadDefaultData();
                BindBreadCrumb();
            }
            
        }
        #endregion Form Load

        #region Private Method
        /// <summary>
        /// Check Authentication
        /// </summary>
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "INFILLSETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");
            btnAddTopInFill.Visible = btnAddBottomInFill.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        /// <summary>
        /// Load Default Data Here
        /// </summary>
        private void LoadDefaultData()
        {
            try
            {
                SetPageLables();
                BindLabel();
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
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
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblGeneralSettings", "General Settings");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblInfillSetup", "Infill Setup") ;
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Clear Control Value
        /// </summary>
        private void ClearControl()
        {
            this.TermID = Guid.Empty;
            ddlLabelName.SelectedIndex = 0;
            txtInfill.Text = txtInfillCode.Text = "";
            txtForeColor.Text = txtBackColor.Text = "FFFFFF";
        }
        /// <summary>
        /// Bind Label Information
        /// </summary>
        private void BindLabel()
        {
            ddlLabel.Items.Clear();
            ddlLabelName.Items.Clear();
            DataSet ds = null;
            ds = ProjectTermBLL.GetDistinctCategory(clsSession.CompanyID, clsSession.PropertyID);
            if (ds.Tables[0].Rows.Count != 0)
            {
                ddlLabel.DataSource = ds.Tables[0];
                ddlLabel.DataTextField = "Category";
                ddlLabel.DataValueField = "Category";
                ddlLabel.DataBind();
                ddlLabel.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-"), Guid.Empty.ToString()));

                ddlLabelName.DataSource = ds.Tables[0];
                ddlLabelName.DataTextField = "Category";
                ddlLabelName.DataValueField = "Category";
                ddlLabelName.DataBind();
                ddlLabelName.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
            }
            else
            {
                ddlLabel.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-"), Guid.Empty.ToString()));
                ddlLabelName.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
            }
        }
        /// <summary>
        /// Bind Data Here
        /// </summary>
        private void BindGrid()
        {
            ProjectTerm GetPrj = new ProjectTerm();
            if (ddlLabel.SelectedValue != Guid.Empty.ToString())
                GetPrj.Category = ddlLabel.SelectedValue.ToString().Trim();
            else
                GetPrj.Category = null;
            GetPrj.CompanyID = clsSession.CompanyID;
            GetPrj.PropertyID = clsSession.PropertyID;
            GetPrj.IsActive = true;
            List<ProjectTerm> LstPrj = ProjectTermBLL.GetAll(GetPrj);
            RowCount = LstPrj.Count;
            gvInfillList.DataSource = LstPrj;
            gvInfillList.DataBind();
        }
        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            //Button Declaraction
            btnAddBottomInFill.Text = clsCommon.GetGlobalResourceText("InfillSetup", "btnAddBottomDenomination", "Add New");
            btnAddTopInFill.Text = clsCommon.GetGlobalResourceText("InfillSetup", "btnAddTopDenomination", "Add New");
           
            //Search Criate 
            ltrMainHeading.Text = clsCommon.GetGlobalResourceText("InfillSetup", "ltrMainHeading", "INFILL SETUP");
            ltrName.Text = clsCommon.GetGlobalResourceText("InfillSetup", "ltrName", "Label Name");

            //Infill Model Popup 
            ltrInfillHeading.Text = clsCommon.GetGlobalResourceText("InfillSetup", "ltrInfillHeading", "Infill Setup");
            ltrLabelName.Text = clsCommon.GetGlobalResourceText("InfillSetup", "ltrLabelName", "Label Name");
            ltrInfillName.Text = clsCommon.GetGlobalResourceText("InfillSetup", "ltrInfillName", "Infill Name");
            ltrInfillCode.Text = clsCommon.GetGlobalResourceText("InfillSetup", "ltrInfillCode", "Infill Code");
            ltrFontColor.Text = clsCommon.GetGlobalResourceText("InfillSetup", "ltrFontColor", "Font Color");
            ltrBackgroundColor.Text = clsCommon.GetGlobalResourceText("InfillSetup", "ltrBackgroundColor", "BG. Color");
            btnSave.Text = clsCommon.GetGlobalResourceText("InfillSetup", "btnSave", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("InfillSetup", "btnCancel", "Cancel");
            btnSaveAndExit.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSaveAndClose", "Save And Close");

            //Delete Infill Model Popup
            litInFillDataHeader.Text = clsCommon.GetGlobalResourceText("InfillSetup", "ltrMainHeading", "INFILL SETUP");
            litInFillDataMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnNo.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");

            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
        }
        /// <summary>
        /// Insert and Update Department
        /// </summary>
        private void SaveAndUpdateInFillData()
        {
            ProjectTerm IInfillDup = new ProjectTerm();
            IInfillDup.DisplayTerm = txtInfill.Text.Trim();
            IInfillDup.IsActive = true;
            IInfillDup.PropertyID = clsSession.PropertyID;
            IInfillDup.Category = Convert.ToString(ddlLabelName.SelectedValue);

            List<ProjectTerm> LstDupInfill = null;
            LstDupInfill = ProjectTermBLL.GetAll(IInfillDup);

            if (LstDupInfill.Count > 0)
            {
                if (this.TermID!= Guid.Empty)
                {
                    if (Convert.ToString((LstDupInfill[0].TermID)) != Convert.ToString(this.TermID.ToString()))
                    {
                        IsDuplicateRecord = Message = true;
                        ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        InfillData.Show();
                        return;
                    }
                }
                else
                {
                    IsDuplicateRecord = Message = true;
                    ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                    InfillData.Show();
                    return;
                }
            }

            if (this.TermID != Guid.Empty)
            {
                ProjectTerm objUpd = new ProjectTerm();
                ProjectTerm objOld = new ProjectTerm();
                objUpd = ProjectTermBLL.GetByPrimaryKey(this.TermID);
                //objUpd.Updatelog = this.UpdateLog;
                objOld = ProjectTermBLL.GetByPrimaryKey(this.TermID);
                objUpd.DisplayTerm  = txtInfill.Text.Trim();
                objUpd.TermCode = txtInfillCode.Text.Trim();
                objUpd.Category= ddlLabelName.Text.Trim();
                objUpd.BackColor = txtBackColor.Text.Trim();
                objUpd.ForeColor = txtForeColor.Text.Trim();

                ProjectTermBLL.Update(objUpd);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOld.ToString(), objUpd.ToString(), "mst_ProjectTerm");
                Message = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
            }
            else
            {
                ProjectTerm objIns = new ProjectTerm();

                objIns.CompanyID = clsSession.CompanyID;
                objIns.PropertyID = clsSession.PropertyID;
                objIns.DisplayTerm = txtInfill.Text.Trim();
                objIns.Term = txtInfill.Text.Trim();
                objIns.TermCode = txtInfillCode.Text.Trim();
                objIns.Category = ddlLabelName.Text.Trim();
                objIns.BackColor = txtBackColor.Text.Trim();
                objIns.ForeColor = txtForeColor.Text.Trim();
                objIns.IsDefault = false;
                objIns.IsActive = true;
                objIns.LastUpdatedOn = DateTime.Now;
                objIns.LastUpdatedBy = clsSession.UserID;
                objIns.IsSynch = false;

                ProjectTermBLL.Save(objIns);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objIns.ToString(), objIns.ToString(), "mst_ProjectTerm");
                Message = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
            }
            BindGrid();

        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
            ddlLabel.SelectedIndex = 0;
        }
        #endregion Private Method

        #region Grid Event
        /// <summary>
        /// Grid Data Row Command
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as GridViewCommandEventArgs</param>
        protected void gvInfillList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("EDITDATA"))
            {
                btnSave.Visible = btnSaveAndExit.Visible = this.UserRights.Substring(2, 1) == "1";
                ClearControl();
                InfillData.Show();
                this.TermID = new Guid(Convert.ToString(e.CommandArgument));
                ProjectTerm objTerm = new ProjectTerm();
                objTerm = ProjectTermBLL.GetByPrimaryKey(this.TermID);
                if (objTerm != null)
                {
                    ddlLabelName.SelectedValue = objTerm.Category.Trim();
                    txtInfill.Text = objTerm.DisplayTerm.Trim();
                    txtInfillCode.Text = objTerm.TermCode.Trim();
                    //txtBackColor.Text = objTerm.BackColor.Trim();
                    //txtForeColor.Text = objTerm.ForeColor.Trim();
                }
                
            }
            else if (e.CommandName.Equals("DELETEDATA"))
            {
                this.TermID = new Guid(e.CommandArgument.ToString());
                DeleteInFillData.Show();
            }
        }
        /// <summary>
        /// Grid Row Data Bound Event
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as GridViewRowEventArgs</param>
        
        protected void gvInfillList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Literal)e.Row.FindControl("litGvrNo")).Text = clsCommon.GetGlobalResourceText("InfillSetup", "litGvrNo", "No.");
                ((Literal)e.Row.FindControl("ltrGvrLabelName")).Text = clsCommon.GetGlobalResourceText("InfillSetup", "ltrGvrInfillName", "Infill Name");
                ((Literal)e.Row.FindControl("ltrGvrInfillName")).Text = clsCommon.GetGlobalResourceText("InfillSetup", "ltrGvrLabelName", "Label Name");
                ((Literal)e.Row.FindControl("litGvfViewDelete")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                

                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                
                if (this.UserRights.Substring(2, 1) == "1")
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                else
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                if (Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsDefault")) == false)
                {
                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    ((LinkButton)e.Row.FindControl("lnkDelete")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                }
                else
                    lnkDelete.Visible = false;
                ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                ((LinkButton)e.Row.FindControl("lnkDelete")).OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TermID")));              
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("InfillSetup", "lblNoRecordFound", "No any record found.");
            }
        }
        /// <summary>
        /// Page Index Changing Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvInfillList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInfillList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        #endregion Grid Event

        #region Add New Term Button Event
        /// <summary>
        /// Top Add New InFill Value
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e a EventArgs</param>
        protected void btnAddTopInFill_Click(object sender, EventArgs e)
        {
            btnSave.Visible = btnSaveAndExit.Visible = this.UserRights.Substring(1, 1) == "1";
            ClearControl();
            InfillData.Show();
        }

        #endregion Add New Term Button Event

        #region Infill Save Button 
        /// <summary>
        /// Save Infill Data Here
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateInFillData();
                    if (!IsDuplicateRecord)
                        ClearControl();
                    InfillData.Show();
                }
                catch (Exception ex)
                {
                    InfillData.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        /// <summary>
        /// Save And Exit Infill Data Here
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e a EventArgs</param>
        protected void btnSaveAndExit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateInFillData();
                    if (!IsDuplicateRecord)
                    {
                        InfillData.Hide();
                        ListMessage = true;

                        if (this.TermID != Guid.Empty)
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                        else
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                        ClearControl();
                    }
                }
                catch (Exception ex)
                {
                    InfillData.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        /// <summary>
        /// Clear or Hide Infill Control
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Infill Save Button

        #region Search Button Event
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

        /// <summary>
        /// Clear Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #endregion Search Button Event

        #region Delete Popup Button Event
        /// <summary>
        /// Yes Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnInFillData.Value) != string.Empty)
                {
                    DeleteInFillData.Hide();
                    ProjectTerm objDelete = new ProjectTerm();
                    objDelete = ProjectTermBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnInFillData.Value)));

                    ProjectTermBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_ProjectTerm");
                    ListMessage = true;
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
        

        #endregion Delete Popup Button Event

    }
}