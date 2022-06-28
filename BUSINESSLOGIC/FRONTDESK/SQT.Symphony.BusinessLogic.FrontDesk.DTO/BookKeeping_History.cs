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
    public class BookKeeping_History : BusinessObjectBase
    {

        #region InnerClass
        public enum BookKeeping_HistoryFields
        {
            BookHistoryID,
            BookID,
            OperationDate,
            OperationCode_TermID,
            NewBookID,
            HistoryRemark,
            BKPRecord,
            BeforeAmt,
            AfterAmt,
            EffectiveAmt,
            ReservationID,
            FolioID,
            AuditID,
            UserID,
            PropertyID,
            CompanyID,
            SeqNo,
            IsSynch,
            SynchOn,
            UpdatedOn,
            UpdatedBy,
            IsActive,
            OperationCode_Term
        }
        #endregion

        #region Data Members

        Guid _bookHistoryID;
        Guid? _bookID;
        DateTime? _operationDate;
        Guid? _operationCode_TermID;
        Guid? _newBookID;
        string _historyRemark;
        string _bKPRecord;
        decimal? _beforeAmt;
        decimal? _afterAmt;
        decimal? _effectiveAmt;
        Guid? _reservationID;
        Guid? _folioID;
        Guid? _auditID;
        Guid? _userID;
        Guid? _propertyID;
        Guid? _companyID;
        long _seqNo;
        bool? _isSynch;
        DateTime? _synchOn;
        DateTime? _updatedOn;
        Guid? _updatedBy;
        bool? _isActive;
        string _operationCode_Term;

        #endregion

        #region Properties

        [DataMember]
        public Guid BookHistoryID
        {
            get { return _bookHistoryID; }
            set
            {
                if (_bookHistoryID != value)
                {
                    _bookHistoryID = value;
                    PropertyHasChanged("BookHistoryID");
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
        public DateTime? OperationDate
        {
            get { return _operationDate; }
            set
            {
                if (_operationDate != value)
                {
                    _operationDate = value;
                    PropertyHasChanged("OperationDate");
                }
            }
        }

        [DataMember]
        public Guid? OperationCode_TermID
        {
            get { return _operationCode_TermID; }
            set
            {
                if (_operationCode_TermID != value)
                {
                    _operationCode_TermID = value;
                    PropertyHasChanged("OperationCode_TermID");
                }
            }
        }

        [DataMember]
        public Guid? NewBookID
        {
            get { return _newBookID; }
            set
            {
                if (_newBookID != value)
                {
                    _newBookID = value;
                    PropertyHasChanged("NewBookID");
                }
            }
        }

        [DataMember]
        public string HistoryRemark
        {
            get { return _historyRemark; }
            set
            {
                if (_historyRemark != value)
                {
                    _historyRemark = value;
                    PropertyHasChanged("HistoryRemark");
                }
            }
        }

        [DataMember]
        public string BKPRecord
        {
            get { return _bKPRecord; }
            set
            {
                if (_bKPRecord != value)
                {
                    _bKPRecord = value;
                    PropertyHasChanged("BKPRecord");
                }
            }
        }

        [DataMember]
        public decimal? BeforeAmt
        {
            get { return _beforeAmt; }
            set
            {
                if (_beforeAmt != value)
                {
                    _beforeAmt = value;
                    PropertyHasChanged("BeforeAmt");
                }
            }
        }

        [DataMember]
        public decimal? AfterAmt
        {
            get { return _afterAmt; }
            set
            {
                if (_afterAmt != value)
                {
                    _afterAmt = value;
                    PropertyHasChanged("AfterAmt");
                }
            }
        }

        [DataMember]
        public decimal? EffectiveAmt
        {
            get { return _effectiveAmt; }
            set
            {
                if (_effectiveAmt != value)
                {
                    _effectiveAmt = value;
                    PropertyHasChanged("EffectiveAmt");
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

        public string OperationCode_Term
        {
            get { return _operationCode_Term; }
            set
            {
                if (_operationCode_Term != value)
                {
                    _operationCode_Term = value;
                    PropertyHasChanged("OperationCode_Term");
                }
            }
        }
        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("BookHistoryID", "BookHistoryID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("HistoryRemark", "HistoryRemark", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("BKPRecord", "BKPRecord", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "BookHistoryID = {0}\n" +
            "BookID = {1}\n" +
            "OperationDate = {2}\n" +
            "OperationCode_TermID = {3}\n" +
            "NewBookID = {4}\n" +
            "HistoryRemark = {5}\n" +
            "BKPRecord = {6}\n" +
            "BeforeAmt = {7}\n" +
            "AfterAmt = {8}\n" +
            "EffectiveAmt = {9}\n" +
            "ReservationID = {10}\n" +
            "FolioID = {11}\n" +
            "AuditID = {12}\n" +
            "UserID = {13}\n" +
            "PropertyID = {14}\n" +
            "CompanyID = {15}\n" +
            "SeqNo = {16}\n" +
            "IsSynch = {17}\n" +
            "SynchOn = {18}\n" +
            "UpdatedOn = {19}\n" +
            "UpdatedBy = {20}\n" +
            "IsActive = {21}\n"+
            "OperationCode_Term={22}\n",
            BookHistoryID, BookID, OperationDate, OperationCode_TermID, NewBookID, HistoryRemark, BKPRecord, BeforeAmt, AfterAmt, EffectiveAmt, ReservationID, FolioID, AuditID, UserID, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, OperationCode_Term); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class BookKeeping_HistoryKeys
    {

        #region Data Members

        Guid _bookHistoryID;

        #endregion

        #region Constructor

        public BookKeeping_HistoryKeys(Guid bookHistoryID)
        {
            _bookHistoryID = bookHistoryID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid BookHistoryID
        {
            get { return _bookHistoryID; }
        }

        #endregion

    }
}
