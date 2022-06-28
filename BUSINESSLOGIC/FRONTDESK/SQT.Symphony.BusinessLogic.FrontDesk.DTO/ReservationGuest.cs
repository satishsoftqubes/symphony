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
	public class ReservationGuest: BusinessObjectBase
	{

		#region InnerClass
		public enum ReservationGuestFields
		{
			ReservationGuestID,
			ReservationID,
			GuestID,
			RelationToParentGuest_TermID,
			CheckInDate,
			CheckOutDate,
			GuestNotes,
			Status_TermID,
			IsBilledToCustomer,
			FolioID,
			RoomID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
            Status,
            Cashcard_Number,
            CheckOutNote
		}
		#endregion

		#region Data Members

			Guid _reservationGuestID;
			Guid? _reservationID;
			Guid? _guestID;
			Guid? _relationToParentGuest_TermID;
			DateTime? _checkInDate;
			DateTime? _checkOutDate;
			string _guestNotes;
			Guid? _status_TermID;
			bool? _isBilledToCustomer;
			Guid? _folioID;
			Guid? _roomID;
			Guid? _propertyID;
			Guid? _companyID;
			long _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
            string _status;
            string _cashcard_Number;
            string _checkOutNote;

		#endregion

		#region Properties

		[DataMember]
		public Guid  ReservationGuestID
		{
			 get { return _reservationGuestID; }
			 set
			 {
				 if (_reservationGuestID != value)
				 {
					_reservationGuestID = value;
					 PropertyHasChanged("ReservationGuestID");
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
		public Guid?  RelationToParentGuest_TermID
		{
			 get { return _relationToParentGuest_TermID; }
			 set
			 {
				 if (_relationToParentGuest_TermID != value)
				 {
					_relationToParentGuest_TermID = value;
					 PropertyHasChanged("RelationToParentGuest_TermID");
				 }
			 }
		}

		[DataMember]
		public DateTime?  CheckInDate
		{
			 get { return _checkInDate; }
			 set
			 {
				 if (_checkInDate != value)
				 {
					_checkInDate = value;
					 PropertyHasChanged("CheckInDate");
				 }
			 }
		}

		[DataMember]
		public DateTime?  CheckOutDate
		{
			 get { return _checkOutDate; }
			 set
			 {
				 if (_checkOutDate != value)
				 {
					_checkOutDate = value;
					 PropertyHasChanged("CheckOutDate");
				 }
			 }
		}

		[DataMember]
		public string  GuestNotes
		{
			 get { return _guestNotes; }
			 set
			 {
				 if (_guestNotes != value)
				 {
					_guestNotes = value;
					 PropertyHasChanged("GuestNotes");
				 }
			 }
		}

		[DataMember]
		public Guid?  Status_TermID
		{
			 get { return _status_TermID; }
			 set
			 {
				 if (_status_TermID != value)
				 {
					_status_TermID = value;
					 PropertyHasChanged("Status_TermID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsBilledToCustomer
		{
			 get { return _isBilledToCustomer; }
			 set
			 {
				 if (_isBilledToCustomer != value)
				 {
					_isBilledToCustomer = value;
					 PropertyHasChanged("IsBilledToCustomer");
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

        [DataMember]
        public string Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    PropertyHasChanged("Status");
                }
            }
        }

        [DataMember]
        public string Cashcard_Number
        {
            get { return _cashcard_Number; }
            set
            {
                if (_cashcard_Number != value)
                {
                    _cashcard_Number = value;
                    PropertyHasChanged("Cashcard_Number");
                }
            }
        }

        [DataMember]
        public string CheckOutNote
        {
            get { return _checkOutNote; }
            set
            {
                if (_checkOutNote != value)
                {
                    _checkOutNote = value;
                    PropertyHasChanged("CheckOutNote");
                }
            }
        }


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ReservationGuestID", "ReservationGuestID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("GuestNotes", "GuestNotes",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ReservationGuestID = {0}\n"+
			"ReservationID = {1}\n"+
			"GuestID = {2}\n"+
			"RelationToParentGuest_TermID = {3}\n"+
			"CheckInDate = {4}\n"+
			"CheckOutDate = {5}\n"+
			"GuestNotes = {6}\n"+
			"Status_TermID = {7}\n"+
			"IsBilledToCustomer = {8}\n"+
			"FolioID = {9}\n"+
			"RoomID = {10}\n"+
			"PropertyID = {11}\n"+
			"CompanyID = {12}\n"+
			"SeqNo = {13}\n"+
			"IsSynch = {14}\n"+
			"SynchOn = {15}\n"+
			"UpdatedOn = {16}\n"+
			"UpdatedBy = {17}\n"+
			"IsActive = {18}\n"+
            "Status={19}\n"+
            "Cashcard_Number={20}\n" +
            "CheckOutNote={21}\n",

            ReservationGuestID, ReservationID, GuestID, RelationToParentGuest_TermID, CheckInDate, CheckOutDate, GuestNotes, Status_TermID, IsBilledToCustomer, FolioID, RoomID, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, Status, Cashcard_Number, CheckOutNote); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ReservationGuestKeys
	{

		#region Data Members

		Guid _reservationGuestID;

		#endregion

		#region Constructor

		public ReservationGuestKeys(Guid reservationGuestID)
		{
			 _reservationGuestID = reservationGuestID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ReservationGuestID
		{
			 get { return _reservationGuestID; }
		}

		#endregion

	}
}
