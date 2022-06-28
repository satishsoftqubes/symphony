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
    public class Collection : BusinessObjectBase
    {

        #region InnerClass
        public enum CollectionFields
        {
            CollectionID,
            BookID,
            CR,
            DB,
            MOP_TermID,
            EntryDate,
            MOP_AcctID,
            Narration,
            ReservationID,
            FolioID,
            CounterID,
            GuestID,
            UserID,
            InvoiceID,
            GeneralBillID,
            AuditID,
            CloseID,
            ReconcileID,
            GeneralID,
            GeneralIDType_TermID,
            IsDeposit,
            PropertyID,
            CompanyID,
            SeqNo,
            IsSynch,
            SynchOn,
            UpdatedOn,
            UpdatedBy,
            IsActive
        }
        #endregion

        #region Data Members

        Guid _collectionID;
        Guid? _bookID;
        decimal? _cR;
        decimal? _dB;
        int? _mOP_TermID;
        DateTime? _entryDate;
        Guid? _mOP_AcctID;
        string _narration;
        Guid? _reservationID;
        Guid? _folioID;
        Guid? _counterID;
        Guid? _guestID;
        Guid? _userID;
        Guid? _invoiceID;
        Guid? _generalBillID;
        Guid? _auditID;
        Guid? _closeID;
        Guid? _reconcileID;
        Guid? _generalID;
        Guid? _generalIDType_TermID;
        bool? _isDeposit;
        Guid? _propertyID;
        Guid? _companyID;
        long _seqNo;
        bool? _isSynch;
        DateTime? _synchOn;
        DateTime? _updatedOn;
        Guid? _updatedBy;
        bool? _isActive;

        #endregion

        #region Properties

        [DataMember]
        public Guid CollectionID
        {
            get { return _collectionID; }
            set
            {
                if (_collectionID != value)
                {
                    _collectionID = value;
                    PropertyHasChanged("CollectionID");
                }
            }
        }

        [DataMember]
        public Guid? BookID
        {
            get { return _bookID; }
            set
            {
                if (_bookID != value)
                {
                    _bookID = value;
                    PropertyHasChanged("BookID");
                }
            }
        }

        [DataMember]
        public decimal? CR
        {
            get { return _cR; }
            set
            {
                if (_cR != value)
                {
                    _cR = value;
                    PropertyHasChanged("CR");
                }
            }
        }

        [DataMember]
        public decimal? DB
        {
            get { return _dB; }
            set
            {
                if (_dB != value)
                {
                    _dB = value;
                    PropertyHasChanged("DB");
                }
            }
        }

        [DataMember]
        public int? MOP_TermID
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
        public DateTime? EntryDate
        {
            get { return _entryDate; }
            set
            {
                if (_entryDate != value)
                {
                    _entryDate = value;
                    PropertyHasChanged("EntryDate");
                }
            }
        }

        [DataMember]
        public Guid? MOP_AcctID
        {
            get { return _mOP_AcctID; }
            set
            {
                if (_mOP_AcctID != value)
                {
                    _mOP_AcctID = value;
                    PropertyHasChanged("MOP_AcctID");
                }
            }
        }

        [DataMember]
        public string Narration
        {
            get { return _narration; }
            set
            {
                if (_narration != value)
                {
                    _narration = value;
                    PropertyHasChanged("Narration");
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
        public Guid? CounterID
        {
            get { return _counterID; }
            set
            {
                if (_counterID != value)
                {
                    _counterID = value;
                    PropertyHasChanged("CounterID");
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
        public Guid? UserID
        {
            get { return _userID; }
            set
            {
                if (_userID != value)
                {
                    _userID = value;
                    PropertyHasChanged("UserID");
                }
            }
        }

        [DataMember]
        public Guid? InvoiceID
        {
            get { return _invoiceID; }
            set
            {
                if (_invoiceID != value)
                {
                    _invoiceID = value;
                    PropertyHasChanged("InvoiceID");
                }
            }
        }

        [DataMember]
        public Guid? GeneralBillID
        {
            get { return _generalBillID; }
            set
            {
                if (_generalBillID != value)
                {
                    _generalBillID = value;
                    PropertyHasChanged("GeneralBillID");
                }
            }
        }

        [DataMember]
        public Guid? AuditID
        {
            get { return _auditID; }
            set
            {
                if (_auditID != value)
                {
                    _auditID = value;
                    PropertyHasChanged("AuditID");
                }
            }
        }

        [DataMember]
        public Guid? CloseID
        {
            get { return _closeID; }
            set
            {
                if (_closeID != value)
                {
                    _closeID = value;
                    PropertyHasChanged("CloseID");
                }
            }
        }

        [DataMember]
        public Guid? ReconcileID
        {
            get { return _reconcileID; }
            set
            {
                if (_reconcileID != value)
                {
                    _reconcileID = value;
                    PropertyHasChanged("ReconcileID");
                }
            }
        }

        [DataMember]
        public Guid? GeneralID
        {
            get { return _generalID; }
            set
            {
                if (_generalID != value)
                {
                    _generalID = value;
                    PropertyHasChanged("GeneralID");
                }
            }
        }

        [DataMember]
        public Guid? GeneralIDType_TermID
        {
            get { return _generalIDType_TermID; }
            set
            {
                if (_generalIDType_TermID != value)
                {
                    _generalIDType_TermID = value;
                    PropertyHasChanged("GeneralIDType_TermID");
                }
            }
        }

        [DataMember]
        public bool? IsDeposit
        {
            get { return _isDeposit; }
            set
            {
                if (_isDeposit != value)
                {
                    _isDeposit = value;
                    PropertyHasChanged("IsDeposit");
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


        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("CollectionID", "CollectionID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Narration", "Narration", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "CollectionID = {0}\n" +
            "BookID = {1}\n" +
            "CR = {2}\n" +
            "DB = {3}\n" +
            "MOP_TermID = {4}\n" +
            "EntryDate = {5}\n" +
            "MOP_AcctID = {6}\n" +
            "Narration = {7}\n" +
            "ReservationID = {8}\n" +
            "FolioID = {9}\n" +
            "CounterID = {10}\n" +
            "GuestID = {11}\n" +
            "UserID = {12}\n" +
            "InvoiceID = {13}\n" +
            "GeneralBillID = {14}\n" +
            "AuditID = {15}\n" +
            "CloseID = {16}\n" +
            "ReconcileID = {17}\n" +
            "GeneralID = {18}\n" +
            "GeneralIDType_TermID = {19}\n" +
            "IsDeposit = {20}\n" +
            "PropertyID = {21}\n" +
            "CompanyID = {22}\n" +
            "SeqNo = {23}\n" +
            "IsSynch = {24}\n" +
            "SynchOn = {25}\n" +
            "UpdatedOn = {26}\n" +
            "UpdatedBy = {27}\n" +
            "IsActive = {28}\n",
            CollectionID, BookID, CR, DB, MOP_TermID, EntryDate, MOP_AcctID, Narration, ReservationID, FolioID, CounterID, GuestID, UserID, InvoiceID, GeneralBillID, AuditID, CloseID, ReconcileID, GeneralID, GeneralIDType_TermID, IsDeposit, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class CollectionKeys
    {

        #region Data Members

        Guid _collectionID;

        #endregion

        #region Constructor

        public CollectionKeys(Guid collectionID)
        {
            _collectionID = collectionID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid CollectionID
        {
            get { return _collectionID; }
        }

        #endregion

    }
}
