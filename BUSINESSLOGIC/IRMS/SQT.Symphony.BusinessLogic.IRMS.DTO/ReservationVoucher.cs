using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;
namespace SQT.Symphony.BusinessLogic.IRMS.DTO
{
    [DataContract]
    public class ReservationVoucher : BusinessObjectBase
    {

        #region InnerClass
        public enum ReservationVoucherFields
        {
            ResVoucherID,
            VoucherNo,
            InvestorID,
            CheckInDate,
            CheckOutDate,
            TotalNights,
            GuestName,
            TotalGuest,
            Status_Term,
            CreatedBy_Term,
            Adult,
            Children,
            NoOfRoom,
            PropertyID,
            CompanyID,
            CreatedBy,
            CreatedOn,
            ApprovedBy,
            ApprovedOn,
            ReservationID,
            AllocatedRoomID,
            InvestorUnitID,
            SeqNo,
            UpdateBy,
            UpdatedOn,
            Email,
            Phone,
            IsToAddDaysBack,
            Notes
        }
        #endregion

        #region Data Members

        Guid _resVoucherID;
        string _voucherNo;
        Guid? _investorID;
        DateTime? _checkInDate;
        DateTime? _checkOutDate;
        int? _totalNights;
        string _guestName;
        int? _totalGuest;
        string _status_Term;
        string _createdBy_Term;
        int? _adult;
        int? _children;
        int? _noOfRoom;
        Guid? _propertyID;
        Guid? _companyID;
        Guid? _createdBy;
        DateTime? _createdOn;
        Guid? _approvedBy;
        DateTime? _approvedOn;
        Guid? _reservationID;
        Guid? _allocatedRoomID;
        Guid? _investorUnitID;
        int _seqNo;
        Guid? _updateBy;
        DateTime? _updatedOn;
        string _Email;
        string _Phone;
        bool _isToAddDaysBack;
        string _notes;

        #endregion

        #region Properties

        [DataMember]
        public Guid ResVoucherID
        {
            get { return _resVoucherID; }
            set
            {
                if (_resVoucherID != value)
                {
                    _resVoucherID = value;
                    PropertyHasChanged("ResVoucherID");
                }
            }
        }

        [DataMember]
        public string VoucherNo
        {
            get { return _voucherNo; }
            set
            {
                if (_voucherNo != value)
                {
                    _voucherNo = value;
                    PropertyHasChanged("VoucherNo");
                }
            }
        }

