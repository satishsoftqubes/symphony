using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Text;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.GUI
{
    public partial class Dashboard : System.Web.UI.Page
    {
        #region Variable

        int TotalRooms = 0;
        int AvailableRooms = 0;
        int OOSRooms = 0;
        int TodaysArrival = 0;
        int CheckIn = 0;
        int TodaysDepature = 0;
        int TodaysCheckOut = 0;
        int PastCheckIn = 0;
        int PastCheckOut = 0;

        #endregion Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                caltxtDateFrom.Format = calExtDateTo.Format = hfDateFormat.Value = clsSession.DateFormat;
                mvDashboard.ActiveViewIndex = 0;
                BindBreadCrumb();
                BindTodaysAvailabilityChart();
                BindRoomType();
                //////BindRoomToSellGrid();
                //BindAvailabilityChartGrid();
                ////BindGridData();

                ////This SP will update some data which are required to update on frequent time, so called here. 
                ReservationBLL.ReservationGetReservations(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 2, clsSession.CompanyID, clsSession.PropertyID);
            }
        }

        #endregion Page Load

        #region Private Method

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            DataRow dr2 = dt.NewRow();
            dr2["NameColumn"] = "Dashboard";
            dr2["Link"] = "";
            dt.Rows.Add(dr2);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindRoomDetail()
        {
            try
            {
                DataTable dtRoomDetail = new DataTable();

                DataColumn dc1 = new DataColumn("RoomNo");
                DataColumn dc2 = new DataColumn("RoomType");
                DataColumn dc3 = new DataColumn("GuestName");
                DataColumn dc4 = new DataColumn("BlockName");
                DataColumn dc5 = new DataColumn("Floor");


                dtRoomDetail.Columns.Add(dc1);
                dtRoomDetail.Columns.Add(dc2);
                dtRoomDetail.Columns.Add(dc3);
                dtRoomDetail.Columns.Add(dc4);
                dtRoomDetail.Columns.Add(dc5);

                DataRow dr1 = dtRoomDetail.NewRow();
                dr1["RoomNo"] = "1001";
                dr1["RoomType"] = "AC";
                dr1["GuestName"] = "Pradip Patel";
                dr1["BlockName"] = "B001";
                dr1["Floor"] = "F001";
                dtRoomDetail.Rows.Add(dr1);

                DataRow dr2 = dtRoomDetail.NewRow();
                dr2["RoomNo"] = "1002";
                dr2["RoomType"] = "Non AC";
                dr2["GuestName"] = "Raj Patel";
                dr2["BlockName"] = "B002";
                dr2["Floor"] = "F002";
                dtRoomDetail.Rows.Add(dr2);

                DataRow dr3 = dtRoomDetail.NewRow();
                dr3["RoomNo"] = "1003";
                dr3["RoomType"] = "AC";
                dr3["GuestName"] = "Om Patel";
                dr3["BlockName"] = "B003";
                dr3["Floor"] = "F003";
                dtRoomDetail.Rows.Add(dr3);

                DataRow dr4 = dtRoomDetail.NewRow();
                dr4["RoomNo"] = "1004";
                dr4["RoomType"] = "Non AC";
                dr4["GuestName"] = "Dipen Rakholiya";
                dr4["BlockName"] = "B004";
                dr4["Floor"] = "F004";
                dtRoomDetail.Rows.Add(dr4);

                DataRow dr5 = dtRoomDetail.NewRow();
                dr5["RoomNo"] = "1005";
                dr5["RoomType"] = "AC";
                dr5["GuestName"] = "Thummar Satish";
                dr5["BlockName"] = "B005";
                dr5["Floor"] = "F005";
                dtRoomDetail.Rows.Add(dr5);

                gvRoomDetail.DataSource = dtRoomDetail;
                gvRoomDetail.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindRoomBookingDetail()
        {
            try
            {
                DataTable dtRoomBookingDetail = new DataTable();

                DataColumn dc1 = new DataColumn("RoomNo");
                DataColumn dc2 = new DataColumn("RoomType");
                DataColumn dc3 = new DataColumn("GuestName");
                DataColumn dc4 = new DataColumn("BlockName");
                DataColumn dc5 = new DataColumn("Floor");


                dtRoomBookingDetail.Columns.Add(dc1);
                dtRoomBookingDetail.Columns.Add(dc2);
                dtRoomBookingDetail.Columns.Add(dc3);
                dtRoomBookingDetail.Columns.Add(dc4);
                dtRoomBookingDetail.Columns.Add(dc5);

                DataRow dr1 = dtRoomBookingDetail.NewRow();
                dr1["RoomNo"] = "001";
                dr1["RoomType"] = "AC";
                dr1["GuestName"] = "Pradip Patel";
                dr1["BlockName"] = "B001";
                dr1["Floor"] = "F001";
                dtRoomBookingDetail.Rows.Add(dr1);

                DataRow dr2 = dtRoomBookingDetail.NewRow();
                dr2["RoomNo"] = "002";
                dr2["RoomType"] = "Non AC";
                dr2["GuestName"] = "Raj Patel";
                dr2["BlockName"] = "B002";
                dr2["Floor"] = "F002";
                dtRoomBookingDetail.Rows.Add(dr2);

                DataRow dr3 = dtRoomBookingDetail.NewRow();
                dr3["RoomNo"] = "003";
                dr3["RoomType"] = "AC";
                dr3["GuestName"] = "Om Patel";
                dr3["BlockName"] = "B003";
                dr3["Floor"] = "F003";
                dtRoomBookingDetail.Rows.Add(dr3);

                DataRow dr4 = dtRoomBookingDetail.NewRow();
                dr4["RoomNo"] = "004";
                dr4["RoomType"] = "Non AC";
                dr4["GuestName"] = "Dipen Rakholiya";
                dr4["BlockName"] = "B004";
                dr4["Floor"] = "F004";
                dtRoomBookingDetail.Rows.Add(dr4);

                DataRow dr5 = dtRoomBookingDetail.NewRow();
                dr5["RoomNo"] = "005";
                dr5["RoomType"] = "AC";
                dr5["GuestName"] = "Thummar Satish";
                dr5["BlockName"] = "B005";
                dr5["Floor"] = "F005";
                dtRoomBookingDetail.Rows.Add(dr5);

                gvRoomBookingDetail.DataSource = dtRoomBookingDetail;
                gvRoomBookingDetail.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindRoomType()
        {
            try
            {
                string strRoomTypeQuery = "select RoomTypeID,RoomTypeName from mst_RoomType where PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and IsActive = 1 order by RoomTypeName asc";
                DataSet dsRoomType = RoomTypeBLL.GetUnitType(strRoomTypeQuery);

                ddlRoomTypes.Items.Clear();
                if (dsRoomType.Tables.Count > 0 && dsRoomType.Tables[0].Rows.Count > 0)
                {
                    ddlRoomTypes.DataSource = dsRoomType.Tables[0];
                    ddlRoomTypes.DataTextField = "RoomTypeName";
                    ddlRoomTypes.DataValueField = "RoomTypeID";
                    ddlRoomTypes.DataBind();

                    ddlRoomTypes.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlRoomTypes.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindTodaysAvailabilityChart()
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                DateTime? dtStartDate = null;
                DateTime? dtEndDate = null;

                //DateTime dtToSetCheckInDate = Convert.ToDateTime(DateTime.Now.ToString(clsSession.DateFormat));
                DateTime dtToSetCheckInDate = Convert.ToDateTime(DateTime.Now.ToString("MM-dd-yyyy"));
                DateTime dtToSetCheckOutDate = dtToSetCheckInDate.AddDays(1);
                //DateTime dtToSetCheckOutDate = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString(clsSession.DateFormat));

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

                    dtStartDate = new DateTime(dtToSetCheckInDate.Year, dtToSetCheckInDate.Month, Convert.ToInt32(dtToSetCheckInDate.Day), dtStandardCheckInTime.Hour, dtStandardCheckInTime.Minute, 0);
                    dtEndDate = new DateTime(dtToSetCheckOutDate.Year, dtToSetCheckOutDate.Month, Convert.ToInt32(dtToSetCheckOutDate.Day), dtStandardCheckOutTime.Hour, dtStandardCheckOutTime.Minute, 0);
                }

                DataSet dsTodaysAvailability = ReservationBLL.ReservationTodaysAvailabilityChart(null, dtStartDate, dtEndDate, null, null, clsSession.PropertyID, clsSession.CompanyID);

                if (dsTodaysAvailability.Tables.Count > 0 && dsTodaysAvailability.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsTodaysAvailability.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = dsTodaysAvailability.Tables[0].Rows[i];
                        TotalRooms += Convert.ToInt32(Convert.ToString(dr["Rooms"]));
                        AvailableRooms += Convert.ToInt32(Convert.ToString(dr["AvailableRooms"]));
                        OOSRooms += Convert.ToInt32(Convert.ToString(dr["OOS"]));
                        TodaysArrival += Convert.ToInt32(Convert.ToString(dr["Arrival"]));
                        CheckIn += Convert.ToInt32(Convert.ToString(dr["CheckedIn"]));
                        TodaysDepature += Convert.ToInt32(Convert.ToString(dr["Departure"]));
                        TodaysCheckOut += Convert.ToInt32(Convert.ToString(dr["CheckedOut"]));
                        PastCheckIn += Convert.ToInt32(Convert.ToString(dr["NoShow"]));

                        //PastCheckOut += Convert.ToInt32(Convert.ToString(dr[""]));
                    }

                    gvRoomToSell.DataSource = dsTodaysAvailability.Tables[0];
                    gvRoomToSell.DataBind();
                }
                else
                {
                    gvRoomToSell.DataSource = null;
                    gvRoomToSell.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Private Method

        #region Control Events
        protected void btnSearchRoomLayout_OnClick(object sender, EventArgs e)
        {
            Session["DashboardFromDate"] = Convert.ToString(txtDateFrom.Text.Trim());
            Session["DashboardToDate"] = Convert.ToString(txtDateTo.Text.Trim());
            Session["DashboardRoomTypeID"] = Convert.ToString(ddlRoomTypes.SelectedValue);

            Response.Redirect("~/GUI/Reservation/RoomAvailability.aspx");
        }

        protected void btnBackToDashboard_OnClick(object sender, EventArgs e)
        {
            mvDashboard.ActiveViewIndex = 0;
        }

        protected void btnProceed_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Reservation/RoomReservation.aspx?Mode=Reservation");
        }
        #endregion

        #region Grid Event

        protected void gvRoomToSell_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("TOTAL"))
                {
                    BindRoomDetail();
                    mpeRoomDetail.Show();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvBookingChart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("TOTAL"))
                {
                    BindRoomBookingDetail();
                    mpeBookingDetail.Show();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvRoomToSell_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblGvFtrTotalRooms = (Label)e.Row.FindControl("lblGvFtrTotalRooms");
                    Label lblGvFtrTotalAVL = (Label)e.Row.FindControl("lblGvFtrTotalAVL");
                    Label lblGvFtrOOS = (Label)e.Row.FindControl("lblGvFtrOOS");
                    Label lblGvFtrTodaysArrival = (Label)e.Row.FindControl("lblGvFtrTodaysArrival");
                    Label lblGvFtrTotalCheckIn = (Label)e.Row.FindControl("lblGvFtrTotalCheckIn");
                    Label lblGvFtrPastCheckinTime = (Label)e.Row.FindControl("lblGvFtrPastCheckinTime");
                    Label lblGvFtrDeparture = (Label)e.Row.FindControl("lblGvFtrDeparture");
                    Label lblGvFtrCheckedout = (Label)e.Row.FindControl("lblGvFtrCheckedout");
                    Label lblGvFtrPastCheckedout = (Label)e.Row.FindControl("lblGvFtrPastCheckedout");

                    lblGvFtrTotalRooms.Text = Convert.ToString(TotalRooms);
                    lblGvFtrTotalAVL.Text = Convert.ToString(AvailableRooms);
                    lblGvFtrOOS.Text = Convert.ToString(OOSRooms);
                    lblGvFtrTodaysArrival.Text = Convert.ToString(TodaysArrival);
                    lblGvFtrTotalCheckIn.Text = Convert.ToString(CheckIn);
                    lblGvFtrPastCheckinTime.Text = Convert.ToString(PastCheckIn);
                    lblGvFtrDeparture.Text = Convert.ToString(TodaysDepature);
                    lblGvFtrCheckedout.Text = Convert.ToString(TodaysCheckOut);
                    lblGvFtrPastCheckedout.Text = Convert.ToString(PastCheckOut);
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        private void BindGridData()
        {
            try
            {
                DateTime? dtStartDate = null;
                DateTime? dtEndDate = null;

                DateTime dtToSetCheckInDate = Convert.ToDateTime(DateTime.Now.ToString(clsSession.DateFormat));
                DateTime dtToSetCheckOutDate = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString(clsSession.DateFormat));

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

                    dtStartDate = new DateTime(dtToSetCheckInDate.Year, dtToSetCheckInDate.Month, Convert.ToInt32(dtToSetCheckInDate.Day), dtStandardCheckInTime.Hour, dtStandardCheckInTime.Minute, 0);
                    dtEndDate = new DateTime(dtToSetCheckOutDate.Year, dtToSetCheckOutDate.Month, Convert.ToInt32(dtToSetCheckOutDate.Day), dtStandardCheckOutTime.Hour, dtStandardCheckOutTime.Minute, 0);
                }


                int RoomToSell = 0;

                string strRoomTypeQuery = "select RoomTypeID,RoomTypeName from mst_RoomType where PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and IsActive = 1 order by RoomTypeName asc";
                DataSet ds = RoomTypeBLL.GetUnitType(strRoomTypeQuery);
                DataView rmtype = new DataView(ds.Tables[0]);

                DataTable dtTemp = new DataTable();

                dtTemp.Columns.Add("RoomTypeName");
                dtTemp.Columns.Add("Available");
                dtTemp.Columns.Add("OutOfService");
                dtTemp.Columns.Add("CheckIn");
                dtTemp.Columns.Add("CheckOut");

                for (int i = 0; i < rmtype.Count; i++)
                {
                    for (int j = 1; j < 7; j++)
                    {
                        string strCount;
                        switch (j)
                        {
                            case 1:
                                strCount = GetStatusData(dtStartDate, dtEndDate, 27, new Guid(Convert.ToString(rmtype[i]["RoomTypeID"])));
                                break;
                            case 2:
                                strCount = GetStatusData(dtStartDate, dtEndDate, 28, new Guid(Convert.ToString(rmtype[i]["RoomTypeID"])));
                                break;
                            case 3:
                                strCount = GetStatusData(dtStartDate, dtEndDate, 29, new Guid(Convert.ToString(rmtype[i]["RoomTypeID"])));
                                break;
                            case 4:
                                strCount = GetStatusData(dtStartDate, dtEndDate, 32, new Guid(Convert.ToString(rmtype[i]["RoomTypeID"])));
                                break;
                            case 5:
                                strCount = GetStatusData(dtStartDate, dtEndDate, 33, new Guid(Convert.ToString(rmtype[i]["RoomTypeID"])));
                                break;
                            case 6:
                                strCount = GetStatusData(dtStartDate, dtEndDate, 34, new Guid(Convert.ToString(rmtype[i]["RoomTypeID"])));
                                break;
                        }
                    }

                    DataRow dr = dtTemp.NewRow();

                    dr["RoomTypeName"] = Convert.ToString(rmtype[i]["RoomTypeName"]);

                    DataSet dsrm = new DataSet();
                    dsrm = ReservationBLL.ReservationGetAllVacantRoom(dtStartDate, dtEndDate, new Guid(Convert.ToString(rmtype[i]["RoomTypeID"])), null, null, null, clsSession.CompanyID, clsSession.PropertyID);
                    DataView rm = new DataView(dsrm.Tables[0]);

                    DataSet dsrs = new DataSet();
                    dsrs = ReservationBLL.ReservationSelectRoomsToSell(new Guid(Convert.ToString(rmtype[i]["RoomTypeID"])), dtStartDate, dtEndDate, null, null, clsSession.PropertyID, clsSession.CompanyID);
                    DataView rs = new DataView(dsrs.Tables[0]);

                    RoomToSell = rm.Count - rs.Count;

                    DataSet dsbrs = new DataSet();
                    dsbrs = ReservationBLL.RoomBlockSelectAllBlockRooms(dtStartDate, dtEndDate, new Guid(Convert.ToString(rmtype[i]["RoomTypeID"])), null, clsSession.PropertyID, clsSession.CompanyID);
                    DataView brs = new DataView(dsbrs.Tables[0]);

                    string str1 = RoomToSell.ToString();
                    string str2 = brs.Count.ToString();
                    string str3 = rmtype[i]["RoomTypeID"].ToString();

                    //lstvwAvailable.Items[i].Group = lstvwAvailable.Groups["grpRoomType"];

                    //lblVRooms.Text = Convert.ToString(Convert.ToInt32(lblVRooms.Text) + RoomToSell);
                    //lblBRooms.Text = Convert.ToString(Convert.ToInt32(lblBRooms.Text) + brs.dv.Count);                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private string GetStatusData(DateTime? dtStart, DateTime? dtEnd, int iStatus_ID, Guid RooomTypeID)
        {
            DateTime? dtS = null, dtE = null, dtTodays = null;
            string strReturn = "";

            if (iStatus_ID == 27 || iStatus_ID == 28)
            {
                dtS = dtStart;
                if (dtEnd != null)
                    dtE = Convert.ToDateTime(dtEnd).Date;
                else
                    dtE = dtS.Value.AddDays(1.0).Date;
            }
            else if (iStatus_ID != 32)
            {
                if (dtEnd == null)
                    dtTodays = DateTime.Now.Date;
                else
                {
                    dtS = dtStart;
                    dtE = Convert.ToDateTime(dtEnd).Date;
                }
            }
            else if (iStatus_ID == 32)
            {
                dtTodays = null;
                dtS = null;
                dtE = null;
            }

            DataSet dsReservation = ReservationBLL.ReservationGetReservations(null, null, null, dtStart, dtEnd, RooomTypeID, null, null, null, iStatus_ID, null, null, dtTodays, null, null, 1, clsSession.CompanyID, clsSession.PropertyID);

            string strCheckIn, strUnconfirmed, strConfirmed, strCancelled, strWaiting, strCheckOut = "";

            if (iStatus_ID == 27)
                strReturn = strUnconfirmed = dsReservation.Tables[0].Rows.Count.ToString();
            else if (iStatus_ID == 28)
                strReturn = strConfirmed = dsReservation.Tables[0].Rows.Count.ToString();
            else if (iStatus_ID == 29)
                strReturn = strWaiting = dsReservation.Tables[0].Rows.Count.ToString();
            else if (iStatus_ID == 32)
                strReturn = strCheckIn = dsReservation.Tables[0].Rows.Count.ToString();
            else if (iStatus_ID == 33)
                strReturn = strCheckOut = dsReservation.Tables[0].Rows.Count.ToString();
            else if (iStatus_ID == 34)
                strReturn = strCancelled = dsReservation.Tables[0].Rows.Count.ToString();

            return strReturn;
        }
    }
}