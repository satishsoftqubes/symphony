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
	public class ReservationPolicies: BusinessObjectBase
	{

		#region InnerClass
		public enum ReservationPoliciesFields
		{
			ResPolicyID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			BfrCheckInHrs,
			BfrCharges,
			IsBfrChargesInPercentage,
			BfrChargePer_TermID,
			AftCheckInHrs,
			AftCharges,
			IsAftChargesInPercentage,
			AftChargePer_TermID,
			IsReasonRequired,
			DefaultReservationType_TermID,
			IsFirstNightChargeCompForCashPayers,
			IsAssignRoomToUnConfirmRes,
			IsAssignRoomOnReservation,
			IsUserCanOverrideRackRate,
			IsUserCanApplyDiscount,
			IsUserCanSetTaxExempt
		}
		#endregion

		#region Data Members

			Guid _resPolicyID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			int? _bfrCheckInHrs;
			decimal? _bfrCharges;
			bool? _isBfrChargesInPercentage;
			Guid? _bfrChargePer_TermID;
			int? _aftCheckInHrs;
			decimal? _aftCharges;
			bool? _isAftChargesInPercentage;
			Guid? _aftChargePer_TermID;
			bool? _isReasonRequired;
			Guid? _defaultReservationType_TermID;
			bool? _isFirstNightChargeCompForCashPayers;
			bool? _isAssignRoomToUnConfirmRes;
			bool? _isAssignRoomOnReservation;
			bool? _isUserCanOverrideRackRate;
			bool? _isUserCanApplyDiscount;
			bool? _isUserCanSetTaxExempt;

		#endregion

		#region Properties

		[DataMember]
		public Guid  ResPolicyID
		{
			 get { return _resPolicyID; }
			 set
			 {
				 if (_resPolicyID != value)
				 {
					_resPolicyID = value;
					 PropertyHasChanged("ResPolicyID");
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
		public int?  BfrCheckInHrs
		{
			 get { return _bfrCheckInHrs; }
			 set
			 {
				 if (_bfrCheckInHrs != value)
				 {
					_bfrCheckInHrs = value;
					 PropertyHasChanged("BfrCheckInHrs");
				 }
			 }
		}

		[DataMember]
		public decimal?  BfrCharges
		{
			 get { return _bfrCharges; }
			 set
			 {
				 if (_bfrCharges != value)
				 {
					_bfrCharges = value;
					 PropertyHasChanged("BfrCharges");
				 }
			 }
		}

		[DataMember]
		public bool?  IsBfrChargesInPercentage
		{
			 get { return _isBfrChargesInPercentage; }
			 set
			 {
				 if (_isBfrChargesInPercentage != value)
				 {
					_isBfrChargesInPercentage = value;
					 PropertyHasChanged("IsBfrChargesInPercentage");
				 }
			 }
		}

		[DataMember]
		public Guid?  BfrChargePer_TermID
		{
			 get { return _bfrChargePer_TermID; }
			 set
			 {
				 if (_bfrChargePer_TermID != value)
				 {
					_bfrChargePer_TermID = value;
					 PropertyHasChanged("BfrChargePer_TermID");
				 }
			 }
		}

		[DataMember]
		public int?  AftCheckInHrs
		{
			 get { return _aftCheckInHrs; }
			 set
			 {
				 if (_aftCheckInHrs != value)
				 {
					_aftCheckInHrs = value;
					 PropertyHasChanged("AftCheckInHrs");
				 }
			 }
		}

		[DataMember]
		public decimal?  AftCharges
		{
			 get { return _aftCharges; }
			 set
			 {
				 if (_aftCharges != value)
				 {
					_aftCharges = value;
					 PropertyHasChanged("AftCharges");
				 }
			 }
		}

		[DataMember]
		public bool?  IsAftChargesInPercentage
		{
			 get { return _isAftChargesInPercentage; }
			 set
			 {
				 if (_isAftChargesInPercentage != value)
				 {
					_isAftChargesInPercentage = value;
					 PropertyHasChanged("IsAftChargesInPercentage");
				 }
			 }
		}

		[DataMember]
		public Guid?  AftChargePer_TermID
		{
			 get { return _aftChargePer_TermID; }
			 set
			 {
				 if (_aftChargePer_TermID != value)
				 {
					_aftChargePer_TermID = value;
					 PropertyHasChanged("AftChargePer_TermID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsReasonRequired
		{
			 get { return _isReasonRequired; }
			 set
			 {
				 if (_isReasonRequired != value)
				 {
					_isReasonRequired = value;
					 PropertyHasChanged("IsReasonRequired");
				 }
			 }
		}

		[DataMember]
		public Guid?  DefaultReservationType_TermID
		{
			 get { return _defaultReservationType_TermID; }
			 set
			 {
				 if (_defaultReservationType_TermID != value)
				 {
					_defaultReservationType_TermID = value;
					 PropertyHasChanged("DefaultReservationType_TermID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsFirstNightChargeCompForCashPayers
		{
			 get { return _isFirstNightChargeCompForCashPayers; }
			 set
			 {
				 if (_isFirstNightChargeCompForCashPayers != value)
				 {
					_isFirstNightChargeCompForCashPayers = value;
					 PropertyHasChanged("IsFirstNightChargeCompForCashPayers");
				 }
			 }
		}

		[DataMember]
		public bool?  IsAssignRoomToUnConfirmRes
		{
			 get { return _isAssignRoomToUnConfirmRes; }
			 set
			 {
				 if (_isAssignRoomToUnConfirmRes != value)
				 {
					_isAssignRoomToUnConfirmRes = value;
					 PropertyHasChanged("IsAssignRoomToUnConfirmRes");
				 }
			 }
		}

		[DataMember]
		public bool?  IsAssignRoomOnReservation
		{
			 get { return _isAssignRoomOnReservation; }
			 set
			 {
				 if (_isAssignRoomOnReservation != value)
				 {
					_isAssignRoomOnReservation = value;
					 PropertyHasChanged("IsAssignRoomOnReservation");
				 }
			 }
		}

		[DataMember]
		public bool?  IsUserCanOverrideRackRate
		{
			 get { return _isUserCanOverrideRackRate; }
			 set
			 {
				 if (_isUserCanOverrideRackRate != value)
				 {
					_isUserCanOverrideRackRate = value;
					 PropertyHasChanged("IsUserCanOverrideRackRate");
				 }
			 }
		}

		[DataMember]
		public bool?  IsUserCanApplyDiscount
		{
			 get { return _isUserCanApplyDiscount; }
			 set
			 {
				 if (_isUserCanApplyDiscount != value)
				 {
					_isUserCanApplyDiscount = value;
					 PropertyHasChanged("IsUserCanApplyDiscount");
				 }
			 }
		}

		[DataMember]
		public bool?  IsUserCanSetTaxExempt
		{
			 get { return _isUserCanSetTaxExempt; }
			 set
			 {
				 if (_isUserCanSetTaxExempt != value)
				 {
					_isUserCanSetTaxExempt = value;
					 PropertyHasChanged("IsUserCanSetTaxExempt");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ResPolicyID", "ResPolicyID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ResPolicyID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"CompanyID = {2}~\n"+
			"SeqNo = {3}~\n"+
			"IsSynch = {4}~\n"+
			"SynchOn = {5}~\n"+
			"UpdatedOn = {6}~\n"+
			"UpdatedBy = {7}~\n"+
			"IsActive = {8}~\n"+
			"BfrCheckInHrs = {9}~\n"+
			"BfrCharges = {10}~\n"+
			"IsBfrChargesInPercentage = {11}~\n"+
			"BfrChargePer_TermID = {12}~\n"+
			"AftCheckInHrs = {13}~\n"+
			"AftCharges = {14}~\n"+
			"IsAftChargesInPercentage = {15}~\n"+
			"AftChargePer_TermID = {16}~\n"+
			"IsReasonRequired = {17}~\n"+
			"DefaultReservationType_TermID = {18}~\n"+
			"IsFirstNightChargeCompForCashPayers = {19}~\n"+
			"IsAssignRoomToUnConfirmRes = {20}~\n"+
			"IsAssignRoomOnReservation = {21}~\n"+
			"IsUserCanOverrideRackRate = {22}~\n"+
			"IsUserCanApplyDiscount = {23}~\n"+
			"IsUserCanSetTaxExempt = {24}~\n",
			ResPolicyID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			BfrCheckInHrs,			BfrCharges,			IsBfrChargesInPercentage,			BfrChargePer_TermID,			AftCheckInHrs,			AftCharges,			IsAftChargesInPercentage,			AftChargePer_TermID,			IsReasonRequired,			DefaultReservationType_TermID,			IsFirstNightChargeCompForCashPayers,			IsAssignRoomToUnConfirmRes,			IsAssignRoomOnReservation,			IsUserCanOverrideRackRate,			IsUserCanApplyDiscount,			IsUserCanSetTaxExempt);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ReservationPoliciesKeys
	{

		#region Data Members

		Guid _resPolicyID;

		#endregion

		#region Constructor

		public ReservationPoliciesKeys(Guid resPolicyID)
		{
			 _resPolicyID = resPolicyID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ResPolicyID
		{
			 get { return _resPolicyID; }
		}

		#endregion

	}
}
