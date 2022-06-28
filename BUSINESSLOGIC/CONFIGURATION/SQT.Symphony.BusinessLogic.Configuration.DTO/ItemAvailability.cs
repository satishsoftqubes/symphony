
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
	public class ItemAvailability: BusinessObjectBase
	{

		#region InnerClass
		public enum ItemAvailabilityFields
		{
			ItemAvailabilityID,
			ItemID,
			Location_TermID,
			POSPointID,
			QtyOnHand,
			SeqNo,
			IsSynch,
			SynchOn,
			ServiceRate,
			MarkUpRate,
			IsMarkUpFlat,
            CategoryID
		}
		#endregion

		#region Data Members

			Guid _itemAvailabilityID;
			Guid? _itemID;
			Guid? _location_TermID;
			Guid? _pOSPointID;
			decimal? _qtyOnHand;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			decimal? _serviceRate;
			decimal? _markUpRate;
			bool? _isMarkUpFlat;
            Guid? _categoryID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  ItemAvailabilityID
		{
			 get { return _itemAvailabilityID; }
			 set
			 {
				 if (_itemAvailabilityID != value)
				 {
					_itemAvailabilityID = value;
					 PropertyHasChanged("ItemAvailabilityID");
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
		public Guid?  Location_TermID
		{
			 get { return _location_TermID; }
			 set
			 {
				 if (_location_TermID != value)
				 {
					_location_TermID = value;
					 PropertyHasChanged("Location_TermID");
				 }
			 }
		}

		[DataMember]
		public Guid?  POSPointID
		{
			 get { return _pOSPointID; }
			 set
			 {
				 if (_pOSPointID != value)
				 {
					_pOSPointID = value;
					 PropertyHasChanged("POSPointID");
				 }
			 }
		}

		[DataMember]
		public decimal?  QtyOnHand
		{
			 get { return _qtyOnHand; }
			 set
			 {
				 if (_qtyOnHand != value)
				 {
					_qtyOnHand = value;
					 PropertyHasChanged("QtyOnHand");
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
		public decimal?  ServiceRate
		{
			 get { return _serviceRate; }
			 set
			 {
				 if (_serviceRate != value)
				 {
					_serviceRate = value;
					 PropertyHasChanged("ServiceRate");
				 }
			 }
		}

		[DataMember]
		public decimal?  MarkUpRate
		{
			 get { return _markUpRate; }
			 set
			 {
				 if (_markUpRate != value)
				 {
					_markUpRate = value;
					 PropertyHasChanged("MarkUpRate");
				 }
			 }
		}

		[DataMember]
		public bool?  IsMarkUpFlat
		{
			 get { return _isMarkUpFlat; }
			 set
			 {
				 if (_isMarkUpFlat != value)
				 {
					_isMarkUpFlat = value;
					 PropertyHasChanged("IsMarkUpFlat");
				 }
			 }
		}
        
        [DataMember]
        public Guid? CategoryID
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
		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ItemAvailabilityID", "ItemAvailabilityID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ItemAvailabilityID = {0}~\n"+
			"ItemID = {1}~\n"+
			"Location_TermID = {2}~\n"+
			"POSPointID = {3}~\n"+
			"QtyOnHand = {4}~\n"+
			"SeqNo = {5}~\n"+
			"IsSynch = {6}~\n"+
			"SynchOn = {7}~\n"+
			"ServiceRate = {8}~\n"+
			"MarkUpRate = {9}~\n"+
            "IsMarkUpFlat = {10}~\n" +
            "CategoryID = {11}~\n",
            ItemAvailabilityID, ItemID, Location_TermID, POSPointID, QtyOnHand, SeqNo, IsSynch, SynchOn, ServiceRate, MarkUpRate, IsMarkUpFlat, CategoryID); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ItemAvailabilityKeys
	{

		#region Data Members

		Guid _itemAvailabilityID;

		#endregion

		#region Constructor

		public ItemAvailabilityKeys(Guid itemAvailabilityID)
		{
			 _itemAvailabilityID = itemAvailabilityID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ItemAvailabilityID
		{
			 get { return _itemAvailabilityID; }
		}

		#endregion

	}
}
