using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using SQT.FRAMEWORK.DAL.Linq;

namespace SQT.Symphony.BusinessLogic.Configuration.DTO
{
    public class PurchasePartnerSchedule : BusinessObjectBase
    {
        public enum PurchaseScheduleFields
        {
            PurchasePartnerScheduleID,
            PropertyID,
            PartnerID,
            InstallmentTypeTerm,
            InstallmentAmount,
            InstallmentInPercentage,
            StatusTerm,
            MOPTerm,
            ActualPaymentDate,
            TotalToInvest,
            TotalPaid,
            TotalDue,
            IsActive,
            SeqNo
        }

        #region DataMember

        Guid _purchasePartnerScheduleID;
        Guid? _propertyID;
        Guid? _partnerID;
        string _installmentTypeTerm;
        decimal? _installmentAmount;
        decimal? _installmentInPercentage;
        string _statusTerm;
        string _mopTerm;
        DateTime? _actualPaymentDate;
        decimal _totalToInvest;
        decimal _totalPaid;
        decimal _totalDue;
        bool? _isActive;
        int? _seqNo;
        byte[] _updateLog;

        #endregion

        #region Properties

        [DataMember]
        public Guid PurchasePartnerScheduleID
        {
            get { return _purchasePartnerScheduleID; }
            set
            {
                if (_purchasePartnerScheduleID != value)
                {
                    _purchasePartnerScheduleID = value;
                    PropertyHasChanged("PurchasePartnerScheduleID");
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
        public Guid? PartnerID
        {
            get { return _partnerID; }
            set
            {
                if (_partnerID != value)
                {
                    _partnerID = value;
                    PropertyHasChanged("PartnerID");
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
        public decimal TotalToInvest
        {
            get { return _totalToInvest; }
            set
            {
                if (_totalToInvest != value)
                {
                    _totalToInvest = value;
                    PropertyHasChanged("TotalToInvest");
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

        [DataContract]
        public class PurchasePartnerScheduleKeys
        {

            #region Data Members

            Guid _purchasePartnerScheduleID;

            #endregion

            #region Constructor

            public PurchasePartnerScheduleKeys(Guid purchasePartnerScheduleID)
            {
                _purchasePartnerScheduleID = purchasePartnerScheduleID;
            }

            #endregion

            #region Properties

            [DataMember]
            public Guid PurchasePartnerScheduleID
            {
                get { return _purchasePartnerScheduleID; }
            }

            #endregion

        }
    }
}
