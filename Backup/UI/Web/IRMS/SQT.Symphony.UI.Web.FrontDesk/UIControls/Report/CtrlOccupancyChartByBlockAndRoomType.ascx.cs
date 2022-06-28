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
using System.IO;
using System.Web.UI.HtmlControls;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Report
{
    public partial class CtrlOccupancyChartByBlockAndRoomType : System.Web.UI.UserControl
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
                Session.Add("ReportName", "Occupancy Chart By Block & Room Type");
                DataSet ds = new DataSet();               
                DateTime? startdt = null;
                DateTime? enddt = null;

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

                Session.Add("StartDate", startdt);
                Session.Add("EndDate", enddt);              

                ds = BlockDateRateBLL.GetRPTOccupancyChartByBlockAndRoomType(clsSession.CompanyID, clsSession.PropertyID, null, startdt, enddt);
               // ds.Tables[0].Columns.Remove("RoomTypeID");
                //grdOccupancy.AutoGenerateColumns = true;
                //grdOccupancy.AllowPaging = false;                
                //grdOccupancy.DataSource = ds.Tables[0];
                //grdOccupancy.DataBind();
                DataSet dsRmTyp = RoomTypeBLL.GetDistinctRoomTypeOnRoom(clsSession.PropertyID);
                DataSet dsWing = WingBLL.GetDistinctWingOnRoom(clsSession.PropertyID);
                DataTable MainDS = ds.Tables[0].Copy();
                //MainDS.Merge(dsRmTyp.Tables[0], true);
                MainDS.Merge(dsWing.Tables[0], true);
                DataSet FinalDS = new DataSet();
                FinalDS.Tables.Add(MainDS);
                Session["DataSource"] = FinalDS;
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
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
            Response.Clear();
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
            grdOccupancy.Visible = false;
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
            //grdOccupancy.Visible = true;
            //LoadReport();
            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;filename=OccupancyChartByBlockAndRoomType.xls");
            //Response.Charset = "";
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.ContentType = "application/vnd.xls";
            //Response.ContentEncoding = System.Text.Encoding.Unicode;
            //Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            //grdOccupancy.RenderControl(htmlWrite);
            //Response.Write(stringWrite.ToString());
            //Response.End();
            //grdOccupancy.Visible = false;
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

        protected void lbkbtnRateCard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Report/RPTOccupancyChartByBlockType.aspx");
        }
    }
}