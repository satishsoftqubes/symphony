using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;
namespace SQT.Symphony.BusinessLogic.FrontDesk.DTO
{
    [DataContract]
    public class Reservation : BusinessObjectBase
    {

        #region InnerClass
        public enum ReservationFields
        {
            ReservationID,
            RefReservationID,
            ReservationType_TermID,
            GroupReservationID,
            GroupID,
            RoomTypeID,
            RoomID,
            RefRoomID,
            ConferenceID,
            GRNo,
            ConferenceTypeID,
            CheckInDate,
            CheckOutDate,
            IsOpenToShareRoom,
            ActualCheckInDate,
            ActualCheckOutDate,
            GuestID,
            FolioID,
            Gender_TermID,
            RateID,
            RestStatus_TermID,
            ReservationNo,
            ReservationDate,
            AgentID,
            Adults,
            Children,
            Infant,
            DiscountID,
            MOP_TermID,
            IsLockRates,
            IsLocked,
            LockedBy,
            IsMoveRoomAllowed,
            IsDateAdjustable,
            IsOverbooked,
            PropertyID,
            CompanyID,
            SeqNo,
            IsSynch,
            SynchOn,
            UpdatedOn,
            UpdatedBy,
            IsActive,
            SourceOfBusiness_TermID,
            RefInvestorID,
            IsToPickup,
            SpecificNote,
            BookedBy,
            IsComplimentoryReservation,
            ComplimentoryReferenceBy,
            BillingInstruction_TermID,
            BookingRefAgentID,
            CreatedBy,
            UpdateMode,
            ExpectedCheckOutDate
        }
        #endregion

        #region Data Members

        Guid _reservationID;
        Guid? _refReservationID;
        Guid? _reservationType_TermID;
        Guid? _groupReservationID;
        Guid? _groupID;
        Guid? _roomTypeID;
        Guid? _roomID;
        Guid? _refRoomID;
        Guid? _conferenceID;
        string _gRNo;
        Guid? _conferenceTypeID;
        DateTime? _checkInDate;
        DateTime? _checkOutDate;
        bool? _isOpenToShareRoom;
        DateTime? _actualCheckInDate;
        DateTime? _actualCheckOutDate;
        Guid? _guestID;
        Guid? _folioID;
        Guid? _gender_TermID;
        Guid? _rateID;
        int? _restStatus_TermID;
        string _reservationNo;
        DateTime? _reservationDate;
        Guid? _agentID;
        int? _adults;
        int? _children;
        int? _infant;
        Guid? _discountID;
        Guid? _mOP_TermID;
        bool? _isLockRates;
        bool? _isLocked;
        Guid? _lockedBy;
        bool? _isMoveRoomAllowed;
        bool? _isDateAdjustable;
        bool? _isOverbooked;
        Guid? _propertyID;
        Guid? _companyID;
        long _seqNo;
        bool? _isSynch;
        DateTime? _synchOn;
        DateTime? _updatedOn;
        Guid? _updatedBy;
        bool? _isActive;
        Guid? _sourceOfBusiness_TermID;
        Guid? _refInvestorID;
        bool? _isToPickup;
        string _specificNote;
        string _bookedBy;
        bool? _isComplimentoryReservation;
        Guid? _complimentoryReferenceBy;
        Guid? _billingInstruction_TermID;
        Guid? _bookingRefAgentID;
        Guid? _createdBy;
        string _UpdateMode;
        DateTime? _expectedCheckOutDate;

        #endregion

        #region Properties

        [DataMember]
        public Guid ReservationID
        {
            get { return _reservationID; }
            set
            {
                if (_reservationID != value)
                {
                    _reservationID = value;
                    PropertyHasChanged("ReservationID");
                }
            }
        }

        [DataMember]
        public Guid? RefReservationID
        {
            get { return _refReservationID; }
            set
            {
                if (_refReservationID != value)
                {
                    _refReservationID = value;
                    PropertyHasChanged("RefReservationID");
                }
            }
        }

