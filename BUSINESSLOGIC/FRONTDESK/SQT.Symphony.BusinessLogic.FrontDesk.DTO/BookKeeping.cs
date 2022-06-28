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
    public class BookKeeping : BusinessObjectBase
    {

        #region InnerClass
        public enum BookKeepingFields
        {
            BookID,
            BookNo,
            RefBookID,
            ReservationID,
            FolioID,
            EntryDate,
            TransactionZone_TermID,
            AuditDate,
            CounterID,
            CloseID,
            IsLocked,
            AuditID,
            Amount,
            Narration,
            Description,
            EntryOrigin_TermID,
            POS_PointID,
            IsCharge,
            TransactionType_TermID,
            RoomID,
            UnitID,
            UnitType_TermID,
            IsPosted,
            GeneralBillID,
            InvoiceID,
            IsOverride,
            OverrideReason,
            OverrideBy,
            ConferenceID,
            IsVoid,
            VoidReason,
            VoidBy,
            SourceFolioID,
            ItemID,
            ItemQty,
            ItemRate,
            IsCreditNote,
            IsVoucher,
            VoucherNo,
            EntryByUserID,
            MOP_TermID,
            ResPayID,
            AppliedTax,
            CR_Ledger,
            DB_Ledger,
            CR_Amt,
            DB_Amt,
            YearID,
            OriginalBookID,
            IsCredit,
            AccountGroup_TermID,
            ReconcileID,
            PropertyID,
            CompanyID,
            SeqNo,
            IsSynch,
            SynchOn,
            UpdatedOn,
            UpdatedBy,
            IsActive,
            GeneralID,
            GeneralIDType_Term

        }
        #endregion

        #region Data Members

        Guid _bookID;
        string _bookNo;
        Guid? _refBookID;
        Guid? _reservationID;
        Guid? _folioID;
        DateTime? _entryDate;
        Guid? _transactionZone_TermID;
        DateTime? _auditDate;
        Guid? _counterID;
        Guid? _closeID;
        bool? _isLocked;
        Guid? _auditID;
        decimal? _amount;
        string _narration;
        string _description;
        int? _entryOrigin_TermID;
        Guid? _pOS_PointID;
        bool? _isCharge;
        int? _transactionType_TermID;
        Guid? _roomID;
        Guid? _unitID;
        string _unitType_Term;
        bool? _isPosted;
        Guid? _generalBillID;
        Guid? _invoiceID;
        bool? _isOverride;
        string _overrideReason;
        Guid? _overrideBy;
        Guid? _conferenceID;
        bool? _isVoid;
        string _voidReason;
        Guid? _voidBy;
        Guid? _sourceFolioID;
        Guid? _itemID;
        decimal? _itemQty;
        decimal? _itemRate;
        bool? _isCreditNote;
        bool? _isVoucher;
        string _voucherNo;
        Guid? _entryByUserID;
        int? _mOP_TermID;
        Guid? _resPayID;
        decimal? _appliedTax;
        string _cR_Ledger;
        string _dB_Ledger;
        decimal? _cR_Amt;
        decimal? _dB_Amt;
        Guid? _yearID;
        Guid? _originalBookID;
        bool? _isCredit;
        int? _accountGroup_TermID;
        Guid? _reconcileID;
        Guid? _propertyID;
        Guid? _companyID;
        long _seqNo;
        bool? _isSynch;
        DateTime? _synchOn;
        DateTime? _updatedOn;
        Guid? _updatedBy;
        bool? _isActive;
        Guid? _generalID;
        string _generalIDType_Term;
        
        #endregion

        #region Properties

        [DataMember]
        public Guid BookID
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
        public string BookNo
        {
            get { return _bookNo; }
            set
            {
                if (_bookNo != value)
                {
                    _bookNo = value;
                    PropertyHasChanged("BookNo");
                }
            }
        }

        [DataMember]
        public Guid? RefBookID
        {
            get { return _refBookID; }
            set
            {
                if (_refBookID != value)
                {
                    _refBookID = value;
                    PropertyHasChanged("RefBookID");
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
        public DateTime? AuditDate
        {
            get { return _auditDate; }
            set
            {
                if (_auditDate != value)
                {
                    _auditDate = value;
                    PropertyHasChanged("AuditDate");
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
        public decimal? Amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    PropertyHasChanged("Amount");
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
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    PropertyHasChanged("Description");
                }
            }
        }

        [DataMember]
        public int? EntryOrigin_TermID
        {
            get { return _entryOrigin_TermID; }
            set
            {
                if (_entryOrigin_TermID != value)
                {
                    _entryOrigin_TermID = value;
                    PropertyHasChanged("EntryOrigin_TermID");
                }
            }
        }

        [DataMember]
        public Guid? POS_PointID
        {
            get { return _pOS_PointID; }
            set
            {
                if (_pOS_PointID != value)
                {
                    _pOS_PointID = value;
                    PropertyHasChanged("POS_PointID");
                }
            }
        }

        [DataMember]
        public bool? IsCharge
        {
            get { return _isCharge; }
            set
            {
                if (_isCharge != value)
                {
                    _isCharge = value;
                    PropertyHasChanged("IsCharge");
                }
            }
        }

        [DataMember]
        public int? TransactionType_TermID
        {
            get { return _transactionType_TermID; }
            set
            {
                if (_transactionType_TermID != value)
                {
                    _transactionType_TermID = value;
                    PropertyHasChanged("TransactionType_TermID");
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
        public Guid? UnitID
        {
            get { return _unitID; }
            set
            {
                if (_unitID != value)
                {
                    _unitID = value;
                    PropertyHasChanged("UnitID");
                }
            }
        }

        [DataMember]
        public string UnitType_Term
        {
            get { return _unitType_Term; }
            set
            {
                if (_unitType_Term != value)
                {
                    _unitType_Term = value;
                    PropertyHasChanged("UnitType_Term");
                }
            }
        }

        [DataMember]
        public bool? IsPosted
        {
            get { return _isPosted; }
            set
            {
                if (_isPosted != value)
                {
                    _isPosted = value;
                    PropertyHasChanged("IsPosted");
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
        public bool? IsOverride
        {
            get { return _isOverride; }
            set
            {
                if (_isOverride != value)
                {
                    _isOverride = value;
                    PropertyHasChanged("IsOverride");
                }
            }
        }

        [DataMember]
        public string OverrideReason
        {
            get { return _overrideReason; }
            set
            {
                if (_overrideReason != value)
                {
                    _overrideReason = value;
                    PropertyHasChanged("OverrideReason");
                }
            }
        }

        [DataMember]
        public Guid? OverrideBy
        {
            get { return _overrideBy; }
            set
            {
                if (_overrideBy != value)
                {
                    _overrideBy = value;
                    PropertyHasChanged("OverrideBy");
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
        public bool? IsVoid
        {
            get { return _isVoid; }
            set
            {
                if (_isVoid != value)
                {
                    _isVoid = value;
                    PropertyHasChanged("IsVoid");
                }
            }
        }

        [DataMember]
        public string VoidReason
        {
            get { return _voidReason; }
            set
            {
                if (_voidReason != value)
                {
                    _voidReason = value;
                    PropertyHasChanged("VoidReason");
                }
            }
        }

        [DataMember]
        public Guid? VoidBy
        {
            get { return _voidBy; }
            set
            {
                if (_voidBy != value)
                {
                    _voidBy = value;
                    PropertyHasChanged("VoidBy");
                }
            }
        }

        [DataMember]
        public Guid? SourceFolioID
        {
            get { return _sourceFolioID; }
            set
            {
                if (_sourceFolioID != value)
                {
                    _sourceFolioID = value;
                    PropertyHasChanged("SourceFolioID");
                }
            }
        }

        [DataMember]
        public Guid? ItemID
        {
            get { return _itemID; }
            set
            {
                if (_itemID != value)
                {
                    _itemID = value;
                    PropertyHasChanged("ItemID");
                }
            }
        }

        [DataMember]
        public decimal? ItemQty
        {
            get { return _itemQty; }
            set
            {
                if (_itemQty != value)
                {
                    _itemQty = value;
                    PropertyHasChanged("ItemQty");
                }
            }
        }

        [DataMember]
        public decimal? ItemRate
        {
            get { return _itemRate; }
            set
            {
                if (_itemRate != value)
                {
                    _itemRate = value;
                    PropertyHasChanged("ItemRate");
                }
            }
        }

        [DataMember]
        public bool? IsCreditNote
        {
            get { return _isCreditNote; }
            set
            {
                if (_isCreditNote != value)
                {
                    _isCreditNote = value;
                    PropertyHasChanged("IsCreditNote");
                }
            }
        }

        [DataMember]
        public bool? IsVoucher
        {
            get { return _isVoucher; }
            set
            {
                if (_isVoucher != value)
                {
                    _isVoucher = value;
                    PropertyHasChanged("IsVoucher");
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
        public Guid? EntryByUserID
        {
            get { return _entryByUserID; }
            set
            {
                if (_entryByUserID != value)
                {
                    _entryByUserID = value;
                    PropertyHasChanged("EntryByUserID");
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
        public Guid? ResPayID
        {
            get { return _resPayID; }
            set
            {
                if (_resPayID != value)
                {
                    _resPayID = value;
                    PropertyHasChanged("ResPayID");
                }
            }
        }

        [DataMember]
        public decimal? AppliedTax
        {
            get { return _appliedTax; }
            set
            {
                if (_appliedTax != value)
                {
                    _appliedTax = value;
                    PropertyHasChanged("AppliedTax");
                }
            }
        }

        [DataMember]
        public string CR_Ledger
        {
            get { return _cR_Ledger; }
            set
            {
                if (_cR_Ledger != value)
                {
                    _cR_Ledger = value;
                    PropertyHasChanged("CR_Ledger");
                }
            }
        }

        [DataMember]
        public string DB_Ledger
        {
            get { return _dB_Ledger; }
            set
            {
                if (_dB_Ledger != value)
                {
                    _dB_Ledger = value;
                    PropertyHasChanged("DB_Ledger");
                }
            }
        }

        [DataMember]
        public decimal? CR_Amt
        {
            get { return _cR_Amt; }
            set
            {
                if (_cR_Amt != value)
                {
                    _cR_Amt = value;
                    PropertyHasChanged("CR_Amt");
                }
            }
        }

        [DataMember]
        public decimal? DB_Amt
        {
            get { return _dB_Amt; }
            set
            {
                if (_dB_Amt != value)
                {
                    _dB_Amt = value;
                    PropertyHasChanged("DB_Amt");
                }
            }
        }

        [DataMember]
        public Guid? YearID
        {
            get { return _yearID; }
            set
            {
                if (_yearID != value)
                {
                    _yearID = value;
                    PropertyHasChanged("YearID");
                }
            }
        }

        [DataMember]
        public Guid? OriginalBookID
        {
            get { return _originalBookID; }
            set
            {
                if (_originalBookID != value)
                {
                    _originalBookID = value;
                    PropertyHasChanged("OriginalBookID");
                }
            }
        }

        [DataMember]
        public bool? IsCredit
        {
            get { return _isCredit; }
            set
            {
                if (_isCredit != value)
                {
                    _isCredit = value;
                    PropertyHasChanged("IsCredit");
                }
            }
        }

        [DataMember]
        public int? AccountGroup_TermID
        {
            get { return _accountGroup_TermID; }
            set
            {
                if (_accountGroup_TermID != value)
                {
                    _accountGroup_TermID = value;
                    PropertyHasChanged("AccountGroup_TermID");
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
        public string GeneralIDType_Term
        {
            get { return _generalIDType_Term; }
            set
            {
                if (_generalIDType_Term != value)
                {
                    _generalIDType_Term = value;
                    PropertyHasChanged("GeneralIDType_Term");
                }
            }
        }

        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("BookID", "BookID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("BookNo", "BookNo", 65));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Narration", "Narration", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Description", "Description", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("OverrideReason", "OverrideReason", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("VoidReason", "VoidReason", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("VoucherNo", "VoucherNo", 65));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CR_Ledger", "CR_Ledger", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("DB_Ledger", "DB_Ledger", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "BookID = {0}\n" +
            "BookNo = {1}\n" +
            "RefBookID = {2}\n" +
            "ReservationID = {3}\n" +
            "FolioID = {4}\n" +
            "EntryDate = {5}\n" +
            "TransactionZone_TermID = {6}\n" +
            "AuditDate = {7}\n" +
            "CounterID = {8}\n" +
            "CloseID = {9}\n" +
            "IsLocked = {10}\n" +
            "AuditID = {11}\n" +
            "Amount = {12}\n" +
            "Narration = {13}\n" +
            "Description = {14}\n" +
            "EntryOrigin_TermID = {15}\n" +
            "POS_PointID = {16}\n" +
            "IsCharge = {17}\n" +
            "TransactionType_TermID = {18}\n" +
            "RoomID = {19}\n" +
            "UnitID = {20}\n" +
            "UnitType_Term = {21}\n" +
            "IsPosted = {22}\n" +
            "GeneralBillID = {23}\n" +
            "InvoiceID = {24}\n" +
            "IsOverride = {25}\n" +
            "OverrideReason = {26}\n" +
            "OverrideBy = {27}\n" +
            "ConferenceID = {28}\n" +
            "IsVoid = {29}\n" +
            "VoidReason = {30}\n" +
            "VoidBy = {31}\n" +
            "SourceFolioID = {32}\n" +
            "ItemID = {33}\n" +
            "ItemQty = {34}\n" +
            "ItemRate = {35}\n" +
            "IsCreditNote = {36}\n" +
            "IsVoucher = {37}\n" +
            "VoucherNo = {38}\n" +
            "EntryByUserID = {39}\n" +
            "MOP_TermID = {40}\n" +
            "ResPayID = {41}\n" +
            "AppliedTax = {42}\n" +
            "CR_Ledger = {43}\n" +
            "DB_Ledger = {44}\n" +
            "CR_Amt = {45}\n" +
            "DB_Amt = {46}\n" +
            "YearID = {47}\n" +
            "OriginalBookID = {48}\n" +
            "IsCredit = {49}\n" +
            "AccountGroup_TermID = {50}\n" +
            "ReconcileID = {51}\n" +
            "PropertyID = {52}\n" +
            "CompanyID = {53}\n" +
            "SeqNo = {54}\n" +
            "IsSynch = {55}\n" +
            "SynchOn = {56}\n" +
            "UpdatedOn = {57}\n" +
            "UpdatedBy = {58}\n" +
            "IsActive = {59}\n" +
            "GeneralID = {60}\n" +
            "GeneralIDType_Term = {61}\n",
            BookID, BookNo, RefBookID, ReservationID, FolioID, EntryDate, TransactionZone_TermID, AuditDate, CounterID, CloseID, IsLocked, AuditID, Amount, Narration, Description, EntryOrigin_TermID, POS_PointID, IsCharge, TransactionType_TermID, RoomID, UnitID, UnitType_Term, IsPosted, GeneralBillID, InvoiceID, IsOverride, OverrideReason, OverrideBy, ConferenceID, IsVoid, VoidReason, VoidBy, SourceFolioID, ItemID, ItemQty, ItemRate, IsCreditNote, IsVoucher, VoucherNo, EntryByUserID, MOP_TermID, ResPayID, AppliedTax, CR_Ledger, DB_Ledger, CR_Amt, DB_Amt, YearID, OriginalBookID, IsCredit, AccountGroup_TermID, ReconcileID, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, GeneralID, GeneralIDType_Term); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class BookKeepingKeys
    {

        #region Data Members

        Guid _bookID;

        #endregion

        #region Constructor

        public BookKeepingKeys(Guid bookID)
        {
            _bookID = bookID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid BookID
        {
            get { return _bookID; }
        }

        #endregion

    }
}
