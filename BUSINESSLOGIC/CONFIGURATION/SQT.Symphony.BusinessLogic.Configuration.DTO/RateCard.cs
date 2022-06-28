using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;
namespace SQT.Symphony.BusinessLogic.Configuration.DTO
{
	[DataContract]
	public class RateCard: BusinessObjectBase
	{

		#region InnerClass
		public enum RateCardFields
		{
			RateID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			StayTypeID,
			RateType_TermID,
			Code,
			RateCardName,
			AcctID,
			StartDate,
			EndDate,
			PostingFreq_TermID,
			NonRevenueChildren,
			PkgNoOfNight,
			PkgNoOfAdult,
			DepositID,
			IsCheckInSunday,
			IsCheckInMonday,
			IsCheckInTuesday,
			IsCheckInWednesday,
			IsCheckInThursday,
			IsCheckInFriday,
			IsCheckInSaturday,
			RateCardDetails,
			TermsAndCondition,
			IsEnable,
			IsYieldEnable,
			IsEventChargeEnable,
			IsRateInclService,
			IsDefault,
            IsStandard,
            MinimumDaysRequired,
            CancellationPolicyID,
            IsPerRoom,
            RateCardDispName,
            RetentionChargePercent
		}
		#endregion

		#region Data Members

			Guid _rateID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			Guid? _stayTypeID;
			Guid _rateType_TermID;
			string _code;
			string _rateCardName;
			Guid? _acctID;
			DateTime? _startDate;
			DateTime? _endDate;
			Guid? _postingFreq_TermID;
			int? _nonRevenueChildren;
			int? _pkgNoOfNight;
			int? _pkgNoOfAdult;
			Guid? _depositID;
			bool? _isCheckInSunday;
			bool? _isCheckInMonday;
			bool? _isCheckInTuesday;
			bool? _isCheckInWednesday;
			bool? _isCheckInThursday;
			bool? _isCheckInFriday;
			bool? _isCheckInSaturday;
			string _rateCardDetails;
			string _termsAndCondition;
			bool? _isEnable;
			bool? _isYieldEnable;
			bool? _isEventChargeEnable;
			bool? _isRateInclService;
			bool? _isDefault;
            string _rateTypeName;
            bool? _IsStandard;
            int? _minimumDaysRequired;
            Guid? _cancellationPolicyID;
            bool? _isPerRoom;
            string _rateCardDispName;
            int? _retentionChargePercent;

		#endregion

		#region Properties

