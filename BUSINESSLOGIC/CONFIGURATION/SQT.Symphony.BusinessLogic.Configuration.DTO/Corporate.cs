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
	public class Corporate: BusinessObjectBase
	{

		#region InnerClass
		public enum CorporateFields
		{
			CorporateID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			Code,
			CompanyName,
			Title,
			FName,
			LName,
			DisplayName,
			CorporateType_TermID,
			DBAcctID,
			ComissionAcctID,
			IsDirectBill,
			IsComission,
			IsComissionFlat,
			ComissionValue,
			ComissionFlag_TermID,
			Notes,
			DefaultResStatus_TermID,
			IsBlock,
			BlockReason,
			ApplicationUserID,
			Turnover,
			DefaultRateID,
            AddressID,
            Email,
            ContactNo,
            Fax,
            VoucherTitle,
            VoucherImage,
            MobileNo,
            Department,
            Designation
		}
		#endregion

		#region Data Members

			Guid _corporateID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			string _code;
			string _companyName;
			string _title;
			string _fName;
			string _lName;
			string _displayName;
			Guid? _corporateType_TermID;
			Guid? _dBAcctID;
			Guid? _comissionAcctID;
			bool? _isDirectBill;
			bool? _isComission;
			bool? _isComissionFlat;
			decimal? _comissionValue;
			Guid? _comissionFlag_TermID;
			string _notes;
			Guid? _defaultResStatus_TermID;
			bool? _isBlock;
			string _blockReason;
			Guid? _applicationUserID;
			decimal? _turnover;
			Guid? _defaultRateID;
            Guid? _addressID;
            string _email;
            string _contactNo;
            string _fax;
            string _voucherTitle;
            string _voucherImage;
            string _mobileNo;
            string _department;
            string _designation;

		#endregion

		#region Properties

		[DataMember]
		public Guid  CorporateID
		{
			 get { return _corporateID; }
			 set
			 {
				 if (_corporateID != value)
				 {
					_corporateID = value;
					 PropertyHasChanged("CorporateID");
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
		public string  Code
		{
			 get { return _code; }
			 set
			 {
				 if (_code != value)
				 {
					_code = value;
					 PropertyHasChanged("Code");
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
		public Guid?  CorporateType_TermID
		{
			 get { return _corporateType_TermID; }
			 set
			 {
				 if (_corporateType_TermID != value)
				 {
					_corporateType_TermID = value;
					 PropertyHasChanged("CorporateType_TermID");
				 }
			 }
		}

		[DataMember]
		public Guid?  DBAcctID
		{
			 get { return _dBAcctID; }
			 set
			 {
				 if (_dBAcctID != value)
				 {
					_dBAcctID = value;
					 PropertyHasChanged("DBAcctID");
				 }
			 }
		}

		[DataMember]
		public Guid?  ComissionAcctID
		{
			 get { return _comissionAcctID; }
			 set
			 {
				 if (_comissionAcctID != value)
				 {
					_comissionAcctID = value;
					 PropertyHasChanged("ComissionAcctID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsDirectBill
		{
			 get { return _isDirectBill; }
			 set
			 {
				 if (_isDirectBill != value)
				 {
					_isDirectBill = value;
					 PropertyHasChanged("IsDirectBill");
				 }
			 }
		}

		[DataMember]
		public bool?  IsComission
		{
			 get { return _isComission; }
			 set
			 {
				 if (_isComission != value)
				 {
					_isComission = value;
					 PropertyHasChanged("IsComission");
				 }
			 }
		}

		[DataMember]
		public bool?  IsComissionFlat
		{
			 get { return _isComissionFlat; }
			 set
			 {
				 if (_isComissionFlat != value)
				 {
					_isComissionFlat = value;
					 PropertyHasChanged("IsComissionFlat");
				 }
			 }
		}

		[DataMember]
		public decimal?  ComissionValue
		{
			 get { return _comissionValue; }
			 set
			 {
				 if (_comissionValue != value)
				 {
					_comissionValue = value;
					 PropertyHasChanged("ComissionValue");
				 }
			 }
		}

		[DataMember]
		public Guid?  ComissionFlag_TermID
		{
			 get { return _comissionFlag_TermID; }
			 set
			 {
				 if (_comissionFlag_TermID != value)
				 {
					_comissionFlag_TermID = value;
					 PropertyHasChanged("ComissionFlag_TermID");
				 }
			 }
		}

		[DataMember]
		public string  Notes
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
		public Guid?  DefaultResStatus_TermID
		{
			 get { return _defaultResStatus_TermID; }
			 set
			 {
				 if (_defaultResStatus_TermID != value)
				 {
					_defaultResStatus_TermID = value;
					 PropertyHasChanged("DefaultResStatus_TermID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsBlock
		{
			 get { return _isBlock; }
			 set
			 {
				 if (_isBlock != value)
				 {
					_isBlock = value;
					 PropertyHasChanged("IsBlock");
				 }
			 }
		}

		[DataMember]
		public string  BlockReason
		{
			 get { return _blockReason; }
			 set
			 {
				 if (_blockReason != value)
				 {
					_blockReason = value;
					 PropertyHasChanged("BlockReason");
				 }
			 }
		}

		[DataMember]
		public Guid?  ApplicationUserID
		{
			 get { return _applicationUserID; }
			 set
			 {
				 if (_applicationUserID != value)
				 {
					_applicationUserID = value;
					 PropertyHasChanged("ApplicationUserID");
				 }
			 }
		}

		[DataMember]
		public decimal?  Turnover
		{
			 get { return _turnover; }
			 set
			 {
				 if (_turnover != value)
				 {
					_turnover = value;
					 PropertyHasChanged("Turnover");
				 }
			 }
		}

		[DataMember]
		public Guid?  DefaultRateID
		{
			 get { return _defaultRateID; }
			 set
			 {
				 if (_defaultRateID != value)
				 {
					_defaultRateID = value;
					 PropertyHasChanged("DefaultRateID");
				 }
			 }
		}

        [DataMember]
        public Guid? AddressID
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

        [DataMember]
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

        [DataMember]
        public string Fax
        {
            get { return _fax; }
            set
            {
                if (_fax != value)
                {
                    _fax = value;
                    PropertyHasChanged("Fax");
                }
            }
        }

        [DataMember]
        public string VoucherTitle
        {
            get { return _voucherTitle; }
            set
            {
                if (_voucherTitle != value)
                {
                    _voucherTitle = value;
                    PropertyHasChanged("VoucherTitle");
                }
            }
        }

        [DataMember]
        public string VoucherImage
        {
            get { return _voucherImage; }
            set
            {
                if (_voucherImage != value)
                {
                    _voucherImage = value;
                    PropertyHasChanged("VoucherImage");
                }
            }
        }

        [DataMember]
        public string MobileNo
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
        public string Department
        {
            get { return _department; }
            set
            {
                if (_department != value)
                {
                    _department = value;
                    PropertyHasChanged("Department");
                }
            }
        }

        [DataMember]
        public string Designation
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
		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("CorporateID", "CorporateID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Code", "Code",7));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CompanyName", "CompanyName",167));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Title", "Title",13));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("FName", "FName",75));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("LName", "LName",75));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("DisplayName", "DisplayName",167));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Notes", "Notes",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("BlockReason", "BlockReason",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"CorporateID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"CompanyID = {2}~\n"+
			"SeqNo = {3}~\n"+
			"IsSynch = {4}~\n"+
			"SynchOn = {5}~\n"+
			"UpdatedOn = {6}~\n"+
			"UpdatedBy = {7}~\n"+
			"IsActive = {8}~\n"+
			"Code = {9}~\n"+
			"CompanyName = {10}~\n"+
			"Title = {11}~\n"+
			"FName = {12}~\n"+
			"LName = {13}~\n"+
			"DisplayName = {14}~\n"+
			"CorporateType_TermID = {15}~\n"+
			"DBAcctID = {16}~\n"+
			"ComissionAcctID = {17}~\n"+
			"IsDirectBill = {18}~\n"+
			"IsComission = {19}~\n"+
			"IsComissionFlat = {20}~\n"+
			"ComissionValue = {21}~\n"+
			"ComissionFlag_TermID = {22}~\n"+
			"Notes = {23}~\n"+
			"DefaultResStatus_TermID = {24}~\n"+
			"IsBlock = {25}~\n"+
			"BlockReason = {26}~\n"+
			"ApplicationUserID = {27}~\n"+
			"Turnover = {28}~\n"+
            "DefaultRateID = {29}~\n" +
			"AddressID = {30}~\n" +
            "Email = {31}~\n" +
            "ContactNo = {32}~\n" +
            "Fax = {33}~\n" +
            "VoucherTitle = {34}~\n" +
            "VoucherImage = {35}~\n" +
            "MobileNo = {36}~\n" +
            "Department = {37}~\n" +
            "Designation = {38}~\n",

            CorporateID, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, Code, CompanyName, Title, FName, LName, DisplayName, CorporateType_TermID, DBAcctID, ComissionAcctID, IsDirectBill, IsComission, IsComissionFlat, ComissionValue, ComissionFlag_TermID, Notes, DefaultResStatus_TermID, IsBlock, BlockReason, ApplicationUserID, Turnover, DefaultRateID, AddressID, Email, ContactNo, Fax, VoucherTitle, VoucherImage, MobileNo, Department, Designation); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class CorporateKeys
	{

		#region Data Members

		Guid _corporateID;

		#endregion

		#region Constructor

		public CorporateKeys(Guid corporateID)
		{
			 _corporateID = corporateID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  CorporateID
		{
			 get { return _corporateID; }
		}

		#endregion

	}
}
