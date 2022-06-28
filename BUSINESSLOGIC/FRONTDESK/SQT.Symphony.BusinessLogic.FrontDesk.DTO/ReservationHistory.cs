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
	public class ReservationHistory: BusinessObjectBase
	{

		#region InnerClass
		public enum ReservationHistoryFields
		{
			ResHistoryID,
			ReservationID,
			Operation,
			OperationDate,
			OperationBy,
			AuthorizedBy,
			Reason,
			ReasonByGuest,
			SeqNo,
			UserName,
			OldStatus_TermID,
			NewStatus_TermID,
			CompanyID,
			PropertyID,
			OldRecord,
			OperationRequestBy,
			OperationRequestMode_TermID
		}
		#endregion

		#region Data Members

			Guid _resHistoryID;
			Guid _reservationID;
			string _operation;
			DateTime? _operationDate;
			Guid? _operationBy;
			Guid? _authorizedBy;
			string _reason;
			string _reasonByGuest;
			int _seqNo;
			string _userName;
			int? _oldStatus_TermID;
			int? _newStatus_TermID;
			Guid? _companyID;
			Guid? _propertyID;
			string _oldRecord;
			string _operationRequestBy;
			Guid? _operationRequestMode_TermID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  ResHistoryID
		{
			 get { return _resHistoryID; }
			 set
			 {
				 if (_resHistoryID != value)
				 {
					_resHistoryID = value;
					 PropertyHasChanged("ResHistoryID");
				 }
			 }
		}

		[DataMember]
		public Guid  ReservationID
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
		public string  Operation
		{
			 get { return _operation; }
			 set
			 {
				 if (_operation != value)
				 {
					_operation = value;
					 PropertyHasChanged("Operation");
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
		public Guid?  OperationBy
		{
			 get { return _operationBy; }
			 set
			 {
				 if (_operationBy != value)
				 {
					_operationBy = value;
					 PropertyHasChanged("OperationBy");
				 }
			 }
		}

		[DataMember]
		public Guid?  AuthorizedBy
		{
			 get { return _authorizedBy; }
			 set
			 {
				 if (_authorizedBy != value)
				 {
					_authorizedBy = value;
					 PropertyHasChanged("AuthorizedBy");
				 }
			 }
		}

		[DataMember]
		public string  Reason
		{
			 get { return _reason; }
			 set
			 {
				 if (_reason != value)
				 {
					_reason = value;
					 PropertyHasChanged("Reason");
				 }
			 }
		}

		[DataMember]
		public string  ReasonByGuest
		{
			 get { return _reasonByGuest; }
			 set
			 {
				 if (_reasonByGuest != value)
				 {
					_reasonByGuest = value;
					 PropertyHasChanged("ReasonByGuest");
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
		public string  UserName
		{
			 get { return _userName; }
			 set
			 {
				 if (_userName != value)
				 {
					_userName = value;
					 PropertyHasChanged("UserName");
				 }
			 }
		}

		[DataMember]
		public int?  OldStatus_TermID
		{
			 get { return _oldStatus_TermID; }
			 set
			 {
				 if (_oldStatus_TermID != value)
				 {
					_oldStatus_TermID = value;
					 PropertyHasChanged("OldStatus_TermID");
				 }
			 }
		}

		[DataMember]
		public int?  NewStatus_TermID
		{
			 get { return _newStatus_TermID; }
			 set
			 {
				 if (_newStatus_TermID != value)
				 {
					_newStatus_TermID = value;
					 PropertyHasChanged("NewStatus_TermID");
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
		public string  OldRecord
		{
			 get { return _oldRecord; }
			 set
			 {
				 if (_oldRecord != value)
				 {
					_oldRecord = value;
					 PropertyHasChanged("OldRecord");
				 }
			 }
		}

		[DataMember]
		public string  OperationRequestBy
		{
			 get { return _operationRequestBy; }
			 set
			 {
				 if (_operationRequestBy != value)
				 {
					_operationRequestBy = value;
					 PropertyHasChanged("OperationRequestBy");
				 }
			 }
		}

		[DataMember]
		public Guid?  OperationRequestMode_TermID
		{
			 get { return _operationRequestMode_TermID; }
			 set
			 {
				 if (_operationRequestMode_TermID != value)
				 {
					_operationRequestMode_TermID = value;
					 PropertyHasChanged("OperationRequestMode_TermID");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ResHistoryID", "ResHistoryID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ReservationID", "ReservationID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("Operation", "Operation"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Operation", "Operation",120));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Reason", "Reason",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ReasonByGuest", "ReasonByGuest",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("UserName", "UserName",150));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("OldRecord", "OldRecord",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("OperationRequestBy", "OperationRequestBy",250));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ResHistoryID = {0}\n"+
			"ReservationID = {1}\n"+
			"Operation = {2}\n"+
			"OperationDate = {3}\n"+
			"OperationBy = {4}\n"+
			"AuthorizedBy = {5}\n"+
			"Reason = {6}\n"+
			"ReasonByGuest = {7}\n"+
			"SeqNo = {8}\n"+
			"UserName = {9}\n"+
			"OldStatus_TermID = {10}\n"+
			"NewStatus_TermID = {11}\n"+
			"CompanyID = {12}\n"+
			"PropertyID = {13}\n"+
			"OldRecord = {14}\n"+
			"OperationRequestBy = {15}\n"+
			"OperationRequestMode_TermID = {16}\n",
			ResHistoryID,			ReservationID,			Operation,			OperationDate,			OperationBy,			AuthorizedBy,			Reason,			ReasonByGuest,			SeqNo,			UserName,			OldStatus_TermID,			NewStatus_TermID,			CompanyID,			PropertyID,			OldRecord,			OperationRequestBy,			OperationRequestMode_TermID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ReservationHistoryKeys
	{

		#region Data Members

		Guid _resHistoryID;

		#endregion

		#region Constructor

		public ReservationHistoryKeys(Guid resHistoryID)
		{
			 _resHistoryID = resHistoryID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ResHistoryID
		{
			 get { return _resHistoryID; }
		}

		#endregion

	}
}
