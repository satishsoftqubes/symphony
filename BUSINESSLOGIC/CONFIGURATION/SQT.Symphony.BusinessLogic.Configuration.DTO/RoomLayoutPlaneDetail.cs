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
	public class RoomLayoutPlaneDetail: BusinessObjectBase
	{

		#region InnerClass
		public enum RoomLayoutPlaneDetailFields
		{
			RoomLayoutID,
			PropertyID,
			PlaneID,
			SeqNo,
			WingID,
			FloorID,
			TypeOfItem,
			CarpetArea,
			Usefor,
			ItemID,
			TopPos,
			LeftPos,
			Height,
			Width,
			ItemTax,
			ItemImage,
			FontName,
			FontSize,
			IsActive,
			SynchOn
		}
		#endregion

		#region Data Members

			Guid _roomLayoutID;
			Guid? _propertyID;
			Guid? _planeID;
			int? _seqNo;
			Guid? _wingID;
			Guid? _floorID;
			string _typeOfItem;
			decimal? _carpetArea;
			string _usefor;
			Guid? _itemID;
			int? _topPos;
			int? _leftPos;
			int? _height;
			int? _width;
			string _itemTax;
			byte[] _itemImage;
			string _fontName;
			int? _fontSize;
			int? _isActive;
			DateTime? _synchOn;

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoomLayoutID
		{
			 get { return _roomLayoutID; }
			 set
			 {
				 if (_roomLayoutID != value)
				 {
					_roomLayoutID = value;
					 PropertyHasChanged("RoomLayoutID");
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
		public Guid?  PlaneID
		{
			 get { return _planeID; }
			 set
			 {
				 if (_planeID != value)
				 {
					_planeID = value;
					 PropertyHasChanged("PlaneID");
				 }
			 }
		}

		[DataMember]
		public int?  SeqNo
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
		public Guid?  WingID
		{
			 get { return _wingID; }
			 set
			 {
				 if (_wingID != value)
				 {
					_wingID = value;
					 PropertyHasChanged("WingID");
				 }
			 }
		}

		[DataMember]
		public Guid?  FloorID
		{
			 get { return _floorID; }
			 set
			 {
				 if (_floorID != value)
				 {
					_floorID = value;
					 PropertyHasChanged("FloorID");
				 }
			 }
		}

		[DataMember]
		public string  TypeOfItem
		{
			 get { return _typeOfItem; }
			 set
			 {
				 if (_typeOfItem != value)
				 {
					_typeOfItem = value;
					 PropertyHasChanged("TypeOfItem");
				 }
			 }
		}

		[DataMember]
		public decimal?  CarpetArea
		{
			 get { return _carpetArea; }
			 set
			 {
				 if (_carpetArea != value)
				 {
					_carpetArea = value;
					 PropertyHasChanged("CarpetArea");
				 }
			 }
		}

		[DataMember]
		public string  Usefor
		{
			 get { return _usefor; }
			 set
			 {
				 if (_usefor != value)
				 {
					_usefor = value;
					 PropertyHasChanged("Usefor");
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
		public int?  TopPos
		{
			 get { return _topPos; }
			 set
			 {
				 if (_topPos != value)
				 {
					_topPos = value;
					 PropertyHasChanged("TopPos");
				 }
			 }
		}

		[DataMember]
		public int?  LeftPos
		{
			 get { return _leftPos; }
			 set
			 {
				 if (_leftPos != value)
				 {
					_leftPos = value;
					 PropertyHasChanged("LeftPos");
				 }
			 }
		}

		[DataMember]
		public int?  Height
		{
			 get { return _height; }
			 set
			 {
				 if (_height != value)
				 {
					_height = value;
					 PropertyHasChanged("Height");
				 }
			 }
		}

		[DataMember]
		public int?  Width
		{
			 get { return _width; }
			 set
			 {
				 if (_width != value)
				 {
					_width = value;
					 PropertyHasChanged("Width");
				 }
			 }
		}

		[DataMember]
		public string  ItemTax
		{
			 get { return _itemTax; }
			 set
			 {
				 if (_itemTax != value)
				 {
					_itemTax = value;
					 PropertyHasChanged("ItemTax");
				 }
			 }
		}

		[DataMember]
		public byte[]  ItemImage
		{
			 get { return _itemImage; }
			 set
			 {
				 if (_itemImage != value)
				 {
					_itemImage = value;
					 PropertyHasChanged("ItemImage");
				 }
			 }
		}

		[DataMember]
		public string  FontName
		{
			 get { return _fontName; }
			 set
			 {
				 if (_fontName != value)
				 {
					_fontName = value;
					 PropertyHasChanged("FontName");
				 }
			 }
		}

		[DataMember]
		public int?  FontSize
		{
			 get { return _fontSize; }
			 set
			 {
				 if (_fontSize != value)
				 {
					_fontSize = value;
					 PropertyHasChanged("FontSize");
				 }
			 }
		}

		[DataMember]
		public int?  IsActive
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("RoomLayoutID", "RoomLayoutID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("TypeOfItem", "TypeOfItem",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Usefor", "Usefor",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ItemTax", "ItemTax",180));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("FontName", "FontName",180));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"RoomLayoutID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"PlaneID = {2}~\n"+
			"SeqNo = {3}~\n"+
			"WingID = {4}~\n"+
			"FloorID = {5}~\n"+
			"TypeOfItem = {6}~\n"+
			"CarpetArea = {7}~\n"+
			"Usefor = {8}~\n"+
			"ItemID = {9}~\n"+
			"TopPos = {10}~\n"+
			"LeftPos = {11}~\n"+
			"Height = {12}~\n"+
			"Width = {13}~\n"+
			"ItemTax = {14}~\n"+
			"ItemImage = {15}~\n"+
			"FontName = {16}~\n"+
			"FontSize = {17}~\n"+
			"IsActive = {18}~\n"+
			"SynchOn = {19}~\n",
			RoomLayoutID,			PropertyID,			PlaneID,			SeqNo,			WingID,			FloorID,			TypeOfItem,			CarpetArea,			Usefor,			ItemID,			TopPos,			LeftPos,			Height,			Width,			ItemTax,			ItemImage,			FontName,			FontSize,			IsActive,			SynchOn);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class RoomLayoutPlaneDetailKeys
	{

		#region Data Members

		Guid _roomLayoutID;

		#endregion

		#region Constructor

		public RoomLayoutPlaneDetailKeys(Guid roomLayoutID)
		{
			 _roomLayoutID = roomLayoutID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoomLayoutID
		{
			 get { return _roomLayoutID; }
		}

		#endregion

	}
}
