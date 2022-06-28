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
	public class RoomType: BusinessObjectBase
	{

		#region InnerClass
		public enum RoomTypeFields
		{
			RoomTypeID,
			PropertyID,
			SeqNo,
			RoomTypeCode,
			RoomTypeName,
			ElevationDrawing,
			IsBlock,
			RackRate,
			CreditLimit,
			SoftRooms,
			MaxWaitingList,
			Overbooking,
			ReleaseDays,
			DefaultRateID,
			CoverageCodeID,
			MinimumStay,
			MaximumStay,
			IsDiscountApplicable,
			MaximumAdults,
			MaximumChilds,
			IsAvailableOnIRS,
			RoomTypeImage,
			AboutRoomType,
			CancellationCharges,
			IsCancellationInPereentege,
			RetentionCharge,
			IsRetentionInPercentage,
			CreatedOn,
			CreatedBy,
			UpdatedBy,
			UpdatedOn,
			UpdatedLog,
			IsActive,
			IsSynch,
			SynchOn,
			ImagePath,
			IsOBInPercentage,
			SBArea,
			CarpetArea,
            PerFlat_TermID,
            NoOfBeds,
            BedSize,
            IsExtraBedAllow,
            NoOfExtraBed
		}
		#endregion

		#region Data Members

			Guid _roomTypeID;
			Guid? _propertyID;
			int? _seqNo;
			string _roomTypeCode;
			string _roomTypeName;
			string _elevationDrawing;
			bool? _isBlock;
			decimal? _rackRate;
			decimal? _creditLimit;
			int? _softRooms;
			int? _maxWaitingList;
			decimal? _overbooking;
			int? _releaseDays;
			Guid? _defaultRateID;
			Guid? _coverageCodeID;
			int? _minimumStay;
			int? _maximumStay;
			bool? _isDiscountApplicable;
			int? _maximumAdults;
			int? _maximumChilds;
			bool? _isAvailableOnIRS;
			byte[] _roomTypeImage;
			string _aboutRoomType;
			decimal? _cancellationCharges;
			bool? _isCancellationInPereentege;
			decimal? _retentionCharge;
			bool? _isRetentionInPercentage;
			DateTime? _createdOn;
			Guid? _createdBy;
			Guid? _updatedBy;
			DateTime? _updatedOn;
			byte[] _updatedLog;
			bool? _isActive;
			bool? _isSynch;
			DateTime? _synchOn;
			string _imagePath;
			bool? _isOBInPercentage;
			decimal? _sBArea;
			decimal? _carpetArea;
            Guid? _perFlat_TermID;
            int? _NoOfBeds;    
            string _BedSize;
            bool? _IsExtraBedAllow;
            int? _NoOfExtraBed;

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoomTypeID
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
		public int?  SeqNo
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
		public string  RoomTypeCode
		{
			 get { return _roomTypeCode; }
			 set
			 {
				 if (_roomTypeCode != value)
				 {
					_roomTypeCode = value;
					 PropertyHasChanged("RoomTypeCode");
				 }
			 }
		}

		[DataMember]
		public string  RoomTypeName
		{
			 get { return _roomTypeName; }
			 set
			 {
				 if (_roomTypeName != value)
				 {
					_roomTypeName = value;
					 PropertyHasChanged("RoomTypeName");
				 }
			 }
		}

		[DataMember]
		public string  ElevationDrawing
		{
			 get { return _elevationDrawing; }
			 set
			 {
				 if (_elevationDrawing != value)
				 {
					_elevationDrawing = value;
					 PropertyHasChanged("ElevationDrawing");
				 }
			 }
		}

		[DataMember]
		public bool?  IsBlock
		{
			 get { return _isBlock; }
			 set
			 {
				 if (_isBlock != value)
				 {
					_isBlock = value;
					 PropertyHasChanged("IsBlock");
				 }
			 }
		}

		[DataMember]
		public decimal?  RackRate
		{
			 get { return _rackRate; }
			 set
			 {
				 if (_rackRate != value)
				 {
					_rackRate = value;
					 PropertyHasChanged("RackRate");
				 }
			 }
		}

		[DataMember]
		public decimal?  CreditLimit
		{
			 get { return _creditLimit; }
			 set
			 {
				 if (_creditLimit != value)
				 {
					_creditLimit = value;
					 PropertyHasChanged("CreditLimit");
				 }
			 }
		}

		[DataMember]
		public int?  SoftRooms
		{
			 get { return _softRooms; }
			 set
			 {
				 if (_softRooms != value)
				 {
					_softRooms = value;
					 PropertyHasChanged("SoftRooms");
				 }
			 }
		}

		[DataMember]
		public int?  MaxWaitingList
		{
			 get { return _maxWaitingList; }
			 set
			 {
				 if (_maxWaitingList != value)
				 {
					_maxWaitingList = value;
					 PropertyHasChanged("MaxWaitingList");
				 }
			 }
		}

		[DataMember]
		public decimal?  Overbooking
		{
			 get { return _overbooking; }
			 set
			 {
				 if (_overbooking != value)
				 {
					_overbooking = value;
					 PropertyHasChanged("Overbooking");
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
		public Guid?  DefaultRateID
		{
			 get { return _defaultRateID; }
			 set
			 {
				 if (_defaultRateID != value)
				 {
					_defaultRateID = value;
					 PropertyHasChanged("DefaultRateID");
				 }
			 }
		}

		[DataMember]
		public Guid?  CoverageCodeID
		{
			 get { return _coverageCodeID; }
			 set
			 {
				 if (_coverageCodeID != value)
				 {
					_coverageCodeID = value;
					 PropertyHasChanged("CoverageCodeID");
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
		public int?  MaximumAdults
		{
			 get { return _maximumAdults; }
			 set
			 {
				 if (_maximumAdults != value)
				 {
					_maximumAdults = value;
					 PropertyHasChanged("MaximumAdults");
				 }
			 }
		}

		[DataMember]
		public int?  MaximumChilds
		{
			 get { return _maximumChilds; }
			 set
			 {
				 if (_maximumChilds != value)
				 {
					_maximumChilds = value;
					 PropertyHasChanged("MaximumChilds");
				 }
			 }
		}

		[DataMember]
        public bool? IsAvailableOnIRS
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
		public byte[]  RoomTypeImage
		{
			 get { return _roomTypeImage; }
			 set
			 {
				 if (_roomTypeImage != value)
				 {
					_roomTypeImage = value;
					 PropertyHasChanged("RoomTypeImage");
				 }
			 }
		}

		[DataMember]
		public string  AboutRoomType
		{
			 get { return _aboutRoomType; }
			 set
			 {
				 if (_aboutRoomType != value)
				 {
					_aboutRoomType = value;
					 PropertyHasChanged("AboutRoomType");
				 }
			 }
		}

		[DataMember]
		public decimal?  CancellationCharges
		{
			 get { return _cancellationCharges; }
			 set
			 {
				 if (_cancellationCharges != value)
				 {
					_cancellationCharges = value;
					 PropertyHasChanged("CancellationCharges");
				 }
			 }
		}

		[DataMember]
		public bool?  IsCancellationInPereentege
		{
			 get { return _isCancellationInPereentege; }
			 set
			 {
				 if (_isCancellationInPereentege != value)
				 {
					_isCancellationInPereentege = value;
					 PropertyHasChanged("IsCancellationInPereentege");
				 }
			 }
		}

		[DataMember]
		public decimal?  RetentionCharge
		{
			 get { return _retentionCharge; }
			 set
			 {
				 if (_retentionCharge != value)
				 {
					_retentionCharge = value;
					 PropertyHasChanged("RetentionCharge");
				 }
			 }
		}

		[DataMember]
		public bool?  IsRetentionInPercentage
		{
			 get { return _isRetentionInPercentage; }
			 set
			 {
				 if (_isRetentionInPercentage != value)
				 {
					_isRetentionInPercentage = value;
					 PropertyHasChanged("IsRetentionInPercentage");
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
		public byte[]  UpdatedLog
		{
			 get { return _updatedLog; }
			 set
			 {
				 if (_updatedLog != value)
				 {
					_updatedLog = value;
					 PropertyHasChanged("UpdatedLog");
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
		public string  ImagePath
		{
			 get { return _imagePath; }
			 set
			 {
				 if (_imagePath != value)
				 {
					_imagePath = value;
					 PropertyHasChanged("ImagePath");
				 }
			 }
		}

		[DataMember]
		public bool?  IsOBInPercentage
		{
			 get { return _isOBInPercentage; }
			 set
			 {
				 if (_isOBInPercentage != value)
				 {
					_isOBInPercentage = value;
					 PropertyHasChanged("IsOBInPercentage");
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
        public Guid? PerFlat_TermID
        {
            get { return _perFlat_TermID; }
            set
            {
                if (_perFlat_TermID != value)
                {
                    _perFlat_TermID = value;
                    PropertyHasChanged("PerFlat_TermID");
                }
            }
        }

        [DataMember]
        public string BedSize
        {
            get { return _BedSize; }
            set
            {
                if (_BedSize != value)
                {
                    _BedSize = value;
                    PropertyHasChanged("BedSize");
                }
            }
        }

        [DataMember]
        public int? NoOfBeds
        {
            get { return _NoOfBeds; }
            set
            {
                if (_NoOfBeds != value)
                {
                    _NoOfBeds = value;
                    PropertyHasChanged("NoOfBeds");
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("RoomTypeID", "RoomTypeID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("RoomTypeCode", "RoomTypeCode",7));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("RoomTypeName", "RoomTypeName",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ElevationDrawing", "ElevationDrawing",2147483647));
			//ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("IsAvailableOnIRS", "IsAvailableOnIRS",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("AboutRoomType", "AboutRoomType",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ImagePath", "ImagePath",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"RoomTypeID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"SeqNo = {2}~\n"+
			"RoomTypeCode = {3}~\n"+
			"RoomTypeName = {4}~\n"+
			"ElevationDrawing = {5}~\n"+
			"IsBlock = {6}~\n"+
			"RackRate = {7}~\n"+
			"CreditLimit = {8}~\n"+
			"SoftRooms = {9}~\n"+
			"MaxWaitingList = {10}~\n"+
			"Overbooking = {11}~\n"+
			"ReleaseDays = {12}~\n"+
			"DefaultRateID = {13}~\n"+
			"CoverageCodeID = {14}~\n"+
			"MinimumStay = {15}~\n"+
			"MaximumStay = {16}~\n"+
			"IsDiscountApplicable = {17}~\n"+
			"MaximumAdults = {18}~\n"+
			"MaximumChilds = {19}~\n"+
			"IsAvailableOnIRS = {20}~\n"+
			"RoomTypeImage = {21}~\n"+
			"AboutRoomType = {22}~\n"+
			"CancellationCharges = {23}~\n"+
			"IsCancellationInPereentege = {24}~\n"+
			"RetentionCharge = {25}~\n"+
			"IsRetentionInPercentage = {26}~\n"+
			"CreatedOn = {27}~\n"+
			"CreatedBy = {28}~\n"+
			"UpdatedBy = {29}~\n"+
			"UpdatedOn = {30}~\n"+
			"UpdatedLog = {31}~\n"+
			"IsActive = {32}~\n"+
			"IsSynch = {33}~\n"+
			"SynchOn = {34}~\n"+
			"ImagePath = {35}~\n"+
			"IsOBInPercentage = {36}~\n"+
			"SBArea = {37}~\n"+
            "CarpetArea = {38}~\n" +
            "PerFlat_TermID = {39}~\n" +
            "NoOfBeds = {40}~\n" +
            "BedSize = {41}~\n" +
            "IsExtraBedAllow = {42}~\n" +
            "NoOfExtraBed = {43}~\n",
            RoomTypeID, PropertyID, SeqNo, RoomTypeCode, RoomTypeName, ElevationDrawing, IsBlock, RackRate, CreditLimit, SoftRooms, MaxWaitingList, Overbooking, ReleaseDays, DefaultRateID, CoverageCodeID, MinimumStay, MaximumStay, IsDiscountApplicable, MaximumAdults, MaximumChilds, IsAvailableOnIRS, RoomTypeImage, AboutRoomType, CancellationCharges, IsCancellationInPereentege, RetentionCharge, IsRetentionInPercentage, CreatedOn, CreatedBy, UpdatedBy, UpdatedOn, UpdatedLog, IsActive, IsSynch, SynchOn, ImagePath, IsOBInPercentage, SBArea, CarpetArea, PerFlat_TermID, NoOfBeds, BedSize, IsExtraBedAllow, NoOfExtraBed); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class RoomTypeKeys
	{

		#region Data Members

		Guid _roomTypeID;

		#endregion

		#region Constructor

		public RoomTypeKeys(Guid roomTypeID)
		{
			 _roomTypeID = roomTypeID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoomTypeID
		{
			 get { return _roomTypeID; }
		}

		#endregion

	}
}