        [DataMember]
        public Guid? ReservationType_TermID
        {
            get { return _reservationType_TermID; }
            set
            {
                if (_reservationType_TermID != value)
                {
                    _reservationType_TermID = value;
                    PropertyHasChanged("ReservationType_TermID");
                }
            }
        }

        [DataMember]
        public Guid? GroupReservationID
        {
            get { return _groupReservationID; }
            set
            {
                if (_groupReservationID != value)
                {
                    _groupReservationID = value;
                    PropertyHasChanged("GroupReservationID");
                }
            }
        }

        [DataMember]
        public Guid? GroupID
        {
            get { return _groupID; }
            set
            {
                if (_groupID != value)
                {
                    _groupID = value;
                    PropertyHasChanged("GroupID");
                }
            }
        }

        [DataMember]
        public Guid? RoomTypeID
        {
            get { return _roomTypeID; }
            set
            {
                if (_roomTypeID != value)
                {
                    _roomTypeID = value;
                    PropertyHasChanged("RoomTypeID");
                }
            }
        }

        [DataMember]
        public Guid? RoomID
        {
            get { return _roomID; }
            set
            {
                if (_roomID != value)
                {
                    _roomID = value;
                    PropertyHasChanged("RoomID");
                }
            }
        }

        [DataMember]
        public Guid? RefRoomID
        {
            get { return _refRoomID; }
            set
            {
                if (_refRoomID != value)
                {
                    _refRoomID = value;
                    PropertyHasChanged("RefRoomID");
                }
            }
        }

        [DataMember]
        public Guid? ConferenceID
        {
            get { return _conferenceID; }
            set
            {
                if (_conferenceID != value)
                {
                    _conferenceID = value;
                    PropertyHasChanged("ConferenceID");
                }
            }
        }

        [DataMember]
        public string GRNo
        {
            get { return _gRNo; }
            set
            {
                if (_gRNo != value)
                {
                    _gRNo = value;
                    PropertyHasChanged("GRNo");
                }
            }
        }

        [DataMember]
        public Guid? ConferenceTypeID
        {
            get { return _conferenceTypeID; }
            set
            {
                if (_conferenceTypeID != value)
                {
                    _conferenceTypeID = value;
                    PropertyHasChanged("ConferenceTypeID");
                }
            }
        }

        [DataMember]
        public DateTime? CheckInDate
        {
            get { return _checkInDate; }
            set
            {
                if (_checkInDate != value)
                {
                    _checkInDate = value;
                    PropertyHasChanged("CheckInDate");
                }
            }
        }

        [DataMember]
        public DateTime? CheckOutDate
        {
            get { return _checkOutDate; }
            set
            {
                if (_checkOutDate != value)
                {
                    _checkOutDate = value;
                    PropertyHasChanged("CheckOutDate");
                }
            }
        }

        [DataMember]
        public bool? IsOpenToShareRoom
        {
            get { return _isOpenToShareRoom; }
            set
            {
                if (_isOpenToShareRoom != value)
                {
                    _isOpenToShareRoom = value;
                    PropertyHasChanged("IsOpenToShareRoom");
                }
            }
        }

        [DataMember]
        public DateTime? ActualCheckInDate
        {
            get { return _actualCheckInDate; }
            set
            {
                if (_actualCheckInDate != value)
                {
                    _actualCheckInDate = value;
                    PropertyHasChanged("ActualCheckInDate");
                }
            }
        }

        [DataMember]
        public DateTime? ActualCheckOutDate
        {
            get { return _actualCheckOutDate; }
            set
            {
                if (_actualCheckOutDate != value)
                {
                    _actualCheckOutDate = value;
                    PropertyHasChanged("ActualCheckOutDate");
                }
            }
        }

