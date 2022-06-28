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
using System.Web.UI.HtmlControls;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlRoomList : System.Web.UI.UserControl
    {

        #region Variable and Property
        public bool IsListMessage = false;
        public bool IsListMessageForCR = false;
        public bool IsPopupMessage = false;
        public bool IsDuplicateRecord = false;
        public Guid RoomID
        {
            get
            {
                return ViewState["RoomID"] != null ? new Guid(Convert.ToString(ViewState["RoomID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RoomID"] = value;
            }
        }

        public int RoomSellOrderCount
        {
            get
            {
                return ViewState["RoomSellOrderCount"] != null ? Convert.ToInt32(ViewState["RoomSellOrderCount"]) : 0;
            }
            set
            {
                ViewState["RoomSellOrderCount"] = value;
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

        #region Form Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

            if (!IsPostBack)
            {
                CheckUserAuthorization();
                clsSession.ToEditItemID = Guid.Empty;
                clsSession.ToEditItemType = string.Empty;
                BindData();
                BindBreadCrumb();
            }
        }
        #endregion Form Load

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "UNITSETUP.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnSaveCopyRoom.Visible = btnAddBottomRoomList.Visible = btnAddTopRoomList.Visible = this.UserRights.Substring(1, 1) == "1";
        }

        private void BindData()
        {
            try
            {
                SetPageLabels();
                BindUnitType();
                BindWing();
                BindFloor();
                ddlCRRoomNo.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));

                if (Session["RoomTypeID4Unit"] != null)
                {
                    ddlSearchUnitType.SelectedIndex = ddlSearchUnitType.Items.FindByValue(Convert.ToString(Session["RoomTypeID4Unit"])) != null ? ddlSearchUnitType.Items.IndexOf(ddlSearchUnitType.Items.FindByValue(Convert.ToString(Session["RoomTypeID4Unit"]))) : 0;
                    ddlSellOrderRoomType.SelectedIndex = ddlSellOrderRoomType.Items.FindByValue(Convert.ToString(Session["RoomTypeID4Unit"])) != null ? ddlSellOrderRoomType.Items.IndexOf(ddlSellOrderRoomType.Items.FindByValue(Convert.ToString(Session["RoomTypeID4Unit"]))) : 0;
                    Session.Remove("RoomTypeID4Unit");
                }

                if (Session["WingID4Unit"] != null)
                {
                    ddlSearchRoomListWingName.SelectedIndex = ddlSearchRoomListWingName.Items.FindByValue(Convert.ToString(Session["WingID4Unit"])) != null ? ddlSearchRoomListWingName.Items.IndexOf(ddlSearchRoomListWingName.Items.FindByValue(Convert.ToString(Session["WingID4Unit"]))) : 0;
                    Session.Remove("WingID4Unit");
                }

                BindGrid();
                BindRoomSellOrderGrid();
                BindRoom();
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
                dr["NameColumn"] = clsSession.CompanyName;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblPropertyConfiguration", "Property Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblUnitList", "Room List");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void SetPageLabels()
        {
            litMainHeader.Text = clsCommon.GetGlobalResourceText("RoomList", "lblMainHeader", "UNIT SETUP");
            lblSUnitTypeName.Text = clsCommon.GetGlobalResourceText("RoomList", "lblSUnitTypeName", "Room Type");
            lblSUnitNo.Text = clsCommon.GetGlobalResourceText("RoomList", "lblSUnitNo", "Room No.");
            btnAddBottomRoomList.Text = btnAddTopRoomList.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnAddNew", "Add New");
            litRoomList.Text = litSellOrderRoomList.Text = clsCommon.GetGlobalResourceText("RoomList", "lblRoomList", "Room List");
            ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("RoomList", "lblHeaderConfirmDeletePopup", "Room");
            btnCancelCopyRoom.Text = btnNo.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");
            litCRRoomNo.Text = clsCommon.GetGlobalResourceText("RoomList", "lblCopyRoomUnitNo", "Room No.");
            litCRRoomType.Text = clsCommon.GetGlobalResourceText("RoomList", "lblCopyRoomUnitType", "Room Type");
            litCRNewRoomCreate.Text = clsCommon.GetGlobalResourceText("RoomList", "lblCopyRoomNewRoomCreate", "New Rooms To Create");
            chkCRCopyAmenities.Text = clsCommon.GetGlobalResourceText("RoomList", "lblCopyRoomCopyAmeniteis", "Copy Amenities");
            btnSaveCopyRoom.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            litSellOrderRoomType.Text = clsCommon.GetGlobalResourceText("RoomList", "lblSellOrderRoomType", "Room Type");
            lblSearchRoomListWingName.Text = clsCommon.GetGlobalResourceText("RoomList", "lblSearchRoomListWingName", "Wing");
            lblSearchRoomListFloorName.Text = clsCommon.GetGlobalResourceText("RoomList", "lblSearchRoomListFloorName", "Floor");
            btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            litSellOrderHeaderMsg.Text = clsCommon.GetGlobalResourceText("RoomList", "lblSellOrderHeaderMsg", "Reorder Items");
            ltiTabUnitList.Text = clsCommon.GetGlobalResourceText("RoomList", "lblTabUnitList", "Room List");
            litTabSellOrder.Text = clsCommon.GetGlobalResourceText("RoomList", "lblTabSellOrder", "Sell Order");
            litTabCopyRoom.Text = clsCommon.GetGlobalResourceText("RoomList", "lblTabCopyRoom", "Copy Room");
        }

        /// <summary>
        /// Bind Unit Type
        /// </summary>
        private void BindUnitType()
        {
            ddlSearchUnitType.Items.Clear();
            ddlCRRoomType.Items.Clear();
            ddlSellOrderRoomType.Items.Clear();

            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
            string strSearchSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-");

            RoomType Rm = new RoomType();
            Rm.PropertyID = clsSession.PropertyID;
            Rm.IsActive = true;
            List<RoomType> LstRm = RoomTypeBLL.GetAll(Rm);
            if (LstRm.Count > 0)
            {
                LstRm.Sort((RoomType rm1, RoomType rm2) => rm1.RoomTypeName.CompareTo(rm2.RoomTypeName));
                ddlSearchUnitType.DataSource = LstRm;
                ddlSearchUnitType.DataTextField = "RoomTypeName";
                ddlSearchUnitType.DataValueField = "RoomTypeID";
                ddlSearchUnitType.DataBind();
                ddlSearchUnitType.Items.Insert(0, new ListItem(strSearchSelect, Guid.Empty.ToString()));

                ddlCRRoomType.DataSource = LstRm;
                ddlCRRoomType.DataTextField = "RoomTypeName";
                ddlCRRoomType.DataValueField = "RoomTypeID";
                ddlCRRoomType.DataBind();
                ddlCRRoomType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

                ddlSellOrderRoomType.DataSource = LstRm;
                ddlSellOrderRoomType.DataTextField = "RoomTypeName";
                ddlSellOrderRoomType.DataValueField = "RoomTypeID";
                ddlSellOrderRoomType.DataBind();
            }
            else
            {
                ddlSearchUnitType.Items.Insert(0, new ListItem(strSearchSelect, Guid.Empty.ToString()));
                ddlCRRoomType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                ddlSellOrderRoomType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
        }

        private void BindGrid()
        {
            try
            {
                Guid? RoomTypeID;
                Guid? FloorID;
                Guid? WingID;

                string RoomNo = null;
                if (ddlSearchUnitType.SelectedValue != Guid.Empty.ToString())
                    RoomTypeID = new Guid(ddlSearchUnitType.SelectedValue);
                else
                    RoomTypeID = null;

                if (txtSUnitNo.Text.Trim() != "")
                    RoomNo = txtSUnitNo.Text.Trim();
                else
                    RoomNo = null;

                if (ddlSearchRoomListWingName.SelectedValue != Guid.Empty.ToString())
                    WingID = new Guid(ddlSearchRoomListWingName.SelectedValue);
                else
                    WingID = null;

                if (ddlSearchRoomListFloorName.SelectedValue != Guid.Empty.ToString())
                    FloorID = new Guid(ddlSearchRoomListFloorName.SelectedValue);
                else
                    FloorID = null;

                DataSet dsRoom = new DataSet();
                dsRoom = RoomBLL.RoomSearchData(clsSession.PropertyID, RoomTypeID, RoomNo, WingID, FloorID);
                gvRoomList.DataSource = dsRoom;
                gvRoomList.DataBind();

                DataSet dsRoomBedCount = new DataSet();
                dsRoomBedCount = RoomBLL.RoomCountBed(clsSession.PropertyID, RoomTypeID, RoomNo, WingID, FloorID);
                int CountOfBed = 0;
                for (int i = 0; i < dsRoomBedCount.Tables[0].Rows.Count; i++)
                {
                    CountOfBed += Convert.ToInt32(dsRoomBedCount.Tables[0].Rows[i]["NoofBeds"]);
                }

                litTotalNoofRoom.Text = "Total No of Room (" + dsRoom.Tables[0].Rows.Count.ToString() + ")";
                litTotalOnofBed.Text = "Total No of Bed (" + CountOfBed.ToString() + ")";

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
            this.RoomID = Guid.Empty;
        }

        /// <summary>
        /// Bind Room No
        /// </summary>
        private void BindRoomNo()
        {
            //string strRoomNoQuery = "select RoomID, RoomNo, RoomTypeID from mst_Room where IsActive = 1 and PropertyID='" + new Guid(Convert.ToString(clsSession.PropertyID)) + "' And RoomTypeID = '" + new Guid(Convert.ToString(ddlCRRoomType.SelectedValue)) + "' And ReferenceRoomID is null  order by RoomNo Asc";
            string strRoomNoQuery = "select RoomID, (SELECT LEFT(mst_Room.RoomNo, ISNULL(NULLIF(CHARINDEX('|', mst_Room.RoomNo) - 1, -1), LEN(mst_Room.RoomNo))))'RoomNo', RoomTypeID from mst_Room where IsActive = 1 and PropertyID='" + new Guid(Convert.ToString(clsSession.PropertyID)) + "' And RoomTypeID = '" + new Guid(Convert.ToString(ddlCRRoomType.SelectedValue)) + "' And ReferenceRoomID is null  order by RoomNo Asc";
            DataSet dsRoom = RoomBLL.GetUnitNo(strRoomNoQuery);

            ddlCRRoomNo.Items.Clear();
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
            if (dsRoom.Tables[0].Rows.Count != 0)
            {
                ddlCRRoomNo.DataSource = dsRoom.Tables[0];
                ddlCRRoomNo.DataTextField = "RoomNo";
                ddlCRRoomNo.DataValueField = "RoomID";
                ddlCRRoomNo.DataBind();
                ddlCRRoomNo.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlCRRoomNo.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        }

        /// <summary>
        /// Clear Control CopyRoom Data
        /// </summary>
        private void ClearControlCopyRoom()
        {
            ddlCRRoomType.SelectedIndex = 0;
            ddlCRRoomNo.Items.Clear();
            ddlCRRoomNo.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
            txtCRNewRoomCreate.Text = "";
            chkCRCopyAmenities.Checked = false;
        }

        /// <summary>
        /// Bind Wing
        /// </summary>
        private void BindWing()
        {
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-");

            Wing objLoadWing = new Wing();
            objLoadWing.IsActive = true;
            objLoadWing.PropertyID = clsSession.PropertyID;
            List<Wing> LstWin = WingBLL.GetAll(objLoadWing);
            if (LstWin.Count > 0)
            {
                LstWin.Sort((Wing win1, Wing win2) => win1.WingName.CompareTo(win2.WingName));
                ddlSearchRoomListWingName.DataSource = LstWin;
                ddlSearchRoomListWingName.DataTextField = "WingName";
                ddlSearchRoomListWingName.DataValueField = "WingID";
                ddlSearchRoomListWingName.DataBind();
                ddlSearchRoomListWingName.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlSearchRoomListWingName.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        }

        /// <summary>
        /// Bind Floor
        /// </summary>
        private void BindFloor()
        {
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelectAll", "-All-");

            List<Floor> lstFloor = null;
            Floor objFloor = new Floor();
            objFloor.PropertyID = clsSession.PropertyID;
            objFloor.IsActive = true;

            lstFloor = FloorBLL.GetAll(objFloor);

            if (lstFloor.Count > 0)
            {
                lstFloor.Sort((Floor f1, Floor f2) => f1.FloorName.CompareTo(f2.FloorName));
                ddlSearchRoomListFloorName.DataSource = lstFloor;
                ddlSearchRoomListFloorName.DataTextField = "FloorName";
                ddlSearchRoomListFloorName.DataValueField = "FloorID";
                ddlSearchRoomListFloorName.DataBind();
                ddlSearchRoomListFloorName.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            }
            else
                ddlSearchRoomListFloorName.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        }

        /// <summary>
        /// Bind Room Sell Order Grid
        /// </summary>
        private void BindRoomSellOrderGrid()
        {
            try
            {
                if (ddlSellOrderRoomType.SelectedValue != Guid.Empty.ToString())
                {
                    DataSet dsRoomSellOrder = RoomSellOrderBLL.RoomSellOrderSelectAllData(new Guid(ddlSellOrderRoomType.SelectedValue));

                    if (this.UserRights.Substring(1, 1) == "1" || this.UserRights.Substring(2, 1) == "1")
                    {
                        trRoomSellOrder.Visible = false;
                        if (dsRoomSellOrder.Tables[0].Rows.Count > 0)
                        {
                            lblMsg.Visible = false;
                            Session["RoomTypeID"] = Convert.ToString(ddlSellOrderRoomType.SelectedValue);
                            ItemsListView.DataSource = dsRoomSellOrder.Tables[0];
                            ItemsListView.DataBind();
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            Session["RoomTypeID"] = null;
                            ItemsListView.DataSource = null;
                            ItemsListView.DataBind();
                        }
                    }
                    else
                    {
                        trRoomSellOrder.Visible = true;
                        gvSellOrderRoom.DataSource = dsRoomSellOrder.Tables[0];
                        gvSellOrderRoom.DataBind();
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    trRoomSellOrder.Visible = false;
                    Session["RoomTypeID"] = null;
                    ItemsListView.DataSource = null;
                    ItemsListView.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Bind Room
        /// </summary>
        private void BindRoom()
        {
            //string strRoomNoQuery = "select RoomID, RoomNo, RoomTypeID from mst_Room where IsActive = 1 and PropertyID='" + Convert.ToString(clsSession.PropertyID) + "' order by RoomNo Asc";
            //DataSet dsRoom = RoomBLL.GetUnitNo(strRoomNoQuery);
            //gvRooms.DataSource = dsRoom;
            //gvRooms.DataBind();
        }

        /// <summary>
        /// Clear Search Control Method
        /// </summary>
        private void ClearSearchControlForRoom()
        {
            ddlSearchRoomListFloorName.SelectedIndex = ddlSearchRoomListWingName.SelectedIndex = ddlSearchUnitType.SelectedIndex = 0;
            txtSUnitNo.Text = "";
        }
        public string TruncateString(string TruncString, int NumberOfCharacter)
        {
            string NewStr;
            if (TruncString.Length > NumberOfCharacter + 1)
            {
                NewStr = TruncString.Substring(0, NumberOfCharacter) + "...";
            }
            else
            {
                NewStr = TruncString;
            }

            return NewStr;
        }
        #endregion Private Method

        #region GridEvent

        protected void gvRoomList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRoomList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvRoomList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hdnRoomListIsAvailableOnIRS = (HiddenField)e.Row.FindControl("hdnRoomListIsAvailableOnIRS");
                    HiddenField hdnRoomListDiscount = (HiddenField)e.Row.FindControl("hdnRoomListDiscount");

                    if (hdnRoomListIsAvailableOnIRS != null)
                    {
                        HtmlImage imgIsAvailableOnIRS = (HtmlImage)e.Row.FindControl("imgIsAvailableOnIRS");
                        if (imgIsAvailableOnIRS != null)
                        {
                            if (Convert.ToBoolean(hdnRoomListIsAvailableOnIRS.Value) == false)
                                imgIsAvailableOnIRS.Src = "~/images/no.png";
                            else
                                imgIsAvailableOnIRS.Src = "~/images/yes.png";

                        }
                    }

                    //if (hdnRoomListDiscount != null)
                    //{
                    //    HtmlImage imgIsDiscountApplicable = (HtmlImage)e.Row.FindControl("imgIsDiscountApplicable");

                    //    if (imgIsDiscountApplicable != null)
                    //    {
                    //        if (Convert.ToBoolean(hdnRoomListDiscount.Value) == false)
                    //            imgIsDiscountApplicable.Src = "~/images/no.png";
                    //        else
                    //            imgIsDiscountApplicable.Src = "~/images/yes.png";
                    //    }
                    //}

                    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                    if (this.UserRights.Substring(2, 1) == "1")
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
                    else
                        lnkEdit.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

                    lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
                    lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

                    lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomID")));
                }
                else if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblGvHdrUnitType")).Text = clsCommon.GetGlobalResourceText("RoomList", "lblGvHdrUnitType", "Room Type");
                    ((Label)e.Row.FindControl("lblGvHdrUnitNo")).Text = clsCommon.GetGlobalResourceText("RoomList", "lblGvHdrUnitNo", "Room No.");
                    ((Label)e.Row.FindControl("lblGvHdrAction")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
                    ((Label)e.Row.FindControl("lblGvHdrKeyNo")).Text = clsCommon.GetGlobalResourceText("RoomList", "lblGvHdrKeyNo", "Key No.");
                    ((Label)e.Row.FindControl("lblGvHdrExtentionNo")).Text = clsCommon.GetGlobalResourceText("RoomList", "lblGvHdrExtentionNo", "Ext. No.");
                    ((Label)e.Row.FindControl("lblGvHdrCRV")).Text = clsCommon.GetGlobalResourceText("RoomList", "lblGvHdrCRV", "CRS");
                    ////((Label)e.Row.FindControl("lblGvHdrDiscount")).Text = clsCommon.GetGlobalResourceText("RoomList", "lblGvHdrDiscount", "Discount");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        protected void gvSellOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("UP"))
                {
                    ////Guid RoomSellOrderID = new Guid(gvSellOrder.DataKeys[Convert.ToInt32(Convert.ToString(e.CommandArgument))]["RoomSellOrderID"].ToString());
                    ////Guid RoomTypeID = new Guid(gvSellOrder.DataKeys[Convert.ToInt32(Convert.ToString(e.CommandArgument))]["RoomTypeID"].ToString());

                    ////RoomSellOrderBLL.RoomSellOrderSelectAllAfterSwap(RoomSellOrderID, "UP", RoomTypeID);
                    ////BindRoomSellOrderGrid();

                }
                else if (e.CommandName.Equals("DOWN"))
                {
                    ////Guid RoomSellOrderID = new Guid(gvSellOrder.DataKeys[Convert.ToInt32(Convert.ToString(e.CommandArgument))]["RoomSellOrderID"].ToString());
                    ////Guid RoomTypeID = new Guid(gvSellOrder.DataKeys[Convert.ToInt32(Convert.ToString(e.CommandArgument))]["RoomTypeID"].ToString());

                    ////RoomSellOrderBLL.RoomSellOrderSelectAllAfterSwap(RoomSellOrderID, "DOWN", RoomTypeID);
                    ////BindRoomSellOrderGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvRoomList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("EDITDATA"))
                {
                    clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                    clsSession.ToEditItemType = "ROOM";
                    Response.Redirect("~/GUI/Configurations/Room.aspx");
                }
                else if (e.CommandName.Equals("DELETEDATA"))
                {
                    this.RoomID = new Guid(Convert.ToString(e.CommandArgument));
                    mpeConfirmDelete.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvSellOrderRoom_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    ((Label)e.Row.FindControl("lblSORGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
                    ((Label)e.Row.FindControl("lblSORGvHdrUnitNo")).Text = clsCommon.GetGlobalResourceText("RoomList", "lblGvHdrUnitNo", "Room No.");
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFoundMsgForSellOrder")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion GridEvent

        #region Control Event
        protected void btnAddTopRoomList_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/GUI/Configurations/Room.aspx");
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
                gvRoomList.PageIndex = 0;
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnSaveCopyRoom_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    string[] arlNewRoomCreate = Convert.ToString(txtCRNewRoomCreate.Text.Trim()).Split(new char[] { ',' });

                    Room objGetRoomData = new Room();
                    objGetRoomData = RoomBLL.GetByPrimaryKey(new Guid(ddlCRRoomNo.SelectedValue));

                    List<RoomAmenities> lstCRRoomAmenities = new List<RoomAmenities>();
                    RoomAmenities objCRRoomAmenities = new RoomAmenities();
                    objCRRoomAmenities.RoomID = new Guid(ddlCRRoomNo.SelectedValue);

                    lstCRRoomAmenities = RoomAmenitiesBLL.GetAll(objCRRoomAmenities);

                    for (int i = 0; i < arlNewRoomCreate.Length; i++)
                    {
                        string strSplitByDash = Convert.ToString(arlNewRoomCreate[i].Trim());
                        string[] arlNewRoomCreate1 = Convert.ToString(strSplitByDash.Trim()).Split(new char[] { '-' });

                        if (arlNewRoomCreate1.Length > 1)
                        {
                            int intStartValue = Convert.ToInt32(arlNewRoomCreate1[0]);
                            int intEndValue = Convert.ToInt32(arlNewRoomCreate1[arlNewRoomCreate1.Length - 1]);

                            for (int j = intStartValue; j <= intEndValue; j++)
                            {
                                List<Room> lstCRDup = null;
                                Room objCRRoom = new Room();
                                objCRRoom.RoomNo = Convert.ToString(j);
                                objCRRoom.PropertyID = clsSession.PropertyID;
                                objCRRoom.IsActive = true;

                                lstCRDup = RoomBLL.GetAll(objCRRoom);

                                if (lstCRDup.Count == 0)
                                {
                                    Room objToInsertCR = new Room();
                                    List<RoomAmenities> lstToInsertRoomAmenities = new List<RoomAmenities>();

                                    if (objGetRoomData != null)
                                        objToInsertCR = objGetRoomData;

                                    objToInsertCR.RoomNo = Convert.ToString(j);
                                    objToInsertCR.KeyNo = Convert.ToString(j);
                                    objToInsertCR.ExtentionNo = Convert.ToString(j);

                                    if (chkCRCopyAmenities.Checked)
                                    {
                                        if (lstCRRoomAmenities.Count != 0)
                                        {
                                            lstToInsertRoomAmenities = lstCRRoomAmenities;

                                            RoomBLL.Save(objToInsertCR, lstToInsertRoomAmenities);
                                        }
                                        else
                                            RoomBLL.Save(objToInsertCR, lstToInsertRoomAmenities);
                                    }
                                    else
                                        RoomBLL.Save(objToInsertCR, lstToInsertRoomAmenities);
                                }
                            }
                        }
                        else
                        {
                            List<Room> lstCRDup1 = null;
                            Room objCRRoom1 = new Room();
                            objCRRoom1.RoomNo = Convert.ToString(arlNewRoomCreate1[0].Trim());
                            objCRRoom1.PropertyID = clsSession.PropertyID;
                            objCRRoom1.IsActive = true;

                            lstCRDup1 = RoomBLL.GetAll(objCRRoom1);

                            if (lstCRDup1.Count == 0)
                            {
                                Room objToInsertCR1 = new Room();
                                List<RoomAmenities> lstToInsertRoomAmenities1 = new List<RoomAmenities>();

                                if (objGetRoomData != null)
                                    objToInsertCR1 = objGetRoomData;

                                objToInsertCR1.RoomNo = Convert.ToString(arlNewRoomCreate1[0].Trim());
                                objToInsertCR1.KeyNo = Convert.ToString(arlNewRoomCreate1[0].Trim());
                                objToInsertCR1.ExtentionNo = Convert.ToString(arlNewRoomCreate1[0].Trim());

                                if (chkCRCopyAmenities.Checked)
                                {
                                    if (lstCRRoomAmenities.Count != 0)
                                    {
                                        lstToInsertRoomAmenities1 = lstCRRoomAmenities;

                                        RoomBLL.Save(objToInsertCR1, lstToInsertRoomAmenities1);
                                    }
                                    else
                                        RoomBLL.Save(objToInsertCR1, lstToInsertRoomAmenities1);
                                }
                                else
                                    RoomBLL.Save(objToInsertCR1, lstToInsertRoomAmenities1);
                            }
                        }
                    }

                    string msg = string.Empty;

                    for (int m = 0; m < arlNewRoomCreate.Length; m++)
                    {
                        string strSplitByDashForAL = Convert.ToString(arlNewRoomCreate[m].Trim());
                        string[] arlAl = Convert.ToString(strSplitByDashForAL.Trim()).Split(new char[] { '-' });

                        if (arlAl.Length > 1)
                        {
                            int intFirstValue = Convert.ToInt32(arlAl[0]);
                            int intLastValue = Convert.ToInt32(arlAl[arlAl.Length - 1]);

                            for (int l = intFirstValue; l <= intLastValue; l++)
                            {
                                if (msg.Length != 0)
                                    msg += "," + Convert.ToString(l);
                                else
                                    msg = Convert.ToString(l);
                            }
                        }
                        else
                        {
                            if (msg.Length != 0)
                                msg += "," + Convert.ToString(arlAl[0]);
                            else
                                msg = Convert.ToString(arlAl[0]);
                        }
                    }

                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", "Copy Room Data :-  '" + msg + "'", null, "mst_Room");
                    IsListMessageForCR = true;
                    litListMsgForCR.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
                    ClearControlCopyRoom();
                    BindGrid();
                    BindRoomSellOrderGrid();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnCancelCopyRoom_Click(object sender, EventArgs e)
        {
            try
            {
                ddlCRRoomType.SelectedIndex = ddlCRRoomNo.SelectedIndex = 0;
                chkCRCopyAmenities.Checked = false;
                txtCRNewRoomCreate.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Clear Search Button Event For Room
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnClearSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ClearSearchControlForRoom();
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
                    SQT.Symphony.BusinessLogic.Configuration.DTO.Room objDelete = new SQT.Symphony.BusinessLogic.Configuration.DTO.Room();
                    objDelete = RoomBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

                    RoomBLL.Delete(objDelete);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_Room");
                    IsListMessage = true;
                    ltrMsgList.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
                    ClearControl();
                    BindRoomSellOrderGrid();
                }
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion

        #region DropDown Event
        protected void ddlCRRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCRRoomType.SelectedValue != Guid.Empty.ToString())
                    BindRoomNo();
                else
                {
                    ddlCRRoomNo.Items.Clear();
                    ddlCRRoomNo.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-"), Guid.Empty.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        protected void ddlSellOrderRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindRoomSellOrderGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion DropDown Event
    }
}