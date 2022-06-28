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
	public class GuestLaundry: BusinessObjectBase
	{

		#region InnerClass
		public enum GuestLaundryFields
		{
			GuestLaundryID,
			ReservationID,
			RoomID,
			FolioID,
			GuestName,
			DateOfReceived,
			DateToReturn,
			IsReturned,
			DocateNo,
			IsBilled,
			BilledAmt,
			Remarks,
			GeneralBillID,
			IsPaid,
			IsTransferredToFolio,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive
		}
		#endregion

		#region Data Members

			Guid _guestLaundryID;
			Guid? _reservationID;
			Guid? _roomID;
			Guid? _folioID;
			string _guestName;
			DateTime? _dateOfReceived;
			DateTime? _dateToReturn;
			bool? _isReturned;
			string _docateNo;
			bool? _isBilled;
			decimal? _billedAmt;
			string _remarks;
			Guid? _generalBillID;
			bool? _isPaid;
			bool? _isTransferredToFolio;
			Guid? _propertyID;
			Guid? _companyID;
			long _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;

		#endregion

		#region Properties

		[DataMember]
		public Guid  GuestLaundryID
		{
			 get { return _guestLaundryID; }
			 set
			 {
				 if (_guestLaundryID != value)
				 {
					_guestLaundryID = value;
					 PropertyHasChanged("GuestLaundryID");
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
		public Guid?  RoomID
		{
			 get { return _roomID; }
			 set
			 {
				 if (_roomID != value)
				 {
					_roomID = value;
					 PropertyHasChanged("RoomID");
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
		public string  GuestName
		{
			 get { return _guestName; }
			 set
			 {
				 if (_guestName != value)
				 {
					_guestName = value;
					 PropertyHasChanged("GuestName");
				 }
			 }
		}

		[DataMember]
		public DateTime?  DateOfReceived
		{
			 get { return _dateOfReceived; }
			 set
			 {
				 if (_dateOfReceived != value)
				 {
					_dateOfReceived = value;
					 PropertyHasChanged("DateOfReceived");
				 }
			 }
		}

		[DataMember]
		public DateTime?  DateToReturn
		{
			 get { return _dateToReturn; }
			 set
			 {
				 if (_dateToReturn != value)
				 {
					_dateToReturn = value;
					 PropertyHasChanged("DateToReturn");
				 }
			 }
		}

		[DataMember]
		public bool?  IsReturned
		{
			 get { return _isReturned; }
			 set
			 {
				 if (_isReturned != value)
				 {
					_isReturned = value;
					 PropertyHasChanged("IsReturned");
				 }
			 }
		}

		[DataMember]
		public string  DocateNo
		{
			 get { return _docateNo; }
			 set
			 {
				 if (_docateNo != value)
				 {
					_docateNo = value;
					 PropertyHasChanged("DocateNo");
				 }
			 }
		}

		[DataMember]
		public bool?  IsBilled
		{
			 get { return _isBilled; }
			 set
			 {
				 if (_isBilled != value)
				 {
					_isBilled = value;
					 PropertyHasChanged("IsBilled");
				 }
			 }
		}

		[DataMember]
		public decimal?  BilledAmt
		{
			 get { return _billedAmt; }
			 set
			 {
				 if (_billedAmt != value)
				 {
					_billedAmt = value;
					 PropertyHasChanged("BilledAmt");
				 }
			 }
		}

		[DataMember]
		public string  Remarks
		{
			 get { return _remarks; }
			 set
			 {
				 if (_remarks != value)
				 {
					_remarks = value;
					 PropertyHasChanged("Remarks");
				 }
			 }
		}

		[DataMember]
		public Guid?  GeneralBillID
		{
			 get { return _generalBillID; }
			 set
			 {
				 if (_generalBillID != value)
				 {
					_generalBillID = value;
					 PropertyHasChanged("GeneralBillID");
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
		public bool?  IsTransferredToFolio
		{
			 get { return _isTransferredToFolio; }
			 set
			 {
				 if (_isTransferredToFolio != value)
				 {
					_isTransferredToFolio = value;
					 PropertyHasChanged("IsTransferredToFolio");
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
		public long  SeqNo
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("GuestLaundryID", "GuestLaundryID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("GuestName", "GuestName",320));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("DocateNo", "DocateNo",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Remarks", "Remarks",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"GuestLaundryID = {0}\n"+
			"ReservationID = {1}\n"+
			"RoomID = {2}\n"+
			"FolioID = {3}\n"+
			"GuestName = {4}\n"+
			"DateOfReceived = {5}\n"+
			"DateToReturn = {6}\n"+
			"IsReturned = {7}\n"+
			"DocateNo = {8}\n"+
			"IsBilled = {9}\n"+
			"BilledAmt = {10}\n"+
			"Remarks = {11}\n"+
			"GeneralBillID = {12}\n"+
			"IsPaid = {13}\n"+
			"IsTransferredToFolio = {14}\n"+
			"PropertyID = {15}\n"+
			"CompanyID = {16}\n"+
			"SeqNo = {17}\n"+
			"IsSynch = {18}\n"+
			"SynchOn = {19}\n"+
			"UpdatedOn = {20}\n"+
			"UpdatedBy = {21}\n"+
			"IsActive = {22}\n",
			GuestLaundryID,			ReservationID,			RoomID,			FolioID,			GuestName,			DateOfReceived,			DateToReturn,			IsReturned,			DocateNo,			IsBilled,			BilledAmt,			Remarks,			GeneralBillID,			IsPaid,			IsTransferredToFolio,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class GuestLaundryKeys
	{

		#region Data Members

		Guid _guestLaundryID;

		#endregion

		#region Constructor

		public GuestLaundryKeys(Guid guestLaundryID)
		{
			 _guestLaundryID = guestLaundryID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  GuestLaundryID
		{
			 get { return _guestLaundryID; }
		}

		#endregion

	}
}
