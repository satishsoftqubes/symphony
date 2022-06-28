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
    public class ReservationConfig : BusinessObjectBase
    {

        #region InnerClass
        public enum ReservationConfigFields
        {
            ResConfigID,
            PropertyID,
            CompanyID,
            SeqNo,
            IsSynch,
            SynchOn,
            UpdatedOn,
            UpdatedBy,
            IsActive,
            IsShowDepositAlertOnCheckIn,
            IsShowDirtyRoomAlertOnCheckIn,
            IsAutoPostFirstNightChargeAtCheckIn,
            IsGuestEMailCompulsory,
            IsGuestIdentityCompulsory,
            UnConfirmedReservationRemindBeforeDays,
            RoomReservationConfirmBeforeDays,
            ConferenceReservationConfirmBeforeDays,
            GroupReservationConfirmBeforeDays,
            IsRateInclusiveService,
            CheckInSettlementMins,
            CheckOutSettlementMins,
            IsEnableAutoAssignRooms,
            HighWeekDays,
            Is24HrsCheckIn,
            CheckInTime,
            CheckOutTime,
            ChildAgeLimit,
            InfantAgeLimit,
            GeneralTravelAgentComission,
            GeneralCorporateDiscount,
            ProvisionalReservationDayLimit,
            NoShowHours,
            IsCardInformationRequired,
            IsWarnOnOverBooking,
            IsShowDinomination,
            DefaultHoldType_TermID,
            IsApplyYield,
            IsYieldFlat,
            IsTravelAgentCommissionFlat,
            IsCorporateDiscountFlat,
            LongStayDays,
            CancellationPolicy,
            NoOfAmendmentCriteria,
            MinDaysForLongstay,
            ReservationPolicy,
            DefaultDepositAcctID,
            RetentionCharge,
            MaxCashLimitForRefund
        }
        #endregion

        #region Data Members

        Guid _resConfigID;
        Guid? _propertyID;
        Guid? _companyID;
        int _seqNo;
        bool? _isSynch;
        DateTime? _synchOn;
        DateTime? _updatedOn;
        Guid? _updatedBy;
        bool? _isActive;
        bool? _isShowDepositAlertOnCheckIn;
        bool? _isShowDirtyRoomAlertOnCheckIn;
        bool? _isAutoPostFirstNightChargeAtCheckIn;
        bool? _isGuestEMailCompulsory;
        bool? _isGuestIdentityCompulsory;
        int? _unConfirmedReservationRemindBeforeDays;
        int? _roomReservationConfirmBeforeDays;
        int? _conferenceReservationConfirmBeforeDays;
        int? _groupReservationConfirmBeforeDays;
        bool? _isRateInclusiveService;
        int? _checkInSettlementMins;
        int? _checkOutSettlementMins;
        bool? _isEnableAutoAssignRooms;
        string _highWeekDays;
        bool? _is24HrsCheckIn;
        DateTime? _checkInTime;
        DateTime? _checkOutTime;
        int? _childAgeLimit;
        int? _infantAgeLimit;
        decimal? _generalTravelAgentComission;
        decimal? _generalCorporateDiscount;
        int? _provisionalReservationDayLimit;
        int? _noShowHours;
        bool? _isCardInformationRequired;
        bool? _isWarnOnOverBooking;
        bool? _isShowDinomination;
        Guid? _defaultHoldType_TermID;
        bool? _isApplyYield;
        bool? _isYieldFlat;
        bool? _isTravelAgentCommissionFlat;
        bool? _isCorporateDiscountFlat;
        int? _longStayDays;
        string _CancellationPolicy;
        int? _NoOfAmendmentCriteria;
        decimal? _MinDaysForLongstay;
        string _ReservationPolicy;
        Guid? _defaultDepositAcctID;
        decimal? _retentionCharge;
        decimal? _maxCashLimitForRefund;

        #endregion

        #region Properties

        [DataMember]
        public Guid ResConfigID
        {
            get { return _resConfigID; }
            set
            {
                if (_resConfigID != value)
                {
                    _resConfigID = value;
                    PropertyHasChanged("ResConfigID");
                }
            }
        }



        [DataMember]
        public Guid? PropertyID
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
        public Guid? DefaultDepositAcctID
        {
            get { return _defaultDepositAcctID; }
            set
            {
                if (_defaultDepositAcctID != value)
                {
                    _defaultDepositAcctID = value;
                    PropertyHasChanged("DefaultDepositAcctID");
                }
            }
        }

        [DataMember]
        public Guid? CompanyID
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
        public int SeqNo
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
        public bool? IsSynch
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
        public DateTime? SynchOn
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
        public DateTime? UpdatedOn
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
        public Guid? UpdatedBy
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
        public bool? IsActive
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
        public bool? IsShowDepositAlertOnCheckIn
        {
            get { return _isShowDepositAlertOnCheckIn; }
            set
            {
                if (_isShowDepositAlertOnCheckIn != value)
                {
                    _isShowDepositAlertOnCheckIn = value;
                    PropertyHasChanged("IsShowDepositAlertOnCheckIn");
                }
            }
        }

        [DataMember]
        public bool? IsShowDirtyRoomAlertOnCheckIn
        {
            get { return _isShowDirtyRoomAlertOnCheckIn; }
            set
            {
                if (_isShowDirtyRoomAlertOnCheckIn != value)
                {
                    _isShowDirtyRoomAlertOnCheckIn = value;
                    PropertyHasChanged("IsShowDirtyRoomAlertOnCheckIn");
                }
            }
        }

        [DataMember]
        public bool? IsAutoPostFirstNightChargeAtCheckIn
        {
            get { return _isAutoPostFirstNightChargeAtCheckIn; }
            set
            {
                if (_isAutoPostFirstNightChargeAtCheckIn != value)
                {
                    _isAutoPostFirstNightChargeAtCheckIn = value;
                    PropertyHasChanged("IsAutoPostFirstNightChargeAtCheckIn");
                }
            }
        }

        [DataMember]
        public bool? IsGuestEMailCompulsory
        {
            get { return _isGuestEMailCompulsory; }
            set
            {
                if (_isGuestEMailCompulsory != value)
                {
                    _isGuestEMailCompulsory = value;
                    PropertyHasChanged("IsGuestEMailCompulsory");
                }
            }
        }

        [DataMember]
        public bool? IsGuestIdentityCompulsory
        {
            get { return _isGuestIdentityCompulsory; }
            set
            {
                if (_isGuestIdentityCompulsory != value)
                {
                    _isGuestIdentityCompulsory = value;
                    PropertyHasChanged("IsGuestIdentityCompulsory");
                }
            }
        }

        [DataMember]
        public int? UnConfirmedReservationRemindBeforeDays
        {
            get { return _unConfirmedReservationRemindBeforeDays; }
            set
            {
                if (_unConfirmedReservationRemindBeforeDays != value)
                {
                    _unConfirmedReservationRemindBeforeDays = value;
                    PropertyHasChanged("UnConfirmedReservationRemindBeforeDays");
                }
            }
        }

        [DataMember]
        public int? RoomReservationConfirmBeforeDays
        {
            get { return _roomReservationConfirmBeforeDays; }
            set
            {
                if (_roomReservationConfirmBeforeDays != value)
                {
                    _roomReservationConfirmBeforeDays = value;
                    PropertyHasChanged("RoomReservationConfirmBeforeDays");
                }
            }
        }

        [DataMember]
        public int? ConferenceReservationConfirmBeforeDays
        {
            get { return _conferenceReservationConfirmBeforeDays; }
            set
            {
                if (_conferenceReservationConfirmBeforeDays != value)
                {
                    _conferenceReservationConfirmBeforeDays = value;
                    PropertyHasChanged("ConferenceReservationConfirmBeforeDays");
                }
            }
        }

        [DataMember]
        public int? GroupReservationConfirmBeforeDays
        {
            get { return _groupReservationConfirmBeforeDays; }
            set
            {
                if (_groupReservationConfirmBeforeDays != value)
                {
                    _groupReservationConfirmBeforeDays = value;
                    PropertyHasChanged("GroupReservationConfirmBeforeDays");
                }
            }
        }

        [DataMember]
        public bool? IsRateInclusiveService
        {
            get { return _isRateInclusiveService; }
            set
            {
                if (_isRateInclusiveService != value)
                {
                    _isRateInclusiveService = value;
                    PropertyHasChanged("IsRateInclusiveService");
                }
            }
        }

        [DataMember]
        public int? CheckInSettlementMins
        {
            get { return _checkInSettlementMins; }
            set
            {
                if (_checkInSettlementMins != value)
                {
                    _checkInSettlementMins = value;
                    PropertyHasChanged("CheckInSettlementMins");
                }
            }
        }

        [DataMember]
        public int? CheckOutSettlementMins
        {
            get { return _checkOutSettlementMins; }
            set
            {
                if (_checkOutSettlementMins != value)
                {
                    _checkOutSettlementMins = value;
                    PropertyHasChanged("CheckOutSettlementMins");
                }
            }
        }

        [DataMember]
        public bool? IsEnableAutoAssignRooms
        {
            get { return _isEnableAutoAssignRooms; }
            set
            {
                if (_isEnableAutoAssignRooms != value)
                {
                    _isEnableAutoAssignRooms = value;
                    PropertyHasChanged("IsEnableAutoAssignRooms");
                }
            }
        }

        [DataMember]
        public string HighWeekDays
        {
            get { return _highWeekDays; }
            set
            {
                if (_highWeekDays != value)
                {
                    _highWeekDays = value;
                    PropertyHasChanged("HighWeekDays");
                }
            }
        }

        [DataMember]
        public bool? Is24HrsCheckIn
        {
            get { return _is24HrsCheckIn; }
            set
            {
                if (_is24HrsCheckIn != value)
                {
                    _is24HrsCheckIn = value;
                    PropertyHasChanged("Is24HrsCheckIn");
                }
            }
        }

        [DataMember]
        public DateTime? CheckInTime
        {
            get { return _checkInTime; }
            set
            {
                if (_checkInTime != value)
                {
                    _checkInTime = value;
                    PropertyHasChanged("CheckInTime");
                }
            }
        }

        [DataMember]
        public DateTime? CheckOutTime
        {
            get { return _checkOutTime; }
            set
            {
                if (_checkOutTime != value)
                {
                    _checkOutTime = value;
                    PropertyHasChanged("CheckOutTime");
                }
            }
        }

        [DataMember]
        public int? ChildAgeLimit
        {
            get { return _childAgeLimit; }
            set
            {
                if (_childAgeLimit != value)
                {
                    _childAgeLimit = value;
                    PropertyHasChanged("ChildAgeLimit");
                }
            }
        }

        [DataMember]
        public int? InfantAgeLimit
        {
            get { return _infantAgeLimit; }
            set
            {
                if (_infantAgeLimit != value)
                {
                    _infantAgeLimit = value;
                    PropertyHasChanged("InfantAgeLimit");
                }
            }
        }

        [DataMember]
        public decimal? GeneralTravelAgentComission
        {
            get { return _generalTravelAgentComission; }
            set
            {
                if (_generalTravelAgentComission != value)
                {
                    _generalTravelAgentComission = value;
                    PropertyHasChanged("GeneralTravelAgentComission");
                }
            }
        }

        [DataMember]
        public decimal? GeneralCorporateDiscount
        {
            get { return _generalCorporateDiscount; }
            set
            {
                if (_generalCorporateDiscount != value)
                {
                    _generalCorporateDiscount = value;
                    PropertyHasChanged("GeneralCorporateDiscount");
                }
            }
        }

        [DataMember]
        public int? ProvisionalReservationDayLimit
        {
            get { return _provisionalReservationDayLimit; }
            set
            {
                if (_provisionalReservationDayLimit != value)
                {
                    _provisionalReservationDayLimit = value;
                    PropertyHasChanged("ProvisionalReservationDayLimit");
                }
            }
        }

        [DataMember]
        public int? NoShowHours
        {
            get { return _noShowHours; }
            set
            {
                if (_noShowHours != value)
                {
                    _noShowHours = value;
                    PropertyHasChanged("NoShowHours");
                }
            }
        }

        [DataMember]
        public bool? IsCardInformationRequired
        {
            get { return _isCardInformationRequired; }
            set
            {
                if (_isCardInformationRequired != value)
                {
                    _isCardInformationRequired = value;
                    PropertyHasChanged("IsCardInformationRequired");
                }
            }
        }

        [DataMember]
        public bool? IsWarnOnOverBooking
        {
            get { return _isWarnOnOverBooking; }
            set
            {
                if (_isWarnOnOverBooking != value)
                {
                    _isWarnOnOverBooking = value;
                    PropertyHasChanged("IsWarnOnOverBooking");
                }
            }
        }

        [DataMember]
        public bool? IsShowDinomination
        {
            get { return _isShowDinomination; }
            set
            {
                if (_isShowDinomination != value)
                {
                    _isShowDinomination = value;
                    PropertyHasChanged("IsShowDinomination");
                }
            }
        }

        [DataMember]
        public Guid? DefaultHoldType_TermID
        {
            get { return _defaultHoldType_TermID; }
            set
            {
                if (_defaultHoldType_TermID != value)
                {
                    _defaultHoldType_TermID = value;
                    PropertyHasChanged("DefaultHoldType_TermID");
                }
            }
        }

        [DataMember]
        public bool? IsApplyYield
        {
            get { return _isApplyYield; }
            set
            {
                if (_isApplyYield != value)
                {
                    _isApplyYield = value;
                    PropertyHasChanged("IsApplyYield");
                }
            }
        }

        [DataMember]
        public bool? IsYieldFlat
        {
            get { return _isYieldFlat; }
            set
            {
                if (_isYieldFlat != value)
                {
                    _isYieldFlat = value;
                    PropertyHasChanged("IsYieldFlat");
                }
            }
        }
        [DataMember]
        public bool? IsTravelAgentCommissionFlat
        {
            get { return _isTravelAgentCommissionFlat; }
            set
            {
                if (_isTravelAgentCommissionFlat != value)
                {
                    _isTravelAgentCommissionFlat = value;
                    PropertyHasChanged("IsTravelAgentCommissionFlat");
                }
            }
        }
        [DataMember]
        public bool? IsCorporateDiscountFlat
        {
            get { return _isCorporateDiscountFlat; }
            set
            {
                if (_isCorporateDiscountFlat != value)
                {
                    _isCorporateDiscountFlat = value;
                    PropertyHasChanged("IsCorporateDiscountFlat");
                }
            }
        }

        [DataMember]
        public int? LongStayDays
        {
            get { return _longStayDays; }
            set
            {
                if (_longStayDays != value)
                {
                    _longStayDays = value;
                    PropertyHasChanged("LongStayDays");
                }
            }
        }

        [DataMember]
        public string CancellationPolicy
        {
            get { return _CancellationPolicy; }
            set
            {
                if (_CancellationPolicy != value)
                {
                    _CancellationPolicy = value;
                    PropertyHasChanged("CancellationPolicy");
                }
            }
        }

        [DataMember]
        public int? NoOfAmendmentCriteria
        {
            get { return _NoOfAmendmentCriteria; }
            set
            {
                if (_NoOfAmendmentCriteria != value)
                {
                    _NoOfAmendmentCriteria = value;
                    PropertyHasChanged("NoOfAmendmentCriteria");
                }
            }
        }

        [DataMember]
        public decimal? MinDaysForLongstay
        {
            get { return _MinDaysForLongstay; }
            set
            {
                if (_MinDaysForLongstay != value)
                {
                    _MinDaysForLongstay = value;
                    PropertyHasChanged("MinDaysForLongstay");
                }
            }
        }

        [DataMember]
        public string ReservationPolicy
        {
            get { return _ReservationPolicy; }
            set
            {
                if (_ReservationPolicy != value)
                {
                    _ReservationPolicy = value;
                    PropertyHasChanged("ReservationPolicy");
                }
            }
        }

        [DataMember]
        public decimal? RetentionCharge
        {
            get { return _retentionCharge; }
            set
            {
                if (_retentionCharge != value)
                {
                    _retentionCharge = value;
                    PropertyHasChanged("RetentionCharge");
                }
            }
        }
        [DataMember]
        public decimal? MaxCashLimitForRefund
        {
            get { return _maxCashLimitForRefund; }
            set
            {
                if (_maxCashLimitForRefund != value)
                {
                    _maxCashLimitForRefund = value;
                    PropertyHasChanged("MaxCashLimitForRefund");
                }
            }
        }

        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ResConfigID", "ResConfigID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("HighWeekDays", "HighWeekDays", 50));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "ResConfigID = {0}~\n" +
            "PropertyID = {1}~\n" +
            "CompanyID = {2}~\n" +
            "SeqNo = {3}~\n" +
            "IsSynch = {4}~\n" +
            "SynchOn = {5}~\n" +
            "UpdatedOn = {6}~\n" +
            "UpdatedBy = {7}~\n" +
            "IsActive = {8}~\n" +
            "IsShowDepositAlertOnCheckIn = {9}~\n" +
            "IsShowDirtyRoomAlertOnCheckIn = {10}~\n" +
            "IsAutoPostFirstNightChargeAtCheckIn = {11}~\n" +
            "IsGuestEMailCompulsory = {12}~\n" +
            "IsGuestIdentityCompulsory = {13}~\n" +
            "UnConfirmedReservationRemindBeforeDays = {14}~\n" +
            "RoomReservationConfirmBeforeDays = {15}~\n" +
            "ConferenceReservationConfirmBeforeDays = {16}~\n" +
            "GroupReservationConfirmBeforeDays = {17}~\n" +
            "IsRateInclusiveService = {18}~\n" +
            "CheckInSettlementMins = {19}~\n" +
            "CheckOutSettlementMins = {20}~\n" +
            "IsEnableAutoAssignRooms = {21}~\n" +
            "HighWeekDays = {22}~\n" +
            "Is24HrsCheckIn = {23}~\n" +
            "CheckInTime = {24}~\n" +
            "CheckOutTime = {25}~\n" +
            "ChildAgeLimit = {26}~\n" +
            "InfantAgeLimit = {27}~\n" +
            "GeneralTravelAgentComission = {28}~\n" +
            "GeneralCorporateDiscount = {29}~\n" +
            "ProvisionalReservationDayLimit = {30}~\n" +
            "NoShowHours = {31}~\n" +
            "IsCardInformationRequired = {32}~\n" +
            "IsWarnOnOverBooking = {33}~\n" +
            "IsShowDinomination = {34}~\n" +
            "DefaultHoldType_TermID = {35}~\n" +
            "IsApplyYield = {36}~\n" +
            "IsYieldFlat = {37}~\n" +
            "IsTravelAgentCommissionFlat={38}~\n" +
            "IsCorporateDiscountFlat={39}~\n" +
            "LongStayDays={40}~\n" +
            "CancellationPolicy={41}~\n" +
            "NoOfAmendmentCriteria={42}~\n" +
            "MinDaysForLongstay={43}~\n" +
            "ReservationPolicy={44}~\n" +
            "DefaultDepositAcctID={45}~\n" +
            "RetentionCharge={46}~\n" +
            "MaxCashLimitForRefund={47}~\n",
            ResConfigID, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, IsShowDepositAlertOnCheckIn, IsShowDirtyRoomAlertOnCheckIn, IsAutoPostFirstNightChargeAtCheckIn, IsGuestEMailCompulsory, IsGuestIdentityCompulsory, UnConfirmedReservationRemindBeforeDays, RoomReservationConfirmBeforeDays, ConferenceReservationConfirmBeforeDays, GroupReservationConfirmBeforeDays, IsRateInclusiveService, CheckInSettlementMins, CheckOutSettlementMins, IsEnableAutoAssignRooms, HighWeekDays, Is24HrsCheckIn, CheckInTime, CheckOutTime, ChildAgeLimit, InfantAgeLimit, GeneralTravelAgentComission, GeneralCorporateDiscount, ProvisionalReservationDayLimit, NoShowHours, IsCardInformationRequired, IsWarnOnOverBooking, IsShowDinomination, DefaultHoldType_TermID, IsApplyYield, IsYieldFlat, IsTravelAgentCommissionFlat, IsCorporateDiscountFlat, LongStayDays, CancellationPolicy, NoOfAmendmentCriteria, MinDaysForLongstay, ReservationPolicy, DefaultDepositAcctID, RetentionCharge, MaxCashLimitForRefund); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class ReservationConfigKeys
    {

        #region Data Members

        Guid _resConfigID;

        #endregion

        #region Constructor

        public ReservationConfigKeys(Guid resConfigID)
        {
            _resConfigID = resConfigID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid ResConfigID
        {
            get { return _resConfigID; }
        }

        #endregion

    }
}
