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
	public class Country: BusinessObjectBase
	{

		#region InnerClass
		public enum CountryFields
		{
			CountryID,
			CountryCode,
			CountryName,
			IsActive,
			CompanyID
		}
		#endregion

		#region Data Members

			Guid _countryID;
			string _countryCode;
			string _countryName;
			bool? _isActive;
			Guid? _companyID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  CountryID
		{
			 get { return _countryID; }
			 set
			 {
				 if (_countryID != value)
				 {
					_countryID = value;
					 PropertyHasChanged("CountryID");
				 }
			 }
		}

		[DataMember]
		public string  CountryCode
		{
			 get { return _countryCode; }
			 set
			 {
				 if (_countryCode != value)
				 {
					_countryCode = value;
					 PropertyHasChanged("CountryCode");
				 }
			 }
		}

		[DataMember]
		public string  CountryName
		{
			 get { return _countryName; }
			 set
			 {
				 if (_countryName != value)
				 {
					_countryName = value;
					 PropertyHasChanged("CountryName");
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("CountryID", "CountryID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CountryCode", "CountryCode",5));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CountryName", "CountryName",120));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"CountryID = {0}~\n"+
			"CountryCode = {1}~\n"+
			"CountryName = {2}~\n"+
			"IsActive = {3}~\n"+
			"CompanyID = {4}~\n",
			CountryID,			CountryCode,			CountryName,			IsActive,			CompanyID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class CountryKeys
	{

		#region Data Members

		Guid _countryID;

		#endregion

		#region Constructor

		public CountryKeys(Guid countryID)
		{
			 _countryID = countryID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  CountryID
		{
			 get { return _countryID; }
		}

		#endregion

	}
}
