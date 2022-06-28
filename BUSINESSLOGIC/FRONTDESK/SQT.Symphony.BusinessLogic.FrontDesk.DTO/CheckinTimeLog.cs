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
	public class CheckinTimeLog: BusinessObjectBase
	{

		#region InnerClass
		public enum CheckinTimeLogFields
		{
			CheckInLogID,
			ReservationID,
			ReservationType_TermID,
			CheckInStartTime,
			CheckInEndTime,
			CheckInBy,
			CreatedOn,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn
		}
		#endregion

		#region Data Members

			Guid _checkInLogID;
			Guid? _reservationID;
			Guid? _reservationType_TermID;
			DateTime? _checkInStartTime;
			DateTime? _checkInEndTime;
			Guid? _checkInBy;
			DateTime? _createdOn;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;

		#endregion

		#region Properties

		[DataMember]
		public Guid  CheckInLogID
		{
			 get { return _checkInLogID; }
			 set
			 {
				 if (_checkInLogID != value)
				 {
					_checkInLogID = value;
					 PropertyHasChanged("CheckInLogID");
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
		public Guid?  ReservationType_TermID
		{
			 get { return _reservationType_TermID; }
			 set
			 {
				 if (_reservationType_TermID != value)
				 {
					_reservationType_TermID = value;
					 PropertyHasChanged("ReservationType_TermID");
				 }
			 }
		}

		[DataMember]
		public DateTime?  CheckInStartTime
		{
			 get { return _checkInStartTime; }
			 set
			 {
				 if (_checkInStartTime != value)
				 {
					_checkInStartTime = value;
					 PropertyHasChanged("CheckInStartTime");
				 }
			 }
		}

		[DataMember]
		public DateTime?  CheckInEndTime
		{
			 get { return _checkInEndTime; }
			 set
			 {
				 if (_checkInEndTime != value)
				 {
					_checkInEndTime = value;
					 PropertyHasChanged("CheckInEndTime");
				 }
			 }
		}

		[DataMember]
		public Guid?  CheckInBy
		{
			 get { return _checkInBy; }
			 set
			 {
				 if (_checkInBy != value)
				 {
					_checkInBy = value;
					 PropertyHasChanged("CheckInBy");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("CheckInLogID", "CheckInLogID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"CheckInLogID = {0}\n"+
			"ReservationID = {1}\n"+
			"ReservationType_TermID = {2}\n"+
			"CheckInStartTime = {3}\n"+
			"CheckInEndTime = {4}\n"+
			"CheckInBy = {5}\n"+
			"CreatedOn = {6}\n"+
			"PropertyID = {7}\n"+
			"CompanyID = {8}\n"+
			"SeqNo = {9}\n"+
			"IsSynch = {10}\n"+
			"SynchOn = {11}\n",
			CheckInLogID,			ReservationID,			ReservationType_TermID,			CheckInStartTime,			CheckInEndTime,			CheckInBy,			CreatedOn,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class CheckinTimeLogKeys
	{

		#region Data Members

		Guid _checkInLogID;

		#endregion

		#region Constructor

		public CheckinTimeLogKeys(Guid checkInLogID)
		{
			 _checkInLogID = checkInLogID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  CheckInLogID
		{
			 get { return _checkInLogID; }
		}

		#endregion

	}
}
