using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;
namespace SQT.Symphony.BusinessLogic.FrontDesk.DTO
{
	[DataContract]
	public class Guest: BusinessObjectBase
	{

		#region InnerClass
		public enum GuestFields
		{
			GuestID,
			Guest_TypeID,
			Title,
			FName,
			LName,
			GuestFullName,
			MName,
			DOB,
			Nationality,
			IDType1_TermID,
			IDType1,
			IDType2_TermID,
			IDType2,
			ScanID1,
			ScanID2,
			MaritalStatus_TermID,
			AnniversaryDate,
			Gender_TermID,
			Occupation_TermID,
			JobTitle,
			CompanyName,
			StaffReferenceID,
			GuestReferenceID,
			IsByReference,
			Email,
			Phone1,
			Phone2,
			FavouriteRoomID,
			GuestPhoto,
			GuestNotes,
			OtherNotes,
			IsBlocked,
			BlockReason,
			LastArrivalDate,
			LastReservationID,
			IsMainGuest,
			LastRateID,
			LastRate,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			TotalNight,
			BlockBy,
			BlockOn,
			IsSmoking,
			CompanySector,
			WorkLocation,
			WorkTiming,
			BloodGroup,
			MealPreference,
			ParentName,
			ParentContactNo,
			RefInvestorID,
			AddressID,
            LocalContactPerson,
            LocalContactNo,
            EmployeeID,
            Department
		}
		#endregion

		#region Data Members

			Guid _guestID;
			Guid? _guest_TypeID;
			string _title;
			string _fName;
			string _lName;
			string _guestFullName;
			string _mName;
			DateTime? _dOB;
			string _nationality;
			Guid? _iDType1_TermID;
			string _iDType1;
			Guid? _iDType2_TermID;
			string _iDType2;
			string _scanID1;
			string _scanID2;
			Guid? _maritalStatus_TermID;
			DateTime? _anniversaryDate;
			Guid? _gender_TermID;
			Guid? _occupation_TermID;
			string _jobTitle;
			string _companyName;
			Guid? _staffReferenceID;
			Guid? _guestReferenceID;
			bool? _isByReference;
			string _email;
			string _phone1;
			string _phone2;
			Guid? _favouriteRoomID;
			string _guestPhoto;
			string _guestNotes;
			string _otherNotes;
			bool? _isBlocked;
			string _blockReason;
			DateTime? _lastArrivalDate;
			Guid? _lastReservationID;
			bool? _isMainGuest;
			Guid? _lastRateID;
			decimal? _lastRate;
			Guid? _propertyID;
			Guid? _companyID;
			long _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			int? _totalNight;
			Guid? _blockBy;
			DateTime? _blockOn;
			bool? _isSmoking;
			Guid? _companySector;
			string _workLocation;
			Guid? _workTiming;
			string _bloodGroup;
			Guid? _mealPreference;
			string _parentName;
			string _parentContactNo;
			Guid? _refInvestorID;
			Guid? _addressID;
            string _localContactPerson;
            string _localContactNo;
            string _employeeID;
            string _department;

		#endregion

		#region Properties

		[DataMember]
		public Guid  GuestID
		{
			 get { return _guestID; }
			 set
			 {
				 if (_guestID != value)
				 {
					_guestID = value;
					 PropertyHasChanged("GuestID");
				 }
			 }
		}

