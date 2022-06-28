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
	public class ResHouseKeeping: BusinessObjectBase
	{

		#region InnerClass
		public enum ResHouseKeepingFields
		{
			ResHKPID,
			ReservationID,
			HKDate,
			HKPType_TermID,
			RoomID,
			ConferenceID,
			RoomStatus_TermID,
			CleanType_TermID,
			IsScheduleData,
			IsOnDemandHK,
			RequestedOwnerID,
			OwnerType_TermID,
			RequestedDate,
			HandledDate,
			Request,
			HandledBy,
			HouseKeepingType_TermID,
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

			Guid _resHKPID;
			Guid? _reservationID;
			DateTime? _hKDate;
			Guid? _hKPType_TermID;
			Guid? _roomID;
			Guid? _conferenceID;
			Guid? _roomStatus_TermID;
			Guid? _cleanType_TermID;
			bool? _isScheduleData;
			bool? _isOnDemandHK;
			Guid? _requestedOwnerID;
			Guid? _ownerType_TermID;
			DateTime? _requestedDate;
			DateTime? _handledDate;
			string _request;
			Guid? _handledBy;
			Guid? _houseKeepingType_TermID;
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
		public Guid  ResHKPID
		{
			 get { return _resHKPID; }
			 set
			 {
				 if (_resHKPID != value)
				 {
					_resHKPID = value;
					 PropertyHasChanged("ResHKPID");
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
		public DateTime?  HKDate
		{
			 get { return _hKDate; }
			 set
			 {
				 if (_hKDate != value)
				 {
					_hKDate = value;
					 PropertyHasChanged("HKDate");
				 }
			 }
		}

		[DataMember]
		public Guid?  HKPType_TermID
		{
			 get { return _hKPType_TermID; }
			 set
			 {
				 if (_hKPType_TermID != value)
				 {
					_hKPType_TermID = value;
					 PropertyHasChanged("HKPType_TermID");
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
		public Guid?  ConferenceID
		{
			 get { return _conferenceID; }
			 set
			 {
				 if (_conferenceID != value)
				 {
					_conferenceID = value;
					 PropertyHasChanged("ConferenceID");
				 }
			 }
		}

		[DataMember]
		public Guid?  RoomStatus_TermID
		{
			 get { return _roomStatus_TermID; }
			 set
			 {
				 if (_roomStatus_TermID != value)
				 {
					_roomStatus_TermID = value;
					 PropertyHasChanged("RoomStatus_TermID");
				 }
			 }
		}

		[DataMember]
		public Guid?  CleanType_TermID
		{
			 get { return _cleanType_TermID; }
			 set
			 {
				 if (_cleanType_TermID != value)
				 {
					_cleanType_TermID = value;
					 PropertyHasChanged("CleanType_TermID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsScheduleData
		{
			 get { return _isScheduleData; }
			 set
			 {
				 if (_isScheduleData != value)
				 {
					_isScheduleData = value;
					 PropertyHasChanged("IsScheduleData");
				 }
			 }
		}

		[DataMember]
		public bool?  IsOnDemandHK
		{
			 get { return _isOnDemandHK; }
			 set
			 {
				 if (_isOnDemandHK != value)
				 {
					_isOnDemandHK = value;
					 PropertyHasChanged("IsOnDemandHK");
				 }
			 }
		}

		[DataMember]
		public Guid?  RequestedOwnerID
		{
			 get { return _requestedOwnerID; }
			 set
			 {
				 if (_requestedOwnerID != value)
				 {
					_requestedOwnerID = value;
					 PropertyHasChanged("RequestedOwnerID");
				 }
			 }
		}

		[DataMember]
		public Guid?  OwnerType_TermID
		{
			 get { return _ownerType_TermID; }
			 set
			 {
				 if (_ownerType_TermID != value)
				 {
					_ownerType_TermID = value;
					 PropertyHasChanged("OwnerType_TermID");
				 }
			 }
		}

		[DataMember]
		public DateTime?  RequestedDate
		{
			 get { return _requestedDate; }
			 set
			 {
				 if (_requestedDate != value)
				 {
					_requestedDate = value;
					 PropertyHasChanged("RequestedDate");
				 }
			 }
		}

		[DataMember]
		public DateTime?  HandledDate
		{
			 get { return _handledDate; }
			 set
			 {
				 if (_handledDate != value)
				 {
					_handledDate = value;
					 PropertyHasChanged("HandledDate");
				 }
			 }
		}

		[DataMember]
		public string  Request
		{
			 get { return _request; }
			 set
			 {
				 if (_request != value)
				 {
					_request = value;
					 PropertyHasChanged("Request");
				 }
			 }
		}

		[DataMember]
		public Guid?  HandledBy
		{
			 get { return _handledBy; }
			 set
			 {
				 if (_handledBy != value)
				 {
					_handledBy = value;
					 PropertyHasChanged("HandledBy");
				 }
			 }
		}

		[DataMember]
		public Guid?  HouseKeepingType_TermID
		{
			 get { return _houseKeepingType_TermID; }
			 set
			 {
				 if (_houseKeepingType_TermID != value)
				 {
					_houseKeepingType_TermID = value;
					 PropertyHasChanged("HouseKeepingType_TermID");
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ResHKPID", "ResHKPID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Request", "Request",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ResHKPID = {0}\n"+
			"ReservationID = {1}\n"+
			"HKDate = {2}\n"+
			"HKPType_TermID = {3}\n"+
			"RoomID = {4}\n"+
			"ConferenceID = {5}\n"+
			"RoomStatus_TermID = {6}\n"+
			"CleanType_TermID = {7}\n"+
			"IsScheduleData = {8}\n"+
			"IsOnDemandHK = {9}\n"+
			"RequestedOwnerID = {10}\n"+
			"OwnerType_TermID = {11}\n"+
			"RequestedDate = {12}\n"+
			"HandledDate = {13}\n"+
			"Request = {14}\n"+
			"HandledBy = {15}\n"+
			"HouseKeepingType_TermID = {16}\n"+
			"PropertyID = {17}\n"+
			"CompanyID = {18}\n"+
			"SeqNo = {19}\n"+
			"IsSynch = {20}\n"+
			"SynchOn = {21}\n"+
			"UpdatedOn = {22}\n"+
			"UpdatedBy = {23}\n"+
			"IsActive = {24}\n",
			ResHKPID,			ReservationID,			HKDate,			HKPType_TermID,			RoomID,			ConferenceID,			RoomStatus_TermID,			CleanType_TermID,			IsScheduleData,			IsOnDemandHK,			RequestedOwnerID,			OwnerType_TermID,			RequestedDate,			HandledDate,			Request,			HandledBy,			HouseKeepingType_TermID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ResHouseKeepingKeys
	{

		#region Data Members

		Guid _resHKPID;

		#endregion

		#region Constructor

		public ResHouseKeepingKeys(Guid resHKPID)
		{
			 _resHKPID = resHKPID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ResHKPID
		{
			 get { return _resHKPID; }
		}

		#endregion

	}
}
