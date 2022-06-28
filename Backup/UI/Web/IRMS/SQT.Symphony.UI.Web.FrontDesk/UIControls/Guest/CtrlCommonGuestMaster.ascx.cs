using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using System.Globalization;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Guest
{
    public partial class CtrlCommonGuestMaster : System.Web.UI.UserControl
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
        public Guid FolioID
        {
            get
            {
                return ViewState["FolioID"] != null ? new Guid(Convert.ToString(ViewState["FolioID"])) : Guid.Empty;
            }
            set
            {
                ViewState["FolioID"] = value;
            }
        }
        public Guid GuestID
        {
            get
            {
                return ViewState["GuestID"] != null ? new Guid(Convert.ToString(ViewState["GuestID"])) : Guid.Empty;
            }
            set
            {
                ViewState["GuestID"] = value;
            }
        }

        decimal dcmlftCharge = Convert.ToDecimal("0.000000");
        decimal dcmlftPayment = Convert.ToDecimal("0.000000");
        decimal dcmlftAccomodationCharge = Convert.ToDecimal("0.000000");
        decimal dcmlftMISCCharge = Convert.ToDecimal("0.000000");
        decimal dcmlftTotalPayment = Convert.ToDecimal("0.000000");
        decimal dcmlftTotalDueAmount = Convert.ToDecimal("0.000000");
        decimal dcmlBalanceAmount = Convert.ToDecimal("0.000000");
        #endregion

        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();
                
                BindBreadCrumb();
                BindGuestList();
                mvGuestMaster.ActiveViewIndex = 0;
                calStartDate.Format = calEndDate.Format = clsSession.DateFormat;
            }
        }
        #endregion  Page Load

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "GuestMaster.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");

        }
        private void BindGuestList()
        {
            try
            {
                string strName = null;
                string strMobileNo = null;
                string strCompany = null;
                string strNationality = null;
                string strEmail = null;

                if (txtSrchName.Text.Trim() != "")
                    strName = txtSrchName.Text.Trim();

                if (txtSrchMobileNo.Text.Trim() != "")
                    strMobileNo = txtSrchMobileNo.Text.Trim();

                if (txtSrchCompany.Text.Trim() != "")
                    strCompany = txtSrchCompany.Text.Trim();

                if (txtSrchNationality.Text.Trim() != "")
                    strNationality = txtSrchNationality.Text.Trim();
                
                DataSet dsGuestList = GuestBLL.GetAllForGuestHistory(strName,strNationality,strCompany,strEmail,strMobileNo,clsSession.PropertyID,clsSession.CompanyID);
                if (dsGuestList != null && dsGuestList.Tables.Count > 0 && dsGuestList.Tables[0].Rows.Count > 0)
                {
                    gvGuestList.DataSource = dsGuestList.Tables[0];
                    gvGuestList.DataBind();
                }
                else
                {
                    gvGuestList.DataSource = null;
                    gvGuestList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                //MessageBox.Show(ex.Message.ToString());
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
            dr4["NameColumn"] = "Guest Mgmt.";
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Guest History";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void BindGuestStayHistory()
        {
            try
            {
                if (this.GuestID != Guid.Empty)
                {
                    DataSet dtGuestStayHistory = ReservationGuestBLL.GetAllGuestStayHistory(clsSession.PropertyID, clsSession.CompanyID, this.GuestID);

                    gvGuestHistory.DataSource = dtGuestStayHistory;
                    gvGuestHistory.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public int Reservation_GetTotalDays(Object CheckInDate, Object CheckOutDate)
        {
            int Day = (Convert.ToInt32(((Convert.ToDateTime(CheckOutDate.ToString())) - (Convert.ToDateTime(CheckInDate.ToString()))).TotalDays));
            return Day;
        }

        private void BindFolioDetail()
        {
            try
            {
                DataSet dsRservationData = ReservationBLL.GetResrvationViewData(this.ReservationID, clsSession.PropertyID, clsSession.CompanyID, "RESERVATIONLIST", null, null, null);
                if (dsRservationData.Tables.Count > 0 && dsRservationData.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsRservationData.Tables[0].Rows[0];

                    //litDspGuestName.Text = Convert.ToString(dr["GuestFullName"]);
                    litDisplayFolioNo.Text = Convert.ToString(dr["FolioNo"]);
                    //litDspRoomNo.Text = Convert.ToString(dr["RoomNo"]);

                    DateTime CheckinDate = Convert.ToDateTime(Convert.ToString(dr["CheckInDate"]));
                    litDisplayArrivalDate.Text = Convert.ToString(CheckinDate.ToString(clsSession.DateFormat));

                    DateTime CheckoutDate = Convert.ToDateTime(Convert.ToString(dr["CheckOutDate"]));
                    litDisplayDepatureDate.Text = Convert.ToString(CheckoutDate.ToString(clsSession.DateFormat));

                    litDisplayUnitNo.Text = clsCommon.GetFormatedRoomNumber(Convert.ToString(dr["RoomNo"]));
                    lblFolioDetailsDisplayGuestName.Text = Convert.ToString(dr["GuestFullName"]);
                    lblFolioDetailsDisplayMobileNo.Text = Convert.ToString(clsCommon.GetMobileNo(Convert.ToString(dr["Phone1"])));
                    lblFolioDetailsDisplayEmail.Text = Convert.ToString(dr["Email"]);
                    litDisplayRoomType.Text = Convert.ToString(dr["RoomTypeName"]);

                    litDisplayRateCard.Text = Convert.ToString(dr["RateCardName"]);
                    litDisplayCreditLimit.Text = Convert.ToString(Session["FolioListFolioBalance"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void BindAllFolioChargesGrid()
        {
            try
            {
                DateTime? startdt = null;
                DateTime? enddt = null;

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                if (!txtStartDate.Text.Equals(""))
                    startdt = DateTime.ParseExact(txtStartDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                if (!txtEndDate.Text.Equals(""))
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                else
                {
                    txtEndDate.Text = System.DateTime.Now.ToString(clsSession.DateFormat);
                    enddt = DateTime.ParseExact(txtEndDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                }
                DataSet dsTransaction = TransactionBLL.GetAllTransaction(this.ReservationID, this.FolioID, startdt, enddt, clsSession.PropertyID, clsSession.CompanyID);
                if (dsTransaction != null && dsTransaction.Tables.Count > 0 && dsTransaction.Tables[0].Rows.Count > 0)
                {
                    DataView dvTransaction = new DataView(dsTransaction.Tables[0]);

                    bool isvoid = false;
                    dvTransaction.RowFilter = "IsVoid = '" + isvoid + "' and IsOverride = 0";


                    if (dvTransaction.Count > 0)
                    {
                        dcmlftCharge = (decimal)dsTransaction.Tables[0].Compute("sum(CR_AMOUNT)", "IsVoid = '" + isvoid + "' and IsOverride = 0");
                        dcmlftPayment = (decimal)dsTransaction.Tables[0].Compute("sum(DB_AMOUNT)", "IsVoid = '" + isvoid + "' and IsOverride = 0");

                        decimal dcAllCharges = Convert.ToDecimal("0.000000");
                        dcAllCharges = dcmlftPayment - dcmlftCharge;
                        //litDisplayCreditLimit.Text = lbltabAllCharges.Text = "Folio Balance : " + dcAllCharges.ToString().Substring(0, dcAllCharges.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        lbltabAllCharges.Text = "Folio Balance : " + dcAllCharges.ToString().Substring(0, dcAllCharges.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        litDisplayCreditLimit.Text = dcAllCharges.ToString().Substring(0, dcAllCharges.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        hdnAllCharges.Value = dcAllCharges.ToString().Substring(0, dcAllCharges.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                        dvTransaction.Sort = "EntryDate desc";
                        gvFolioDetails.DataSource = dvTransaction;
                        gvFolioDetails.DataBind();
                    }
                    else
                    {
                        hdnAllCharges.Value = "0.00";
                        lbltabAllCharges.Text = "Folio Balance : 0.00";
                        gvFolioDetails.DataSource = null;
                        gvFolioDetails.DataBind();
                    }

                    DataView dvRentCharges = new DataView(dsTransaction.Tables[0]);
                    dvRentCharges.RowFilter = "EntryOrigin_TermID = 40 and IsVoid = '" + isvoid + "' and IsOverride = 0";
                    if (dvRentCharges.Count > 0)
                    {
                        dvRentCharges.Sort = "EntryDate desc";

                        ////decimal dcmlftTotalRoomRentAmt = (decimal)dsTransaction.Tables[0].Compute("sum(CR_AMOUNT)", "EntryOrigin_TermID = 40 and IsVoid = '" + isvoid + "' and IsOverride = 0");


                        //error occurs.
                        //string strOpe = "DISCOUNT ACCOMODATION CHARGE";
                        //dcmlDiscAmt = (decimal)dsTransaction.Tables[0].Compute("sum(DB_AMOUNT)", "EntryOrigin_TermID = 40 and IsVoid = '" + isvoid + "' and IsOverride = 0 and GeneralIDType_Term = '" + strOpe + "' ");

                        gvAccommodationList.DataSource = dvRentCharges;
                        gvAccommodationList.DataBind();

                        hdnRentCharges.Value = dcmlftAccomodationCharge.ToString().Substring(0, dcmlftAccomodationCharge.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        littabRentCharge.Text = "Room Rent: " + hdnRentCharges.Value;
                    }
                    else
                    {
                        hdnRentCharges.Value = "0.00";
                        gvAccommodationList.DataSource = null;
                        gvAccommodationList.DataBind();
                        littabRentCharge.Text = "Room Rent: 0.00";
                    }

                    DataView dvMISC = new DataView(dsTransaction.Tables[0]);
                    dvMISC.RowFilter = "EntryOrigin_TermID in (41,44)  and IsVoid = '" + isvoid + "' and IsOverride = 0 and GeneralIDType_Term not in ('DISCOUNT ACCOMODATION CHARGE')";
                    if (dvMISC.Count > 0)
                    {
                        //dcmlftMISCCharge = (decimal)dsTransaction.Tables[0].Compute("sum(CR_AMOUNT)", "EntryOrigin_TermID in (41,44)  and IsVoid = '" + isvoid + "' and IsOverride = 0 and GeneralIDType_Term not in ('DISCOUNT ACCOMODATION CHARGE')");
                        dvMISC.Sort = "EntryDate desc";
                        gvMISCDetails.DataSource = dvMISC;
                        gvMISCDetails.DataBind();

                        hdnMISC.Value = dcmlftMISCCharge.ToString().Substring(0, dcmlftMISCCharge.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        littabMISC.Text = "Other Charge: " + hdnMISC.Value;
                    }
                    else
                    {
                        hdnMISC.Value = "0.00";
                        gvMISCDetails.DataSource = null;
                        gvMISCDetails.DataBind();
                        littabMISC.Text = "Other Charge: 0.00";
                    }

                    DataView dvPayment = new DataView(dsTransaction.Tables[0]);
                    dvPayment.RowFilter = "GeneralIDType_Term like '%PAYMENT%' and IsVoid = '" + isvoid + "' and IsOverride = 0 and IsCharge = 0";
                    if (dvPayment.Count > 0)
                    {
                        dcmlftTotalPayment = (decimal)dsTransaction.Tables[0].Compute("sum(DB_AMOUNT)", "GeneralIDType_Term like '%PAYMENT%' and IsVoid = '" + isvoid + "' and IsOverride = 0 and IsCharge = 0");
                        dvPayment.Sort = "EntryDate desc";
                        gvPaymentDetails.DataSource = dvPayment;
                        gvPaymentDetails.DataBind();
                        hdnPayment.Value = dcmlftTotalPayment.ToString().Substring(0, dcmlftTotalPayment.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        littabPayment.Text = "Credit: " + hdnPayment.Value;
                    }
                    else
                    {
                        hdnPayment.Value = "0.00";
                        gvPaymentDetails.DataSource = null;
                        gvPaymentDetails.DataBind();
                        littabPayment.Text = "Credit: 0.00";
                    }
                }
                else
                {
                    hdnAllCharges.Value = hdnRentCharges.Value = hdnMISC.Value = hdnPayment.Value = "0.00";
                    lbltabAllCharges.Text = "Folio Balance : 0.00";
                    littabRentCharge.Text = "Room Rent: 0.00";
                    littabMISC.Text = "Other Charge: 0.00";
                    littabPayment.Text = "Credit: 0.00";

                    gvFolioDetails.DataSource = null;
                    gvFolioDetails.DataBind();

                    gvAccommodationList.DataSource = null;
                    gvAccommodationList.DataBind();

                    gvMISCDetails.DataSource = null;
                    gvMISCDetails.DataBind();

                    gvPaymentDetails.DataSource = null;
                    gvPaymentDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public static string GetFormatedRoomNumber(Object strRoomNumber)
        {
            string strRoomNo = string.Empty;

            if (strRoomNumber.ToString() != "")
            {
                string[] str = strRoomNumber.ToString().Split('|');
                if (str.Length > 0)
                    strRoomNo = str[0] + "(" + str[1] + ")";
            }

            return strRoomNo;
        }

        private void BindAllFolioDepositGrid()
        {
            try
            {
                DataSet dsTransactionDeposit = TransactionBLL.TransactionGetAllDeposit(this.ReservationID, false, clsSession.PropertyID, clsSession.CompanyID);
                if (dsTransactionDeposit != null && dsTransactionDeposit.Tables.Count > 0 && dsTransactionDeposit.Tables[0].Rows.Count > 0)
                {
                    DataView dvDeposit = new DataView(dsTransactionDeposit.Tables[0]);
                    dvDeposit.RowFilter = "[DUE AMOUNT] <> 0";

                    if (dvDeposit.Count > 0)
                    {
                        dcmlftTotalDueAmount = (decimal)dsTransactionDeposit.Tables[0].Compute("sum([DUE AMOUNT])", "[DUE AMOUNT] <> 0");
                        lblTabDeposit.Text = "Deposit : " + dcmlftTotalDueAmount.ToString().Substring(0, dcmlftTotalDueAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                        dvDeposit.Sort = "EntryDate desc";
                        gvDepositDetails.DataSource = dvDeposit;
                        gvDepositDetails.DataBind();
                        hdnDeposit.Value = dcmlftTotalDueAmount.ToString().Substring(0, dcmlftTotalDueAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                    else
                    {
                        lblTabDeposit.Text = "Deposit : 0.00";
                        gvDepositDetails.DataSource = null;
                        gvDepositDetails.DataBind();
                        hdnDeposit.Value = "0.00";
                    }
                }
                else
                {
                    lblTabDeposit.Text = "Deposit : 0.00";
                    gvDepositDetails.DataSource = null;
                    gvDepositDetails.DataBind();
                    hdnDeposit.Value = "0.00";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion  Private Method

        #region Control Event
        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            BindGuestList();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindAllFolioChargesGrid();
        }

        protected void imgbtnClearSearch_OnClick(object sender, EventArgs e)
        {
            txtSrchCompany.Text = txtSrchMobileNo.Text = txtSrchName.Text = txtSrchNationality.Text = "";
        }

        protected void btnBackFromStayHistory_OnClick(object sender, EventArgs e)
        {
            this.GuestID = Guid.Empty;
            litpageBoxTitle.Text = "Guest History";
            mvGuestMaster.ActiveViewIndex = 0;
        }

        protected void BtnBackFromFolioDetail_OnClick(object sender, EventArgs e)
        {
            litpageBoxTitle.Text = "Stay History";
            mvGuestMaster.ActiveViewIndex = 1;
        }

        protected void btnPreferenceCancel_Click(object sender, EventArgs e)
        {
            mvGuestMaster.ActiveViewIndex = 0;
        }
        #endregion Control Event

        #region CheckBox Event
        protected void chkStartDate_CheckedChanged(object sender, EventArgs e)
        {
            txtStartDate.Enabled = calStartDate.Enabled = chkStartDate.Checked;
            txtStartDate.Text = "";
        }

        protected void chkEndDate_CheckedChanged(object sender, EventArgs e)
        {
            txtEndDate.Enabled = calEndDate.Enabled = chkEndDate.Checked;
            txtEndDate.Text = "";
        }
        #endregion 

        #region Grid Event
        protected void gvGuestList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("VIEWGUESTHISTORY"))
                {
                    this.GuestID = new Guid(Convert.ToString(e.CommandArgument));
                    litpageBoxTitle.Text = "Stay History";
                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Guest objGuest = GuestBLL.GetByPrimaryKey(this.GuestID);
                    if (objGuest != null)
                    {
                        lblStayHistoryDisplayGuestName.Text = Convert.ToString(objGuest.GuestFullName);
                        lblStayHistoryDisplayMobileNo.Text = Convert.ToString(objGuest.Phone1);
                        lblStayHistoryDisplayEmail.Text = Convert.ToString(objGuest.Email);
                    }

                    BindGuestStayHistory();
                    mvGuestMaster.ActiveViewIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvGuestList_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGuestList.PageIndex = e.NewPageIndex;
            BindGuestList();
        }

        protected void gvGuestHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("VIEWFOLIODETAIL"))
                {
                    litpageBoxTitle.Text = "Folio Detail";
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    this.ReservationID = new Guid(Convert.ToString(gvGuestHistory.DataKeys[rowIndex]["ReservationID"]));
                    this.FolioID = new Guid(Convert.ToString(gvGuestHistory.DataKeys[rowIndex]["FolioID"]));

                    txtStartDate.Text = System.DateTime.Now.ToString(clsSession.DateFormat);
                    chkEndDate.Checked = false;
                    chkEndDate_CheckedChanged(null, null);
                    chkStartDate.Checked = false;
                    chkStartDate_CheckedChanged(null, null);
                    BindFolioDetail();
                    BindAllFolioChargesGrid();
                    BindAllFolioDepositGrid();
                    BindBreadCrumb();

                    mvGuestMaster.ActiveViewIndex = 2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvGuestHistory_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGuestHistory.PageIndex = e.NewPageIndex;
            BindGuestStayHistory();
        }

        protected void gvGuestHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    decimal dcmlInvoiceAmt = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Display_Charges"));
                    ((Label)e.Row.FindControl("lblGvInvoiceAmount")).Text = dcmlInvoiceAmt.ToString().Substring(0, dcmlInvoiceAmt.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvFolioDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvCharges = (Label)e.Row.FindControl("lblGvCharges");
                    decimal dcmlCharges = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CR_AMOUNT"));
                    if (dcmlCharges > 0)
                    {
                        dcmlBalanceAmount = dcmlBalanceAmount - dcmlCharges;
                    }
                    lblGvCharges.Text = dcmlCharges.ToString().Substring(0, dcmlCharges.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    Label lblGvPayment = (Label)e.Row.FindControl("lblGvPayment");
                    decimal dcmlPayment = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DB_AMOUNT"));
                    if (dcmlPayment > 0)
                    {
                        dcmlBalanceAmount = dcmlBalanceAmount + dcmlPayment;
                    }
                    lblGvPayment.Text = dcmlPayment.ToString().Substring(0, dcmlPayment.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    //// Set Banalce Amount.
                    ((Label)e.Row.FindControl("lblBalance")).Text = dcmlBalanceAmount.ToString().Substring(0, dcmlBalanceAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));


                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblGvFtTotalCharge = (Label)e.Row.FindControl("lblGvFtTotalCharge");
                    Label lblGvFtTotalPayment = (Label)e.Row.FindControl("lblGvFtTotalPayment");
                    Label lblGvFtFinalBalance = (Label)e.Row.FindControl("lblGvFtFinalBalance");

                    lblGvFtTotalCharge.Text = dcmlftCharge.ToString().Substring(0, dcmlftCharge.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    lblGvFtTotalPayment.Text = dcmlftPayment.ToString().Substring(0, dcmlftPayment.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvFolioDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFolioDetails.PageIndex = e.NewPageIndex;
            BindAllFolioChargesGrid();
            //lblDisplayAmount.Text = Convert.ToString(hdnAllCharges.Value);
        }

        protected void gvAccommodationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    decimal dcmlCharges = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CR_AMOUNT"));

                    string strGeneralIDType_Term = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GeneralIDType_Term"));

                    if (Convert.ToString(strGeneralIDType_Term.Substring(0, 8)) == "DISCOUNT")
                        dcmlCharges = (-1) * Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DB_AMOUNT"));

                    //if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GeneralIDType_Term")) == "DISCOUNT ACCOMODATION CHARGE")
                    //    dcmlCharges = (-1) * Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DB_AMOUNT"));

                    ((Label)e.Row.FindControl("lblGvAccommodationCharges")).Text = dcmlCharges.ToString().Substring(0, dcmlCharges.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    dcmlftAccomodationCharge += dcmlCharges;

                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblFtTotalAccommodationCharges = (Label)e.Row.FindControl("lblFtTotalAccommodationCharges");
                    lblFtTotalAccommodationCharges.Text = dcmlftAccomodationCharge.ToString().Substring(0, dcmlftAccomodationCharge.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvAccommodationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAccommodationList.PageIndex = e.NewPageIndex;
            BindAllFolioChargesGrid();
            //lblDisplayAmount.Text = Convert.ToString(hdnRentCharges.Value);
        }

        protected void gvMISCDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    decimal dcmlCharges = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CR_AMOUNT"));

                    string strGeneralIDType_Term = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GeneralIDType_Term"));

                    if (Convert.ToString(strGeneralIDType_Term.Substring(0, 8)) == "DISCOUNT")
                        dcmlCharges = (-1) * Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DB_AMOUNT"));

                    Label lblGvMISCCharges = (Label)e.Row.FindControl("lblGvMISCCharges");
                    lblGvMISCCharges.Text = dcmlCharges.ToString().Substring(0, dcmlCharges.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    dcmlftMISCCharge += dcmlCharges;

                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblFtTotalMISCCharges = (Label)e.Row.FindControl("lblFtTotalMISCCharges");
                    lblFtTotalMISCCharges.Text = dcmlftMISCCharge.ToString().Substring(0, dcmlftMISCCharge.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvMISCDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMISCDetails.PageIndex = e.NewPageIndex;
            BindAllFolioChargesGrid();
            //lblDisplayAmount.Text = Convert.ToString(hdnMISC.Value);
        }

        protected void gvPaymentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ////Label lblGvPaymentRoomNo = (Label)e.Row.FindControl("lblGvPaymentRoomNo");
                    ////string strRoomNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomNo"));
                    ////lblGvPaymentRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(strRoomNo));

                    Label lblGvPayment = (Label)e.Row.FindControl("lblGvPayment");
                    decimal dcmlPayment = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DB_AMOUNT"));
                    lblGvPayment.Text = dcmlPayment.ToString().Substring(0, dcmlPayment.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblGvFtTotalPayment = (Label)e.Row.FindControl("lblGvFtTotalPayment");
                    lblGvFtTotalPayment.Text = dcmlftTotalPayment.ToString().Substring(0, dcmlftTotalPayment.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvDepositDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ////Label lblGvDepositRoomNo = (Label)e.Row.FindControl("lblGvDepositRoomNo");
                    ////string strRoomNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomNo"));
                    ////lblGvDepositRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(strRoomNo));

                    Label lblGvDepositDueAmount = (Label)e.Row.FindControl("lblGvDepositDueAmount");
                    decimal dcmlDueAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DUE AMOUNT"));
                    lblGvDepositDueAmount.Text = dcmlDueAmount.ToString().Substring(0, dcmlDueAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    //((LinkButton)e.Row.FindControl("lnkDepositDetailsRefund")).OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "REFUND")));
                    //((LinkButton)e.Row.FindControl("lnkDepositDetailsTransfer")).OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TRANSFER")));
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblGvFtTotalDepositDueAmount = (Label)e.Row.FindControl("lblGvFtTotalDepositDueAmount");
                    lblGvFtTotalDepositDueAmount.Text = dcmlftTotalDueAmount.ToString().Substring(0, dcmlftTotalDueAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvPaymentDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPaymentDetails.PageIndex = e.NewPageIndex;
            BindAllFolioChargesGrid();
            //lblDisplayAmount.Text = Convert.ToString(hdnPayment.Value);
        }

        protected void gvDepositDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDepositDetails.PageIndex = e.NewPageIndex;
            BindAllFolioDepositGrid();
            //lblDisplayAmount.Text = Convert.ToString(hdnDeposit.Value);
        }
        #endregion
    }
}