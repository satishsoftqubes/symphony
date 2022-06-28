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
	public class Prospects: BusinessObjectBase
	{

		#region InnerClass
		public enum ProspectsFields
		{
			CompanyID,
			ProspectID,
			SeqNo,
			Title,
			FName,
			LName,
			Reference,
			StatusID,
			EMail,
			MobileNo,
			LandlineNo,
			Location,
			AddressID,
			OccupationTermID,
			CompanyName,
			ContactedBy,
			ContactedPersonType,
			IsActive,
			InvestorID,
			IsSynch,
			SynchOn,
			CreatedOn,
			UpdatedOn,
			CreatedBy,
			UpdatedBy,
			Thumb,
			UpdateLog,
            IsEmail,
            IsSMS,
            ManagerType,
            RelationShipManagerID,
            ManagerContactNo,
            ManagerEmail,
            NameOfFirm,
            RegionTermID,
            ReferenceTermID
		}
		#endregion

		#region Data Members

			Guid? _companyID;
			Guid _prospectID;
			int _seqNo;
			string _title;
			string _fName;
			string _lName;
			string _reference;
			Guid? _statusID;
			string _eMail;
			string _mobileNo;
			string _landlineNo;
			string _location;
			Guid? _addressID;
			Guid? _occupationTermID;
			string _companyName;
			Guid? _contactedBy;
			string _contactedPersonType;
			bool? _isActive;
			Guid? _investorID;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _createdOn;
			DateTime? _updatedOn;
			Guid? _createdBy;
			Guid? _updatedBy;
			string _thumb;
			byte[] _updateLog;
            bool? _isEmail;
            bool? _isSMS;
            string _managerType;
            Guid? _relationShipManagerID;
            string _managerContactNo;
            string _managerEmail;
            string _nameOfFirm;
            Guid? _regionTermID;
            Guid? _referenceTermID;

		#endregion

		#region Properties

            
            
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
		public Guid  ProspectID
		{
			 get { return _prospectID; }
			 set
			 {
				 if (_prospectID != value)
				 {
					_prospectID = value;
					 PropertyHasChanged("ProspectID");
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
		public string  Reference
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

		[DataMember]
		public string  Location
		{
			 get { return _location; }
			 set
			 {
				 if (_location != value)
				 {
					_location = value;
					 PropertyHasChanged("Location");
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
		public Guid?  ContactedBy
		{
			 get { return _contactedBy; }
			 set
			 {
				 if (_contactedBy != value)
				 {
					_contactedBy = value;
					 PropertyHasChanged("ContactedBy");
				 }
			 }
		}

		[DataMember]
		public string  ContactedPersonType
		{
			 get { return _contactedPersonType; }
			 set
			 {
				 if (_contactedPersonType != value)
				 {
					_contactedPersonType = value;
					 PropertyHasChanged("ContactedPersonType");
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
                    _isSMS= value;
                    PropertyHasChanged("IsSMS");
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
		public Guid?  InvestorID
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
        public string ManagerType
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
        public Guid? RelationShipManagerID
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
        public string ManagerContactNo
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
        public string ManagerEmail
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
        public string NameOfFirm
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
		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ProspectID", "ProspectID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Title", "Title",6));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("FName", "FName",120));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("LName", "LName",120));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Reference", "Reference",180));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("EMail", "EMail",250));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("MobileNo", "MobileNo",17));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("LandlineNo", "LandlineNo",17));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Location", "Location",18));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CompanyName", "CompanyName",320));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ContactedPersonType", "ContactedPersonType",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Thumb", "Thumb",2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ManagerType", "ManagerType", 100));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ManagerContactNo", "ManagerContactNo", 15));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ManagerEmail", "ManagerEmail", 300));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("NameOfFirm", "NameOfFirm", 300));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"CompanyID = {0}\n"+
			"ProspectID = {1}\n"+
			"SeqNo = {2}\n"+
			"Title = {3}\n"+
			"FName = {4}\n"+
			"LName = {5}\n"+
			"Reference = {6}\n"+
			"StatusID = {7}\n"+
			"EMail = {8}\n"+
			"MobileNo = {9}\n"+
			"LandlineNo = {10}\n"+
			"Location = {11}\n"+
			"AddressID = {12}\n"+
			"OccupationTermID = {13}\n"+
			"CompanyName = {14}\n"+
			"ContactedBy = {15}\n"+
			"ContactedPersonType = {16}\n"+
			"IsActive = {17}\n"+
			"InvestorID = {18}\n"+
			"IsSynch = {19}\n"+
			"SynchOn = {20}\n"+
			"CreatedOn = {21}\n"+
			"UpdatedOn = {22}\n"+
			"CreatedBy = {23}\n"+
			"UpdatedBy = {24}\n"+
			"Thumb = {25}\n"+
			"UpdateLog = {26}\n"+
            "IsEmail = {27}\n"+
            "IsSMS={28}\n"+
            "ManagerType={29}\n"+
            "RelationShipManagerID={30}\n"+
            "ManagerContactNo={31}\n"+
            "ManagerEmail={32}\n"+
            "NameOfFirm={33}\n"+
            "RegionTermID={34}\n"+
            "ReferenceTermID={35}\n",
            CompanyID, ProspectID, SeqNo, Title, FName, LName, Reference, StatusID, EMail, MobileNo, LandlineNo, Location, AddressID, OccupationTermID, CompanyName, ContactedBy, ContactedPersonType, IsActive, InvestorID, IsSynch, SynchOn, CreatedOn, UpdatedOn, CreatedBy, UpdatedBy, Thumb, UpdateLog, IsEmail, IsSMS, ManagerType, RelationShipManagerID, ManagerContactNo, ManagerEmail, NameOfFirm, RegionTermID, ReferenceTermID); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ProspectsKeys
	{

		#region Data Members

		Guid _prospectID;

		#endregion

		#region Constructor

		public ProspectsKeys(Guid prospectID)
		{
			 _prospectID = prospectID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ProspectID
		{
			 get { return _prospectID; }
		}

		#endregion

	}
}
