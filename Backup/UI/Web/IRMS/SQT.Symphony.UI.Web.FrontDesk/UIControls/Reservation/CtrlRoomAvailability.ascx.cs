using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Globalization;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System.Globalization;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlRoomAvailability : System.Web.UI.UserControl
    {
        #region Property and Variables

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
        public string StandardCheckInTime
        {
            get
            {
                return ViewState["StandardCheckInTime"] != null ? Convert.ToString(ViewState["StandardCheckInTime"]) : string.Empty;
            }
            set
            {
                ViewState["StandardCheckInTime"] = value;
            }
        }

        public string StandardCheckOutTime
        {
            get
            {
                return ViewState["StandardCheckOutTime"] != null ? Convert.ToString(ViewState["StandardCheckOutTime"]) : string.Empty;
            }
            set
            {
                ViewState["StandardCheckOutTime"] = value;
            }
        }

        DataSet dsRatecardData = null;
        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();
                LoadDefaultValue();
            }
        }

        #endregion Page Load

        #region Private Methode
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "RoomAvailability.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");
        }
        private void LoadDefaultValue()
        {
            try
            {
                // calSearchFromDate.Format = calSearchToDate.Format = clsSession.DateFormat;
                calReservationProceedFromDate.Format = calReservationProceedToDate.Format = hfDateFormat.Value = clsSession.DateFormat;
                BindRoomType();
                BindBreadCrumb();
                BindStandardCheckInCheckOutTime();

                string strFromData = Convert.ToString(Session["DashboardFromDate"]);
                string strToData = Convert.ToString(Session["DashboardToDate"]);
                string strRoomTypeID = Convert.ToString(Session["DashboardRoomTypeID"]);

                if (strFromData != "" && strToData != "" && strRoomTypeID != "" && strRoomTypeID != Guid.Empty.ToString())
                {
                    txtSearchFromDate.Text = Convert.ToString(strFromData);
                    txtSearchToDate.Text = Convert.ToString(strToData);
                    ddlSearchRoomType.SelectedIndex = ddlSearchRoomType.Items.FindByValue(Convert.ToString(strRoomTypeID)) != null ? ddlSearchRoomType.Items.IndexOf(ddlSearchRoomType.Items.FindByValue(Convert.ToString(strRoomTypeID))) : 0;

                    Session.Remove("DashboardFromDate");
                    Session.Remove("DashboardToDate");
                    Session.Remove("DashboardRoomTypeID");

                    BindRoomReservationChart();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindRoomReservationChart()
        {
            CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

            DateTime? dtCheckInDate = null;
            DateTime? dtCheckoutDate = null;
            Guid? RoomTypeID = null;

            DateTime dtToSetCheckInDate = new DateTime();
            DateTime dtToSetCheckOutDate = new DateTime();

            if (txtSearchFromDate.Text.Trim() != "")
                dtToSetCheckInDate = DateTime.ParseExact(txtSearchFromDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
            if (txtSearchToDate.Text.Trim() != "")
                dtToSetCheckOutDate = DateTime.ParseExact(txtSearchToDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
            if (ddlSearchRoomType.SelectedIndex != 0)
                RoomTypeID = new Guid(ddlSearchRoomType.SelectedValue);

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

            //lblCalanderToFrom.Text = DateTime.Today.AddDays(-1).ToString("dd-MM-yyyy") + " - " + DateTime.Today.AddDays(13).ToString("dd/MM/yyyy");


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
                                strBldr.Append("<td class='cellheader'>" + (dtDate.ToString("dd-MM-yy")) + "<br />" + Convert.ToString(dtDate.ToString("ddd")) + "</td>");
                            }
                        }
                        else
                        {
                            if (j == 0)
                            {
                                strBldr.Append("<td class='roomname' style=\"cursor:pointer;\" onclick=\"fnClick('" + Convert.ToString(dsRoomData.Tables[0].Rows[i - 1]["RoomID"]) + "','" + Convert.ToString(dsRoomData.Tables[0].Rows[i - 1]["RoomNumber"]) + "');\">" + (GetRoomNumber(Convert.ToString(dsRoomData.Tables[0].Rows[i - 1]["RoomNumber"]))) + "</td>");
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
                                        //oosroom 
                                        //string strRackRate = txtTotalRackRate.Text.Trim().IndexOf('.') > -1 ? txtTotalRackRate.Text.Trim() + "000000" : txtTotalRackRate.Text.Trim() + ".000000";
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

            //DataTable dtToBind = GetDataToBind("DAILY");

            //for (int i = 0; i < dtToBind.Rows.Count; i++)
            //{
            //    strBldr.Append("<tr>");
            //    for (int j = 0; j < dtToBind.Columns.Count; j++)
            //    {
            //        if (i == 0)
            //        {
            //            if (j == 0)
            //                strBldr.Append("<td class='commonheader'><b>Date/Room</b></td>");
            //            else
            //                strBldr.Append("<td class='cellheader'>" + DateTime.Today.AddDays(j - 2).ToString("dd-MM") + "<br />" + GetDayName(j) + "</td>");
            //        }
            //        else
            //        {
            //            if (j == 0)
            //            {
            //                if (i < 6)
            //                    strBldr.Append("<td class='roomname' onclick=\"fnClick('" + i.ToString() + "');\">A0-00" + (i).ToString() + " B1</td>");
            //                else if (i <= 11)
            //                    strBldr.Append("<td class='roomname' onclick=\"fnClick('" + i.ToString() + "');\">A1-00" + (i).ToString() + " B1</td>");
            //                else if (i <= 16)
            //                    strBldr.Append("<td class='roomname' onclick=\"fnClick('" + i.ToString() + "');\">A2-00" + (i).ToString() + " B1</td>");
            //            }
            //            else
            //            {
            //                string cellID = i.ToString() + j.ToString();
            //                if (i < 11)
            //                {
            //                    if (i == 1)
            //                    {
            //                        if (j <= 6)
            //                            strBldr.Append("<td id='" + cellID + "' title='Mr. Prakash Mehra | Infosys | Day Shift' class='checkinroom'></td>");
            //                        else if (j > 6 && j < 13)
            //                            strBldr.Append("<td id='" + cellID + "' class='availableroom'></td>");
            //                        else
            //                            strBldr.Append("<td id='" + cellID + "' title='Mr. Anant Patel | Infosys | Day Shift' class='bookedroom' ></td>");
            //                    }
            //                    else if (i == 2)
            //                    {
            //                        if (j <= 3)
            //                            strBldr.Append("<td id='" + cellID + "' title='Mr. Anant Patel | Infosys | Day Shift' class='checkinroom'></td>");
            //                        else if (j > 3 && j < 10)
            //                            strBldr.Append("<td id='" + cellID + "' class='availableroom' ></td>");
            //                        else if (j > 10 && j < 14)
            //                            strBldr.Append("<td id='" + cellID + "' title='Mr. Anant Patel | Infosys | Day Shift' class='bookedroom' ></td>");
            //                        else
            //                            strBldr.Append("<td id='" + cellID + "' class='oosroom' ></td>");
            //                    }
            //                    else if (i == 3)
            //                    {
            //                        if (j <= 2)
            //                            strBldr.Append("<td id='" + cellID + "' title='Mr. Anant Patel | Infosys | Day Shift' class='bookedroom' ></td>");
            //                        else if (j > 2 && j < 8)
            //                            strBldr.Append("<td id='" + cellID + "' class='availableroom' ></td>");
            //                        else if (j > 8 && j < 12)
            //                            strBldr.Append("<td id='" + cellID + "' title='Mr. Anant Patel | Infosys | Day Shift' class='bookedroom' ></td>");
            //                        else
            //                            strBldr.Append("<td id='" + cellID + "' class='availableroom' ></td>");
            //                    }
            //                    else if (i == 4)
            //                    {
            //                        if (j < 15)
            //                            strBldr.Append("<td id='" + cellID + "' title='Mr. Anant Patel | Infosys | Day Shift' class='checkinroom' ></td>");
            //                        else
            //                            strBldr.Append("<td id='" + cellID + "' title='Mr. Anant Patel | Infosys | Day Shift' class='bookedroom' ></td>");
            //                    }
            //                    else if (i == 5)
            //                    {
            //                        strBldr.Append("<td id='" + cellID + "' title='Mr. Anant Patel | Infosys | Day Shift' class='checkinroom' ></td>");
            //                    }
            //                    else if (i == 6)
            //                    {
            //                        if (j < 8)
            //                            strBldr.Append("<td id='" + cellID + "' class='availableroom' ></td>");
            //                        else if (j > 8 && j < 13)
            //                            strBldr.Append("<td id='" + cellID + "' title='Mr. Anant Patel | Infosys | Day Shift' class='bookedroom' ></td>");
            //                        else if (j > 12 && j < 17)
            //                            strBldr.Append("<td id='" + cellID + "' class='availableroom' ></td>");
            //                        else
            //                            strBldr.Append("<td id='" + cellID + "' title='Mr. Anant Patel | Infosys | Day Shift' class='bookedroom' ></td>");
            //                    }
            //                    else if (i == 7)
            //                    {
            //                        if (j < 8)
            //                            strBldr.Append("<td id='" + cellID + "' title='Mr. Anant Patel | Infosys | Day Shift' class='bookedroom' ></td>");
            //                        else if (j >= 8 && j < 15)
            //                            strBldr.Append("<td id='" + cellID + "' class='availableroom' ></td>");
            //                        else
            //                            strBldr.Append("<td id='" + cellID + "' title='Mr. Anant Patel | Infosys | Day Shift' class='bookedroom' ></td>");
            //                    }
            //                    else if (i == 8)
            //                    {
            //                        if (j < 8)
            //                            strBldr.Append("<td id='" + cellID + "' title='Mr. Anant Patel | Infosys | Day Shift' class='checkinroom' ></td>");
            //                        else if (j >= 8 && j < 19)
            //                            strBldr.Append("<td id='" + cellID + "' class='availableroom' ></td>");
            //                        else
            //                            strBldr.Append("<td id='" + cellID + "' title='Mr. Anant Patel | Infosys | Day Shift' class='bookedroom' ></td>");
            //                    }
            //                    else
            //                        strBldr.Append("<td id='" + cellID + "' title='Mr. Anant Patel | Infosys | Day Shift' class='bookedroom' ></td>");
            //                }
            //                else
            //                {
            //                    strBldr.Append("<td id='" + cellID + "' class='availableroom' ></td>");
            //                }
            //            }
            //        }
            //    }
            //    strBldr.Append("</tr>");
            //}

            //strBldr.Append("</table>");



        }

        public DataTable GetDataToBind(string strViewType)
        {
            DataTable dtToReturn = new DataTable();

            int iColCount = 0;
            if (strViewType.ToUpper() == "DAILY")
                iColCount = 20;
            else if (strViewType.ToUpper() == "WEEKLY")
                iColCount = 11;
            else if (strViewType.ToUpper() == "MONTHLY")
                iColCount = 13;
            else if (strViewType.ToUpper() == "QUARTERLY")
                iColCount = 10;

            for (int i = 1; i <= iColCount; i++)
            {
                DataColumn dtCol = new DataColumn(i.ToString());
                dtToReturn.Columns.Add(dtCol);
            }

            DataRow dr0 = dtToReturn.NewRow(); DataRow dr1 = dtToReturn.NewRow(); DataRow dr2 = dtToReturn.NewRow(); DataRow dr3 = dtToReturn.NewRow();
            DataRow dr4 = dtToReturn.NewRow(); DataRow dr5 = dtToReturn.NewRow(); DataRow dr6 = dtToReturn.NewRow(); DataRow dr7 = dtToReturn.NewRow();
            DataRow dr8 = dtToReturn.NewRow(); DataRow dr9 = dtToReturn.NewRow(); DataRow dr10 = dtToReturn.NewRow(); DataRow dr11 = dtToReturn.NewRow();
            DataRow dr12 = dtToReturn.NewRow(); DataRow dr13 = dtToReturn.NewRow(); DataRow dr14 = dtToReturn.NewRow(); DataRow dr15 = dtToReturn.NewRow();
            DataRow dr16 = dtToReturn.NewRow();

            dtToReturn.Rows.Add(dr0); dtToReturn.Rows.Add(dr1); dtToReturn.Rows.Add(dr2); dtToReturn.Rows.Add(dr3); dtToReturn.Rows.Add(dr4);
            dtToReturn.Rows.Add(dr5); dtToReturn.Rows.Add(dr6); dtToReturn.Rows.Add(dr7); dtToReturn.Rows.Add(dr8); dtToReturn.Rows.Add(dr9);
            dtToReturn.Rows.Add(dr10); dtToReturn.Rows.Add(dr11); dtToReturn.Rows.Add(dr12); dtToReturn.Rows.Add(dr13); dtToReturn.Rows.Add(dr14);
            dtToReturn.Rows.Add(dr15); dtToReturn.Rows.Add(dr16);

            return dtToReturn;
        }

        public string GetDayName(int date)
        {
            DateTime dt = DateTime.Today.AddDays(date - 2);
            string strDay = dt.ToString("ddd");

            return strDay;
        }

        public string GetMonthName(int count)
        {
            DateTime dt = DateTime.Now;
            dt = dt.AddMonths(count - 1);
            int smnth = dt.Month;
            string strMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(smnth);
            int year = dt.Year;

            return strMonthName + "-" + year.ToString();
        }

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

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Reservation";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Room Availability";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindRoomType()
        {
            try
            {
                string strRoomTypeQuery = "select RoomTypeID,RoomTypeName from mst_RoomType where PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and IsActive = 1 order by RoomTypeName asc";
                DataSet dsRoomType = RoomTypeBLL.GetUnitType(strRoomTypeQuery);

                ddlSearchRoomType.Items.Clear();
                if (dsRoomType.Tables.Count > 0 && dsRoomType.Tables[0].Rows.Count > 0)
                {
                    ddlSearchRoomType.DataSource = dsRoomType.Tables[0];
                    ddlSearchRoomType.DataTextField = "RoomTypeName";
                    ddlSearchRoomType.DataValueField = "RoomTypeID";
                    ddlSearchRoomType.DataBind();

                    ddlSearchRoomType.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                }
                else
                    ddlSearchRoomType.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private string GetRoomNumber(string strRoomNumber)
        {
            string strRoomNo = string.Empty;

            string[] str = strRoomNumber.Split('|');
            if (str.Length > 0)
                strRoomNo = str[0] + "(" + str[1] + ")";

            return strRoomNo;
        }

        private void BindStandardCheckInCheckOutTime()
        {
            try
            {
                List<ReservationConfig> lstReservation = null;
                ReservationConfig objReservationConfig = new ReservationConfig();
                objReservationConfig.IsActive = true;
                objReservationConfig.CompanyID = clsSession.CompanyID;
                objReservationConfig.PropertyID = clsSession.PropertyID;
                lstReservation = ReservationConfigBLL.GetAll(objReservationConfig);

                if (lstReservation.Count != 0)
                {
                    this.StandardCheckInTime = Convert.ToString(lstReservation[0].CheckInTime);
                    this.StandardCheckOutTime = Convert.ToString(lstReservation[0].CheckOutTime);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindRateCardData()
        {
            try
            {
                Guid? RateID = null;
                if (rblRatecardTyep.Items.Count > 0)
                    RateID = new Guid(rblRatecardTyep.SelectedValue);

                dsRatecardData = new DataSet();

                dsRatecardData = RateCardBLL.GetDashboardRatecardData(clsSession.PropertyID, clsSession.CompanyID, RateID, chkIsFullRoomForRoomAvail.Checked);

                if (dsRatecardData.Tables.Count > 0 && dsRatecardData.Tables[0].Rows.Count > 0)
                {
                    rblRatecardTyep.DataSource = dsRatecardData.Tables[0];
                    rblRatecardTyep.DataTextField = "DisplayMinimumDays";
                    rblRatecardTyep.DataValueField = "RateID";
                    rblRatecardTyep.DataBind();

                    if (RateID == null)
                        rblRatecardTyep.SelectedIndex = 0;
                    else
                        rblRatecardTyep.SelectedValue = Convert.ToString(RateID);

                    if (dsRatecardData.Tables[1] != null && dsRatecardData.Tables[1].Rows.Count > 0)
                    {
                        gvRoomTypeList.DataSource = dsRatecardData.Tables[1];
                        gvRoomTypeList.DataBind();
                    }
                    else
                    {
                        gvRoomTypeList.DataSource = null;
                        gvRoomTypeList.DataBind();
                    }
                }
                else
                {
                    rblRatecardTyep.DataSource = null;
                    rblRatecardTyep.DataBind();

                    gvRoomTypeList.DataSource = null;
                    gvRoomTypeList.DataBind();

                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion

        #region Control Event
        protected void chkIsFullRoomForRoomAvail_CheckChanged(object sender, EventArgs e)
        {
            rblRatecardTyep.Items.Clear();
            BindRateCardData();
            mpeRateCardDetail.Show();
        }
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    litDisplayRoomType.Text = Convert.ToString(ddlSearchRoomType.SelectedItem.Text);
                    BindRoomReservationChart();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void lnkViewRateCardDetail_OnClick(object sender, EventArgs e)
        {
            BindRateCardData();
            mpeRateCardDetail.Show();
        }

        protected void rblRatecardTyep_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRateCardData();
            mpeRateCardDetail.Show();
        }

        protected void btnProceed_OnClick(object sender, EventArgs e)
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                DateTime? checkInDate = null;
                DateTime? checkOutDate = null;
                Guid? roomTypeID = null;

                DateTime dtToSetCheckInDate = new DateTime();
                DateTime dtToSetCheckOutDate = new DateTime();

                if (ddlSearchRoomType.SelectedIndex != 0)
                    roomTypeID = new Guid(ddlSearchRoomType.SelectedValue);

                if (txtReservationProceedFromDate.Text.Trim() != "")
                    dtToSetCheckInDate = DateTime.ParseExact(txtReservationProceedFromDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                if (txtReservationProceedToDate.Text.Trim() != "")
                    dtToSetCheckOutDate = DateTime.ParseExact(txtReservationProceedToDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

                DateTime dtStandardCheckInTime;
                DateTime dtStandardCheckOutTime;

                //// If Standard check in/Check out time is there, then apply it,
                if (this.StandardCheckInTime != string.Empty && this.StandardCheckOutTime != string.Empty)
                {
                    dtStandardCheckInTime = Convert.ToDateTime(this.StandardCheckInTime);
                    dtStandardCheckOutTime = Convert.ToDateTime(this.StandardCheckOutTime);

                    checkInDate = new DateTime(dtToSetCheckInDate.Year, dtToSetCheckInDate.Month, Convert.ToInt32(dtToSetCheckInDate.Day), dtStandardCheckInTime.Hour, dtStandardCheckInTime.Minute, 0);
                    checkOutDate = new DateTime(dtToSetCheckOutDate.Year, dtToSetCheckOutDate.Month, Convert.ToInt32(dtToSetCheckOutDate.Day), dtStandardCheckOutTime.Hour, dtStandardCheckOutTime.Minute, 0);
                }
                else// o/w pass only check in/check out date.
                {
                    if (txtReservationProceedFromDate.Text.Trim() != "")
                        checkInDate = DateTime.ParseExact(txtReservationProceedFromDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                    if (txtReservationProceedToDate.Text.Trim() != "")
                        checkOutDate = DateTime.ParseExact(txtReservationProceedToDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                }

                DataSet dsIsRoomAvbl = ReservationBLL.GetAllVacantRoom(checkInDate, checkOutDate, roomTypeID, false, null, clsSession.PropertyID, clsSession.CompanyID);
                DataRow[] drRoomAvbl = dsIsRoomAvbl.Tables[0].Select("RoomID = '" + Convert.ToString(hdnRoomID.Value) + "'");

                if (drRoomAvbl.Length == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show("Selected room is not available, please select other room.");
                    return;
                }
                else
                {
                    if (DateTime.ParseExact(txtReservationProceedFromDate.Text.Trim(), clsSession.DateFormat, objCultureInfo) < DateTime.ParseExact(DateTime.Today.ToString(clsSession.DateFormat), clsSession.DateFormat, objCultureInfo))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("From date must not be less than today's date.");
                        return;
                    }

                    Session["RoomIDfromAVBLTchart"] = hdnRoomID.Value;
                    Session["CheckInDatefromAVBLTchart"] = txtReservationProceedFromDate.Text.Trim();
                    Session["CheckOutDatefromAVBLTchart"] = txtReservationProceedToDate.Text.Trim();
                    Session["RoomTypeIDfromAVBLTchart"] = ddlSearchRoomType.SelectedValue.ToString();

                    if (txtReservationProceedFromDate.Text.Trim() == DateTime.Today.ToString(clsSession.DateFormat))
                        Response.Redirect("~/GUI/Reservation/Reservation.aspx?WalkIn=WalkIn");
                    else
                        Response.Redirect("~/GUI/Reservation/Reservation.aspx");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Dashboard.aspx");
        }

        #endregion Control Event

        #region Grid Events
        protected void gvRoomTypeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvTax = (Label)e.Row.FindControl("lblGvTax");
                    Label lblGvTotal = (Label)e.Row.FindControl("lblGvTotal");
                    Label lblGvDepositAmount = (Label)e.Row.FindControl("lblGvDepositAmount");
                    Label lblGvTotalRackRate = (Label)e.Row.FindControl("lblGvTotalRackRate");

                    decimal dcTax = Convert.ToDecimal("0.000000");
                    decimal dcRackRate = Convert.ToDecimal("0.000000");
                    decimal dcDeposit = Convert.ToDecimal("0.000000");
                    decimal dcTotalRackrate = Convert.ToDecimal("0.000000");

                    dcRackRate = Convert.ToDecimal(Convert.ToString(gvRoomTypeList.DataKeys[e.Row.RowIndex]["RackRate"]));
                    dcDeposit = Convert.ToDecimal(Convert.ToString(gvRoomTypeList.DataKeys[e.Row.RowIndex]["DepositAmount"]));
                    dcTotalRackrate = Convert.ToDecimal(Convert.ToString(gvRoomTypeList.DataKeys[e.Row.RowIndex]["TotalRackRate"]));

                    if (dsRatecardData != null && dsRatecardData.Tables.Count > 2 && dsRatecardData.Tables[2] != null && dsRatecardData.Tables[2].Rows.Count > 0)
                    {

                        for (int i = 0; i < dsRatecardData.Tables[2].Rows.Count; i++)
                        {
                            //decimal dcTax = Convert.ToDecimal("0.000000");
                            //decimal dcRackRate = Convert.ToDecimal("0.000000");
                            //decimal dcDeposit = Convert.ToDecimal("0.000000");
                            //decimal dcTotalRackrate = Convert.ToDecimal("0.000000");

                            if (dsRatecardData.Tables.Count > 3 && dsRatecardData.Tables[3] != null && dsRatecardData.Tables[3].Rows.Count > 0)
                            {
                                //dcRackRate = Convert.ToDecimal(Convert.ToString(gvRoomTypeList.DataKeys[e.Row.RowIndex]["RackRate"]));
                                //dcDeposit = Convert.ToDecimal(Convert.ToString(gvRoomTypeList.DataKeys[e.Row.RowIndex]["DepositAmount"]));
                                //dcTotalRackrate = Convert.ToDecimal(Convert.ToString(gvRoomTypeList.DataKeys[e.Row.RowIndex]["TotalRackRate"]));

                                DataRow[] drSelectTax = dsRatecardData.Tables[3].Select("TaxID = '" + Convert.ToString(dsRatecardData.Tables[2].Rows[i]["TaxID"]) + "' and '" + dcRackRate + "' >= MinAmount and '" + dcRackRate + "' <= MaxAmount");

                                if (drSelectTax.Length > 0)
                                {
                                    string strRate = Convert.ToString(drSelectTax[0]["TaxRate"]);
                                    string strIsFlat = Convert.ToString(drSelectTax[0]["IsTaxFlat"]);

                                    if (strRate != "" && strIsFlat != "")
                                    {
                                        if (Convert.ToBoolean(strIsFlat) == true)
                                        {
                                            dcTax += Convert.ToDecimal(strRate);
                                        }
                                        else if (Convert.ToBoolean(strIsFlat) == false)
                                        {
                                            decimal dcpercentage = Convert.ToDecimal(strRate);
                                            dcTax += Convert.ToDecimal((dcRackRate * dcpercentage) / 100);
                                        }
                                    }
                                }
                                else
                                    dcTax = Convert.ToDecimal("0.000000");
                            }
                            else
                                dcTax = Convert.ToDecimal("0.000000");
                        }
                    }

                    lblGvTotalRackRate.Text = Convert.ToString(dcTotalRackrate.ToString().Substring(0, dcTotalRackrate.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                    lblGvDepositAmount.Text = Convert.ToString(dcDeposit.ToString().Substring(0, dcDeposit.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                    lblGvTax.Text = Convert.ToString(dcTax.ToString().Substring(0, dcTax.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));

                    decimal dcDisplayTotal = Convert.ToDecimal("0.000000");
                    dcDisplayTotal = Convert.ToDecimal(dcDeposit + dcTotalRackrate + dcTax);
                    string strDisplayTotal = dcDisplayTotal.ToString().IndexOf('.') > -1 ? dcDisplayTotal.ToString() + "000000" : dcDisplayTotal.ToString() + ".000000";
                    lblGvTotal.Text = strDisplayTotal.ToString().Substring(0, strDisplayTotal.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
    }
}