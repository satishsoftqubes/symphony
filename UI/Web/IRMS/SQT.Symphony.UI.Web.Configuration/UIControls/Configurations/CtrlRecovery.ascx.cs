using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Data;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlRecovery : System.Web.UI.UserControl
    {

        #region Variable and Property

        public bool IsListMessage = false;

        public Guid RecoveryID
        {
            get
            {
                return ViewState["RecoveryID"] != null ? new Guid(Convert.ToString(ViewState["RecoveryID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RecoveryID"] = value;
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
        #endregion Variable and Property

        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

            if (!IsPostBack)
            {
                CheckUserAuthorization();
                SetPageLableText();
                BindGridRecovery();
                BinddllCategory();
                BinddllAccounts();
                BindBreadCrumb();
                mvRecovery.ActiveViewIndex = 0;
            }

        }

        #region Button Event
        protected void btnTopAdd_Click(object sender, EventArgs e)
        {
            mvRecovery.ActiveViewIndex = 1;
            ClearControl();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (this.RecoveryID != Guid.Empty)
                    {
                        Recovery objUpd = new Recovery();

                        objUpd = RecoveryBLL.GetByPrimaryKey(this.RecoveryID);

                        objUpd.CompanyID = clsSession.CompanyID;
                        objUpd.PropertyID = clsSession.PropertyID;
                        objUpd.Title = txtTitle.Text.Trim();
                        objUpd.Amount = Convert.ToDecimal(txtAmount.Text.Trim());
                        objUpd.Description = Convert.ToString(txtDescription.Text.Trim());

                        if (ddlCategory.SelectedIndex != 0)
                            objUpd.CategoryID = new Guid(ddlCategory.SelectedValue.ToString());
                        else
                            objUpd.CategoryID = null;
                        if (ddlAccSelection.SelectedIndex != 0)
                            objUpd.AcctID = new Guid(ddlAccSelection.SelectedValue.ToString());
                        else
                            objUpd.AcctID = null;
                        objUpd.IsActive = true;

                        objUpd.UpdatedBy = clsSession.UserID;
                        objUpd.UpdatedOn = DateTime.Now.Date;
                        //EMailTemplatesBLL.Update(objUpd);
                        // ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldCurr.ToString(), objUpd.ToString(), "mst_EMailTemplates");
                        RecoveryBLL.Update(objUpd);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", null, objUpd.ToString(), "mst_Recovery");
                        IsListMessage = true;
                        ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                    }
                    else
                    {
                        Recovery objIns = new Recovery();
                        objIns.CompanyID = clsSession.CompanyID;
                        objIns.PropertyID = clsSession.PropertyID;
                        objIns.Title = txtTitle.Text.Trim();
                        objIns.Amount = Convert.ToDecimal(txtAmount.Text.Trim());
                        objIns.Description = Convert.ToString(txtDescription.Text.Trim());
                        if (ddlCategory.SelectedIndex != 0)
                            objIns.CategoryID = new Guid(ddlCategory.SelectedValue.ToString());
                        else
                            objIns.CategoryID = null;
                        if (ddlAccSelection.SelectedIndex != 0)
                            objIns.AcctID = new Guid(ddlAccSelection.SelectedValue.ToString());
                        else
                            objIns.AcctID  = null;

                        objIns.IsActive = true;
                        objIns.CreatedBy = clsSession.UserID;
                        objIns.CreatedOn = DateTime.Now.Date;
                        RecoveryBLL.Save(objIns);
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objIns.ToString(), objIns.ToString(), "mst_Recovery");
                        IsListMessage = true;
                        ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                    }
                    BindGridRecovery();
                    ClearControl();
                    mvRecovery.ActiveViewIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {

            mvRecovery.ActiveViewIndex = 0;
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindGridRecovery();
        }

        protected void imgbtnClearSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearControl();
                BindGridRecovery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Grid Event

        protected void gvRecovery_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                    //lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    //if (this.UserRights.Substring(2, 1) == "1")
                    //    lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    //else
                    //    lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RecoveryID")));

                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrTitle")).Text = clsCommon.GetGlobalResourceText("Recovery", "lblGvHdrTitle", "Item");
                    ((Label)e.Row.FindControl("lblGvHdrAmount")).Text = clsCommon.GetGlobalResourceText("Recovery", "lblGvHdrAmount", "Amount");
                    // ((Label)e.Row.FindControl("lblGvHdrDescription")).Text = clsCommon.GetGlobalResourceText("Recovery", "lblGvHdrDescription", "Description");
                    ((Label)e.Row.FindControl("lblGvHdrAction")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvRecovery_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    mvRecovery.ActiveViewIndex = 1;

                    this.RecoveryID = new Guid(Convert.ToString(e.CommandArgument));
                    Recovery objRecovery = new Recovery();
                    objRecovery = RecoveryBLL.GetByPrimaryKey(this.RecoveryID);
                    if (objRecovery != null)
                    {
                        txtTitle.Text = objRecovery.Title;

                        if (Convert.ToString(objRecovery.Amount) != "" && Convert.ToString(objRecovery.Amount) != string.Empty)
                            txtAmount.Text = Convert.ToString(objRecovery.Amount.ToString().Substring(0, objRecovery.Amount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                        else
                            txtAmount.Text = "";

                        ddlCategory.SelectedIndex = ddlCategory.Items.FindByValue(Convert.ToString(objRecovery.CategoryID)) != null ? ddlCategory.Items.IndexOf(ddlCategory.Items.FindByValue(Convert.ToString(objRecovery.CategoryID))) : 0;
                        ddlAccSelection.SelectedIndex = ddlAccSelection.Items.FindByValue(Convert.ToString(objRecovery.AcctID)) != null ? ddlAccSelection.Items.IndexOf(ddlAccSelection.Items.FindByValue(Convert.ToString(objRecovery.AcctID))) : 0;


                        txtDescription.Text = Convert.ToString(objRecovery.Description);

                    }

                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    this.RecoveryID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvRecovery_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRecoveryList.PageIndex = e.NewPageIndex;
            BindGridRecovery();
        }

        #endregion

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "UNITTYPESETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        private void SetPageLableText()
        {
            revAmount.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            revAmount.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");
            litMainHeaderRecovery.Text = clsCommon.GetGlobalResourceText("Recovery", "litMainHeaderTranscript", "Recovery");
            litSearchTitle.Text = clsCommon.GetGlobalResourceText("Recovery", "litSearchTitle", "Item");
            litTitle.Text = clsCommon.GetGlobalResourceText("Recovery", "litTitle", "Item");
            litAmount.Text = clsCommon.GetGlobalResourceText("Recovery", "litAmount", "Amount");
            litDescription.Text = clsCommon.GetGlobalResourceText("Recovery", "litContent", "Description");
            btnButtomAdd.Text = btnTopAdd.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
        
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnNo.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            litRecovery.Text = clsCommon.GetGlobalResourceText("Recovery", "litRecovery", "Recovery List");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            litCategory.Text = clsCommon.GetGlobalResourceText("Recovery", "litCategory", "Category");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("Recovery", "litMainHeaderTranscript", "Recovery");
            litAccount.Text = clsCommon.GetGlobalResourceText("Recovery", "litAccount", "Account");
        }

        private void BindGridRecovery()
        {
            try
            {
                string Title = null;

                if (txtSearchTitle.Text.Trim() != string.Empty)
                    Title = Convert.ToString(txtSearchTitle.Text.Trim());
                else
                    Title = null;

                List<Recovery> litRecovery = RecoveryBLL.SearchRecoveryData(clsSession.PropertyID, Title);
                gvRecoveryList.DataSource = litRecovery;
                gvRecoveryList.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearControl()
        {
            txtAmount.Text = "";
            txtDescription.Text = "";
            txtSearchTitle.Text = "";
            txtTitle.Text = "";
            ddlCategory.SelectedIndex = 0;
            ddlAccSelection.SelectedIndex = 0;
            this.RecoveryID = Guid.Empty;
        }


        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            DataRow dr2 = dt.NewRow();
            dr2["NameColumn"] = "Uniworld E-City";
            dr2["Link"] = "";
            dt.Rows.Add(dr2);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Policy & Configuration";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Recovery";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }
        #endregion

        private void BinddllCategory()
        {
            //List<ProjectTerm> lstPostingFeq = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "RECOVERY ITEM");
            //if (lstPostingFeq.Count != 0)
            //{
            //    ddlCategory.DataSource = lstPostingFeq;
            //    ddlCategory.DataTextField = "DisplayTerm";
            //    ddlCategory.DataValueField = "TermID";
            //    ddlCategory.DataBind();
            //    ddlCategory.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));

            //    ddlCategory.DataSource = lstPostingFeq;
            //    ddlCategory.DataTextField = "DisplayTerm";
            //    ddlCategory.DataValueField = "TermID";
            //    ddlCategory.DataBind();
            //    ddlCategory.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-"), Guid.Empty.ToString()));
            //}
            //else
            //{
            //    ddlCategory.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
            //    ddlCategory.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-"), Guid.Empty.ToString()));
            //}


            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
            ProjectTerm Prj = new ProjectTerm();
            Prj.Category = "RECOVERY ITEM";
            Prj.CompanyID = clsSession.CompanyID;
            Prj.PropertyID = clsSession.PropertyID;
            Prj.IsActive = true;
            List<ProjectTerm> Lst = ProjectTermBLL.GetAll(Prj);
            if (Lst.Count > 0)
            {
                ddlCategory.DataSource = Lst;
                ddlCategory.DataTextField = "DisplayTerm";
                ddlCategory.DataValueField = "TermID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlCategory.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

        }

        private void BinddllAccounts()
        {
            
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
            Account objAccount = new Account();
            objAccount.CompanyID = clsSession.CompanyID;
            objAccount.PropertyID = clsSession.PropertyID;
            objAccount.SymphonyAcctID = 1;

            //Prj.Category = "RECOVERY ITEM";
            //Prj.CompanyID = clsSession.CompanyID;
            //Prj.PropertyID = clsSession.PropertyID;
            //Prj.IsActive = true;
            List<Account> LstAccount = AccountBLL.GetAll(objAccount);
            if (LstAccount.Count > 0)
            {
                ddlAccSelection .DataSource = LstAccount;
                ddlAccSelection.DataTextField = "AcctName";
                ddlAccSelection.DataValueField = "AcctID";
                ddlAccSelection.DataBind();
                ddlAccSelection.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlAccSelection.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

        }


        #region Popup Button Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    mpeConfirmDelete.Hide();
                    Recovery objDelete = new Recovery();
                    objDelete = RecoveryBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    RecoveryBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_Recovery");
                    IsListMessage = true;
                    ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    ClearControl();
                }
                BindGridRecovery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControl();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion
    }
}