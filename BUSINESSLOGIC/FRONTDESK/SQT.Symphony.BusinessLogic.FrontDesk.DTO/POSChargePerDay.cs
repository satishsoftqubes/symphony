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
	public class POSChargePerDay: BusinessObjectBase
	{

		#region InnerClass
		public enum POSChargePerDayFields
		{
			POSChargeID,
			ReservationID,
			ChargeAmount,
			CreatedBy,
			CreatedOn,
			UpdatedBy,
			UpdatedOn,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
            RateCardID,
            RoomTypeID
		}
		#endregion

		#region Data Members

			Guid _pOSChargeID;
			Guid? _reservationID;
			decimal? _chargeAmount;
			Guid? _createdBy;
			DateTime? _createdOn;
			Guid? _updatedBy;
			DateTime? _updatedOn;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
            Guid? _rateCardID;
            Guid? _roomTypeID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  POSChargeID
		{
			 get { return _pOSChargeID; }
			 set
			 {
				 if (_pOSChargeID != value)
				 {
					_pOSChargeID = value;
					 PropertyHasChanged("POSChargeID");
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
		public decimal?  ChargeAmount
		{
			 get { return _chargeAmount; }
			 set
			 {
				 if (_chargeAmount != value)
				 {
					_chargeAmount = value;
					 PropertyHasChanged("ChargeAmount");
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
        public Guid? RateCardID
        {
            get { return _rateCardID; }
            set
            {
                if (_rateCardID != value)
                {
                    _rateCardID = value;
                    PropertyHasChanged("RateCardID");
                }
            }
        }

        [DataMember]
        public Guid? RoomTypeID
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
		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("POSChargeID", "POSChargeID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"POSChargeID = {0}\n"+
			"ReservationID = {1}\n"+
			"ChargeAmount = {2}\n"+
			"CreatedBy = {3}\n"+
			"CreatedOn = {4}\n"+
			"UpdatedBy = {5}\n"+
			"UpdatedOn = {6}\n"+
			"PropertyID = {7}\n"+
			"CompanyID = {8}\n"+
			"SeqNo = {9}\n"+
			"IsSynch = {10}\n"+
			"SynchOn = {11}\n"+
            "RateCardID = {12}\n" +
            "RoomTypeID = {13}\n",
            POSChargeID, ReservationID, ChargeAmount, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, RateCardID,RoomTypeID); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class POSChargePerDayKeys
	{

		#region Data Members

		Guid _pOSChargeID;

		#endregion

		#region Constructor

		public POSChargePerDayKeys(Guid pOSChargeID)
		{
			 _pOSChargeID = pOSChargeID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  POSChargeID
		{
			 get { return _pOSChargeID; }
		}

		#endregion

	}
}
