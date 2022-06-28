using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQT.Symphony.BusinessLogic.IRMS.COMMON
{
    public class MasterDALConstant
    {
        //SPs for Reports
        public const string ReportProspectsList = "[dbo].[rpt_ProspectsList]";
        public const string ReportInvestorList = "[dbo].[rpt_InvestorList]";
        public const string ReportChannelPartnerList = "[dbo].[rpt_ChannelPartnerList]";
        public const string ReportSalesList = "[dbo].[rpt_SalesList]";
        public const string ReportBookedUnitList = "[dbo].[rpt_BookedUnitList]";
        public const string ReportPaymentAlerts = "[dbo].[rpt_PaymentAlerts]";
        public const string ReportPaymentReceipt = "[dbo].[rpt_PaymentReceipt]";
        public const string ReportActionLog = "[dbo].[rpt_ActionLog]";
        public const string ReportLogInLog = "[dbo].[rpt_LogInLog]";
        public const string ReprotTotalSalses = "[dbo].[rpt_TotalSales]";
        public const string ReprotPaymentDue = "[dbo].[rpt_PaymentDueReport]";
        public const string ReportInvestorTerm = "[dbo].[rpt_InvestorTerm]";
        public const string ReportInvestorBankDetail = "[dbo].[rpt_InvestorBankDetail]";
        public const string ReportInvestorDocumentation = "[dbo].[rpt_InvestorDocumentation]";
        public const string ReportConversionExecutive = "[dbo].[rpt_ConversionReportExecutive]";
        public const string ReportConversionExecutive_CP = "[dbo].[rpt_ConversionReportExecutive_CP]";
        public const string ReportConversionExecutive_RefThrough = "[dbo].[rpt_ConversionReportExecutive_RefThrough]";
        public const string ReportLocationAnalysis = "[dbo].[rpt_LocationAnalysis]";

        //SPs for  irm_ChannelPartner
        public const string ChannelPartnerInsert = "[dbo].[irm_ChannelPartner_Insert]";
        public const string ChannelPartnerUpdate = "[dbo].[irm_ChannelPartner_Update]";
        public const string ChannelPartnerSelectByPrimaryKey = "[dbo].[irm_ChannelPartner_SelectByPrimaryKey]";
        public const string ChannelPartnerSelectAll = "[dbo].[irm_ChannelPartner_SelectAll]";
        public const string ChannelPartnerSelectByField = "[dbo].[irm_ChannelPartner_SelectByField]";
        public const string ChannelPartnerDeleteByPrimaryKey = "[dbo].[irm_ChannelPartner_DeleteByPrimaryKey]";
        public const string ChannelPartnerDeleteByField = "[dbo].[irm_ChannelPartner_DeleteByField]";
        public const string ChannelPartnerSearchData = "[dbo].[irm_ChannelPartner_SearchProspectData]";
        public const string ChannelPartnerGetAllChannelPartnerForEmailSubscription = "[dbo].[irm_ChannelPartner_GetAllChannelPartnerForEmailSubscription]";
        public const string ChannelPartnerSelectDeletePermission = "[dbo].[irm_ChannelPartner_SelectDeletePermission]";
        public const string ChannelPartnerSelectAllForUserStatus = "[dbo].[irm_ChannelPartner_SelectALLForUserStatus]";

        //SPs for  irm_Prospects
        public const string ProspectsInsert = "[dbo].[irm_Prospects_Insert]";
        public const string ProspectsUpdate = "[dbo].[irm_Prospects_Update]";
        public const string ProspectsSelectByPrimaryKey = "[dbo].[irm_Prospects_SelectByPrimaryKey]";
        public const string ProspectsSelectAll = "[dbo].[irm_Prospects_SelectAll]";
        public const string ProspectsSelectByField = "[dbo].[irm_Prospects_SelectByField]";
        public const string ProspectsDeleteByPrimaryKey = "[dbo].[irm_Prospects_DeleteByPrimaryKey]";
        public const string ProspectsDeleteByField = "[dbo].[irm_Prospects_DeleteByField]";
        public const string ProspectsSearchData = "[dbo].[irm_Prospects_SearchProspectData]";
        public const string ProspectsGetAllProspectsForEmailSubscription = "[dbo].[irm_Prospects_GetAllProspectsForEmailSubscription]";
        //SPs for  irm_Investor
        public const string InvestorInsert = "[dbo].[irm_Investor_Insert]";
        public const string InvestorUpdate = "[dbo].[irm_Investor_Update]";
        public const string InvestorSelectByPrimaryKey = "[dbo].[irm_Investor_SelectByPrimaryKey]";
        public const string InvestorSelectAll = "[dbo].[irm_Investor_SelectAll]";
        public const string InvestorSelectByField = "[dbo].[irm_Investor_SelectByField]";
        public const string InvestorDeleteByPrimaryKey = "[dbo].[irm_Investor_DeleteByPrimaryKey]";
        public const string InvestorDeleteByField = "[dbo].[irm_Investor_DeleteByField]";
        public const string InvestorSearchData = "[dbo].[irm_Investor_SelectAllSearch]";
        public const string InvestorNewSearchData = "[dbo].[irm_Investor_SelectAllNewSearch]";
        public const string InvestorGetPaymentList = "[dbo].[irm_Investor_GetInvestorPaymentList]";
        public const string InvestorGetPaymentScheduleDetail = "[dbo].[irm_Investor_GetInvestorPaymentScheduleDetail]";
        public const string InvestorUnitInformation = "[dbo].[Investor_DashBoard_UnitInformation]";
        public const string InvestorGetAllInvestorForEmailSubscription = "[dbo].[irm_Investor_GetAllInvestorForEmailSubscription]";
        public const string InvestorGetAllInvestorForActiveInactive = "[dbo].[irm_Investor_SelectAllForActiveDeActive]";
        public const string InvestorSelectForInvestorUpdateIndication = "[dbo].[irm_Investor_SelectForInvestorUpdateIndication]";
        public const string InvestorSelectGetCoOrdinators = "[dbo].[irm_Investor_GetCoOrdinators]";
        public const string InvestorSelectInvestorsForFrontDesk = "[dbo].[irm_Investor_SelectAllForFrontDesk]";
        public const string InvestorSelectInvestorEmailAddress = "[dbo].[irm_Investor_SelectInvestorEmailAddress]";
        public const string InvestorDetailsReportData = "[dbo].[irm_InvestorDetailReportData]";

        //SPs for  irm_SalesTeam
        public const string SalesTeamInsert = "[dbo].[irm_SalesTeam_Insert]";
        public const string SalesTeamUpdate = "[dbo].[irm_SalesTeam_Update]";
        public const string SalesTeamSelectByPrimaryKey = "[dbo].[irm_SalesTeam_SelectByPrimaryKey]";
        public const string SalesTeamSelectAll = "[dbo].[irm_SalesTeam_SelectAll]";
        public const string SalesTeamSelectByField = "[dbo].[irm_SalesTeam_SelectByField]";
        public const string SalesTeamDeleteByPrimaryKey = "[dbo].[irm_SalesTeam_DeleteByPrimaryKey]";
        public const string SalesTeamDeleteByField = "[dbo].[irm_SalesTeam_DeleteByField]";
        public const string SalesTeamGetAllSalesForEmailSubscription = "[dbo].[irm_SalesTeam_GetAllSalesForEmailSubscription]";

        //SPs for  dms_Documents
        public const string DocumentsInsert = "[dbo].[dms_Documents_Insert]";
        public const string DocumentsUpdate = "[dbo].[dms_Documents_Update]";
        public const string DocumentsSelectByPrimaryKey = "[dbo].[dms_Documents_SelectByPrimaryKey]";
        public const string DocumentsSelectAll = "[dbo].[dms_Documents_SelectAll]";
        public const string DocumentsSelectByField = "[dbo].[dms_Documents_SelectByField]";
        public const string DocumentsDeleteByPrimaryKey = "[dbo].[dms_Documents_DeleteByPrimaryKey]";
        public const string DocumentsDeleteByField = "[dbo].[dms_Documents_DeleteByField]";
        public const string DocumentsDeleteByPropertyID = "[dbo].[dms_Documents_DeleteByPropertyID]";
        public const string DocumentsDeleteByAssociationID = "[dbo].[dms_Documents_DeleteByAssociationID]";
        public const string DocumentsSearchDocument = "[dbo].[dms_Documents_SearchDocument]";
        public const string DocumentsSelectAllDocument = "[dbo].[dms_Documents_SelectAllDocument]";
        public const string DocumentsSelectDocumentGrid = "[dbo].[dms_Documents_SelectDocumentGrid]";
        public const string DocumentsSelectDocumentByPropertyID = "[dbo].[dms_Documents_SelectDocumentByPropertyID]";
        //public const string DocumentsSelectDocumentByCriteria = "[dbo].[dms_Documents_SearchDocumentByCriteria]";
        public const string DocumentsSelectDocumentByCriteria = "[dbo].[dms_Documents_SearchDocumentByCriteriaWithView]";

        //SPs for  irm_InvestorsUnit
        public const string InvestorsUnitInsert = "[dbo].[irm_InvestorsUnit_Insert]";
        public const string InvestorsUnitUpdate = "[dbo].[irm_InvestorsUnit_Update]";
        public const string InvestorsUnitSelectByPrimaryKey = "[dbo].[irm_InvestorsUnit_SelectByPrimaryKey]";
        public const string InvestorsUnitSelectAll = "[dbo].[irm_InvestorsUnit_SelectAll]";
        public const string InvestorsUnitSelectByField = "[dbo].[irm_InvestorsUnit_SelectByField]";
        public const string InvestorsUnitDeleteByPrimaryKey = "[dbo].[irm_InvestorsUnit_DeleteByPrimaryKey]";
        public const string InvestorsUnitDeleteByField = "[dbo].[irm_InvestorsUnit_DeleteByField]";
        public const string InvestorsUnitSearchData = "[dbo].[irm_InvestorsUnit_SearchData]";
        public const string InvestorsUnitCheckDuplicate = "[dbo].[irm_InvestorsUnit_CheckDuplicate]";
        public const string InvestorsUnitSelectUnitDetails = "[dbo].[irm_InvestorUnit_SelectUnitDetails]";
        public const string InvestorsUnitCreateStandardSchedule = "[dbo].[irm_InvestorsUnit_CreateStandardSchedule]";
        public const string InvestorsUnitSelectInvestorsUnitForResell = "[dbo].[irm_InvestorsUnit_SelectInvestorsUnitForResell]";
        public const string InvestorsUnitInsertReSell = "[dbo].[irm_InvestorsUnit_Insert_ReSell]";

        //SPs for  PaymentSchedule
        public const string PaymentScheduleInsert = "[dbo].[irm_InvestorPaymentSchedule_Insert]";
        public const string PaymentScheduleInsertNew = "[dbo].[irm_InvestorPaymentSchedule_InsertNew]";
        public const string PaymentScheduleDeleteByInvestorRoomID = "[dbo].[irm_InvestorPaymentSchedule_DeleteByInvestorRoomID]";
        public const string PaymentScheduleUpdate = "[dbo].[irm_InvestorPaymentSchedule_Update]";
        public const string PaymentScheduleSelectByPrimaryKey = "[dbo].[irm_InvestorPaymentSchedule_SelectByPrimaryKey]";
        public const string PaymentScheduleSelectAll = "[dbo].[irm_InvestorPaymentSchedule_SelectAll]";
        public const string PaymentScheduleSelectByField = "[dbo].[irm_InvestorPaymentSchedule_SelectByField]";
        public const string PaymentScheduleDeleteByPrimaryKey = "[dbo].[irm_InvestorPaymentSchedule_DeleteByPrimaryKey]";
        public const string PaymentScheduleDeleteByField = "[dbo].[irm_InvestorPaymentSchedule_DeleteByField]";
        public const string PaymentScheduleSearchData = "[dbo].[irm_InvestorPaymentSchedule_SearchData]";
        public const string PaymentScheduleGetSchedule = "[dbo].[irm_InvestorPaymentSchedule_GetSchedule]";
        public const string PaymentScheduleGetMaxAmount = "[dbo].[Inv_irm_InvestorPaymentSchedule_ScheduleWithInvPayment]";
        public const string InvestorScheduleLoadStadScheduleAgain = "[dbo].[irm_InvestorSchedule_LoadStadScheduleAgain]";
        public const string PaymentScheduleGetByInvestorRoomID = "[dbo].[irm_InvestorPaymentSchedule_GetByInvestorRoomIDNew]";
        public const string PaymentScheduleSearchDataNew = "[dbo].[irm_InvestorPaymentSchedule_SearchDataNew]";
        public const string PaymentScheduleSelectInvestorPaymentDetails = "[dbo].[irm_InvestorPaymentSchedule_SelectInvestorPaymentDetails]";
        public const string PaymentScheduleGetAllByInvestorRoomID = "[dbo].[irm_InvestorPaymentSchedule_GetAllByInvestorRoomID]";
        public const string PaymentScheduleGetLadgerStatement = "[dbo].[irm_InvestorPaymentSchedule_GetLadgerStatement]";

        //SPs for  irm_InvestorPaymentReceipt
        public const string InvestorPaymentReceiptInsert = "[dbo].[irm_InvestorPaymentReceipt_Insert]";
        public const string InvestorPaymentReceiptUpdate = "[dbo].[irm_InvestorPaymentReceipt_Update]";
        public const string InvestorPaymentReceiptSelectByPrimaryKey = "[dbo].[irm_InvestorPaymentReceipt_SelectByPrimaryKey]";
        public const string InvestorPaymentReceiptSelectAll = "[dbo].[irm_InvestorPaymentReceipt_SelectAll]";
        public const string InvestorPaymentReceiptSelectByField = "[dbo].[irm_InvestorPaymentReceipt_SelectByField]";
        public const string InvestorPaymentReceiptDeleteByPrimaryKey = "[dbo].[irm_InvestorPaymentReceipt_DeleteByPrimaryKey]";
        public const string InvestorPaymentReceiptDeleteByField = "[dbo].[irm_InvestorPaymentReceipt_DeleteByField]";
        public const string InvestorPaymentReceiptSearchDataSet = "[dbo].[irm_InvestorPaymentReceipt_SearchData]";
        public const string InvestorPaymentReceiptSearchDataSetForTax = "[dbo].[irm_InvestorPaymentReceipt_SearchDataForTax]";
        public const string InvestorTaxAndInsuranceReceiptList = "[dbo].[irm_InvestorPaymentReceipt_GetTaxInsuranceReceipt]";
        public const string InvestorPaymentReceiptSelectTaxAndInsuranceData = "[dbo].[irm_InvestorPaymentReceipt_GetPropertyTaxAndReceiptData]";
        public const string InvestorPaymentReceiptSelectReceiptDetails = "[dbo].[irm_InvestorPaymentReceipt_SelectReceiptDetails]";
        public const string InvestorPaymentReceiptSearchPaymentReceiptData = "[dbo].[irm_InvestorPaymentReceipt_SearchPaymentReceiptData]";
        public const string InvestorsUnitSelectPropertyName = "[dbo].[irm_InvestorsUnit_SelectPropertyName]";
        public const string InvestorPaymentReceiptSelectPaymentReceipt = "[dbo].[irm_InvestorPaymentReceipt_SelectPaymentReceipt]";
        public const string InvestorTaxGetPropertyName = "[dbo].[irm_PropertyTax_SelectPropertyName]";

        //SPs for  mst_UnitTypeMarketRate
        public const string UnitTypeMarketRateInsert = "[dbo].[mst_UnitTypeMarketRate_Insert]";
        public const string UnitTypeMarketRateUpdate = "[dbo].[mst_UnitTypeMarketRate_Update]";
        public const string UnitTypeMarketRateSelectByPrimaryKey = "[dbo].[mst_UnitTypeMarketRate_SelectByPrimaryKey]";
        public const string UnitTypeMarketRateSelectAll = "[dbo].[mst_UnitTypeMarketRate_SelectAll]";
        public const string UnitTypeMarketRateSelectByField = "[dbo].[mst_UnitTypeMarketRate_SelectByField]";
        public const string UnitTypeMarketRateDeleteByPrimaryKey = "[dbo].[mst_UnitTypeMarketRate_DeleteByPrimaryKey]";
        public const string UnitTypeMarketRateDeleteByField = "[dbo].[mst_UnitTypeMarketRate_DeleteByField]";
        public const string UnitTypeMarketRateSelectMarketRateData = "[dbo].[mst_UnitTypeMarketRate_SelectMarketRateData]";
        public const string UnitTypeMarketRateSearchData = "[dbo].[mst_UnitTypeMarketRate_SearchData]";
        public const string UnitTypeMarketRateDeleteByID = "[dbo].[mst_UnitTypeMarketRate_DeleteByID]";
        public const string UnitTypeMarketDrawChart = "[dbo].[mst_UnitTypeMarketRate_DrawChart]";
        public const string UnitTypeMarketSelectData = "[dbo].[mst_UnitTypeMarketRate_SelectData]";
        public const string UnitTypeMarketSelectGridData = "[dbo].[mst_UnitTypeMarketRate_SelectGridData]";
        public const string UnitTypeMarketSelectDate = "[dbo].[mst_UnitTypeMarketRate_SelectDate]";

        //SPs for  mst_EMailTmplts
        public const string EMailTmpltsInsert = "[dbo].[mst_EMailTemplates_Insert]";
        public const string EMailTmpltsUpdate = "[dbo].[mst_EMailTemplates_Update]";
        public const string EMailTmpltsSelectByPrimaryKey = "[dbo].[mst_EMailTemplates_SelectByPrimaryKey]";
        public const string EMailTmpltsSelectAll = "[dbo].[mst_EMailTemplates_SelectAll]";
        public const string EMailTmpltsSelectByField = "[dbo].[mst_EMailTemplates_SelectByField]";
        public const string EMailTmpltsDeleteByPrimaryKey = "[dbo].[mst_EMailTemplates_DeleteByPrimaryKey]";
        public const string EMailTmpltsDeleteByField = "[dbo].[mst_EMailTemplates_DeleteByField]";
        public const string EMailTmpltsSearchData = "[dbo].[mst_EMailTemplates_SearchData]";
        public const string EMailTmpltsGetDataByTitle = "[dbo].[mst_EMailTemplates_GetDataByProperty]";

        //SPs for  irs_ReservationVoucher
        public const string ReservationVoucherInsert = "[dbo].[irs_ReservationVoucher_Insert]";
        public const string ReservationVoucherUpdate = "[dbo].[irs_ReservationVoucher_Update]";
        public const string ReservationVoucherSelectByPrimaryKey = "[dbo].[irs_ReservationVoucher_SelectByPrimaryKey]";
        public const string ReservationVoucherSelectAll = "[dbo].[irs_ReservationVoucher_SelectAll]";
        public const string ReservationVoucherSelectByField = "[dbo].[irs_ReservationVoucher_SelectByField]";
        public const string ReservationVoucherDeleteByPrimaryKey = "[dbo].[irs_ReservationVoucher_DeleteByPrimaryKey]";
        public const string ReservationVoucherDeleteByField = "[dbo].[irs_ReservationVoucher_DeleteByField]";
        public const string ReservationVoucherSelectAll_ForFrontDesk_ByInvestorID = "[dbo].[irs_ReservationVoucher_SelectAll_ForFrontDesk_ByInvestorID]";
        public const string ReservationVoucherUpdate_ReservationAndAllocatedRoomID = "[dbo].[irs_ReservationVoucher_Update_ReservationAndAllocatedRoomID]";
        public const string ReservationVoucher_VoucherList = "[dbo].[irs_SelectReservationVoucherList]";


        //SPs for  mst_RentPayOutPerQuarter
        public const string RentPayOutPerQuarterInsert = "[dbo].[mst_RentPayOutPerQuarter_Insert]";
        public const string RentPayOutPerQuarterUpdate = "[dbo].[mst_RentPayOutPerQuarter_Update]";
        public const string RentPayOutPerQuarterSelectByPrimaryKey = "[dbo].[mst_RentPayOutPerQuarter_SelectByPrimaryKey]";
        public const string RentPayOutPerQuarterSelectAll = "[dbo].[mst_RentPayOutPerQuarter_SelectAll]";
        public const string RentPayOutPerQuarterSelectByField = "[dbo].[mst_RentPayOutPerQuarter_SelectByField]";
        public const string RentPayOutPerQuarterDeleteByPrimaryKey = "[dbo].[mst_RentPayOutPerQuarter_DeleteByPrimaryKey]";
        public const string RentPayOutPerQuarterDeleteByField = "[dbo].[mst_RentPayOutPerQuarter_DeleteByField]";
        public const string RentPayoutQuarterSetup_CheckDateOverlap = "[dbo].[mst_RentPayoutQuarterSetup_CheckDateOverlap]";
        public const string RentPayoutInvestorRentPayoutPerQuarter = "[dbo].[irm_InvestorRentPayoutPerQuarter_SellDate]";
        public const string RentPayOutPerQuarterSelectQuarterbyDate = "[dbo].[mst_RentPayoutQuarterSetup_SelectQuarterbyDate]";
        public const string RentPayOutPerQuarterSelectTop4QuarterWithIncome = "[dbo].[mst_RentPayoutQuarterSetup_WithIncome]";

        //SPs for  mst_RentPayoutQuarterSetup
        public const string RentPayoutQuarterSetupInsert = "[dbo].[mst_RentPayoutQuarterSetup_Insert]";
        public const string RentPayoutQuarterSetupUpdate = "[dbo].[mst_RentPayoutQuarterSetup_Update]";
        public const string RentPayoutQuarterSetupSelectByPrimaryKey = "[dbo].[mst_RentPayoutQuarterSetup_SelectByPrimaryKey]";
        public const string RentPayoutQuarterSetupSelectAll = "[dbo].[mst_RentPayoutQuarterSetup_SelectAll]";
        public const string RentPayoutQuarterSetupSelectByField = "[dbo].[mst_RentPayoutQuarterSetup_SelectByField]";
        public const string RentPayoutQuarterSetupDeleteByPrimaryKey = "[dbo].[mst_RentPayoutQuarterSetup_DeleteByPrimaryKey]";
        public const string RentPayoutQuarterSetupDeleteByField = "[dbo].[mst_RentPayoutQuarterSetup_DeleteByField]";

        //SPs for  irm_InsuranceDetails
        public const string InsuranceDetailsInsert = "[dbo].[irm_InsuranceDetails_Insert]";
        public const string InsuranceDetailsUpdate = "[dbo].[irm_InsuranceDetails_Update]";
        public const string InsuranceDetailsSelectByPrimaryKey = "[dbo].[irm_InsuranceDetails_SelectByPrimaryKey]";
        public const string InsuranceDetailsSelectAll = "[dbo].[irm_InsuranceDetails_SelectAll]";
        public const string InsuranceDetailsSelectByField = "[dbo].[irm_InsuranceDetails_SelectByField]";
        public const string InsuranceDetailsDeleteByPrimaryKey = "[dbo].[irm_InsuranceDetails_DeleteByPrimaryKey]";
        public const string InsuranceDetailsDeleteByField = "[dbo].[irm_InsuranceDetails_DeleteByField]";
        public const string InsuranceDetailGetData = "[dbo].[irm_InsuranceDetails_GetData]";
    }
}

