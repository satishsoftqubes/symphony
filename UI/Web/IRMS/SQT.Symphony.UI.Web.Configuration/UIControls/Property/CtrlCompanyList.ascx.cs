using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Data;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Property
{
    public partial class CtrlCompanyList : System.Web.UI.UserControl
    {
        #region Variable

        public bool IsListMessage = false;

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
        #endregion Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.UserType.ToUpper() == "ADMINISTRATOR")
                {
                    clsSession.ToEditItemType = "COMPANY";
                    clsSession.ToEditItemID = clsSession.CompanyID;
                    Response.Redirect("~/GUI/Property/CompanySetup.aspx");
                }
                else if (clsSession.UserType.ToUpper() == "SUPERADMIN")
                {
                    clsSession.ToEditItemID = Guid.Empty;
                    clsSession.ToEditItemType = string.Empty;
                    BindData();
                    BindBreadCrumb();
                }
                else
                    Response.Redirect("~/GUI/AccessDenied.aspx");
            }
        }

        #endregion Page Load

        #region Method

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

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblGeneralSettings", "General Settings");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = "Company List&nbsp;";
            dr1["Link"] = "";
            dt.Rows.Add(dr1);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Set Page Lable Here
        /// </summary>
        private void SetPageLabels()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("CompanyList", "lblMainHeader", "COMPANY SETUP");
            litSearchCompanyCode.Text = clsCommon.GetGlobalResourceText("CompanyList", "lblSearchCompanyCode", "Company Code");
            litSearchCompanyName.Text = clsCommon.GetGlobalResourceText("CompanyList", "lblSearchCompanyName", "Company Name");
            litSearchDisplayName.Text = clsCommon.GetGlobalResourceText("CompanyList", "lblSearchDisplayName", "Display Name");
            litSearchCompanyType.Text = clsCommon.GetGlobalResourceText("CompanyList", "lblSearchCompanyType", "Company Type");
            litCompanyList.Text = clsCommon.GetGlobalResourceText("CompanyList", "lblCompanyList", "Company List");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("CompanyList", "lblHeaderConfirmDeletePopup", "Company");
            btnAddBottomCompany.Text = btnAddTopCompany.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
        }

        /// <summary>
        /// Bind Grid Method
        /// </summary>
        private void BindGrid()
        {
            try
            {
                Guid? CompanyType = null;
                string CompanyName = null;
                string DisplayName = null;
                string CompanyCode = null;

                if (ddlSearchCompanyType.SelectedValue != Guid.Empty.ToString())
                    CompanyType = new Guid(Convert.ToString(ddlSearchCompanyType.SelectedValue));

                if (txtSearchCompanyCode.Text.Trim() != "")
                    CompanyCode = txtSearchCompanyCode.Text.Trim();

                if (txtSearchCompanyName.Text.Trim() != "")
                    CompanyName = txtSearchCompanyName.Text.Trim();

                if (txtSearchDisplayName.Text.Trim() != "")
                    DisplayName = txtSearchDisplayName.Text.Trim();

                DataSet dsCompany = CompanyBLL.GetAllCompanyData(null, CompanyName, DisplayName, CompanyCode, CompanyType);
                gvCompanyList.DataSource = dsCompany.Tables[0];
                gvCompanyList.DataBind();
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

                List<ProjectTerm> lstProjectTermCT = null;
                ProjectTerm objProjectTermCT = new ProjectTerm();
                objProjectTermCT.IsActive = true;
                objProjectTermCT.Category = "CompanyType";

                lstProjectTermCT = ProjectTermBLL.GetAll(objProjectTermCT);

                if (lstProjectTermCT.Count > 0)
                {
                    ddlSearchCompanyType.DataSource = lstProjectTermCT;
                    ddlSearchCompanyType.DataTextField = "DisplayTerm";
                    ddlSearchCompanyType.DataValueField = "TermID";
                    ddlSearchCompanyType.DataBind();
                    ddlSearchCompanyType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                }
                else
                    ddlSearchCompanyType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
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
            this.CompanyID = Guid.Empty;
            BindGrid();
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControl()
        {
            ddlSearchCompanyType.SelectedIndex = 0;
            txtSearchCompanyCode.Text = txtSearchCompanyName.Text = txtSearchDisplayName.Text = "";
        }
        #endregion Method

        #region  Grid Event
        protected void gvCompanyList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    ((LinkButton)e.Row.FindControl("lnkDelete")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                    ((LinkButton)e.Row.FindControl("lnkDelete")).OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CompanyID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrCompanyCode")).Text = clsCommon.GetGlobalResourceText("CompanyList", "lblGvHdrCompanyCode", "Company Code");
                    ((Label)e.Row.FindControl("lblGvHdrCompanyName")).Text = clsCommon.GetGlobalResourceText("CompanyList", "lblGvHdrCompanyName", "Company Name");
                    ((Label)e.Row.FindControl("lblGvHdrDisplayName")).Text = clsCommon.GetGlobalResourceText("CompanyList", "lblGvHdrDisplayName", "Display Name");
                    ((Label)e.Row.FindControl("lblGvHdrPrimoryEmailAddress")).Text = clsCommon.GetGlobalResourceText("CompanyList", "lblGvHdrPrimoryEmailAddress", "Email");
                    ((Label)e.Row.FindControl("lblGvHdrPrimoryContactNo")).Text = clsCommon.GetGlobalResourceText("CompanyList", "lblGvHdrPrimoryContactNo", "Contact No");
                    ((Label)e.Row.FindControl("lblGvHdrCompanyType")).Text = clsCommon.GetGlobalResourceText("CompanyList", "lblGvHdrCompanyType", "Company Type");
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

        protected void gvCompanyList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                    clsSession.ToEditItemType = "COMPANY";
                    clsSession.CompanyID = new Guid(Convert.ToString(e.CommandArgument));
                    clsSession.PropertyID = Guid.Empty;
                    clsSession.PropertyName = String.Empty;
                    Response.Redirect("~/GUI/Property/CompanySetup.aspx");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvCompanyList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvCompanyList.PageIndex = e.NewPageIndex;
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
        protected void btnAddTopCompany_Click(object sender, EventArgs e)
        {
            try
            {
                clsSession.CompanyID = clsSession.PropertyID = Guid.Empty;
                clsSession.CompanyName = clsSession.PropertyName = string.Empty;
                Response.Redirect("~/GUI/Property/CompanySetup.aspx");
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
                gvCompanyList.PageIndex = 0;
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
                    Company objDelete = new Company();
                    objDelete = CompanyBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    CompanyBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_Company");
                    IsListMessage = true;
                    ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    ClearControl();

                    if (clsSession.CompanyID == new Guid(Convert.ToString(hdnConfirmDelete.Value)))
                    {
                        clsSession.CompanyID = clsSession.PropertyID = Guid.Empty;
                        clsSession.CompanyName = clsSession.PropertyName = string.Empty;

                        Label lblPropertyName = (Label)this.Page.Master.FindControl("lblPropertyName");
                        lblPropertyName.Text = string.Empty;
                        UpdatePanel uPnlMasterPropertyName = (UpdatePanel)this.Page.Master.FindControl("uPnlMasterPropertyName");
                        uPnlMasterPropertyName.Update();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion
    }
}