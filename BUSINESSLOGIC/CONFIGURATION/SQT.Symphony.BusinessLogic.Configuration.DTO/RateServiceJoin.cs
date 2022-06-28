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
	public class RateServiceJoin: BusinessObjectBase
	{

		#region InnerClass
		public enum RateServiceJoinFields
		{
			RateServiceID,
			RateID,
			ItemID,
			IsPerPerson,
			PostingFreq_TermID,
			DefaultServiceTime,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
            ItemName,
            PostingFrequencyName,
            ServiceRate,
            RateCardDetailID,
            RoomTypeID
		}
		#endregion

		#region Data Members

			Guid _rateServiceID;
			Guid? _rateID;
			Guid? _itemID;
			bool? _isPerPerson;
			Guid? _postingFreq_TermID;
			DateTime? _defaultServiceTime;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
            string _itemName;
            string _postingFrequencyName;
            decimal? _serviceRate;
            Guid? _rateCardDetailID;
            Guid? _roomTypeID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  RateServiceID
		{
			 get { return _rateServiceID; }
			 set
			 {
				 if (_rateServiceID != value)
				 {
					_rateServiceID = value;
					 PropertyHasChanged("RateServiceID");
				 }
			 }
		}

		[DataMember]
		public Guid?  RateID
		{
			 get { return _rateID; }
			 set
			 {
				 if (_rateID != value)
				 {
					_rateID = value;
					 PropertyHasChanged("RateID");
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
		public bool?  IsPerPerson
		{
			 get { return _isPerPerson; }
			 set
			 {
				 if (_isPerPerson != value)
				 {
					_isPerPerson = value;
					 PropertyHasChanged("IsPerPerson");
				 }
			 }
		}

		[DataMember]
		public Guid?  PostingFreq_TermID
		{
			 get { return _postingFreq_TermID; }
			 set
			 {
				 if (_postingFreq_TermID != value)
				 {
					_postingFreq_TermID = value;
					 PropertyHasChanged("PostingFreq_TermID");
				 }
			 }
		}

		[DataMember]
		public DateTime?  DefaultServiceTime
		{
			 get { return _defaultServiceTime; }
			 set
			 {
				 if (_defaultServiceTime != value)
				 {
					_defaultServiceTime = value;
					 PropertyHasChanged("DefaultServiceTime");
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

        [DataMember]
        public string ItemName
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
        public Decimal? ServiceRate
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
        public string PostingFrequencyName
        {
            get { return _postingFrequencyName; }
            set
            {
                if (_postingFrequencyName != value)
                {
                    _postingFrequencyName = value;
                    PropertyHasChanged("PostingFrequencyName");
                }
            }
        }

        [DataMember]
        public Guid? RateCardDetailID
        {
            get { return _rateCardDetailID; }
            set
            {
                if (_rateCardDetailID != value)
                {
                    _rateCardDetailID = value;
                    PropertyHasChanged("RateCardDetailID");
                }
            }
        }
        [DataMember]
        public Guid? RoomTypeID
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
		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("RateServiceID", "RateServiceID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"RateServiceID = {0}~\n"+
			"RateID = {1}~\n"+
			"ItemID = {2}~\n"+
			"IsPerPerson = {3}~\n"+
			"PostingFreq_TermID = {4}~\n"+
			"DefaultServiceTime = {5}~\n"+
			"SeqNo = {6}~\n"+
			"IsSynch = {7}~\n"+
			"SynchOn = {8}~\n"+
			"UpdatedOn = {9}~\n"+
			"UpdatedBy = {10}~\n"+
			"IsActive = {11}~\n"+
            "ItemName = {12}~\n" +
            "ServiceRate = {13}~\n" +
            "PostingFrequencyName = {14}~\n" +
            "RateCardDetailID = {15}~\n" +
            "RoomTypeID = {16}~\n",
            RateServiceID, RateID, ItemID, IsPerPerson, PostingFreq_TermID, DefaultServiceTime, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, ItemName, ServiceRate, PostingFrequencyName, RateCardDetailID, RoomTypeID); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class RateServiceJoinKeys
	{

		#region Data Members

		Guid _rateServiceID;

		#endregion

		#region Constructor

		public RateServiceJoinKeys(Guid rateServiceID)
		{
			 _rateServiceID = rateServiceID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  RateServiceID
		{
			 get { return _rateServiceID; }
		}

		#endregion

	}
}
