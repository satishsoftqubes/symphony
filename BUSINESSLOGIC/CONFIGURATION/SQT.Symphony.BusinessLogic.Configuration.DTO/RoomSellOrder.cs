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
	public class RoomSellOrder: BusinessObjectBase
	{

		#region InnerClass
		public enum RoomSellOrderFields
		{
			RoomSellOrderID,
			RoomTypeID,
			RoomID,
			RoomTypeWiseOrder,
			OverAllOrder
		}
		#endregion

		#region Data Members

			Guid _roomSellOrderID;
			Guid? _roomTypeID;
			Guid? _roomID;
			int? _roomTypeWiseOrder;
			int? _overAllOrder;

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoomSellOrderID
		{
			 get { return _roomSellOrderID; }
			 set
			 {
				 if (_roomSellOrderID != value)
				 {
					_roomSellOrderID = value;
					 PropertyHasChanged("RoomSellOrderID");
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
		public int?  RoomTypeWiseOrder
		{
			 get { return _roomTypeWiseOrder; }
			 set
			 {
				 if (_roomTypeWiseOrder != value)
				 {
					_roomTypeWiseOrder = value;
					 PropertyHasChanged("RoomTypeWiseOrder");
				 }
			 }
		}

		[DataMember]
		public int?  OverAllOrder
		{
			 get { return _overAllOrder; }
			 set
			 {
				 if (_overAllOrder != value)
				 {
					_overAllOrder = value;
					 PropertyHasChanged("OverAllOrder");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("RoomSellOrderID", "RoomSellOrderID"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"RoomSellOrderID = {0}~\n"+
			"RoomTypeID = {1}~\n"+
			"RoomID = {2}~\n"+
			"RoomTypeWiseOrder = {3}~\n"+
			"OverAllOrder = {4}~\n",
			RoomSellOrderID,			RoomTypeID,			RoomID,			RoomTypeWiseOrder,			OverAllOrder);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class RoomSellOrderKeys
	{

		#region Data Members

		Guid _roomSellOrderID;

		#endregion

		#region Constructor

		public RoomSellOrderKeys(Guid roomSellOrderID)
		{
			 _roomSellOrderID = roomSellOrderID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoomSellOrderID
		{
			 get { return _roomSellOrderID; }
		}

		#endregion

	}
}
