using SQT.FRAMEWORK.DAL.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SQT.Symphony.BusinessLogic.Configuration.DTO
{
    [DataContract]
    public class SalerPartner : BusinessObjectBase
    {  

        #region InnerClass
        public enum SalerPartnerFields
        {
            PartnerID,
            FirstName,
            MiddleName,
            LastName,
            DisplayName,
            MobileNo,
            Email,
            Address,
            PhotoImage,
            CreatedOn,
            CretaedBy,
            UpdatedOn,
            UpdatedBy,
            TotalProperties,
            TotalInvestment,
            IsActive,
            UpdateLog,
            SeqNo
        }
        #endregion

        #region Data Members

        Guid _PartnerID;
        int? _SeqNo;
        DateTime? _UpdateLog;
        string _FirstName;
        string _LastName;
        string _MiddleName;
        string _DisplayName;
        string _MobileNo;
        string _Email;
        string _Address;
        string _PhotoImage;
        DateTime? _CreatedOn;
        Guid _CreatedBy;
        Guid _UpdatedBy;
        DateTime? _UpdatedOn;
        int? _TotalProperties;
        Decimal? _TotalInvestment;
        #endregion

        #region Properties

        [DataMember]
        public Guid PartnerID
        {
            get { return _PartnerID; }
            set
            {
                if (_PartnerID != value)
                {
                    _PartnerID = value;
                    PropertyHasChanged("PartnerID");
                }
            }
        }
        
        [DataMember]
        public int? SeqNo
        {
            get { return _SeqNo; }
            set
            {
                if (_SeqNo != value)
                {
                    _SeqNo = value;
                    PropertyHasChanged("SeqNo");
                }
            }
        }
        [DataMember]
        public DateTime? UpdateLog
        {
            get { return _UpdateLog; }
            set
            {
                if (_UpdateLog != value)
                {
                    _UpdateLog  = value;
                    PropertyHasChanged("UpdateLog");
                }
            }
        }
        [DataMember]
        public Decimal? TotalInvestment
        {
            get { return _TotalInvestment; }
            set
            {
                if (_TotalInvestment != value)
                {
                    _TotalInvestment = value;
                    PropertyHasChanged("TotalInvestment");
                }
            }
        }
        [DataMember]
        public int? TotalProperties
        {
            get { return _TotalProperties; }
            set {
                if (_TotalProperties != value)
                {
                    _TotalProperties = value;
                    PropertyHasChanged("TotalProperties");
                }
            }
        }
        [DataMember]
        public DateTime? UpdatedOn
        {
            get { return _UpdatedOn; }
            set
            {
                if (_UpdatedOn != value)
                {
                    _UpdatedOn = value;
                    PropertyHasChanged("UpdatedOn");
                }
            }
        }
        [DataMember]
        public Guid UpdatedBy
        {
            get { return _UpdatedBy; }
            set
            {
                if (_UpdatedBy != value)
                {
                    _UpdatedBy = value;
                    PropertyHasChanged("UpdatedBy");
                }
            }
        }
        [DataMember]
        public Guid CreatedBy
        {
            get { return _CreatedBy; }
            set
            {
                if (_CreatedBy != value)
                {
                    _CreatedBy = value;
                    PropertyHasChanged("CreatedBy");
                }
            }
        }
        [DataMember]
        public DateTime? CreatedOn
        {
            get { return _CreatedOn; }
            set
            {
                if (_CreatedOn != value)
                {
                    _CreatedOn = value;
                    PropertyHasChanged("CreatedOn");
                }
            }
        }
        [DataMember]
        public string PhotoImage
        {
            get { return _PhotoImage; }
            set
            {
                if (_PhotoImage != value)
                {
                    _PhotoImage = value;
                    PropertyHasChanged("PhotoImage");
                }
            }
        }
        [DataMember]
        public string Address
        {
            get { return _Address; }
            set
            {
                if (_Address != value)
                {
                    _Address = value;
                    PropertyHasChanged("Address");
                }
            }
        }
        [DataMember]
        public string Email
        {
            get { return _Email; }
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    PropertyHasChanged("Email");
                }
            }
        }
        [DataMember]
        public string MobileNo
        {
            get { return _MobileNo; }
            set
            {
                if (_MobileNo != value)
                {
                    _MobileNo = value;
                    PropertyHasChanged("MobileNo");
                }
            }
        }
        [DataMember]
        public string DisplayName
        {
            get { return _DisplayName; }
            set
            {
                if (_DisplayName != value)
                {
                    _DisplayName = value;
                    PropertyHasChanged("DisplayName");
                }
            }
        }
        [DataMember]
        public string MiddleName
        {
            get { return _MiddleName; }
            set
            {
                if (_MiddleName != value)
                {
                    _MiddleName = value;
                    PropertyHasChanged("MiddleName");
                }
            }
        }
        [DataMember]
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    PropertyHasChanged("LastName");
                }
            }
        }
        [DataMember]
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    PropertyHasChanged("FirstName");
                }
            }
        }
        #endregion
    }
}
