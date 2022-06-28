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
	public class TaxSlabe: BusinessObjectBase
	{

		#region InnerClass
		public enum TaxSlabeFields
		{
			TaxSlabID,
			TaxID,
			TaxRate,
			IsTaxFlat,
			MinAmount,
			MaxAmount,
			TaxRateID,
			SlabSeqNo,
			PropertyID,
			CompanyID
		}
		#endregion

		#region Data Members

			Guid _taxSlabID;
			Guid? _taxID;
			decimal? _taxRate;
			bool? _isTaxFlat;
			decimal? _minAmount;
			decimal? _maxAmount;
			Guid? _taxRateID;
			int _slabSeqNo;
			Guid? _propertyID;
			Guid? _companyID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  TaxSlabID
		{
			 get { return _taxSlabID; }
			 set
			 {
				 if (_taxSlabID != value)
				 {
					_taxSlabID = value;
					 PropertyHasChanged("TaxSlabID");
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
		public decimal?  TaxRate
		{
			 get { return _taxRate; }
			 set
			 {
				 if (_taxRate != value)
				 {
					_taxRate = value;
					 PropertyHasChanged("TaxRate");
				 }
			 }
		}

		[DataMember]
		public bool?  IsTaxFlat
		{
			 get { return _isTaxFlat; }
			 set
			 {
				 if (_isTaxFlat != value)
				 {
					_isTaxFlat = value;
					 PropertyHasChanged("IsTaxFlat");
				 }
			 }
		}

		[DataMember]
		public decimal?  MinAmount
		{
			 get { return _minAmount; }
			 set
			 {
				 if (_minAmount != value)
				 {
					_minAmount = value;
					 PropertyHasChanged("MinAmount");
				 }
			 }
		}

		[DataMember]
		public decimal?  MaxAmount
		{
			 get { return _maxAmount; }
			 set
			 {
				 if (_maxAmount != value)
				 {
					_maxAmount = value;
					 PropertyHasChanged("MaxAmount");
				 }
			 }
		}

		[DataMember]
		public Guid?  TaxRateID
		{
			 get { return _taxRateID; }
			 set
			 {
				 if (_taxRateID != value)
				 {
					_taxRateID = value;
					 PropertyHasChanged("TaxRateID");
				 }
			 }
		}

		[DataMember]
		public int  SlabSeqNo
		{
			 get { return _slabSeqNo; }
			 set
			 {
				 if (_slabSeqNo != value)
				 {
					_slabSeqNo = value;
					 PropertyHasChanged("SlabSeqNo");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("TaxSlabID", "TaxSlabID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SlabSeqNo", "SlabSeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"TaxSlabID = {0}\n"+
			"TaxID = {1}\n"+
			"TaxRate = {2}\n"+
			"IsTaxFlat = {3}\n"+
			"MinAmount = {4}\n"+
			"MaxAmount = {5}\n"+
			"TaxRateID = {6}\n"+
			"SlabSeqNo = {7}\n"+
			"PropertyID = {8}\n"+
			"CompanyID = {9}\n",
			TaxSlabID,			TaxID,			TaxRate,			IsTaxFlat,			MinAmount,			MaxAmount,			TaxRateID,			SlabSeqNo,			PropertyID,			CompanyID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class TaxSlabeKeys
	{

		#region Data Members

		Guid _taxSlabID;

		#endregion

		#region Constructor

		public TaxSlabeKeys(Guid taxSlabID)
		{
			 _taxSlabID = taxSlabID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  TaxSlabID
		{
			 get { return _taxSlabID; }
		}

		#endregion

	}
}
