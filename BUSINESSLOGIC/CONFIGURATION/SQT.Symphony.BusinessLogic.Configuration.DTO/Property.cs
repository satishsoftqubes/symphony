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
	public class Property: BusinessObjectBase
	{

		#region InnerClass
		public enum PropertyFields
		{
			PropertyID,
			CompanyID,
			SeqNo,
			PropertyTypeID,
			PropertyCode,
			PropertyName,
			AddressID,
			PropManagerName,
			PrimaryContactNo,
			PrimaryEmail,
			PrimaryFax,
			PropertyDisplayName,
			PropertyRegisteredOn,
			PropertyRegisteredBy,
			PropertyCreatedOn,
			IsApproved,
			ApprovedBy,
			ApprovedOn,
			PropertyRating,
			PropertyComments,
			LastUpdateOn,
			LastUpdateBy,
			IsSynch,
			IsActive,
			ActivationKey,
			ActivationCode,
			LicenseNoOfUsers,
			Thumb,
			SynchOn,
			UpdateLog,
			SBArea,
			CarpetArea,
			PhotoLocal,
			SBAreaCommercial,
			KhataNo,
			BuldingPlanApprovalNo,
			KPSBNoc,
			SEACNOC,
			CertificationNo,
			LicenceNo,
            PurchaseOptionID,
            SurveyNo
		}
		#endregion

		#region Data Members

			Guid _propertyID;
			Guid? _companyID;
			int? _seqNo;
			Guid? _propertyTypeID;            
			string _propertyCode;
			string _propertyName;
			Guid? _addressID;
			string _propManagerName;
			string _primaryContactNo;
			string _primaryEmail;
			string _primaryFax;
			string _propertyDisplayName;
			DateTime? _propertyRegisteredOn;
			Guid? _propertyRegisteredBy;
			DateTime? _propertyCreatedOn;
			bool? _isApproved;
			Guid? _approvedBy;
			DateTime? _approvedOn;
			string _propertyRating;
			string _propertyComments;
			DateTime? _lastUpdateOn;
			Guid? _lastUpdateBy;
			bool? _isSynch;
			bool? _isActive;
			string _activationKey;
			string _activationCode;
			int? _licenseNoOfUsers;
			string _thumb;
			DateTime? _synchOn;
			byte[] _updateLog;
			decimal? _sBArea;
			decimal? _carpetArea;
			byte[] _photoLocal;
			decimal? _sBAreaCommercial;
			string _khataNo;
			string _buldingPlanApprovalNo;
			string _kPSBNoc;
			string _sEACNOC;
			string _certificationNo;
			string _licenceNo;
            Guid? _purchaseOptionID;
            string _surveyNo;

		#endregion

		#region Properties

		[DataMember]
		public Guid  PropertyID
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
		public Guid?  CompanyID
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
		public Guid?  PropertyTypeID
		{
			 get { return _propertyTypeID; }
			 set
			 {
				 if (_propertyTypeID != value)
				 {
					_propertyTypeID = value;
					 PropertyHasChanged("PropertyTypeID");
				 }
			 }
		}

        [DataMember]
        public Guid? PurchaseOptionID
        {
            get { return _purchaseOptionID; }
            set
            {
                if (_purchaseOptionID != value)
                {
                    _purchaseOptionID = value;
                    PropertyHasChanged("PurchaseOptionID");
                }
            }
        }

		[DataMember]
		public string  PropertyCode
		{
			 get { return _propertyCode; }
			 set
			 {
				 if (_propertyCode != value)
				 {
					_propertyCode = value;
					 PropertyHasChanged("PropertyCode");
				 }
			 }
		}

		[DataMember]
		public string  PropertyName
		{
			 get { return _propertyName; }
			 set
			 {
				 if (_propertyName != value)
				 {
					_propertyName = value;
					 PropertyHasChanged("PropertyName");
				 }
			 }
		}

		[DataMember]
		public Guid?  AddressID
		{
			 get { return _addressID; }
			 set
			 {
				 if (_addressID != value)
				 {
					_addressID = value;
					 PropertyHasChanged("AddressID");
				 }
			 }
		}

		[DataMember]
		public string  PropManagerName
		{
			 get { return _propManagerName; }
			 set
			 {
				 if (_propManagerName != value)
				 {
					_propManagerName = value;
					 PropertyHasChanged("PropManagerName");
				 }
			 }
		}

		[DataMember]
		public string  PrimaryContactNo
		{
			 get { return _primaryContactNo; }
			 set
			 {
				 if (_primaryContactNo != value)
				 {
					_primaryContactNo = value;
					 PropertyHasChanged("PrimaryContactNo");
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
		public string  PropertyDisplayName
		{
			 get { return _propertyDisplayName; }
			 set
			 {
				 if (_propertyDisplayName != value)
				 {
					_propertyDisplayName = value;
					 PropertyHasChanged("PropertyDisplayName");
				 }
			 }
		}

		[DataMember]
		public DateTime?  PropertyRegisteredOn
		{
			 get { return _propertyRegisteredOn; }
			 set
			 {
				 if (_propertyRegisteredOn != value)
				 {
					_propertyRegisteredOn = value;
					 PropertyHasChanged("PropertyRegisteredOn");
				 }
			 }
		}

		[DataMember]
		public Guid?  PropertyRegisteredBy
		{
			 get { return _propertyRegisteredBy; }
			 set
			 {
				 if (_propertyRegisteredBy != value)
				 {
					_propertyRegisteredBy = value;
					 PropertyHasChanged("PropertyRegisteredBy");
				 }
			 }
		}

		[DataMember]
		public DateTime?  PropertyCreatedOn
		{
			 get { return _propertyCreatedOn; }
			 set
			 {
				 if (_propertyCreatedOn != value)
				 {
					_propertyCreatedOn = value;
					 PropertyHasChanged("PropertyCreatedOn");
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
		public string  PropertyRating
		{
			 get { return _propertyRating; }
			 set
			 {
				 if (_propertyRating != value)
				 {
					_propertyRating = value;
					 PropertyHasChanged("PropertyRating");
				 }
			 }
		}

		[DataMember]
		public string  PropertyComments
		{
			 get { return _propertyComments; }
			 set
			 {
				 if (_propertyComments != value)
				 {
					_propertyComments = value;
					 PropertyHasChanged("PropertyComments");
				 }
			 }
		}

		[DataMember]
		public DateTime?  LastUpdateOn
		{
			 get { return _lastUpdateOn; }
			 set
			 {
				 if (_lastUpdateOn != value)
				 {
					_lastUpdateOn = value;
					 PropertyHasChanged("LastUpdateOn");
				 }
			 }
		}

		[DataMember]
		public Guid?  LastUpdateBy
		{
			 get { return _lastUpdateBy; }
			 set
			 {
				 if (_lastUpdateBy != value)
				 {
					_lastUpdateBy = value;
					 PropertyHasChanged("LastUpdateBy");
				 }
			 }
		}

		[DataMember]
		public bool?  IsSynch
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
		public string  ActivationKey
		{
			 get { return _activationKey; }
			 set
			 {
				 if (_activationKey != value)
				 {
					_activationKey = value;
					 PropertyHasChanged("ActivationKey");
				 }
			 }
		}

		[DataMember]
		public string  ActivationCode
		{
			 get { return _activationCode; }
			 set
			 {
				 if (_activationCode != value)
				 {
					_activationCode = value;
					 PropertyHasChanged("ActivationCode");
				 }
			 }
		}

		[DataMember]
		public int?  LicenseNoOfUsers
		{
			 get { return _licenseNoOfUsers; }
			 set
			 {
				 if (_licenseNoOfUsers != value)
				 {
					_licenseNoOfUsers = value;
					 PropertyHasChanged("LicenseNoOfUsers");
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
		public DateTime?  SynchOn
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
		public byte[]  UpdateLog
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

		[DataMember]
		public decimal?  SBArea
		{
			 get { return _sBArea; }
			 set
			 {
				 if (_sBArea != value)
				 {
					_sBArea = value;
					 PropertyHasChanged("SBArea");
				 }
			 }
		}

		[DataMember]
		public decimal?  CarpetArea
		{
			 get { return _carpetArea; }
			 set
			 {
				 if (_carpetArea != value)
				 {
					_carpetArea = value;
					 PropertyHasChanged("CarpetArea");
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
		public decimal?  SBAreaCommercial
		{
			 get { return _sBAreaCommercial; }
			 set
			 {
				 if (_sBAreaCommercial != value)
				 {
					_sBAreaCommercial = value;
					 PropertyHasChanged("SBAreaCommercial");
				 }
			 }
		}

		[DataMember]
		public string  KhataNo
		{
			 get { return _khataNo; }
			 set
			 {
				 if (_khataNo != value)
				 {
					_khataNo = value;
					 PropertyHasChanged("KhataNo");
				 }
			 }
		}

		[DataMember]
		public string  BuldingPlanApprovalNo
		{
			 get { return _buldingPlanApprovalNo; }
			 set
			 {
				 if (_buldingPlanApprovalNo != value)
				 {
					_buldingPlanApprovalNo = value;
					 PropertyHasChanged("BuldingPlanApprovalNo");
				 }
			 }
		}

		[DataMember]
		public string  KPSBNoc
		{
			 get { return _kPSBNoc; }
			 set
			 {
				 if (_kPSBNoc != value)
				 {
					_kPSBNoc = value;
					 PropertyHasChanged("KPSBNoc");
				 }
			 }
		}

		[DataMember]
		public string  SEACNOC
		{
			 get { return _sEACNOC; }
			 set
			 {
				 if (_sEACNOC != value)
				 {
					_sEACNOC = value;
					 PropertyHasChanged("SEACNOC");
				 }
			 }
		}

		[DataMember]
		public string  CertificationNo
		{
			 get { return _certificationNo; }
			 set
			 {
				 if (_certificationNo != value)
				 {
					_certificationNo = value;
					 PropertyHasChanged("CertificationNo");
				 }
			 }
		}

		[DataMember]
		public string  LicenceNo
		{
			 get { return _licenceNo; }
			 set
			 {
				 if (_licenceNo != value)
				 {
					_licenceNo = value;
					 PropertyHasChanged("LicenceNo");
				 }
			 }
		}

        [DataMember]
        public string SurveyNo
        {
            get { return _surveyNo; }
            set
            {
                if (_surveyNo != value)
                {
                    _surveyNo = value;
                    PropertyHasChanged("SurveyNo");
                }
            }
        }

		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("PropertyID", "PropertyID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PropertyCode", "PropertyCode",7));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PropertyName", "PropertyName",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PropManagerName", "PropManagerName",180));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimaryContactNo", "PrimaryContactNo",17));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimaryEmail", "PrimaryEmail",180));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimaryFax", "PrimaryFax",17));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PropertyDisplayName", "PropertyDisplayName",35));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PropertyRating", "PropertyRating",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PropertyComments", "PropertyComments",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ActivationKey", "ActivationKey",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ActivationCode", "ActivationCode",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Thumb", "Thumb",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("KhataNo", "KhataNo",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("BuldingPlanApprovalNo", "BuldingPlanApprovalNo",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("KPSBNoc", "KPSBNoc",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("SEACNOC", "SEACNOC",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CertificationNo", "CertificationNo",2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("LicenceNo", "LicenceNo", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("SurveyNo", "SurveyNo", 2147483647));            
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"PropertyID = {0}~\n"+
			"CompanyID = {1}~\n"+
			"SeqNo = {2}~\n"+
			"PropertyTypeID = {3}~\n"+
			"PropertyCode = {4}~\n"+
			"PropertyName = {5}~\n"+
			"AddressID = {6}~\n"+
			"PropManagerName = {7}~\n"+
			"PrimaryContactNo = {8}~\n"+
			"PrimaryEmail = {9}~\n"+
			"PrimaryFax = {10}~\n"+
			"PropertyDisplayName = {11}~\n"+
			"PropertyRegisteredOn = {12}~\n"+
			"PropertyRegisteredBy = {13}~\n"+
			"PropertyCreatedOn = {14}~\n"+
			"IsApproved = {15}~\n"+
			"ApprovedBy = {16}~\n"+
			"ApprovedOn = {17}~\n"+
			"PropertyRating = {18}~\n"+
			"PropertyComments = {19}~\n"+
			"LastUpdateOn = {20}~\n"+
			"LastUpdateBy = {21}~\n"+
			"IsSynch = {22}~\n"+
			"IsActive = {23}~\n"+
			"ActivationKey = {24}~\n"+
			"ActivationCode = {25}~\n"+
			"LicenseNoOfUsers = {26}~\n"+
			"Thumb = {27}~\n"+
			"SynchOn = {28}~\n"+
			"UpdateLog = {29}~\n"+
			"SBArea = {30}~\n"+
			"CarpetArea = {31}~\n"+
			"PhotoLocal = {32}~\n"+
			"SBAreaCommercial = {33}~\n"+
			"KhataNo = {34}~\n"+
			"BuldingPlanApprovalNo = {35}~\n"+
			"KPSBNoc = {36}~\n"+
			"SEACNOC = {37}~\n"+
			"CertificationNo = {38}~\n"+
			"LicenceNo = {39}~\n",
            "PurchaseOptionID = {40}~\n",
            "SurveyNo = {41}~\n",
			PropertyID,			CompanyID,			SeqNo,			PropertyTypeID,			PropertyCode,			PropertyName,			AddressID,			PropManagerName,			PrimaryContactNo,			PrimaryEmail,			PrimaryFax,			PropertyDisplayName,			PropertyRegisteredOn,			PropertyRegisteredBy,			PropertyCreatedOn,			IsApproved,			ApprovedBy,			ApprovedOn,			PropertyRating,			PropertyComments,			LastUpdateOn,			LastUpdateBy,			IsSynch,			IsActive,			ActivationKey,			ActivationCode,			LicenseNoOfUsers,			Thumb,			SynchOn,			UpdateLog,			SBArea,			CarpetArea,			PhotoLocal,			SBAreaCommercial,			KhataNo,			BuldingPlanApprovalNo,			KPSBNoc,			SEACNOC,			CertificationNo,			LicenceNo,          PurchaseOptionID,           SurveyNo);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class PropertyKeys
	{

		#region Data Members

		Guid _propertyID;

		#endregion

		#region Constructor

		public PropertyKeys(Guid propertyID)
		{
			 _propertyID = propertyID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  PropertyID
		{
			 get { return _propertyID; }
		}

		#endregion

	}
}
