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
	public class ReservationDetail: BusinessObjectBase
	{

		#region InnerClass
		public enum ReservationDetailFields
		{
			ResDetailID,
			ReservationID,
			CreditAllowed,
			ResNotes,
			GuestNotes,
			HouseKeepingNotes,
			TaxExemptNotes,
			OnArrivalNotes,
			OnDepartureNotes,
			SourceOfBusiness_TermID,
			ReasonForStay_TermID,
			GeneralNotes,
			OperatorNotes,
			ReservationThrough_TermID,
			ReservationThroughDetail,
			ReservationThroughContactNo,
			SourceOfReservation_TermID,
			SourceOfReservationDetails,
			SourceOfReservationID,
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

			Guid _resDetailID;
			Guid? _reservationID;
			decimal? _creditAllowed;
			string _resNotes;
			string _guestNotes;
			string _houseKeepingNotes;
			string _taxExemptNotes;
			string _onArrivalNotes;
			string _onDepartureNotes;
			Guid? _sourceOfBusiness_TermID;
			Guid? _reasonForStay_TermID;
			string _generalNotes;
			string _operatorNotes;
			Guid? _reservationThrough_TermID;
			string _reservationThroughDetail;
			string _reservationThroughContactNo;
			Guid? _sourceOfReservation_TermID;
			string _sourceOfReservationDetails;
			Guid? _sourceOfReservationID;
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
		public Guid  ResDetailID
		{
			 get { return _resDetailID; }
			 set
			 {
				 if (_resDetailID != value)
				 {
					_resDetailID = value;
					 PropertyHasChanged("ResDetailID");
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
		public decimal?  CreditAllowed
		{
			 get { return _creditAllowed; }
			 set
			 {
				 if (_creditAllowed != value)
				 {
					_creditAllowed = value;
					 PropertyHasChanged("CreditAllowed");
				 }
			 }
		}

		[DataMember]
		public string  ResNotes
		{
			 get { return _resNotes; }
			 set
			 {
				 if (_resNotes != value)
				 {
					_resNotes = value;
					 PropertyHasChanged("ResNotes");
				 }
			 }
		}

		[DataMember]
		public string  GuestNotes
		{
			 get { return _guestNotes; }
			 set
			 {
				 if (_guestNotes != value)
				 {
					_guestNotes = value;
					 PropertyHasChanged("GuestNotes");
				 }
			 }
		}

		[DataMember]
		public string  HouseKeepingNotes
		{
			 get { return _houseKeepingNotes; }
			 set
			 {
				 if (_houseKeepingNotes != value)
				 {
					_houseKeepingNotes = value;
					 PropertyHasChanged("HouseKeepingNotes");
				 }
			 }
		}

		[DataMember]
		public string  TaxExemptNotes
		{
			 get { return _taxExemptNotes; }
			 set
			 {
				 if (_taxExemptNotes != value)
				 {
					_taxExemptNotes = value;
					 PropertyHasChanged("TaxExemptNotes");
				 }
			 }
		}

		[DataMember]
		public string  OnArrivalNotes
		{
			 get { return _onArrivalNotes; }
			 set
			 {
				 if (_onArrivalNotes != value)
				 {
					_onArrivalNotes = value;
					 PropertyHasChanged("OnArrivalNotes");
				 }
			 }
		}

		[DataMember]
		public string  OnDepartureNotes
		{
			 get { return _onDepartureNotes; }
			 set
			 {
				 if (_onDepartureNotes != value)
				 {
					_onDepartureNotes = value;
					 PropertyHasChanged("OnDepartureNotes");
				 }
			 }
		}

		[DataMember]
		public Guid?  SourceOfBusiness_TermID
		{
			 get { return _sourceOfBusiness_TermID; }
			 set
			 {
				 if (_sourceOfBusiness_TermID != value)
				 {
					_sourceOfBusiness_TermID = value;
					 PropertyHasChanged("SourceOfBusiness_TermID");
				 }
			 }
		}

		[DataMember]
		public Guid?  ReasonForStay_TermID
		{
			 get { return _reasonForStay_TermID; }
			 set
			 {
				 if (_reasonForStay_TermID != value)
				 {
					_reasonForStay_TermID = value;
					 PropertyHasChanged("ReasonForStay_TermID");
				 }
			 }
		}

		[DataMember]
		public string  GeneralNotes
		{
			 get { return _generalNotes; }
			 set
			 {
				 if (_generalNotes != value)
				 {
					_generalNotes = value;
					 PropertyHasChanged("GeneralNotes");
				 }
			 }
		}

		[DataMember]
		public string  OperatorNotes
		{
			 get { return _operatorNotes; }
			 set
			 {
				 if (_operatorNotes != value)
				 {
					_operatorNotes = value;
					 PropertyHasChanged("OperatorNotes");
				 }
			 }
		}

		[DataMember]
		public Guid?  ReservationThrough_TermID
		{
			 get { return _reservationThrough_TermID; }
			 set
			 {
				 if (_reservationThrough_TermID != value)
				 {
					_reservationThrough_TermID = value;
					 PropertyHasChanged("ReservationThrough_TermID");
				 }
			 }
		}

		[DataMember]
		public string  ReservationThroughDetail
		{
			 get { return _reservationThroughDetail; }
			 set
			 {
				 if (_reservationThroughDetail != value)
				 {
					_reservationThroughDetail = value;
					 PropertyHasChanged("ReservationThroughDetail");
				 }
			 }
		}

		[DataMember]
		public string  ReservationThroughContactNo
		{
			 get { return _reservationThroughContactNo; }
			 set
			 {
				 if (_reservationThroughContactNo != value)
				 {
					_reservationThroughContactNo = value;
					 PropertyHasChanged("ReservationThroughContactNo");
				 }
			 }
		}

		[DataMember]
		public Guid?  SourceOfReservation_TermID
		{
			 get { return _sourceOfReservation_TermID; }
			 set
			 {
				 if (_sourceOfReservation_TermID != value)
				 {
					_sourceOfReservation_TermID = value;
					 PropertyHasChanged("SourceOfReservation_TermID");
				 }
			 }
		}

		[DataMember]
		public string  SourceOfReservationDetails
		{
			 get { return _sourceOfReservationDetails; }
			 set
			 {
				 if (_sourceOfReservationDetails != value)
				 {
					_sourceOfReservationDetails = value;
					 PropertyHasChanged("SourceOfReservationDetails");
				 }
			 }
		}

		[DataMember]
		public Guid?  SourceOfReservationID
		{
			 get { return _sourceOfReservationID; }
			 set
			 {
				 if (_sourceOfReservationID != value)
				 {
					_sourceOfReservationID = value;
					 PropertyHasChanged("SourceOfReservationID");
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ResDetailID", "ResDetailID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ResNotes", "ResNotes",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("GuestNotes", "GuestNotes",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("HouseKeepingNotes", "HouseKeepingNotes",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("TaxExemptNotes", "TaxExemptNotes",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("OnArrivalNotes", "OnArrivalNotes",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("OnDepartureNotes", "OnDepartureNotes",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("GeneralNotes", "GeneralNotes",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("OperatorNotes", "OperatorNotes",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ReservationThroughDetail", "ReservationThroughDetail",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ReservationThroughContactNo", "ReservationThroughContactNo",20));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("SourceOfReservationDetails", "SourceOfReservationDetails",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ResDetailID = {0}\n"+
			"ReservationID = {1}\n"+
			"CreditAllowed = {2}\n"+
			"ResNotes = {3}\n"+
			"GuestNotes = {4}\n"+
			"HouseKeepingNotes = {5}\n"+
			"TaxExemptNotes = {6}\n"+
			"OnArrivalNotes = {7}\n"+
			"OnDepartureNotes = {8}\n"+
			"SourceOfBusiness_TermID = {9}\n"+
			"ReasonForStay_TermID = {10}\n"+
			"GeneralNotes = {11}\n"+
			"OperatorNotes = {12}\n"+
			"ReservationThrough_TermID = {13}\n"+
			"ReservationThroughDetail = {14}\n"+
			"ReservationThroughContactNo = {15}\n"+
			"SourceOfReservation_TermID = {16}\n"+
			"SourceOfReservationDetails = {17}\n"+
			"SourceOfReservationID = {18}\n"+
			"PropertyID = {19}\n"+
			"CompanyID = {20}\n"+
			"SeqNo = {21}\n"+
			"IsSynch = {22}\n"+
			"SynchOn = {23}\n"+
			"UpdatedOn = {24}\n"+
			"UpdatedBy = {25}\n"+
			"IsActive = {26}\n",
			ResDetailID,			ReservationID,			CreditAllowed,			ResNotes,			GuestNotes,			HouseKeepingNotes,			TaxExemptNotes,			OnArrivalNotes,			OnDepartureNotes,			SourceOfBusiness_TermID,			ReasonForStay_TermID,			GeneralNotes,			OperatorNotes,			ReservationThrough_TermID,			ReservationThroughDetail,			ReservationThroughContactNo,			SourceOfReservation_TermID,			SourceOfReservationDetails,			SourceOfReservationID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ReservationDetailKeys
	{

		#region Data Members

		Guid _resDetailID;

		#endregion

		#region Constructor

		public ReservationDetailKeys(Guid resDetailID)
		{
			 _resDetailID = resDetailID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ResDetailID
		{
			 get { return _resDetailID; }
		}

		#endregion

	}
}
