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
    public class InvestorPaymentReceipt : BusinessObjectBase
    {

        #region InnerClass
        public enum InvestorPaymentReceiptFields
        {
            InvestorPaymentReceiptID,
            PaymentScheduleID,
            InvestorID,
            PaidAmount,
            DateToPay,
            PayRefNo,
            Note,
            ModeOfPaymentTermID,
            BankName,
            ReceiptNo,
            IsActive,
            BookID,
            IsReconciled,
            ReconciledOn,
            ReconcileBy,
            CreatedOn,
            CreatedBy,
            UpdatedOn,
            UpdatedBy,
            DepositToBank,
            CompanyID,
            SeqNo,
            ReconcileID,
            IsSynch,
            SynchOn,
            ReceiptType_TermID,
            YearToPay,
            RefPayReceiptNo,
            UnitID,
            InsuranceVendor,
            FromDate,
            ToDate,
            PropertyID
        }
        #endregion

        #region Data Members

        Guid _investorPaymentReceiptID;
        Guid? _paymentScheduleID;
        Guid? _investorID;
        decimal? _paidAmount;
        DateTime? _dateToPay;
        string _payRefNo;
        string _note;
        Guid? _modeOfPaymentTermID;
        string _bankName;
        string _receiptNo;
        bool? _isActive;
        Guid? _bookID;
        bool? _isReconciled;
        DateTime? _reconciledOn;
        Guid? _reconcileBy;
        DateTime? _createdOn;
        Guid? _createdBy;
        DateTime? _updatedOn;
        Guid? _updatedBy;
        string _depositToBank;
        Guid? _companyID;
        int _seqNo;
        Guid? _reconcileID;
        bool? _isSynch;
        DateTime? _synchOn;
        Guid? _receiptType_TermID;
        string _yearToPay;
        string _refPayReceiptNo;
        Guid? _unitID;
        string _insuranceVendor;
        DateTime? _fromDate;
        DateTime? _toDate;
        Guid? _propertyID;

        #endregion

        #region Properties

        [DataMember]
        public Guid InvestorPaymentReceiptID
        {
            get { return _investorPaymentReceiptID; }
            set
            {
                if (_investorPaymentReceiptID != value)
                {
                    _investorPaymentReceiptID = value;
                    PropertyHasChanged("InvestorPaymentReceiptID");
                }
            }
        }

        [DataMember]
        public Guid? PaymentScheduleID
        {
            get { return _paymentScheduleID; }
            set
            {
                if (_paymentScheduleID != value)
                {
                    _paymentScheduleID = value;
                    PropertyHasChanged("PaymentScheduleID");
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
        public decimal? PaidAmount
        {
            get { return _paidAmount; }
            set
            {
                if (_paidAmount != value)
                {
                    _paidAmount = value;
                    PropertyHasChanged("PaidAmount");
                }
            }
        }

        [DataMember]
        public DateTime? DateToPay
        {
            get { return _dateToPay; }
            set
            {
                if (_dateToPay != value)
                {
                    _dateToPay = value;
                    PropertyHasChanged("DateToPay");
                }
            }
        }

        [DataMember]
        public string PayRefNo
        {
            get { return _payRefNo; }
            set
            {
                if (_payRefNo != value)
                {
                    _payRefNo = value;
                    PropertyHasChanged("PayRefNo");
                }
            }
        }

        [DataMember]
        public string Note
        {
            get { return _note; }
            set
            {
                if (_note != value)
                {
                    _note = value;
                    PropertyHasChanged("Note");
                }
            }
        }

        [DataMember]
        public Guid? ModeOfPaymentTermID
        {
            get { return _modeOfPaymentTermID; }
            set
            {
                if (_modeOfPaymentTermID != value)
                {
                    _modeOfPaymentTermID = value;
                    PropertyHasChanged("ModeOfPaymentTermID");
                }
            }
        }

        [DataMember]
        public string BankName
        {
            get { return _bankName; }
            set
            {
                if (_bankName != value)
                {
                    _bankName = value;
                    PropertyHasChanged("BankName");
                }
            }
        }

        [DataMember]
        public string ReceiptNo
        {
            get { return _receiptNo; }
            set
            {
                if (_receiptNo != value)
                {
                    _receiptNo = value;
                    PropertyHasChanged("ReceiptNo");
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
        public bool? IsReconciled
        {
            get { return _isReconciled; }
            set
            {
                if (_isReconciled != value)
                {
                    _isReconciled = value;
                    PropertyHasChanged("IsReconciled");
                }
            }
        }

        [DataMember]
        public DateTime? ReconciledOn
        {
            get { return _reconciledOn; }
            set
            {
                if (_reconciledOn != value)
                {
                    _reconciledOn = value;
                    PropertyHasChanged("ReconciledOn");
                }
            }
        }

        [DataMember]
        public Guid? ReconcileBy
        {
            get { return _reconcileBy; }
            set
            {
                if (_reconcileBy != value)
                {
                    _reconcileBy = value;
                    PropertyHasChanged("ReconcileBy");
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
        public string DepositToBank
        {
            get { return _depositToBank; }
            set
            {
                if (_depositToBank != value)
                {
                    _depositToBank = value;
                    PropertyHasChanged("DepositToBank");
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
        public DateTime? FromDate
        {
            get { return _fromDate; }
            set
            {
                if (_fromDate != value)
                {
                    _fromDate = value;
                    PropertyHasChanged("FromDate");
                }
            }
        }

        [DataMember]
        public DateTime? ToDate
        {
            get { return _toDate; }
            set
            {
                if (_toDate != value)
                {
                    _toDate = value;
                    PropertyHasChanged("ToDate");
                }
            }
        }

        [DataMember]
        public Guid? ReceiptType_TermID
        {
            get { return _receiptType_TermID; }
            set
            {
                if (_receiptType_TermID != value)
                {
                    _receiptType_TermID = value;
                    PropertyHasChanged("ReceiptType_TermID");
                }
            }
        }

        [DataMember]
        public string YearToPay
        {
            get { return _yearToPay; }
            set
            {
                if (_yearToPay != value)
                {
                    _yearToPay = value;
                    PropertyHasChanged("YearToPay");
                }
            }
        }

        [DataMember]
        public string RefPayReceiptNo
        {
            get { return _refPayReceiptNo; }
            set
            {
                if (_refPayReceiptNo != value)
                {
                    _refPayReceiptNo = value;
                    PropertyHasChanged("RefPayReceiptNo");
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
        public string InsuranceVendor
        {
            get { return _insuranceVendor; }
            set
            {
                if (_insuranceVendor != value)
                {
                    _insuranceVendor = value;
                    PropertyHasChanged("InsuranceVendor");
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

        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("InvestorPaymentReceiptID", "InvestorPaymentReceiptID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PayRefNo", "PayRefNo", 50));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Note", "Note", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("BankName", "BankName", 250));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ReceiptNo", "ReceiptNo", 13));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("DepositToBank", "DepositToBank", 65));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("YearToPay", "YearToPay", 25));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("RefPayReceiptNo", "RefPayReceiptNo", 250));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("InsuranceVendor", "InsuranceVendor", 250));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "InvestorPaymentReceiptID = {0}\n" +
            "PaymentScheduleID = {1}\n" +
            "InvestorID = {2}\n" +
            "PaidAmount = {3}\n" +
            "DateToPay = {4}\n" +
            "PayRefNo = {5}\n" +
            "Note = {6}\n" +
            "ModeOfPaymentTermID = {7}\n" +
            "BankName = {8}\n" +
            "ReceiptNo = {9}\n" +
            "IsActive = {10}\n" +
            "BookID = {11}\n" +
            "IsReconciled = {12}\n" +
            "ReconciledOn = {13}\n" +
            "ReconcileBy = {14}\n" +
            "CreatedOn = {15}\n" +
            "CreatedBy = {16}\n" +
            "UpdatedOn = {17}\n" +
            "UpdatedBy = {18}\n" +
            "DepositToBank = {19}\n" +
            "CompanyID = {20}\n" +
            "SeqNo = {21}\n" +
            "ReconcileID = {22}\n" +
            "IsSynch = {23}\n" +
            "SynchOn = {24}\n" +
            "ReceiptType_TermID = {25}\n" +
            "YearToPay = {26}\n" +
            "RefPayReceiptNo = {27}\n" +
            "UnitID = {28}\n" +
            "InsuranceVendor = {29}\n" +
            "FromDate={30}\n" +
            "ToDate={31}\n" +
            "PropertyID={32}",
            InvestorPaymentReceiptID, PaymentScheduleID, InvestorID, PaidAmount, DateToPay, PayRefNo, Note, ModeOfPaymentTermID, BankName, ReceiptNo, IsActive, BookID, IsReconciled, ReconciledOn, ReconcileBy, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, DepositToBank, CompanyID, SeqNo, ReconcileID, IsSynch, SynchOn, ReceiptType_TermID, YearToPay, RefPayReceiptNo, UnitID, InsuranceVendor, FromDate, ToDate, PropertyID); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class InvestorPaymentReceiptKeys
    {

        #region Data Members

        Guid _investorPaymentReceiptID;

        #endregion

        #region Constructor

        public InvestorPaymentReceiptKeys(Guid investorPaymentReceiptID)
        {
            _investorPaymentReceiptID = investorPaymentReceiptID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid InvestorPaymentReceiptID
        {
            get { return _investorPaymentReceiptID; }
        }

        #endregion

    }
}
