using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Billing
{
    public partial class CtrlCheckOutVoucher : System.Web.UI.UserControl
    {
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Methods
        public void BindVoucherData(Guid ReservationID, Guid ReservationFolioID, decimal dcmlTotalAmountRefundOrPayment, string strRefundOrPayment, string strModeOfRefundOrPayment)
        {
            try
            {
                hdnReservationID.Value = ReservationID.ToString();
                hdnReservationFolioID.Value = ReservationFolioID.ToString();
                hdnDcmlTotalAmountRefundOrPayment.Value = dcmlTotalAmountRefundOrPayment.ToString();
                hdnStrRefundOrPayment.Value = strRefundOrPayment;
                hdnStrModeOfRefundOrPayment.Value = strModeOfRefundOrPayment;

                DataSet dsVoucherData = ReservationBLL.GetCheckOutVoucherData(ReservationID, clsSession.PropertyID, clsSession.CompanyID);
                if (dsVoucherData.Tables.Count > 0 && dsVoucherData.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsVoucherData.Tables[0].Rows[0];

                    ltrChkVchrGuestName.Text = Convert.ToString(dr["GuestFullName"]);
                    ltrChkVchrBookingNo.Text = Convert.ToString(dr["ReservationNo"]);
                    ltrChkVchrMobileNo.Text = Convert.ToString(clsCommon.GetMobileNo(Convert.ToString(dr["Phone1"])));
                    ltrChkVchrGuestEmail.Text = Convert.ToString(dr["Email"]);
                    ltrChkVchrRateCard.Text = Convert.ToString(dr["RateCardName"]);
                    ltrChkVchrRoomType.Text = Convert.ToString(dr["RoomTypeName"]);
                    ltrChkVchrRoomNo.Text = clsCommon.GetFormatedRoomNumber(Convert.ToString(dr["RoomNo"]));

                    if (dr["ActualCheckInDate"] != null && Convert.ToString(dr["ActualCheckInDate"]) != string.Empty)
                    {
                        DateTime dtCheckInDate = Convert.ToDateTime(Convert.ToString(dr["ActualCheckInDate"]));
                        ltrChkVchrCheckInDate.Text = Convert.ToString(dtCheckInDate.ToString(clsSession.DateFormat));
                    }

                    if (dr["ActualCheckOutDate"] != null && Convert.ToString(dr["ActualCheckOutDate"]) != string.Empty)
                    {
                        DateTime dtCheckOutDate = Convert.ToDateTime(Convert.ToString(dr["ActualCheckOutDate"]));
                        ltrChkVchrCheckOutDate.Text = Convert.ToString(dtCheckOutDate.ToString(clsSession.DateFormat));
                    }
                }

                decimal dcmlPayment = Convert.ToDecimal("0.000000");
                decimal dcmlRefundedPayment = Convert.ToDecimal("0.000000");
                decimal dcmlRefundedDeposit = Convert.ToDecimal("0.000000");
                decimal dcmlTransferedDeposit = Convert.ToDecimal("0.000000");
                DataSet dsSummary = FolioBLL.GetCheckOutTimeSummary(ReservationID, ReservationFolioID, clsSession.PropertyID, clsSession.CompanyID);
                if (dsSummary != null && dsSummary.Tables.Count > 0 && dsSummary.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsSummary.Tables[0].Rows.Count; i++)
                    {
                        decimal dcmlTemp = Convert.ToDecimal("0.000000");
                        DataRow dr = dsSummary.Tables[0].Rows[i];
                        if (Convert.ToString(dr["Description1"]).ToUpper() == "ROOM RENT")
                        {
                            if (dr["Debit"] != null && Convert.ToString(dr["Debit"]) != "")
                            {
                                dcmlTemp = Convert.ToDecimal(dr["Debit"].ToString());
                                lblChkOutVchrSmryRoomRentDebit.Text = dcmlTemp.ToString().Substring(0, dcmlTemp.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                            }
                            else
                                lblChkOutVchrSmryRoomRentDebit.Text = "0.00";
                        }
                        else if (Convert.ToString(dr["Description1"]).ToUpper() == "SERVICE CHARGE")
                        {
                            if (dr["Debit"] != null && Convert.ToString(dr["Debit"]) != "")
                            {
                                dcmlTemp = Convert.ToDecimal(dr["Debit"].ToString());
                                lblChkOutVchrSmryServicesChargeDebit.Text = dcmlTemp.ToString().Substring(0, dcmlTemp.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                            }
                            else
                                lblChkOutVchrSmryServicesChargeDebit.Text = "0.00";
                        }
                        else if (Convert.ToString(dr["Description1"]).ToUpper() == "PAYMENT")
                        {
                            if (dr["Credit"] != null && Convert.ToString(dr["Credit"]) != "")
                                dcmlPayment = Convert.ToDecimal(dr["Credit"].ToString());
                        }
                        else if (Convert.ToString(dr["Description1"]).ToUpper() == "REFUND PAYMENT")
                        {
                            if (dr["Debit"] != null && Convert.ToString(dr["Debit"]) != "")
                                dcmlRefundedPayment = Convert.ToDecimal(dr["Debit"].ToString());
                        }
                        else if (Convert.ToString(dr["Description1"]).ToUpper() == "REFUND DEPOSIT")
                        {
                            if (dr["Debit"] != null && Convert.ToString(dr["Debit"]) != "")
                                dcmlRefundedDeposit = Convert.ToDecimal(dr["Debit"].ToString());

                            lblChkOutVchrSmryDepositCredit.Text = dcmlRefundedDeposit.ToString().Substring(0, dcmlRefundedDeposit.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        }
                        else if (Convert.ToString(dr["Description1"]).ToUpper() == "DEPOSIT TRANSFER")
                        {
                            if (dr["Credit"] != null && Convert.ToString(dr["Credit"]) != "")
                                dcmlTransferedDeposit = Convert.ToDecimal(dr["Credit"].ToString());
                        }
                    }

                    //// Actual Payment = Paymend Amount + Transferred Amount ==> Transferred Amount = Total transfered Amount - Refunded Amount; b'cas Reunded Amount also make entry as transfered amount.
                    decimal dcmlActualPayment = dcmlPayment + (dcmlTransferedDeposit - dcmlRefundedDeposit);
                    lblChkOutVchrSmryPaymentCredit.Text = dcmlActualPayment.ToString().Substring(0, dcmlActualPayment.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    lblChkOutVchrSmryTotalDebit.Text = Convert.ToString(Convert.ToDecimal(lblChkOutVchrSmryRoomRentDebit.Text) + Convert.ToDecimal(lblChkOutVchrSmryServicesChargeDebit.Text));
                    lblChkOutVchrSmryTotalCredit.Text = Convert.ToString(Convert.ToDecimal(lblChkOutVchrSmryPaymentCredit.Text) + Convert.ToDecimal(lblChkOutVchrSmryDepositCredit.Text));

                    if (Convert.ToDecimal(lblChkOutVchrSmryTotalDebit.Text) > Convert.ToDecimal(lblChkOutVchrSmryTotalCredit.Text))
                    {
                        lblChkOutVchrSmryNetBalanceAmount.Text = Convert.ToString(Convert.ToDecimal(lblChkOutVchrSmryTotalDebit.Text) - Convert.ToDecimal(lblChkOutVchrSmryTotalCredit.Text));
                        lblChkOutVchrSmryTotalDebitOrCredit.Text = "Due";
                    }
                    else
                    {
                        lblChkOutVchrSmryNetBalanceAmount.Text = Convert.ToString(Convert.ToDecimal(lblChkOutVchrSmryTotalCredit.Text) - Convert.ToDecimal(lblChkOutVchrSmryTotalDebit.Text));
                        lblChkOutVchrSmryTotalDebitOrCredit.Text = "Credit";
                    }

                }
                else
                {
                    lblChkOutVchrSmryRoomRentDebit.Text = lblChkOutVchrSmryServicesChargeDebit.Text = lblChkOutVchrSmryPaymentCredit.Text = lblChkOutVchrSmryDepositCredit.Text = lblChkOutVchrSmryNetBalanceAmount.Text = "0.00";
                    lblChkOutVchrSmryTotalDebitOrCredit.Text = "Credit";
                }

                if (strRefundOrPayment.ToUpper() == "REFUND")
                {
                    //ltrChkOutVchrRefundOrPaymentHeader.Text = "Refund";
                    ltrChkOutVchrTotalAmountRefundOrPayment.Text = dcmlRefundedPayment.ToString().Substring(0, dcmlRefundedPayment.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    ltrChkOutVchrRefundedDeposits.Text = dcmlRefundedDeposit.ToString().Substring(0, dcmlRefundedDeposit.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    ////Don't delete this line b'cas it will use if mode of refund required.
                    //if(dcmlRefundedPayment > 0)
                    //    ltrChkOutVchrModeOfRefundOrPayment.Text = "(" + strModeOfRefundOrPayment + ")";

                    //if(dcmlRefundedDeposit > 0)
                    //    ltrChkOutVchrModeOfRefundDeposits.Text = "(" + strModeOfRefundOrPayment + ")";

                    decimal dcmlTemp1 = Convert.ToDecimal("0.000000");
                    decimal dcmlTotalRefund = dcmlTotalRefund = dcmlRefundedDeposit + dcmlRefundedPayment;
                    if (Convert.ToDecimal(lblChkOutVchrSmryNetBalanceAmount.Text) > dcmlTotalRefund)
                    {
                        dcmlTemp1 = Convert.ToDecimal(lblChkOutVchrSmryNetBalanceAmount.Text) - Convert.ToDecimal(dcmlRefundedDeposit + dcmlRefundedPayment);
                        ltrChkOutVchrBalanceAmountDueOrCredit.Text = dcmlTemp1.ToString().Substring(0, dcmlTemp1.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        ltrChkOutVchrDueOrCredit.Text = "Due";
                    }
                    else
                    {
                        dcmlTemp1 = dcmlTotalRefund - Convert.ToDecimal(lblChkOutVchrSmryNetBalanceAmount.Text);
                        ltrChkOutVchrBalanceAmountDueOrCredit.Text = dcmlTemp1.ToString().Substring(0, dcmlTemp1.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        ltrChkOutVchrDueOrCredit.Text = "Credit";
                    }

                    ltrChkOutVchrTotalRefund.Text = dcmlTotalRefund.ToString().Substring(0, dcmlTotalRefund.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
                else
                {
                    //ltrChkOutVchrRefundOrPaymentHeader.Text = "Payment";
                    //ltrChkOutVchrModeOfRefundOrPayment.Text = "(" + strModeOfRefundOrPayment + ")";
                    //ltrChkOutVchrTotalAmountRefundOrPayment.Text = dcmlTotalAmountRefundOrPayment.ToString().Substring(0, dcmlTotalAmountRefundOrPayment.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    //decimal dcmlTemp1 = Convert.ToDecimal("0.000000");
                    //if (Convert.ToDecimal(lblChkOutVchrSmryNetBalanceAmount.Text) > dcmlTotalAmountRefundOrPayment)
                    //{
                    //    dcmlTemp1 = Convert.ToDecimal(lblChkOutVchrSmryNetBalanceAmount.Text) - Convert.ToDecimal(dcmlTotalAmountRefundOrPayment);
                    //    ltrChkOutVchrBalanceAmountDueOrCredit.Text = dcmlTemp1.ToString().Substring(0, dcmlTemp1.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    //    ltrChkOutVchrDueOrCredit.Text = "Due";
                    //}
                    //else
                    //{
                    //    dcmlTemp1 = Convert.ToDecimal(dcmlTotalAmountRefundOrPayment) - Convert.ToDecimal(lblChkOutVchrSmryNetBalanceAmount.Text);
                    //    ltrChkOutVchrBalanceAmountDueOrCredit.Text = dcmlTemp1.ToString().Substring(0, dcmlTemp1.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    //    ltrChkOutVchrDueOrCredit.Text = "Credit";
                    //}

                    ltrChkOutVchrTotalAmountRefundOrPayment.Text = ltrChkOutVchrRefundedDeposits.Text = ltrChkOutVchrTotalRefund.Text = "0.00";

                    ////Make Balance AMount and Due/Credit same as Summary.
                    ltrChkOutVchrBalanceAmountDueOrCredit.Text = lblChkOutVchrSmryNetBalanceAmount.Text;
                    ltrChkOutVchrDueOrCredit.Text = lblChkOutVchrSmryTotalDebitOrCredit.Text;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void HidPrintVoucherButton()
        {
            btnCheckOutVoucherPrint.Visible = false;
        }
        #endregion
    }
}