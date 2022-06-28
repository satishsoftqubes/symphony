using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.IO;
using System.Globalization;
using System.Text;

namespace SQT.Symphony.UI.Web.IRMS.Applications.Activity
{
    public partial class RentPayoutInvestorListPrint : System.Web.UI.Page
    {
        #region Property and Variable
        decimal dblTotalSqft = 0;
        public bool? IsPreview = false;
        decimal dblTotalYieldAmount = 0;
        public string DateFormat
        {
            get
            {
                return ViewState["DateFormat"] != null ? Convert.ToString(ViewState["DateFormat"]) : string.Empty;
            }
            set
            {
                ViewState["DateFormat"] = value;
            }
        }
        public Guid CompanyID
        {
            get
            {
                return ViewState["CompanyID"] != null ? new Guid(Convert.ToString(ViewState["CompanyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["CompanyID"] = value;
            }
        }
        public Guid QuarterID
        {
            get
            {
                return ViewState["QuarterID"] != null ? new Guid(Convert.ToString(ViewState["QuarterID"])) : Guid.Empty;
            }
            set
            {
                ViewState["QuarterID"] = value;
            }
        }
        public bool IsInsert = false;
        #endregion Property and Variable

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.DateFormat = "dd/MM/yyyy";
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                if (Request.QueryString != null && Request.QueryString["QID"] != "")
                {
                    this.QuarterID = new Guid(Convert.ToString(Request.QueryString["QID"]));
                    BindRentPayoutGrid();
                }
            }
        }
        #endregion Page Load

        #region Grid Event
        protected void gvAdminRendPayoutDetails_PageIndexChange(object sender, GridViewPageEventArgs e)
        {
            gvAdminRendPayoutDetails.PageIndex = e.NewPageIndex;
            BindRentPayoutGrid();
        }
        protected void gvAdminRendPayoutDetails_RowDatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Literal litTotalSFT = (Literal)e.Row.FindControl("litTotalSFT");
                Literal litTotalYieldAmount = (Literal)e.Row.FindControl("litTotalYieldAmount");

                if (litTotalSFT != null)
                {
                    litTotalSFT.Text = Convert.ToString(dblTotalSqft.ToString().Substring(0, dblTotalSqft.ToString().LastIndexOf(".") + 1 + 2));
                }
                if (litTotalYieldAmount != null)
                {
                    litTotalYieldAmount.Text = Convert.ToString(dblTotalYieldAmount.ToString().Substring(0, dblTotalYieldAmount.ToString().LastIndexOf(".") + 1 + 2));
                }

            }
        }
        #endregion Grid Event

        #region Private Method
        protected void LoadReport()
        {
            try
            {
                Session.Add("ReportName", "Investor Rent Payout Detail");
                DataSet dsForRentPayout = RentPayOutPerQuarterBLL.GetRentPayoutPerQuarterData(this.CompanyID, null, this.QuarterID, false,null,null,null,null);
                Session["DataSource"] = dsForRentPayout;

                ////More Search
                DataSet ds = new DataSet();
                ds = RentPayOutPerQuarterBLL.GetRentPayoutPerQuarterData(this.CompanyID, null, this.QuarterID, true, null, null, null, null);

                if (ds.Tables[0].Rows[0]["StartDateOfQtr"] != null && Convert.ToString(ds.Tables[0].Rows[0]["StartDateOfQtr"]) != "" && ds.Tables[0].Rows[0]["EndDate"] != null && Convert.ToString(ds.Tables[0].Rows[0]["EndDate"]) != "")
                {
                    Session.Add("QuarterTitleToPrint", Convert.ToString(ds.Tables[0].Rows[0]["QuarterTitle"]));
                    Session.Add("QuarterPeriodToPrint", Convert.ToString(ds.Tables[0].Rows[0]["StartDateOfQtr"]) + " to " + Convert.ToString(ds.Tables[0].Rows[0]["EndDate"]));
                }
                else
                {
                    Session.Add("QuarterTitleToPrint","");
                    Session.Add("QuarterPeriodToPrint", "");
                }

                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void BindRentPayoutGrid()
        {
            string CityName, FirmName, ExecutiveName = null;
            string InvestorName = null;

            if (Request["InvName"] != null && Request["InvName"] != "")
                InvestorName = Convert.ToString(Request["InvName"]);
            else
                InvestorName = null;

            if (Request["CityName"] != null && Request["CityName"] != "")
                CityName = Convert.ToString(Request["CityName"]);
            else
                CityName = null;

            if (Request["CPFirm"] != null && Request["CPFirm"] != "")
                FirmName = Convert.ToString(Request["CPFirm"]);
            else
                FirmName = null;

            if (Request["CPName"] != null && Request["CPName"] != "")
            {
                string[] strExecutiveName = Convert.ToString(Request["CPName"]).Trim().Split('-');

                if (strExecutiveName.Length > 0)
                    ExecutiveName = Convert.ToString(strExecutiveName[0]).Trim();
                else
                    ExecutiveName = "";
            }
            else
                ExecutiveName = null;

            DataSet dsForRentPayout = RentPayOutPerQuarterBLL.GetRentPayoutPerQuarterData(this.CompanyID, null, this.QuarterID, false, InvestorName, CityName, FirmName, ExecutiveName);
            if (dsForRentPayout != null && dsForRentPayout.Tables.Count > 0 && dsForRentPayout.Tables[0] != null && dsForRentPayout.Tables[0].Rows.Count > 0)
            {
                if (dsForRentPayout.Tables[0].Rows[0]["StartDateOfQtr"] != null && Convert.ToString(dsForRentPayout.Tables[0].Rows[0]["StartDateOfQtr"]) != "" && dsForRentPayout.Tables[0].Rows[0]["EndDate"] != null && Convert.ToString(dsForRentPayout.Tables[0].Rows[0]["EndDate"]) != "")
                    litQuarterPeriod.Text = Convert.ToString(dsForRentPayout.Tables[0].Rows[0]["StartDateOfQtr"]) + " to " + Convert.ToString(dsForRentPayout.Tables[0].Rows[0]["EndDate"]);
                else
                    litQuarterPeriod.Text = "";

                if (dsForRentPayout.Tables[0].Rows[0]["QuarterTitle"] != null)
                    litDispQuarterTitle.Text = Convert.ToString(dsForRentPayout.Tables[0].Rows[0]["QuarterTitle"]);
                else
                    litDispQuarterTitle.Text = "";

                decimal TotalSFT = 0;
                decimal TotalYieldAmount = 0;

                TotalSFT = (decimal)dsForRentPayout.Tables[0].Compute("sum(TotalSqft)", "InvName IS NOT NULL");
                TotalYieldAmount = (decimal)dsForRentPayout.Tables[0].Compute("sum(YieldAmount)", "InvName IS NOT NULL");
                dblTotalSqft = TotalSFT;
                dblTotalYieldAmount = TotalYieldAmount;
            }
            gvAdminRendPayoutDetails.DataSource = dsForRentPayout;
            gvAdminRendPayoutDetails.DataBind();

        }
        #endregion Private Method

        #region Control Event
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            this.IsPreview = true;
            Session.Add("ExportMode", null);
            LoadReport();
        }

        protected void imgbtnPDF_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "PDF");
            LoadReport();
        }

        protected void imgbtnXLSX_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "XLSX");
            LoadReport();
        }

        protected void imgbtnDOC_Click(object sender, ImageClickEventArgs e)
        {
            this.IsPreview = false;
            Session.Add("ExportMode", "DOC");
            LoadReport();
        }
        #endregion Control Event

    }
}