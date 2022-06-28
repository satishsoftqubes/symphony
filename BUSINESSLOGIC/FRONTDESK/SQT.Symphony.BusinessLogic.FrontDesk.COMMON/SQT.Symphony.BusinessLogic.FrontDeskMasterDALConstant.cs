using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQT.Symphony.BusinessLogic.FrontDesk.COMMON
{
    public class MasterDALConstant
    {
        // Vijay

        //SPs for  hkp_ResHouseKeeping
        public const string ResHouseKeepingInsert = "[dbo].[hkp_ResHouseKeeping_Insert]";
        public const string ResHouseKeepingUpdate = "[dbo].[hkp_ResHouseKeeping_Update]";
        public const string ResHouseKeepingSelectByPrimaryKey = "[dbo].[hkp_ResHouseKeeping_SelectByPrimaryKey]";
        public const string ResHouseKeepingSelectAll = "[dbo].[hkp_ResHouseKeeping_SelectAll]";
        public const string ResHouseKeepingSelectByField = "[dbo].[hkp_ResHouseKeeping_SelectByField]";
        public const string ResHouseKeepingDeleteByPrimaryKey = "[dbo].[hkp_ResHouseKeeping_DeleteByPrimaryKey]";
        public const string ResHouseKeepingDeleteByField = "[dbo].[hkp_ResHouseKeeping_DeleteByField]";
        //SPs for  mst_Guest
        public const string GuestInsert = "[dbo].[mst_Guest_Insert]";
        public const string GuestUpdate = "[dbo].[mst_Guest_Update]";
        public const string GuestSelectByPrimaryKey = "[dbo].[mst_Guest_SelectByPrimaryKey]";
        public const string GuestSelectAll = "[dbo].[mst_Guest_SelectAll]";
        public const string GuestSelectByField = "[dbo].[mst_Guest_SelectByField]";
        public const string GuestDeleteByPrimaryKey = "[dbo].[mst_Guest_DeleteByPrimaryKey]";
        public const string GuestDeleteByField = "[dbo].[mst_Guest_DeleteByField]";
        public const string GuestSelectExistingGuest = "[dbo].[mst_Guest_SelectExistingGuest]";
        public const string GuestSelectGuestInfoByGuestID = "[dbo].[mst_Guest_SelectGuestInfoByGuestID]";
        public const string GuestSelectCurrentGuestList = "[dbo].[res_Reservation_SelectCurrentGuestList]";
        public const string GuestSelectGuestAndReserForGuestMsglist = "[dbo].[mst_Guest_SelectGuestAndReserForGuestMsglist]";
        public const string GuestSelectGuestAndReserForTroubleTicket = "[dbo].[mst_Guest_SelectGuestAndReserForTroubleTicket]";
        public const string GuestSelectAllForGuestHistory = "[dbo].[mst_Guest_SelectAllForGuestHistory]";
        public const string GuestSelectGuestBirthDayReport = "[dbo].[mst_Guest_SelectGuestBirthDayReport]";
        public const string Report_res_OccupancyReprtByType = "[dbo].[res_OccupancyReprtByType]";
        public const string mst_GuestGetEmailAddressOfGuestForSendMail = "[dbo].[mst_GetEmailAddressOfGuestForSendMail]";
        public const string res_GetNoOfOccupiedAndNoOfBeds = "[dbo].[res_GetNoOfOccupiedAndNoOfBeds]";
        public const string GuestSelectPastGuestList = "[dbo].[res_Reservation_SelectPastGuestList]";
        public const string GuestUpdateEmail = "[dbo].[mst_Guest_UpdateGuestEmail]";

        //SPs for  mst_GuestPreference
        public const string GuestPreferenceInsert = "[dbo].[mst_GuestPreference_Insert]";
        public const string GuestPreferenceUpdate = "[dbo].[mst_GuestPreference_Update]";
        public const string GuestPreferenceSelectByPrimaryKey = "[dbo].[mst_GuestPreference_SelectByPrimaryKey]";
        public const string GuestPreferenceSelectAll = "[dbo].[mst_GuestPreference_SelectAll]";
        public const string GuestPreferenceSelectByField = "[dbo].[mst_GuestPreference_SelectByField]";
        public const string GuestPreferenceDeleteByPrimaryKey = "[dbo].[mst_GuestPreference_DeleteByPrimaryKey]";
        public const string GuestPreferenceDeleteByField = "[dbo].[mst_GuestPreference_DeleteByField]";
        public const string GuestPreferenceSelectAllForList = "[dbo].[mst_GuestPreference_SelectAllForList]";
        //SPs for  mst_PreferenceMaster
        public const string PreferenceMasterInsert = "[dbo].[mst_PreferenceMaster_Insert]";
        public const string PreferenceMasterUpdate = "[dbo].[mst_PreferenceMaster_Update]";
        public const string PreferenceMasterSelectByPrimaryKey = "[dbo].[mst_PreferenceMaster_SelectByPrimaryKey]";
        public const string PreferenceMasterSelectAll = "[dbo].[mst_PreferenceMaster_SelectAll]";
        public const string PreferenceMasterSelectByField = "[dbo].[mst_PreferenceMaster_SelectByField]";
        public const string PreferenceMasterDeleteByPrimaryKey = "[dbo].[mst_PreferenceMaster_DeleteByPrimaryKey]";
        public const string PreferenceMasterDeleteByField = "[dbo].[mst_PreferenceMaster_DeleteByField]";
        public const string PreferenceMasterSelectAllForList = "[dbo].[mst_PreferenceMaster_SelectAllForList]";
        //SPs for  res_BlockDateRate
        public const string BlockDateRateInsert = "[dbo].[res_BlockDateRate_Insert]";
        public const string BlockDateRateUpdate = "[dbo].[res_BlockDateRate_Update]";
        public const string BlockDateRateSelectByPrimaryKey = "[dbo].[res_BlockDateRate_SelectByPrimaryKey]";
        public const string BlockDateRateSelectAll = "[dbo].[res_BlockDateRate_SelectAll]";
        public const string BlockDateRateSelectByField = "[dbo].[res_BlockDateRate_SelectByField]";
        public const string BlockDateRateDeleteByPrimaryKey = "[dbo].[res_BlockDateRate_DeleteByPrimaryKey]";
        public const string BlockDateRateDeleteByField = "[dbo].[res_BlockDateRate_DeleteByField]";
        public const string BlockDateRateUpdateRoomID = "[dbo].[res_BlockDateRate_UpdateRoomID]";
        public const string BlockDateRateDeleteByReservationID = "[dbo].[res_BlockDateRate_Delete]";
        public const string RPTRoomRentRevenueDetail = "[dbo].[rpt_RoomRentRevenueDetail]";
        public const string BlockDateRateDeleteUnPostedTransByReservationID = "[dbo].[res_BlockDateRate_DeleteUnPostedTransByReservationID]";
        public const string BlockDateRateSelectTotalRoomRateByDatePeriod = "[dbo].[res_BlockDateRate_SelectTotalRoomRateByDatePeriod]";
        public const string BlockDateRateSelectData4UpgradeDowngrade = "[dbo].[res_Reservation_SelectData4UpgradeDowngrade]";
        public const string ReportCompanyPosting = "[dbo].[rpt_CompanyPostingData]";

        //SPs for  res_Folio
        public const string FolioInsert = "[dbo].[res_Folio_Insert]";
        public const string FolioUpdate = "[dbo].[res_Folio_Update]";
        public const string FolioSelectByPrimaryKey = "[dbo].[res_Folio_SelectByPrimaryKey]";
        public const string FolioSelectAll = "[dbo].[res_Folio_SelectAll]";
        public const string FolioSelectByField = "[dbo].[res_Folio_SelectByField]";
        public const string FolioDeleteByPrimaryKey = "[dbo].[res_Folio_DeleteByPrimaryKey]";
        public const string FolioDeleteByField = "[dbo].[res_Folio_DeleteByField]";
        public const string FolioSelectFolioBalance = "[dbo].[res_Folio_Balance]";
        public const string FolioSelectAllFolio = "[dbo].[res_Folio_GetAllFolio]";
        public const string FolioSelectAllFolioBalance = "[dbo].[res_Folio_GetAllFolioBalance]";
        public const string FolioSelectAllFolios = "[dbo].[res_Folio_GetAllFolios]";
        public const string Folio_GetSummary = "[dbo].[res_Folio_GetSummary]";
        public const string Folio_QuickPostInAccount = "[dbo].[acct_QuickPostInAccount]";
        public const string Folio_FolioTransferTransaction = "[dbo].[res_Folio_TransferTransaction]";
        public const string Folio_GetAllOverridesTransaction = "[dbo].[res_Folio_GetAllOverrides]";
        public const string Folio_GetAllRecoveryTransaction = "[dbo].[tra_Transaction_GetAllRecoveryTransaction]";
        public const string FolioDetailStatement = "[dbo].[acc_PrintFolioStatement]";
        public const string Folio_SelectAllDataForSplitBilling = "[dbo].[res_Folio_SelectAllDataForSplitBilling]";
        public const string Folio_SelectPastFolioList = "[dbo].[res_Folio_PastFolioList]";
        public const string Folio_PostCreditInAccount = "[dbo].[acct_PostCreditInAccount]";
        public const string Folio_SelectAll_CheckOutOpenFolios = "[dbo].[res_Folio_SelectAll_CheckOutOpenFolios]";

        //SPs for  res_FolioReRoute
        public const string FolioReRouteInsert = "[dbo].[res_FolioReRoute_Insert]";
        public const string FolioReRouteUpdate = "[dbo].[res_FolioReRoute_Update]";
        public const string FolioReRouteSelectByPrimaryKey = "[dbo].[res_FolioReRoute_SelectByPrimaryKey]";
        public const string FolioReRouteSelectAll = "[dbo].[res_FolioReRoute_SelectAll]";
        public const string FolioReRouteSelectByField = "[dbo].[res_FolioReRoute_SelectByField]";
        public const string FolioReRouteDeleteByPrimaryKey = "[dbo].[res_FolioReRoute_DeleteByPrimaryKey]";
        public const string FolioReRouteDeleteByField = "[dbo].[res_FolioReRoute_DeleteByField]";
        public const string FolioReRouteDeleteBySourceAndDestinationFolioID = "[dbo].[res_FolioReRoute_DeleteBySourceAndDestinationFolioID]";

        //SPs for  res_GuestLaundry
        public const string GuestLaundryInsert = "[dbo].[res_GuestLaundry_Insert]";
        public const string GuestLaundryUpdate = "[dbo].[res_GuestLaundry_Update]";
        public const string GuestLaundrySelectByPrimaryKey = "[dbo].[res_GuestLaundry_SelectByPrimaryKey]";
        public const string GuestLaundrySelectAll = "[dbo].[res_GuestLaundry_SelectAll]";
        public const string GuestLaundrySelectByField = "[dbo].[res_GuestLaundry_SelectByField]";
        public const string GuestLaundryDeleteByPrimaryKey = "[dbo].[res_GuestLaundry_DeleteByPrimaryKey]";
        public const string GuestLaundryDeleteByField = "[dbo].[res_GuestLaundry_DeleteByField]";
        //SPs for  res_GuestMsgJoin
        public const string GuestMsgJoinInsert = "[dbo].[res_GuestMsgJoin_Insert]";
        public const string GuestMsgJoinUpdate = "[dbo].[res_GuestMsgJoin_Update]";
        public const string GuestMsgJoinSelectByPrimaryKey = "[dbo].[res_GuestMsgJoin_SelectByPrimaryKey]";
        public const string GuestMsgJoinSelectAll = "[dbo].[res_GuestMsgJoin_SelectAll]";
        public const string GuestMsgJoinSelectByField = "[dbo].[res_GuestMsgJoin_SelectByField]";
        public const string GuestMsgJoinDeleteByPrimaryKey = "[dbo].[res_GuestMsgJoin_DeleteByPrimaryKey]";
        public const string GuestMsgJoinDeleteByField = "[dbo].[res_GuestMsgJoin_DeleteByField]";
        public const string GuestMsgJoinSelectForList = "[dbo].[res_GuestMsgJoin_SelectForList]";
        public const string GuestMsgJoinSelectUnreadMsgList = "[dbo].[res_GuestMsgJoin_SelectUnreadMsgList]";
        //SPs for  res_MoveRoom
        public const string MoveRoomInsert = "[dbo].[res_MoveRoom_Insert]";
        public const string MoveRoomUpdate = "[dbo].[res_MoveRoom_Update]";
        public const string MoveRoomSelectByPrimaryKey = "[dbo].[res_MoveRoom_SelectByPrimaryKey]";
        public const string MoveRoomSelectAll = "[dbo].[res_MoveRoom_SelectAll]";
        public const string MoveRoomSelectByField = "[dbo].[res_MoveRoom_SelectByField]";
        public const string MoveRoomDeleteByPrimaryKey = "[dbo].[res_MoveRoom_DeleteByPrimaryKey]";
        public const string MoveRoomDeleteByField = "[dbo].[res_MoveRoom_DeleteByField]";
        public const string MoveRoom_SelectMoveRoomHistory = "[dbo].[res_MoveRoom_Select]";

        //SPs for  res_ResAuditLog
        public const string ResAuditLogInsert = "[dbo].[res_ResAuditLog_Insert]";
        public const string ResAuditLogUpdate = "[dbo].[res_ResAuditLog_Update]";
        public const string ResAuditLogSelectByPrimaryKey = "[dbo].[res_ResAuditLog_SelectByPrimaryKey]";
        public const string ResAuditLogSelectAll = "[dbo].[res_ResAuditLog_SelectAll]";
        public const string ResAuditLogSelectByField = "[dbo].[res_ResAuditLog_SelectByField]";
        public const string ResAuditLogDeleteByPrimaryKey = "[dbo].[res_ResAuditLog_DeleteByPrimaryKey]";
        public const string ResAuditLogDeleteByField = "[dbo].[res_ResAuditLog_DeleteByField]";
        //SPs for  res_Reservation
        public const string ReservationInsert = "[dbo].[res_Reservation_Insert]";
        public const string ReservationUpdate = "[dbo].[res_Reservation_Update]";
        public const string ReservationSelectByPrimaryKey = "[dbo].[res_Reservation_SelectByPrimaryKey]";
        public const string ReservationSelectAll = "[dbo].[res_Reservation_SelectAll]";
        public const string ReservationSelectByField = "[dbo].[res_Reservation_SelectByField]";
        public const string ReservationDeleteByPrimaryKey = "[dbo].[res_Reservation_DeleteByPrimaryKey]";
        public const string ReservationDeleteByField = "[dbo].[res_Reservation_DeleteByField]";
        public const string ReservationDrawReservationChart = "[dbo].[res_Reservation_GetReservationsForChart]";
        public const string Reservation_GetRoomStatus = "[dbo].[res_Reservation_GetRoomStatus]";
        public const string ReservationSelectReservationList = "[dbo].[res_Reservation_SelectReservationList]";
        public const string ReservationSelectReservationViewData = "[dbo].[res_Reservation_SelectReservationViewData]";
        public const string ReservationGetAllVacantRoom = "[dbo].[mst_Room_GetAllVacantRoom]";
        public const string ReservationSelectArrivalListData = "[dbo].[res_Reservation_SelectArrivalListData]";
        public const string ReservationIsRoomAvailable = "[dbo].[mst_Room_IsRoomAvailable]";
        public const string ReservationSelectReservationVoucherData = "[dbo].[res_Reservation_SelectReservationVoucherData]";
        public const string ReservationSelectReservationProjectTermData = "[dbo].[mst_ProjectTerm_SelectReservationData]";
        public const string ReservationSelectReservationPaymentInfo = "[dbo].[res_Reservation_SelectReservationPaymentInfo]";
        public const string ReservationSelectReservationPaymentInfoForReprint = "[dbo].[res_Reservation_SelectReservationPaymentInfoForReprint]";
        public const string ReservationSelectCancelReservationData = "[dbo].[res_Reservation_SelectCancelReservationData]";
        public const string ReservationSelectCancellationPolicyAndGuestPayment = "[dbo].[res_Reservation_SelectCancellationPolicyAndGuestPayment]";
        public const string ReservationSelectDepatureListData = "[dbo].[res_Reservation_SelectDepatureListData]";
        public const string ReservationTodaysAvailabilityChart = "[dbo].[res_Reservation_RoomsToSellDashBoard]";
        public const string ReservationSelectCheckInVoucherData = "[dbo].[res_Reservation_SelectCheckInVoucherData]";
        public const string ReservationSelectReservationDetailByReservationNo = "[dbo].[res_Reservation_SelectReservationDetailByReservationNo]";
        public const string ReservationSelectDetailForFeedback = "[dbo].[res_Reservation_SelectDetailForFeedback]";
        public const string ReservationDeleteBlockDateRateAndResServiceListData = "[dbo].[res_Reservation_DeleteBlockDateRateAndResServiceListData]";
        public const string ReservationSelectAmendReservationListData = "[dbo].[res_Reservation_SelectAmendReservationListData]";
        public const string ReservationGetAllUnpostedCharges = "[dbo].[res_Reservation_UnpostedCharges]";
        public const string ReservationSelectSwapRoomList = "[dbo].[res_Reservation_SelectSwapRoomList]";
        public const string ReservationSelectCheckOutVoucherData = "[dbo].[res_Reservation_SelectCheckOutVoucherData]";
        public const string ReservationSelectCheckInRoomNoAndReservationNo = "[dbo].[res_Reservation_SelectCheckInRoomNoAndReservationNo]";
        public const string Reservation_SymphonySelectReservation = "[dbo].[res_Reservation_SymphonySelect]";
        public const string Reservation_Update_AgentID = "[dbo].[res_Reservation_Update_AgentID]";
        public const string ReservationSelectReservationPaymentInfo4ExtendStay = "[dbo].[res_Reservation_SelectReservationPaymentInfo4ExtendStay]";
        public const string ReservationAmendHistoryData = "[dbo].[res_ReservationUpdateLog_AmendHistoryData]";
        public const string ReservationSelectAll4CompanyInvoice = "[dbo].[res_Reservation_SelectAll4CompanyInvoice]";
        public const string ReservationSelectReservationInfo4CompanyInvoice = "[dbo].[res_Reservation_SelectReservationInfo4CompanyInvoice]";
        public const string ReservationSelectBillingInstructionTermStatus = "[dbo].[SelectBillingInstructionTermStatus]";
        public const string ReservationGetRetentionChargePercent = "[dbo].[res_Reservation_GetRetentionChargePercent]";
        public const string ReservationGetNoOfRoomNights = "[dbo].[res_Reservation_GetNoOfRoomNights]";
        public const string ReservationRoomStatusCount = "[dbo].[res_Reservation_RoomStatus]";
        public const string Reservation_GetRoomStatusNew = "[dbo].[res_Reservation_GetRoomStatusNew]";
        public const string Reservation_GetTotalNumOfOverstayDays = "[dbo].[res_Reservation_GetOverStayDays]";
        public const string Reservation_Get4OverstayNotification = "[dbo].[res_Reservation_Select4OverstayNotification]";
        public const string Reservation_GetTotalNumOfOverstayCharge = "[dbo].[res_Reservation_GetOverStayCharge]";
        public const string Reservation_Update_OverStayStatusAfterPayment = "[dbo].[res_Reservation_UpdateOverStayStatusAfterPayment]";
        public const string Reservation_UpdateWronglyAssignedRoomNo = "[dbo].[res_Reservation_UpdateWronglyAssignedRoomNo]";
        public const string Room_SearchRoomByRoomNo = "[dbo].[mst_Room_SearchRoomByRoomNo]";

        //SPs for  res_Reservation_LaundryDetail
        public const string Reservation_LaundryDetailInsert = "[dbo].[res_Reservation_LaundryDetail_Insert]";
        public const string Reservation_LaundryDetailUpdate = "[dbo].[res_Reservation_LaundryDetail_Update]";
        public const string Reservation_LaundryDetailSelectByPrimaryKey = "[dbo].[res_Reservation_LaundryDetail_SelectByPrimaryKey]";
        public const string Reservation_LaundryDetailSelectAll = "[dbo].[res_Reservation_LaundryDetail_SelectAll]";
        public const string Reservation_LaundryDetailSelectByField = "[dbo].[res_Reservation_LaundryDetail_SelectByField]";
        public const string Reservation_LaundryDetailDeleteByPrimaryKey = "[dbo].[res_Reservation_LaundryDetail_DeleteByPrimaryKey]";
        public const string Reservation_LaundryDetailDeleteByField = "[dbo].[res_Reservation_LaundryDetail_DeleteByField]";
        //SPs for  res_ReservationDetail
        public const string ReservationDetailInsert = "[dbo].[res_ReservationDetail_Insert]";
        public const string ReservationDetailUpdate = "[dbo].[res_ReservationDetail_Update]";
        public const string ReservationDetailSelectByPrimaryKey = "[dbo].[res_ReservationDetail_SelectByPrimaryKey]";
        public const string ReservationDetailSelectAll = "[dbo].[res_ReservationDetail_SelectAll]";
        public const string ReservationDetailSelectByField = "[dbo].[res_ReservationDetail_SelectByField]";
        public const string ReservationDetailDeleteByPrimaryKey = "[dbo].[res_ReservationDetail_DeleteByPrimaryKey]";
        public const string ReservationDetailDeleteByField = "[dbo].[res_ReservationDetail_DeleteByField]";
        //SPs for  res_ReservationGuest
        public const string ReservationGuestInsert = "[dbo].[res_ReservationGuest_Insert]";
        public const string ReservationGuestUpdate = "[dbo].[res_ReservationGuest_Update]";
        public const string ReservationGuestSelectByPrimaryKey = "[dbo].[res_ReservationGuest_SelectByPrimaryKey]";
        public const string ReservationGuestSelectAll = "[dbo].[res_ReservationGuest_SelectAll]";
        public const string ReservationGuestSelectByField = "[dbo].[res_ReservationGuest_SelectByField]";
        public const string ReservationGuestDeleteByPrimaryKey = "[dbo].[res_ReservationGuest_DeleteByPrimaryKey]";
        public const string ReservationGuestDeleteByField = "[dbo].[res_ReservationGuest_DeleteByField]";
        public const string ReservationGuestSelectForGuestStayHistory = "[dbo].[res_ReservationGuest_SelectForGuestStayHistory]";
        public const string ReservationGuest_Update_CashcardNumber = "[dbo].[res_ReservationGuest_Update_CashcardNumber]";
        //SPs for  res_ResGuestPaymentInfo
        public const string ResGuestPaymentInfoInsert = "[dbo].[res_ResGuestPaymentInfo_Insert]";
        public const string ResGuestPaymentInfoUpdate = "[dbo].[res_ResGuestPaymentInfo_Update]";
        public const string ResGuestPaymentInfoSelectByPrimaryKey = "[dbo].[res_ResGuestPaymentInfo_SelectByPrimaryKey]";
        public const string ResGuestPaymentInfoSelectAll = "[dbo].[res_ResGuestPaymentInfo_SelectAll]";
        public const string ResGuestPaymentInfoSelectByField = "[dbo].[res_ResGuestPaymentInfo_SelectByField]";
        public const string ResGuestPaymentInfoDeleteByPrimaryKey = "[dbo].[res_ResGuestPaymentInfo_DeleteByPrimaryKey]";
        public const string ResGuestPaymentInfoDeleteByField = "[dbo].[res_ResGuestPaymentInfo_DeleteByField]";
        public const string ResGuestPaymentSelectCreditCardList = "[dbo].[res_ResGuestPaymentInfo_SelectCreditCardList]";

        //SPs for  res_ResRoomInventory
        public const string ResRoomInventoryInsert = "[dbo].[res_ResRoomInventory_Insert]";
        public const string ResRoomInventoryUpdate = "[dbo].[res_ResRoomInventory_Update]";
        public const string ResRoomInventorySelectByPrimaryKey = "[dbo].[res_ResRoomInventory_SelectByPrimaryKey]";
        public const string ResRoomInventorySelectAll = "[dbo].[res_ResRoomInventory_SelectAll]";
        public const string ResRoomInventorySelectByField = "[dbo].[res_ResRoomInventory_SelectByField]";
        public const string ResRoomInventoryDeleteByPrimaryKey = "[dbo].[res_ResRoomInventory_DeleteByPrimaryKey]";
        public const string ResRoomInventoryDeleteByField = "[dbo].[res_ResRoomInventory_DeleteByField]";
        //SPs for  res_ResServiceList
        public const string ResServiceListInsert = "[dbo].[res_ResServiceList_Insert]";
        public const string ResServiceListUpdate = "[dbo].[res_ResServiceList_Update]";
        public const string ResServiceListSelectByPrimaryKey = "[dbo].[res_ResServiceList_SelectByPrimaryKey]";
        public const string ResServiceListSelectAll = "[dbo].[res_ResServiceList_SelectAll]";
        public const string ResServiceListSelectByField = "[dbo].[res_ResServiceList_SelectByField]";
        public const string ResServiceListDeleteByPrimaryKey = "[dbo].[res_ResServiceList_DeleteByPrimaryKey]";
        public const string ResServiceListDeleteByField = "[dbo].[res_ResServiceList_DeleteByField]";
        //SPs for  res_TaxExempt
        public const string TaxExemptInsert = "[dbo].[res_TaxExempt_Insert]";
        public const string TaxExemptUpdate = "[dbo].[res_TaxExempt_Update]";
        public const string TaxExemptSelectByPrimaryKey = "[dbo].[res_TaxExempt_SelectByPrimaryKey]";
        public const string TaxExemptSelectAll = "[dbo].[res_TaxExempt_SelectAll]";
        public const string TaxExemptSelectByField = "[dbo].[res_TaxExempt_SelectByField]";
        public const string TaxExemptDeleteByPrimaryKey = "[dbo].[res_TaxExempt_DeleteByPrimaryKey]";
        public const string TaxExemptDeleteByField = "[dbo].[res_TaxExempt_DeleteByField]";
        //SPs for  res_TaxExemptValue
        public const string TaxExemptValueInsert = "[dbo].[res_TaxExemptValue_Insert]";
        public const string TaxExemptValueUpdate = "[dbo].[res_TaxExemptValue_Update]";
        public const string TaxExemptValueSelectByPrimaryKey = "[dbo].[res_TaxExemptValue_SelectByPrimaryKey]";
        public const string TaxExemptValueSelectAll = "[dbo].[res_TaxExemptValue_SelectAll]";
        public const string TaxExemptValueSelectByField = "[dbo].[res_TaxExemptValue_SelectByField]";
        public const string TaxExemptValueDeleteByPrimaryKey = "[dbo].[res_TaxExemptValue_DeleteByPrimaryKey]";
        public const string TaxExemptValueDeleteByField = "[dbo].[res_TaxExemptValue_DeleteByField]";
        //SPs for  res_VoucherDetail
        public const string VoucherDetailInsert = "[dbo].[res_VoucherDetail_Insert]";
        public const string VoucherDetailUpdate = "[dbo].[res_VoucherDetail_Update]";
        public const string VoucherDetailSelectByPrimaryKey = "[dbo].[res_VoucherDetail_SelectByPrimaryKey]";
        public const string VoucherDetailSelectAll = "[dbo].[res_VoucherDetail_SelectAll]";
        public const string VoucherDetailSelectByField = "[dbo].[res_VoucherDetail_SelectByField]";
        public const string VoucherDetailDeleteByPrimaryKey = "[dbo].[res_VoucherDetail_DeleteByPrimaryKey]";
        public const string VoucherDetailDeleteByField = "[dbo].[res_VoucherDetail_DeleteByField]";
        //SPs for  tra_BookKeeping
        public const string BookKeepingInsert = "[dbo].[tra_BookKeeping_Insert]";
        public const string BookKeepingUpdate = "[dbo].[tra_BookKeeping_Update]";
        public const string BookKeepingSelectByPrimaryKey = "[dbo].[tra_BookKeeping_SelectByPrimaryKey]";
        public const string BookKeepingSelectAll = "[dbo].[tra_BookKeeping_SelectAll]";
        public const string BookKeepingSelectByField = "[dbo].[tra_BookKeeping_SelectByField]";
        public const string BookKeepingDeleteByPrimaryKey = "[dbo].[tra_BookKeeping_DeleteByPrimaryKey]";
        public const string BookKeepingDeleteByField = "[dbo].[tra_BookKeeping_DeleteByField]";
        public const string BookKeepingReceivePayment = "[dbo].[res_ReceivePayment]";
        public const string BookKeepingSelectPaymentForCheckInVoucher = "[dbo].[tra_BookKeeping_SelectPaymentForCheckInVoucher]";
        public const string BookKeepingSelectPaymentForCheckInVoucherForReprint = "[dbo].[tra_BookKeeping_SelectPaymentForCheckInVoucherForReprint]";
        public const string BookKeepingTransactionVoid = "[dbo].[acc_TransactionVoid]";
        public const string BookKeepingTransactionDiscount_GiveDiscount = "[dbo].[acc_TransactionDiscount]";
        public const string BookKeepingTransactionDiscount_GetAllDicounts = "[dbo].[res_Folio_GetAllDicounts]";
        public const string BookKeepingTransaction_TransactionOverride = "[dbo].[acc_TransactionOverride]";
        public const string BookKeepingDistinctGeneralType = "[dbo].[tra_BookKeeping_DistinctGeneralType]";
        public const string BookKeepingUpdateInvoiceID = "[dbo].[tra_BookKeeping_UpdateInvoiceID]";
        public const string rpt_VoidReport = "[dbo].[rpt_VoidReport]";

        //SPs for  tra_BookKeeping_History
        public const string BookKeeping_HistoryInsert = "[dbo].[tra_BookKeeping_History_Insert]";
        public const string BookKeeping_HistoryUpdate = "[dbo].[tra_BookKeeping_History_Update]";
        public const string BookKeeping_HistorySelectByPrimaryKey = "[dbo].[tra_BookKeeping_History_SelectByPrimaryKey]";
        public const string BookKeeping_HistorySelectAll = "[dbo].[tra_BookKeeping_History_SelectAll]";
        public const string BookKeeping_HistorySelectByField = "[dbo].[tra_BookKeeping_History_SelectByField]";
        public const string BookKeeping_HistoryDeleteByPrimaryKey = "[dbo].[tra_BookKeeping_History_DeleteByPrimaryKey]";
        public const string BookKeeping_HistoryDeleteByField = "[dbo].[tra_BookKeeping_History_DeleteByField]";
        
        //SPs for  tra_Collection
        public const string CollectionInsert = "[dbo].[tra_Collection_Insert]";
        public const string CollectionUpdate = "[dbo].[tra_Collection_Update]";
        public const string CollectionSelectByPrimaryKey = "[dbo].[tra_Collection_SelectByPrimaryKey]";
        public const string CollectionSelectAll = "[dbo].[tra_Collection_SelectAll]";
        public const string CollectionSelectByField = "[dbo].[tra_Collection_SelectByField]";
        public const string CollectionDeleteByPrimaryKey = "[dbo].[tra_Collection_DeleteByPrimaryKey]";
        public const string CollectionDeleteByField = "[dbo].[tra_Collection_DeleteByField]";
        public const string CollectionTotalRevenueForQuarterForIR = "[dbo].[ir_TotalRevenueForQuarter]";

        //SPs for  acc_TaxSlabe
        public const string TaxSlabeInsert = "[dbo].[acc_TaxSlabe_Insert]";
        public const string TaxSlabeUpdate = "[dbo].[acc_TaxSlabe_Update]";
        public const string TaxSlabeSelectByPrimaryKey = "[dbo].[acc_TaxSlabe_SelectByPrimaryKey]";
        public const string TaxSlabeSelectAll = "[dbo].[acc_TaxSlabe_SelectAll]";
        public const string TaxSlabeSelectByField = "[dbo].[acc_TaxSlabe_SelectByField]";
        public const string TaxSlabeDeleteByPrimaryKey = "[dbo].[acc_TaxSlabe_DeleteByPrimaryKey]";
        public const string TaxSlabeDeleteByField = "[dbo].[acc_TaxSlabe_DeleteByField]";
        //SPs for  res_ReservationHistory
        public const string ReservationHistoryInsert = "[dbo].[res_ReservationHistory_Insert]";
        public const string ReservationHistoryUpdate = "[dbo].[res_ReservationHistory_Update]";
        public const string ReservationHistorySelectByPrimaryKey = "[dbo].[res_ReservationHistory_SelectByPrimaryKey]";
        public const string ReservationHistorySelectAll = "[dbo].[res_ReservationHistory_SelectAll]";
        public const string ReservationHistorySelectByField = "[dbo].[res_ReservationHistory_SelectByField]";
        public const string ReservationHistoryDeleteByPrimaryKey = "[dbo].[res_ReservationHistory_DeleteByPrimaryKey]";
        public const string ReservationHistoryDeleteByField = "[dbo].[res_ReservationHistory_DeleteByField]";
        //SPs for  res_ReservationUpdateLog
        public const string ReservationUpdateLogInsert = "[dbo].[res_ReservationUpdateLog_Insert]";
        public const string ReservationUpdateLogUpdate = "[dbo].[res_ReservationUpdateLog_Update]";
        public const string ReservationUpdateLogSelectByPrimaryKey = "[dbo].[res_ReservationUpdateLog_SelectByPrimaryKey]";
        public const string ReservationUpdateLogSelectAll = "[dbo].[res_ReservationUpdateLog_SelectAll]";
        public const string ReservationUpdateLogSelectByField = "[dbo].[res_ReservationUpdateLog_SelectByField]";
        public const string ReservationUpdateLogDeleteByPrimaryKey = "[dbo].[res_ReservationUpdateLog_DeleteByPrimaryKey]";
        public const string ReservationUpdateLogDeleteByField = "[dbo].[res_ReservationUpdateLog_DeleteByField]";

        //SPs for  tra_Journal
        public const string JournalInsert = "[dbo].[tra_Journal_Insert]";
        public const string JournalUpdate = "[dbo].[tra_Journal_Update]";
        public const string JournalSelectByPrimaryKey = "[dbo].[tra_Journal_SelectByPrimaryKey]";
        public const string JournalSelectAll = "[dbo].[tra_Journal_SelectAll]";
        public const string JournalSelectByField = "[dbo].[tra_Journal_SelectByField]";
        public const string JournalDeleteByPrimaryKey = "[dbo].[tra_Journal_DeleteByPrimaryKey]";
        public const string JournalDeleteByField = "[dbo].[tra_Journal_DeleteByField]";

        //SPs for  tra_Transaction
        public const string TransactionInsert = "[dbo].[tra_Transaction_Insert]";
        public const string TransactionUpdate = "[dbo].[tra_Transaction_Update]";
        public const string TransactionSelectByPrimaryKey = "[dbo].[tra_Transaction_SelectByPrimaryKey]";
        public const string TransactionSelectAll = "[dbo].[tra_Transaction_SelectAll]";
        public const string TransactionSelectByField = "[dbo].[tra_Transaction_SelectByField]";
        public const string TransactionDeleteByPrimaryKey = "[dbo].[tra_Transaction_DeleteByPrimaryKey]";
        public const string TransactionDeleteByField = "[dbo].[tra_Transaction_DeleteByField]";
        public const string TransactionInsertDeposit = "[dbo].[tra_Transaction_InsertDeposit]";
        public const string TransactionPostRoomCharge = "[dbo].[res_PostRoomCharge]";
        public const string TransactionRefundDeposit = "[dbo].[tra_Transaction_RefundDeposit]";
        public const string TransactionSelectAllReservationDepositByReservationID = "[dbo].[tra_Transaction_SelectAllReservationDepositByReservationID]";
        public const string TransactionGetAllTransaction = "[dbo].[tra_Transaction_GetAllTransaction]";
        public const string TransactionGetAllDeposit = "[dbo].[tra_Transaction_GetAllDeposit]";
        public const string TransactionTransferDeposit = "[dbo].[tra_Transaction_TransferDeposit]";
        public const string Transaction_ItemPosting = "[dbo].[mst_ItemPosting]";
        public const string Transaction_RefundPayment = "[dbo].[acc_RefundPayment]";

        //SPs for  tra_Invoice
        public const string InvoiceInsert = "[tra_Invoice_Insert]";
        public const string InvoiceUpdate = "[tra_Invoice_Update]";
        public const string InvoiceSelectByPrimaryKey = "[tra_Invoice_SelectByPrimaryKey]";
        public const string InvoiceSelectAll = "[tra_Invoice_SelectAll]";
        public const string InvoiceSelectByField = "[tra_Invoice_SelectByField]";
        public const string InvoiceDeleteByPrimaryKey = "[tra_Invoice_DeleteByPrimaryKey]";
        public const string InvoiceDeleteByField = "[tra_Invoice_DeleteByField]";
        public const string SelectAll4RePrint = "[tra_Invoice_SelectAll4RePrint]";
        public const string Invoice_SelectInvoicesOfCompany = "[tra_Invoice_Select]";
        public const string Invoice_AgentReceivePayment = "[acc_AgentReceivePayment]";


        public const string ReservationSelectRoomsToSell = "[res_Reservation_RoomsToSell]";
        public const string ReservationSelectGetAllVacantRoom = "[mst_Room_GetAllVacantRoom]";
        public const string RoomSearchRoomAndKey = "[dbo].[mst_SearchKeyAndRoom]";
        public const string ReservationSelectGetReservations = "[res_Reservation_GetReservations]";
        public const string RoomBlockSelectAllBlockRoomsForReservation = "[mst_BlockedRooms_GetAllBlockRooms]";
        public const string Reservation_SelectReservationsForExtendStay = "[res_Reservation_GetReservationsForExtendStay]";

        //SPs for  tra_Transfer_Deposit_Join
        public const string Transfer_Deposit_JoinInsert = "[dbo].[tra_Transfer_Deposit_Join_Insert]";
        public const string Transfer_Deposit_JoinUpdate = "[dbo].[tra_Transfer_Deposit_Join_Update]";
        public const string Transfer_Deposit_JoinSelectByPrimaryKey = "[dbo].[tra_Transfer_Deposit_Join_SelectByPrimaryKey]";
        public const string Transfer_Deposit_JoinSelectAll = "[dbo].[tra_Transfer_Deposit_Join_SelectAll]";
        public const string Transfer_Deposit_JoinSelectByField = "[dbo].[tra_Transfer_Deposit_Join_SelectByField]";
        public const string Transfer_Deposit_JoinDeleteByPrimaryKey = "[dbo].[tra_Transfer_Deposit_Join_DeleteByPrimaryKey]";
        public const string Transfer_Deposit_JoinDeleteByField = "[dbo].[tra_Transfer_Deposit_Join_DeleteByField]";

        //SPs for  mst_GuestManagementNote
        public const string GuestManagementNoteInsert = "[dbo].[mst_GuestManagementNote_Insert]";
        public const string GuestManagementNoteUpdate = "[dbo].[mst_GuestManagementNote_Update]";
        public const string GuestManagementNoteSelectByPrimaryKey = "[dbo].[mst_GuestManagementNote_SelectByPrimaryKey]";
        public const string GuestManagementNoteSelectAll = "[dbo].[mst_GuestManagementNote_SelectAll]";
        public const string GuestManagementNoteSelectByField = "[dbo].[mst_GuestManagementNote_SelectByField]";
        public const string GuestManagementNoteDeleteByPrimaryKey = "[dbo].[mst_GuestManagementNote_DeleteByPrimaryKey]";
        public const string GuestManagementNoteDeleteByField = "[dbo].[mst_GuestManagementNote_DeleteByField]";
        public const string GuestManagementNoteSelectForList = "[dbo].[mst_GuestManagementNote_SelectForList]";


        //SPs for  mst_GuestComments
        public const string GuestCommentsInsert = "[dbo].[mst_GuestComments_Insert]";
        public const string GuestCommentsUpdate = "[dbo].[mst_GuestComments_Update]";
        public const string GuestCommentsSelectByPrimaryKey = "[dbo].[mst_GuestComments_SelectByPrimaryKey]";
        public const string GuestCommentsSelectAll = "[dbo].[mst_GuestComments_SelectAll]";
        public const string GuestCommentsSelectByField = "[dbo].[mst_GuestComments_SelectByField]";
        public const string GuestCommentsDeleteByPrimaryKey = "[dbo].[mst_GuestComments_DeleteByPrimaryKey]";
        public const string GuestCommentsDeleteByField = "[dbo].[mst_GuestComments_DeleteByField]";
        public const string GuestCommentsSelectAllForList = "[dbo].[mst_GuestComments_SelectAllForList]";
        //SPs for  mst_GuestComplaint
        public const string GuestComplaintInsert = "[dbo].[mst_GuestComplaint_Insert]";
        public const string GuestComplaintUpdate = "[dbo].[mst_GuestComplaint_Update]";
        public const string GuestComplaintSelectByPrimaryKey = "[dbo].[mst_GuestComplaint_SelectByPrimaryKey]";
        public const string GuestComplaintSelectAll = "[dbo].[mst_GuestComplaint_SelectAll]";
        public const string GuestComplaintSelectByField = "[dbo].[mst_GuestComplaint_SelectByField]";
        public const string GuestComplaintDeleteByPrimaryKey = "[dbo].[mst_GuestComplaint_DeleteByPrimaryKey]";
        public const string GuestComplaintDeleteByField = "[dbo].[mst_GuestComplaint_DeleteByField]";
        public const string GuestComplaintSelectAllForLisr = "[dbo].[mst_GuestComplaint_SelectAllForList]";
        //SPs for  mst_FrontDeskAlert
        public const string FrontDeskAlertInsert = "[dbo].[mst_FrontDeskAlert_Insert]";
        public const string FrontDeskAlertUpdate = "[dbo].[mst_FrontDeskAlert_Update]";
        public const string FrontDeskAlertSelectByPrimaryKey = "[dbo].[mst_FrontDeskAlert_SelectByPrimaryKey]";
        public const string FrontDeskAlertSelectAll = "[dbo].[mst_FrontDeskAlert_SelectAll]";
        public const string FrontDeskAlertSelectByField = "[dbo].[mst_FrontDeskAlert_SelectByField]";
        public const string FrontDeskAlertDeleteByPrimaryKey = "[dbo].[mst_FrontDeskAlert_DeleteByPrimaryKey]";
        public const string FrontDeskAlertDeleteByField = "[dbo].[mst_FrontDeskAlert_DeleteByField]";
        //SPs for  mst_FrontDeskAlertMaster
        public const string FrontDeskAlertMasterInsert = "[dbo].[mst_FrontDeskAlertMaster_Insert]";
        public const string FrontDeskAlertMasterUpdate = "[dbo].[mst_FrontDeskAlertMaster_Update]";
        public const string FrontDeskAlertMasterSelectByPrimaryKey = "[dbo].[mst_FrontDeskAlertMaster_SelectByPrimaryKey]";
        public const string FrontDeskAlertMasterSelectAll = "[dbo].[mst_FrontDeskAlertMaster_SelectAll]";
        public const string FrontDeskAlertMasterSelectByField = "[dbo].[mst_FrontDeskAlertMaster_SelectByField]";
        public const string FrontDeskAlertMasterDeleteByPrimaryKey = "[dbo].[mst_FrontDeskAlertMaster_DeleteByPrimaryKey]";
        public const string FrontDeskAlertMasterDeleteByField = "[dbo].[mst_FrontDeskAlertMaster_DeleteByField]";
        public const string GetAlertListSelect = "[dbo].[mst_FrontDeskAlertMaster_SelectAlertList]";

        //SPs for  res_CheckinTimeLog
        public const string CheckinTimeLogInsert = "[dbo].[res_CheckinTimeLog_Insert]";
        public const string CheckinTimeLogUpdate = "[dbo].[res_CheckinTimeLog_Update]";
        public const string CheckinTimeLogSelectByPrimaryKey = "[dbo].[res_CheckinTimeLog_SelectByPrimaryKey]";
        public const string CheckinTimeLogSelectAll = "[dbo].[res_CheckinTimeLog_SelectAll]";
        public const string CheckinTimeLogSelectByField = "[dbo].[res_CheckinTimeLog_SelectByField]";
        public const string CheckinTimeLogDeleteByPrimaryKey = "[dbo].[res_CheckinTimeLog_DeleteByPrimaryKey]";
        public const string CheckinTimeLogDeleteByField = "[dbo].[res_CheckinTimeLog_DeleteByField]";
        public const string CheckinTimeLogSelectCheckInLog = "[dbo].[res_CheckinTimeLog_SelectCheckInLog]";

        //SPs for Reports
        public const string RPTRevenueDetail = "[dbo].[rpt_RevenueDetail]";
        public const string RPTCollectionSummary = "[dbo].[rpt_CollectionSummary]";
        public const string RPTCollectionSummary_Summary = "[dbo].[rpt_CollectionSummary_Summary]";
        public const string RPTCashReport = "[dbo].[rpt_CashReport]";
        public const string RPTRoomDeposit = "[dbo].[rpt_RoomDeposit]";
        public const string RPTFolioStatement = "[dbo].[rpt_PrintFolioStatement]";
        public const string RPTOccupancyChartByBlockAndRoomType = "[dbo].[rpt_OccupancyChartByBlockAndRoomType]";
        public const string RPTOccupancyChartByBlockType = "[dbo].[rpt_OccupancyChartByBlockType]";
        public const string RPTYieldCalculation = "[dbo].[rpt_YeildCalculation]";
        public const string RPTOccupancyChartByBlockAndRateCard = "[dbo].[rpt_OccupancyChartByBlockAndRateCard]";
        public const string RPTRoomRentAdvance = "[dbo].[rpt_RoomRentAdvanced]";
        public const string RPTRoomRentAdvance_Summary = "[dbo].[rpt_RoomRentAdvanced_Summary]";
        public const string RPTRoomRentAdvance_ClosingBal = "[dbo].[rpt_RoomRentAdvanced_ClosingBal]";
        public const string RPTBillFormat = "[dbo].[rpt_Reservation_BillFormat]";
        public const string RPTInvoiceReservationDetail = "[dbo].[rpt_Invoice_ReservationDetail]";
        public const string RPTBillFormat_Summary = "[dbo].[rpt_Reservation_BillFormatSummary]";
        public const string RPTRoomHistory = "[dbo].[rpt_RoomHistory]";
        public const string RPTCancellationCharges = "[dbo].[rpt_CancellationCharges]";
        public const string RPTRetentionCharges = "[dbo].[rpt_RetentionCharges]";
        public const string RPTCompanyPosting = "[dbo].[rpt_CompanyPosting]";
        public const string RPTBillFormat_Summary4CompanyInvoice = "[dbo].[rpt_Reservation_BillFormatSummary4CompanyInvoice]";

        public const string GenerateLedgerReports = "[dbo].[acc_GenerateLedgerReports]";
        public const string SelectGeneralData_ForLedgerReport = "[dbo].[SelectGeneralData_ForLedgerReport]";

        public const string res_BlockDateRate_BillingToCompany = "[dbo].[res_BlockDateRate_BillingToCompany]";

        public const string POS_SelectCheckInGuestList = "[dbo].[POS_SelectCheckInGuestList]";
        public const string RPTInfraServiceCharges = "[dbo].[rpt_InfraServiceCharge]";



        //SPs for  res_ForeignNationalInfo
        public const string ForeignNationalInfoInsert = "[dbo].[res_ForeignNationalInfo_Insert]";
        public const string ForeignNationalInfoUpdate = "[dbo].[res_ForeignNationalInfo_Update]";
        public const string ForeignNationalInfoSelectByPrimaryKey = "[dbo].[res_ForeignNationalInfo_SelectByPrimaryKey]";
        public const string ForeignNationalInfoSelectAll = "[dbo].[res_ForeignNationalInfo_SelectAll]";
        public const string ForeignNationalInfoSelectByField = "[dbo].[res_ForeignNationalInfo_SelectByField]";
        public const string ForeignNationalInfoDeleteByPrimaryKey = "[dbo].[res_ForeignNationalInfo_DeleteByPrimaryKey]";
        public const string ForeignNationalInfoDeleteByField = "[dbo].[res_ForeignNationalInfo_DeleteByField]";
        public const string RPTCFormReport = "[dbo].[rpt_CFormReport]";
        public const string TaxCalculator = "[dbo].[TaxCalculator_HARI]";

        //SPs for  res_TroubleTicket
        public const string TroubleTicketInsert = "[dbo].[res_TroubleTicket_Insert]";
        public const string TroubleTicketUpdate = "[dbo].[res_TroubleTicket_Update]";
        public const string TroubleTicketSelectByPrimaryKey = "[dbo].[res_TroubleTicket_SelectByPrimaryKey]";
        public const string TroubleTicketSelectAll = "[dbo].[res_TroubleTicket_SelectAll]";
        public const string TroubleTicketSelectByField = "[dbo].[res_TroubleTicket_SelectByField]";
        public const string TroubleTicketDeleteByPrimaryKey = "[dbo].[res_TroubleTicket_DeleteByPrimaryKey]";
        public const string TroubleTicketDeleteByField = "[dbo].[res_TroubleTicket_DeleteByField]";
        public const string TroubleTicketSelectList = "[dbo].[res_TroubleTicketSelectList]";

        //SPs for  res_ResAddOnServiceList
        public const string ResAddOnServiceListInsert = "[dbo].[res_ResAddOnServiceList_Insert]";
        public const string ResAddOnServiceListUpdate = "[dbo].[res_ResAddOnServiceList_Update]";
        public const string ResAddOnServiceListSelectByPrimaryKey = "[dbo].[res_ResAddOnServiceList_SelectByPrimaryKey]";
        public const string ResAddOnServiceListSelectAll = "[dbo].[res_ResAddOnServiceList_SelectAll]";
        public const string ResAddOnServiceListSelectByField = "[dbo].[res_ResAddOnServiceList_SelectByField]";
        public const string ResAddOnServiceListDeleteByPrimaryKey = "[dbo].[res_ResAddOnServiceList_DeleteByPrimaryKey]";
        public const string ResAddOnServiceListDeleteByField = "[dbo].[res_ResAddOnServiceList_DeleteByField]";
        public const string GuestSelectCurrentGuestListAddOnServices = "[dbo].[res_Reservation_SelectCurrentGuestList_ForAddOnServices]";
        public const string ResAddOnServiceListItemTypeTermIDServiceName = "[dbo].[res_ResAddOnServiceList_ItemType_TermID_ServiceName]";
        public const string ResAddOnServiceListSelectAllWithServiceName = "[dbo].[res_ResAddOnServiceList_SelectAllWithServiceName]";
        public const string ResAddOnServiceListSelectAllSelectAllSearchServices = "[dbo].[res_ResAddOnServiceList_SelectAllSearchServices]";

        //SPs for  res_Inquiry
        public const string InquiryInsert = "[dbo].[res_Inquiry_Insert]";
        public const string InquiryUpdate = "[dbo].[res_Inquiry_Update]";
        public const string InquirySelectByPrimaryKey = "[dbo].[res_Inquiry_SelectByPrimaryKey]";
        public const string InquirySelectAll = "[dbo].[res_Inquiry_SelectAll]";
        public const string InquirySelectByField = "[dbo].[res_Inquiry_SelectByField]";
        public const string InquiryDeleteByPrimaryKey = "[dbo].[res_Inquiry_DeleteByPrimaryKey]";
        public const string InquiryDeleteByField = "[dbo].[res_Inquiry_DeleteByField]";
        public const string Inquiryres_InquiryList = "[dbo].[res_InquiryList]";
        public const string CreditCardWiseCollectionReport = "[dbo].[rpt_CollectionReportCreditCardWise]";
        public const string EmailConfigSelectForMarketingEmail = "[dbo].[mst_EmailConfigSelectForMarketingEmail]";

        //SPs for  res_POSChargePerDay
        public const string POSChargePerDayInsert = "[res_POSChargePerDay_Insert]";
        public const string POSChargePerDayUpdate = "[res_POSChargePerDay_Update]";
        public const string POSChargePerDaySelectByPrimaryKey = "[res_POSChargePerDay_SelectByPrimaryKey]";
        public const string POSChargePerDaySelectAll = "[res_POSChargePerDay_SelectAll]";
        public const string POSChargePerDaySelectByField = "[res_POSChargePerDay_SelectByField]";
        public const string POSChargePerDayDeleteByPrimaryKey = "[res_POSChargePerDay_DeleteByPrimaryKey]";
        public const string POSChargePerDayDeleteByField = "[res_POSChargePerDay_DeleteByField]";
        public const string POSChargePerDaySelectByRateIDAndRoomTypeID = "[res_POSChargePerDay_SelectByRateIDAndRoomTypeID]";
    }
}

