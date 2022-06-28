using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Globalization;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Inventory
{
    public partial class CtrlItemList : System.Web.UI.UserControl
    {
        #region Property and Variables

        public bool IsMessage = false;

        public Guid ItemID
        {
            get
            {
                return ViewState["ItemID"] != null ? new Guid(Convert.ToString(ViewState["ItemID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ItemID"] = value;
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
        #endregion Property and Variables

        #region Form Load
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "ITEMMANAGEMENT.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnAdd.Visible = btnAddTop.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        //Method to Bind default data.
        private void BindData()
        {
            try
            {
                BindDDL();
                BindGrid();
                SetPageLables();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //Set page labels from Resourcefiles based on Hotelcode.
        private void SetPageLables()
        {
            ltrMainHeader.Text = clsCommon.GetGlobalResourceText("ItemList", "lblMainHeader", "Item Management");
            litSrchItemName.Text = clsCommon.GetGlobalResourceText("ItemList", "lblSearchItemName", "Item name");
            litSrchItemCode.Text = clsCommon.GetGlobalResourceText("ItemList", "lblSearchCode", "Code");
            litSrchItemType.Text = clsCommon.GetGlobalResourceText("ItemList", "lblSearchType", "Type");

            btnAddTop.Text = btnAdd.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            litItemList.Text = clsCommon.GetGlobalResourceText("ItemList", "lblItemList", "Item List");

            litHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("ItemList", "lblHeaderConfirmDeletePopup", "Item");
            litConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            btnCancelDelete.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            btnSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpSearch", "Search");
            imgbtnClearSearch.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpReset", "Reset");
        }

        private void ClearSearchControl()
        {
            txtSrchItemCode.Text = txtSrchItemName.Text = string.Empty;
            ddlSrchItemType.SelectedIndex = 0;
        }

        /// <summary>
        /// Load Access
        /// </summary>
        private void LoadAccess()
        {
            //DataView DV = RoleRightJoinBLL.GetIUDVAccess("ConfigurationPropertyInfo.aspx", new Guid(Convert.ToString(Session["UserID"])));
            //if (DV.Count > 0)
            //{
            //    ViewState["Delete"] = Convert.ToBoolean(DV[0]["IsDelete"]);
            //    ViewState["Edit"] = Convert.ToBoolean(DV[0]["IsUpdate"]);
            //    btnAdd.Enabled = btnAddTop.Enabled = Convert.ToBoolean(DV[0]["IsCreate"]);
            //    ViewState["View"] = Convert.ToBoolean(DV[0]["IsView"]);
            //}
            //else
            //    Response.Redirect("~/Applications/AccessDenied.aspx");
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
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblMaterialManagementSetup", "Item Master Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblItemList", "Item List") ;
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        /// <summary>
        /// Bind Grid Event
        /// </summary>
        private void BindGrid()
        {
            Item objToGetList = new Item();
            objToGetList.IsActive = true;
            objToGetList.CompanyID = clsSession.CompanyID;
            objToGetList.PropertyID = clsSession.PropertyID;

            if (ddlSrchItemType.SelectedIndex != 0)
                objToGetList.ItemType_TermID = new Guid(ddlSrchItemType.SelectedValue);

            if (txtSrchItemName.Text.Trim() != string.Empty)
                objToGetList.ItemName = txtSrchItemName.Text.Trim();

            if (txtSrchItemCode.Text.Trim() != string.Empty)
                objToGetList.ItemCode = txtSrchItemCode.Text.Trim();

            DataSet dsItems = ItemBLL.GetAllWithRelatedData(objToGetList);

            gvItemList.DataSource = dsItems;
            gvItemList.DataBind();

        }

        private void BindDDL()
        {
            //Bind ddlSrchRateType
            List<ProjectTerm> lstItemType = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "ITEMTYPE");
            if (lstItemType.Count != 0)
            {
                ddlSrchItemType.DataSource = lstItemType;
                ddlSrchItemType.DataTextField = "DisplayTerm";
                ddlSrchItemType.DataValueField = "TermID";
                ddlSrchItemType.DataBind();
                ddlSrchItemType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-"), Guid.Empty.ToString()));
            }
            else
                ddlSrchItemType.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-"), Guid.Empty.ToString()));

        }
        #endregion Private Method

        #region Control Event

        /// <summary>
        /// Button Search Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                gvItemList.PageIndex = 0;
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

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            clsSession.ToEditItemID = Guid.Empty;
            Response.Redirect("~/GUI/Inventory/Item.aspx");
        }

        #endregion Control Event

        #region Grid Event
        protected void gvItemList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");
                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    
                    if (this.UserRights.Substring(2, 1) == "1")
                        ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    string strPurchasePrice = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DefPurPrice"));
                    if (strPurchasePrice != string.Empty)
                    {
                        ((Label)e.Row.FindControl("lblPurchasePrice")).Text = strPurchasePrice.Substring(0, strPurchasePrice.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }

                    string strSalePrice = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DefSalesPrice"));
                    if (strSalePrice != string.Empty)
                    {
                        ((Label)e.Row.FindControl("lblSalePrice")).Text = strSalePrice.Substring(0, strSalePrice.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }

                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ItemID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("litGvHdrNumber")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrItemName")).Text = clsCommon.GetGlobalResourceText("ItemList", "lblGvHdrItemName", "Item Name");
                    ((Label)e.Row.FindControl("lblGvHdrItemCode")).Text = clsCommon.GetGlobalResourceText("ItemList", "lblGvHdrCode", "Code");
                    ((Label)e.Row.FindControl("lblGvHdrItemType")).Text = clsCommon.GetGlobalResourceText("ItemList", "lblGvHdrType", "Type");
                    ////((Label)e.Row.FindControl("lblGvHdrItemCategory")).Text = clsCommon.GetGlobalResourceText("ItemList", "lblGvHdrCategory", "Cagegory");
                    ((Label)e.Row.FindControl("lblGvHdrSalePrice")).Text = clsCommon.GetGlobalResourceText("ItemList", "lblGvHdrSalePrice", "Sale Price");
                    ((Label)e.Row.FindControl("lblGvHdrPurchasePrice")).Text = clsCommon.GetGlobalResourceText("ItemList", "lblGvHdrPurchasePrice", "Purchase Price");
                    ((Label)e.Row.FindControl("litGvHdrActions")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
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

        protected void gvItemList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                    clsSession.ToEditItemType = "ADDEDITITEM";
                    Response.Redirect("~/GUI/Inventory/Item.aspx");
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    this.ItemID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvItemList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvItemList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        #endregion Grid Event

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
                    Item objToDelete = ItemBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));
                    //objToDelete.IsActive = false;
                    ItemBLL.Delete(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    //ItemBLL.Update(objToDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objToDelete.ToString(), null, "mst_Item");
                    IsMessage = true;
                    lblMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    this.ItemID = Guid.Empty;
                    BindGrid();
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