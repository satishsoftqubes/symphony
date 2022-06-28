using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;
namespace SQT.Symphony.BusinessLogic.BackOffice.DTO
{
	[DataContract]
	public class DayEnd: BusinessObjectBase
	{

		#region InnerClass
		public enum DayEndFields
		{
			DayEndID,
			SeqNo,
			LastAuditDate,
			AuditDate,
			UserID,
			Notes,
			ClosedBusinessDay,
			OpeningBusinessDay,
			IsExpress,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive
		}
		#endregion

		#region Data Members

			Guid _dayEndID;
			int _seqNo;
			DateTime _lastAuditDate;
			DateTime _auditDate;
			Guid _userID;
			string _notes;
			DateTime? _closedBusinessDay;
			DateTime? _openingBusinessDay;
			bool? _isExpress;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;

		#endregion

		#region Properties

		[DataMember]
		public Guid  DayEndID
		{
			 get { return _dayEndID; }
			 set
			 {
				 if (_dayEndID != value)
				 {
					_dayEndID = value;
					 PropertyHasChanged("DayEndID");
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
		public DateTime  LastAuditDate
		{
			 get { return _lastAuditDate; }
			 set
			 {
				 if (_lastAuditDate != value)
				 {
					_lastAuditDate = value;
					 PropertyHasChanged("LastAuditDate");
				 }
			 }
		}

		[DataMember]
		public DateTime  AuditDate
		{
			 get { return _auditDate; }
			 set
			 {
				 if (_auditDate != value)
				 {
					_auditDate = value;
					 PropertyHasChanged("AuditDate");
				 }
			 }
		}

		[DataMember]
		public Guid  UserID
		{
			 get { return _userID; }
			 set
			 {
				 if (_userID != value)
				 {
					_userID = value;
					 PropertyHasChanged("UserID");
				 }
			 }
		}

		[DataMember]
		public string  Notes
		{
			 get { return _notes; }
			 set
			 {
				 if (_notes != value)
				 {
					_notes = value;
					 PropertyHasChanged("Notes");
				 }
			 }
		}

		[DataMember]
		public DateTime?  ClosedBusinessDay
		{
			 get { return _closedBusinessDay; }
			 set
			 {
				 if (_closedBusinessDay != value)
				 {
					_closedBusinessDay = value;
					 PropertyHasChanged("ClosedBusinessDay");
				 }
			 }
		}

		[DataMember]
		public DateTime?  OpeningBusinessDay
		{
			 get { return _openingBusinessDay; }
			 set
			 {
				 if (_openingBusinessDay != value)
				 {
					_openingBusinessDay = value;
					 PropertyHasChanged("OpeningBusinessDay");
				 }
			 }
		}

		[DataMember]
		public bool?  IsExpress
		{
			 get { return _isExpress; }
			 set
			 {
				 if (_isExpress != value)
				 {
					_isExpress = value;
					 PropertyHasChanged("IsExpress");
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("DayEndID", "DayEndID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("LastAuditDate", "LastAuditDate"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("AuditDate", "AuditDate"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("UserID", "UserID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Notes", "Notes",500));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"DayEndID = {0}\n"+
			"SeqNo = {1}\n"+
			"LastAuditDate = {2}\n"+
			"AuditDate = {3}\n"+
			"UserID = {4}\n"+
			"Notes = {5}\n"+
			"ClosedBusinessDay = {6}\n"+
			"OpeningBusinessDay = {7}\n"+
			"IsExpress = {8}\n"+
			"IsSynch = {9}\n"+
			"SynchOn = {10}\n"+
			"UpdatedOn = {11}\n"+
			"UpdatedBy = {12}\n"+
			"IsActive = {13}\n",
			DayEndID,			SeqNo,			LastAuditDate,			AuditDate,			UserID,			Notes,			ClosedBusinessDay,			OpeningBusinessDay,			IsExpress,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class DayEndKeys
	{

		#region Data Members

		Guid _dayEndID;

		#endregion

		#region Constructor

		public DayEndKeys(Guid dayEndID)
		{
			 _dayEndID = dayEndID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  DayEndID
		{
			 get { return _dayEndID; }
		}

		#endregion

	}
}
