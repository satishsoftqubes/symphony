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
	public class Transaction: BusinessObjectBase
	{

		#region InnerClass
		public enum TransactionFields
		{
			TransID,
			RefTransID,
			JournalID,
			Amt,
			AcctID,
			AcctNo,
			AcctName,
			TransType,
			IsTax,
			CurBal,
			Updatelog,
			BookID,
			EntryDate,
			CompanyID,
			PropertyID,
			OrderSeqNo,
			AcctTaxRate,
			IsAcctTaxFlat
		}
		#endregion

		#region Data Members

			Guid _transID;
			Guid? _refTransID;
			Guid? _journalID;
			decimal _amt;
			Guid _acctID;
			string _acctNo;
			string _acctName;
			string _transType;
			bool _isTax;
			decimal? _curBal;
			byte[] _updatelog;
			Guid? _bookID;
			DateTime? _entryDate;
			Guid? _companyID;
			Guid? _propertyID;
			int _orderSeqNo;
			decimal? _acctTaxRate;
			bool? _isAcctTaxFlat;

		#endregion

		#region Properties

		[DataMember]
		public Guid  TransID
		{
			 get { return _transID; }
			 set
			 {
				 if (_transID != value)
				 {
					_transID = value;
					 PropertyHasChanged("TransID");
				 }
			 }
		}

		[DataMember]
		public Guid?  RefTransID
		{
			 get { return _refTransID; }
			 set
			 {
				 if (_refTransID != value)
				 {
					_refTransID = value;
					 PropertyHasChanged("RefTransID");
				 }
			 }
		}

		[DataMember]
		public Guid?  JournalID
		{
			 get { return _journalID; }
			 set
			 {
				 if (_journalID != value)
				 {
					_journalID = value;
					 PropertyHasChanged("JournalID");
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
		public Guid  AcctID
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
		public string  AcctNo
		{
			 get { return _acctNo; }
			 set
			 {
				 if (_acctNo != value)
				 {
					_acctNo = value;
					 PropertyHasChanged("AcctNo");
				 }
			 }
		}

		[DataMember]
		public string  AcctName
		{
			 get { return _acctName; }
			 set
			 {
				 if (_acctName != value)
				 {
					_acctName = value;
					 PropertyHasChanged("AcctName");
				 }
			 }
		}

		[DataMember]
		public string  TransType
		{
			 get { return _transType; }
			 set
			 {
				 if (_transType != value)
				 {
					_transType = value;
					 PropertyHasChanged("TransType");
				 }
			 }
		}

		[DataMember]
		public bool  IsTax
		{
			 get { return _isTax; }
			 set
			 {
				 if (_isTax != value)
				 {
					_isTax = value;
					 PropertyHasChanged("IsTax");
				 }
			 }
		}

		[DataMember]
		public decimal?  CurBal
		{
			 get { return _curBal; }
			 set
			 {
				 if (_curBal != value)
				 {
					_curBal = value;
					 PropertyHasChanged("CurBal");
				 }
			 }
		}

		[DataMember]
		public byte[]  Updatelog
		{
			 get { return _updatelog; }
			 set
			 {
				 if (_updatelog != value)
				 {
					_updatelog = value;
					 PropertyHasChanged("Updatelog");
				 }
			 }
		}

		[DataMember]
		public Guid?  BookID
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
		public DateTime?  EntryDate
		{
			 get { return _entryDate; }
			 set
			 {
				 if (_entryDate != value)
				 {
					_entryDate = value;
					 PropertyHasChanged("EntryDate");
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
		public int  OrderSeqNo
		{
			 get { return _orderSeqNo; }
			 set
			 {
				 if (_orderSeqNo != value)
				 {
					_orderSeqNo = value;
					 PropertyHasChanged("OrderSeqNo");
				 }
			 }
		}

		[DataMember]
		public decimal?  AcctTaxRate
		{
			 get { return _acctTaxRate; }
			 set
			 {
				 if (_acctTaxRate != value)
				 {
					_acctTaxRate = value;
					 PropertyHasChanged("AcctTaxRate");
				 }
			 }
		}

		[DataMember]
		public bool?  IsAcctTaxFlat
		{
			 get { return _isAcctTaxFlat; }
			 set
			 {
				 if (_isAcctTaxFlat != value)
				 {
					_isAcctTaxFlat = value;
					 PropertyHasChanged("IsAcctTaxFlat");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("TransID", "TransID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("Amt", "Amt"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("AcctID", "AcctID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("AcctNo", "AcctNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("AcctNo", "AcctNo",10));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("AcctName", "AcctName"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("AcctName", "AcctName",75));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("TransType", "TransType"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("TransType", "TransType",2));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("IsTax", "IsTax"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("Updatelog", "Updatelog"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("OrderSeqNo", "OrderSeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"TransID = {0}\n"+
			"RefTransID = {1}\n"+
			"JournalID = {2}\n"+
			"Amt = {3}\n"+
			"AcctID = {4}\n"+
			"AcctNo = {5}\n"+
			"AcctName = {6}\n"+
			"TransType = {7}\n"+
			"IsTax = {8}\n"+
			"CurBal = {9}\n"+
			"Updatelog = {10}\n"+
			"BookID = {11}\n"+
			"EntryDate = {12}\n"+
			"CompanyID = {13}\n"+
			"PropertyID = {14}\n"+
			"OrderSeqNo = {15}\n"+
			"AcctTaxRate = {16}\n"+
			"IsAcctTaxFlat = {17}\n",
			TransID,			RefTransID,			JournalID,			Amt,			AcctID,			AcctNo,			AcctName,			TransType,			IsTax,			CurBal,			Updatelog,			BookID,			EntryDate,			CompanyID,			PropertyID,			OrderSeqNo,			AcctTaxRate,			IsAcctTaxFlat);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class TransactionKeys
	{

		#region Data Members

		Guid _transID;

		#endregion

		#region Constructor

		public TransactionKeys(Guid transID)
		{
			 _transID = transID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  TransID
		{
			 get { return _transID; }
		}

		#endregion

	}
}
