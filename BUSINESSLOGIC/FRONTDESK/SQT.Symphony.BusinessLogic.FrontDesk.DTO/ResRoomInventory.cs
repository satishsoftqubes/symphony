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
	public class ResRoomInventory: BusinessObjectBase
	{

		#region InnerClass
		public enum ResRoomInventoryFields
		{
			ResRoomInventoryID,
			ReservationID,
			BlockDateRateID,
			RoomTypeID,
			RoomID,
			Date,
			Status_TermID,
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

			Guid _resRoomInventoryID;
			Guid? _reservationID;
			Guid? _blockDateRateID;
			Guid? _roomTypeID;
			Guid? _roomID;
			DateTime? _date;
			Guid? _status_TermID;
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
		public Guid  ResRoomInventoryID
		{
			 get { return _resRoomInventoryID; }
			 set
			 {
				 if (_resRoomInventoryID != value)
				 {
					_resRoomInventoryID = value;
					 PropertyHasChanged("ResRoomInventoryID");
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
		public Guid?  BlockDateRateID
		{
			 get { return _blockDateRateID; }
			 set
			 {
				 if (_blockDateRateID != value)
				 {
					_blockDateRateID = value;
					 PropertyHasChanged("BlockDateRateID");
				 }
			 }
		}

		[DataMember]
		public Guid?  RoomTypeID
		{
			 get { return _roomTypeID; }
			 set
			 {
				 if (_roomTypeID != value)
				 {
					_roomTypeID = value;
					 PropertyHasChanged("RoomTypeID");
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
		public DateTime?  Date
		{
			 get { return _date; }
			 set
			 {
				 if (_date != value)
				 {
					_date = value;
					 PropertyHasChanged("Date");
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ResRoomInventoryID", "ResRoomInventoryID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ResRoomInventoryID = {0}\n"+
			"ReservationID = {1}\n"+
			"BlockDateRateID = {2}\n"+
			"RoomTypeID = {3}\n"+
			"RoomID = {4}\n"+
			"Date = {5}\n"+
			"Status_TermID = {6}\n"+
			"PropertyID = {7}\n"+
			"CompanyID = {8}\n"+
			"SeqNo = {9}\n"+
			"IsSynch = {10}\n"+
			"SynchOn = {11}\n"+
			"UpdatedOn = {12}\n"+
			"UpdatedBy = {13}\n"+
			"IsActive = {14}\n",
			ResRoomInventoryID,			ReservationID,			BlockDateRateID,			RoomTypeID,			RoomID,			Date,			Status_TermID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ResRoomInventoryKeys
	{

		#region Data Members

		Guid _resRoomInventoryID;

		#endregion

		#region Constructor

		public ResRoomInventoryKeys(Guid resRoomInventoryID)
		{
			 _resRoomInventoryID = resRoomInventoryID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ResRoomInventoryID
		{
			 get { return _resRoomInventoryID; }
		}

		#endregion

	}
}
