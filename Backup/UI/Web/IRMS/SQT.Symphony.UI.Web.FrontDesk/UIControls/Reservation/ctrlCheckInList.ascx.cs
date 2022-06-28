using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Globalization;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Collections;
using System.Configuration;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class ctrlCheckInList : System.Web.UI.UserControl
    {
        #region Property and Variable
        public bool IsMessage = false;
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
        #endregion Property and variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();

                mvCheckInForm.ActiveViewIndex = 0;
                LoadDefaultValue();
            }
        }

        #endregion Page Load

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "CheckInList.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");


        }
        protected void LoadDefaultValue()
        {
            try
            {
                BindReservationGrid();
                BindBreadCrumb();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
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

            //DataRow dr1 = dt.NewRow();
            //dr1["NameColumn"] = "Uniworld E-City";
            //dt.Rows.Add(dr1);

            //DataRow dr4 = dt.NewRow();
            //dr4["NameColumn"] = "Reservation";
            //dr4["Link"] = "";
            //dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Check In";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);


            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Arrival List";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindReservationGrid()
        {
            try
            {
                string strName = null;
                string strMobileNo = null;
                string strReservationNo = null;
                DateTime? StartDate = null;
                DateTime? EndDate = null;
                string strSymphonyValue = "";

                if (txtSearchName.Text.Trim() != "")
                    strName = Convert.ToString(txtSearchName.Text.Trim());

                if (txtMobileNo.Text.Trim() != "")
                    strMobileNo = Convert.ToString(txtMobileNo.Text.Trim());

                if (txtSearcReservationNo.Text.Trim() != "")
                    strReservationNo = "RES#" + Convert.ToString(txtSearcReservationNo.Text.Trim());

                if (Convert.ToString(rblList.SelectedValue) == "Day")
                    StartDate = EndDate = DateTime.Now;
                else if (Convert.ToString(rblList.SelectedValue) == "Week")
                {
                    StartDate = DateTime.Now;
                    EndDate = DateTime.Now.AddDays(6);
                }
                else if (Convert.ToString(rblList.SelectedValue) == "Month")
                {
                    StartDate = DateTime.Now;
                    EndDate = DateTime.Now.AddDays(30);
                }
                else if (Convert.ToString(rblList.SelectedValue) == "All")
                    StartDate = EndDate = null;

                if (chkConfirmed.Checked)
                {
                    if (strSymphonyValue == "")
                        strSymphonyValue = "28";
                    else
                        strSymphonyValue += "," + "28";
                }
                if (chkProvisional.Checked)
                {
                    if (strSymphonyValue == "")
                        strSymphonyValue = "27";
                    else
                        strSymphonyValue += "," + "27";
                }
                if (chkWaitingList.Checked)
                {
                    if (strSymphonyValue == "")
                        strSymphonyValue = "29";
                    else
                        strSymphonyValue += "," + "29";
                }
                if (chkAll.Checked)
                {
                    strSymphonyValue = "27,28,29";
                }

                if (strSymphonyValue == "")
                    strSymphonyValue = "28";

                DataSet dsReservationList = ReservationBLL.GetArrivalListData(null, clsSession.PropertyID, clsSession.CompanyID, strName, strMobileNo, strReservationNo, StartDate, EndDate, "LIST", strSymphonyValue);

                if (dsReservationList.Tables.Count > 0 && dsReservationList.Tables[0].Rows.Count > 0)
                {
                    gvRoomReservationList.DataSource = dsReservationList.Tables[0];
                    gvRoomReservationList.DataBind();
                }
                else
                {
                    gvRoomReservationList.DataSource = null;
                    gvRoomReservationList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearSearch()
        {
            txtSearchName.Text = txtMobileNo.Text = txtSearcReservationNo.Text = "";
            rblList.SelectedIndex = 0;
            chkConfirmed.Checked = true;
            chkProvisional.Checked = chkWaitingList.Checked = chkAll.Checked = false;
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
        public void SendMailTo(string EmailAddress, string subjectForEmail, string FileNameToSave, Guid ReservationID)
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

                        if (File.Exists(Server.MapPath("~/EmailTemplate/ReservationVoucher.htm")) && ReservationID != null && ReservationID != Guid.Empty)
                        {
                            DataSet dsVoucherData = ReservationBLL.GetReservationVoucherData(ReservationID, clsSession.PropertyID, clsSession.CompanyID);
                            if (dsVoucherData.Tables.Count > 0 && dsVoucherData.Tables[0].Rows.Count > 0)
                            {
                                DataRow dr = dsVoucherData.Tables[0].Rows[0];

                                DateTime dtCheckInDate = Convert.ToDateTime(Convert.ToString(dr["CheckInDate"]));
                                DateTime dtCheckOutDate = Convert.ToDateTime(Convert.ToString(dr["CheckOutDate"]));
                                int day = 0;
                                bool b1 = false;
                                bool b2 = false;
                                clsCommon.Reservation_GetTotalDays(null, dtCheckInDate, dtCheckOutDate, ref day, ref b1, ref b2);
                                string strHTML = File.ReadAllText(Server.MapPath("~/EmailTemplate/ReservationVoucher.htm"));
                                strHTML = strHTML.Replace("$PROPERTYADDRESS$", BindPropertyAddress());
                                strHTML = strHTML.Replace("$CURRENTDATE$", Convert.ToString(DateTime.Now.ToString(clsSession.DateFormat + " " + clsSession.TimeFormat)));
                                strHTML = strHTML.Replace("$NAME$", Convert.ToString(dr["GuestFullName"]));
                                strHTML = strHTML.Replace("$BOOKINGNO$", Convert.ToString(dr["ReservationNo"]));


                                strHTML = strHTML.Replace("$MOBILENO$", Convert.ToString(clsCommon.GetMobileNo(Convert.ToString(dr["Phone1"]))));
                                strHTML = strHTML.Replace("$EMAILID$", Convert.ToString(dr["Email"]));
                                strHTML = strHTML.Replace("$CHECKINDATE$", Convert.ToString(dtCheckInDate.ToString(clsSession.DateFormat)));

                                strHTML = strHTML.Replace("$CHECKOUTDATE$", Convert.ToString(dtCheckOutDate.ToString(clsSession.DateFormat)));
                                strHTML = strHTML.Replace("$NOOFNIGHT$", Convert.ToString(day));
                                strHTML = strHTML.Replace("$NOOFGUEST$", Convert.ToString(dr["NoofGuests"]));

                                strHTML = strHTML.Replace("$RATECARD$", Convert.ToString(dr["RateCardName"]));
                                strHTML = strHTML.Replace("$ROOMTYPE$", Convert.ToString(dr["RoomTypeName"]));
                                strHTML = strHTML.Replace("$BOOKINGSTATUS$", Convert.ToString(dr["Status"]));

                                if (dsVoucherData.Tables[1] != null && dsVoucherData.Tables[1].Rows.Count > 0)
                                {
                                    DataRow dr1 = dsVoucherData.Tables[1].Rows[0];

                                    if (Convert.ToString(dr["SymphonyValue"]) == "27")
                                    {
                                        int addDays = Convert.ToInt32(Convert.ToString(dr1["ProvisionalReservationDayLimit"]));
                                        strHTML = strHTML.Replace("$VALIDUPTO$", Convert.ToString(dtCheckInDate.AddDays(addDays).ToString(clsSession.DateFormat)));
                                    }
                                    else
                                    {
                                        strHTML = strHTML.Replace("$VALIDUPTO$", "");
                                    }

                                    DateTime dtCheckInTime = Convert.ToDateTime(Convert.ToString(dr1["CheckInTime"]));
                                    DateTime dtCheckOutTime = Convert.ToDateTime(Convert.ToString(dr1["CheckOutTime"]));
                                    strHTML = strHTML.Replace("$VOUCHECKIN$", Convert.ToString(dtCheckInTime.ToString(clsSession.TimeFormat)));
                                    strHTML = strHTML.Replace("$VOUCHECKOUT$", Convert.ToString(dtCheckOutTime.ToString(clsSession.TimeFormat)));
                                    strHTML = strHTML.Replace(" $RESPOLICY$", Convert.ToString(dr1["ReservationPolicy"]));
                                }
                                else
                                {
                                    strHTML = strHTML.Replace("$VALIDUPTO$", "");
                                    strHTML = strHTML.Replace("$VOUCHECKIN$", "");
                                    strHTML = strHTML.Replace("$VOUCHECKOUT$", "");
                                    strHTML = strHTML.Replace(" $RESPOLICY$", "");
                                }

                                if (dsVoucherData.Tables[2] != null && dsVoucherData.Tables[2].Rows.Count > 0)
                                    strHTML = strHTML.Replace("$CANCELPOLICY$", Convert.ToString(dsVoucherData.Tables[2].Rows[0]["PolicyNote"]));
                                else
                                    strHTML = strHTML.Replace("$CANCELPOLICY$", "");



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

                                clsCommon.GetReservationPaymentInfo(ReservationID, ref RoomRent, ref Tax, ref TotalAmount, ref NoofDays, ref DepositAmount, ref PaidDeposit, ref TotalPaymentReceived, ref dtPaidAmountInfo, ref InfraServiceCharge, ref PaidInfraServiceCharge, ref FoodCharges, ref PaidFoodCharges, ref ElectricityCharges, ref PaidElectricityCharges);

                                string strRoomRent, strTax, strTotalAmount, strDepositAmount, strTotalAmountPayable, strTotalAmountReceived, strDueBalanceAmount = "";

                                strRoomRent = RoomRent.ToString().Substring(0, RoomRent.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                                strTax = Tax.ToString().Substring(0, Tax.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                                strTotalAmount = TotalAmount.ToString().Substring(0, TotalAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                                strDepositAmount = DepositAmount.ToString().Substring(0, DepositAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                                TotalAmountPayable = TotalAmount + DepositAmount;
                                strTotalAmountPayable = TotalAmountPayable.ToString().Substring(0, TotalAmountPayable.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                                strHTML = strHTML.Replace("$NONRR$", Convert.ToString(NoofDays));
                                strHTML = strHTML.Replace("$AMTRR$", Convert.ToString(strRoomRent));

                                strHTML = strHTML.Replace("$NONTAX$", "-");
                                strHTML = strHTML.Replace("$AMTTAX$", Convert.ToString(strTax));
                                strHTML = strHTML.Replace("$NONTOC$", "-");
                                strHTML = strHTML.Replace("$AMTTC$", Convert.ToString(strTotalAmount));

                                strHTML = strHTML.Replace("$NONDEP$", "-");
                                strHTML = strHTML.Replace("$AMTDEP$", Convert.ToString(strDepositAmount));
                                strHTML = strHTML.Replace("$TOTAL$", Convert.ToString(strTotalAmountPayable));
                                strHTML = strHTML.Replace("$AMTPR$", Convert.ToString(strTotalAmountPayable));



                                strTotalAmountReceived = TotalPaymentReceived.ToString().Substring(0, TotalPaymentReceived.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                                strHTML = strHTML.Replace("$TOTALAMTREC$", Convert.ToString(strTotalAmountReceived));
                                if (Convert.ToDecimal(Convert.ToString(strTotalAmountReceived)) > Convert.ToDecimal(Convert.ToString(strTotalAmountPayable)) || Convert.ToDecimal(Convert.ToString(strTotalAmountReceived)) == Convert.ToDecimal(Convert.ToString(strTotalAmountPayable)))
                                {
                                    DueBalanceAmount = TotalPaymentReceived - TotalAmountPayable;
                                    strHTML = strHTML.Replace("$BALANCEAMT$", DueBalanceAmount.ToString().Substring(0, DueBalanceAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                                    strHTML = strHTML.Replace("$BALANCEAMTLABEL$", "Balance Amount(Credit)");
                                }
                                else
                                {
                                    DueBalanceAmount = TotalAmountPayable - TotalPaymentReceived;
                                    strHTML = strHTML.Replace("$BALANCEAMT$", DueBalanceAmount.ToString().Substring(0, DueBalanceAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                                    strHTML = strHTML.Replace("$BALANCEAMTLABEL$", "Balance Amount(Due)");
                                }

                                // close all open files
                                string strfilename = Server.MapPath("~/PDFs/" + FileNameToSave + ".pdf");

                                // Export to pdf document
                                Document pdfDoc = new Document();

                                pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                                if (!Directory.Exists(Server.MapPath("~/PDFs")))
                                    Directory.CreateDirectory(Server.MapPath("~/PDFs"));


                                if (File.Exists(strfilename))
                                    File.Delete(strfilename);


                                using (FileStream strFilestrema = new FileStream(strfilename, FileMode.Create))
                                {
                                    PdfWriter.GetInstance(pdfDoc, strFilestrema);
                                    pdfDoc.Open();

                                    var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(strHTML), null);

                                    //Get each array values from parsed elements and add to the PDF document
                                    foreach (var htmlElement in parsedHtmlElements)
                                    {
                                        pdfDoc.Add(htmlElement as IElement);
                                    }
                                    //Close your PDF
                                    pdfDoc.Close();
                                    pdfDoc.CloseDocument();
                                    SentMail.SendMail(strPrimoryDomainName, strUserName, strPassword, strSmtpAddress, EmailAddress, subjectForEmail, strHTML, strfilename);
                                    strFilestrema.Close();
                                    strFilestrema.Dispose();
                                    pdfDoc.Close();
                                    pdfDoc.Dispose();
                                    parsedHtmlElements.Clear();
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                                    MessageBox.Show("Email sent sucessfully.");

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
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Sorry for inconvenience, system can't send mail. Please try again later.");
                        return;
                    }

                }

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show("This guest has no email, you can't send mail to him");
                return;
            }
        }
        #endregion Private Method

        #region Control Event
        protected void rblList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                gvRoomReservationList.PageIndex = 0;
                BindReservationGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void imgbtnClearSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ClearSearch();
                gvRoomReservationList.PageIndex = 0;
                BindReservationGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        #endregion Control Event

        #region Grid Event

        protected void gvRoomReservationList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("CHECKIN"))
                {
                    DataSet dsReservationData = ReservationBLL.GetArrivalListData(new Guid(Convert.ToString(e.CommandArgument)), clsSession.PropertyID, clsSession.CompanyID, null, null, null, null, null, "DETAILS", null);
                    if (dsReservationData.Tables.Count > 0 && dsReservationData.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToDateTime(Convert.ToString(dsReservationData.Tables[0].Rows[0]["CheckInDate"]).ToString()).ToString("MM-dd-yyyy") != DateTime.Today.ToString("MM-dd-yyyy"))
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                            MessageBox.Show("You can't check in this reservation, because it's check in date is not today's date.");
                            return;
                        }

                        clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                        clsSession.ToEditItemType = "GUESTDETAILS";
                        Response.Redirect("~/GUI/Reservation/CheckIn.aspx");
                    }
                }
                else if (e.CommandName.ToUpper().Equals("REPRINTRESERVATIONVOUCHER"))
                {
                    hdnReservationID.Value = Convert.ToString(new Guid(Convert.ToString(e.CommandArgument)));
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openReservationVoucher();", true);

                }
                else if (e.CommandName.ToUpper().Equals("EMAILTOGUEST"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    string strEmailToIR = Convert.ToString(gvRoomReservationList.DataKeys[row.RowIndex]["Email"].ToString());
                    SendMailTo(strEmailToIR, "Reservation Voucher", "ReservationVoucher", new Guid(Convert.ToString(e.CommandArgument)));
                }
                else if (e.CommandName.ToUpper().Equals("EMAILTOIR"))
                {
                    string strEmailToIR = ConfigurationManager.AppSettings["IREmailAddress"].ToString();
                    SendMailTo(strEmailToIR, "Complementory Reservation Voucher", "ComplementoryReservationVoucher", new Guid(Convert.ToString(e.CommandArgument)));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message);
            }
        }

        protected void gvRoomReservationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRoomReservationList.PageIndex = e.NewPageIndex;
            BindReservationGrid();
        }

        protected void gvRoomReservationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int SymphonyValue = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SymphonyValue")));

                    ((Label)e.Row.FindControl("lblGvPhone")).Text = clsCommon.GetMobileNo(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Phone1")));
                    ((Label)e.Row.FindControl("lblGvRoomNo")).Text = clsCommon.GetFormatedRoomNumber(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomNo")));

                    System.Web.UI.WebControls.Image imgReservationStatus = (System.Web.UI.WebControls.Image)e.Row.FindControl("imgReservationStatus");

                    string strimagesrc = "";
                    string strAltTag = "";

                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SpecificNote")).Trim() != string.Empty)
                    {
                        e.Row.Style.Add("background-color", "#d5d5d5");
                    }

                    switch (SymphonyValue)
                    {
                        case 27:
                            strimagesrc = "~/images/UnConfirmed22x22.png";
                            strAltTag = " Provisional";
                            break;
                        case (28):
                            strimagesrc = "~/images/Confirmed22x22.png";
                            strAltTag = "Confirmed";
                            break;
                        case (29):
                            strimagesrc = "~/images/WaitingList22x22.png";
                            strAltTag = "Waiting List";
                            break;
                        case (32):
                            strimagesrc = "~/images/CheckIn22x22.png";
                            strAltTag = "Check In";
                            break;
                        case (33):
                            strimagesrc = "~/images/CheckOut22x22.png";
                            strAltTag = "Check Out";
                            break;
                        case (34):
                            strimagesrc = "~/images/Cancelled22x22.png";
                            strAltTag = "Cancelled";
                            break;
                    }

                    LinkButton lnkMailToIR = (LinkButton)e.Row.FindControl("lnkMailToIR");

                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservationToCheckComp = new BusinessLogic.FrontDesk.DTO.Reservation();
                    objReservationToCheckComp = ReservationBLL.GetByPrimaryKey(new Guid(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ReservationID"))));
                    if (objReservationToCheckComp.IsComplimentoryReservation != null && objReservationToCheckComp.IsComplimentoryReservation == true && objReservationToCheckComp.RefInvestorID != null && Convert.ToString(objReservationToCheckComp.RefInvestorID) != string.Empty && Convert.ToString(objReservationToCheckComp.RefInvestorID) != Guid.Empty.ToString())
                    {
                        lnkMailToIR.Visible = true;
                    }
                    else
                    {
                        lnkMailToIR.Visible = false;
                    }
                    imgReservationStatus.ImageUrl = strimagesrc;
                    imgReservationStatus.ToolTip = strAltTag;
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