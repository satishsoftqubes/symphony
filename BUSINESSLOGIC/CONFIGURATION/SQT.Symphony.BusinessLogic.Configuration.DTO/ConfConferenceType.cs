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
	public class ConfConferenceType: BusinessObjectBase
	{

		#region InnerClass
		public enum ConfConferenceTypeFields
		{
			ConfConferenceTypeID,
			ConferenceID,
			ConferenceTypeID,
			Capacity,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive
		}
		#endregion

		#region Data Members

			Guid _confConferenceTypeID;
			Guid? _conferenceID;
			Guid _conferenceTypeID;
			int? _capacity;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;

		#endregion

		#region Properties

		[DataMember]
		public Guid  ConfConferenceTypeID
		{
			 get { return _confConferenceTypeID; }
			 set
			 {
				 if (_confConferenceTypeID != value)
				 {
					_confConferenceTypeID = value;
					 PropertyHasChanged("ConfConferenceTypeID");
				 }
			 }
		}

		[DataMember]
		public Guid?  ConferenceID
		{
			 get { return _conferenceID; }
			 set
			 {
				 if (_conferenceID != value)
				 {
					_conferenceID = value;
					 PropertyHasChanged("ConferenceID");
				 }
			 }
		}

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
		public int?  Capacity
		{
			 get { return _capacity; }
			 set
			 {
				 if (_capacity != value)
				 {
					_capacity = value;
					 PropertyHasChanged("Capacity");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ConfConferenceTypeID", "ConfConferenceTypeID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ConferenceTypeID", "ConferenceTypeID"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ConfConferenceTypeID = {0}~\n"+
			"ConferenceID = {1}~\n"+
			"ConferenceTypeID = {2}~\n"+
			"Capacity = {3}~\n"+
			"IsSynch = {4}~\n"+
			"SynchOn = {5}~\n"+
			"UpdatedOn = {6}~\n"+
			"UpdatedBy = {7}~\n"+
			"IsActive = {8}~\n",
			ConfConferenceTypeID,			ConferenceID,			ConferenceTypeID,			Capacity,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ConfConferenceTypeKeys
	{

		#region Data Members

		Guid _confConferenceTypeID;

		#endregion

		#region Constructor

		public ConfConferenceTypeKeys(Guid confConferenceTypeID)
		{
			 _confConferenceTypeID = confConferenceTypeID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ConfConferenceTypeID
		{
			 get { return _confConferenceTypeID; }
		}

		#endregion

	}
}
