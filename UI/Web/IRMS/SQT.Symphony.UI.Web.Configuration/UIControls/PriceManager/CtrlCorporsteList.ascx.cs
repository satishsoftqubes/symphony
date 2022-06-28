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
    public partial class CtrlCorporsteList : System.Web.UI.UserControl
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
                    BindCorporateGrid();
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
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "CORPORATESETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAddBottomCorporateList.Visible = btnAddTopCorporateList.Visible = this.UserRights.Substring(1, 1) == "1";
        }
        private void SetPageLabels()
        {
            litMainHeader.Text = "COMPANY SETUP"; clsCommon.GetGlobalResourceText("CorporateList", "lblMainHeader", "CORPORATE SETUP");
            litSearchCompanyName.Text = clsCommon.GetGlobalResourceText("CorporateList", "lblSearchCompanyName", "Company Name");
            //chkSearchDirectBill.Text = clsCommon.GetGlobalResourceText("CorporateList", "lblSearchDirectBillAgents", "Direct Bill Agents");
            litCorporateSetupList.Text = "Company List";//// clsCommon.GetGlobalResourceText("CorporateList", "lblCorporateSetupList", "Corporate List");
            btnAddTopCorporateList.Text = btnAddBottomCorporateList.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");

            litHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("CorporateList", "lblHeaderConfirmDeletePopup", "Corporate");
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
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblCorporateList", "Corporate List");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindCorporateGrid()
        {
            string strCompanyName = null;

            if (txtSearchCompanyName.Text.Trim() != string.Empty)
                strCompanyName = txtSearchCompanyName.Text.Trim();

            DataSet dsAgent = CorporateBLL.SearchAgentData(clsSession.PropertyID, clsSession.CompanyID, null, strCompanyName, true);

            gvCorporateList.DataSource = dsAgent.Tables[0];
            gvCorporateList.DataBind();
        }

        private void ClearSearchControl()
        {
            txtSearchCompanyName.Text = string.Empty;
        }

        #endregion Private Method

        #region Grid Event

        protected void gvCorporateList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCorporateList.PageIndex = e.NewPageIndex;
            BindCorporateGrid();
        }

        protected void gvCorporateList_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("EDITDATA"))
            {
                clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                clsSession.ToEditItemType = "CORPORATE";
                Response.Redirect("~/GUI/PriceManager/Corporate.aspx");
            }
            //else if (e.CommandName.Equals("DELETEDATA"))
            //{
            //    this.CorporateID = new Guid(Convert.ToString(e.CommandArgument));
            //    mpeConfirmDelete.Show();
            //}
        }

        protected void gvCorporateList_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                Label lblCorporateContactNo = (Label)e.Row.FindControl("lblCorporateContactNo");

                lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                if (this.UserRights.Substring(2, 1) == "1")
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                else
                    ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

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

                //string strTurnOver = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Turnover"));
                //if (strTurnOver != string.Empty)
                //{
                //    Label lblTurnOver = (Label)e.Row.FindControl("lblTurnOver");
                //    lblTurnOver.Text = strTurnOver.Substring(0, strTurnOver.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                //}

                lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CorporateID")));
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                //((Label)e.Row.FindControl("lblGvHdrCorporateCode")).Text = clsCommon.GetGlobalResourceText("CorporateList", "lblGvHdrCorporateCode", "Code");
                ((Label)e.Row.FindControl("lblGvHdrCorporateName")).Text = "Contact Person Name";//// clsCommon.GetGlobalResourceText("CorporateList", "lblGvHdrCorporateName", "Name");
                ((Label)e.Row.FindControl("lblGvHdrCompanyName")).Text = clsCommon.GetGlobalResourceText("CorporateList", "lblGvHdrCompanyName", "Company Name");
                ////((Label)e.Row.FindControl("lblGvHdrTurnOver")).Text = clsCommon.GetGlobalResourceText("CorporateList", "lblGvHdrTurnOver", "Turn Over");
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
            gvCorporateList.PageIndex = 0;
            BindCorporateGrid();
        }

        protected void imgbtnClearSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearSearchControl();
                BindCorporateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnAddTopCorporateList_Click(object sender, EventArgs e)
        {
            clsSession.ToEditItemID = Guid.Empty;
            Response.Redirect("~/GUI/PriceManager/Corporate.aspx");
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
                    BindCorporateGrid();
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