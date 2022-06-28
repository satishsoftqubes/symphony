using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation
{
    public partial class RegistrationVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {   
                BindReservationVoucherData();
                BindPropertyAddress();
            }
        }

        private void BindPropertyAddress()
        {
            DataSet dsPropertyAddress = PropertyBLL.GetPropertyAddressInfo(clsSession.PropertyID, clsSession.CompanyID);
            lblPropertyaddress.Text = "";
            if (dsPropertyAddress != null && dsPropertyAddress.Tables.Count > 0 && dsPropertyAddress.Tables[0].Rows.Count > 0)
            {
                lblPropertyaddress.Text = dsPropertyAddress.Tables[0].Rows[0]["FullAddress"].ToString();
            }
            else
            {
                lblPropertyaddress.Text = "";
            }
        }
        public void BindReservationVoucherData()
        {
            if (Request.QueryString["id"] != null)
            {
                DataSet dsVoucherData = ReservationBLL.GetReservationVoucherData(new Guid(Request.QueryString["id"]), clsSession.PropertyID, clsSession.CompanyID);

                litCurrentDate.Text = Convert.ToString(DateTime.Now.ToString(clsSession.DateFormat + " " + clsSession.TimeFormat));

                if (dsVoucherData.Tables.Count > 0 && dsVoucherData.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsVoucherData.Tables[0].Rows[0];

                    litReservationVoucherGuestName.Text = Convert.ToString(dr["GuestFullName"]);
                    litReservationVoucherBookingNo.Text = Convert.ToString(dr["ReservationNo"]);
                    litReservationVoucherMobileNo.Text = Convert.ToString(clsCommon.GetMobileNo(Convert.ToString(dr["Phone1"])));
                    litReservationVoucherEmail.Text = Convert.ToString(dr["Email"]);

                    DateTime dtCheckInDate = Convert.ToDateTime(Convert.ToString(dr["CheckInDate"]));
                    DateTime dtCheckOutDate = Convert.ToDateTime(Convert.ToString(dr["CheckOutDate"]));

                    litReservationVoucherCheckinDate.Text = Convert.ToString(dtCheckInDate.ToString(clsSession.DateFormat));
                    litReservationVoucherCheckoutDate.Text = Convert.ToString(dtCheckOutDate.ToString(clsSession.DateFormat));

                    int day = 0;
                    bool b1 = false;
                    bool b2 = false;

                    clsCommon.Reservation_GetTotalDays(null, dtCheckInDate, dtCheckOutDate, ref day, ref b1, ref b2);

                    litReservationVoucherNoofNights.Text = Convert.ToString(day);
                    litReservationVoucherNoofGuests.Text = Convert.ToString(dr["NoofGuests"]);
                    litReservationVoucherRateCard.Text = Convert.ToString(dr["RateCardName"]);
                    litReservationVoucherRoomType.Text = Convert.ToString(dr["RoomTypeName"]);
                    litReservationVoucherBookingStatus.Text = Convert.ToString(dr["Status"]);

                    if (dsVoucherData.Tables[1] != null && dsVoucherData.Tables[1].Rows.Count > 0)
                    {
                        litReservationVoucherValidUpto.Visible = litValidUpto.Visible = true;

                        DataRow dr1 = dsVoucherData.Tables[1].Rows[0];

                        if (Convert.ToString(dr["SymphonyValue"]) == "27")
                        {
                            int addDays = Convert.ToInt32(Convert.ToString(dr1["ProvisionalReservationDayLimit"]));
                            litReservationVoucherValidUpto.Text = Convert.ToString(dtCheckInDate.AddDays(addDays));
                        }
                        else
                        {
                            litReservationVoucherValidUpto.Text = "";
                            litReservationVoucherValidUpto.Visible = litValidUpto.Visible = false;
                        }

                        DateTime dtCheckInTime = Convert.ToDateTime(Convert.ToString(dr1["CheckInTime"]));
                        DateTime dtCheckOutTime = Convert.ToDateTime(Convert.ToString(dr1["CheckOutTime"]));

                        litDisplayReservationVoucherCheckInTime.Text = Convert.ToString(dtCheckInTime.ToString(clsSession.TimeFormat));
                        litDisplayReservationVoucherCheckOutTime.Text = Convert.ToString(dtCheckOutTime.ToString(clsSession.TimeFormat));

                        lblDisplayReservationPolicy.Text = Convert.ToString(dr1["ReservationPolicy"]);
                    }
                    else
                    {
                        litReservationVoucherValidUpto.Text = litDisplayReservationVoucherCheckInTime.Text = litDisplayReservationVoucherCheckOutTime.Text = lblDisplayReservationPolicy.Text = "";
                        litReservationVoucherValidUpto.Visible = litValidUpto.Visible = false;
                    }

                    if (dsVoucherData.Tables[2] != null && dsVoucherData.Tables[2].Rows.Count > 0)
                        lblDisplayCancellationPolicy.Text = Convert.ToString(dsVoucherData.Tables[2].Rows[0]["PolicyNote"]);
                    else
                        lblDisplayCancellationPolicy.Text = "";

                    //Reservation Payment Calculaltion

                    decimal RoomRent = Convert.ToDecimal("0.000000");
                    decimal Tax = Convert.ToDecimal("0.000000");
                    decimal TotalAmount = Convert.ToDecimal("0.000000");
                    int NoofDays = 0;
                    decimal DepositAmount = Convert.ToDecimal("0.000000");
                    decimal PaidDeposit = Convert.ToDecimal("0.000000");
                    int InfraServiceCharge = 0;
                    int PaidInfraServiceCharge = 0;
                    int FoodCharges = 0;
                    int PaidFoodCharges = 0;
                    int ElectricityCharges = 0;
                    int PaidElectricityCharges = 0;
                    decimal TotalAmountPayable = Convert.ToDecimal("0.000000");
                    decimal DueBalanceAmount = Convert.ToDecimal("0.000000");
                    decimal TotalPaymentReceived = Convert.ToDecimal("0.000000");
                    DataTable dtPaidAmountInfo = null;

                    clsCommon.GetReservationPaymentInfo(new Guid(Request.QueryString["id"]), ref RoomRent, ref Tax, ref TotalAmount, ref NoofDays, ref DepositAmount, ref PaidDeposit, ref TotalPaymentReceived, ref dtPaidAmountInfo, ref InfraServiceCharge, ref PaidInfraServiceCharge, ref FoodCharges, ref PaidFoodCharges, ref ElectricityCharges, ref PaidElectricityCharges);

                    string strRoomRent, strTax, strTotalAmount, strDepositAmount, strTotalAmountPayable, strTotalAmountReceived, strDueBalanceAmount = "";

                    strRoomRent = RoomRent.ToString().Substring(0, RoomRent.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    strTax = Tax.ToString().Substring(0, Tax.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    strTotalAmount = TotalAmount.ToString().Substring(0, TotalAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    strDepositAmount = DepositAmount.ToString().Substring(0, DepositAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    TotalAmountPayable = TotalAmount + DepositAmount;
                    strTotalAmountPayable = TotalAmountPayable.ToString().Substring(0, TotalAmountPayable.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    lblDisplayNoOfDays.Text = Convert.ToString(NoofDays);
                    lblDisplayRoomRent.Text = Convert.ToString(strRoomRent);
                    lblDisplayTax.Text = Convert.ToString(strTax);
                    lblInfraServiceCharges.Text = Convert.ToString(InfraServiceCharge) + ".00";
                    lblFoodCharges.Text = Convert.ToString(FoodCharges) + ".00";
                    lblElectricityCharges.Text = Convert.ToString(ElectricityCharges) + ".00";

                    lblDisplayTotalAmount.Text = Convert.ToString(strTotalAmount);
                    lblDisplayDepositAmount.Text = Convert.ToString(strDepositAmount);

                    lblTotalAmountPayable.Text = lblDisplayAmount.Text = Convert.ToString(strTotalAmountPayable);

                    strTotalAmountReceived = TotalPaymentReceived.ToString().Substring(0, TotalPaymentReceived.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    lblDisplayTotalAmountReceived.Text = Convert.ToString(strTotalAmountReceived);

                    DueBalanceAmount = TotalAmountPayable - TotalPaymentReceived;
                    lblDisplayBalanceAmountDue.Text = DueBalanceAmount.ToString().Substring(0, DueBalanceAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    if (Convert.ToDecimal(lblDisplayTotalAmountReceived.Text) > Convert.ToDecimal(lblTotalAmountPayable.Text) || Convert.ToDecimal(lblDisplayTotalAmountReceived.Text) == Convert.ToDecimal(lblTotalAmountPayable.Text))
                    {
                        DueBalanceAmount = TotalPaymentReceived - TotalAmountPayable;
                        lblDisplayBalanceAmountDue.Text = DueBalanceAmount.ToString().Substring(0, DueBalanceAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        litDispBalanceAmount.Text = "Balance Amount(Credit)";
                    }
                    else
                    {
                        DueBalanceAmount = TotalAmountPayable - TotalPaymentReceived;
                        lblDisplayBalanceAmountDue.Text = DueBalanceAmount.ToString().Substring(0, DueBalanceAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        litDispBalanceAmount.Text = "Balance Amount(Due)";
                    }
                }
                else
                {
                    litReservationVoucherGuestName.Text = litReservationVoucherBookingNo.Text = litReservationVoucherMobileNo.Text = litReservationVoucherEmail.Text = litReservationVoucherCheckinDate.Text = litReservationVoucherCheckoutDate.Text = litReservationVoucherNoofNights.Text = litReservationVoucherNoofGuests.Text = litReservationVoucherRateCard.Text = litReservationVoucherRoomType.Text = litReservationVoucherBookingStatus.Text = litReservationVoucherValidUpto.Text = "";
                    litDisplayReservationVoucherCheckInTime.Text = litDisplayReservationVoucherCheckOutTime.Text = "";
                    lblDisplayCancellationPolicy.Text = "";
                }
            }
        }
    }
}