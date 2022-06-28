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
	public class ResCancellationPolicy: BusinessObjectBase
	{

		#region InnerClass
		public enum ResCancellationPolicyFields
		{
			ResPolicyID,
			CompanyID,
			PropertyID,
			ResType_TermID,
			MinHrs,
			MaxHrs,
			CancellationCharges,
			IsFlatCharge,
			ChargesApply_TermID,
			IsActive,
			IsSynch,
			SynchOn,
			UpdatedOn,
			SeqNo,
			UpdatedBy,
			CreatedBy,
			CreatedOn
		}
		#endregion

		#region Data Members

			Guid _resPolicyID;
			Guid? _companyID;
			Guid? _propertyID;
			Guid? _resType_TermID;
			int? _minHrs;
			int? _maxHrs;
			decimal? _cancellationCharges;
			bool? _isFlatCharge;
			Guid? _chargesApply_TermID;
			bool? _isActive;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			int _seqNo;
			Guid? _updatedBy;
			Guid? _createdBy;
			DateTime? _createdOn;

		#endregion

		#region Properties

		[DataMember]
		public Guid  ResPolicyID
		{
			 get { return _resPolicyID; }
			 set
			 {
				 if (_resPolicyID != value)
				 {
					_resPolicyID = value;
					 PropertyHasChanged("ResPolicyID");
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
		public Guid?  ResType_TermID
		{
			 get { return _resType_TermID; }
			 set
			 {
				 if (_resType_TermID != value)
				 {
					_resType_TermID = value;
					 PropertyHasChanged("ResType_TermID");
				 }
			 }
		}

		[DataMember]
		public int?  MinHrs
		{
			 get { return _minHrs; }
			 set
			 {
				 if (_minHrs != value)
				 {
					_minHrs = value;
					 PropertyHasChanged("MinHrs");
				 }
			 }
		}

		[DataMember]
		public int?  MaxHrs
		{
			 get { return _maxHrs; }
			 set
			 {
				 if (_maxHrs != value)
				 {
					_maxHrs = value;
					 PropertyHasChanged("MaxHrs");
				 }
			 }
		}

		[DataMember]
		public decimal?  CancellationCharges
		{
			 get { return _cancellationCharges; }
			 set
			 {
				 if (_cancellationCharges != value)
				 {
					_cancellationCharges = value;
					 PropertyHasChanged("CancellationCharges");
				 }
			 }
		}

		[DataMember]
		public bool?  IsFlatCharge
		{
			 get { return _isFlatCharge; }
			 set
			 {
				 if (_isFlatCharge != value)
				 {
					_isFlatCharge = value;
					 PropertyHasChanged("IsFlatCharge");
				 }
			 }
		}

		[DataMember]
		public Guid?  ChargesApply_TermID
		{
			 get { return _chargesApply_TermID; }
			 set
			 {
				 if (_chargesApply_TermID != value)
				 {
					_chargesApply_TermID = value;
					 PropertyHasChanged("ChargesApply_TermID");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ResPolicyID", "ResPolicyID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
            "ResPolicyID = {0}~\n" +
            "CompanyID = {1}~\n" +
            "PropertyID = {2}~\n" +
            "ResType_TermID = {3}~\n" +
            "MinHrs = {4}~\n" +
            "MaxHrs = {5}~\n" +
            "CancellationCharges = {6}~\n" +
            "IsFlatCharge = {7}~\n" +
            "ChargesApply_TermID = {8}~\n" +
            "IsActive = {9}~\n" +
            "IsSynch = {10}~\n" +
            "SynchOn = {11}~\n" +
            "UpdatedOn = {12}~\n" +
            "SeqNo = {13}~\n" +
            "UpdatedBy = {14}~\n" +
            "CreatedBy = {15}~\n" +
            "CreatedOn = {16}~\n",
			ResPolicyID,			CompanyID,			PropertyID,			ResType_TermID,			MinHrs,			MaxHrs,			CancellationCharges,			IsFlatCharge,			ChargesApply_TermID,			IsActive,			IsSynch,			SynchOn,			UpdatedOn,			SeqNo,			UpdatedBy,			CreatedBy,			CreatedOn);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ResCancellationPolicyKeys
	{

		#region Data Members

		Guid _resPolicyID;

		#endregion

		#region Constructor

		public ResCancellationPolicyKeys(Guid resPolicyID)
		{
			 _resPolicyID = resPolicyID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ResPolicyID
		{
			 get { return _resPolicyID; }
		}

		#endregion

	}
}
