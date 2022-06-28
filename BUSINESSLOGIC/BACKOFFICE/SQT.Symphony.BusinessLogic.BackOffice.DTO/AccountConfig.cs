using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;
namespace SQT.Symphony.BusinessLogic.BackOffice.DTO
{
	[DataContract]
	public class AccountConfig: BusinessObjectBase
	{

		#region InnerClass
		public enum AccountConfigFields
		{
			AcctConfigID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			AccountingMethod_TermID,
			IsStockInHandCompulsoryBeforeSold,
			IsBillRequiredBeforePayment,
			IsUpdateStockOnReceiveGoods,
			IsUpdateStockOnDeliveryChallan,
			IsPartialPaymentAllowed,
			IsPostingDoneAutomatically,
			IsPostingRemainderAtNightAudit,
			IsAutoGenAcctCode,
			IsAutoGenItemCode,
			IsAutoGenAgentCode,
			IsAutoGenCustomerCode,
			IsAutoGenGuestCode,
			IsAutoGenVendorCode,
			CurrentFinancialYearID,
			DefaultCurrencyID,
			CurrencyConversionRate,
			IsAutoConversion,
			IsTaxBreakUpInInvoice,
			IsAdjustmentAllowed,
			DecimalPlaces,
			AccountFolioDate_TermID,
			IsCounterCompulsoryOnPosting,
			IsCounterLoginCoumpOnDayEnd,
			IsInclusiveTax
		}
		#endregion

		#region Data Members

			Guid _acctConfigID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			Guid? _accountingMethod_TermID;
			bool? _isStockInHandCompulsoryBeforeSold;
			bool? _isBillRequiredBeforePayment;
			bool? _isUpdateStockOnReceiveGoods;
			bool? _isUpdateStockOnDeliveryChallan;
			bool? _isPartialPaymentAllowed;
			bool? _isPostingDoneAutomatically;
			bool? _isPostingRemainderAtNightAudit;
			bool? _isAutoGenAcctCode;
			bool? _isAutoGenItemCode;
			bool? _isAutoGenAgentCode;
			bool? _isAutoGenCustomerCode;
			bool? _isAutoGenGuestCode;
			bool? _isAutoGenVendorCode;
			Guid? _currentFinancialYearID;
			Guid? _defaultCurrencyID;
			decimal? _currencyConversionRate;
			bool? _isAutoConversion;
			bool? _isTaxBreakUpInInvoice;
			bool? _isAdjustmentAllowed;
			int? _decimalPlaces;
			Guid? _accountFolioDate_TermID;
			bool? _isCounterCompulsoryOnPosting;
			bool? _isCounterLoginCoumpOnDayEnd;
			bool? _isInclusiveTax;

		#endregion

		#region Properties

		[DataMember]
		public Guid  AcctConfigID
		{
			 get { return _acctConfigID; }
			 set
			 {
				 if (_acctConfigID != value)
				 {
					_acctConfigID = value;
					 PropertyHasChanged("AcctConfigID");
				 }
			 }
		}

		[DataMember]
		public Guid?  PropertyID
		{
			 get { return _propertyID; }
			 set
			 {
				 if (_propertyID != value)
				 {
					_propertyID = value;
					 PropertyHasChanged("PropertyID");
				 }
			 }
		}

		[DataMember]
		public Guid?  CompanyID
		{
			 get { return _companyID; }
			 set
			 {
				 if (_companyID != value)
				 {
					_companyID = value;
					 PropertyHasChanged("CompanyID");
				 }
			 }
		}

		[DataMember]
		public int  SeqNo
		{
			 get { return _seqNo; }
			 set
			 {
				 if (_seqNo != value)
				 {
					_seqNo = value;
					 PropertyHasChanged("SeqNo");
				 }
			 }
		}

		[DataMember]
		public bool?  IsSynch
		{
			 get { return _isSynch; }
			 set
			 {
				 if (_isSynch != value)
				 {
					_isSynch = value;
					 PropertyHasChanged("IsSynch");
				 }
			 }
		}

		[DataMember]
		public DateTime?  SynchOn
		{
			 get { return _synchOn; }
			 set
			 {
				 if (_synchOn != value)
				 {
					_synchOn = value;
					 PropertyHasChanged("SynchOn");
				 }
			 }
		}

