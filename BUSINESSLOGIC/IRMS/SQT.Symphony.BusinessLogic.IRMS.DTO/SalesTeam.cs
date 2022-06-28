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
	public class SalesTeam: BusinessObjectBase
	{

		#region InnerClass
		public enum SalesTeamFields
		{
			SalesTeamID,
			Title,
			FName,
			LName,
			DisplayName,
			Thumb,
			MobileNo,
			LandLineNo,
			Email,
			AddressID,
			UserID,
			IsActive,
			CreatedOn,
			UpdatedOn,
			CreatedBy,
			UpdatedBy,
			UpdateLog,
			SeqNo,
			CompanyID
		}
		#endregion

		#region Data Members

			Guid _salesTeamID;
			string _title;
			string _fName;
			string _lName;
			string _displayName;
			string _thumb;
			string _mobileNo;
			string _landLineNo;
			string _email;
			Guid? _addressID;
			Guid? _userID;
			bool? _isActive;
			DateTime? _createdOn;
			DateTime? _updatedOn;
			Guid? _createdBy;
			Guid? _updatedBy;
			byte[] _updateLog;
			int _seqNo;
			Guid? _companyID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  SalesTeamID
		{
			 get { return _salesTeamID; }
			 set
			 {
				 if (_salesTeamID != value)
				 {
					_salesTeamID = value;
					 PropertyHasChanged("SalesTeamID");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SalesTeamID", "SalesTeamID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Title", "Title",5));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("FName", "FName",150));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("LName", "LName",150));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("DisplayName", "DisplayName",250));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Thumb", "Thumb",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("MobileNo", "MobileNo",17));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("LandLineNo", "LandLineNo",17));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Email", "Email",350));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"SalesTeamID = {0}\n"+
			"Title = {1}\n"+
			"FName = {2}\n"+
			"LName = {3}\n"+
			"DisplayName = {4}\n"+
			"Thumb = {5}\n"+
			"MobileNo = {6}\n"+
			"LandLineNo = {7}\n"+
			"Email = {8}\n"+
			"AddressID = {9}\n"+
			"UserID = {10}\n"+
			"IsActive = {11}\n"+
			"CreatedOn = {12}\n"+
			"UpdatedOn = {13}\n"+
			"CreatedBy = {14}\n"+
			"UpdatedBy = {15}\n"+
			"UpdateLog = {16}\n"+
			"SeqNo = {17}\n"+
			"CompanyID = {18}\n",
			SalesTeamID,			Title,			FName,			LName,			DisplayName,			Thumb,			MobileNo,			LandLineNo,			Email,			AddressID,			UserID,			IsActive,			CreatedOn,			UpdatedOn,			CreatedBy,			UpdatedBy,			UpdateLog,			SeqNo,			CompanyID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class SalesTeamKeys
	{

		#region Data Members

		Guid _salesTeamID;

		#endregion

		#region Constructor

		public SalesTeamKeys(Guid salesTeamID)
		{
			 _salesTeamID = salesTeamID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  SalesTeamID
		{
			 get { return _salesTeamID; }
		}

		#endregion

	}
}
