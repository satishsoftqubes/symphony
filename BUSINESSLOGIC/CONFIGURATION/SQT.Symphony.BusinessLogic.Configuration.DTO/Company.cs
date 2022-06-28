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
	public class Company: BusinessObjectBase
	{

		#region InnerClass
		public enum CompanyFields
		{
			CompanyID,
			SeqNo,
			CompanyName,
			DisplayName,
			CompanyCode,
			PrimaryContactName,
			PrimoryEmailAddress,
			PrimoryContactNo,
			OrganizationType,
			BusinessDomain,
			DateOfRegistration,
			ApplicableRegNo,
			TaxationIdentification,
			RegistrationCompany,
			YearbyTurnover,
			Updatelog,
			CompanyRegistrationDate,
			RegistrationStatus,
			HaveMultipleProperties,
			IsApproved,
			ApprovedOn,
			ApprovedBy,
			DateofExpiry,
			PaymentTerms,
			PackageID,
			CreditLimit,
			Thumb,
			IsActive,
			PrimaryAddID,
			PrimaryAdd1,
			PrimaryAdd2,
			PrimaryCity,
			PrimaryZipCode,
			PrimaryState,
			PrimaryCountry,
			PrimaryPhone,
			PrimaryEmail,
			PrimaryFax,
			PrimaryUrl,
			PhotoLocal,
			InCorporatonNo,
			PanNo,
			TanNo,
			TinNo,
			ServiceTaxNo,
			CompanyType
		}
		#endregion

		#region Data Members

			Guid _companyID;
			int? _seqNo;
			string _companyName;
			string _displayName;
			string _companyCode;
			string _primaryContactName;
			string _primoryEmailAddress;
			string _primoryContactNo;
			string _organizationType;
			string _businessDomain;
			DateTime? _dateOfRegistration;
			string _applicableRegNo;
			string _taxationIdentification;
			string _registrationCompany;
			decimal? _yearbyTurnover;
			byte[] _updatelog;
			DateTime? _companyRegistrationDate;
			string _registrationStatus;
			bool? _haveMultipleProperties;
			bool? _isApproved;
			DateTime? _approvedOn;
			Guid? _approvedBy;
			DateTime? _dateofExpiry;
			string _paymentTerms;
			Guid? _packageID;
			decimal? _creditLimit;
			string _thumb;
			bool? _isActive;
			Guid? _primaryAddID;
			string _primaryAdd1;
			string _primaryAdd2;
			string _primaryCity;
			string _primaryZipCode;
			string _primaryState;
			string _primaryCountry;
			string _primaryPhone;
			string _primaryEmail;
			string _primaryFax;
			string _primaryUrl;
			byte[] _photoLocal;
			string _inCorporatonNo;
			string _panNo;
			string _tanNo;
			string _tinNo;
			string _serviceTaxNo;
			Guid? _companyType;

		#endregion

		#region Properties

		[DataMember]
		public Guid  CompanyID
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
		public int?  SeqNo
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
		public string  CompanyName
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

		[DataMember]
		public string  DisplayName
		{
			 get { return _displayName; }
			 set
			 {
				 if (_displayName != value)
				 {
					_displayName = value;
					 PropertyHasChanged("DisplayName");
				 }
			 }
		}

		[DataMember]
		public string  CompanyCode
		{
			 get { return _companyCode; }
			 set
			 {
				 if (_companyCode != value)
				 {
					_companyCode = value;
					 PropertyHasChanged("CompanyCode");
				 }
			 }
		}

		[DataMember]
		public string  PrimaryContactName
		{
			 get { return _primaryContactName; }
			 set
			 {
				 if (_primaryContactName != value)
				 {
					_primaryContactName = value;
					 PropertyHasChanged("PrimaryContactName");
				 }
			 }
		}

		[DataMember]
		public string  PrimoryEmailAddress
		{
			 get { return _primoryEmailAddress; }
			 set
			 {
				 if (_primoryEmailAddress != value)
				 {
					_primoryEmailAddress = value;
					 PropertyHasChanged("PrimoryEmailAddress");
				 }
			 }
		}

		[DataMember]
		public string  PrimoryContactNo
		{
			 get { return _primoryContactNo; }
			 set
			 {
				 if (_primoryContactNo != value)
				 {
					_primoryContactNo = value;
					 PropertyHasChanged("PrimoryContactNo");
				 }
			 }
		}

		[DataMember]
		public string  OrganizationType
		{
			 get { return _organizationType; }
			 set
			 {
				 if (_organizationType != value)
				 {
					_organizationType = value;
					 PropertyHasChanged("OrganizationType");
				 }
			 }
		}

		[DataMember]
		public string  BusinessDomain
		{
			 get { return _businessDomain; }
			 set
			 {
				 if (_businessDomain != value)
				 {
					_businessDomain = value;
					 PropertyHasChanged("BusinessDomain");
				 }
			 }
		}

		[DataMember]
		public DateTime?  DateOfRegistration
		{
			 get { return _dateOfRegistration; }
			 set
			 {
				 if (_dateOfRegistration != value)
				 {
					_dateOfRegistration = value;
					 PropertyHasChanged("DateOfRegistration");
				 }
			 }
		}

		[DataMember]
		public string  ApplicableRegNo
		{
			 get { return _applicableRegNo; }
			 set
			 {
				 if (_applicableRegNo != value)
				 {
					_applicableRegNo = value;
					 PropertyHasChanged("ApplicableRegNo");
				 }
			 }
		}

		[DataMember]
		public string  TaxationIdentification
		{
			 get { return _taxationIdentification; }
			 set
			 {
				 if (_taxationIdentification != value)
				 {
					_taxationIdentification = value;
					 PropertyHasChanged("TaxationIdentification");
				 }
			 }
		}

		[DataMember]
		public string  RegistrationCompany
		{
			 get { return _registrationCompany; }
			 set
			 {
				 if (_registrationCompany != value)
				 {
					_registrationCompany = value;
					 PropertyHasChanged("RegistrationCompany");
				 }
			 }
		}

		[DataMember]
		public decimal?  YearbyTurnover
		{
			 get { return _yearbyTurnover; }
			 set
			 {
				 if (_yearbyTurnover != value)
				 {
					_yearbyTurnover = value;
					 PropertyHasChanged("YearbyTurnover");
				 }
			 }
		}

		[DataMember]
		public byte[]  Updatelog
		{
			 get { return _updatelog; }
			 set
			 {
				 if (_updatelog != value)
				 {
					_updatelog = value;
					 PropertyHasChanged("Updatelog");
				 }
			 }
		}

		[DataMember]
		public DateTime?  CompanyRegistrationDate
		{
			 get { return _companyRegistrationDate; }
			 set
			 {
				 if (_companyRegistrationDate != value)
				 {
					_companyRegistrationDate = value;
					 PropertyHasChanged("CompanyRegistrationDate");
				 }
			 }
		}

		[DataMember]
		public string  RegistrationStatus
		{
			 get { return _registrationStatus; }
			 set
			 {
				 if (_registrationStatus != value)
				 {
					_registrationStatus = value;
					 PropertyHasChanged("RegistrationStatus");
				 }
			 }
		}

		[DataMember]
		public bool?  HaveMultipleProperties
		{
			 get { return _haveMultipleProperties; }
			 set
			 {
				 if (_haveMultipleProperties != value)
				 {
					_haveMultipleProperties = value;
					 PropertyHasChanged("HaveMultipleProperties");
				 }
			 }
		}

		[DataMember]
		public bool?  IsApproved
		{
			 get { return _isApproved; }
			 set
			 {
				 if (_isApproved != value)
				 {
					_isApproved = value;
					 PropertyHasChanged("IsApproved");
				 }
			 }
		}

		[DataMember]
		public DateTime?  ApprovedOn
		{
			 get { return _approvedOn; }
			 set
			 {
				 if (_approvedOn != value)
				 {
					_approvedOn = value;
					 PropertyHasChanged("ApprovedOn");
				 }
			 }
		}

		[DataMember]
		public Guid?  ApprovedBy
		{
			 get { return _approvedBy; }
			 set
			 {
				 if (_approvedBy != value)
				 {
					_approvedBy = value;
					 PropertyHasChanged("ApprovedBy");
				 }
			 }
		}

		[DataMember]
		public DateTime?  DateofExpiry
		{
			 get { return _dateofExpiry; }
			 set
			 {
				 if (_dateofExpiry != value)
				 {
					_dateofExpiry = value;
					 PropertyHasChanged("DateofExpiry");
				 }
			 }
		}

		[DataMember]
		public string  PaymentTerms
		{
			 get { return _paymentTerms; }
			 set
			 {
				 if (_paymentTerms != value)
				 {
					_paymentTerms = value;
					 PropertyHasChanged("PaymentTerms");
				 }
			 }
		}

		[DataMember]
		public Guid?  PackageID
		{
			 get { return _packageID; }
			 set
			 {
				 if (_packageID != value)
				 {
					_packageID = value;
					 PropertyHasChanged("PackageID");
				 }
			 }
		}

		[DataMember]
		public decimal?  CreditLimit
		{
			 get { return _creditLimit; }
			 set
			 {
				 if (_creditLimit != value)
				 {
					_creditLimit = value;
					 PropertyHasChanged("CreditLimit");
				 }
			 }
		}

		[DataMember]
		public string  Thumb
		{
			 get { return _thumb; }
			 set
			 {
				 if (_thumb != value)
				 {
					_thumb = value;
					 PropertyHasChanged("Thumb");
				 }
			 }
		}

		[DataMember]
		public bool?  IsActive
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
		public Guid?  PrimaryAddID
		{
			 get { return _primaryAddID; }
			 set
			 {
				 if (_primaryAddID != value)
				 {
					_primaryAddID = value;
					 PropertyHasChanged("PrimaryAddID");
				 }
			 }
		}

		[DataMember]
		public string  PrimaryAdd1
		{
			 get { return _primaryAdd1; }
			 set
			 {
				 if (_primaryAdd1 != value)
				 {
					_primaryAdd1 = value;
					 PropertyHasChanged("PrimaryAdd1");
				 }
			 }
		}

		[DataMember]
		public string  PrimaryAdd2
		{
			 get { return _primaryAdd2; }
			 set
			 {
				 if (_primaryAdd2 != value)
				 {
					_primaryAdd2 = value;
					 PropertyHasChanged("PrimaryAdd2");
				 }
			 }
		}

		[DataMember]
		public string  PrimaryCity
		{
			 get { return _primaryCity; }
			 set
			 {
				 if (_primaryCity != value)
				 {
					_primaryCity = value;
					 PropertyHasChanged("PrimaryCity");
				 }
			 }
		}

		[DataMember]
		public string  PrimaryZipCode
		{
			 get { return _primaryZipCode; }
			 set
			 {
				 if (_primaryZipCode != value)
				 {
					_primaryZipCode = value;
					 PropertyHasChanged("PrimaryZipCode");
				 }
			 }
		}

		[DataMember]
		public string  PrimaryState
		{
			 get { return _primaryState; }
			 set
			 {
				 if (_primaryState != value)
				 {
					_primaryState = value;
					 PropertyHasChanged("PrimaryState");
				 }
			 }
		}

		[DataMember]
		public string  PrimaryCountry
		{
			 get { return _primaryCountry; }
			 set
			 {
				 if (_primaryCountry != value)
				 {
					_primaryCountry = value;
					 PropertyHasChanged("PrimaryCountry");
				 }
			 }
		}

		[DataMember]
		public string  PrimaryPhone
		{
			 get { return _primaryPhone; }
			 set
			 {
				 if (_primaryPhone != value)
				 {
					_primaryPhone = value;
					 PropertyHasChanged("PrimaryPhone");
				 }
			 }
		}

		[DataMember]
		public string  PrimaryEmail
		{
			 get { return _primaryEmail; }
			 set
			 {
				 if (_primaryEmail != value)
				 {
					_primaryEmail = value;
					 PropertyHasChanged("PrimaryEmail");
				 }
			 }
		}

		[DataMember]
		public string  PrimaryFax
		{
			 get { return _primaryFax; }
			 set
			 {
				 if (_primaryFax != value)
				 {
					_primaryFax = value;
					 PropertyHasChanged("PrimaryFax");
				 }
			 }
		}

		[DataMember]
		public string  PrimaryUrl
		{
			 get { return _primaryUrl; }
			 set
			 {
				 if (_primaryUrl != value)
				 {
					_primaryUrl = value;
					 PropertyHasChanged("PrimaryUrl");
				 }
			 }
		}

		[DataMember]
		public byte[]  PhotoLocal
		{
			 get { return _photoLocal; }
			 set
			 {
				 if (_photoLocal != value)
				 {
					_photoLocal = value;
					 PropertyHasChanged("PhotoLocal");
				 }
			 }
		}

		[DataMember]
		public string  InCorporatonNo
		{
			 get { return _inCorporatonNo; }
			 set
			 {
				 if (_inCorporatonNo != value)
				 {
					_inCorporatonNo = value;
					 PropertyHasChanged("InCorporatonNo");
				 }
			 }
		}

		[DataMember]
		public string  PanNo
		{
			 get { return _panNo; }
			 set
			 {
				 if (_panNo != value)
				 {
					_panNo = value;
					 PropertyHasChanged("PanNo");
				 }
			 }
		}

		[DataMember]
		public string  TanNo
		{
			 get { return _tanNo; }
			 set
			 {
				 if (_tanNo != value)
				 {
					_tanNo = value;
					 PropertyHasChanged("TanNo");
				 }
			 }
		}

		[DataMember]
		public string  TinNo
		{
			 get { return _tinNo; }
			 set
			 {
				 if (_tinNo != value)
				 {
					_tinNo = value;
					 PropertyHasChanged("TinNo");
				 }
			 }
		}

		[DataMember]
		public string  ServiceTaxNo
		{
			 get { return _serviceTaxNo; }
			 set
			 {
				 if (_serviceTaxNo != value)
				 {
					_serviceTaxNo = value;
					 PropertyHasChanged("ServiceTaxNo");
				 }
			 }
		}

		[DataMember]
		public Guid?  CompanyType
		{
			 get { return _companyType; }
			 set
			 {
				 if (_companyType != value)
				 {
					_companyType = value;
					 PropertyHasChanged("CompanyType");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("CompanyID", "CompanyID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CompanyName", "CompanyName",320));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("DisplayName", "DisplayName",120));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CompanyCode", "CompanyCode",50));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimaryContactName", "PrimaryContactName",180));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimoryEmailAddress", "PrimoryEmailAddress",180));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimoryContactNo", "PrimoryContactNo",17));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("OrganizationType", "OrganizationType",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("BusinessDomain", "BusinessDomain",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ApplicableRegNo", "ApplicableRegNo",60));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("TaxationIdentification", "TaxationIdentification",60));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("RegistrationCompany", "RegistrationCompany",90));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("RegistrationStatus", "RegistrationStatus",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PaymentTerms", "PaymentTerms",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Thumb", "Thumb",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimaryAdd1", "PrimaryAdd1",280));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimaryAdd2", "PrimaryAdd2",340));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimaryCity", "PrimaryCity",135));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimaryZipCode", "PrimaryZipCode",13));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimaryState", "PrimaryState",135));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimaryCountry", "PrimaryCountry",135));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimaryPhone", "PrimaryPhone",17));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimaryEmail", "PrimaryEmail",180));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimaryFax", "PrimaryFax",17));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimaryUrl", "PrimaryUrl",180));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("InCorporatonNo", "InCorporatonNo",50));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PanNo", "PanNo",50));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("TanNo", "TanNo",50));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("TinNo", "TinNo",50));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ServiceTaxNo", "ServiceTaxNo",50));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"CompanyID = {0}~\n"+
			"SeqNo = {1}~\n"+
			"CompanyName = {2}~\n"+
			"DisplayName = {3}~\n"+
			"CompanyCode = {4}~\n"+
			"PrimaryContactName = {5}~\n"+
			"PrimoryEmailAddress = {6}~\n"+
			"PrimoryContactNo = {7}~\n"+
			"OrganizationType = {8}~\n"+
			"BusinessDomain = {9}~\n"+
			"DateOfRegistration = {10}~\n"+
			"ApplicableRegNo = {11}~\n"+
			"TaxationIdentification = {12}~\n"+
			"RegistrationCompany = {13}~\n"+
			"YearbyTurnover = {14}~\n"+
			"Updatelog = {15}~\n"+
			"CompanyRegistrationDate = {16}~\n"+
			"RegistrationStatus = {17}~\n"+
			"HaveMultipleProperties = {18}~\n"+
			"IsApproved = {19}~\n"+
			"ApprovedOn = {20}~\n"+
			"ApprovedBy = {21}~\n"+
			"DateofExpiry = {22}~\n"+
			"PaymentTerms = {23}~\n"+
			"PackageID = {24}~\n"+
			"CreditLimit = {25}~\n"+
			"Thumb = {26}~\n"+
			"IsActive = {27}~\n"+
			"PrimaryAddID = {28}~\n"+
			"PrimaryAdd1 = {29}~\n"+
			"PrimaryAdd2 = {30}~\n"+
			"PrimaryCity = {31}~\n"+
			"PrimaryZipCode = {32}~\n"+
			"PrimaryState = {33}~\n"+
			"PrimaryCountry = {34}~\n"+
			"PrimaryPhone = {35}~\n"+
			"PrimaryEmail = {36}~\n"+
			"PrimaryFax = {37}~\n"+
			"PrimaryUrl = {38}~\n"+
			"PhotoLocal = {39}~\n"+
			"InCorporatonNo = {40}~\n"+
			"PanNo = {41}~\n"+
			"TanNo = {42}~\n"+
			"TinNo = {43}~\n"+
			"ServiceTaxNo = {44}~\n"+
			"CompanyType = {45}~\n",
			CompanyID,			SeqNo,			CompanyName,			DisplayName,			CompanyCode,			PrimaryContactName,			PrimoryEmailAddress,			PrimoryContactNo,			OrganizationType,			BusinessDomain,			DateOfRegistration,			ApplicableRegNo,			TaxationIdentification,			RegistrationCompany,			YearbyTurnover,			Updatelog,			CompanyRegistrationDate,			RegistrationStatus,			HaveMultipleProperties,			IsApproved,			ApprovedOn,			ApprovedBy,			DateofExpiry,			PaymentTerms,			PackageID,			CreditLimit,			Thumb,			IsActive,			PrimaryAddID,			PrimaryAdd1,			PrimaryAdd2,			PrimaryCity,			PrimaryZipCode,			PrimaryState,			PrimaryCountry,			PrimaryPhone,			PrimaryEmail,			PrimaryFax,			PrimaryUrl,			PhotoLocal,			InCorporatonNo,			PanNo,			TanNo,			TinNo,			ServiceTaxNo,			CompanyType);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class CompanyKeys
	{

		#region Data Members

		Guid _companyID;

		#endregion

		#region Constructor

		public CompanyKeys(Guid companyID)
		{
			 _companyID = companyID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  CompanyID
		{
			 get { return _companyID; }
		}

		#endregion

	}
}
