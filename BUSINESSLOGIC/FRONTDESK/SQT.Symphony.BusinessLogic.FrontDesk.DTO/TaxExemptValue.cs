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
	public class TaxExemptValue: BusinessObjectBase
	{

		#region InnerClass
		public enum TaxExemptValueFields
		{
			TaxExemptValueID,
			TaxExemptID,
			TransID,
			ExemptedAmt,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive
		}
		#endregion

		#region Data Members

			Guid _taxExemptValueID;
			Guid? _taxExemptID;
			Guid? _transID;
			decimal? _exemptedAmt;
			Guid? _propertyID;
			Guid? _companyID;
			long _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;

		#endregion

		#region Properties

		[DataMember]
		public Guid  TaxExemptValueID
		{
			 get { return _taxExemptValueID; }
			 set
			 {
				 if (_taxExemptValueID != value)
				 {
					_taxExemptValueID = value;
					 PropertyHasChanged("TaxExemptValueID");
				 }
			 }
		}

		[DataMember]
		public Guid?  TaxExemptID
		{
			 get { return _taxExemptID; }
			 set
			 {
				 if (_taxExemptID != value)
				 {
					_taxExemptID = value;
					 PropertyHasChanged("TaxExemptID");
				 }
			 }
		}

		[DataMember]
		public Guid?  TransID
		{
			 get { return _transID; }
			 set
			 {
				 if (_transID != value)
				 {
					_transID = value;
					 PropertyHasChanged("TransID");
				 }
			 }
		}

		[DataMember]
		public decimal?  ExemptedAmt
		{
			 get { return _exemptedAmt; }
			 set
			 {
				 if (_exemptedAmt != value)
				 {
					_exemptedAmt = value;
					 PropertyHasChanged("ExemptedAmt");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("TaxExemptValueID", "TaxExemptValueID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"TaxExemptValueID = {0}\n"+
			"TaxExemptID = {1}\n"+
			"TransID = {2}\n"+
			"ExemptedAmt = {3}\n"+
			"PropertyID = {4}\n"+
			"CompanyID = {5}\n"+
			"SeqNo = {6}\n"+
			"IsSynch = {7}\n"+
			"SynchOn = {8}\n"+
			"UpdatedOn = {9}\n"+
			"UpdatedBy = {10}\n"+
			"IsActive = {11}\n",
			TaxExemptValueID,			TaxExemptID,			TransID,			ExemptedAmt,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class TaxExemptValueKeys
	{

		#region Data Members

		Guid _taxExemptValueID;

		#endregion

		#region Constructor

		public TaxExemptValueKeys(Guid taxExemptValueID)
		{
			 _taxExemptValueID = taxExemptValueID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  TaxExemptValueID
		{
			 get { return _taxExemptValueID; }
		}

		#endregion

	}
}
