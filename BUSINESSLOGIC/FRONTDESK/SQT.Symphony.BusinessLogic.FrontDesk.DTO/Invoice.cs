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
	public class Invoice: BusinessObjectBase
	{

		#region InnerClass
		public enum InvoiceFields
		{
			InvoiceID,
			InvoiceNo,
			YearID,
			ReservationID,
			FolioID,
			GuestID,
			AgentID,
			InvoiceDate,
			Amt,
			IsPaid,
			PendingAmount,
			CustomerID,
			TransactionOrigin_TermID,
			FName,
			LName,
			CompanyID,
			PropertyID,
			IsPrinted,
			PrintedOn,
			UpdateLog,
			AuditID,
			IsLocked,
			SeqNo,
			IsVoid,
			VoidBy,
			VoidOn,
			VoidReason,
			IsActive,
			IsSynch,
			SynchOn,
			IsDiscount,
			DiscAmount,
			IsDiscInPercentage,
			InvoiceDetail
		}
		#endregion

		#region Data Members

			Guid _invoiceID;
			string _invoiceNo;
			Guid? _yearID;
			Guid? _reservationID;
			Guid? _folioID;
			Guid? _guestID;
			Guid? _agentID;
			DateTime? _invoiceDate;
			decimal? _amt;
			bool? _isPaid;
			decimal? _pendingAmount;
			Guid? _customerID;
			int? _transactionOrigin_TermID;
			string _fName;
			string _lName;
			Guid? _companyID;
			Guid? _propertyID;
			bool? _isPrinted;
			DateTime? _printedOn;
			byte[] _updateLog;
			Guid? _auditID;
			bool? _isLocked;
			int _seqNo;
			bool? _isVoid;
			Guid? _voidBy;
			DateTime? _voidOn;
			string _voidReason;
			bool? _isActive;
			bool? _isSynch;
			DateTime? _synchOn;
			bool? _isDiscount;
			decimal? _discAmount;
			bool? _isDiscInPercentage;
			string _invoiceDetail;

		#endregion

		#region Properties

		[DataMember]
		public Guid  InvoiceID
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
		public string  InvoiceNo
		{
			 get { return _invoiceNo; }
			 set
			 {
				 if (_invoiceNo != value)
				 {
					_invoiceNo = value;
					 PropertyHasChanged("InvoiceNo");
				 }
			 }
		}

		[DataMember]
		public Guid?  YearID
		{
			 get { return _yearID; }
			 set
			 {
				 if (_yearID != value)
				 {
					_yearID = value;
					 PropertyHasChanged("YearID");
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

		[DataMember]
		public Guid?  AgentID
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
		public DateTime?  InvoiceDate
		{
			 get { return _invoiceDate; }
			 set
			 {
				 if (_invoiceDate != value)
				 {
					_invoiceDate = value;
					 PropertyHasChanged("InvoiceDate");
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
		public bool?  IsPaid
		{
			 get { return _isPaid; }
			 set
			 {
				 if (_isPaid != value)
				 {
					_isPaid = value;
					 PropertyHasChanged("IsPaid");
				 }
			 }
		}

		[DataMember]
		public decimal?  PendingAmount
		{
			 get { return _pendingAmount; }
			 set
			 {
				 if (_pendingAmount != value)
				 {
					_pendingAmount = value;
					 PropertyHasChanged("PendingAmount");
				 }
			 }
		}

		[DataMember]
		public Guid?  CustomerID
		{
			 get { return _customerID; }
			 set
			 {
				 if (_customerID != value)
				 {
					_customerID = value;
					 PropertyHasChanged("CustomerID");
				 }
			 }
		}

		[DataMember]
		public int?  TransactionOrigin_TermID
		{
			 get { return _transactionOrigin_TermID; }
			 set
			 {
				 if (_transactionOrigin_TermID != value)
				 {
					_transactionOrigin_TermID = value;
					 PropertyHasChanged("TransactionOrigin_TermID");
				 }
			 }
		}

		[DataMember]
		public string  FName
		{
			 get { return _fName; }
			 set
			 {
				 if (_fName != value)
				 {
					_fName = value;
					 PropertyHasChanged("FName");
				 }
			 }
		}

		[DataMember]
		public string  LName
		{
			 get { return _lName; }
			 set
			 {
				 if (_lName != value)
				 {
					_lName = value;
					 PropertyHasChanged("LName");
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
		public bool?  IsPrinted
		{
			 get { return _isPrinted; }
			 set
			 {
				 if (_isPrinted != value)
				 {
					_isPrinted = value;
					 PropertyHasChanged("IsPrinted");
				 }
			 }
		}

		[DataMember]
		public DateTime?  PrintedOn
		{
			 get { return _printedOn; }
			 set
			 {
				 if (_printedOn != value)
				 {
					_printedOn = value;
					 PropertyHasChanged("PrintedOn");
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
		public Guid?  AuditID
		{
			 get { return _auditID; }
			 set
			 {
				 if (_auditID != value)
				 {
					_auditID = value;
					 PropertyHasChanged("AuditID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsLocked
		{
			 get { return _isLocked; }
			 set
			 {
				 if (_isLocked != value)
				 {
					_isLocked = value;
					 PropertyHasChanged("IsLocked");
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
		public bool?  IsVoid
		{
			 get { return _isVoid; }
			 set
			 {
				 if (_isVoid != value)
				 {
					_isVoid = value;
					 PropertyHasChanged("IsVoid");
				 }
			 }
		}

		[DataMember]
		public Guid?  VoidBy
		{
			 get { return _voidBy; }
			 set
			 {
				 if (_voidBy != value)
				 {
					_voidBy = value;
					 PropertyHasChanged("VoidBy");
				 }
			 }
		}

		[DataMember]
		public DateTime?  VoidOn
		{
			 get { return _voidOn; }
			 set
			 {
				 if (_voidOn != value)
				 {
					_voidOn = value;
					 PropertyHasChanged("VoidOn");
				 }
			 }
		}

		[DataMember]
		public string  VoidReason
		{
			 get { return _voidReason; }
			 set
			 {
				 if (_voidReason != value)
				 {
					_voidReason = value;
					 PropertyHasChanged("VoidReason");
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
		public bool?  IsDiscount
		{
			 get { return _isDiscount; }
			 set
			 {
				 if (_isDiscount != value)
				 {
					_isDiscount = value;
					 PropertyHasChanged("IsDiscount");
				 }
			 }
		}

		[DataMember]
		public decimal?  DiscAmount
		{
			 get { return _discAmount; }
			 set
			 {
				 if (_discAmount != value)
				 {
					_discAmount = value;
					 PropertyHasChanged("DiscAmount");
				 }
			 }
		}

		[DataMember]
		public bool?  IsDiscInPercentage
		{
			 get { return _isDiscInPercentage; }
			 set
			 {
				 if (_isDiscInPercentage != value)
				 {
					_isDiscInPercentage = value;
					 PropertyHasChanged("IsDiscInPercentage");
				 }
			 }
		}

		[DataMember]
		public string  InvoiceDetail
		{
			 get { return _invoiceDetail; }
			 set
			 {
				 if (_invoiceDetail != value)
				 {
					_invoiceDetail = value;
					 PropertyHasChanged("InvoiceDetail");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("InvoiceID", "InvoiceID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("InvoiceNo", "InvoiceNo",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("FName", "FName",150));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("LName", "LName",150));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("VoidReason", "VoidReason",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("InvoiceDetail", "InvoiceDetail",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"InvoiceID = {0}\n"+
			"InvoiceNo = {1}\n"+
			"YearID = {2}\n"+
			"ReservationID = {3}\n"+
			"FolioID = {4}\n"+
			"GuestID = {5}\n"+
			"AgentID = {6}\n"+
			"InvoiceDate = {7}\n"+
			"Amt = {8}\n"+
			"IsPaid = {9}\n"+
			"PendingAmount = {10}\n"+
			"CustomerID = {11}\n"+
			"TransactionOrigin_TermID = {12}\n"+
			"FName = {13}\n"+
			"LName = {14}\n"+
			"CompanyID = {15}\n"+
			"PropertyID = {16}\n"+
			"IsPrinted = {17}\n"+
			"PrintedOn = {18}\n"+
			"UpdateLog = {19}\n"+
			"AuditID = {20}\n"+
			"IsLocked = {21}\n"+
			"SeqNo = {22}\n"+
			"IsVoid = {23}\n"+
			"VoidBy = {24}\n"+
			"VoidOn = {25}\n"+
			"VoidReason = {26}\n"+
			"IsActive = {27}\n"+
			"IsSynch = {28}\n"+
			"SynchOn = {29}\n"+
			"IsDiscount = {30}\n"+
			"DiscAmount = {31}\n"+
			"IsDiscInPercentage = {32}\n"+
			"InvoiceDetail = {33}\n",
			InvoiceID,			InvoiceNo,			YearID,			ReservationID,			FolioID,			GuestID,			AgentID,			InvoiceDate,			Amt,			IsPaid,			PendingAmount,			CustomerID,			TransactionOrigin_TermID,			FName,			LName,			CompanyID,			PropertyID,			IsPrinted,			PrintedOn,			UpdateLog,			AuditID,			IsLocked,			SeqNo,			IsVoid,			VoidBy,			VoidOn,			VoidReason,			IsActive,			IsSynch,			SynchOn,			IsDiscount,			DiscAmount,			IsDiscInPercentage,			InvoiceDetail);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class InvoiceKeys
	{

		#region Data Members

		Guid _invoiceID;

		#endregion

		#region Constructor

		public InvoiceKeys(Guid invoiceID)
		{
			 _invoiceID = invoiceID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  InvoiceID
		{
			 get { return _invoiceID; }
		}

		#endregion

	}
}
