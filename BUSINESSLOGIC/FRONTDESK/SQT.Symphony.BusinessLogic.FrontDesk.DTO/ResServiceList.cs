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
    public class ResServiceList : BusinessObjectBase
    {

        #region InnerClass
        public enum ResServiceListFields
        {
            ResServiceID,
            ReservationID,
            ItemID,
            FolioID,
            RateID,
            ResBlockDateRateID,
            ServiceStatus_TermID,
            StatusRemark,
            Amount,
            Qty,
            Total,
            ServiceDate,
            PostingDate,
            BookID,
            Notes,
            ReRouteFolioID,
            ReRouteCharge,
            PropertyID,
            CompanyID,
            SeqNo,
            IsSynch,
            SynchOn,
            UpdatedOn,
            UpdatedBy,
            IsActive,
            ServiceStatus_Term
        }
        #endregion

        #region Data Members

        Guid _resServiceID;
        Guid? _reservationID;
        Guid? _itemID;
        Guid? _folioID;
        Guid? _rateID;
        Guid? _resBlockDateRateID;
        Guid? _serviceStatus_TermID;
        string _statusRemark;
        decimal? _amount;
        decimal? _qty;
        decimal? _total;
        DateTime? _serviceDate;
        DateTime? _postingDate;
        Guid? _bookID;
        string _notes;
        Guid? _reRouteFolioID;
        decimal? _reRouteCharge;
        Guid? _propertyID;
        Guid? _companyID;
        long _seqNo;
        bool? _isSynch;
        DateTime? _synchOn;
        DateTime? _updatedOn;
        Guid? _updatedBy;
        bool? _isActive;
        string _serviceStatus_Term;

        #endregion

        #region Properties

        [DataMember]
        public Guid ResServiceID
        {
            get { return _resServiceID; }
            set
            {
                if (_resServiceID != value)
                {
                    _resServiceID = value;
                    PropertyHasChanged("ResServiceID");
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
        public Guid? RateID
        {
            get { return _rateID; }
            set
            {
                if (_rateID != value)
                {
                    _rateID = value;
                    PropertyHasChanged("RateID");
                }
            }
        }

        [DataMember]
        public Guid? ResBlockDateRateID
        {
            get { return _resBlockDateRateID; }
            set
            {
                if (_resBlockDateRateID != value)
                {
                    _resBlockDateRateID = value;
                    PropertyHasChanged("ResBlockDateRateID");
                }
            }
        }

        [DataMember]
        public Guid? ServiceStatus_TermID
        {
            get { return _serviceStatus_TermID; }
            set
            {
                if (_serviceStatus_TermID != value)
                {
                    _serviceStatus_TermID = value;
                    PropertyHasChanged("ServiceStatus_TermID");
                }
            }
        }

        [DataMember]
        public string StatusRemark
        {
            get { return _statusRemark; }
            set
            {
                if (_statusRemark != value)
                {
                    _statusRemark = value;
                    PropertyHasChanged("StatusRemark");
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
        public decimal? Qty
        {
            get { return _qty; }
            set
            {
                if (_qty != value)
                {
                    _qty = value;
                    PropertyHasChanged("Qty");
                }
            }
        }

        [DataMember]
        public decimal? Total
        {
            get { return _total; }
            set
            {
                if (_total != value)
                {
                    _total = value;
                    PropertyHasChanged("Total");
                }
            }
        }

        [DataMember]
        public DateTime? ServiceDate
        {
            get { return _serviceDate; }
            set
            {
                if (_serviceDate != value)
                {
                    _serviceDate = value;
                    PropertyHasChanged("ServiceDate");
                }
            }
        }

        [DataMember]
        public DateTime? PostingDate
        {
            get { return _postingDate; }
            set
            {
                if (_postingDate != value)
                {
                    _postingDate = value;
                    PropertyHasChanged("PostingDate");
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
        public string Notes
        {
            get { return _notes; }
            set
            {
                if (_notes != value)
                {
                    _notes = value;
                    PropertyHasChanged("Notes");
                }
            }
        }

        [DataMember]
        public Guid? ReRouteFolioID
        {
            get { return _reRouteFolioID; }
            set
            {
                if (_reRouteFolioID != value)
                {
                    _reRouteFolioID = value;
                    PropertyHasChanged("ReRouteFolioID");
                }
            }
        }

        [DataMember]
        public decimal? ReRouteCharge
        {
            get { return _reRouteCharge; }
            set
            {
                if (_reRouteCharge != value)
                {
                    _reRouteCharge = value;
                    PropertyHasChanged("ReRouteCharge");
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
        public string ServiceStatus_Term
        {
            get { return _serviceStatus_Term; }
            set
            {
                if (_serviceStatus_Term != value)
                {
                    _serviceStatus_Term = value;
                    PropertyHasChanged("ServiceStatus_Term");
                }
            }
        }


        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ResServiceID", "ResServiceID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("StatusRemark", "StatusRemark", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Notes", "Notes", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "ResServiceID = {0}\n" +
            "ReservationID = {1}\n" +
            "ItemID = {2}\n" +
            "FolioID = {3}\n" +
            "RateID = {4}\n" +
            "ResBlockDateRateID = {5}\n" +
            "ServiceStatus_TermID = {6}\n" +
            "StatusRemark = {7}\n" +
            "Amount = {8}\n" +
            "Qty = {9}\n" +
            "Total = {10}\n" +
            "ServiceDate = {11}\n" +
            "PostingDate = {12}\n" +
            "BookID = {13}\n" +
            "Notes = {14}\n" +
            "ReRouteFolioID = {15}\n" +
            "ReRouteCharge = {16}\n" +
            "PropertyID = {17}\n" +
            "CompanyID = {18}\n" +
            "SeqNo = {19}\n" +
            "IsSynch = {20}\n" +
            "SynchOn = {21}\n" +
            "UpdatedOn = {22}\n" +
            "UpdatedBy = {23}\n" +
            "IsActive = {24}\n"+
            "ServiceStatus_Term={25}\n",
            ResServiceID, ReservationID, ItemID, FolioID, RateID, ResBlockDateRateID, ServiceStatus_TermID, StatusRemark, Amount, Qty, Total, ServiceDate, PostingDate, BookID, Notes, ReRouteFolioID, ReRouteCharge, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, ServiceStatus_Term); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class ResServiceListKeys
    {

        #region Data Members

        Guid _resServiceID;

        #endregion

        #region Constructor

        public ResServiceListKeys(Guid resServiceID)
        {
            _resServiceID = resServiceID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid ResServiceID
        {
            get { return _resServiceID; }
        }

        #endregion

    }
}
