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
	public class ItemUOM: BusinessObjectBase
	{

		#region InnerClass
		public enum ItemUOMFields
		{
			ItemUOMID,
			SeqNo,
			IsSynch,
			SynchOn,
			IsActive,
			ItemID,
			UOMID1,
			Factor1,
			UOMID2,
			Factor2
		}
		#endregion

		#region Data Members

			Guid _itemUOMID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			bool? _isActive;
			Guid? _itemID;
			Guid? _uOMID1;
			decimal? _factor1;
			Guid? _uOMID2;
			decimal? _factor2;

		#endregion

		#region Properties

		[DataMember]
		public Guid  ItemUOMID
		{
			 get { return _itemUOMID; }
			 set
			 {
				 if (_itemUOMID != value)
				 {
					_itemUOMID = value;
					 PropertyHasChanged("ItemUOMID");
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
		public Guid?  UOMID1
		{
			 get { return _uOMID1; }
			 set
			 {
				 if (_uOMID1 != value)
				 {
					_uOMID1 = value;
					 PropertyHasChanged("UOMID1");
				 }
			 }
		}

		[DataMember]
		public decimal?  Factor1
		{
			 get { return _factor1; }
			 set
			 {
				 if (_factor1 != value)
				 {
					_factor1 = value;
					 PropertyHasChanged("Factor1");
				 }
			 }
		}

		[DataMember]
		public Guid?  UOMID2
		{
			 get { return _uOMID2; }
			 set
			 {
				 if (_uOMID2 != value)
				 {
					_uOMID2 = value;
					 PropertyHasChanged("UOMID2");
				 }
			 }
		}

		[DataMember]
		public decimal?  Factor2
		{
			 get { return _factor2; }
			 set
			 {
				 if (_factor2 != value)
				 {
					_factor2 = value;
					 PropertyHasChanged("Factor2");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ItemUOMID", "ItemUOMID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ItemUOMID = {0}~\n"+
			"SeqNo = {1}~\n"+
			"IsSynch = {2}~\n"+
			"SynchOn = {3}~\n"+
			"IsActive = {4}~\n"+
			"ItemID = {5}~\n"+
			"UOMID1 = {6}~\n"+
			"Factor1 = {7}~\n"+
			"UOMID2 = {8}~\n"+
			"Factor2 = {9}~\n",
			ItemUOMID,			SeqNo,			IsSynch,			SynchOn,			IsActive,			ItemID,			UOMID1,			Factor1,			UOMID2,			Factor2);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ItemUOMKeys
	{

		#region Data Members

		Guid _itemUOMID;

		#endregion

		#region Constructor

		public ItemUOMKeys(Guid itemUOMID)
		{
			 _itemUOMID = itemUOMID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ItemUOMID
		{
			 get { return _itemUOMID; }
		}

		#endregion

	}
}
