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
	public class RentPayoutQuarterSetup: BusinessObjectBase
	{

		#region InnerClass
		public enum RentPayoutQuarterSetupFields
		{
			QuarterID,
			Title,
			StartDate,
			EndDate,
			Note,
			PropertyManagementCharge,
			PropertyID,
			CompanyID,
			SeqNo,
			IsActive,
			CreatedOn,
			CreatedBy,
			UpdatedOn,
			UpdatedBy,
			IsSync,
			SyncOn
		}
		#endregion

		#region Data Members

			Guid _quarterID;
			string _title;
			DateTime? _startDate;
			DateTime? _endDate;
			string _note;
			decimal? _propertyManagementCharge;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isActive;
			DateTime? _createdOn;
			Guid? _createdBy;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isSync;
			DateTime? _syncOn;

		#endregion

		#region Properties

		[DataMember]
		public Guid  QuarterID
		{
			 get { return _quarterID; }
			 set
			 {
				 if (_quarterID != value)
				 {
					_quarterID = value;
					 PropertyHasChanged("QuarterID");
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
		public DateTime?  StartDate
		{
			 get { return _startDate; }
			 set
			 {
				 if (_startDate != value)
				 {
					_startDate = value;
					 PropertyHasChanged("StartDate");
				 }
			 }
		}

		[DataMember]
		public DateTime?  EndDate
		{
			 get { return _endDate; }
			 set
			 {
				 if (_endDate != value)
				 {
					_endDate = value;
					 PropertyHasChanged("EndDate");
				 }
			 }
		}

		[DataMember]
		public string  Note
		{
			 get { return _note; }
			 set
			 {
				 if (_note != value)
				 {
					_note = value;
					 PropertyHasChanged("Note");
				 }
			 }
		}

		[DataMember]
		public decimal?  PropertyManagementCharge
		{
			 get { return _propertyManagementCharge; }
			 set
			 {
				 if (_propertyManagementCharge != value)
				 {
					_propertyManagementCharge = value;
					 PropertyHasChanged("PropertyManagementCharge");
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
		public bool?  IsSync
		{
			 get { return _isSync; }
			 set
			 {
				 if (_isSync != value)
				 {
					_isSync = value;
					 PropertyHasChanged("IsSync");
				 }
			 }
		}

		[DataMember]
		public DateTime?  SyncOn
		{
			 get { return _syncOn; }
			 set
			 {
				 if (_syncOn != value)
				 {
					_syncOn = value;
					 PropertyHasChanged("SyncOn");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("QuarterID", "QuarterID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Title", "Title",150));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Note", "Note",250));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"QuarterID = {0}\n"+
			"Title = {1}\n"+
			"StartDate = {2}\n"+
			"EndDate = {3}\n"+
			"Note = {4}\n"+
			"PropertyManagementCharge = {5}\n"+
			"PropertyID = {6}\n"+
			"CompanyID = {7}\n"+
			"SeqNo = {8}\n"+
			"IsActive = {9}\n"+
			"CreatedOn = {10}\n"+
			"CreatedBy = {11}\n"+
			"UpdatedOn = {12}\n"+
			"UpdatedBy = {13}\n"+
			"IsSync = {14}\n"+
			"SyncOn = {15}\n",
			QuarterID,			Title,			StartDate,			EndDate,			Note,			PropertyManagementCharge,			PropertyID,			CompanyID,			SeqNo,			IsActive,			CreatedOn,			CreatedBy,			UpdatedOn,			UpdatedBy,			IsSync,			SyncOn);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class RentPayoutQuarterSetupKeys
	{

		#region Data Members

		Guid _quarterID;

		#endregion

		#region Constructor

		public RentPayoutQuarterSetupKeys(Guid quarterID)
		{
			 _quarterID = quarterID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  QuarterID
		{
			 get { return _quarterID; }
		}

		#endregion

	}
}
