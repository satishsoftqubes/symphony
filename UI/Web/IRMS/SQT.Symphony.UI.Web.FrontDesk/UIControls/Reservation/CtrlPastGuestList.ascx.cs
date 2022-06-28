using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Globalization;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlPastGuestList : System.Web.UI.UserControl
    {
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                calStartDate.Format = calEndDate.Format = clsSession.DateFormat;
                txtStartDate.Text = txtEndDate.Text = DateTime.Today.ToString(clsSession.DateFormat);
                //CheckUserAuthorization();

                BindBreadCrumb();
                //BindBillingInstruction();
                BindGrid();
            }
        }
        #endregion

        #region Control Events
        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnPrintGuestList_OnClick(object sender, EventArgs e)
        {
            //if (gvGuestList.Rows.Count > 0)
            //{
            //    Session["GuestListPageIndex"] = gvGuestList.PageIndex.ToString();

            //    Session["GuestListSearchName"] = txtSearchName.Text.Trim();
            //    Session["GuestListSearchMobileNo"] = txtSearchMobileNo.Text.Trim();

            //    if (txtSearcReservationNo.Text.Trim() != "")
            //        Session["GuestListSearcReservationNo"] = "RES#" + txtSearcReservationNo.Text.Trim();
            //    else
            //        Session["GuestListSearcReservationNo"] = "";

            //    if (txtSearchUnitNo.Text.Trim() != "")
            //        Session["GuestListSearchUnitNo"] = Convert.ToString(clsCommon.GetOriginalRoomNumber(txtSearchUnitNo.Text.Trim()));
            //    else
            //        Session["GuestListSearchUnitNo"] = "";

            //    if (ddlbillinginstruction.SelectedIndex != 0)
            //        Session["GuestListBillingInstructionID"] = ddlbillinginstruction.SelectedValue.ToString();
            //    else
            //        Session["GuestListBillingInstructionID"] = "";

            //    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnGuestListPrint();", true);
            //}
        }

        protected void btnExportToExcel_OnClick(object sender, EventArgs e)
        {
            string strName = null;
            string strMobileNo = null;
            string strReservationNo = null;
            string strRoomNo = null;
            Guid? BillingInstructionID = null;
            //if (txtSearchName.Text.Trim() != "")
            //    strName = txtSearchName.Text.Trim();

            //if (txtSearchMobileNo.Text.Trim() != "")
            //    strMobileNo = txtSearchMobileNo.Text.Trim();

            //if (txtSearcReservationNo.Text.Trim() != "")
            //    strReservationNo = "RES#" + txtSearcReservationNo.Text.Trim();

            //if (txtSearchUnitNo.Text.Trim() != "")
            //{
            //    strRoomNo = Convert.ToString(clsCommon.GetOriginalRoomNumber(txtSearchUnitNo.Text.Trim()));
            //    if (strRoomNo == "")
            //        strRoomNo = null;
            //}
            //if (ddlbillinginstruction.SelectedIndex != 0)
            //    BillingInstructionID = new Guid(ddlbillinginstruction.SelectedValue);

            DateTime? startdt = null;
            DateTime? enddt = null;

            CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

            if (!txtStartDate.Text.Equals(""))
                startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
            if (!txtEndDate.Text.Equals(""))
                enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

            DataSet dsReservationData = GuestBLL.GetPastGuestListData(startdt, enddt, clsSession.PropertyID, clsSession.CompanyID, strName, strMobileNo, strReservationNo, strRoomNo, BillingInstructionID);
                
            DataTable dt = dsReservationData.Tables[0];

            //if (dsReservationData != null && dsReservationData.Tables.Count > 0 && dsReservationData.Tables[0].Rows.Count > 0)
            //{
            //    //dvForGuestListOrderBy = new DataView(dsReservationData.Tables[0]);
            //    string strOrderByName = string.Empty;
            //    if (ddlOrderByList.SelectedValue.Trim().Equals("Booking No"))
            //        strOrderByName = "ReservationNo Desc";
            //    else if (ddlOrderByList.SelectedValue.Trim().Equals("Room No"))
            //        strOrderByName = "RoomNo Asc";
            //    else if (ddlOrderByList.SelectedValue.Trim().Equals("Block name"))
            //        strOrderByName = "WingName Asc";
            //    else if (ddlOrderByList.SelectedValue.Trim().Equals("Arrival Date"))
            //        strOrderByName = "CheckInDate Desc";
            //    else if (ddlOrderByList.SelectedValue.Trim().Equals("Company Name"))
            //        strOrderByName = "CompanyName Asc";

            //    dt.DefaultView.Sort = strOrderByName;
            //}

            if (dt.Rows.Count > 0)
            {
                string filename = "PastGuestList_" + DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".xls";
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
        #endregion

        #region Private Method
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
            dr4["NameColumn"] = "Guest Mgmt.";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Past Guest List";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindGrid()
        {
            try
            {
                string strName = null;
                string strMobileNo = null;
                string strReservationNo = null;
                string strRoomNo = null;
                Guid? BillingInstructionID = null;
                //if (txtSearchName.Text.Trim() != "")
                //    strName = txtSearchName.Text.Trim();

                //if (txtSearchMobileNo.Text.Trim() != "")
                //    strMobileNo = txtSearchMobileNo.Text.Trim();

                //if (txtSearcReservationNo.Text.Trim() != "")
                //    strReservationNo = "RES#" + txtSearcReservationNo.Text.Trim();

                //if (txtSearchUnitNo.Text.Trim() != "")
                //{
                //    strRoomNo = Convert.ToString(clsCommon.GetOriginalRoomNumber(txtSearchUnitNo.Text.Trim()));
                //    if (strRoomNo == "")
                //        strRoomNo = null;
                //}
                //if (ddlbillinginstruction.SelectedIndex != 0)
                //    BillingInstructionID = new Guid(ddlbillinginstruction.SelectedValue);

                DateTime? startdt = null;
                DateTime? enddt = null;

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

                DataSet dsReservationData = GuestBLL.GetPastGuestListData(startdt,enddt, clsSession.PropertyID, clsSession.CompanyID, strName, strMobileNo, strReservationNo, strRoomNo, BillingInstructionID);
                // Order By Logic
                DataView dvForGuestListOrderBy = null;
                if (dsReservationData != null && dsReservationData.Tables.Count > 0 && dsReservationData.Tables[0].Rows.Count > 0)
                {
                    dvForGuestListOrderBy = new DataView(dsReservationData.Tables[0]);
                    //string strOrderByName = string.Empty;
                    //if (ddlOrderByList.SelectedValue.Trim().Equals("Booking No"))
                    //    strOrderByName = "ReservationNo Desc";
                    //else if (ddlOrderByList.SelectedValue.Trim().Equals("Room No"))
                    //    strOrderByName = "RoomNo Asc";
                    //else if (ddlOrderByList.SelectedValue.Trim().Equals("Block name"))
                    //    strOrderByName = "WingName Asc";
                    //else if (ddlOrderByList.SelectedValue.Trim().Equals("Arrival Date"))
                    //    strOrderByName = "CheckInDate Desc";
                    //else if (ddlOrderByList.SelectedValue.Trim().Equals("Company Name"))
                    //    strOrderByName = "CompanyName Asc";

                    //dvForGuestListOrderBy.Sort = strOrderByName;
                }

                gvGuestList.DataSource = dvForGuestListOrderBy;
                gvGuestList.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Grid Event

        protected void gvGuestList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //this.RowIndex = 0;
                //this.strIsValidate = this.strOpenModalDialog = string.Empty;

                //if (e.CommandName.Equals("GUESTPROFILE"))
                //{
                //    clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                //    clsSession.ToEditItemType = "GUESTDETAILS";
                //    Response.Redirect("~/GUI/Folio/GuestProfile.aspx");
                //}
                //else if (e.CommandName.Equals("VIEWFOLIO"))
                //{
                //    LinkButton lb = (LinkButton)e.CommandSource;

                //    GridViewRow gvr = (GridViewRow)lb.NamingContainer;
                //    Guid id = (Guid)(gvGuestList.DataKeys[gvr.RowIndex]["FolioID"]);
                //    string strBalance = Convert.ToString((gvGuestList.DataKeys[gvr.RowIndex]["Balance"]));
                //    if (strBalance != string.Empty)
                //        strBalance = strBalance.ToString().Substring(0, strBalance.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                //    else
                //        strBalance = "0.00";

                //    clsSession.ToEditItemID = new Guid(Convert.ToString(e.CommandArgument));
                //    clsSession.ToEditItemType = "FOLIODETAILS";
                //    Session["FolioListFolioID"] = Convert.ToString(id);
                //    Session["FolioListFolioBalance"] = strBalance;

                //    Response.Redirect("~/GUI/Folio/FolioDetailsOld.aspx");
                //}
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        protected void gvGuestList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGuestList.PageIndex = e.NewPageIndex;
            BindGrid();
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

        #endregion Grid Event
    }
}