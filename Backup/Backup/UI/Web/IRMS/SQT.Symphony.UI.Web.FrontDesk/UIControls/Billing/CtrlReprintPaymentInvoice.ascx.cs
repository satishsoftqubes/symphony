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
    public partial class CtrlReprintPaymentInvoice : System.Web.UI.UserControl
    {

        #region Property
        public bool? IsPreview = false;

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
        public Guid ReservationFolioID
        {
            get
            {
                return ViewState["ReservationFolioID"] != null ? new Guid(Convert.ToString(ViewState["ReservationFolioID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ReservationFolioID"] = value;
            }
        }
        public Guid ReservationID
        {
            get
            {
                return ViewState["ReservationID"] != null ? new Guid(Convert.ToString(ViewState["ReservationID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ReservationID"] = value;
            }
        }
        #endregion Property

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();
                mvReprint.ActiveViewIndex = 0;
                BindBreadCrumb();
                //mpeCheckOut.Show();
            }
        }
        #endregion Page Load

        #region Private Method

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "ReprintPaymentInvoice.aspx");
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
            dr3["NameColumn"] = "Reprint Payment";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }
        private void BindPaymentDetails()
        {
            try
            {
                DataSet dsPaymentInfo = ReservationBLL.GetReservationPaymentInfoForReprint(clsSession.PropertyID, clsSession.CompanyID, this.ReservationID);
                if (dsPaymentInfo != null && dsPaymentInfo.Tables.Count > 0 && dsPaymentInfo.Tables[0].Rows.Count > 0)
                {
                    gvPaymentList.DataSource = dsPaymentInfo.Tables[0];
                    gvPaymentList.DataBind();
                }
                else
                {
                    gvPaymentList.DataSource = null;
                    gvPaymentList.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Control Events
        protected void btnPrintBill_OnClick(object sender, EventArgs e)
        {
            try
            {
                DataSet dsForCheckBillingInstruction = ReservationBLL.GetBillingInstructionTermStatus(this.ReservationID, clsSession.CompanyID, clsSession.PropertyID, false);
                if (dsForCheckBillingInstruction != null && dsForCheckBillingInstruction.Tables.Count > 0 && dsForCheckBillingInstruction.Tables[0].Rows.Count > 0 && Convert.ToInt32(dsForCheckBillingInstruction.Tables[0].Rows[0]["NoOfRecord"]) > 0)
                {
                    hdnResID.Value = this.ReservationID.ToString();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnCompanyInvoicePrint();", true);

                }
                else
                {
                    this.IsPreview = false;
                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio objFolio = FolioBLL.GetByPrimaryKey(this.ReservationFolioID);
                    DataSet ds = new DataSet();
                    if (rdoDetail.Checked)
                        ds = InvoiceBLL.GetRPTInvoiceBillDetail(this.ReservationID, objFolio.FolioID);
                    else if (rdoSummary.Checked)
                    {
                        //Session["RptResID"] = this.ReservationID.ToString();
                        DataSet dsMain = InvoiceBLL.GetRPTInvoiceReservationDetail(null, this.ReservationID, objFolio.FolioID);
                        DataSet dsDetail = InvoiceBLL.GetRPTInvoiceBillSummary(this.ReservationID, objFolio.FolioID);
                        DataTable MainDS = dsMain.Tables[0].Copy();
                        MainDS.Merge(dsDetail.Tables[0], true);
                        ds.Tables.Add(MainDS);
                    }

                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
                        {
                            if (Convert.ToString(ds.Tables[0].Rows[i]["GeneralIDType_Term"]).ToUpper() == "RETENTION CHARGE" && Convert.ToString(ds.Tables[0].Rows[i]["Charge"]) == "0.00" && Convert.ToString(ds.Tables[0].Rows[i]["Credit"]) == "0.00")
                            {
                                ds.Tables[0].Rows.RemoveAt(i);
                            }
                        }
                    }

                    Session["RptResID"] = this.ReservationID;
                    Session["DataSource"] = ds;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "openViewer();", true);
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        protected void rdoDetail_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDetail.Checked)
                Session.Add("ReportName", "Bill Format");
            else if (rdoSummary.Checked)
                Session.Add("ReportName", "Bill Summary");
        }
        protected void btnBackToReprint_Click(object sender, EventArgs e)
        {
            mvReprint.ActiveViewIndex = 0;
        }
        protected void btnProceedCheckOut_OnClick(object sender, EventArgs e)
        {
            try
            {
                DataSet dsReservation = ReservationBLL.SelectReservationDetailByReservationNo("RES#" + txtBookingNoForCheckOut.Text.Trim(), "");
                if (dsReservation != null && dsReservation.Tables[0].Rows.Count > 0)
                {
                    DataRow drResData = dsReservation.Tables[0].Rows[0];

                    ltrChkPmtReservationNo.Text = Convert.ToString(drResData["ReservationNo"]);
                    ltrChkPmtGuestName.Text = Convert.ToString(drResData["GuestFullName"]);
                    DateTime dtCheckInDate = Convert.ToDateTime(Convert.ToString(drResData["CheckInDate"]));
                    DateTime dtCheckOutDate = Convert.ToDateTime(Convert.ToString(drResData["CheckOutDate"]));
                    ltrChkPmtCheckInDate.Text = Convert.ToString(dtCheckInDate.ToString(clsSession.DateFormat));
                    ltrChkPmtCheckOutDate.Text = Convert.ToString(dtCheckOutDate.ToString(clsSession.DateFormat));
                    ltrChkPmtRoomType.Text = Convert.ToString(drResData["RoomTypeName"]);
                    ltrChkPmtRateCard.Text = Convert.ToString(drResData["RateCardName"]);
                    ltrChkPmtRoomNo.Text = clsCommon.GetFormatedRoomNumber(Convert.ToString(drResData["RoomNo"]));


                    int intReservationStatusTermID = Convert.ToInt32(drResData["RestStatus_TermID"]);
                    if ((intReservationStatusTermID == 33))
                    {
                        btnPrintBill.Visible = true;
                        rdoDetail.Visible = true;
                        rdoSummary.Visible = true;
                    }
                    else
                    {
                        btnPrintBill.Visible = false;
                        rdoDetail.Visible = false;
                        rdoSummary.Visible = false;
                    }
                    this.ReservationID = new Guid(Convert.ToString(drResData["ReservationID"]));
                    this.ReservationFolioID = new Guid(drResData["FolioID"].ToString());
                    hdnResID.Value = Convert.ToString(this.ReservationID);
                    mvReprint.ActiveViewIndex = 1;
                    BindPaymentDetails();
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
        protected void iBtnCacelCheckOut_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Dashboard.aspx");
        }
        protected void btnSuccessMessageOK_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/Dashboard.aspx");
        }
        #endregion

        #region Grid Event
        protected void gvPaymentList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PaymentMode")) == string.Empty)
                    {
                        //if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GeneralIDType_Term")).ToUpper() == "DEPOSIT TRANSFER")
                        //    ((Label)e.Row.FindControl("lblPaymentMode")).Text = "Transferred from Deposit";
                    }
                    else
                        ((Label)e.Row.FindControl("lblPaymentMode")).Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PaymentMode"));
                    LinkButton lnkPrintReceipt = (LinkButton)e.Row.FindControl("lnkPrintReceipt");
                    hdnTransID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BookID"));
                    ((Label)e.Row.FindControl("lblDateOfPayment")).Text = Convert.ToDateTime(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DateOfPayment"))).ToString(clsSession.DateFormat);
                    //lnkPrintReceipt.OnClientClick = "fnOpneWindow();";
                    lnkPrintReceipt.OnClientClick = string.Format("return fnOpneWindow('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BookID")));
                    string strAmount = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Amount"));
                    ((Label)e.Row.FindControl("lblAmount")).Text = strAmount.Substring(0, strAmount.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
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