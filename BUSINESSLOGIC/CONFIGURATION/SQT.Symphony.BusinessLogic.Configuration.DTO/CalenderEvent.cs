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
	public class CalenderEvent: BusinessObjectBase
	{

		#region InnerClass
		public enum CalenderEventFields
		{
			EventID,
			PropertyID,
			SeqNo,
			EventDate,
			EventName,
			Description,
			Rate,
			IsFlat,
			GroupEventID,
			IsActive,
			RateID,
			RoomTypeID
		}
		#endregion

		#region Data Members

			Guid _eventID;
			Guid _propertyID;
			int _seqNo;
			DateTime? _eventDate;
			string _eventName;
			string _description;
			decimal? _rate;
			bool _isFlat;
			Guid _groupEventID;
			bool _isActive;
			Guid? _rateID;
			Guid? _roomTypeID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  EventID
		{
			 get { return _eventID; }
			 set
			 {
				 if (_eventID != value)
				 {
					_eventID = value;
					 PropertyHasChanged("EventID");
				 }
			 }
		}

		[DataMember]
		public Guid  PropertyID
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
		public DateTime?  EventDate
		{
			 get { return _eventDate; }
			 set
			 {
				 if (_eventDate != value)
				 {
					_eventDate = value;
					 PropertyHasChanged("EventDate");
				 }
			 }
		}

		[DataMember]
		public string  EventName
		{
			 get { return _eventName; }
			 set
			 {
				 if (_eventName != value)
				 {
					_eventName = value;
					 PropertyHasChanged("EventName");
				 }
			 }
		}

		[DataMember]
		public string  Description
		{
			 get { return _description; }
			 set
			 {
				 if (_description != value)
				 {
					_description = value;
					 PropertyHasChanged("Description");
				 }
			 }
		}

		[DataMember]
		public decimal?  Rate
		{
			 get { return _rate; }
			 set
			 {
				 if (_rate != value)
				 {
					_rate = value;
					 PropertyHasChanged("Rate");
				 }
			 }
		}

		[DataMember]
		public bool  IsFlat
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
		public Guid  GroupEventID
		{
			 get { return _groupEventID; }
			 set
			 {
				 if (_groupEventID != value)
				 {
					_groupEventID = value;
					 PropertyHasChanged("GroupEventID");
				 }
			 }
		}

		[DataMember]
		public bool  IsActive
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
		public Guid?  RateID
		{
			 get { return _rateID; }
			 set
			 {
				 if (_rateID != value)
				 {
					_rateID = value;
					 PropertyHasChanged("RateID");
				 }
			 }
		}

		[DataMember]
		public Guid?  RoomTypeID
		{
			 get { return _roomTypeID; }
			 set
			 {
				 if (_roomTypeID != value)
				 {
					_roomTypeID = value;
					 PropertyHasChanged("RoomTypeID");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("EventID", "EventID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("PropertyID", "PropertyID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("EventName", "EventName",50));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Description", "Description",500));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("IsFlat", "IsFlat"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("GroupEventID", "GroupEventID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("IsActive", "IsActive"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"EventID = {0}\n"+
			"PropertyID = {1}\n"+
			"SeqNo = {2}\n"+
			"EventDate = {3}\n"+
			"EventName = {4}\n"+
			"Description = {5}\n"+
			"Rate = {6}\n"+
			"IsFlat = {7}\n"+
			"GroupEventID = {8}\n"+
			"IsActive = {9}\n"+
			"RateID = {10}\n"+
			"RoomTypeID = {11}\n",
			EventID,			PropertyID,			SeqNo,			EventDate,			EventName,			Description,			Rate,			IsFlat,			GroupEventID,			IsActive,			RateID,			RoomTypeID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class CalenderEventKeys
	{

		#region Data Members

		Guid _eventID;

		#endregion

		#region Constructor

		public CalenderEventKeys(Guid eventID)
		{
			 _eventID = eventID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  EventID
		{
			 get { return _eventID; }
		}

		#endregion

	}
}
