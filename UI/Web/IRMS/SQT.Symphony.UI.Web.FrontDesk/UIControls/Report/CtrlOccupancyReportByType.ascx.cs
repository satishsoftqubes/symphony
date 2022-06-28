using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Web.UI.DataVisualization.Charting;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Report
{
    public partial class CtrlOccupancyReportByType : System.Web.UI.UserControl
    {
        public bool IsAsOn = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadControlValue();
            }
        }
        private void LoadControlValue()
        {
            try
            {
                divReportParameter.Visible = true;
                dvDashBoard.Visible = false;
                calAsOnDate.Format = calStartDate.Format = calEndDate.Format = clsSession.DateFormat;
                chkEndDate.Checked = false;
                chkEndDate_CheckedChanged(null, null);
                chkStartDate.Checked = true;
                chkStartDate_CheckedChanged(null, null);
                txtAsOnDate.Text = txtStartDate.Text = System.DateTime.Now.ToString(clsSession.DateFormat);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnAsPrint_Click(object sender, EventArgs e)
        {
            this.IsAsOn = true;
            divReportParameter.Visible = false;
            dvDashBoard.Visible = true;
            BindChart();
        }
        protected void chkStartDate_CheckedChanged(object sender, EventArgs e)
        {
            txtStartDate.Text = System.DateTime.Now.ToString(clsSession.DateFormat);
            txtStartDate.Enabled = calStartDate.Enabled = chkStartDate.Checked;
        }

        protected void chkEndDate_CheckedChanged(object sender, EventArgs e)
        {
            txtEndDate.Enabled = calEndDate.Enabled = chkEndDate.Checked;
            txtEndDate.Text = "";
        }
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            this.IsAsOn = false;
            divReportParameter.Visible = false;
            dvDashBoard.Visible = true;
            BindChart();
        }
        protected void btnBackToParameter_Click(object sender, EventArgs e)
        {
            LoadControlValue();
        }
        private void BindChart()
        {
            DateTime? startdt = null;
            DateTime? enddt = null;

            CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
            if (IsAsOn)
            {
                startdt = enddt = DateTime.ParseExact(txtAsOnDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
            }
            else
            {
                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                else
                {
                    txtEndDate.Text = System.DateTime.Now.ToString(clsSession.DateFormat);
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                }
            }

            DataSet dsForOccupancyChartReport = GuestBLL.GetOccupancyReportData(clsSession.CompanyID, clsSession.PropertyID, startdt, enddt);
            if (dsForOccupancyChartReport != null && dsForOccupancyChartReport.Tables.Count > 0)
            {
                // 1. Occupancy By Gender 
                if (dsForOccupancyChartReport.Tables[0].Rows.Count > 0)
                {
                    chartByGender.DataSource = dsForOccupancyChartReport.Tables[0];
                    //chartByGender.Series["seriesByGender"].XValueMember = "DisplayTerm";
                    //chartByGender.Series["seriesByGender"].YValueMembers = "Percentage";
                    chartByGender.Series["seriesByGender"]["PieLabelStyle"] = "Enabled";
                    chartByGender.ChartAreas["chartAreaByGender"].Area3DStyle.Enable3D = true;

                    chartByGender.Legends[0].Enabled = true;
                    // chartByGender.Legends[0].Position = new ElementPosition(50, 20, 50, height);
                    chartByGender.Legends[0].Alignment = System.Drawing.StringAlignment.Far;
                    chartByGender.Series["seriesByGender"].Points.DataBind(dsForOccupancyChartReport.Tables[0].AsEnumerable(), "DisplayTerm", "Percentage", "Tooltip=Counts");
                    // chartByGender.DataBind();
                }
                // 2. Occupancy By Meal Preference 
                if (dsForOccupancyChartReport.Tables[1].Rows.Count > 0)
                {
                    chartBymealpreference.DataSource = dsForOccupancyChartReport.Tables[1];
                    //chartBymealpreference.Series["seriesByPreference"].XValueMember = "DisplayTerm";
                    //chartBymealpreference.Series["seriesByPreference"].YValueMembers = "Percentage";
                    chartBymealpreference.Series["seriesByPreference"]["PieLabelStyle"] = "Enabled";
                    chartBymealpreference.ChartAreas["chartAreaByMealPreference"].Area3DStyle.Enable3D = true;
                    chartBymealpreference.Legends[0].Enabled = true;
                    chartBymealpreference.Legends[0].Alignment = System.Drawing.StringAlignment.Far;
                    chartBymealpreference.Series["seriesByPreference"].Points.DataBind(dsForOccupancyChartReport.Tables[1].AsEnumerable(), "DisplayTerm", "Percentage", "Tooltip=Counts");
                    //chartBymealpreference.DataBind();
                }

                // 3. Occupancy By Sector
                if (dsForOccupancyChartReport.Tables[2].Rows.Count > 0)
                {
                    chartCompanySector.DataSource = dsForOccupancyChartReport.Tables[2];
                    //chartCompanySector.Series["seriesByCompanySector"].XValueMember = "DisplayTerm";
                    //chartCompanySector.Series["seriesByCompanySector"].YValueMembers = "Percentage";
                    chartCompanySector.Series["seriesByCompanySector"]["PieLabelStyle"] = "Enabled";
                    chartCompanySector.ChartAreas["chartAreaByCompanySector"].Area3DStyle.Enable3D = true;
                    chartCompanySector.Legends[0].Enabled = true;
                    chartCompanySector.Legends[0].Alignment = System.Drawing.StringAlignment.Far;
                    chartCompanySector.Series["seriesByCompanySector"].Points.DataBind(dsForOccupancyChartReport.Tables[2].AsEnumerable(), "DisplayTerm", "Percentage", "Tooltip=Counts");
                    //chartCompanySector.DataBind();
                }

                // 4. Occupancy By Work Timing
                if (dsForOccupancyChartReport.Tables[3].Rows.Count > 0)
                {
                    chartByWorkingTime.DataSource = dsForOccupancyChartReport.Tables[3];
                    //chartByWorkingTime.Series["seriesByWorkingTime"].XValueMember = "DisplayTerm";
                    //chartByWorkingTime.Series["seriesByWorkingTime"].YValueMembers = "Percentage";
                    chartByWorkingTime.Series["seriesByWorkingTime"]["PieLabelStyle"] = "Enabled";
                    chartByWorkingTime.ChartAreas["chartAreaByWorkingTime"].Area3DStyle.Enable3D = true;
                    chartByWorkingTime.Legends[0].Enabled = true;
                    chartByWorkingTime.Legends[0].Alignment = System.Drawing.StringAlignment.Far;
                    chartByWorkingTime.Series["seriesByWorkingTime"].Points.DataBind(dsForOccupancyChartReport.Tables[3].AsEnumerable(), "DisplayTerm", "Percentage", "Tooltip=Counts");
                   // chartByWorkingTime.DataBind();
                }

                // 5. Occupancy By Billing Instruction 
                if (dsForOccupancyChartReport.Tables[4].Rows.Count > 0)
                {
                    chartByBillingInstruction.DataSource = dsForOccupancyChartReport.Tables[4];
                    //chartByBillingInstruction.Series["seriesByBillingInstruction"].XValueMember = "DisplayTerm";
                    //chartByBillingInstruction.Series["seriesByBillingInstruction"].YValueMembers = "Percentage";
                    chartByBillingInstruction.Series["seriesByBillingInstruction"]["PieLabelStyle"] = "Enabled";
                    chartByBillingInstruction.ChartAreas["chartAreaByBillingInstruction"].Area3DStyle.Enable3D = true;
                    chartByBillingInstruction.Legends[0].Enabled = true;
                    chartByBillingInstruction.Legends[0].Alignment = System.Drawing.StringAlignment.Far;
                    chartByBillingInstruction.Series["seriesByBillingInstruction"].Points.DataBind(dsForOccupancyChartReport.Tables[4].AsEnumerable(), "DisplayTerm", "Percentage", "Tooltip=Counts");
                   // chartByBillingInstruction.DataBind();
                }
                // 6. Occupancy By Reservation Type 
                if (dsForOccupancyChartReport.Tables[5].Rows.Count > 0)
                {
                    chartByReservationType.DataSource = dsForOccupancyChartReport.Tables[5];
                    //chartByReservationType.Series["seriesByReservationType"].XValueMember = "DisplayTerm";
                    //chartByReservationType.Series["seriesByReservationType"].YValueMembers = "Percentage";
                    chartByReservationType.Series["seriesByReservationType"]["PieLabelStyle"] = "Enabled";
                    chartByReservationType.ChartAreas["chartAreaByReservationType"].Area3DStyle.Enable3D = true;
                    chartByReservationType.Legends[0].Enabled = true;
                    chartByReservationType.Legends[0].Alignment = System.Drawing.StringAlignment.Far;
                    chartByReservationType.Series["seriesByReservationType"].Points.DataBind(dsForOccupancyChartReport.Tables[5].AsEnumerable(), "DisplayTerm", "Percentage", "Tooltip=Counts");
                    //chartByReservationType.DataBind();
                }

                // 7. Occupancy By Reservation Type 
                if (dsForOccupancyChartReport.Tables[6].Rows.Count > 0)
                {
                    chartByRateCard.DataSource = dsForOccupancyChartReport.Tables[6];
                    //chartByRateCard.Series["By Rate Card"].XValueMember = "RateCardName";
                    //chartByRateCard.Series["By Rate Card"].YValueMembers = "Percentage";
                    chartByRateCard.Series["By Rate Card"]["PieLabelStyle"] = "Enabled";
                    chartByRateCard.ChartAreas["chartAreaByRateCard"].AxisX.Interval = 1;
                    chartByRateCard.Legends[0].Enabled = true;
                    chartByRateCard.Legends[0].Alignment = System.Drawing.StringAlignment.Far;
                    chartByRateCard.Series["By Rate Card"].Points.DataBind(dsForOccupancyChartReport.Tables[6].AsEnumerable(), "RateCardName", "Percentage", "Tooltip=Counts");
                    //chartByRateCard.DataBind();

                }
            }
        }
    }
}