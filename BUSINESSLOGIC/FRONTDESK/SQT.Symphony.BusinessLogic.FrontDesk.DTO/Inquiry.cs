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
	public class Inquiry: BusinessObjectBase
	{

		#region InnerClass
		public enum InquiryFields
		{
			InqID,
			Title,
			FName,
			LName,
			GuestFullName,
			Email,
			Phone,
			Company_Name,
			ArrivalDate,
			DepartureDate,
			Inq_StatusTerm,
			CreatedOn,
			CreatedBy,
			UpdatedOn,
			UpdatedBy,
			GenderTermID,
			SeqNo,
			CompanyID,
			PropertyID,
			IsActive,
            EmailDatabase_TermID
		}
		#endregion

		#region Data Members

			Guid _inqID;
			string _title;
			string _fName;
			string _lName;
			string _guestFullName;
			string _email;
			string _phone;
			string _company_Name;
			DateTime? _arrivalDate;
			DateTime? _departureDate;
			string _inq_StatusTerm;
			DateTime? _createdOn;
			Guid? _createdBy;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			Guid? _genderTermID;
			int _seqNo;
			Guid? _companyID;
			Guid? _propertyID;
			bool? _isActive;
            Guid? _emailDatabase_TermID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  InqID
		{
			 get { return _inqID; }
			 set
			 {
				 if (_inqID != value)
				 {
					_inqID = value;
					 PropertyHasChanged("InqID");
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
		public string  Phone
		{
			 get { return _phone; }
			 set
			 {
				 if (_phone != value)
				 {
					_phone = value;
					 PropertyHasChanged("Phone");
				 }
			 }
		}

		[DataMember]
		public string  Company_Name
		{
			 get { return _company_Name; }
			 set
			 {
				 if (_company_Name != value)
				 {
					_company_Name = value;
					 PropertyHasChanged("Company_Name");
				 }
			 }
		}

		[DataMember]
		public DateTime?  ArrivalDate
		{
			 get { return _arrivalDate; }
			 set
			 {
				 if (_arrivalDate != value)
				 {
					_arrivalDate = value;
					 PropertyHasChanged("ArrivalDate");
				 }
			 }
		}

		[DataMember]
		public DateTime?  DepartureDate
		{
			 get { return _departureDate; }
			 set
			 {
				 if (_departureDate != value)
				 {
					_departureDate = value;
					 PropertyHasChanged("DepartureDate");
				 }
			 }
		}

		[DataMember]
		public string  Inq_StatusTerm
		{
			 get { return _inq_StatusTerm; }
			 set
			 {
				 if (_inq_StatusTerm != value)
				 {
					_inq_StatusTerm = value;
					 PropertyHasChanged("Inq_StatusTerm");
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
		public Guid?  GenderTermID
		{
			 get { return _genderTermID; }
			 set
			 {
				 if (_genderTermID != value)
				 {
					_genderTermID = value;
					 PropertyHasChanged("GenderTermID");
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
        public Guid? EmailDatabase_TermID
		{
			 get { return _emailDatabase_TermID; }
			 set
			 {
                 if (_emailDatabase_TermID != value)
				 {
                     _emailDatabase_TermID = value;
                    PropertyHasChanged("EmailDatabase_TermID");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("InqID", "InqID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Title", "Title",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("FName", "FName",120));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("LName", "LName",120));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("GuestFullName", "GuestFullName",500));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Email", "Email",250));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Phone", "Phone",20));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Company_Name", "Company_Name",500));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Inq_StatusTerm", "Inq_StatusTerm",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"InqID = {0}\n"+
			"Title = {1}\n"+
			"FName = {2}\n"+
			"LName = {3}\n"+
			"GuestFullName = {4}\n"+
			"Email = {5}\n"+
			"Phone = {6}\n"+
			"Company_Name = {7}\n"+
			"ArrivalDate = {8}\n"+
			"DepartureDate = {9}\n"+
			"Inq_StatusTerm = {10}\n"+
			"CreatedOn = {11}\n"+
			"CreatedBy = {12}\n"+
			"UpdatedOn = {13}\n"+
			"UpdatedBy = {14}\n"+
			"GenderTermID = {15}\n"+
			"SeqNo = {16}\n"+
			"CompanyID = {17}\n"+
			"PropertyID = {18}\n"+
			"IsActive = {19}\n"+
            "EmailDatabase_TermID = {20}\n",
            InqID, Title, FName, LName, GuestFullName, Email, Phone, Company_Name, ArrivalDate, DepartureDate, Inq_StatusTerm, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, GenderTermID, SeqNo, CompanyID, PropertyID, IsActive, EmailDatabase_TermID); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class InquiryKeys
	{

		#region Data Members

		Guid _inqID;

		#endregion

		#region Constructor

		public InquiryKeys(Guid inqID)
		{
			 _inqID = inqID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  InqID
		{
			 get { return _inqID; }
		}

		#endregion

	}
}
