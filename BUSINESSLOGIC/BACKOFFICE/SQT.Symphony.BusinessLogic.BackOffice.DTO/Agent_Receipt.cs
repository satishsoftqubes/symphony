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
	public class Agent_Receipt: BusinessObjectBase
	{

		#region InnerClass
		public enum Agent_ReceiptFields
		{
			ReceiptID,
			ReceiptNo,
			SeqNo,
			AgentID,
			BookID,
			ReceiptDate,
			AcctID,
			Description,
			Amt,
			PayType,
			IsAllocated,
			CounterID,
			UserID,
			CompanyID,
			UpdateLog,
			PropertyID
		}
		#endregion

		#region Data Members

			Guid _receiptID;
			string _receiptNo;
			int _seqNo;
			Guid _agentID;
			Guid _bookID;
			DateTime _receiptDate;
			Guid? _acctID;
			string _description;
			decimal _amt;
			string _payType;
			bool? _isAllocated;
			Guid? _counterID;
			Guid? _userID;
			Guid? _companyID;
			byte[] _updateLog;
			Guid? _propertyID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  ReceiptID
		{
			 get { return _receiptID; }
			 set
			 {
				 if (_receiptID != value)
				 {
					_receiptID = value;
					 PropertyHasChanged("ReceiptID");
				 }
			 }
		}

		[DataMember]
		public string  ReceiptNo
		{
			 get { return _receiptNo; }
			 set
			 {
				 if (_receiptNo != value)
				 {
					_receiptNo = value;
					 PropertyHasChanged("ReceiptNo");
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
		public Guid  AgentID
		{
			 get { return _agentID; }
			 set
			 {
				 if (_agentID != value)
				 {
					_agentID = value;
					 PropertyHasChanged("AgentID");
				 }
			 }
		}

		[DataMember]
		public Guid  BookID
		{
			 get { return _bookID; }
			 set
			 {
				 if (_bookID != value)
				 {
					_bookID = value;
					 PropertyHasChanged("BookID");
				 }
			 }
		}

		[DataMember]
		public DateTime  ReceiptDate
		{
			 get { return _receiptDate; }
			 set
			 {
				 if (_receiptDate != value)
				 {
					_receiptDate = value;
					 PropertyHasChanged("ReceiptDate");
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
		public string  Description
		{
			 get { return _description; }
			 set
			 {
				 if (_description != value)
				 {
					_description = value;
					 PropertyHasChanged("Description");
				 }
			 }
		}

		[DataMember]
		public decimal  Amt
		{
			 get { return _amt; }
			 set
			 {
				 if (_amt != value)
				 {
					_amt = value;
					 PropertyHasChanged("Amt");
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
		public bool?  IsAllocated
		{
			 get { return _isAllocated; }
			 set
			 {
				 if (_isAllocated != value)
				 {
					_isAllocated = value;
					 PropertyHasChanged("IsAllocated");
				 }
			 }
		}

		[DataMember]
		public Guid?  CounterID
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
		public byte[]  UpdateLog
		{
			 get { return _updateLog; }
			 set
			 {
				 if (_updateLog != value)
				 {
					_updateLog = value;
					 PropertyHasChanged("UpdateLog");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ReceiptID", "ReceiptID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ReceiptNo", "ReceiptNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ReceiptNo", "ReceiptNo",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("AgentID", "AgentID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("BookID", "BookID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ReceiptDate", "ReceiptDate"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Description", "Description",500));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("Amt", "Amt"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("PayType", "PayType"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PayType", "PayType",50));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ReceiptID = {0}\n"+
			"ReceiptNo = {1}\n"+
			"SeqNo = {2}\n"+
			"AgentID = {3}\n"+
			"BookID = {4}\n"+
			"ReceiptDate = {5}\n"+
			"AcctID = {6}\n"+
			"Description = {7}\n"+
			"Amt = {8}\n"+
			"PayType = {9}\n"+
			"IsAllocated = {10}\n"+
			"CounterID = {11}\n"+
			"UserID = {12}\n"+
			"CompanyID = {13}\n"+
			"UpdateLog = {14}\n"+
			"PropertyID = {15}\n",
			ReceiptID,			ReceiptNo,			SeqNo,			AgentID,			BookID,			ReceiptDate,			AcctID,			Description,			Amt,			PayType,			IsAllocated,			CounterID,			UserID,			CompanyID,			UpdateLog,			PropertyID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class Agent_ReceiptKeys
	{

		#region Data Members

		Guid _receiptID;

		#endregion

		#region Constructor

		public Agent_ReceiptKeys(Guid receiptID)
		{
			 _receiptID = receiptID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ReceiptID
		{
			 get { return _receiptID; }
		}

		#endregion

	}
}
