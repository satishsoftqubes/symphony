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
	public class MoveRoom: BusinessObjectBase
	{

		#region InnerClass
		public enum MoveRoomFields
		{
			MoveRoomID,
			RefMoveRoomID,
			MoveType_TermID,
			Reasom,
			OldRoomID,
			NewRoomID,
			ConfirmedBy,
			DateOfMove,
			IsByExtraCost,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
            ReservationID,
            DateUpTo
		}
		#endregion

		#region Data Members

			Guid _moveRoomID;
			Guid? _refMoveRoomID;
			Guid? _moveType_TermID;
			string _reasom;
			Guid? _oldRoomID;
			Guid? _newRoomID;
			Guid? _confirmedBy;
			DateTime? _dateOfMove;
			bool? _isByExtraCost;
			Guid? _propertyID;
			Guid? _companyID;
			long _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
            Guid? _reservationID;
            DateTime? _dateUpTo;

		#endregion

		#region Properties

		[DataMember]
		public Guid  MoveRoomID
		{
			 get { return _moveRoomID; }
			 set
			 {
				 if (_moveRoomID != value)
				 {
					_moveRoomID = value;
					 PropertyHasChanged("MoveRoomID");
				 }
			 }
		}

		[DataMember]
		public Guid?  RefMoveRoomID
		{
			 get { return _refMoveRoomID; }
			 set
			 {
				 if (_refMoveRoomID != value)
				 {
					_refMoveRoomID = value;
					 PropertyHasChanged("RefMoveRoomID");
				 }
			 }
		}

		[DataMember]
		public Guid?  MoveType_TermID
		{
			 get { return _moveType_TermID; }
			 set
			 {
				 if (_moveType_TermID != value)
				 {
					_moveType_TermID = value;
					 PropertyHasChanged("MoveType_TermID");
				 }
			 }
		}

		[DataMember]
		public string  Reasom
		{
			 get { return _reasom; }
			 set
			 {
				 if (_reasom != value)
				 {
					_reasom = value;
					 PropertyHasChanged("Reasom");
				 }
			 }
		}

		[DataMember]
		public Guid?  OldRoomID
		{
			 get { return _oldRoomID; }
			 set
			 {
				 if (_oldRoomID != value)
				 {
					_oldRoomID = value;
					 PropertyHasChanged("OldRoomID");
				 }
			 }
		}

		[DataMember]
		public Guid?  NewRoomID
		{
			 get { return _newRoomID; }
			 set
			 {
				 if (_newRoomID != value)
				 {
					_newRoomID = value;
					 PropertyHasChanged("NewRoomID");
				 }
			 }
		}

		[DataMember]
		public Guid?  ConfirmedBy
		{
			 get { return _confirmedBy; }
			 set
			 {
				 if (_confirmedBy != value)
				 {
					_confirmedBy = value;
					 PropertyHasChanged("ConfirmedBy");
				 }
			 }
		}

		[DataMember]
		public DateTime?  DateOfMove
		{
			 get { return _dateOfMove; }
			 set
			 {
				 if (_dateOfMove != value)
				 {
					_dateOfMove = value;
					 PropertyHasChanged("DateOfMove");
				 }
			 }
		}

		[DataMember]
		public bool?  IsByExtraCost
		{
			 get { return _isByExtraCost; }
			 set
			 {
				 if (_isByExtraCost != value)
				 {
					_isByExtraCost = value;
					 PropertyHasChanged("IsByExtraCost");
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
        public Guid? ReservationID
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
        public DateTime? DateUpTo
        {
            get { return _dateUpTo; }
            set
            {
                if (_dateUpTo != value)
                {
                    _dateUpTo = value;
                    PropertyHasChanged("DateUpTo");
                }
            }
        }
		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("MoveRoomID", "MoveRoomID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Reasom", "Reasom",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"MoveRoomID = {0}\n"+
			"RefMoveRoomID = {1}\n"+
			"MoveType_TermID = {2}\n"+
			"Reasom = {3}\n"+
			"OldRoomID = {4}\n"+
			"NewRoomID = {5}\n"+
			"ConfirmedBy = {6}\n"+
			"DateOfMove = {7}\n"+
			"IsByExtraCost = {8}\n"+
			"PropertyID = {9}\n"+
			"CompanyID = {10}\n"+
			"SeqNo = {11}\n"+
			"IsSynch = {12}\n"+
			"SynchOn = {13}\n"+
			"UpdatedOn = {14}\n"+
			"UpdatedBy = {15}\n"+
            "IsActive = {16}\n" +
            "ReservationID = {17}\n" +
            "DateUpTo = {18}\n",
            MoveRoomID, RefMoveRoomID, MoveType_TermID, Reasom, OldRoomID, NewRoomID, ConfirmedBy, DateOfMove, IsByExtraCost, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, ReservationID, DateUpTo); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class MoveRoomKeys
	{

		#region Data Members

		Guid _moveRoomID;

		#endregion

		#region Constructor

		public MoveRoomKeys(Guid moveRoomID)
		{
			 _moveRoomID = moveRoomID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  MoveRoomID
		{
			 get { return _moveRoomID; }
		}

		#endregion

	}
}
