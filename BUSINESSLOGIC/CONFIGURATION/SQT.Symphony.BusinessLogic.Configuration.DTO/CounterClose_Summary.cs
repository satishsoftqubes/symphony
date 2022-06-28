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
	public class CounterClose_Summary: BusinessObjectBase
	{

		#region InnerClass
		public enum CounterClose_SummaryFields
		{
			ID,
			SeqNo,
			CloseID,
			Code,
			AcctID,
			NewTransID,
			OldTransID,
			PayType,
			System_Amount,
			AdjustedAmount,
			Net_Amount,
			IsReadOnly,
			UserID,
			PropertyID,
			CompanyID,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive
		}
		#endregion

		#region Data Members

			Guid _iD;
			int _seqNo;
			Guid _closeID;
			string _code;
			Guid? _acctID;
			string _newTransID;
			string _oldTransID;
			string _payType;
			decimal? _system_Amount;
			decimal? _adjustedAmount;
			decimal? _net_Amount;
			bool? _isReadOnly;
			Guid? _userID;
			Guid? _propertyID;
			Guid? _companyID;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;

		#endregion

		#region Properties

		[DataMember]
		public Guid  ID
		{
			 get { return _iD; }
			 set
			 {
				 if (_iD != value)
				 {
					_iD = value;
					 PropertyHasChanged("ID");
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
		public Guid  CloseID
		{
			 get { return _closeID; }
			 set
			 {
				 if (_closeID != value)
				 {
					_closeID = value;
					 PropertyHasChanged("CloseID");
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
		public Guid?  AcctID
		{
			 get { return _acctID; }
			 set
			 {
				 if (_acctID != value)
				 {
					_acctID = value;
					 PropertyHasChanged("AcctID");
				 }
			 }
		}

		[DataMember]
		public string  NewTransID
		{
			 get { return _newTransID; }
			 set
			 {
				 if (_newTransID != value)
				 {
					_newTransID = value;
					 PropertyHasChanged("NewTransID");
				 }
			 }
		}

		[DataMember]
		public string  OldTransID
		{
			 get { return _oldTransID; }
			 set
			 {
				 if (_oldTransID != value)
				 {
					_oldTransID = value;
					 PropertyHasChanged("OldTransID");
				 }
			 }
		}

		[DataMember]
		public string  PayType
		{
			 get { return _payType; }
			 set
			 {
				 if (_payType != value)
				 {
					_payType = value;
					 PropertyHasChanged("PayType");
				 }
			 }
		}

		[DataMember]
		public decimal?  System_Amount
		{
			 get { return _system_Amount; }
			 set
			 {
				 if (_system_Amount != value)
				 {
					_system_Amount = value;
					 PropertyHasChanged("System_Amount");
				 }
			 }
		}

		[DataMember]
		public decimal?  AdjustedAmount
		{
			 get { return _adjustedAmount; }
			 set
			 {
				 if (_adjustedAmount != value)
				 {
					_adjustedAmount = value;
					 PropertyHasChanged("AdjustedAmount");
				 }
			 }
		}

		[DataMember]
		public decimal?  Net_Amount
		{
			 get { return _net_Amount; }
			 set
			 {
				 if (_net_Amount != value)
				 {
					_net_Amount = value;
					 PropertyHasChanged("Net_Amount");
				 }
			 }
		}

		[DataMember]
		public bool?  IsReadOnly
		{
			 get { return _isReadOnly; }
			 set
			 {
				 if (_isReadOnly != value)
				 {
					_isReadOnly = value;
					 PropertyHasChanged("IsReadOnly");
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ID", "ID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("CloseID", "CloseID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Code", "Code",25));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("NewTransID", "NewTransID",50));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("OldTransID", "OldTransID",50));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PayType", "PayType",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ID = {0}\n"+
			"SeqNo = {1}\n"+
			"CloseID = {2}\n"+
			"Code = {3}\n"+
			"AcctID = {4}\n"+
			"NewTransID = {5}\n"+
			"OldTransID = {6}\n"+
			"PayType = {7}\n"+
			"System_Amount = {8}\n"+
			"AdjustedAmount = {9}\n"+
			"Net_Amount = {10}\n"+
			"IsReadOnly = {11}\n"+
			"UserID = {12}\n"+
			"PropertyID = {13}\n"+
			"CompanyID = {14}\n"+
			"IsSynch = {15}\n"+
			"SynchOn = {16}\n"+
			"UpdatedOn = {17}\n"+
			"UpdatedBy = {18}\n"+
			"IsActive = {19}\n",
			ID,			SeqNo,			CloseID,			Code,			AcctID,			NewTransID,			OldTransID,			PayType,			System_Amount,			AdjustedAmount,			Net_Amount,			IsReadOnly,			UserID,			PropertyID,			CompanyID,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class CounterClose_SummaryKeys
	{

		#region Data Members

		Guid _iD;

		#endregion

		#region Constructor

		public CounterClose_SummaryKeys(Guid iD)
		{
			 _iD = iD; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ID
		{
			 get { return _iD; }
		}

		#endregion

	}
}
