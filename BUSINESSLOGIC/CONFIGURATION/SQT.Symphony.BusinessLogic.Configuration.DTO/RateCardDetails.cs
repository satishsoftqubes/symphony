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
	public class RateCardDetails: BusinessObjectBase
	{

		#region InnerClass
		public enum RateCardDetailsFields
		{
			RateCardDetailID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			RateID,
			RoomTypeID,
			OccupencyLevelID,
			RackRate,
			ExtraAdultRate,
			ChildRate,
			MondayRate,
			TuesdayRate,
			WednesdayRate,
			ThursdayRate,
			FridayRate,
			SaturdayRate,
			SundayRate,
			ConferenceID,
            DepositAmount,
            ExtarbedCharge,
            TotalRackRate
		}
		#endregion

		#region Data Members

			Guid _rateCardDetailID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			Guid? _rateID;
			Guid? _roomTypeID;
			Guid? _occupencyLevelID;
			decimal? _rackRate;
			decimal? _extraAdultRate;
			decimal? _childRate;
			decimal? _mondayRate;
			decimal? _tuesdayRate;
			decimal? _wednesdayRate;
			decimal? _thursdayRate;
			decimal? _fridayRate;
			decimal? _saturdayRate;
			decimal? _sundayRate;
			Guid? _conferenceID;
            decimal? _depositAmount;
            decimal? _extarbedCharge;
            decimal? _totalRackRate;

		#endregion

		#region Properties

		[DataMember]
		public Guid  RateCardDetailID
		{
			 get { return _rateCardDetailID; }
			 set
			 {
				 if (_rateCardDetailID != value)
				 {
					_rateCardDetailID = value;
					 PropertyHasChanged("RateCardDetailID");
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
		public Guid?  OccupencyLevelID
		{
			 get { return _occupencyLevelID; }
			 set
			 {
				 if (_occupencyLevelID != value)
				 {
					_occupencyLevelID = value;
					 PropertyHasChanged("OccupencyLevelID");
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
		public decimal?  ExtraAdultRate
		{
			 get { return _extraAdultRate; }
			 set
			 {
				 if (_extraAdultRate != value)
				 {
					_extraAdultRate = value;
					 PropertyHasChanged("ExtraAdultRate");
				 }
			 }
		}

		[DataMember]
		public decimal?  ChildRate
		{
			 get { return _childRate; }
			 set
			 {
				 if (_childRate != value)
				 {
					_childRate = value;
					 PropertyHasChanged("ChildRate");
				 }
			 }
		}

		[DataMember]
		public decimal?  MondayRate
		{
			 get { return _mondayRate; }
			 set
			 {
				 if (_mondayRate != value)
				 {
					_mondayRate = value;
					 PropertyHasChanged("MondayRate");
				 }
			 }
		}

		[DataMember]
		public decimal?  TuesdayRate
		{
			 get { return _tuesdayRate; }
			 set
			 {
				 if (_tuesdayRate != value)
				 {
					_tuesdayRate = value;
					 PropertyHasChanged("TuesdayRate");
				 }
			 }
		}

		[DataMember]
		public decimal?  WednesdayRate
		{
			 get { return _wednesdayRate; }
			 set
			 {
				 if (_wednesdayRate != value)
				 {
					_wednesdayRate = value;
					 PropertyHasChanged("WednesdayRate");
				 }
			 }
		}

		[DataMember]
		public decimal?  ThursdayRate
		{
			 get { return _thursdayRate; }
			 set
			 {
				 if (_thursdayRate != value)
				 {
					_thursdayRate = value;
					 PropertyHasChanged("ThursdayRate");
				 }
			 }
		}

		[DataMember]
		public decimal?  FridayRate
		{
			 get { return _fridayRate; }
			 set
			 {
				 if (_fridayRate != value)
				 {
					_fridayRate = value;
					 PropertyHasChanged("FridayRate");
				 }
			 }
		}

		[DataMember]
		public decimal?  SaturdayRate
		{
			 get { return _saturdayRate; }
			 set
			 {
				 if (_saturdayRate != value)
				 {
					_saturdayRate = value;
					 PropertyHasChanged("SaturdayRate");
				 }
			 }
		}

		[DataMember]
		public decimal?  SundayRate
		{
			 get { return _sundayRate; }
			 set
			 {
				 if (_sundayRate != value)
				 {
					_sundayRate = value;
					 PropertyHasChanged("SundayRate");
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
        public decimal? DepositAmount
        {
            get { return _depositAmount; }
            set
            {
                if (_depositAmount != value)
                {
                    _depositAmount = value;
                    PropertyHasChanged("DepositAmount");
                }
            }
        }

        [DataMember]
        public decimal? ExtarbedCharge
        {
            get { return _extarbedCharge; }
            set
            {
                if (_extarbedCharge != value)
                {
                    _extarbedCharge = value;
                    PropertyHasChanged("ExtarbedCharge");
                }
            }
        }

        [DataMember]
        public decimal? TotalRackRate
        {
            get { return _totalRackRate; }
            set
            {
                if (_totalRackRate != value)
                {
                    _totalRackRate = value;
                    PropertyHasChanged("TotalRackRate");
                }
            }
        }

		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("RateCardDetailID", "RateCardDetailID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"RateCardDetailID = {0}~\n"+
			"SeqNo = {1}~\n"+
			"IsSynch = {2}~\n"+
			"SynchOn = {3}~\n"+
			"UpdatedOn = {4}~\n"+
			"UpdatedBy = {5}~\n"+
			"IsActive = {6}~\n"+
			"RateID = {7}~\n"+
			"RoomTypeID = {8}~\n"+
			"OccupencyLevelID = {9}~\n"+
			"RackRate = {10}~\n"+
			"ExtraAdultRate = {11}~\n"+
			"ChildRate = {12}~\n"+
			"MondayRate = {13}~\n"+
			"TuesdayRate = {14}~\n"+
			"WednesdayRate = {15}~\n"+
			"ThursdayRate = {16}~\n"+
			"FridayRate = {17}~\n"+
			"SaturdayRate = {18}~\n"+
			"SundayRate = {19}~\n"+
            "ConferenceID = {20}~\n" +
            "DepositAmount = {21}~\n" +
            "ExtarbedCharge = {22}~\n" +
            "TotalRackRate = {23}~\n",
            RateCardDetailID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, RateID, RoomTypeID, OccupencyLevelID, RackRate, ExtraAdultRate, ChildRate, MondayRate, TuesdayRate, WednesdayRate, ThursdayRate, FridayRate, SaturdayRate, SundayRate, ConferenceID, DepositAmount, ExtarbedCharge, TotalRackRate); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class RateCardDetailsKeys
	{

		#region Data Members

		Guid _rateCardDetailID;

		#endregion

		#region Constructor

		public RateCardDetailsKeys(Guid rateCardDetailID)
		{
			 _rateCardDetailID = rateCardDetailID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  RateCardDetailID
		{
			 get { return _rateCardDetailID; }
		}

		#endregion

	}
}
