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
    public class Folio : BusinessObjectBase
    {

        #region InnerClass
        public enum FolioFields
        {
            FolioID,
            ReservationID,
            GuestID,
            AgentID,
            FolioNo,
            CreationDate,
            IsSubFolio,
            IsSplitFolio,
            ParentFolioID,
            FolioStatus_TermID,
            IsLocked,
            LockedBy,
            CurrentBalace,
            Charges,
            Payment,
            Adjustment,
            IsSourceFolio,
            IsDestinationFolio,
            TransactionZone_TermID,
            IsDirectBill,
            BilledTo,
            FolioType_TermID,
            PropertyID,
            CompanyID,
            SeqNo,
            IsSynch,
            SynchOn,
            UpdatedOn,
            UpdatedBy,
            IsActive,
            FolioStatus,
            BillingAddress
        }
        #endregion

        #region Data Members

        Guid _folioID;
        Guid? _reservationID;
        Guid? _guestID;
        Guid? _agentID;
        string _folioNo;
        DateTime? _creationDate;
        bool? _isSubFolio;
        bool? _isSplitFolio;
        Guid? _parentFolioID;
        Guid? _folioStatus_TermID;
        bool? _isLocked;
        Guid? _lockedBy;
        decimal? _currentBalace;
        decimal? _charges;
        decimal? _payment;
        decimal? _adjustment;
        bool? _isSourceFolio;
        bool? _isDestinationFolio;
        Guid? _transactionZone_TermID;
        bool? _isDirectBill;
        string _billedTo;
        Guid? _folioType_TermID;
        Guid? _propertyID;
        Guid? _companyID;
        long _seqNo;
        bool? _isSynch;
        DateTime? _synchOn;
        DateTime? _updatedOn;
        Guid? _updatedBy;
        bool? _isActive;
        string _folioStatus;
        string _billingAddress;

        #endregion

        #region Properties

        [DataMember]
        public Guid FolioID
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
        public string FolioNo
        {
            get { return _folioNo; }
            set
            {
                if (_folioNo != value)
                {
                    _folioNo = value;
                    PropertyHasChanged("FolioNo");
                }
            }
        }

        [DataMember]
        public DateTime? CreationDate
        {
            get { return _creationDate; }
            set
            {
                if (_creationDate != value)
                {
                    _creationDate = value;
                    PropertyHasChanged("CreationDate");
                }
            }
        }

        [DataMember]
        public bool? IsSubFolio
        {
            get { return _isSubFolio; }
            set
            {
                if (_isSubFolio != value)
                {
                    _isSubFolio = value;
                    PropertyHasChanged("IsSubFolio");
                }
            }
        }

        [DataMember]
        public bool? IsSplitFolio
        {
            get { return _isSplitFolio; }
            set
            {
                if (_isSplitFolio != value)
                {
                    _isSplitFolio = value;
                    PropertyHasChanged("IsSplitFolio");
                }
            }
        }

        [DataMember]
        public Guid? ParentFolioID
        {
            get { return _parentFolioID; }
            set
            {
                if (_parentFolioID != value)
                {
                    _parentFolioID = value;
                    PropertyHasChanged("ParentFolioID");
                }
            }
        }

        [DataMember]
        public Guid? FolioStatus_TermID
        {
            get { return _folioStatus_TermID; }
            set
            {
                if (_folioStatus_TermID != value)
                {
                    _folioStatus_TermID = value;
                    PropertyHasChanged("FolioStatus_TermID");
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
        public decimal? CurrentBalace
        {
            get { return _currentBalace; }
            set
            {
                if (_currentBalace != value)
                {
                    _currentBalace = value;
                    PropertyHasChanged("CurrentBalace");
                }
            }
        }

        [DataMember]
        public decimal? Charges
        {
            get { return _charges; }
            set
            {
                if (_charges != value)
                {
                    _charges = value;
                    PropertyHasChanged("Charges");
                }
            }
        }

        [DataMember]
        public decimal? Payment
        {
            get { return _payment; }
            set
            {
                if (_payment != value)
                {
                    _payment = value;
                    PropertyHasChanged("Payment");
                }
            }
        }

        [DataMember]
        public decimal? Adjustment
        {
            get { return _adjustment; }
            set
            {
                if (_adjustment != value)
                {
                    _adjustment = value;
                    PropertyHasChanged("Adjustment");
                }
            }
        }

        [DataMember]
        public bool? IsSourceFolio
        {
            get { return _isSourceFolio; }
            set
            {
                if (_isSourceFolio != value)
                {
                    _isSourceFolio = value;
                    PropertyHasChanged("IsSourceFolio");
                }
            }
        }

        [DataMember]
        public bool? IsDestinationFolio
        {
            get { return _isDestinationFolio; }
            set
            {
                if (_isDestinationFolio != value)
                {
                    _isDestinationFolio = value;
                    PropertyHasChanged("IsDestinationFolio");
                }
            }
        }

        [DataMember]
        public Guid? TransactionZone_TermID
        {
            get { return _transactionZone_TermID; }
            set
            {
                if (_transactionZone_TermID != value)
                {
                    _transactionZone_TermID = value;
                    PropertyHasChanged("TransactionZone_TermID");
                }
            }
        }

        [DataMember]
        public bool? IsDirectBill
        {
            get { return _isDirectBill; }
            set
            {
                if (_isDirectBill != value)
                {
                    _isDirectBill = value;
                    PropertyHasChanged("IsDirectBill");
                }
            }
        }

        [DataMember]
        public string BilledTo
        {
            get { return _billedTo; }
            set
            {
                if (_billedTo != value)
                {
                    _billedTo = value;
                    PropertyHasChanged("BilledTo");
                }
            }
        }

        [DataMember]
        public Guid? FolioType_TermID
        {
            get { return _folioType_TermID; }
            set
            {
                if (_folioType_TermID != value)
                {
                    _folioType_TermID = value;
                    PropertyHasChanged("FolioType_TermID");
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


        public string FolioStatus
        {
            get { return _folioStatus; }
            set
            {
                if (_folioStatus != value)
                {
                    _folioStatus = value;
                    PropertyHasChanged("FolioStatus");
                }
            }
        }

        [DataMember]
        public string BillingAddress
        {
            get { return _billingAddress; }
            set
            {
                if (_billingAddress != value)
                {
                    _billingAddress = value;
                    PropertyHasChanged("BillingAddress");
                }
            }
        }

        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("FolioID", "FolioID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("FolioNo", "FolioNo", 165));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("BilledTo", "BilledTo", 65));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "FolioID = {0}\n" +
            "ReservationID = {1}\n" +
            "GuestID = {2}\n" +
            "AgentID = {3}\n" +
            "FolioNo = {4}\n" +
            "CreationDate = {5}\n" +
            "IsSubFolio = {6}\n" +
            "IsSplitFolio = {7}\n" +
            "ParentFolioID = {8}\n" +
            "FolioStatus_TermID = {9}\n" +
            "IsLocked = {10}\n" +
            "LockedBy = {11}\n" +
            "CurrentBalace = {12}\n" +
            "Charges = {13}\n" +
            "Payment = {14}\n" +
            "Adjustment = {15}\n" +
            "IsSourceFolio = {16}\n" +
            "IsDestinationFolio = {17}\n" +
            "TransactionZone_TermID = {18}\n" +
            "IsDirectBill = {19}\n" +
            "BilledTo = {20}\n" +
            "FolioType_TermID = {21}\n" +
            "PropertyID = {22}\n" +
            "CompanyID = {23}\n" +
            "SeqNo = {24}\n" +
            "IsSynch = {25}\n" +
            "SynchOn = {26}\n" +
            "UpdatedOn = {27}\n" +
            "UpdatedBy = {28}\n" +
            "IsActive = {29}\n"+
            "FolioStatus = {30}\n" +
            "BillingAddress={31}\n",
            FolioID, ReservationID, GuestID, AgentID, FolioNo, CreationDate, IsSubFolio, IsSplitFolio, ParentFolioID, FolioStatus_TermID, IsLocked, LockedBy, CurrentBalace, Charges, Payment, Adjustment, IsSourceFolio, IsDestinationFolio, TransactionZone_TermID, IsDirectBill, BilledTo, FolioType_TermID, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, FolioStatus, BillingAddress); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class FolioKeys
    {

        #region Data Members

        Guid _folioID;

        #endregion

        #region Constructor

        public FolioKeys(Guid folioID)
        {
            _folioID = folioID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid FolioID
        {
            get { return _folioID; }
        }

        #endregion

    }
}
