using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.BackOffice.DTO;
using System.Data;
using SQT.Symphony.BusinessLogic.BackOffice.BLL;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.BackOffice.UIControls.AccountSetup
{
    public partial class CtrlAccountGroup : System.Web.UI.UserControl
    {
        #region Variable & Property
        public bool IsMessage = false;
        public Guid AcctGrpID
        {
            get
            {
                return ViewState["AcctGrpID"] != null ? new Guid(Convert.ToString(ViewState["AcctGrpID"])) : Guid.Empty;
            }
            set
            {
                ViewState["AcctGrpID"] = value;
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
                    Response.Redirect("~/GUI/CommonControls/AccessDenied.aspx");
                CheckUserAuthorization();
                BindData();
                BindBreadCrumb();
            }
        }

        public bool IsPopupMessage = false;
        public bool IsListMessage = false;
        public bool IsDuplicateRecord = false;

        #endregion Form Load

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "AccountGroup.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddBottomGroup .Visible = btnAddTopGroup .Visible = this.UserRights.Substring(1, 1) == "1";
        }
        /// <summary>
        /// Bind Data Here
        /// </summary>
        private void BindData()
        {
            try
            {
                SetPageLabels();
                BindGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            AccountGroup objAcctGrp = new AccountGroup();
            if (!txtGroupCode.Text.Trim().Equals(""))
                objAcctGrp.GroupCode = txtGroupCode.Text.Trim();
            else
                objAcctGrp.GroupCode = null;
            if (!txtGroupName.Text.Trim().Equals(""))
                objAcctGrp.GroupName = txtGroupName.Text.Trim();
            else
                objAcctGrp.GroupName = null;

            objAcctGrp.PropertyID = clsSession.PropertyID;
            objAcctGrp.CompanyID = clsSession.CompanyID;

            DataSet Dst = AccountGroupBLL.GetAllWithDataSet(objAcctGrp);
            DataView Dv = new DataView(Dst.Tables[0]);
            Dv.Sort = "GroupName ASC";
            gvAcctGroupList.DataSource = Dv;
            gvAcctGroupList.DataBind();

        }

        private void BindDDL()
        {
            AccountGroup objToGetList = new AccountGroup();
            //objToGetList.IsDefault = true;
            objToGetList.IsActive = true;
            List<AccountGroup> lstGroup = AccountGroupBLL.GetAll(objToGetList);

            if (lstGroup != null && lstGroup.Count > 0)
            {
                if (this.AcctGrpID != Guid.Empty)
                {
                    var listaccoutFilter = from o in lstGroup
                                           where o.AcctGrpID != AcctGrpID
                                           select o;
                    ddlAccountGroup.DataSource = listaccoutFilter;
                    ddlAccountGroup.DataTextField = "GroupName";
                    ddlAccountGroup.DataValueField = "AcctGrpID";
                    ddlAccountGroup.DataBind();
                    ddlAccountGroup.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                {
                    ddlAccountGroup.DataSource = lstGroup;
                    ddlAccountGroup.DataTextField = "GroupName";
                    ddlAccountGroup.DataValueField = "AcctGrpID";
                    ddlAccountGroup.DataBind();
                    ddlAccountGroup.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }

            }
            else
            {
                ddlAccountGroup.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
        }

        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLabels()
        {
            litMainHeading.Text = clsCommon.GetGlobalResourceText("AccountGroup", "lblMainHeader", "ACCOUNT GROUP");
            litGroupCode.Text = ltrGroupCode.Text = clsCommon.GetGlobalResourceText("AccountGroup", "lblGroupCode", "Group Code");
            litGroupName.Text = ltrGroupName.Text = clsCommon.GetGlobalResourceText("AccountGroup", "lblGroupName", "Group Name");
            //chkIsDefault.Text = clsCommon.GetGlobalResourceText("AccountGroup", "lblDefault", "Default?");
            ltrAcctGroupHeading.Text = clsCommon.GetGlobalResourceText("AccountGroup", "ltrAcctGroupHeading", "ACCOUNT GROUP SETUP");
            litAcctGroupList.Text = clsCommon.GetGlobalResourceText("AccountGroup", "ltrAccountGroup", "Account Group List");
            btnAddTopGroup.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            btnAddBottomGroup.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnSaveAndExit.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSaveAndClose", "Save And Close");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
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
            dr2["NameColumn"] = "Dashboard";// clsCommon.GetGlobalResourceText("BreadCrumb", "lblDashboard", "Dashboard");
            dr2["Link"] = "~/GUI/AccountsHome.aspx";
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Account Group";// clsCommon.GetGlobalResourceText("BreadCrumb", "lblAccountGroupSetup", "Account Group");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void ClearControl()
        {
            IsDuplicateRecord = false;
            this.AcctGrpID = Guid.Empty;
            txtGrpCode.Text = txtGrpName.Text = "";
            ddlAccountGroup.SelectedIndex = 0;
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
            txtGroupCode.Text = txtGroupName.Text = "";
        }
        private void SaveAndUpdateGroup()
        {
            AccountGroup IsAccGrp = new AccountGroup();
            IsAccGrp.GroupCode = txtGrpCode.Text.Trim();
            IsAccGrp.GroupName = txtGrpName.Text.Trim();
            IsAccGrp.IsActive = true;
            IsAccGrp.PropertyID = clsSession.PropertyID;
            IsAccGrp.CompanyID = clsSession.CompanyID;
            List<AccountGroup> LstAccGrp = null;
            LstAccGrp = AccountGroupBLL.GetAll(IsAccGrp);

            if (LstAccGrp.Count > 0)
            {
                if (this.AcctGrpID != Guid.Empty)
                {
                    if (Convert.ToString((LstAccGrp[0].AcctGrpID)) != Convert.ToString(this.AcctGrpID.ToString()))
                    {
                        IsDuplicateRecord = IsPopupMessage = true;
                        ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        mpeAddEditAcctGroup.Show();
                        return;
                    }
                }
                else
                {
                    IsDuplicateRecord = IsPopupMessage = true;
                    ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                    mpeAddEditAcctGroup.Show();
                    return;
                }
            }

            if (this.AcctGrpID != Guid.Empty)
            {
                AccountGroup objUpd = new AccountGroup();
                AccountGroup objOldData = new AccountGroup();
                objUpd = AccountGroupBLL.GetByPrimaryKey(this.AcctGrpID);
                objOldData = AccountGroupBLL.GetByPrimaryKey(this.AcctGrpID);

                objUpd.GroupCode = txtGrpCode.Text.Trim();
                objUpd.GroupName = txtGrpName.Text.Trim();
                objUpd.IsDefault = false;

                if (ddlAccountGroup.SelectedIndex != 0)
                    objUpd.RefAcctGrpID = new Guid(ddlAccountGroup.SelectedValue);
                else
                    objUpd.RefAcctGrpID = null;

                if (txtGrpName.Text.ToUpper().Equals("INCOME"))
                    objUpd.SymphonyGroupID = 1;
                else if (txtGrpName.Text.ToUpper().Equals("EXPENSE"))
                    objUpd.SymphonyGroupID = 2;
                else if (txtGrpName.Text.ToUpper().Equals("ASSETS") || txtGrpName.Text.ToUpper().Equals("ASSET"))
                    objUpd.SymphonyGroupID = 3;
                else if (txtGrpName.Text.ToUpper().Equals("LIABILITY") || txtGrpName.Text.ToUpper().Equals("LIABILITIES"))
                    objUpd.SymphonyGroupID = 4;

                objUpd.UpdatedBy = clsSession.UserID;
                objUpd.UpdatedOn = System.DateTime.Now;
                AccountGroupBLL.Update(objUpd);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldData.ToString(), objUpd.ToString(), "acc_AccountGroup");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
            }
            else
            {
                AccountGroup objIns = new AccountGroup();


                objIns.GroupCode = txtGrpCode.Text.Trim();
                objIns.GroupName = txtGrpName.Text.Trim();
                objIns.IsDefault = false;

                if (txtGrpName.Text.ToUpper().Equals("INCOME"))
                    objIns.SymphonyGroupID = 1;
                else if (txtGrpName.Text.ToUpper().Equals("EXPENSE"))
                    objIns.SymphonyGroupID = 2;
                else if (txtGrpName.Text.ToUpper().Equals("ASSETS") || txtGrpName.Text.ToUpper().Equals("ASSET"))
                    objIns.SymphonyGroupID = 3;
                else if (txtGrpName.Text.ToUpper().Equals("LIABILITY") || txtGrpName.Text.ToUpper().Equals("LIABILITIES"))
                    objIns.SymphonyGroupID = 4;

                if (ddlAccountGroup.SelectedIndex != 0)
                    objIns.RefAcctGrpID = new Guid(ddlAccountGroup.SelectedValue);
                else
                    objIns.RefAcctGrpID = null;

                objIns.PropertyID = clsSession.PropertyID;
                objIns.CompanyID = clsSession.CompanyID;
                objIns.IsSynch = false;
                objIns.UpdatedOn = DateTime.Now;
                objIns.UpdatedBy = clsSession.UserID;
                objIns.IsActive = true;

                AccountGroupBLL.Save(objIns);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objIns.ToString(), objIns.ToString(), "acc_AccountGroup");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
            }
            BindGrid();

        }

        #endregion Private Method

        #region Grid Event

        protected void gvAcctGroupList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");

                if (this.UserRights.Substring(2, 1) == "1")
                    lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                else
                    lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Literal)e.Row.FindControl("lblGvHdrEditView")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                ((Literal)e.Row.FindControl("litAcctGroupCode")).Text = clsCommon.GetGlobalResourceText("AccountGroup", "ltrGroupCode", "Group Code");
                ((Literal)e.Row.FindControl("litAcctGroupName")).Text = clsCommon.GetGlobalResourceText("AccountGroup", "ltrGroupName", "Group Name");
                //((Literal)e.Row.FindControl("litDefault")).Text = clsCommon.GetGlobalResourceText("AccountGroup", "ltrDefault", "Default?");
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }
        }

        protected void gvAcctGroupList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("EDITDATA"))
            {
                btnSave.Visible = this.UserRights.Substring(2, 1) == "1";
                ClearControl();
                mpeAddEditAcctGroup.Show();
                this.AcctGrpID = new Guid(Convert.ToString(e.CommandArgument));
                AccountGroup objAccGrp = new AccountGroup();
                objAccGrp = AccountGroupBLL.GetByPrimaryKey(this.AcctGrpID);
                if (objAccGrp != null)
                {
                    txtGrpCode.Text = Convert.ToString(objAccGrp.GroupCode);
                    txtGrpName.Text = Convert.ToString(objAccGrp.GroupName);
                    BindDDL();
                    ddlAccountGroup.SelectedIndex = ddlAccountGroup.Items.FindByValue(Convert.ToString(objAccGrp.RefAcctGrpID)) != null ? ddlAccountGroup.Items.IndexOf(ddlAccountGroup.Items.FindByValue(Convert.ToString(objAccGrp.RefAcctGrpID))) : 0;
                }
            }
            else if (e.CommandName.ToUpper().Equals("DELETEDATA"))
            {
                ClearControl();
                this.AcctGrpID = new Guid(Convert.ToString(e.CommandArgument));
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
        protected void btnAddTopGroup_Click(object sender, EventArgs e)
        {
            btnSave.Visible = this.UserRights.Substring(1, 1) == "1";
            ClearSearchControl();
            ClearControl();
            BindDDL();
            ddlAccountGroup.SelectedIndex = 0;
            mpeAddEditAcctGroup.Show();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateGroup();
                    if (!IsDuplicateRecord)
                        ClearControl();
                    mpeAddEditAcctGroup.Show();
                }
                catch (Exception ex)
                {
                    mpeAddEditAcctGroup.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnSaveAndExit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateGroup();
                    if (!IsDuplicateRecord)
                    {
                        mpeAddEditAcctGroup.Hide();
                        IsListMessage = true;

                        if (this.AcctGrpID != Guid.Empty)
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                        else
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                        ClearControl();
                    }
                }
                catch (Exception ex)
                {
                    mpeAddEditAcctGroup.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.AcctGrpID != Guid.Empty)
                {
                    mpeAddEditAcctGroup.Hide();
                    AccountGroup objDelete = new AccountGroup();
                    objDelete = AccountGroupBLL.GetByPrimaryKey(this.AcctGrpID);

                    AccountGroupBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "acc_AccountGroup");
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

        protected void btnCancelDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.AcctGrpID != Guid.Empty)
                {
                    mpeAddEditAcctGroup.Hide();
                    ClearControl();
                }
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
        #endregion Button Event
    }
}