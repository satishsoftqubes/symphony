using SQT.FRAMEWORK.DAL.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SQT.Symphony.BusinessLogic.Configuration.DTO
{
    [DataContract]
    public class Vendor : BusinessObjectBase
    {
        #region InnerClass
        public enum VendorDetailes
        {

            VendorID,
            CompanyID,
            ContactName,
            VendorName,
            Email,
            MobileNo,
            AddressID,
            VendorDetail,
            VendorType_Term,
            CreatedOn,
            CreatedBy,
            UpdatedBy,
            UpdatedOn,
            BusinessDomain_Term,
            Status_Term,
            LastBusinessDate,
            TotalBusiness,
            PayableAcctID
        }
        #endregion

        #region Data Members
        Guid _VendorID;
        Guid _CompanyID;
        string _ContactName;
        string _VendorName;
        string _Emaill;
        string _MobileNo;
        int? _AddressID;
        string _VendorDetail;
        string _VendorType_Term;
        DateTime? _CreatedOn;
        DateTime? _UpdatedOn;
        Guid _CreatedBy;
        Guid _UpdatedBy;
        #endregion

        #region Property
        [DataMember]
        public Guid VendorID
        {
            get { return _VendorID; }
            set
            {
                if (_VendorID != value)
                {
                    _VendorID = value;
                    PropertyHasChanged("VendorID");
                }
            }
        }
        [DataMember]
        public Guid CompanyID
        {
            get { return _CompanyID; }
            set
            {
                if (_CompanyID != value)
                {
                    _CompanyID = value;
                    PropertyHasChanged("CompanyID");
                }
            }
        }
        [DataMember]
        public string VendorName
        {
            get { return _VendorName; }
            set
            {
                if (_VendorName != value)
                {
                    _VendorName = value;
                    PropertyHasChanged("VendorName");
                }
            }
        }
        [DataMember]
        public string ContactName
        {
            get { return _ContactName; }
            set
            {
                if (_ContactName != value)
                {
                    _ContactName = value;
                    PropertyHasChanged("ContactName");
                }
            }
        }
        [DataMember]
        public string Emaill
        {
            get { return _Emaill; }
            set
            {
                if (_Emaill != value)
                {
                    _Emaill = value;
                    PropertyHasChanged("Emaill");
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
        public int? AddressID
        {
            get { return _AddressID; }
            set
            {
                if (_AddressID != value)
                {
                    _AddressID = value;
                    PropertyHasChanged("AddressID");
                }
            }
        }
        [DataMember]
        public string VendorDetail
        {
            get { return _VendorDetail; }
            set
            {
                if (_VendorDetail != value)
                {
                    _VendorDetail = value;
                    PropertyHasChanged("VendorDetail");
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
        #endregion
    }
}
