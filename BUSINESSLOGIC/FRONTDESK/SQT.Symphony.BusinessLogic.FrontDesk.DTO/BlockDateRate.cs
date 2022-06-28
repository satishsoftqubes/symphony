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
	public class BlockDateRate: BusinessObjectBase
	{

		#region InnerClass
		public enum BlockDateRateFields
		{
			ResBlockDateRateID,
			ReservationID,
			RateID,
			RoomID,
			BlockDate,
			StartDate,
			EndDate,
			PostingDate,
			BookID,
			RoomRate,
			DiscountAmt,
			IsFerEarly,
			IsFerLate,
			ReRouteFolioID,
			ReRouteCharge,
			RateCardRate,
			DiscountID,
			AppliedTax,
			ConferenceID,
			RoomTypeID,
			ResStatus_TermID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
            IsOverBook,
            IsOverStay,
            InfraServiceCharge,
            FoodCharge,
            ElectricityCharge
		}
		#endregion

		#region Data Members

			Guid _resBlockDateRateID;
			Guid? _reservationID;
			Guid? _rateID;
			Guid? _roomID;
			DateTime? _blockDate;
			DateTime? _startDate;
			DateTime? _endDate;
			DateTime? _postingDate;
			Guid? _bookID;
			decimal? _roomRate;
			decimal? _discountAmt;
			bool? _isFerEarly;
			bool? _isFerLate;
			Guid? _reRouteFolioID;
			decimal? _reRouteCharge;
			decimal? _rateCardRate;
			Guid? _discountID;
			decimal? _appliedTax;
			Guid? _conferenceID;
			Guid? _roomTypeID;
			int? _resStatus_TermID;
			Guid? _propertyID;
			Guid? _companyID;
			long _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
            bool? _isOverBook;
            bool? _isOverStay;
            decimal? _infraServiceCharge;
            decimal? _foodCharge;
            decimal? _electricityCharge;
		#endregion

		#region Properties

		[DataMember]
		public Guid  ResBlockDateRateID
		{
			 get { return _resBlockDateRateID; }
			 set
			 {
				 if (_resBlockDateRateID != value)
				 {
					_resBlockDateRateID = value;
					 PropertyHasChanged("ResBlockDateRateID");
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
		public Guid?  RateID
		{
			 get { return _rateID; }
			 set
			 {
				 if (_rateID != value)
				 {
					_rateID = value;
					 PropertyHasChanged("RateID");
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
		public DateTime?  BlockDate
		{
			 get { return _blockDate; }
			 set
			 {
				 if (_blockDate != value)
				 {
					_blockDate = value;
					 PropertyHasChanged("BlockDate");
				 }
			 }
		}

		[DataMember]
		public DateTime?  StartDate
		{
			 get { return _startDate; }
			 set
			 {
				 if (_startDate != value)
				 {
					_startDate = value;
					 PropertyHasChanged("StartDate");
				 }
			 }
		}

		[DataMember]
		public DateTime?  EndDate
		{
			 get { return _endDate; }
			 set
			 {
				 if (_endDate != value)
				 {
					_endDate = value;
					 PropertyHasChanged("EndDate");
				 }
			 }
		}

		[DataMember]
		public DateTime?  PostingDate
		{
			 get { return _postingDate; }
			 set
			 {
				 if (_postingDate != value)
				 {
					_postingDate = value;
					 PropertyHasChanged("PostingDate");
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
		public decimal?  RoomRate
		{
			 get { return _roomRate; }
			 set
			 {
				 if (_roomRate != value)
				 {
					_roomRate = value;
					 PropertyHasChanged("RoomRate");
				 }
			 }
		}

		[DataMember]
		public decimal?  DiscountAmt
		{
			 get { return _discountAmt; }
			 set
			 {
				 if (_discountAmt != value)
				 {
					_discountAmt = value;
					 PropertyHasChanged("DiscountAmt");
				 }
			 }
		}

		[DataMember]
		public bool?  IsFerEarly
		{
			 get { return _isFerEarly; }
			 set
			 {
				 if (_isFerEarly != value)
				 {
					_isFerEarly = value;
					 PropertyHasChanged("IsFerEarly");
				 }
			 }
		}

		[DataMember]
		public bool?  IsFerLate
		{
			 get { return _isFerLate; }
			 set
			 {
				 if (_isFerLate != value)
				 {
					_isFerLate = value;
					 PropertyHasChanged("IsFerLate");
				 }
			 }
		}

		[DataMember]
		public Guid?  ReRouteFolioID
		{
			 get { return _reRouteFolioID; }
			 set
			 {
				 if (_reRouteFolioID != value)
				 {
					_reRouteFolioID = value;
					 PropertyHasChanged("ReRouteFolioID");
				 }
			 }
		}

		[DataMember]
		public decimal?  ReRouteCharge
		{
			 get { return _reRouteCharge; }
			 set
			 {
				 if (_reRouteCharge != value)
				 {
					_reRouteCharge = value;
					 PropertyHasChanged("ReRouteCharge");
				 }
			 }
		}

		[DataMember]
		public decimal?  RateCardRate
		{
			 get { return _rateCardRate; }
			 set
			 {
				 if (_rateCardRate != value)
				 {
					_rateCardRate = value;
					 PropertyHasChanged("RateCardRate");
				 }
			 }
		}

		[DataMember]
		public Guid?  DiscountID
		{
			 get { return _discountID; }
			 set
			 {
				 if (_discountID != value)
				 {
					_discountID = value;
					 PropertyHasChanged("DiscountID");
				 }
			 }
		}

		[DataMember]
		public decimal?  AppliedTax
		{
			 get { return _appliedTax; }
			 set
			 {
				 if (_appliedTax != value)
				 {
					_appliedTax = value;
					 PropertyHasChanged("AppliedTax");
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
		public int?  ResStatus_TermID
		{
			 get { return _resStatus_TermID; }
			 set
			 {
				 if (_resStatus_TermID != value)
				 {
					_resStatus_TermID = value;
					 PropertyHasChanged("ResStatus_TermID");
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
        public bool? IsOverBook
		{
			 get { return _isOverBook; }
			 set
			 {
                 if (_isOverBook != value)
				 {
                     _isOverBook = value;
                    PropertyHasChanged("IsOverBook");
				 }
			 }
		}

        [DataMember]
        public bool? IsOverStay
        {
            get { return _isOverStay; }
            set
            {
                if (_isOverStay != value)
                {
                    _isOverStay = value;
                    PropertyHasChanged("IsOverStay");
                }
            }
        }

        [DataMember]
        public decimal? InfraServiceCharge
        {
            get { return _infraServiceCharge; }
            set
            {
                if (_infraServiceCharge != value)
                {
                    _infraServiceCharge = value;
                    PropertyHasChanged("InfraServiceCharge");
                }
            }
        }

        [DataMember]
        public decimal? FoodCharge
        {
            get { return _foodCharge; }
            set
            {
                if (_foodCharge != value)
                {
                    _foodCharge = value;
                    PropertyHasChanged("FoodCharge");
                }
            }
        }

        [DataMember]
        public decimal? ElectricityCharge
        {
            get { return _electricityCharge; }
            set
            {
                if (_electricityCharge != value)
                {
                    _electricityCharge = value;
                    PropertyHasChanged("ElectricityCharge");
                }
            }
        }
        
		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ResBlockDateRateID", "ResBlockDateRateID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ResBlockDateRateID = {0}\n"+
			"ReservationID = {1}\n"+
			"RateID = {2}\n"+
			"RoomID = {3}\n"+
			"BlockDate = {4}\n"+
			"StartDate = {5}\n"+
			"EndDate = {6}\n"+
			"PostingDate = {7}\n"+
			"BookID = {8}\n"+
			"RoomRate = {9}\n"+
			"DiscountAmt = {10}\n"+
			"IsFerEarly = {11}\n"+
			"IsFerLate = {12}\n"+
			"ReRouteFolioID = {13}\n"+
			"ReRouteCharge = {14}\n"+
			"RateCardRate = {15}\n"+
			"DiscountID = {16}\n"+
			"AppliedTax = {17}\n"+
			"ConferenceID = {18}\n"+
			"RoomTypeID = {19}\n"+
			"ResStatus_TermID = {20}\n"+
			"PropertyID = {21}\n"+
			"CompanyID = {22}\n"+
			"SeqNo = {23}\n"+
			"IsSynch = {24}\n"+
			"SynchOn = {25}\n"+
			"UpdatedOn = {26}\n"+
			"UpdatedBy = {27}\n"+
            "IsActive = {28}\n" +
			"IsOverBook = {29}\n" +
            "IsOverStay = {30}\n",
            ResBlockDateRateID, ReservationID, RateID, RoomID, BlockDate, StartDate, EndDate, PostingDate, BookID, RoomRate, DiscountAmt, IsFerEarly, IsFerLate, ReRouteFolioID, ReRouteCharge, RateCardRate, DiscountID, AppliedTax, ConferenceID, RoomTypeID, ResStatus_TermID, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, IsOverBook,IsOverStay); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class BlockDateRateKeys
	{

		#region Data Members

		Guid _resBlockDateRateID;

		#endregion

		#region Constructor

		public BlockDateRateKeys(Guid resBlockDateRateID)
		{
			 _resBlockDateRateID = resBlockDateRateID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ResBlockDateRateID
		{
			 get { return _resBlockDateRateID; }
		}

		#endregion

	}
}