		[DataMember]
		public Guid  RateID
		{
			 get { return _rateID; }
			 set
			 {
				 if (_rateID != value)
				 {
					_rateID = value;
					 PropertyHasChanged("RateID");
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
		public Guid?  StayTypeID
		{
			 get { return _stayTypeID; }
			 set
			 {
				 if (_stayTypeID != value)
				 {
					_stayTypeID = value;
					 PropertyHasChanged("StayTypeID");
				 }
			 }
		}

		[DataMember]
		public Guid  RateType_TermID
		{
			 get { return _rateType_TermID; }
			 set
			 {
				 if (_rateType_TermID != value)
				 {
					_rateType_TermID = value;
					 PropertyHasChanged("RateType_TermID");
				 }
			 }
		}

		[DataMember]
		public string  Code
		{
			 get { return _code; }
			 set
			 {
				 if (_code != value)
				 {
					_code = value;
					 PropertyHasChanged("Code");
				 }
			 }
		}

		[DataMember]
		public string  RateCardName
		{
			 get { return _rateCardName; }
			 set
			 {
				 if (_rateCardName != value)
				 {
					_rateCardName = value;
					 PropertyHasChanged("RateCardName");
				 }
			 }
		}

		[DataMember]
		public Guid?  AcctID
		{
			 get { return _acctID; }
			 set
			 {
				 if (_acctID != value)
				 {
					_acctID = value;
					 PropertyHasChanged("AcctID");
				 }
			 }
		}

		[DataMember]
		public DateTime?  StartDate
		{
			 get { return _startDate; }
			 set
			 {
				 if (_startDate != value)
				 {
					_startDate = value;
					 PropertyHasChanged("StartDate");
				 }
			 }
		}

		[DataMember]
		public DateTime?  EndDate
		{
			 get { return _endDate; }
			 set
			 {
				 if (_endDate != value)
				 {
					_endDate = value;
					 PropertyHasChanged("EndDate");
				 }
			 }
		}

		[DataMember]
		public Guid?  PostingFreq_TermID
		{
			 get { return _postingFreq_TermID; }
			 set
			 {
				 if (_postingFreq_TermID != value)
				 {
					_postingFreq_TermID = value;
					 PropertyHasChanged("PostingFreq_TermID");
				 }
			 }
		}

		[DataMember]
		public int?  NonRevenueChildren
		{
			 get { return _nonRevenueChildren; }
			 set
			 {
				 if (_nonRevenueChildren != value)
				 {
					_nonRevenueChildren = value;
					 PropertyHasChanged("NonRevenueChildren");
				 }
			 }
		}

		[DataMember]
		public int?  PkgNoOfNight
		{
			 get { return _pkgNoOfNight; }
			 set
			 {
				 if (_pkgNoOfNight != value)
				 {
					_pkgNoOfNight = value;
					 PropertyHasChanged("PkgNoOfNight");
				 }
			 }
		}

		[DataMember]
		public int?  PkgNoOfAdult
		{
			 get { return _pkgNoOfAdult; }
			 set
			 {
				 if (_pkgNoOfAdult != value)
				 {
					_pkgNoOfAdult = value;
					 PropertyHasChanged("PkgNoOfAdult");
				 }
			 }
		}

		[DataMember]
		public Guid?  DepositID
		{
			 get { return _depositID; }
			 set
			 {
				 if (_depositID != value)
				 {
					_depositID = value;
					 PropertyHasChanged("DepositID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsCheckInSunday
		{
			 get { return _isCheckInSunday; }
			 set
			 {
				 if (_isCheckInSunday != value)
				 {
					_isCheckInSunday = value;
					 PropertyHasChanged("IsCheckInSunday");
				 }
			 }
		}

		[DataMember]
		public bool?  IsCheckInMonday
		{
			 get { return _isCheckInMonday; }
			 set
			 {
				 if (_isCheckInMonday != value)
				 {
					_isCheckInMonday = value;
					 PropertyHasChanged("IsCheckInMonday");
				 }
			 }
		}

		[DataMember]
		public bool?  IsCheckInTuesday
		{
			 get { return _isCheckInTuesday; }
			 set
			 {
				 if (_isCheckInTuesday != value)
				 {
					_isCheckInTuesday = value;
					 PropertyHasChanged("IsCheckInTuesday");
				 }
			 }
		}

		[DataMember]
		public bool?  IsCheckInWednesday
		{
			 get { return _isCheckInWednesday; }
			 set
			 {
				 if (_isCheckInWednesday != value)
				 {
					_isCheckInWednesday = value;
					 PropertyHasChanged("IsCheckInWednesday");
				 }
			 }
		}

		[DataMember]
		public bool?  IsCheckInThursday
		{
			 get { return _isCheckInThursday; }
			 set
			 {
				 if (_isCheckInThursday != value)
				 {
					_isCheckInThursday = value;
					 PropertyHasChanged("IsCheckInThursday");
				 }
			 }
		}

		[DataMember]
		public bool?  IsCheckInFriday
		{
			 get { return _isCheckInFriday; }
			 set
			 {
				 if (_isCheckInFriday != value)
				 {
					_isCheckInFriday = value;
					 PropertyHasChanged("IsCheckInFriday");
				 }
			 }
		}

		[DataMember]
		public bool?  IsCheckInSaturday
		{
			 get { return _isCheckInSaturday; }
			 set
			 {
				 if (_isCheckInSaturday != value)
				 {
					_isCheckInSaturday = value;
					 PropertyHasChanged("IsCheckInSaturday");
				 }
			 }
		}

		[DataMember]
		public string  RateCardDetails
		{
			 get { return _rateCardDetails; }
			 set
			 {
				 if (_rateCardDetails != value)
				 {
					_rateCardDetails = value;
					 PropertyHasChanged("RateCardDetails");
				 }
			 }
		}

		[DataMember]
		public string  TermsAndCondition
		{
			 get { return _termsAndCondition; }
			 set
			 {
				 if (_termsAndCondition != value)
				 {
					_termsAndCondition = value;
					 PropertyHasChanged("TermsAndCondition");
				 }
			 }
		}

		[DataMember]
		public bool?  IsEnable
		{
			 get { return _isEnable; }
			 set
			 {
				 if (_isEnable != value)
				 {
					_isEnable = value;
					 PropertyHasChanged("IsEnable");
				 }
			 }
		}

		[DataMember]
		public bool?  IsYieldEnable
		{
			 get { return _isYieldEnable; }
			 set
			 {
				 if (_isYieldEnable != value)
				 {
					_isYieldEnable = value;
					 PropertyHasChanged("IsYieldEnable");
				 }
			 }
		}

		[DataMember]
		public bool?  IsEventChargeEnable
		{
			 get { return _isEventChargeEnable; }
			 set
			 {
				 if (_isEventChargeEnable != value)
				 {
					_isEventChargeEnable = value;
					 PropertyHasChanged("IsEventChargeEnable");
				 }
			 }
		}

		[DataMember]
		public bool?  IsRateInclService
		{
			 get { return _isRateInclService; }
			 set
			 {
				 if (_isRateInclService != value)
				 {
					_isRateInclService = value;
					 PropertyHasChanged("IsRateInclService");
				 }
			 }
		}

		[DataMember]
		public bool?  IsDefault
		{
			 get { return _isDefault; }
			 set
			 {
				 if (_isDefault != value)
				 {
					_isDefault = value;
					 PropertyHasChanged("IsDefault");
				 }
			 }
		}

        [DataMember]
        public string RateTypeName
        {
            get { return _rateTypeName; }
            set
            {
                if (_rateTypeName != value)
                {
                    _rateTypeName = value;
                    PropertyHasChanged("RateTypeName");
                }
            }
        }

        [DataMember]
        public bool? IsStandard
        {
            get { return _IsStandard; }
            set
            {
                if (_IsStandard != value)
                {
                    _IsStandard = value;
                    PropertyHasChanged("IsStandard");
                }
            }
        }

        [DataMember]
        public int? MinimumDaysRequired
        {
            get { return _minimumDaysRequired; }
            set
            {
                if (_minimumDaysRequired != value)
                {
                    _minimumDaysRequired = value;
                    PropertyHasChanged("MinimumDaysRequired");
                }
            }
        }

        [DataMember]
        public Guid? CancellationPolicyID
        {
            get { return _cancellationPolicyID; }
            set
            {
                if (_cancellationPolicyID != value)
                {
                    _cancellationPolicyID = value;
                    PropertyHasChanged("CancellationPolicyID");
                }
            }
        }
        [DataMember]
        public bool? IsPerRoom
        {
            get { return _isPerRoom; }
            set
            {
                if (_isPerRoom != value)
                {
                    _isPerRoom = value;
                    PropertyHasChanged("IsPerRoom");
                }
            }
        }
        [DataMember]
        public string RateCardDispName
        {
            get { return _rateCardDispName; }
            set
            {
                if (_rateCardDispName != value)
                {
                    _rateCardDispName = value;
                    PropertyHasChanged("RateCardDispName");
                }
            }
        }

        [DataMember]
        public int? RetentionChargePercent
		{
            get { return _retentionChargePercent; }
			 set
			 {
                 if (_retentionChargePercent != value)
				 {
                     _retentionChargePercent = value;
                    PropertyHasChanged("RetentionChargePercent");
				 }
			 }
		}

		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("RateID", "RateID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("RateType_TermID", "RateType_TermID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Code", "Code",7));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("RateCardName", "RateCardName",65));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("RateCardDispName", "RateCardDispName", 150));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("RateCardDetails", "RateCardDetails",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("TermsAndCondition", "TermsAndCondition",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"RateID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"CompanyID = {2}~\n"+
			"SeqNo = {3}~\n"+
			"IsSynch = {4}~\n"+
			"SynchOn = {5}~\n"+
			"UpdatedOn = {6}~\n"+
			"UpdatedBy = {7}~\n"+
			"IsActive = {8}~\n"+
			"StayTypeID = {9}~\n"+
			"RateType_TermID = {10}~\n"+
			"Code = {11}~\n"+
			"RateCardName = {12}~\n"+
			"AcctID = {13}~\n"+
			"StartDate = {14}~\n"+
			"EndDate = {15}~\n"+
			"PostingFreq_TermID = {16}~\n"+
			"NonRevenueChildren = {17}~\n"+
			"PkgNoOfNight = {18}~\n"+
			"PkgNoOfAdult = {19}~\n"+
			"DepositID = {20}~\n"+
			"IsCheckInSunday = {21}~\n"+
			"IsCheckInMonday = {22}~\n"+
			"IsCheckInTuesday = {23}~\n"+
			"IsCheckInWednesday = {24}~\n"+
			"IsCheckInThursday = {25}~\n"+
			"IsCheckInFriday = {26}~\n"+
			"IsCheckInSaturday = {27}~\n"+
			"RateCardDetails = {28}~\n"+
			"TermsAndCondition = {29}~\n"+
			"IsEnable = {30}~\n"+
			"IsYieldEnable = {31}~\n"+
			"IsEventChargeEnable = {32}~\n"+
			"IsRateInclService = {33}~\n"+
            "IsDefault = {34}~\n"+
            "RateTypeName = {35}~\n" +
            "IsStandard = {36}~\n" +
            "CancellationPolicyID = {37}~\n" +
            "IsPerRoom = {38}~\n" +
            "RateCardDispName = {39}~\n" +
            "RetentionChargePercent = {40}~\n",
            RateID, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, StayTypeID, RateType_TermID, Code, RateCardName, AcctID, StartDate, EndDate, PostingFreq_TermID, NonRevenueChildren, PkgNoOfNight, PkgNoOfAdult, DepositID, IsCheckInSunday, IsCheckInMonday, IsCheckInTuesday, IsCheckInWednesday, IsCheckInThursday, IsCheckInFriday, IsCheckInSaturday, RateCardDetails, TermsAndCondition, IsEnable, IsYieldEnable, IsEventChargeEnable, IsRateInclService, IsDefault, RateTypeName, IsStandard, CancellationPolicyID, IsPerRoom, RateCardDispName, RetentionChargePercent); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class RateCardKeys
	{

		#region Data Members

		Guid _rateID;

		#endregion

		#region Constructor

		public RateCardKeys(Guid rateID)
		{
			 _rateID = rateID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  RateID
		{
			 get { return _rateID; }
		}

		#endregion

	}
}
