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
	public class ResAuditLog: BusinessObjectBase
	{

		#region InnerClass
		public enum ResAuditLogFields
		{
			AuditLogID,
			ReservationID,
			OperatorID,
			OperationType_TermID,
			OperationDate,
			OperationRemark,
			OperationNote,
			ObjectValue,
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

			Guid _auditLogID;
			Guid? _reservationID;
			Guid? _operatorID;
			Guid? _operationType_TermID;
			DateTime? _operationDate;
			string _operationRemark;
			string _operationNote;
			string _objectValue;
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
		public Guid  AuditLogID
		{
			 get { return _auditLogID; }
			 set
			 {
				 if (_auditLogID != value)
				 {
					_auditLogID = value;
					 PropertyHasChanged("AuditLogID");
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
		public Guid?  OperatorID
		{
			 get { return _operatorID; }
			 set
			 {
				 if (_operatorID != value)
				 {
					_operatorID = value;
					 PropertyHasChanged("OperatorID");
				 }
			 }
		}

		[DataMember]
		public Guid?  OperationType_TermID
		{
			 get { return _operationType_TermID; }
			 set
			 {
				 if (_operationType_TermID != value)
				 {
					_operationType_TermID = value;
					 PropertyHasChanged("OperationType_TermID");
				 }
			 }
		}

		[DataMember]
		public DateTime?  OperationDate
		{
			 get { return _operationDate; }
			 set
			 {
				 if (_operationDate != value)
				 {
					_operationDate = value;
					 PropertyHasChanged("OperationDate");
				 }
			 }
		}

		[DataMember]
		public string  OperationRemark
		{
			 get { return _operationRemark; }
			 set
			 {
				 if (_operationRemark != value)
				 {
					_operationRemark = value;
					 PropertyHasChanged("OperationRemark");
				 }
			 }
		}

		[DataMember]
		public string  OperationNote
		{
			 get { return _operationNote; }
			 set
			 {
				 if (_operationNote != value)
				 {
					_operationNote = value;
					 PropertyHasChanged("OperationNote");
				 }
			 }
		}

		[DataMember]
		public string  ObjectValue
		{
			 get { return _objectValue; }
			 set
			 {
				 if (_objectValue != value)
				 {
					_objectValue = value;
					 PropertyHasChanged("ObjectValue");
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("AuditLogID", "AuditLogID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("OperationRemark", "OperationRemark",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("OperationNote", "OperationNote",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ObjectValue", "ObjectValue",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"AuditLogID = {0}\n"+
			"ReservationID = {1}\n"+
			"OperatorID = {2}\n"+
			"OperationType_TermID = {3}\n"+
			"OperationDate = {4}\n"+
			"OperationRemark = {5}\n"+
			"OperationNote = {6}\n"+
			"ObjectValue = {7}\n"+
			"PropertyID = {8}\n"+
			"CompanyID = {9}\n"+
			"SeqNo = {10}\n"+
			"IsSynch = {11}\n"+
			"SynchOn = {12}\n"+
			"UpdatedOn = {13}\n"+
			"UpdatedBy = {14}\n"+
			"IsActive = {15}\n",
			AuditLogID,			ReservationID,			OperatorID,			OperationType_TermID,			OperationDate,			OperationRemark,			OperationNote,			ObjectValue,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ResAuditLogKeys
	{

		#region Data Members

		Guid _auditLogID;

		#endregion

		#region Constructor

		public ResAuditLogKeys(Guid auditLogID)
		{
			 _auditLogID = auditLogID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  AuditLogID
		{
			 get { return _auditLogID; }
		}

		#endregion

	}
}
