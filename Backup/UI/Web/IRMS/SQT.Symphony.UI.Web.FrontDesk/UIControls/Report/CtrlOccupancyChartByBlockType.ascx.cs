using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;
using System.Globalization;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Web.UI.HtmlControls;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Report
{
    public partial class CtrlOccupancyChartByBlockType : System.Web.UI.UserControl
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
                //if (Session["PropertyConfigurationInfo"] != null)
                //{
                //    PropertyConfiguration objPropertyConfiguration = (PropertyConfiguration)Session["PropertyConfigurationInfo"];
                //    ProjectTerm objProjectTerm = new ProjectTerm();
                //    Guid TermID = (Guid)objPropertyConfiguration.DateFormatID;
                //    objProjectTerm = ProjectTermBLL.GetByPrimaryKey(TermID);

                //    if (objProjectTerm != null)
                //    {
                //        calStartDate.Format = calEndDate.Format = objProjectTerm.Term;
                //        this.DateFormat = objProjectTerm.Term;
                //    }
                //    else
                //    {
                //        calStartDate.Format = calEndDate.Format = "dd/MM/yyyy";
                //        this.DateFormat = "dd/MM/yyyy";
                //    }
                //}
                //else
                //{
                    calStartDate.Format = calEndDate.Format = "dd-MM-yyyy";
                    this.DateFormat = "dd-MM-yyyy";
                //}
                chkEndDate.Checked = false;
                chkEndDate_CheckedChanged(null, null);
                chkStartDate.Checked = true;
                chkStartDate_CheckedChanged(null, null);
                txtStartDate.Text = System.DateTime.Now.ToString(this.DateFormat);
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

                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), this.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);
                else
                {
                    txtEndDate.Text = System.DateTime.Now.ToString(this.DateFormat);
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), this.DateFormat, objCultureInfo);
                }

                Session.Add("StartDate", startdt);
                Session.Add("EndDate", enddt);
                lblFromDate.Text = "From : " + ((DateTime)startdt).ToString(this.DateFormat);
                lblToDate.Text = "To : " + ((DateTime)enddt).ToString(this.DateFormat);

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
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Button Click Event
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            LoadReport();
        }


        protected void btnPreview_Click(object sender, EventArgs e)
        {
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

        protected void lnkbtnRateCard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Report/RPTOccupancyChartByBlockAndRateCard.aspx");
        }

        protected void lnkbtnRoomType_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Report/RPTOccupancyChartByBlockAndRoomType.aspx");
        }
    }
}