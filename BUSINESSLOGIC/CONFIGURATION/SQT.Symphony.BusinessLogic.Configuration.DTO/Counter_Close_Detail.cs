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
	public class Counter_Close_Detail: BusinessObjectBase
	{

		#region InnerClass
		public enum Counter_Close_DetailFields
		{
			CloseDetailID,
			CounterID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			CloseID,
			CurrencyCode,
			MOP_TermID,
			Field_Name,
			TotalCount,
			TotalAmount,
			OriginalAmount,
			LastUpdateOn
		}
		#endregion

		#region Data Members

			Guid _closeDetailID;
			Guid _counterID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			Guid _closeID;
			string _currencyCode;
			Guid? _mOP_TermID;
			string _field_Name;
			int _totalCount;
			decimal _totalAmount;
			decimal _originalAmount;
			byte[] _lastUpdateOn;

		#endregion

		#region Properties

		[DataMember]
		public Guid  CloseDetailID
		{
			 get { return _closeDetailID; }
			 set
			 {
				 if (_closeDetailID != value)
				 {
					_closeDetailID = value;
					 PropertyHasChanged("CloseDetailID");
				 }
			 }
		}

		[DataMember]
		public Guid  CounterID
		{
			 get { return _counterID; }
			 set
			 {
				 if (_counterID != value)
				 {
					_counterID = value;
					 PropertyHasChanged("CounterID");
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
		public string  CurrencyCode
		{
			 get { return _currencyCode; }
			 set
			 {
				 if (_currencyCode != value)
				 {
					_currencyCode = value;
					 PropertyHasChanged("CurrencyCode");
				 }
			 }
		}

		[DataMember]
		public Guid?  MOP_TermID
		{
			 get { return _mOP_TermID; }
			 set
			 {
				 if (_mOP_TermID != value)
				 {
					_mOP_TermID = value;
					 PropertyHasChanged("MOP_TermID");
				 }
			 }
		}

		[DataMember]
		public string  Field_Name
		{
			 get { return _field_Name; }
			 set
			 {
				 if (_field_Name != value)
				 {
					_field_Name = value;
					 PropertyHasChanged("Field_Name");
				 }
			 }
		}

		[DataMember]
		public int  TotalCount
		{
			 get { return _totalCount; }
			 set
			 {
				 if (_totalCount != value)
				 {
					_totalCount = value;
					 PropertyHasChanged("TotalCount");
				 }
			 }
		}

		[DataMember]
		public decimal  TotalAmount
		{
			 get { return _totalAmount; }
			 set
			 {
				 if (_totalAmount != value)
				 {
					_totalAmount = value;
					 PropertyHasChanged("TotalAmount");
				 }
			 }
		}

		[DataMember]
		public decimal  OriginalAmount
		{
			 get { return _originalAmount; }
			 set
			 {
				 if (_originalAmount != value)
				 {
					_originalAmount = value;
					 PropertyHasChanged("OriginalAmount");
				 }
			 }
		}

		[DataMember]
		public byte[]  LastUpdateOn
		{
			 get { return _lastUpdateOn; }
			 set
			 {
				 if (_lastUpdateOn != value)
				 {
					_lastUpdateOn = value;
					 PropertyHasChanged("LastUpdateOn");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("CloseDetailID", "CloseDetailID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("CounterID", "CounterID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("CloseID", "CloseID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CurrencyCode", "CurrencyCode",50));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("Field_Name", "Field_Name"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Field_Name", "Field_Name",100));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("TotalCount", "TotalCount"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("TotalAmount", "TotalAmount"));
			//ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("OriginalAmount", "OriginalAmount"));
			//ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("LastUpdateOn", "LastUpdateOn"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"CloseDetailID = {0}\n"+
			"CounterID = {1}\n"+
			"PropertyID = {2}\n"+
			"CompanyID = {3}\n"+
			"SeqNo = {4}\n"+
			"IsSynch = {5}\n"+
			"SynchOn = {6}\n"+
			"UpdatedOn = {7}\n"+
			"UpdatedBy = {8}\n"+
			"IsActive = {9}\n"+
			"CloseID = {10}\n"+
			"CurrencyCode = {11}\n"+
			"MOP_TermID = {12}\n"+
			"Field_Name = {13}\n"+
			"TotalCount = {14}\n"+
			"TotalAmount = {15}\n"+
			"OriginalAmount = {16}\n"+
			"LastUpdateOn = {17}\n",
			CloseDetailID,			CounterID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			CloseID,			CurrencyCode,			MOP_TermID,			Field_Name,			TotalCount,			TotalAmount,			OriginalAmount,			LastUpdateOn);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class Counter_Close_DetailKeys
	{

		#region Data Members

		Guid _closeDetailID;

		#endregion

		#region Constructor

		public Counter_Close_DetailKeys(Guid closeDetailID)
		{
			 _closeDetailID = closeDetailID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  CloseDetailID
		{
			 get { return _closeDetailID; }
		}

		#endregion

	}
}
