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
using System.IO;
using System.Text;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest
{
    public partial class CtrlChangeRoom : System.Web.UI.UserControl
    {
        #region Property and Variable

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

        //public Guid NewRoomID
        //{
        //    get
        //    {
        //        return ViewState["NewRoomID"] != null ? new Guid(Convert.ToString(ViewState["NewRoomID"])) : Guid.Empty;
        //    }
        //    set
        //    {
        //        ViewState["NewRoomID"] = value;
        //    }
        //}

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

        public DateTime dtCheckOutDate
        {
            get
            {
                return ViewState["dtCheckOutDate"] != null ? Convert.ToDateTime(ViewState["dtCheckOutDate"]) : DateTime.Now;
            }
            set
            {
                ViewState["dtCheckOutDate"] = value;
            }
        }

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();
                Session["lstMoveRoomBlockDateRate"] = Session["lstMoveRoomResService"] = null;
                LoadDefaultValue();
            }
        }

        #endregion

        #region Private Method
        private bool IsWholeRoomIsAvailable(DateTime? checkInDate, DateTime? checkOutDate, Guid RoomID)
        {
            bool isWholeRommAvailable = true;

            DataSet dsIsRoomAvbl = ReservationBLL.GetAllIsAvailableRoom(checkInDate, checkOutDate, this.RoomTypeID, this.ReservationID, clsSession.PropertyID, clsSession.CompanyID);
            DataSet dsRoomIDs = RoomBLL.GetAllRoomIDOfRoomByAnyRoomID(RoomID, clsSession.PropertyID);

            if (dsRoomIDs.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsRoomIDs.Tables[0].Rows.Count; i++)
                {
                    DataRow[] drRoomAvbl = dsIsRoomAvbl.Tables[0].Select("RoomID = '" + Convert.ToString(dsRoomIDs.Tables[0].Rows[i]["RoomID"]) + "'");
                    if (drRoomAvbl.Length == 0)
                    {
                        isWholeRommAvailable = false;
                        break;
                    }
                }
            }

            return isWholeRommAvailable;
        }
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "ChangeRoom.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");
        }
        private void LoadDefaultValue()
        {
            try
            {
                gvMoveUnitList.DataSource = null;
                gvMoveUnitList.DataBind();
                mvChangeRoom.ActiveViewIndex = 0;
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

                    ddlSearchRoomType.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
                else
                {
                    ddlSearchRoomType.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
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

                    ddlMoveUnitUnitType.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
                else
                    ddlMoveUnitUnitType.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
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
                    strReservationNo = "RES#" + Convert.ToString(txtSearchBookingNo.Text.Trim());


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
            //this.NewRoomID = this.OldRoomID = this.ReservationID = Guid.Empty;
            this.OldRoomID = this.ReservationID = Guid.Empty;
            //ddlMoveUnitUnitType.SelectedIndex = 0;
            gvMoveUnitList.DataSource = null;
            gvMoveUnitList.DataBind();
            Session["lstMoveRoomBlockDateRate"] = Session["lstMoveRoomResService"] = null;
            hdnRMID.Value = hdnRMNo.Value = "";
        }

        private void BindRoomReservationChart()
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                DateTime dtToSetCheckInDate = new DateTime();
                DateTime dtToSetCheckOutDate = new DateTime();

                DateTime? dtCheckInDate = null;
                DateTime? dtCheckoutDate = null;
                Guid? RoomTypeID = null;


                dtToSetCheckInDate = DateTime.Now;
                dtToSetCheckOutDate = dtCheckOutDate;

                RoomTypeID = this.RoomTypeID;

                List<ReservationConfig> lstReservation = null;
                ReservationConfig objReservationConfig = new ReservationConfig();
                objReservationConfig.IsActive = true;
                objReservationConfig.CompanyID = clsSession.CompanyID;
                objReservationConfig.PropertyID = clsSession.PropertyID;
                lstReservation = ReservationConfigBLL.GetAll(objReservationConfig);

                DateTime dtStandardCheckInTime;
                DateTime dtStandardCheckOutTime;

                if (lstReservation.Count != 0)
                {
                    dtStandardCheckInTime = Convert.ToDateTime(lstReservation[0].CheckInTime);
                    dtStandardCheckOutTime = Convert.ToDateTime(lstReservation[0].CheckOutTime);

                    dtCheckInDate = new DateTime(dtToSetCheckInDate.Year, dtToSetCheckInDate.Month, Convert.ToInt32(dtToSetCheckInDate.Day), dtStandardCheckInTime.Hour, dtStandardCheckInTime.Minute, 0);
                    dtCheckoutDate = new DateTime(dtToSetCheckOutDate.Year, dtToSetCheckOutDate.Month, Convert.ToInt32(dtToSetCheckOutDate.Day), dtStandardCheckOutTime.Hour, dtStandardCheckOutTime.Minute, 0);
                }

                StringBuilder strBldr = new StringBuilder();

                DataSet dsRoomData = ReservationBLL.GetRoomResrvationChartData(dtCheckInDate, dtCheckoutDate, RoomTypeID, clsSession.PropertyID, clsSession.CompanyID, 24);

                if (dsRoomData.Tables.Count > 0 && dsRoomData.Tables[0].Rows.Count > 0)
                {
                    strBldr.Append("<table id='tblchart' name='tblchart' cellpadding='0' cellspacing='1' class='maintable' width='100%'>");

                    for (int i = 0; i < dsRoomData.Tables[0].Rows.Count + 1; i++)
                    {
                        strBldr.Append("<tr>");
                        for (int j = 0; j < dsRoomData.Tables[0].Columns.Count - 2; j++)
                        {
                            if (i == 0)
                            {
                                if (j == 0)
                                    strBldr.Append("<td class='commonheader'><b>Date/Room</b></td>");
                                else
                                {
                                    DateTime dtDate = Convert.ToDateTime(Convert.ToString(dsRoomData.Tables[0].Columns[j + 2].ColumnName));
                                    strBldr.Append("<td class='cellheader'>" + (dtDate.ToString("dd-MM")) + "<br />" + Convert.ToString(dtDate.ToString("ddd")) + "</td>");
                                }
                            }
                            else
                            {
                                if (j == 0)
                                {
                                    strBldr.Append("<td class='roomname' style=\"cursor:pointer;\" onclick=\"fnClick('" + Convert.ToString(dsRoomData.Tables[0].Rows[i - 1]["RoomID"]) + "','" + Convert.ToString(dsRoomData.Tables[0].Rows[i - 1]["RoomNumber"]) + "');\">" + (clsCommon.GetFormatedRoomNumber(Convert.ToString(dsRoomData.Tables[0].Rows[i - 1]["RoomNumber"]))) + "</td>");
                                }
                                else
                                {
                                    string strData = Convert.ToString(dsRoomData.Tables[0].Rows[i - 1][j + 2]);
                                    if (strData != string.Empty)
                                    {
                                        string[] strResult = strData.Split('~');
                                        if (strResult.Length != 0)
                                        {
                                            string strSymphonyValue = Convert.ToString(strResult[0]);
                                            string strCompanyName = Convert.ToString(strResult[2]);
                                            string strGuestName = Convert.ToString(strResult[3]);
                                            string strCalss = "availableroom";

                                            switch (Convert.ToInt32(strSymphonyValue))
                                            {
                                                case 27:
                                                    strCalss = "availableroom";
                                                    break;
                                                case (28):
                                                    strCalss = "bookedroom";
                                                    break;
                                                case (29):
                                                    strCalss = "";
                                                    break;
                                                case (32):
                                                    strCalss = "checkinroom";
                                                    break;
                                                case (33):
                                                    strCalss = "";
                                                    break;
                                                case (34):
                                                    strCalss = "";
                                                    break;
                                            }
                                            strCompanyName = strCompanyName != "" ? " | " + strCompanyName : "";
                                            string srtTitle = strGuestName + strCompanyName;
                                            strBldr.Append("<td class='" + strCalss + "' title='" + srtTitle + "'></td>");
                                        }
                                        else
                                            strBldr.Append("<td class='availableroom'></td>");
                                    }
                                    else
                                        strBldr.Append("<td class='availableroom'></td>");
                                }
                            }
                        }
                        strBldr.Append("</tr>");
                    }
                    strBldr.Append("</table>");

                    dvChart.Visible = true;
                    dvChart.InnerHtml = strBldr.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Control Event

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
                    ////mvChangeRoom.ActiveViewIndex = 1;

                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                    ltrChkPmtReservationNo.Text = ((Label)row.FindControl("lblGvListReservationNo")).Text.Trim();
                    ltrChkPmtGuestName.Text = ((Label)row.FindControl("lblGvListName")).Text.Trim();
                    ltrChkPmtCheckInDate.Text = ((Label)row.FindControl("lblGvListCheckInDate")).Text.Trim();
                    ltrChkPmtCheckOutDate.Text = ((Label)row.FindControl("lblGvListCheckOutDate")).Text.Trim();
                    ltrChkPmtRoomType.Text = ((Label)row.FindControl("lblGvListRoomTypeName")).Text.Trim();
                    ltrChkPmtRoomNo.Text = ((Label)row.FindControl("lblGvListRoomNo")).Text.Trim();

                    //litDisplayMoveUnitRoomNo.Text = Convert.ToString(lblGvListRoomNo.Text.Trim());
                    //litDisplayMoveUnitReservationNo.Text = Convert.ToString(lblGvListReservationNo.Text.Trim());
                    //litDisplayMoveUnitGuestName.Text = Convert.ToString(lblGvListName.Text.Trim());

                    ////decimal dcBalance = Convert.ToDecimal(gvResevationList.DataKeys[row.RowIndex]["Balance"].ToString());
                    this.RoomTypeID = new Guid(gvResevationList.DataKeys[row.RowIndex]["RoomTypeID"].ToString());
                    this.ReservationID = new Guid(Convert.ToString(e.CommandArgument));
                    this.OldRoomID = new Guid(gvResevationList.DataKeys[row.RowIndex]["RoomID"].ToString());
                    this.RateID = new Guid(gvResevationList.DataKeys[row.RowIndex]["RateID"].ToString());
                    this.FolioID = new Guid(gvResevationList.DataKeys[row.RowIndex]["FolioID"].ToString());
                    this.dtCheckOutDate = Convert.ToDateTime(gvResevationList.DataKeys[row.RowIndex]["CheckOutDate"].ToString());

                    ////litDisplayMoveUnitCheckInDate.Text = Convert.ToString(lblGvListCheckInDate.Text.Trim());
                    ////litDisplayMoveUnitCheckOutDate.Text = Convert.ToString(lblGvListCheckOutDate.Text.Trim());
                    ////litDisplayMoveUnitFolioBalance.Text = dcBalance.ToString().Substring(0, dcBalance.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    ////litDisplayMoveUnitRoomNoAndRoomType.Text = Convert.ToString(lblGvListRoomNo.Text.Trim()) + " - " + Convert.ToString(lblGvListRoomTypeName.Text.Trim());

                    ////BindRoomTypeByRateID();
                    ////ddlMoveUnitUnitType.SelectedIndex = 0;
                    ////gvMoveUnitList.DataSource = null;
                    ////gvMoveUnitList.DataBind();

                    ////Session["lstMoveRoomBlockDateRate"] = Session["lstMoveRoomResService"] = null;
                    BindRoomReservationChart();
                    mvChangeRoom.ActiveViewIndex = 2;

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

        protected void btnOKChangeRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnRMID.Value != string.Empty && hdnRMID.Value != Guid.Empty.ToString())
                {
                    //If Select from room assign grid, then check it's availability

                    DateTime? checkInDate = null;
                    DateTime? checkOutDate = null;

                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    DateTime dtToSetCheckInDate = new DateTime();
                    DateTime dtToSetCheckOutDate = new DateTime();

                    dtToSetCheckInDate = DateTime.Now;
                    dtToSetCheckOutDate = dtCheckOutDate;

                    //// Get Standard check in/check out time
                    List<ReservationConfig> lstReservation = null;
                    ReservationConfig objReservationConfig = new ReservationConfig();
                    objReservationConfig.IsActive = true;
                    objReservationConfig.CompanyID = clsSession.CompanyID;
                    objReservationConfig.PropertyID = clsSession.PropertyID;
                    lstReservation = ReservationConfigBLL.GetAll(objReservationConfig);

                    DateTime dtStandardCheckInTime;
                    DateTime dtStandardCheckOutTime;

                    if (lstReservation.Count != 0)
                    {
                        dtStandardCheckInTime = Convert.ToDateTime(lstReservation[0].CheckInTime);
                        dtStandardCheckOutTime = Convert.ToDateTime(lstReservation[0].CheckOutTime);

                        checkInDate = new DateTime(dtToSetCheckInDate.Year, dtToSetCheckInDate.Month, Convert.ToInt32(dtToSetCheckInDate.Day), dtStandardCheckInTime.Hour, dtStandardCheckInTime.Minute, 0);
                        checkOutDate = new DateTime(dtToSetCheckOutDate.Year, dtToSetCheckOutDate.Month, Convert.ToInt32(dtToSetCheckOutDate.Day), dtStandardCheckOutTime.Hour, dtStandardCheckOutTime.Minute, 0);
                    }

                    DataSet dsIsRoomAvbl = ReservationBLL.GetAllIsAvailableRoom(checkInDate, checkOutDate, this.RoomTypeID, this.ReservationID, clsSession.PropertyID, clsSession.CompanyID);

                    DataRow[] drRoomAvbl = dsIsRoomAvbl.Tables[0].Select("RoomID = '" + Convert.ToString(hdnRMID.Value) + "'");

                    if (drRoomAvbl.Length == 0)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Selected room is not available, please select other room.");
                        return;
                    }

                    ////If Complementory reservation is there and it's ref. type is Investor, then give whole room to guest instead of any bed.
                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservationForCheck = ReservationBLL.GetByPrimaryKey(this.ReservationID);

                    RateCard objRateCardForCheckIsPerRoom = new RateCard();
                    objRateCardForCheckIsPerRoom = RateCardBLL.GetByPrimaryKey(new Guid(Convert.ToString(objReservationForCheck.RateID)));
                    //(objRateCardForCheckIsPerRoom != null && objRateCardForCheckIsPerRoom.IsPerRoom == true)
                    if ((objReservationForCheck.IsComplimentoryReservation == true && objReservationForCheck.RefInvestorID != null && Convert.ToString(objReservationForCheck.RefInvestorID) != string.Empty && Convert.ToString(objReservationForCheck.RefInvestorID) != Guid.Empty.ToString()) || (objRateCardForCheckIsPerRoom != null && objRateCardForCheckIsPerRoom.IsPerRoom == true))
                    {
                        if (!IsWholeRoomIsAvailable(objReservationForCheck.CheckInDate, objReservationForCheck.CheckOutDate, new Guid(hdnRMID.Value)))
                        {
                            string strMessageToShow = "";
                            if (objRateCardForCheckIsPerRoom.IsPerRoom == true)
                            {
                                strMessageToShow = "This reservation is full room reservation, you can't give partially occupied room to guest";
                            }
                            else
                            {
                                strMessageToShow = "This reservation is complementory reservation, You can't give partially occupied room to guest.";
                            }
                            MessageBox.Show(strMessageToShow);
                            return;
                        }
                    }

                    DataSet dsResTemp = ReservationBLL.Reservation_SymphonySelectReservation(null, null, null, null, null, null, null, null, null, null, null, new Guid(hdnRMID.Value), null, null, 32);
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
                        objToInsert.NewRoomID = new Guid(hdnRMID.Value);
                        objToInsert.Reasom = clsCommon.GetUpperCaseText(Convert.ToString(txtReasontoMoveRoom.Text.Trim()));
                        objToInsert.ConfirmedBy = clsSession.UserID;
                        objToInsert.DateOfMove = DateTime.Now;
                        objToInsert.PropertyID = clsSession.PropertyID;
                        objToInsert.CompanyID = clsSession.CompanyID;
                        objToInsert.IsActive = true;
                        objToInsert.ReservationID = this.ReservationID;
                        objToInsert.DateUpTo = objOldReservationData.CheckOutDate;

                        MoveRoomBLL.Save(objToInsert);
                        ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Save", objToInsert.ToString(), objToInsert.ToString(), "res_MoveRoom", null);


                        objReservation.RoomTypeID = this.RoomTypeID;
                        objReservation.RoomID = new Guid(hdnRMID.Value);
                        objReservation.UpdateMode = "CHANGE ROOM";
                        ReservationBLL.Update(objReservation);
                        ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Update", objOldReservationData.ToString(), objReservation.ToString(), "res_Reservation", null);


                        // Logic to Block Room

                        if (objReservation.IsComplimentoryReservation == true)
                        {
                            RoomBlockBLL.DeleteForOldandInsertForNewRoomBlockDetails((DateTime)objReservation.CheckInDate, (DateTime)objReservation.CheckOutDate, clsSession.UserName, (Guid)clsSession.PropertyID, (Guid)clsSession.CompanyID, DateTime.Now, null, (Guid)objReservation.RoomID, (Guid)objReservation.RoomTypeID, (Guid)objReservation.ReservationID,false);

                        }
                        else if (objRateCardForCheckIsPerRoom.IsPerRoom == true)
                        {
                            RoomBlockBLL.DeleteForOldandInsertForNewRoomBlockDetails((DateTime)objReservation.CheckInDate, (DateTime)objReservation.CheckOutDate, clsSession.UserName, (Guid)clsSession.PropertyID, (Guid)clsSession.CompanyID, DateTime.Now, null, (Guid)objReservation.RoomID, (Guid)objReservation.RoomTypeID, (Guid)objReservation.ReservationID,true);
                        }

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
                                        if (hdnRMID.Value != string.Empty && hdnRMID.Value != Guid.Empty.ToString())
                                        {
                                            bd.RoomID = new Guid(hdnRMID.Value);
                                            BlockDateRateBLL.Update(bd);
                                        }
                                    }
                                }
                            }
                        }


                        ClearFormData();
                        gvResevationList.PageIndex = 0;
                        BindGrid();
                        mvChangeRoom.ActiveViewIndex = 0;
                        IsListMessage = true;
                        ltrListMessage.Text = "Room Change Successfully.";
                    }
                    else
                    {
                        lblCustomePopupMsg.Text = "Guest is already checked-in to this room, Complete check-out process.";
                        mpeCustomePopup.Show();
                        return;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnBackFromRoomChart_OnClick(object sender, EventArgs e)
        {
            mvChangeRoom.ActiveViewIndex = 0;
        }
    }
}