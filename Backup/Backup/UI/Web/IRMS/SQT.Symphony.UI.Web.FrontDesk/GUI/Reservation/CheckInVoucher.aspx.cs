using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.GUI.Reservation
{
    public partial class CheckInVoucher : System.Web.UI.Page
    {
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPropertyAddress();

                if (Request["ReservationID"] != null && Convert.ToString(Request["ReservationID"]) != string.Empty)
                {
                    BindCheckInVoucherData(new Guid(Request["ReservationID"]));
                }
            }
        }
        #endregion

        #region Method
        public void BindCheckInVoucherData(Guid ReservationID)
        {
            try
            {
                DataSet dsVoucherData = ReservationBLL.GetCheckInVoucherData(ReservationID, clsSession.PropertyID, clsSession.CompanyID);

                litCurrentDate.Text = Convert.ToString(DateTime.Now.ToString(clsSession.DateFormat + " " + clsSession.TimeFormat));

                if (dsVoucherData.Tables.Count > 0 && dsVoucherData.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsVoucherData.Tables[0].Rows[0];

                    litChVchrGuestName.Text = Convert.ToString(dr["GuestFullName"]);
                    ltrChVchrReservationNo.Text = Convert.ToString(dr["ReservationNo"]);
                    litChVchrMobileNo.Text = Convert.ToString(clsCommon.GetMobileNo(Convert.ToString(dr["Phone1"])));
                    litChVchrEmail.Text = Convert.ToString(dr["Email"]);
                    ltrChVchrFolioNo.Text = Convert.ToString(dr["FolioNo"]);
                    ltrChVchrRateCard.Text = Convert.ToString(dr["RateCardName"]);
                    ltrChVchrRoomType.Text = Convert.ToString(dr["RoomTypeName"]);
                    ltrChVchrRoomNo.Text = clsCommon.GetFormatedRoomNumber(Convert.ToString(dr["RoomNo"]));
                    ltrChVchrAdultChild.Text = Convert.ToString(dr["Adults"]) + "/" + Convert.ToString(dr["Children"]);

                    DateTime dtCheckInDate = Convert.ToDateTime(Convert.ToString(dr["CheckInDate"]));
                    DateTime dtCheckOutDate = Convert.ToDateTime(Convert.ToString(dr["CheckOutDate"]));

                    ltrChVchrCheckInDate.Text = Convert.ToString(dtCheckInDate.ToString(clsSession.DateFormat));
                    ltrChVchrCheckOutDate.Text = Convert.ToString(dtCheckOutDate.ToString(clsSession.DateFormat));


                    //int day = 0;//bool b1 = false;//bool b2 = false;
                    //clsCommon.Reservation_GetTotalDays(null, dtCheckInDate, dtCheckOutDate, ref day, ref b1, ref b2);
                    //litReservationVoucherNoofNights.Text = Convert.ToString(day);

                    if (dsVoucherData.Tables.Count > 1 && dsVoucherData.Tables[1].Rows.Count > 0)
                        lblChVchrHousingRules.Text = Convert.ToString(dsVoucherData.Tables[1].Rows[0]["HousingRules"]);
                    else
                        lblChVchrHousingRules.Text = "";

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
                    decimal AmountToPayCheckInTime = Convert.ToDecimal("0.000000");
                    decimal TotalPaymentReceived = Convert.ToDecimal("0.000000");
                    decimal NetAmountToPay = Convert.ToDecimal("0.000000");
                    DataTable dtPaidAmountInfo = null;

                    //Common function to get payment related all details.
                    clsCommon.GetReservationPaymentInfo(ReservationID, ref RoomRent, ref Tax, ref TotalAmount, ref NoofDays, ref DepositAmount, ref PaidDeposit, ref TotalPaymentReceived, ref dtPaidAmountInfo, ref InfraServiceCharge, ref PaidInfraServiceCharge, ref FoodCharges, ref PaidFoodCharges, ref ElectricityCharges, ref PaidElectricityCharges);

                    string strRoomRent, strTax, strTotalAmount, strDepositAmount = "";

                    strRoomRent = RoomRent.ToString().Substring(0, RoomRent.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    strTax = Tax.ToString().Substring(0, Tax.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    strTotalAmount = TotalAmount.ToString().Substring(0, TotalAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    strDepositAmount = DepositAmount.ToString().Substring(0, DepositAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    ltrChVchrNoOfDays.Text = Convert.ToString(NoofDays);
                    ltrChVchrRoomRent.Text = Convert.ToString(strRoomRent);
                    ltrChVchrTaxes.Text = Convert.ToString(strTax);

                    //Reservation time total charges(Room Rent)
                    ltrChVchrTotalCharges.Text = Convert.ToString(strTotalAmount);
                    //Reservation time total Deposit
                    ltrChVchrDeposit.Text = Convert.ToString(strDepositAmount);

                    //Reservation time total Amount payable(Room Rent + Deposit)
                    TotalAmountPayable = TotalAmount + DepositAmount;
                    ltrChVchrTotalAmount.Text = TotalAmountPayable.ToString().Substring(0, TotalAmountPayable.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    //Total Deposit received
                    ltrChVchrPaidAmount.Text = PaidDeposit.ToString().Substring(0, PaidDeposit.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    if (TotalAmountPayable >= PaidDeposit)
                    {
                        NetAmountToPay = TotalAmountPayable - PaidDeposit;
                        ltrChVchrAmountToPay.Text = NetAmountToPay.ToString().Substring(0, NetAmountToPay.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                }
                else
                {
                    //litReservationVoucherGuestName.Text = litReservationVoucherBookingNo.Text = litReservationVoucherMobileNo.Text = litReservationVoucherEmail.Text = litReservationVoucherCheckinDate.Text = litReservationVoucherCheckoutDate.Text = litReservationVoucherNoofNights.Text = litReservationVoucherNoofGuests.Text = litReservationVoucherRateCard.Text = litReservationVoucherRoomType.Text = litReservationVoucherBookingStatus.Text = litReservationVoucherValidUpto.Text = "";
                    //litDisplayReservationVoucherCheckInTime.Text = litDisplayReservationVoucherCheckOutTime.Text = "";
                    //lblDisplayCancellationPolicy.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void BindPropertyAddress()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
    }
}