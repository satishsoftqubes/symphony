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
	public class RoomTypeServices: BusinessObjectBase
	{

		#region InnerClass
		public enum RoomTypeServicesFields
		{
			RoomTypeServiceID,
			RoomTypeID,
			ItemID,
			IsPerPerson,
			ServiceRate
		}
		#endregion

		#region Data Members

			Guid _roomTypeServiceID;
			Guid? _roomTypeID;
			Guid? _itemID;
			bool? _isPerPerson;
			decimal? _serviceRate;

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoomTypeServiceID
		{
			 get { return _roomTypeServiceID; }
			 set
			 {
				 if (_roomTypeServiceID != value)
				 {
					_roomTypeServiceID = value;
					 PropertyHasChanged("RoomTypeServiceID");
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

		[DataMember]
		public Guid?  ItemID
		{
			 get { return _itemID; }
			 set
			 {
				 if (_itemID != value)
				 {
					_itemID = value;
					 PropertyHasChanged("ItemID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsPerPerson
		{
			 get { return _isPerPerson; }
			 set
			 {
				 if (_isPerPerson != value)
				 {
					_isPerPerson = value;
					 PropertyHasChanged("IsPerPerson");
				 }
			 }
		}

		[DataMember]
		public decimal?  ServiceRate
		{
			 get { return _serviceRate; }
			 set
			 {
				 if (_serviceRate != value)
				 {
					_serviceRate = value;
					 PropertyHasChanged("ServiceRate");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("RoomTypeServiceID", "RoomTypeServiceID"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"RoomTypeServiceID = {0}\n"+
			"RoomTypeID = {1}\n"+
			"ItemID = {2}\n"+
			"IsPerPerson = {3}\n"+
			"ServiceRate = {4}\n",
			RoomTypeServiceID,			RoomTypeID,			ItemID,			IsPerPerson,			ServiceRate);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class RoomTypeServicesKeys
	{

		#region Data Members

		Guid _roomTypeServiceID;

		#endregion

		#region Constructor

		public RoomTypeServicesKeys(Guid roomTypeServiceID)
		{
			 _roomTypeServiceID = roomTypeServiceID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoomTypeServiceID
		{
			 get { return _roomTypeServiceID; }
		}

		#endregion

	}
}
