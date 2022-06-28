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
	public class ExchangeRate: BusinessObjectBase
	{

		#region InnerClass
		public enum ExchangeRateFields
		{
			ExchangeRateID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			SourceCurrencyID,
			DestinationCurrencyID,
			SourceRate,
			DestinationRate,
			MarginRateInPercentage
		}
		#endregion

		#region Data Members

			Guid _exchangeRateID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			Guid? _sourceCurrencyID;
			Guid? _destinationCurrencyID;
			decimal? _sourceRate;
			decimal? _destinationRate;
			decimal? _marginRateInPercentage;

		#endregion

		#region Properties

		[DataMember]
		public Guid  ExchangeRateID
		{
			 get { return _exchangeRateID; }
			 set
			 {
				 if (_exchangeRateID != value)
				 {
					_exchangeRateID = value;
					 PropertyHasChanged("ExchangeRateID");
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
		public Guid?  SourceCurrencyID
		{
			 get { return _sourceCurrencyID; }
			 set
			 {
				 if (_sourceCurrencyID != value)
				 {
					_sourceCurrencyID = value;
					 PropertyHasChanged("SourceCurrencyID");
				 }
			 }
		}

		[DataMember]
		public Guid?  DestinationCurrencyID
		{
			 get { return _destinationCurrencyID; }
			 set
			 {
				 if (_destinationCurrencyID != value)
				 {
					_destinationCurrencyID = value;
					 PropertyHasChanged("DestinationCurrencyID");
				 }
			 }
		}

		[DataMember]
		public decimal?  SourceRate
		{
			 get { return _sourceRate; }
			 set
			 {
				 if (_sourceRate != value)
				 {
					_sourceRate = value;
					 PropertyHasChanged("SourceRate");
				 }
			 }
		}

		[DataMember]
		public decimal?  DestinationRate
		{
			 get { return _destinationRate; }
			 set
			 {
				 if (_destinationRate != value)
				 {
					_destinationRate = value;
					 PropertyHasChanged("DestinationRate");
				 }
			 }
		}

		[DataMember]
		public decimal?  MarginRateInPercentage
		{
			 get { return _marginRateInPercentage; }
			 set
			 {
				 if (_marginRateInPercentage != value)
				 {
					_marginRateInPercentage = value;
					 PropertyHasChanged("MarginRateInPercentage");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ExchangeRateID", "ExchangeRateID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ExchangeRateID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"CompanyID = {2}~\n"+
			"SeqNo = {3}~\n"+
			"IsSynch = {4}~\n"+
			"SynchOn = {5}~\n"+
			"UpdatedOn = {6}~\n"+
			"UpdatedBy = {7}~\n"+
			"IsActive = {8}~\n"+
			"SourceCurrencyID = {9}~\n"+
			"DestinationCurrencyID = {10}~\n"+
			"SourceRate = {11}~\n"+
			"DestinationRate = {12}~\n"+
			"MarginRateInPercentage = {13}~\n",
			ExchangeRateID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			SourceCurrencyID,			DestinationCurrencyID,			SourceRate,			DestinationRate,			MarginRateInPercentage);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ExchangeRateKeys
	{

		#region Data Members

		Guid _exchangeRateID;

		#endregion

		#region Constructor

		public ExchangeRateKeys(Guid exchangeRateID)
		{
			 _exchangeRateID = exchangeRateID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ExchangeRateID
		{
			 get { return _exchangeRateID; }
		}

		#endregion

	}
}
