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
	public class POSConfig: BusinessObjectBase
	{

		#region InnerClass
		public enum POSConfigFields
		{
			POSConfigID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			IsShowFastSalesItemFirst,
			IsStockInHandAdjustable,
			IsNonStockItemSold,
			IsBarCodeEnable,
			IsItemCodeAutoGenerated,
			IsAlphaNumeric,
			FirstCharLength,
			StockUpdateType_TermID
		}
		#endregion

		#region Data Members

			Guid _pOSConfigID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			bool? _isShowFastSalesItemFirst;
			bool? _isStockInHandAdjustable;
			bool? _isNonStockItemSold;
			bool? _isBarCodeEnable;
			bool? _isItemCodeAutoGenerated;
			bool? _isAlphaNumeric;
			int? _firstCharLength;
			Guid? _stockUpdateType_TermID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  POSConfigID
		{
			 get { return _pOSConfigID; }
			 set
			 {
				 if (_pOSConfigID != value)
				 {
					_pOSConfigID = value;
					 PropertyHasChanged("POSConfigID");
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
		public bool?  IsShowFastSalesItemFirst
		{
			 get { return _isShowFastSalesItemFirst; }
			 set
			 {
				 if (_isShowFastSalesItemFirst != value)
				 {
					_isShowFastSalesItemFirst = value;
					 PropertyHasChanged("IsShowFastSalesItemFirst");
				 }
			 }
		}

		[DataMember]
		public bool?  IsStockInHandAdjustable
		{
			 get { return _isStockInHandAdjustable; }
			 set
			 {
				 if (_isStockInHandAdjustable != value)
				 {
					_isStockInHandAdjustable = value;
					 PropertyHasChanged("IsStockInHandAdjustable");
				 }
			 }
		}

		[DataMember]
		public bool?  IsNonStockItemSold
		{
			 get { return _isNonStockItemSold; }
			 set
			 {
				 if (_isNonStockItemSold != value)
				 {
					_isNonStockItemSold = value;
					 PropertyHasChanged("IsNonStockItemSold");
				 }
			 }
		}

		[DataMember]
		public bool?  IsBarCodeEnable
		{
			 get { return _isBarCodeEnable; }
			 set
			 {
				 if (_isBarCodeEnable != value)
				 {
					_isBarCodeEnable = value;
					 PropertyHasChanged("IsBarCodeEnable");
				 }
			 }
		}

		[DataMember]
		public bool?  IsItemCodeAutoGenerated
		{
			 get { return _isItemCodeAutoGenerated; }
			 set
			 {
				 if (_isItemCodeAutoGenerated != value)
				 {
					_isItemCodeAutoGenerated = value;
					 PropertyHasChanged("IsItemCodeAutoGenerated");
				 }
			 }
		}

		[DataMember]
		public bool?  IsAlphaNumeric
		{
			 get { return _isAlphaNumeric; }
			 set
			 {
				 if (_isAlphaNumeric != value)
				 {
					_isAlphaNumeric = value;
					 PropertyHasChanged("IsAlphaNumeric");
				 }
			 }
		}

		[DataMember]
		public int?  FirstCharLength
		{
			 get { return _firstCharLength; }
			 set
			 {
				 if (_firstCharLength != value)
				 {
					_firstCharLength = value;
					 PropertyHasChanged("FirstCharLength");
				 }
			 }
		}

		[DataMember]
		public Guid?  StockUpdateType_TermID
		{
			 get { return _stockUpdateType_TermID; }
			 set
			 {
				 if (_stockUpdateType_TermID != value)
				 {
					_stockUpdateType_TermID = value;
					 PropertyHasChanged("StockUpdateType_TermID");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("POSConfigID", "POSConfigID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"POSConfigID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"CompanyID = {2}~\n"+
			"SeqNo = {3}~\n"+
			"IsSynch = {4}~\n"+
			"SynchOn = {5}~\n"+
			"UpdatedOn = {6}~\n"+
			"UpdatedBy = {7}~\n"+
			"IsActive = {8}~\n"+
			"IsShowFastSalesItemFirst = {9}~\n"+
			"IsStockInHandAdjustable = {10}~\n"+
			"IsNonStockItemSold = {11}~\n"+
			"IsBarCodeEnable = {12}~\n"+
			"IsItemCodeAutoGenerated = {13}~\n"+
			"IsAlphaNumeric = {14}~\n"+
			"FirstCharLength = {15}~\n"+
			"StockUpdateType_TermID = {16}~\n",
			POSConfigID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			IsShowFastSalesItemFirst,			IsStockInHandAdjustable,			IsNonStockItemSold,			IsBarCodeEnable,			IsItemCodeAutoGenerated,			IsAlphaNumeric,			FirstCharLength,			StockUpdateType_TermID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class POSConfigKeys
	{

		#region Data Members

		Guid _pOSConfigID;

		#endregion

		#region Constructor

		public POSConfigKeys(Guid pOSConfigID)
		{
			 _pOSConfigID = pOSConfigID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  POSConfigID
		{
			 get { return _pOSConfigID; }
		}

		#endregion

	}
}
