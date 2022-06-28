using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using System.Globalization;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Billing
{
    public partial class CtrlNewCashierCheckout : System.Web.UI.UserControl
    {
        #region Property and Variables

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
        #endregion Property and Variables

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();
                BindBreadCrumb();
                //mpeCheckOut.Show();
            }
        }
        #endregion Page Load

        #region Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "CashierCheckOut.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");
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

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = "Cashier";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Check Out";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }
        #endregion

        #region Control Events
        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsReservation = ReservationBLL.SelectReservationDetailByReservationNo("RES#" + txtBookingNoForCheckOut.Text.Trim(), "");
                if (dsReservation != null && dsReservation.Tables[0].Rows.Count > 0)
                {
                    DataRow drResData = dsReservation.Tables[0].Rows[0];

                    int intReservationStatusTermID = Convert.ToInt32(drResData["RestStatus_TermID"]);
                    if (!(intReservationStatusTermID == 32))
                    {
                        lblSuccessMessage.Text = "This reservation is not checked in, you can't proceed for check out.";

                        mpeSuccessMessage.Show();
                        return;
                    }

                    if (dsReservation.Tables.Count > 1)
                    {
                        if (Convert.ToInt32(dsReservation.Tables[1].Rows[0]["INFRASERVICECHARGE"]) > 0)
                        {
                            Session["ReservationNo"] = Convert.ToString(drResData["ReservationNo"]);
                            clsSession.ToEditItemID = new Guid(Convert.ToString(drResData["ReservationID"]));
                            clsSession.ToEditItemType = "TAKE INFRA CHARGES";
                            Response.Redirect("~/GUI/Billing/InfraCharges.aspx");
                        }
                    }

                    clsSession.ToEditItemID = new Guid(Convert.ToString(drResData["ReservationID"]));
                    clsSession.ToEditItemType = "CHECKOUT RESERVATION";
                    Response.Redirect("~/GUI/Billing/CheckOutNew.aspx");
                }
                else
                {
                    lblSuccessMessage.Text = "No reservation found with given Booking #";
                    mpeSuccessMessage.Show();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void btnProceedCheckOut_OnClick(object sender, EventArgs e)
        {

        }

        protected void iBtnCacelCheckOut_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Dashboard.aspx");
        }

        protected void btnSuccessMessageOK_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Dashboard.aspx");
        }
        #endregion
    }
}