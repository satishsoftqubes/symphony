using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;
namespace SQT.Symphony.BusinessLogic.Configuration.DTO
{
	[DataContract]
	public class Room: BusinessObjectBase
	{

		#region InnerClass
		public enum RoomFields
		{
			RoomID,
			PropertyID,
			WingID,
			FloorID,
			RoomNo,
			RoomTypeID,
			BedTypeID,
			SBArea,
			CarpetArea,
			IsSold,
			LocationDetail,
			Thumb1,
			Thumb2,
			OrderSeqNo,
			KeyNo,
			ExtentionNo,
			NoOfBeds,
			IsBlocked,
			IsAvailableOnIRS,
			EmergencyExitDesc,
			NoOfAdults,
			NoOfChilds,
			HKPSectionID,
			MinimalHKPdays,
			FullHKPDays,
			ConnectingRoomLID,
			ConnectingRoomRID,
			OppositeRoomID,
			DataNo,
			InvesterID,
			CreatedBy,
			CreatedOn,
			UpdatedBy,
			UpdatedOn,
			UpdateLog,
			IsActive,
			PropertyTaxNo,
			PropertyTaxAmt,
			IsPaidPropertyTax,
			LastDateOfPaid,
			SelfPrioritySeqNo,
			RoomClassID,
			ReleaseDays,
			MinimumStay,
			MaximumStay,
			IsDiscountApplicable,
			IsSynch,
			SynchOn,
			SeqNo,
            ReferenceRoomID,
            IsSmokingAllowed,
            IsExtraBedAllow,
            NoOfExtraBed
		}
		#endregion

		#region Data Members

			Guid _roomID;
			Guid? _propertyID;
			Guid? _wingID;
			Guid? _floorID;
			string _roomNo;
			Guid? _roomTypeID;
			Guid? _bedTypeID;
			decimal? _sBArea;
			decimal? _carpetArea;
			bool? _isSold;
			string _locationDetail;
			string _thumb1;
			byte[] _thumb2;
			int? _orderSeqNo;
			string _keyNo;
			string _extentionNo;
			int? _noOfBeds;
			bool? _isBlocked;
			bool? _isAvailableOnIRS;
			string _emergencyExitDesc;
			int? _noOfAdults;
			int? _noOfChilds;
			Guid? _hKPSectionID;
			string _minimalHKPdays;
			string _fullHKPDays;
			Guid? _connectingRoomLID;
			Guid? _connectingRoomRID;
			Guid? _oppositeRoomID;
			string _dataNo;
			Guid? _investerID;
			Guid? _createdBy;
			DateTime? _createdOn;
			Guid? _updatedBy;
			DateTime? _updatedOn;
			byte[] _updateLog;
			bool? _isActive;
			string _propertyTaxNo;
			decimal? _propertyTaxAmt;
			bool? _isPaidPropertyTax;
			DateTime? _lastDateOfPaid;
			int? _selfPrioritySeqNo;
			Guid? _roomClassID;
			int? _releaseDays;
			int? _minimumStay;
			int? _maximumStay;
			bool? _isDiscountApplicable;
			bool? _isSynch;
			DateTime? _synchOn;
			int _seqNo;
            Guid? _ReferenceRoomID;
            bool? _IsSmokingAllowed;
            bool? _IsExtraBedAllow;
            int? _NoOfExtraBed;

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoomID
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
		public Guid?  WingID
		{
			 get { return _wingID; }
			 set
			 {
				 if (_wingID != value)
				 {
					_wingID = value;
					 PropertyHasChanged("WingID");
				 }
			 }
		}

		[DataMember]
		public Guid?  FloorID
		{
			 get { return _floorID; }
			 set
			 {
				 if (_floorID != value)
				 {
					_floorID = value;
					 PropertyHasChanged("FloorID");
				 }
			 }
		}

