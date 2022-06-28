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
    public class CurrencyTypes : BusinessObjectBase
    {

        #region InnerClass
        public enum CurrencyTypeFields
        {
            CurrencyTypeID,
            SeqNo,
            CurrencyCode,
            CurrencyName,
            CurrencyValue,
            CurrencyType_Term,
            CurrencyType,
            UpdateLog,
            PropertyID,
            CompanyID,
            IsSynch,
            SynchOn,
            UpdatedOn,
            UpdatedBy,
            IsActive
        }
        #endregion

        #region Data Members

        Guid _currencyTypeID;
        long _seqNo;
        string _currencyCode;
        string _currencyName;
        decimal _currencyValue;
        string _currencyType_Term;
        string _currencyType;
        byte[] _updateLog;
        Guid? _propertyID;
        Guid? _companyID;
        bool? _isSynch;
        DateTime? _synchOn;
        DateTime? _updatedOn;
        Guid? _updatedBy;
        bool? _isActive;

        #endregion

        #region Properties

        [DataMember]
        public Guid CurrencyTypeID
        {
            get { return _currencyTypeID; }
            set
            {
                if (_currencyTypeID != value)
                {
                    _currencyTypeID = value;
                    PropertyHasChanged("CurrencyTypeID");
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
        public string CurrencyCode
        {
            get { return _currencyCode; }
            set
            {
                if (_currencyCode != value)
                {
                    _currencyCode = value;
                    PropertyHasChanged("CurrencyCode");
                }
            }
        }

        [DataMember]
        public string CurrencyName
        {
            get { return _currencyName; }
            set
            {
                if (_currencyName != value)
                {
                    _currencyName = value;
                    PropertyHasChanged("CurrencyName");
                }
            }
        }

        [DataMember]
        public decimal CurrencyValue
        {
            get { return _currencyValue; }
            set
            {
                if (_currencyValue != value)
                {
                    _currencyValue = value;
                    PropertyHasChanged("CurrencyValue");
                }
            }
        }

        [DataMember]
        public string CurrencyType_Term
        {
            get { return _currencyType_Term; }
            set
            {
                if (_currencyType_Term != value)
                {
                    _currencyType_Term = value;
                    PropertyHasChanged("CurrencyType_Term");
                }
            }
        }

        [DataMember]
        public string CurrencyType
        {
            get { return _currencyType; }
            set
            {
                if (_currencyType != value)
                {
                    _currencyType = value;
                    PropertyHasChanged("CurrencyType");
                }
            }
        }

        [DataMember]
        public byte[] UpdateLog
        {
            get { return _updateLog; }
            set
            {
                if (_updateLog != value)
                {
                    _updateLog = value;
                    PropertyHasChanged("UpdateLog");
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
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("CurrencyTypeID", "CurrencyTypeID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CurrencyCode", "CurrencyCode", 10));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CurrencyName", "CurrencyName", 20));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("CurrencyValue", "CurrencyValue"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CurrencyType_Term", "CurrencyType_Term", 12));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CurrencyType", "CurrencyType", 20));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "CurrencyTypeID = {0}\n" +
            "SeqNo = {1}\n" +
            "CurrencyCode = {2}\n" +
            "CurrencyName = {3}\n" +
            "CurrencyValue = {4}\n" +
            "CurrencyType_Term = {5}\n" +
            "CurrencyType = {6}\n" +
            "UpdateLog = {7}\n" +
            "PropertyID = {8}\n" +
            "CompanyID = {9}\n" +
            "IsSynch = {10}\n" +
            "SynchOn = {11}\n" +
            "UpdatedOn = {12}\n" +
            "UpdatedBy = {13}\n" +
            "IsActive = {14}\n",
            CurrencyTypeID, SeqNo, CurrencyCode, CurrencyName, CurrencyValue, CurrencyType_Term, CurrencyType, UpdateLog, PropertyID, CompanyID, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class CurrencyTypeKeys
    {

        #region Data Members

        Guid _currencyTypeID;

        #endregion

        #region Constructor

        public CurrencyTypeKeys(Guid currencyTypeID)
        {
            _currencyTypeID = currencyTypeID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid CurrencyTypeID
        {
            get { return _currencyTypeID; }
        }

        #endregion

    }
}
