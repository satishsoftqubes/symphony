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
	public class RoomBlockDetails: BusinessObjectBase
	{

		#region InnerClass
		public enum RoomBlockDetailsFields
		{
			BlockRoomDetailID,
			BlockRoomID,
			RoomTypeID,
			RoomID,
			ConferenceID
		}
		#endregion

		#region Data Members

			Guid _blockRoomDetailID;
			Guid _blockRoomID;
			Guid? _roomTypeID;
			Guid? _roomID;
			Guid? _conferenceID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  BlockRoomDetailID
		{
			 get { return _blockRoomDetailID; }
			 set
			 {
				 if (_blockRoomDetailID != value)
				 {
					_blockRoomDetailID = value;
					 PropertyHasChanged("BlockRoomDetailID");
				 }
			 }
		}

		[DataMember]
		public Guid  BlockRoomID
		{
			 get { return _blockRoomID; }
			 set
			 {
				 if (_blockRoomID != value)
				 {
					_blockRoomID = value;
					 PropertyHasChanged("BlockRoomID");
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
		public Guid?  ConferenceID
		{
			 get { return _conferenceID; }
			 set
			 {
				 if (_conferenceID != value)
				 {
					_conferenceID = value;
					 PropertyHasChanged("ConferenceID");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("BlockRoomDetailID", "BlockRoomDetailID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("BlockRoomID", "BlockRoomID"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"BlockRoomDetailID = {0}~\n"+
			"BlockRoomID = {1}~\n"+
			"RoomTypeID = {2}~\n"+
			"RoomID = {3}~\n"+
			"ConferenceID = {4}~\n",
			BlockRoomDetailID,			BlockRoomID,			RoomTypeID,			RoomID,			ConferenceID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class RoomBlockDetailsKeys
	{

		#region Data Members

		Guid _blockRoomDetailID;

		#endregion

		#region Constructor

		public RoomBlockDetailsKeys(Guid blockRoomDetailID)
		{
			 _blockRoomDetailID = blockRoomDetailID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  BlockRoomDetailID
		{
			 get { return _blockRoomDetailID; }
		}

		#endregion

	}
}
