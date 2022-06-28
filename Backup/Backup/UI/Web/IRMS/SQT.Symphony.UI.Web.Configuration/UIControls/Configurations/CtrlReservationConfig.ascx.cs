using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.BLL;
using System.Collections;

namespace SQT.Symphony.UI.Web.Configuration.UIControls.Configurations
{
    public partial class CtrlReservationConfig : System.Web.UI.UserControl
    {
        #region Property and Variables
        // property to save companyid;
        public Guid ResConfigID
        {
            get
            {
                return ViewState["ResConfigID"] != null ? new Guid(Convert.ToString(ViewState["ResConfigID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ResConfigID"] = value;
            }
        }

        public Guid ResPolicyID
        {
            get
            {
                return ViewState["ResPolicyID"] != null ? new Guid(Convert.ToString(ViewState["ResPolicyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ResPolicyID"] = value;
            }
        }

        public Guid ResCancellationPolicyID
        {
            get
            {
                return ViewState["ResCancellationPolicyID"] != null ? new Guid(Convert.ToString(ViewState["ResCancellationPolicyID"])) : Guid.Empty;
            }
            set
            {
                ViewState["ResCancellationPolicyID"] = value;
            }
        }

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

        public bool IsMessage = false;

        public bool IsInsert = false;

        public bool IsMessageForHR = false;

        public Guid FolioConfigID
        {
            get
            {
                return ViewState["FolioConfigID"] != null ? new Guid(Convert.ToString(ViewState["FolioConfigID"])) : Guid.Empty;
            }
            set
            {
                ViewState["FolioConfigID"] = value;
            }
        }
        #endregion Property and Variables

        #region Form Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (clsSession.CompanyID == Guid.Empty || clsSession.PropertyID == Guid.Empty)
                    Response.Redirect("~/GUI/AccessDenied.aspx?returnurl=" + Request.RawUrl.ToString());

                CheckUserAuthorization();

                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                LoadDefaultValue();
            }
        }
        #endregion Form Load

        #region Private Methods

        private void LoadDefaultValue()
        {
            try
            {
                BindBreadCrumb();
                SetPageLabels();
                LoadReservationType();
                ////BindChargesOn();
                ////BindCPReservationType();
                LoadData();
                GetData();
                GetReservationPolicyData();
                BindTermsAndConditionData();
                ////BindCancellationPolicyGrid();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void SetPageLabels()
        {
            litTabReservationConfiguration.Text = "Basic Settings"; //clsCommon.GetGlobalResourceText("ReservationConfig", "lblTabReservationConfiguration", "Basic Settings");
            litTabResPolicy.Text = "Advance Settings"; //clsCommon.GetGlobalResourceText("ReservationConfig", "lblTabResPolicy", "Advance Settings");
            litTabReservationPolicy.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblTabReservationPolicy", "Reservation Policy");
            //////litTabResCancellationPolicy.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblTabResCancellationPolicy", "Cancellation Policy");
            litTabHousingRules.Text = "Property Rules"; //clsCommon.GetGlobalResourceText("ReservationConfig", "lblTabHousingRules", "Housing Rules");
            litUnconfirmedResRmdDays.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblUnconfirmedResRmdDays", "Unconfirmed Reservation Remind");
            litRoomReservationCnfmDays.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblRoomReservationCnfmDays", "Room Reservation Confirm ");
            litConferenceReservationCnfmDays.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblConferenceReservationCnfmDays", "Conference Reservation Confirm ");
            litGroupReservationCnfmDays.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblGroupReservationCnfmDays", "Group Reservation Confirm ");
            litCheckInStlMins.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblCheckInStlMins", "CheckIn Settlement Mins");
            litCheckOutStlMins.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblCheckOutStlMins", "CheckOut Settlement Mins");
            litHighWeekDays.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblHighWeekDays", "High Week Days");
            litCheckInTime.Text = "Standard Check In Time"; // clsCommon.GetGlobalResourceText("ReservationConfig", "lblCheckInTime", "Check In Time");
            litCheckOutTime.Text = "Standard Check Out Time"; // clsCommon.GetGlobalResourceText("ReservationConfig", "lblCheckOutTime", "Check Out Time");
            litChildAgeLimit.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblChildAgeLimit", "Child Age Limit");
            litInFantAgeLimit.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblInFantAgeLimit", "InFant Age Limit");
            litGeneralTravelAgntCmsn.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblGeneralTravelAgntCmsn", "General Travel Agent Comission") + " (" + Convert.ToString(clsSession.CurrentCurrency) + ")";
            litGeneralCorporateDisc.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblGeneralCorporateDisc", "General Corporate Discount") + " (" + Convert.ToString(clsSession.CurrentCurrency) + ")";
            litProvisionRsrvnDayLmt.Text = "Validity for Provisional Reservation(Days)"; ////clsCommon.GetGlobalResourceText("ReservationConfig", "lblProvisionRsrvnDayLmt", "Provision Reservation Day Limit");
            litDefualtHoldType.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblDefualtHoldType", "Defualt Hold Type");
            chkIsShowDepositAlertCheckIn.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "chkIsShowDepositAlertCheckIn", "Show Deposit Alert On CheckIn");
            chkIsShowDirtyRoomAlertCheckIn.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "chkIsShowDirtyRoomAlertCheckIn", "Show Dirty Room Alert On CheckIn");
            chkIsAutoPostFirstNightChargeCheckIn.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "chkIsAutoPostFirstNightChargeCheckIn", "Auto Post First Night Charge at CheckIn");
            chkGuestEmailCompulsory.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "chkGuestEmailCompulsory", "Guest Email Compulsory");
            chkGuestIdentifyCompulsory.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "chkGuestIdentifyCompulsory", "Guest Identify Compulsory");
            chkRateInclusiveService.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "chkRateInclusiveService", "Rate Inclusive Service");
            chkEnblAutoAsgnRoom.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "chkEnblAutoAsgnRoom", "Enable Auto Assign Rooms");
            chkIs24HrsChckIn.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "chkIs24HrsChckIn", "24 Hours Check In");
            chkCardInfmRequired.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "chkCardInfmRequired", "Card Information Required");
            chkWarnOnOverBooking.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "chkWarnOnOverBooking", "Warn On Overbooking");
            chkShowDenomination.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "chkShowDenomination", "Show Dinomination");
            chkApplyYield.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "chkApplyYield", "Apply Yield");
            chkYieldFlat.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "chkYieldFlat", "Yield Flat");
            rgvGeneralTravelAgentCMS.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationConfig", "rgvGeneralTravelAgentCMS", "General Travel Agent Comission not more than 100%");
            rgvCorporateDiscount.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationConfig", "rgvGeneralTravelAgentCMS", "Corporate Discount not more than 100%");
            chkMon.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblCheckinMonday", "MON");
            chkTue.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblCheckinTuesday", "TUE");
            chkWed.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblCheckinWednesday", "WED");
            chkThr.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblCheckinThursday", "THR");
            chkFri.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblCheckinFriday", "FRI");
            chkSat.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblCheckinSaturday", "SAT");
            chkSun.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblCheckinSunday", "SUN");


            refBeforeCharge.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            refBeforeCharge.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            regAfterCharge.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            regAfterCharge.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            regGeneralCorporateDisc.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            regGeneralCorporateDisc.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            regGeneralTravelAgentCmsn.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            regGeneralTravelAgentCmsn.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            litMainHeader.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "litMainHeader", "Reservation");
            litBeforeCheckInHR.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "litBeforeCheckInHR", "Early Check In (Hour)");
            litBeforeCharge.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "litBeforeCharge", "Early Check In Charge") + " (" + Convert.ToString(clsSession.CurrentCurrency) + ")";
            //chkBeforeChargeInPercentate.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "chkBeforeChargeInPercentate");
            litAfterCheckInHR.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "litAfterCheckInHR", "Late Check Out (Hour)");
            litAfterCharge.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "litAfterCharge", "Late Check Out Charge") + " (" + Convert.ToString(clsSession.CurrentCurrency) + ")";
            //chkAfterChargeInPercentate.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "chkAfterChargeInPercentate");
            //litReservationType.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "litReservationType","Reservation Type");
            ChkIsReasonRequired.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "ChkIsReasonRequired", "Require Reason");
            ChkIsFirstNightChargeCompForCashPayers.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "ChkIsFirstNightChargeCompForCashPayers", "First Night Charge For Cash Payers");
            ChkIsAssignRoomToUnConfirmRes.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "ChkIsAssignRoomToUnConfirmRes", "Assign Room To Unconfirmed Res.");
            ChkIsAssignRoomOnReservation.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "ChkIsAssignRoomOnReservation", "Assign Room On Reservation");
            ChkIsUserCanOverrideRackRate.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "ChkIsUserCanOverrideRackRate", "User Can Override Rack Rate");
            btnSave.Text = btnTermsConditionSave.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnSave", "Save");
            //btnCancel.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");

            ChkIsUserCanApplyDiscount.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "ChkIsUserCanApplyDiscount", "User Can Apply Discount");
            ChkIsUserCanSetTaxExempt.Text = clsCommon.GetGlobalResourceText("ReservationPolicy", "ChkIsUserCanSetTaxExempt", "User Can Set Tax Exempt");

            rbgBeforeCharge.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationPolicy", "rbgBeforeCharge", "Early Check In Charge not more than 100%");
            rgvAfterCharge.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationPolicy", "rgvAfterCharge", "Late Check In Charge not more than 100%");

            ////litCPResType.Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblReservationType", "Reservation Type");
            ////litCPMinHrs.Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblMinimumHours", "Min. Hours");
            ////litCPMaxHrs.Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblMaximumHours", "Max. Hours");
            ////litCPCancellationCharges.Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationCharges", "Cancellation Charges");
            ////litCPChargeOn.Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblChargeOn", "Charge On");

            ////revCancellationCharges.ValidationExpression = "\\d{0,18}.\\d{0," + Convert.ToString(clsSession.DigitsAfterDecimalPoint) + "}";
            ////revCancellationCharges.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");

            ////rvCancellationCharges.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationChargesMessageInPercentage", "Cancellation Charges On Discount not more than 100%");
            ////cmpHours.ErrorMessage = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblCancellationHoursMessage", "Max. hours should be greater than or equal Min. hours");

            ////ltrConfirmDeleteMsg.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDeleteConfirmation", "Sure you want to delete?");
            ////ltrHeaderConfirmDeletePopup.Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblHeaderConfirmDeletePopup", "Cancellation Policy");
            ////litHeadingCancellationPolicyList.Text = litCancellationPolicyList.Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblancellationPolicyList", "Cancellation Policy List");

            ////btnYes.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnYes", "Yes");
            ////btnNo.Text = clsCommon.GetGlobalResourceText("Common", "lblBtnCancel", "Cancel");

            //litTermsCondition.Text = clsCommon.GetGlobalResourceText("FolioConfiguration", "lblTermsCondition", "Housing Rules");
            ////litNoOfVerificationCriteriaForAmendmentOrCancellationReservaion.Text = "Min. Verification Criteria for Cancel Reservation"; //clsCommon.GetGlobalResourceText("FolioConfiguration", "lblNoOfVerificationCriteriaforAmendmentOrCancellationReservation", "No. Of Verification Criteria for Amendment Or Cancellation Reservation");

            litMinDaysForLongstay.Text = clsCommon.GetGlobalResourceText("ReservationConfig", "lblMinDaysForLongstay", "Min. Days for Long Stay");            
            revMinDaysForLongstay.ErrorMessage = Convert.ToString(clsSession.DigitsAfterDecimalPoint) + " " + clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgDigitAfterDecimalPoint", "digits allowed after decimal point.");
        }

        private void CheckUserAuthorization()
        {
            if (clsSession.UserType.ToUpper() != "SUPERADMIN")
                this.UserRights = clsCommon.GetUserAuthorization(clsSession.UserID, "RESERVATIONCONFIG.ASPX");
            else
                this.UserRights = "1111";

            if (this.UserRights.Substring(0, 1) == "0")
                Response.Redirect("~/GUI/AccessDenied.aspx");

            btnSave.Visible = btnReservationPolicySave.Visible = this.UserRights.Substring(2, 1) == "1";
        }

        private void SaveAndUpdateResConfiguration()
        {
            try
            {
                if (this.ResConfigID != Guid.Empty)
                {
                    ReservationConfig objUpd = new ReservationConfig();
                    ReservationConfig objOldDeptData = new ReservationConfig();
                    objUpd = ReservationConfigBLL.GetByPrimaryKey(this.ResConfigID);
                    objOldDeptData = ReservationConfigBLL.GetByPrimaryKey(this.ResConfigID);

                    if (txtUnconfirmedResRmdDays.Text.Trim() != string.Empty)
                        objUpd.UnConfirmedReservationRemindBeforeDays = Convert.ToInt32(txtUnconfirmedResRmdDays.Text.Trim());
                    else
                        objUpd.UnConfirmedReservationRemindBeforeDays = null;

                    if (txtRoomReservationCnfmDays.Text.Trim() != string.Empty)
                        objUpd.RoomReservationConfirmBeforeDays = Convert.ToInt32(txtRoomReservationCnfmDays.Text.Trim());
                    else
                        objUpd.RoomReservationConfirmBeforeDays = null;

                    if (txtConferenceReservationCnfmDays.Text.Trim() != string.Empty)
                        objUpd.ConferenceReservationConfirmBeforeDays = Convert.ToInt32(txtConferenceReservationCnfmDays.Text.Trim());
                    else
                        objUpd.ConferenceReservationConfirmBeforeDays = null;

                    if (txtGroupReservationCnfmDays.Text.Trim() != string.Empty)
                        objUpd.GroupReservationConfirmBeforeDays = Convert.ToInt32(txtGroupReservationCnfmDays.Text.Trim());
                    else
                        objUpd.GroupReservationConfirmBeforeDays = null;

                    if (txtCheckInStlMins.Text.Trim() != string.Empty)
                        objUpd.CheckInSettlementMins = Convert.ToInt32(txtCheckInStlMins.Text.Trim());
                    else
                        objUpd.CheckInSettlementMins = null;

                    if (txtCheckOutStlMins.Text.Trim() != string.Empty)
                        objUpd.CheckOutSettlementMins = Convert.ToInt32(txtCheckOutStlMins.Text.Trim());
                    else
                        objUpd.CheckOutSettlementMins = null;

                    if (txtCheckInTime.Text.Trim() != string.Empty)
                        objUpd.CheckInTime = Convert.ToDateTime(txtCheckInTime.Text.Trim());
                    else
                        objUpd.CheckInTime = null;

                    if (txtCheckOutTime.Text.Trim() != string.Empty)
                        objUpd.CheckOutTime = Convert.ToDateTime(txtCheckOutTime.Text.Trim());
                    else
                        objUpd.CheckOutTime = null;

                    if (txtChildAgeLimit.Text.Trim() != string.Empty)
                        objUpd.ChildAgeLimit = Convert.ToInt32(txtChildAgeLimit.Text.Trim());
                    else
                        objUpd.ChildAgeLimit = null;

                    if (txtInFantAgeLimit.Text.Trim() != string.Empty)
                        objUpd.InfantAgeLimit = Convert.ToInt32(txtInFantAgeLimit.Text.Trim());
                    else
                        objUpd.InfantAgeLimit = null;

                    if (txtGeneralTravelAgntCmsn.Text.Trim() != string.Empty)
                        objUpd.GeneralTravelAgentComission = Convert.ToDecimal(txtGeneralTravelAgntCmsn.Text.Trim());
                    else
                        objUpd.GeneralTravelAgentComission = null;

                    if (txtGeneralCorporateDisc.Text.Trim() != string.Empty)
                        objUpd.GeneralCorporateDiscount = Convert.ToDecimal(txtGeneralCorporateDisc.Text.Trim());
                    else
                        objUpd.GeneralCorporateDiscount = null;

                    if (txtProvisionRsrvnDayLmt.Text.Trim() != string.Empty)
                        objUpd.ProvisionalReservationDayLimit = Convert.ToInt32(txtProvisionRsrvnDayLmt.Text.Trim());
                    else
                        objUpd.ProvisionalReservationDayLimit = null;

                    if (ddlGeneralCorporateDisc.SelectedIndex == 0)
                        objUpd.IsCorporateDiscountFlat = false;
                    else
                        objUpd.IsCorporateDiscountFlat = true;

                    if (ddlGeneralTravlAgntCmnd.SelectedIndex == 0)
                        objUpd.IsTravelAgentCommissionFlat = false;
                    else
                        objUpd.IsTravelAgentCommissionFlat = true;

                    if (txtMinDaysForLongstay.Text.Trim() != string.Empty)
                        objUpd.MinDaysForLongstay = Convert.ToDecimal(txtMinDaysForLongstay.Text.Trim());
                    else
                        objUpd.MinDaysForLongstay = null;

                    if (txtMaxRefundCashLimit.Text.Trim() != string.Empty)
                        objUpd.MaxCashLimitForRefund = Convert.ToDecimal(txtMaxRefundCashLimit.Text.Trim());
                    else
                        objUpd.MaxCashLimitForRefund = null;


                    objUpd.DefaultHoldType_TermID = new Guid(ddlDefualtHoldType.SelectedValue);

                    ////objUpd.CancellationPolicy = Convert.ToString(txtCancellationPolicy.Text.Trim());

                    /////if (txtNoOfVerificationCriteriaForAmendmentOrCancellationReservaion.Text.Trim() != string.Empty)
                    /////    objUpd.NoOfAmendmentCriteria = Convert.ToInt32(txtNoOfVerificationCriteriaForAmendmentOrCancellationReservaion.Text.Trim());
                    /////else
                    /////    objUpd.NoOfAmendmentCriteria = null;

                    ReservationConfigBLL.Update(objUpd);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldDeptData.ToString(), objUpd.ToString(), "res_ReservationConfig");
                    IsMessage = true;
                    litResConfMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");

                    this.ResConfigID = objUpd.ResConfigID;
                }
                else
                {
                    ReservationConfig objIns = new ReservationConfig();

                    objIns.CompanyID = clsSession.CompanyID;
                    objIns.PropertyID = clsSession.PropertyID;

                    if (txtUnconfirmedResRmdDays.Text.Trim() != string.Empty)
                        objIns.UnConfirmedReservationRemindBeforeDays = Convert.ToInt32(txtUnconfirmedResRmdDays.Text.Trim());
                    else
                        objIns.UnConfirmedReservationRemindBeforeDays = null;

                    if (txtRoomReservationCnfmDays.Text.Trim() != string.Empty)
                        objIns.RoomReservationConfirmBeforeDays = Convert.ToInt32(txtRoomReservationCnfmDays.Text.Trim());
                    else
                        objIns.RoomReservationConfirmBeforeDays = null;


                    if (txtConferenceReservationCnfmDays.Text.Trim() != string.Empty)
                        objIns.ConferenceReservationConfirmBeforeDays = Convert.ToInt32(txtConferenceReservationCnfmDays.Text.Trim());
                    else
                        objIns.ConferenceReservationConfirmBeforeDays = null;


                    if (txtGroupReservationCnfmDays.Text.Trim() != string.Empty)
                        objIns.GroupReservationConfirmBeforeDays = Convert.ToInt32(txtGroupReservationCnfmDays.Text.Trim());
                    else
                        objIns.GroupReservationConfirmBeforeDays = null;

                    if (txtCheckInStlMins.Text.Trim() != string.Empty)
                        objIns.CheckInSettlementMins = Convert.ToInt32(txtCheckInStlMins.Text.Trim());
                    else
                        objIns.CheckInSettlementMins = null;


                    if (txtCheckOutStlMins.Text.Trim() != string.Empty)
                        objIns.CheckOutSettlementMins = Convert.ToInt32(txtCheckOutStlMins.Text.Trim());
                    else
                        objIns.CheckOutSettlementMins = null;

                    if (txtCheckInTime.Text.Trim() != string.Empty)
                        objIns.CheckInTime = Convert.ToDateTime(txtCheckInTime.Text.Trim());
                    else
                        objIns.CheckInTime = null;

                    if (txtCheckOutTime.Text.Trim() != string.Empty)
                        objIns.CheckOutTime = Convert.ToDateTime(txtCheckOutTime.Text.Trim());
                    else
                        objIns.CheckOutTime = null;

                    if (txtChildAgeLimit.Text.Trim() != string.Empty)
                        objIns.ChildAgeLimit = Convert.ToInt32(txtChildAgeLimit.Text.Trim());
                    else
                        objIns.ChildAgeLimit = null;

                    if (txtInFantAgeLimit.Text.Trim() != string.Empty)
                        objIns.InfantAgeLimit = Convert.ToInt32(txtInFantAgeLimit.Text.Trim());
                    else
                        objIns.InfantAgeLimit = null;

                    if (txtGeneralTravelAgntCmsn.Text.Trim() != string.Empty)
                        objIns.GeneralTravelAgentComission = Convert.ToDecimal(txtGeneralTravelAgntCmsn.Text.Trim());
                    else
                        objIns.GeneralTravelAgentComission = null;

                    if (txtGeneralCorporateDisc.Text.Trim() != string.Empty)
                        objIns.GeneralCorporateDiscount = Convert.ToDecimal(txtGeneralCorporateDisc.Text.Trim());
                    else
                        objIns.GeneralCorporateDiscount = null;

                    if (txtProvisionRsrvnDayLmt.Text.Trim() != string.Empty)
                        objIns.ProvisionalReservationDayLimit = Convert.ToInt32(txtProvisionRsrvnDayLmt.Text.Trim());
                    else
                        objIns.ProvisionalReservationDayLimit = null;

                    objIns.DefaultHoldType_TermID = new Guid(ddlDefualtHoldType.SelectedValue);

                    if (ddlGeneralCorporateDisc.SelectedIndex == 0)
                        objIns.IsCorporateDiscountFlat = false;
                    else
                        objIns.IsCorporateDiscountFlat = true;

                    if (ddlGeneralTravlAgntCmnd.SelectedIndex == 0)
                        objIns.IsTravelAgentCommissionFlat = false;
                    else
                        objIns.IsTravelAgentCommissionFlat = true;

                    if (txtMinDaysForLongstay.Text.Trim() != string.Empty)
                        objIns.MinDaysForLongstay = Convert.ToDecimal(txtMinDaysForLongstay.Text.Trim());
                    else
                        objIns.MinDaysForLongstay = null;

                    if (txtMaxRefundCashLimit.Text.Trim() != string.Empty)
                        objIns.MaxCashLimitForRefund = Convert.ToDecimal(txtMaxRefundCashLimit.Text.Trim());
                    else
                        objIns.MaxCashLimitForRefund = null;

                    objIns.IsActive = true;
                    objIns.UpdatedOn = DateTime.Now;
                    objIns.UpdatedBy = clsSession.UserID;
                    objIns.IsSynch = false;

                    ////objIns.CancellationPolicy = Convert.ToString(txtCancellationPolicy.Text.Trim());

                    /////if (txtNoOfVerificationCriteriaForAmendmentOrCancellationReservaion.Text.Trim() != string.Empty)
                    /////    objIns.NoOfAmendmentCriteria = Convert.ToInt32(txtNoOfVerificationCriteriaForAmendmentOrCancellationReservaion.Text.Trim());
                    /////else
                    /////    objIns.NoOfAmendmentCriteria = null;

                    ReservationConfigBLL.Save(objIns);
                    ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objIns.ToString(), objIns.ToString(), "res_ReservationConfig");
                    IsMessage = true;
                    litResConfMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                    this.ResConfigID = objIns.ResConfigID;
                }

                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(1);", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "fnDisplayCatchErrorMessage();", true);
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void GetData()
        {
            List<ReservationConfig> lstReservation = null;
            ReservationConfig objReservationConfig = new ReservationConfig();
            objReservationConfig = new ReservationConfig();
            objReservationConfig.IsActive = true;
            objReservationConfig.CompanyID = clsSession.CompanyID;
            objReservationConfig.PropertyID = clsSession.PropertyID;
            lstReservation = ReservationConfigBLL.GetAll(objReservationConfig);

            if (lstReservation.Count != 0)
            {
                this.ResConfigID = lstReservation[0].ResConfigID;

                chkIsShowDepositAlertCheckIn.Checked = Convert.ToBoolean(lstReservation[0].IsShowDepositAlertOnCheckIn);
                chkIsShowDirtyRoomAlertCheckIn.Checked = Convert.ToBoolean(lstReservation[0].IsShowDirtyRoomAlertOnCheckIn);
                chkIsAutoPostFirstNightChargeCheckIn.Checked = Convert.ToBoolean(lstReservation[0].IsAutoPostFirstNightChargeAtCheckIn);
                chkGuestEmailCompulsory.Checked = Convert.ToBoolean(lstReservation[0].IsGuestEMailCompulsory);
                chkGuestIdentifyCompulsory.Checked = Convert.ToBoolean(lstReservation[0].IsGuestIdentityCompulsory);
                chkRateInclusiveService.Checked = Convert.ToBoolean(lstReservation[0].IsRateInclusiveService);
                chkEnblAutoAsgnRoom.Checked = Convert.ToBoolean(lstReservation[0].IsEnableAutoAssignRooms);
                chkIs24HrsChckIn.Checked = Convert.ToBoolean(lstReservation[0].Is24HrsCheckIn);
                chkCardInfmRequired.Checked = Convert.ToBoolean(lstReservation[0].IsCardInformationRequired);
                chkWarnOnOverBooking.Checked = Convert.ToBoolean(lstReservation[0].IsWarnOnOverBooking);
                chkShowDenomination.Checked = Convert.ToBoolean(lstReservation[0].IsShowDinomination);
                chkApplyYield.Checked = Convert.ToBoolean(lstReservation[0].IsApplyYield);
                chkYieldFlat.Checked = Convert.ToBoolean(lstReservation[0].IsYieldFlat);

                txtUnconfirmedResRmdDays.Text = Convert.ToString(lstReservation[0].UnConfirmedReservationRemindBeforeDays);
                txtRoomReservationCnfmDays.Text = Convert.ToString(lstReservation[0].RoomReservationConfirmBeforeDays);
                txtConferenceReservationCnfmDays.Text = Convert.ToString(lstReservation[0].ConferenceReservationConfirmBeforeDays);
                txtGroupReservationCnfmDays.Text = Convert.ToString(lstReservation[0].GroupReservationConfirmBeforeDays);
                txtCheckInStlMins.Text = Convert.ToString(lstReservation[0].CheckInSettlementMins);
                txtCheckOutStlMins.Text = Convert.ToString(lstReservation[0].CheckOutSettlementMins);

               //// txtCancellationPolicy.Text = Convert.ToString(lstReservation[0].CancellationPolicy);

                /////if (lstReservation[0].NoOfAmendmentCriteria != null && Convert.ToString(lstReservation[0].NoOfAmendmentCriteria) != "")
                /////    txtNoOfVerificationCriteriaForAmendmentOrCancellationReservaion.Text = Convert.ToString(lstReservation[0].NoOfAmendmentCriteria);
                /////else
                /////    txtNoOfVerificationCriteriaForAmendmentOrCancellationReservaion.Text = "";

                if (lstReservation[0].MinDaysForLongstay != null && Convert.ToString(lstReservation[0].MinDaysForLongstay) != "")
                {
                    string strMindays = Convert.ToString(lstReservation[0].MinDaysForLongstay);
                    string[] str = strMindays.Split('.');
                    if(str[0] != "")
                        txtMinDaysForLongstay.Text = Convert.ToString(str[0]);
                    else
                        txtMinDaysForLongstay.Text = Convert.ToString(lstReservation[0].MinDaysForLongstay);
                }
                else
                    txtMinDaysForLongstay.Text = "";

                if (lstReservation[0].MaxCashLimitForRefund != null && Convert.ToString(lstReservation[0].MaxCashLimitForRefund) != "")
                {
                    string strMaxLimit = Convert.ToString(lstReservation[0].MaxCashLimitForRefund);
                    string[] str = strMaxLimit.Split('.');
                    if (str[0] != "")
                        txtMaxRefundCashLimit.Text = Convert.ToString(str[0]);
                    else
                        txtMaxRefundCashLimit.Text = Convert.ToString(lstReservation[0].MaxCashLimitForRefund);
                }
                else
                    txtMaxRefundCashLimit.Text = "";

                //Old Code.
                /*
                string[] HWDAy = lstReservation[0].HighWeekDays.Split(',');

                for (int i = 0; i < HWDAy.Length; i++)
                {
                    if (HWDAy[i].Equals("SUN"))
                        chkSun.Checked = true;
                    else if (HWDAy[i].Equals("MON"))
                        chkMon.Checked = true;
                    else if (HWDAy[i].Equals("TUE"))
                        chkTue.Checked = true;
                    else if (HWDAy[i].Equals("WED"))
                        chkWed.Checked = true;
                    else if (HWDAy[i].Equals("THR"))
                        chkThr.Checked = true;
                    else if (HWDAy[i].Equals("FRI"))
                        chkFri.Checked = true;
                    else if (HWDAy[i].Equals("SAT"))
                        chkSat.Checked = true;
                }
                */

                string[] HWDAy = lstReservation[0].HighWeekDays.Split(',');
                if (lstReservation[0].HighWeekDays != null && Convert.ToString(lstReservation[0].HighWeekDays) != string.Empty)
                {
                    for (int i = 0; i < HWDAy.Length; i++)
                    {
                        if (HWDAy[i].Equals("SUN"))
                            chkSun.Checked = true;
                        else if (HWDAy[i].Equals("MON"))
                            chkMon.Checked = true;
                        else if (HWDAy[i].Equals("TUE"))
                            chkTue.Checked = true;
                        else if (HWDAy[i].Equals("WED"))
                            chkWed.Checked = true;
                        else if (HWDAy[i].Equals("THR"))
                            chkThr.Checked = true;
                        else if (HWDAy[i].Equals("FRI"))
                            chkFri.Checked = true;
                        else if (HWDAy[i].Equals("SAT"))
                            chkSat.Checked = true;
                    }
                }

                txtCheckInTime.Text = Convert.ToDateTime(lstReservation[0].CheckInTime).ToString("HH:mm");
                txtCheckOutTime.Text = Convert.ToDateTime(lstReservation[0].CheckOutTime).ToString("HH:mm");
                txtChildAgeLimit.Text = Convert.ToString(lstReservation[0].ChildAgeLimit);
                txtInFantAgeLimit.Text = Convert.ToString(lstReservation[0].InfantAgeLimit);
                ddlGeneralCorporateDisc.SelectedIndex = lstReservation[0].IsCorporateDiscountFlat == true ? 1 : 0;
                ddlGeneralTravlAgntCmnd.SelectedIndex = lstReservation[0].IsTravelAgentCommissionFlat == true ? 1 : 0;
                ddlGeneralTravlAgntCmnd_SelectedIndexChanged(null, null);
                ddlGeneralCorporateDisc_SelectedIndexChanged(null, null);
                string strGeneralTravelAgnt = Convert.ToString(lstReservation[0].GeneralTravelAgentComission);
                if (lstReservation[0].GeneralTravelAgentComission != null)
                    txtGeneralTravelAgntCmsn.Text = lstReservation[0].GeneralTravelAgentComission.ToString().Substring(0, lstReservation[0].GeneralTravelAgentComission.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                string strGeneralCorporate = Convert.ToString(lstReservation[0].GeneralCorporateDiscount);
                if (lstReservation[0].GeneralCorporateDiscount != null)
                    txtGeneralCorporateDisc.Text = lstReservation[0].GeneralCorporateDiscount.ToString().Substring(0, lstReservation[0].GeneralCorporateDiscount.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));

                txtProvisionRsrvnDayLmt.Text = Convert.ToString(lstReservation[0].ProvisionalReservationDayLimit);
                ddlDefualtHoldType.SelectedIndex = ddlDefualtHoldType.Items.FindByValue(Convert.ToString(lstReservation[0].DefaultHoldType_TermID)) != null ? ddlDefualtHoldType.Items.IndexOf(ddlDefualtHoldType.Items.FindByValue(Convert.ToString(lstReservation[0].DefaultHoldType_TermID))) : 0;
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
            dr4["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblFrontOfficeSetup", "Front Office Setup");
            dr4["Link"] = "";
            dt.Rows.Add(dr4);

            DataRow dr3 = dt.NewRow();
            dr3["NameColumn"] = clsCommon.GetGlobalResourceText("BreadCrumb", "lblReservationConfiguration", "Reservation");
            dr3["Link"] = "";
            dt.Rows.Add(dr3);

            dlBreadCrumb.RepeatColumns = dt.Rows.Count;
            dlBreadCrumb.DataSource = dt;
            dlBreadCrumb.DataBind();
        }

        private void LoadData()
        {
            List<ProjectTerm> lstProjectTerm = null;
            ProjectTerm objProjectTerm = new ProjectTerm();
            objProjectTerm.IsActive = true;
            objProjectTerm.CompanyID = clsSession.CompanyID;
            objProjectTerm.PropertyID = clsSession.PropertyID;
            objProjectTerm.Category = "RESHOLDTYPE";
            lstProjectTerm = ProjectTermBLL.GetAll(objProjectTerm);
            if (lstProjectTerm.Count != 0)
            {
                ddlDefualtHoldType.DataSource = lstProjectTerm;
                ddlDefualtHoldType.DataTextField = "DisplayTerm";
                ddlDefualtHoldType.DataValueField = "TermID";
                ddlDefualtHoldType.DataBind();
                ddlDefualtHoldType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));
            }
            else
                ddlDefualtHoldType.Items.Insert(0, new ListItem("-Select-", Guid.Empty.ToString()));


            ddlGeneralTravlAgntCmnd.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeInPercentage", "%"), "0"));
            ddlGeneralTravlAgntCmnd.Items.Insert(1, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeFlat", "Flat"), "1"));

            ddlGeneralCorporateDisc.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeInPercentage", "%"), "0"));
            ddlGeneralCorporateDisc.Items.Insert(1, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeFlat", "Flat"), "1"));
        }

        private void GetReservationPolicyData()
        {
            ReservationPolicies GetPolicyData = new ReservationPolicies();
            GetPolicyData.CompanyID = clsSession.CompanyID;
            GetPolicyData.PropertyID = clsSession.PropertyID;
            GetPolicyData.IsActive = true;
            List<ReservationPolicies> LstPolicy = ReservationPoliciesBLL.GetAll(GetPolicyData);
            if (LstPolicy.Count == 1)
            {
                this.ResPolicyID = LstPolicy[0].ResPolicyID;
                txtBeforeCheckInHR.Text = Convert.ToString(Convert.ToInt32(LstPolicy[0].BfrCheckInHrs));
                string strRate = Convert.ToString(Convert.ToDecimal(LstPolicy[0].BfrCharges));
                if (!strRate.Equals(string.Empty) && !strRate.Equals("0"))
                    txtBeforeCharge.Text = strRate.Substring(0, strRate.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                else
                    txtBeforeCharge.Text = "";

                if (Convert.ToBoolean(LstPolicy[0].IsBfrChargesInPercentage) == true)
                    ddlBeforeCharge.SelectedIndex = 0;
                else
                    ddlBeforeCharge.SelectedIndex = 1;


                string strAfter = Convert.ToString(Convert.ToDecimal(LstPolicy[0].AftCharges));
                if (!strAfter.Equals(string.Empty) && !strAfter.Equals("0"))
                    txtAfterCharge.Text = strAfter.Substring(0, strAfter.LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint));
                else
                    txtAfterCharge.Text = "";
                txtAfterCheckInHR.Text = Convert.ToString(Convert.ToInt32(LstPolicy[0].AftCheckInHrs));

                if (Convert.ToBoolean(LstPolicy[0].IsAftChargesInPercentage) == true)
                    ddlAfterCharge.SelectedIndex = 0;
                else
                    ddlAfterCharge.SelectedIndex = 1;
                //ddlReservationType.SelectedIndex = ddlReservationType.Items.FindByValue(Convert.ToString(LstPolicy[0].DefaultReservationType_TermID)) != null ? ddlReservationType.Items.IndexOf(ddlReservationType.Items.FindByValue(Convert.ToString(LstPolicy[0].DefaultReservationType_TermID))) : 0;
                ChkIsReasonRequired.Checked = Convert.ToBoolean(LstPolicy[0].IsReasonRequired);
                ChkIsFirstNightChargeCompForCashPayers.Checked = Convert.ToBoolean(LstPolicy[0].IsFirstNightChargeCompForCashPayers);
                ChkIsAssignRoomToUnConfirmRes.Checked = Convert.ToBoolean(LstPolicy[0].IsAssignRoomToUnConfirmRes);
                ChkIsAssignRoomOnReservation.Checked = Convert.ToBoolean(LstPolicy[0].IsAssignRoomOnReservation);
                ChkIsUserCanApplyDiscount.Checked = Convert.ToBoolean(LstPolicy[0].IsUserCanApplyDiscount);
                ChkIsUserCanOverrideRackRate.Checked = Convert.ToBoolean(LstPolicy[0].IsUserCanOverrideRackRate);
                ChkIsUserCanSetTaxExempt.Checked = Convert.ToBoolean(LstPolicy[0].IsUserCanSetTaxExempt);

                ddlAfterCharge_SelectedIndexChanged(null, null);
                ddlBeforeCharge_SelectedIndexChanged(null, null);
            }
        }

        private void LoadReservationType()
        {
            string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");

            //List<ProjectTerm> lstProjectTerm = null;
            //ProjectTerm objProjectTerm = new ProjectTerm();
            //objProjectTerm.IsActive = true;
            //objProjectTerm.CompanyID = clsSession.CompanyID;
            //objProjectTerm.PropertyID = clsSession.PropertyID;
            //objProjectTerm.Category = "RESERVATIONTYPE";
            //lstProjectTerm = ProjectTermBLL.GetAll(objProjectTerm);
            //if (lstProjectTerm.Count != 0)
            //{
            //    ddlReservationType.DataSource = lstProjectTerm;
            //    ddlReservationType.DataTextField = "DisplayTerm";
            //    ddlReservationType.DataValueField = "TermID";
            //    ddlReservationType.DataBind();
            //    ddlReservationType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
            //}
            //else
            //    ddlReservationType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));

            ddlBeforeCharge.Items.Clear();
            ddlBeforeCharge.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeInPercentage", "%"), "0"));
            ddlBeforeCharge.Items.Insert(1, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeFlat", "Flat"), "1"));

            ddlAfterCharge.Items.Clear();
            ddlAfterCharge.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeInPercentage", "%"), "0"));
            ddlAfterCharge.Items.Insert(1, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeFlat", "Flat"), "1"));

            //ddlCPCancellationCharges.Items.Clear();
            //ddlCPCancellationCharges.Items.Insert(0, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeInPercentage", "%"), "0"));
            //ddlCPCancellationCharges.Items.Insert(1, new ListItem(clsCommon.GetGlobalResourceText("Discount", "lblDiscountRateTypeFlat", "Flat"), "1"));

        }

        ////private void BindChargesOn()
        ////{
        ////    string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");

        ////    List<ProjectTerm> lstProjectTerm = null;
        ////    ProjectTerm objProjectTerm = new ProjectTerm();
        ////    objProjectTerm.IsActive = true;
        ////    objProjectTerm.CompanyID = clsSession.CompanyID;
        ////    objProjectTerm.PropertyID = clsSession.PropertyID;
        ////    objProjectTerm.Category = "DISCOUNTTYPE";
        ////    lstProjectTerm = ProjectTermBLL.GetAll(objProjectTerm);
        ////    if (lstProjectTerm.Count != 0)
        ////    {
        ////        ddlCPChargeOn.DataSource = lstProjectTerm;
        ////        ddlCPChargeOn.DataTextField = "DisplayTerm";
        ////        ddlCPChargeOn.DataValueField = "TermID";
        ////        ddlCPChargeOn.DataBind();
        ////        ddlCPChargeOn.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        ////    }
        ////    else
        ////        ddlCPChargeOn.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        ////}

        ////private void BindCPReservationType()
        ////{
        ////    string strSelect = clsCommon.GetGlobalResourceText("Common", "lblDDLSelect", "-Select-");

        ////    List<ProjectTerm> lstProjectTerm = null;
        ////    ProjectTerm objProjectTerm = new ProjectTerm();
        ////    objProjectTerm.IsActive = true;
        ////    objProjectTerm.CompanyID = clsSession.CompanyID;
        ////    objProjectTerm.PropertyID = clsSession.PropertyID;
        ////    objProjectTerm.Category = "RESERVATIONTYPE";
        ////    lstProjectTerm = ProjectTermBLL.GetAll(objProjectTerm);
        ////    if (lstProjectTerm.Count != 0)
        ////    {
        ////        ddlCPResType.DataSource = lstProjectTerm;
        ////        ddlCPResType.DataTextField = "DisplayTerm";
        ////        ddlCPResType.DataValueField = "TermID";
        ////        ddlCPResType.DataBind();
        ////        ddlCPResType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        ////    }
        ////    else
        ////        ddlCPResType.Items.Insert(0, new ListItem(strSelect, Guid.Empty.ToString()));
        ////}

        //private void BindCancellationPolicyData()
        //{
        //    if (this.ResCancellationPolicyID != Guid.Empty)
        //    {
        //        ResCancellationPolicy GetCancellationPolicyData = ResCancellationPolicyBLL.GetByPrimaryKey(this.ResCancellationPolicyID);

        //        if (GetCancellationPolicyData != null)
        //        {

        //            ddlCPResType.SelectedIndex = ddlCPResType.Items.FindByValue(Convert.ToString(GetCancellationPolicyData.ResType_TermID)) != null ? ddlCPResType.Items.IndexOf(ddlCPResType.Items.FindByValue(Convert.ToString(GetCancellationPolicyData.ResType_TermID))) : 0;
        //            ddlCPChargeOn.SelectedIndex = ddlCPChargeOn.Items.FindByValue(Convert.ToString(GetCancellationPolicyData.ChargesApply_TermID)) != null ? ddlCPChargeOn.Items.IndexOf(ddlCPChargeOn.Items.FindByValue(Convert.ToString(GetCancellationPolicyData.ChargesApply_TermID))) : 0;

        //            if (Convert.ToString(GetCancellationPolicyData.MinHrs) != "")
        //                txtCPMinHrs.Text = Convert.ToString(GetCancellationPolicyData.MinHrs);
        //            else
        //                txtCPMinHrs.Text = "";

        //            if (Convert.ToString(GetCancellationPolicyData.MaxHrs) != "")
        //                txtCPMaxHrs.Text = Convert.ToString(GetCancellationPolicyData.MaxHrs);
        //            else
        //                txtCPMaxHrs.Text = "";

        //            if (Convert.ToString(GetCancellationPolicyData.CancellationCharges) != "")
        //                txtCPCancellationCharges.Text = Convert.ToString(GetCancellationPolicyData.CancellationCharges.ToString().Substring(0, GetCancellationPolicyData.CancellationCharges.ToString().LastIndexOf(".") + 1 + Convert.ToInt32(clsSession.DigitsAfterDecimalPoint)));
        //            else
        //                txtCPCancellationCharges.Text = "";

        //            if (Convert.ToBoolean(GetCancellationPolicyData.IsFlatCharge) == true)
        //                ddlCPCancellationCharges.SelectedIndex = 1;
        //            else
        //                ddlCPCancellationCharges.SelectedIndex = 0;

        //            ddlCPCancellationCharges_SelectedIndexChanged(null, null);
        //        }
        //    }
        //}

        //private void ClearControl()
        //{
        //    ddlCPCancellationCharges.SelectedIndex = ddlCPResType.SelectedIndex = ddlCPChargeOn.SelectedIndex = 0;
        //    txtCPCancellationCharges.Text = txtCPMaxHrs.Text = txtCPMinHrs.Text = "";
        //    this.ResCancellationPolicyID = Guid.Empty;
        //    ddlCPCancellationCharges_SelectedIndexChanged(null, null);
        //}

        ////private void BindCancellationPolicyGrid()
        ////{
        ////    DataSet dsCancellationPolicy = ResCancellationPolicyBLL.SearchCancellationPoliycData(clsSession.CompanyID, clsSession.PropertyID, null, null);

        ////    if (dsCancellationPolicy.Tables[0] != null && dsCancellationPolicy.Tables[0].Rows.Count > 0)
        ////    {
        ////        gvReservationCancellationPolicyList.DataSource = dsCancellationPolicy.Tables[0];
        ////        gvReservationCancellationPolicyList.DataBind();
        ////    }
        ////    else
        ////    {
        ////        gvReservationCancellationPolicyList.DataSource = null;
        ////        gvReservationCancellationPolicyList.DataBind();
        ////    }
        ////}

        private void BindTermsAndConditionData()
        {
            FolioConfig FolioConf = new FolioConfig();
            FolioConf.CompanyID = clsSession.CompanyID;
            FolioConf.PropertyID = clsSession.PropertyID;
            FolioConf.IsActive = true;
            List<FolioConfig> LstConfig = FolioConfigBLL.GetAll(FolioConf);
            if (LstConfig.Count == 1)
            {
                this.FolioConfigID = LstConfig[0].FolioConfigID;
                ////txtFolioNotes.Text = Convert.ToString(LstConfig[0].FolioNotes);
                txtTermsCondition.Text = Convert.ToString(LstConfig[0].TermnCondition);
            }
        }
        #endregion

        #region Control Event
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    SaveAndUpdateResConfiguration();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        protected void btnReservationPolicySave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                try
                {
                    return;
                    
                    if (this.ResPolicyID != Guid.Empty)
                    {
                        //Update Record
                        ReservationPolicies Updt = ReservationPoliciesBLL.GetByPrimaryKey(this.ResPolicyID);
                        ReservationPolicies OldUpdt = ReservationPoliciesBLL.GetByPrimaryKey(this.ResPolicyID);

                        if (txtBeforeCheckInHR.Text.Trim().Equals(string.Empty))
                            Updt.BfrCheckInHrs = null;
                        else
                            Updt.BfrCheckInHrs = Convert.ToInt32(txtBeforeCheckInHR.Text);

                        if (txtBeforeCharge.Text.Equals(string.Empty))
                            Updt.BfrCharges = null;
                        else
                            Updt.BfrCharges = Convert.ToDecimal(txtBeforeCharge.Text.Trim());

                        if (ddlBeforeCharge.SelectedIndex == 0)
                            Updt.IsBfrChargesInPercentage = true;
                        else
                            Updt.IsBfrChargesInPercentage = false;

                        if (txtAfterCharge.Text.Equals(string.Empty))
                            Updt.AftCharges = null;
                        else
                            Updt.AftCharges = Convert.ToDecimal(txtAfterCharge.Text.Trim());

                        if (txtAfterCheckInHR.Text.Equals(string.Empty))
                            Updt.AftCheckInHrs = null;
                        else
                            Updt.AftCheckInHrs = Convert.ToInt32(txtAfterCheckInHR.Text.Trim());

                        if (ddlAfterCharge.SelectedIndex == 0)
                            Updt.IsAftChargesInPercentage = true;
                        else
                            Updt.IsAftChargesInPercentage = false;

                        //if (ddlReservationType.SelectedValue.Equals(Guid.Empty))
                        //    Updt.DefaultReservationType_TermID = null;
                        //else
                        //    Updt.DefaultReservationType_TermID = new Guid(Convert.ToString(ddlReservationType.SelectedValue));

                        Updt.IsReasonRequired = Convert.ToBoolean(ChkIsReasonRequired.Checked);
                        Updt.IsFirstNightChargeCompForCashPayers = Convert.ToBoolean(ChkIsFirstNightChargeCompForCashPayers.Checked);
                        Updt.IsAssignRoomToUnConfirmRes = Convert.ToBoolean(ChkIsAssignRoomToUnConfirmRes.Checked);
                        Updt.IsAssignRoomOnReservation = Convert.ToBoolean(ChkIsAssignRoomOnReservation.Checked);
                        Updt.IsUserCanApplyDiscount = Convert.ToBoolean(ChkIsUserCanApplyDiscount.Checked);
                        Updt.IsUserCanOverrideRackRate = Convert.ToBoolean(ChkIsUserCanOverrideRackRate.Checked);
                        Updt.IsUserCanSetTaxExempt = Convert.ToBoolean(ChkIsUserCanSetTaxExempt.Checked);
                        Updt.IsActive = true;

                        ReservationConfig objUpdateOldReservationConfig = ReservationConfigBLL.GetByPrimaryKey(this.ResConfigID);
                        ReservationConfig objUpdateReservationConfig = ReservationConfigBLL.GetByPrimaryKey(this.ResConfigID);

                        ArrayList HighWeekDay = new ArrayList();

                        if (chkMon.Checked == true)
                            HighWeekDay.Add("MON");
                        if (chkTue.Checked == true)
                            HighWeekDay.Add("TUE");
                        if (chkWed.Checked == true)
                            HighWeekDay.Add("WED");
                        if (chkThr.Checked == true)
                            HighWeekDay.Add("THR");
                        if (chkFri.Checked == true)
                            HighWeekDay.Add("FRI");
                        if (chkSat.Checked == true)
                            HighWeekDay.Add("SAT");
                        if (chkSun.Checked == true)
                            HighWeekDay.Add("SUN");

                        string HighWKDay = string.Empty;
                        for (int i = 0; i < HighWeekDay.Count; i++)
                        {
                            HighWKDay = HighWKDay + Convert.ToString(HighWeekDay[i]) + ",";
                        }
                        if (HighWKDay != string.Empty)
                            objUpdateReservationConfig.HighWeekDays = HighWKDay.Substring(0, HighWKDay.Length - 1);
                        else
                            objUpdateReservationConfig.HighWeekDays = null;

                        objUpdateReservationConfig.IsShowDepositAlertOnCheckIn = chkIsShowDepositAlertCheckIn.Checked;
                        objUpdateReservationConfig.IsShowDirtyRoomAlertOnCheckIn = chkIsShowDirtyRoomAlertCheckIn.Checked;
                        objUpdateReservationConfig.IsAutoPostFirstNightChargeAtCheckIn = chkIsAutoPostFirstNightChargeCheckIn.Checked;
                        objUpdateReservationConfig.IsGuestEMailCompulsory = chkGuestEmailCompulsory.Checked;
                        objUpdateReservationConfig.IsGuestIdentityCompulsory = chkGuestIdentifyCompulsory.Checked;
                        objUpdateReservationConfig.IsRateInclusiveService = chkRateInclusiveService.Checked;
                        objUpdateReservationConfig.IsEnableAutoAssignRooms = chkEnblAutoAsgnRoom.Checked;
                        objUpdateReservationConfig.Is24HrsCheckIn = chkIs24HrsChckIn.Checked;
                        objUpdateReservationConfig.IsCardInformationRequired = chkCardInfmRequired.Checked;
                        objUpdateReservationConfig.IsWarnOnOverBooking = chkWarnOnOverBooking.Checked;
                        objUpdateReservationConfig.IsShowDinomination = chkShowDenomination.Checked;
                        objUpdateReservationConfig.IsApplyYield = chkApplyYield.Checked;
                        objUpdateReservationConfig.IsYieldFlat = chkYieldFlat.Checked;

                        ReservationPoliciesBLL.Update(Updt);
                        ReservationConfigBLL.Update(objUpdateReservationConfig);

                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", OldUpdt.ToString(), Updt.ToString(), "res_ReservationPolicy");
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objUpdateOldReservationConfig.ToString(), objUpdateReservationConfig.ToString(), "res_ReservationConfig");

                        IsInsert = true;
                        litResPolicyMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");

                        this.ResPolicyID = Updt.ResPolicyID;
                        this.ResConfigID = objUpdateReservationConfig.ResConfigID;
                    }
                    else
                    {
                        //Insert Record

                        ReservationPolicies Ins = new ReservationPolicies();

                        Ins.CompanyID = clsSession.CompanyID;
                        Ins.PropertyID = clsSession.PropertyID;
                        if (txtBeforeCheckInHR.Text.Trim().Equals(string.Empty))
                            Ins.BfrCheckInHrs = null;
                        else
                            Ins.BfrCheckInHrs = Convert.ToInt32(txtBeforeCheckInHR.Text);
                        if (txtBeforeCharge.Text.Equals(string.Empty))
                            Ins.BfrCharges = null;
                        else
                            Ins.BfrCharges = Convert.ToDecimal(txtBeforeCharge.Text.Trim());

                        if (ddlBeforeCharge.SelectedIndex == 0)
                            Ins.IsBfrChargesInPercentage = true;
                        else
                            Ins.IsBfrChargesInPercentage = false;
                        if (txtAfterCharge.Text.Equals(string.Empty))
                            Ins.AftCharges = null;
                        else
                            Ins.AftCharges = Convert.ToDecimal(txtAfterCharge.Text.Trim());

                        if (txtAfterCheckInHR.Text.Equals(string.Empty))
                            Ins.AftCheckInHrs = null;
                        else
                            Ins.AftCheckInHrs = Convert.ToInt32(txtAfterCheckInHR.Text.Trim());

                        if (ddlAfterCharge.SelectedIndex == 0)
                            Ins.IsAftChargesInPercentage = true;
                        else
                            Ins.IsAftChargesInPercentage = false;

                        //if (ddlReservationType.SelectedValue.Equals(Guid.Empty))
                        //    Ins.DefaultReservationType_TermID = null;
                        //else
                        //    Ins.DefaultReservationType_TermID = new Guid(Convert.ToString(ddlReservationType.SelectedValue));

                        Ins.IsReasonRequired = Convert.ToBoolean(ChkIsReasonRequired.Checked);
                        Ins.IsFirstNightChargeCompForCashPayers = Convert.ToBoolean(ChkIsFirstNightChargeCompForCashPayers.Checked);
                        Ins.IsAssignRoomToUnConfirmRes = Convert.ToBoolean(ChkIsAssignRoomToUnConfirmRes.Checked);
                        Ins.IsAssignRoomOnReservation = Convert.ToBoolean(ChkIsAssignRoomOnReservation.Checked);
                        Ins.IsUserCanApplyDiscount = Convert.ToBoolean(ChkIsUserCanApplyDiscount.Checked);
                        Ins.IsUserCanOverrideRackRate = Convert.ToBoolean(ChkIsUserCanOverrideRackRate.Checked);
                        Ins.IsUserCanSetTaxExempt = Convert.ToBoolean(ChkIsUserCanSetTaxExempt.Checked);
                        Ins.IsActive = true;

                        ReservationConfig objSaveReservationConfig = new ReservationConfig();

                        ArrayList HighWeekDay = new ArrayList();

                        if (chkMon.Checked == true)
                            HighWeekDay.Add("MON");
                        if (chkTue.Checked == true)
                            HighWeekDay.Add("TUE");
                        if (chkWed.Checked == true)
                            HighWeekDay.Add("WED");
                        if (chkThr.Checked == true)
                            HighWeekDay.Add("THR");
                        if (chkFri.Checked == true)
                            HighWeekDay.Add("FRI");
                        if (chkSat.Checked == true)
                            HighWeekDay.Add("SAT");
                        if (chkSun.Checked == true)
                            HighWeekDay.Add("SUN");

                        string HighWKDay = string.Empty;
                        for (int i = 0; i < HighWeekDay.Count; i++)
                        {
                            HighWKDay = HighWKDay + Convert.ToString(HighWeekDay[i]) + ",";
                        }

                        if (HighWKDay != string.Empty)
                            objSaveReservationConfig.HighWeekDays = HighWKDay.Substring(0, HighWKDay.Length - 1);
                        else
                            objSaveReservationConfig.HighWeekDays = null;

                        objSaveReservationConfig.IsShowDepositAlertOnCheckIn = chkIsShowDepositAlertCheckIn.Checked;
                        objSaveReservationConfig.IsShowDirtyRoomAlertOnCheckIn = chkIsShowDirtyRoomAlertCheckIn.Checked;
                        objSaveReservationConfig.IsAutoPostFirstNightChargeAtCheckIn = chkIsAutoPostFirstNightChargeCheckIn.Checked;
                        objSaveReservationConfig.IsGuestEMailCompulsory = chkGuestEmailCompulsory.Checked;
                        objSaveReservationConfig.IsGuestIdentityCompulsory = chkGuestIdentifyCompulsory.Checked;
                        objSaveReservationConfig.IsRateInclusiveService = chkRateInclusiveService.Checked;
                        objSaveReservationConfig.IsEnableAutoAssignRooms = chkEnblAutoAsgnRoom.Checked;
                        objSaveReservationConfig.Is24HrsCheckIn = chkIs24HrsChckIn.Checked;
                        objSaveReservationConfig.IsCardInformationRequired = chkCardInfmRequired.Checked;
                        objSaveReservationConfig.IsWarnOnOverBooking = chkWarnOnOverBooking.Checked;
                        objSaveReservationConfig.IsShowDinomination = chkShowDenomination.Checked;
                        objSaveReservationConfig.IsApplyYield = chkApplyYield.Checked;
                        objSaveReservationConfig.IsYieldFlat = chkYieldFlat.Checked;

                        ReservationPoliciesBLL.Save(Ins);
                        ReservationConfigBLL.Save(objSaveReservationConfig);

                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", Ins.ToString(), Ins.ToString(), "res_ReservationPolicy");
                        ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objSaveReservationConfig.ToString(), objSaveReservationConfig.ToString(), "res_ReservationConfig");

                        IsInsert = true;
                        litResPolicyMessage.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");

                        this.ResPolicyID = Ins.ResPolicyID;
                        this.ResConfigID = objSaveReservationConfig.ResConfigID;
                    }

                    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(2);", true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        ////protected void btnCPSave_Click(object sender, EventArgs e)
        ////{
        ////    if (this.Page.IsValid)
        ////    {
        ////        try
        ////        {
        ////            if (this.ResCancellationPolicyID != Guid.Empty)
        ////            {
        ////                ResCancellationPolicy objOldData = ResCancellationPolicyBLL.GetByPrimaryKey(this.ResCancellationPolicyID);
        ////                ResCancellationPolicy objToUpd = ResCancellationPolicyBLL.GetByPrimaryKey(this.ResCancellationPolicyID);

        ////                objToUpd.CompanyID = clsSession.CompanyID;
        ////                objToUpd.PropertyID = clsSession.PropertyID;
        ////                if (ddlCPResType.SelectedIndex != 0)
        ////                    objToUpd.ResType_TermID = new Guid(ddlCPResType.SelectedValue);
        ////                else
        ////                    objToUpd.ResType_TermID = null;

        ////                if (txtCPMinHrs.Text.Trim() != "")
        ////                    objToUpd.MinHrs = Convert.ToInt32(txtCPMinHrs.Text.Trim());
        ////                else
        ////                    objToUpd.MinHrs = null;

        ////                if (txtCPMaxHrs.Text.Trim() != "")
        ////                    objToUpd.MaxHrs = Convert.ToInt32(txtCPMaxHrs.Text.Trim());
        ////                else
        ////                    objToUpd.MaxHrs = null;

        ////                if (ddlCPChargeOn.SelectedIndex != 0)
        ////                    objToUpd.ChargesApply_TermID = new Guid(ddlCPChargeOn.SelectedValue);
        ////                else
        ////                    objToUpd.ChargesApply_TermID = null;

        ////                if (ddlCPCancellationCharges.SelectedIndex == 0)
        ////                {
        ////                    if (txtCPCancellationCharges.Text.Trim() != "")
        ////                    {
        ////                        objToUpd.IsFlatCharge = false;
        ////                        objToUpd.CancellationCharges = Convert.ToDecimal(txtCPCancellationCharges.Text.Trim());
        ////                    }
        ////                }
        ////                else
        ////                {
        ////                    if (txtCPCancellationCharges.Text.Trim() != "")
        ////                    {
        ////                        objToUpd.IsFlatCharge = true;
        ////                        objToUpd.CancellationCharges = Convert.ToDecimal(txtCPCancellationCharges.Text.Trim());
        ////                    }
        ////                }

        ////                objToUpd.UpdatedOn = DateTime.Now;
        ////                objToUpd.UpdatedBy = new Guid(Convert.ToString(Session["UserID"]));

        ////                ResCancellationPolicyBLL.Update(objToUpd);

        ////                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", objOldData.ToString(), objToUpd.ToString(), "res_ResCancellationPolicy");

        ////                IsCancellationPolicy = true;
        ////                litCancellationPolicy.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");
        ////            }
        ////            else
        ////            {
        ////                ResCancellationPolicy objToIns = new ResCancellationPolicy();

        ////                objToIns.CompanyID = clsSession.CompanyID;
        ////                objToIns.PropertyID = clsSession.PropertyID;
        ////                if (ddlCPResType.SelectedIndex != 0)
        ////                    objToIns.ResType_TermID = new Guid(ddlCPResType.SelectedValue);
        ////                if (txtCPMinHrs.Text.Trim() != "")
        ////                    objToIns.MinHrs = Convert.ToInt32(txtCPMinHrs.Text.Trim());
        ////                if (txtCPMaxHrs.Text.Trim() != "")
        ////                    objToIns.MaxHrs = Convert.ToInt32(txtCPMaxHrs.Text.Trim());
        ////                if (ddlCPChargeOn.SelectedIndex != 0)
        ////                    objToIns.ChargesApply_TermID = new Guid(ddlCPChargeOn.SelectedValue);
        ////                if (ddlCPCancellationCharges.SelectedIndex == 0)
        ////                {
        ////                    if (txtCPCancellationCharges.Text.Trim() != "")
        ////                    {
        ////                        objToIns.IsFlatCharge = false;
        ////                        objToIns.CancellationCharges = Convert.ToDecimal(txtCPCancellationCharges.Text.Trim());
        ////                    }
        ////                }
        ////                else
        ////                {
        ////                    if (txtCPCancellationCharges.Text.Trim() != "")
        ////                    {
        ////                        objToIns.IsFlatCharge = true;
        ////                        objToIns.CancellationCharges = Convert.ToDecimal(txtCPCancellationCharges.Text.Trim());
        ////                    }
        ////                }

        ////                objToIns.CreatedOn = DateTime.Now;
        ////                objToIns.CreatedBy = new Guid(Convert.ToString(Session["UserID"]));
        ////                objToIns.IsActive = true;

        ////                ResCancellationPolicyBLL.Save(objToIns);

        ////                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Save", objToIns.ToString(), objToIns.ToString(), "res_ResCancellationPolicy");

        ////                IsCancellationPolicy = true;
        ////                litCancellationPolicy.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordSavedSuccessfully", "Record saved successfully.");
        ////            }

        ////            ClearControl();
        ////            BindCancellationPolicyGrid();

        ////        }
        ////        catch (Exception ex)
        ////        {
        ////            MessageBox.Show(ex.Message.ToString());
        ////        }
        ////    }
        ////}

        ////protected void btnCPCancel_Click(object sender, EventArgs e)
        ////{
        ////    ClearControl();
        ////}

        #endregion

        #region Dropdown Event

        protected void ddlBeforeCharge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBeforeCharge.SelectedIndex == 0)
                rbgBeforeCharge.Enabled = true;
            else
                rbgBeforeCharge.Enabled = false;
        }

        protected void ddlAfterCharge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAfterCharge.SelectedIndex == 0)
                rgvAfterCharge.Enabled = true;
            else
                rgvAfterCharge.Enabled = false;
        }

        protected void ddlGeneralTravlAgntCmnd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneralTravlAgntCmnd.SelectedIndex == 0)
                rgvGeneralTravelAgentCMS.Enabled = true;
            else
                rgvGeneralTravelAgentCMS.Enabled = false;
        }

        protected void ddlGeneralCorporateDisc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneralCorporateDisc.SelectedIndex == 0)
                rgvCorporateDiscount.Enabled = true;
            else
                rgvCorporateDiscount.Enabled = false;
        }

        ////protected void ddlCPCancellationCharges_SelectedIndexChanged(object sender, EventArgs e)
        ////{
        ////    if (ddlCPCancellationCharges.SelectedIndex == 0)
        ////        rvCancellationCharges.Enabled = true;
        ////    else
        ////        rvCancellationCharges.Enabled = false;
        ////}

        #endregion Dropdown Event

        //#region Grid Event

        //protected void gvReservationCancellationPolicyList_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            Label lblGvCancellationCharges = (Label)e.Row.FindControl("lblGvCancellationCharges");
        //            string strCancellationCharges = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CancellationCharges"));

        //            if (lblGvCancellationCharges != null)
        //            {
        //                if (strCancellationCharges != string.Empty)
        //                    lblGvCancellationCharges.Text = strCancellationCharges.Substring(0, strCancellationCharges.LastIndexOf(".") + 1 + clsSession.DigitsAfterDecimalPoint);
        //            }

        //            LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

        //            if (this.UserRights.Substring(2, 1) == "1")
        //                ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpEdit", "Edit");
        //            else
        //                ((LinkButton)e.Row.FindControl("lnkEdit")).ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpView", "View");

        //            lnkDelete.Visible = this.UserRights.Substring(3, 1) == "1";
        //            lnkDelete.ToolTip = clsCommon.GetGlobalResourceText("Common", "lblTltpDelete", "Delete");

        //            lnkDelete.OnClientClick = string.Format("return fnConfirmDelete('{0}');", Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ResPolicyID")));
        //        }
        //        else if (e.Row.RowType == DataControlRowType.Header)
        //        {
        //            ((Label)e.Row.FindControl("lblGvHdrSrNo")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrNumber", "No.");
        //            ((Label)e.Row.FindControl("lblGvHdrReservationType")).Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblGvHdrReservationType", "Reservation Type");
        //            ((Label)e.Row.FindControl("lblGvHdrChargesOn")).Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblGvHdrChargesOn", "Charge On");
        //            ((Label)e.Row.FindControl("lblGvHdrMinHrs")).Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblGvHdrMinHrs", "Min. Hours");
        //            ((Label)e.Row.FindControl("lblGvHdrMaxHrs")).Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblGvHdrMaxHrs", "Max. Hours");
        //            ((Label)e.Row.FindControl("lblGvHdrCancellationCharges")).Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblGvHdrCancellationCharges", "Cancellation Charges");
        //            ((Label)e.Row.FindControl("lblGvHdrType")).Text = clsCommon.GetGlobalResourceText("ReservationCancellationPolicy", "lblGvHdrType", "Type");
        //            ((Label)e.Row.FindControl("lblGvHdrAction")).Text = clsCommon.GetGlobalResourceText("Common", "lblGvHdrActions", "Actions");
        //        }
        //        else if (e.Row.RowType == DataControlRowType.EmptyDataRow)
        //        {
        //            ((Label)e.Row.FindControl("lblNoRecordFound")).Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgNoRecordFound", "No record found.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        //protected void gvReservationCancellationPolicyList_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        if (e.CommandName.Equals("EDITDATA"))
        //        {
        //            this.ResCancellationPolicyID = new Guid(Convert.ToString(e.CommandArgument));
        //            BindCancellationPolicyData();
        //        }
        //        else if (e.CommandName.Equals("DELETEDATA"))
        //        {
        //            mpeConfirmDelete.Show();
        //            this.ResCancellationPolicyID = new Guid(Convert.ToString(e.CommandArgument));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString());
        //    }
        //}

        //protected void gvReservationCancellationPolicyList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvReservationCancellationPolicyList.PageIndex = e.NewPageIndex;
        //    BindCancellationPolicyGrid();
        //}

        //#endregion Grid Event

        #region Popup Button Event

        ////protected void btnYes_Click(object sender, EventArgs e)
        ////{
        ////    try
        ////    {
        ////        if (Convert.ToString(hdnConfirmDelete.Value) != string.Empty)
        ////        {
        ////            mpeConfirmDelete.Hide();
        ////            ResCancellationPolicy objDelete = new ResCancellationPolicy();
        ////            objDelete = ResCancellationPolicyBLL.GetByPrimaryKey(new Guid(Convert.ToString(hdnConfirmDelete.Value)));

        ////            ResCancellationPolicyBLL.Delete(objDelete);
        ////            ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Delete", objDelete.ToString(), null, "mst_Room");
        ////            IsCancellationPolicy = true;
        ////            litCancellationPolicy.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordDeletedSuccessfully", "Record deleted successfully.");
        ////            ClearControl();
        ////        }
        ////        BindCancellationPolicyGrid();
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        MessageBox.Show(ex.Message.ToString());
        ////    }
        ////}

        ////protected void btnNo_Click(object sender, EventArgs e)
        ////{
        ////    try
        ////    {
        ////        ClearControl();
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        MessageBox.Show(ex.Message.ToString());
        ////    }
        ////}

        #endregion

        #region Term & Condition Button Event

        /// <summary>
        /// Save Button Event
        /// </summary>
        /// <param name="sender">sender as Object</param>
        /// <param name="e">e as EventArgs</param>
        protected void btnTermsConditionSave_Click(object sender, EventArgs e)
        {
            if (this.FolioConfigID != Guid.Empty)
            {
                FolioConfig Updt = FolioConfigBLL.GetByPrimaryKey(this.FolioConfigID);
                FolioConfig OldUpdt = FolioConfigBLL.GetByPrimaryKey(this.FolioConfigID);
                ////Updt.FolioNotes = txtFolioNotes.Text.Trim();
                Updt.TermnCondition = txtTermsCondition.Text.Trim();
                FolioConfigBLL.Update(Updt);
                ActionLogBLL.SaveConfigurationActionLog(clsSession.UserID, "Update", OldUpdt.ToString() + "<br/><br/>" + Updt.ToString(), Updt.ToString() + "<br/><br/>" + OldUpdt.ToString(), "res_FolioConfig");
            }
            IsMessageForHR = true;
            ltrSuccessfullyTerm.Text = clsCommon.GetGlobalResourceText("CommonMessage", "lblMsgRecordUpdatedSuccessfully", "Record updated successfully.");

            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "SelectTab(3);", true);
        }
        #endregion Term & Condition Button Event        
    }
}