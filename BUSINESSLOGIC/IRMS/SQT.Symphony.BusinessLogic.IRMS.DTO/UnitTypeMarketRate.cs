using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;
namespace SQT.Symphony.BusinessLogic.IRMS.DTO
{
	[DataContract]
	public class UnitTypeMarketRate: BusinessObjectBase
	{

		#region InnerClass
		public enum UnitTypeMarketRateFields
		{
			MarketRateID,
			PropertyID,
			CompanyID,
			UnitTypeID,
			Rate,
			DateOfRate,
			IsActive,
			CreatedBy,
			CreatedOn,
			UpdatedBy,
			UpdatedOn,
			SeqNo,
			UpdateLog,
			SynchOn,
			IsSynch
		}
		#endregion

		#region Data Members

			Guid _marketRateID;
			Guid? _propertyID;
			Guid? _companyID;
			Guid? _unitTypeID;
			decimal? _rate;
			DateTime? _dateOfRate;
			bool? _isActive;
			Guid? _createdBy;
			DateTime? _createdOn;
			Guid? _updatedBy;
			DateTime? _updatedOn;
			int _seqNo;
			byte[] _updateLog;
			DateTime? _synchOn;
			bool? _isSynch;

		#endregion

		#region Properties

		[DataMember]
		public Guid  MarketRateID
		{
			 get { return _marketRateID; }
			 set
			 {
				 if (_marketRateID != value)
				 {
					_marketRateID = value;
					 PropertyHasChanged("MarketRateID");
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
		public Guid?  UnitTypeID
		{
			 get { return _unitTypeID; }
			 set
			 {
				 if (_unitTypeID != value)
				 {
					_unitTypeID = value;
					 PropertyHasChanged("UnitTypeID");
				 }
			 }
		}

		[DataMember]
		public decimal?  Rate
		{
			 get { return _rate; }
			 set
			 {
				 if (_rate != value)
				 {
					_rate = value;
					 PropertyHasChanged("Rate");
				 }
			 }
		}

		[DataMember]
		public DateTime?  DateOfRate
		{
			 get { return _dateOfRate; }
			 set
			 {
				 if (_dateOfRate != value)
				 {
					_dateOfRate = value;
					 PropertyHasChanged("DateOfRate");
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
		public Guid?  CreatedBy
		{
			 get { return _createdBy; }
			 set
			 {
				 if (_createdBy != value)
				 {
					_createdBy = value;
					 PropertyHasChanged("CreatedBy");
				 }
			 }
		}

		[DataMember]
		public DateTime?  CreatedOn
		{
			 get { return _createdOn; }
			 set
			 {
				 if (_createdOn != value)
				 {
					_createdOn = value;
					 PropertyHasChanged("CreatedOn");
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
		public byte[]  UpdateLog
		{
			 get { return _updateLog; }
			 set
			 {
				 if (_updateLog != value)
				 {
					_updateLog = value;
					 PropertyHasChanged("UpdateLog");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("MarketRateID", "MarketRateID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"MarketRateID = {0}\n"+
			"PropertyID = {1}\n"+
			"CompanyID = {2}\n"+
			"UnitTypeID = {3}\n"+
			"Rate = {4}\n"+
			"DateOfRate = {5}\n"+
			"IsActive = {6}\n"+
			"CreatedBy = {7}\n"+
			"CreatedOn = {8}\n"+
			"UpdatedBy = {9}\n"+
			"UpdatedOn = {10}\n"+
			"SeqNo = {11}\n"+
			"UpdateLog = {12}\n"+
			"SynchOn = {13}\n"+
			"IsSynch = {14}\n",
			MarketRateID,			PropertyID,			CompanyID,			UnitTypeID,			Rate,			DateOfRate,			IsActive,			CreatedBy,			CreatedOn,			UpdatedBy,			UpdatedOn,			SeqNo,			UpdateLog,			SynchOn,			IsSynch);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class UnitTypeMarketRateKeys
	{

		#region Data Members

		Guid _marketRateID;

		#endregion

		#region Constructor

		public UnitTypeMarketRateKeys(Guid marketRateID)
		{
			 _marketRateID = marketRateID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  MarketRateID
		{
			 get { return _marketRateID; }
		}

		#endregion

	}
}
