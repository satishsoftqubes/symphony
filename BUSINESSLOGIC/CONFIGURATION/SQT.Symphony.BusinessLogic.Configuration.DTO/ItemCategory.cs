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
	public class ItemCategory: BusinessObjectBase
	{

		#region InnerClass
		public enum ItemCategoryFields
		{
			ItemCategoryID,
			ItemID,
			CategoryID,
			OrderNo
		}
		#endregion

		#region Data Members

			Guid _itemCategoryID;
			Guid? _itemID;
			Guid? _categoryID;
			int? _orderNo;

		#endregion

		#region Properties

		[DataMember]
		public Guid  ItemCategoryID
		{
			 get { return _itemCategoryID; }
			 set
			 {
				 if (_itemCategoryID != value)
				 {
					_itemCategoryID = value;
					 PropertyHasChanged("ItemCategoryID");
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
		public Guid?  CategoryID
		{
			 get { return _categoryID; }
			 set
			 {
				 if (_categoryID != value)
				 {
					_categoryID = value;
					 PropertyHasChanged("CategoryID");
				 }
			 }
		}

		[DataMember]
		public int?  OrderNo
		{
			 get { return _orderNo; }
			 set
			 {
				 if (_orderNo != value)
				 {
					_orderNo = value;
					 PropertyHasChanged("OrderNo");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ItemCategoryID", "ItemCategoryID"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ItemCategoryID = {0}~\n"+
			"ItemID = {1}~\n"+
			"CategoryID = {2}~\n"+
			"OrderNo = {3}~\n",
			ItemCategoryID,			ItemID,			CategoryID,			OrderNo);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ItemCategoryKeys
	{

		#region Data Members

		Guid _itemCategoryID;

		#endregion

		#region Constructor

		public ItemCategoryKeys(Guid itemCategoryID)
		{
			 _itemCategoryID = itemCategoryID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ItemCategoryID
		{
			 get { return _itemCategoryID; }
		}

		#endregion

	}
}
