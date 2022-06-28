using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;
namespace SQT.Symphony.BusinessLogic.BackOffice.DTO
{
	[DataContract]
	public class AccountGroup: BusinessObjectBase
	{

		#region InnerClass
		public enum AccountGroupFields
		{
			AcctGrpID,
			RefAcctGrpID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			GroupCode,
			GroupName,
			IsDefault,
			SymphonyGroupID
		}
		#endregion

		#region Data Members

			Guid _acctGrpID;
			Guid? _refAcctGrpID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			string _groupCode;
			string _groupName;
			bool? _isDefault;
			int? _symphonyGroupID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  AcctGrpID
		{
			 get { return _acctGrpID; }
			 set
			 {
				 if (_acctGrpID != value)
				 {
					_acctGrpID = value;
					 PropertyHasChanged("AcctGrpID");
				 }
			 }
		}

		[DataMember]
		public Guid?  RefAcctGrpID
		{
			 get { return _refAcctGrpID; }
			 set
			 {
				 if (_refAcctGrpID != value)
				 {
					_refAcctGrpID = value;
					 PropertyHasChanged("RefAcctGrpID");
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
		public string  GroupCode
		{
			 get { return _groupCode; }
			 set
			 {
				 if (_groupCode != value)
				 {
					_groupCode = value;
					 PropertyHasChanged("GroupCode");
				 }
			 }
		}

		[DataMember]
		public string  GroupName
		{
			 get { return _groupName; }
			 set
			 {
				 if (_groupName != value)
				 {
					_groupName = value;
					 PropertyHasChanged("GroupName");
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

		[DataMember]
		public int?  SymphonyGroupID
		{
			 get { return _symphonyGroupID; }
			 set
			 {
				 if (_symphonyGroupID != value)
				 {
					_symphonyGroupID = value;
					 PropertyHasChanged("SymphonyGroupID");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("AcctGrpID", "AcctGrpID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("GroupCode", "GroupCode",10));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("GroupName", "GroupName",70));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"AcctGrpID = {0}\n"+
			"RefAcctGrpID = {1}\n"+
			"PropertyID = {2}\n"+
			"CompanyID = {3}\n"+
			"SeqNo = {4}\n"+
			"IsSynch = {5}\n"+
			"SynchOn = {6}\n"+
			"UpdatedOn = {7}\n"+
			"UpdatedBy = {8}\n"+
			"IsActive = {9}\n"+
			"GroupCode = {10}\n"+
			"GroupName = {11}\n"+
			"IsDefault = {12}\n"+
			"SymphonyGroupID = {13}\n",
			AcctGrpID,			RefAcctGrpID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			GroupCode,			GroupName,			IsDefault,			SymphonyGroupID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class AccountGroupKeys
	{

		#region Data Members

		Guid _acctGrpID;

		#endregion

		#region Constructor

		public AccountGroupKeys(Guid acctGrpID)
		{
			 _acctGrpID = acctGrpID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  AcctGrpID
		{
			 get { return _acctGrpID; }
		}

		#endregion

	}
}
