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
	public class Transfer_Deposit_Join: BusinessObjectBase
	{

		#region InnerClass
		public enum Transfer_Deposit_JoinFields
		{
			DepositTransferID,
			SeqNo,
			BookID,
			DepositBookID,
			Amount,
			UpdateLog,
			CompanyID,
			PropertyID,
			IsSynch,
			SynchOn,
			ReservationID,
			FolioID,
			EntryDate,
			Narration
		}
		#endregion

		#region Data Members

			Guid _depositTransferID;
			int _seqNo;
			Guid _bookID;
			Guid _depositBookID;
			decimal _amount;
			byte[] _updateLog;
			Guid? _companyID;
			Guid? _propertyID;
			bool? _isSynch;
			DateTime? _synchOn;
			Guid? _reservationID;
			Guid? _folioID;
			DateTime? _entryDate;
			string _narration;

		#endregion

		#region Properties

		[DataMember]
		public Guid  DepositTransferID
		{
			 get { return _depositTransferID; }
			 set
			 {
				 if (_depositTransferID != value)
				 {
					_depositTransferID = value;
					 PropertyHasChanged("DepositTransferID");
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
		public Guid  DepositBookID
		{
			 get { return _depositBookID; }
			 set
			 {
				 if (_depositBookID != value)
				 {
					_depositBookID = value;
					 PropertyHasChanged("DepositBookID");
				 }
			 }
		}

		[DataMember]
		public decimal  Amount
		{
			 get { return _amount; }
			 set
			 {
				 if (_amount != value)
				 {
					_amount = value;
					 PropertyHasChanged("Amount");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("DepositTransferID", "DepositTransferID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("BookID", "BookID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("DepositBookID", "DepositBookID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("Amount", "Amount"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Narration", "Narration",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"DepositTransferID = {0}\n"+
			"SeqNo = {1}\n"+
			"BookID = {2}\n"+
			"DepositBookID = {3}\n"+
			"Amount = {4}\n"+
			"UpdateLog = {5}\n"+
			"CompanyID = {6}\n"+
			"PropertyID = {7}\n"+
			"IsSynch = {8}\n"+
			"SynchOn = {9}\n"+
			"ReservationID = {10}\n"+
			"FolioID = {11}\n"+
			"EntryDate = {12}\n"+
			"Narration = {13}\n",
			DepositTransferID,			SeqNo,			BookID,			DepositBookID,			Amount,			UpdateLog,			CompanyID,			PropertyID,			IsSynch,			SynchOn,			ReservationID,			FolioID,			EntryDate,			Narration);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class Transfer_Deposit_JoinKeys
	{

		#region Data Members

		Guid _depositTransferID;

		#endregion

		#region Constructor

		public Transfer_Deposit_JoinKeys(Guid depositTransferID)
		{
			 _depositTransferID = depositTransferID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  DepositTransferID
		{
			 get { return _depositTransferID; }
		}

		#endregion

	}
}
