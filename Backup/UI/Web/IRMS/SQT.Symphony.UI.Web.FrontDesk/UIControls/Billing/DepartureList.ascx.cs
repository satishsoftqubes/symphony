using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Billing
{
    public partial class DepartureList : System.Web.UI.UserControl
    {
        #region Property and variable
        public string UserRights
        {
            get
            {
                return ViewState["UserRights"] != null ? Convert.ToString(ViewState["UserRights"]) : string.Empty;
            }
            set
            {
                ViewState["UserRights"] = value;
            }
        }

        #endregion Property and variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();
                BindBreadCrumb();
                BindDepartureGrid();
            }
        }

        #endregion Page Load

        #region Control Events
        protected void btnYes_Click(object sender, EventArgs e)
        {

            clsSession.ToEditItemID = new Guid(Convert.ToString(hdnConfirmDelete.Value));
            clsSession.ToEditItemType = "CHECKOUT RESERVATION";
            Response.Redirect("~/GUI/Billing/CheckOut.aspx");
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                gvDepartureList.PageIndex = 0;
                BindDepartureGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void imgbtnClearSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ClearSearchControl();
                gvDepartureList.PageIndex = 0;
                BindDepartureGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Methods
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "DepartureList.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");

        }
        private void BindDepartureGrid()
        {
            try
            {
                string strName = null;
                string strMobileNo = null;
                string strReservationNo = null;
                string strRoomNo = null;
                DateTime? StartDate = null;
                DateTime? EndDate = null;

                if (txtSearchName.Text.Trim() != "")
                    strName = Convert.ToString(txtSearchName.Text.Trim());

                if (txtMobileNo.Text.Trim() != "")
                    strMobileNo = Convert.ToString(txtMobileNo.Text.Trim());

                if (txtSearcReservationNo.Text.Trim() != "")
                    strReservationNo = "RES#" + Convert.ToString(txtSearcReservationNo.Text.Trim());

                if (Convert.ToString(rblList.SelectedValue) == "Day")
                    StartDate = EndDate = DateTime.Now;
                else if (Convert.ToString(rblList.SelectedValue) == "Week")
                {
                    StartDate = DateTime.Now;
                    EndDate = DateTime.Now.AddDays(6);
                }
                else if (Convert.ToString(rblList.SelectedValue) == "Month")
                {
                    StartDate = DateTime.Now;
                    EndDate = DateTime.Now.AddDays(30);
                }
                else if (Convert.ToString(rblList.SelectedValue) == "All")
                    StartDate = EndDate = null;

                if (txtSearchRoomNo.Text.Trim() != "")
                {
                    strRoomNo = Convert.ToString(clsCommon.GetOriginalRoomNumber(txtSearchRoomNo.Text.Trim()));
                    if (strRoomNo == "")
                        strRoomNo = null;
                }

                DataSet dsCheckOutList = ReservationBLL.SelectDepatureListData(null, clsSession.PropertyID, clsSession.CompanyID, strName, strMobileNo, strReservationNo, StartDate, EndDate, strRoomNo);

                if (dsCheckOutList.Tables.Count > 0 && dsCheckOutList.Tables[0].Rows.Count > 0)
                {
                    gvDepartureList.DataSource = dsCheckOutList.Tables[0];
                    gvDepartureList.DataBind();
                }
                else
                {
                    gvDepartureList.DataSource = null;
                    gvDepartureList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ClearSearchControl()
        {
            txtSearchName.Text = txtMobileNo.Text = txtSearcReservationNo.Text = txtSearchRoomNo.Text = "";
            rblList.SelectedIndex = 0;
        }

        /// <summary>
        /// Bind BreadCrumb
        /// </summary>
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
            dr4["NameColumn"] = "Check Out";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Departure List";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        #endregion

        #region Grid Event

        protected void gvDepartureList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("CHECKOUT"))
                {
                    // this.ReservationID = new Guid(Convert.ToString(e.CommandArgument));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvDepartureList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvPhone = (Label)e.Row.FindControl("lblGvPhone");
                    string strPhoneNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Phone1"));
                    lblGvPhone.Text = Convert.ToString(clsCommon.GetMobileNo(strPhoneNo));

                    Label lblGvRoomNo = (Label)e.Row.FindControl("lblGvRoomNo");
                    string strRoomNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomNo"));
                    lblGvRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(strRoomNo));

                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CheckOutNote")).Trim() != string.Empty)
                    {
                        e.Row.Style.Add("background-color", "#d5d5d5");
                    }

                    Label lblGvBalance = (Label)e.Row.FindControl("lblGvBalance");
                    decimal dcmlBalance = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Balance"));
                    dcmlBalance = dcmlBalance * (-1);
                    lblGvBalance.Text = dcmlBalance.ToString().Substring(0, dcmlBalance.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    LinkButton lnkReservationNo = (LinkButton)e.Row.FindControl("lnkReservationNo");
                    LinkButton lnkGuestName = (LinkButton)e.Row.FindControl("lnkGuestName");
                    lnkGuestName.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ReservationID")));
                    lnkReservationNo.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ReservationID")));
                    //lblGvBalance.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvDepartureList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDepartureList.PageIndex = e.NewPageIndex;
            BindDepartureGrid();
        }
        #endregion Grid Event
    }
}