        [DataMember]
        public Guid? InvestorID
        {
            get { return _investorID; }
            set
            {
                if (_investorID != value)
                {
                    _investorID = value;
                    PropertyHasChanged("InvestorID");
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
        public int? TotalNights
        {
            get { return _totalNights; }
            set
            {
                if (_totalNights != value)
                {
                    _totalNights = value;
                    PropertyHasChanged("TotalNights");
                }
            }
        }

        [DataMember]
        public string GuestName
        {
            get { return _guestName; }
            set
            {
                if (_guestName != value)
                {
                    _guestName = value;
                    PropertyHasChanged("GuestName");
                }
            }
        }

        [DataMember]
        public int? TotalGuest
        {
            get { return _totalGuest; }
            set
            {
                if (_totalGuest != value)
                {
                    _totalGuest = value;
                    PropertyHasChanged("TotalGuest");
                }
            }
        }

        [DataMember]
        public string Status_Term
        {
            get { return _status_Term; }
            set
            {
                if (_status_Term != value)
                {
                    _status_Term = value;
                    PropertyHasChanged("Status_Term");
                }
            }
        }

        [DataMember]
        public string CreatedBy_Term
        {
            get { return _createdBy_Term; }
            set
            {
                if (_createdBy_Term != value)
                {
                    _createdBy_Term = value;
                    PropertyHasChanged("CreatedBy_Term");
                }
            }
        }

        [DataMember]
        public int? Adult
        {
            get { return _adult; }
            set
            {
                if (_adult != value)
                {
                    _adult = value;
                    PropertyHasChanged("Adult");
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
        public int? NoOfRoom
        {
            get { return _noOfRoom; }
            set
            {
                if (_noOfRoom != value)
                {
                    _noOfRoom = value;
                    PropertyHasChanged("NoOfRoom");
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
        public DateTime? CreatedOn
        {
            get { return _createdOn; }
            set
            {
                if (_createdOn != value)
                {
                    _createdOn = value;
                    PropertyHasChanged("CreatedOn");
                }
            }
        }

        [DataMember]
        public Guid? ApprovedBy
        {
            get { return _approvedBy; }
            set
            {
                if (_approvedBy != value)
                {
                    _approvedBy = value;
                    PropertyHasChanged("ApprovedBy");
                }
            }
        }

        [DataMember]
        public DateTime? ApprovedOn
        {
            get { return _approvedOn; }
            set
            {
                if (_approvedOn != value)
                {
                    _approvedOn = value;
                    PropertyHasChanged("ApprovedOn");
                }
            }
        }

        [DataMember]
        public Guid? ReservationID
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
        public Guid? AllocatedRoomID
        {
            get { return _allocatedRoomID; }
            set
            {
                if (_allocatedRoomID != value)
                {
                    _allocatedRoomID = value;
                    PropertyHasChanged("AllocatedRoomID");
                }
            }
        }

        [DataMember]
        public Guid? InvestorUnitID
        {
            get { return _investorUnitID; }
            set
            {
                if (_investorUnitID != value)
                {
                    _investorUnitID = value;
                    PropertyHasChanged("InvestorUnitID");
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
        public Guid? UpdateBy
        {
            get { return _updateBy; }
            set
            {
                if (_updateBy != value)
                {
                    _updateBy = value;
                    PropertyHasChanged("UpdateBy");
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
        public string Email
        {
            get { return _Email; }
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    PropertyHasChanged("Email");
                }
            }
        }

        [DataMember]
        public string Phone
        {
            get { return _Phone; }
            set
            {
                if (_Phone != value)
                {
                    _Phone = value;
                    PropertyHasChanged("Phone");
                }
            }
        }

        [DataMember]
        public bool IsToAddDaysBack
        {
            get { return _isToAddDaysBack; }
            set
            {
                if (_isToAddDaysBack != value)
                {
                    _isToAddDaysBack = value;
                    PropertyHasChanged("IsToAddDaysBack");
                }
            }
        }
        [DataMember]
        public string Notes
        {
            get { return _notes ; }
            set
            {
                if (_notes  != value)
                {
                    _notes  = value;
                    PropertyHasChanged("Notes");
                }
            }
        }


        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ResVoucherID", "ResVoucherID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("VoucherNo", "VoucherNo", 25));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("GuestName", "GuestName", 250));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Status_Term", "Status_Term", 165));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CreatedBy_Term", "CreatedBy_Term", 165));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "ResVoucherID = {0}\n" +
            "VoucherNo = {1}\n" +
            "InvestorID = {2}\n" +
            "CheckInDate = {3}\n" +
            "CheckOutDate = {4}\n" +
            "TotalNights = {5}\n" +
            "GuestName = {6}\n" +
            "TotalGuest = {7}\n" +
            "Status_Term = {8}\n" +
            "CreatedBy_Term = {9}\n" +
            "Adult = {10}\n" +
            "Children = {11}\n" +
            "NoOfRoom = {12}\n" +
            "PropertyID = {13}\n" +
            "CompanyID = {14}\n" +
            "CreatedBy = {15}\n" +
            "CreatedOn = {16}\n" +
            "ApprovedBy = {17}\n" +
            "ApprovedOn = {18}\n" +
            "ReservationID = {19}\n" +
            "AllocatedRoomID = {20}\n" +
            "InvestorUnitID = {21}\n" +
            "SeqNo = {22}\n" +
            "UpdateBy = {23}\n" +
            "UpdatedOn = {24}\n" +
            "Email = {25}\n" +
            "Phone = {26}\n" +
            "IsToAddDaysBack = {27}\n" +
            "Notes = {28}\n",
            ResVoucherID, VoucherNo, InvestorID, CheckInDate, CheckOutDate, TotalNights, GuestName, TotalGuest, Status_Term, CreatedBy_Term, Adult, Children, NoOfRoom, PropertyID, CompanyID, CreatedBy, CreatedOn, ApprovedBy, ApprovedOn, ReservationID, AllocatedRoomID, InvestorUnitID, SeqNo, UpdateBy, UpdatedOn, Email, Phone, IsToAddDaysBack,Notes); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class ReservationVoucherKeys
    {

        #region Data Members

        Guid _resVoucherID;

        #endregion

        #region Constructor

        public ReservationVoucherKeys(Guid resVoucherID)
        {
            _resVoucherID = resVoucherID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid ResVoucherID
        {
            get { return _resVoucherID; }
        }

        #endregion

    }
}
