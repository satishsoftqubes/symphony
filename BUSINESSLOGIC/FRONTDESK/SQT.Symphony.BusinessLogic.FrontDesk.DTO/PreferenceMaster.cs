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
	public class PreferenceMaster: BusinessObjectBase
	{

		#region InnerClass
		public enum PreferenceMasterFields
		{
			PreferenceID,
			PreferenceName,
			PreferenceDetails,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive
		}
		#endregion

		#region Data Members

			Guid _preferenceID;
			string _preferenceName;
			string _preferenceDetails;
			Guid? _propertyID;
			Guid? _companyID;
			long _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;

		#endregion

		#region Properties

		[DataMember]
		public Guid  PreferenceID
		{
			 get { return _preferenceID; }
			 set
			 {
				 if (_preferenceID != value)
				 {
					_preferenceID = value;
					 PropertyHasChanged("PreferenceID");
				 }
			 }
		}

		[DataMember]
		public string  PreferenceName
		{
			 get { return _preferenceName; }
			 set
			 {
				 if (_preferenceName != value)
				 {
					_preferenceName = value;
					 PropertyHasChanged("PreferenceName");
				 }
			 }
		}

		[DataMember]
		public string  PreferenceDetails
		{
			 get { return _preferenceDetails; }
			 set
			 {
				 if (_preferenceDetails != value)
				 {
					_preferenceDetails = value;
					 PropertyHasChanged("PreferenceDetails");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("PreferenceID", "PreferenceID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PreferenceName", "PreferenceName",120));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PreferenceDetails", "PreferenceDetails",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"PreferenceID = {0}\n"+
			"PreferenceName = {1}\n"+
			"PreferenceDetails = {2}\n"+
			"PropertyID = {3}\n"+
			"CompanyID = {4}\n"+
			"SeqNo = {5}\n"+
			"IsSynch = {6}\n"+
			"SynchOn = {7}\n"+
			"UpdatedOn = {8}\n"+
			"UpdatedBy = {9}\n"+
			"IsActive = {10}\n",
			PreferenceID,			PreferenceName,			PreferenceDetails,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class PreferenceMasterKeys
	{

		#region Data Members

		Guid _preferenceID;

		#endregion

		#region Constructor

		public PreferenceMasterKeys(Guid preferenceID)
		{
			 _preferenceID = preferenceID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  PreferenceID
		{
			 get { return _preferenceID; }
		}

		#endregion

	}
}