		[DataMember]
		public string  RoomNo
		{
			 get { return _roomNo; }
			 set
			 {
				 if (_roomNo != value)
				 {
					_roomNo = value;
					 PropertyHasChanged("RoomNo");
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
		public Guid?  BedTypeID
		{
			 get { return _bedTypeID; }
			 set
			 {
				 if (_bedTypeID != value)
				 {
					_bedTypeID = value;
					 PropertyHasChanged("BedTypeID");
				 }
			 }
		}

		[DataMember]
		public decimal?  SBArea
		{
			 get { return _sBArea; }
			 set
			 {
				 if (_sBArea != value)
				 {
					_sBArea = value;
					 PropertyHasChanged("SBArea");
				 }
			 }
		}

		[DataMember]
		public decimal?  CarpetArea
		{
			 get { return _carpetArea; }
			 set
			 {
				 if (_carpetArea != value)
				 {
					_carpetArea = value;
					 PropertyHasChanged("CarpetArea");
				 }
			 }
		}

		[DataMember]
		public bool?  IsSold
		{
			 get { return _isSold; }
			 set
			 {
				 if (_isSold != value)
				 {
					_isSold = value;
					 PropertyHasChanged("IsSold");
				 }
			 }
		}

		[DataMember]
		public string  LocationDetail
		{
			 get { return _locationDetail; }
			 set
			 {
				 if (_locationDetail != value)
				 {
					_locationDetail = value;
					 PropertyHasChanged("LocationDetail");
				 }
			 }
		}

		[DataMember]
		public string  Thumb1
		{
			 get { return _thumb1; }
			 set
			 {
				 if (_thumb1 != value)
				 {
					_thumb1 = value;
					 PropertyHasChanged("Thumb1");
				 }
			 }
		}

		[DataMember]
		public byte[]  Thumb2
		{
			 get { return _thumb2; }
			 set
			 {
				 if (_thumb2 != value)
				 {
					_thumb2 = value;
					 PropertyHasChanged("Thumb2");
				 }
			 }
		}

		[DataMember]
		public int?  OrderSeqNo
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
		public string  KeyNo
		{
			 get { return _keyNo; }
			 set
			 {
				 if (_keyNo != value)
				 {
					_keyNo = value;
					 PropertyHasChanged("KeyNo");
				 }
			 }
		}

		[DataMember]
		public string  ExtentionNo
		{
			 get { return _extentionNo; }
			 set
			 {
				 if (_extentionNo != value)
				 {
					_extentionNo = value;
					 PropertyHasChanged("ExtentionNo");
				 }
			 }
		}

		[DataMember]
		public int?  NoOfBeds
		{
			 get { return _noOfBeds; }
			 set
			 {
				 if (_noOfBeds != value)
				 {
					_noOfBeds = value;
					 PropertyHasChanged("NoOfBeds");
				 }
			 }
		}

		[DataMember]
		public bool?  IsBlocked
		{
			 get { return _isBlocked; }
			 set
			 {
				 if (_isBlocked != value)
				 {
					_isBlocked = value;
					 PropertyHasChanged("IsBlocked");
				 }
			 }
		}

		[DataMember]
		public bool?  IsAvailableOnIRS
		{
			 get { return _isAvailableOnIRS; }
			 set
			 {
				 if (_isAvailableOnIRS != value)
				 {
					_isAvailableOnIRS = value;
					 PropertyHasChanged("IsAvailableOnIRS");
				 }
			 }
		}

		[DataMember]
		public string  EmergencyExitDesc
		{
			 get { return _emergencyExitDesc; }
			 set
			 {
				 if (_emergencyExitDesc != value)
				 {
					_emergencyExitDesc = value;
					 PropertyHasChanged("EmergencyExitDesc");
				 }
			 }
		}

		[DataMember]
		public int?  NoOfAdults
		{
			 get { return _noOfAdults; }
			 set
			 {
				 if (_noOfAdults != value)
				 {
					_noOfAdults = value;
					 PropertyHasChanged("NoOfAdults");
				 }
			 }
		}

		[DataMember]
		public int?  NoOfChilds
		{
			 get { return _noOfChilds; }
			 set
			 {
				 if (_noOfChilds != value)
				 {
					_noOfChilds = value;
					 PropertyHasChanged("NoOfChilds");
				 }
			 }
		}

		[DataMember]
		public Guid?  HKPSectionID
		{
			 get { return _hKPSectionID; }
			 set
			 {
				 if (_hKPSectionID != value)
				 {
					_hKPSectionID = value;
					 PropertyHasChanged("HKPSectionID");
				 }
			 }
		}

		[DataMember]
		public string  MinimalHKPdays
		{
			 get { return _minimalHKPdays; }
			 set
			 {
				 if (_minimalHKPdays != value)
				 {
					_minimalHKPdays = value;
					 PropertyHasChanged("MinimalHKPdays");
				 }
			 }
		}

		[DataMember]
		public string  FullHKPDays
		{
			 get { return _fullHKPDays; }
			 set
			 {
				 if (_fullHKPDays != value)
				 {
					_fullHKPDays = value;
					 PropertyHasChanged("FullHKPDays");
				 }
			 }
		}

		[DataMember]
		public Guid?  ConnectingRoomLID
		{
			 get { return _connectingRoomLID; }
			 set
			 {
				 if (_connectingRoomLID != value)
				 {
					_connectingRoomLID = value;
					 PropertyHasChanged("ConnectingRoomLID");
				 }
			 }
		}

		[DataMember]
		public Guid?  ConnectingRoomRID
		{
			 get { return _connectingRoomRID; }
			 set
			 {
				 if (_connectingRoomRID != value)
				 {
					_connectingRoomRID = value;
					 PropertyHasChanged("ConnectingRoomRID");
				 }
			 }
		}

		[DataMember]
		public Guid?  OppositeRoomID
		{
			 get { return _oppositeRoomID; }
			 set
			 {
				 if (_oppositeRoomID != value)
				 {
					_oppositeRoomID = value;
					 PropertyHasChanged("OppositeRoomID");
				 }
			 }
		}

		[DataMember]
		public string  DataNo
		{
			 get { return _dataNo; }
			 set
			 {
				 if (_dataNo != value)
				 {
					_dataNo = value;
					 PropertyHasChanged("DataNo");
				 }
			 }
		}

		[DataMember]
		public Guid?  InvesterID
		{
			 get { return _investerID; }
			 set
			 {
				 if (_investerID != value)
				 {
					_investerID = value;
					 PropertyHasChanged("InvesterID");
				 }
			 }
		}

		[DataMember]
		public Guid?  CreatedBy
		{
			 get { return _createdBy; }
			 set
			 {
				 if (_createdBy != value)
				 {
					_createdBy = value;
					 PropertyHasChanged("CreatedBy");
				 }
			 }
		}

		[DataMember]
		public DateTime?  CreatedOn
		{
			 get { return _createdOn; }
			 set
			 {
				 if (_createdOn != value)
				 {
					_createdOn = value;
					 PropertyHasChanged("CreatedOn");
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
		public string  PropertyTaxNo
		{
			 get { return _propertyTaxNo; }
			 set
			 {
				 if (_propertyTaxNo != value)
				 {
					_propertyTaxNo = value;
					 PropertyHasChanged("PropertyTaxNo");
				 }
			 }
		}

		[DataMember]
		public decimal?  PropertyTaxAmt
		{
			 get { return _propertyTaxAmt; }
			 set
			 {
				 if (_propertyTaxAmt != value)
				 {
					_propertyTaxAmt = value;
					 PropertyHasChanged("PropertyTaxAmt");
				 }
			 }
		}

		[DataMember]
		public bool?  IsPaidPropertyTax
		{
			 get { return _isPaidPropertyTax; }
			 set
			 {
				 if (_isPaidPropertyTax != value)
				 {
					_isPaidPropertyTax = value;
					 PropertyHasChanged("IsPaidPropertyTax");
				 }
			 }
		}

		[DataMember]
		public DateTime?  LastDateOfPaid
		{
			 get { return _lastDateOfPaid; }
			 set
			 {
				 if (_lastDateOfPaid != value)
				 {
					_lastDateOfPaid = value;
					 PropertyHasChanged("LastDateOfPaid");
				 }
			 }
		}

		[DataMember]
		public int?  SelfPrioritySeqNo
		{
			 get { return _selfPrioritySeqNo; }
			 set
			 {
				 if (_selfPrioritySeqNo != value)
				 {
					_selfPrioritySeqNo = value;
					 PropertyHasChanged("SelfPrioritySeqNo");
				 }
			 }
		}

		[DataMember]
		public Guid?  RoomClassID
		{
			 get { return _roomClassID; }
			 set
			 {
				 if (_roomClassID != value)
				 {
					_roomClassID = value;
					 PropertyHasChanged("RoomClassID");
				 }
			 }
		}

		[DataMember]
		public int?  ReleaseDays
		{
			 get { return _releaseDays; }
			 set
			 {
				 if (_releaseDays != value)
				 {
					_releaseDays = value;
					 PropertyHasChanged("ReleaseDays");
				 }
			 }
		}

		[DataMember]
		public int?  MinimumStay
		{
			 get { return _minimumStay; }
			 set
			 {
				 if (_minimumStay != value)
				 {
					_minimumStay = value;
					 PropertyHasChanged("MinimumStay");
				 }
			 }
		}

		[DataMember]
		public int?  MaximumStay
		{
			 get { return _maximumStay; }
			 set
			 {
				 if (_maximumStay != value)
				 {
					_maximumStay = value;
					 PropertyHasChanged("MaximumStay");
				 }
			 }
		}

		[DataMember]
		public bool?  IsDiscountApplicable
		{
			 get { return _isDiscountApplicable; }
			 set
			 {
				 if (_isDiscountApplicable != value)
				 {
					_isDiscountApplicable = value;
					 PropertyHasChanged("IsDiscountApplicable");
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
        public Guid? ReferenceRoomID
        {
            get { return _ReferenceRoomID; }
            set
            {
                if (_ReferenceRoomID != value)
                {
                    _ReferenceRoomID = value;
                    PropertyHasChanged("ReferenceRoomID");
                }
            }
        }

        [DataMember]
        public bool? IsSmokingAllowed
        {
            get { return _IsSmokingAllowed; }
            set
            {
                if (_IsSmokingAllowed != value)
                {
                    _IsSmokingAllowed = value;
                    PropertyHasChanged("IsSmokingAllowed");
                }
            }
        }

        [DataMember]
        public bool? IsExtraBedAllow
        {
            get { return _IsExtraBedAllow; }
            set
            {
                if (_IsExtraBedAllow != value)
                {
                    _IsExtraBedAllow = value;
                    PropertyHasChanged("IsExtraBedAllow");
                }
            }
        }

        [DataMember]
        public int? NoOfExtraBed
        {
            get { return _NoOfExtraBed; }
            set
            {
                if (_NoOfExtraBed != value)
                {
                    _NoOfExtraBed = value;
                    PropertyHasChanged("NoOfExtraBed");
                }
            }
        }

		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("RoomID", "RoomID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("RoomNo", "RoomNo",9));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("LocationDetail", "LocationDetail",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Thumb1", "Thumb1",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("KeyNo", "KeyNo",10));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ExtentionNo", "ExtentionNo",10));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("EmergencyExitDesc", "EmergencyExitDesc",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("MinimalHKPdays", "MinimalHKPdays",43));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("FullHKPDays", "FullHKPDays",43));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("DataNo", "DataNo",320));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PropertyTaxNo", "PropertyTaxNo",300));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"RoomID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"WingID = {2}~\n"+
			"FloorID = {3}~\n"+
			"RoomNo = {4}~\n"+
			"RoomTypeID = {5}~\n"+
			"BedTypeID = {6}~\n"+
			"SBArea = {7}~\n"+
			"CarpetArea = {8}~\n"+
			"IsSold = {9}~\n"+
			"LocationDetail = {10}~\n"+
			"Thumb1 = {11}~\n"+
			"Thumb2 = {12}~\n"+
			"OrderSeqNo = {13}~\n"+
			"KeyNo = {14}~\n"+
			"ExtentionNo = {15}~\n"+
			"NoOfBeds = {16}~\n"+
			"IsBlocked = {17}~\n"+
			"IsAvailableOnIRS = {18}~\n"+
			"EmergencyExitDesc = {19}~\n"+
			"NoOfAdults = {20}~\n"+
			"NoOfChilds = {21}~\n"+
			"HKPSectionID = {22}~\n"+
			"MinimalHKPdays = {23}~\n"+
			"FullHKPDays = {24}~\n"+
			"ConnectingRoomLID = {25}~\n"+
			"ConnectingRoomRID = {26}~\n"+
			"OppositeRoomID = {27}~\n"+
			"DataNo = {28}~\n"+
			"InvesterID = {29}~\n"+
			"CreatedBy = {30}~\n"+
			"CreatedOn = {31}~\n"+
			"UpdatedBy = {32}~\n"+
			"UpdatedOn = {33}~\n"+
			"UpdateLog = {34}~\n"+
			"IsActive = {35}~\n"+
			"PropertyTaxNo = {36}~\n"+
			"PropertyTaxAmt = {37}~\n"+
			"IsPaidPropertyTax = {38}~\n"+
			"LastDateOfPaid = {39}~\n"+
			"SelfPrioritySeqNo = {40}~\n"+
			"RoomClassID = {41}~\n"+
			"ReleaseDays = {42}~\n"+
			"MinimumStay = {43}~\n"+
			"MaximumStay = {44}~\n"+
			"IsDiscountApplicable = {45}~\n"+
			"IsSynch = {46}~\n"+
			"SynchOn = {47}~\n"+
            "SynchOn = {48}~\n" +
            "ReferenceRoomID = {49}~\n" +
            "IsSmokingAllowed = {50}~\n" +
            "IsExtraBedAllow = {51}~\n" +
            "NoOfExtraBed = {52}~\n",
            RoomID, PropertyID, WingID, FloorID, RoomNo, RoomTypeID, BedTypeID, SBArea, CarpetArea, IsSold, LocationDetail, Thumb1, Thumb2, OrderSeqNo, KeyNo, ExtentionNo, NoOfBeds, IsBlocked, IsAvailableOnIRS, EmergencyExitDesc, NoOfAdults, NoOfChilds, HKPSectionID, MinimalHKPdays, FullHKPDays, ConnectingRoomLID, ConnectingRoomRID, OppositeRoomID, DataNo, InvesterID, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, UpdateLog, IsActive, PropertyTaxNo, PropertyTaxAmt, IsPaidPropertyTax, LastDateOfPaid, SelfPrioritySeqNo, RoomClassID, ReleaseDays, MinimumStay, MaximumStay, IsDiscountApplicable, IsSynch, SynchOn, SeqNo, ReferenceRoomID, IsSmokingAllowed, IsExtraBedAllow, NoOfExtraBed); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class RoomKeys
	{

		#region Data Members

		Guid _roomID;

		#endregion

		#region Constructor

		public RoomKeys(Guid roomID)
		{
			 _roomID = roomID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoomID
		{
			 get { return _roomID; }
		}

		#endregion

	}
}
