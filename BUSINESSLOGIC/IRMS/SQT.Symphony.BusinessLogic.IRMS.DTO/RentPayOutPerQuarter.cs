using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;
namespace SQT.Symphony.BusinessLogic.IRMS.DTO
{
	[DataContract]
	public class RentPayOutPerQuarter: BusinessObjectBase
	{

		#region InnerClass
		public enum RentPayOutPerQuarterFields
		{
			RentPayoutID,
			QuarterID,
			TotalAreaOfComplex,
			SelfOccupiedArea,
			AreaUnderPMS,
			RoomRentCollected,
			InterestOnRoomRent,
			TotalAmountToDistribute,
			PropertyManagementCharge,
			NetAmountToDistribute,
			RentYieldPerSqft,
			RentYieldPerDay,
			PropertyID,
			CompanyID,
			SeqNo,
			IsActive,
			CreatedOn,
			CreatedBy,
			IsSync,
			SyncOn,
            ServiceTax,
            BankCharges,
            TotalAmountToDeduct,
            RemainingRoomRent
		}
		#endregion

		#region Data Members

			Guid _rentPayoutID;
			Guid? _quarterID;
			decimal? _totalAreaOfComplex;
			decimal? _selfOccupiedArea;
			decimal? _areaUnderPMS;
			decimal? _roomRentCollected;
			decimal? _interestOnRoomRent;
			decimal? _totalAmountToDistribute;
			decimal? _propertyManagementCharge;
			decimal? _netAmountToDistribute;
			decimal? _rentYieldPerSqft;
			decimal? _rentYieldPerDay;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isActive;
			DateTime? _createdOn;
			Guid? _createdBy;
			bool? _isSync;
			DateTime? _syncOn;
            decimal? _serviceTax;
            decimal? _bankCharges;
            decimal? _totalAmountToDeduct;
            decimal? _remainingRoomRent;

		#endregion

		#region Properties

		[DataMember]
		public Guid  RentPayoutID
		{
			 get { return _rentPayoutID; }
			 set
			 {
				 if (_rentPayoutID != value)
				 {
					_rentPayoutID = value;
					 PropertyHasChanged("RentPayoutID");
				 }
			 }
		}

		[DataMember]
		public Guid?  QuarterID
		{
			 get { return _quarterID; }
			 set
			 {
				 if (_quarterID != value)
				 {
					_quarterID = value;
					 PropertyHasChanged("QuarterID");
				 }
			 }
		}

		[DataMember]
		public decimal?  TotalAreaOfComplex
		{
			 get { return _totalAreaOfComplex; }
			 set
			 {
				 if (_totalAreaOfComplex != value)
				 {
					_totalAreaOfComplex = value;
					 PropertyHasChanged("TotalAreaOfComplex");
				 }
			 }
		}

		[DataMember]
		public decimal?  SelfOccupiedArea
		{
			 get { return _selfOccupiedArea; }
			 set
			 {
				 if (_selfOccupiedArea != value)
				 {
					_selfOccupiedArea = value;
					 PropertyHasChanged("SelfOccupiedArea");
				 }
			 }
		}

		[DataMember]
		public decimal?  AreaUnderPMS
		{
			 get { return _areaUnderPMS; }
			 set
			 {
				 if (_areaUnderPMS != value)
				 {
					_areaUnderPMS = value;
					 PropertyHasChanged("AreaUnderPMS");
				 }
			 }
		}

		[DataMember]
		public decimal?  RoomRentCollected
		{
			 get { return _roomRentCollected; }
			 set
			 {
				 if (_roomRentCollected != value)
				 {
					_roomRentCollected = value;
					 PropertyHasChanged("RoomRentCollected");
				 }
			 }
		}

		[DataMember]
		public decimal?  InterestOnRoomRent
		{
			 get { return _interestOnRoomRent; }
			 set
			 {
				 if (_interestOnRoomRent != value)
				 {
					_interestOnRoomRent = value;
					 PropertyHasChanged("InterestOnRoomRent");
				 }
			 }
		}

		[DataMember]
		public decimal?  TotalAmountToDistribute
		{
			 get { return _totalAmountToDistribute; }
			 set
			 {
				 if (_totalAmountToDistribute != value)
				 {
					_totalAmountToDistribute = value;
					 PropertyHasChanged("TotalAmountToDistribute");
				 }
			 }
		}

		[DataMember]
		public decimal?  PropertyManagementCharge
		{
			 get { return _propertyManagementCharge; }
			 set
			 {
				 if (_propertyManagementCharge != value)
				 {
					_propertyManagementCharge = value;
					 PropertyHasChanged("PropertyManagementCharge");
				 }
			 }
		}

