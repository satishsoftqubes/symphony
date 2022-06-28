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
	public class Currency: BusinessObjectBase
	{

		#region InnerClass
		public enum CurrencyFields
		{
			CurrencyID,
			Name,
			CurrencyCode,
			DisplayLocale,
			Rate,
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

			Guid _currencyID;
			string _name;
			string _currencyCode;
			string _displayLocale;
			decimal? _rate;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;

		#endregion

		#region Properties

		[DataMember]
		public Guid  CurrencyID
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
		public string  Name
		{
			 get { return _name; }
			 set
			 {
				 if (_name != value)
				 {
					_name = value;
					 PropertyHasChanged("Name");
				 }
			 }
		}

		[DataMember]
		public string  CurrencyCode
		{
			 get { return _currencyCode; }
			 set
			 {
				 if (_currencyCode != value)
				 {
					_currencyCode = value;
					 PropertyHasChanged("CurrencyCode");
				 }
			 }
		}

		[DataMember]
		public string  DisplayLocale
		{
			 get { return _displayLocale; }
			 set
			 {
				 if (_displayLocale != value)
				 {
					_displayLocale = value;
					 PropertyHasChanged("DisplayLocale");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("CurrencyID", "CurrencyID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Name", "Name",35));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CurrencyCode", "CurrencyCode",5));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("DisplayLocale", "DisplayLocale",10));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"CurrencyID = {0}~\n"+
			"Name = {1}~\n"+
			"CurrencyCode = {2}~\n"+
			"DisplayLocale = {3}~\n"+
			"Rate = {4}~\n"+
			"PropertyID = {5}~\n"+
			"CompanyID = {6}~\n"+
			"SeqNo = {7}~\n"+
			"IsSynch = {8}~\n"+
			"SynchOn = {9}~\n"+
			"UpdatedOn = {10}~\n"+
			"UpdatedBy = {11}~\n"+
			"IsActive = {12}~\n",
			CurrencyID,			Name,			CurrencyCode,			DisplayLocale,			Rate,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class CurrencyKeys
	{

		#region Data Members

		Guid _currencyID;

		#endregion

		#region Constructor

		public CurrencyKeys(Guid currencyID)
		{
			 _currencyID = currencyID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  CurrencyID
		{
			 get { return _currencyID; }
		}

		#endregion

	}
}
