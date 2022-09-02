using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using SQT.FRAMEWORK.DAL.Linq;

namespace SQT.Symphony.BusinessLogic.Configuration.DTO
{
    [DataContract]
    public class PropertyPartner : BusinessObjectBase
    {
        #region InnerClass

        public enum PropertyPartnerField
        {
            PropertyPartnerID,
            PropertyID,
            PartnerID,
            AddedOn,
            PartnershipInPercentage,
            TotalToInvest,
            TotalDue,
            TotalInvested,
            PartnershipDissolveOn,
            StatusTerm,
            SeqNo,
            IsActive,
            PartnerLegalName,
            Description
        }

        #endregion

        #region Data Members

        Guid _propertyPartnerID;
        Guid? _propertyID;
        Guid? _partnerID;
        DateTime? _addedOn;
        decimal? _partnershipInPercentage;
        decimal? _totalToInvest;
        decimal? _totalDue;
        decimal? _totalInvested;
        DateTime? _partnershipDissolveOn;
        string _statusTerm;
        int? _seqNo;
        bool? _isActive;
        string _partnerLegalName;
        string _description;

        #endregion

        #region Properties

        [DataMember]
        public Guid PropertyPartnerID
        {
            get { return _propertyPartnerID; }
            set
            {
                if (_propertyPartnerID != value)
                {
                    _propertyPartnerID = value;
                    PropertyHasChanged("PropertyPartnerID");
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
        public DateTime? AddedOn
        {
            get { return _addedOn; }
            set
            {
                if (_addedOn != value)
                {
                    _addedOn = value;
                    PropertyHasChanged("AddedOn");
                }
            }
        }

        [DataMember]
        public decimal? PartnershipInPercentage
        {
            get { return _partnershipInPercentage; }
            set
            {
                if (_partnershipInPercentage != value)
                {
                    _partnershipInPercentage = value;
                    PropertyHasChanged("PartnershipInPercentage");
                }
            }
        }

        [DataMember]
        public decimal? TotalToInvest
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
        public decimal? TotalDue
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
        public decimal? TotalInvested
        {
            get { return _totalInvested; }
            set
            {
                if (_totalInvested != value)
                {
                    _totalInvested = value;
                    PropertyHasChanged("TotalInvested");
                }
            }
        }

        [DataMember]
        public DateTime? PartnershipDissolveOn
        {
            get { return _partnershipDissolveOn; }
            set
            {
                if (_partnershipDissolveOn != value)
                {
                    _partnershipDissolveOn = value;
                    PropertyHasChanged("PartnershipDissolveOn");
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
        public string PartnerLegalName
        {
            get { return _partnerLegalName; }
            set
            {
                if (_partnerLegalName != value)
                {
                    _partnerLegalName = value;
                    PropertyHasChanged("PartnerLegalName");
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

        #endregion

    }

    [DataContract]
    public class PropertyPartnerKeys
    {

        #region Data Members

        Guid _propertyPartnerID;

        #endregion

        #region Constructor

        public PropertyPartnerKeys(Guid propertyPartnerID)
        {
            _propertyPartnerID = propertyPartnerID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid PropertyPartnerID
        {
            get { return _propertyPartnerID; }
        }

        #endregion

    }
}
