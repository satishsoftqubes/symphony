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
	public class SMSTemplates: BusinessObjectBase
	{

		#region InnerClass
		public enum SMSTemplatesFields
		{
			SMSTemplateID,
			Title,
			SMSDetails,
			IsSynch,
			SynchOn,
			UpdateLog,
			CreatedOn,
			CreatedBy,
			UpdatedOn,
			UpdatedBy,
			CompanyID,
			IsActive,
			SeqNo,
			IsOnUnitBooking,
			IsOnInvestorCreation,
			IsOnUnitPaymentReceived,
			IsOnUnitTaxReceived,
			IsOnUnitInsuranceReceived,
            IsOther
		}
		#endregion

		#region Data Members

			Guid _sMSTemplateID;
			string _title;
			string _sMSDetails;
			bool? _isSynch;
			DateTime? _synchOn;
			byte[] _updateLog;
			DateTime? _createdOn;
			Guid? _createdBy;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			Guid? _companyID;
			bool? _isActive;
			int _seqNo;
			bool? _isOnUnitBooking;
			bool? _isOnInvestorCreation;
			bool? _isOnUnitPaymentReceived;
			bool? _isOnUnitTaxReceived;
			bool? _isOnUnitInsuranceReceived;
            bool? _isOther;

		#endregion

		#region Properties

		[DataMember]
		public Guid  SMSTemplateID
		{
			 get { return _sMSTemplateID; }
			 set
			 {
				 if (_sMSTemplateID != value)
				 {
					_sMSTemplateID = value;
					 PropertyHasChanged("SMSTemplateID");
				 }
			 }
		}

		[DataMember]
		public string  Title
		{
			 get { return _title; }
			 set
			 {
				 if (_title != value)
				 {
					_title = value;
					 PropertyHasChanged("Title");
				 }
			 }
		}

		[DataMember]
		public string  SMSDetails
		{
			 get { return _sMSDetails; }
			 set
			 {
				 if (_sMSDetails != value)
				 {
					_sMSDetails = value;
					 PropertyHasChanged("SMSDetails");
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
		public bool?  IsOnUnitBooking
		{
			 get { return _isOnUnitBooking; }
			 set
			 {
				 if (_isOnUnitBooking != value)
				 {
					_isOnUnitBooking = value;
					 PropertyHasChanged("IsOnUnitBooking");
				 }
			 }
		}

		[DataMember]
		public bool?  IsOnInvestorCreation
		{
			 get { return _isOnInvestorCreation; }
			 set
			 {
				 if (_isOnInvestorCreation != value)
				 {
					_isOnInvestorCreation = value;
					 PropertyHasChanged("IsOnInvestorCreation");
				 }
			 }
		}

		[DataMember]
		public bool?  IsOnUnitPaymentReceived
		{
			 get { return _isOnUnitPaymentReceived; }
			 set
			 {
				 if (_isOnUnitPaymentReceived != value)
				 {
					_isOnUnitPaymentReceived = value;
					 PropertyHasChanged("IsOnUnitPaymentReceived");
				 }
			 }
		}

		[DataMember]
		public bool?  IsOnUnitTaxReceived
		{
			 get { return _isOnUnitTaxReceived; }
			 set
			 {
				 if (_isOnUnitTaxReceived != value)
				 {
					_isOnUnitTaxReceived = value;
					 PropertyHasChanged("IsOnUnitTaxReceived");
				 }
			 }
		}

		[DataMember]
		public bool?  IsOnUnitInsuranceReceived
		{
			 get { return _isOnUnitInsuranceReceived; }
			 set
			 {
				 if (_isOnUnitInsuranceReceived != value)
				 {
					_isOnUnitInsuranceReceived = value;
					 PropertyHasChanged("IsOnUnitInsuranceReceived");
				 }
			 }
		}

        [DataMember]
        public bool? IsOther
        {
            get { return _isOther; }
            set
            {
                if (_isOther != value)
                {
                    _isOther = value;
                    PropertyHasChanged("IsOther");
                }
            }
        }

		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SMSTemplateID", "SMSTemplateID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Title", "Title",20));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("SMSDetails", "SMSDetails",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
            "SMSTemplateID = {0}~\n" +
            "Title = {1}~\n" +
            "SMSDetails = {2}~\n" +
            "IsSynch = {3}~\n" +
            "SynchOn = {4}~\n" +
            "UpdateLog = {5}~\n" +
            "CreatedOn = {6}~\n" +
            "CreatedBy = {7}~\n" +
            "UpdatedOn = {8}~\n" +
            "UpdatedBy = {9}~\n" +
            "CompanyID = {10}~\n" +
            "IsActive = {11}~\n" +
            "SeqNo = {12}~\n" +
            "IsOnUnitBooking = {13}~\n" +
            "IsOnInvestorCreation = {14}~\n" +
            "IsOnUnitPaymentReceived = {15}~\n" +
            "IsOnUnitTaxReceived = {16}~\n" +
            "IsOnUnitInsuranceReceived = {17}~\n" +
            "IsOther={18}\n",
            SMSTemplateID, Title, SMSDetails, IsSynch, SynchOn, UpdateLog, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, CompanyID, IsActive, SeqNo, IsOnUnitBooking, IsOnInvestorCreation, IsOnUnitPaymentReceived, IsOnUnitTaxReceived, IsOnUnitInsuranceReceived, IsOther); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class SMSTemplatesKeys
	{

		#region Data Members

		Guid _sMSTemplateID;

		#endregion

		#region Constructor

		public SMSTemplatesKeys(Guid sMSTemplateID)
		{
			 _sMSTemplateID = sMSTemplateID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  SMSTemplateID
		{
			 get { return _sMSTemplateID; }
		}

		#endregion

	}
}
