using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;
namespace SQT.Symphony.BusinessLogic.IRMS.DTO
{
	[DataContract]
	public class Investor: BusinessObjectBase
	{

		#region InnerClass 
		public enum InvestorFields
		{
			InvestorID,
			Title,
			FName,
			LName,
			RefInverstorID,
			Age,
			PanNo,
			POAHolder,
			AgreementAddressID,
			PostalAddressID,
			MobileNo,
			LandLineNo,
			EMail,
			BankName,
			AccountNo,
			OccupationTermID,
			CompanyName,
			Designation,
			RelationShipManagerID,
			ManagerType,
			NameOfFirm,
			ManagerContactNo,
			ManagerEmail,
			UniworldPrime,
			PrimeMobileNo,
			PrimeEmail,
			Thumb,
			IsActive,
			CreatedOn,
			UpdatedOn,
			CreatedBy,
			UpdatedBy,
			UpdateLog,
			SeqNo,
			UserID,
			InvestorTypeID,
			CompanyID,
            RelationsOf,
            RelationalName,
            ContactPersonName,
            ContactPersonEmail,
            ContactPersonMobile,
            IsEmail,
            IsSMS,
            Reference,
            RegionTermID,
            ReferenceTermID,
            IFSCCode,
            DateOfBirth,
            CoOrdinatorInvestorID,
            BankAcctName,
            BankBranchName
		}
		#endregion

		#region Data Members

			Guid _investorID;
			string _title;
			string _fName;
			string _lName;
			Guid? _refInverstorID;
			int? _age;
			string _panNo;
			string _pOAHolder;
			Guid? _agreementAddressID;
			Guid? _postalAddressID;
			string _mobileNo;
			string _landLineNo;
			string _eMail;
			string _bankName;
			string _accountNo;
			Guid? _occupationTermID;
			string _companyName;
			string _designation;
			Guid? _relationShipManagerID;
			string _managerType;
			string _nameOfFirm;
			string _managerContactNo;
			string _managerEmail;
			string _uniworldPrime;
			string _primeMobileNo;
			string _primeEmail;
			string _thumb;
			bool? _isActive;
			DateTime? _createdOn;
			DateTime? _updatedOn;
			Guid? _createdBy;
			Guid? _updatedBy;
			byte[] _updateLog;
			int _seqNo;
			Guid? _userID;
			Guid? _investorTypeID;
			Guid? _companyID;
            string _relationsOf;
            string _relationalName;
            string _contactPersonName;
            string _contactPersonEmail;
            string _contactPersonMobile;
            bool? _isEmail;
            bool? _isSMS;
            string _reference;
            Guid? _regionTermID;
            Guid? _referenceTermID;
            string _IFSCCode;
            DateTime? _dateOfBirth;
            Guid? _coOrdinatorInvestorID;
            string _bankAcctName;
            string _bankBranchName;
		#endregion

		#region Properties

            [DataMember]
            public string ContactPersonMobile
            {
                get { return _contactPersonMobile; }
                set
                {
                    if (_contactPersonMobile != value)
                    {
                        _contactPersonMobile = value;
                        PropertyHasChanged("ContactPersonMobile");
                    }
                }
            }

            [DataMember]
            public string ContactPersonEmail
            {
                get { return _contactPersonEmail; }
                set
                {
                    if (_contactPersonEmail != value)
                    {
                        _contactPersonEmail = value;
                        PropertyHasChanged("ContactPersonEmail");
                    }
                }
            }

            [DataMember]
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

            [DataMember]
            public string RelationalName
            {
                get { return _relationalName; }
                set
                {
                    if (_relationalName != value)
                    {
                        _relationalName = value;
                        PropertyHasChanged("RelationalName");
                    }
                }
            }

            [DataMember]
            public string RelationsOf
            {
                get { return _relationsOf; }
                set
                {
                    if (_relationsOf != value)
                    {
                        _relationsOf = value;
                        PropertyHasChanged("RelationsOf");
                    }
                }
            }

		[DataMember]
		public Guid  InvestorID
		{
			 get { return _investorID; }
			 set
			 {
				 if (_investorID != value)
				 {
					_investorID = value;
					 PropertyHasChanged("InvestorID");
				 }
			 }
		}