        [DataMember]
        public Guid? GuestID
        {
            get { return _guestID; }
            set
            {
                if (_guestID != value)
                {
                    _guestID = value;
                    PropertyHasChanged("GuestID");
                }
            }
        }

        [DataMember]
        public Guid? FolioID
        {
            get { return _folioID; }
            set
            {
                if (_folioID != value)
                {
                    _folioID = value;
                    PropertyHasChanged("FolioID");
                }
            }
        }

        [DataMember]
        public Guid? Gender_TermID
        {
            get { return _gender_TermID; }
            set
            {
                if (_gender_TermID != value)
                {
                    _gender_TermID = value;
                    PropertyHasChanged("Gender_TermID");
                }
            }
        }

        [DataMember]
        public Guid? RateID
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
        public int? RestStatus_TermID
        {
            get { return _restStatus_TermID; }
            set
            {
                if (_restStatus_TermID != value)
                {
                    _restStatus_TermID = value;
                    PropertyHasChanged("RestStatus_TermID");
                }
            }
        }

        [DataMember]
        public string ReservationNo
        {
            get { return _reservationNo; }
            set
            {
                if (_reservationNo != value)
                {
                    _reservationNo = value;
                    PropertyHasChanged("ReservationNo");
                }
            }
        }

        [DataMember]
        public DateTime? ReservationDate
        {
            get { return _reservationDate; }
            set
            {
                if (_reservationDate != value)
                {
                    _reservationDate = value;
                    PropertyHasChanged("ReservationDate");
                }
            }
        }

        [DataMember]
        public Guid? AgentID
        {
            get { return _agentID; }
            set
            {
                if (_agentID != value)
                {
                    _agentID = value;
                    PropertyHasChanged("AgentID");
                }
            }
        }

        [DataMember]
        public int? Adults
        {
            get { return _adults; }
            set
            {
                if (_adults != value)
                {
                    _adults = value;
                    PropertyHasChanged("Adults");
                }
            }
        }

        [DataMember]
        public int? Children
        {
            get { return _children; }
            set
            {
                if (_children != value)
                {
                    _children = value;
                    PropertyHasChanged("Children");
                }
            }
        }

        [DataMember]
        public int? Infant
        {
            get { return _infant; }
            set
            {
                if (_infant != value)
                {
                    _infant = value;
                    PropertyHasChanged("Infant");
                }
            }
        }

        [DataMember]
        public Guid? DiscountID
        {
            get { return _discountID; }
            set
            {
                if (_discountID != value)
                {
                    _discountID = value;
                    PropertyHasChanged("DiscountID");
                }
            }
        }

        [DataMember]
        public Guid? MOP_TermID
        {
            get { return _mOP_TermID; }
            set
            {
                if (_mOP_TermID != value)
                {
                    _mOP_TermID = value;
                    PropertyHasChanged("MOP_TermID");
                }
            }
        }

        [DataMember]
        public bool? IsLockRates
        {
            get { return _isLockRates; }
            set
            {
                if (_isLockRates != value)
                {
                    _isLockRates = value;
                    PropertyHasChanged("IsLockRates");
                }
            }
        }

        [DataMember]
        public bool? IsLocked
        {
            get { return _isLocked; }
            set
            {
                if (_isLocked != value)
                {
                    _isLocked = value;
                    PropertyHasChanged("IsLocked");
                }
            }
        }

        [DataMember]
        public Guid? LockedBy
        {
            get { return _lockedBy; }
            set
            {
                if (_lockedBy != value)
                {
                    _lockedBy = value;
                    PropertyHasChanged("LockedBy");
                }
            }
        }

        [DataMember]
        public bool? IsMoveRoomAllowed
        {
            get { return _isMoveRoomAllowed; }
            set
            {
                if (_isMoveRoomAllowed != value)
                {
                    _isMoveRoomAllowed = value;
                    PropertyHasChanged("IsMoveRoomAllowed");
                }
            }
        }

