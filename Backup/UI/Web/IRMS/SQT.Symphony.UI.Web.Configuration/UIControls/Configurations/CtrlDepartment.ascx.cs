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
    public partial class CtrlDepartment : System.Web.UI.UserControl
    {
        #region Property and Variables
        // property to save companyid;
        public Guid DepartmentID
        {
            get
            {
                return ViewState["DepartmentID"] != null ? new Guid(Convert.ToString(ViewState["DepartmentID"])) : Guid.Empty;
            }
            set
            {
                ViewState["DepartmentID"] = value;
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

        public byte[] UpdateLog
        {
            get
            {
                return ViewState["UpdateLog"] != null ? (byte[])ViewState["UpdateLog"] : null;
            }
            set
            {
                ViewState["UpdateLog"] = value;
            }
        }

        public bool IsPopupMessage = false;
        public bool IsListMessage = false;
        public bool IsDuplicateRecord = false;

        #endregion Property and Variables

        #region Form Load
        /// <summary>
        /// Form Load Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

            if (!IsPostBack)
            {
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
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "DEPARTMENT.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddBottomDepartment.Visible = btnAddTopDepartment.Visible = this.UserRights.Substring(1, 1) == "1";
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
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblUserSettiongs", "User Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblDepartment", "Department");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Bind Grid Information
        /// </summary>
        private void BindGrid()
        {
            string DepartmentName = null;

            if (txtSDepartmentName.Text.Trim() != "")
                DepartmentName = txtSDepartmentName.Text.Trim();

            DataSet dsSearchDepartment = DepartmentBLL.SearchDepartmentData(null, clsSession.PropertyID, clsSession.CompanyID, DepartmentName);

            gvDepartmentList.DataSource = dsSearchDepartment.Tables[0];
            gvDepartmentList.DataBind();
        }
        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLables()
        {
            ltrMainHeader.Text = clsCommon.GetGlobalResourceText("Department", "lblMainHeader", "DEPARTMENT");
            ltrSearchDepartmentName.Text = clsCommon.GetGlobalResourceText("Department", "lblDepartmentName", "Department Name");
            btnAddTopDepartment.Text = btnAddBottomDepartment.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            ltrDepartmentList.Text = clsCommon.GetGlobalResourceText("Department", "lblDepartmentList", "Department List");
            ltrHeaderPopupDepartment.Text = clsCommon.GetGlobalResourceText("Department", "lblHeaderPopupDepartment", "Department");
            ltrDepartmentName.Text = clsCommon.GetGlobalResourceText("Department", "lblDepartmentName", "Department Name");
            ltrDepartmentCode.Text = clsCommon.GetGlobalResourceText("Department", "lblDepartmentCode", "Department Code");
            btnSaveAndClose.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSaveAndClose", "Save And Close");
            btnSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            btnCancelDelete.Text = btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("Department", "lblHeaderConfirmDeletePopup", "Department");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");             
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
            litGeneralMandartoryFiledMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblGeneralMandartoryFiledMessage", "All Bold Fields are Mandatory");
        }
        /// <summary>
        /// Insert and Update Department
        /// </summary>
        private void SaveAndUpdateDepartment()
        {
            Department IsDeptDup = new Department();
            IsDeptDup.DepartmentName = txtDepartmentName.Text.Trim();
            IsDeptDup.IsActive = true;
            IsDeptDup.PropertyID = clsSession.PropertyID;
            List<Department> LstDupDept = null;
            LstDupDept = DepartmentBLL.GetAll(IsDeptDup);

            if (LstDupDept.Count > 0)
            {
                if (this.DepartmentID != Guid.Empty)
                {
                    if (Convert.ToString((LstDupDept[0].DepartmentID)) != Convert.ToString(this.DepartmentID.ToString()))
                    {
                        IsDuplicateRecord = IsPopupMessage = true;
                        ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                        mpeAddEditDepartment.Show();
                        return;
                    }
                }
                else
                {
                    IsDuplicateRecord = IsPopupMessage = true;
                    ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgSameRecordAlreadyExist", "Recored Already Exist.");
                    mpeAddEditDepartment.Show();
                    return;
                }
            }

            if (this.DepartmentID != Guid.Empty)
            {
                Department objUpd = new Department();
                Department objOldDeptData = new Department();
                objUpd = DepartmentBLL.GetByPrimaryKey(this.DepartmentID);
                //objUpd.Updatelog = this.UpdateLog;
                objOldDeptData = DepartmentBLL.GetByPrimaryKey(this.DepartmentID);


                objUpd.DepartmentName = txtDepartmentName.Text.Trim();
                objUpd.DepartmentCode = txtDepartmentCode.Text.Trim();

                DepartmentBLL.Update(objUpd);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldDeptData.ToString(), objUpd.ToString(), "mst_Department");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
            }
            else
            {
                Department objIns = new Department();

                objIns.CompanyID = clsSession.CompanyID;
                objIns.PropertyID = clsSession.PropertyID;
                objIns.DepartmentName = txtDepartmentName.Text.Trim();
                objIns.DepartmentCode = txtDepartmentCode.Text.Trim();
                objIns.IsActive = true;
                objIns.CreatedOn = DateTime.Now;
                objIns.CraetedBy = clsSession.UserID;
                objIns.IsDefault = false;
                objIns.IsSynch = false;

                DepartmentBLL.Save(objIns);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objIns.ToString(), objIns.ToString(), "mst_Department");
                IsPopupMessage = true;
                ltrMsgPopup.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
            }
            BindGrid();

        }
        /// <summary>
        /// Clear Control Method
        /// </summary>
        private void ClearControl()
        {
            IsDuplicateRecord = false;
            this.DepartmentID = Guid.Empty;
            txtDepartmentName.Text = txtDepartmentCode.Text = "";
            BindBreadCrumb();
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
            txtSDepartmentName.Text = "";
        }
        #endregion Private Method

        #region Grid Event
        /// <summary>
        /// Grid Row Command Evnet
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">e as GridViewCommandEventArgs</param>
        protected void gvDepartmentList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper().Equals("EDITDATA"))
            {
                btnSave.Visible = btnSaveAndClose.Visible = this.UserRights.Substring(2, 1) == "1";
                ClearControl();
                mpeAddEditDepartment.Show();
                this.DepartmentID = new Guid(Convert.ToString(e.CommandArgument));
                Department objDepartment = new Department();
                objDepartment = DepartmentBLL.GetByPrimaryKey(this.DepartmentID);
                if (objDepartment != null)
                {
                    //this.UpdateLog = objDepartment.Updatelog;
                    txtDepartmentName.Text = objDepartment.DepartmentName;
                    txtDepartmentCode.Text = objDepartment.DepartmentCode;
                }
            }
            else if (e.CommandName.ToUpper().Equals("DELETEDATA"))
            {
                ClearControl();
                this.DepartmentID = new Guid(Convert.ToString(e.CommandArgument));
                mpeConfirmDelete.Show();
            }
        }

        /// <summary>
        /// Grid Row Data Command Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as GridViewRowEventArgs</param>
        protected void gvDepartmentList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                if (this.UserRights.Substring(2, 1) == "1")
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                else
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");


                lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DepartmentID")));
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                ((Label)e.Row.FindControl("lblGvHdrDepartmentName")).Text = clsCommon.GetGlobalResourceText("Department", "lblGvHdrDepartmentName", "Department Name");
                ((Label)e.Row.FindControl("lblGvHdrDepartmentCode")).Text = clsCommon.GetGlobalResourceText("Department", "lblGvHdrDepartmentCode", "Department Code");
                ((Label)e.Row.FindControl("lblGvHdrAction")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                ((Label)e.Row.FindControl("lblGvHrdNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }
        }

        /// <summary>
        /// Paging Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvDepartmentList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDepartmentList.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        #endregion Grid Event

        #region Button Event
        /// <summary>
        /// Add New Department
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnAddTopDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Visible = btnSaveAndClose.Visible = this.UserRights.Substring(1, 1) == "1";
                ClearControl();
                mpeAddEditDepartment.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Save And Update Department
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateDepartment();
                    if (!IsDuplicateRecord)
                        ClearControl();
                    mpeAddEditDepartment.Show();
                }
                catch (Exception ex)
                {
                    mpeAddEditDepartment.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// Save And Update Department with Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveAndUpdateDepartment();
                    if (!IsDuplicateRecord)
                    {
                        mpeAddEditDepartment.Hide();
                        IsListMessage = true;

                        if (this.DepartmentID != Guid.Empty)
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
                        else
                            ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                        ClearControl();
                    }
                }
                catch (Exception ex)
                {
                    mpeAddEditDepartment.Hide();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                gvDepartmentList.PageIndex = 0;
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

        #region Popup Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    mpeAddEditDepartment.Hide();
                    Department objDelete = new Department();
                    objDelete = DepartmentBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    DepartmentBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_Department");
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
        #endregion
    }
}