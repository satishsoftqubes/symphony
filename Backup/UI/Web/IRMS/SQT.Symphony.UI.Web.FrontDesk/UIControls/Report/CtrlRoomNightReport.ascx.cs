using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Report
{
    public partial class CtrlRoomNightReport : System.Web.UI.UserControl
    {
        #region Property and Variables
        public Guid RateID
        {
            get
            {
                return ViewState["RateID"] != null ? new Guid(Convert.ToString(ViewState["RateID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RateID"] = value;
            }
        }
        #endregion

        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                calStartDate.Format = calEndDate.Format = clsSession.DateFormat;
                mvRoomNight.ActiveViewIndex = 0;
                BindBreadCrumb();
            }
        }
        #endregion

        #region Control Events
        protected void imtbtnSearch_OnClick(object sender, EventArgs e)
        {
            BindRoomNightListGrid();
        }

        protected void imgbtnXLSX_OnClick(object sender, EventArgs e)
        {
            try
            {
                DateTime startdt = DateTime.Today;
                DateTime enddt = DateTime.Today;

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

                DataSet ds = ReservationBLL.GetNoOfRoomNights(startdt, enddt, "ROOMNIGHTLIST", null, "BOTH");
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string filename = "RoomNights_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";
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

        protected void btnBack2List_OnClick(object sender, EventArgs e)
        {
            this.RateID = Guid.Empty;
            mvRoomNight.ActiveViewIndex = 0;
        }

        protected void btnDetailExcelExport_OnClick(object sender, EventArgs e)
        {
            try
            {
                DateTime startdt = DateTime.Today;
                DateTime enddt = DateTime.Today;

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

                DataSet ds = ReservationBLL.GetNoOfRoomNights(startdt, enddt, "ROOMNIGHTDETAIL", this.RateID, "BOTH");
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string filename = "RoomNightsDetail_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";
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
        #endregion

        #region Private Methods
        private void BindRoomNightListGrid()
        {
            try
            {
                DateTime startdt = DateTime.Today;
                DateTime enddt = DateTime.Today;

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

                DataSet ds = ReservationBLL.GetNoOfRoomNights(startdt, enddt, "ROOMNIGHTLIST", null, "BOTH");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    gvRoomNights.DataSource = ds;
                    gvRoomNights.DataBind();
                }
                else
                {
                    gvRoomNights.DataSource = ds;
                    gvRoomNights.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindDetailGrid()
        {
            try
            {
                DateTime startdt = DateTime.Today;
                DateTime enddt = DateTime.Today;

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

                DataSet ds = ReservationBLL.GetNoOfRoomNights(startdt, enddt, "ROOMNIGHTDETAIL", this.RateID, "BOTH");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    gvRoomNightDetail.DataSource = ds;
                    gvRoomNightDetail.DataBind();
                }
                else
                {
                    gvRoomNightDetail.DataSource = ds;
                    gvRoomNightDetail.DataBind();
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
            dr3["NameColumn"] = "Room Night Report";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }
        #endregion

        #region Grid Events
        protected void gvRoomNights_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("ROOMNIGHTDETAIL"))
                {
                    this.RateID = new Guid(e.CommandArgument.ToString());

                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    int rowIndex = Convert.ToInt32(row.RowIndex);
                    lblRateCardName.Text = Convert.ToString(gvRoomNights.DataKeys[rowIndex]["RateCardName"]);
                    lblRoomNightsCount.Text = Convert.ToString(gvRoomNights.DataKeys[rowIndex]["Nights"]);

                    mvRoomNight.ActiveViewIndex = 1;
                    BindDetailGrid();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvRoomNights_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRoomNights.PageIndex = e.NewPageIndex;
            BindRoomNightListGrid();
        }

        protected void gvRoomNightDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRoomNightDetail.PageIndex = e.NewPageIndex;
            BindDetailGrid();
        }

        protected void gvGuestList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvPhone = (Label)e.Row.FindControl("lblGvPhone");
                    string strPhoneNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Phone1"));
                    lblGvPhone.Text = Convert.ToString(clsCommon.GetMobileNo(strPhoneNo));
                }
                else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
    }
}