		[DataMember]
		public DateTime?  UpdatedOn
		{
			 get { return _updatedOn; }
			 set
			 {
				 if (_updatedOn != value)
				 {
					_updatedOn = value;
					 PropertyHasChanged("UpdatedOn");
				 }
			 }
		}

		[DataMember]
		public Guid?  UpdatedBy
		{
			 get { return _updatedBy; }
			 set
			 {
				 if (_updatedBy != value)
				 {
					_updatedBy = value;
					 PropertyHasChanged("UpdatedBy");
				 }
			 }
		}

		[DataMember]
		public bool?  IsActive
		{
			 get { return _isActive; }
			 set
			 {
				 if (_isActive != value)
				 {
					_isActive = value;
					 PropertyHasChanged("IsActive");
				 }
			 }
		}

		[DataMember]
		public Guid?  AccountingMethod_TermID
		{
			 get { return _accountingMethod_TermID; }
			 set
			 {
				 if (_accountingMethod_TermID != value)
				 {
					_accountingMethod_TermID = value;
					 PropertyHasChanged("AccountingMethod_TermID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsStockInHandCompulsoryBeforeSold
		{
			 get { return _isStockInHandCompulsoryBeforeSold; }
			 set
			 {
				 if (_isStockInHandCompulsoryBeforeSold != value)
				 {
					_isStockInHandCompulsoryBeforeSold = value;
					 PropertyHasChanged("IsStockInHandCompulsoryBeforeSold");
				 }
			 }
		}

		[DataMember]
		public bool?  IsBillRequiredBeforePayment
		{
			 get { return _isBillRequiredBeforePayment; }
			 set
			 {
				 if (_isBillRequiredBeforePayment != value)
				 {
					_isBillRequiredBeforePayment = value;
					 PropertyHasChanged("IsBillRequiredBeforePayment");
				 }
			 }
		}

		[DataMember]
		public bool?  IsUpdateStockOnReceiveGoods
		{
			 get { return _isUpdateStockOnReceiveGoods; }
			 set
			 {
				 if (_isUpdateStockOnReceiveGoods != value)
				 {
					_isUpdateStockOnReceiveGoods = value;
					 PropertyHasChanged("IsUpdateStockOnReceiveGoods");
				 }
			 }
		}

		[DataMember]
		public bool?  IsUpdateStockOnDeliveryChallan
		{
			 get { return _isUpdateStockOnDeliveryChallan; }
			 set
			 {
				 if (_isUpdateStockOnDeliveryChallan != value)
				 {
					_isUpdateStockOnDeliveryChallan = value;
					 PropertyHasChanged("IsUpdateStockOnDeliveryChallan");
				 }
			 }
		}

		[DataMember]
		public bool?  IsPartialPaymentAllowed
		{
			 get { return _isPartialPaymentAllowed; }
			 set
			 {
				 if (_isPartialPaymentAllowed != value)
				 {
					_isPartialPaymentAllowed = value;
					 PropertyHasChanged("IsPartialPaymentAllowed");
				 }
			 }
		}

		[DataMember]
		public bool?  IsPostingDoneAutomatically
		{
			 get { return _isPostingDoneAutomatically; }
			 set
			 {
				 if (_isPostingDoneAutomatically != value)
				 {
					_isPostingDoneAutomatically = value;
					 PropertyHasChanged("IsPostingDoneAutomatically");
				 }
			 }
		}

		[DataMember]
		public bool?  IsPostingRemainderAtNightAudit
		{
			 get { return _isPostingRemainderAtNightAudit; }
			 set
			 {
				 if (_isPostingRemainderAtNightAudit != value)
				 {
					_isPostingRemainderAtNightAudit = value;
					 PropertyHasChanged("IsPostingRemainderAtNightAudit");
				 }
			 }
		}

		[DataMember]
		public bool?  IsAutoGenAcctCode
		{
			 get { return _isAutoGenAcctCode; }
			 set
			 {
				 if (_isAutoGenAcctCode != value)
				 {
					_isAutoGenAcctCode = value;
					 PropertyHasChanged("IsAutoGenAcctCode");
				 }
			 }
		}

		[DataMember]
		public bool?  IsAutoGenItemCode
		{
			 get { return _isAutoGenItemCode; }
			 set
			 {
				 if (_isAutoGenItemCode != value)
				 {
					_isAutoGenItemCode = value;
					 PropertyHasChanged("IsAutoGenItemCode");
				 }
			 }
		}

		[DataMember]
		public bool?  IsAutoGenAgentCode
		{
			 get { return _isAutoGenAgentCode; }
			 set
			 {
				 if (_isAutoGenAgentCode != value)
				 {
					_isAutoGenAgentCode = value;
					 PropertyHasChanged("IsAutoGenAgentCode");
				 }
			 }
		}

		[DataMember]
		public bool?  IsAutoGenCustomerCode
		{
			 get { return _isAutoGenCustomerCode; }
			 set
			 {
				 if (_isAutoGenCustomerCode != value)
				 {
					_isAutoGenCustomerCode = value;
					 PropertyHasChanged("IsAutoGenCustomerCode");
				 }
			 }
		}

		[DataMember]
		public bool?  IsAutoGenGuestCode
		{
			 get { return _isAutoGenGuestCode; }
			 set
			 {
				 if (_isAutoGenGuestCode != value)
				 {
					_isAutoGenGuestCode = value;
					 PropertyHasChanged("IsAutoGenGuestCode");
				 }
			 }
		}

		[DataMember]
		public bool?  IsAutoGenVendorCode
		{
			 get { return _isAutoGenVendorCode; }
			 set
			 {
				 if (_isAutoGenVendorCode != value)
				 {
					_isAutoGenVendorCode = value;
					 PropertyHasChanged("IsAutoGenVendorCode");
				 }
			 }
		}

		[DataMember]
		public Guid?  CurrentFinancialYearID
		{
			 get { return _currentFinancialYearID; }
			 set
			 {
				 if (_currentFinancialYearID != value)
				 {
					_currentFinancialYearID = value;
					 PropertyHasChanged("CurrentFinancialYearID");
				 }
			 }
		}

		[DataMember]
		public Guid?  DefaultCurrencyID
		{
			 get { return _defaultCurrencyID; }
			 set
			 {
				 if (_defaultCurrencyID != value)
				 {
					_defaultCurrencyID = value;
					 PropertyHasChanged("DefaultCurrencyID");
				 }
			 }
		}

		[DataMember]
		public decimal?  CurrencyConversionRate
		{
			 get { return _currencyConversionRate; }
			 set
			 {
				 if (_currencyConversionRate != value)
				 {
					_currencyConversionRate = value;
					 PropertyHasChanged("CurrencyConversionRate");
				 }
			 }
		}

		[DataMember]
		public bool?  IsAutoConversion
		{
			 get { return _isAutoConversion; }
			 set
			 {
				 if (_isAutoConversion != value)
				 {
					_isAutoConversion = value;
					 PropertyHasChanged("IsAutoConversion");
				 }
			 }
		}

		[DataMember]
		public bool?  IsTaxBreakUpInInvoice
		{
			 get { return _isTaxBreakUpInInvoice; }
			 set
			 {
				 if (_isTaxBreakUpInInvoice != value)
				 {
					_isTaxBreakUpInInvoice = value;
					 PropertyHasChanged("IsTaxBreakUpInInvoice");
				 }
			 }
		}

		[DataMember]
		public bool?  IsAdjustmentAllowed
		{
			 get { return _isAdjustmentAllowed; }
			 set
			 {
				 if (_isAdjustmentAllowed != value)
				 {
					_isAdjustmentAllowed = value;
					 PropertyHasChanged("IsAdjustmentAllowed");
				 }
			 }
		}

		[DataMember]
		public int?  DecimalPlaces
		{
			 get { return _decimalPlaces; }
			 set
			 {
				 if (_decimalPlaces != value)
				 {
					_decimalPlaces = value;
					 PropertyHasChanged("DecimalPlaces");
				 }
			 }
		}

		[DataMember]
		public Guid?  AccountFolioDate_TermID
		{
			 get { return _accountFolioDate_TermID; }
			 set
			 {
				 if (_accountFolioDate_TermID != value)
				 {
					_accountFolioDate_TermID = value;
					 PropertyHasChanged("AccountFolioDate_TermID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsCounterCompulsoryOnPosting
		{
			 get { return _isCounterCompulsoryOnPosting; }
			 set
			 {
				 if (_isCounterCompulsoryOnPosting != value)
				 {
					_isCounterCompulsoryOnPosting = value;
					 PropertyHasChanged("IsCounterCompulsoryOnPosting");
				 }
			 }
		}

		[DataMember]
		public bool?  IsCounterLoginCoumpOnDayEnd
		{
			 get { return _isCounterLoginCoumpOnDayEnd; }
			 set
			 {
				 if (_isCounterLoginCoumpOnDayEnd != value)
				 {
					_isCounterLoginCoumpOnDayEnd = value;
					 PropertyHasChanged("IsCounterLoginCoumpOnDayEnd");
				 }
			 }
		}

		[DataMember]
		public bool?  IsInclusiveTax
		{
			 get { return _isInclusiveTax; }
			 set
			 {
				 if (_isInclusiveTax != value)
				 {
					_isInclusiveTax = value;
					 PropertyHasChanged("IsInclusiveTax");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("AcctConfigID", "AcctConfigID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"AcctConfigID = {0}\n"+
			"PropertyID = {1}\n"+
			"CompanyID = {2}\n"+
			"SeqNo = {3}\n"+
			"IsSynch = {4}\n"+
			"SynchOn = {5}\n"+
			"UpdatedOn = {6}\n"+
			"UpdatedBy = {7}\n"+
			"IsActive = {8}\n"+
			"AccountingMethod_TermID = {9}\n"+
			"IsStockInHandCompulsoryBeforeSold = {10}\n"+
			"IsBillRequiredBeforePayment = {11}\n"+
			"IsUpdateStockOnReceiveGoods = {12}\n"+
			"IsUpdateStockOnDeliveryChallan = {13}\n"+
			"IsPartialPaymentAllowed = {14}\n"+
			"IsPostingDoneAutomatically = {15}\n"+
			"IsPostingRemainderAtNightAudit = {16}\n"+
			"IsAutoGenAcctCode = {17}\n"+
			"IsAutoGenItemCode = {18}\n"+
			"IsAutoGenAgentCode = {19}\n"+
			"IsAutoGenCustomerCode = {20}\n"+
			"IsAutoGenGuestCode = {21}\n"+
			"IsAutoGenVendorCode = {22}\n"+
			"CurrentFinancialYearID = {23}\n"+
			"DefaultCurrencyID = {24}\n"+
			"CurrencyConversionRate = {25}\n"+
			"IsAutoConversion = {26}\n"+
			"IsTaxBreakUpInInvoice = {27}\n"+
			"IsAdjustmentAllowed = {28}\n"+
			"DecimalPlaces = {29}\n"+
			"AccountFolioDate_TermID = {30}\n"+
			"IsCounterCompulsoryOnPosting = {31}\n"+
			"IsCounterLoginCoumpOnDayEnd = {32}\n"+
			"IsInclusiveTax = {33}\n",
			AcctConfigID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			AccountingMethod_TermID,			IsStockInHandCompulsoryBeforeSold,			IsBillRequiredBeforePayment,			IsUpdateStockOnReceiveGoods,			IsUpdateStockOnDeliveryChallan,			IsPartialPaymentAllowed,			IsPostingDoneAutomatically,			IsPostingRemainderAtNightAudit,			IsAutoGenAcctCode,			IsAutoGenItemCode,			IsAutoGenAgentCode,			IsAutoGenCustomerCode,			IsAutoGenGuestCode,			IsAutoGenVendorCode,			CurrentFinancialYearID,			DefaultCurrencyID,			CurrencyConversionRate,			IsAutoConversion,			IsTaxBreakUpInInvoice,			IsAdjustmentAllowed,			DecimalPlaces,			AccountFolioDate_TermID,			IsCounterCompulsoryOnPosting,			IsCounterLoginCoumpOnDayEnd,			IsInclusiveTax);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class AccountConfigKeys
	{

		#region Data Members

		Guid _acctConfigID;

		#endregion

		#region Constructor

		public AccountConfigKeys(Guid acctConfigID)
		{
			 _acctConfigID = acctConfigID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  AcctConfigID
		{
			 get { return _acctConfigID; }
		}

		#endregion

	}
}
