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
	public class ItemTax: BusinessObjectBase
	{

		#region InnerClass
		public enum ItemTaxFields
		{
			ItemTaxID,
			ItemID,
			TaxID,
			SeqNo,
			IsSynch,
			SynchOn
		}
		#endregion

		#region Data Members

			Guid _itemTaxID;
			Guid? _itemID;
			Guid? _taxID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;

		#endregion

		#region Properties

		[DataMember]
		public Guid  ItemTaxID
		{
			 get { return _itemTaxID; }
			 set
			 {
				 if (_itemTaxID != value)
				 {
					_itemTaxID = value;
					 PropertyHasChanged("ItemTaxID");
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
		public Guid?  TaxID
		{
			 get { return _taxID; }
			 set
			 {
				 if (_taxID != value)
				 {
					_taxID = value;
					 PropertyHasChanged("TaxID");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ItemTaxID", "ItemTaxID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ItemTaxID = {0}~\n"+
			"ItemID = {1}~\n"+
			"TaxID = {2}~\n"+
			"SeqNo = {3}~\n"+
			"IsSynch = {4}~\n"+
			"SynchOn = {5}~\n",
			ItemTaxID,			ItemID,			TaxID,			SeqNo,			IsSynch,			SynchOn);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ItemTaxKeys
	{

		#region Data Members

		Guid _itemTaxID;

		#endregion

		#region Constructor

		public ItemTaxKeys(Guid itemTaxID)
		{
			 _itemTaxID = itemTaxID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ItemTaxID
		{
			 get { return _itemTaxID; }
		}

		#endregion

	}
}
