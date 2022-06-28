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
	public class RoomTypeDeposit: BusinessObjectBase
	{

		#region InnerClass
		public enum RoomTypeDepositFields
		{
			RoomTypeDepositID,
			RoomTypeID,
			DepositID,
			DepositRate,
			IsRateFlat,
			SeqNo
		}
		#endregion

		#region Data Members

			Guid _roomTypeDepositID;
			Guid? _roomTypeID;
			Guid? _depositID;
			decimal? _depositRate;
			bool? _isRateFlat;
			int _seqNo;

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoomTypeDepositID
		{
			 get { return _roomTypeDepositID; }
			 set
			 {
				 if (_roomTypeDepositID != value)
				 {
					_roomTypeDepositID = value;
					 PropertyHasChanged("RoomTypeDepositID");
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
		public Guid?  DepositID
		{
			 get { return _depositID; }
			 set
			 {
				 if (_depositID != value)
				 {
					_depositID = value;
					 PropertyHasChanged("DepositID");
				 }
			 }
		}

		[DataMember]
		public decimal?  DepositRate
		{
			 get { return _depositRate; }
			 set
			 {
				 if (_depositRate != value)
				 {
					_depositRate = value;
					 PropertyHasChanged("DepositRate");
				 }
			 }
		}

		[DataMember]
		public bool?  IsRateFlat
		{
			 get { return _isRateFlat; }
			 set
			 {
				 if (_isRateFlat != value)
				 {
					_isRateFlat = value;
					 PropertyHasChanged("IsRateFlat");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("RoomTypeDepositID", "RoomTypeDepositID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
            "RoomTypeDepositID = {0}~\n" +
            "RoomTypeID = {1}~\n" +
            "DepositID = {2}~\n" +
            "DepositRate = {3}~\n" +
            "IsRateFlat = {4}~\n" +
            "SeqNo = {5}~\n",
			RoomTypeDepositID,			RoomTypeID,			DepositID,			DepositRate,			IsRateFlat,			SeqNo);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class RoomTypeDepositKeys
	{

		#region Data Members

		Guid _roomTypeDepositID;

		#endregion

		#region Constructor

		public RoomTypeDepositKeys(Guid roomTypeDepositID)
		{
			 _roomTypeDepositID = roomTypeDepositID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoomTypeDepositID
		{
			 get { return _roomTypeDepositID; }
		}

		#endregion

	}
}
