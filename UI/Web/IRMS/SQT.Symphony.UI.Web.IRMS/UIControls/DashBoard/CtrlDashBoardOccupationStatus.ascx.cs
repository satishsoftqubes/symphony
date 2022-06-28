using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Globalization;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.IRMS.BLL;
using System.Data;

namespace SQT.Symphony.UI.Web.IRMS.UIControls.DashBoard
{
    public partial class CtrlDashBoardOccupationStatus : System.Web.UI.UserControl
    {
        #region Variable
        public bool? IsPreview = false;
        public string ReportName = string.Empty;
        public bool IsAsOn = false;

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
        #endregion

        #region Form Load Event
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                LoadControlValue();
        }
        #endregion

        #region Private Method

        /// <summary>
        /// Load Control Value
        /// </summary>
        private void LoadControlValue()
        {
            try
            {
                calAsOnDate.Format = calStartDate.Format = calEndDate.Format = "dd-MM-yyyy";
                this.DateFormat = "dd-MM-yyyy";
                //}
                chkEndDate.Checked = false;
                chkEndDate_CheckedChanged(null, null);
                chkStartDate.Checked = true;
                chkStartDate_CheckedChanged(null, null);
                txtAsOnDate.Text = txtStartDate.Text = System.DateTime.Now.ToString(this.DateFormat);
                //lblNumberOfBedsOccupied
                SrvcOccupancy.CheckInGuestListSoapClient objClient = new SrvcOccupancy.CheckInGuestListSoapClient();
                DataSet ds = objClient.GetNoOfBedsAndNoOfOccupiedBeds();
                if (ds != null && ds.Tables.Count == 2)
                {
                    lblNoOfBeds.Text = Convert.ToString(ds.Tables[1].Rows[0]["TotalNoOfBed"]);
                    lblNumberOfBedsOccupied.Text = Convert.ToString(ds.Tables[0].Rows[0]["TotalOccupiedRoom"]);
                    decimal NoOfoccupiedBeds = Convert.ToDecimal(ds.Tables[0].Rows[0]["TotalOccupiedRoom"]);
                    decimal NoOfBeds = Convert.ToDecimal(ds.Tables[1].Rows[0]["TotalNoOfBed"]);
                    decimal OccupamcyPerc = Convert.ToDecimal(NoOfoccupiedBeds * 100 / NoOfBeds);
                    if (OccupamcyPerc.ToString().Contains("."))
                        lblOccupancyPercentage.Text = OccupamcyPerc.ToString().Substring(0, OccupamcyPerc.ToString().LastIndexOf(".") + 1 + 2);
                    else
                         lblOccupancyPercentage.Text = OccupamcyPerc.ToString();
                }

                DataSet dsCurrentQuarter = RentPayoutQuarterSetupBLL.RentPayoutQuarterSetupSelectQuarterbyDate(DateTime.Today,null,null);
                if (dsCurrentQuarter != null && dsCurrentQuarter.Tables[0].Rows.Count > 0)
                {
                    lblHeaderQuarterTitle.Text = Convert.ToString(dsCurrentQuarter.Tables[0].Rows[0]["Title"]); // +" (" + Convert.ToDateTime(dsCurrentQuarter.Tables[0].Rows[0]["StartDate"].ToString()).ToString("") + " to " + Convert.ToString(dsCurrentQuarter.Tables[0].Rows[0]["EndDate"]) + ")";

                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                    DateTime dtStartDate = DateTime.ParseExact(Convert.ToString(dsCurrentQuarter.Tables[0].Rows[0]["StartDate"]), "MM-dd-yyyy", objCultureInfo);
                    DateTime dtEndDate = DateTime.ParseExact(Convert.ToString(dsCurrentQuarter.Tables[0].Rows[0]["EndDate"]), "MM-dd-yyyy", objCultureInfo);

                    DataSet dsRevenueOfQuarter = objClient.GetTotalRevenueForQuarterForIR(dtStartDate, dtEndDate);
                    if (dsRevenueOfQuarter != null && dsRevenueOfQuarter.Tables[0].Rows.Count > 0)
                        lblRentIncomeForCurrentQtr.Text = Convert.ToString(dsRevenueOfQuarter.Tables[0].Rows[0]["TotalAmount"]);
                    else
                        lblRentIncomeForCurrentQtr.Text = "-";
                }
                else
                {
                    lblHeaderQuarterTitle.Text = "Occupancy Status";
                    lblRentIncomeForCurrentQtr.Text = "-";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Load Report
        /// </summary>
        protected void LoadReport()
        {
            try
            {
                DateTime startdt = DateTime.Today;
                DateTime enddt = DateTime.Today;

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                if (Session["CompanyID"] != null)
                {
                    Company objCmpData = CompanyBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["CompanyID"])));
                    //litCompanyName.Text = objCmpData.CompanyName;
                }
                if (IsAsOn)
                {
                    startdt = enddt = DateTime.ParseExact(txtAsOnDate.Text.Trim(), this.DateFormat, objCultureInfo);
                }
                else
                {
                    if (!txtStartDate.Text.Equals(""))
                        startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), this.DateFormat, objCultureInfo);
                    if (!txtEndDate.Text.Equals(""))
                        enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);
                    else
                    {
                        txtEndDate.Text = System.DateTime.Now.ToString(this.DateFormat);
                        enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);
                    }
                }

                Session.Add("StartDate", startdt);
                Session.Add("EndDate", enddt);
                lblFromDate.Text = "From : " + ((DateTime)startdt).ToString(this.DateFormat);
                lblToDate.Text = "To : " + ((DateTime)enddt).ToString(this.DateFormat);

                SrvcOccupancy.CheckInGuestListSoapClient objClient = new SrvcOccupancy.CheckInGuestListSoapClient();

                DataSet ds = objClient.GetDataForOccupancyReport(Convert.ToString(startdt.ToString("dd-MM-yyyy")), Convert.ToString(enddt.ToString("dd-MM-yyyy")));

                decimal dcmlTotalBedsUnderPMS = Convert.ToDecimal("0.000000");
                decimal dcmlTotalBedsOccupied = Convert.ToDecimal("0.000000");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    double total = 0.00;
                    for (int j = 1; j < ds.Tables[0].Columns.Count - 1; j++)
                    {
                        if (!Convert.ToString(ds.Tables[0].Rows[i][j]).Equals(""))
                            total += Convert.ToDouble(ds.Tables[0].Rows[i][j]);
                    }
                    ds.Tables[0].Rows[i]["Total"] = total;

                    if (Convert.ToString(ds.Tables[0].Rows[i]["Particular"]).ToUpper() == "BEDS UNDER PMS")
                        dcmlTotalBedsUnderPMS = (decimal)total;

                    if (Convert.ToString(ds.Tables[0].Rows[i]["Particular"]).ToUpper() == "BEDS OCCUPIED")
                        dcmlTotalBedsOccupied = (decimal)total;
                }

                decimal dcmlTotalPercentage = Convert.ToDecimal("0.000000");
                if (dcmlTotalBedsUnderPMS > 0)
                    dcmlTotalPercentage = (dcmlTotalBedsOccupied / dcmlTotalBedsUnderPMS) * 100;

                /*
                //Set the chart type
                chartOccupancy.Series["Default"].ChartType = SeriesChartType.Pie;

                //add points
                double y1 = (double)Math.Round(dcmlTotalPercentage, 2);     //Convert.ToDouble(dcmlTotalPercentage);
                double y2 = (double)Math.Round(100 - dcmlTotalPercentage, 2); //Convert.ToDouble(100 - dcmlTotalPercentage);
                double[] yValues = { y1, y2 };
                string[] xValues = { "Occupied", "Unoccupied" };
                //chartOccupancy.Series["Series1"].Points.AddY(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["Total"]);
                //chartOccupancy.Series["Series1"].Points.AddY(100 - Convert.ToDecimal(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["Total"]));

                chartOccupancy.Series["Default"].Points.DataBindXY(xValues, yValues);

                chartOccupancy.Series["Default"].ChartType = SeriesChartType.Pie;

                chartOccupancy.Series["Default"]["PieLabelStyle"] = "Enabled";
                chartOccupancy.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                chartOccupancy.Legends[0].Enabled = true;
                chartOccupancy.Legends[0].Alignment = System.Drawing.StringAlignment.Center;
                */
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Button Click Event

        protected void btnAsPrint_Click(object sender, EventArgs e)
        {
            this.IsAsOn = true;
            /////chartOccupancy.Visible = true;
            this.IsPreview = true;
            Session.Add("ExportMode", null);
            LoadReport();
            mpeOccupancy.Show();
        }

        protected void btnReportView_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Add("ReportName", "Occupation Report - By RoomType");
                this.ReportName = "Occupation Report - By RoomType";
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            this.IsAsOn = false;
            /////chartOccupancy.Visible = true;
            this.IsPreview = true;
            Session.Add("ExportMode", null);
            LoadReport();
            mpeOccupancy.Show();
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
            /////chartOccupancy.Visible = true;
            LoadReport();
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=OccupancyChartByBlockType.xls");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            /////chartOccupancy.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
            /////chartOccupancy.Visible = false;
        }

        #endregion

        #region CheckBox Event
        protected void chkStartDate_CheckedChanged(object sender, EventArgs e)
        {
            txtStartDate.Text = System.DateTime.Now.ToString(this.DateFormat);
            txtStartDate.Enabled = calStartDate.Enabled = chkStartDate.Checked;
        }

        protected void chkEndDate_CheckedChanged(object sender, EventArgs e)
        {
            txtEndDate.Enabled = calEndDate.Enabled = chkEndDate.Checked;
            txtEndDate.Text = "";
        }
        #endregion
    }
}