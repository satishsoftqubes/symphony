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
    public partial class CtrlEmployeeList : System.Web.UI.UserControl
    {
        #region Variable
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
        public bool IsListMessage = false;

        public Guid EmployeeID
        {
            get
            {
                return ViewState["EmployeeID"] != null ? new Guid(Convert.ToString(ViewState["EmployeeID"])) : Guid.Empty;
            }
            set
            {
                ViewState["EmployeeID"] = value;
            }
        }
        #endregion Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                CheckUserAuthorization();
                clsSession.ToEditItemID = Guid.Empty;
                clsSession.ToEditItemType = string.Empty;
                BindData();
                BindBreadCrumb();
            }
        }

        #endregion Page Load

        #region Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "EMPLOYEESETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddBottomEmployee.Visible = btnAddTopEmployee.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        private void BindData()
        {
            try
            {
                SetPageLabels();
                BindDDL();
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLabels()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("EmployeeList", "lblMainHeader", "EMPLOYEE SETUP");
            litSearchEmployeeListName.Text = clsCommon.GetGlobalResourceText("EmployeeList", "lblSearchEmployeeListName", "Name");
            litSearchEmployeeListDepartment.Text = clsCommon.GetGlobalResourceText("EmployeeList", "lblSearchEmployeeListDepartmentName", "Department");
            litEmployeeList.Text = clsCommon.GetGlobalResourceText("EmployeeList", "lblEmployeeList", "Employee List");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("EmployeeList", "lblHeaderConfirmDeletePopup", "Employee");
            btnAddBottomEmployee.Text = btnAddTopEmployee.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            litSearchLocation.Text = clsCommon.GetGlobalResourceText("EmployeeList", "lblSearchLocation", "City");
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
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblUserSettiongs", "User Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblEmployeeList", "Employee List");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Bind Grid Method
        /// </summary>
        private void BindGrid()
        {
            try
            {
                Guid? DepartmentID;
                string FullName, Location = null;
                if (ddlSearchDepartment.SelectedValue != Guid.Empty.ToString())
                    DepartmentID = new Guid(Convert.ToString(ddlSearchDepartment.SelectedValue));
                else
                    DepartmentID = null;
                if (txtSearchEmployeeName.Text.Trim() != "")
                    FullName = txtSearchEmployeeName.Text.Trim();
                else
                    FullName = null;
                if (txtSearchLocation.Text.Trim() != "")
                    Location = txtSearchLocation.Text.Trim();
                else
                    Location = null;

                DataSet dsEmp = EmployeeBLL.GetAllSearch(null, clsSession.PropertyID, clsSession.CompanyID, DepartmentID, null, FullName, Location);
                gvEmployeeList.DataSource = dsEmp.Tables[0];
                gvEmployeeList.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load All DDL
        /// </summary>
        private void BindDDL()
        {
            try
            {
                string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-");

                Department objDepartment = new Department();
                objDepartment.IsActive = true;
                objDepartment.CompanyID = clsSession.CompanyID;
                objDepartment.PropertyID = clsSession.PropertyID;

                List<Department> lstDepartment = DepartmentBLL.GetAll(objDepartment);
                if (lstDepartment.Count > 0)
                {
                    lstDepartment.Sort((Department d1, Department d2) => d1.DepartmentName.CompareTo(d2.DepartmentName));
                    ddlSearchDepartment.DataSource = lstDepartment;
                    ddlSearchDepartment.DataTextField = "DepartmentName";
                    ddlSearchDepartment.DataValueField = "DepartmentID";
                    ddlSearchDepartment.DataBind();
                    ddlSearchDepartment.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                }
                else
                    ddlSearchDepartment.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// ClearControl Method
        /// </summary>
        private void ClearControl()
        {
            this.EmployeeID = Guid.Empty;
            BindGrid();
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
            ddlSearchDepartment.SelectedIndex = 0;
            txtSearchLocation.Text = txtSearchEmployeeName.Text = "";
        }
        #endregion Method

        #region  Grid Event
        protected void gvEmployeeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    if (this.UserRights.Substring(2, 1) == "1")
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EmployeeID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrName")).Text = clsCommon.GetGlobalResourceText("EmployeeList", "lblGvHdrName", "Name");
                    ((Label)e.Row.FindControl("lblGvHdrEmail")).Text = clsCommon.GetGlobalResourceText("EmployeeList", "lblGvHdrEmail", "Email");
                    ((Label)e.Row.FindControl("lblGvHdrLocation")).Text = clsCommon.GetGlobalResourceText("EmployeeList", "lblGvHdrLocation", "City");
                    ((Label)e.Row.FindControl("lblGvHdrEmployeeNo")).Text = clsCommon.GetGlobalResourceText("EmployeeList", "lblGvHdrEmployeeNo", "Employee No.");
                    ((Label)e.Row.FindControl("lblGvHdrDepartmentName")).Text = clsCommon.GetGlobalResourceText("EmployeeList", "lblGvHdrDepartmentName", "Department");
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

        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                    clsSession.ToEditItemType = "EMPLOYEE";
                    Response.Redirect("~/GUI/Configurations/EmployeeSetup.aspx");
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    this.EmployeeID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvEmployeeList.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event

        #region Control Event

        /// <summary>
        /// Add New Employee
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnAddTopEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/GUI/Configurations/EmployeeSetup.aspx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
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
                gvEmployeeList.PageIndex = 0;
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
        #endregion Control Event

        #region Popup Button Event

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    mpeConfirmDelete.Hide();
                    Employee objDelete = new Employee();
                    objDelete = EmployeeBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    EmployeeBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "hrm_Employee");
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