        [DataMember]
        public bool? IsDateAdjustable
        {
            get { return _isDateAdjustable; }
            set
            {
                if (_isDateAdjustable != value)
                {
                    _isDateAdjustable = value;
                    PropertyHasChanged("IsDateAdjustable");
                }
            }
        }

        [DataMember]
        public bool? IsOverbooked
        {
            get { return _isOverbooked; }
            set
            {
                if (_isOverbooked != value)
                {
                    _isOverbooked = value;
                    PropertyHasChanged("IsOverbooked");
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
        public long SeqNo
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
        public Guid? SourceOfBusiness_TermID
        {
            get { return _sourceOfBusiness_TermID; }
            set
            {
                if (_sourceOfBusiness_TermID != value)
                {
                    _sourceOfBusiness_TermID = value;
                    PropertyHasChanged("SourceOfBusiness_TermID");
                }
            }
        }

        [DataMember]
        public Guid? RefInvestorID
        {
            get { return _refInvestorID; }
            set
            {
                if (_refInvestorID != value)
                {
                    _refInvestorID = value;
                    PropertyHasChanged("RefInvestorID");
                }
            }
        }

        [DataMember]
        public bool? IsToPickup
        {
            get { return _isToPickup; }
            set
            {
                if (_isToPickup != value)
                {
                    _isToPickup = value;
                    PropertyHasChanged("IsToPickup");
                }
            }
        }

        [DataMember]
        public string SpecificNote
        {
            get { return _specificNote; }
            set
            {
                if (_specificNote != value)
                {
                    _specificNote = value;
                    PropertyHasChanged("SpecificNote");
                }
            }
        }

        [DataMember]
        public string BookedBy
        {
            get { return _bookedBy; }
            set
            {
                if (_bookedBy != value)
                {
                    _bookedBy = value;
                    PropertyHasChanged("BookedBy");
                }
            }
        }

        [DataMember]
        public bool? IsComplimentoryReservation
        {
            get { return _isComplimentoryReservation; }
            set
            {
                if (_isComplimentoryReservation != value)
                {
                    _isComplimentoryReservation = value;
                    PropertyHasChanged("IsComplimentoryReservation");
                }
            }
        }

        [DataMember]
        public Guid? ComplimentoryReferenceBy
        {
            get { return _complimentoryReferenceBy; }
            set
            {
                if (_complimentoryReferenceBy != value)
                {
                    _complimentoryReferenceBy = value;
                    PropertyHasChanged("ComplimentoryReferenceBy");
                }
            }
        }

        [DataMember]
        public Guid? BillingInstruction_TermID
        {
            get { return _billingInstruction_TermID; }
            set
            {
                if (_billingInstruction_TermID != value)
                {
                    _billingInstruction_TermID = value;
                    PropertyHasChanged("BillingInstruction_TermID");
                }
            }
        }

        [DataMember]
        public Guid? BookingRefAgentID
        {
            get { return _bookingRefAgentID; }
            set
            {
                if (_bookingRefAgentID != value)
                {
                    _bookingRefAgentID = value;
                    PropertyHasChanged("BookingRefAgentID");
                }
            }
        }

        [DataMember]
        public Guid? CreatedBy
        {
            get { return _createdBy; }
            set
            {
                if (_createdBy != value)
                {
                    _createdBy = value;
                    PropertyHasChanged("CreatedBy");
                }
            }
        }
        [DataMember]
        public string UpdateMode
        {
            get { return _UpdateMode; }
            set
            {
                if (_UpdateMode != value)
                {
                    _UpdateMode = value;
                    PropertyHasChanged("UpdateMode");
                }
            }
        }
        [DataMember]
        public DateTime? ExpectedCheckOutDate
        {
            get { return _expectedCheckOutDate; }
            set
            {
                if (_expectedCheckOutDate != value)
                {
                    _expectedCheckOutDate = value;
                    PropertyHasChanged("ExpectedCheckOutDate");
                }
            }
        }
        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ReservationID", "ReservationID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("GRNo", "GRNo", 65));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ReservationNo", "ReservationNo", 65));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("SpecificNote", "SpecificNote", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("BookedBy", "BookedBy", 250));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "ReservationID = {0}\n" +
            "RefReservationID = {1}\n" +
            "ReservationType_TermID = {2}\n" +
            "GroupReservationID = {3}\n" +
            "GroupID = {4}\n" +
            "RoomTypeID = {5}\n" +
            "RoomID = {6}\n" +
            "RefRoomID = {7}\n" +
            "ConferenceID = {8}\n" +
            "GRNo = {9}\n" +
            "ConferenceTypeID = {10}\n" +
            "CheckInDate = {11}\n" +
            "CheckOutDate = {12}\n" +
            "IsOpenToShareRoom = {13}\n" +
            "ActualCheckInDate = {14}\n" +
            "ActualCheckOutDate = {15}\n" +
            "GuestID = {16}\n" +
            "FolioID = {17}\n" +
            "Gender_TermID = {18}\n" +
            "RateID = {19}\n" +
            "RestStatus_TermID = {20}\n" +
            "ReservationNo = {21}\n" +
            "ReservationDate = {22}\n" +
            "AgentID = {23}\n" +
            "Adults = {24}\n" +
            "Children = {25}\n" +
            "Infant = {26}\n" +
            "DiscountID = {27}\n" +
            "MOP_TermID = {28}\n" +
            "IsLockRates = {29}\n" +
            "IsLocked = {30}\n" +
            "LockedBy = {31}\n" +
            "IsMoveRoomAllowed = {32}\n" +
            "IsDateAdjustable = {33}\n" +
            "IsOverbooked = {34}\n" +
            "PropertyID = {35}\n" +
            "CompanyID = {36}\n" +
            "SeqNo = {37}\n" +
            "IsSynch = {38}\n" +
            "SynchOn = {39}\n" +
            "UpdatedOn = {40}\n" +
            "UpdatedBy = {41}\n" +
            "IsActive = {42}\n" +
            "SourceOfBusiness_TermID = {43}\n" +
            "RefInvestorID = {44}\n" +
            "IsToPickup = {45}\n" +
            "SpecificNote = {46}\n" +
            "BookedBy = {47}\n" +
            "IsComplimentoryReservation = {48}\n" +
            "ComplimentoryReferenceBy = {49}\n" +
            "BillingInstruction_TermID = {50}\n" +
            "BookingRefAgentID = {51}\n" +
            "CreatedBy = {52}\n" +
            "ExpectedCheckOutDate = {53}\n",
            ReservationID, RefReservationID, ReservationType_TermID, GroupReservationID, GroupID, RoomTypeID, RoomID, RefRoomID, ConferenceID, GRNo, ConferenceTypeID, CheckInDate, CheckOutDate, IsOpenToShareRoom, ActualCheckInDate, ActualCheckOutDate, GuestID, FolioID, Gender_TermID, RateID, RestStatus_TermID, ReservationNo, ReservationDate, AgentID, Adults, Children, Infant, DiscountID, MOP_TermID, IsLockRates, IsLocked, LockedBy, IsMoveRoomAllowed, IsDateAdjustable, IsOverbooked, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, SourceOfBusiness_TermID, RefInvestorID, IsToPickup, SpecificNote, BookedBy, IsComplimentoryReservation, ComplimentoryReferenceBy, BillingInstruction_TermID, BookingRefAgentID, CreatedBy, ExpectedCheckOutDate); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class ReservationKeys
    {

        #region Data Members

        Guid _reservationID;

        #endregion

        #region Constructor

        public ReservationKeys(Guid reservationID)
        {
            _reservationID = reservationID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid ReservationID
        {
            get { return _reservationID; }
        }

        #endregion

    }
}
