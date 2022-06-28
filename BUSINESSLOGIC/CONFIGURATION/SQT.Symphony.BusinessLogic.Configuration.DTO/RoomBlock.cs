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
	public class RoomBlock: BusinessObjectBase
	{


		#region InnerClass
		public enum RoomBlockFields
		{
			BlockRoomID,
			StartDate,
			EndDate,
			BlockBy,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			DateOfBlock,
			BlockReason,
			CauseOfBlock_TermID,
            RoomTypeID,
            BlockForTermID
		}
		#endregion

		#region Data Members

			Guid _blockRoomID;
			DateTime? _startDate;
			DateTime? _endDate;
			string _blockBy;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			DateTime? _dateOfBlock;
			string _blockReason;
			Guid? _causeOfBlock_TermID;
            Guid? _roomTypeID;
            Guid? _blockForTermID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  BlockRoomID
		{
			 get { return _blockRoomID; }
			 set
			 {
				 if (_blockRoomID != value)
				 {
					_blockRoomID = value;
					 PropertyHasChanged("BlockRoomID");
				 }
			 }
		}

		[DataMember]
		public DateTime?  StartDate
		{
			 get { return _startDate; }
			 set
			 {
				 if (_startDate != value)
				 {
					_startDate = value;
					 PropertyHasChanged("StartDate");
				 }
			 }
		}

		[DataMember]
		public DateTime?  EndDate
		{
			 get { return _endDate; }
			 set
			 {
				 if (_endDate != value)
				 {
					_endDate = value;
					 PropertyHasChanged("EndDate");
				 }
			 }
		}

		[DataMember]
		public string  BlockBy
		{
			 get { return _blockBy; }
			 set
			 {
				 if (_blockBy != value)
				 {
					_blockBy = value;
					 PropertyHasChanged("BlockBy");
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
		public DateTime?  DateOfBlock
		{
			 get { return _dateOfBlock; }
			 set
			 {
				 if (_dateOfBlock != value)
				 {
					_dateOfBlock = value;
					 PropertyHasChanged("DateOfBlock");
				 }
			 }
		}

		[DataMember]
		public string  BlockReason
		{
			 get { return _blockReason; }
			 set
			 {
				 if (_blockReason != value)
				 {
					_blockReason = value;
					 PropertyHasChanged("BlockReason");
				 }
			 }
		}

		[DataMember]
		public Guid?  CauseOfBlock_TermID
		{
			 get { return _causeOfBlock_TermID; }
			 set
			 {
				 if (_causeOfBlock_TermID != value)
				 {
					_causeOfBlock_TermID = value;
					 PropertyHasChanged("CauseOfBlock_TermID");
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

        [DataMember]
        public Guid? BlockForTermID
        {
            get { return _blockForTermID; }
            set
            {
                if (_blockForTermID != value)
                {
                    _blockForTermID = value;
                    PropertyHasChanged("BlockForTermID");
                }
            }
        }

		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("BlockRoomID", "BlockRoomID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("BlockBy", "BlockBy",180));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("BlockReason", "BlockReason",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"BlockRoomID = {0}~\n"+
			"StartDate = {1}~\n"+
			"EndDate = {2}~\n"+
			"BlockBy = {3}~\n"+
			"PropertyID = {4}~\n"+
			"CompanyID = {5}~\n"+
			"SeqNo = {6}~\n"+
			"IsSynch = {7}~\n"+
			"SynchOn = {8}~\n"+
			"UpdatedOn = {9}~\n"+
			"UpdatedBy = {10}~\n"+
			"IsActive = {11}~\n"+
			"DateOfBlock = {12}~\n"+
			"BlockReason = {13}~\n"+
            "CauseOfBlock_TermID = {14}~\n" +
            "RoomTypeID = {15}~\n" +
            "BlockForTermID = {16}~\n",
            BlockRoomID, StartDate, EndDate, BlockBy, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, DateOfBlock, BlockReason, CauseOfBlock_TermID, RoomTypeID, BlockForTermID); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class RoomBlockKeys
	{

		#region Data Members

		Guid _blockRoomID;

		#endregion

		#region Constructor

		public RoomBlockKeys(Guid blockRoomID)
		{
			 _blockRoomID = blockRoomID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  BlockRoomID
		{
			 get { return _blockRoomID; }
		}

		#endregion

	}
}
