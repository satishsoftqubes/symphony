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
	public class Agent_Payment: BusinessObjectBase
	{

		#region InnerClass
		public enum Agent_PaymentFields
		{
			PaymentID,
			SeqNo,
			ReceiptID,
			PaymentDate,
			InvoiceID,
			Amt,
			Description,
			UpdateLog,
			CompanyID,
			PropertyID
		}
		#endregion

		#region Data Members

			Guid _paymentID;
			int _seqNo;
			Guid _receiptID;
			DateTime _paymentDate;
			Guid? _invoiceID;
			decimal _amt;
			string _description;
			byte[] _updateLog;
			Guid? _companyID;
			Guid? _propertyID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  PaymentID
		{
			 get { return _paymentID; }
			 set
			 {
				 if (_paymentID != value)
				 {
					_paymentID = value;
					 PropertyHasChanged("PaymentID");
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
		public DateTime  PaymentDate
		{
			 get { return _paymentDate; }
			 set
			 {
				 if (_paymentDate != value)
				 {
					_paymentDate = value;
					 PropertyHasChanged("PaymentDate");
				 }
			 }
		}

		[DataMember]
		public Guid?  InvoiceID
		{
			 get { return _invoiceID; }
			 set
			 {
				 if (_invoiceID != value)
				 {
					_invoiceID = value;
					 PropertyHasChanged("InvoiceID");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("PaymentID", "PaymentID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ReceiptID", "ReceiptID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("PaymentDate", "PaymentDate"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("Amt", "Amt"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Description", "Description",125));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"PaymentID = {0}\n"+
			"SeqNo = {1}\n"+
			"ReceiptID = {2}\n"+
			"PaymentDate = {3}\n"+
			"InvoiceID = {4}\n"+
			"Amt = {5}\n"+
			"Description = {6}\n"+
			"UpdateLog = {7}\n"+
			"CompanyID = {8}\n"+
			"PropertyID = {9}\n",
			PaymentID,			SeqNo,			ReceiptID,			PaymentDate,			InvoiceID,			Amt,			Description,			UpdateLog,			CompanyID,			PropertyID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class Agent_PaymentKeys
	{

		#region Data Members

		Guid _paymentID;

		#endregion

		#region Constructor

		public Agent_PaymentKeys(Guid paymentID)
		{
			 _paymentID = paymentID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  PaymentID
		{
			 get { return _paymentID; }
		}

		#endregion

	}
}
