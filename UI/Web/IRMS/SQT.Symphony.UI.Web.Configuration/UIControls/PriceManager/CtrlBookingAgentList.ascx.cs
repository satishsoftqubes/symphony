using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.PriceManager
{
    public partial class CtrlBookingAgentList : System.Web.UI.UserControl
    {
        #region Variable and Property
        public bool IsListMessage = false;
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
        #endregion

        #region Page Load Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                try
                {

                    CheckUserAuthorization();

                    SetPageLabels();
                    BindAgentGrid();
                    BindBreadCrumb();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        #endregion Form Load

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "BOOKINGAGENT.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddBottomAgentList.Visible = btnAddTopAgentList.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        private void SetPageLabels()
        {
            litMainHeader.Text = "BOOKING AGENT"; 
            //clsCommon.GetGlobalResourceText("CorporateList", "lblMainHeader", "CORPORATE SETUP");            
            litSearchCompanyName.Text = clsCommon.GetGlobalResourceText("CorporateList", "lblSearchCompanyName", "Company Name");
            litAgentList.Text = "Booking Agent List";//// clsCommon.GetGlobalResourceText("CorporateList", "lblCorporateSetupList", "Corporate List");
            btnAddTopAgentList.Text = btnAddBottomAgentList.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");

            litHeaderConfirmDeletePopup.Text = "Booking Agent";
            litConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
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
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPriceManager", "Tariff Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Booking Agent List";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindAgentGrid()
        {
            string strCompanyName = null;
            string strname = null;

            if (txtSearchCompanyName.Text.Trim() != string.Empty)
                strCompanyName = txtSearchCompanyName.Text.Trim();

            if (txtSearchName.Text.Trim() != string.Empty)
                strname = txtSearchName.Text.Trim();

            DataSet dsAgent = CorporateBLL.SearchAgentData(clsSession.PropertyID, clsSession.CompanyID, strname, strCompanyName,false);

            gvAgentList.DataSource = dsAgent.Tables[0];
            gvAgentList.DataBind();
        }

        private void ClearSearchControl()
        {
            txtSearchName.Text = txtSearchCompanyName.Text = string.Empty;            
        }

        #endregion Private Method

        #region Grid Event

        protected void gvAgentList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAgentList.PageIndex = e.NewPageIndex;
            BindAgentGrid();
        }

        protected void gvAgentList_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("EDITDATA"))
            {
                clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                clsSession.ToEditItemType = "AGENT";
                Response.Redirect("~/GUI/PriceManager/BookingAgent.aspx");
            }
        }

        protected void gvAgentList_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                if (this.UserRights.Substring(2, 1) == "1")
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                else
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CorporateID")));


                Label lblCorporateContactNo = (Label)e.Row.FindControl("lblCorporateContactNo");
                string strPhoneNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MobileNo"));

                string[] str = strPhoneNo.Split('-');
                if (str.Length > 0)
                {
                    if (str.Length > 0 && str[0] != "" && str.Length > 1 && str[1] != "")
                        lblCorporateContactNo.Text = strPhoneNo;
                    else if (str.Length > 0 && str[0] != "" && str.Length > 1 && str[1] == "")
                        lblCorporateContactNo.Text = Convert.ToString(strPhoneNo[0]);
                    else if (str.Length > 0 && str[0] == "" && str.Length > 1 && str[1] != "")
                        lblCorporateContactNo.Text = Convert.ToString(strPhoneNo.Replace('-', ' ').Trim());
                    else
                        lblCorporateContactNo.Text = Convert.ToString(strPhoneNo.Replace('-', ' ').Trim());
                }
                else
                    lblCorporateContactNo.Text = Convert.ToString(strPhoneNo);
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {   
                ((Label)e.Row.FindControl("lblGvHdrCompanyName")).Text = clsCommon.GetGlobalResourceText("CorporateList", "lblGvHdrCompanyName", "Company Name");                
                ((Label)e.Row.FindControl("lblGvHdrAction")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
            }
            else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
            }

        }
        #endregion Grid Event

        #region Control Event

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            gvAgentList.PageIndex = 0;
            BindAgentGrid();
        }

        protected void imgbtnClearSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearSearchControl();
                BindAgentGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnAddTopAgentList_Click(object sender, EventArgs e)
        {
            clsSession.ToEditItemID = Guid.Empty;
            Response.Redirect("~/GUI/PriceManager/BookingAgent.aspx");
        }

        #endregion Control Event

        #region Popup Button Event

        /// <summary>
        /// Yes Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
                {
                    Corporate objToDelete = CorporateBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));
                    objToDelete.IsActive = false;

                    CorporateBLL.Update(objToDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objToDelete.ToString(), null, "mst_Corporate");
                    IsListMessage = true;
                    ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    BindAgentGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Popup Button Event
    }
}