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
	public class Reservation_LaundryDetail: BusinessObjectBase
	{

		#region InnerClass
		public enum Reservation_LaundryDetailFields
		{
			LaundryDetailID,
			GuestLaundryID,
			ItemID,
			TakenQty,
			Price,
			ReceivedQty,
			LaundryItemTypeID,
			LaundryServiceID,
			HotelServiceID,
			Fabric_TermID,
			Pattern_TermID,
			Colour_TermID,
			ReturnIn_TermID,
			IsReceived,
			IsPosted,
			BookID,
			DateOfTaken,
			DateOfReceived,
			LaundryRateID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive
		}
		#endregion

		#region Data Members

			Guid _laundryDetailID;
			Guid? _guestLaundryID;
			Guid? _itemID;
			decimal? _takenQty;
			decimal? _price;
			decimal? _receivedQty;
			Guid? _laundryItemTypeID;
			Guid? _laundryServiceID;
			Guid? _hotelServiceID;
			Guid? _fabric_TermID;
			Guid? _pattern_TermID;
			Guid? _colour_TermID;
			Guid? _returnIn_TermID;
			bool? _isReceived;
			bool? _isPosted;
			Guid? _bookID;
			DateTime? _dateOfTaken;
			DateTime? _dateOfReceived;
			Guid? _laundryRateID;
			Guid? _propertyID;
			Guid? _companyID;
			long _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;

		#endregion

		#region Properties

		[DataMember]
		public Guid  LaundryDetailID
		{
			 get { return _laundryDetailID; }
			 set
			 {
				 if (_laundryDetailID != value)
				 {
					_laundryDetailID = value;
					 PropertyHasChanged("LaundryDetailID");
				 }
			 }
		}

		[DataMember]
		public Guid?  GuestLaundryID
		{
			 get { return _guestLaundryID; }
			 set
			 {
				 if (_guestLaundryID != value)
				 {
					_guestLaundryID = value;
					 PropertyHasChanged("GuestLaundryID");
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
		public decimal?  TakenQty
		{
			 get { return _takenQty; }
			 set
			 {
				 if (_takenQty != value)
				 {
					_takenQty = value;
					 PropertyHasChanged("TakenQty");
				 }
			 }
		}

		[DataMember]
		public decimal?  Price
		{
			 get { return _price; }
			 set
			 {
				 if (_price != value)
				 {
					_price = value;
					 PropertyHasChanged("Price");
				 }
			 }
		}

		[DataMember]
		public decimal?  ReceivedQty
		{
			 get { return _receivedQty; }
			 set
			 {
				 if (_receivedQty != value)
				 {
					_receivedQty = value;
					 PropertyHasChanged("ReceivedQty");
				 }
			 }
		}

		[DataMember]
		public Guid?  LaundryItemTypeID
		{
			 get { return _laundryItemTypeID; }
			 set
			 {
				 if (_laundryItemTypeID != value)
				 {
					_laundryItemTypeID = value;
					 PropertyHasChanged("LaundryItemTypeID");
				 }
			 }
		}

		[DataMember]
		public Guid?  LaundryServiceID
		{
			 get { return _laundryServiceID; }
			 set
			 {
				 if (_laundryServiceID != value)
				 {
					_laundryServiceID = value;
					 PropertyHasChanged("LaundryServiceID");
				 }
			 }
		}

		[DataMember]
		public Guid?  HotelServiceID
		{
			 get { return _hotelServiceID; }
			 set
			 {
				 if (_hotelServiceID != value)
				 {
					_hotelServiceID = value;
					 PropertyHasChanged("HotelServiceID");
				 }
			 }
		}

		[DataMember]
		public Guid?  Fabric_TermID
		{
			 get { return _fabric_TermID; }
			 set
			 {
				 if (_fabric_TermID != value)
				 {
					_fabric_TermID = value;
					 PropertyHasChanged("Fabric_TermID");
				 }
			 }
		}

		[DataMember]
		public Guid?  Pattern_TermID
		{
			 get { return _pattern_TermID; }
			 set
			 {
				 if (_pattern_TermID != value)
				 {
					_pattern_TermID = value;
					 PropertyHasChanged("Pattern_TermID");
				 }
			 }
		}

		[DataMember]
		public Guid?  Colour_TermID
		{
			 get { return _colour_TermID; }
			 set
			 {
				 if (_colour_TermID != value)
				 {
					_colour_TermID = value;
					 PropertyHasChanged("Colour_TermID");
				 }
			 }
		}

		[DataMember]
		public Guid?  ReturnIn_TermID
		{
			 get { return _returnIn_TermID; }
			 set
			 {
				 if (_returnIn_TermID != value)
				 {
					_returnIn_TermID = value;
					 PropertyHasChanged("ReturnIn_TermID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsReceived
		{
			 get { return _isReceived; }
			 set
			 {
				 if (_isReceived != value)
				 {
					_isReceived = value;
					 PropertyHasChanged("IsReceived");
				 }
			 }
		}

		[DataMember]
		public bool?  IsPosted
		{
			 get { return _isPosted; }
			 set
			 {
				 if (_isPosted != value)
				 {
					_isPosted = value;
					 PropertyHasChanged("IsPosted");
				 }
			 }
		}

		[DataMember]
		public Guid?  BookID
		{
			 get { return _bookID; }
			 set
			 {
				 if (_bookID != value)
				 {
					_bookID = value;
					 PropertyHasChanged("BookID");
				 }
			 }
		}

		[DataMember]
		public DateTime?  DateOfTaken
		{
			 get { return _dateOfTaken; }
			 set
			 {
				 if (_dateOfTaken != value)
				 {
					_dateOfTaken = value;
					 PropertyHasChanged("DateOfTaken");
				 }
			 }
		}

		[DataMember]
		public DateTime?  DateOfReceived
		{
			 get { return _dateOfReceived; }
			 set
			 {
				 if (_dateOfReceived != value)
				 {
					_dateOfReceived = value;
					 PropertyHasChanged("DateOfReceived");
				 }
			 }
		}

		[DataMember]
		public Guid?  LaundryRateID
		{
			 get { return _laundryRateID; }
			 set
			 {
				 if (_laundryRateID != value)
				 {
					_laundryRateID = value;
					 PropertyHasChanged("LaundryRateID");
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
		public long  SeqNo
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("LaundryDetailID", "LaundryDetailID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"LaundryDetailID = {0}\n"+
			"GuestLaundryID = {1}\n"+
			"ItemID = {2}\n"+
			"TakenQty = {3}\n"+
			"Price = {4}\n"+
			"ReceivedQty = {5}\n"+
			"LaundryItemTypeID = {6}\n"+
			"LaundryServiceID = {7}\n"+
			"HotelServiceID = {8}\n"+
			"Fabric_TermID = {9}\n"+
			"Pattern_TermID = {10}\n"+
			"Colour_TermID = {11}\n"+
			"ReturnIn_TermID = {12}\n"+
			"IsReceived = {13}\n"+
			"IsPosted = {14}\n"+
			"BookID = {15}\n"+
			"DateOfTaken = {16}\n"+
			"DateOfReceived = {17}\n"+
			"LaundryRateID = {18}\n"+
			"PropertyID = {19}\n"+
			"CompanyID = {20}\n"+
			"SeqNo = {21}\n"+
			"IsSynch = {22}\n"+
			"SynchOn = {23}\n"+
			"UpdatedOn = {24}\n"+
			"UpdatedBy = {25}\n"+
			"IsActive = {26}\n",
			LaundryDetailID,			GuestLaundryID,			ItemID,			TakenQty,			Price,			ReceivedQty,			LaundryItemTypeID,			LaundryServiceID,			HotelServiceID,			Fabric_TermID,			Pattern_TermID,			Colour_TermID,			ReturnIn_TermID,			IsReceived,			IsPosted,			BookID,			DateOfTaken,			DateOfReceived,			LaundryRateID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class Reservation_LaundryDetailKeys
	{

		#region Data Members

		Guid _laundryDetailID;

		#endregion

		#region Constructor

		public Reservation_LaundryDetailKeys(Guid laundryDetailID)
		{
			 _laundryDetailID = laundryDetailID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  LaundryDetailID
		{
			 get { return _laundryDetailID; }
		}

		#endregion

	}
}
