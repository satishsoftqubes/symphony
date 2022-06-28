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
	public class ResAddOnServiceList: BusinessObjectBase
	{

		#region InnerClass
		public enum ResAddOnServiceListFields
		{
			ResAddOnServiceID,
			ReservationID,
			GuestID,
			ItemID,
			FolioID,
			StatusRemark,
			Amount,
			Qty,
			Total,
			ServiceDate,
			StartDate,
			ExpiryDate,
			BookID,
			Notes,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			ServiceStatus_Term,
            IsDelete
		}
		#endregion

		#region Data Members

			Guid _resAddOnServiceID;
			Guid? _reservationID;
			Guid? _guestID;
			Guid? _itemID;
			Guid? _folioID;
			string _statusRemark;
			decimal? _amount;
			decimal? _qty;
			decimal? _total;
			DateTime? _serviceDate;
			DateTime? _startDate;
			DateTime? _expiryDate;
			Guid? _bookID;
			string _notes;
			Guid? _propertyID;
			Guid? _companyID;
			long _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			string _serviceStatus_Term;
            bool? _IsDelete;

		#endregion

		#region Properties

		[DataMember]
		public Guid  ResAddOnServiceID
		{
			 get { return _resAddOnServiceID; }
			 set
			 {
				 if (_resAddOnServiceID != value)
				 {
					_resAddOnServiceID = value;
					 PropertyHasChanged("ResAddOnServiceID");
				 }
			 }
		}

		[DataMember]
		public Guid?  ReservationID
		{
			 get { return _reservationID; }
			 set
			 {
				 if (_reservationID != value)
				 {
					_reservationID = value;
					 PropertyHasChanged("ReservationID");
				 }
			 }
		}

		[DataMember]
		public Guid?  GuestID
		{
			 get { return _guestID; }
			 set
			 {
				 if (_guestID != value)
				 {
					_guestID = value;
					 PropertyHasChanged("GuestID");
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
		public Guid?  FolioID
		{
			 get { return _folioID; }
			 set
			 {
				 if (_folioID != value)
				 {
					_folioID = value;
					 PropertyHasChanged("FolioID");
				 }
			 }
		}

		[DataMember]
		public string  StatusRemark
		{
			 get { return _statusRemark; }
			 set
			 {
				 if (_statusRemark != value)
				 {
					_statusRemark = value;
					 PropertyHasChanged("StatusRemark");
				 }
			 }
		}

		[DataMember]
		public decimal?  Amount
		{
			 get { return _amount; }
			 set
			 {
				 if (_amount != value)
				 {
					_amount = value;
					 PropertyHasChanged("Amount");
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
		public decimal?  Total
		{
			 get { return _total; }
			 set
			 {
				 if (_total != value)
				 {
					_total = value;
					 PropertyHasChanged("Total");
				 }
			 }
		}

		[DataMember]
		public DateTime?  ServiceDate
		{
			 get { return _serviceDate; }
			 set
			 {
				 if (_serviceDate != value)
				 {
					_serviceDate = value;
					 PropertyHasChanged("ServiceDate");
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
		public DateTime?  ExpiryDate
		{
			 get { return _expiryDate; }
			 set
			 {
				 if (_expiryDate != value)
				 {
					_expiryDate = value;
					 PropertyHasChanged("ExpiryDate");
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
		public string  Notes
		{
			 get { return _notes; }
			 set
			 {
				 if (_notes != value)
				 {
					_notes = value;
					 PropertyHasChanged("Notes");
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

		[DataMember]
		public string  ServiceStatus_Term
		{
			 get { return _serviceStatus_Term; }
			 set
			 {
				 if (_serviceStatus_Term != value)
				 {
					_serviceStatus_Term = value;
					 PropertyHasChanged("ServiceStatus_Term");
				 }
			 }
		}

        [DataMember]
        public bool? IsDelete
        {
            get { return _IsDelete; }
            set
            {
                if (_IsDelete != value)
                {
                    _IsDelete = value;
                    PropertyHasChanged("IsDelete");
                }
            }
        }

		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ResAddOnServiceID", "ResAddOnServiceID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("StatusRemark", "StatusRemark",165));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Notes", "Notes",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ServiceStatus_Term", "ServiceStatus_Term",65));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ResAddOnServiceID = {0}\n"+
			"ReservationID = {1}\n"+
			"GuestID = {2}\n"+
			"ItemID = {3}\n"+
			"FolioID = {4}\n"+
			"StatusRemark = {5}\n"+
			"Amount = {6}\n"+
			"Qty = {7}\n"+
			"Total = {8}\n"+
			"ServiceDate = {9}\n"+
			"StartDate = {10}\n"+
			"ExpiryDate = {11}\n"+
			"BookID = {12}\n"+
			"Notes = {13}\n"+
			"PropertyID = {14}\n"+
			"CompanyID = {15}\n"+
			"SeqNo = {16}\n"+
			"IsSynch = {17}\n"+
			"SynchOn = {18}\n"+
			"UpdatedOn = {19}\n"+
			"UpdatedBy = {20}\n"+
			"IsActive = {21}\n"+
			"ServiceStatus_Term = {22}\n"+
            "IsDelete = {23}",
			ResAddOnServiceID,			ReservationID,			GuestID,			ItemID,			FolioID,			StatusRemark,			Amount,			Qty,			Total,			ServiceDate,			StartDate,			ExpiryDate,			BookID,			Notes,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			ServiceStatus_Term, IsDelete);			return objValue;
		}

		#endregion

	}

	[DataContract]
	public class ResAddOnServiceListKeys
	{

		#region Data Members

		Guid _resAddOnServiceID;

		#endregion

		#region Constructor

		public ResAddOnServiceListKeys(Guid resAddOnServiceID)
		{
			 _resAddOnServiceID = resAddOnServiceID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ResAddOnServiceID
		{
			 get { return _resAddOnServiceID; }
		}

		#endregion

	}
}
