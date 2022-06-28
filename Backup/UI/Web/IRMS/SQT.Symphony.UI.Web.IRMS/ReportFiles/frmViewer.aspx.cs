using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Text.RegularExpressions;

namespace SQT.Symphony.UI.Web.IRMS.ReportFiles
{
    public partial class frmViewer : System.Web.UI.Page
    {
        string ReportName = "";
        DataSet DataSourceValue;
        bool IsPreview = true;
        public string strdate;
        public string ExportMode;
        CrystalDecisions.CrystalReports.Engine.ReportDocument rptPrint;
        CrystalDecisions.Shared.DiskFileDestinationOptions dskdstOpt = new DiskFileDestinationOptions();
        HTMLFormatOptions HTMLExpOpts = new HTMLFormatOptions();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["preview"] != null)
                this.IsPreview = Convert.ToBoolean(Request.QueryString["preview"]);
            if (Session["ReportName"] != null)
                this.ReportName = Convert.ToString(Session["ReportName"]);
            if (Session["ExportMode"] != null)
                this.ExportMode = Convert.ToString(Session["ExportMode"]);
            //  if (!IsPostBack)
            //  {
            this.DataSourceValue = (DataSet)Session["DataSource"];
            SetParameter();
            CRViewer.SeparatePages = false;
            CRViewer.EnableDatabaseLogonPrompt = false;
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
                    rptPrint.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    //System.Threading.Thread.Sleep(1500);
                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "clientScript", "<script>javascript:window.print();</script>");
                    ////ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script>fnPrintPage();</script>");

                    //Response.Buffer = false;
                    //// Clear the response content and headers
                    //Response.ClearContent();
                    //Response.ClearHeaders();
                    try
                    {
                        // Export the Report to Response stream in HTML format and file name ReportName
                        //rptPrint.ExportToHttpResponse(ExportFormatType.HTML40, Response, false, this.ReportName);
                        //ClientScript.RegisterClientScriptBlock(this.GetType(), "clientScript", "<script>javascript:window.print();</script>");                       
                        // There are other format options available such as Word, Excel, CVS, and HTML in the ExportFormatType Enum given by crystal reports
                        //dskdstOpt.DiskFileName = @"c:\tmp\html\b.html";
                        //HTMLExpOpts = new HTMLFormatOptions();
                        ////HTMLExpOpts.HTMLFileName = @"c:\tmp\html\phonebook report that looks real purdy.html";
                        //HTMLExpOpts.HTMLBaseFolderName = @"c:\tmp\html\b.html";
                        //HTMLExpOpts.HTMLEnableSeparatedPages = false;
                        //HTMLExpOpts.UsePageRange = false;
                        //HTMLExpOpts.HTMLHasPageNavigator = false;

                        //System.IO.Stream oStream;
                        //byte[] byteArray = null;

                        ////oStream = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.CharacterSeparatedValues);
                        //oStream = rptPrint.ExportToStream(CrystalDecisions.Shared.ExportFormatType.HTML32);
                        //byteArray = new byte[oStream.Length];
                        //oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));

                        //// this is used to verify the file so I saved it to disk
                        //System.IO.File.Create(dskdstOpt.DiskFileName, Convert.ToInt32(oStream.Length - 1)).Close();

                        //System.IO.File.OpenWrite(dskdstOpt.DiskFileName).Write(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
                        //System.IO.File.SetAttributes(dskdstOpt.DiskFileName, System.IO.FileAttributes.Directory);
                        //oStream.Close();

                        //GC.Collect();
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
                btnPrint.Visible = false;
            }
            //  }   
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
                    //strPhoneEmail = "Phone : " + objCmpData.PrimaryPhone + " Email : " + objCmpData.PrimaryEmail + " Url : " + objCmpData.PrimaryUrl;
                    strPhoneEmail = "Email : " + objCmpData.PrimaryEmail + " Url : " + objCmpData.PrimaryUrl;
                    switch (ReportName)
                    {
                        case "Investor Detail Report":
                            rptInvestorDetailReport invDetailreport = new rptInvestorDetailReport();
                            invDetailreport.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)invDetailreport;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            CRViewer.ReportSource = rptPrint;
                            break;
                        case "Investor Rent Payout Detail":
                            rpt_RentPayoutDetail invRentPayoutDetail = new rpt_RentPayoutDetail();
                            invRentPayoutDetail.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)invRentPayoutDetail;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Period", Session["QuarterPeriodToPrint"]);
                            rptPrint.SetParameterValue("QuarterTitle", Session["QuarterTitleToPrint"]);
                            CRViewer.ReportSource = rptPrint;
                            Session["QuarterTitleToPrint"] = null;
                            Session["QuarterPeriodToPrint"] = null;
                            break;
                        case "Investor Rent Payout":
                            rpt_RentPayoutconsolidateWithTotal invrentpayoutList = new rpt_RentPayoutconsolidateWithTotal();
                            invrentpayoutList.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)invrentpayoutList;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Period", Session["QuarterPeriodToPrint"]);
                            rptPrint.SetParameterValue("QuarterTitle", Session["QuarterTitleToPrint"]);
                            CRViewer.ReportSource = rptPrint;
                            Session["QuarterTitleToPrint"] = null;
                            Session["QuarterPeriodToPrint"] = null;
                            break;
                        case "Prospects List":
                            string pName = "ALL", pCity = "ALL", pReference = "ALL", pStatus = "ALL", pRegion = "ALL";
                            if (Session["Name"] != null)
                                pName = Convert.ToString(Session["Name"]);
                            if (Session["City"] != null)
                                pCity = Convert.ToString(Session["City"]);
                            if (Session["Reference"] != null)
                                pReference = Convert.ToString(Session["Reference"]);
                            if (Session["Status"] != null)
                                pStatus = Convert.ToString(Session["Status"]);
                            if (Session["Region"] != null)
                                pRegion = Convert.ToString(Session["Region"]);
                            rptProspectsList prospList = new rptProspectsList();
                            prospList.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)prospList;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Name", pName);
                            rptPrint.SetParameterValue("City", pCity);
                            rptPrint.SetParameterValue("Status", pStatus);
                            rptPrint.SetParameterValue("Reference", pReference);
                            rptPrint.SetParameterValue("Region", pRegion);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("Name", null);
                            Session.Add("City", null);
                            Session.Add("Status", null);
                            Session.Add("Reference", null);
                            Session.Add("Region", null);
                            break;

                        case "Investor List":
                            string iName = "ALL", iMobile = "ALL", iEmail = "ALL", iCity = "ALL", iOccupation = "ALL", iCompany = "ALL";
                            if (Session["Name"] != null)
                                iName = Convert.ToString(Session["Name"]);
                            if (Session["Mobile"] != null)
                                iMobile = Convert.ToString(Session["Mobile"]);
                            if (Session["Email"] != null)
                                iEmail = Convert.ToString(Session["Email"]);
                            if (Session["City"] != null)
                                iCity = Convert.ToString(Session["City"]);
                            if (Session["Occupation"] != null)
                                iOccupation = Convert.ToString(Session["Occupation"]);
                            if (Session["Company"] != null)
                                iCompany = Convert.ToString(Session["Company"]);
                            rptInvestorList investorList = new rptInvestorList();
                            investorList.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)investorList;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Name", iName);
                            rptPrint.SetParameterValue("Mobile", iMobile);
                            rptPrint.SetParameterValue("Email", iEmail);
                            rptPrint.SetParameterValue("City", iCity);
                            rptPrint.SetParameterValue("Occupation", iOccupation);
                            rptPrint.SetParameterValue("Company", iCompany);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("Name", null);
                            Session.Add("Mobile", null);
                            Session.Add("Email", null);
                            Session.Add("City", null);
                            Session.Add("Occupation", null);
                            Session.Add("Company", null);
                            break;

                        case "Channel Partner List":
                            string cName = "ALL", cCity = "ALL", cMobileNo = "ALL", cEmail = "ALL", cCompName = "ALL";
                            if (Session["Name"] != null)
                                cName = Convert.ToString(Session["Name"]);
                            if (Session["City"] != null)
                                cCity = Convert.ToString(Session["City"]);
                            if (Session["MobileNo"] != null)
                                cMobileNo = Convert.ToString(Session["MobileNo"]);
                            if (Session["Email"] != null)
                                cEmail = Convert.ToString(Session["Email"]);
                            if (Session["CompName"] != null)
                                cCompName = Convert.ToString(Session["CompName"]);
                            rptChannelPartner CPList = new rptChannelPartner();
                            CPList.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)CPList;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Name", cName);
                            rptPrint.SetParameterValue("City", cCity);
                            rptPrint.SetParameterValue("MobileNo", cMobileNo);
                            rptPrint.SetParameterValue("Email", cEmail);
                            rptPrint.SetParameterValue("CompName", cCompName);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("Name", null);
                            Session.Add("City", null);
                            Session.Add("MobileNo", null);
                            Session.Add("Email", null);
                            Session.Add("CompName", null);
                            break;

                        case "Sales List":
                            string sName = "ALL", sMobile = "ALL", sEmail = "ALL", sCity = "ALL", sDisplayName = "ALL";
                            if (Session["Name"] != null)
                                sName = Convert.ToString(Session["Name"]);
                            if (Session["DisplayName"] != null)
                                sDisplayName = Convert.ToString(Session["DisplayName"]);
                            if (Session["Mobile"] != null)
                                sMobile = Convert.ToString(Session["Mobile"]);
                            if (Session["Email"] != null)
                                sEmail = Convert.ToString(Session["Email"]);
                            if (Session["City"] != null)
                                sCity = Convert.ToString(Session["City"]);
                            rptSalesList salesList = new rptSalesList();
                            salesList.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)salesList;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Name", sName);
                            rptPrint.SetParameterValue("DisplayName", sDisplayName);
                            rptPrint.SetParameterValue("Mobile", sMobile);
                            rptPrint.SetParameterValue("Email", sEmail);
                            rptPrint.SetParameterValue("City", sCity);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("Name", null);
                            Session.Add("DisplayName", null);
                            Session.Add("Mobile", null);
                            Session.Add("Email", null);
                            Session.Add("City", null);
                            break;

                        case "Unit Booking List":
                            string block = "ALL", floor = "ALL", unitType = "ALL", uInvestor = "ALL", unit = "ALL";
                            if (Session["Block"] != null)
                                block = Convert.ToString(Session["Block"]);
                            if (Session["Floor"] != null)
                                floor = Convert.ToString(Session["Floor"]);
                            if (Session["UnitType"] != null)
                                unitType = Convert.ToString(Session["UnitType"]);
                            if (Session["Investor"] != null)
                                uInvestor = Convert.ToString(Session["Investor"]);
                            if (Session["Unit"] != null)
                                unit = Convert.ToString(Session["Unit"]);
                            rptUnitBooking UBList = new rptUnitBooking();
                            UBList.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)UBList;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Block", block);
                            rptPrint.SetParameterValue("Floor", floor);
                            rptPrint.SetParameterValue("UnitType", unitType);
                            rptPrint.SetParameterValue("Investor", uInvestor);
                            rptPrint.SetParameterValue("Unit", unit);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("Block", null);
                            Session.Add("Floor", null);
                            Session.Add("UnitType", null);
                            Session.Add("Investor", null);
                            Session.Add("Unit", null);
                            break;

                        case "LogIn Log List":
                            string LogName = "ALL", LogRole = "ALL", LogDate = "-";
                            if (Session["Name"] != null)
                                LogName = Convert.ToString(Session["Name"]);
                            if (Session["Role"] != null)
                                LogRole = Convert.ToString(Session["Role"]);
                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                LogDate = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                LogDate = Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                                LogDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + DateTime.Now.ToString("dd/MM/yyyy");
                            else
                                LogDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");

                            rptLogInLog LoginList = new rptLogInLog();
                            LoginList.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)LoginList;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Name", LogName);
                            rptPrint.SetParameterValue("Role", LogRole);
                            rptPrint.SetParameterValue("Date", LogDate);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("Name", null);
                            Session.Add("Role", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            break;

                        case "Action Log List":
                            string ActName = "ALL", ActType = "ALL", ActObject = "ALL", ActDate = "-";
                            if (Session["Name"] != null)
                                ActName = Convert.ToString(Session["Name"]);
                            if (Session["ActionType"] != null)
                                ActType = Convert.ToString(Session["ActionType"]);
                            if (Session["ActionObject"] != null)
                                ActObject = Convert.ToString(Session["ActionObject"]);
                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                ActDate = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                ActDate = Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                                ActDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + DateTime.Now.ToString("dd/MM/yyyy");
                            else
                                ActDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");

                            rptActionLog ALList = new rptActionLog();
                            ALList.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)ALList;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Name", ActName);
                            rptPrint.SetParameterValue("ActionType", ActType);
                            rptPrint.SetParameterValue("ActionObject", ActObject);
                            rptPrint.SetParameterValue("Date", ActDate);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("Name", null);
                            Session.Add("ActionType", null);
                            Session.Add("ActionObject", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            break;

                        case "Payment Alert List":
                            string pAProperty = "ALL", pAInvestor = "ALL", pAUnit = "ALL", pAStartDate = "-";
                            if (Session["Property"] != null)
                                pAProperty = Convert.ToString(Session["Property"]);
                            if (Session["Investor"] != null)
                                pAInvestor = Convert.ToString(Session["Investor"]);
                            if (Session["Unit"] != null)
                                pAUnit = Convert.ToString(Session["Unit"]);
                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                pAStartDate = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                pAStartDate = Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                                pAStartDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + DateTime.Now.ToString("dd/MM/yyyy");
                            else
                                pAStartDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");

                            rptPaymentAlerts payAlerts = new rptPaymentAlerts();
                            payAlerts.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)payAlerts;
                            rptPrint.OpenSubreport("subrptSummaryDueStatus").SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Property", pAProperty);
                            rptPrint.SetParameterValue("Investor", pAInvestor);
                            rptPrint.SetParameterValue("Unit", pAUnit);
                            rptPrint.SetParameterValue("Date", pAStartDate);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("Property", null);
                            Session.Add("Investor", null);
                            Session.Add("Unit", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            break;

                        case "Payment Receipt List":
                            string pRProperty = "ALL", pRInvestor = "ALL", pRUnit = "ALL", pRStartDate = "-";
                            if (Session["Property"] != null)
                                pRProperty = Convert.ToString(Session["Property"]);
                            if (Session["Investor"] != null)
                                pRInvestor = Convert.ToString(Session["Investor"]);
                            if (Session["Unit"] != null)
                                pRUnit = Convert.ToString(Session["Unit"]);
                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                pRStartDate = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                pRStartDate = Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                                pRStartDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + DateTime.Now.ToString("dd/MM/yyyy");
                            else
                                pRStartDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");

                            rptPaymentReceiptList payReceiptList = new rptPaymentReceiptList();
                            payReceiptList.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)payReceiptList;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Property", pRProperty);
                            rptPrint.SetParameterValue("Investor", pRInvestor);
                            rptPrint.SetParameterValue("Unit", pRUnit);
                            rptPrint.SetParameterValue("StartDate", pRStartDate);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("Property", null);
                            Session.Add("Investor", null);
                            Session.Add("Unit", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            break;

                        case "Payment Information":
                            string pIpropertyName = "ALL", pIunitNo = "ALL";
                            if (Session["Property"] != null)
                                pIpropertyName = Convert.ToString(Session["Property"]);
                            if (Session["Unit"] != null)
                                pIunitNo = Convert.ToString(Session["Unit"]);

                            rptPaymentAgainstUnit payInfo = new rptPaymentAgainstUnit();
                            payInfo.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)payInfo;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Name", pIpropertyName);
                            rptPrint.SetParameterValue("Role", pIunitNo);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("Property", null);
                            Session.Add("Unit", null);
                            break;

                        case "Unit Information":
                            string uIpropertyName = "ALL", uIunitType = "ALL";
                            if (Session["Property"] != null)
                                uIpropertyName = Convert.ToString(Session["Property"]);
                            if (Session["UnitType"] != null)
                                uIunitType = Convert.ToString(Session["UnitType"]);

                            rptUnitInformation unitInfo = new rptUnitInformation();
                            unitInfo.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)unitInfo;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Name", uIpropertyName);
                            rptPrint.SetParameterValue("Role", uIunitType);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("Property", null);
                            Session.Add("UnitType", null);
                            break;

                        case "Property Tax & Insurance":
                            string TIpropertyName = "ALL", TIunitNo = "ALL";
                            string strSDate = "", strEDate = "";
                            if (Session["Property"] != null)
                                TIpropertyName = Convert.ToString(Session["Property"]);
                            if (Session["Unit"] != null)
                                TIunitNo = Convert.ToString(Session["Unit"]);
                            if (Session["StartDate"] != null)
                                strSDate = Convert.ToString(Session["StartDate"]);
                            if (Session["EndDate"] != null)
                                strEDate = Convert.ToString(Session["EndDate"]);

                            rptInvestorPropertyTaxList taxIns = new rptInvestorPropertyTaxList();
                            taxIns.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)taxIns;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Name", TIpropertyName);
                            rptPrint.SetParameterValue("Role", TIunitNo);
                            rptPrint.SetParameterValue("StartDate", strSDate);
                            rptPrint.SetParameterValue("EndDate", strEDate);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("Property", null);
                            Session.Add("Unit", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            break;

                        case "Investor Payment Details":
                            string scheduleType = "ALL", pdUnitType = "ALL", pdUnit = "ALL", pdTotal = "ALL";
                            if (Session["Name"] != null)
                                scheduleType = Convert.ToString(Session["Name"]);
                            if (Session["Unit"] != null)
                                pdUnitType = Convert.ToString(Session["Unit"]);
                            if (Session["UnitNo"] != null)
                                pdUnit = Convert.ToString(Session["UnitNo"]);
                            if (Session["Total"] != null)
                                pdTotal = Convert.ToString(Session["Total"]);

                            rptPaymentDetails rptPD = new rptPaymentDetails();
                            rptPD.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)rptPD;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Name", scheduleType);
                            rptPrint.SetParameterValue("UnitType", pdUnitType);
                            rptPrint.SetParameterValue("Unit", pdUnit);
                            rptPrint.SetParameterValue("Total", pdTotal);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("Name", null);
                            Session.Add("Unit", null);
                            Session.Add("UnitType", null);
                            Session.Add("Total", null);
                            break;

                        case "Investor GridList":
                            string iGName = "ALL", iGCity = "ALL", iCPF = "ALL", iExeNm = "ALL";
                            if (Session["Name"] != null)
                                iGName = Convert.ToString(Session["Name"]);
                            if (Session["City"] != null)
                                iGCity = Convert.ToString(Session["City"]);
                            if (Session["ChannelPartnerFirm"] != null)
                                iCPF = Convert.ToString(Session["ChannelPartnerFirm"]);
                            if (Session["ExecutiveName"] != null)
                                iExeNm = Convert.ToString(Session["ExecutiveName"]);
                            rptInvestorGridList investorGList = new rptInvestorGridList();
                            investorGList.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)investorGList;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Name", iGName);
                            rptPrint.SetParameterValue("City", iGCity);
                            rptPrint.SetParameterValue("ChannelPartnerFirm", iCPF);
                            rptPrint.SetParameterValue("ExecutiveName", iExeNm);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("Name", null);
                            Session.Add("City", null);
                            Session.Add("ChannelPartnerFirm", null);
                            Session.Add("ExecutiveName", null);
                            break;

                        case "Total Sales":
                            string tsProperty = "ALL", tsRefTh = "ALL", tsDate = "-";
                            if (Session["Property"] != null)
                                tsProperty = Convert.ToString(Session["Property"]);
                            if (Session["RefThrough"] != null)
                                tsRefTh = Convert.ToString(Session["RefThrough"]);
                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                tsDate = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                tsDate = Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                                tsDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + DateTime.Now.ToString("dd/MM/yyyy");
                            else
                                tsDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");

                            rptTotalSales totSales = new rptTotalSales();
                            totSales.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)totSales;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Name", tsProperty);
                            rptPrint.SetParameterValue("ReferenceThrough", tsRefTh);
                            rptPrint.SetParameterValue("Date", tsDate);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("Property", null);
                            Session.Add("RefThrough", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            break;

                        case "Payment Due Report":
                            string pdProperty = "ALL", pdInv = "ALL", pdDate = "-";
                            if (Session["Property"] != null)
                                pdProperty = Convert.ToString(Session["Property"]);
                            if (Session["Investor"] != null)
                                pdInv = Convert.ToString(Session["Investor"]);
                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                pdDate = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                pdDate = Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                                pdDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + DateTime.Now.ToString("dd/MM/yyyy");
                            else
                                pdDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");

                            rptPaymentDueReport paymentDue = new rptPaymentDueReport();
                            paymentDue.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)paymentDue;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Name", pdProperty);
                            rptPrint.SetParameterValue("Investor", pdInv);
                            rptPrint.SetParameterValue("Date", pdDate);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("Property", null);
                            Session.Add("Investor", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            break;

                        case "Investor Terms":
                            string iTermInv = "ALL", iTermDate = "-", iTermUnit = "ALL", iTermUnitNo = "ALL";
                            if (Session["Investor"] != null)
                                iTermInv = Convert.ToString(Session["Investor"]);
                            if (Session["UnitType"] != null)
                                iTermUnit = Convert.ToString(Session["UnitType"]);
                            if (Session["Unit"] != null)
                                iTermUnitNo = Convert.ToString(Session["Unit"]);
                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                iTermDate = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                iTermDate = Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                                iTermDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + DateTime.Now.ToString("dd/MM/yyyy");
                            else
                                iTermDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");

                            rptInvestorTerm invTerm = new rptInvestorTerm();
                            invTerm.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)invTerm;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Investor", iTermInv);
                            rptPrint.SetParameterValue("Date", iTermDate);
                            rptPrint.SetParameterValue("UnitType", iTermUnit);
                            rptPrint.SetParameterValue("UnitNo", iTermUnitNo);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("Investor", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            Session.Add("UnitType", null);
                            Session.Add("Unit", null);
                            break;

                        case "Investor Bank Detail":
                            string ibdInv = "ALL";
                            if (Session["Investor"] != null)
                                ibdInv = Convert.ToString(Session["Investor"]);

                            rptInvestorBankDetail invBankDetail = new rptInvestorBankDetail();
                            invBankDetail.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)invBankDetail;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Investor", ibdInv);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("Investor", null);
                            break;

                        case "Investor Documentation":
                            string idocInv = "ALL", idocUnit = "ALL", idocUnitNo = "ALL";
                            if (Session["Investor"] != null)
                                idocInv = Convert.ToString(Session["Investor"]);
                            if (Session["UnitType"] != null)
                                idocUnit = Convert.ToString(Session["UnitType"]);
                            if (Session["Unit"] != null)
                                idocUnitNo = Convert.ToString(Session["Unit"]);

                            rptInvestorDocumentation invDoc = new rptInvestorDocumentation();
                            invDoc.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)invDoc;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Name", idocInv);
                            rptPrint.SetParameterValue("UnitType", idocUnit);
                            rptPrint.SetParameterValue("UnitNo", idocUnitNo);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("Investor", null);
                            Session.Add("UnitType", null);
                            Session.Add("Unit", null);
                            break;

                        case "Ledger Statement":
                            string lsProp = "ALL", lsInv = "ALL", lsDate = "-";
                            string lsOpenBal_MS = "0", lsOpenBal_Rec = "0", lsBalCr = "0", lsBalDue = "0", lsTot_MS = "0.00", lsTot_Rec = "0.00";
                            if (Session["Led_stmt_Property"] != null)
                                lsProp = Convert.ToString(Session["Led_stmt_Property"]);
                            if (Session["Led_stmt_Investor"] != null)
                                lsInv = Convert.ToString(Session["Led_stmt_Investor"]);
                            if (Session["Led_stmt_OpeningBalance_MileStone"] != null)
                                lsOpenBal_MS = Convert.ToString(Session["Led_stmt_OpeningBalance_MileStone"]);
                            if (Session["Led_stmt_OpeningBalance_Receipt"] != null)
                                lsOpenBal_Rec = Convert.ToString(Session["Led_stmt_OpeningBalance_Receipt"]);
                            if (Session["Led_stmt_BalanceCredit"] != null)
                                lsBalCr = Convert.ToString(Session["Led_stmt_BalanceCredit"]);
                            if (Session["Led_stmt_BalanceDue"] != null)
                                lsBalDue = Convert.ToString(Session["Led_stmt_BalanceDue"]);
                            if (Session["Led_stmt_Total_MileStone"] != null)
                                lsTot_MS = Convert.ToString(Session["Led_stmt_Total_MileStone"]);
                            if (Session["Led_stmt_Total_Rec"] != null)
                                lsTot_Rec = Convert.ToString(Session["Led_stmt_Total_Rec"]);
                            if (Session["Led_stmt_StartDate"] == null && Session["Led_stmt_EndDate"] == null)
                                lsDate = "-";
                            else if (Session["Led_stmt_StartDate"] == null && Session["Led_stmt_EndDate"] != null)
                                lsDate = "UpTo " + Convert.ToDateTime(Session["Led_stmt_EndDate"]).ToString("dd/MM/yyyy");
                            else if (Session["Led_stmt_StartDate"] != null && Session["Led_stmt_EndDate"] == null)
                                lsDate = "From " + Convert.ToDateTime(Session["Led_stmt_StartDate"]).ToString("dd/MM/yyyy");
                            else
                                lsDate = Convert.ToDateTime(Session["Led_stmt_StartDate"]).ToString("dd/MM/yyyy") + " To " + Convert.ToDateTime(Session["Led_stmt_EndDate"]).ToString("dd/MM/yyyy");

                            rptLedgerStatement rptLS = new rptLedgerStatement();
                            DataTable dt = new DataTable();
                            dt = this.DataSourceValue.Tables[0];

                            bool blIsMerged = false;
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                if (dt.Columns[i].ColumnName.ToString().ToUpper() == "INVESTORPAYMENTRECEIPTID")
                                {
                                    blIsMerged = true;
                                    break;
                                }
                            }

                            if (!blIsMerged)
                            {
                                dt.Merge(this.DataSourceValue.Tables[2]);
                            }

                            //dt.Merge(this.DataSourceValue.Tables[2]);
                            dt.TableName = "irm_InvestorPaymentSchedule_GetLadgerStatement";
                            rptLS.SetDataSource(dt);
                            rptLS.OpenSubreport("subrpt_Receipt").SetDataSource(dt);
                            rptLS.OpenSubreport("subrpt_Milestone").SetDataSource(dt);
                            rptPrint = (ReportDocument)rptLS;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Name", lsProp);
                            rptPrint.SetParameterValue("Investor", lsInv);
                            rptPrint.SetParameterValue("OB_MS", lsOpenBal_MS);
                            rptPrint.SetParameterValue("OB_Rec", lsOpenBal_Rec);
                            rptPrint.SetParameterValue("BalCr", lsBalCr);
                            rptPrint.SetParameterValue("BalDue", lsBalDue);
                            rptPrint.SetParameterValue("Total_MileStone", lsTot_MS);
                            rptPrint.SetParameterValue("Total_Rec", lsTot_Rec);
                            rptPrint.SetParameterValue("Date", lsDate);
                            CRViewer.ReportSource = rptPrint;
                            break;

                        case "Conversion Executive":
                            string ceCPF = "ALL", ceExeName = "ALL", ceDate = "-";
                            if (Session["ChannelPartnerFirm"] != null)
                                ceCPF = Convert.ToString(Session["ChannelPartnerFirm"]);
                            if (Session["ExecutiveName"] != null)
                                ceExeName = Convert.ToString(Session["ExecutiveName"]);
                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                ceDate = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                ceDate = Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                                ceDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + DateTime.Now.ToString("dd/MM/yyyy");
                            else
                                ceDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");

                            rptConversionExecutive conversionexecutive = new rptConversionExecutive();
                            conversionexecutive.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)conversionexecutive;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("ChannelPartnerFirm", ceCPF);
                            rptPrint.SetParameterValue("Date", ceDate);
                            rptPrint.SetParameterValue("ExecutiveName", ceExeName);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("ChannelPartnerFirm", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            Session.Add("ExecutiveName", null);
                            break;

                        case "Conversion Executive_CP":
                            string ce_cpPF = "ALL", ce_cpDate = "-";
                            if (Session["ChannelPartnerFirm"] != null)
                                ce_cpPF = Convert.ToString(Session["ChannelPartnerFirm"]);
                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                ce_cpDate = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                ce_cpDate = Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                                ce_cpDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + DateTime.Now.ToString("dd/MM/yyyy");
                            else
                                ce_cpDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");

                            rptConversionCP conversionCP = new rptConversionCP();
                            conversionCP.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)conversionCP;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("ChannelPartnerFirm", ce_cpPF);
                            rptPrint.SetParameterValue("Date", ce_cpDate);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("ChannelPartnerFirm", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            break;

                        case "Conversion Executive_RefThrough":
                            string ce_RefTh = "ALL", ce_Ref = "ALL", ceRefDate = "-";
                            if (Session["ReferenceThrough"] != null)
                                ce_RefTh = Convert.ToString(Session["ReferenceThrough"]);
                            if (Session["ReferenceName"] != null)
                                ce_Ref = Convert.ToString(Session["ReferenceName"]);
                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                ceRefDate = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                ceRefDate = Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                                ceRefDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + DateTime.Now.ToString("dd/MM/yyyy");
                            else
                                ceRefDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");

                            rptConversionRefThrough conversionRef = new rptConversionRefThrough();
                            conversionRef.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)conversionRef;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("ReferenceThrough", ce_RefTh);
                            rptPrint.SetParameterValue("Date", ceRefDate);
                            rptPrint.SetParameterValue("ReferenceName", ce_Ref);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("ReferenceThrough", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            Session.Add("ReferenceName", null);
                            break;

                        case "Location Analysis":
                            string laProp = "ALL", laCountry = "ALL", laDate = "-";
                            if (Session["Property"] != null)
                                laProp = Convert.ToString(Session["Property"]);
                            if (Session["Location"] != null)
                                laCountry = Convert.ToString(Session["Location"]);
                            if (Session["StartDate"] == null && Session["EndDate"] == null)
                                laDate = "-";
                            else if (Session["StartDate"] == null && Session["EndDate"] != null)
                                laDate = Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");
                            else if (Session["StartDate"] != null && Session["EndDate"] == null)
                                laDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + DateTime.Now.ToString("dd/MM/yyyy");
                            else
                                laDate = Convert.ToDateTime(Session["StartDate"]).ToString("dd/MM/yyyy") + " To " + Convert.ToDateTime(Session["EndDate"]).ToString("dd/MM/yyyy");

                            rptLocationAnalysis locAnalysis = new rptLocationAnalysis();
                            locAnalysis.SetDataSource(this.DataSourceValue.Tables[0]);
                            rptPrint = (ReportDocument)locAnalysis;
                            rptPrint.SetParameterValue("CompanyName", strCompName);
                            rptPrint.SetParameterValue("CompAddress", strCompAdd);
                            rptPrint.SetParameterValue("CompPhoneNo", strPhoneEmail);
                            rptPrint.SetParameterValue("Property", laProp);
                            rptPrint.SetParameterValue("Country", laCountry);
                            rptPrint.SetParameterValue("Date", laDate);
                            CRViewer.ReportSource = rptPrint;
                            Session.Add("Property", null);
                            Session.Add("StartDate", null);
                            Session.Add("EndDate", null);
                            Session.Add("Location", null);
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

    }
}