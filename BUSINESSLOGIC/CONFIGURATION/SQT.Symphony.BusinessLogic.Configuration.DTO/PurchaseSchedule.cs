using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SQT.FRAMEWORK.DAL.Linq;

namespace SQT.Symphony.BusinessLogic.Configuration.DTO
{
    [DataContract]
    public class PurchaseSchedule : BusinessObjectBase
    {
        #region InnerClass

        public enum PurchaseScheduleFields
        {
            PurchaseScheduleID,
            PropertyID,
            InstallmentTypeTerm,
            InstallmentAmount,
            InstallmentInPercentage,
            StatusTerm,
            MOPTerm,
            ActualPaymentDate,
            TotalPaid,
            TotalDue,
            IsActive,
            SeqNo
        }

        #endregion

        #region DataMember

        Guid _purchaseScheduleID;
        Guid? _propertyID;
        string _installmentTypeTerm;
        decimal? _installmentAmount;
        decimal? _installmentInPercentage;
        string _statusTerm;
        string _mopTerm;
        DateTime? _actualPaymentDate;
        decimal _totalPaid;
        decimal _totalDue;
        bool? _isActive;
        int? _seqNo;
        byte[] _updateLog;

        #endregion

        #region Properties

        [DataMember]
        public Guid PurchaseScheduleID
        {
            get { return _purchaseScheduleID; }
            set
            {
                if (_purchaseScheduleID != value)
                {
                    _purchaseScheduleID = value;
                    PropertyHasChanged("PurchaseScheduleID");
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
        public string InstallmentTypeTerm
        {
            get { return _installmentTypeTerm; }
            set
            {
                if (_installmentTypeTerm != value)
                {
                    _installmentTypeTerm = value;
                    PropertyHasChanged("InstallmentTypeTerm");
                }
            }
        }

        [DataMember]
        public decimal? InstallmentAmount
        {
            get { return _installmentAmount; }
            set
            {
                if (_installmentAmount != value)
                {
                    _installmentAmount = value;
                    PropertyHasChanged("InstallmentAmount");
                }
            }
        }

        [DataMember]
        public decimal? InstallmentInPercentage
        {
            get { return _installmentInPercentage; }
            set
            {
                if (_installmentInPercentage != value)
                {
                    _installmentInPercentage = value;
                    PropertyHasChanged("InstallmentInPercentage");
                }
            }
        }

        [DataMember]
        public string StatusTerm
        {
            get { return _statusTerm; }
            set
            {
                if (_statusTerm != value)
                {
                    _statusTerm = value;
                    PropertyHasChanged("StatusTerm");
                }
            }
        }

        [DataMember]
        public string MOPTerm
        {
            get { return _mopTerm; }
            set
            {
                if (_mopTerm != value)
                {
                    _mopTerm = value;
                    PropertyHasChanged("MOPTerm");
                }
            }
        }
        
        [DataMember]
        public DateTime? ActualPaymentDate
        {
            get { return _actualPaymentDate; }
            set
            {
                if (_actualPaymentDate != value)
                {
                    _actualPaymentDate = value;
                    PropertyHasChanged("ActualPaymentDate");
                }
            }
        }
        
        [DataMember]
        public decimal TotalPaid
        {
            get { return _totalPaid; }
            set
            {
                if (_totalPaid != value)
                {
                    _totalPaid = value;
                    PropertyHasChanged("TotalPaid");
                }
            }
        }

        [DataMember]
        public decimal TotalDue
        {
            get { return _totalDue; }
            set
            {
                if (_totalDue != value)
                {
                    _totalDue = value;
                    PropertyHasChanged("TotalDue");
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
        public int? SeqNo
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

        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("PurchaseScheduleID", "PurchaseScheduleID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("PropertyID", "PropertyID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("InstallmentTypeTerm", "InstallmentTypeTerm", 39));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("StatusTerm", "StatusTerm", 29));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("MOPTerm", "MOPTerm", 29));

        }

        #endregion

        [DataContract]
        public class PurchaseScheduleKeys
        {

            #region Data Members

            Guid _purchaseScheduleID;

            #endregion

            #region Constructor

            public PurchaseScheduleKeys(Guid purchaseScheduleID)
            {
                _purchaseScheduleID = purchaseScheduleID;
            }

            #endregion

            #region Properties

            [DataMember]
            public Guid PurchaseScheduleID
            {
                get { return _purchaseScheduleID; }
            }

            #endregion

        }

    }
}
