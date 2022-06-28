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
	public class RoomTypeAmenities: BusinessObjectBase
	{

		#region InnerClass
		public enum RoomTypeAmenitiesFields
		{
			RoomTypeAmenitiesID,
			AmenitiesID,
			RoomTypeID
		}
		#endregion

		#region Data Members

			Guid _roomTypeAmenitiesID;
			Guid? _amenitiesID;
			Guid? _roomTypeID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoomTypeAmenitiesID
		{
			 get { return _roomTypeAmenitiesID; }
			 set
			 {
				 if (_roomTypeAmenitiesID != value)
				 {
					_roomTypeAmenitiesID = value;
					 PropertyHasChanged("RoomTypeAmenitiesID");
				 }
			 }
		}

		[DataMember]
		public Guid?  AmenitiesID
		{
			 get { return _amenitiesID; }
			 set
			 {
				 if (_amenitiesID != value)
				 {
					_amenitiesID = value;
					 PropertyHasChanged("AmenitiesID");
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("RoomTypeAmenitiesID", "RoomTypeAmenitiesID"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"RoomTypeAmenitiesID = {0}~\n"+
			"AmenitiesID = {1}~\n"+
			"RoomTypeID = {2}~\n",
			RoomTypeAmenitiesID,			AmenitiesID,			RoomTypeID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class RoomTypeAmenitiesKeys
	{

		#region Data Members

		Guid _roomTypeAmenitiesID;

		#endregion

		#region Constructor

		public RoomTypeAmenitiesKeys(Guid roomTypeAmenitiesID)
		{
			 _roomTypeAmenitiesID = roomTypeAmenitiesID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoomTypeAmenitiesID
		{
			 get { return _roomTypeAmenitiesID; }
		}

		#endregion

	}
}
