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
	public class GuestPreference: BusinessObjectBase
	{

		#region InnerClass
		public enum GuestPreferenceFields
		{
			GuestPrefID,
			GuestID,
			PreferenceID,
			Preference,
			PreferenceDetail,
			Comments,
			DateToSet,
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

			Guid _guestPrefID;
			Guid? _guestID;
			Guid? _preferenceID;
			string _preference;
			string _preferenceDetail;
			string _comments;
			DateTime? _dateToSet;
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
		public Guid  GuestPrefID
		{
			 get { return _guestPrefID; }
			 set
			 {
				 if (_guestPrefID != value)
				 {
					_guestPrefID = value;
					 PropertyHasChanged("GuestPrefID");
				 }
			 }
		}

		[DataMember]
		public Guid?  GuestID
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
		public Guid?  PreferenceID
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
		public string  Preference
		{
			 get { return _preference; }
			 set
			 {
				 if (_preference != value)
				 {
					_preference = value;
					 PropertyHasChanged("Preference");
				 }
			 }
		}

		[DataMember]
		public string  PreferenceDetail
		{
			 get { return _preferenceDetail; }
			 set
			 {
				 if (_preferenceDetail != value)
				 {
					_preferenceDetail = value;
					 PropertyHasChanged("PreferenceDetail");
				 }
			 }
		}

		[DataMember]
		public string  Comments
		{
			 get { return _comments; }
			 set
			 {
				 if (_comments != value)
				 {
					_comments = value;
					 PropertyHasChanged("Comments");
				 }
			 }
		}

		[DataMember]
		public DateTime?  DateToSet
		{
			 get { return _dateToSet; }
			 set
			 {
				 if (_dateToSet != value)
				 {
					_dateToSet = value;
					 PropertyHasChanged("DateToSet");
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("GuestPrefID", "GuestPrefID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Preference", "Preference",120));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PreferenceDetail", "PreferenceDetail",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Comments", "Comments",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"GuestPrefID = {0}\n"+
			"GuestID = {1}\n"+
			"PreferenceID = {2}\n"+
			"Preference = {3}\n"+
			"PreferenceDetail = {4}\n"+
			"Comments = {5}\n"+
			"DateToSet = {6}\n"+
			"PropertyID = {7}\n"+
			"CompanyID = {8}\n"+
			"SeqNo = {9}\n"+
			"IsSynch = {10}\n"+
			"SynchOn = {11}\n"+
			"UpdatedOn = {12}\n"+
			"UpdatedBy = {13}\n"+
			"IsActive = {14}\n",
			GuestPrefID,			GuestID,			PreferenceID,			Preference,			PreferenceDetail,			Comments,			DateToSet,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class GuestPreferenceKeys
	{

		#region Data Members

		Guid _guestPrefID;

		#endregion

		#region Constructor

		public GuestPreferenceKeys(Guid guestPrefID)
		{
			 _guestPrefID = guestPrefID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  GuestPrefID
		{
			 get { return _guestPrefID; }
		}

		#endregion

	}
}