		[DataMember]
		public decimal?  NetAmountToDistribute
		{
			 get { return _netAmountToDistribute; }
			 set
			 {
				 if (_netAmountToDistribute != value)
				 {
					_netAmountToDistribute = value;
					 PropertyHasChanged("NetAmountToDistribute");
				 }
			 }
		}

		[DataMember]
		public decimal?  RentYieldPerSqft
		{
			 get { return _rentYieldPerSqft; }
			 set
			 {
				 if (_rentYieldPerSqft != value)
				 {
					_rentYieldPerSqft = value;
					 PropertyHasChanged("RentYieldPerSqft");
				 }
			 }
		}

		[DataMember]
		public decimal?  RentYieldPerDay
		{
			 get { return _rentYieldPerDay; }
			 set
			 {
				 if (_rentYieldPerDay != value)
				 {
					_rentYieldPerDay = value;
					 PropertyHasChanged("RentYieldPerDay");
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
		public bool?  IsSync
		{
			 get { return _isSync; }
			 set
			 {
				 if (_isSync != value)
				 {
					_isSync = value;
					 PropertyHasChanged("IsSync");
				 }
			 }
		}

		[DataMember]
		public DateTime?  SyncOn
		{
			 get { return _syncOn; }
			 set
			 {
				 if (_syncOn != value)
				 {
					_syncOn = value;
					 PropertyHasChanged("SyncOn");
				 }
			 }
		}

        [DataMember]
        public decimal? ServiceTax
        {
            get { return _serviceTax; }
            set
            {
                if (_serviceTax != value)
                {
                    _serviceTax = value;
                    PropertyHasChanged("ServiceTax");
                }
            }
        }

        [DataMember]
        public decimal? BankCharges
        {
            get { return _bankCharges; }
            set
            {
                if (_bankCharges != value)
                {
                    _bankCharges = value;
                    PropertyHasChanged("BankCharges");
                }
            }
        }

        [DataMember]
        public decimal? TotalAmountToDeduct
        {
            get { return _totalAmountToDeduct; }
            set
            {
                if (_totalAmountToDeduct != value)
                {
                    _totalAmountToDeduct = value;
                    PropertyHasChanged("TotalAmountToDeduct");
                }
            }
        }

        [DataMember]
        public decimal? RemainingRoomRent
        {
            get { return _remainingRoomRent; }
            set
            {
                if (_remainingRoomRent != value)
                {
                    _remainingRoomRent = value;
                    PropertyHasChanged("RemainingRoomRent");
                }
            }
        }
		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("RentPayoutID", "RentPayoutID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"RentPayoutID = {0}\n"+
			"QuarterID = {1}\n"+
			"TotalAreaOfComplex = {2}\n"+
			"SelfOccupiedArea = {3}\n"+
			"AreaUnderPMS = {4}\n"+
			"RoomRentCollected = {5}\n"+
			"InterestOnRoomRent = {6}\n"+
			"TotalAmountToDistribute = {7}\n"+
			"PropertyManagementCharge = {8}\n"+
			"NetAmountToDistribute = {9}\n"+
			"RentYieldPerSqft = {10}\n"+
			"RentYieldPerDay = {11}\n"+
			"PropertyID = {12}\n"+
			"CompanyID = {13}\n"+
			"SeqNo = {14}\n"+
			"IsActive = {15}\n"+
			"CreatedOn = {16}\n"+
			"CreatedBy = {17}\n"+
			"IsSync = {18}\n"+
            "SyncOn = {19}\n" +
            "ServiceTax = {20}\n" +
            "BankCharges = {21}\n" +
            "TotalAmountToDeduct = {22}\n"+
            "RemainingRoomRent = {23}\n",
            RentPayoutID, QuarterID, TotalAreaOfComplex, SelfOccupiedArea, AreaUnderPMS, RoomRentCollected, InterestOnRoomRent, TotalAmountToDistribute, PropertyManagementCharge, NetAmountToDistribute, RentYieldPerSqft, RentYieldPerDay, PropertyID, CompanyID, SeqNo, IsActive, CreatedOn, CreatedBy, IsSync, SyncOn, ServiceTax, BankCharges, TotalAmountToDeduct, RemainingRoomRent); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class RentPayOutPerQuarterKeys
	{

		#region Data Members

		Guid _rentPayoutID;

		#endregion

		#region Constructor

		public RentPayOutPerQuarterKeys(Guid rentPayoutID)
		{
			 _rentPayoutID = rentPayoutID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  RentPayoutID
		{
			 get { return _rentPayoutID; }
		}

		#endregion

	}
}
