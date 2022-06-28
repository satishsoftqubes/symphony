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
	public class RoomAmenities: BusinessObjectBase
	{

		#region InnerClass
		public enum RoomAmenitiesFields
		{
			RoomAmenitiesID,
			RoomID,
			AmenitiesID
		}
		#endregion

		#region Data Members

			Guid _roomAmenitiesID;
			Guid? _roomID;
			Guid? _amenitiesID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoomAmenitiesID
		{
			 get { return _roomAmenitiesID; }
			 set
			 {
				 if (_roomAmenitiesID != value)
				 {
					_roomAmenitiesID = value;
					 PropertyHasChanged("RoomAmenitiesID");
				 }
			 }
		}

		[DataMember]
		public Guid?  RoomID
		{
			 get { return _roomID; }
			 set
			 {
				 if (_roomID != value)
				 {
					_roomID = value;
					 PropertyHasChanged("RoomID");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("RoomAmenitiesID", "RoomAmenitiesID"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"RoomAmenitiesID = {0}~\n"+
			"RoomID = {1}~\n"+
			"AmenitiesID = {2}~\n",
			RoomAmenitiesID,			RoomID,			AmenitiesID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class RoomAmenitiesKeys
	{

		#region Data Members

		Guid _roomAmenitiesID;

		#endregion

		#region Constructor

		public RoomAmenitiesKeys(Guid roomAmenitiesID)
		{
			 _roomAmenitiesID = roomAmenitiesID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoomAmenitiesID
		{
			 get { return _roomAmenitiesID; }
		}

		#endregion

	}
}