		[DataMember]
		public string  Title
		{
			 get { return _title; }
			 set
			 {
				 if (_title != value)
				 {
					_title = value;
					 PropertyHasChanged("Title");
				 }
			 }
		}

		[DataMember]
		public string  FName
		{
			 get { return _fName; }
			 set
			 {
				 if (_fName != value)
				 {
					_fName = value;
					 PropertyHasChanged("FName");
				 }
			 }
		}

		[DataMember]
		public string  LName
		{
			 get { return _lName; }
			 set
			 {
				 if (_lName != value)
				 {
					_lName = value;
					 PropertyHasChanged("LName");
				 }
			 }
		}

		[DataMember]
		public Guid?  RefInverstorID
		{
			 get { return _refInverstorID; }
			 set
			 {
				 if (_refInverstorID != value)
				 {
					_refInverstorID = value;
					 PropertyHasChanged("RefInverstorID");
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
		public string  POAHolder
		{
			 get { return _pOAHolder; }
			 set
			 {
				 if (_pOAHolder != value)
				 {
					_pOAHolder = value;
					 PropertyHasChanged("POAHolder");
				 }
			 }
		}

		[DataMember]
		public Guid?  AgreementAddressID
		{
			 get { return _agreementAddressID; }
			 set
			 {
				 if (_agreementAddressID != value)
				 {
					_agreementAddressID = value;
					 PropertyHasChanged("AgreementAddressID");
				 }
			 }
		}

		[DataMember]
		public Guid?  PostalAddressID
		{
			 get { return _postalAddressID; }
			 set
			 {
				 if (_postalAddressID != value)
				 {
					_postalAddressID = value;
					 PropertyHasChanged("PostalAddressID");
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
		public string  LandLineNo
		{
			 get { return _landLineNo; }
			 set
			 {
				 if (_landLineNo != value)
				 {
					_landLineNo = value;
					 PropertyHasChanged("LandLineNo");
				 }
			 }
		}

		[DataMember]
		public string  EMail
		{
			 get { return _eMail; }
			 set
			 {
				 if (_eMail != value)
				 {
					_eMail = value;
					 PropertyHasChanged("EMail");
				 }
			 }
		}

		[DataMember]
		public string  BankName
		{
			 get { return _bankName; }
			 set
			 {
				 if (_bankName != value)
				 {
					_bankName = value;
					 PropertyHasChanged("BankName");
				 }
			 }
		}

		[DataMember]
		public string  AccountNo
		{
			 get { return _accountNo; }
			 set
			 {
				 if (_accountNo != value)
				 {
					_accountNo = value;
					 PropertyHasChanged("AccountNo");
				 }
			 }
		}

		[DataMember]
		public Guid?  OccupationTermID
		{
			 get { return _occupationTermID; }
			 set
			 {
				 if (_occupationTermID != value)
				 {
					_occupationTermID = value;
					 PropertyHasChanged("OccupationTermID");
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
		public string  Designation
		{
			 get { return _designation; }
			 set
			 {
				 if (_designation != value)
				 {
					_designation = value;
					 PropertyHasChanged("Designation");
				 }
			 }
		}

		[DataMember]
		public Guid?  RelationShipManagerID
		{
			 get { return _relationShipManagerID; }
			 set
			 {
				 if (_relationShipManagerID != value)
				 {
					_relationShipManagerID = value;
					 PropertyHasChanged("RelationShipManagerID");
				 }
			 }
		}

		[DataMember]
		public string  ManagerType
		{
			 get { return _managerType; }
			 set
			 {
				 if (_managerType != value)
				 {
					_managerType = value;
					 PropertyHasChanged("ManagerType");
				 }
			 }
		}

		[DataMember]
		public string  NameOfFirm
		{
			 get { return _nameOfFirm; }
			 set
			 {
				 if (_nameOfFirm != value)
				 {
					_nameOfFirm = value;
					 PropertyHasChanged("NameOfFirm");
				 }
			 }
		}

		[DataMember]
		public string  ManagerContactNo
		{
			 get { return _managerContactNo; }
			 set
			 {
				 if (_managerContactNo != value)
				 {
					_managerContactNo = value;
					 PropertyHasChanged("ManagerContactNo");
				 }
			 }
		}

		[DataMember]
		public string  ManagerEmail
		{
			 get { return _managerEmail; }
			 set
			 {
				 if (_managerEmail != value)
				 {
					_managerEmail = value;
					 PropertyHasChanged("ManagerEmail");
				 }
			 }
		}

		[DataMember]
		public string  UniworldPrime
		{
			 get { return _uniworldPrime; }
			 set
			 {
				 if (_uniworldPrime != value)
				 {
					_uniworldPrime = value;
					 PropertyHasChanged("UniworldPrime");
				 }
			 }
		}

		[DataMember]
		public string  PrimeMobileNo
		{
			 get { return _primeMobileNo; }
			 set
			 {
				 if (_primeMobileNo != value)
				 {
					_primeMobileNo = value;
					 PropertyHasChanged("PrimeMobileNo");
				 }
			 }
		}

		[DataMember]
		public string  PrimeEmail
		{
			 get { return _primeEmail; }
			 set
			 {
				 if (_primeEmail != value)
				 {
					_primeEmail = value;
					 PropertyHasChanged("PrimeEmail");
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
        public bool? IsEmail
        {
            get { return _isEmail; }
            set
            {
                if (_isEmail != value)
                {
                    _isEmail = value;
                    PropertyHasChanged("IsEmail");
                }
            }
        }

        [DataMember]
        public bool? IsSMS
        {
            get { return _isSMS; }
            set
            {
                if (_isSMS != value)
                {
                    _isSMS = value;
                    PropertyHasChanged("IsSMS");
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
		public DateTime?  UpdatedOn
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
		public Guid?  UpdatedBy
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
		public int  SeqNo
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
		public Guid?  InvestorTypeID
		{
			 get { return _investorTypeID; }
			 set
			 {
				 if (_investorTypeID != value)
				 {
					_investorTypeID = value;
					 PropertyHasChanged("InvestorTypeID");
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
        public string Reference
        {
            get { return _reference; }
            set
            {
                if (_reference != value)
                {
                    _reference = value;
                    PropertyHasChanged("Reference");
                }
            }
        }
        [DataMember]
        public Guid? ReferenceTermID
        {
            get { return _referenceTermID; }
            set
            {
                if (_referenceTermID != value)
                {
                    _referenceTermID = value;
                    PropertyHasChanged("ReferenceTermID");
                }
            }
        }

        [DataMember]
        public Guid? RegionTermID
        {
            get { return _regionTermID; }
            set
            {
                if (_regionTermID != value)
                {
                    _regionTermID = value;
                    PropertyHasChanged("RegionTermID");
                }
            }
        }

        [DataMember]
        public string IFSCCode
        {
            get { return _IFSCCode; }
            set
            {
                if (_IFSCCode != value)
                {
                    _IFSCCode = value;
                    PropertyHasChanged("IFSCCode");
                }
            }
        }

        [DataMember]
        public DateTime? DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                if (_dateOfBirth != value)
                {
                    _dateOfBirth = value;
                    PropertyHasChanged("DateOfBirth");
                }
            }
        }

        [DataMember]
        public Guid? CoOrdinatorInvestorID
        {
            get { return _coOrdinatorInvestorID; }
            set
            {
                if (_coOrdinatorInvestorID != value)
                {
                    _coOrdinatorInvestorID = value;
                    PropertyHasChanged("CoOrdinatorInvestorID");
                }
            }
        }

        [DataMember]
        public string BankAcctName
        {
            get { return _bankAcctName; }
            set
            {
                if (_bankAcctName != value)
                {
                    _bankAcctName = value;
                    PropertyHasChanged("BankAcctName");
                }
            }
        }

        [DataMember]
        public string BankBranchName
        {
            get { return _bankBranchName; }
            set
            {
                if (_bankBranchName != value)
                {
                    _bankBranchName = value;
                    PropertyHasChanged("BankBranchName");
                }
            }
        }

		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("InvestorID", "InvestorID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Title", "Title",5));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("FName", "FName",120));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("LName", "LName",120));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PanNo", "PanNo",25));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("POAHolder", "POAHolder",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("MobileNo", "MobileNo",17));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("LandLineNo", "LandLineNo",17));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("EMail", "EMail",320));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("BankName", "BankName",200));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("AccountNo", "AccountNo",25));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CompanyName", "CompanyName",350));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Designation", "Designation",350));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ManagerType", "ManagerType",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("NameOfFirm", "NameOfFirm",550));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ManagerContactNo", "ManagerContactNo",17));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ManagerEmail", "ManagerEmail",320));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("UniworldPrime", "UniworldPrime",120));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimeMobileNo", "PrimeMobileNo",17));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimeEmail", "PrimeEmail",350));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("RelationsOf", "RelationsOf", 150));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("RelationalName", "RelationalName", 150));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ContactPersonName", "ContactPersonName", 150));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ContactPersonEmail", "ContactPersonEmail", 50));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ContactPersonMobile", "ContactPersonMobile", 50));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Thumb", "Thumb",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Reference", "Reference", 180));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"InvestorID = {0}\n"+
			"Title = {1}\n"+
			"FName = {2}\n"+
			"LName = {3}\n"+
			"RefInverstorID = {4}\n"+
			"Age = {5}\n"+
			"PanNo = {6}\n"+
			"POAHolder = {7}\n"+
			"AgreementAddressID = {8}\n"+
			"PostalAddressID = {9}\n"+
			"MobileNo = {10}\n"+
			"LandLineNo = {11}\n"+
			"EMail = {12}\n"+
			"BankName = {13}\n"+
			"AccountNo = {14}\n"+
			"OccupationTermID = {15}\n"+
			"CompanyName = {16}\n"+
			"Designation = {17}\n"+
			"RelationShipManagerID = {18}\n"+
			"ManagerType = {19}\n"+
			"NameOfFirm = {20}\n"+
			"ManagerContactNo = {21}\n"+
			"ManagerEmail = {22}\n"+
			"UniworldPrime = {23}\n"+
			"PrimeMobileNo = {24}\n"+
			"PrimeEmail = {25}\n"+
			"Thumb = {26}\n"+
			"IsActive = {27}\n"+
			"CreatedOn = {28}\n"+
			"UpdatedOn = {29}\n"+
			"CreatedBy = {30}\n"+
			"UpdatedBy = {31}\n"+
			"UpdateLog = {32}\n"+
			"SeqNo = {33}\n"+
			"UserID = {34}\n"+
			"InvestorTypeID = {35}\n"+
			"CompanyID = {36}\n" +
            "RelationsOf = {37}\n" +
            "RelationalName = {38}\n" +
            "ContactPersonName = {39}\n" +
            "ContactPersonEmail = {40}\n" +
            "ContactPersonMobile = {41}\n" +
            "IsEmail = {42}\n"+
            "IsSMS={43}\n"+
            "Reference = {44}\n" + 
            "RegionTermID={45}\n" +
            "ReferenceTermID={46}\n",
            InvestorID, Title, FName, LName, RefInverstorID, Age, PanNo, POAHolder, AgreementAddressID, PostalAddressID, MobileNo, LandLineNo, EMail, BankName, AccountNo, OccupationTermID, CompanyName, Designation, RelationShipManagerID, ManagerType, NameOfFirm, ManagerContactNo, ManagerEmail, UniworldPrime, PrimeMobileNo, PrimeEmail, Thumb, IsActive, CreatedOn, UpdatedOn, CreatedBy, UpdatedBy, UpdateLog, SeqNo, UserID, InvestorTypeID, CompanyID, RelationsOf, RelationalName, ContactPersonName, ContactPersonEmail, ContactPersonMobile, IsEmail, IsSMS, Reference, RegionTermID, ReferenceTermID); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class InvestorKeys
	{

		#region Data Members

		Guid _investorID;

		#endregion

		#region Constructor

		public InvestorKeys(Guid investorID)
		{
			 _investorID = investorID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  InvestorID
		{
			 get { return _investorID; }
		}

		#endregion

	}
}
