using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;
using System.Globalization;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Report
{
    public partial class InfraServiceCharges : System.Web.UI.UserControl
    {
        #region Variable
        public bool? IsPreview = false;

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
                calStartDate.Format = calEndDate.Format = "dd-MM-yyyy";
                this.DateFormat = "dd-MM-yyyy";
                txtStartDate.Text = txtEndDate.Text = System.DateTime.Now.ToString(this.DateFormat);
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
                string strReportType = "";

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), this.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);
                else
                {
                    txtEndDate.Text = System.DateTime.Now.ToString(this.DateFormat);
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);
                }

                if (rdbReportType.SelectedValue.ToUpper() == "SUMMARY")
                    strReportType = "SUMMARY";
                else
                    strReportType = "DETAIL";

                ds = ReservationBLL.GetInfraServiceChargeReport(clsSession.CompanyID, clsSession.PropertyID, startdt, enddt, strReportType);

                if (rdbReportType.SelectedValue.ToUpper() == "SUMMARY")
                {
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        gvInfraServiceCharge.DataSource = ds.Tables[0];
                        gvInfraServiceCharge.DataBind();

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            ltrTotalAmount.Text = Convert.ToString(ds.Tables[1].Rows[0]["TotalAmount"]);
                        }
                        else
                            ltrTotalAmount.Text = "";
                    }
                    else
                    {
                        gvInfraServiceCharge.DataSource = null;
                        gvInfraServiceCharge.DataBind();
                        ltrTotalAmount.Text = "";
                    }
                }
                else
                {
                    gvInfraServiceCharge.DataSource = null;
                    gvInfraServiceCharge.DataBind();
                    ltrTotalAmount.Text = "";

                    DataTable dt = new DataTable();
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                        dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        string filename = "InfraServiceCharges_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";
                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                        DataGrid dgGrid = new DataGrid();
                        dgGrid.DataSource = dt;
                        dgGrid.DataBind();

                        //Get the HTML for the control.
                        dgGrid.RenderControl(hw);
                        //Write the HTML back to the browser.
                        //Response.ContentType = application/vnd.ms-excel;
                        Response.ContentType = "application/vnd.ms-excel";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                        this.EnableViewState = false;
                        Response.Write(tw.ToString());
                        Response.End();
                    }
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
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            LoadReport();
        }
        #endregion
    }
}