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
	public class ServiceVendorMaster: BusinessObjectBase
	{

        #region InnerClass
        public enum ServiceVendorMasterFields
        {
            VendorID,
            CompanyName,
            RegistrationNo,
            RegistrationDate,
            VATRegNo,
            VATRegistrationDate,
            ContactPersonName,
            ContactNo,
            Email,
            URL,
            BillingAddress,
            POSDetails,
            CityLedgerAcctID,
            CompanyID,
            PropertyID,
            CreatedOn,
            CreatedBy,
            UpdatedOn,
            UpdatedBy,
            UpdateLog,
            IsActive,
            SynchOn,
            SeqNo
        }
        #endregion

        #region Data Members

        Guid _vendorID;
        string _companyName;
        string _registrationNo;
        DateTime? _registrationDate;
        string _vATRegNo;
        DateTime? _vATRegistrationDate;
        string _contactPersonName;
        string _contactNo;
        string _email;
        string _uRL;
        string _billingAddress;
        string _pOSDetails;
        Guid? _cityLedgerAcctID;
        Guid? _companyID;
        Guid? _propertyID;
        DateTime? _createdOn;
        Guid? _createdBy;
        DateTime? _updatedOn;
        Guid? _updatedBy;
        byte[] _updateLog;
        bool? _isActive;
        DateTime? _synchOn;
        int _seqNo;

        #endregion

        #region Properties

        public Guid VendorID
        {
            get { return _vendorID; }
            set
            {
                if (_vendorID != value)
                {
                    _vendorID = value;
                    PropertyHasChanged("VendorID");
                }
            }
        }

        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                if (_companyName != value)
                {
                    _companyName = value;
                    PropertyHasChanged("CompanyName");
                }
            }
        }

        public string RegistrationNo
        {
            get { return _registrationNo; }
            set
            {
                if (_registrationNo != value)
                {
                    _registrationNo = value;
                    PropertyHasChanged("RegistrationNo");
                }
            }
        }

        public DateTime? RegistrationDate
        {
            get { return _registrationDate; }
            set
            {
                if (_registrationDate != value)
                {
                    _registrationDate = value;
                    PropertyHasChanged("RegistrationDate");
                }
            }
        }

        public string VATRegNo
        {
            get { return _vATRegNo; }
            set
            {
                if (_vATRegNo != value)
                {
                    _vATRegNo = value;
                    PropertyHasChanged("VATRegNo");
                }
            }
        }

        public DateTime? VATRegistrationDate
        {
            get { return _vATRegistrationDate; }
            set
            {
                if (_vATRegistrationDate != value)
                {
                    _vATRegistrationDate = value;
                    PropertyHasChanged("VATRegistrationDate");
                }
            }
        }

        public string ContactPersonName
        {
            get { return _contactPersonName; }
            set
            {
                if (_contactPersonName != value)
                {
                    _contactPersonName = value;
                    PropertyHasChanged("ContactPersonName");
                }
            }
        }

        public string ContactNo
        {
            get { return _contactNo; }
            set
            {
                if (_contactNo != value)
                {
                    _contactNo = value;
                    PropertyHasChanged("ContactNo");
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    PropertyHasChanged("Email");
                }
            }
        }

        public string URL
        {
            get { return _uRL; }
            set
            {
                if (_uRL != value)
                {
                    _uRL = value;
                    PropertyHasChanged("URL");
                }
            }
        }

        public string BillingAddress
        {
            get { return _billingAddress; }
            set
            {
                if (_billingAddress != value)
                {
                    _billingAddress = value;
                    PropertyHasChanged("BillingAddress");
                }
            }
        }

        public string POSDetails
        {
            get { return _pOSDetails; }
            set
            {
                if (_pOSDetails != value)
                {
                    _pOSDetails = value;
                    PropertyHasChanged("POSDetails");
                }
            }
        }

        public Guid? CityLedgerAcctID
        {
            get { return _cityLedgerAcctID; }
            set
            {
                if (_cityLedgerAcctID != value)
                {
                    _cityLedgerAcctID = value;
                    PropertyHasChanged("CityLedgerAcctID");
                }
            }
        }

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


        #endregion

        #region Validation

        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("VendorID", "VendorID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CompanyName", "CompanyName", 350));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("RegistrationNo", "RegistrationNo", 35));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("VATRegNo", "VATRegNo", 35));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ContactPersonName", "ContactPersonName", 350));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ContactNo", "ContactNo", 17));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Email", "Email", 350));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("URL", "URL", 350));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("BillingAddress", "BillingAddress", 450));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("POSDetails", "POSDetails", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
        }

        public override string ToString()
        {
            string objValue = string.Format(
            "VendorID = {0}~\n" +
            "CompanyName = {1}~\n" +
            "RegistrationNo = {2}~\n" +
            "RegistrationDate = {3}~\n" +
            "VATRegNo = {4}~\n" +
            "VATRegistrationDate = {5}~\n" +
            "ContactPersonName = {6}~\n" +
            "ContactNo = {7}~\n" +
            "Email = {8}~\n" +
            "URL = {9}~\n" +
            "BillingAddress = {10}~\n" +
            "POSDetails = {11}~\n" +
            "CityLedgerAcctID = {12}~\n" +
            "CompanyID = {13}~\n" +
            "PropertyID = {14}~\n" +
            "CreatedOn = {15}~\n" +
            "CreatedBy = {16}~\n" +
            "UpdatedOn = {17}~\n" +
            "UpdatedBy = {18}~\n" +
            "UpdateLog = {19}~\n" +
            "IsActive = {20}~\n" +
            "SynchOn = {21}~\n" +
            "SeqNo = {22}~\n",
            VendorID, CompanyName, RegistrationNo, RegistrationDate, VATRegNo, VATRegistrationDate, ContactPersonName, ContactNo, Email, URL, BillingAddress, POSDetails, CityLedgerAcctID, CompanyID, PropertyID, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, UpdateLog, IsActive, SynchOn, SeqNo); return objValue;
        }

        #endregion
	}
	[DataContract]
	public class ServiceVendorMasterKeys
	{

        #region Data Members

        Guid _vendorID;

        #endregion

        #region Constructor

        public ServiceVendorMasterKeys(Guid vendorID)
        {
            _vendorID = vendorID;
        }

        #endregion

        #region Properties

        public Guid VendorID
        {
            get { return _vendorID; }
        }

        #endregion

	}
}
