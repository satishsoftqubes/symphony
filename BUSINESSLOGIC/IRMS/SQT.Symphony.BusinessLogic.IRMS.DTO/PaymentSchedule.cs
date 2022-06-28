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
	public class PaymentSchedule: BusinessObjectBase
	{

		#region InnerClass
		public enum PaymentScheduleFields
		{
			PaymentScheduleID,
			InvestorRoomID,
			InvestorID,
			PaymentSlabID,
			SeqNo,
			ProjectMilestone,
			AmountPayable,
			TotalReceived,
			DueDate,
			IsActive,
			CreatedOn,
			CreatedBy,
			UpdatedOn,
			UpdatedBy,
			UpdateLog,
			CompanyID,
            IsDefaultSchedule, ScheduleType,
            IsReceiptCreated
		}
		#endregion

		#region Data Members

			Guid _paymentScheduleID;
			Guid? _investorRoomID;
			Guid? _investorID;
			Guid? _paymentSlabID;
			int _seqNo;
			string _projectMilestone;
			decimal? _amountPayable;
			decimal? _totalReceived;
			DateTime? _dueDate;
			bool? _isActive;
			DateTime? _createdOn;
			Guid? _createdBy;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			byte[] _updateLog;
			Guid? _companyID;
            bool? _isDefaultSchedule;
            string _scheduleType;
            bool? _isReceiptCreated;

		#endregion

		#region Properties

            

		[DataMember]
		public Guid  PaymentScheduleID
		{
			 get { return _paymentScheduleID; }
			 set
			 {
				 if (_paymentScheduleID != value)
				 {
					_paymentScheduleID = value;
					 PropertyHasChanged("PaymentScheduleID");
				 }
			 }
		}

		[DataMember]
		public Guid?  InvestorRoomID
		{
			 get { return _investorRoomID; }
			 set
			 {
				 if (_investorRoomID != value)
				 {
					_investorRoomID = value;
					 PropertyHasChanged("InvestorRoomID");
				 }
			 }
		}

		[DataMember]
		public Guid?  InvestorID
		{
			 get { return _investorID; }
			 set
			 {
				 if (_investorID != value)
				 {
					_investorID = value;
					 PropertyHasChanged("InvestorID");
				 }
			 }
		}

		[DataMember]
		public Guid?  PaymentSlabID
		{
			 get { return _paymentSlabID; }
			 set
			 {
				 if (_paymentSlabID != value)
				 {
					_paymentSlabID = value;
					 PropertyHasChanged("PaymentSlabID");
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
		public string  ProjectMilestone
		{
			 get { return _projectMilestone; }
			 set
			 {
				 if (_projectMilestone != value)
				 {
					_projectMilestone = value;
					 PropertyHasChanged("ProjectMilestone");
				 }
			 }
		}

		[DataMember]
		public decimal?  AmountPayable
		{
			 get { return _amountPayable; }
			 set
			 {
				 if (_amountPayable != value)
				 {
					_amountPayable = value;
					 PropertyHasChanged("AmountPayable");
				 }
			 }
		}

		[DataMember]
		public decimal?  TotalReceived
		{
			 get { return _totalReceived; }
			 set
			 {
				 if (_totalReceived != value)
				 {
					_totalReceived = value;
					 PropertyHasChanged("TotalReceived");
				 }
			 }
		}

		[DataMember]
		public DateTime?  DueDate
		{
			 get { return _dueDate; }
			 set
			 {
				 if (_dueDate != value)
				 {
					_dueDate = value;
					 PropertyHasChanged("DueDate");
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
        public bool? IsDefaultSchedule
        {
            get { return _isDefaultSchedule; }
            set
            {
                if (_isDefaultSchedule != value)
                {
                    _isDefaultSchedule = value;
                    PropertyHasChanged("IsDefaultSchedule");
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
        public string ScheduleType
        {
            get { return _scheduleType; }
            set
            {
                if (_scheduleType != value)
                {
                    _scheduleType = value;
                    PropertyHasChanged("ScheduleType");
                }
            }
        }

        [DataMember]
        public bool? IsReceiptCreated
        {
            get { return _isReceiptCreated; }
            set
            {
                if (_isReceiptCreated != value)
                {
                    _isReceiptCreated = value;
                    PropertyHasChanged("IsReceiptCreated");
                }
            }
        }
		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("PaymentScheduleID", "PaymentScheduleID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ProjectMilestone", "ProjectMilestone",250));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"PaymentScheduleID = {0}\n"+
			"InvestorRoomID = {1}\n"+
			"InvestorID = {2}\n"+
			"PaymentSlabID = {3}\n"+
			"SeqNo = {4}\n"+
			"ProjectMilestone = {5}\n"+
			"AmountPayable = {6}\n"+
			"TotalReceived = {7}\n"+
			"DueDate = {8}\n"+
			"IsActive = {9}\n"+
			"CreatedOn = {10}\n"+
			"CreatedBy = {11}\n"+
			"UpdatedOn = {12}\n"+
			"UpdatedBy = {13}\n"+
			"UpdateLog = {14}\n"+
			"CompanyID = {15}\n"+
            "IsDefaultSchedule = {16}\n"+
            "ScheduleType = {17}",
            PaymentScheduleID, InvestorRoomID, InvestorID, PaymentSlabID, SeqNo, ProjectMilestone, AmountPayable, TotalReceived, DueDate, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, UpdateLog, CompanyID, IsDefaultSchedule, ScheduleType); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class PaymentScheduleKeys
	{

		#region Data Members

		Guid _paymentScheduleID;

		#endregion

		#region Constructor

		public PaymentScheduleKeys(Guid paymentScheduleID)
		{
			 _paymentScheduleID = paymentScheduleID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  PaymentScheduleID
		{
			 get { return _paymentScheduleID; }
		}

		#endregion

	}
}
