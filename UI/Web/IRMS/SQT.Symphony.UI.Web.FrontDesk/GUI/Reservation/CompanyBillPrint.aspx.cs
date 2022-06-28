using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation
{
    public partial class CompanyBillPrint : System.Web.UI.Page
    {
        #region Property and Variables
        public Guid ReservationFolioID
        {
            get
            {
                return ViewState["ReservationFolioID"] != null ? new Guid(Convert.ToString(ViewState["ReservationFolioID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ReservationFolioID"] = value;
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
        #endregion

        #region Page event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["ReservationID"] != null && Convert.ToString(Request["ReservationID"]) != string.Empty)
                {
                    this.ReservationID = new Guid(Convert.ToString(Request["ReservationID"]));
                }

                LoadData();
            }
        }
        #endregion

        #region Private Method
        public void LoadData()
        {
            Company objCmpData = CompanyBLL.GetByPrimaryKey(clsSession.CompanyID);
            if (objCmpData != null)
            {
                ltrUniworldMobileNo.Text = Convert.ToString(objCmpData.PrimaryPhone);
                ltrUniworldURL.Text = Convert.ToString(objCmpData.PrimaryUrl);
                ltrUniworldEmail.Text = Convert.ToString(objCmpData.PrimaryEmail);
                ltrUniworldAddress.Text = Convert.ToString(objCmpData.PrimaryAdd1.Replace("\r\n", string.Empty));
            }

            DataSet dsMain = InvoiceBLL.GetRPTInvoiceReservationDetail(null, this.ReservationID, this.ReservationFolioID);
            if (dsMain != null && dsMain.Tables[0].Rows.Count > 0)
            {
                DataRow dr = dsMain.Tables[0].Rows[0];

                ltrBillNo.Text = Convert.ToString(dr["InvoiceNo"]);
                ltrTodaysDate.Text = DateTime.Now.ToString(clsSession.DateFormat);
                ltrReservationNo.Text = Convert.ToString(dr["ReservationNo"]);
                ltrPax.Text = Convert.ToString(dr["GuestNo"]);
                ltrArrivalDate.Text = Convert.ToDateTime(Convert.ToString(dr["CheckInDate"])).ToString(clsSession.DateFormat);
                ltrDepartureDate.Text = Convert.ToDateTime(Convert.ToString(dr["CheckOutDate"])).ToString(clsSession.DateFormat);
                ltrNoOfNights.Text = ltrNoOfNightsInGrid.Text = Convert.ToString(dr["Duration"]);
                ltrRoomNo.Text = Convert.ToString(dr["RoomNo"]);
                ltrCheckInTime.Text = Convert.ToDateTime(Convert.ToString(dr["CheckInDate"])).ToString(clsSession.TimeFormat);
                ltrCheckOutTime.Text = Convert.ToDateTime(Convert.ToString(dr["CheckOutDate"])).ToString(clsSession.TimeFormat);
                ltrGuestName.Text = Convert.ToString(dr["Guest_Name"]);
                ltrBillingInstruction.Text = Convert.ToString(dr["BillingInst"]).ToUpper() == "FULL BILLING TO COMPANY" ? "Bill to Company" : Convert.ToString(dr["BillingInst"]);
                ltrRoomType.Text = Convert.ToString(dr["RoomTypeName"]);
            }

            DataSet dsInvoiceInfo = ReservationBLL.SelectReservationInfo4CompanyInvoice(this.ReservationID);
            if (dsInvoiceInfo.Tables.Count > 1 && dsInvoiceInfo.Tables[1].Rows.Count > 0)
            {
                ltrCompanyName.Text = Convert.ToString(dsInvoiceInfo.Tables[1].Rows[0]["CompanyName"]);
                ltrCompanyAddress.Text = Convert.ToString(dsInvoiceInfo.Tables[1].Rows[0]["Add1"]) + " " + Convert.ToString(dsInvoiceInfo.Tables[1].Rows[0]["Add2"]);
            }

            DataSet dsInvoiceDetial = InvoiceBLL.GetRPTInvoiceBillSummary4CompanyInvoice(this.ReservationID);
            if (dsInvoiceDetial != null && dsInvoiceDetial.Tables[0].Rows.Count > 0)
            {
                DataRow dr = dsInvoiceDetial.Tables[0].Rows[0];

                ltrRatePerNight.Text = Convert.ToString(dr["RoomRatePerNight"]);
                ltrTotalRoomRate.Text = Convert.ToString(dr["TotalRoomRate"]);
                ltrLuxuryTax.Text = Convert.ToString(dr["LuxuryTax"]);
                ltrTotalBillAmount.Text = Convert.ToString(dr["TotalBillAmount"]);
            }
        }
        #endregion
    }
}