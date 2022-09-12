using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQT.Symphony.BusinessLogic.Configuration.COMMON
{
    public class MasterConstant
    {

        //SPs for  res_ReservationPolicies
        public const string ReservationPoliciesInsert = "[dbo].[res_ReservationPolicies_Insert]";
        public const string ReservationPoliciesUpdate = "[dbo].[res_ReservationPolicies_Update]";
        public const string ReservationPoliciesSelectByPrimaryKey = "[dbo].[res_ReservationPolicies_SelectByPrimaryKey]";
        public const string ReservationPoliciesSelectAll = "[dbo].[res_ReservationPolicies_SelectAll]";
        public const string ReservationPoliciesSelectByField = "[dbo].[res_ReservationPolicies_SelectByField]";
        public const string ReservationPoliciesDeleteByPrimaryKey = "[dbo].[res_ReservationPolicies_DeleteByPrimaryKey]";
        public const string ReservationPoliciesDeleteByField = "[dbo].[res_ReservationPolicies_DeleteByField]";

        //SPs for  res_FolioConfig
        public const string FolioConfigInsert = "[dbo].[res_FolioConfig_Insert]";
        public const string FolioConfigUpdate = "[dbo].[res_FolioConfig_Update]";
        public const string FolioConfigSelectByPrimaryKey = "[dbo].[res_FolioConfig_SelectByPrimaryKey]";
        public const string FolioConfigSelectAll = "[dbo].[res_FolioConfig_SelectAll]";
        public const string FolioConfigSelectByField = "[dbo].[res_FolioConfig_SelectByField]";
        public const string FolioConfigDeleteByPrimaryKey = "[dbo].[res_FolioConfig_DeleteByPrimaryKey]";
        public const string FolioConfigDeleteByField = "[dbo].[res_FolioConfig_DeleteByField]";

        //SPs for  res_ReservationConfig
        public const string ReservationConfigInsert = "[dbo].[res_ReservationConfig_Insert]";
        public const string ReservationConfigUpdate = "[dbo].[res_ReservationConfig_Update]";
        public const string ReservationConfigSelectByPrimaryKey = "[dbo].[res_ReservationConfig_SelectByPrimaryKey]";
        public const string ReservationConfigSelectAll = "[dbo].[res_ReservationConfig_SelectAll]";
        public const string ReservationConfigSelectByField = "[dbo].[res_ReservationConfig_SelectByField]";
        public const string ReservationConfigDeleteByPrimaryKey = "[dbo].[res_ReservationConfig_DeleteByPrimaryKey]";
        public const string ReservationConfigDeleteByField = "[dbo].[res_ReservationConfig_DeleteByField]";
        public const string ReservationConfigSelectRetentionAccountID = "[dbo].[res_ReservationConfig_SelectRetentionAccountID]";
        public const string ReservationConfigSelectMaxCashLimitForRefund = "[dbo].[res_ReservationConfig_SelectMaxCashLimitForRefund]";

        //SPs for  hkp_HousekeepingConfig
        public const string HousekeepingConfigInsert = "[dbo].[hkp_HousekeepingConfig_Insert]";
        public const string HousekeepingConfigUpdate = "[dbo].[hkp_HousekeepingConfig_Update]";
        public const string HousekeepingConfigSelectByPrimaryKey = "[dbo].[hkp_HousekeepingConfig_SelectByPrimaryKey]";
        public const string HousekeepingConfigSelectAll = "[dbo].[hkp_HousekeepingConfig_SelectAll]";
        public const string HousekeepingConfigSelectByField = "[dbo].[hkp_HousekeepingConfig_SelectByField]";
        public const string HousekeepingConfigDeleteByPrimaryKey = "[dbo].[hkp_HousekeepingConfig_DeleteByPrimaryKey]";
        public const string HousekeepingConfigDeleteByField = "[dbo].[hkp_HousekeepingConfig_DeleteByField]";

        //SPs for  pos_POSConfig
        public const string POSConfigInsert = "[dbo].[pos_POSConfig_Insert]";
        public const string POSConfigUpdate = "[dbo].[pos_POSConfig_Update]";
        public const string POSConfigSelectByPrimaryKey = "[dbo].[pos_POSConfig_SelectByPrimaryKey]";
        public const string POSConfigSelectAll = "[dbo].[pos_POSConfig_SelectAll]";
        public const string POSConfigSelectByField = "[dbo].[pos_POSConfig_SelectByField]";
        public const string POSConfigDeleteByPrimaryKey = "[dbo].[pos_POSConfig_DeleteByPrimaryKey]";
        public const string POSConfigDeleteByField = "[dbo].[pos_POSConfig_DeleteByField]";

        //SPs for  mst_EMailTemplates
        public const string EMailTemplatesInsert = "[dbo].[mst_EMailTemplates_Insert]";
        public const string EMailTemplatesUpdate = "[dbo].[mst_EMailTemplates_Update]";
        public const string EMailTemplatesSelectByPrimaryKey = "[dbo].[mst_EMailTemplates_SelectByPrimaryKey]";
        public const string EMailTemplatesSelectAll = "[dbo].[mst_EMailTemplates_SelectAll]";
        public const string EMailTemplatesSelectByField = "[dbo].[mst_EMailTemplates_SelectByField]";
        public const string EMailTemplatesDeleteByPrimaryKey = "[dbo].[mst_EMailTemplates_DeleteByPrimaryKey]";
        public const string EMailTemplatesDeleteByField = "[dbo].[mst_EMailTemplates_DeleteByField]";
        public const string EmailTemplatesSearchData = "[dbo].[mst_EMailTemplates_SearchData]";
        public const string EmailTemplatesGetDataByProperty = "[dbo].[mst_EMailTemplates_GetDataByProperty]";

        //SPs for  mst_EmailConfig
        public const string EmailConfigInsert = "[dbo].[mst_EmailConfig_Insert]";
        public const string EmailConfigUpdate = "[dbo].[mst_EmailConfig_Update]";
        public const string EmailConfigSelectByPrimaryKey = "[dbo].[mst_EmailConfig_SelectByPrimaryKey]";
        public const string EmailConfigSelectAll = "[dbo].[mst_EmailConfig_SelectAll]";
        public const string EmailConfigSelectByField = "[dbo].[mst_EmailConfig_SelectByField]";
        public const string EmailConfigDeleteByPrimaryKey = "[dbo].[mst_EmailConfig_DeleteByPrimaryKey]";
        public const string EmailConfigDeleteByField = "[dbo].[mst_EmailConfig_DeleteByField]";

        //SPs for  mst_Language
        public const string LanguageInsert = "[dbo].[mst_Language_Insert]";
        public const string LanguageUpdate = "[dbo].[mst_Language_Update]";
        public const string LanguageSelectByPrimaryKey = "[dbo].[mst_Language_SelectByPrimaryKey]";
        public const string LanguageSelectAll = "[dbo].[mst_Language_SelectAll]";
        public const string LanguageSelectByField = "[dbo].[mst_Language_SelectByField]";
        public const string LanguageDeleteByPrimaryKey = "[dbo].[mst_Language_DeleteByPrimaryKey]";
        public const string LanguageDeleteByField = "[dbo].[mst_Language_DeleteByField]";

        //SPs for  mst_UOM
        public const string UOMInsert = "[dbo].[mst_UOM_Insert]";
        public const string UOMUpdate = "[dbo].[mst_UOM_Update]";
        public const string UOMSelectByPrimaryKey = "[dbo].[mst_UOM_SelectByPrimaryKey]";
        public const string UOMSelectAll = "[dbo].[mst_UOM_SelectAll]";
        public const string UOMSelectByField = "[dbo].[mst_UOM_SelectByField]";
        public const string UOMDeleteByPrimaryKey = "[dbo].[mst_UOM_DeleteByPrimaryKey]";
        public const string UOMDeleteByField = "[dbo].[mst_UOM_DeleteByField]";

        //SPs for  mst_Denomination
        public const string DenominationInsert = "[dbo].[mst_Denomination_Insert]";
        public const string DenominationUpdate = "[dbo].[mst_Denomination_Update]";
        public const string DenominationSelectByPrimaryKey = "[dbo].[mst_Denomination_SelectByPrimaryKey]";
        public const string DenominationSelectAll = "[dbo].[mst_Denomination_SelectAll]";
        public const string DenominationSelectByField = "[dbo].[mst_Denomination_SelectByField]";
        public const string DenominationDeleteByPrimaryKey = "[dbo].[mst_Denomination_DeleteByPrimaryKey]";
        public const string DenominationDeleteByField = "[dbo].[mst_Denomination_DeleteByField]";
        public const string DenominationSelectSearch = "[dbo].[mst_Denomination_SelectSearch]";

        //SPs for  mst_Currency
        public const string CurrencyInsert = "[dbo].[mst_Currency_Insert]";
        public const string CurrencyUpdate = "[dbo].[mst_Currency_Update]";
        public const string CurrencySelectByPrimaryKey = "[dbo].[mst_Currency_SelectByPrimaryKey]";
        public const string CurrencySelectAll = "[dbo].[mst_Currency_SelectAll]";
        public const string CurrencySelectByField = "[dbo].[mst_Currency_SelectByField]";
        public const string CurrencyDeleteByPrimaryKey = "[dbo].[mst_Currency_DeleteByPrimaryKey]";
        public const string CurrencyDeleteByField = "[dbo].[mst_Currency_DeleteByField]";

        //SPs for  mst_ExchangeRate
        public const string ExchangeRateInsert = "[dbo].[mst_ExchangeRate_Insert]";
        public const string ExchangeRateUpdate = "[dbo].[mst_ExchangeRate_Update]";
        public const string ExchangeRateSelectByPrimaryKey = "[dbo].[mst_ExchangeRate_SelectByPrimaryKey]";
        public const string ExchangeRateSelectAll = "[dbo].[mst_ExchangeRate_SelectAll]";
        public const string ExchangeRateSelectByField = "[dbo].[mst_ExchangeRate_SelectByField]";
        public const string ExchangeRateDeleteByPrimaryKey = "[dbo].[mst_ExchangeRate_DeleteByPrimaryKey]";
        public const string ExchangeRateDeleteByField = "[dbo].[mst_ExchangeRate_DeleteByField]";
        public const string ExchangeRateSearchData = "[dbo].[mst_ExchangeRate_SearchData]";
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

        //SPs for  mst_SMSTemplates
        public const string SMSTemplatesInsert = "[dbo].[mst_SMSTemplates_Insert]";
        public const string SMSTemplatesUpdate = "[dbo].[mst_SMSTemplates_Update]";
        public const string SMSTemplatesSelectByPrimaryKey = "[dbo].[mst_SMSTemplates_SelectByPrimaryKey]";
        public const string SMSTemplatesSelectAll = "[dbo].[mst_SMSTemplates_SelectAll]";
        public const string SMSTemplatesSelectByField = "[dbo].[mst_SMSTemplates_SelectByField]";
        public const string SMSTemplatesDeleteByPrimaryKey = "[dbo].[mst_SMSTemplates_DeleteByPrimaryKey]";
        public const string SMSTemplatesDeleteByField = "[dbo].[mst_SMSTemplates_DeleteByField]";
        public const string SMSTemplateSearchDate = "[dbo].[mst_SMSTemplates_SearchData]";
        //SPs for  mst_NewsLetters
        public const string NewsLettersInsert = "[dbo].[mst_NewsLetters_Insert]";
        public const string NewsLettersUpdate = "[dbo].[mst_NewsLetters_Update]";
        public const string NewsLettersSelectByPrimaryKey = "[dbo].[mst_NewsLetters_SelectByPrimaryKey]";
        public const string NewsLettersSelectAll = "[dbo].[mst_NewsLetters_SelectAll]";
        public const string NewsLettersSelectByField = "[dbo].[mst_NewsLetters_SelectByField]";
        public const string NewsLettersDeleteByPrimaryKey = "[dbo].[mst_NewsLetters_DeleteByPrimaryKey]";
        public const string NewsLettersDeleteByField = "[dbo].[mst_NewsLetters_DeleteByField]";
        public const string NewsLattersSearchData = "[dbo].[mst_NewsLetters_SearchDate]";

        //SPs for  con_ControlNumber
        public const string ControlNumberInsert = "[dbo].[con_ControlNumber_Insert]";
        public const string ControlNumberUpdate = "[dbo].[con_ControlNumber_Update]";
        public const string ControlNumberSelectByPrimaryKey = "[dbo].[con_ControlNumber_SelectByPrimaryKey]";
        public const string ControlNumberSelectAll = "[dbo].[con_ControlNumber_SelectAll]";
        public const string ControlNumberSelectByField = "[dbo].[con_ControlNumber_SelectByField]";
        public const string ControlNumberDeleteByPrimaryKey = "[dbo].[con_ControlNumber_DeleteByPrimaryKey]";
        public const string ControlNumberDeleteByField = "[dbo].[con_ControlNumber_DeleteByField]";
        //SPs for  hrm_Employee
        public const string EmployeeInsert = "[dbo].[hrm_Employee_Insert]";
        public const string EmployeeUpdate = "[dbo].[hrm_Employee_Update]";
        public const string EmployeeSelectByPrimaryKey = "[dbo].[hrm_Employee_SelectByPrimaryKey]";
        public const string EmployeeSelectAll = "[dbo].[hrm_Employee_SelectAll]";
        public const string EmployeeSelectByField = "[dbo].[hrm_Employee_SelectByField]";
        public const string EmployeeDeleteByPrimaryKey = "[dbo].[hrm_Employee_DeleteByPrimaryKey]";
        public const string EmployeeDeleteByField = "[dbo].[hrm_Employee_DeleteByField]";
        public const string EmployeeSelectAllSearch = "[dbo].[hrm_Employee_SelectAllSearch]";
        public const string EmployeeSelectEmployeeForUser = "[dbo].[hrm_Employee_SelectEmployeeForUser]";
        public const string EmployeeSelectAllEmployeeForEmailSubscription = "[dbo].[hrm_Employee_GetAllEmployeeForEmailSubscription]";

        //SPs for  mst_Address
        public const string AddressInsert = "[dbo].[mst_Address_Insert]";
        public const string AddressUpdate = "[dbo].[mst_Address_Update]";
        public const string AddressSelectByPrimaryKey = "[dbo].[mst_Address_SelectByPrimaryKey]";
        public const string AddressSelectAll = "[dbo].[mst_Address_SelectAll]";
        public const string AddressSelectByField = "[dbo].[mst_Address_SelectByField]";
        public const string AddressDeleteByPrimaryKey = "[dbo].[mst_Address_DeleteByPrimaryKey]";
        public const string AddressDeleteByField = "[dbo].[mst_Address_DeleteByField]";
        //SPs for  mst_Company
        public const string CompanyInsert = "[dbo].[mst_Company_Insert]";
        public const string CompanyUpdate = "[dbo].[mst_Company_Update]";
        public const string CompanySelectByPrimaryKey = "[dbo].[mst_Company_SelectByPrimaryKey]";
        public const string CompanySelectAll = "[dbo].[mst_Company_SelectAll]";
        public const string CompanySelectByField = "[dbo].[mst_Company_SelectByField]";
        public const string CompanyDeleteByPrimaryKey = "[dbo].[mst_Company_DeleteByPrimaryKey]";
        public const string CompanyDeleteByField = "[dbo].[mst_Company_DeleteByField]";
        public const string CompanySelectData = "[dbo].[mst_Company_SelectData]";
        public const string CompanySelectAllCompanyData = "[dbo].[mst_Company_SelectAllData]";

        //SPs for  mst_Department
        public const string DepartmentInsert = "[dbo].[mst_Department_Insert]";
        public const string DepartmentUpdate = "[dbo].[mst_Department_Update]";
        public const string DepartmentSelectByPrimaryKey = "[dbo].[mst_Department_SelectByPrimaryKey]";
        public const string DepartmentSelectAll = "[dbo].[mst_Department_SelectAll]";
        public const string DepartmentSelectByField = "[dbo].[mst_Department_SelectByField]";
        public const string DepartmentDeleteByPrimaryKey = "[dbo].[mst_Department_DeleteByPrimaryKey]";
        public const string DepartmentDeleteByField = "[dbo].[mst_Department_DeleteByField]";
        public const string DepartmentSearchData = "[dbo].[mst_Department_SearchData]";
        public const string DepartmentSearchDepartmentData = "[dbo].[mst_Department_SearchDepartment]";

        //SPs for  mst_Floor
        public const string FloorInsert = "[dbo].[mst_Floor_Insert]";
        public const string FloorUpdate = "[dbo].[mst_Floor_Update]";
        public const string FloorSelectByPrimaryKey = "[dbo].[mst_Floor_SelectByPrimaryKey]";
        public const string FloorSelectAll = "[dbo].[mst_Floor_SelectAll]";
        public const string FloorSelectByField = "[dbo].[mst_Floor_SelectByField]";
        public const string FloorDeleteByPrimaryKey = "[dbo].[mst_Floor_DeleteByPrimaryKey]";
        public const string FloorDeleteByField = "[dbo].[mst_Floor_DeleteByField]";
        public const string FloorSearchFloorData = "[dbo].[mst_Floor_SearchFloorData]";

        //SPs for  mst_PaymentSlabe
        public const string PaymentSlabeInsert = "[dbo].[mst_PaymentSlabe_Insert]";
        public const string PaymentSlabeUpdate = "[dbo].[mst_PaymentSlabe_Update]";
        public const string PaymentSlabeSelectByPrimaryKey = "[dbo].[mst_PaymentSlabe_SelectByPrimaryKey]";
        public const string PaymentSlabeSelectAll = "[dbo].[mst_PaymentSlabe_SelectAll]";
        public const string PaymentSlabeSelectByField = "[dbo].[mst_PaymentSlabe_SelectByField]";
        public const string PaymentSlabeDeleteByPrimaryKey = "[dbo].[mst_PaymentSlabe_DeleteByPrimaryKey]";
        public const string PaymentSlabeDeleteByField = "[dbo].[mst_PaymentSlabe_DeleteByField]";
        public const string PaymentSlabeSearchData = "[dbo].[mst_PaymentSlabe_SearchData]";
        public const string PaymentSlabeGetBlocksTotalMilestone = "[dbo].[mst_PaymentSlabe_GetBlocksTotalMilestone]";

        //SPs for  mst_ProjectTerm
        public const string ProjectTermInsert = "[dbo].[mst_ProjectTerm_Insert]";
        public const string ProjectTermUpdate = "[dbo].[mst_ProjectTerm_Update]";
        public const string ProjectTermSelectByPrimaryKey = "[dbo].[mst_ProjectTerm_SelectByPrimaryKey]";
        public const string ProjectTermSelectAll = "[dbo].[mst_ProjectTerm_SelectAll]";
        public const string ProjectTermSelectByField = "[dbo].[mst_ProjectTerm_SelectByField]";
        public const string ProjectTermDeleteByPrimaryKey = "[dbo].[mst_ProjectTerm_DeleteByPrimaryKey]";
        public const string ProjectTermDeleteByField = "[dbo].[mst_ProjectTerm_DeleteByField]";
        public const string ProjectTermSelectDistinctCategory = "[dbo].[mst_ProjectTerm_SelectDistinctCategory]";
        public const string ProjectTermUpdateSeqNo = "[dbo].[mst_ProjectTerm_UpdateSeqNo]";
        public const string ProjectTermSelectAllByCategory = "[dbo].[mst_ProjectTerm_SelectAll_ByCategory]";
        public const string ProjectTermSelectAllByCategoryAndTerm = "[dbo].[mst_ProjectTerm_SearchBy_CategoryAndTerm]";
        public const string ProjectTermSelectAllResStatusByPageType = "[dbo].[mst_ProjectTerm_SelectAllResStatusByPageType]";
        public const string ProjectTermSelectTitleCSWTGT = "[dbo].[mst_ProjectTerm_SelectTitleCSWTGT]";
        public const string ProjectTermSelectTranzactionZoneIDByTransZone = "[dbo].[mst_ProjectTerm_SelectTransZoneIDByTransZone]";
        public const string ProjectTermSelectReservationTypeTermID = "[dbo].[mst_ProjectTerm_SelectReservationTypeTermID]";
        public const string ProjectTermSelectPaymentAcctIDByMOP = "[dbo].[mst_ProjectTerm_SelectPaymentAcctIDByMOP]";

        //SPs for  mst_Property
        public const string PropertyInsert = "[dbo].[mst_Property_Insert]";
        public const string PropertyUpdate = "[dbo].[mst_Property_Update]";
        public const string PropertyPurchaseUpdate = "[dbo].[mst_PropertyPurchase_Update]";
        public const string PropertySelectByPrimaryKey = "[dbo].[mst_Property_SelectByPrimaryKey]";
        public const string PropertySelectAll = "[dbo].[mst_Property_SelectAll]";
        public const string PropertySelectByField = "[dbo].[mst_Property_SelectByField]";
        public const string PropertyDeleteByPrimaryKey = "[dbo].[mst_Property_DeleteByPrimaryKey]";
        public const string PropertyDeleteByField = "[dbo].[mst_Property_DeleteByField]";
        public const string PropertySelectData = "[dbo].[mst_Property_SelectData]";
        public const string PropertyUnitView = "[dbo].[mst_Property_PropertyUnitView]";
        public const string PropertyRoomTypeView = "[dbo].[mst_Property_RoomTypeView]";
        public const string PropertyBlockUnitView = "[dbo].[mst_Property_PropertyBlockUnitView]";
        public const string PropertySelectAddressInfo = "[dbo].[mst_Property_SelectAddressInfo]";

        //SPs for propertypurchase_schedule
        public const string PurchaseScheduleInsert = "[dbo].[purchaseSchedule_Insert]";
        public const string PurchaseScheduleUpdate = "[dbo].[purchaseSchedule_Update]";
        public const string PurchaseScheduleSelectData = "[dbo].[purchaseSchedule_SelectData]";
        public const string PropertyListForPurchaseSchedule = "[dbo].[propertyListForPurchaseSchedule]";
        public const string PurchaseschedulePropertyInstallmentGrid_SelectData = "[dbo].[purchaseschedulePropertyInstallmentGrid_SelectData]";
        public const string PurchaseScheduleDeleteByPrimaryKey = "[dbo].[purchaseScheduleList_DeleteByPrimaryKey]";

        //SPs for PurchasePartnerScheduleInsert
        public const string PurchasePartnerScheduleInsert = "[dbo].[purchasePartnerSchedule_Insert]";

        //SPs for PropertyPartner
        public const string PartnerPaymentInsert = "[dbo].[PartnerPayment_Insert]";
        public const string PartnerPaymentUpdate = "[dbo].[PartnerPayment_Update]";
        public const string PartnerPaymentSelectData = "[dbo].[PartnerPayment_SelectData]";

        //SPs for PropertyPartner
        public const string PropertyPartnerSelectData = "[dbo].[mst_PropertyPartner_SelectData]";
        public const string PropertyPartnerGetData = "[dbo].[mst_PropertyPartner_GetData]";
        public const string PropertyPartnerSelectByPrimaryKey = "[dbo].[mst_PropertyPartner_SelectByPrimaryKey]";
        public const string PropertyPartnerInsert = "[dbo].[mst_PropertyPartner_Insert]";
        public const string PropertyPartnerUpdate = "[dbo].[mst_PropertyPartner_Update]";
        public const string PropertyPartnerDeleteByPrimaryKey = "[dbo].[mst_PropertyPartner_DeleteByPrimaryKey]";
        public const string PropertyPartnerCheckDuplication = "[dbo].[mst_PropertyPartner_CheckDuplication]";

        //SPs for  mst_PropertyConfiguration
        public const string PropertyConfigurationInsert = "[dbo].[mst_PropertyConfiguration_Insert]";
        public const string PropertyConfigurationUpdate = "[dbo].[mst_PropertyConfiguration_Update]";
        public const string PropertyConfigurationSelectByPrimaryKey = "[dbo].[mst_PropertyConfiguration_SelectByPrimaryKey]";
        public const string PropertyConfigurationSelectAll = "[dbo].[mst_PropertyConfiguration_SelectAll]";
        public const string PropertyConfigurationSelectByField = "[dbo].[mst_PropertyConfiguration_SelectByField]";
        public const string PropertyConfigurationDeleteByPrimaryKey = "[dbo].[mst_PropertyConfiguration_DeleteByPrimaryKey]";
        public const string PropertyConfigurationDeleteByField = "[dbo].[mst_PropertyConfiguration_DeleteByField]";
        public const string PropertyConfigurationSelectByCmpnAndPrpt = "[dbo].[mst_PropertyConfiguration_SelectByCmpnAndPrpt]";

        //SPs for  mst_Room
        public const string RoomInsert = "[dbo].[mst_Room_Insert]";
        public const string RoomUpdate = "[dbo].[mst_Room_Update]";
        public const string RoomSelectByPrimaryKey = "[dbo].[mst_Room_SelectByPrimaryKey]";
        public const string RoomSelectAll = "[dbo].[mst_Room_SelectAll]";
        public const string RoomSelectByField = "[dbo].[mst_Room_SelectByField]";
        public const string RoomDeleteByPrimaryKey = "[dbo].[mst_Room_DeleteByPrimaryKey]";
        public const string RoomDeleteByField = "[dbo].[mst_Room_DeleteByField]";
        public const string RoomSelectAllByProperty = "[dbo].[mst_Room_SelectAllByPropertyRoomType]";
        public const string RoomSearchData = "[dbo].[mst_Room_SearchData]";
        public const string Room_Conference_SelectExtensionNo = "[dbo].[mst_Room_Conference_SelectExtensionNO]";
        public const string RoomCheckDuplicateRoom = "[dbo].[mst_Room_CheckDuplicateRoom]";
        public const string RoomCountBed = "[dbo].[mst_Room_CountBed]";
        public const string RoomVacantList = "[dbo].[rpt_VacantRoomList]";
        public const string Room_SelectAllRoomIDOfRoomByAnyRoomID = "[dbo].[mst_Room_SelectAllRoomIDOfRoomByAnyRoomID]";

        //SPs for  mst_RoomLayoutPlane
        public const string RoomLayoutPlaneInsert = "[dbo].[mst_RoomLayoutPlane_Insert]";
        public const string RoomLayoutPlaneUpdate = "[dbo].[mst_RoomLayoutPlane_Update]";
        public const string RoomLayoutPlaneSelectByPrimaryKey = "[dbo].[mst_RoomLayoutPlane_SelectByPrimaryKey]";
        public const string RoomLayoutPlaneSelectAll = "[dbo].[mst_RoomLayoutPlane_SelectAll]";
        public const string RoomLayoutPlaneSelectByField = "[dbo].[mst_RoomLayoutPlane_SelectByField]";
        public const string RoomLayoutPlaneDeleteByPrimaryKey = "[dbo].[mst_RoomLayoutPlane_DeleteByPrimaryKey]";
        public const string RoomLayoutPlaneDeleteByField = "[dbo].[mst_RoomLayoutPlane_DeleteByField]";
        //SPs for  mst_RoomLayoutPlaneDetail
        public const string RoomLayoutPlaneDetailInsert = "[dbo].[mst_RoomLayoutPlaneDetail_Insert]";
        public const string RoomLayoutPlaneDetailUpdate = "[dbo].[mst_RoomLayoutPlaneDetail_Update]";
        public const string RoomLayoutPlaneDetailSelectByPrimaryKey = "[dbo].[mst_RoomLayoutPlaneDetail_SelectByPrimaryKey]";
        public const string RoomLayoutPlaneDetailSelectAll = "[dbo].[mst_RoomLayoutPlaneDetail_SelectAll]";
        public const string RoomLayoutPlaneDetailSelectByField = "[dbo].[mst_RoomLayoutPlaneDetail_SelectByField]";
        public const string RoomLayoutPlaneDetailDeleteByPrimaryKey = "[dbo].[mst_RoomLayoutPlaneDetail_DeleteByPrimaryKey]";
        public const string RoomLayoutPlaneDetailDeleteByField = "[dbo].[mst_RoomLayoutPlaneDetail_DeleteByField]";
        //SPs for  mst_RoomType
        public const string RoomTypeInsert = "[dbo].[mst_RoomType_Insert]";
        public const string RoomTypeUpdate = "[dbo].[mst_RoomType_Update]";
        public const string RoomTypeSelectByPrimaryKey = "[dbo].[mst_RoomType_SelectByPrimaryKey]";
        public const string RoomTypeSelectAll = "[dbo].[mst_RoomType_SelectAll]";
        public const string RoomTypeSelectByField = "[dbo].[mst_RoomType_SelectByField]";
        public const string RoomTypeDeleteByPrimaryKey = "[dbo].[mst_RoomType_DeleteByPrimaryKey]";
        public const string RoomTypeDeleteByField = "[dbo].[mst_RoomType_DeleteByField]";
        public const string RoomTypeSelectAllForRateCard = "[dbo].[mst_RoomType_SelectAllForRateCard]";
        public const string RoomTypeSearchData = "[dbo].[mst_RoomType_SearchData]";
        public const string RoomTypeSelectDistinctRoomTypeOnRoom = "[dbo].[mst_RoomType_SelectDistinctByRoom]";
        public const string RoomTypeSelectRoomTypeServices = "[dbo].[mst_RoomType_SelectRoomTypeServices]";

        //SPs for  mst_Wing
        public const string WingInsert = "[dbo].[mst_Wing_Insert]";
        public const string WingUpdate = "[dbo].[mst_Wing_Update]";
        public const string WingSelectByPrimaryKey = "[dbo].[mst_Wing_SelectByPrimaryKey]";
        public const string WingSelectAll = "[dbo].[mst_Wing_SelectAll]";
        public const string WingSelectByField = "[dbo].[mst_Wing_SelectByField]";
        public const string WingDeleteByPrimaryKey = "[dbo].[mst_Wing_DeleteByPrimaryKey]";
        public const string WingDeleteByField = "[dbo].[mst_Wing_DeleteByField]";
        public const string WingSearchWingData = "[dbo].[mst_Wing_SearchWingData]";
        public const string WingSelectDistinctWingOnRoom = "[dbo].[mst_Wing_SelectDistinctByRoom]";
        public const string WingSelectDistinctWingAndRate = "[dbo].[mst_Wing_SelectDistinctWingAndRate]";

        //SPs for  mst_WingFloorJoin
        public const string WingFloorJoinInsert = "[dbo].[mst_WingFloorJoin_Insert]";
        public const string WingFloorJoinUpdate = "[dbo].[mst_WingFloorJoin_Update]";
        public const string WingFloorJoinSelectByPrimaryKey = "[dbo].[mst_WingFloorJoin_SelectByPrimaryKey]";
        public const string WingFloorJoinSelectAll = "[dbo].[mst_WingFloorJoin_SelectAll]";
        public const string WingFloorJoinSelectByField = "[dbo].[mst_WingFloorJoin_SelectByField]";
        public const string WingFloorJoinDeleteByPrimaryKey = "[dbo].[mst_WingFloorJoin_DeleteByPrimaryKey]";
        public const string WingFloorJoinDeleteByField = "[dbo].[mst_WingFloorJoin_DeleteByField]";
        public const string WingFlorrJoinSelectAllWithName = "[dbo].[mst_WingFloorJoin_SelectAllWithName]";
        public const string WingFlorrJoinDeleteByFloorID = "[dbo].[mst_WingFloorJoin_DeleteByFloorID]";

        //SPs for  usr_ActionLog
        public const string ActionLogInsert = "[dbo].[usr_ActionLog_Insert]";
        public const string ActionLogUpdate = "[dbo].[usr_ActionLog_Update]";
        public const string ActionLogSelectByPrimaryKey = "[dbo].[usr_ActionLog_SelectByPrimaryKey]";
        public const string ActionLogSelectAll = "[dbo].[usr_ActionLog_SelectAll]";
        public const string ActionLogSelectByField = "[dbo].[usr_ActionLog_SelectByField]";
        public const string ActionLogDeleteByPrimaryKey = "[dbo].[usr_ActionLog_DeleteByPrimaryKey]";
        public const string ActionLogDeleteByField = "[dbo].[usr_ActionLog_DeleteByField]";
        public const string ActionLogSearchData = "[dbo].[usr_ActionLog_SearchData]";
        public const string ActionLogSymphonySearchData = "[dbo].[usr_ActionLogSymphony_SearchData]";

        //SPs for  usr_LoginLog
        public const string LoginLogInsert = "[dbo].[usr_LoginLog_Insert]";
        public const string LoginLogUpdate = "[dbo].[usr_LoginLog_Update]";
        public const string LoginLogSelectByPrimaryKey = "[dbo].[usr_LoginLog_SelectByPrimaryKey]";
        public const string LoginLogSelectAll = "[dbo].[usr_LoginLog_SelectAll]";
        public const string LoginLogSelectByField = "[dbo].[usr_LoginLog_SelectByField]";
        public const string LoginLogDeleteByPrimaryKey = "[dbo].[usr_LoginLog_DeleteByPrimaryKey]";
        public const string LoginLogDeleteByField = "[dbo].[usr_LoginLog_DeleteByField]";
        public const string LoginLogSearchData = "[dbo].[usr_LoginLog_SearchData]";
        public const string LoginLogSymphonySearchData = "[dbo].[usr_LoginLogSymphony_SearchData]";

        //SPs for  usr_Right
        public const string RightInsert = "[dbo].[usr_Right_Insert]";
        public const string RightUpdate = "[dbo].[usr_Right_Update]";
        public const string RightSelectByPrimaryKey = "[dbo].[usr_Right_SelectByPrimaryKey]";
        public const string RightSelectAll = "[dbo].[usr_Right_SelectAll]";
        public const string RightSelectByField = "[dbo].[usr_Right_SelectByField]";
        public const string RightDeleteByPrimaryKey = "[dbo].[usr_Right_DeleteByPrimaryKey]";
        public const string RightDeleteByField = "[dbo].[usr_Right_DeleteByField]";
        //SPs for  usr_Role
        public const string RoleInsert = "[dbo].[usr_Role_Insert]";
        public const string RoleUpdate = "[dbo].[usr_Role_Update]";
        public const string RoleSelectByPrimaryKey = "[dbo].[usr_Role_SelectByPrimaryKey]";
        public const string RoleSelectAll = "[dbo].[usr_Role_SelectAll]";
        public const string RoleSelectByField = "[dbo].[usr_Role_SelectByField]";
        public const string RoleDeleteByPrimaryKey = "[dbo].[usr_Role_DeleteByPrimaryKey]";
        public const string RoleDeleteByField = "[dbo].[usr_Role_DeleteByField]";
        public const string RoleSearchData = "[dbo].[usr_Role_SearchData]";
        public const string SearchUserRole = "[dbo].[usr_Role_SearchUserRole]";

        //SPs for  usr_RoleRightJoin
        public const string RoleRightJoinInsert = "[dbo].[usr_RoleRightJoin_Insert]";
        public const string RoleRightJoinUpdate = "[dbo].[usr_RoleRightJoin_Update]";
        public const string RoleRightJoinSelectByPrimaryKey = "[dbo].[usr_RoleRightJoin_SelectByPrimaryKey]";
        public const string RoleRightJoinSelectAll = "[dbo].[usr_RoleRightJoin_SelectAll]";
        public const string RoleRightJoinSelectByField = "[dbo].[usr_RoleRightJoin_SelectByField]";
        public const string RoleRightJoinDeleteByPrimaryKey = "[dbo].[usr_RoleRightJoin_DeleteByPrimaryKey]";
        public const string RoleRightJoinDeleteByField = "[dbo].[usr_RoleRightJoin_DeleteByField]";
        public const string RoleRightJoinDeleteByRoleID = "[dbo].[usr_RoleRightJoin_DeleteByRoleID]";
        public const string RoleRightJoinSearchByRole = "[dbo].[usr_RoleRightJoin_SelectAllRights]";
        public const string RoleRightGetAccess = "[dbo].[usr_RoleRightJoin_GetAccess]";
        public const string RoleRightGetIUDVAccess = "[dbo].[usr_RoleRightJoin_GetAccessRights]";
        //SPs for  usr_User
        public const string UserInsert = "[dbo].[usr_User_Insert]";
        public const string UserUpdate = "[dbo].[usr_User_Update]";
        public const string UserSelectByPrimaryKey = "[dbo].[usr_User_SelectByPrimaryKey]";
        public const string UserSelectAll = "[dbo].[usr_User_SelectAll]";
        public const string UserSelectByField = "[dbo].[usr_User_SelectByField]";
        public const string UserDeleteByPrimaryKey = "[dbo].[usr_User_DeleteByPrimaryKey]";
        public const string UserDeleteByField = "[dbo].[usr_User_DeleteByField]";
        public const string UserSearchData = "[dbo].[usr_User_SearchData]";
        public const string UserCredential = "[dbo].[usr_User_UserCredentail]";
        public const string UserAuthentication = "[dbo].[usr_User_UserAuthentication]";
        public const string UserAuthorization = "[dbo].[usr_User_Authorization]";
        public const string UserAllAuthorization = "[dbo].[usr_User_AllAuthorization]";
        public const string UserSelectAllByRoleTypeHierarchy = "[dbo].[usr_User_SelectAllByRoleTypeHierarchy]";

        //SPs for  usr_UserRole
        public const string UserRoleInsert = "[dbo].[usr_UserRole_Insert]";
        public const string UserRoleUpdate = "[dbo].[usr_UserRole_Update]";
        public const string UserRoleSelectByPrimaryKey = "[dbo].[usr_UserRole_SelectByPrimaryKey]";
        public const string UserRoleSelectAll = "[dbo].[usr_UserRole_SelectAll]";
        public const string UserRoleSelectByField = "[dbo].[usr_UserRole_SelectByField]";
        public const string UserRoleDeleteByPrimaryKey = "[dbo].[usr_UserRole_DeleteByPrimaryKey]";
        public const string UserRoleDeleteByField = "[dbo].[usr_UserRole_DeleteByField]";
        public const string UserRoleDeleteByUserID = "[dbo].[usr_UserRole_DeleteByUserID]";
        public const string SelectFunctionalUserRole = "[dbo].[usr_UserRole_SelectIsFunctional]";


        //SPs for  mst_City
        public const string CityInsert = "[dbo].[mst_City_Insert]";
        public const string CityUpdate = "[dbo].[mst_City_Update]";
        public const string CitySelectByPrimaryKey = "[dbo].[mst_City_SelectByPrimaryKey]";
        public const string CitySelectAll = "[dbo].[mst_City_SelectAll]";
        public const string CitySelectByField = "[dbo].[mst_City_SelectByField]";
        public const string CityDeleteByPrimaryKey = "[dbo].[mst_City_DeleteByPrimaryKey]";
        public const string CityDeleteByField = "[dbo].[mst_City_DeleteByField]";
        //SPs for  mst_Country
        public const string CountryInsert = "[dbo].[mst_Country_Insert]";
        public const string CountryUpdate = "[dbo].[mst_Country_Update]";
        public const string CountrySelectByPrimaryKey = "[dbo].[mst_Country_SelectByPrimaryKey]";
        public const string CountrySelectAll = "[dbo].[mst_Country_SelectAll]";
        public const string CountrySelectByField = "[dbo].[mst_Country_SelectByField]";
        public const string CountryDeleteByPrimaryKey = "[dbo].[mst_Country_DeleteByPrimaryKey]";
        public const string CountryDeleteByField = "[dbo].[mst_Country_DeleteByField]";
        //SPs for  mst_State
        public const string StateInsert = "[dbo].[mst_State_Insert]";
        public const string StateUpdate = "[dbo].[mst_State_Update]";
        public const string StateSelectByPrimaryKey = "[dbo].[mst_State_SelectByPrimaryKey]";
        public const string StateSelectAll = "[dbo].[mst_State_SelectAll]";
        public const string StateSelectByField = "[dbo].[mst_State_SelectByField]";
        public const string StateDeleteByPrimaryKey = "[dbo].[mst_State_DeleteByPrimaryKey]";
        public const string StateDeleteByField = "[dbo].[mst_State_DeleteByField]";


        public const string IndexDashBoard = "[dbo].[Mst_IndexDashBoard]";



        //SPs for  mst_Amenities
        public const string AmenitiesInsert = "[dbo].[mst_Amenities_Insert]";
        public const string AmenitiesUpdate = "[dbo].[mst_Amenities_Update]";
        public const string AmenitiesSelectByPrimaryKey = "[dbo].[mst_Amenities_SelectByPrimaryKey]";
        public const string AmenitiesSelectAll = "[dbo].[mst_Amenities_SelectAll]";
        public const string AmenitiesSelectByField = "[dbo].[mst_Amenities_SelectByField]";
        public const string AmenitiesDeleteByPrimaryKey = "[dbo].[mst_Amenities_DeleteByPrimaryKey]";
        public const string AmenitiesDeleteByField = "[dbo].[mst_Amenities_DeleteByField]";
        public const string AmenitiesSearchData = "[dbo].[mst_Amenities_SearchAmenitiesData]";

        //SPs for  mst_RoomAmenities
        public const string RoomAmenitiesInsert = "[dbo].[mst_RoomAmenities_Insert]";
        public const string RoomAmenitiesUpdate = "[dbo].[mst_RoomAmenities_Update]";
        public const string RoomAmenitiesSelectByPrimaryKey = "[dbo].[mst_RoomAmenities_SelectByPrimaryKey]";
        public const string RoomAmenitiesSelectAll = "[dbo].[mst_RoomAmenities_SelectAll]";
        public const string RoomAmenitiesSelectByField = "[dbo].[mst_RoomAmenities_SelectByField]";
        public const string RoomAmenitiesDeleteByPrimaryKey = "[dbo].[mst_RoomAmenities_DeleteByPrimaryKey]";
        public const string RoomAmenitiesDeleteByField = "[dbo].[mst_RoomAmenities_DeleteByField]";
        public const string RoomAmenitiesDeleteByRoomID = "[dbo].[mst_RoomAmenities_DeleteByRoomID]";

        //SPs for  mst_RoomTypeAmenities
        public const string RoomTypeAmenitiesInsert = "[dbo].[mst_RoomTypeAmenities_Insert]";
        public const string RoomTypeAmenitiesUpdate = "[dbo].[mst_RoomTypeAmenities_Update]";
        public const string RoomTypeAmenitiesSelectByPrimaryKey = "[dbo].[mst_RoomTypeAmenities_SelectByPrimaryKey]";
        public const string RoomTypeAmenitiesSelectAll = "[dbo].[mst_RoomTypeAmenities_SelectAll]";
        public const string RoomTypeAmenitiesSelectByField = "[dbo].[mst_RoomTypeAmenities_SelectByField]";
        public const string RoomTypeAmenitiesDeleteByPrimaryKey = "[dbo].[mst_RoomTypeAmenities_DeleteByPrimaryKey]";
        public const string RoomTypeAmenitiesDeleteByField = "[dbo].[mst_RoomTypeAmenities_DeleteByField]";
        public const string RoomTypeAmenitiesDeleteByRoomTypeID = "[dbo].[mst_RoomTypeAmenities_DeleteByRoomTypeID]";
        public const string RoomTypeAmenitiesSelectAmenities = "[dbo].[mst_RoomTypeAmenities_SelectAmenities]";

        //SPs for  mst_StayType
        public const string StayTypeInsert = "[dbo].[mst_StayType_Insert]";
        public const string StayTypeUpdate = "[dbo].[mst_StayType_Update]";
        public const string StayTypeSelectByPrimaryKey = "[dbo].[mst_StayType_SelectByPrimaryKey]";
        public const string StayTypeSelectAll = "[dbo].[mst_StayType_SelectAll]";
        public const string StayTypeSelectByField = "[dbo].[mst_StayType_SelectByField]";
        public const string StayTypeDeleteByPrimaryKey = "[dbo].[mst_StayType_DeleteByPrimaryKey]";
        public const string StayTypeDeleteByField = "[dbo].[mst_StayType_DeleteByField]";
        public const string StayTypeSelectAllForCheckDuplicate = "[dbo].[mst_StayType_SelectAllForCheckDuplicate]";

        //SPs for  mst_Discounts
        public const string DiscountsInsert = "[dbo].[mst_Discounts_Insert]";
        public const string DiscountsUpdate = "[dbo].[mst_Discounts_Update]";
        public const string DiscountsSelectByPrimaryKey = "[dbo].[mst_Discounts_SelectByPrimaryKey]";
        public const string DiscountsSelectAll = "[dbo].[mst_Discounts_SelectAll]";
        public const string DiscountsSelectByField = "[dbo].[mst_Discounts_SelectByField]";
        public const string DiscountsDeleteByPrimaryKey = "[dbo].[mst_Discounts_DeleteByPrimaryKey]";
        public const string DiscountsDeleteByField = "[dbo].[mst_Discounts_DeleteByField]";
        public const string DiscountsSelectAllForCheckDuplicate = "[dbo].[mst_Discounts_SelectAllForCheckDuplicate]";
        //SPs for  mst_VIPTypes
        public const string VIPTypesInsert = "[dbo].[mst_VIPTypes_Insert]";
        public const string VIPTypesUpdate = "[dbo].[mst_VIPTypes_Update]";
        public const string VIPTypesSelectByPrimaryKey = "[dbo].[mst_VIPTypes_SelectByPrimaryKey]";
        public const string VIPTypesSelectAll = "[dbo].[mst_VIPTypes_SelectAll]";
        public const string VIPTypesSelectByField = "[dbo].[mst_VIPTypes_SelectByField]";
        public const string VIPTypesDeleteByPrimaryKey = "[dbo].[mst_VIPTypes_DeleteByPrimaryKey]";
        public const string VIPTypesDeleteByField = "[dbo].[mst_VIPTypes_DeleteByField]";
        public const string VIPTypesSelectAllForCheckDuplicate = "[dbo].[mst_VIPTypes_SelectAllForCheckDuplicate]";

        //SPs for  mst_Deposits
        public const string DepositsInsert = "[dbo].[mst_Deposits_Insert]";
        public const string DepositsUpdate = "[dbo].[mst_Deposits_Update]";
        public const string DepositsSelectByPrimaryKey = "[dbo].[mst_Deposits_SelectByPrimaryKey]";
        public const string DepositsSelectAll = "[dbo].[mst_Deposits_SelectAll]";
        public const string DepositsSelectByField = "[dbo].[mst_Deposits_SelectByField]";
        public const string DepositsDeleteByPrimaryKey = "[dbo].[mst_Deposits_DeleteByPrimaryKey]";
        public const string DepositsDeleteByField = "[dbo].[mst_Deposits_DeleteByField]";
        public const string DepositsSelectAllSearchData = "[dbo].[mst_Deposits_SelectSearchAll]";

        //SPs for  mst_RoomTypeDeposit
        public const string RoomTypeDepositInsert = "[dbo].[mst_RoomTypeDeposit_Insert]";
        public const string RoomTypeDepositUpdate = "[dbo].[mst_RoomTypeDeposit_Update]";
        public const string RoomTypeDepositSelectByPrimaryKey = "[dbo].[mst_RoomTypeDeposit_SelectByPrimaryKey]";
        public const string RoomTypeDepositSelectAll = "[dbo].[mst_RoomTypeDeposit_SelectAll]";
        public const string RoomTypeDepositSelectByField = "[dbo].[mst_RoomTypeDeposit_SelectByField]";
        public const string RoomTypeDepositDeleteByPrimaryKey = "[dbo].[mst_RoomTypeDeposit_DeleteByPrimaryKey]";
        public const string RoomTypeDepositDeleteByField = "[dbo].[mst_RoomTypeDeposit_DeleteByField]";
        public const string RoomTypeDepositDeleteByRoomTypeID = "[dbo].[mst_RoomTypeDeposit_DeleteByRoomTypeID]";

        //SPs for  acc_Account
        public const string AccountInsert = "[dbo].[acc_Account_Insert]";
        public const string AccountUpdate = "[dbo].[acc_Account_Update]";
        public const string AccountSelectByPrimaryKey = "[dbo].[acc_Account_SelectByPrimaryKey]";
        public const string AccountSelectAll = "[dbo].[acc_Account_SelectAll]";
        public const string AccountSelectByField = "[dbo].[acc_Account_SelectByField]";
        public const string AccountDeleteByPrimaryKey = "[dbo].[acc_Account_DeleteByPrimaryKey]";
        public const string AccountDeleteByField = "[dbo].[acc_Account_DeleteByField]";
        public const string AccountSearchAccountData = "[dbo].[acc_Account_SearchAccountData]";
        public const string AccountSelectAllTaxesForRateCard = "[dbo].[acc_Account_SelectAllTaxesForRateCard]";
        public const string AccountSelectTaxData = "[dbo].[acc_Account_SelectTaxData]";
        public const string AccountGetPaymentAcctsByMOPTermID = "[dbo].[acc_Account_GetPaymentAcctsByMOPTermID]";
        public const string RPTAccountRevenueDetail = "[dbo].[rpt_AccountRevenue_WeeklyChart]";

        //SPs for  mst_AddOnItems
        public const string AddOnItemsInsert = "[dbo].[mst_AddOnItems_Insert]";
        public const string AddOnItemsUpdate = "[dbo].[mst_AddOnItems_Update]";
        public const string AddOnItemsSelectByPrimaryKey = "[dbo].[mst_AddOnItems_SelectByPrimaryKey]";
        public const string AddOnItemsSelectAll = "[dbo].[mst_AddOnItems_SelectAll]";
        public const string AddOnItemsSelectByField = "[dbo].[mst_AddOnItems_SelectByField]";
        public const string AddOnItemsDeleteByPrimaryKey = "[dbo].[mst_AddOnItems_DeleteByPrimaryKey]";
        public const string AddOnItemsDeleteByField = "[dbo].[mst_AddOnItems_DeleteByField]";
        //SPs for  mst_AddOns
        public const string AddOnsInsert = "[dbo].[mst_AddOns_Insert]";
        public const string AddOnsUpdate = "[dbo].[mst_AddOns_Update]";
        public const string AddOnsSelectByPrimaryKey = "[dbo].[mst_AddOns_SelectByPrimaryKey]";
        public const string AddOnsSelectAll = "[dbo].[mst_AddOns_SelectAll]";
        public const string AddOnsSelectByField = "[dbo].[mst_AddOns_SelectByField]";
        public const string AddOnsDeleteByPrimaryKey = "[dbo].[mst_AddOns_DeleteByPrimaryKey]";
        public const string AddOnsDeleteByField = "[dbo].[mst_AddOns_DeleteByField]";
        public const string AddOnsSelectAllForSearch = "[dbo].[mst_AddOns_SelectAllForSearch]";
        //SPs for  mst_Conference
        public const string ConferenceInsert = "[dbo].[mst_Conference_Insert]";
        public const string ConferenceUpdate = "[dbo].[mst_Conference_Update]";
        public const string ConferenceSelectByPrimaryKey = "[dbo].[mst_Conference_SelectByPrimaryKey]";
        public const string ConferenceSelectAll = "[dbo].[mst_Conference_SelectAll]";
        public const string ConferenceSelectByField = "[dbo].[mst_Conference_SelectByField]";
        public const string ConferenceDeleteByPrimaryKey = "[dbo].[mst_Conference_DeleteByPrimaryKey]";
        public const string ConferenceDeleteByField = "[dbo].[mst_Conference_DeleteByField]";
        public const string ConferenceSelectAllForRateCard = "[dbo].[mst_Conference_SelectAllForRateCard]";
        public const string ConferenceSearchConferenceData = "[dbo].[mst_Conference_SearchConferenceData]";

        //SPs for  mst_Corporate
        public const string CorporateInsert = "[dbo].[mst_Corporate_Insert]";
        public const string CorporateUpdate = "[dbo].[mst_Corporate_Update]";
        public const string CorporateSelectByPrimaryKey = "[dbo].[mst_Corporate_SelectByPrimaryKey]";
        public const string CorporateSelectAll = "[dbo].[mst_Corporate_SelectAll]";
        public const string CorporateSelectByField = "[dbo].[mst_Corporate_SelectByField]";
        public const string CorporateDeleteByPrimaryKey = "[dbo].[mst_Corporate_DeleteByPrimaryKey]";
        public const string CorporateDeleteByField = "[dbo].[mst_Corporate_DeleteByField]";
        public const string CorporateSelectAllForRateCard = "[dbo].[mst_Corporate_SelectAllForRateCard]";
        public const string CorporateUpdateDefaultRateID = "[dbo].[mst_Corporate_UpdateDefaultRate]";
        public const string CorporateSelectAllSearchData = "[dbo].[mst_Corporate_SelectAllSearchData]";
        public const string CorporateUpdateVoucherImage = "[dbo].[mst_Corporate_UpdateVoucherImage]";
        public const string CorporateSearchAgentData = "[dbo].[mst_Corporate_SearchAgentData]";
        public const string CorporateSelectCompanyList = "[dbo].[mst_SelectCompanyList]";
        public const string AgentSelectAgentWithReceipt = "[dbo].[mst_Agent_AgentWithReceipt]";


        //SPs for  mst_CorporateRates
        public const string CorporateRatesInsert = "[dbo].[mst_CorporateRates_Insert]";
        public const string CorporateRatesUpdate = "[dbo].[mst_CorporateRates_Update]";
        public const string CorporateRatesSelectByPrimaryKey = "[dbo].[mst_CorporateRates_SelectByPrimaryKey]";
        public const string CorporateRatesSelectAll = "[dbo].[mst_CorporateRates_SelectAll]";
        public const string CorporateRatesSelectByField = "[dbo].[mst_CorporateRates_SelectByField]";
        public const string CorporateRatesDeleteByPrimaryKey = "[dbo].[mst_CorporateRates_DeleteByPrimaryKey]";
        public const string CorporateRatesDeleteByField = "[dbo].[mst_CorporateRates_DeleteByField]";
        //SPs for  mst_Item
        public const string ItemInsert = "[dbo].[mst_Item_Insert]";
        public const string ItemUpdate = "[dbo].[mst_Item_Update]";
        public const string ItemSelectByPrimaryKey = "[dbo].[mst_Item_SelectByPrimaryKey]";
        public const string ItemSelectAll = "[dbo].[mst_Item_SelectAll]";
        public const string ItemSelectByField = "[dbo].[mst_Item_SelectByField]";
        public const string ItemDeleteByPrimaryKey = "[dbo].[mst_Item_DeleteByPrimaryKey]";
        public const string ItemDeleteByField = "[dbo].[mst_Item_DeleteByField]";
        public const string ItemSelectAllForAddOns = "[dbo].[mst_Item_SelectAllForAddOns]";
        public const string ItemSelectAllWithData = "[dbo].[mst_Item_SelectAllWithData]";
        public const string ItemSelectItemDataByPrimaryKey = "[dbo].[mst_Item_SelectItemDataByPrimaryKey]";
        public const string ItemSelectItemsForRateCard = "[dbo].[mst_Item_SelectAllForRateCard]";
        public const string ItemSelectItemAvailabilityDataByItemAndCategoryIDs = "[dbo].[mst_Item_SelectItemAvailabilityData]";
        public const string SearchDataForRoomService = "[mst_Item_SearchDataForRoomService]";

        //SPs for  mst_RateCard
        public const string RateCardInsert = "[dbo].[mst_RateCard_Insert]";
        public const string RateCardUpdate = "[dbo].[mst_RateCard_Update]";
        public const string RateCardSelectByPrimaryKey = "[dbo].[mst_RateCard_SelectByPrimaryKey]";
        public const string RateCardSelectAll = "[dbo].[mst_RateCard_SelectAll]";
        public const string RateCardSelectByField = "[dbo].[mst_RateCard_SelectByField]";
        public const string RateCardDeleteByPrimaryKey = "[dbo].[mst_RateCard_DeleteByPrimaryKey]";
        public const string RateCardDeleteByField = "[dbo].[mst_RateCard_DeleteByField]";
        public const string RateCardSelectAllByProperty = "[dbo].[mst_RateCard_SelectAllByProperty]";
        public const string RateCardSelectDataByPrimaryKey = "[dbo].[mst_RateCard_SelectDataByPrimaryKey]";
        public const string RateCardSelectAllByRateCardType = "[dbo].[mst_RateCard_SelectALLByRateCardType]";
        public const string RateCardSelectAllForCorporate = "[dbo].[mst_RateCard_SelectALLForCorporate]";
        public const string RateCardGetAllAvailableRateCards = "[dbo].[mst_Rate_GetAllAvailableRateCards]";
        public const string RateCardSelectDashboardRatecardData = "[dbo].[mst_RateCard_SelectDashboardData]";
        public const string RateCardSelectDashboardServicesData = "[dbo].[mst_RateCard_SelectDashboardServicesData]";
        public const string RateCardSelectForRoomRateCardResStatus = "[dbo].[mst_RateCard_SelectForRoomRateCardResStatus]";
        public const string RateCardSelectRateCardsReqMinDaysByRateCardIDs = "[dbo].[mst_RateCard_SelectRateCardsReqMinDaysByRateCardIDs]";
        public const string RateCardForOverStay = "[dbo].[mst_Rate_GetOverStayRateCard]";



        //SPs for  mst_RateCardDetails
        public const string RateCardDetailsInsert = "[dbo].[mst_RateCardDetails_Insert]";
        public const string RateCardDetailsUpdate = "[dbo].[mst_RateCardDetails_Update]";
        public const string RateCardDetailsSelectByPrimaryKey = "[dbo].[mst_RateCardDetails_SelectByPrimaryKey]";
        public const string RateCardDetailsSelectAll = "[dbo].[mst_RateCardDetails_SelectAll]";
        public const string RateCardDetailsSelectByField = "[dbo].[mst_RateCardDetails_SelectByField]";
        public const string RateCardDetailsDeleteByPrimaryKey = "[dbo].[mst_RateCardDetails_DeleteByPrimaryKey]";
        public const string RateCardDetailsDeleteByField = "[dbo].[mst_RateCardDetails_DeleteByField]";
        public const string RateCardDetailsGetByRateIDnRoomTypeID = "[dbo].[mst_RateCardDetails_SelectByRateIDnRoomTypeID]";
        public const string RateCardDetailsSelectRoomTypeByRateID = "[dbo].[mst_RateCardDetails_SelectRoomTypeByRateID]";
        public const string RateCardDetailsSelectForPOSCharge = "[dbo].[mst_RateCardDetails_SelectForPOSCharge]";

        //SPs for  mst_RateServiceJoin
        public const string RateServiceJoinInsert = "[dbo].[mst_RateServiceJoin_Insert]";
        public const string RateServiceJoinUpdate = "[dbo].[mst_RateServiceJoin_Update]";
        public const string RateServiceJoinSelectByPrimaryKey = "[dbo].[mst_RateServiceJoin_SelectByPrimaryKey]";
        public const string RateServiceJoinSelectAll = "[dbo].[mst_RateServiceJoin_SelectAll]";
        public const string RateServiceJoinSelectByField = "[dbo].[mst_RateServiceJoin_SelectByField]";
        public const string RateServiceJoinDeleteByPrimaryKey = "[dbo].[mst_RateServiceJoin_DeleteByPrimaryKey]";
        public const string RateServiceJoinDeleteByField = "[dbo].[mst_RateServiceJoin_DeleteByField]";
        public const string RateServiceJoinDeleteByRateID = "[dbo].[mst_RateServiceJoin_DeleteByRateID]";
        public const string RateServiceJoinSelectAllDataByRateID = "[dbo].[mst_RateServiceJoin_SelectAllDataByRateID]";
        public const string RateServiceJoinSelectAllByRateIDnRoomTypeID = "[dbo].[mst_RateServiceJoin_SelectAllByRateIDnRoomTypeID]";

        //SPs for  mst_RateTaxes
        public const string RateTaxesInsert = "[dbo].[mst_RateTaxes_Insert]";
        public const string RateTaxesUpdate = "[dbo].[mst_RateTaxes_Update]";
        public const string RateTaxesSelectByPrimaryKey = "[dbo].[mst_RateTaxes_SelectByPrimaryKey]";
        public const string RateTaxesSelectAll = "[dbo].[mst_RateTaxes_SelectAll]";
        public const string RateTaxesSelectByField = "[dbo].[mst_RateTaxes_SelectByField]";
        public const string RateTaxesDeleteByPrimaryKey = "[dbo].[mst_RateTaxes_DeleteByPrimaryKey]";
        public const string RateTaxesDeleteByField = "[dbo].[mst_RateTaxes_DeleteByField]";

        //SPs for  mst_ConfConferenceType
        public const string ConfConferenceTypeInsert = "[dbo].[mst_ConfConferenceType_Insert]";
        public const string ConfConferenceTypeUpdate = "[dbo].[mst_ConfConferenceType_Update]";
        public const string ConfConferenceTypeSelectByPrimaryKey = "[dbo].[mst_ConfConferenceType_SelectByPrimaryKey]";
        public const string ConfConferenceTypeSelectAll = "[dbo].[mst_ConfConferenceType_SelectAll]";
        public const string ConfConferenceTypeSelectByField = "[dbo].[mst_ConfConferenceType_SelectByField]";
        public const string ConfConferenceTypeDeleteByPrimaryKey = "[dbo].[mst_ConfConferenceType_DeleteByPrimaryKey]";
        public const string ConfConferenceTypeDeleteByField = "[dbo].[mst_ConfConferenceType_DeleteByField]";
        public const string ConfConferenceTypeDeleteByConferenceID = "[dbo].[mst_ConfConferenceType_DeleteByConferenceID]";

        //SPs for  mst_ConferenceType
        public const string ConferenceTypeInsert = "[dbo].[mst_ConferenceType_Insert]";
        public const string ConferenceTypeUpdate = "[dbo].[mst_ConferenceType_Update]";
        public const string ConferenceTypeSelectByPrimaryKey = "[dbo].[mst_ConferenceType_SelectByPrimaryKey]";
        public const string ConferenceTypeSelectAll = "[dbo].[mst_ConferenceType_SelectAll]";
        public const string ConferenceTypeSelectByField = "[dbo].[mst_ConferenceType_SelectByField]";
        public const string ConferenceTypeDeleteByPrimaryKey = "[dbo].[mst_ConferenceType_DeleteByPrimaryKey]";
        public const string ConferenceTypeDeleteByField = "[dbo].[mst_ConferenceType_DeleteByField]";
        public const string ConferenceTypeSelectDataByConfernceID = "[dbo].[mst_ConferenceType_SelectDataByConfernceID]";
        public const string ConferenceTypeSearchConferenceTypeData = "[dbo].[mst_ConferenceType_SearchConferenceTypeData]";

        //SPs for  mst_RoomBlock
        public const string RoomBlockInsert = "[dbo].[mst_RoomBlock_Insert]";
        public const string RoomBlockUpdate = "[dbo].[mst_RoomBlock_Update]";
        public const string RoomBlockSelectByPrimaryKey = "[dbo].[mst_RoomBlock_SelectByPrimaryKey]";
        public const string RoomBlockSelectAll = "[dbo].[mst_RoomBlock_SelectAll]";
        public const string RoomBlockSelectByField = "[dbo].[mst_RoomBlock_SelectByField]";
        public const string RoomBlockDeleteByPrimaryKey = "[dbo].[mst_RoomBlock_DeleteByPrimaryKey]";
        public const string RoomBlockDeleteByField = "[dbo].[mst_RoomBlock_DeleteByField]";
        public const string RoomBlockSearchData = "[dbo].[mst_RoomBlock_SearchData]";
        public const string RoomBlockSelectAllRoomBlockData = "[dbo].[mst_RoomBlock_SelectAllRoomBlockData]";
        public const string RoomBlockInsertForComplementoryReservation = "[dbo].[mst_RoomBlock_Insert_ForComplementoryReservation]";
        public const string RoomBlockDeleteForComplementoryReservation = "[dbo].[mst_RoomBlock_Delete_ForComplementoryReservation]";

        //SPs for  mst_RoomBlockDetails
        public const string RoomBlockDetailsInsert = "[dbo].[mst_RoomBlockDetails_Insert]";
        public const string RoomBlockDetailsUpdate = "[dbo].[mst_RoomBlockDetails_Update]";
        public const string RoomBlockDetailsSelectByPrimaryKey = "[dbo].[mst_RoomBlockDetails_SelectByPrimaryKey]";
        public const string RoomBlockDetailsSelectAll = "[dbo].[mst_RoomBlockDetails_SelectAll]";
        public const string RoomBlockDetailsSelectByField = "[dbo].[mst_RoomBlockDetails_SelectByField]";
        public const string RoomBlockDetailsDeleteByPrimaryKey = "[dbo].[mst_RoomBlockDetails_DeleteByPrimaryKey]";
        public const string RoomBlockDetailsDeleteByField = "[dbo].[mst_RoomBlockDetails_DeleteByField]";
        public const string RoomBlockDetailsDeleteByBlockRoomID = "[dbo].[mst_RoomBlockDetails_DeleteByBlockRoomID]";
        public const string RoomBlockDetailsDeleteBlockRoomDetailsRoomData = "[dbo].[mst_RoomBlock_Delete_ForComplementoryReservation]";

        //SPs for  mst_RoomSellOrder
        public const string RoomSellOrderInsert = "[dbo].[mst_RoomSellOrder_Insert]";
        public const string RoomSellOrderUpdate = "[dbo].[mst_RoomSellOrder_Update]";
        public const string RoomSellOrderSelectByPrimaryKey = "[dbo].[mst_RoomSellOrder_SelectByPrimaryKey]";
        public const string RoomSellOrderSelectAll = "[dbo].[mst_RoomSellOrder_SelectAll]";
        public const string RoomSellOrderSelectByField = "[dbo].[mst_RoomSellOrder_SelectByField]";
        public const string RoomSellOrderDeleteByPrimaryKey = "[dbo].[mst_RoomSellOrder_DeleteByPrimaryKey]";
        public const string RoomSellOrderDeleteByField = "[dbo].[mst_RoomSellOrder_DeleteByField]";
        public const string RoomSellOrderSelectAllAfterSwap = "[dbo].[mst_RoomSellOrder_SelectAllAfterSwap]";
        public const string RoomSellOrderGetAllData = "[dbo].[mst_RoomSellOrder_GetAllData]";

        //SPs for  mst_Counters
        public const string CountersInsert = "[dbo].[mst_Counters_Insert]";
        public const string CountersUpdate = "[dbo].[mst_Counters_Update]";
        public const string CountersSelectByPrimaryKey = "[dbo].[mst_Counters_SelectByPrimaryKey]";
        public const string CountersSelectAll = "[dbo].[mst_Counters_SelectAll]";
        public const string CountersSelectByField = "[dbo].[mst_Counters_SelectByField]";
        public const string CountersDeleteByPrimaryKey = "[dbo].[mst_Counters_DeleteByPrimaryKey]";
        public const string CountersDeleteByField = "[dbo].[mst_Counters_DeleteByField]";
        public const string CountersSearchCounterData = "[dbo].[mst_Counters_SearchCounterData]";
        public const string CountersSelectLogoutCounter = "[dbo].[mst_Counters_SelectLogoutCounterList]";
        //SPs for  pos_POSPoints
        public const string POSPointsInsert = "[dbo].[pos_POSPoints_Insert]";
        public const string POSPointsUpdate = "[dbo].[pos_POSPoints_Update]";
        public const string POSPointsSelectByPrimaryKey = "[dbo].[pos_POSPoints_SelectByPrimaryKey]";
        public const string POSPointsSelectAll = "[dbo].[pos_POSPoints_SelectAll]";
        public const string POSPointsSelectByField = "[dbo].[pos_POSPoints_SelectByField]";
        public const string POSPointsDeleteByPrimaryKey = "[dbo].[pos_POSPoints_DeleteByPrimaryKey]";
        public const string POSPointsDeleteByField = "[dbo].[pos_POSPoints_DeleteByField]";
        public const string POSPointSearchDate = "[dbo].[pos_POSPoints_SearchData]";
        public const string POSPointSelectAllForItem = "[dbo].[pos_POSPoints_SelectAllForItem]";

        //SPs for  mst_Category
        public const string CategoryInsert = "[dbo].[mst_Category_Insert]";
        public const string CategoryUpdate = "[dbo].[mst_Category_Update]";
        public const string CategorySelectByPrimaryKey = "[dbo].[mst_Category_SelectByPrimaryKey]";
        public const string CategorySelectAll = "[dbo].[mst_Category_SelectAll]";
        public const string CategorySelectByField = "[dbo].[mst_Category_SelectByField]";
        public const string CategoryDeleteByPrimaryKey = "[dbo].[mst_Category_DeleteByPrimaryKey]";
        public const string CategoryDeleteByField = "[dbo].[mst_Category_DeleteByField]";
        public const string CategorySelectCategoryData = "[dbo].[mst_Category_SelectCategoryData]";
        public const string CategorySearchCategory = "[dbo].[mst_Category_SearchCategoryData]";

        //SPs for  mst_ItemAvailability
        public const string ItemAvailabilityInsert = "[dbo].[mst_ItemAvailability_Insert]";
        public const string ItemAvailabilityUpdate = "[dbo].[mst_ItemAvailability_Update]";
        public const string ItemAvailabilitySelectByPrimaryKey = "[dbo].[mst_ItemAvailability_SelectByPrimaryKey]";
        public const string ItemAvailabilitySelectAll = "[dbo].[mst_ItemAvailability_SelectAll]";
        public const string ItemAvailabilitySelectByField = "[dbo].[mst_ItemAvailability_SelectByField]";
        public const string ItemAvailabilityDeleteByPrimaryKey = "[dbo].[mst_ItemAvailability_DeleteByPrimaryKey]";
        public const string ItemAvailabilityDeleteByField = "[dbo].[mst_ItemAvailability_DeleteByField]";
        public const string ItemAvailabilitySelectDataByPosPointsID = "[dbo].[mst_ItemAvailability_SelectDataByPosPointsID]";
        public const string ItemAvailabilitySelectAllItems = "[dbo].[mst_ItemServiceRateJoin_GetAllItems]";

        //SPs for  mst_ItemTax
        public const string ItemTaxInsert = "[dbo].[mst_ItemTax_Insert]";
        public const string ItemTaxUpdate = "[dbo].[mst_ItemTax_Update]";
        public const string ItemTaxSelectByPrimaryKey = "[dbo].[mst_ItemTax_SelectByPrimaryKey]";
        public const string ItemTaxSelectAll = "[dbo].[mst_ItemTax_SelectAll]";
        public const string ItemTaxSelectByField = "[dbo].[mst_ItemTax_SelectByField]";
        public const string ItemTaxDeleteByPrimaryKey = "[dbo].[mst_ItemTax_DeleteByPrimaryKey]";
        public const string ItemTaxDeleteByField = "[dbo].[mst_ItemTax_DeleteByField]";

        //SPs for  mst_ItemUOM
        public const string ItemUOMInsert = "[dbo].[mst_ItemUOM_Insert]";
        public const string ItemUOMUpdate = "[dbo].[mst_ItemUOM_Update]";
        public const string ItemUOMSelectByPrimaryKey = "[dbo].[mst_ItemUOM_SelectByPrimaryKey]";
        public const string ItemUOMSelectAll = "[dbo].[mst_ItemUOM_SelectAll]";
        public const string ItemUOMSelectByField = "[dbo].[mst_ItemUOM_SelectByField]";
        public const string ItemUOMDeleteByPrimaryKey = "[dbo].[mst_ItemUOM_DeleteByPrimaryKey]";
        public const string ItemUOMDeleteByField = "[dbo].[mst_ItemUOM_DeleteByField]";

        //SPs for  mst_Test_Item
        public const string Test_ItemInsert = "[dbo].[mst_Test_Item_Insert]";
        public const string Test_ItemUpdate = "[dbo].[mst_Test_Item_Update]";
        public const string Test_ItemSelectByPrimaryKey = "[dbo].[mst_Test_Item_SelectByPrimaryKey]";
        public const string Test_ItemSelectAll = "[dbo].[mst_Test_Item_SelectAll]";
        public const string Test_ItemSelectByField = "[dbo].[mst_Test_Item_SelectByField]";
        public const string Test_ItemDeleteByPrimaryKey = "[dbo].[mst_Test_Item_DeleteByPrimaryKey]";
        public const string Test_ItemDeleteByField = "[dbo].[mst_Test_Item_DeleteByField]";

        //SPs for  mst_ResourceFiles
        public const string ResourceFilesInsert = "[dbo].[mst_ResourceFiles_Insert]";
        public const string ResourceFilesUpdate = "[dbo].[mst_ResourceFiles_Update]";
        public const string ResourceFilesSelectByPrimaryKey = "[dbo].[mst_ResourceFiles_SelectByPrimaryKey]";
        public const string ResourceFilesSelectAll = "[dbo].[mst_ResourceFiles_SelectAll]";
        public const string ResourceFilesSelectByField = "[dbo].[mst_ResourceFiles_SelectByField]";
        public const string ResourceFilesDeleteByPrimaryKey = "[dbo].[mst_ResourceFiles_DeleteByPrimaryKey]";
        public const string ResourceFilesDeleteByField = "[dbo].[mst_ResourceFiles_DeleteByField]";

        //SPs for  res_ResCancellationPolicy
        public const string ResCancellationPolicyInsert = "[dbo].[res_ResCancellationPolicy_Insert]";
        public const string ResCancellationPolicyUpdate = "[dbo].[res_ResCancellationPolicy_Update]";
        public const string ResCancellationPolicySelectByPrimaryKey = "[dbo].[res_ResCancellationPolicy_SelectByPrimaryKey]";
        public const string ResCancellationPolicySelectAll = "[dbo].[res_ResCancellationPolicy_SelectAll]";
        public const string ResCancellationPolicySelectByField = "[dbo].[res_ResCancellationPolicy_SelectByField]";
        public const string ResCancellationPolicyDeleteByPrimaryKey = "[dbo].[res_ResCancellationPolicy_DeleteByPrimaryKey]";
        public const string ResCancellationPolicyDeleteByField = "[dbo].[res_ResCancellationPolicy_DeleteByField]";
        public const string ResCancellationPolicySearchData = "[dbo].[res_ResCancellationPolicy_SearchData]";

        //SPs for  mst_ItemCategory
        public const string ItemCategoryInsert = "[dbo].[mst_ItemCategory_Insert]";
        public const string ItemCategoryUpdate = "[dbo].[mst_ItemCategory_Update]";
        public const string ItemCategorySelectByPrimaryKey = "[dbo].[mst_ItemCategory_SelectByPrimaryKey]";
        public const string ItemCategorySelectAll = "[dbo].[mst_ItemCategory_SelectAll]";
        public const string ItemCategorySelectByField = "[dbo].[mst_ItemCategory_SelectByField]";
        public const string ItemCategoryDeleteByPrimaryKey = "[dbo].[mst_ItemCategory_DeleteByPrimaryKey]";
        public const string ItemCategoryDeleteByField = "[dbo].[mst_ItemCategory_DeleteByField]";
        public const string ItemCategorySelectItemAndRateFromItemAvailability = "[dbo].[mst_ItemCategory_SelectItemAndRateFromItemAvailability]";
        public const string ItemCategorySelectItemByCategoryID = "[dbo].[mst_ItemCategory_SelectItemByCategoryID]";

        //SPs for  pos_ServiceVendorMaster
        public const string ServiceVendorMasterInsert = "[dbo].[pos_ServiceVendorMaster_Insert]";
        public const string ServiceVendorMasterUpdate = "[dbo].[pos_ServiceVendorMaster_Update]";
        public const string ServiceVendorMasterSelectByPrimaryKey = "[dbo].[pos_ServiceVendorMaster_SelectByPrimaryKey]";
        public const string ServiceVendorMasterSelectAll = "[dbo].[pos_ServiceVendorMaster_SelectAll]";
        public const string ServiceVendorMasterSelectByField = "[dbo].[pos_ServiceVendorMaster_SelectByField]";
        public const string ServiceVendorMasterDeleteByPrimaryKey = "[dbo].[pos_ServiceVendorMaster_DeleteByPrimaryKey]";
        public const string ServiceVendorMasterDeleteByField = "[dbo].[pos_ServiceVendorMaster_DeleteByField]";
        public const string ServiceVendorMasterSearchData = "[dbo].[pos_ServiceVendorMaster_SearchData]";

        //SPs for  mst_CategoryPOSPoints
        public const string CategoryPOSPointsInsert = "[dbo].[mst_CategoryPOSPoints_Insert]";
        public const string CategoryPOSPointsUpdate = "[dbo].[mst_CategoryPOSPoints_Update]";
        public const string CategoryPOSPointsSelectByPrimaryKey = "[dbo].[mst_CategoryPOSPoints_SelectByPrimaryKey]";
        public const string CategoryPOSPointsSelectAll = "[dbo].[mst_CategoryPOSPoints_SelectAll]";
        public const string CategoryPOSPointsSelectByField = "[dbo].[mst_CategoryPOSPoints_SelectByField]";
        public const string CategoryPOSPointsDeleteByPrimaryKey = "[dbo].[mst_CategoryPOSPoints_DeleteByPrimaryKey]";
        public const string CategoryPOSPointsDeleteByField = "[dbo].[mst_CategoryPOSPoints_DeleteByField]";

        //SPs for  res_CancellationPolicy
        public const string CancellationPolicyInsert = "[dbo].[res_CancellationPolicy_Insert]";
        public const string CancellationPolicyUpdate = "[dbo].[res_CancellationPolicy_Update]";
        public const string CancellationPolicySelectByPrimaryKey = "[dbo].[res_CancellationPolicy_SelectByPrimaryKey]";
        public const string CancellationPolicySelectAll = "[dbo].[res_CancellationPolicy_SelectAll]";
        public const string CancellationPolicySelectByField = "[dbo].[res_CancellationPolicy_SelectByField]";
        public const string CancellationPolicyDeleteByPrimaryKey = "[dbo].[res_CancellationPolicy_DeleteByPrimaryKey]";
        public const string CancellationPolicyDeleteByField = "[dbo].[res_CancellationPolicy_DeleteByField]";

        //SPs for  res_CancellationPolicyMaster
        public const string CancellationPolicyMasterInsert = "[dbo].[res_CancellationPolicyMaster_Insert]";
        public const string CancellationPolicyMasterUpdate = "[dbo].[res_CancellationPolicyMaster_Update]";
        public const string CancellationPolicyMasterSelectByPrimaryKey = "[dbo].[res_CancellationPolicyMaster_SelectByPrimaryKey]";
        public const string CancellationPolicyMasterSelectAll = "[dbo].[res_CancellationPolicyMaster_SelectAll]";
        public const string CancellationPolicyMasterSelectByField = "[dbo].[res_CancellationPolicyMaster_SelectByField]";
        public const string CancellationPolicyMasterDeleteByPrimaryKey = "[dbo].[res_CancellationPolicyMaster_DeleteByPrimaryKey]";
        public const string CancellationPolicyMasterDeleteByField = "[dbo].[res_CancellationPolicyMaster_DeleteByField]";

        public const string CancellationPolicySortBySeqNoSelectByField = "[dbo].[res_CancellationPolicySortBySeqNo_SelectByField]";
        public const string CancellationPolicyDeleteByPolicyID = "[dbo].[res_CancellationPolicy_DeleteByResPolicyID]";

        //SPs for  mst_RoomTypeServices
        public const string RoomTypeServicesInsert = "[dbo].[mst_RoomTypeServices_Insert]";
        public const string RoomTypeServicesUpdate = "[dbo].[mst_RoomTypeServices_Update]";
        public const string RoomTypeServicesSelectByPrimaryKey = "[dbo].[mst_RoomTypeServices_SelectByPrimaryKey]";
        public const string RoomTypeServicesSelectAll = "[dbo].[mst_RoomTypeServices_SelectAll]";
        public const string RoomTypeServicesSelectByField = "[dbo].[mst_RoomTypeServices_SelectByField]";
        public const string RoomTypeServicesDeleteByPrimaryKey = "[dbo].[mst_RoomTypeServices_DeleteByPrimaryKey]";
        public const string RoomTypeServicesDeleteByField = "[dbo].[mst_RoomTypeServices_DeleteByField]";
        public const string RoomTypeServicesDeleteByRoomTypeID = "[dbo].[mst_RoomTypeServices_DeleteByRoomTypeID]";

        public const string UserSelectModule = "[dbo].[usr_SelectModule]";


        //SPs for  mst_Transcript
        public const string TranscriptInsert = "[dbo].[mst_Transcript_Insert]";
        public const string TranscriptUpdate = "[dbo].[mst_Transcript_Update]";
        public const string TranscriptSelectByPrimaryKey = "[dbo].[mst_Transcript_SelectByPrimaryKey]";
        public const string TranscriptSelectAll = "[dbo].[mst_Transcript_SelectAll]";
        public const string TranscriptSelectByField = "[dbo].[mst_Transcript_SelectByField]";
        public const string TranscriptDeleteByPrimaryKey = "[dbo].[mst_Transcript_DeleteByPrimaryKey]";
        public const string TranscriptDeleteByField = "[dbo].[mst_Transcript_DeleteByField]";
        public const string TranscriptSearchData = "[mst_Transcript_SearchData]";

        //SPs for  mst_Recovery
        public const string RecoveryInsert = "[dbo].[mst_Recovery_Insert]";
        public const string RecoveryUpdate = "[dbo].[mst_Recovery_Update]";
        public const string RecoverySelectByPrimaryKey = "[dbo].[mst_Recovery_SelectByPrimaryKey]";
        public const string RecoverySelectAll = "[dbo].[mst_Recovery_SelectAll]";
        public const string RecoverySelectByField = "[dbo].[mst_Recovery_SelectByField]";
        public const string RecoveryDeleteByPrimaryKey = "[dbo].[mst_Recovery_DeleteByPrimaryKey]";
        public const string RecoveryDeleteByField = "[dbo].[mst_Recovery_DeleteByField]";
        public const string RecoverySearchData = "[mst_Recovery_SearchData]";

        //SPs for  mst_CalenderEvent
        public const string CalenderEventInsert = "[dbo].[mst_CalenderEvent_Insert]";
        public const string CalenderEventUpdate = "[dbo].[mst_CalenderEvent_Update]";
        public const string CalenderEventSelectByPrimaryKey = "[dbo].[mst_CalenderEvent_SelectByPrimaryKey]";
        public const string CalenderEventSelectAll = "[dbo].[mst_CalenderEvent_SelectAll]";
        public const string CalenderEventSelectByField = "[dbo].[mst_CalenderEvent_SelectByField]";
        public const string CalenderEventDeleteByPrimaryKey = "[dbo].[mst_CalenderEvent_DeleteByPrimaryKey]";
        public const string CalenderEventDeleteByField = "[dbo].[mst_CalenderEvent_DeleteByField]";
        public const string CalenderEventDeleteDataByDateAndRateID = "[dbo].[mst_CalenderEvent_DeleteDataByDateAndRateID]";
        public const string CalenderEventDeleteDataByRateID = "[dbo].[mst_CalenderEvent_DeleteDataByRateID]";

        //SPs for  acc_TaxRate
        public const string TaxRateInsert = "[dbo].[acc_TaxRate_Insert]";
        public const string TaxRateUpdate = "[dbo].[acc_TaxRate_Update]";
        public const string TaxRateSelectByPrimaryKey = "[dbo].[acc_TaxRate_SelectByPrimaryKey]";
        public const string TaxRateSelectAll = "[dbo].[acc_TaxRate_SelectAll]";
        public const string TaxRateSelectByField = "[dbo].[acc_TaxRate_SelectByField]";
        public const string TaxRateDeleteByPrimaryKey = "[dbo].[acc_TaxRate_DeleteByPrimaryKey]";
        public const string TaxRateDeleteByField = "[dbo].[acc_TaxRate_DeleteByField]";
        public const string TaxRateSelectAllDataByTaxID = "[dbo].[acc_TaxRate_SelectAllDataByTaxID]";
        public const string DeleteByTaxID = "[dbo].[acc_TaxRate_DeleteByTaxID]";

        //SPs for  acc_TaxSlabe
        public const string TaxSlabeInsert = "[dbo].[acc_TaxSlabe_Insert]";
        public const string TaxSlabeUpdate = "[dbo].[acc_TaxSlabe_Update]";
        public const string TaxSlabeSelectByPrimaryKey = "[dbo].[acc_TaxSlabe_SelectByPrimaryKey]";
        public const string TaxSlabeSelectAll = "[dbo].[acc_TaxSlabe_SelectAll]";
        public const string TaxSlabeSelectByField = "[dbo].[acc_TaxSlabe_SelectByField]";
        public const string TaxSlabeDeleteByPrimaryKey = "[dbo].[acc_TaxSlabe_DeleteByPrimaryKey]";
        public const string TaxSlabeDeleteByField = "[dbo].[acc_TaxSlabe_DeleteByField]";
        public const string TaxSlabeSelectAllDataByTaxID = "[dbo].[acc_TaxSlabe_SelectAllDataByTaxID]";


        //SPs for  mst_PreferenceMaster
        public const string PreferenceMasterInsert = "[dbo].[mst_PreferenceMaster_Insert]";
        public const string PreferenceMasterUpdate = "[dbo].[mst_PreferenceMaster_Update]";
        public const string PreferenceMasterSelectByPrimaryKey = "[dbo].[mst_PreferenceMaster_SelectByPrimaryKey]";
        public const string PreferenceMasterSelectAll = "[dbo].[mst_PreferenceMaster_SelectAll]";
        public const string PreferenceMasterSelectByField = "[dbo].[mst_PreferenceMaster_SelectByField]";
        public const string PreferenceMasterDeleteByPrimaryKey = "[dbo].[mst_PreferenceMaster_DeleteByPrimaryKey]";
        public const string PreferenceMasterDeleteByField = "[dbo].[mst_PreferenceMaster_DeleteByField]";
        public const string PreferenceMasterSelectAllForList = "[dbo].[mst_PreferenceMaster_SelectAllForList]";
        public const string PreferenceMasterSearchByPreferenceName = "[dbo].[mst_PreferenceMaster_SearchBy_PreferenceName]";

        //SPs for  usr_CounterLoginLog
        public const string CounterLoginLogInsert = "[dbo].[usr_CounterLoginLog_Insert]";
        public const string CounterLoginLogUpdate = "[dbo].[usr_CounterLoginLog_Update]";
        public const string CounterLoginLogSelectByPrimaryKey = "[dbo].[usr_CounterLoginLog_SelectByPrimaryKey]";
        public const string CounterLoginLogSelectAll = "[dbo].[usr_CounterLoginLog_SelectAll]";
        public const string CounterLoginLogSelectByField = "[dbo].[usr_CounterLoginLog_SelectByField]";
        public const string CounterLoginLogDeleteByPrimaryKey = "[dbo].[usr_CounterLoginLog_DeleteByPrimaryKey]";
        public const string CounterLoginLogDeleteByField = "[dbo].[usr_CounterLoginLog_DeleteByField]";
        public const string CounterLoginLogSelectDetails = "[dbo].[usr_CounterLoginLog_SelectCounterDetails]";

        public const string ReservationSaveCounterCloseData = "[dbo].[acc_Reservation_SaveCounterClose]";
        public const string ReservationSelectCounterCloseRport = "[dbo].[acc_Reservation_CounterCloseRport]";
        public const string ReservationCounterAdjustment = "[dbo].[acc_ShortCounter_Adjustment]";
        public const string ReservationCounterSelectBeginingAmount = "[dbo].[mst_Counter_Close_Select]";
        public const string Counter_CounterCloseDetailRport = "[dbo].[acc_Reservation_CounterCloseDetailRport]";
        public const string Counter_GenerateLedgerReports = "[dbo].[acc_GenerateLedgerReports]";
        public const string CounterClose_SelectCounterCloseSummary = "[dbo].[mst_CounterClose_Summary_Select]";

        //SPs for  mst_Counter_Close_Detail
        public const string Counter_Close_DetailInsert = "[dbo].[mst_Counter_Close_Detail_Insert]";
        public const string Counter_Close_DetailUpdate = "[dbo].[mst_Counter_Close_Detail_Update]";
        public const string Counter_Close_DetailSelectByPrimaryKey = "[dbo].[mst_Counter_Close_Detail_SelectByPrimaryKey]";
        public const string Counter_Close_DetailSelectAll = "[dbo].[mst_Counter_Close_Detail_SelectAll]";
        public const string Counter_Close_DetailSelectByField = "[dbo].[mst_Counter_Close_Detail_SelectByField]";
        public const string Counter_Close_DetailDeleteByPrimaryKey = "[dbo].[mst_Counter_Close_Detail_DeleteByPrimaryKey]";
        public const string Counter_Close_DetailDeleteByField = "[dbo].[mst_Counter_Close_Detail_DeleteByField]";
        public const string Counter_Close_DetailDenomination = "[dbo].[rpt_CounterCloseDetail_Denomination]";
        public const string Counter_Close_GeneralInformation = "[dbo].[rpt_Counter_Close_GeneralInformation]";
        //SPs for  mst_CounterClose_Summary
        public const string CounterClose_SummaryInsert = "[dbo].[mst_CounterClose_Summary_Insert]";
        public const string CounterClose_SummaryUpdate = "[dbo].[mst_CounterClose_Summary_Update]";
        public const string CounterClose_SummarySelectByPrimaryKey = "[dbo].[mst_CounterClose_Summary_SelectByPrimaryKey]";
        public const string CounterClose_SummarySelectAll = "[dbo].[mst_CounterClose_Summary_SelectAll]";
        public const string CounterClose_SummarySelectByField = "[dbo].[mst_CounterClose_Summary_SelectByField]";
        public const string CounterClose_SummaryDeleteByPrimaryKey = "[dbo].[mst_CounterClose_Summary_DeleteByPrimaryKey]";
        public const string CounterClose_SummaryDeleteByField = "[dbo].[mst_CounterClose_Summary_DeleteByField]";

        //SPs for  con_CurrencyType
        public const string CurrencyTypeInsert = "[dbo].[con_CurrencyType_Insert]";
        public const string CurrencyTypeUpdate = "[dbo].[con_CurrencyType_Update]";
        public const string CurrencyTypeSelectByPrimaryKey = "[dbo].[con_CurrencyType_SelectByPrimaryKey]";
        public const string CurrencyTypeSelectAll = "[dbo].[con_CurrencyType_SelectAll]";
        public const string CurrencyTypeSelectByField = "[dbo].[con_CurrencyType_SelectByField]";
        public const string CurrencyTypeDeleteByPrimaryKey = "[dbo].[con_CurrencyType_DeleteByPrimaryKey]";
        public const string CurrencyTypeDeleteByField = "[dbo].[con_CurrencyType_DeleteByField]";

        //SPs for  mst_SalerParner
        public const string SalerPartnerInsert = "[dbo].[mst_SalerPartner_Insert]";
        public const string SalerPartnerGetAll = "[dbo].[mst_SalerPartner_GetAll]";
        public const string GetByIdWise_SalePartnerData = "[dbo].[mst_SalePartnerData_GetByIdWise]";
        public const string SalerDelete_IdWise = "[dbo].[mst_SalerDelete_IdWise]";
        public const string SalerPartnerUpdate = "[dbo].[mst_SalerPartner_Update]";

        //SPs for  mst_Vendor
        public const string VendorInsert = "[dbo].[mst_Vendor_Insert]";
        public const string VendorGetAll = "[dbo].[mst_Vendor_GetAll]";
        public const string GetByIdWise_VendorData = "[dbo].[mst_VendorData_GetByIdWise]";
        public const string VendorDelete_IdWise = "[dbo].[mst_VendorDelete_IdWise]";
        public const string VendorUpdate = "[dbo].[mst_Vendor_Update]";

        //SPs for mst_Expense
        public const string GetPropertyName = "[dbo].[mst_Expense_PropertyGetName]";
        public const string GetVendorName = "[dbo].[mst_Expense_VendorGetName]";
        public const string ExpenseInsert = "[dbo].[mst_Expense_Insert]";
        public const string ExpenseUpdate = "[dbo].[mst_Expense_Update]";
        public const string Multiple_ExpenseInsert = "[dbo].[mst_ExpenseDetail_Insert]";
        public const string ExpenseGetAll = "[dbo].[mst_Expense_GetAll]";
        public const string GetByIdWise_ExpenseData = "[dbo].[mst_Expense_GetByIdWise]";
        public const string Multiple_ExpenseUpdate = "[dbo].[mst_ExpenseDetail_Update]";
        public const string ExpenseDelete_IdWise = "[dbo].[mst_ExpenseDelete_IdWise]";
    }
}

