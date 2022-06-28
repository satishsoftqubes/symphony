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
    public partial class CtrlOccupancyChart : System.Web.UI.UserControl
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
                divTilte.Visible = true;
                divParameter.Visible = false;
               calAsOnDate.Format = calStartDate.Format = calEndDate.Format = "dd-MM-yyyy";
                this.DateFormat = "dd-MM-yyyy";
                //}
                chkEndDate.Checked = false;
                chkEndDate_CheckedChanged(null, null);
                chkStartDate.Checked = true;
                chkStartDate_CheckedChanged(null, null);
                txtAsOnDate.Text = txtStartDate.Text = System.DateTime.Now.ToString(this.DateFormat);
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
                DataSet ds = new DataSet();
                DateTime? startdt = null;
                DateTime? enddt = null;

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                if (Session["CompanyID"] != null)
                {
                    Company objCmpData = CompanyBLL.GetByPrimaryKey(new Guid(Convert.ToString(Session["CompanyID"])));
                    litCompanyName.Text = objCmpData.CompanyName;
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

                switch (litHeading.Text.ToString())
                {
                    case "Occupation Report - By RoomType":
                        ds = BlockDateRateBLL.GetRPTOccupancyChartByBlockType(clsSession.CompanyID, clsSession.PropertyID, startdt, enddt);
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

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["Total"] = dcmlTotalPercentage.ToString().Substring(0, dcmlTotalPercentage.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        }

                        grdOccupancy.AutoGenerateColumns = true;
                        grdOccupancy.AllowPaging = false;
                        grdOccupancy.DataSource = ds.Tables[0];
                        grdOccupancy.DataBind();

                        //Set the chart type
                        chartOccupancy.Series["Default"].ChartType = SeriesChartType.Pie;

                        //add points
                        double y1 = (double)Convert.ToDouble(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["Total"]);
                        double y2 = (double)Convert.ToDouble(100 - Convert.ToDouble(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["Total"]));
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
                        break;
                    default:
                        break;
                }
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
            grdOccupancy.Visible = true;
            this.IsPreview = true;
            Session.Add("ExportMode", null);
            LoadReport();
            mpeOccupancy.Show();
        }

        protected void btnReportView_Click(object sender, EventArgs e)
        {
            try
            {
                //By RoomType
                divParameter.Visible = true;
                divTilte.Visible = false;
                litHeading.Text = "Occupation Report - By RoomType";
                Session.Add("ReportName", "By RoomType");
                this.ReportName = "By RoomType";

                //if (!Convert.ToString(rdoReportName.SelectedValue).Equals(""))
                //{
                //    divParameter.Visible = true;
                //    divTilte.Visible = false;
                //    litHeading.Text = "Occupation Report - " + rdoReportName.SelectedItem.ToString();
                //    switch (Convert.ToInt32(rdoReportName.SelectedValue))
                //    {
                //        case 1:
                //            Session.Add("ReportName", rdoReportName.SelectedItem);
                //            this.ReportName = rdoReportName.SelectedItem.ToString();
                //            break;

                //        default:
                //            break;
                //    }
                //}
                //else
                //{
                //    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                //    MessageBox.Show("Select Any Type");
                //}
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            this.IsAsOn = false;
            grdOccupancy.Visible = true;
            this.IsPreview = true;
            Session.Add("ExportMode", null);
            LoadReport();
            mpeOccupancy.Show();
            //Response.Clear();
            ////Response.AddHeader("content-disposition", "attachment;filename=OccupancyChartByBlockAndRoomType.xls");
            ////Response.Charset = "";
            ////Response.Cache.SetCacheability(HttpCacheability.NoCache);
            ////Response.ContentType = "application/vnd.xls";
            ////Response.ContentEncoding = System.Text.Encoding.Unicode;
            ////Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            //Control ctrl = grdOccupancy;
            //Unit w = new Unit(100, UnitType.Percentage); ((WebControl)ctrl).Width = w;
            //grdOccupancy.RenderControl(htmlWrite);
            //Response.Write(stringWrite.ToString());
            //Page pg = new System.Web.UI.Page();
            //HtmlForm frm = new HtmlForm();
            //pg.Controls.Add(frm);
            //frm.Attributes.Add("runat", "server");
            //frm.Controls.Add(ctrl);
            //pg.DesignerInitialize();
            //pg.RenderControl(htmlWrite);
            //string strHTML = stringWrite.ToString();
            //HttpContext.Current.Response.Clear();
            //HttpContext.Current.Response.Write(strHTML);
            //HttpContext.Current.Response.Write("<script>window.print();</script>");
            ////HttpContext.Current.Response.End();
            //grdOccupancy.Visible = false;
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
            grdOccupancy.Visible = true;
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
            grdOccupancy.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
            grdOccupancy.Visible = false;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            divParameter.Visible = false;
            divTilte.Visible = true;
            litHeading.Text = "Occupation Report";
            Session.Remove("ReportName");
            this.ReportName = "";
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