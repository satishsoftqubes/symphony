using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.Shared;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using CrystalDecisions.CrystalReports.Engine;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Net;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;

namespace SQT.Symphony.UI.Web.FrontDesk.ReportFiles
{
    public partial class frmViewer : System.Web.UI.Page
    {
        string ReportName = "";
        DataSet DataSourceValue;
        bool IsPreview = true;
        bool IsEMail = false;
        public string strdate;
        public string ExportMode;
        CrystalDecisions.CrystalReports.Engine.ReportDocument rptPrint;
        CrystalDecisions.Shared.DiskFileDestinationOptions dskdstOpt = new DiskFileDestinationOptions();
        HTMLFormatOptions HTMLExpOpts = new HTMLFormatOptions();
        double nettot = 0, netpaidin = 0, netpaidout = 0;
        double tmptot = 0, totpaidin = 0, totpaidout = 0, totcityledger = 0;
        string s_DateTimeStamp, RptName, exportPath;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mail"] != null)
                this.IsEMail = Convert.ToBoolean(Request.QueryString["mail"]);
            if (Request.QueryString["preview"] != null)
                this.IsPreview = Convert.ToBoolean(Request.QueryString["preview"]);

            if (Session["ReportName"] != null)
                this.ReportName = Convert.ToString(Session["ReportName"]);
            if (Session["ExportMode"] != null)
                this.ExportMode = Convert.ToString(Session["ExportMode"]);
            //  if (!IsPostBack)
            //  {
            if (this.ReportName.Equals("Bill Format") || this.ReportName.Equals("Bill Summary"))
                btnEmail.Visible = true;
            else
                btnEmail.Visible = false;
            this.DataSourceValue = (DataSet)Session["DataSource"];
            SetParameter();
            CRViewer.SeparatePages = false;
            CRViewer.EnableDatabaseLogonPrompt = false;
            if (IsEMail == true)
            {
                //exportPath = CheckDirectory();
                //RptName = "Bill Format";              
                //rptPrint.ExportToDisk(ExportFormatType.PortableDocFormat, exportPath + "\\BillInvoice" + s_DateTimeStamp + ".pdf");
                //DataSet ds = this.DataSourceValue;
                //if (ds != null)
                //{
                //    string strSubject = "Invoice of Reservation - " + Convert.ToString(ds.Tables[0].Rows[0]["ReservationNo"]);
                //    string strMailMsg = "Here sending you Invoice No : " + Convert.ToString(ds.Tables[0].Rows[0]["InvoiceNo"]) + " for Reservation No. " + Convert.ToString(ds.Tables[0].Rows[0]["ReservationNo"]) + ".<br /> Please find the attachment for same.";
                //    string strHTML = File.ReadAllText(Server.MapPath("~/EmailTemplate/InvoiceTemplate.htm"));
                //        strHTML = strHTML.Replace("$FULLNAME$", Convert.ToString(ds.Tables[0].Rows[0]["Guest_Name"]));
                //        strHTML = strHTML.Replace("$BODY$", Convert.ToString(strMailMsg));
                //        Company obj = CompanyBLL.GetByPrimaryKey(clsSession.CompanyID);
                //        strHTML = strHTML.Replace("$COMPANYCONTACTNO$", Convert.ToString(obj.PrimoryContactNo));
                //    bool flg = SendEmailMessage(Convert.ToString(ds.Tables[0].Rows[0]["Email"]), "", strSubject, strHTML, exportPath + "\\BillInvoice" + s_DateTimeStamp + ".pdf");                                            
                //    if(flg)
                //        MessageBox.Show("Mail Sent Successfully.");
                //}
            }
            else
            {
                if (IsPreview == false)
                {
                    if (Session["ExportMode"] != null)
                    {
                        if (ExportMode.Equals("PDF"))
                        {
                            CRViewer.PrintMode = CrystalDecisions.Web.PrintMode.Pdf;
                            Response.Buffer = false;
                            // Clear the response content and headers
                            Response.ClearContent();
                            Response.ClearHeaders();
                            try
                            {
                                // Export the Report to Response stream in PDF format and file name ReportName
                                rptPrint.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, ReportName);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                ex = null;
                            }
                        }
                        else if (ExportMode.Equals("XLSX"))
                        {
                            Response.Buffer = false;
                            // Clear the response content and headers
                            Response.ClearContent();
                            Response.ClearHeaders();
                            try
                            {
                                // Export the Report to Response stream in XLSX format and file name ReportName
                                rptPrint.ExportToHttpResponse(ExportFormatType.Excel, Response, true, this.ReportName);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                ex = null;
                            }
                        }
                        else if (ExportMode.Equals("DOC"))
                        {
                            Response.Buffer = false;
                            // Clear the response content and headers
                            Response.ClearContent();
                            Response.ClearHeaders();
                            try
                            {
                                // Export the Report to Response stream in DOC format and file name ReportName
                                rptPrint.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, this.ReportName);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                ex = null;
                            }
                        }
                    }
                    else
                    {
                        CRViewer.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX;
                        //rptPrint.PrintOptions.PaperOrientation = PaperOrientation.Landscape;

                    }

                }
            }
            //else
            //{
            //    btnPrint.Visible = false;
            //}            
        }

        private string CheckDirectory()
        {
            s_DateTimeStamp = Convert.ToString(DateTime.Today.Month) + Convert.ToString(DateTime.Today.Day) + Convert.ToString(DateTime.Today.Year);
            s_DateTimeStamp += Convert.ToString(DateTime.Now.Hour) + Convert.ToString(DateTime.Now.Minute) + Convert.ToString(DateTime.Now.Second);

            string exportPath = MapPath("..\\ExportFile");
            if (!Directory.Exists(exportPath))
            {
                Directory.CreateDirectory(exportPath);
            }
            return exportPath;
        }

        protected void btnPrint_OnClick(object sender, EventArgs e)
        {
            //rptPrint.PrintToPrinter(1, false, 0, 0);
        }

        public void SetParameter()
        {
            try
            {
                if (Session["CompanyID"] != null)
                {
                    Company objCmpData = CompanyBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["CompanyID"])));
                    string strCompName = null;
                    string strCompAdd = null;
                    string strPhoneEmail = null;
                    strCompName = objCmpData.CompanyName;
                    strCompAdd = objCmpData.PrimaryAdd1.Replace("\r\n", string.Empty);
                    strPhoneEmail = "M : " + objCmpData.PrimaryPhone + "       E : " + objCmpData.PrimaryEmail + "       W : " + objCmpData.PrimaryUrl;
                    switch (ReportName)
                    {
                        case "Folio Statement":
                            string foliono = "ALL", guestNm = "ALL", FdF_Date = "-", FdT_Date = "-";
                            if (Session["FolioNo"] != null)
                                foliono = Convert.ToString(Session["FolioNo"]);
                            if (Session["GuestName"] != null)
                                guestNm = Convert.ToString(Session["GuestName"]);
                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                FdF_Date = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                FdT_Date = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                            {
                                FdF_Date = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                FdT_Date = DateTime.Now.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                FdF_Date = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                FdT_Date = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            }
                            rptFolioStatement prospList = new rptFolioStatement();
                            prospList.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)prospList;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("FromDate", FdF_Date);
                            rptPrint.SetParameterValue("ToDate", FdT_Date);
                            rptPrint.SetParameterValue("FolioNo", foliono);
                            rptPrint.SetParameterValue("GuestName", guestNm);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("FolioNo", null);
                            Session.Add("GuestName", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            break;

                        case "Folio Summary":
                            string sfoliono = "ALL", sguestNm = "ALL", sFdF_Date = "-", sFdT_Date = "-";
                            if (Session["FolioNo"] != null)
                                sfoliono = Convert.ToString(Session["FolioNo"]);
                            if (Session["GuestName"] != null)
                                sguestNm = Convert.ToString(Session["GuestName"]);
                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                sFdF_Date = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                sFdT_Date = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                            {
                                sFdF_Date = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                sFdT_Date = DateTime.Now.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                sFdF_Date = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                sFdT_Date = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            }
                            rptFolioStatementSummary foliosum = new rptFolioStatementSummary();
                            foliosum.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)foliosum;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("FromDate", sFdF_Date);
                            rptPrint.SetParameterValue("ToDate", sFdT_Date);
                            rptPrint.SetParameterValue("FolioNo", sfoliono);
                            rptPrint.SetParameterValue("GuestName", sguestNm);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("FolioNo", null);
                            Session.Add("GuestName", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            break;

                        case "Collection Summary":
                            string CntNo = "ALL";
                            string GenType = "ALL", collF_Date = "-", collT_Date = "-";
                            string PmtMd = "ALL";
                            int csdays = 0;

                            if (Session["Days"] != null)
                                csdays = Convert.ToInt32(Session["Days"]);
                            if (Session["RptCounter"] != null)
                                CntNo = Convert.ToString(Session["RptCounter"]);
                            if (Session["RptGenIDTyp"] != null)
                                GenType = Convert.ToString(Session["RptGenIDTyp"]);
                            if (Session["RptPaymentMode"] != null)
                                PmtMd = Convert.ToString(Session["RptPaymentMode"]);
                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                collF_Date = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                collT_Date = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                            {
                                collF_Date = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                collT_Date = DateTime.Now.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                collF_Date = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                collT_Date = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            }
                            rptCollectionSummary collectionSummary = new rptCollectionSummary();
                            collectionSummary.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)collectionSummary;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("FromDate", collF_Date);
                            rptPrint.SetParameterValue("ToDate", collT_Date);
                            rptPrint.SetParameterValue("Counter", CntNo);
                            rptPrint.SetParameterValue("PaymentMode", PmtMd);
                            rptPrint.SetParameterValue("GenTypeID", GenType);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("RptCounter", null);
                            Session.Add("RptPaymentMode", null);
                            Session.Add("RptGenIDTyp", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            Session.Add("Days", null);
                            break;

                        case "Collection Detail Summary":
                            string dCntNo = "ALL";
                            string dGenType = "ALL", dcollF_Date = "-", dcollT_Date = "-";
                            string dPmtMd = "ALL";
                            int cddays = 0;

                            if (Session["Days"] != null)
                                cddays = Convert.ToInt32(Session["Days"]);
                            if (Session["RptCounter"] != null)
                                dCntNo = Convert.ToString(Session["RptCounter"]);
                            if (Session["RptGenIDTyp"] != null)
                                dGenType = Convert.ToString(Session["RptGenIDTyp"]);
                            if (Session["RptPaymentMode"] != null)
                                dPmtMd = Convert.ToString(Session["RptPaymentMode"]);
                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                dcollF_Date = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                dcollT_Date = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                            {
                                dcollF_Date = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                dcollT_Date = DateTime.Now.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                dcollF_Date = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                dcollT_Date = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            }
                            rptCollectionDetail_Summary collecDetSummary = new rptCollectionDetail_Summary();
                            collecDetSummary.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)collecDetSummary;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("FromDate", dcollF_Date);
                            rptPrint.SetParameterValue("ToDate", dcollT_Date);
                            rptPrint.SetParameterValue("Counter", dCntNo);
                            rptPrint.SetParameterValue("PaymentMode", dPmtMd);
                            rptPrint.SetParameterValue("GenTypeID", dGenType);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("RptCounter", null);
                            Session.Add("RptPaymentMode", null);
                            Session.Add("RptGenIDTyp", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            Session.Add("Days", null);
                            break;

                        case "Revenue Detail":
                            string RCntNo = "ALL";
                            string RGenType = "ALL";
                            string RResNo = "ALL";
                            if (Session["RptCounter"] != null)
                                RCntNo = Convert.ToString(Session["RptCounter"]);
                            if (Session["RptRmType"] != null)
                                RGenType = Convert.ToString(Session["GeneralType"]);
                            if (Session["RptReservationNo"] != null)
                                RResNo = Convert.ToString(Session["RptReservationNo"]);

                            rptRevenueDetail revDetail = new rptRevenueDetail();
                            revDetail.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)revDetail;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("RptCounter", null);
                            Session.Add("GeneralType", null);
                            Session.Add("RptReservationNo", null);
                            break;

                        case "Counter Close":
                            string CCntNo = "ALL";
                            string Date = "";
                            string strOpen = "0.00", strSuggest = "0.00", strShort = "0.00", strActual = "0.00", strDropped = "0.00";
                            string strReason = "", strNotes = "";
                            if (Session["RptCounter"] != null)
                                CCntNo = Convert.ToString(Session["RptCounter"]);
                            if (Session["Date"] != null)
                                Date = Convert.ToDateTime(Session["Date"]).ToString("dd-MM-yyyy");
                            ////string total1 = GetCounterTotal(new DataView(this.DataSourceValue.Tables[0]));
                            ////string netTotal = GetNetCounterTotal(new DataView(this.DataSourceValue.Tables[0]));
                            ////string diff1 = (totpaidin - totpaidout).ToString("N");
                            ////string finalTotal = (Convert.ToDouble(diff1) - Convert.ToDouble(netTotal)).ToString("N");
                            //string total1 = GetNetCounterTotal(new DataView(this.DataSourceValue.Tables[0]));
                            //string netTotal = netpaidout.ToString("N");
                            //string diff1 = netpaidin.ToString("N");
                            //string finalTotal = nettot.ToString("N");

                            if (Session["RptOpening"] != null)
                                strOpen = Convert.ToString(Session["RptOpening"]);
                            if (Session["RptSuggested"] != null)
                                strSuggest = Convert.ToString(Session["RptSuggested"]);
                            if (Session["RptShortOver"] != null)
                                strShort = Convert.ToString(Session["RptShortOver"]);
                            if (Session["RptActual"] != null)
                                strActual = Convert.ToString(Session["RptActual"]);
                            if (Session["RptReason"] != null)
                                strReason = Convert.ToString(Session["RptReason"]);
                            if (Session["RptDropped"] != null)
                                strDropped = Convert.ToString(Session["RptDropped"]);
                            if (Session["RptNotes"] != null)
                                strNotes = Convert.ToString(Session["RptNotes"]);

                            rptCounterClose cntClose = new rptCounterClose();
                            cntClose.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)cntClose;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("CounterNo", CCntNo);
                            rptPrint.SetParameterValue("Date", Date);
                            rptPrint.SetParameterValue("UserName", clsSession.UserName);
                            rptPrint.SetParameterValue("OpeningBal", strOpen);
                            rptPrint.SetParameterValue("Suggested", strSuggest);
                            rptPrint.SetParameterValue("ShortOverAmt", strShort);
                            rptPrint.SetParameterValue("Actual", strActual);
                            rptPrint.SetParameterValue("Reason", strReason);
                            rptPrint.SetParameterValue("DroppedAmt", strDropped);
                            rptPrint.SetParameterValue("Remarks", strNotes);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("RptCounter", null);
                            Session.Add("RptOpening", null);
                            Session.Add("RptSuggested", null);
                            Session.Add("RptShortOver", null);
                            Session.Add("RptActual", null);
                            Session.Add("RptReason", null);
                            Session.Add("RptDropped", null);
                            Session.Add("RptNotes", null);
                            Session.Add("Date", null);
                            break;

                        case "Counter Close History":
                            string CCHCntNo = "ALL";
                            string CCHDate = "";
                            string CHstrOpen = "0.00", CHstrSuggest = "0.00", CHstrShort = "0.00", CHstrActual = "0.00", CHstrDropped = "0.00";
                            string CHstrReason = "", CHstrNotes = "";
                            if (Session["RptCounter"] != null)
                                CCHCntNo = Convert.ToString(Session["RptCounter"]);
                            if (Session["Date"] != null)
                                CCHDate = Convert.ToDateTime(Session["Date"]).ToString("dd-MM-yyyy");
                            ////string total1 = GetCounterTotal(new DataView(this.DataSourceValue.Tables[0]));
                            ////string netTotal = GetNetCounterTotal(new DataView(this.DataSourceValue.Tables[0]));
                            ////string diff1 = (totpaidin - totpaidout).ToString("N");
                            ////string finalTotal = (Convert.ToDouble(diff1) - Convert.ToDouble(netTotal)).ToString("N");
                            //string total1 = GetNetCounterTotal(new DataView(this.DataSourceValue.Tables[0]));
                            //string netTotal = netpaidout.ToString("N");
                            //string diff1 = netpaidin.ToString("N");
                            //string finalTotal = nettot.ToString("N");

                            if (Session["RptOpening"] != null)
                                CHstrOpen = Convert.ToString(Session["RptOpening"]);
                            if (Session["RptSuggested"] != null)
                                CHstrSuggest = Convert.ToString(Session["RptSuggested"]);
                            if (Session["RptShortOver"] != null)
                                CHstrShort = Convert.ToString(Session["RptShortOver"]);
                            if (Session["RptActual"] != null)
                                CHstrActual = Convert.ToString(Session["RptActual"]);
                            if (Session["RptReason"] != null)
                                CHstrReason = Convert.ToString(Session["RptReason"]);
                            if (Session["RptDropped"] != null)
                                CHstrDropped = Convert.ToString(Session["RptDropped"]);
                            if (Session["RptNotes"] != null)
                                CHstrNotes = Convert.ToString(Session["RptNotes"]);

                            rptCounterCloseHistory cntHClose = new rptCounterCloseHistory();
                            cntHClose.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)cntHClose;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("CounterNo", CCHCntNo);
                            rptPrint.SetParameterValue("Date", CCHDate);
                            rptPrint.SetParameterValue("UserName", clsSession.UserName);
                            rptPrint.SetParameterValue("OpeningBal", CHstrOpen);
                            rptPrint.SetParameterValue("Suggested", CHstrSuggest);
                            rptPrint.SetParameterValue("ShortOverAmt", CHstrShort);
                            rptPrint.SetParameterValue("Actual", CHstrActual);
                            rptPrint.SetParameterValue("Reason", CHstrReason);
                            rptPrint.SetParameterValue("DroppedAmt", CHstrDropped);
                            rptPrint.SetParameterValue("Remarks", CHstrNotes);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("RptCounter", null);
                            Session.Add("RptOpening", null);
                            Session.Add("RptSuggested", null);
                            Session.Add("RptShortOver", null);
                            Session.Add("RptActual", null);
                            Session.Add("RptReason", null);
                            Session.Add("RptDropped", null);
                            Session.Add("RptNotes", null);
                            Session.Add("Date", null);
                            break;

                        case "Cash Report":
                            string CashCntNo = "ALL", cashFrom = "-", cashTo = "-";
                            string Cashier = "ALL";
                            int cashdays = 0;

                            if (Session["Days"] != null)
                                cashdays = Convert.ToInt32(Session["Days"]);
                            if (Session["RptCounter"] != null)
                                CashCntNo = Convert.ToString(Session["RptCounter"]);
                            if (Session["RptCashier"] != null)
                                Cashier = Convert.ToString(Session["RptCashier"]);
                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                cashFrom = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                cashTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                            {
                                cashFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                cashTo = DateTime.Now.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                cashFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                cashTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            }

                            rptCashReport cash = new rptCashReport();
                            cash.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)cash;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("FromDate", cashFrom);
                            rptPrint.SetParameterValue("ToDate", cashTo);
                            rptPrint.SetParameterValue("Counter", CashCntNo);
                            rptPrint.SetParameterValue("Cashier", Cashier);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("RptCounter", null);
                            Session.Add("RptCashier", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            Session.Add("Days", null);
                            break;

                        case "Room Rent Revenue Detail":
                            string rrF_Date = "-", rrT_Date = "-";
                            string rrRmType = "ALL";
                            int rrdays = 0;
                            if (Session["Days"] != null)
                                rrdays = Convert.ToInt32(Session["Days"]);
                            if (Session["RptRmType"] != null)
                                rrRmType = Convert.ToString(Session["RptRmType"]);

                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                rrF_Date = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                rrT_Date = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                            {
                                rrF_Date = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                rrT_Date = DateTime.Now.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                rrF_Date = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                rrT_Date = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            }

                            rptRevenueDetail roomRevDetail = new rptRevenueDetail();
                            roomRevDetail.SetDataSource(this.DataSourceValue.Tables[0]);
                            //roomRevDetail.OpenSubreport("subrpt_summary").SetDataSource(this.DataSourceValue.Tables[1]);
                            rptPrint = (ReportDocument)roomRevDetail;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("FromDate", rrF_Date);
                            rptPrint.SetParameterValue("ToDate", rrT_Date);
                            rptPrint.SetParameterValue("RoomType", rrRmType);
                            rptPrint.SetParameterValue("Days", rrdays);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("RptRmType", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            Session.Add("Days", null);
                            break;

                        case "Room Rent Revenue Summary":
                            string rrsF_Date = "-", rrsT_Date = "-";
                            string rrsRmType = "ALL";
                            int rrsdays = 0;
                            if (Session["Days"] != null)
                                rrsdays = Convert.ToInt32(Session["Days"]);
                            if (Session["RptRmType"] != null)
                                rrsRmType = Convert.ToString(Session["RptRmType"]);

                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                rrsF_Date = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                rrsT_Date = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                            {
                                rrsF_Date = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                rrsT_Date = DateTime.Now.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                rrsF_Date = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                rrsT_Date = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            }

                            rptRoomRentRevenueSummary roomRevSummary = new rptRoomRentRevenueSummary();
                            roomRevSummary.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)roomRevSummary;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("FromDate", rrsF_Date);
                            rptPrint.SetParameterValue("ToDate", rrsT_Date);
                            rptPrint.SetParameterValue("RoomType", rrsRmType);
                            rptPrint.SetParameterValue("Days", rrsdays);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("RptRmType", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            Session.Add("Days", null);
                            break;

                        case "Room Deposit":
                            string depoCntNo = "ALL", depoFrom = "-", depoTo = "-";
                            string depoCashier = "ALL";
                            int rddays = 0;

                            if (Session["Days"] != null)
                                rddays = Convert.ToInt32(Session["Days"]);

                            if (Session["RptCounter"] != null)
                                depoCntNo = Convert.ToString(Session["RptCounter"]);
                            if (Session["RptCashier"] != null)
                                depoCashier = Convert.ToString(Session["RptCashier"]);
                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                depoFrom = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                depoTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                            {
                                depoFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                depoTo = DateTime.Now.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                depoFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                depoTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            }
                            DataTable dtTotal = this.DataSourceValue.Tables[1];
                            decimal closingtotal = Convert.ToDecimal(dtTotal.Rows[0][0]);
                            rptRoomDeposit rmDepo = new rptRoomDeposit();
                            rmDepo.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)rmDepo;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("FromDate", depoFrom);
                            rptPrint.SetParameterValue("ToDate", depoTo);
                            rptPrint.SetParameterValue("ClosingBalance", closingtotal);
                            rptPrint.SetParameterValue("Counter", depoCntNo);
                            rptPrint.SetParameterValue("Cashier", depoCashier);
                            rptPrint.SetParameterValue("Today", System.DateTime.Now.ToString("dd-MM-yyyy"));
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("RptCounter", null);
                            Session.Add("RptCashier", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            Session.Add("Days", null);
                            break;

                        case "Room Rent Advance":
                            string advCntNo = "ALL", advFrom = "-", advTo = "-";
                            string advCashier = "ALL";
                            int advdays = 0;

                            if (Session["Days"] != null)
                                advdays = Convert.ToInt32(Session["Days"]);

                            if (Session["RptCounter"] != null)
                                advCntNo = Convert.ToString(Session["RptCounter"]);
                            if (Session["RptCashier"] != null)
                                advCashier = Convert.ToString(Session["RptCashier"]);
                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                advFrom = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                advTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                            {
                                advFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                advTo = DateTime.Now.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                advFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                advTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            }
                            Guid? iAcctID = null;
                            if (Session["AcctID"] != null)
                                iAcctID = new Guid(Convert.ToString(Session["AcctID"]));
                            DataSet ds = BookKeepingBLL.GetRPTRoomRentAdvance_ClosingBal(clsSession.CompanyID, clsSession.PropertyID, null, null, iAcctID, null, Convert.ToDateTime(Session["EndDate"]));
                            decimal advclosingtotal = 0;
                            if (ds.Tables[0].Rows.Count > 0)
                                advclosingtotal = Convert.ToDecimal(ds.Tables[0].Rows[0]["Balance"]);
                            rptRoomRentAdvance advRent = new rptRoomRentAdvance();
                            advRent.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)advRent;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("FromDate", advFrom);
                            rptPrint.SetParameterValue("ToDate", advTo);
                            rptPrint.SetParameterValue("ClosingBalance", advclosingtotal);
                            rptPrint.SetParameterValue("Counter", advCntNo);
                            rptPrint.SetParameterValue("Cashier", advCashier);
                            rptPrint.SetParameterValue("Today", System.DateTime.Now.ToString("dd-MM-yyyy"));
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("RptCounter", null);
                            Session.Add("RptCashier", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            Session.Add("Days", null);
                            break;

                        case "Room Rent Advance Summary":
                            string advSCntNo = "ALL", advSFrom = "-", advSTo = "-";
                            string advSCashier = "ALL";
                            int advSdays = 0;

                            if (Session["Days"] != null)
                                advSdays = Convert.ToInt32(Session["Days"]);

                            if (Session["RptCounter"] != null)
                                advSCntNo = Convert.ToString(Session["RptCounter"]);
                            if (Session["RptCashier"] != null)
                                advSCashier = Convert.ToString(Session["RptCashier"]);
                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                advSFrom = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                advSTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                            {
                                advSFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                advSTo = DateTime.Now.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                advSFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                advSTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            }
                            Guid? iSAcctID = null;
                            if (Session["AcctID"] != null)
                                iSAcctID = new Guid(Convert.ToString(Session["AcctID"]));
                            DataSet Sds = BookKeepingBLL.GetRPTRoomRentAdvance_ClosingBal(clsSession.CompanyID, clsSession.PropertyID, null, null, iSAcctID, null, Convert.ToDateTime(Session["EndDate"]));
                            decimal advSclosingtotal = 0;
                            if (Sds.Tables[0].Rows.Count > 0)
                                advSclosingtotal = Convert.ToDecimal(Sds.Tables[0].Rows[0]["Balance"]);
                            rptRoomRentAdvance_Summary advSRent = new rptRoomRentAdvance_Summary();
                            advSRent.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)advSRent;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("FromDate", advSFrom);
                            rptPrint.SetParameterValue("ToDate", advSTo);
                            rptPrint.SetParameterValue("ClosingBalance", advSclosingtotal);
                            rptPrint.SetParameterValue("Counter", advSCntNo);
                            rptPrint.SetParameterValue("Cashier", advSCashier);
                            rptPrint.SetParameterValue("Today", System.DateTime.Now.ToString("dd-MM-yyyy"));
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("RptCounter", null);
                            Session.Add("RptCashier", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            Session.Add("Days", null);
                            break;

                        case "Occupancy Chart By Block & Room Type":
                            string OccFrom = "-", OccTo = "-";

                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                OccFrom = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                OccTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                            {
                                OccFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                OccTo = DateTime.Now.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                OccFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                OccTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            }

                            rptOccupancyChartByBlockAndRoomType OccBRT = new rptOccupancyChartByBlockAndRoomType();
                            OccBRT.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)OccBRT;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("FromDate", OccFrom);
                            rptPrint.SetParameterValue("ToDate", OccTo);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            Session.Add("Days", null);
                            break;

                        case "Occupancy Chart By Block & RateCard":
                            string OccRFrom = "-", OccRTo = "-";

                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                OccRFrom = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                OccRTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                            {
                                OccRFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                OccRTo = DateTime.Now.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                OccRFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                OccRTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            }

                            rptOccupancyChartByBlockAndRateCard OccBRC = new rptOccupancyChartByBlockAndRateCard();
                            OccBRC.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)OccBRC;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("FromDate", OccRFrom);
                            rptPrint.SetParameterValue("ToDate", OccRTo);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            Session.Add("Days", null);
                            break;

                        case "Bill Format":
                            rptInvoice Inv = new rptInvoice();
                            Inv.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)Inv;
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompContact", strPhoneEmail);
                            CRViewer.ReportSource = rptPrint;
                            break;

                        case "Bill Summary":
                            Reservation objRes;
                            double totalInfracharge = 0.00;
                            double totalFoodcharge = 0.00;
                            double totalElectricitycharge = 0.00;
                            if (Session["RptResID"] != null)
                            {
                                objRes = ReservationBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["RptResID"])));
                                // Method to get POS charge is changed, so pass ReservationID instead of RateID in this SP. SP is changed appropreatly.
                                DataSet dsPOSCharge = POSChargePerDayBLL.SelectByRateIDAndRoomTypeID((Guid)objRes.ReservationID, (Guid)objRes.RoomTypeID);

                                if (dsPOSCharge != null && dsPOSCharge.Tables[0].Rows.Count > 0)
                                {
                                    totalInfracharge = Convert.ToDouble(Convert.ToDecimal(dsPOSCharge.Tables[0].Rows[0]["PaidInfraServiceCharge"].ToString()));
                                }

                                if (dsPOSCharge != null && dsPOSCharge.Tables.Count > 1 && dsPOSCharge.Tables[1].Rows.Count > 0)
                                {
                                    totalFoodcharge = Convert.ToDouble(Convert.ToDecimal(dsPOSCharge.Tables[1].Rows[0]["PaidFoodCharge"].ToString()));
                                }

                                if (dsPOSCharge != null && dsPOSCharge.Tables.Count > 2 && dsPOSCharge.Tables[2].Rows.Count > 0)
                                {
                                    totalElectricitycharge = Convert.ToDouble(Convert.ToDecimal(dsPOSCharge.Tables[2].Rows[0]["PaidElectricityCharge"].ToString()));
                                }
                            }

                            if (this.DataSourceValue != null && this.DataSourceValue.Tables[0].Rows.Count > 0)
                            {
                                if (totalInfracharge > 0)
                                {
                                    DataRow dr1 = this.DataSourceValue.Tables[0].NewRow();
                                    dr1["GeneralIDType_Term"] = "Infra. Service Charge";
                                    dr1["Tax"] = "Infra. Service Charge";
                                    dr1["Charge"] = totalInfracharge.ToString();
                                    dr1["Credit"] = "0.00";
                                    this.DataSourceValue.Tables[0].Rows.Add(dr1);
                                }

                                if (totalFoodcharge > 0)
                                {
                                    DataRow dr1 = this.DataSourceValue.Tables[0].NewRow();
                                    dr1["GeneralIDType_Term"] = "Food Charge";
                                    dr1["Tax"] = "Food Charge";
                                    dr1["Charge"] = totalFoodcharge.ToString();
                                    dr1["Credit"] = "0.00";
                                    this.DataSourceValue.Tables[0].Rows.Add(dr1);
                                }

                                if (totalElectricitycharge > 0)
                                {
                                    DataRow dr1 = this.DataSourceValue.Tables[0].NewRow();
                                    dr1["GeneralIDType_Term"] = "Electricity and Water Charge";
                                    dr1["Tax"] = "Electricity Charge";
                                    dr1["Charge"] = totalElectricitycharge.ToString();
                                    dr1["Credit"] = "0.00";
                                    this.DataSourceValue.Tables[0].Rows.Add(dr1);
                                }
                            }

                            rptInvoiceSummary InvSum = new rptInvoiceSummary();
                            InvSum.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)InvSum;
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompContact", strPhoneEmail);
                            rptPrint.SetParameterValue("POSCharge", "0");
                            CRViewer.ReportSource = rptPrint;
                            //Session["RptResID"] = "";
                            break;

                        case "Vacant Room List":
                            string vF_Date = "-", vT_Date = "-";
                            string vRmType = "ALL";
                            if (Session["RptRmType"] != null)
                                vRmType = Convert.ToString(Session["RptRmType"]);

                            if (Session["StartDate"] != null)
                            {
                                vF_Date = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                            }

                            rptVacantList vacantList = new rptVacantList();
                            vacantList.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)vacantList;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("Date", vF_Date);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("RptRmType", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            break;

                        case "C-Form Report":
                            string cfromFrom = "-", cformTo = "-";

                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                cfromFrom = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                cformTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                            {
                                cfromFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                cformTo = DateTime.Now.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                cfromFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                cformTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            }

                            rptCForm cform = new rptCForm();
                            cform.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)cform;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("FromDate", cfromFrom);
                            rptPrint.SetParameterValue("ToDate", cformTo);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            break;

                        case "Cancellation Charges":
                            string canchrgGstNm = "ALL", canchrgFrom = "-", canchrgTo = "-";

                            if (Session["RptGstNM"] != null)
                                canchrgGstNm = Convert.ToString(Session["RptGstNM"]);

                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                canchrgFrom = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                canchrgTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                            {
                                canchrgFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                canchrgTo = DateTime.Now.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                canchrgFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                canchrgTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            }

                            rptCancellationCharges cancelCharge = new rptCancellationCharges();
                            cancelCharge.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)cancelCharge;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("FromDate", canchrgFrom);
                            rptPrint.SetParameterValue("ToDate", canchrgTo);
                            rptPrint.SetParameterValue("GuestName", canchrgGstNm);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("RptGstNM", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            break;

                        case "Retention Charges":
                            string retchrgGstNm = "ALL", retchrgFrom = "-", retchrgTo = "-";

                            if (Session["RptGstNM"] != null)
                                retchrgGstNm = Convert.ToString(Session["RptGstNM"]);

                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                retchrgFrom = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                retchrgTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                            {
                                retchrgFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                retchrgTo = DateTime.Now.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                retchrgFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                retchrgTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            }

                            rptRetentionCharges retCharge = new rptRetentionCharges();
                            retCharge.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)retCharge;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("FromDate", retchrgFrom);
                            rptPrint.SetParameterValue("ToDate", retchrgTo);
                            rptPrint.SetParameterValue("GuestName", retchrgGstNm);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("RptGstNM", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            break;

                        case "Room History":
                            string rmNo = "ALL", rmFrom = "-", rmTo = "-";

                            if (Session["RptRoomNM"] != null)
                                rmNo = Convert.ToString(Session["RptRoomNM"]);

                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                rmFrom = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                rmTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                            {
                                rmFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                rmTo = DateTime.Now.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                rmFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                rmTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            }

                            rptRoomHistory rmHistory = new rptRoomHistory();
                            rmHistory.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)rmHistory;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("FromDate", rmFrom);
                            rptPrint.SetParameterValue("ToDate", rmTo);
                            rptPrint.SetParameterValue("RoomNo", rmNo);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("RptRoomNM", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            break;

                        case "Company Posting":
                            string cpAgID = "ALL", cpFrom = "-", cpTo = "-";

                            if (Session["RptAgtNM"] != null)
                                cpAgID = Convert.ToString(Session["RptAgtNM"]);
                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                cpFrom = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                cpTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                            {
                                cpFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                cpTo = DateTime.Now.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                cpFrom = Convert.ToDateTime(Session["StartDate"]).ToString("dd-MM-yyyy");
                                cpTo = Convert.ToDateTime(Session["EndDate"]).ToString("dd-MM-yyyy");
                            }

                            rptCompanyPosting rptCP = new rptCompanyPosting();
                            rptCP.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)rptCP;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("FromDate", cpFrom);
                            rptPrint.SetParameterValue("ToDate", cpTo);
                            rptPrint.SetParameterValue("AgentName", cpAgID);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("RptAgtNM", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("~/Default.aspx");
                }
            }
            catch (Exception ex)
            {
            }
        }

        private string GetCounterTotal(DataView TheDataView)
        {
            DataView tmpdv = new DataView(TheDataView.Table);
            tmpdv.RowFilter = "(System_Amount <> 0.00 or Net_Amount <> 0.00) and Code <> 'TOTAL'";
            for (int i = 0; i < tmpdv.Count; i++)
            {
                if (tmpdv[i]["Code"].ToString().Trim().ToUpper().Equals("PAYMENT"))
                {
                    totpaidin += Convert.ToDouble(tmpdv[i]["System_Amount"]);
                }
                if (tmpdv[i]["Code"].ToString().Trim().ToUpper().Equals("PAID OUT"))
                {
                    totpaidout += Convert.ToDouble(tmpdv[i]["System_Amount"]);
                }
                if (tmpdv[i]["Code"].ToString().Trim().ToUpper().Equals("CITY LEDGER"))
                {
                    totcityledger += Convert.ToDouble(tmpdv[i]["System_Amount"]);
                }
            }
            tmptot = totpaidin + totcityledger - totpaidout;
            return tmptot.ToString("N");
        }

        private string GetNetCounterTotal(DataView TheDataView)
        {

            DataView tmpdv = new DataView(TheDataView.Table);

            tmpdv.RowFilter = "(System_Amount <> 0.00 or Net_Amount <> 0.00) and Code <> 'TOTAL'";
            for (int i = 0; i < tmpdv.Count; i++)
            {
                if (tmpdv[i]["Code"].ToString().Trim().ToUpper().Equals("PAYMENT"))
                {
                    netpaidin += Convert.ToDouble(tmpdv[i]["Net_Amount"]);
                }
                if (tmpdv[i]["Code"].ToString().Trim().ToUpper().Equals("PAID OUT"))
                {
                    netpaidout += Convert.ToDouble(tmpdv[i]["Net_Amount"]);
                }
            }
            nettot = netpaidin - netpaidout;
            return nettot.ToString("N");
        }

        public bool SendEmailMessage(string strTo, string strCc, string strSubject, string strMessage, string fileList)
        {
            List<PropertyConfiguration> objProperty = PropertyConfigurationBLL.GetAllBy(PropertyConfiguration.PropertyConfigurationFields.PropertyID, Convert.ToString(clsSession.PropertyID));
            try
            {
                MailMessage NetMail = new MailMessage();
                SmtpClient MailClient = new SmtpClient();

                string ThisHost = objProperty[0].SmtpAddress;

                NetworkCredential TheseCredentials = new NetworkCredential(objProperty[0].UserName, objProperty[0].Password);

                string ThisSender = "UniWorld <  " + objProperty[0].UserName + " >";

                NetMail.To.Add(strTo);
                NetMail.From = new MailAddress(objProperty[0].UserName);
                NetMail.ReplyTo = new MailAddress(objProperty[0].UserName);
                NetMail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                NetMail.IsBodyHtml = true;
                NetMail.Priority = MailPriority.High;
                NetMail.Subject = strSubject;
                NetMail.Body = strMessage;
                //attach each file attachment
                if (fileList != "")
                {
                    Attachment MsgAttach = new Attachment(fileList);
                    NetMail.Attachments.Add(MsgAttach);
                }
                MailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailClient.Host = ThisHost;
                MailClient.UseDefaultCredentials = false;
                MailClient.Credentials = TheseCredentials;
                MailClient.Send(NetMail);
                return true;
            }
            catch (SmtpException se)
            {
                try
                {
                    SmtpClient sc = new SmtpClient(objProperty[0].SmtpAddress, 587);
                    sc.EnableSsl = true;
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.UseDefaultCredentials = false;
                    sc.Credentials = new NetworkCredential(objProperty[0].UserName, objProperty[0].Password);
                    MailMessage mail = new MailMessage();
                    mail.To.Add(new MailAddress(strTo));
                    mail.From = new MailAddress(objProperty[0].UserName);
                    mail.Subject = strSubject;
                    mail.IsBodyHtml = true;
                    //attach each file attachment
                    if (fileList != "")
                    {
                        Attachment MsgAttach = new Attachment(fileList);
                        mail.Attachments.Add(MsgAttach);
                    }
                    mail.ReplyTo = new MailAddress(objProperty[0].UserName);
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    mail.Priority = MailPriority.High;
                    mail.Body = strMessage;
                    sc.Send(mail);
                    return true;
                }
                catch (SmtpException s)
                {
                    return false;
                }
            }
        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            try
            {
                exportPath = CheckDirectory();
                RptName = "Bill Format";
                rptPrint.ExportToDisk(ExportFormatType.PortableDocFormat, exportPath + "\\BillInvoice" + s_DateTimeStamp + ".pdf");
                DataSet ds = this.DataSourceValue;
                if (ds != null)
                {
                    string strSubject = "Invoice of Reservation - " + Convert.ToString(ds.Tables[0].Rows[0]["ReservationNo"]);
                    string strMailMsg = "Here sending you Invoice No : " + Convert.ToString(ds.Tables[0].Rows[0]["InvoiceNo"]) + " for Reservation No. " + Convert.ToString(ds.Tables[0].Rows[0]["ReservationNo"]) + ".<br /> Please find the attachment for same.";
                    string strHTML = File.ReadAllText(Server.MapPath("~/EmailTemplate/InvoiceTemplate.htm"));
                    strHTML = strHTML.Replace("$FULLNAME$", Convert.ToString(ds.Tables[0].Rows[0]["Guest_Name"]));
                    strHTML = strHTML.Replace("$BODY$", Convert.ToString(strMailMsg));
                    Company obj = CompanyBLL.GetByPrimaryKey(clsSession.CompanyID);
                    strHTML = strHTML.Replace("$COMPANYCONTACTNO$", Convert.ToString(obj.PrimoryContactNo));
                    bool flg = SendEmailMessage(Convert.ToString(ds.Tables[0].Rows[0]["Email"]), "", strSubject, strHTML, exportPath + "\\BillInvoice" + s_DateTimeStamp + ".pdf");
                    if (flg)
                    {
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Mail Sent Successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}