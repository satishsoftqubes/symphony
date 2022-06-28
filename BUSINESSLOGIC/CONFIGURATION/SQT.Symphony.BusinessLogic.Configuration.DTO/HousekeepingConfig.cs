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
	public class HousekeepingConfig: BusinessObjectBase
	{

		#region InnerClass
		public enum HousekeepingConfigFields
		{
			HKPConfigID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			IsSetDefaultHKP,
			IsAlternetDayHKP,
			HKPInterval,
			HKPType_TermID,
			DefaultTimeForFullHKP,
			DefaultTimeForMinimalHKP
		}
		#endregion

		#region Data Members

			Guid _hKPConfigID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			bool? _isSetDefaultHKP;
			bool? _isAlternetDayHKP;
			int? _hKPInterval;
			Guid? _hKPType_TermID;
			DateTime? _defaultTimeForFullHKP;
			DateTime? _defaultTimeForMinimalHKP;

		#endregion

		#region Properties

		[DataMember]
		public Guid  HKPConfigID
		{
			 get { return _hKPConfigID; }
			 set
			 {
				 if (_hKPConfigID != value)
				 {
					_hKPConfigID = value;
					 PropertyHasChanged("HKPConfigID");
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
		public bool?  IsSetDefaultHKP
		{
			 get { return _isSetDefaultHKP; }
			 set
			 {
				 if (_isSetDefaultHKP != value)
				 {
					_isSetDefaultHKP = value;
					 PropertyHasChanged("IsSetDefaultHKP");
				 }
			 }
		}

		[DataMember]
		public bool?  IsAlternetDayHKP
		{
			 get { return _isAlternetDayHKP; }
			 set
			 {
				 if (_isAlternetDayHKP != value)
				 {
					_isAlternetDayHKP = value;
					 PropertyHasChanged("IsAlternetDayHKP");
				 }
			 }
		}

		[DataMember]
		public int?  HKPInterval
		{
			 get { return _hKPInterval; }
			 set
			 {
				 if (_hKPInterval != value)
				 {
					_hKPInterval = value;
					 PropertyHasChanged("HKPInterval");
				 }
			 }
		}

		[DataMember]
		public Guid?  HKPType_TermID
		{
			 get { return _hKPType_TermID; }
			 set
			 {
				 if (_hKPType_TermID != value)
				 {
					_hKPType_TermID = value;
					 PropertyHasChanged("HKPType_TermID");
				 }
			 }
		}

		[DataMember]
		public DateTime?  DefaultTimeForFullHKP
		{
			 get { return _defaultTimeForFullHKP; }
			 set
			 {
				 if (_defaultTimeForFullHKP != value)
				 {
					_defaultTimeForFullHKP = value;
					 PropertyHasChanged("DefaultTimeForFullHKP");
				 }
			 }
		}

		[DataMember]
		public DateTime?  DefaultTimeForMinimalHKP
		{
			 get { return _defaultTimeForMinimalHKP; }
			 set
			 {
				 if (_defaultTimeForMinimalHKP != value)
				 {
					_defaultTimeForMinimalHKP = value;
					 PropertyHasChanged("DefaultTimeForMinimalHKP");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("HKPConfigID", "HKPConfigID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"HKPConfigID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"CompanyID = {2}~\n"+
			"SeqNo = {3}~\n"+
			"IsSynch = {4}~\n"+
			"SynchOn = {5}~\n"+
			"UpdatedOn = {6}~\n"+
			"UpdatedBy = {7}~\n"+
			"IsActive = {8}~\n"+
			"IsSetDefaultHKP = {9}~\n"+
			"IsAlternetDayHKP = {10}~\n"+
			"HKPInterval = {11}~\n"+
			"HKPType_TermID = {12}~\n"+
			"DefaultTimeForFullHKP = {13}~\n"+
			"DefaultTimeForMinimalHKP = {14}~\n",
			HKPConfigID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			IsSetDefaultHKP,			IsAlternetDayHKP,			HKPInterval,			HKPType_TermID,			DefaultTimeForFullHKP,			DefaultTimeForMinimalHKP);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class HousekeepingConfigKeys
	{

		#region Data Members

		Guid _hKPConfigID;

		#endregion

		#region Constructor

		public HousekeepingConfigKeys(Guid hKPConfigID)
		{
			 _hKPConfigID = hKPConfigID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  HKPConfigID
		{
			 get { return _hKPConfigID; }
		}

		#endregion

	}
}
