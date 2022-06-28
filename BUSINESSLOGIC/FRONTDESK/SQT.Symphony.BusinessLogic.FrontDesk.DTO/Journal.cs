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
	public class Journal: BusinessObjectBase
	{

		#region InnerClass
		public enum JournalFields
		{
			JournalID,
			RefJournalID,
			BookID,
			Amt,
			AcctID,
			TransType,
			IsReverse,
			MEMO,
			Job_ID,
			IDType,
			Updatelog,
			Tax,
			EntryDate,
			CompanyID,
			PropertyID,
			OrderSeqNo
		}
		#endregion

		#region Data Members

			Guid _journalID;
			Guid? _refJournalID;
			Guid? _bookID;
			decimal _amt;
			Guid _acctID;
			string _transType;
			bool _isReverse;
			string _mEMO;
			Guid? _job_ID;
			string _iDType;
			byte[] _updatelog;
			decimal? _tax;
			DateTime? _entryDate;
			Guid? _companyID;
			Guid? _propertyID;
			int _orderSeqNo;

		#endregion

		#region Properties

		[DataMember]
		public Guid  JournalID
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
		public Guid?  RefJournalID
		{
			 get { return _refJournalID; }
			 set
			 {
				 if (_refJournalID != value)
				 {
					_refJournalID = value;
					 PropertyHasChanged("RefJournalID");
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
		public bool  IsReverse
		{
			 get { return _isReverse; }
			 set
			 {
				 if (_isReverse != value)
				 {
					_isReverse = value;
					 PropertyHasChanged("IsReverse");
				 }
			 }
		}

		[DataMember]
		public string  MEMO
		{
			 get { return _mEMO; }
			 set
			 {
				 if (_mEMO != value)
				 {
					_mEMO = value;
					 PropertyHasChanged("MEMO");
				 }
			 }
		}

		[DataMember]
		public Guid?  Job_ID
		{
			 get { return _job_ID; }
			 set
			 {
				 if (_job_ID != value)
				 {
					_job_ID = value;
					 PropertyHasChanged("Job_ID");
				 }
			 }
		}

		[DataMember]
		public string  IDType
		{
			 get { return _iDType; }
			 set
			 {
				 if (_iDType != value)
				 {
					_iDType = value;
					 PropertyHasChanged("IDType");
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
		public decimal?  Tax
		{
			 get { return _tax; }
			 set
			 {
				 if (_tax != value)
				 {
					_tax = value;
					 PropertyHasChanged("Tax");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("JournalID", "JournalID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("Amt", "Amt"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("AcctID", "AcctID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("TransType", "TransType"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("TransType", "TransType",2));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("IsReverse", "IsReverse"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("MEMO", "MEMO",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("IDType", "IDType",120));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("Updatelog", "Updatelog"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("OrderSeqNo", "OrderSeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"JournalID = {0}\n"+
			"RefJournalID = {1}\n"+
			"BookID = {2}\n"+
			"Amt = {3}\n"+
			"AcctID = {4}\n"+
			"TransType = {5}\n"+
			"IsReverse = {6}\n"+
			"MEMO = {7}\n"+
			"Job_ID = {8}\n"+
			"IDType = {9}\n"+
			"Updatelog = {10}\n"+
			"Tax = {11}\n"+
			"EntryDate = {12}\n"+
			"CompanyID = {13}\n"+
			"PropertyID = {14}\n"+
			"OrderSeqNo = {15}\n",
			JournalID,			RefJournalID,			BookID,			Amt,			AcctID,			TransType,			IsReverse,			MEMO,			Job_ID,			IDType,			Updatelog,			Tax,			EntryDate,			CompanyID,			PropertyID,			OrderSeqNo);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class JournalKeys
	{

		#region Data Members

		Guid _journalID;

		#endregion

		#region Constructor

		public JournalKeys(Guid journalID)
		{
			 _journalID = journalID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  JournalID
		{
			 get { return _journalID; }
		}

		#endregion

	}
}
