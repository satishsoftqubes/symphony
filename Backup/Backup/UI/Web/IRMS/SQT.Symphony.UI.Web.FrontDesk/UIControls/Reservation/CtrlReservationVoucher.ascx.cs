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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Collections;
using System.Configuration;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlReservationVoucher : System.Web.UI.UserControl
    {
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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BindReservationVoucherData()
        {
            if (this.ReservationID != Guid.Empty)
            {
                hdnReservationID.Value = Convert.ToString(this.ReservationID);

                DataSet dsVoucherData = ReservationBLL.GetReservationVoucherData(this.ReservationID, clsSession.PropertyID, clsSession.CompanyID);

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
                            litReservationVoucherValidUpto.Text = Convert.ToString(dtCheckInDate.AddDays(addDays).ToString(clsSession.DateFormat));
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
                    int FoodCharges = 0;
                    int ElectricityCharges = 0;
                    int PaidInfraServiceCharge = 0;
                    int PaidFoodCharges = 0;
                    int PaidElectricityCharges = 0;
                    decimal TotalAmountPayable = Convert.ToDecimal("0.000000");
                    decimal DueBalanceAmount = Convert.ToDecimal("0.000000");
                    decimal TotalPaymentReceived = Convert.ToDecimal("0.000000");
                    DataTable dtPaidAmountInfo = null;

                    clsCommon.GetReservationPaymentInfo(this.ReservationID, ref RoomRent, ref Tax, ref TotalAmount, ref NoofDays, ref DepositAmount, ref PaidDeposit, ref TotalPaymentReceived, ref dtPaidAmountInfo, ref InfraServiceCharge, ref PaidInfraServiceCharge, ref FoodCharges, ref PaidFoodCharges, ref ElectricityCharges, ref PaidElectricityCharges);

                    string strRoomRent, strTax, strTotalAmount, strDepositAmount, strTotalAmountPayable, strTotalAmountReceived = "";

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
                    lblElectricityCharge.Text = Convert.ToString(ElectricityCharges) + ".00";

                    lblDisplayTotalAmount.Text = Convert.ToString(strTotalAmount);
                    lblDisplayDepositAmount.Text = Convert.ToString(strDepositAmount);

                    lblTotalAmountPayable.Text = lblDisplayAmount.Text = Convert.ToString(strTotalAmountPayable);

                    strTotalAmountReceived = TotalPaymentReceived.ToString().Substring(0, TotalPaymentReceived.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    lblDisplayTotalAmountReceived.Text = Convert.ToString(strTotalAmountReceived);

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
        private string BindPropertyAddress()
        {
            DataSet dsPropertyAddress = PropertyBLL.GetPropertyAddressInfo(clsSession.PropertyID, clsSession.CompanyID);
            if (dsPropertyAddress != null && dsPropertyAddress.Tables.Count > 0 && dsPropertyAddress.Tables[0].Rows.Count > 0)
            {
                return Convert.ToString(dsPropertyAddress.Tables[0].Rows[0]["FullAddress"]);
            }
            else
            {
                return string.Empty;
            }
        }
        protected void btnsendEmail_Click(object sender, EventArgs e)
        {
            SendMailTo(litReservationVoucherEmail.Text.Trim().ToLower(), "Reservation Voucher", "ReservationVoucher", "NORMALRESERVATION");
        }
        public void SendMailTo(string EmailAddress, string subjectForEmail, string FileNameToSave, string ReservationType)
        {
            if (EmailAddress != null && EmailAddress != "")
            {
                Guid? companyID = null;
                Guid? propertyID = null;

                if (Convert.ToString(clsSession.CompanyID) != string.Empty && clsSession.CompanyID != Guid.Empty)
                {
                    companyID = clsSession.CompanyID;
                }


                if (Convert.ToString(clsSession.PropertyID) != string.Empty && Convert.ToString(clsSession.PropertyID) != Guid.Empty.ToString())
                {
                    propertyID = clsSession.PropertyID;
                }
                else
                {
                    //Company Administrator has no PropertyID, So to use default property's ids.
                    propertyID = new Guid("BBB0707B-AB26-4B6D-A5B5-C33B4A774ABC");
                    companyID = new Guid("AAA0707A-2C6A-4C39-896C-B3025CF8BD16");
                }

                //Get Email Template info. First table contains Email template and second table contains it's Email Configuration info.
                DataSet dsSearchEmailTemplate = EMailTemplatesBLL.GetDataByProperty(propertyID, companyID, "Reservation Voucher");
                if (dsSearchEmailTemplate != null && dsSearchEmailTemplate.Tables.Count > 0)
                {
                    string strPrimoryDomainName = string.Empty;
                    string strUserName = string.Empty;
                    string strPassword = string.Empty;
                    string strSmtpAddress = string.Empty;

                    //If second table cotains data, then use this SMTP detail.
                    if (dsSearchEmailTemplate.Tables.Count > 1 && dsSearchEmailTemplate.Tables[1].Rows.Count > 0)
                    {
                        strPrimoryDomainName = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["PrimoryDomainName"]);
                        strUserName = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["UserName"]);
                        strPassword = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["Password"]);
                        strSmtpAddress = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["SMTPHost"]);
                    }
                    else
                    {
                        // else use Property's default smtp detail.
                        PropertyConfiguration ObjPrtConfig = PropertyConfigurationBLL.GetByCmpnAndPrpt(companyID, propertyID);
                        if (ObjPrtConfig != null)
                        {
                            strPrimoryDomainName = Convert.ToString(ObjPrtConfig.PrimoryDomainName);
                            strUserName = Convert.ToString(ObjPrtConfig.UserName);
                            strPassword = Convert.ToString(ObjPrtConfig.Password);
                            strSmtpAddress = Convert.ToString(ObjPrtConfig.SmtpAddress);
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                            MessageBox.Show("Sorry for inconvenience, system can't send mail. Please try again later.");
                            return;
                        }
                    }

                    //if smtp(either from template's Email config or from property's email config) exist, then send mail.
                    if (strPrimoryDomainName != string.Empty && strUserName != string.Empty && strPassword != string.Empty && strSmtpAddress != string.Empty)
                    {
                        if (dsSearchEmailTemplate.Tables[0] != null && dsSearchEmailTemplate.Tables[0].Rows.Count != 0)
                        {
                            string strHTML = "";
                            if (ReservationType.Trim().ToUpper().Equals("COMPLEMENTORYRESERVATION") && File.Exists(Server.MapPath("~/EmailTemplate/ComplementoryReservationVoucher.htm")))
                            {
                                strHTML = File.ReadAllText(Server.MapPath("~/EmailTemplate/ComplementoryReservationVoucher.htm"));
                                strHTML = strHTML.Replace("$PROPERTYADDRESS$", BindPropertyAddress());
                                strHTML = strHTML.Replace("$CURRENTDATE$", litCurrentDate.Text);
                                strHTML = strHTML.Replace("$NAME$", litReservationVoucherGuestName.Text);
                                strHTML = strHTML.Replace("$BOOKINGNO$", litReservationVoucherBookingNo.Text);


                                strHTML = strHTML.Replace("$MOBILENO$", litReservationVoucherMobileNo.Text);
                                strHTML = strHTML.Replace("$EMAILID$", litReservationVoucherEmail.Text);
                                strHTML = strHTML.Replace("$CHECKINDATE$", litReservationVoucherCheckinDate.Text);

                                strHTML = strHTML.Replace("$CHECKOUTDATE$", litReservationVoucherCheckoutDate.Text);
                                strHTML = strHTML.Replace("$NOOFNIGHT$", litReservationVoucherNoofNights.Text);
                                strHTML = strHTML.Replace("$NOOFGUEST$", litReservationVoucherNoofGuests.Text);

                                strHTML = strHTML.Replace("$RATECARD$", litReservationVoucherRateCard.Text);
                                strHTML = strHTML.Replace("$ROOMTYPE$", litReservationVoucherRoomType.Text);
                                strHTML = strHTML.Replace("$BOOKINGSTATUS$", litReservationVoucherBookingStatus.Text);
                                strHTML = strHTML.Replace("$NONRR$", lblDisplayNoOfDays.Text);

                                // Get Investor related Information 
                                if (this.ReservationID != null && this.ReservationID != Guid.Empty)
                                {
                                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservationForInvID = new SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation();
                                    objReservationForInvID = ReservationBLL.GetByPrimaryKey(this.ReservationID);
                                    SrvcRefInvestorList.InvestorListSoapClient clnt = new SrvcRefInvestorList.InvestorListSoapClient();

                                    if (objReservationForInvID.RefInvestorID != null && Convert.ToString(objReservationForInvID.RefInvestorID) != string.Empty)
                                    {
                                        DataSet ds = clnt.GetInvestorListInDataSet(new Guid(Convert.ToString(objReservationForInvID.RefInvestorID)));
                                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                        {
                                            strHTML = strHTML.Replace("$INVNAME$", Convert.ToString(ds.Tables[0].Rows[0]["InvFullNameForResVoucher"]));
                                            strHTML = strHTML.Replace("$INVEMAILID$", Convert.ToString(ds.Tables[0].Rows[0]["InvResVoucherEmail"]));
                                        }
                                        else
                                        {
                                            strHTML = strHTML.Replace("$INVNAME$", "");
                                            strHTML = strHTML.Replace("$INVEMAILID$", "");
                                        }
                                    }
                                    else
                                    {
                                        strHTML = strHTML.Replace("$INVNAME$", "");
                                        strHTML = strHTML.Replace("$INVEMAILID$", "");
                                    }
                                }
                                else
                                {
                                    strHTML = strHTML.Replace("$INVNAME$", "");
                                    strHTML = strHTML.Replace("$INVEMAILID$", "");
                                }
                            }
                            else if (ReservationType.Trim().ToUpper().Equals("NORMALRESERVATION") && File.Exists(Server.MapPath("~/EmailTemplate/ReservationVoucher.htm")))
                            {
                                strHTML = File.ReadAllText(Server.MapPath("~/EmailTemplate/ReservationVoucher.htm"));
                                strHTML = strHTML.Replace("$PROPERTYADDRESS$", BindPropertyAddress());
                                strHTML = strHTML.Replace("$CURRENTDATE$", litCurrentDate.Text);
                                strHTML = strHTML.Replace("$NAME$", litReservationVoucherGuestName.Text);
                                strHTML = strHTML.Replace("$BOOKINGNO$", litReservationVoucherBookingNo.Text);


                                strHTML = strHTML.Replace("$MOBILENO$", litReservationVoucherMobileNo.Text);
                                strHTML = strHTML.Replace("$EMAILID$", litReservationVoucherEmail.Text);
                                strHTML = strHTML.Replace("$CHECKINDATE$", litReservationVoucherCheckinDate.Text);

                                strHTML = strHTML.Replace("$CHECKOUTDATE$", litReservationVoucherCheckoutDate.Text);
                                strHTML = strHTML.Replace("$NOOFNIGHT$", litReservationVoucherNoofNights.Text);
                                strHTML = strHTML.Replace("$NOOFGUEST$", litReservationVoucherNoofGuests.Text);

                                strHTML = strHTML.Replace("$RATECARD$", litReservationVoucherRateCard.Text);
                                strHTML = strHTML.Replace("$ROOMTYPE$", litReservationVoucherRoomType.Text);
                                strHTML = strHTML.Replace("$BOOKINGSTATUS$", litReservationVoucherBookingStatus.Text);
                                strHTML = strHTML.Replace("$VALIDUPTO$", litReservationVoucherValidUpto.Text);
                                strHTML = strHTML.Replace("$NONRR$", lblDisplayNoOfDays.Text);
                                strHTML = strHTML.Replace("$AMTRR$", lblDisplayRoomRent.Text);
                                strHTML = strHTML.Replace("$NONTAX$", "-");

                                strHTML = strHTML.Replace("$AMTTAX$", lblDisplayTax.Text);
                                strHTML = strHTML.Replace("$NONTOC$", "-");
                                strHTML = strHTML.Replace("$AMTTC$", lblDisplayTotalAmount.Text);

                                strHTML = strHTML.Replace("$NONDEP$", "-");
                                strHTML = strHTML.Replace("$AMTDEP$", lblDisplayDepositAmount.Text);
                                strHTML = strHTML.Replace("$TOTAL$", lblTotalAmountPayable.Text);


                                strHTML = strHTML.Replace("$AMTPR$", lblDisplayAmount.Text);
                                strHTML = strHTML.Replace("$TOTALAMTREC$", lblDisplayTotalAmountReceived.Text);
                                strHTML = strHTML.Replace("$BALANCEAMT$", lblDisplayBalanceAmountDue.Text);

                                strHTML = strHTML.Replace("$CANCELPOLICY$", lblDisplayCancellationPolicy.Text);

                                strHTML = strHTML.Replace("$VOUCHECKIN$", litDisplayReservationVoucherCheckInTime.Text);
                                strHTML = strHTML.Replace("$VOUCHECKOUT$", litDisplayReservationVoucherCheckOutTime.Text);

                                strHTML = strHTML.Replace("$RESPOLICY$", lblDisplayReservationPolicy.Text);
                                strHTML = strHTML.Replace("$BALANCEAMTLABEL$", litDispBalanceAmount.Text);
                            }
                            else
                            {
                                strHTML = string.Empty;
                            }
                            if (strHTML != "" && strHTML != string.Empty)
                            {
                                // Export to pdf document

                                Document pdfDoc = new Document();

                                pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                                if (!Directory.Exists(Server.MapPath("~/PDFs")))
                                    Directory.CreateDirectory(Server.MapPath("~/PDFs"));


                                string strfilename = Server.MapPath("~/PDFs/" + FileNameToSave + ".pdf");
                                if (File.Exists(strfilename))
                                    File.Delete(strfilename);

                                PdfWriter.GetInstance(pdfDoc, new FileStream(strfilename, FileMode.Create));
                                pdfDoc.Open();
                                var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(strHTML), null);
                                // Add a Logo For reservation voucher 
                                iTextSharp.text.Image imgUniLogo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/images/Logo - registerd_small.jpg"));
                                imgUniLogo.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                                pdfDoc.Add(imgUniLogo);
                                //Get each array values from parsed elements and add to the PDF document
                                foreach (var htmlElement in parsedHtmlElements)
                                {
                                    pdfDoc.Add(htmlElement as IElement);
                                }
                                pdfDoc.Close();
                                pdfDoc.CloseDocument();
                                SentMail.SendMail(strPrimoryDomainName, strUserName, strPassword, strSmtpAddress, EmailAddress, subjectForEmail, strHTML, strfilename);

                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                                MessageBox.Show("Sorry for inconvenience, system can't send mail. Please try again later.");
                                return;
                            }
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                            MessageBox.Show("Sorry for inconvenience, system can't send mail. Please try again later.");
                            return;
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Sorry for inconvenience, system can't send mail. Please try again later.");
                        return;

                    }
                }

            }
        }
    }
}