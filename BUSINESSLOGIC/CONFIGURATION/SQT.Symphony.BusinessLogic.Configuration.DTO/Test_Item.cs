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
	public class Test_Item: BusinessObjectBase
	{

		#region InnerClass
		public enum Test_ItemFields
		{
			ItemID,
			ItemName,
			ItemOrder
		}
		#endregion

		#region Data Members

			int _itemID;
			string _itemName;
			int? _itemOrder;

		#endregion

		#region Properties

		[DataMember]
		public int  ItemID
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
		public string  ItemName
		{
			 get { return _itemName; }
			 set
			 {
				 if (_itemName != value)
				 {
					_itemName = value;
					 PropertyHasChanged("ItemName");
				 }
			 }
		}

		[DataMember]
		public int?  ItemOrder
		{
			 get { return _itemOrder; }
			 set
			 {
				 if (_itemOrder != value)
				 {
					_itemOrder = value;
					 PropertyHasChanged("ItemOrder");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ItemID", "ItemID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ItemName", "ItemName",50));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ItemID = {0}\n"+
			"ItemName = {1}\n"+
			"ItemOrder = {2}\n",
			ItemID,			ItemName,			ItemOrder);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class Test_ItemKeys
	{

		#region Data Members

		int _itemID;

		#endregion

		#region Constructor

		public Test_ItemKeys(int itemID)
		{
			 _itemID = itemID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public int  ItemID
		{
			 get { return _itemID; }
		}

		#endregion

	}
}
