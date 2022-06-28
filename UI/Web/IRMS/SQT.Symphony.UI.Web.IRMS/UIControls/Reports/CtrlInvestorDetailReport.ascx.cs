using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using System.IO;
using System.Web.UI.HtmlControls;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.Reports
{
    public partial class CtrlInvestorDetailReport : System.Web.UI.UserControl
    {
        #region Property and Variables
        public bool? IsPreview = false;
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
        #endregion Property and Variables

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CompanyID = new Guid(Convert.ToString(Session["CompanyID"]));
                BindInvestorName();
                BindinvestorDetailGrid();
            }
        }
        #endregion Page Load

        #region Private Method
        protected void LoadReport()
        {
            try
            {
                string BankName = "";
                Guid? InvestorID = null;
                if (ddlinvestorList.SelectedIndex > 0)
                    InvestorID = new Guid(ddlinvestorList.SelectedValue);
                else
                    InvestorID = null;

                if (txtSearchBankName.Text.Trim() != "")
                    BankName = txtSearchBankName.Text.Trim();
                else
                    BankName = "";


                Session.Add("ReportName", "Investor Detail Report");
                DataSet dsForInvDetailGrid = InvestorBLL.GetInvestorDetailReportData(this.CompanyID, InvestorID, BankName);
                Session["DataSource"] = dsForInvDetailGrid;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindInvestorName()
        {
            DataSet dsForInvestorList = InvestorBLL.GetAllInvestorsForFrontDesk(this.CompanyID, null);

            if (dsForInvestorList != null && dsForInvestorList.Tables.Count > 0 && dsForInvestorList.Tables[0].Rows.Count > 0)
            {

                ddlinvestorList.DataSource = dsForInvestorList.Tables[0];
                ddlinvestorList.DataTextField = "InvestorFullName";
                ddlinvestorList.DataValueField = "InvestorID";
                ddlinvestorList.DataBind();
                ddlinvestorList.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
            }
            else
                ddlinvestorList.Items.Insert(0, new ListItem("-ALL-", Guid.Empty.ToString()));
        }

        private void BindinvestorDetailGrid()
        {
            string BankName = "";
            Guid? InvestorID = null;
            if (ddlinvestorList.SelectedIndex > 0)
                InvestorID = new Guid(ddlinvestorList.SelectedValue);
            else
                InvestorID = null;

            if (txtSearchBankName.Text.Trim() != "")
                BankName = txtSearchBankName.Text.Trim();
            else
                BankName = "";

            DataSet dsForInvDetailGrid = InvestorBLL.GetInvestorDetailReportData(this.CompanyID, InvestorID, BankName);

            if (dsForInvDetailGrid != null && dsForInvDetailGrid.Tables.Count > 0 && dsForInvDetailGrid.Tables[0].Rows.Count > 0)
            {
                gvInvestorDetailInformation.DataSource = dsForInvDetailGrid.Tables[0];
                gvInvestorDetailInformation.DataBind();
            }
            else
                gvInvestorDetailInformation.DataSource = null;
        }
        #endregion Private Method

        #region Control Event
        protected void btnPrintReport_Click(object sender, EventArgs e)
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
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BindinvestorDetailGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            if (ddlinvestorList.SelectedIndex > 0)
                Session["InvestorIDForPrint"] = ddlinvestorList.SelectedValue;
            else
                Session["InvestorIDForPrint"] = null;


            if (txtSearchBankName.Text.Trim() != "")
                Session["BankNameForPrint"] = txtSearchBankName.Text.Trim();
            else
                Session["BankNameForPrint"] = null;


            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewerForPrint();", true);
        }
        #endregion Control Event

    }
}