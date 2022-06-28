using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQT.Symphony.BusinessLogic.BackOffice.DTO;
using SQT.Symphony.BusinessLogic.BackOffice.BLL;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.BLL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Data;
using System.Globalization;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.CommonControls
{
    public partial class ctrlCommonDayEnd : System.Web.UI.UserControl
    {
        #region Property and Variable
        public decimal dcFtTotal = Convert.ToDecimal("0.000000");
        decimal dcmlTotlRate = Convert.ToDecimal("0.000000");
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
        public string StandardCheckOutTime
        {
            get
            {
                return ViewState["StandardCheckOutTime"] != null ? Convert.ToString(ViewState["StandardCheckOutTime"]) : string.Empty;
            }
            set
            {
                ViewState["StandardCheckOutTime"] = value;
            }
        }
        public int RestStatus_TermID
        {
            get
            {
                return ViewState["RestStatus_TermID"] != null ? Convert.ToInt32(ViewState["RestStatus_TermID"]) : 0;
            }
            set
            {
                ViewState["RestStatus_TermID"] = value;
            }
        }
        public bool IsMessage = false;

        public string strAction
        {
            get
            {
                return ViewState["strAction"] != null ? Convert.ToString(ViewState["strAction"]) : string.Empty;
            }
            set
            {
                ViewState["strAction"] = value;
            }
        }

        public bool IsCheckOutCleared
        {
            get
            {
                return ViewState["IsCheckOutCleared"] != null ? Convert.ToBoolean(ViewState["IsCheckOutCleared"]) : false;
            }
            set
            {
                ViewState["IsCheckOutCleared"] = value;
            }
        }

        public bool IsCheckInCleared
        {
            get
            {
                return ViewState["IsCheckInCleared"] != null ? Convert.ToBoolean(ViewState["IsCheckInCleared"]) : false;
            }
            set
            {
                ViewState["IsCheckInCleared"] = value;
            }
        }

        //public bool IsNoShowCleared
        //{
        //    get
        //    {
        //        return ViewState["IsNoShowCleared"] != null ? Convert.ToBoolean(ViewState["IsNoShowCleared"]) : false;
        //    }
        //    set
        //    {
        //        ViewState["IsNoShowCleared"] = value;
        //    }
        //}

        public bool IsAccomodationChargeCleared
        {
            get
            {
                return ViewState["IsAccomodationChargeCleared"] != null ? Convert.ToBoolean(ViewState["IsAccomodationChargeCleared"]) : false;
            }
            set
            {
                ViewState["IsAccomodationChargeCleared"] = value;
            }
        }

        public bool IsServiceChargeCleared
        {
            get
            {
                return ViewState["IsServiceChargeCleared"] != null ? Convert.ToBoolean(ViewState["IsServiceChargeCleared"]) : false;
            }
            set
            {
                ViewState["IsServiceChargeCleared"] = value;
            }
        }

        public bool IsActBalanceSheetCleared
        {
            get
            {
                return ViewState["IsActBalanceSheetCleared"] != null ? Convert.ToBoolean(ViewState["IsActBalanceSheetCleared"]) : false;
            }
            set
            {
                ViewState["IsActBalanceSheetCleared"] = value;
            }
        }
        public Guid ReservationIDForPostRoomCharge
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
        public Guid ReservationFolioIDForPostRoomCharge
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
        public Guid ReservationIDForOverStay
        {
            get
            {
                return ViewState["ReservationIDForOverStay"] != null ? new Guid(Convert.ToString(ViewState["ReservationIDForOverStay"])) : Guid.Empty;
            }
            set
            {
                ViewState["ReservationIDForOverStay"] = value;
            }
        }
        public DateTime New_CheckOutDate
        {
            get
            {
                return ViewState["New_CheckOutDate"] != null ? Convert.ToDateTime(ViewState["New_CheckOutDate"]) : DateTime.Now;
            }
            set
            {
                ViewState["New_CheckOutDate"] = value;
            }
        }
        public Guid RoomTypeID
        {
            get
            {
                return ViewState["RoomTypeID"] != null ? new Guid(Convert.ToString(ViewState["RoomTypeID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RoomTypeID"] = value;
            }
        }
        public Guid RoomID
        {
            get
            {
                return ViewState["RoomID"] != null ? new Guid(Convert.ToString(ViewState["RoomID"])) : Guid.Empty;
            }
            set
            {
                ViewState["RoomID"] = value;
            }
        }

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
        #endregion Property and Variable

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();

                ////Session["IsComeFromCounterClose"] = 1 means user come here after closing counter for day end; so current coutnerID is empty but don't to check it's access.
                if ((clsSession.DefaultCounterID == Guid.Empty || clsSession.DefaultCounterID == null) && !(Session["IsComeFromCounterClose"] != null && Convert.ToString(Session["IsComeFromCounterClose"]) == "1"))
                {
                    Response.Redirect("~/GUI/CommonControl/AccessDenied.aspx");
                }
                else
                {
                    //BindGrid();
                    gvDayEndDetails.DataSource = null;
                    gvDayEndDetails.DataBind();
                    Session["DayEndData"] = null;
                    litDayEndDetails.Text = "";
                    btnPost.Visible = false;
                    BindBreadCrumb();

                    if (Session["IsComeFromCounterClose"] != null && Convert.ToString(Session["IsComeFromCounterClose"]) == "1")
                    {
                        btnPreChecks_OnClick(sender, e);
                        Session.Remove("IsComeFromCounterClose");
                    }
                }
            }
        }

        #endregion Page Load

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "DayEnd.aspx");
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

            //DataRow dr2 = dt.NewRow();
            //dr2["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblDashboard", "Dashboard");
            //dr2["Link"] = "";
            //dt.Rows.Add(dr2);

            if (clsSession.UserType.ToUpper() == "SUPERADMIN")
            {
                DataRow dr = dt.NewRow();
                dr["NameColumn"] = clsSession.CompanyName;
                dr["Link"] = "~/GUI/Property/CompanyList.aspx";
                dt.Rows.Add(dr);
            }

            DataRow dr1 = dt.NewRow();
            dr1["NameColumn"] = clsSession.PropertyName;
            dr1["Link"] = "~/GUI/Property/PropertyList.aspx";
            dt.Rows.Add(dr1);

            DataRow dr4 = dt.NewRow();
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblBackOfficeSetup", "BackOffice Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = "Day End";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void CheckAvailabilityForDayEnd()
        {
            try
            {
                litDayEndDetails.Text = "";
                gvDayEndDetails.Columns[2].Visible = false;
                gvDayEndDetails.DataSource = null;
                gvDayEndDetails.DataBind();

                Session["DayEndData"] = null;
                btnPost.Visible = false;
                int cnt = 0;

                DataSet dsPreCheckData = DayEndBLL.Get_DayEnd_PreCheckReport(null, clsSession.PropertyID, clsSession.CompanyID);

                if (dsPreCheckData.Tables.Count > 0 && dsPreCheckData.Tables[0].Rows.Count > 0)
                {
                    Session["DayEndData"] = dsPreCheckData;

                    DataView dvCheckIn = new DataView(dsPreCheckData.Tables[0]);
                    dvCheckIn.RowFilter = "Opeartion Like 'ARRIVAL'";

                    if (dvCheckIn.Count == 1)
                    {
                        //temperory off
                        //cnt++;
                        lnkCheckIn.Enabled = false;
                        imgCheckIn.ImageUrl = "~/images/24_tick.png";
                        this.IsCheckInCleared = true;
                    }
                    else
                    {
                        lnkCheckIn.Enabled = true;
                        imgCheckIn.ImageUrl = "~/images/24_x_false.png";
                        this.IsCheckInCleared = false;
                    }


                    DataView dvCheckOut = new DataView(dsPreCheckData.Tables[0]);
                    dvCheckOut.RowFilter = "Opeartion Like 'DEPARTURE'";

                    if (dvCheckOut.Count == 1)
                    {
                        //temperory off
                        //cnt++;
                        lnkCheckOut.Enabled = false;
                        imgCheckOut.ImageUrl = "~/images/24_tick.png";
                        this.IsCheckOutCleared = true;
                    }
                    else
                    {
                        lnkCheckOut.Enabled = true;
                        imgCheckOut.ImageUrl = "~/images/24_x_false.png";
                        this.IsCheckOutCleared = false;
                    }

                    DataView dvDepositTransfer = new DataView(dsPreCheckData.Tables[0]);
                    dvDepositTransfer.RowFilter = "Opeartion Like 'DEPOSIT'";

                    //if (dvDepositTransfer.Count == 1)
                    //{
                    //    //temperory off
                    //    //cnt++;
                    //    lnkDepositTranferred.Enabled = false;
                    //    imgDepositTranferred.ImageUrl = "~/images/24_tick.png";
                    //}
                    //else
                    //{
                    //    lnkDepositTranferred.Enabled = true;
                    //    imgDepositTranferred.ImageUrl = "~/images/24_x_false.png";
                    //}

                    DataView dvAccomodation = new DataView(dsPreCheckData.Tables[0]);
                    dvAccomodation.RowFilter = "Opeartion Like 'ROOM_POSTING'";

                    if (dvAccomodation.Count == 1)
                    {
                        cnt++;
                        lnkPOSTAccomodationCharges.Enabled = false;
                        imgPOSTAccomodationCharges.ImageUrl = "~/images/24_tick.png";
                        this.IsAccomodationChargeCleared = true;
                    }
                    else
                    {
                        lnkPOSTAccomodationCharges.Enabled = true;
                        imgPOSTAccomodationCharges.ImageUrl = "~/images/24_x_false.png";
                        this.IsAccomodationChargeCleared = false;
                    }

                    DataView dvService = new DataView(dsPreCheckData.Tables[0]);
                    dvService.RowFilter = "Opeartion Like 'ROOM_SERVICE_POSTING'";

                    if (dvService.Count == 1)
                    {
                        cnt++;
                        lnkPOSTServiceCharges.Enabled = false;
                        imgPOSTServiceCharges.ImageUrl = "~/images/24_tick.png";
                        this.IsServiceChargeCleared = true;
                    }
                    else
                    {
                        lnkPOSTServiceCharges.Enabled = true;
                        imgPOSTServiceCharges.ImageUrl = "~/images/24_x_false.png";
                        this.IsServiceChargeCleared = false;
                    }

                    DataView dvBalanceSheet = new DataView(dsPreCheckData.Tables[0]);
                    dvBalanceSheet.RowFilter = "Opeartion Like 'CR_DB_BALANCE'";

                    if (dvBalanceSheet.Count == 1)
                    {
                        cnt++;
                        lnkACBalanceSheet.Enabled = false;
                        imgACBalanceSheet.ImageUrl = "~/images/24_tick.png";
                        this.IsActBalanceSheetCleared = true;
                    }
                    else
                    {
                        lnkACBalanceSheet.Enabled = true;
                        imgACBalanceSheet.ImageUrl = "~/images/24_x_false.png";
                        this.IsActBalanceSheetCleared = false;
                    }

                    DataView dvCounter = new DataView(dsPreCheckData.Tables[0]);
                    dvCounter.RowFilter = "Opeartion Like 'CLOSE_COUNTER'";

                    if (dvCounter.Count == 1)
                    {
                        cnt++;
                        lnkCloseCounter.Enabled = false;
                        imgCloseCounter.ImageUrl = "~/images/24_tick.png";
                    }
                    else
                    {
                        lnkCloseCounter.Enabled = true;
                        imgCloseCounter.ImageUrl = "~/images/24_x_false.png";
                    }

                    //temperory change
                    //if (Convert.ToString(cnt) == "7")
                    if (Convert.ToString(cnt) == "4")
                        btnDayEnd.Visible = true;
                    else
                        btnDayEnd.Visible = false;

                }
                else
                {
                    lnkCheckIn.Enabled = lnkCheckOut.Enabled = lnkPOSTAccomodationCharges.Enabled = lnkPOSTServiceCharges.Enabled = lnkACBalanceSheet.Enabled = lnkCloseCounter.Enabled = true; // lnkNoShowList.Enabled = true;
                    imgCheckIn.ImageUrl = imgCheckOut.ImageUrl = imgPOSTAccomodationCharges.ImageUrl = imgPOSTServiceCharges.ImageUrl = imgACBalanceSheet.ImageUrl = imgCloseCounter.ImageUrl = "~/images/24_x_false.png"; // imgNoShowList.ImageUrl = "~/images/24_x_false.png";
                    btnDayEnd.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private string CheckOtherClearanceB4CloseCounter()
        {
            string strClearanceMessage = "";

            if (!(this.IsCheckOutCleared))
                strClearanceMessage = strClearanceMessage + " Check Out,";

            if (!(this.IsCheckInCleared))
                strClearanceMessage = strClearanceMessage + " Check In,";

            //if (!(this.IsNoShowCleared))
            //    strClearanceMessage = strClearanceMessage + " No Show List,";

            if (!(this.IsAccomodationChargeCleared))
                strClearanceMessage = strClearanceMessage + " Room Rent,";

            if (!(this.IsServiceChargeCleared))
                strClearanceMessage = strClearanceMessage + " Service Charge,";

            if (!(this.IsActBalanceSheetCleared))
                strClearanceMessage = strClearanceMessage + " Account Balance Sheet,";

            return strClearanceMessage;
        }

        private void CancelReservation(Guid ReservationID)
        {
            try
            {
                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservation = ReservationBLL.GetByPrimaryKey(ReservationID);
                objReservation.UpdatedBy = clsSession.UserID;
                objReservation.UpdatedOn = DateTime.Now;
                objReservation.RestStatus_TermID = 34;
                objReservation.RoomID = null;
                objReservation.UpdateMode = "DAY END-CANCELLED";
                ReservationHistory objToInsert = new ReservationHistory();
                objToInsert.ReservationID = ReservationID;
                objToInsert.Operation = "Cancel";
                objToInsert.OperationDate = DateTime.Now;
                objToInsert.OperationBy = clsSession.UserID;
                objToInsert.UserName = clsSession.UserName;
                objToInsert.OldStatus_TermID = objReservation.RestStatus_TermID;
                objToInsert.NewStatus_TermID = 34;
                objToInsert.CompanyID = clsSession.CompanyID;
                objToInsert.PropertyID = clsSession.PropertyID;
                objToInsert.OldRecord = objReservation.ToString();
                objToInsert.OperationRequestBy = clsSession.UserName; //Convert.ToString(this.OperationRequestBy);
                objToInsert.OperationRequestMode_TermID = null; //this.OperationRequestModeID;

                DataSet dsCancellationPolicy = ReservationBLL.GetCancellationPolicyAndGuestPayment(clsSession.PropertyID, clsSession.CompanyID, ReservationID, null);

                DataTable dt = new DataTable();

                DataColumn dc1 = new DataColumn("DepositBookID");
                DataColumn dc2 = new DataColumn("Zone_TermID");
                DataColumn dc3 = new DataColumn("Amt");
                DataColumn dc4 = new DataColumn("PaymentAcctID");
                DataColumn dc5 = new DataColumn("DepositAcctID");
                DataColumn dc6 = new DataColumn("ReservationID");
                DataColumn dc7 = new DataColumn("FolioID");
                DataColumn dc8 = new DataColumn("UserID");
                DataColumn dc9 = new DataColumn("CounterID");
                DataColumn dc10 = new DataColumn("PropertyID");
                //DataColumn dc11 = new DataColumn("EntryOrigin");
                DataColumn dc12 = new DataColumn("UnitID");
                DataColumn dc13 = new DataColumn("UnitType");
                DataColumn dc14 = new DataColumn("IsApplyCancellationFees");
                //DataColumn dc15 = new DataColumn("DefaultCounterID");
                DataColumn dc16 = new DataColumn("CompanyID");

                dt.Columns.Add(dc1);
                dt.Columns.Add(dc2);
                dt.Columns.Add(dc3);
                dt.Columns.Add(dc4);
                dt.Columns.Add(dc5);
                dt.Columns.Add(dc6);
                dt.Columns.Add(dc7);
                dt.Columns.Add(dc8);
                dt.Columns.Add(dc9);
                dt.Columns.Add(dc10);
                //dt.Columns.Add(dc11);
                dt.Columns.Add(dc12);
                dt.Columns.Add(dc13);
                dt.Columns.Add(dc14);
                //dt.Columns.Add(dc15);
                dt.Columns.Add(dc16);

                if (dsCancellationPolicy.Tables.Count > 2 && dsCancellationPolicy.Tables[2] != null && dsCancellationPolicy.Tables[2].Rows.Count > 0)
                {
                    DataTable dtDeposits = dsCancellationPolicy.Tables[2];

                    Guid PaymentAccountID = Guid.Empty;
                    if (dsCancellationPolicy.Tables.Count > 3 && dsCancellationPolicy.Tables[3] != null && dsCancellationPolicy.Tables[3].Rows.Count > 0)
                    {
                        PaymentAccountID = new Guid(Convert.ToString(dsCancellationPolicy.Tables[3].Rows[0]["AcctID"]));
                    }

                    if (dtDeposits.Rows.Count > 0)
                    {
                        int? Zone_TermID = null;
                        DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                        if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                            Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);

                        for (int i = 0; i < dtDeposits.Rows.Count; i++)
                        {
                            bool isapplycancelcharge = true; ////Take whole payment as Cancellation charge.

                            Guid? RoomID;
                            if (Convert.ToString(dtDeposits.Rows[i]["RoomID"]) != "" && Convert.ToString(dtDeposits.Rows[i]["RoomID"]) != null)
                                RoomID = new Guid(Convert.ToString(dtDeposits.Rows[i]["RoomID"]));
                            else
                                RoomID = null;

                            DataRow dr = dt.NewRow();

                            dr["DepositBookID"] = Convert.ToString(dtDeposits.Rows[i]["BookID"]);
                            dr["Zone_TermID"] = Convert.ToString(Zone_TermID);
                            dr["Amt"] = "0"; ////Don't to refund any amount, so pass 0 as refunded amount.
                            dr["PaymentAcctID"] = PaymentAccountID;
                            dr["DepositAcctID"] = Convert.ToString(clsSession.DefaultDepositAcctID);
                            dr["ReservationID"] = Convert.ToString(ReservationID);
                            dr["FolioID"] = Convert.ToString(dtDeposits.Rows[i]["FolioID"]);
                            dr["UserID"] = Convert.ToString(clsSession.UserID);
                            dr["CounterID"] = Convert.ToString(clsSession.DefaultCounterID);
                            dr["PropertyID"] = Convert.ToString(clsSession.PropertyID);
                            //dc11["EntryOrigin"] = Convert.ToString("");
                            dr["UnitID"] = Convert.ToString(RoomID);
                            dr["UnitType"] = Convert.ToString("REFUND DEPOSIT");
                            dr["IsApplyCancellationFees"] = Convert.ToString(isapplycancelcharge);
                            //dc15["DefaultCounterID"] = Convert.ToString("");
                            dr["CompanyID"] = Convert.ToString(clsSession.CompanyID);

                            dt.Rows.Add(dr);
                        }
                    }
                }

                ReservationBLL.UpdateWithReservationHistory(objReservation, objToInsert, dt);

                lblCommonMsg.Text = "Reservation transferred to cancelled status Successfully.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void PostRoomCharge()
        {
            try
            {
                DataSet dsUnPostedCharges = ReservationBLL.GetAllUnpostedCharges(this.ReservationIDForPostRoomCharge, null, false);
                if (dsUnPostedCharges != null && dsUnPostedCharges.Tables.Count > 0 && dsUnPostedCharges.Tables[0].Rows.Count > 0)
                {

                    int Zone_TermID = 0;
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                    for (int i = 0; i < dsUnPostedCharges.Tables[0].Rows.Count; i++)
                    {
                        Guid? ResBlockDateRateID = null;
                        Guid? ResServiceID = null;

                        if (dsUnPostedCharges.Tables[0].Rows[i]["ResBlockDateRateID"] != null && Convert.ToString(dsUnPostedCharges.Tables[0].Rows[i]["ResBlockDateRateID"]) != string.Empty)
                            ResBlockDateRateID = new Guid(Convert.ToString(dsUnPostedCharges.Tables[0].Rows[i]["ResBlockDateRateID"]));

                        if (dsUnPostedCharges.Tables[0].Rows[i]["ResServiceID"] != null && Convert.ToString(dsUnPostedCharges.Tables[0].Rows[i]["ResServiceID"]) != string.Empty)
                            ResServiceID = new Guid(Convert.ToString(dsUnPostedCharges.Tables[0].Rows[i]["ResServiceID"]));


                        DateTime dtPostDate = DateTime.ParseExact(Convert.ToDateTime(dsUnPostedCharges.Tables[0].Rows[i]["ServiceDate"]).ToString(clsSession.DateFormat), clsSession.DateFormat, objCultureInfo);

                        Guid? DepositAcctID = clsSession.DefaultDepositAcctID;
                        Guid? CounterID = clsSession.DefaultCounterID;

                        if (Zone_TermID == 0)
                        {
                            DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                            if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                                Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);
                        }

                        decimal dcmlAmount = Convert.ToDecimal("0.000000");
                        if (ResBlockDateRateID != null && Convert.ToString(ResBlockDateRateID) != Guid.Empty.ToString())
                        {
                            if (Convert.ToString(dsUnPostedCharges.Tables[0].Rows[i]["RateCardRate"]) != string.Empty)
                                dcmlAmount = Convert.ToDecimal(Convert.ToString(dsUnPostedCharges.Tables[0].Rows[i]["RateCardRate"]));

                            TransactionBLL.PostRoomCharge(dtPostDate, this.ReservationIDForPostRoomCharge, clsSession.UserID, clsSession.DefaultCounterID, clsSession.PropertyID, "FRONT DESK", dcmlAmount, clsSession.CompanyID);
                        }
                        else
                        {
                            this.ReservationFolioIDForPostRoomCharge = new Guid(Convert.ToString(dsUnPostedCharges.Tables[0].Rows[i]["FolioID"]));
                            string strAmount = Convert.ToString(dsUnPostedCharges.Tables[0].Rows[i]["Amount"]);
                            dcmlAmount = Convert.ToDecimal(strAmount.Substring(0, strAmount.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
                            ResServiceList bojResService = ResServiceListBLL.GetByPrimaryKey((Guid)ResServiceID);
                            TransactionBLL.ItemPosting(bojResService.ItemID, bojResService.Amount, Convert.ToInt32(bojResService.Qty), this.ReservationIDForPostRoomCharge, this.ReservationFolioIDForPostRoomCharge, clsSession.UserID, CounterID, clsSession.PropertyID, "FRONT DESK", Zone_TermID, null, null, ResServiceID, null, dcmlAmount, clsSession.CompanyID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        #endregion

        #region Control Event

        protected void lnkCheckOut_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.strAction = string.Empty;
                litDayEndDetails.Text = "Check Out List";

                if (Session["DayEndData"] != null)
                {
                    DataSet dsCheckOutData = (DataSet)Session["DayEndData"];
                    DataView dvCheckOutData = new DataView(dsCheckOutData.Tables[0]);
                    dvCheckOutData.RowFilter = "Opeartion Like 'DEPARTURE' and CodeID <> '0'";

                    if (dvCheckOutData.Count > 0)
                    {
                        this.strAction = "CHECKOUT";
                        btnPost.Visible = true;
                        btnPost.Text = "Transfer to Unsettled Check Out";
                        gvDayEndDetails.DataSource = dvCheckOutData;
                        gvDayEndDetails.DataBind();
                        gvDayEndDetails.Columns[2].Visible = true;
                    }
                    else
                    {
                        btnPost.Visible = false;
                        btnPost.Text = "Transfer to Unsettled Check Out";
                        gvDayEndDetails.DataSource = null;
                        gvDayEndDetails.DataBind();
                    }
                }
                else
                {
                    btnPost.Visible = false;
                    btnPost.Text = "Transfer to Unsettled Check Out";
                    gvDayEndDetails.DataSource = null;
                    gvDayEndDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void lnkCheckIn_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.strAction = string.Empty;
                litDayEndDetails.Text = "Check In List";

                if (Session["DayEndData"] != null)
                {
                    DataSet dsCheckInData = (DataSet)Session["DayEndData"];
                    DataView dvCheckInData = new DataView(dsCheckInData.Tables[0]);
                    dvCheckInData.RowFilter = "Opeartion Like 'ARRIVAL' and CodeID <> '0'";

                    if (dvCheckInData.Count > 0)
                    {
                        this.strAction = "CHECKIN";
                        //btnPost.Visible = true; //No Action will be done on individual row, so don't visible Post button.
                        btnPost.Visible = false;
                        btnPost.Text = "Transfer to No Show";
                        gvDayEndDetails.DataSource = dvCheckInData;
                        gvDayEndDetails.DataBind();
                        gvDayEndDetails.Columns[2].Visible = true;
                    }
                    else
                    {
                        btnPost.Visible = false;
                        btnPost.Text = "Transfer to No Show";
                        gvDayEndDetails.DataSource = null;
                        gvDayEndDetails.DataBind();
                    }
                }
                else
                {
                    btnPost.Visible = false;
                    btnPost.Text = "Transfer to No Show";
                    gvDayEndDetails.DataSource = null;
                    gvDayEndDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void NoShowList_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.strAction = string.Empty;
                litDayEndDetails.Text = "No Show List";

                if (Session["DayEndData"] != null)
                {
                    DataSet dsNoShowData = (DataSet)Session["DayEndData"];
                    DataView dvNoShowData = new DataView(dsNoShowData.Tables[0]);
                    dvNoShowData.RowFilter = "Opeartion Like 'NOSHOW' and CodeID <> '0'";

                    if (dvNoShowData.Count > 0)
                    {
                        this.strAction = "NOSHOW";
                        btnPost.Visible = true;
                        btnPost.Text = "Release";
                        gvDayEndDetails.DataSource = dvNoShowData;
                        gvDayEndDetails.DataBind();
                        gvDayEndDetails.Columns[2].Visible = false;
                    }
                    else
                    {
                        btnPost.Visible = false;
                        btnPost.Text = "Release";
                        gvDayEndDetails.DataSource = null;
                        gvDayEndDetails.DataBind();

                        ////Temporary until one record come in Precheck data
                        btnPost.Visible = true;
                        btnPost.Text = "Release";
                    }
                }
                else
                {
                    btnPost.Visible = false;
                    btnPost.Text = "Release";
                    gvDayEndDetails.DataSource = null;
                    gvDayEndDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void lnkDepositTranferred_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.strAction = string.Empty;
                litDayEndDetails.Text = "Deposit Tranferred List";

                if (Session["DayEndData"] != null)
                {
                    DataSet dsDepositTranferred = (DataSet)Session["DayEndData"];
                    DataView dvDepositTranferred = new DataView(dsDepositTranferred.Tables[0]);
                    dvDepositTranferred.RowFilter = "Opeartion Like 'DEPOSIT' and CodeID <> '0'";

                    if (dvDepositTranferred.Count > 0)
                    {
                        this.strAction = "DEPOSTITRANSFERRED";
                        btnPost.Visible = true;
                        btnPost.Text = "Transfer";
                        gvDayEndDetails.DataSource = dvDepositTranferred;
                        gvDayEndDetails.DataBind();
                        gvDayEndDetails.Columns[2].Visible = false;
                    }
                    else
                    {
                        btnPost.Visible = false;
                        btnPost.Text = "Transfer";
                        gvDayEndDetails.DataSource = null;
                        gvDayEndDetails.DataBind();
                    }
                }
                else
                {
                    btnPost.Visible = false;
                    btnPost.Text = "Transfer";
                    gvDayEndDetails.DataSource = null;
                    gvDayEndDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void lnkPOSTAccomodationCharges_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.strAction = string.Empty;
                litDayEndDetails.Text = "Post Room Rent List";

                if (Session["DayEndData"] != null)
                {
                    DataSet dsAccomodationCharges = (DataSet)Session["DayEndData"];
                    DataView dvAccomodationCharges = new DataView(dsAccomodationCharges.Tables[0]);
                    dvAccomodationCharges.RowFilter = "Opeartion Like 'ROOM_POSTING' and CodeID <> '0'";

                    if (dvAccomodationCharges.Count > 0)
                    {
                        this.strAction = "ACCOMODATIONCHARGES";
                        btnPost.Visible = true;
                        btnPost.Text = "Post";
                        gvDayEndDetails.DataSource = dvAccomodationCharges;
                        gvDayEndDetails.DataBind();
                        gvDayEndDetails.Columns[2].Visible = false;
                    }
                    else
                    {
                        btnPost.Visible = false;
                        btnPost.Text = "Post";
                        gvDayEndDetails.DataSource = null;
                        gvDayEndDetails.DataBind();
                    }
                }
                else
                {
                    btnPost.Visible = false;
                    btnPost.Text = "Post";
                    gvDayEndDetails.DataSource = null;
                    gvDayEndDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void lnkPOSTServiceCharges_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.strAction = string.Empty;
                litDayEndDetails.Text = "Post Service Charges List";

                if (Session["DayEndData"] != null)
                {
                    DataSet dsService = (DataSet)Session["DayEndData"];
                    DataView dvService = new DataView(dsService.Tables[0]);
                    dvService.RowFilter = "Opeartion Like 'ROOM_POSTING' and CodeID <> '0'";

                    if (dvService.Count > 0)
                    {
                        this.strAction = "POSTSERVICE";
                        btnPost.Visible = true;
                        btnPost.Text = "Post";
                        gvDayEndDetails.DataSource = dvService;
                        gvDayEndDetails.DataBind();
                        gvDayEndDetails.Columns[2].Visible = false;
                    }
                    else
                    {
                        btnPost.Visible = false;
                        btnPost.Text = "Post";
                        gvDayEndDetails.DataSource = null;
                        gvDayEndDetails.DataBind();
                    }
                }
                else
                {
                    btnPost.Visible = false;
                    btnPost.Text = "Post";
                    gvDayEndDetails.DataSource = null;
                    gvDayEndDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void lnkACBalanceSheet_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.strAction = string.Empty;
                litDayEndDetails.Text = "Account Balance Sheet";

                if (Session["DayEndData"] != null)
                {
                    DataSet dsBalanceSheet = (DataSet)Session["DayEndData"];
                    DataView dvBalanceSheet = new DataView(dsBalanceSheet.Tables[0]);
                    dvBalanceSheet.RowFilter = "Opeartion Like 'CR_DB_BALANCE' and CodeID <> '0'";

                    if (dvBalanceSheet.Count > 0)
                    {
                        this.strAction = "BALANCESHEET";
                        btnPost.Visible = true;
                        btnPost.Text = "View";
                        gvDayEndDetails.DataSource = dvBalanceSheet;
                        gvDayEndDetails.DataBind();
                        gvDayEndDetails.Columns[2].Visible = false;
                    }
                    else
                    {
                        btnPost.Visible = false;
                        btnPost.Text = "View";
                        gvDayEndDetails.DataSource = null;
                        gvDayEndDetails.DataBind();
                    }
                }
                else
                {
                    btnPost.Visible = false;
                    btnPost.Text = "View";
                    gvDayEndDetails.DataSource = null;
                    gvDayEndDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void lnkCloseCounter_OnClick(object sender, EventArgs e)
        {
            try
            {
                this.strAction = string.Empty;
                litDayEndDetails.Text = "Close Counter List";

                if (Session["DayEndData"] != null)
                {
                    DataSet dsCounter = (DataSet)Session["DayEndData"];
                    DataView dvCounter = new DataView(dsCounter.Tables[0]);
                    dvCounter.RowFilter = "Opeartion Like 'CLOSE_COUNTER' and CodeID <> '0'";

                    if (dvCounter.Count > 0)
                    {
                        this.strAction = "COUNTERCLOSE";
                        btnPost.Visible = true;
                        btnPost.Text = "Close Counter";
                        gvDayEndDetails.DataSource = dvCounter;
                        gvDayEndDetails.DataBind();
                        gvDayEndDetails.Columns[2].Visible = false;
                    }
                    else
                    {
                        btnPost.Visible = false;
                        btnPost.Text = "Close Counter";
                        gvDayEndDetails.DataSource = null;
                        gvDayEndDetails.DataBind();
                    }
                }
                else
                {
                    btnPost.Visible = false;
                    btnPost.Text = "Close Counter";
                    gvDayEndDetails.DataSource = null;
                    gvDayEndDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnPreChecks_OnClick(object sender, EventArgs e)
        {
            CheckAvailabilityForDayEnd();
        }

        protected void btnDayEnd_Click(object sender, EventArgs e)
        {
            try
            {
                txtConfirmMessage.Text = "";
                mpeConfirmMessage.Show();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnConfirmMessageOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtConfirmMessage.Text.Trim()) != "")
                {
                    if (Convert.ToString(txtConfirmMessage.Text.Trim()) == "YES")
                    {
                        bool blreturnIsSuccess = false;
                        blreturnIsSuccess = DayEndBLL.DayEnd_Save(clsSession.UserID, txtConfirmMessage.Text.Trim(), null, clsSession.CompanyID, clsSession.PropertyID);

                        if (blreturnIsSuccess)
                        {
                            if (clsSession.LogInLogID != Guid.Empty)
                            {
                                LoginLog objToUpdate = LoginLogBLL.GetByPrimaryKey(clsSession.LogInLogID);
                                objToUpdate.Logout = DateTime.Now;
                                LoginLogBLL.Update(objToUpdate);
                            }

                            Session.Clear();
                            Response.Redirect("~/Login.aspx");

                            //IsMessage = true;
                            //lblCommonMsg.Text = "Day End Successfully.";
                            //CheckAvailabilityForDayEnd();
                        }
                    }
                    else
                    {
                        lblCustomePopupMsg.Text = "Day End Process Cancelled.";
                        mpeCustomePopup.Show();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.strAction != string.Empty)
                {
                    DateTime dtStart;
                    if (this.strAction == "ACCOMODATIONCHARGES")
                    {
                        if (gvDayEndDetails.Rows.Count > 0)
                        {
                            BlockDateRate objBlockDateRate = new BlockDateRate();
                            objBlockDateRate = BlockDateRateBLL.GetByPrimaryKey(new Guid(gvDayEndDetails.DataKeys[0]["CodeID"].ToString()));

                            if (objBlockDateRate != null)
                            {
                                dtStart = Convert.ToDateTime(objBlockDateRate.BlockDate);

                                TimeSpan ts = DateTime.Now.Date.Subtract(dtStart.Date);
                                for (int i = 0; i <= ts.TotalDays; i++)
                                {
                                    DayEndBLL.Reservation_AutoPostRoomAndServiceCharge(dtStart.AddDays((double)i), clsSession.UserID, clsSession.DefaultCounterID, clsSession.PropertyID, "RESERVATION", clsSession.CompanyID);
                                }
                            }

                            CheckAvailabilityForDayEnd();
                            IsMessage = true;
                            lblCommonMsg.Text = "Service Posted Successfully.";
                            lnkPOSTAccomodationCharges_OnClick(sender, e);
                        }
                    }
                    else if (this.strAction == "POSTSERVICE")
                    {
                        ResServiceList objResServiceList = new ResServiceList();
                        objResServiceList = ResServiceListBLL.GetByPrimaryKey(new Guid(gvDayEndDetails.DataKeys[0]["CodeID"].ToString()));

                        if (objResServiceList != null)
                        {
                            if (objResServiceList.PostingDate != null && Convert.ToString(objResServiceList.PostingDate) != "")
                            {
                                dtStart = Convert.ToDateTime(objResServiceList.PostingDate);

                                TimeSpan ts = DateTime.Now.Date.Subtract(dtStart.Date);
                                for (int i = 0; i <= ts.TotalDays; i++)
                                {
                                    DayEndBLL.Reservation_AutoPostRoomAndServiceCharge(dtStart.AddDays((double)i), clsSession.UserID, clsSession.DefaultCounterID, clsSession.PropertyID, "RESERVATION", clsSession.CompanyID);
                                }
                            }
                        }

                        CheckAvailabilityForDayEnd();
                        IsMessage = true;
                        lblCommonMsg.Text = "Service Posted Successfully.";
                        lnkPOSTServiceCharges_OnClick(sender, e);
                    }
                    else if (this.strAction == "COUNTERCLOSE")
                    {
                        string strClearanceMessage = CheckOtherClearanceB4CloseCounter();

                        if (strClearanceMessage == "")
                        {
                            ////Check If any counter open or not.
                            if (gvDayEndDetails.Rows.Count > 0)
                            {
                                //// If Open counter is greater than 1, then don't allow to close currently open(selected) counter.
                                if (gvDayEndDetails.Rows.Count > 1)
                                {
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                                    MessageBox.Show("Please close <b>other counter(s)</b> before you going to close your currently open counter.");
                                }
                                else
                                {
                                    if (clsSession.DefaultCounterID == new Guid(gvDayEndDetails.DataKeys[0]["CodeID"].ToString()))
                                    {
                                        Session["IsCounterCloseForDayEnd"] = "1";
                                        Response.Redirect("~/GUI/Counter/CloseCounter.aspx");
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (gvDayEndDetails.Rows.Count > 1)
                                strClearanceMessage = "Please clear<b>" + strClearanceMessage.TrimEnd(',') + " and close other counter(s)</b> before you going to close your currently open counter.";
                            else
                                strClearanceMessage = "Please clear<b>" + strClearanceMessage.TrimEnd(',') + "</b> before you going to close your currently open counter.";

                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                            MessageBox.Show(strClearanceMessage);
                        }
                    }
                    else if (this.strAction == "CHECKOUT")
                    {
                        for (int i = 0; i < gvDayEndDetails.Rows.Count; i++)
                        {
                            if (Convert.ToString(gvDayEndDetails.DataKeys[i]["CodeID"]) != string.Empty)
                            {
                                this.ReservationIDForPostRoomCharge = new Guid(gvDayEndDetails.DataKeys[i]["CodeID"].ToString());
                                PostRoomCharge();

                                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservation = ReservationBLL.GetByPrimaryKey(new Guid(gvDayEndDetails.DataKeys[i]["CodeID"].ToString()));
                                objReservation.UpdatedBy = clsSession.UserID;
                                objReservation.UpdatedOn = DateTime.Now;
                                objReservation.RestStatus_TermID = 33;
                                objReservation.ActualCheckOutDate = DateTime.Now;
                                objReservation.UpdateMode = "DAY END-UNSETTLED CHECKOUT";
                                ReservationBLL.Update(objReservation);

                                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio objFolio = FolioBLL.GetByPrimaryKey((Guid)objReservation.FolioID);
                                objFolio.FolioStatus = "CHECK_OUT_OPEN";
                                objFolio.UpdatedOn = DateTime.Now;

                                FolioBLL.Update(objFolio);
                            }
                        }

                        CheckAvailabilityForDayEnd();
                        IsMessage = true;
                        lblCommonMsg.Text = "Reservations transfed to unsettled check out successfully.";
                        lnkCheckOut_OnClick(sender, e);
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

        #region Grid Event

        protected void gvDayEndDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    //((CheckBox)e.Row.FindControl("chkSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("chkSelectAll")).ClientID + "')");
                }
                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //LinkButton LinkButton = (LinkButton)e.Row.FindControl("lnkAction");                    
                    if (this.strAction == "CHECKIN")
                    {
                        if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ErrorCode")).ToUpper().IndexOf("CONFIRMED") > -1)
                            ((LinkButton)e.Row.FindControl("lnkTransferToNoShow")).Visible = true;
                        else
                            ((LinkButton)e.Row.FindControl("lnkTransferToCancelled")).Visible = true;
                    }
                    else if (this.strAction == "CHECKOUT")
                    {
                        DataSet dsForCheckBillingInstruction = ReservationBLL.GetBillingInstructionTermStatus(new Guid(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CodeID"))), clsSession.CompanyID, clsSession.PropertyID, true);
                        if (dsForCheckBillingInstruction != null && dsForCheckBillingInstruction.Tables.Count > 0 && dsForCheckBillingInstruction.Tables[0].Rows.Count > 0 && Convert.ToInt32(dsForCheckBillingInstruction.Tables[0].Rows[0]["NoOfRecord"]) > 0)
                        {
                            ((LinkButton)e.Row.FindControl("lnkOverStay")).Visible = true;
                            ((LinkButton)e.Row.FindControl("lnkOverStay")).Enabled = true;
                        }
                        else
                        {
                            ((LinkButton)e.Row.FindControl("lnkOverStay")).Visible = true;
                            ((LinkButton)e.Row.FindControl("lnkOverStay")).Enabled = false;
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvDayEndDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("TRANSFERTONOSHOW"))
                {
                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservation = ReservationBLL.GetByPrimaryKey(new Guid(Convert.ToString(e.CommandArgument)));
                    objReservation.RestStatus_TermID = 35;
                    objReservation.UpdatedOn = DateTime.Now;
                    objReservation.UpdatedBy = clsSession.UserID;
                    objReservation.UpdateMode = "DAY END-NOSHOW";
                    ReservationBLL.Update(objReservation);

                    lblCommonMsg.Text = "Reservation transferred to no show status Successfully.";
                    IsMessage = true;
                    CheckAvailabilityForDayEnd();
                    lnkCheckIn_OnClick(sender, e);
                }
                else if (e.CommandName.ToUpper().Equals("TRANSFERTOCANCELLED"))
                {
                    CancelReservation(new Guid(Convert.ToString(e.CommandArgument)));

                    lblCommonMsg.Text = "Reservation transferred to cancelled status Successfully.";
                    IsMessage = true;
                    CheckAvailabilityForDayEnd();
                    lnkCheckIn_OnClick(sender, e);
                }
                else if (e.CommandName.ToUpper().Equals("OVERSTAY"))
                {
                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    this.ReservationIDForOverStay = new Guid(gvDayEndDetails.DataKeys[row.RowIndex]["CodeID"].ToString());
                    ProcessForOverStay();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void ProcessForOverStay()
        {
            try
            {
                CheckRoomAvailabilityForOverStay();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void CalculateRoomRate()
        {
            string strRoomRate = "select IsNUll(sum(RoomRate),0.000000)'RoomRate' from res_BlockDateRate where ReservationID = '" + Convert.ToString(this.ReservationIDForOverStay) + "'";
            DataSet dsRate = RoomBLL.GetUnitNo(strRoomRate);

            decimal dcmlOldRoomRate = Convert.ToDecimal("0.000000");
            if (dsRate.Tables.Count > 0 && dsRate.Tables[0].Rows.Count > 0)
            {
                dcmlOldRoomRate = Convert.ToDecimal(dsRate.Tables[0].Rows[0]["RoomRate"]);
            }
            decimal dcmlTotalTaxes = Convert.ToDecimal("0.000000");

            decimal dcmlNewRoundOffTotal = 0;
            decimal dcmlUpdateLastBlockdaterateamt = 0;

            List<BlockDateRate> lstBlockDateRate_Insert = new List<BlockDateRate>();
            if (Session["lstExtendReservationBlockDateRate"] != null)
            {
                lstBlockDateRate_Insert = (List<BlockDateRate>)Session["lstExtendReservationBlockDateRate"];
            }
            dcmlNewRoundOffTotal = Math.Round(dcFtTotal);
            List<BlockDateRate> query = lstBlockDateRate_Insert.Distinct().ToList();
            List<BlockDateRate> lastRecord = query.Skip(query.Count - 1).ToList();
            if (dcmlNewRoundOffTotal > dcFtTotal)
            {
                dcmlUpdateLastBlockdaterateamt = dcmlNewRoundOffTotal - dcFtTotal;
                lastRecord[0].RoomRate = Convert.ToDecimal(lastRecord[0].RoomRate) + dcmlUpdateLastBlockdaterateamt;
                lastRecord[0].RateCardRate = Convert.ToDecimal(lastRecord[0].RateCardRate) + dcmlUpdateLastBlockdaterateamt;
            }
            else
            {
                dcmlUpdateLastBlockdaterateamt = dcFtTotal - dcmlNewRoundOffTotal;
                lastRecord[0].RoomRate = Convert.ToDecimal(lastRecord[0].RoomRate) - dcmlUpdateLastBlockdaterateamt;
                lastRecord[0].RateCardRate = Convert.ToDecimal(lastRecord[0].RateCardRate) - dcmlUpdateLastBlockdaterateamt;
            }

            lstBlockDateRate_Insert.RemoveAt(lstBlockDateRate_Insert.Count - 1);
            lstBlockDateRate_Insert.Add(lastRecord[lastRecord.Count - 1]);

            Session["lstExtendReservationBlockDateRate"] = lstBlockDateRate_Insert;
            dcmlTotlRate = dcmlOldRoomRate + dcmlNewRoundOffTotal;
        }
        private void ProcessOverStayForOneDay()
        {
            try
            {
                if (this.ReservationIDForOverStay != Guid.Empty && this.RoomID != Guid.Empty && this.RoomTypeID != Guid.Empty && this.FolioID != Guid.Empty)
                {
                    decimal dcmlAllowRateForOverStay = Convert.ToDecimal("0.000000");
                    decimal PaidDeposit = Convert.ToDecimal("0.000000");
                    decimal TotalPaymentReceived = Convert.ToDecimal("0.000000");
                    decimal NewTotalRoomRate = Convert.ToDecimal("0.000000");

                    ////Get Payment info.
                    DataSet dsPaymentInfo = ReservationBLL.GetReservationPaymentInfo4ExtendStay(clsSession.PropertyID, clsSession.CompanyID, this.ReservationIDForOverStay);

                    ////Set Paid Deposit
                    if (dsPaymentInfo != null && dsPaymentInfo.Tables.Count > 2 && dsPaymentInfo.Tables[2].Rows.Count > 0)
                        PaidDeposit = Convert.ToDecimal(Convert.ToString(dsPaymentInfo.Tables[2].Rows[0]["PaidDeposit"]));

                    ////Set paid total amount
                    if (dsPaymentInfo != null && dsPaymentInfo.Tables.Count > 3 && dsPaymentInfo.Tables[3].Rows.Count > 0)
                        TotalPaymentReceived = Convert.ToDecimal(Convert.ToString(dsPaymentInfo.Tables[3].Rows[0]["TotalPaidAmount"]));

                    ////Set new total room rent
                    NewTotalRoomRate = dcmlTotlRate;

                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio objFolioBalance = new SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio();
                    objFolioBalance = FolioBLL.GetByPrimaryKey(this.FolioID);

                    decimal dcmlFolioBalance = Convert.ToDecimal("0.000000");

                    if (objFolioBalance != null)
                        dcmlFolioBalance = Convert.ToDecimal(objFolioBalance.CurrentBalace);

                    //Sec. Depost + Curr. Balance -  Over Stay Day Posting >= 0
                    dcmlAllowRateForOverStay = Convert.ToDecimal(PaidDeposit - dcmlFolioBalance - (NewTotalRoomRate - (TotalPaymentReceived - PaidDeposit)));
                    if (dcmlAllowRateForOverStay <= 0)
                    {
                        lblCustomePopupMsg.Text = "You can't overstay this reservation because it has not enough deposit for that.";
                        mpeCustomePopup.Show();
                        return;
                    }

                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    List<BlockDateRate> lstBlockDateRate_Insert = new List<BlockDateRate>();
                    List<ResServiceList> lstResServiceList_Insert = new List<ResServiceList>();

                    if (Session["lstExtendReservationBlockDateRate"] != null)
                    {
                        lstBlockDateRate_Insert = (List<BlockDateRate>)Session["lstExtendReservationBlockDateRate"];
                    }


                    if (Session["lstExtendReservationResService"] != null)
                    {
                        lstResServiceList_Insert = (List<ResServiceList>)Session["lstExtendReservationResService"];
                    }

                    lstBlockDateRate_Insert[0].IsOverStay = true;

                    BlockDateRateBLL.SaveBlockDateEntry(lstBlockDateRate_Insert, lstResServiceList_Insert, this.ReservationIDForOverStay, this.RoomID, this.RoomTypeID, this.RestStatus_TermID, this.FolioID);

                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objOldReservationData = new BusinessLogic.FrontDesk.DTO.Reservation();
                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservation = new BusinessLogic.FrontDesk.DTO.Reservation();

                    objReservation = ReservationBLL.GetByPrimaryKey(this.ReservationIDForOverStay);
                    objOldReservationData = ReservationBLL.GetByPrimaryKey(this.ReservationIDForOverStay);

                    DateTime dtToSetStdCheckInOutTime = new DateTime();
                    DateTime dtToSetCheckInOutDate = new DateTime();
                    if (this.StandardCheckOutTime != string.Empty)
                    {
                        dtToSetCheckInOutDate = this.New_CheckOutDate.Date.AddDays(1);
                        dtToSetStdCheckInOutTime = Convert.ToDateTime(this.StandardCheckOutTime);
                        objReservation.CheckOutDate = new DateTime(dtToSetCheckInOutDate.Year, dtToSetCheckInOutDate.Month, Convert.ToInt32(dtToSetCheckInOutDate.Day), dtToSetStdCheckInOutTime.Hour, dtToSetStdCheckInOutTime.Minute, 0);
                    }
                    else
                    {
                        objReservation.CheckOutDate = this.New_CheckOutDate.Date.AddDays(1);
                    }
                    // objReservation.CheckOutDate = DateTime.ParseExact(txtNewDepartureDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                    objReservation.UpdatedBy = clsSession.UserID;
                    objReservation.UpdatedOn = DateTime.Now;
                    objReservation.UpdateMode = "RESERVATION EXTAND";
                    ReservationBLL.Update(objReservation);
                    ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Save", null, null, "res_BlockDateRate", "");

                    CheckForOverStayPanelty();

                    ClearFormData();
                    CheckAvailabilityForDayEnd();
                    lnkCheckOut_OnClick(null, null);
                    //lnkPOSTAccomodationCharges_OnClick(null, null);
                    IsMessage = true;
                    lblCommonMsg.Text = "Reservations Extanded For one day more successfully.";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void CheckRoomAvailabilityForOverStay()
        {
            try
            {
                SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservationInfo = ReservationBLL.GetByPrimaryKey(this.ReservationIDForOverStay);
                this.New_CheckOutDate = Convert.ToDateTime(objReservationInfo.CheckOutDate);
                this.RestStatus_TermID = Convert.ToInt32(objReservationInfo.RestStatus_TermID);
                this.FolioID = new Guid(Convert.ToString(objReservationInfo.FolioID));
                this.RoomTypeID = new Guid(Convert.ToString(objReservationInfo.RoomTypeID));
                this.RoomID = new Guid(Convert.ToString(objReservationInfo.RoomID));
                
                this.RateID = new Guid(Convert.ToString(objReservationInfo.RateID));
                //// Use Reservation's Ratecard to over stay instead of 1N ratecard.
                //// Take 1 N Rate Card For Over stay
                //DataSet dsForOverStayratecard = RateCardBLL.GetRateCardForOverStay(dtCheckInDate, dtCheckoutDate, clsSession.PropertyID, clsSession.CompanyID);
                //if (dsForOverStayratecard != null && dsForOverStayratecard.Tables.Count > 0 && dsForOverStayratecard.Tables[0].Rows.Count > 0 && Convert.ToString(dsForOverStayratecard.Tables[0].Rows[0]["RateID"]) != "")
                //{
                //    this.RateID = new Guid(Convert.ToString(dsForOverStayratecard.Tables[0].Rows[0]["RateID"]));
                //}
                //else
                //{
                //    lblCustomePopupMsg.Text = "Over stay rate card is not available so you can't proceed.";
                //    mpeCustomePopup.Show();
                //    return;
                //}

                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                DateTime? dtCheckInDate = null;
                DateTime? dtCheckoutDate = null;

                DateTime dtToSetCheckInDate = new DateTime();
                DateTime dtToSetCheckOutDate = new DateTime();

                dtToSetCheckInDate = this.New_CheckOutDate.Date;

                dtToSetCheckOutDate = this.New_CheckOutDate.Date.AddDays(1);

                List<ReservationConfig> lstReservation = null;
                ReservationConfig objReservationConfig = new ReservationConfig();
                objReservationConfig.IsActive = true;
                objReservationConfig.CompanyID = clsSession.CompanyID;
                objReservationConfig.PropertyID = clsSession.PropertyID;
                lstReservation = ReservationConfigBLL.GetAll(objReservationConfig);

                DateTime dtStandardCheckInTime;
                DateTime dtStandardCheckOutTime;

                if (lstReservation.Count != 0)
                {
                    dtStandardCheckInTime = Convert.ToDateTime(lstReservation[0].CheckInTime);
                    dtStandardCheckOutTime = Convert.ToDateTime(lstReservation[0].CheckOutTime);

                    dtCheckInDate = new DateTime(dtToSetCheckInDate.Year, dtToSetCheckInDate.Month, Convert.ToInt32(dtToSetCheckInDate.Day), dtStandardCheckInTime.Hour, dtStandardCheckInTime.Minute, 0);
                    dtCheckoutDate = new DateTime(dtToSetCheckOutDate.Year, dtToSetCheckOutDate.Month, Convert.ToInt32(dtToSetCheckOutDate.Day), dtStandardCheckOutTime.Hour, dtStandardCheckOutTime.Minute, 0);
                }

                decimal dcmlTotalAmt = Convert.ToDecimal("0.000000");
                DataSet dsGetAllVacantRoom = ReservationBLL.GetAllVacantRoom(dtCheckInDate, dtCheckoutDate, new Guid(Convert.ToString(objReservationInfo.RoomTypeID)), false, null, clsSession.PropertyID, clsSession.CompanyID);

                
                if (dsGetAllVacantRoom.Tables.Count > 0 && dsGetAllVacantRoom.Tables[0].Rows.Count > 0)
                {
                    DataView dvData = new DataView(dsGetAllVacantRoom.Tables[0]);
                    dvData.RowFilter = "RoomID = '" + Convert.ToString(objReservationInfo.RoomID) + "'";

                    if (dvData.Count > 0)
                    {
                        //Available So Go Further For Over Stay
                        CalculateNewRoomrateForOverStay();
                        ProcessOverStayForOneDay();
                    }
                    else
                    {
                        //Not Available                            
                        DataSet dsExtendStayData = ReservationBLL.GetReservationsForExtendStay(dtCheckInDate, dtCheckoutDate, null, new Guid(Convert.ToString(objReservationInfo.RoomID)), null, clsSession.CompanyID, clsSession.PropertyID);
                        if (dsExtendStayData.Tables.Count > 0 && dsExtendStayData.Tables[0].Rows.Count > 0)
                        {
                            DataRow[] dr = dsExtendStayData.Tables[0].Select("ReservationID <> '" + Convert.ToString(this.ReservationIDForOverStay) + "'");
                            if (dr.Length > 0)
                            {
                                DateTime dtGuestCheckInDate = Convert.ToDateTime(dr[0]["CheckInDate"]);
                                DateTime dtGuestCheckOutDate = Convert.ToDateTime(dr[0]["CheckOutDate"]);
                                lblCustomePopupMsg.Text = "Current Room is not available because" + Convert.ToString(dr[0]["Guest_Name"]) + " with Booking No. " + Convert.ToString(dr[0]["ReservationNo"]) + " already blocked it from " + dtGuestCheckInDate.ToString(clsSession.DateFormat) + " to " + dtGuestCheckOutDate.ToString(clsSession.DateFormat) + "";
                            }
                        }
                        else
                        {
                            lblCustomePopupMsg.Text = "Room is not Available, you can't extend your this stay.";
                        }
                        mpeCustomePopup.Show();
                        ClearFormData();
                        return;
                    }
                }
                else
                {
                    lblCustomePopupMsg.Text = "Room is not Available, you can't extend your this stay.";
                    mpeCustomePopup.Show();
                    return;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }


        }
        private void CalculateTotalNewRate()
        {
            List<BlockDateRate> lstBlockDateRate_CalculateNewRate = new List<BlockDateRate>();
            List<ResServiceList> lstResServiceList_Insert = new List<ResServiceList>();

            if (Session["lstExtendReservationBlockDateRate"] != null)
            {
                lstBlockDateRate_CalculateNewRate = (List<BlockDateRate>)Session["lstExtendReservationBlockDateRate"];
            }
            foreach (BlockDateRate objTocalc in lstBlockDateRate_CalculateNewRate)
            {
                decimal dcmlRMRate = Convert.ToDecimal("0.00000");
                decimal dcmlTax = Convert.ToDecimal("0.00000");
                decimal dcmlDiscount = Convert.ToDecimal("0.00000");
                decimal dcmlTotal = Convert.ToDecimal("0.00000");

                decimal dcmTotalPaidByGuest = Convert.ToDecimal("0.00000");

                if (Convert.ToString(objTocalc.RateCardRate) != null && Convert.ToString(objTocalc.RateCardRate) != "")
                {
                    string strRMRate = Convert.ToString(objTocalc.RateCardRate).Trim().IndexOf('.') > -1 ? Convert.ToString(objTocalc.RateCardRate).Trim() + "000000" : Convert.ToString(objTocalc.RateCardRate).Trim() + ".000000";
                    dcmlRMRate = Convert.ToDecimal(strRMRate);
                }


                if (Convert.ToString(objTocalc.AppliedTax) != null && Convert.ToString(objTocalc.AppliedTax) != "")
                {
                    string strTax = Convert.ToString(objTocalc.AppliedTax).Trim().IndexOf('.') > -1 ? Convert.ToString(objTocalc.AppliedTax).Trim() + "000000" : Convert.ToString(objTocalc.AppliedTax).Trim() + ".000000";
                    dcmlTax = Convert.ToDecimal(strTax);
                }

                if (Convert.ToString(objTocalc.DiscountAmt) != null && Convert.ToString(objTocalc.DiscountAmt) != "")
                {
                    string strDiscountAmt = Convert.ToString(objTocalc.DiscountAmt).Trim().IndexOf('.') > -1 ? Convert.ToString(objTocalc.DiscountAmt).Trim() + "000000" : Convert.ToString(objTocalc.DiscountAmt).Trim() + ".000000";
                    dcmlDiscount = Convert.ToDecimal(strDiscountAmt);

                }

                dcmlTotal = dcmlRMRate + dcmlTax + dcmlDiscount;
                dcFtTotal += dcmlTotal;

            }
        }
        private void CalculateNewRoomrateForOverStay()
        {
            try
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                List<BlockDateRate> lstBlockDateRate_New = new List<BlockDateRate>();
                List<ResServiceList> lstResServiceList = new List<ResServiceList>();
                string strStandardCheckInTime = string.Empty;
                string strStandardCheckOutTime = string.Empty;

                DateTime dtnewCheckInDate = this.New_CheckOutDate.Date;
                DateTime dtnewCheckOutDate = this.New_CheckOutDate.Date.AddDays(1);
                lstBlockDateRate_New = clsBlockDateRate.GetCal_RoomWorksheet(dtnewCheckInDate, dtnewCheckOutDate, this.RoomTypeID, this.RateID, null, 1, 0, string.Empty, ref lstResServiceList, ref strStandardCheckInTime, ref strStandardCheckOutTime, this.ReservationIDForOverStay, "EDIT");

                this.StandardCheckOutTime = strStandardCheckOutTime;
                Session["lstExtendReservationBlockDateRate"] = lstBlockDateRate_New;
                Session["lstExtendReservationResService"] = lstResServiceList;
                CalculateTotalNewRate();
                CalculateRoomRate();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void ClearFormData()
        {
            Session["lstExtendReservationBlockDateRate"] = Session["lstExtendReservationResService"] = null;
            this.New_CheckOutDate = DateTime.Now;
            this.StandardCheckOutTime = string.Empty;
            this.RateID = this.ReservationIDForOverStay = this.RoomID = this.RoomTypeID = Guid.Empty;
            this.RestStatus_TermID = 0;
            dcmlTotlRate = Convert.ToDecimal("0.000000");
            dcFtTotal = Convert.ToDecimal("0.000000");
        }
        public void CheckForOverStayPanelty()
        {
            DataSet dsOverStayCharges = ReservationBLL.GetTotalNumOfOverstayCharges(this.ReservationIDForOverStay);
            if (dsOverStayCharges != null && dsOverStayCharges.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToInt32(dsOverStayCharges.Tables[0].Rows[0]["Charges"].ToString()) > 0)
                {
                    Guid returnID = Guid.Empty;

                    returnID = FolioBLL.FolioQuickPostInAccountNew(new Guid("3465811B-BDB5-43C1-ADBA-61F92927D16A"), null, Convert.ToDecimal(dsOverStayCharges.Tables[0].Rows[0]["Charges"].ToString()), 1, this.ReservationIDForOverStay, this.FolioID, clsSession.DefaultCounterID, clsSession.PropertyID, clsSession.UserID, null, null, Convert.ToDecimal(dsOverStayCharges.Tables[0].Rows[0]["Charges"].ToString()), clsSession.CompanyID);

                    if (returnID != Guid.Empty)
                    {
                        BookKeeping objBookKeeping = new BookKeeping();
                        objBookKeeping = BookKeepingBLL.GetByPrimaryKey(returnID);

                        if (objBookKeeping != null)
                        {
                            objBookKeeping.Narration = "Over stay panelty charge";
                            BookKeepingBLL.Update(objBookKeeping);
                        }
                    }
                }
            }
        }
        #endregion
    }
}