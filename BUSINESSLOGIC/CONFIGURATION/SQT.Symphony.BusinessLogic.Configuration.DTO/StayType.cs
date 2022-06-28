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
	public class StayType: BusinessObjectBase
	{

		#region InnerClass
		public enum StayTypeFields
		{
			StayTypeID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			Code,
			StayTypeName,
			MinDays,
			MaxDays,
			Details,
			IsDefault
		}
		#endregion

		#region Data Members

			Guid _stayTypeID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			string _code;
			string _stayTypeName;
			int? _minDays;
			int? _maxDays;
			string _details;
			bool? _isDefault;

		#endregion

		#region Properties

		[DataMember]
		public Guid  StayTypeID
		{
			 get { return _stayTypeID; }
			 set
			 {
				 if (_stayTypeID != value)
				 {
					_stayTypeID = value;
					 PropertyHasChanged("StayTypeID");
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
		public string  StayTypeName
		{
			 get { return _stayTypeName; }
			 set
			 {
				 if (_stayTypeName != value)
				 {
					_stayTypeName = value;
					 PropertyHasChanged("StayTypeName");
				 }
			 }
		}

		[DataMember]
		public int?  MinDays
		{
			 get { return _minDays; }
			 set
			 {
				 if (_minDays != value)
				 {
					_minDays = value;
					 PropertyHasChanged("MinDays");
				 }
			 }
		}

		[DataMember]
		public int?  MaxDays
		{
			 get { return _maxDays; }
			 set
			 {
				 if (_maxDays != value)
				 {
					_maxDays = value;
					 PropertyHasChanged("MaxDays");
				 }
			 }
		}

		[DataMember]
		public string  Details
		{
			 get { return _details; }
			 set
			 {
				 if (_details != value)
				 {
					_details = value;
					 PropertyHasChanged("Details");
				 }
			 }
		}

		[DataMember]
		public bool?  IsDefault
		{
			 get { return _isDefault; }
			 set
			 {
				 if (_isDefault != value)
				 {
					_isDefault = value;
					 PropertyHasChanged("IsDefault");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("StayTypeID", "StayTypeID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Code", "Code",7));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("StayTypeName", "StayTypeName",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Details", "Details",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
            "StayTypeID = {0}~\n" +
            "PropertyID = {1}~\n" +
            "CompanyID = {2}~\n" +
            "SeqNo = {3}~\n" +
            "IsSynch = {4}~\n" +
            "SynchOn = {5}~\n" +
            "UpdatedOn = {6}~\n" +
            "UpdatedBy = {7}~\n" +
            "IsActive = {8}~\n" +
            "Code = {9}~\n" +
            "StayTypeName = {10}~\n" +
            "MinDays = {11}~\n" +
            "MaxDays = {12}~\n" +
            "Details = {13}~\n" +
            "IsDefault = {14}~\n",
			StayTypeID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			Code,			StayTypeName,			MinDays,			MaxDays,			Details,			IsDefault);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class StayTypeKeys
	{

		#region Data Members

		Guid _stayTypeID;

		#endregion

		#region Constructor

		public StayTypeKeys(Guid stayTypeID)
		{
			 _stayTypeID = stayTypeID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  StayTypeID
		{
			 get { return _stayTypeID; }
		}

		#endregion

	}
}
