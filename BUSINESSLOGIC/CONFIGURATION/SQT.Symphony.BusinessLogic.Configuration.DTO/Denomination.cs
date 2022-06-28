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
	public class Denomination: BusinessObjectBase
	{

		#region InnerClass
		public enum DenominationFields
		{
			CurDenominationID,
			CurrencyID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			CurrencyType_TermID,
			DenominationName,
			DenominationValue
		}
		#endregion

		#region Data Members

			Guid _curDenominationID;
			Guid? _currencyID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			Guid? _currencyType_TermID;
			string _denominationName;
			decimal? _denominationValue;

		#endregion

		#region Properties

		[DataMember]
		public Guid  CurDenominationID
		{
			 get { return _curDenominationID; }
			 set
			 {
				 if (_curDenominationID != value)
				 {
					_curDenominationID = value;
					 PropertyHasChanged("CurDenominationID");
				 }
			 }
		}

		[DataMember]
		public Guid?  CurrencyID
		{
			 get { return _currencyID; }
			 set
			 {
				 if (_currencyID != value)
				 {
					_currencyID = value;
					 PropertyHasChanged("CurrencyID");
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
		public Guid?  CurrencyType_TermID
		{
			 get { return _currencyType_TermID; }
			 set
			 {
				 if (_currencyType_TermID != value)
				 {
					_currencyType_TermID = value;
					 PropertyHasChanged("CurrencyType_TermID");
				 }
			 }
		}

		[DataMember]
		public string  DenominationName
		{
			 get { return _denominationName; }
			 set
			 {
				 if (_denominationName != value)
				 {
					_denominationName = value;
					 PropertyHasChanged("DenominationName");
				 }
			 }
		}

		[DataMember]
		public decimal?  DenominationValue
		{
			 get { return _denominationValue; }
			 set
			 {
				 if (_denominationValue != value)
				 {
					_denominationValue = value;
					 PropertyHasChanged("DenominationValue");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("CurDenominationID", "CurDenominationID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("DenominationName", "DenominationName",10));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"CurDenominationID = {0}~\n"+
			"CurrencyID = {1}~\n"+
			"PropertyID = {2}~\n"+
			"CompanyID = {3}~\n"+
			"SeqNo = {4}~\n"+
			"IsSynch = {5}~\n"+
			"SynchOn = {6}~\n"+
			"UpdatedOn = {7}~\n"+
			"UpdatedBy = {8}~\n"+
			"IsActive = {9}~\n"+
			"CurrencyType_TermID = {10}~\n"+
			"DenominationName = {11}~\n"+
			"DenominationValue = {12}~\n",
			CurDenominationID,			CurrencyID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			CurrencyType_TermID,			DenominationName,			DenominationValue);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class DenominationKeys
	{

		#region Data Members

		Guid _curDenominationID;

		#endregion

		#region Constructor

		public DenominationKeys(Guid curDenominationID)
		{
			 _curDenominationID = curDenominationID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  CurDenominationID
		{
			 get { return _curDenominationID; }
		}

		#endregion

	}
}
