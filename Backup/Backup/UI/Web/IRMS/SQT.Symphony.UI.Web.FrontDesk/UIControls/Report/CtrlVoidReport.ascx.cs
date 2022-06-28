using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Report
{
    public partial class CtrlVoidReport : System.Web.UI.UserControl
    {
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                calStartDate.Format = calEndDate.Format = clsSession.DateFormat;
                BindBreadCrumb();
            }
        }
        #endregion

        #region Control Events
        protected void imtbtnSearch_OnClick(object sender, EventArgs e)
        {
            BindVoidReport();
        }

        protected void imgbtnXLSX_OnClick(object sender, EventArgs e)
        {
            try
            {
                DateTime startdt = DateTime.Today;
                DateTime enddt = DateTime.Today;
                string strGuestName = null;
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                if (!txtSrchGuestName.Text.Equals(""))
                    strGuestName = Convert.ToString(txtSrchGuestName.Text.Trim());

                DataSet ds = BookKeepingBLL.GetVoidReport(clsSession.CompanyID, clsSession.PropertyID, startdt, enddt, strGuestName);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string filename = "VoidReport_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";
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
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnPrintVoidReport_OnClick(object sender, EventArgs e)
        {
            if (gvVoidTrnasactions.Rows.Count > 0)
            {
                Session["VoidSearchStartDate"] = Convert.ToString(txtStartDate.Text.Trim());
                Session["VoidSearchEndDate"] = Convert.ToString(txtEndDate.Text.Trim());
                Session["VoidSearchGuestName"] = Convert.ToString(txtSrchGuestName.Text.Trim());
                Session["VoidSearchGridPageIndex"] = Convert.ToInt32(gvVoidTrnasactions.PageIndex);
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnVoidReportPrint();", true);
            }

        }
        #endregion

        #region Private Method
        public void BindVoidReport()
        {
            try
            {
                DateTime startdt = DateTime.Today;
                DateTime enddt = DateTime.Today;
                string strGuestName = null;
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                if (!txtSrchGuestName.Text.Equals(""))
                    strGuestName = Convert.ToString(txtSrchGuestName.Text.Trim());

                DataSet ds = BookKeepingBLL.GetVoidReport(clsSession.CompanyID, clsSession.PropertyID, startdt, enddt, strGuestName);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    gvVoidTrnasactions.DataSource = ds;
                    gvVoidTrnasactions.DataBind();
                }
                else
                {
                    gvVoidTrnasactions.DataSource = ds;
                    gvVoidTrnasactions.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindBreadCrumb()
        {
            DataList dlBreadCrumb = (DataList)this.Page.Master.FindControl("dlBreadCrumb");

            DataTable dt = new DataTable();
            DataColumn cl = new DataColumn("NameColumn");
            dt.Columns.Add(cl);

            DataColumn cl1 = new DataColumn("Link");
            dt.Columns.Add(cl1);

            DataRow dr2 = dt.NewRow();
            dr2["NameColumn"] = "Dashboard";
            dr2["Link"] = "";
            dt.Rows.Add(dr2);

            //DataRow dr1 = dt.NewRow();
            //dr1["NameColumn"] = "Uniworld E-City";
            //dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "MIS Report";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Void Report";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }
        #endregion

        #region Grid Events
        protected void gvVoidTrnasactions_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVoidTrnasactions.PageIndex = e.NewPageIndex;
            BindVoidReport();
        }
        #endregion
    }
}