using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Globalization;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlCommonMoveUnitSetup : System.Web.UI.UserControl
    {
        #region Property and Variable

        ////public ModalPopupExtender ucMpeAddEditMoveUnit
        ////{
        ////    get { return this.mpeMoveUnit; }
        ////}

        public MultiView mvOpenMoveUnitHistory
        {
            get { return this.mvMoveUnit; }
        }

        public event EventHandler btnMoveUnitCallParent_Click;

        public string strMode
        {
            get
            {
                return ViewState["strMode"] != null ? Convert.ToString(ViewState["strMode"]) : string.Empty;
            }
            set
            {
                ViewState["strMode"] = value;
            }
        }

        public Guid RoomTypeID
        {
            get
            {
                return ViewState["RoomTypeID"] != null ? new Guid(Convert.ToString(ViewState["RoomTypeID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RoomTypeID"] = value;
            }
        }

        public Guid ReservationID
        {
            get
            {
                return ViewState["ReservationID"] != null ? new Guid(Convert.ToString(ViewState["ReservationID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ReservationID"] = value;
            }
        }

        public Guid NewRoomID
        {
            get
            {
                return ViewState["NewRoomID"] != null ? new Guid(Convert.ToString(ViewState["NewRoomID"])) : Guid.Empty;
            }
            set
            {
                ViewState["NewRoomID"] = value;
            }
        }

        public Guid OldRoomID
        {
            get
            {
                return ViewState["OldRoomID"] != null ? new Guid(Convert.ToString(ViewState["OldRoomID"])) : Guid.Empty;
            }
            set
            {
                ViewState["OldRoomID"] = value;
            }
        }

        public Guid RateID
        {
            get
            {
                return ViewState["RateID"] != null ? new Guid(Convert.ToString(ViewState["RateID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RateID"] = value;
            }
        }

        public string IsOpenPopUp
        {
            get
            {
                return ViewState["IsOpenPopUp"] != null ? Convert.ToString(ViewState["IsOpenPopUp"]) : string.Empty;
            }
            set
            {
                ViewState["IsOpenPopUp"] = value;
            }
        }

        public Guid FolioID
        {
            get
            {
                return ViewState["FolioID"] != null ? new Guid(Convert.ToString(ViewState["FolioID"])) : Guid.Empty;
            }
            set
            {
                ViewState["FolioID"] = value;
            }
        }

        public bool IsListMessage = false;

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["lstMoveRoomBlockDateRate"] = Session["lstMoveRoomResService"] = null;
                LoadDefaultValue();
            }
        }

        #endregion

        #region DropDown Event

        protected void ddlMoveUnitUnitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ////mpeMoveUnit.Show();

                this.IsOpenPopUp = string.Empty;

                strMode = "OPENCHANGEROOM";

                if (ddlMoveUnitUnitType.SelectedIndex != 0)
                {
                    btnMoveUnitSave.Visible = true;
                    BindMoveUnitGrid();
                }
                else
                {
                    btnMoveUnitSave.Visible = false;
                    gvMoveUnitList.DataSource = null;
                    gvMoveUnitList.DataBind();
                }

                string strPageName = GetPageName();
                mvMoveUnit.ActiveViewIndex = 1;

                if (strPageName.ToUpper() != "CHANGEROOM.ASPX")
                {
                    EventHandler temp = btnMoveUnitCallParent_Click;
                    if (temp != null)
                    {
                        temp(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion DropDown Event

        #region Private Method

        private void LoadDefaultValue()
        {
            try
            {
                gvMoveUnitList.DataSource = null;
                gvMoveUnitList.DataBind();
                mvMoveUnit.ActiveViewIndex = 0;
                BindSearchRoomType();
                BindGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void BindMoveUnitGrid()
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                List<ReservationConfig> lstReservation = null;
                ReservationConfig objReservationConfig = new ReservationConfig();
                objReservationConfig.IsActive = true;
                objReservationConfig.CompanyID = clsSession.CompanyID;
                objReservationConfig.PropertyID = clsSession.PropertyID;
                lstReservation = ReservationConfigBLL.GetAll(objReservationConfig);

                DateTime dtToSetCheckInDate = new DateTime();
                DateTime dtToSetCheckOutDate = new DateTime();

                DateTime? dtCheckInDate = null;
                DateTime? dtCheckoutDate = null;

                DateTime dtStandardCheckInTime;
                DateTime dtStandardCheckOutTime;


                //Error occurs
                //dtToSetCheckInDate = Convert.ToDateTime(DateTime.Now.ToString(clsSession.DateFormat));

                dtToSetCheckInDate = DateTime.Now;
                dtToSetCheckOutDate = DateTime.ParseExact(litDisplayMoveUnitCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

                if (lstReservation.Count != 0)
                {
                    dtStandardCheckInTime = Convert.ToDateTime(lstReservation[0].CheckInTime);
                    dtStandardCheckOutTime = Convert.ToDateTime(lstReservation[0].CheckOutTime);

                    dtCheckInDate = new DateTime(dtToSetCheckInDate.Year, dtToSetCheckInDate.Month, Convert.ToInt32(dtToSetCheckInDate.Day), dtStandardCheckInTime.Hour, dtStandardCheckInTime.Minute, 0);
                    dtCheckoutDate = new DateTime(dtToSetCheckOutDate.Year, dtToSetCheckOutDate.Month, Convert.ToInt32(dtToSetCheckOutDate.Day), dtStandardCheckOutTime.Hour, dtStandardCheckOutTime.Minute, 0);
                }

                DataSet dsAvailableRooms = ReservationBLL.GetAllVacantRoom(dtCheckInDate, dtCheckoutDate, new Guid(ddlMoveUnitUnitType.SelectedValue), false, null, clsSession.PropertyID, clsSession.CompanyID);

                if (dsAvailableRooms.Tables.Count > 0 && dsAvailableRooms.Tables[0].Rows.Count > 0)
                {
                    gvMoveUnitList.DataSource = dsAvailableRooms.Tables[0];
                    gvMoveUnitList.DataBind();
                }
                else
                {
                    gvMoveUnitList.DataSource = null;
                    gvMoveUnitList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindMoveUnitHistoryGrid()
        {
            try
            {
                DataSet dsHistory = MoveRoomBLL.GetMoveRoomHistory(null, this.ReservationID, null, null);

                if (dsHistory.Tables.Count > 0 && dsHistory.Tables[0].Rows.Count > 0)
                {
                    gvMoveUnitHistoryList.DataSource = dsHistory.Tables[0];
                    gvMoveUnitHistoryList.DataBind();
                }
                else
                {
                    gvMoveUnitHistoryList.DataSource = null;
                    gvMoveUnitHistoryList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private string GetPageName()
        {
            var uri = new Uri(Convert.ToString(Request.Url));
            string path = uri.GetLeftPart(UriPartial.Path);
            string[] strArray = path.Split('/');
            string strPageName = "";
            return strPageName = Convert.ToString(strArray[strArray.Length - 1]);
        }

        private void BindSearchRoomType()
        {
            try
            {
                string strRoomTypeQuery = "select RoomTypeID,RoomTypeName from mst_RoomType where PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and IsActive = 1 order by RoomTypeName asc";

                ddlSearchRoomType.Items.Clear();

                DataSet dsRoomType = RoomTypeBLL.GetUnitType(strRoomTypeQuery);
                if (dsRoomType.Tables.Count > 0 && dsRoomType.Tables[0].Rows.Count > 0)
                {
                    ddlSearchRoomType.DataSource = dsRoomType.Tables[0];
                    ddlSearchRoomType.DataTextField = "RoomTypeName";
                    ddlSearchRoomType.DataValueField = "RoomTypeID";
                    ddlSearchRoomType.DataBind();

                    ddlSearchRoomType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                {
                    ddlSearchRoomType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindRoomTypeByRateID()
        {
            try
            {
                ddlMoveUnitUnitType.Items.Clear();

                DataSet ds = RateCardDetailsBLL.SelectRoomTypeByRateID(this.RateID, clsSession.PropertyID);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlMoveUnitUnitType.DataSource = ds.Tables[0];
                    ddlMoveUnitUnitType.DataTextField = "RoomTypeName";
                    ddlMoveUnitUnitType.DataValueField = "RoomTypeID";
                    ddlMoveUnitUnitType.DataBind();

                    ddlMoveUnitUnitType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlMoveUnitUnitType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void BindGrid()
        {
            try
            {
                string strName = null;
                string strReservationNo = null;
                string strRoomNo = null;
                Guid? RoomTypeID = null;

                if (txtSearchGuestName.Text.Trim() != "")
                    strName = Convert.ToString(txtSearchGuestName.Text.Trim());

                if (txtSearchBookingNo.Text.Trim() != "")
                    strReservationNo = Convert.ToString(txtSearchBookingNo.Text.Trim());


                if (txtSearchRoomNo.Text.Trim() != "")
                {
                    strRoomNo = Convert.ToString(clsCommon.GetOriginalRoomNumber(txtSearchRoomNo.Text.Trim()));
                    if (strRoomNo == "")
                        strRoomNo = null;
                }

                if (ddlSearchRoomType.SelectedIndex != 0)
                    RoomTypeID = new Guid(ddlSearchRoomType.SelectedValue);

                DataSet dsReservationList = ReservationBLL.GetSwapRoomList(clsSession.PropertyID, clsSession.CompanyID, strName, strReservationNo, strRoomNo, RoomTypeID);

                if (dsReservationList.Tables.Count > 0 && dsReservationList.Tables[0].Rows.Count > 0)
                {
                    gvResevationList.DataSource = dsReservationList.Tables[0];
                    gvResevationList.DataBind();
                }
                else
                {
                    gvResevationList.DataSource = null;
                    gvResevationList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearListData()
        {
            txtSearchBookingNo.Text = txtSearchGuestName.Text = txtSearchRoomNo.Text = "";
            ddlSearchRoomType.SelectedIndex = 0;
        }

        private void ClearFormData()
        {
            this.NewRoomID = this.OldRoomID = this.ReservationID = Guid.Empty;
            ddlMoveUnitUnitType.SelectedIndex = 0;
            gvMoveUnitList.DataSource = null;
            gvMoveUnitList.DataBind();
            Session["lstMoveRoomBlockDateRate"] = Session["lstMoveRoomResService"] = null;
        }

        #endregion

        #region Control Event

        protected void btnMoveUnitHistory_Click(object sender, EventArgs e)
        {
            try
            {
                ////mpeMoveUnit.Show();

                string strPageName = GetPageName();
                BindMoveUnitHistoryGrid();

                if (strPageName.ToUpper() != "CHANGEROOM.ASPX")
                {
                    strMode = "OPENCHANGEROOMHISTORY";

                    EventHandler temp = btnMoveUnitCallParent_Click;
                    if (temp != null)
                    {
                        temp(sender, e);
                    }

                    mvMoveUnit.ActiveViewIndex = 1;
                }
                else
                {
                    mvMoveUnit.ActiveViewIndex = 2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnMoveUnitHistoryCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ////mpeMoveUnit.Show();
                strMode = "OPENCHANGEROOM";
                mvMoveUnit.ActiveViewIndex = 0;

                string strPageName = GetPageName();

                if (strPageName.ToUpper() != "CHANGEROOM.ASPX")
                {
                    EventHandler temp = btnMoveUnitCallParent_Click;
                    if (temp != null)
                    {
                        temp(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void imgbtnClearListData_Click(object sender, EventArgs e)
        {
            gvResevationList.PageIndex = 0;
            ClearListData();
            BindGrid();
        }

        protected void imgbtnSearchListData_Click(object sender, EventArgs e)
        {
            gvResevationList.PageIndex = 0;
            BindGrid();
        }

        protected void btnMoveUnitCancel_Click(object sender, EventArgs e)
        {
            mvMoveUnit.ActiveViewIndex = 0;
        }

        protected void btnMoveUnitSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.RoomTypeID != new Guid(ddlMoveUnitUnitType.SelectedValue))
                {
                    if (this.IsOpenPopUp == string.Empty)
                    {
                        this.IsOpenPopUp = "NOTOPEN";
                        ctrlUpdatesRate.ucmpeRate.Show();
                        ctrlUpdatesRate.uclitDspReservationNo.Text = Convert.ToString(litDisplayMoveUnitReservationNo.Text.Trim());
                        ctrlUpdatesRate.uclitDspRoomType.Text = Convert.ToString(litDisplayMoveUnitRoomNoAndRoomType.Text.Trim());
                        ctrlUpdatesRate.New_RateID = this.RateID;
                        ctrlUpdatesRate.ResID = this.ReservationID;
                        //ctrlUpdatesRate.New_CheckOutDate = Convert.ToDateTime(litDisplayMoveUnitCheckOutDate.Text.Trim());
                        ctrlUpdatesRate.New_RoomTypeID = new Guid(ddlMoveUnitUnitType.SelectedValue);
                        ctrlUpdatesRate.BindBlockDateRateGrid();
                        return;
                    }
                }

                for (int j = 0; j < gvMoveUnitList.Rows.Count; j++)
                {
                    CheckBox chkSelectRoom = (CheckBox)gvMoveUnitList.Rows[j].FindControl("chkSelectRoom");
                    if (chkSelectRoom.Checked)
                        this.NewRoomID = new Guid(gvMoveUnitList.DataKeys[j]["RoomID"].ToString());
                }

                if (this.NewRoomID != Guid.Empty)
                {
                    DataSet dsResTemp = ReservationBLL.Reservation_SymphonySelectReservation(null, null, null, null, null, null, null, null, null, null, null, this.NewRoomID, null, null, 32);
                    if (dsResTemp.Tables[0].Rows.Count == 0)
                    {
                        SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objOldReservationData = new BusinessLogic.FrontDesk.DTO.Reservation();
                        SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservation = new BusinessLogic.FrontDesk.DTO.Reservation();

                        objReservation = ReservationBLL.GetByPrimaryKey(this.ReservationID);
                        objReservation.UpdatedBy = clsSession.UserID;
                        objReservation.UpdatedOn = DateTime.Now;
                        objOldReservationData = ReservationBLL.GetByPrimaryKey(this.ReservationID);

                        SQT.Symphony.BusinessLogic.FrontDesk.DTO.MoveRoom objToInsert = new SQT.Symphony.BusinessLogic.FrontDesk.DTO.MoveRoom();
                        objToInsert.OldRoomID = this.OldRoomID;
                        objToInsert.NewRoomID = this.NewRoomID;
                        objToInsert.Reasom = Convert.ToString(txtReasontoMoveRoom.Text.Trim());
                        objToInsert.ConfirmedBy = clsSession.UserID;
                        objToInsert.DateOfMove = DateTime.Now;
                        objToInsert.PropertyID = clsSession.PropertyID;
                        objToInsert.CompanyID = clsSession.CompanyID;
                        objToInsert.IsActive = true;
                        objToInsert.ReservationID = this.ReservationID;
                        objToInsert.DateUpTo = objOldReservationData.CheckOutDate;

                        MoveRoomBLL.Save(objToInsert);
                        ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Save", objToInsert.ToString(), objToInsert.ToString(), "res_MoveRoom", null);


                        objReservation.RoomTypeID = new Guid(ddlMoveUnitUnitType.SelectedValue);
                        objReservation.RoomID = this.NewRoomID;

                        ReservationBLL.Update(objReservation);
                        ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Update", objOldReservationData.ToString(), objReservation.ToString(), "res_Reservation", null);

                        this.IsOpenPopUp = ctrlUpdatesRate.strOpenMode;

                        if (this.RoomTypeID != new Guid(ddlMoveUnitUnitType.SelectedValue) && this.IsOpenPopUp == "CONTINEWWITHRATEUPDATE" && this.IsOpenPopUp != string.Empty)
                        {
                            BlockDateRateBLL.DeleteByReservationID(this.ReservationID);
                            List<BlockDateRate> lstBlockDateRate_Insert = new List<BlockDateRate>();
                            List<ResServiceList> lstResServiceList_Insert = new List<ResServiceList>();

                            if (Session["lstMoveRoomBlockDateRate"] != null)
                            {
                                lstBlockDateRate_Insert = (List<BlockDateRate>)Session["lstMoveRoomBlockDateRate"];
                            }

                            if (Session["lstMoveRoomResService"] != null)
                            {
                                lstResServiceList_Insert = (List<ResServiceList>)Session["lstMoveRoomResService"];
                            }

                            BlockDateRateBLL.SaveBlockDateEntry(lstBlockDateRate_Insert, lstResServiceList_Insert, this.ReservationID, this.NewRoomID, new Guid(ddlMoveUnitUnitType.SelectedValue), objReservation.RestStatus_TermID, this.FolioID);
                        }

                        if (this.IsOpenPopUp == string.Empty || this.IsOpenPopUp == "CONTINEWWITHOUTRATEUPDATE")
                        {
                            List<BlockDateRate> lstBlockDateRate = null;
                            BlockDateRate objBlockDateRate = new BlockDateRate();
                            objBlockDateRate.ReservationID = this.ReservationID;

                            lstBlockDateRate = BlockDateRateBLL.GetAll(objBlockDateRate);

                            for (int i = 0; i < lstBlockDateRate.Count; i++)
                            {
                                if (lstBlockDateRate[i].BookID == null || Convert.ToString(lstBlockDateRate[i].BookID) == "")
                                {
                                    DateTime dtBlockDateRate = Convert.ToDateTime(lstBlockDateRate[i].BlockDate);
                                    TimeSpan tCheck = DateTime.Now.Date.Subtract(dtBlockDateRate.Date);

                                    if (tCheck.TotalDays <= 0)
                                    {
                                        BlockDateRate bd = new BlockDateRate();
                                        bd = BlockDateRateBLL.GetByPrimaryKey(lstBlockDateRate[i].ResBlockDateRateID);

                                        if (bd != null)
                                        {
                                            if (this.NewRoomID != Guid.Empty)
                                            {
                                                bd.RoomID = this.NewRoomID;
                                                BlockDateRateBLL.Update(bd);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        ClearFormData();
                        gvResevationList.PageIndex = 0;
                        BindGrid();
                        mvMoveUnit.ActiveViewIndex = 0;
                        IsListMessage = true;
                        ltrListMessage.Text = "Room Upgrade Successfully.";
                    }
                    else
                    {
                        lblCustomePopupMsg.Text = "Guest is already checked-in to this room, Complete check-out process.";
                        mpeCustomePopup.Show();
                        return;

                    }
                }
                else
                {
                    lblCustomePopupMsg.Text = "Select Room from the list.";
                    mpeCustomePopup.Show();
                    return;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnUpdatesRateCallParent_Click(object sender, EventArgs e)
        {
            this.IsOpenPopUp = "YES";
        }

        #endregion

        #region Grid Event

        protected void gvResevationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvListPhone = (Label)e.Row.FindControl("lblGvListPhone");
                    string strPhoneNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Phone1"));
                    lblGvListPhone.Text = Convert.ToString(clsCommon.GetMobileNo(strPhoneNo));

                    Label lblGvListRoomNo = (Label)e.Row.FindControl("lblGvListRoomNo");
                    string strRoomNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomNo"));
                    lblGvListRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(strRoomNo));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvResevationList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("MOVEROOM"))
                {
                    mvMoveUnit.ActiveViewIndex = 1;

                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                    Label lblGvListReservationNo = (Label)row.FindControl("lblGvListReservationNo");
                    Label lblGvListRoomTypeName = (Label)row.FindControl("lblGvListRoomTypeName");
                    Label lblGvListRoomNo = (Label)row.FindControl("lblGvListRoomNo");
                    Label lblGvListName = (Label)row.FindControl("lblGvListName");
                    Label lblGvListCheckInDate = (Label)row.FindControl("lblGvListCheckInDate");
                    Label lblGvListCheckOutDate = (Label)row.FindControl("lblGvListCheckOutDate");

                    litDisplayMoveUnitRoomNo.Text = Convert.ToString(lblGvListRoomNo.Text.Trim());
                    litDisplayMoveUnitReservationNo.Text = Convert.ToString(lblGvListReservationNo.Text.Trim());
                    litDisplayMoveUnitGuestName.Text = Convert.ToString(lblGvListName.Text.Trim());

                    decimal dcBalance = Convert.ToDecimal(gvResevationList.DataKeys[row.RowIndex]["Balance"].ToString());
                    this.RoomTypeID = new Guid(gvResevationList.DataKeys[row.RowIndex]["RoomTypeID"].ToString());
                    this.ReservationID = new Guid(Convert.ToString(e.CommandArgument));
                    this.OldRoomID = new Guid(gvResevationList.DataKeys[row.RowIndex]["RoomID"].ToString());
                    this.RateID = new Guid(gvResevationList.DataKeys[row.RowIndex]["RateID"].ToString());
                    this.FolioID = new Guid(gvResevationList.DataKeys[row.RowIndex]["FolioID"].ToString());
                    ctrlUpdatesRate.New_CheckOutDate = Convert.ToDateTime(gvResevationList.DataKeys[row.RowIndex]["CheckOutDate"].ToString());

                    litDisplayMoveUnitCheckInDate.Text = Convert.ToString(lblGvListCheckInDate.Text.Trim());
                    litDisplayMoveUnitCheckOutDate.Text = Convert.ToString(lblGvListCheckOutDate.Text.Trim());
                    litDisplayMoveUnitFolioBalance.Text = dcBalance.ToString().Substring(0, dcBalance.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    litDisplayMoveUnitRoomNoAndRoomType.Text = Convert.ToString(lblGvListRoomNo.Text.Trim()) + " - " + Convert.ToString(lblGvListRoomTypeName.Text.Trim());

                    BindRoomTypeByRateID();
                    ddlMoveUnitUnitType.SelectedIndex = 0;
                    gvMoveUnitList.DataSource = null;
                    gvMoveUnitList.DataBind();

                    this.IsOpenPopUp = ctrlUpdatesRate.strOpenMode = string.Empty;
                    Session["lstMoveRoomBlockDateRate"] = Session["lstMoveRoomResService"] = null;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvResevationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvResevationList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvMoveUnitList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMoveUnitList.PageIndex = e.NewPageIndex;
            BindMoveUnitGrid();
        }

        protected void gvMoveUnitList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvMoveUnitRoomNo = (Label)e.Row.FindControl("lblGvMoveUnitRoomNo");
                    string strRoomNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomNo"));
                    lblGvMoveUnitRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(strRoomNo));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvMoveUnitHistoryList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMoveUnitHistoryList.PageIndex = e.NewPageIndex;
            BindMoveUnitHistoryGrid();
        }

        protected void gvMoveUnitHistoryList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvOldRoomNo = (Label)e.Row.FindControl("lblGvOldRoomNo");
                    string strOldRoomNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "OldRoomNo"));
                    lblGvOldRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(strOldRoomNo));

                    Label lblGvNewRoomNo = (Label)e.Row.FindControl("lblGvNewRoomNo");
                    string strNewRoomNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "NewRoomNo"));
                    lblGvNewRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(strNewRoomNo));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Grid Event

        //#region Checkbox Event

        //protected void chkSelectRoom_CheckedChanged(object sender, EventArgs e)
        //{
        //    CheckBox chkSelectRoom = (CheckBox)sender;

        //    if (chkSelectRoom.Checked)
        //    {
        //        GridViewRow row = (GridViewRow)chkSelectRoom.NamingContainer;
        //        this.NewRoomID = new Guid(gvMoveUnitList.DataKeys[row.RowIndex]["RoomID"].ToString());
        //    }
        //    else
        //        this.NewRoomID = Guid.Empty;

        //}

        //#endregion Checkbox Event
    }
}