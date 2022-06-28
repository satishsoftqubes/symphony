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
	public class Employee: BusinessObjectBase
	{

		#region InnerClass
		public enum EmployeeFields
		{
			EmployeeID,
			PropertyID,
			CompanyID,
			DepartmentID,
			EmployeeNo,
			Photo,
			Surname,
			FirstName,
			LastName,
			MiddleName,
			MaidenName,
			FullName,
			BirthDate,
			BirthPlace,
			Age,
			NationalityAtBirth,
			CurrentNationality,
			Gender,
			Height,
			Weight,
			IdentificationMark,
			MaritalStatus,
			PAddressID,
			CAddressID,
			Email,
			MotherTongue,
			DOJ,
			DOC,
			StatusID,
			CandidateID,
			IsLocked,
			IsActive,
			UpdateLog,
			IsSynch,
			Synch,
			CreatedOn,
			CreatedBy,
			PhotoLocal,
			Thumb,
			SeqNo,
			UserID,
			MobileNo,
			LandlineNo,
            IsSales
		}
		#endregion

		#region Data Members

			Guid _employeeID;
			Guid? _propertyID;
			Guid? _companyID;
			Guid? _departmentID;
			string _employeeNo;
			string _photo;
			string _surname;
			string _firstName;
			string _lastName;
			string _middleName;
			string _maidenName;
			string _fullName;
			DateTime? _birthDate;
			string _birthPlace;
			int? _age;
			string _nationalityAtBirth;
			string _currentNationality;
			string _gender;
			decimal? _height;
			decimal? _weight;
			string _identificationMark;
			string _maritalStatus;
			Guid? _pAddressID;
			Guid? _cAddressID;
			string _email;
			string _motherTongue;
			DateTime? _dOJ;
			DateTime? _dOC;
			Guid? _statusID;
			Guid? _candidateID;
			bool? _isLocked;
			bool? _isActive;
			byte[] _updateLog;
			bool? _isSynch;
			DateTime? _synch;
			DateTime? _createdOn;
			Guid? _createdBy;
			byte[] _photoLocal;
			string _thumb;
			int? _seqNo;
			Guid? _userID;
			string _mobileNo;
			string _landlineNo;
            bool? _isSales;

		#endregion

		#region Properties

		[DataMember]
		public Guid  EmployeeID
		{
			 get { return _employeeID; }
			 set
			 {
				 if (_employeeID != value)
				 {
					_employeeID = value;
					 PropertyHasChanged("EmployeeID");
				 }
			 }
		}

		[DataMember]
		public Guid?  PropertyID
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
		public Guid?  DepartmentID
		{
			 get { return _departmentID; }
			 set
			 {
				 if (_departmentID != value)
				 {
					_departmentID = value;
					 PropertyHasChanged("DepartmentID");
				 }
			 }
		}

		[DataMember]
		public string  EmployeeNo
		{
			 get { return _employeeNo; }
			 set
			 {
				 if (_employeeNo != value)
				 {
					_employeeNo = value;
					 PropertyHasChanged("EmployeeNo");
				 }
			 }
		}

		[DataMember]
		public string  Photo
		{
			 get { return _photo; }
			 set
			 {
				 if (_photo != value)
				 {
					_photo = value;
					 PropertyHasChanged("Photo");
				 }
			 }
		}

		[DataMember]
		public string  Surname
		{
			 get { return _surname; }
			 set
			 {
				 if (_surname != value)
				 {
					_surname = value;
					 PropertyHasChanged("Surname");
				 }
			 }
		}

		[DataMember]
		public string  FirstName
		{
			 get { return _firstName; }
			 set
			 {
				 if (_firstName != value)
				 {
					_firstName = value;
					 PropertyHasChanged("FirstName");
				 }
			 }
		}

		[DataMember]
		public string  LastName
		{
			 get { return _lastName; }
			 set
			 {
				 if (_lastName != value)
				 {
					_lastName = value;
					 PropertyHasChanged("LastName");
				 }
			 }
		}

		[DataMember]
		public string  MiddleName
		{
			 get { return _middleName; }
			 set
			 {
				 if (_middleName != value)
				 {
					_middleName = value;
					 PropertyHasChanged("MiddleName");
				 }
			 }
		}

		[DataMember]
		public string  MaidenName
		{
			 get { return _maidenName; }
			 set
			 {
				 if (_maidenName != value)
				 {
					_maidenName = value;
					 PropertyHasChanged("MaidenName");
				 }
			 }
		}

		[DataMember]
		public string  FullName
		{
			 get { return _fullName; }
			 set
			 {
				 if (_fullName != value)
				 {
					_fullName = value;
					 PropertyHasChanged("FullName");
				 }
			 }
		}

		[DataMember]
		public DateTime?  BirthDate
		{
			 get { return _birthDate; }
			 set
			 {
				 if (_birthDate != value)
				 {
					_birthDate = value;
					 PropertyHasChanged("BirthDate");
				 }
			 }
		}

		[DataMember]
		public string  BirthPlace
		{
			 get { return _birthPlace; }
			 set
			 {
				 if (_birthPlace != value)
				 {
					_birthPlace = value;
					 PropertyHasChanged("BirthPlace");
				 }
			 }
		}

		[DataMember]
		public int?  Age
		{
			 get { return _age; }
			 set
			 {
				 if (_age != value)
				 {
					_age = value;
					 PropertyHasChanged("Age");
				 }
			 }
		}

		[DataMember]
		public string  NationalityAtBirth
		{
			 get { return _nationalityAtBirth; }
			 set
			 {
				 if (_nationalityAtBirth != value)
				 {
					_nationalityAtBirth = value;
					 PropertyHasChanged("NationalityAtBirth");
				 }
			 }
		}

		[DataMember]
		public string  CurrentNationality
		{
			 get { return _currentNationality; }
			 set
			 {
				 if (_currentNationality != value)
				 {
					_currentNationality = value;
					 PropertyHasChanged("CurrentNationality");
				 }
			 }
		}

		[DataMember]
		public string  Gender
		{
			 get { return _gender; }
			 set
			 {
				 if (_gender != value)
				 {
					_gender = value;
					 PropertyHasChanged("Gender");
				 }
			 }
		}

		[DataMember]
		public decimal?  Height
		{
			 get { return _height; }
			 set
			 {
				 if (_height != value)
				 {
					_height = value;
					 PropertyHasChanged("Height");
				 }
			 }
		}

		[DataMember]
		public decimal?  Weight
		{
			 get { return _weight; }
			 set
			 {
				 if (_weight != value)
				 {
					_weight = value;
					 PropertyHasChanged("Weight");
				 }
			 }
		}

		[DataMember]
		public string  IdentificationMark
		{
			 get { return _identificationMark; }
			 set
			 {
				 if (_identificationMark != value)
				 {
					_identificationMark = value;
					 PropertyHasChanged("IdentificationMark");
				 }
			 }
		}

		[DataMember]
		public string  MaritalStatus
		{
			 get { return _maritalStatus; }
			 set
			 {
				 if (_maritalStatus != value)
				 {
					_maritalStatus = value;
					 PropertyHasChanged("MaritalStatus");
				 }
			 }
		}

		[DataMember]
		public Guid?  PAddressID
		{
			 get { return _pAddressID; }
			 set
			 {
				 if (_pAddressID != value)
				 {
					_pAddressID = value;
					 PropertyHasChanged("PAddressID");
				 }
			 }
		}

		[DataMember]
		public Guid?  CAddressID
		{
			 get { return _cAddressID; }
			 set
			 {
				 if (_cAddressID != value)
				 {
					_cAddressID = value;
					 PropertyHasChanged("CAddressID");
				 }
			 }
		}

		[DataMember]
		public string  Email
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

		[DataMember]
		public string  MotherTongue
		{
			 get { return _motherTongue; }
			 set
			 {
				 if (_motherTongue != value)
				 {
					_motherTongue = value;
					 PropertyHasChanged("MotherTongue");
				 }
			 }
		}

		[DataMember]
		public DateTime?  DOJ
		{
			 get { return _dOJ; }
			 set
			 {
				 if (_dOJ != value)
				 {
					_dOJ = value;
					 PropertyHasChanged("DOJ");
				 }
			 }
		}

		[DataMember]
		public DateTime?  DOC
		{
			 get { return _dOC; }
			 set
			 {
				 if (_dOC != value)
				 {
					_dOC = value;
					 PropertyHasChanged("DOC");
				 }
			 }
		}

		[DataMember]
		public Guid?  StatusID
		{
			 get { return _statusID; }
			 set
			 {
				 if (_statusID != value)
				 {
					_statusID = value;
					 PropertyHasChanged("StatusID");
				 }
			 }
		}

		[DataMember]
		public Guid?  CandidateID
		{
			 get { return _candidateID; }
			 set
			 {
				 if (_candidateID != value)
				 {
					_candidateID = value;
					 PropertyHasChanged("CandidateID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsLocked
		{
			 get { return _isLocked; }
			 set
			 {
				 if (_isLocked != value)
				 {
					_isLocked = value;
					 PropertyHasChanged("IsLocked");
				 }
			 }
		}
        [DataMember]
        public bool? IsSales
        {
            get { return _isSales; }
            set
            {
                if (_isSales != value)
                {
                    _isSales = value;
                    PropertyHasChanged("IsSales");
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
		public DateTime?  Synch
		{
			 get { return _synch; }
			 set
			 {
				 if (_synch != value)
				 {
					_synch = value;
					 PropertyHasChanged("Synch");
				 }
			 }
		}

		[DataMember]
		public DateTime?  CreatedOn
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
		public Guid?  CreatedBy
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
		public Guid?  UserID
		{
			 get { return _userID; }
			 set
			 {
				 if (_userID != value)
				 {
					_userID = value;
					 PropertyHasChanged("UserID");
				 }
			 }
		}

		[DataMember]
		public string  MobileNo
		{
			 get { return _mobileNo; }
			 set
			 {
				 if (_mobileNo != value)
				 {
					_mobileNo = value;
					 PropertyHasChanged("MobileNo");
				 }
			 }
		}

		[DataMember]
		public string  LandlineNo
		{
			 get { return _landlineNo; }
			 set
			 {
				 if (_landlineNo != value)
				 {
					_landlineNo = value;
					 PropertyHasChanged("LandlineNo");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("EmployeeID", "EmployeeID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("EmployeeNo", "EmployeeNo",60));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Photo", "Photo",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Surname", "Surname",50));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("FirstName", "FirstName",90));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("LastName", "LastName",90));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("MiddleName", "MiddleName",90));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("MaidenName", "MaidenName",90));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("FullName", "FullName",320));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("BirthPlace", "BirthPlace",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("NationalityAtBirth", "NationalityAtBirth",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CurrentNationality", "CurrentNationality",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Gender", "Gender",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("IdentificationMark", "IdentificationMark",320));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("MaritalStatus", "MaritalStatus",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Email", "Email",180));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("MotherTongue", "MotherTongue",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Thumb", "Thumb",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("MobileNo", "MobileNo",15));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("LandlineNo", "LandlineNo",15));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"EmployeeID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"CompanyID = {2}~\n"+
			"DepartmentID = {3}~\n"+
			"EmployeeNo = {4}~\n"+
			"Photo = {5}~\n"+
			"Surname = {6}~\n"+
			"FirstName = {7}~\n"+
			"LastName = {8}~\n"+
			"MiddleName = {9}~\n"+
			"MaidenName = {10}~\n"+
			"FullName = {11}~\n"+
			"BirthDate = {12}~\n"+
			"BirthPlace = {13}~\n"+
			"Age = {14}~\n"+
			"NationalityAtBirth = {15}~\n"+
			"CurrentNationality = {16}~\n"+
			"Gender = {17}~\n"+
			"Height = {18}~\n"+
			"Weight = {19}~\n"+
			"IdentificationMark = {20}~\n"+
			"MaritalStatus = {21}~\n"+
			"PAddressID = {22}~\n"+
			"CAddressID = {23}~\n"+
			"Email = {24}~\n"+
			"MotherTongue = {25}~\n"+
			"DOJ = {26}~\n"+
			"DOC = {27}~\n"+
			"StatusID = {28}~\n"+
			"CandidateID = {29}~\n"+
			"IsLocked = {30}~\n"+
			"IsActive = {31}~\n"+
			"UpdateLog = {32}~\n"+
			"IsSynch = {33}~\n"+
			"Synch = {34}~\n"+
			"CreatedOn = {35}~\n"+
			"CreatedBy = {36}~\n"+
			"PhotoLocal = {37}~\n"+
			"Thumb = {38}~\n"+
			"SeqNo = {39}~\n"+
			"UserID = {40}~\n"+
			"MobileNo = {41}~\n"+
			"LandlineNo = {42}~\n"+
            "IsSales={43}~\n",
            EmployeeID, PropertyID, CompanyID, DepartmentID, EmployeeNo, Photo, Surname, FirstName, LastName, MiddleName, MaidenName, FullName, BirthDate, BirthPlace, Age, NationalityAtBirth, CurrentNationality, Gender, Height, Weight, IdentificationMark, MaritalStatus, PAddressID, CAddressID, Email, MotherTongue, DOJ, DOC, StatusID, CandidateID, IsLocked, IsActive, UpdateLog, IsSynch, Synch, CreatedOn, CreatedBy, PhotoLocal, Thumb, SeqNo, UserID, MobileNo, LandlineNo, IsSales); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class EmployeeKeys
	{

		#region Data Members

		Guid _employeeID;

		#endregion

		#region Constructor

		public EmployeeKeys(Guid employeeID)
		{
			 _employeeID = employeeID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  EmployeeID
		{
			 get { return _employeeID; }
		}

		#endregion

	}
}
