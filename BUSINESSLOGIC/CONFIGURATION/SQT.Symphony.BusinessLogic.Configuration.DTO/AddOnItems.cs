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
	public class AddOnItems: BusinessObjectBase
	{

		#region InnerClass
		public enum AddOnItemsFields
		{
			AddOnItemID,
			AddOnID,
			ItemID,
			Qty,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive
		}
		#endregion

		#region Data Members

			Guid _addOnItemID;
			Guid? _addOnID;
			Guid? _itemID;
			decimal? _qty;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;

		#endregion

		#region Properties

		[DataMember]
		public Guid  AddOnItemID
		{
			 get { return _addOnItemID; }
			 set
			 {
				 if (_addOnItemID != value)
				 {
					_addOnItemID = value;
					 PropertyHasChanged("AddOnItemID");
				 }
			 }
		}

		[DataMember]
		public Guid?  AddOnID
		{
			 get { return _addOnID; }
			 set
			 {
				 if (_addOnID != value)
				 {
					_addOnID = value;
					 PropertyHasChanged("AddOnID");
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
		public decimal?  Qty
		{
			 get { return _qty; }
			 set
			 {
				 if (_qty != value)
				 {
					_qty = value;
					 PropertyHasChanged("Qty");
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("AddOnItemID", "AddOnItemID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"AddOnItemID = {0}~\n"+
			"AddOnID = {1}~\n"+
			"ItemID = {2}~\n"+
			"Qty = {3}~\n"+
			"SeqNo = {4}~\n"+
			"IsSynch = {5}~\n"+
			"SynchOn = {6}~\n"+
			"UpdatedOn = {7}~\n"+
			"UpdatedBy = {8}~\n"+
			"IsActive = {9}~\n",
			AddOnItemID,			AddOnID,			ItemID,			Qty,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class AddOnItemsKeys
	{

		#region Data Members

		Guid _addOnItemID;

		#endregion

		#region Constructor

		public AddOnItemsKeys(Guid addOnItemID)
		{
			 _addOnItemID = addOnItemID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  AddOnItemID
		{
			 get { return _addOnItemID; }
		}

		#endregion

	}
}
