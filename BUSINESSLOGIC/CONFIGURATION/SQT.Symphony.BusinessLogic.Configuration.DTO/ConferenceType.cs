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
	public class ConferenceType: BusinessObjectBase
	{

		#region InnerClass
		public enum ConferenceTypeFields
		{
			ConferenceTypeID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			ConferenceTypeName,
			MaximumCapacity
		}
		#endregion

		#region Data Members

			Guid _conferenceTypeID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			string _conferenceTypeName;
			int? _maximumCapacity;

		#endregion

		#region Properties

		[DataMember]
		public Guid  ConferenceTypeID
		{
			 get { return _conferenceTypeID; }
			 set
			 {
				 if (_conferenceTypeID != value)
				 {
					_conferenceTypeID = value;
					 PropertyHasChanged("ConferenceTypeID");
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
		public string  ConferenceTypeName
		{
			 get { return _conferenceTypeName; }
			 set
			 {
				 if (_conferenceTypeName != value)
				 {
					_conferenceTypeName = value;
					 PropertyHasChanged("ConferenceTypeName");
				 }
			 }
		}

		[DataMember]
		public int?  MaximumCapacity
		{
			 get { return _maximumCapacity; }
			 set
			 {
				 if (_maximumCapacity != value)
				 {
					_maximumCapacity = value;
					 PropertyHasChanged("MaximumCapacity");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ConferenceTypeID", "ConferenceTypeID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ConferenceTypeName", "ConferenceTypeName",120));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ConferenceTypeID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"CompanyID = {2}~\n"+
			"SeqNo = {3}~\n"+
			"IsSynch = {4}~\n"+
			"SynchOn = {5}~\n"+
			"UpdatedOn = {6}~\n"+
			"UpdatedBy = {7}~\n"+
			"IsActive = {8}~\n"+
			"ConferenceTypeName = {9}~\n"+
			"MaximumCapacity = {10}~\n",
			ConferenceTypeID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			ConferenceTypeName,			MaximumCapacity);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ConferenceTypeKeys
	{

		#region Data Members

		Guid _conferenceTypeID;

		#endregion

		#region Constructor

		public ConferenceTypeKeys(Guid conferenceTypeID)
		{
			 _conferenceTypeID = conferenceTypeID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ConferenceTypeID
		{
			 get { return _conferenceTypeID; }
		}

		#endregion

	}
}
