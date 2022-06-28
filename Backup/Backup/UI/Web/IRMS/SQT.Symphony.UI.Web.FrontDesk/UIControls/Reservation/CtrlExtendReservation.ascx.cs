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
using System.Globalization;
using System.IO;

namespace SQT.Symphony.UI.Web.FrontDesk.UIControls.Reservation
{
    public partial class CtrlExtendReservation : System.Web.UI.UserControl
    {
        #region Property and Variable
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
        public string IsOpenPopUp
        {
            get
            {
                return ViewState["IsOpenPopUp"] != null ? Convert.ToString(ViewState["IsOpenPopUp"]) : string.Empty;
            }
            set
            {
                ViewState["IsOpenPopUp"] = value;
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
        public bool IsListMessage = false;
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
        public decimal dcFtTotal = Convert.ToDecimal("0.000000");
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
        public Guid GuestReservationID
        {
            get
            {
                return ViewState["GuestReservationID"] != null ? new Guid(Convert.ToString(ViewState["GuestReservationID"])) : Guid.Empty;
            }
            set
            {
                ViewState["GuestReservationID"] = value;
            }
        }
        public bool IsToShowPaidByComp
        {
            get
            {
                return ViewState["IsToShowPaidByComp"] != null ? Convert.ToBoolean(ViewState["IsToShowPaidByComp"]) : false;
            }
            set
            {
                ViewState["IsToShowPaidByComp"] = value;
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
        public bool IsReservationMsg = false;
        public Decimal AmountSuggestedToPay
        {
            get
            {
                return ViewState["AmountSuggestedToPay"] != null ? Convert.ToDecimal(ViewState["AmountSuggestedToPay"]) : Convert.ToDecimal("0.000000");
            }
            set
            {
                ViewState["AmountSuggestedToPay"] = value;
            }
        }
        public Decimal ResDepositAmount
        {
            get
            {
                return ViewState["ResDepositAmount"] != null ? Convert.ToDecimal(ViewState["ResDepositAmount"]) : Convert.ToDecimal("0.000000");
            }
            set
            {
                ViewState["ResDepositAmount"] = value;
            }
        }
        public Decimal PaidDepositAmount
        {
            get
            {
                return ViewState["PaidDepositAmount"] != null ? Convert.ToDecimal(ViewState["PaidDepositAmount"]) : Convert.ToDecimal("0.000000");
            }
            set
            {
                ViewState["PaidDepositAmount"] = value;
            }
        }
        public int ResInfraServiceChargeAmount
        {
            get
            {
                return ViewState["ResInfraServiceChargeAmount"] != null ? Convert.ToInt32(ViewState["ResInfraServiceChargeAmount"]) : 0;
            }
            set
            {
                ViewState["ResInfraServiceChargeAmount"] = value;
            }
        }
        public int PaidInfraServiceChargeAmount
        {
            get
            {
                return ViewState["PaidInfraServiceChargeAmount"] != null ? Convert.ToInt32(ViewState["PaidInfraServiceChargeAmount"]) : 0;
            }
            set
            {
                ViewState["PaidInfraServiceChargeAmount"] = value;
            }
        }
        public int ResFoodChargeAmount
        {
            get
            {
                return ViewState["ResFoodChargeAmount"] != null ? Convert.ToInt32(ViewState["ResFoodChargeAmount"]) : 0;
            }
            set
            {
                ViewState["ResFoodChargeAmount"] = value;
            }
        }
        public int PaidFoodChargeAmount
        {
            get
            {
                return ViewState["PaidFoodChargeAmount"] != null ? Convert.ToInt32(ViewState["PaidFoodChargeAmount"]) : 0;
            }
            set
            {
                ViewState["PaidFoodChargeAmount"] = value;
            }
        }
        public int ElectricityChargeAmount
        {
            get
            {
                return ViewState["ElectricityChargeAmount"] != null ? Convert.ToInt32(ViewState["ElectricityChargeAmount"]) : 0;
            }
            set
            {
                ViewState["ElectricityChargeAmount"] = value;
            }
        }
        public int PaidElectricityChargeAmount
        {
            get
            {
                return ViewState["PaidElectricityChargeAmount"] != null ? Convert.ToInt32(ViewState["PaidElectricityChargeAmount"]) : 0;
            }
            set
            {
                ViewState["PaidElectricityChargeAmount"] = value;
            }
        }
        public int ExtendStayInfraServiceChargeAmount
        {
            get
            {
                return ViewState["ExtendStayInfraServiceChargeAmount"] != null ? Convert.ToInt32(ViewState["ExtendStayInfraServiceChargeAmount"]) : 0;
            }
            set
            {
                ViewState["ExtendStayInfraServiceChargeAmount"] = value;
            }
        }
        public int ExtendStayFoodChargeAmount
        {
            get
            {
                return ViewState["ExtendStayFoodChargeAmount"] != null ? Convert.ToInt32(ViewState["ExtendStayFoodChargeAmount"]) : 0;
            }
            set
            {
                ViewState["ExtendStayFoodChargeAmount"] = value;
            }
        }
        public int ExtendStayElectricityChargeAmount
        {
            get
            {
                return ViewState["ExtendStayElectricityChargeAmount"] != null ? Convert.ToInt32(ViewState["ExtendStayElectricityChargeAmount"]) : 0;
            }
            set
            {
                ViewState["ExtendStayElectricityChargeAmount"] = value;
            }
        }
        public string strPaidAmt2AvoidDoubleEntry
        {
            get
            {
                return ViewState["strPaidAmt2AvoidDoubleEntry"] != null ? Convert.ToString(ViewState["strPaidAmt2AvoidDoubleEntry"]) : string.Empty;
            }
            set
            {
                ViewState["strPaidAmt2AvoidDoubleEntry"] = value;
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
        public Decimal RoomRatePerDay
        {
            get
            {
                return ViewState["RoomRatePerDay"] != null ? Convert.ToDecimal(ViewState["RoomRatePerDay"]) : Convert.ToDecimal("0.000000");
            }
            set
            {
                ViewState["RoomRatePerDay"] = value;
            }
        }
        public bool IsAutoCalculateBcasOverStayDays
        {
            get
            {
                return ViewState["IsAutoCalculateBcasOverStayDays"] != null ? Convert.ToBoolean(ViewState["IsAutoCalculateBcasOverStayDays"]) : false;
            }
            set
            {
                ViewState["IsAutoCalculateBcasOverStayDays"] = value;
            }
        }

        #endregion

        #region Page Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessIsDenied.aspx");

                CheckUserAuthorization();
                LoadDefaultValue();
            }
        }

        #endregion Page Load

        #region Private Method
        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "ExtendReservation.aspx");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessIsDenied.aspx");


        }
        //private bool IsWholeRoomIsAvailable(DateTime? checkInDate, DateTime? checkOutDate, Guid RoomID)
        //{
        //    bool isWholeRommAvailable = true;

        //    DataSet dsIsRoomAvbl = ReservationBLL.GetAllIsAvailableRoom(checkInDate, checkOutDate, this.RoomTypeID, this.ReservationID, clsSession.PropertyID, clsSession.CompanyID);
        //    DataSet dsRoomIDs = RoomBLL.GetAllRoomIDOfRoomByAnyRoomID(RoomID, clsSession.PropertyID);

        //    if (dsRoomIDs.Tables[0].Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dsRoomIDs.Tables[0].Rows.Count; i++)
        //        {
        //            DataRow[] drRoomAvbl = dsIsRoomAvbl.Tables[0].Select("RoomID = '" + Convert.ToString(dsRoomIDs.Tables[0].Rows[i]["RoomID"]) + "'");
        //            if (drRoomAvbl.Length == 0)
        //            {
        //                isWholeRommAvailable = false;
        //                break;
        //            }
        //        }
        //    }

        //    return isWholeRommAvailable;
        //}
        private void LoadDefaultValue()
        {
            try
            {
                mvExtendStay.ActiveViewIndex = 0;
                BindBreadCrumb();
                BindSearchRoomType();
                BindProjectTermData();
                //BindGrid(); // To avoid loading time of page, b'cas always new search required to find actual guest.
                Session["lstExtendReservationBlockDateRate"] = Session["lstExtendReservationResService"] = null;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindProjectTermData()
        {
            DataSet dsData = ProjectTermBLL.SelectTitleCSWTGT(clsSession.CompanyID, clsSession.PropertyID, "TITLE", "COMPANYSECTOR", "WORKINGTIME", "GUESTTYPE", "ID DOCUMENT TYPE", "BLOOD GROUP", "MEAL PREFERENCE", "PAYMENTMODE");

            ddlModeOfPayment.Items.Clear();
            if (dsData.Tables.Count != 0 && dsData.Tables[7].Rows.Count > 0)
            {
                ddlModeOfPayment.DataSource = dsData.Tables[7];
                ddlModeOfPayment.DataTextField = "DisplayTerm";
                ddlModeOfPayment.DataValueField = "TermID";
                ddlModeOfPayment.DataBind();
                ddlModeOfPayment.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            else
                ddlModeOfPayment.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
        }

        public void BindGrid()
        {
            try
            {
                string strName = null;
                string strReservationNo = null;
                string strRoomNo = null;
                Guid? RoomTypeID = null;

                if (txtSearchGuestName.Text.Trim() != "")
                    strName = Convert.ToString(txtSearchGuestName.Text.Trim());

                if (txtSearchBookingNo.Text.Trim() != "")
                    strReservationNo = "RES#" + Convert.ToString(txtSearchBookingNo.Text.Trim());


                if (txtSearchRoomNo.Text.Trim() != "")
                {
                    strRoomNo = Convert.ToString(clsCommon.GetOriginalRoomNumber(txtSearchRoomNo.Text.Trim()));
                    if (strRoomNo == "")
                        strRoomNo = null;
                }

                if (ddlSearchRoomType.SelectedIndex != 0)
                    RoomTypeID = new Guid(ddlSearchRoomType.SelectedValue);

                DataSet dsReservationList = ReservationBLL.GetSwapRoomList(clsSession.PropertyID, clsSession.CompanyID, strName, strReservationNo, strRoomNo, RoomTypeID);

                if (dsReservationList.Tables.Count > 0 && dsReservationList.Tables[0].Rows.Count > 0)
                {
                    gvResevationList.DataSource = dsReservationList.Tables[0];
                    gvResevationList.DataBind();
                }
                else
                {
                    gvResevationList.DataSource = null;
                    gvResevationList.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindSearchRoomType()
        {
            string strRoomTypeQuery = "select RoomTypeID,RoomTypeName from mst_RoomType where PropertyID = '" + Convert.ToString(clsSession.PropertyID) + "' and IsActive = 1 order by RoomTypeName asc";

            ddlSearchRoomType.Items.Clear();

            DataSet dsRoomType = RoomTypeBLL.GetUnitType(strRoomTypeQuery);
            if (dsRoomType.Tables.Count > 0 && dsRoomType.Tables[0].Rows.Count > 0)
            {
                ddlSearchRoomType.DataSource = dsRoomType.Tables[0];
                ddlSearchRoomType.DataTextField = "RoomTypeName";
                ddlSearchRoomType.DataValueField = "RoomTypeID";
                ddlSearchRoomType.DataBind();

                ddlSearchRoomType.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
            }
            else
            {
                ddlSearchRoomType.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
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
            dr3["NameColumn"] = "Extend Stay";
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void CalculateRoomRate()
        {
            string strRoomRate = "select IsNUll(sum(RoomRate),0.000000) - IsNUll(sum(ReRouteCharge),0.000000) 'RoomRate' from res_BlockDateRate where ReservationID = '" + Convert.ToString(this.ReservationID) + "'";
            DataSet dsRate = RoomBLL.GetUnitNo(strRoomRate);

            decimal dcmlOldRoomRate = Convert.ToDecimal("0.000000");
            if (dsRate.Tables.Count > 0 && dsRate.Tables[0].Rows.Count > 0)
            {
                dcmlOldRoomRate = Convert.ToDecimal(dsRate.Tables[0].Rows[0]["RoomRate"]);
            }

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


            if (lnkBilltoCompanySettlement.Visible == false)
            {
                if (lstBlockDateRate_Insert.Count > 0)
                {
                    gvRoomRate.DataSource = lstBlockDateRate_Insert;
                    gvRoomRate.DataBind();
                }
                else
                {
                    gvRoomRate.DataSource = null;
                    gvRoomRate.DataBind();
                }
            }

            ///// Find Over stay amount if Over stay happened with this reservation Start
            ///// If folio balance is in minus, that means over stay happen but this logic may be change if POS is implemented and one folio for both PMS and POS

            Decimal dcmlFolioBalance = Convert.ToDecimal("0.000000");
            SQT.Symphony.BusinessLogic.FrontDesk.DTO.Folio flo = FolioBLL.GetByPrimaryKey(this.FolioID);
            if (flo != null && flo.CurrentBalace != null && Convert.ToString(flo.CurrentBalace) != string.Empty)
            {
                dcmlFolioBalance = Convert.ToDecimal(flo.CurrentBalace);
            }

            //// if folio balance is less than 0 that means guest have some amount and over stay is not happed. so dont consider this amount at the time of extend reservation.
            if (dcmlFolioBalance < 0)
            {
                dcmlFolioBalance = 0;
            }

            ////////// Find Over stay amount if Over stay happen with this reservation End

            //Add Over stay Panelty Charges in Over stay amount
            if (ltrOverStayInfraCharges.Text.Trim() != string.Empty)
            {
                dcmlFolioBalance = dcmlFolioBalance + Convert.ToDecimal(ltrOverStayInfraCharges.Text.Trim());
            }

            if (ltrOverStayFoodCharges.Text.Trim() != string.Empty)
            {
                dcmlFolioBalance = dcmlFolioBalance + Convert.ToDecimal(ltrOverStayFoodCharges.Text.Trim());
            }

            if (ltrOverStayElectricityCharges.Text.Trim() != string.Empty)
            {
                dcmlFolioBalance = dcmlFolioBalance + Convert.ToDecimal(ltrOverStayElectricityCharges.Text.Trim());
            }

            decimal dcmlTotlRate = dcmlOldRoomRate + dcmlNewRoundOffTotal + dcmlFolioBalance;
            decimal dcmlTotlRateToDisplay = Convert.ToDecimal("0.000000");

            //// litOldRate made visible false b'cas not to display it to frontdesk person, it's only code purpose use, so dont delete it
            litOldRate.Text = dcmlOldRoomRate.ToString().Substring(0, dcmlOldRoomRate.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

            //// Get Infra. Service Charges
            decimal dcmlInfraCharges = Convert.ToDecimal("0.000000");
            decimal dcmlFoodCharges = Convert.ToDecimal("0.000000");
            decimal dcmlElectricityCharges = Convert.ToDecimal("0.000000");
            for (int i = 0; i < lstBlockDateRate_Insert.Count; i++)
            {
                dcmlInfraCharges += Convert.ToDecimal(lstBlockDateRate_Insert[i].InfraServiceCharge);
                dcmlFoodCharges += Convert.ToDecimal(lstBlockDateRate_Insert[i].FoodCharge);
                dcmlElectricityCharges += Convert.ToDecimal(lstBlockDateRate_Insert[i].ElectricityCharge);
            }

            dcmlInfraCharges = Math.Round(dcmlInfraCharges);
            dcmlFoodCharges = Math.Round(dcmlFoodCharges);
            dcmlElectricityCharges = Math.Round(dcmlElectricityCharges);
            this.ExtendStayInfraServiceChargeAmount = (int)(dcmlInfraCharges);
            this.ExtendStayFoodChargeAmount = (int)(dcmlFoodCharges);
            this.ExtendStayElectricityChargeAmount = (int)(dcmlElectricityCharges);

            dcmlNewRoundOffTotal = dcmlNewRoundOffTotal + dcmlInfraCharges + dcmlFoodCharges + dcmlElectricityCharges;
            dcmlTotlRateToDisplay = dcmlNewRoundOffTotal + dcmlFolioBalance;

            ltrRoomRentPlusInfraCharges.Text = "INR Rs. " + Convert.ToString(dcmlNewRoundOffTotal) + " = " + Convert.ToString(dcmlNewRoundOffTotal - dcmlInfraCharges - dcmlFoodCharges - dcmlElectricityCharges) + " (Room Rent) + " + Convert.ToString(dcmlInfraCharges) + " (Infra. Service Charges) + " + Convert.ToString(dcmlFoodCharges) + " (Food Charges) + " + Convert.ToString(dcmlElectricityCharges) + " (Electricity and Water Charges)";

            litNewRate.Text = dcmlNewRoundOffTotal.ToString() + ".00";

            if (dcmlFolioBalance > 0)
            {
                litNewRate.Text = litNewRate.Text + " + " + dcmlFolioBalance.ToString().Substring(0, dcmlFolioBalance.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                litNewRate.Text = litNewRate.Text + " (Overstay Amount)";
                litNewRate.Text = litNewRate.Text + " = " + dcmlTotlRateToDisplay.ToString().Substring(0, dcmlTotlRateToDisplay.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
            }

            //// litTotalRate made visible false b'cas not to display it to frontdesk person, it's only code purpose use, so dont delete it
            litTotalRate.Text = dcmlTotlRate.ToString().Substring(0, dcmlTotlRate.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

            if (Convert.ToString(litNewRate.Text) != string.Empty)
            {
                this.AmountSuggestedToPay = dcmlTotlRateToDisplay;
                txtPaymentAmount.Text = Convert.ToString(dcmlTotlRateToDisplay); //dcmlTotlRateToDisplay.ToString().Substring(0, dcmlTotlRateToDisplay.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
            }

            trCalculation.Visible = true;
        }

        private void ClearFormData()
        {
            litOldRate.Text = litNewRate.Text = litTotalRate.Text = "0.00";
            txtNight.Text = txtNewDepartureDate.Text = txtAmount.Text = txtPaymentAmount.Text = "";
            Session["lstExtendReservationBlockDateRate"] = Session["lstExtendReservationResService"] = null;
            this.New_CheckOutDate = DateTime.Now;
            this.StandardCheckOutTime = string.Empty;
            this.RateID = this.ReservationID = this.RoomID = this.RoomTypeID = Guid.Empty;
            hdnIsCalculateRate.Value = "NO";
            trCalculation.Visible = false;
            this.RestStatus_TermID = 0;
            btnSave.Visible = btnCalculateRate.Visible = trSavePaymentButton.Visible = false;
            hdnBillingInstMode.Value = "";
            this.IsToShowPaidByComp = false;
        }

        private void ClearListData()
        {
            txtSearchBookingNo.Text = txtSearchGuestName.Text = txtSearchRoomNo.Text = "";
            ddlSearchRoomType.SelectedIndex = 0;
        }
        private void ExtandReservationVoucherPrint()
        {
            if (this.ReservationID != Guid.Empty)
            {
                hdnResID.Value = Convert.ToString(this.ReservationID);
                DataSet dsVoucherData = ReservationBLL.GetCheckInVoucherData(this.ReservationID, clsSession.PropertyID, clsSession.CompanyID);
                if (dsVoucherData.Tables.Count > 0 && dsVoucherData.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsVoucherData.Tables[0].Rows[0];

                    litChVchrGuestName.Text = Convert.ToString(dr["GuestFullName"]);
                    ltrChVchrReservationNo.Text = Convert.ToString(dr["ReservationNo"]);
                    litChVchrMobileNo.Text = Convert.ToString(clsCommon.GetMobileNo(Convert.ToString(dr["Phone1"])));
                    litChVchrEmail.Text = Convert.ToString(dr["Email"]);
                    ltrChVchrFolioNo.Text = Convert.ToString(dr["FolioNo"]);
                    ltrChVchrRateCard.Text = Convert.ToString(dr["RateCardName"]);
                    ltrChVchrRoomType.Text = Convert.ToString(dr["RoomTypeName"]);
                    ltrChVchrRoomNo.Text = clsCommon.GetFormatedRoomNumber(Convert.ToString(dr["RoomNo"]));
                    ltrChVchrAdultChild.Text = Convert.ToString(dr["Adults"]) + "/" + Convert.ToString(dr["Children"]);

                    DateTime dtCheckInDate = Convert.ToDateTime(Convert.ToString(dr["CheckInDate"]));
                    DateTime dtCheckOutDate = Convert.ToDateTime(Convert.ToString(dr["CheckOutDate"]));

                    ltrChVchrCheckInDate.Text = Convert.ToString(dtCheckInDate.ToString(clsSession.DateFormat));
                    ltrChVchrCheckOutDate.Text = Convert.ToString(lblDisplayDepartureDate.Text);

                    if (txtNewDepartureDate.Text != null && txtNewDepartureDate.Text != "")
                    {
                        litchvNewCheckOutDate.Text = txtNewDepartureDate.Text;

                    }
                    else
                    {
                        litchvNewCheckOutDate.Text = "";
                    }

                    litChvNoOfExtendedDays.Text = Convert.ToString(txtNight.Text);

                    Session["ExtandVoucherDataToPrint"] = litChvNoOfExtendedDays.Text + "|" + lblDisplayDepartureDate.Text;
                    //int day = 0;//bool b1 = false;//bool b2 = false;
                    //clsCommon.Reservation_GetTotalDays(null, dtCheckInDate, dtCheckOutDate, ref day, ref b1, ref b2);
                    //litReservationVoucherNoofNights.Text = Convert.ToString(day);

                    if (dsVoucherData.Tables.Count > 1 && dsVoucherData.Tables[1].Rows.Count > 0)
                        lblChVchrHousingRules.Text = Convert.ToString(dsVoucherData.Tables[1].Rows[0]["HousingRules"]);
                    else
                        lblChVchrHousingRules.Text = "";

                    //Reservation Payment Calculaltion
                    decimal RoomRent = Convert.ToDecimal("0.000000");
                    decimal Tax = Convert.ToDecimal("0.000000");
                    decimal TotalAmount = Convert.ToDecimal("0.000000");
                    int NoofDays = 0;
                    decimal DepositAmount = Convert.ToDecimal("0.000000");
                    decimal PaidDeposit = Convert.ToDecimal("0.000000");
                    int InfraServiceCharge = 0;
                    int PaidInfraServiceCharge = 0;
                    int FoodCharges = 0;
                    int PaidFoodCharges = 0;
                    int ElectricityCharges = 0;
                    int PaidElectricityCharges = 0;
                    decimal TotalAmountPayable = Convert.ToDecimal("0.000000");
                    decimal AmountToPayCheckInTime = Convert.ToDecimal("0.000000");
                    decimal TotalPaymentReceived = Convert.ToDecimal("0.000000");
                    decimal NetAmountToPay = Convert.ToDecimal("0.000000");
                    DataTable dtPaidAmountInfo = null;

                    //Common function to get payment related all details.
                    clsCommon.GetReservationPaymentInfo(this.ReservationID, ref RoomRent, ref Tax, ref TotalAmount, ref NoofDays, ref DepositAmount, ref PaidDeposit, ref TotalPaymentReceived, ref dtPaidAmountInfo, ref InfraServiceCharge, ref PaidInfraServiceCharge, ref FoodCharges, ref PaidFoodCharges, ref ElectricityCharges, ref PaidElectricityCharges);

                    string strRoomRent, strTax, strTotalAmount, strDepositAmount = "";

                    strRoomRent = RoomRent.ToString().Substring(0, RoomRent.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    strTax = Tax.ToString().Substring(0, Tax.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    strTotalAmount = TotalAmount.ToString().Substring(0, TotalAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    strDepositAmount = DepositAmount.ToString().Substring(0, DepositAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    ltrChVchrNoOfDays.Text = Convert.ToString(NoofDays);
                    ltrChVchrRoomRent.Text = Convert.ToString(strRoomRent);
                    ltrChVchrTaxes.Text = Convert.ToString(strTax);
                    lblInfraServiceCharges.Text = Convert.ToString(InfraServiceCharge) + ".00";

                    //Reservation time total charges(Room Rent)
                    ltrChVchrTotalCharges.Text = Convert.ToString(strTotalAmount);
                    //Reservation time total Deposit
                    ltrChVchrDeposit.Text = Convert.ToString(strDepositAmount);

                    //Reservation time total Amount payable(Room Rent + Deposit)
                    TotalAmountPayable = TotalAmount + DepositAmount;
                    ltrChVchrTotalAmount.Text = TotalAmountPayable.ToString().Substring(0, TotalAmountPayable.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    // Total Paid Amount 
                    decimal PaidAmountTotal = RoomRent + PaidDeposit + PaidInfraServiceCharge;


                    //Total Deposit received
                    //ltrChVchrPaidAmount.Text = PaidDeposit.ToString().Substring(0, PaidDeposit.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    ltrChVchrPaidAmount.Text = PaidAmountTotal.ToString().Substring(0, PaidAmountTotal.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    if (TotalAmountPayable >= PaidAmountTotal)
                    {
                        NetAmountToPay = TotalAmountPayable - PaidAmountTotal;
                        ltrChVchrAmountToPay.Text = NetAmountToPay.ToString().Substring(0, NetAmountToPay.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                }
                else
                {
                    //litReservationVoucherGuestName.Text = litReservationVoucherBookingNo.Text = litReservationVoucherMobileNo.Text = litReservationVoucherEmail.Text = litReservationVoucherCheckinDate.Text = litReservationVoucherCheckoutDate.Text = litReservationVoucherNoofNights.Text = litReservationVoucherNoofGuests.Text = litReservationVoucherRateCard.Text = litReservationVoucherRoomType.Text = litReservationVoucherBookingStatus.Text = litReservationVoucherValidUpto.Text = "";
                    //litDisplayReservationVoucherCheckInTime.Text = litDisplayReservationVoucherCheckOutTime.Text = "";
                    //lblDisplayCancellationPolicy.Text = "";
                }
            }

            mpeExtandResVoucher.Show();
        }
        private void BindPaymentDetails()
        {
            decimal RoomRent = Convert.ToDecimal("0.000000");
            decimal Tax = Convert.ToDecimal("0.000000");
            decimal TotalAmount = Convert.ToDecimal("0.000000");
            int NoofDays = 0;
            decimal DepositAmount = Convert.ToDecimal("0.000000");
            decimal PaidDeposit = Convert.ToDecimal("0.000000");
            int InfraServiceCharge = 0;
            int PaidInfraServiceCharge = 0;
            int FoodCharges = 0;
            int PaidFoodCharges = 0;
            int ElectricityCharges = 0;
            int PaidElectricityCharges = 0;
            decimal TotalAmountPayable = Convert.ToDecimal("0.000000");
            decimal AmountToPayCheckInTime = Convert.ToDecimal("0.000000");
            decimal TotalPaymentReceived = Convert.ToDecimal("0.000000");
            decimal NetAmountToPay = Convert.ToDecimal("0.000000");
            DataTable dtPaidAmountInfo = null;

            //Common function to get payment related all details.
            clsCommon.GetReservationPaymentInfo(this.ReservationID, ref RoomRent, ref Tax, ref TotalAmount, ref NoofDays, ref DepositAmount, ref PaidDeposit, ref TotalPaymentReceived, ref dtPaidAmountInfo, ref InfraServiceCharge, ref PaidInfraServiceCharge, ref FoodCharges, ref PaidFoodCharges, ref ElectricityCharges, ref PaidElectricityCharges);

            string strRoomRent, strTax, strTotalAmount, strDepositAmount = "";

            strRoomRent = RoomRent.ToString().Substring(0, RoomRent.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
            strTax = Tax.ToString().Substring(0, Tax.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
            strTotalAmount = TotalAmount.ToString().Substring(0, TotalAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
            strDepositAmount = DepositAmount.ToString().Substring(0, DepositAmount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
            this.ResDepositAmount = DepositAmount;
            this.PaidDepositAmount = PaidDeposit;
            this.ResInfraServiceChargeAmount = InfraServiceCharge;
            this.PaidInfraServiceChargeAmount = PaidInfraServiceCharge;
            this.ResFoodChargeAmount = FoodCharges;
            this.PaidFoodChargeAmount = PaidFoodCharges;
            this.ElectricityChargeAmount = ElectricityCharges;
            this.PaidElectricityChargeAmount = PaidElectricityCharges;
            /*
            lblDisplayNoOfDaysPmtTab.Text = lblDisplayNoOfDays.Text = Convert.ToString(NoofDays);
            lblResTimeRoomRentPmtTab.Text = lblResTimeRoomRent.Text = Convert.ToString(strRoomRent);
            lblResTimeTaxPmtTab.Text = lblResTimeTax.Text = Convert.ToString(strTax);

            //Reservation time total charges(Room Rent)
            lblResTimeTotalChargesPmtTab.Text = lblResTimeTotalCharges.Text = Convert.ToString(strTotalAmount);
            //Reservation time total Deposit
            lblResTimeDepositAmountPmtTab.Text = lblResTimeDepositAmount.Text = Convert.ToString(strDepositAmount);

            //Reservation time total Amount payable(Room Rent + Deposit)
            TotalAmountPayable = TotalAmount + DepositAmount;
            lblResTimeTotalPayableAmountPmtTab.Text = lblResTimeTotalPayableAmount.Text = TotalAmountPayable.ToString().Substring(0, TotalAmountPayable.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

            //Total Deposit received
            lblResTimePaidAmountPmtTab.Text = PaidDeposit.ToString().Substring(0, PaidDeposit.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

            if (TotalAmountPayable >= PaidDeposit)
            {
                NetAmountToPay = TotalAmountPayable - PaidDeposit;
                lblResTimeAmountToPayPmtTab.Text = NetAmountToPay.ToString().Substring(0, NetAmountToPay.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
            }

            //Total payment received (Deposit + other payment)
            lblTotalPaymentReceived.Text = TotalPaymentReceived.ToString().Substring(0, TotalPaymentReceived.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

            //Compare total payable amount and Total received amount for Net amount is Balance or Due.
            if (TotalAmountPayable >= TotalPaymentReceived)
            {
                NetAmountToPay = TotalAmountPayable - TotalPaymentReceived;
                lblAmountBalanceOrDueText.Text = "Balance Amount (Due)";
                txtPaymentAmount.Text = lblAmountBalanceOrDue.Text = NetAmountToPay.ToString().Substring(0, NetAmountToPay.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                this.AmountSuggestedToPay = Convert.ToDecimal(txtPaymentAmount.Text);

                if (Request["Mode"] != null && Convert.ToString(Request["Mode"]).ToUpper() == "DEPOSIT")
                {
                    Decimal dcmlNetDepositToPay = DepositAmount - TotalPaymentReceived;
                    if (dcmlNetDepositToPay >= 0)
                        txtPaymentAmount.Text = dcmlNetDepositToPay.ToString().Substring(0, dcmlNetDepositToPay.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    else
                        txtPaymentAmount.Text = "0";

                    this.AmountSuggestedToPay = Convert.ToDecimal(txtPaymentAmount.Text);
                }
            }
            else
            {
                NetAmountToPay = TotalPaymentReceived - TotalAmountPayable;
                lblAmountBalanceOrDueText.Text = "Balance Amount";
                lblAmountBalanceOrDue.Text = NetAmountToPay.ToString().Substring(0, NetAmountToPay.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
            }

            btnPrintReceipt.Visible = true;
            if (dtPaidAmountInfo != null && dtPaidAmountInfo.Rows.Count > 0)
            {
                gvPaymentList.DataSource = dtPaidAmountInfo;
                gvPaymentList.DataBind();
            }
            else
            {
                btnPrintReceipt.Visible = false;
                gvPaymentList.DataSource = null;
                gvPaymentList.DataBind();
            }

            if (Request["Mode"] != null && Convert.ToString(Request["Mode"]).ToUpper() == "PAYMENT")
            {
                if ((Convert.ToDecimal(lblTotalPaymentReceived.Text.Trim()) + (Convert.ToDecimal(hdnAmtPayByCmp.Value)) >= Convert.ToDecimal(lblResTimeTotalPayableAmount.Text.Trim())))
                {
                    ////If reservation already checked in, then don't make btnCheckInReservatin button visible.
                    if (this.ReservationStatusValue == 32)
                    {
                        btnCheckInReservatin.Visible = false;
                        btnBackToListFromPmtView.Visible = true;
                    }
                    else
                    {
                        btnCheckInReservatin.Visible = true;
                        btnBackToListFromPmtView.Visible = false;
                    }
                }
                else
                    btnCheckInReservatin.Visible = false;
            }
            else
                ltrMinAmtForConfirmReservation.Text = "Min. amount for confirm reservation: <b>" + strDepositAmount + "</b>";

              */

            //if (Convert.ToDecimal(hdnAmtPayByCmp.Value) > 0)
            //{
            //    if (txtPaymentAmount.Text.Trim() == string.Empty)
            //        txtPaymentAmount.Text = "0";

            //    lblAmountBalanceOrDueText.Text = "Balance Amount (Bill to Company)";
            //    decimal dcmlTemp = Convert.ToDecimal(txtPaymentAmount.Text) - Convert.ToDecimal(hdnAmtPayByCmp.Value);
            //    txtPaymentAmount.Text = dcmlTemp.ToString().Substring(0, dcmlTemp.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
            //}

            //if (Request["Mode"] != null && Convert.ToString(Request["Mode"]).ToUpper() == "PAYMENT" && this.ReservationStatusValue == 32)
            //{
            //    txtPaymentAmount.Text = "0";
            //    this.AmountSuggestedToPay = Convert.ToDecimal(txtPaymentAmount.Text);
            //}
        }

        public void GoForNightsClick()
        {
            try
            {
                btnCheckAvailibility.Visible = true;
                btnCalculateRate.Visible = lnkBilltoCompanySettlement.Visible = false;
                txtNewDepartureDate.Text = GetCheckOutDate(lblDisplayDepartureDate.Text, "DAILY", txtNight.Text.Trim()); ;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void GoForAmountClick()
        {
            try
            {
                btnCalculateRate.Visible = lnkBilltoCompanySettlement.Visible = false;
                btnCheckAvailibility.Visible = true;
                Decimal dcmlAmount = Convert.ToDecimal("0.000000");
                int NoOfOverStayDays = Convert.ToString(ltrOverStayNights.Text) == "" ? 0 : Convert.ToInt32(ltrOverStayNights.Text);
                int NoOfDays2ExtendAsPerAmount = 0;

                if (txtAmount.Text.Trim() != string.Empty)
                {
                    dcmlAmount = Convert.ToDecimal(txtAmount.Text);
                }

                if (this.RoomRatePerDay > 0)
                {
                    NoOfDays2ExtendAsPerAmount = Convert.ToInt32(Math.Round((dcmlAmount / this.RoomRatePerDay), 0));
                }

                if (NoOfOverStayDays > 0)
                {
                    if (NoOfOverStayDays >= NoOfDays2ExtendAsPerAmount)
                    {
                        btnCheckAvailibility.Visible = false;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Amount is less than Over stay amount, please pay more than over stay amount to extend.");
                    }
                    else
                    {
                        NoOfDays2ExtendAsPerAmount = NoOfDays2ExtendAsPerAmount - NoOfOverStayDays;
                    }
                }

                txtNewDepartureDate.Text = GetCheckOutDate(lblDisplayDepartureDate.Text, "DAILY", NoOfDays2ExtendAsPerAmount.ToString()); ;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public string GetCheckOutDate(string strCheckInDate, string strFrequency, string strAdd)
        {
            string strReturnDate = string.Empty;

            if (Convert.ToString(strCheckInDate) != "" && Convert.ToString(strFrequency) != "" && Convert.ToString(strAdd) != "")
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                int add = Convert.ToInt32(strAdd);

                string strdateformat = "dd-MM-yyyy";
                if (clsSession.DateFormat != string.Empty)
                    strdateformat = Convert.ToString(clsSession.DateFormat);

                DateTime dtCheckInDate = DateTime.ParseExact(Convert.ToString(strCheckInDate), strdateformat, objCultureInfo);

                if (Convert.ToString(strFrequency) == "DAILY")
                {
                    dtCheckInDate = dtCheckInDate.AddDays(add);
                }
                else if (Convert.ToString(strFrequency) == "WEEKLY")
                {
                    dtCheckInDate = dtCheckInDate.AddDays(7 * add);
                }
                else if (Convert.ToString(strFrequency) == "MONTHLY")
                {
                    dtCheckInDate = dtCheckInDate.AddMonths(add);
                }

                strReturnDate = Convert.ToString(dtCheckInDate.ToString(clsSession.DateFormat));
            }
            return strReturnDate;
        }

        private string BindPropertyAddress()
        {
            DataSet dsPropertyAddress = PropertyBLL.GetPropertyAddressInfo(clsSession.PropertyID, clsSession.CompanyID);
            if (dsPropertyAddress != null && dsPropertyAddress.Tables.Count > 0 && dsPropertyAddress.Tables[0].Rows.Count > 0)
            {
                return Convert.ToString(dsPropertyAddress.Tables[0].Rows[0]["FullAddress"]);
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion

        #region Grid Event

        protected void gvResevationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblGvListPhone = (Label)e.Row.FindControl("lblGvListPhone");
                    string strPhoneNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Phone1"));
                    lblGvListPhone.Text = Convert.ToString(clsCommon.GetMobileNo(strPhoneNo));

                    Label lblGvListRoomNo = (Label)e.Row.FindControl("lblGvListRoomNo");
                    string strRoomNo = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RoomNo"));
                    lblGvListRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(strRoomNo));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvResevationList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToUpper().Equals("EXTENDSTAY"))
                {

                    // Complementory Reservation is not allowed to extand
                    SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservation = ReservationBLL.GetByPrimaryKey(new Guid(Convert.ToString(e.CommandArgument)));
                    RateCard objRateCardToCheck = new RateCard();
                    objRateCardToCheck = RateCardBLL.GetByPrimaryKey((Guid)objReservation.RateID);

                    if ((objReservation != null && objReservation.IsComplimentoryReservation == true) || (objRateCardToCheck.IsPerRoom == true))
                    {
                        string strMessageToShow = "";
                        if (objRateCardToCheck.IsPerRoom == true)
                        {
                            strMessageToShow = "This reservation is full room reservation ,You can not extand";
                        }
                        else
                        {
                            strMessageToShow = "This reservation is Complementory Reservation so ,You can not extand";
                        }
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show(strMessageToShow);
                        return;
                    }
                    mvExtendStay.ActiveViewIndex = 1;

                    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                    Label lblGvListReservationNo = (Label)row.FindControl("lblGvListReservationNo");
                    Label lblGvListRoomTypeName = (Label)row.FindControl("lblGvListRoomTypeName");
                    Label lblGvListRoomNo = (Label)row.FindControl("lblGvListRoomNo");
                    Label lblGvListName = (Label)row.FindControl("lblGvListName");
                    Label lblGvListCheckInDate = (Label)row.FindControl("lblGvListCheckInDate");
                    Label lblGvListCheckOutDate = (Label)row.FindControl("lblGvListCheckOutDate");
                    Label lblGvListRateCardName = (Label)row.FindControl("lblGvListRateCardName");

                    litDspReservationNo.Text = Convert.ToString(lblGvListReservationNo.Text.Trim());
                    litDspName.Text = Convert.ToString(lblGvListName.Text.Trim());
                    lblDisplayArrivalDate.Text = Convert.ToString(lblGvListCheckInDate.Text.Trim());
                    lblDisplayDepartureDate.Text = Convert.ToString(lblGvListCheckOutDate.Text.Trim());
                    litDspRoomType.Text = Convert.ToString(lblGvListRoomTypeName.Text.Trim());
                    litDspRoomNo.Text = Convert.ToString(lblGvListRoomNo.Text.Trim());
                    litDspAdultChild.Text = Convert.ToString(gvResevationList.DataKeys[row.RowIndex]["Adults"]) + " - " + Convert.ToString(gvResevationList.DataKeys[row.RowIndex]["Children"]);
                    litDspRateCard.Text = Convert.ToString(lblGvListRateCardName.Text.Trim());

                    string strDiscount = Convert.ToString(gvResevationList.DataKeys[row.RowIndex]["DiscountID"]);

                    if (strDiscount != null && strDiscount != "")
                        litDspDiscount.Text = "YES";
                    else
                        litDspDiscount.Text = "NO";

                    ClearFormData();

                    this.GuestID = new Guid(objReservation.GuestID.ToString());
                    this.RoomTypeID = new Guid(gvResevationList.DataKeys[row.RowIndex]["RoomTypeID"].ToString());
                    this.ReservationID = new Guid(Convert.ToString(e.CommandArgument));
                    hdnResID.Value = Convert.ToString(this.ReservationID);
                    this.RoomID = new Guid(gvResevationList.DataKeys[row.RowIndex]["RoomID"].ToString());
                    this.RateID = new Guid(gvResevationList.DataKeys[row.RowIndex]["RateID"].ToString());
                    this.FolioID = new Guid(gvResevationList.DataKeys[row.RowIndex]["FolioID"].ToString());
                    this.New_CheckOutDate = Convert.ToDateTime(gvResevationList.DataKeys[row.RowIndex]["CheckOutDate"].ToString());
                    this.RestStatus_TermID = Convert.ToInt32(gvResevationList.DataKeys[row.RowIndex]["RestStatus_TermID"].ToString());

                    gvRoomRate.DataSource = null;
                    gvRoomRate.DataBind();
                    lblMakePaymentNotification.Text = "";
                    lnkBilltoCompanySettlement.Visible = false;
                    IsToShowPaidByComp = false;

                    DataSet dsOverStayDays = ReservationBLL.GetTotalNumOfOverstayDays(this.ReservationID);
                    if (dsOverStayDays != null && dsOverStayDays.Tables[0].Rows.Count > 0)
                        ltrOverStayNights.Text = Convert.ToString(dsOverStayDays.Tables[0].Rows[0]["NoOfOverstayDays"]);
                    else
                        ltrOverStayNights.Text = "0";

                    if (dsOverStayDays != null && dsOverStayDays.Tables[1].Rows.Count > 0)
                        this.RoomRatePerDay = Convert.ToDecimal(dsOverStayDays.Tables[1].Rows[0]["RoomRentPerDay"]);
                    else
                        this.RoomRatePerDay = Convert.ToDecimal("0.000000");

                    if (dsOverStayDays != null && dsOverStayDays.Tables[2].Rows.Count > 0)
                        ltrLatePaymentCharges.Text = Convert.ToString(dsOverStayDays.Tables[2].Rows[0]["LatePaymentCharge"]);
                    else
                        ltrLatePaymentCharges.Text = "0";

                    if (dsOverStayDays != null && dsOverStayDays.Tables[3].Rows.Count > 0)
                        ltrOverStayInfraCharges.Text = Convert.ToString(dsOverStayDays.Tables[3].Rows[0]["InfraServiceCharge"]);
                    else
                        ltrOverStayInfraCharges.Text = "0";

                    if (dsOverStayDays != null && dsOverStayDays.Tables[4].Rows.Count > 0)
                        ltrOverStayFoodCharges.Text = Convert.ToString(dsOverStayDays.Tables[4].Rows[0]["FoodCharge"]);
                    else
                        ltrOverStayFoodCharges.Text = "0";

                    if (dsOverStayDays != null && dsOverStayDays.Tables[5].Rows.Count > 0)
                        ltrOverStayElectricityCharges.Text = Convert.ToString(dsOverStayDays.Tables[5].Rows[0]["ElectricityCharge"]);
                    else
                        ltrOverStayElectricityCharges.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void gvResevationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvResevationList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvRoomRate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    decimal dcmlRMRate = Convert.ToDecimal("0.00000");
                    decimal dcmlTax = Convert.ToDecimal("0.00000");
                    decimal dcmlDiscount = Convert.ToDecimal("0.00000");
                    decimal dcmlTotal = Convert.ToDecimal("0.00000");

                    decimal dcmTotalPaidByGuest = Convert.ToDecimal("0.00000");

                    Label lblGvRMTypeRMRate = (Label)e.Row.FindControl("lblGvRMTypeRMRate");
                    ////dcmlRMRate = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "RoomRate"));
                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RateCardRate")) != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RateCardRate")) != "")
                    {
                        string strRMRate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RateCardRate")).Trim().IndexOf('.') > -1 ? Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RateCardRate")).Trim() + "000000" : Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RateCardRate")).Trim() + ".000000";
                        dcmlRMRate = Convert.ToDecimal(strRMRate);
                        lblGvRMTypeRMRate.Text = dcmlRMRate.ToString().Substring(0, dcmlRMRate.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                    else
                        lblGvRMTypeRMRate.Text = "0.00";

                    Label lblGvRMTypeTax = (Label)e.Row.FindControl("lblGvRMTypeTax");
                    ////dcmlTax = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AppliedTax"));
                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AppliedTax")) != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AppliedTax")) != "")
                    {
                        string strTax = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AppliedTax")).Trim().IndexOf('.') > -1 ? Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AppliedTax")).Trim() + "000000" : Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AppliedTax")).Trim() + ".000000";
                        dcmlTax = Convert.ToDecimal(strTax);
                        lblGvRMTypeTax.Text = dcmlTax.ToString().Substring(0, dcmlTax.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                    else
                        lblGvRMTypeTax.Text = "0.00";

                    Label lblGvRMTypeDiscount = (Label)e.Row.FindControl("lblGvRMTypeDiscount");
                    ////dcmlDiscount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DiscountAmt"));

                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DiscountAmt")) != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DiscountAmt")) != "")
                    {
                        string strDiscountAmt = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DiscountAmt")).Trim().IndexOf('.') > -1 ? Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DiscountAmt")).Trim() + "000000" : Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DiscountAmt")).Trim() + ".000000";
                        dcmlDiscount = Convert.ToDecimal(strDiscountAmt);
                        lblGvRMTypeDiscount.Text = dcmlDiscount.ToString().Substring(0, dcmlDiscount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    }
                    else
                        lblGvRMTypeDiscount.Text = "0.00";

                    ////if (Convert.ToString(dcmlDiscount) != "" && dcmlDiscount != null && dcmlDiscount > 0)
                    ////    lblGvRMTypeDiscount.Text = dcmlDiscount.ToString().Substring(0, dcmlDiscount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    ////else
                    ////    lblGvRMTypeDiscount.Text = "0.00";

                    Label lblGvRMTypeTotal = (Label)e.Row.FindControl("lblGvRMTypeTotal");
                    dcmlTotal = dcmlRMRate + dcmlTax + dcmlDiscount;
                    lblGvRMTypeTotal.Text = dcmlTotal.ToString().Substring(0, dcmlTotal.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    if (this.IsToShowPaidByComp)
                    {
                        if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PaidByCompany")) != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PaidByCompany")) != "")
                        {
                            Label lblGvTypePaidByCompany = (Label)e.Row.FindControl("lblGvRMTypePaidByCompany");
                            lblGvTypePaidByCompany.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PaidByCompany"));
                        }

                        if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PaidByGuest")) != null && Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PaidByGuest")) != "")
                        {
                            Label lblGvTypePaidByGuest = (Label)e.Row.FindControl("lblGvRMTypePaidByGuest");
                            lblGvTypePaidByGuest.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PaidByGuest"));
                            dcmTotalPaidByGuest = Convert.ToDecimal(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PaidByGuest")));
                        }
                    }

                    if (hdnBillingInstMode.Value != null && Convert.ToString(hdnBillingInstMode.Value) != "")
                    {
                        dcFtTotal += dcmTotalPaidByGuest;
                    }
                    else
                    {
                        dcFtTotal += dcmlTotal;
                    }
                }

                if (this.IsToShowPaidByComp)
                {
                    gvRoomRate.Columns[6].Visible = true;
                    gvRoomRate.Columns[7].Visible = true;
                }
                else
                {
                    gvRoomRate.Columns[6].Visible = false;
                    gvRoomRate.Columns[7].Visible = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion Grid Event

        #region Control events

        protected void ddlModeOfPayment_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlModeOfPayment.SelectedIndex != 0)
            {
                ddlLedgerAccount.Items.Clear();

                DataSet dstLedgerAccounts = AccountBLL.GetPaymentAcctsByMOPTermID(new Guid(ddlModeOfPayment.SelectedValue), clsSession.PropertyID, clsSession.CompanyID);
                if (dstLedgerAccounts != null && dstLedgerAccounts.Tables[0].Rows.Count > 0)
                {
                    ddlLedgerAccount.DataSource = dstLedgerAccounts.Tables[0];
                    ddlLedgerAccount.DataTextField = "AcctName";
                    ddlLedgerAccount.DataValueField = "AcctID";
                    ddlLedgerAccount.DataBind();
                }

                trLedgerAccount.Visible = true;
            }
            else
            {
                ddlLedgerAccount.Items.Clear();
                trLedgerAccount.Visible = false;
            }


            rfvCreditCardType.Enabled = rfvNameOnCreditCard.Enabled = rfvCreditCardNumber.Enabled = rfvCVVNumber.Enabled = rfvCardExpirationMonth.Enabled = rfvCardExpirationYear.Enabled = false;
            trChequeDD1.Visible = trChequeDD2.Visible = trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = false;
            if (ddlModeOfPayment.SelectedIndex != 0)
            {
                ProjectTerm objProjectTerm = ProjectTermBLL.GetByPrimaryKey(new Guid(ddlModeOfPayment.SelectedValue));

                if (objProjectTerm.Term.Trim().ToUpper() == "CHEQUE" || objProjectTerm.Term.Trim().ToUpper() == "DEMAND DRAFT")
                {
                    trChequeDD1.Visible = trChequeDD2.Visible = trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = false;
                    trChequeDD1.Visible = trChequeDD2.Visible = true;
                }
                else if (objProjectTerm.Term.Trim().ToUpper() == "CREDIT CARD")
                {
                    trChequeDD1.Visible = trChequeDD2.Visible = trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = false;
                    trCreditCard1.Visible = trCreditCard2.Visible = trCreditCard3.Visible = trCVVNo.Visible = trCreditCard4.Visible = true;

                    ////Bind Credit Card Type Start
                    string strSelect = clsCommon.GetUpperCaseText("-Select-"); //clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");
                    ddlCreditCardType.Items.Clear();
                    List<ProjectTerm> lstSourceOfBusiness = ProjectTermBLL.SelectAllByCategory(clsSession.CompanyID, clsSession.PropertyID, "CREDITCARDTYPE");
                    if (lstSourceOfBusiness.Count != 0)
                    {
                        ddlCreditCardType.DataSource = lstSourceOfBusiness;
                        ddlCreditCardType.DataTextField = "DisplayTerm";
                        ddlCreditCardType.DataValueField = "TermID";
                        ddlCreditCardType.DataBind();
                        ddlCreditCardType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                    }
                    else
                        ddlCreditCardType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                    ////Bind Credit Card Type Start

                    ////Bind Year Start

                    ddlCardExpirationYear.Items.Clear();
                    int j = 1;
                    ddlCardExpirationYear.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
                    for (int i = DateTime.Now.Year; i < DateTime.Now.Year + 20; i++)
                    {
                        ddlCardExpirationYear.Items.Insert(j, new ListItem(i.ToString(), i.ToString()));
                        j++;
                    }
                    ////Bind Year Start

                    rfvCreditCardType.Enabled = rfvNameOnCreditCard.Enabled = rfvCreditCardNumber.Enabled = rfvCVVNumber.Enabled = rfvCardExpirationMonth.Enabled = rfvCardExpirationYear.Enabled = true;
                }
            }
        }

        protected void btnSavePayment_OnClick(object sender, EventArgs e)
        {
            try
            {
                //To give success message.111111111111111

                String strPaymentMode = string.Empty;//// It will use to save Credit Card info.
                if (this.ReservationID != Guid.Empty && ddlModeOfPayment.SelectedIndex != 0)
                {
                    if (txtPaymentAmount.Text.Trim() == string.Empty || !(Convert.ToDecimal(txtPaymentAmount.Text.Trim()) > 0))
                    {
                        MessageBox.Show("Invalid receipt amount, it must be greater than 0.");
                        return;
                    }

                    if (Convert.ToDecimal(txtPaymentAmount.Text.Trim()) > this.AmountSuggestedToPay)
                    {
                        mpeAmoutIsLargerThanSuggestedAlert.Show();
                        return;
                    }

                    ResGuestPaymentInfo objPaymentInfo = null;
                    ProjectTerm pTermPaymentInfo = ProjectTermBLL.GetByPrimaryKey(new Guid(ddlModeOfPayment.SelectedValue));
                    if (pTermPaymentInfo != null)
                    {
                        strPaymentMode = Convert.ToString(pTermPaymentInfo.Term).ToUpper();
                        if (strPaymentMode == "CREDIT CARD")
                        {
                            if (ddlCreditCardType.SelectedIndex == 0 || Convert.ToString(txtNameOnCard.Text) == string.Empty || Convert.ToString(txtCardNumber.Text) == string.Empty || Convert.ToString(txtCVVNo.Text) == string.Empty || ddlCardExpirationMonth.SelectedIndex == 0 || ddlCardExpirationYear.SelectedIndex == 0)
                            {
                                MessageBox.Show("Please enter all required fields value.");
                                return;
                            }
                            ////Check Credit Card's Expiration Date
                            bool isCreditCardValid = true;
                            if (Convert.ToInt32(ddlCardExpirationYear.SelectedValue) < DateTime.Today.Year)
                            {
                                isCreditCardValid = false;
                            }
                            else if (Convert.ToInt32(ddlCardExpirationYear.SelectedValue) == DateTime.Today.Year)
                            {
                                if (Convert.ToInt32(ddlCardExpirationMonth.SelectedValue) < DateTime.Today.Month)
                                {
                                    isCreditCardValid = false;
                                }
                            }

                            if (!isCreditCardValid)
                            {
                                MessageBox.Show("Please enter valid Expiration Date of Credit Card.");
                                return;
                            }

                            if (txtCardNumber.Text.Trim().Length < 16)
                            {
                                MessageBox.Show("Invalid card number, it must be 16 digits.");
                                return;
                            }

                            if (txtCVVNo.Text.Trim().Length < 3)
                            {
                                MessageBox.Show("Invalid CVV No., it must have atleast 3 digit.");
                                return;
                            }
                        }
                        //// if payment mode is Credit card, then check Credit Card's Expiretion date End
                    }

                    //Save Payment Start

                    if (strPaidAmt2AvoidDoubleEntry != string.Empty)
                    {
                        if (txtPaymentAmount.Text.Trim() == strPaidAmt2AvoidDoubleEntry)
                        {
                            MessageBox.Show("This is 2nd entry for same amount. Go to 'Reprint Payment' to print Payment receipt.");
                            return;
                        }
                    }

                    //Bind Guest payment info if payment is done using Creditcard
                    if (strPaymentMode == "CREDIT CARD")
                    {
                        objPaymentInfo = new ResGuestPaymentInfo();
                        objPaymentInfo.GuestID = this.GuestID;
                        objPaymentInfo.MOP_TermID = new Guid(ddlModeOfPayment.SelectedValue);
                        objPaymentInfo.CardType_TermID = new Guid(ddlCreditCardType.SelectedValue);
                        objPaymentInfo.CardNo = clsCommon.GetUpperCaseText(txtCardNumber.Text.Trim());
                        objPaymentInfo.CardHolderName = clsCommon.GetUpperCaseText(txtNameOnCard.Text.Trim());
                        objPaymentInfo.DateOfExpiry = new DateTime(Convert.ToInt32(ddlCardExpirationYear.SelectedValue), Convert.ToInt32(ddlCardExpirationMonth.SelectedValue), 1);
                        objPaymentInfo.IsCreditCardCharged = true;
                        objPaymentInfo.CVVNo = clsCommon.GetUpperCaseText(txtCVVNo.Text.Trim());
                        objPaymentInfo.PropertyID = clsSession.PropertyID;
                        objPaymentInfo.CompanyID = clsSession.CompanyID;
                        objPaymentInfo.IsActive = true;

                        ResGuestPaymentInfoBLL.Save(objPaymentInfo);
                    }

                    decimal CurrentPayingAmount = Convert.ToDecimal("0.000000");
                    CurrentPayingAmount = Convert.ToDecimal(txtPaymentAmount.Text.Trim());
                    strPaidAmt2AvoidDoubleEntry = txtPaymentAmount.Text.Trim();

                    Guid? PaymentAcctID = null;
                    Guid? CounterID = clsSession.DefaultCounterID; // new Guid("acadee48-26ec-4a92-8aae-bc2f8c4e8037"); //null;


                    string strReturnBookID = string.Empty;

                    //If paid deposit amount is not same as Reservation deposit, then save deposit first.
                    if (this.PaidDepositAmount < this.ResDepositAmount)
                    {
                        decimal RemainingDepositToPay = Convert.ToDecimal("0.000000");
                        RemainingDepositToPay = this.ResDepositAmount - this.PaidDepositAmount;
                        decimal DepositGoingToPay = Convert.ToDecimal("0.000000");

                        //if current paying amount is larger than deposit to pay, then....
                        if (CurrentPayingAmount > RemainingDepositToPay)
                        {
                            //Set deposit going to pay as all Remaining deposit and...
                            DepositGoingToPay = RemainingDepositToPay;
                            // deduct deposit going to pay amount from current paying amount.
                            CurrentPayingAmount = CurrentPayingAmount - DepositGoingToPay;
                        }
                        else// Current paying amount is less than remaining deposit,
                        {
                            // set whole current paing amount set as Deposit going to pay and
                            DepositGoingToPay = CurrentPayingAmount;
                            // set current paying amout as 0, b'cas all amount set as paying deposit and so no other payment done for this currnet paying amount
                            CurrentPayingAmount = Convert.ToDecimal("0.000000");
                        }

                        int Zone_TermID = 0;
                        Guid? DepositAcctID = clsSession.DefaultDepositAcctID;// new Guid("9693B5FE-580D-4F41-8690-4003A5D981B6"); // null;
                        Guid? ResPayID = null;

                        DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                        if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                            Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);

                        if (ddlLedgerAccount.Items.Count > 0)
                            PaymentAcctID = new Guid(ddlLedgerAccount.SelectedValue);

                        if (objPaymentInfo != null)
                            ResPayID = objPaymentInfo.ResPayID;

                        Guid tempBookID = Guid.Empty;

                        tempBookID = TransactionBLL.InsertDeposit(Zone_TermID, DepositGoingToPay, PaymentAcctID, DepositAcctID, this.ReservationID, this.FolioID, clsSession.UserID, CounterID, clsSession.PropertyID, "FRONT DESK", this.RoomID, "ROOM DEPOSIT", clsSession.CompanyID, ResPayID);

                        if (strReturnBookID == string.Empty)
                            strReturnBookID = Convert.ToString(tempBookID);
                        else
                            strReturnBookID = strReturnBookID + "," + Convert.ToString(tempBookID);
                    }

                    /*
                    //To not consider Infra. Service Charges as Infra. is removed from all rate card.
                    //Infra Service Charge to pay = Old stay's Infra charges + Newly extend stya's infra charges.
                    this.ResInfraServiceChargeAmount = this.ResInfraServiceChargeAmount + this.ExtendStayInfraServiceChargeAmount;
                    ////if current paying amount is larger than deposit to pay, then save Infra. Service Charges
                    if (CurrentPayingAmount > 0 && this.PaidInfraServiceChargeAmount < this.ResInfraServiceChargeAmount)
                    {
                        decimal RemainingInfraServiceChargeToPay = Convert.ToDecimal("0.000000");
                        RemainingInfraServiceChargeToPay = this.ResInfraServiceChargeAmount - this.PaidInfraServiceChargeAmount;
                        decimal InfraServiceChargeGoingToPay = Convert.ToDecimal("0.000000");

                        //if current paying amount is larger than deposit to pay, then....
                        if (CurrentPayingAmount > RemainingInfraServiceChargeToPay)
                        {
                            //Set deposit going to pay as all Remaining deposit and...
                            InfraServiceChargeGoingToPay = RemainingInfraServiceChargeToPay;
                            // deduct deposit going to pay amount from current paying amount.
                            CurrentPayingAmount = CurrentPayingAmount - InfraServiceChargeGoingToPay;
                        }
                        else// Current paying amount is less than remaining deposit,
                        {
                            // set whole current paing amount set as Deposit going to pay and
                            InfraServiceChargeGoingToPay = CurrentPayingAmount;
                            // set current paying amout as 0, b'cas all amount set as paying deposit and so no other payment done for this currnet paying amount
                            CurrentPayingAmount = Convert.ToDecimal("0.000000");
                        }

                        int Zone_TermID = 0;
                        Guid? InfraServiceChargeAcctID = new Guid("A24EC56C-7586-4517-8659-12D84B62541C"); // null;
                        Guid? ResPayID = null;

                        DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                        if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                            Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);

                        if (ddlLedgerAccount.Items.Count > 0)
                            PaymentAcctID = new Guid(ddlLedgerAccount.SelectedValue);

                        if (objPaymentInfo != null)
                            ResPayID = objPaymentInfo.ResPayID;

                        Guid tempBookID = Guid.Empty;

                        if (InfraServiceChargeGoingToPay > 0)
                        {
                            tempBookID = TransactionBLL.InsertDeposit(Zone_TermID, InfraServiceChargeGoingToPay, PaymentAcctID, InfraServiceChargeAcctID, this.ReservationID, this.FolioID, clsSession.UserID, CounterID, clsSession.PropertyID, "FRONT DESK", this.RoomID, "INFRA SERVICE CHARGE", clsSession.CompanyID, ResPayID);

                            if (strReturnBookID == string.Empty)
                                strReturnBookID = Convert.ToString(tempBookID);
                            else
                                strReturnBookID = strReturnBookID + "," + Convert.ToString(tempBookID);
                        }
                    }
                    */

                    //Food Charge to pay = Old stya's Food charges + Newly extend stya's Food charges.
                    this.ResFoodChargeAmount = this.ResFoodChargeAmount + this.ExtendStayFoodChargeAmount;
                    ////if current paying amount is larger than deposit to pay, then save Food Charges
                    if (CurrentPayingAmount > 0 && this.PaidFoodChargeAmount < this.ResFoodChargeAmount)
                    {
                        decimal RemainingFoodChargeToPay = Convert.ToDecimal("0.000000");
                        RemainingFoodChargeToPay = this.ResFoodChargeAmount - this.PaidFoodChargeAmount;
                        decimal FoodChargeGoingToPay = Convert.ToDecimal("0.000000");

                        //if current paying amount is larger than deposit to pay, then....
                        if (CurrentPayingAmount > RemainingFoodChargeToPay)
                        {
                            //Set deposit going to pay as all Remaining deposit and...
                            FoodChargeGoingToPay = RemainingFoodChargeToPay;
                            // deduct deposit going to pay amount from current paying amount.
                            CurrentPayingAmount = CurrentPayingAmount - FoodChargeGoingToPay;
                        }
                        else// Current paying amount is less than remaining deposit,
                        {
                            // set whole current paing amount set as Deposit going to pay and
                            FoodChargeGoingToPay = CurrentPayingAmount;
                            // set current paying amout as 0, b'cas all amount set as paying deposit and so no other payment done for this currnet paying amount
                            CurrentPayingAmount = Convert.ToDecimal("0.000000");
                        }

                        int Zone_TermID = 0;
                        Guid? FoodChargeAcctID = new Guid("9B544844-4BE7-418D-AC93-E37A0101751A"); // null;
                        Guid? ResPayID = null;

                        DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                        if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                            Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);

                        if (ddlLedgerAccount.Items.Count > 0)
                            PaymentAcctID = new Guid(ddlLedgerAccount.SelectedValue);

                        if (objPaymentInfo != null)
                            ResPayID = objPaymentInfo.ResPayID;

                        Guid tempBookID = Guid.Empty;

                        if (FoodChargeGoingToPay > 0)
                        {
                            tempBookID = TransactionBLL.InsertDeposit(Zone_TermID, FoodChargeGoingToPay, PaymentAcctID, FoodChargeAcctID, this.ReservationID, this.FolioID, clsSession.UserID, CounterID, clsSession.PropertyID, "FRONT DESK", this.RoomID, "FOOD CHARGE", clsSession.CompanyID, ResPayID);

                            if (strReturnBookID == string.Empty)
                                strReturnBookID = Convert.ToString(tempBookID);
                            else
                                strReturnBookID = strReturnBookID + "," + Convert.ToString(tempBookID);
                        }
                    }

                    //Electricity Charge to pay = Old stya's Electricity charges + Newly extend stya's Electricity charges.
                    this.ElectricityChargeAmount = this.ElectricityChargeAmount + this.ExtendStayElectricityChargeAmount;
                    ////if current paying amount is larger than deposit to pay, then save Electricity and Water Charges
                    if (CurrentPayingAmount > 0 && this.PaidElectricityChargeAmount < this.ElectricityChargeAmount)
                    {
                        decimal RemainingElectricityChargeToPay = Convert.ToDecimal("0.000000");
                        RemainingElectricityChargeToPay = this.ElectricityChargeAmount - this.PaidElectricityChargeAmount;
                        decimal ElectricityChargeGoingToPay = Convert.ToDecimal("0.000000");

                        //if current paying amount is larger than deposit to pay, then....
                        if (CurrentPayingAmount > RemainingElectricityChargeToPay)
                        {
                            //Set deposit going to pay as all Remaining deposit and...
                            ElectricityChargeGoingToPay = RemainingElectricityChargeToPay;
                            // deduct deposit going to pay amount from current paying amount.
                            CurrentPayingAmount = CurrentPayingAmount - ElectricityChargeGoingToPay;
                        }
                        else// Current paying amount is less than remaining deposit,
                        {
                            // set whole current paing amount set as Deposit going to pay and
                            ElectricityChargeGoingToPay = CurrentPayingAmount;
                            // set current paying amout as 0, b'cas all amount set as paying deposit and so no other payment done for this currnet paying amount
                            CurrentPayingAmount = Convert.ToDecimal("0.000000");
                        }

                        int Zone_TermID = 0;
                        Guid? ElectricityChargeAcctID = new Guid("6A578844-2CE7-414D-AC56-B37A0675754B"); // null;
                        Guid? ResPayID = null;

                        DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                        if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                            Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);

                        if (ddlLedgerAccount.Items.Count > 0)
                            PaymentAcctID = new Guid(ddlLedgerAccount.SelectedValue);

                        if (objPaymentInfo != null)
                            ResPayID = objPaymentInfo.ResPayID;

                        Guid tempBookID = Guid.Empty;

                        tempBookID = TransactionBLL.InsertDeposit(Zone_TermID, ElectricityChargeGoingToPay, PaymentAcctID, ElectricityChargeAcctID, this.ReservationID, this.FolioID, clsSession.UserID, CounterID, clsSession.PropertyID, "FRONT DESK", this.RoomID, "ELECTRICITY CHARGE", clsSession.CompanyID, ResPayID);

                        if (strReturnBookID == string.Empty)
                            strReturnBookID = Convert.ToString(tempBookID);
                        else
                            strReturnBookID = strReturnBookID + "," + Convert.ToString(tempBookID);
                    }

                    //If after checking or paying whole deposit, if Current payment is greater than 0, then save it as reservation Payment.
                    if (CurrentPayingAmount > 0)
                    {
                        ////If Request mode is Deposit, then save remaining amount as Deposit
                        if (Request["Mode"] != null && Convert.ToString(Request["Mode"]).ToUpper() == "DEPOSIT")
                        {
                            int Zone_TermID = 0;
                            Guid? DepositAcctID = clsSession.DefaultDepositAcctID;// new Guid("9693B5FE-580D-4F41-8690-4003A5D981B6"); // null;
                            Guid? ResPayID = null;

                            DataSet dsTransZone = ProjectTermBLL.SelectTranzactionZoneIDByTransZone("RESERVATION DEPOSIT", clsSession.CompanyID, clsSession.PropertyID);
                            if (dsTransZone != null && dsTransZone.Tables[0].Rows.Count > 0)
                                Zone_TermID = Convert.ToInt32(dsTransZone.Tables[0].Rows[0]["SymphonyValue"]);

                            if (ddlLedgerAccount.Items.Count > 0)
                                PaymentAcctID = new Guid(ddlLedgerAccount.SelectedValue);

                            if (objPaymentInfo != null)
                                ResPayID = objPaymentInfo.ResPayID;

                            Guid tempBookID = Guid.Empty;

                            tempBookID = TransactionBLL.InsertDeposit(Zone_TermID, CurrentPayingAmount, PaymentAcctID, DepositAcctID, this.ReservationID, this.FolioID, clsSession.UserID, CounterID, clsSession.PropertyID, "FRONT DESK", this.RoomID, "ROOM DEPOSIT", clsSession.CompanyID, ResPayID);

                            string str34 = strReturnBookID;
                            if (strReturnBookID == string.Empty)
                                strReturnBookID = Convert.ToString(tempBookID);
                            else
                                strReturnBookID = strReturnBookID + "," + Convert.ToString(tempBookID);
                        }
                        else//// it is in payment mode and then save remaining amount as payment.
                        {
                            Guid? ResPayID = null;

                            if (ddlLedgerAccount.Items.Count > 0)
                                PaymentAcctID = new Guid(ddlLedgerAccount.SelectedValue);

                            if (objPaymentInfo != null)
                                ResPayID = objPaymentInfo.ResPayID;

                            Guid tempID = Guid.Empty;

                            tempID = BookKeepingBLL.ReceivePayment(PaymentAcctID, CurrentPayingAmount, this.ReservationID, this.FolioID, clsSession.UserID, CounterID, clsSession.PropertyID, clsSession.CompanyID, "FRONT DESK", ResPayID, false);

                            if (strReturnBookID == string.Empty)
                                strReturnBookID = Convert.ToString(tempID);
                            else
                                strReturnBookID += "," + Convert.ToString(tempID);

                            ReservationBLL.UpdateOverStayStatusAfterPayment(this.ReservationID);
                        }
                    }
                    //Save Payment End

                    //After saving payment, update it's value.
                    if (strReturnBookID == "")
                        strReturnBookID = null;

                    //After saving payment, update it's value.
                    hdnBookingID.Value = strReturnBookID;
                    ucPaymentReceipt.BindSinglePaymentDetails(this.ReservationID, this.GuestID, litDspName.Text, txtPaymentAmount.Text.Trim(), ddlModeOfPayment.SelectedItem.Text, strReturnBookID);

                    txtGuestEmail.Text = hfOldGuestEmail.Value = Convert.ToString(ucPaymentReceipt.gstGuestEmail);

                    // Make late payment charge and over stya infra charges 0, b'cas once payment proceed, IsOverstay flag will be removed in res_Blockdaterate table
                    // and both these fields work on that flag.
                    ltrOverStayInfraCharges.Text = ltrLatePaymentCharges.Text = ltrOverStayFoodCharges.Text = ltrOverStayElectricityCharges.Text = "0";
                    txtPaymentAmount.Text = "";
                    ddlModeOfPayment.SelectedIndex = 0;
                    ddlModeOfPayment_OnSelectedIndexChanged(null, null);
                    BindPaymentDetails();

                    if (ltrOverStayNights.Text.Trim() != "" && Convert.ToInt32(ltrOverStayNights.Text.Trim()) > 0)
                    {
                        this.IsAutoCalculateBcasOverStayDays = true;
                        btnCalculateRate_Click(sender, e);
                    }

                    mpePrintReceipt.Show();
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        protected void btnEmailPaymentReceipt_OnClick(object sender, EventArgs e)
        { 
            try
            {
                if (hfOldGuestEmail.Value.ToString() != txtGuestEmail.Text.Trim())
                { 
                    GuestBLL.UpdateGuestEmail(this.GuestID,txtGuestEmail.Text.Trim());
                }

                //Get Email Template info. First table contains Email template and second table contains it's Email Configuration info.
                DataSet dsSearchEmailTemplate = EMailTemplatesBLL.GetDataByProperty(clsSession.PropertyID, clsSession.CompanyID, "Payment Receipt");
                if (dsSearchEmailTemplate != null && dsSearchEmailTemplate.Tables.Count > 0)
                {
                    string strPrimoryDomainName = string.Empty;
                    string strUserName = string.Empty;
                    string strPassword = string.Empty;
                    string strSmtpAddress = string.Empty;

                    //If second table cotains data, then use this SMTP detail.
                    if (dsSearchEmailTemplate.Tables.Count > 1 && dsSearchEmailTemplate.Tables[1].Rows.Count > 0)
                    {
                        strPrimoryDomainName = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["PrimoryDomainName"]);
                        strUserName = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["UserName"]);
                        strPassword = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["Password"]);
                        strSmtpAddress = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["SMTPHost"]);
                    }
                    else
                    {
                        // else use Property's default smtp detail.
                        PropertyConfiguration ObjPrtConfig = PropertyConfigurationBLL.GetByCmpnAndPrpt(clsSession.CompanyID, clsSession.PropertyID);
                        if (ObjPrtConfig != null)
                        {
                            strPrimoryDomainName = Convert.ToString(ObjPrtConfig.PrimoryDomainName);
                            strUserName = Convert.ToString(ObjPrtConfig.UserName);
                            strPassword = Convert.ToString(ObjPrtConfig.Password);
                            strSmtpAddress = Convert.ToString(ObjPrtConfig.SmtpAddress);
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                            MessageBox.Show("Sorry for inconvenience, system can't send mail. Please try again later.");
                            return;
                        }
                    }

                    //if smtp(either from template's Email config or from property's email config) exist, then send mail.
                    if (strPrimoryDomainName != string.Empty && strUserName != string.Empty && strPassword != string.Empty && strSmtpAddress != string.Empty)
                    {
                        if (dsSearchEmailTemplate.Tables[0] != null && dsSearchEmailTemplate.Tables[0].Rows.Count != 0)
                        {
                            string strHTML = "";
                            if (File.Exists(Server.MapPath("~/EmailTemplate/PaymentReceipt.htm")))
                            {
                                strHTML = File.ReadAllText(Server.MapPath("~/EmailTemplate/PaymentReceipt.htm"));
                                strHTML = strHTML.Replace("$PROPERTYADDRESS$", BindPropertyAddress());

                                DataSet dsPayment = BookKeepingBLL.GetPaymentForCheckInVoucher(ReservationID, clsSession.PropertyID, clsSession.CompanyID, Convert.ToString(hdnBookingID.Value));

                                decimal dcTotalAmount = Convert.ToDecimal("0.00");
                                string strFolioNo = "";
                                string strGuestName = "";

                                if (dsPayment.Tables.Count > 0 && dsPayment.Tables[0].Rows.Count > 0)
                                {
                                    strFolioNo = Convert.ToString(dsPayment.Tables[0].Rows[0]["FolioNo"]);
                                    strGuestName = Convert.ToString(dsPayment.Tables[0].Rows[0]["GuestFullName"]);

                                    if (dsPayment.Tables.Count > 1 && dsPayment.Tables[1].Rows.Count > 0)
                                    {
                                        dcTotalAmount = Convert.ToDecimal(Convert.ToString(dsPayment.Tables[1].Rows[0]["TotalAmount"]));
                                    }

                                    string strTransTRs = string.Empty;
                                    for (int i = 0; i < dsPayment.Tables[0].Rows.Count; i++)
                                    {
                                        DateTime paymentEntryDate = Convert.ToDateTime(Convert.ToString(dsPayment.Tables[0].Rows[i]["EntryDate"]));
                                        strTransTRs += "<tr><td>" + (i + 1).ToString() + "</td><td>" + Convert.ToString(dsPayment.Tables[0].Rows[i]["BookNo"]) + "</td><td>" + paymentEntryDate.ToString(clsSession.DateFormat) + " " + paymentEntryDate.ToString(clsSession.TimeFormat) + "</td><td align='right'>" + Convert.ToString(dsPayment.Tables[0].Rows[i]["Amount"]) + "</td><td>&nbsp;" + Convert.ToString(dsPayment.Tables[0].Rows[i]["MOP"]) + "</td></tr>";
                                    }

                                    strHTML = strHTML.Replace("$TRPAYMENTTRANSACTIONS$", strTransTRs);


                                    //strHTML = strHTML.Replace("$TRANSACTIONNUMBER$", Convert.ToString(dsPayment.Tables[0].Rows[0]["BookNo"]));
                                    //strHTML = strHTML.Replace("$PAYMENTDATETIME$", paymentEntryDate.ToString(clsSession.DateFormat) + " " + paymentEntryDate.ToString(clsSession.TimeFormat));
                                    //strHTML = strHTML.Replace("$AMOUNT$", Convert.ToString(dsPayment.Tables[0].Rows[0]["Amount"]));
                                    //strHTML = strHTML.Replace("$MOP$", Convert.ToString(dsPayment.Tables[0].Rows[0]["MOP"]));

                                    strHTML = strHTML.Replace("$TOTALAMOUNT$", Convert.ToString(dcTotalAmount));
                                }
                                
                                strHTML = strHTML.Replace("$GUESTNAME$", strGuestName);
                                strHTML = strHTML.Replace("$FOLIONUMBER$", strFolioNo);
                                strHTML = strHTML.Replace("$RECEIVEDBY$", Convert.ToString(clsSession.DisplayName));
                                strHTML = strHTML.Replace("$CURRENTDATE$", DateTime.Today.ToString(clsSession.DateFormat));
                                strHTML = strHTML.Replace("$CURRENTTIME$", DateTime.Now.ToString(clsSession.TimeFormat));
                            }
                            else
                            {
                                strHTML = string.Empty;
                            }

                            if (strHTML != "" && strHTML != string.Empty)
                            {
                                SentMail.SendMail(strPrimoryDomainName, strUserName, strPassword, strSmtpAddress, txtGuestEmail.Text, "Payment Receipt from Uniworld", strHTML);
                                //SentMail.SendMail(strPrimoryDomainName, "frontdesk.uniworld@gmail.com", "lenovo@123", strSmtpAddress, txtGuestEmail.Text, "Payment Receipt from Uniworld", strHTML);
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                                MessageBox.Show("Sorry for inconvenience, system can't send mail. Please try again later.");
                                return;
                            }
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                            MessageBox.Show("Sorry for inconvenience, system can't send mail. Please try again later.");
                            return;
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Sorry for inconvenience, system can't send mail. Please try again later.");
                        return;

                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        protected void btnEmailExtendVoucher_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (litChVchrEmail.Text == string.Empty)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show("This guest has no email id, you can't send Extend Reservation Voucher in Email.");
                    mpeExtandResVoucher.Show();
                    return;
                }

                //Get Email Template info. First table contains Email template and second table contains it's Email Configuration info.
                DataSet dsSearchEmailTemplate = EMailTemplatesBLL.GetDataByProperty(clsSession.PropertyID, clsSession.CompanyID, "Payment Receipt");
                if (dsSearchEmailTemplate != null && dsSearchEmailTemplate.Tables.Count > 0)
                {
                    string strPrimoryDomainName = string.Empty;
                    string strUserName = string.Empty;
                    string strPassword = string.Empty;
                    string strSmtpAddress = string.Empty;

                    //If second table cotains data, then use this SMTP detail.
                    if (dsSearchEmailTemplate.Tables.Count > 1 && dsSearchEmailTemplate.Tables[1].Rows.Count > 0)
                    {
                        strPrimoryDomainName = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["PrimoryDomainName"]);
                        strUserName = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["UserName"]);
                        strPassword = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["Password"]);
                        strSmtpAddress = Convert.ToString(dsSearchEmailTemplate.Tables[1].Rows[0]["SMTPHost"]);
                    }
                    else
                    {
                        // else use Property's default smtp detail.
                        PropertyConfiguration ObjPrtConfig = PropertyConfigurationBLL.GetByCmpnAndPrpt(clsSession.CompanyID, clsSession.PropertyID);
                        if (ObjPrtConfig != null)
                        {
                            strPrimoryDomainName = Convert.ToString(ObjPrtConfig.PrimoryDomainName);
                            strUserName = Convert.ToString(ObjPrtConfig.UserName);
                            strPassword = Convert.ToString(ObjPrtConfig.Password);
                            strSmtpAddress = Convert.ToString(ObjPrtConfig.SmtpAddress);
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                            MessageBox.Show("Sorry for inconvenience, system can't send mail. Please try again later.");
                            return;
                        }
                    }

                    //if smtp(either from template's Email config or from property's email config) exist, then send mail.
                    if (strPrimoryDomainName != string.Empty && strUserName != string.Empty && strPassword != string.Empty && strSmtpAddress != string.Empty)
                    {
                        if (dsSearchEmailTemplate.Tables[0] != null && dsSearchEmailTemplate.Tables[0].Rows.Count != 0)
                        {
                            string strHTML = "";
                            if (File.Exists(Server.MapPath("~/EmailTemplate/ExtendReservationVoucher.htm")))
                            {
                                strHTML = File.ReadAllText(Server.MapPath("~/EmailTemplate/ExtendReservationVoucher.htm"));
                                strHTML = strHTML.Replace("$PROPERTYADDRESS$", BindPropertyAddress());

                                //strHTML = strHTML.Replace("$PAYMENTDATETIME$", DateTime.Today.ToString(clsSession.DateFormat) + " " + DateTime.Now.ToString(clsSession.TimeFormat));
                                strHTML = strHTML.Replace("$BOOKINGNUMBER$", Convert.ToString(ltrChVchrReservationNo.Text));
                                strHTML = strHTML.Replace("$GUESTNAME$", Convert.ToString(litChVchrGuestName.Text));
                                strHTML = strHTML.Replace("$MOBILENUMBER$", Convert.ToString(litChVchrMobileNo.Text));
                                strHTML = strHTML.Replace("$EMAIL$", Convert.ToString(litChVchrEmail.Text));
                                strHTML = strHTML.Replace("$FOLIONUMBER$", Convert.ToString(ltrChVchrFolioNo.Text));
                                strHTML = strHTML.Replace("$CHECKINDATE$", Convert.ToString(ltrChVchrCheckInDate.Text));
                                strHTML = strHTML.Replace("$CHECKOUTDATE$", Convert.ToString(ltrChVchrCheckOutDate.Text));
                                strHTML = strHTML.Replace("$NUMOFDAYSEXTENDED$", Convert.ToString(litChvNoOfExtendedDays.Text));
                                strHTML = strHTML.Replace("$NEWCHECKOUTDATE$", Convert.ToString(litchvNewCheckOutDate.Text));
                                strHTML = strHTML.Replace("$NUMOFADULTCHILD$", Convert.ToString(ltrChVchrAdultChild.Text));
                                strHTML = strHTML.Replace("$RATECARDNAME$", Convert.ToString(ltrChVchrRateCard.Text));
                                strHTML = strHTML.Replace("$ROOMTYPE$", Convert.ToString(ltrChVchrRoomType.Text));
                                strHTML = strHTML.Replace("$ROOMNUMBER$", Convert.ToString(ltrChVchrRoomNo.Text));
                            }
                            else
                            {
                                strHTML = string.Empty;
                            }

                            if (strHTML != "" && strHTML != string.Empty)
                            {
                                SentMail.SendMail(strPrimoryDomainName, strUserName, strPassword, strSmtpAddress, litChVchrEmail.Text, "Extend Reservation Voucher from Uniworld", strHTML);
                                //SentMail.SendMail(strPrimoryDomainName, "frontdesk.uniworld@gmail.com", "lenovo@123", strSmtpAddress, txtGuestEmail.Text, "Payment Receipt from Uniworld", strHTML);
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                                MessageBox.Show("Sorry for inconvenience, system can't send mail. Please try again later.");
                                return;
                            }
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                            MessageBox.Show("Sorry for inconvenience, system can't send mail. Please try again later.");
                            return;
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Sorry for inconvenience, system can't send mail. Please try again later.");
                        return;

                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        protected void btnOKAmoutIsLargerThanSuggestedAlert_OnClick(object sender, EventArgs e)
        {
            this.AmountSuggestedToPay = Convert.ToDecimal(txtPaymentAmount.Text.Trim());
            btnSavePayment_OnClick(sender, e);
        }
        #endregion

        #region Button Event

        protected void imgbtnClearListData_Click(object sender, EventArgs e)
        {
            gvResevationList.PageIndex = 0;
            ClearListData();
            BindGrid();
        }

        protected void imgbtnSearchListData_Click(object sender, EventArgs e)
        {
            gvResevationList.PageIndex = 0;
            BindGrid();
        }

        protected void btnCheckAvailibility_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    if (txtNight.Text.Trim() == "" && txtAmount.Text.Trim() == "")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Please, fill either Nights or Amount to Check Availability.");
                        return;
                    }

                    if (txtNight.Text.Trim() != "" && txtAmount.Text.Trim() != "")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("Please, fill any one field either Nights or Amount to Check Availability, not both.");
                        return;
                    }

                    if (txtNight.Text.Trim() != "")
                    {
                        GoForNightsClick();
                    }

                    if (txtAmount.Text.Trim() != "")
                    {
                        GoForAmountClick();
                    }


                    gvRoomRate.DataSource = null;
                    gvRoomRate.DataBind();
                    trCalculation.Visible = false;

                    hfIsToCheckAvailability.Value = "NO";
                    this.GuestReservationID = Guid.Empty;

                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    DateTime? dtCheckInDate = null;
                    DateTime? dtCheckoutDate = null;

                    DateTime dtToSetCheckInDate = new DateTime();
                    DateTime dtToSetCheckOutDate = new DateTime();

                    //if (txtSearchFromDate.Text.Trim() != "")
                    //    dtToSetCheckInDate = DateTime.ParseExact(txtSearchFromDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

                    dtToSetCheckInDate = this.New_CheckOutDate.Date;

                    if (txtNewDepartureDate.Text.Trim() != "")
                        dtToSetCheckOutDate = DateTime.ParseExact(txtNewDepartureDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

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

                    DataSet dsGetAllVacantRoom = ReservationBLL.GetAllVacantRoom(dtCheckInDate, dtCheckoutDate, this.RoomTypeID, false, null, clsSession.PropertyID, clsSession.CompanyID);

                    if (dsGetAllVacantRoom.Tables.Count > 0 && dsGetAllVacantRoom.Tables[0].Rows.Count > 0)
                    {
                        DataView dvData = new DataView(dsGetAllVacantRoom.Tables[0]);
                        dvData.RowFilter = "RoomID = '" + Convert.ToString(this.RoomID) + "'";

                        if (dvData.Count > 0)
                        {
                            //Available
                            btnSave.Visible = btnCalculateRate.Visible = true;
                        }
                        else
                        {
                            //Not Available                            
                            btnSave.Visible = btnCalculateRate.Visible = trSavePaymentButton.Visible = false;
                            DataSet dsExtendStayData = ReservationBLL.GetReservationsForExtendStay(dtCheckInDate, dtCheckoutDate, null, this.RoomID, null, clsSession.CompanyID, clsSession.PropertyID);
                            if (dsExtendStayData.Tables.Count > 0 && dsExtendStayData.Tables[0].Rows.Count > 0)
                            {
                                DataRow[] dr = dsExtendStayData.Tables[0].Select("ReservationID <> '" + Convert.ToString(this.ReservationID) + "'");

                                if (dr.Length > 0)
                                {
                                    this.GuestReservationID = new Guid(Convert.ToString(dr[0]["ReservationID"]));

                                    DateTime dtGuestCheckInDate = Convert.ToDateTime(dr[0]["CheckInDate"]);
                                    DateTime dtGuestCheckOutDate = Convert.ToDateTime(dr[0]["CheckOutDate"]);

                                    lblCustomePopupMsg.Text = "Current room is not available because " + Convert.ToString(dr[0]["Guest_Name"]) + " with Booking No. " + Convert.ToString(dr[0]["ReservationNo"]) + " already blocked it from " + dtGuestCheckInDate.ToString(clsSession.DateFormat) + " to " + dtGuestCheckOutDate.ToString(clsSession.DateFormat) + "";

                                    litDisplayBookingNo.Text = Convert.ToString(dr[0]["ReservationNo"]);
                                    litDisplayGuestName.Text = Convert.ToString(dr[0]["Guest_Name"]);
                                    litDisplayCheckInDate.Text = dtGuestCheckInDate.ToString(clsSession.DateFormat);
                                    litDisplayCheckOutDate.Text = dtGuestCheckOutDate.ToString(clsSession.DateFormat);
                                    litDisplayGuestRateCard.Text = Convert.ToString(dr[0]["RateCardName"]);
                                    litDisplayGuestRoomType.Text = Convert.ToString(dr[0]["RoomTypeName"]);
                                    litDisplayGuestRoomNo.Text = Convert.ToString(clsCommon.GetFormatedRoomNumber(Convert.ToString(dr[0]["Room No"])));
                                }
                            }
                            else
                            {
                                lblCustomePopupMsg.Text = "Room is not Available, you can't extend your this stay.";
                            }
                            mpeCustomePopup.Show();
                            return;
                        }
                    }
                    else
                    {
                        btnSave.Visible = btnCalculateRate.Visible = false;
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
        }

        protected void btnCalculateRate_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {

                    if (hfIsToCheckAvailability.Value.ToUpper() == "YES")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                        MessageBox.Show("No. of nights to extend is chnaged, please check availability of room before you calculate rate.");
                        return;
                    }

                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                    List<BlockDateRate> lstBlockDateRate_New = new List<BlockDateRate>();
                    List<ResServiceList> lstResServiceList = new List<ResServiceList>();
                    string strStandardCheckInTime = string.Empty;
                    string strStandardCheckOutTime = string.Empty;

                    DateTime dtnewCheckInDate = this.New_CheckOutDate.Date;
                    DateTime dtnewCheckOutDate = DateTime.ParseExact(txtNewDepartureDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);

                    lstBlockDateRate_New = clsBlockDateRate.GetCal_RoomWorksheet(dtnewCheckInDate, dtnewCheckOutDate, this.RoomTypeID, this.RateID, null, 1, 0, string.Empty, ref lstResServiceList, ref strStandardCheckInTime, ref strStandardCheckOutTime, this.ReservationID, "EDIT");

                    this.StandardCheckOutTime = strStandardCheckOutTime;

                    hdnBillingInstMode.Value = "";
                    if (lstBlockDateRate_New.Count > 0)
                    {
                        btnSave.Visible = trSavePaymentButton.Visible = true;
                        hdnIsCalculateRate.Value = "YES";
                        gvRoomRate.DataSource = lstBlockDateRate_New;
                        gvRoomRate.DataBind();
                    }
                    else
                    {
                        hdnIsCalculateRate.Value = "NO";
                        btnSave.Visible = trSavePaymentButton.Visible = false;
                        gvRoomRate.DataSource = null;
                        gvRoomRate.DataBind();
                    }

                    Session["lstExtendReservationBlockDateRate"] = lstBlockDateRate_New;
                    Session["lstExtendReservationResService"] = lstResServiceList;

                    CalculateRoomRate();

                    //
                    if (txtNight.Text.Trim() == string.Empty && gvRoomRate.Rows.Count > 0)
                    {
                        txtNight.Text = Convert.ToString(gvRoomRate.Rows.Count);
                    }

                    lblMakePaymentNotification.Text = "Room is available, please collect the payment before extending.";
                    DataSet dsForCheckBillingInstruction = ReservationBLL.GetBillingInstructionTermStatus(this.ReservationID, clsSession.CompanyID, clsSession.PropertyID, false);
                    litDisplayBillingMode.Text = "";

                    if (dsForCheckBillingInstruction != null && dsForCheckBillingInstruction.Tables.Count > 0 && dsForCheckBillingInstruction.Tables[0].Rows.Count > 0 && Convert.ToInt32(dsForCheckBillingInstruction.Tables[0].Rows[0]["NoOfRecord"]) > 0)
                    {

                        litDisplayBillingMode.Text = Convert.ToString(dsForCheckBillingInstruction.Tables[1].Rows[0]["BillingInst"]);
                        hdnBillingInstMode.Value = Convert.ToString(dsForCheckBillingInstruction.Tables[1].Rows[0]["BillingInst"]);
                        lnkBilltoCompanySettlement.Visible = true;
                    }
                    else
                    {

                        litDisplayBillingMode.Text = "";
                        hdnBillingInstMode.Value = "";
                        lnkBilltoCompanySettlement.Visible = false;
                        IsToShowPaidByComp = false;
                    }

                    BindPaymentDetails();

                    if (this.IsAutoCalculateBcasOverStayDays)
                    {
                        txtPaymentAmount.Text = string.Empty;
                        this.IsAutoCalculateBcasOverStayDays = false;
                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvExtendStay.ActiveViewIndex = 0;
            ClearFormData();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    if (hdnIsCalculateRate.Value == "" || hdnIsCalculateRate.Value == "NO")
                    {
                        MessageBox.Show("Please calculate rate of reservation.");
                        return;
                    }
                    if (lnkBilltoCompanySettlement.Visible == true && this.IsToShowPaidByComp == false)
                    {
                        MessageBox.Show("Please apply Bill to company settlement");
                        return;
                    }

                    if (this.ReservationID != Guid.Empty && this.RoomID != Guid.Empty && this.RoomTypeID != Guid.Empty && this.FolioID != Guid.Empty)
                    {
                        //// To use this commented code for payment validation before going to save extend reservatio info.
                        //////
                        ////// Once you check calculation issue Uncomment that code and it will check amount is paid or not.
                        //////


                        ////If Complementory reservation is there and it's ref. type is Investor, then give whole room to guest instead of any bed.
                        //SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservationForCheck = ReservationBLL.GetByPrimaryKey(this.ReservationID);

                        //if (objReservationForCheck.IsComplimentoryReservation == true && objReservationForCheck.RefInvestorID != null && Convert.ToString(objReservationForCheck.RefInvestorID) != string.Empty && Convert.ToString(objReservationForCheck.RefInvestorID) != Guid.Empty.ToString())
                        //{
                        //    if (!IsWholeRoomIsAvailable(objReservationForCheck.CheckInDate, objReservationForCheck.CheckOutDate, this.RoomID))
                        //    {
                        //        MessageBox.Show("This reservation is complementory reservation, You can't give partially occupied room to guest.");
                        //        return;
                        //    }
                        //}
                        decimal PaidDeposit = Convert.ToDecimal("0.000000");
                        decimal TotalPaymentReceived = Convert.ToDecimal("0.000000");
                        decimal NewTotalRoomRate = Convert.ToDecimal("0.000000");

                        ////Get Payment info.
                        DataSet dsPaymentInfo = ReservationBLL.GetReservationPaymentInfo4ExtendStay(clsSession.PropertyID, clsSession.CompanyID, this.ReservationID);

                        ////Set Paid Deposit
                        if (dsPaymentInfo != null && dsPaymentInfo.Tables.Count > 2 && dsPaymentInfo.Tables[2].Rows.Count > 0)
                            PaidDeposit = Convert.ToDecimal(Convert.ToString(dsPaymentInfo.Tables[2].Rows[0]["PaidDeposit"]));

                        ////Set paid total amount
                        if (dsPaymentInfo != null && dsPaymentInfo.Tables.Count > 3 && dsPaymentInfo.Tables[3].Rows.Count > 0)
                            TotalPaymentReceived = Convert.ToDecimal(Convert.ToString(dsPaymentInfo.Tables[3].Rows[0]["TotalPaidAmount"]));

                        ////Set new total room rent
                        if (litTotalRate.Text.Trim() != string.Empty)
                            NewTotalRoomRate = Convert.ToDecimal(litTotalRate.Text.Trim());

                        ////If new room rate is greater than total paid room rent ==> (Total paid amount - total paid deposit)
                        if (NewTotalRoomRate > (TotalPaymentReceived - PaidDeposit))
                        {
                            ////Don't allow to save extended reservation info.
                            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                            MessageBox.Show("Payment is not done for extend reservation, please make payment and try again.");
                            return;
                        }

                        ////////// To uncomment till this to checking payment amount.

                        CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

                        List<BlockDateRate> lstBlockDateRate_Insert = new List<BlockDateRate>();
                        List<ResServiceList> lstResServiceList_Insert = new List<ResServiceList>();

                        if (Session["lstExtendReservationBlockDateRate"] != null)
                        {
                            lstBlockDateRate_Insert = (List<BlockDateRate>)Session["lstExtendReservationBlockDateRate"];
                        }

                        // Set Reroute charge For Bill to company Type reservation

                        if (this.IsToShowPaidByComp == true)
                        {
                            for (int i = 0; i < gvRoomRate.Rows.Count; i++)
                            {
                                //lblGvRMTypePaidByCompany
                                Label lblGvRMTypeRMRate = (Label)gvRoomRate.Rows[i].FindControl("lblGvRMTypePaidByCompany");
                                Label lblGvBlockDate = (Label)gvRoomRate.Rows[i].FindControl("lblGvBlockDate");
                                foreach (BlockDateRate objBlockDateRate in lstBlockDateRate_Insert)
                                {
                                    if (objBlockDateRate.BlockDate == DateTime.ParseExact(lblGvBlockDate.Text, clsSession.DateFormat, objCultureInfo))
                                    {
                                        objBlockDateRate.ReRouteCharge = Convert.ToDecimal(lblGvRMTypeRMRate.Text);
                                    }
                                }
                            }
                        }


                        if (Session["lstExtendReservationResService"] != null)
                        {
                            lstResServiceList_Insert = (List<ResServiceList>)Session["lstExtendReservationResService"];
                        }

                        BlockDateRateBLL.SaveBlockDateEntry(lstBlockDateRate_Insert, lstResServiceList_Insert, this.ReservationID, this.RoomID, this.RoomTypeID, this.RestStatus_TermID, this.FolioID);

                        SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objOldReservationData = new BusinessLogic.FrontDesk.DTO.Reservation();
                        SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservation = new BusinessLogic.FrontDesk.DTO.Reservation();

                        objReservation = ReservationBLL.GetByPrimaryKey(this.ReservationID);
                        objOldReservationData = ReservationBLL.GetByPrimaryKey(this.ReservationID);

                        DateTime dtToSetStdCheckInOutTime = new DateTime();
                        DateTime dtToSetCheckInOutDate = new DateTime();
                        if (this.StandardCheckOutTime != string.Empty)
                        {
                            dtToSetCheckInOutDate = DateTime.ParseExact(txtNewDepartureDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                            dtToSetStdCheckInOutTime = Convert.ToDateTime(this.StandardCheckOutTime);
                            objReservation.CheckOutDate = new DateTime(dtToSetCheckInOutDate.Year, dtToSetCheckInOutDate.Month, Convert.ToInt32(dtToSetCheckInOutDate.Day), dtToSetStdCheckInOutTime.Hour, dtToSetStdCheckInOutTime.Minute, 0);
                        }
                        else
                        {
                            objReservation.CheckOutDate = DateTime.ParseExact(txtNewDepartureDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        }
                        // objReservation.CheckOutDate = DateTime.ParseExact(txtNewDepartureDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                        objReservation.UpdatedBy = clsSession.UserID;
                        objReservation.UpdatedOn = DateTime.Now;
                        objReservation.UpdateMode = "RESERVATION EXTAND";
                        ReservationBLL.Update(objReservation);




                        // Logic to Block Room

                        //if (objReservation.IsComplimentoryReservation == true)
                        //{
                        //    RoomBlockBLL.DeleteForOldandInsertForNewRoomBlockDetails((DateTime)objReservation.CheckInDate, (DateTime)objReservation.CheckOutDate, clsSession.UserName, (Guid)clsSession.PropertyID, (Guid)clsSession.CompanyID, DateTime.Now, null, (Guid)objReservation.RoomID, (Guid)objReservation.RoomTypeID, (Guid)objReservation.ReservationID);

                        //}

                        string strDesc = "Extend Stay for Reservation No.:- " + Convert.ToString(litDspReservationNo.Text.Trim()) + " by " + Convert.ToString(txtNight.Text.Trim()) + " days.";
                        ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Save", null, null, "res_BlockDateRate", strDesc);

                        ExtandReservationVoucherPrint();
                        IsListMessage = true;
                        //ltrListMessage.Text = "Reservation Stay Extended Successfully.";
                        //gvResevationList.PageIndex = 0;
                        //mvExtendStay.ActiveViewIndex = 0;
                        //BindGrid();
                        ClearFormData();
                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnUpdateGuestRoom_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    if (this.GuestReservationID != Guid.Empty)
                    {
                        SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation objReservation = new SQT.Symphony.BusinessLogic.FrontDesk.DTO.Reservation();
                        objReservation = ReservationBLL.GetByPrimaryKey(this.GuestReservationID);

                        if (objReservation != null)
                        {
                            objReservation.RoomID = new Guid(ddlAssignRoomNo.SelectedValue);
                            objReservation.UpdatedBy = clsSession.UserID;
                            objReservation.UpdatedOn = DateTime.Now;
                            objReservation.UpdateMode = "ROOM UPDATED";
                            ReservationHistory objToInsert = new ReservationHistory();
                            objToInsert.ReservationID = this.ReservationID;
                            objToInsert.Operation = clsCommon.GetUpperCaseText("Update");
                            objToInsert.OperationDate = DateTime.Now;
                            objToInsert.OperationBy = clsSession.UserID;
                            objToInsert.UserName = clsCommon.GetUpperCaseText(clsSession.UserName);
                            objToInsert.OldStatus_TermID = objReservation.RestStatus_TermID;
                            objToInsert.NewStatus_TermID = objReservation.RestStatus_TermID;
                            objToInsert.CompanyID = clsSession.CompanyID;
                            objToInsert.PropertyID = clsSession.PropertyID;
                            objToInsert.OldRecord = objReservation.ToString();

                            ReservationBLL.UpdateReservationWithBlockDateRateAndHistory(objReservation, objToInsert, this.GuestReservationID);
                            ActionLogBLL.SaveFrontdeskActionLog(clsSession.UserID, "Update", objReservation.ToString(), objReservation.ToString(), "res_Reservation", null);

                            litDisplayGuestRoomNo.Text = Convert.ToString(ddlAssignRoomNo.SelectedItem.Text);

                            IsReservationMsg = true;
                            lblMessage.Text = "Room Update Successfully.";

                            ListItem itemToRemove = ddlAssignRoomNo.Items.FindByValue(Convert.ToString(ddlAssignRoomNo.SelectedValue));
                            if (itemToRemove != null)
                            {
                                ddlAssignRoomNo.Items.Remove(itemToRemove);
                            }

                            if (ddlAssignRoomNo.Items.Count > 0)
                                ddlAssignRoomNo.SelectedIndex = 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnOKCustomeMsgPopup_Click(object sender, EventArgs e)
        {
            mpeCustomePopup.Hide();
            LoadRoomNumber();
        }

        protected void btnBackChangeRoom_Click(object sender, EventArgs e)
        {
            mvExtendStay.ActiveViewIndex = 1;
        }

        private void LoadRoomNumber()
        {
            DateTime? checkInDate = null;
            DateTime? checkOutDate = null;

            CultureInfo objCultureInfo = CultureInfo.CurrentCulture;

            string dtStandardCheckInTime = "";
            string dtStandardCheckOutTime = "";

            List<ReservationConfig> lstReservation = null;
            ReservationConfig objReservationConfig = new ReservationConfig();
            objReservationConfig.IsActive = true;
            objReservationConfig.CompanyID = clsSession.CompanyID;
            objReservationConfig.PropertyID = clsSession.PropertyID;
            lstReservation = ReservationConfigBLL.GetAll(objReservationConfig);


            if (lstReservation.Count != 0)
            {
                dtStandardCheckInTime = Convert.ToString(lstReservation[0].CheckInTime);
                dtStandardCheckOutTime = Convert.ToString(lstReservation[0].CheckOutTime);
            }

            if (litDisplayCheckInDate.Text.Trim() != string.Empty)
            {
                if (dtStandardCheckInTime != string.Empty)
                {
                    DateTime checkInDateTemp = DateTime.ParseExact(litDisplayCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                    DateTime dtToSetStdCheckInOutTime = Convert.ToDateTime(dtStandardCheckInTime);
                    checkInDate = new DateTime(checkInDateTemp.Year, checkInDateTemp.Month, Convert.ToInt32(checkInDateTemp.Day), dtToSetStdCheckInOutTime.Hour, dtToSetStdCheckInOutTime.Minute, 0);
                }
                else
                    checkInDate = DateTime.ParseExact(litDisplayCheckInDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
            }

            if (litDisplayCheckOutDate.Text.Trim() != string.Empty)
            {
                if (dtStandardCheckOutTime != string.Empty)
                {
                    DateTime CheckOutDateTemp = DateTime.ParseExact(litDisplayCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
                    DateTime dtToSetStdCheckInOutTime = Convert.ToDateTime(dtStandardCheckOutTime);
                    checkOutDate = new DateTime(CheckOutDateTemp.Year, CheckOutDateTemp.Month, Convert.ToInt32(CheckOutDateTemp.Day), dtToSetStdCheckInOutTime.Hour, dtToSetStdCheckInOutTime.Minute, 0);
                }
                else
                    checkOutDate = DateTime.ParseExact(litDisplayCheckOutDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);
            }

            DataSet dsAvailableRooms = ReservationBLL.GetAllVacantRoom(checkInDate, checkOutDate, this.RoomTypeID, false, null, clsSession.PropertyID, clsSession.CompanyID);

            ////Check whether Room Is Available or not Start
            // Get room to sell.
            DataSet dsRoomsToSell = ReservationBLL.ReservationSelectRoomsToSell(this.RoomTypeID, checkInDate, checkOutDate, null, null, clsSession.PropertyID, clsSession.CompanyID);
            DataView rs = new DataView(dsRoomsToSell.Tables[0]);
            rs.RowFilter = "RestStatus_TermID = 28 and RoomID is null";
            int intAvailableRooms = 0;

            if (dsAvailableRooms != null && dsAvailableRooms.Tables.Count > 0)
            {
                intAvailableRooms = dsAvailableRooms.Tables[0].Rows.Count - rs.Count;
            }

            if (!(intAvailableRooms > 0))
            {
                MessageBox.Show("Room is not available, you can't give confirm reservation.");
                return;
            }
            ////Check whether Room Is Available or not End

            ddlAssignRoomNo.Items.Clear();
            if (dsAvailableRooms != null && dsAvailableRooms.Tables[0].Rows.Count > 0)
            {
                ddlAssignRoomNo.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));
                DataTable dtAvblRooms = dsAvailableRooms.Tables[0];
                for (int i = 0; i < dtAvblRooms.Rows.Count; i++)
                {
                    ddlAssignRoomNo.Items.Insert(i + 1, new ListItem(clsCommon.GetFormatedRoomNumber(Convert.ToString(dtAvblRooms.Rows[i]["RoomNo"])), Convert.ToString(dtAvblRooms.Rows[i]["RoomID"])));
                }
            }
            else
                ddlAssignRoomNo.Items.Insert(0, new ListItem(clsCommon.GetUpperCaseText("-Select-"), Guid.Empty.ToString()));

            mvExtendStay.ActiveViewIndex = 2;
        }
        protected void btnApply_Click(object sender, EventArgs e)
        {
            if (this.ReservationID != Guid.Empty)
            {
                if (ddlDiscountType.SelectedIndex == 0)
                {
                    if (Convert.ToDecimal(txtCompnayWillBare.Text.Trim()) > 100)
                    {
                        lblDiscountErrorMsg.Text = "% should be less than or equal to 100.";
                        mpeBillToCompany.Show();
                        return;
                    }
                }

                if (ddlDiscountType.SelectedIndex == 1)
                {
                    for (int i = 0; i < gvRoomRate.Rows.Count; i++)
                    {

                        Label lblGvTotal = (Label)gvRoomRate.Rows[i].FindControl("lblGvRMTypeTotal");

                        if (Convert.ToDecimal(txtCompnayWillBare.Text.Trim()) > Convert.ToDecimal(lblGvTotal.Text.Trim()))
                        {
                            lblDiscountErrorMsg.Text = "Bill to compnay should not greater than total rate.";
                            mpeBillToCompany.Show();
                            return;
                        }
                    }
                }

                decimal dcmlPaidByCompany = Convert.ToDecimal("0.000000");
                decimal dcmlPaidByGuest = Convert.ToDecimal("0.000000");

                DataTable dtForRoomRate = new DataTable();

                DataColumn dc1 = new DataColumn("RateCardRate");
                DataColumn dc2 = new DataColumn("AppliedTax");
                DataColumn dc3 = new DataColumn("DiscountAmt");
                DataColumn dc4 = new DataColumn("BlockDate");
                DataColumn dc5 = new DataColumn("PaidByCompany");
                DataColumn dc6 = new DataColumn("PaidByGuest");


                dtForRoomRate.Columns.Add(dc1);
                dtForRoomRate.Columns.Add(dc2);
                dtForRoomRate.Columns.Add(dc3);
                dtForRoomRate.Columns.Add(dc4);
                dtForRoomRate.Columns.Add(dc5);
                dtForRoomRate.Columns.Add(dc6);


                for (int i = 0; i < gvRoomRate.Rows.Count; i++)
                {
                    DataRow dr1 = dtForRoomRate.NewRow();
                    Label lblGvRMTypeRMRate = (Label)gvRoomRate.Rows[i].FindControl("lblGvRMTypeRMRate");
                    Label lblGvRMTypeTax = (Label)gvRoomRate.Rows[i].FindControl("lblGvRMTypeTax");
                    Label lblGvRMTypeDiscount = (Label)gvRoomRate.Rows[i].FindControl("lblGvRMTypeDiscount");
                    Label lblGvRMBlockDate = (Label)gvRoomRate.Rows[i].FindControl("lblGvBlockDate");

                    dr1["RateCardRate"] = lblGvRMTypeRMRate.Text.Trim();
                    dr1["AppliedTax"] = lblGvRMTypeTax.Text.Trim();
                    dr1["DiscountAmt"] = lblGvRMTypeDiscount.Text.Trim();
                    CultureInfo objCultureInfo = CultureInfo.CurrentCulture;
                    dr1["BlockDate"] = DateTime.ParseExact(lblGvRMBlockDate.Text.Trim(), clsSession.DateFormat, objCultureInfo);


                    Label lblGvTotal = (Label)gvRoomRate.Rows[i].FindControl("lblGvRMTypeTotal");
                    Label lblGvTypePaidByCompany = (Label)gvRoomRate.Rows[i].FindControl("lblGvRMTypePaidByCompany");
                    Label lblGvTypePaidByGuest = (Label)gvRoomRate.Rows[i].FindControl("lblGvRMTypePaidByGuest");

                    if (ddlDiscountType.SelectedIndex == 0)
                    {
                        string strPaidByCompany = txtCompnayWillBare.Text.Trim().IndexOf('.') > -1 ? txtCompnayWillBare.Text.Trim() + "000000" : txtCompnayWillBare.Text.Trim() + ".000000";
                        dcmlPaidByCompany = Convert.ToDecimal(strPaidByCompany);

                        dcmlPaidByCompany = ((Convert.ToDecimal(lblGvTotal.Text.Trim()) * Convert.ToDecimal(strPaidByCompany)) / 100);
                        dcmlPaidByGuest = (Convert.ToDecimal(lblGvTotal.Text.Trim()) - dcmlPaidByCompany);
                    }
                    else
                    {
                        string strPaidByCompany = txtCompnayWillBare.Text.Trim().IndexOf('.') > -1 ? txtCompnayWillBare.Text.Trim() + "000000" : txtCompnayWillBare.Text.Trim() + ".000000";
                        dcmlPaidByCompany = Convert.ToDecimal(strPaidByCompany);
                        dcmlPaidByGuest = (Convert.ToDecimal(lblGvTotal.Text.Trim()) - dcmlPaidByCompany);
                    }
                    this.IsToShowPaidByComp = true;
                    lblGvTypePaidByCompany.Text = dcmlPaidByCompany.ToString().Substring(0, dcmlPaidByCompany.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                    lblGvTypePaidByGuest.Text = dcmlPaidByGuest.ToString().Substring(0, dcmlPaidByGuest.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                    dr1["PaidByCompany"] = lblGvTypePaidByCompany.Text.Trim();
                    dr1["PaidByGuest"] = lblGvTypePaidByGuest.Text.Trim();

                    dtForRoomRate.Rows.Add(dr1);
                }
                if (dtForRoomRate != null && dtForRoomRate.Rows.Count > 0)
                {
                    gvRoomRate.DataSource = dtForRoomRate;
                    gvRoomRate.DataBind();

                    CalculateRoomRate();
                }
            }
        }
        protected void lnkBilltoCompanySettlement_Click(object sender, EventArgs e)
        {

            lblDiscountErrorMsg.Text = "";
            txtCompnayWillBare.Text = "";
            mpeBillToCompany.Show();
        }
        #endregion Button Event
    }
}