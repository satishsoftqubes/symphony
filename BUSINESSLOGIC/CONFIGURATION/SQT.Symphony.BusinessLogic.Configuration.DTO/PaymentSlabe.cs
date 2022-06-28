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
	public class PaymentSlabe: BusinessObjectBase
	{

		#region InnerClass
		public enum PaymentSlabeFields
		{
			PaymentSlabeID,
			PropertyID,
			SeqNo,
			SlabNo,
			SlabTitle,
			SlabDescription,
			RefPaymentSlabID,
			DateOfCompletion,
			CompletionProjection,
			Installment,
			IsFlat,
			LastUpdateOn,
			UpdatedBy,
			IsSynch,
			SynchOn,
			UpdateLog,
			IsActive,
            WingID
		}
		#endregion

		#region Data Members

			Guid _paymentSlabeID;
			Guid? _propertyID;
			int? _seqNo;
			string _slabNo;
			string _slabTitle;
			string _slabDescription;
			Guid? _refPaymentSlabID;
			DateTime? _dateOfCompletion;
			DateTime? _completionProjection;
			decimal? _installment;
			bool? _isFlat;
			DateTime? _lastUpdateOn;
			Guid? _updatedBy;
			bool? _isSynch;
			DateTime? _synchOn;
			byte[] _updateLog;
			bool? _isActive;
            Guid? _wingID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  PaymentSlabeID
		{
			 get { return _paymentSlabeID; }
			 set
			 {
				 if (_paymentSlabeID != value)
				 {
					_paymentSlabeID = value;
					 PropertyHasChanged("PaymentSlabeID");
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
		public string  SlabNo
		{
			 get { return _slabNo; }
			 set
			 {
				 if (_slabNo != value)
				 {
					_slabNo = value;
					 PropertyHasChanged("SlabNo");
				 }
			 }
		}

		[DataMember]
		public string  SlabTitle
		{
			 get { return _slabTitle; }
			 set
			 {
				 if (_slabTitle != value)
				 {
					_slabTitle = value;
					 PropertyHasChanged("SlabTitle");
				 }
			 }
		}

		[DataMember]
		public string  SlabDescription
		{
			 get { return _slabDescription; }
			 set
			 {
				 if (_slabDescription != value)
				 {
					_slabDescription = value;
					 PropertyHasChanged("SlabDescription");
				 }
			 }
		}

		[DataMember]
		public Guid?  RefPaymentSlabID
		{
			 get { return _refPaymentSlabID; }
			 set
			 {
				 if (_refPaymentSlabID != value)
				 {
					_refPaymentSlabID = value;
					 PropertyHasChanged("RefPaymentSlabID");
				 }
			 }
		}

		[DataMember]
		public DateTime?  DateOfCompletion
		{
			 get { return _dateOfCompletion; }
			 set
			 {
				 if (_dateOfCompletion != value)
				 {
					_dateOfCompletion = value;
					 PropertyHasChanged("DateOfCompletion");
				 }
			 }
		}

		[DataMember]
		public DateTime?  CompletionProjection
		{
			 get { return _completionProjection; }
			 set
			 {
				 if (_completionProjection != value)
				 {
					_completionProjection = value;
					 PropertyHasChanged("CompletionProjection");
				 }
			 }
		}

		[DataMember]
		public decimal?  Installment
		{
			 get { return _installment; }
			 set
			 {
				 if (_installment != value)
				 {
					_installment = value;
					 PropertyHasChanged("Installment");
				 }
			 }
		}

		[DataMember]
		public bool?  IsFlat
		{
			 get { return _isFlat; }
			 set
			 {
				 if (_isFlat != value)
				 {
					_isFlat = value;
					 PropertyHasChanged("IsFlat");
				 }
			 }
		}

		[DataMember]
		public DateTime?  LastUpdateOn
		{
			 get { return _lastUpdateOn; }
			 set
			 {
				 if (_lastUpdateOn != value)
				 {
					_lastUpdateOn = value;
					 PropertyHasChanged("LastUpdateOn");
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
        public Guid? WingID
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
		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("PaymentSlabeID", "PaymentSlabeID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("SlabNo", "SlabNo",180));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("SlabTitle", "SlabTitle",180));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("SlabDescription", "SlabDescription",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"PaymentSlabeID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"SeqNo = {2}~\n"+
			"SlabNo = {3}~\n"+
			"SlabTitle = {4}~\n"+
			"SlabDescription = {5}~\n"+
			"RefPaymentSlabID = {6}~\n"+
			"DateOfCompletion = {7}~\n"+
			"CompletionProjection = {8}~\n"+
			"Installment = {9}~\n"+
			"IsFlat = {10}~\n"+
			"LastUpdateOn = {11}~\n"+
			"UpdatedBy = {12}~\n"+
			"IsSynch = {13}~\n"+
			"SynchOn = {14}~\n"+
			"UpdateLog = {15}~\n"+
			"IsActive = {16}~\n"+
            "WingID = {17}~\n",
            PaymentSlabeID, PropertyID, SeqNo, SlabNo, SlabTitle, SlabDescription, RefPaymentSlabID, DateOfCompletion, CompletionProjection, Installment, IsFlat, LastUpdateOn, UpdatedBy, IsSynch, SynchOn, UpdateLog, IsActive, WingID); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class PaymentSlabeKeys
	{

		#region Data Members

		Guid _paymentSlabeID;

		#endregion

		#region Constructor

		public PaymentSlabeKeys(Guid paymentSlabeID)
		{
			 _paymentSlabeID = paymentSlabeID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  PaymentSlabeID
		{
			 get { return _paymentSlabeID; }
		}

		#endregion

	}
}
