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
	public class VoucherDetail: BusinessObjectBase
	{

		#region InnerClass
		public enum VoucherDetailFields
		{
			VoucherDetailID,
			ReservationID,
			VoucherNo,
			AgentID,
			IsApplyCommission,
			Commission_TermID,
			CommissionValue,
			IsCommissionFlat,
			AgentType_TermID,
			IsDirectBill,
			AccommodationChargeFolioID,
			PayableAccommodationCharge,
			POSFolioID,
			RestaurantFolioID,
			CallLoggerFolioID,
			MiscellaneousServiceID,
			MiscellaneousFolioID,
			LaundryFolioID,
			BillingAddressID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
            VoucherAuthorisedBy,
            Validity,
            Voucher
		}
		#endregion

		#region Data Members

			Guid _voucherDetailID;
			Guid? _reservationID;
			string _voucherNo;
			Guid? _agentID;
			bool? _isApplyCommission;
			Guid? _commission_TermID;
			decimal? _commissionValue;
			bool? _isCommissionFlat;
			Guid? _agentType_TermID;
			bool? _isDirectBill;
			Guid? _accommodationChargeFolioID;
			decimal? _payableAccommodationCharge;
			Guid? _pOSFolioID;
			Guid? _restaurantFolioID;
			Guid? _callLoggerFolioID;
			Guid? _miscellaneousServiceID;
			Guid? _miscellaneousFolioID;
			Guid? _laundryFolioID;
			Guid? _billingAddressID;
			Guid? _propertyID;
			Guid? _companyID;
			long _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
            string _voucherAuthorisedBy;
            DateTime? _validity;
            string _voucher;

		#endregion

		#region Properties

		[DataMember]
		public Guid  VoucherDetailID
		{
			 get { return _voucherDetailID; }
			 set
			 {
				 if (_voucherDetailID != value)
				 {
					_voucherDetailID = value;
					 PropertyHasChanged("VoucherDetailID");
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
		public string  VoucherNo
		{
			 get { return _voucherNo; }
			 set
			 {
				 if (_voucherNo != value)
				 {
					_voucherNo = value;
					 PropertyHasChanged("VoucherNo");
				 }
			 }
		}

		[DataMember]
		public Guid?  AgentID
		{
			 get { return _agentID; }
			 set
			 {
				 if (_agentID != value)
				 {
					_agentID = value;
					 PropertyHasChanged("AgentID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsApplyCommission
		{
			 get { return _isApplyCommission; }
			 set
			 {
				 if (_isApplyCommission != value)
				 {
					_isApplyCommission = value;
					 PropertyHasChanged("IsApplyCommission");
				 }
			 }
		}

		[DataMember]
		public Guid?  Commission_TermID
		{
			 get { return _commission_TermID; }
			 set
			 {
				 if (_commission_TermID != value)
				 {
					_commission_TermID = value;
					 PropertyHasChanged("Commission_TermID");
				 }
			 }
		}

		[DataMember]
		public decimal?  CommissionValue
		{
			 get { return _commissionValue; }
			 set
			 {
				 if (_commissionValue != value)
				 {
					_commissionValue = value;
					 PropertyHasChanged("CommissionValue");
				 }
			 }
		}

		[DataMember]
		public bool?  IsCommissionFlat
		{
			 get { return _isCommissionFlat; }
			 set
			 {
				 if (_isCommissionFlat != value)
				 {
					_isCommissionFlat = value;
					 PropertyHasChanged("IsCommissionFlat");
				 }
			 }
		}

		[DataMember]
		public Guid?  AgentType_TermID
		{
			 get { return _agentType_TermID; }
			 set
			 {
				 if (_agentType_TermID != value)
				 {
					_agentType_TermID = value;
					 PropertyHasChanged("AgentType_TermID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsDirectBill
		{
			 get { return _isDirectBill; }
			 set
			 {
				 if (_isDirectBill != value)
				 {
					_isDirectBill = value;
					 PropertyHasChanged("IsDirectBill");
				 }
			 }
		}

		[DataMember]
		public Guid?  AccommodationChargeFolioID
		{
			 get { return _accommodationChargeFolioID; }
			 set
			 {
				 if (_accommodationChargeFolioID != value)
				 {
					_accommodationChargeFolioID = value;
					 PropertyHasChanged("AccommodationChargeFolioID");
				 }
			 }
		}

		[DataMember]
		public decimal?  PayableAccommodationCharge
		{
			 get { return _payableAccommodationCharge; }
			 set
			 {
				 if (_payableAccommodationCharge != value)
				 {
					_payableAccommodationCharge = value;
					 PropertyHasChanged("PayableAccommodationCharge");
				 }
			 }
		}

		[DataMember]
		public Guid?  POSFolioID
		{
			 get { return _pOSFolioID; }
			 set
			 {
				 if (_pOSFolioID != value)
				 {
					_pOSFolioID = value;
					 PropertyHasChanged("POSFolioID");
				 }
			 }
		}

		[DataMember]
		public Guid?  RestaurantFolioID
		{
			 get { return _restaurantFolioID; }
			 set
			 {
				 if (_restaurantFolioID != value)
				 {
					_restaurantFolioID = value;
					 PropertyHasChanged("RestaurantFolioID");
				 }
			 }
		}

		[DataMember]
		public Guid?  CallLoggerFolioID
		{
			 get { return _callLoggerFolioID; }
			 set
			 {
				 if (_callLoggerFolioID != value)
				 {
					_callLoggerFolioID = value;
					 PropertyHasChanged("CallLoggerFolioID");
				 }
			 }
		}

		[DataMember]
		public Guid?  MiscellaneousServiceID
		{
			 get { return _miscellaneousServiceID; }
			 set
			 {
				 if (_miscellaneousServiceID != value)
				 {
					_miscellaneousServiceID = value;
					 PropertyHasChanged("MiscellaneousServiceID");
				 }
			 }
		}

		[DataMember]
		public Guid?  MiscellaneousFolioID
		{
			 get { return _miscellaneousFolioID; }
			 set
			 {
				 if (_miscellaneousFolioID != value)
				 {
					_miscellaneousFolioID = value;
					 PropertyHasChanged("MiscellaneousFolioID");
				 }
			 }
		}

		[DataMember]
		public Guid?  LaundryFolioID
		{
			 get { return _laundryFolioID; }
			 set
			 {
				 if (_laundryFolioID != value)
				 {
					_laundryFolioID = value;
					 PropertyHasChanged("LaundryFolioID");
				 }
			 }
		}

		[DataMember]
		public Guid?  BillingAddressID
		{
			 get { return _billingAddressID; }
			 set
			 {
				 if (_billingAddressID != value)
				 {
					_billingAddressID = value;
					 PropertyHasChanged("BillingAddressID");
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
        public string VoucherAuthorisedBy
        {
            get { return _voucherAuthorisedBy; }
            set
            {
                if (_voucherAuthorisedBy != value)
                {
                    _voucherAuthorisedBy = value;
                    PropertyHasChanged("VoucherAuthorisedBy");
                }
            }
        }


        [DataMember]
        public DateTime? Validity
        {
            get { return _validity; }
            set
            {
                if (_validity != value)
                {
                    _validity = value;
                    PropertyHasChanged("Validity");
                }
            }
        }

        [DataMember]
        public string Voucher
        {
            get { return _voucher; }
            set
            {
                if (_voucher != value)
                {
                    _voucher = value;
                    PropertyHasChanged("Voucher");
                }
            }
        }

		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("VoucherDetailID", "VoucherDetailID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("VoucherNo", "VoucherNo",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"VoucherDetailID = {0}\n"+
			"ReservationID = {1}\n"+
			"VoucherNo = {2}\n"+
			"AgentID = {3}\n"+
			"IsApplyCommission = {4}\n"+
			"Commission_TermID = {5}\n"+
			"CommissionValue = {6}\n"+
			"IsCommissionFlat = {7}\n"+
			"AgentType_TermID = {8}\n"+
			"IsDirectBill = {9}\n"+
			"AccommodationChargeFolioID = {10}\n"+
			"PayableAccommodationCharge = {11}\n"+
			"POSFolioID = {12}\n"+
			"RestaurantFolioID = {13}\n"+
			"CallLoggerFolioID = {14}\n"+
			"MiscellaneousServiceID = {15}\n"+
			"MiscellaneousFolioID = {16}\n"+
			"LaundryFolioID = {17}\n"+
			"BillingAddressID = {18}\n"+
			"PropertyID = {19}\n"+
			"CompanyID = {20}\n"+
			"SeqNo = {21}\n"+
			"IsSynch = {22}\n"+
			"SynchOn = {23}\n"+
			"UpdatedOn = {24}\n"+
			"UpdatedBy = {25}\n"+
            "IsActive = {26}\n" +
            "VoucherAuthorisedBy = {27}\n" +
            "Validity = {28}\n" +
            "Voucher = {29}\n",
            VoucherDetailID, ReservationID, VoucherNo, AgentID, IsApplyCommission, Commission_TermID, CommissionValue, IsCommissionFlat, AgentType_TermID, IsDirectBill, AccommodationChargeFolioID, PayableAccommodationCharge, POSFolioID, RestaurantFolioID, CallLoggerFolioID, MiscellaneousServiceID, MiscellaneousFolioID, LaundryFolioID, BillingAddressID, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, VoucherAuthorisedBy, Validity, Voucher); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class VoucherDetailKeys
	{

		#region Data Members

		Guid _voucherDetailID;

		#endregion

		#region Constructor

		public VoucherDetailKeys(Guid voucherDetailID)
		{
			 _voucherDetailID = voucherDetailID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  VoucherDetailID
		{
			 get { return _voucherDetailID; }
		}

		#endregion

	}
}
