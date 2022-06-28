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
	public class Receipt: BusinessObjectBase
	{

		#region InnerClass
		public enum ReceiptFields
		{
			ReceiptID,
			ReceiptNo,
			BookID,
			Amt,
			GeneralID,
			GeneralIDType,
			Narration,
			CompanyID,
			PropertyID,
			MOP_TermID,
			AcctID,
			EntryDate,
			CounterID,
			ReservationID,
			FolioID,
			OrderSeqNo,
			GuestID
		}
		#endregion

		#region Data Members

			Guid _receiptID;
			string _receiptNo;
			Guid? _bookID;
			decimal? _amt;
			Guid? _generalID;
			string _generalIDType;
			string _narration;
			Guid? _companyID;
			Guid? _propertyID;
			int? _mOP_TermID;
			Guid? _acctID;
			DateTime? _entryDate;
			Guid? _counterID;
			Guid? _reservationID;
			Guid? _folioID;
			int _orderSeqNo;
			Guid? _guestID;

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
		public decimal?  Amt
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
		public Guid?  GeneralID
		{
			 get { return _generalID; }
			 set
			 {
				 if (_generalID != value)
				 {
					_generalID = value;
					 PropertyHasChanged("GeneralID");
				 }
			 }
		}

		[DataMember]
		public string  GeneralIDType
		{
			 get { return _generalIDType; }
			 set
			 {
				 if (_generalIDType != value)
				 {
					_generalIDType = value;
					 PropertyHasChanged("GeneralIDType");
				 }
			 }
		}

		[DataMember]
		public string  Narration
		{
			 get { return _narration; }
			 set
			 {
				 if (_narration != value)
				 {
					_narration = value;
					 PropertyHasChanged("Narration");
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
		public int?  MOP_TermID
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
		public Guid?  ReservationID
		{
			 get { return _reservationID; }
			 set
			 {
				 if (_reservationID != value)
				 {
					_reservationID = value;
					 PropertyHasChanged("ReservationID");
				 }
			 }
		}

		[DataMember]
		public Guid?  FolioID
		{
			 get { return _folioID; }
			 set
			 {
				 if (_folioID != value)
				 {
					_folioID = value;
					 PropertyHasChanged("FolioID");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ReceiptID", "ReceiptID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ReceiptNo", "ReceiptNo",37));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("GeneralIDType", "GeneralIDType",120));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Narration", "Narration",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("OrderSeqNo", "OrderSeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ReceiptID = {0}\n"+
			"ReceiptNo = {1}\n"+
			"BookID = {2}\n"+
			"Amt = {3}\n"+
			"GeneralID = {4}\n"+
			"GeneralIDType = {5}\n"+
			"Narration = {6}\n"+
			"CompanyID = {7}\n"+
			"PropertyID = {8}\n"+
			"MOP_TermID = {9}\n"+
			"AcctID = {10}\n"+
			"EntryDate = {11}\n"+
			"CounterID = {12}\n"+
			"ReservationID = {13}\n"+
			"FolioID = {14}\n"+
			"OrderSeqNo = {15}\n"+
			"GuestID = {16}\n",
			ReceiptID,			ReceiptNo,			BookID,			Amt,			GeneralID,			GeneralIDType,			Narration,			CompanyID,			PropertyID,			MOP_TermID,			AcctID,			EntryDate,			CounterID,			ReservationID,			FolioID,			OrderSeqNo,			GuestID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ReceiptKeys
	{

		#region Data Members

		Guid _receiptID;

		#endregion

		#region Constructor

		public ReceiptKeys(Guid receiptID)
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