		[DataMember]
		public Guid?  Guest_TypeID
		{
			 get { return _guest_TypeID; }
			 set
			 {
				 if (_guest_TypeID != value)
				 {
					_guest_TypeID = value;
					 PropertyHasChanged("Guest_TypeID");
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
		public string  GuestFullName
		{
			 get { return _guestFullName; }
			 set
			 {
				 if (_guestFullName != value)
				 {
					_guestFullName = value;
					 PropertyHasChanged("GuestFullName");
				 }
			 }
		}

		[DataMember]
		public string  MName
		{
			 get { return _mName; }
			 set
			 {
				 if (_mName != value)
				 {
					_mName = value;
					 PropertyHasChanged("MName");
				 }
			 }
		}

		[DataMember]
		public DateTime?  DOB
		{
			 get { return _dOB; }
			 set
			 {
				 if (_dOB != value)
				 {
					_dOB = value;
					 PropertyHasChanged("DOB");
				 }
			 }
		}

		[DataMember]
		public string  Nationality
		{
			 get { return _nationality; }
			 set
			 {
				 if (_nationality != value)
				 {
					_nationality = value;
					 PropertyHasChanged("Nationality");
				 }
			 }
		}

		[DataMember]
		public Guid?  IDType1_TermID
		{
			 get { return _iDType1_TermID; }
			 set
			 {
				 if (_iDType1_TermID != value)
				 {
					_iDType1_TermID = value;
					 PropertyHasChanged("IDType1_TermID");
				 }
			 }
		}

		[DataMember]
		public string  IDType1
		{
			 get { return _iDType1; }
			 set
			 {
				 if (_iDType1 != value)
				 {
					_iDType1 = value;
					 PropertyHasChanged("IDType1");
				 }
			 }
		}

		[DataMember]
		public Guid?  IDType2_TermID
		{
			 get { return _iDType2_TermID; }
			 set
			 {
				 if (_iDType2_TermID != value)
				 {
					_iDType2_TermID = value;
					 PropertyHasChanged("IDType2_TermID");
				 }
			 }
		}

		[DataMember]
		public string  IDType2
		{
			 get { return _iDType2; }
			 set
			 {
				 if (_iDType2 != value)
				 {
					_iDType2 = value;
					 PropertyHasChanged("IDType2");
				 }
			 }
		}

		[DataMember]
		public string  ScanID1
		{
			 get { return _scanID1; }
			 set
			 {
				 if (_scanID1 != value)
				 {
					_scanID1 = value;
					 PropertyHasChanged("ScanID1");
				 }
			 }
		}

		[DataMember]
		public string  ScanID2
		{
			 get { return _scanID2; }
			 set
			 {
				 if (_scanID2 != value)
				 {
					_scanID2 = value;
					 PropertyHasChanged("ScanID2");
				 }
			 }
		}

		[DataMember]
		public Guid?  MaritalStatus_TermID
		{
			 get { return _maritalStatus_TermID; }
			 set
			 {
				 if (_maritalStatus_TermID != value)
				 {
					_maritalStatus_TermID = value;
					 PropertyHasChanged("MaritalStatus_TermID");
				 }
			 }
		}

		[DataMember]
		public DateTime?  AnniversaryDate
		{
			 get { return _anniversaryDate; }
			 set
			 {
				 if (_anniversaryDate != value)
				 {
					_anniversaryDate = value;
					 PropertyHasChanged("AnniversaryDate");
				 }
			 }
		}

		[DataMember]
		public Guid?  Gender_TermID
		{
			 get { return _gender_TermID; }
			 set
			 {
				 if (_gender_TermID != value)
				 {
					_gender_TermID = value;
					 PropertyHasChanged("Gender_TermID");
				 }
			 }
		}

		[DataMember]
		public Guid?  Occupation_TermID
		{
			 get { return _occupation_TermID; }
			 set
			 {
				 if (_occupation_TermID != value)
				 {
					_occupation_TermID = value;
					 PropertyHasChanged("Occupation_TermID");
				 }
			 }
		}

		[DataMember]
		public string  JobTitle
		{
			 get { return _jobTitle; }
			 set
			 {
				 if (_jobTitle != value)
				 {
					_jobTitle = value;
					 PropertyHasChanged("JobTitle");
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
		public Guid?  StaffReferenceID
		{
			 get { return _staffReferenceID; }
			 set
			 {
				 if (_staffReferenceID != value)
				 {
					_staffReferenceID = value;
					 PropertyHasChanged("StaffReferenceID");
				 }
			 }
		}

		[DataMember]
		public Guid?  GuestReferenceID
		{
			 get { return _guestReferenceID; }
			 set
			 {
				 if (_guestReferenceID != value)
				 {
					_guestReferenceID = value;
					 PropertyHasChanged("GuestReferenceID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsByReference
		{
			 get { return _isByReference; }
			 set
			 {
				 if (_isByReference != value)
				 {
					_isByReference = value;
					 PropertyHasChanged("IsByReference");
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
		public string  Phone1
		{
			 get { return _phone1; }
			 set
			 {
				 if (_phone1 != value)
				 {
					_phone1 = value;
					 PropertyHasChanged("Phone1");
				 }
			 }
		}

		[DataMember]
		public string  Phone2
		{
			 get { return _phone2; }
			 set
			 {
				 if (_phone2 != value)
				 {
					_phone2 = value;
					 PropertyHasChanged("Phone2");
				 }
			 }
		}

		[DataMember]
		public Guid?  FavouriteRoomID
		{
			 get { return _favouriteRoomID; }
			 set
			 {
				 if (_favouriteRoomID != value)
				 {
					_favouriteRoomID = value;
					 PropertyHasChanged("FavouriteRoomID");
				 }
			 }
		}

		[DataMember]
		public string  GuestPhoto
		{
			 get { return _guestPhoto; }
			 set
			 {
				 if (_guestPhoto != value)
				 {
					_guestPhoto = value;
					 PropertyHasChanged("GuestPhoto");
				 }
			 }
		}

		[DataMember]
		public string  GuestNotes
		{
			 get { return _guestNotes; }
			 set
			 {
				 if (_guestNotes != value)
				 {
					_guestNotes = value;
					 PropertyHasChanged("GuestNotes");
				 }
			 }
		}

		[DataMember]
		public string  OtherNotes
		{
			 get { return _otherNotes; }
			 set
			 {
				 if (_otherNotes != value)
				 {
					_otherNotes = value;
					 PropertyHasChanged("OtherNotes");
				 }
			 }
		}

		[DataMember]
		public bool?  IsBlocked
		{
			 get { return _isBlocked; }
			 set
			 {
				 if (_isBlocked != value)
				 {
					_isBlocked = value;
					 PropertyHasChanged("IsBlocked");
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
		public DateTime?  LastArrivalDate
		{
			 get { return _lastArrivalDate; }
			 set
			 {
				 if (_lastArrivalDate != value)
				 {
					_lastArrivalDate = value;
					 PropertyHasChanged("LastArrivalDate");
				 }
			 }
		}

		[DataMember]
		public Guid?  LastReservationID
		{
			 get { return _lastReservationID; }
			 set
			 {
				 if (_lastReservationID != value)
				 {
					_lastReservationID = value;
					 PropertyHasChanged("LastReservationID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsMainGuest
		{
			 get { return _isMainGuest; }
			 set
			 {
				 if (_isMainGuest != value)
				 {
					_isMainGuest = value;
					 PropertyHasChanged("IsMainGuest");
				 }
			 }
		}

		[DataMember]
		public Guid?  LastRateID
		{
			 get { return _lastRateID; }
			 set
			 {
				 if (_lastRateID != value)
				 {
					_lastRateID = value;
					 PropertyHasChanged("LastRateID");
				 }
			 }
		}

		[DataMember]
		public decimal?  LastRate
		{
			 get { return _lastRate; }
			 set
			 {
				 if (_lastRate != value)
				 {
					_lastRate = value;
					 PropertyHasChanged("LastRate");
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
		public long  SeqNo
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
		public int?  TotalNight
		{
			 get { return _totalNight; }
			 set
			 {
				 if (_totalNight != value)
				 {
					_totalNight = value;
					 PropertyHasChanged("TotalNight");
				 }
			 }
		}

		[DataMember]
		public Guid?  BlockBy
		{
			 get { return _blockBy; }
			 set
			 {
				 if (_blockBy != value)
				 {
					_blockBy = value;
					 PropertyHasChanged("BlockBy");
				 }
			 }
		}

		[DataMember]
		public DateTime?  BlockOn
		{
			 get { return _blockOn; }
			 set
			 {
				 if (_blockOn != value)
				 {
					_blockOn = value;
					 PropertyHasChanged("BlockOn");
				 }
			 }
		}

		[DataMember]
		public bool?  IsSmoking
		{
			 get { return _isSmoking; }
			 set
			 {
				 if (_isSmoking != value)
				 {
					_isSmoking = value;
					 PropertyHasChanged("IsSmoking");
				 }
			 }
		}

		[DataMember]
		public Guid?  CompanySector
		{
			 get { return _companySector; }
			 set
			 {
				 if (_companySector != value)
				 {
					_companySector = value;
					 PropertyHasChanged("CompanySector");
				 }
			 }
		}

		[DataMember]
		public string  WorkLocation
		{
			 get { return _workLocation; }
			 set
			 {
				 if (_workLocation != value)
				 {
					_workLocation = value;
					 PropertyHasChanged("WorkLocation");
				 }
			 }
		}

		[DataMember]
		public Guid?  WorkTiming
		{
			 get { return _workTiming; }
			 set
			 {
				 if (_workTiming != value)
				 {
					_workTiming = value;
					 PropertyHasChanged("WorkTiming");
				 }
			 }
		}

		[DataMember]
		public string  BloodGroup
		{
			 get { return _bloodGroup; }
			 set
			 {
				 if (_bloodGroup != value)
				 {
					_bloodGroup = value;
					 PropertyHasChanged("BloodGroup");
				 }
			 }
		}

		[DataMember]
		public Guid?  MealPreference
		{
			 get { return _mealPreference; }
			 set
			 {
				 if (_mealPreference != value)
				 {
					_mealPreference = value;
					 PropertyHasChanged("MealPreference");
				 }
			 }
		}

		[DataMember]
		public string  ParentName
		{
			 get { return _parentName; }
			 set
			 {
				 if (_parentName != value)
				 {
					_parentName = value;
					 PropertyHasChanged("ParentName");
				 }
			 }
		}

		[DataMember]
		public string  ParentContactNo
		{
			 get { return _parentContactNo; }
			 set
			 {
				 if (_parentContactNo != value)
				 {
					_parentContactNo = value;
					 PropertyHasChanged("ParentContactNo");
				 }
			 }
		}

		[DataMember]
		public Guid?  RefInvestorID
		{
			 get { return _refInvestorID; }
			 set
			 {
				 if (_refInvestorID != value)
				 {
					_refInvestorID = value;
					 PropertyHasChanged("RefInvestorID");
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
        public string LocalContactPerson
        {
            get { return _localContactPerson; }
            set
            {
                if (_localContactPerson != value)
                {
                    _localContactPerson = value;
                    PropertyHasChanged("LocalContactPerson");
                }
            }
        }

        [DataMember]
        public string LocalContactNo
        {
            get { return _localContactNo; }
            set
            {
                if (_localContactNo != value)
                {
                    _localContactNo = value;
                    PropertyHasChanged("LocalContactNo");
                }
            }
        }

        [DataMember]
        public string EmployeeID
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
		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("GuestID", "GuestID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Title", "Title",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("FName", "FName",120));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("LName", "LName",120));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("GuestFullName", "GuestFullName",500));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("MName", "MName",120));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Nationality", "Nationality",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("IDType1", "IDType1",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("IDType2", "IDType2",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ScanID1", "ScanID1",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ScanID2", "ScanID2",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("JobTitle", "JobTitle",320));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CompanyName", "CompanyName",320));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Email", "Email",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Phone1", "Phone1",20));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Phone2", "Phone2",20));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("GuestPhoto", "GuestPhoto",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("GuestNotes", "GuestNotes",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("OtherNotes", "OtherNotes",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("BlockReason", "BlockReason",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("WorkLocation", "WorkLocation",150));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("BloodGroup", "BloodGroup",10));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ParentName", "ParentName",250));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ParentContactNo", "ParentContactNo",15));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"GuestID = {0}\n"+
			"Guest_TypeID = {1}\n"+
			"Title = {2}\n"+
			"FName = {3}\n"+
			"LName = {4}\n"+
			"GuestFullName = {5}\n"+
			"MName = {6}\n"+
			"DOB = {7}\n"+
			"Nationality = {8}\n"+
			"IDType1_TermID = {9}\n"+
			"IDType1 = {10}\n"+
			"IDType2_TermID = {11}\n"+
			"IDType2 = {12}\n"+
			"ScanID1 = {13}\n"+
			"ScanID2 = {14}\n"+
			"MaritalStatus_TermID = {15}\n"+
			"AnniversaryDate = {16}\n"+
			"Gender_TermID = {17}\n"+
			"Occupation_TermID = {18}\n"+
			"JobTitle = {19}\n"+
			"CompanyName = {20}\n"+
			"StaffReferenceID = {21}\n"+
			"GuestReferenceID = {22}\n"+
			"IsByReference = {23}\n"+
			"Email = {24}\n"+
			"Phone1 = {25}\n"+
			"Phone2 = {26}\n"+
			"FavouriteRoomID = {27}\n"+
			"GuestPhoto = {28}\n"+
			"GuestNotes = {29}\n"+
			"OtherNotes = {30}\n"+
			"IsBlocked = {31}\n"+
			"BlockReason = {32}\n"+
			"LastArrivalDate = {33}\n"+
			"LastReservationID = {34}\n"+
			"IsMainGuest = {35}\n"+
			"LastRateID = {36}\n"+
			"LastRate = {37}\n"+
			"PropertyID = {38}\n"+
			"CompanyID = {39}\n"+
			"SeqNo = {40}\n"+
			"IsSynch = {41}\n"+
			"SynchOn = {42}\n"+
			"UpdatedOn = {43}\n"+
			"UpdatedBy = {44}\n"+
			"IsActive = {45}\n"+
			"TotalNight = {46}\n"+
			"BlockBy = {47}\n"+
			"BlockOn = {48}\n"+
			"IsSmoking = {49}\n"+
			"CompanySector = {50}\n"+
			"WorkLocation = {51}\n"+
			"WorkTiming = {52}\n"+
			"BloodGroup = {53}\n"+
			"MealPreference = {54}\n"+
			"ParentName = {55}\n"+
			"ParentContactNo = {56}\n"+
			"RefInvestorID = {57}\n"+
			"AddressID = {58}\n"+
            "LocalContactPerson = {59}\n" +
            "LocalContactNo = {60}\n" +
            "EmployeeID = {61}\n" +
            "Department = {62}\n",
            GuestID, Guest_TypeID, Title, FName, LName, GuestFullName, MName, DOB, Nationality, IDType1_TermID, IDType1, IDType2_TermID, IDType2, ScanID1, ScanID2, MaritalStatus_TermID, AnniversaryDate, Gender_TermID, Occupation_TermID, JobTitle, CompanyName, StaffReferenceID, GuestReferenceID, IsByReference, Email, Phone1, Phone2, FavouriteRoomID, GuestPhoto, GuestNotes, OtherNotes, IsBlocked, BlockReason, LastArrivalDate, LastReservationID, IsMainGuest, LastRateID, LastRate, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, TotalNight, BlockBy, BlockOn, IsSmoking, CompanySector, WorkLocation, WorkTiming, BloodGroup, MealPreference, ParentName, ParentContactNo, RefInvestorID, AddressID, LocalContactPerson, LocalContactNo, EmployeeID, Department); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class GuestKeys
	{

		#region Data Members

		Guid _guestID;

		#endregion

		#region Constructor

		public GuestKeys(Guid guestID)
		{
			 _guestID = guestID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  GuestID
		{
			 get { return _guestID; }
		}

		#endregion

	}
}
