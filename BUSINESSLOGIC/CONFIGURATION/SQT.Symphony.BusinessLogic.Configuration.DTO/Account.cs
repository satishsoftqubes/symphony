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
    public class Account : BusinessObjectBase
    {

        #region InnerClass
        public enum AccountFields
        {
            AcctID,
            RefAcctID,
            PropertyID,
            CompanyID,
            SeqNo,
            IsSynch,
            SynchOn,
            UpdatedOn,
            UpdatedBy,
            IsActive,
            HardCodeAcctID,
            AcctNo,
            AcctName,
            AcctGroupID,
            DefaultAmt,
            IsDefaultAccount,
            IsServiceAccount,
            IsItemAccount,
            IsMOPAccount,
            IsRoomRevenueAccount,
            IsEnable,
            OpeningBalance,
            BalanceType_TermID,
            CurrentBalance,
            IsTaxAcct,
            IsTaxFlat,
            TaxRate,
            IsRefundable,
            MinValue,
            MaxValue,
            TaxTypeID,
            SymphonyAcctID,
            TransactionZone_TermID,
            BalancyType_Term,
            SymphonyAcctGroupID,
            IsPaidOut,
            IsOverride,
            IsShowInStatement,
            MOP_TermID
        }
        #endregion

        #region Data Members

        Guid _acctID;
        Guid? _refAcctID;
        Guid? _propertyID;
        Guid? _companyID;
        int _seqNo;
        bool? _isSynch;
        DateTime? _synchOn;
        DateTime? _updatedOn;
        Guid? _updatedBy;
        bool? _isActive;
        Guid? _hardCodeAcctID;
        string _acctNo;
        string _acctName;
        Guid? _acctGroupID;
        decimal? _defaultAmt;
        bool? _isDefaultAccount;
        bool? _isServiceAccount;
        bool? _isItemAccount;
        bool? _isMOPAccount;
        bool? _isRoomRevenueAccount;
        int? _transactionZone_TermID;
        bool? _isEnable;
        decimal? _openingBalance;
        Guid? _balanceType_TermID;
        decimal? _currentBalance;
        bool? _isTaxAcct;
        bool? _isTaxFlat;
        decimal? _taxRate;
        bool? _isRefundable;
        decimal? _minValue;
        decimal? _maxValue;
        Guid? _taxTypeID;
        int? _symphonyAcctID;
        //int? _transactionZone_TermID;
        string _balancyType_Term;
        int? _symphonyAcctGroupID;
        bool? _isPaidOut;
        bool? _isOverride;
        bool? _isShowInStatement;
        int? _mop_TermID;

        #endregion

        #region Properties

        [DataMember]
        public Guid AcctID
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
        public Guid? RefAcctID
        {
            get { return _refAcctID; }
            set
            {
                if (_refAcctID != value)
                {
                    _refAcctID = value;
                    PropertyHasChanged("RefAcctID");
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
        public Guid? HardCodeAcctID
        {
            get { return _hardCodeAcctID; }
            set
            {
                if (_hardCodeAcctID != value)
                {
                    _hardCodeAcctID = value;
                    PropertyHasChanged("HardCodeAcctID");
                }
            }
        }

        [DataMember]
        public string AcctNo
        {
            get { return _acctNo; }
            set
            {
                if (_acctNo != value)
                {
                    _acctNo = value;
                    PropertyHasChanged("AcctNo");
                }
            }
        }

        [DataMember]
        public string AcctName
        {
            get { return _acctName; }
            set
            {
                if (_acctName != value)
                {
                    _acctName = value;
                    PropertyHasChanged("AcctName");
                }
            }
        }

        [DataMember]
        public Guid? AcctGroupID
        {
            get { return _acctGroupID; }
            set
            {
                if (_acctGroupID != value)
                {
                    _acctGroupID = value;
                    PropertyHasChanged("AcctGroupID");
                }
            }
        }

        [DataMember]
        public decimal? DefaultAmt
        {
            get { return _defaultAmt; }
            set
            {
                if (_defaultAmt != value)
                {
                    _defaultAmt = value;
                    PropertyHasChanged("DefaultAmt");
                }
            }
        }

        [DataMember]
        public bool? IsDefaultAccount
        {
            get { return _isDefaultAccount; }
            set
            {
                if (_isDefaultAccount != value)
                {
                    _isDefaultAccount = value;
                    PropertyHasChanged("IsDefaultAccount");
                }
            }
        }

        [DataMember]
        public bool? IsServiceAccount
        {
            get { return _isServiceAccount; }
            set
            {
                if (_isServiceAccount != value)
                {
                    _isServiceAccount = value;
                    PropertyHasChanged("IsServiceAccount");
                }
            }
        }

        [DataMember]
        public bool? IsItemAccount
        {
            get { return _isItemAccount; }
            set
            {
                if (_isItemAccount != value)
                {
                    _isItemAccount = value;
                    PropertyHasChanged("IsItemAccount");
                }
            }
        }

        [DataMember]
        public bool? IsMOPAccount
        {
            get { return _isMOPAccount; }
            set
            {
                if (_isMOPAccount != value)
                {
                    _isMOPAccount = value;
                    PropertyHasChanged("IsMOPAccount");
                }
            }
        }

        [DataMember]
        public bool? IsRoomRevenueAccount
        {
            get { return _isRoomRevenueAccount; }
            set
            {
                if (_isRoomRevenueAccount != value)
                {
                    _isRoomRevenueAccount = value;
                    PropertyHasChanged("IsRoomRevenueAccount");
                }
            }
        }

        [DataMember]
        public int? TransactionZone_TermID
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
        public bool? IsEnable
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
        public decimal? OpeningBalance
        {
            get { return _openingBalance; }
            set
            {
                if (_openingBalance != value)
                {
                    _openingBalance = value;
                    PropertyHasChanged("OpeningBalance");
                }
            }
        }

        [DataMember]
        public Guid? BalanceType_TermID
        {
            get { return _balanceType_TermID; }
            set
            {
                if (_balanceType_TermID != value)
                {
                    _balanceType_TermID = value;
                    PropertyHasChanged("BalanceType_TermID");
                }
            }
        }

        [DataMember]
        public decimal? CurrentBalance
        {
            get { return _currentBalance; }
            set
            {
                if (_currentBalance != value)
                {
                    _currentBalance = value;
                    PropertyHasChanged("CurrentBalance");
                }
            }
        }

        [DataMember]
        public bool? IsTaxAcct
        {
            get { return _isTaxAcct; }
            set
            {
                if (_isTaxAcct != value)
                {
                    _isTaxAcct = value;
                    PropertyHasChanged("IsTaxAcct");
                }
            }
        }

        [DataMember]
        public bool? IsTaxFlat
        {
            get { return _isTaxFlat; }
            set
            {
                if (_isTaxFlat != value)
                {
                    _isTaxFlat = value;
                    PropertyHasChanged("IsTaxFlat");
                }
            }
        }

        [DataMember]
        public decimal? TaxRate
        {
            get { return _taxRate; }
            set
            {
                if (_taxRate != value)
                {
                    _taxRate = value;
                    PropertyHasChanged("TaxRate");
                }
            }
        }

        [DataMember]
        public bool? IsRefundable
        {
            get { return _isRefundable; }
            set
            {
                if (_isRefundable != value)
                {
                    _isRefundable = value;
                    PropertyHasChanged("IsRefundable");
                }
            }
        }

        [DataMember]
        public decimal? MinValue
        {
            get { return _minValue; }
            set
            {
                if (_minValue != value)
                {
                    _minValue = value;
                    PropertyHasChanged("MinValue");
                }
            }
        }

        [DataMember]
        public decimal? MaxValue
        {
            get { return _maxValue; }
            set
            {
                if (_maxValue != value)
                {
                    _maxValue = value;
                    PropertyHasChanged("MaxValue");
                }
            }
        }

        [DataMember]
        public Guid? TaxTypeID
        {
            get { return _taxTypeID; }
            set
            {
                if (_taxTypeID != value)
                {
                    _taxTypeID = value;
                    PropertyHasChanged("TaxTypeID");
                }
            }
        }

        [DataMember]
        public int? SymphonyAcctID
        {
            get { return _symphonyAcctID; }
            set
            {
                if (_symphonyAcctID != value)
                {
                    _symphonyAcctID = value;
                    PropertyHasChanged("SymphonyAcctID");
                }
            }
        }

        [DataMember]
        public string BalancyType_Term
        {
            get { return _balancyType_Term; }
            set
            {
                if (_balancyType_Term != value)
                {
                    _balancyType_Term = value;
                    PropertyHasChanged("BalancyType_Term");
                }
            }
        }

        [DataMember]
        public int? SymphonyAcctGroupID
        {
            get { return _symphonyAcctGroupID; }
            set
            {
                if (_symphonyAcctGroupID != value)
                {
                    _symphonyAcctGroupID = value;
                    PropertyHasChanged("SymphonyAcctGroupID");
                }
            }
        }


        [DataMember]
        public bool? IsPaidOut
        {
            get { return _isPaidOut; }
            set
            {
                if (_isPaidOut != value)
                {
                    _isPaidOut = value;
                    PropertyHasChanged("IsPaidOut");
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
        public bool? IsShowInStatement
        {
            get { return _isShowInStatement; }
            set
            {
                if (_isShowInStatement != value)
                {
                    _isShowInStatement = value;
                    PropertyHasChanged("IsShowInStatement");
                }
            }
        }

        [DataMember]
        public int? MOP_TermID
        {
            get { return _mop_TermID; }
            set
            {
                if (_mop_TermID != value)
                {
                    _mop_TermID = value;
                    PropertyHasChanged("MOP_TermID");
                }
            }
        }

        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("AcctID", "AcctID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("AcctNo", "AcctNo", 7));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("AcctName", "AcctName", 150));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "AcctID = {0}~\n" +
            "RefAcctID = {1}~\n" +
            "PropertyID = {2}~\n" +
            "CompanyID = {3}~\n" +
            "SeqNo = {4}~\n" +
            "IsSynch = {5}~\n" +
            "SynchOn = {6}~\n" +
            "UpdatedOn = {7}~\n" +
            "UpdatedBy = {8}~\n" +
            "IsActive = {9}~\n" +
            "HardCodeAcctID = {10}~\n" +
            "AcctNo = {11}~\n" +
            "AcctName = {12}~\n" +
            "AcctGroupID = {13}~\n" +
            "DefaultAmt = {14}~\n" +
            "IsDefaultAccount = {15}~\n" +
            "IsServiceAccount = {16}~\n" +
            "IsItemAccount = {17}~\n" +
            "IsMOPAccount = {18}~\n" +
            "IsRoomRevenueAccount = {19}~\n" +
            "TransactionZone_TermID = {20}~\n" +
            "IsEnable = {21}~\n" +
            "OpeningBalance = {22}~\n" +
            "BalanceType_TermID = {23}~\n" +
            "CurrentBalance = {24}~\n" +
            "IsTaxAcct = {25}~\n" +
            "IsTaxFlat = {26}~\n" +
            "TaxRate = {27}~\n" +
            "IsRefundable = {28}~\n" +
            "MinValue = {29}~\n" +
            "MaxValue = {30}~\n" +
            "TaxTypeID = {31}~\n" +
            "BalancyType_Term = {32}~\n" +
            "SymphonyAcctGroupID = {33}~\n" +
            "SymphonyAcctID = {34}~\n" +
            "IsPaidOut = {35}~\n" +
            "IsOverride = {36}~\n" +
            "IsShowInStatement = {37}~\n" +
            "MOP_TermID = {38}~\n",
            AcctID, RefAcctID, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, HardCodeAcctID, AcctNo, AcctName, AcctGroupID, DefaultAmt, IsDefaultAccount, IsServiceAccount, IsItemAccount, IsMOPAccount, IsRoomRevenueAccount, TransactionZone_TermID, IsEnable, OpeningBalance, BalanceType_TermID, CurrentBalance, IsTaxAcct, IsTaxFlat, TaxRate, IsRefundable, MinValue, MaxValue, TaxTypeID, BalancyType_Term, SymphonyAcctGroupID, SymphonyAcctID, IsPaidOut, IsOverride, IsShowInStatement, MOP_TermID); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class AccountKeys
    {

        #region Data Members

        Guid _acctID;

        #endregion

        #region Constructor

        public AccountKeys(Guid acctID)
        {
            _acctID = acctID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid AcctID
        {
            get { return _acctID; }
        }

        #endregion

    }
}
