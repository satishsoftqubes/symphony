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
using AjaxControlToolkit;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class CtrlCommonRoomAvailabilityChart : System.Web.UI.UserControl
    {
        #region Property and Variables

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

        public ModalPopupExtender ucMpeRoomAvailabilityChart
        {
            get { return this.mpeRoomAvailabilityChart; }
        }

        public TextBox uctxtSearchFromDate
        {
            get { return this.txtSearchFromDate; }
        }

        public TextBox uctxtSearchToDate
        {
            get { return this.txtSearchToDate; }
        }

        public DropDownList ucddlSearchRoomType
        {
            get { return this.ddlSearchRoomType; }
        }

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        #endregion Page Load

        #region Private Methode

        public void LoadDefaultValue()
        {
            try
            {   
                hfDateFormat.Value = clsSession.DateFormat;
                BindRoomType();                
                BindStandardCheckInCheckOutTime();
                dvChart.Visible = false;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindRoomReservationChart()
        {
            try
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
                                    strBldr.Append("<td class='roomname' style=\"cursor:pointer;\");\">" + (GetRoomNumber(Convert.ToString(dsRoomData.Tables[0].Rows[i - 1]["RoomNumber"]))) + "</td>");
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
                                                    strCalss = "";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
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

                    ddlSearchRoomType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
                }
                else
                    ddlSearchRoomType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private string GetRoomNumber(string strRoomNumber)
        {
            string strRoomNo = string.Empty;

            if (strRoomNumber != string.Empty)
            {
                string[] str = strRoomNumber.Split('|');
                if (str.Length > 0)
                    strRoomNo = str[0] + "(" + str[1] + ")";
            }

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

        #endregion

        #region Control Event

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    mpeRoomAvailabilityChart.Show();
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
               
        #endregion Control Event        
    }
}