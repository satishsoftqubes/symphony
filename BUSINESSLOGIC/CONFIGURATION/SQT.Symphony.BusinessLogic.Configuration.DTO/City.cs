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
	public class City: BusinessObjectBase
	{

		#region InnerClass
		public enum CityFields
		{
			CityID,
			CityCode,
			CityName,
			CountryID,
			StateID,
			IsActive
		}
		#endregion

		#region Data Members

			Guid _cityID;
			string _cityCode;
			string _cityName;
			Guid? _countryID;
			Guid? _stateID;
			bool? _isActive;

		#endregion

		#region Properties

		[DataMember]
		public Guid  CityID
		{
			 get { return _cityID; }
			 set
			 {
				 if (_cityID != value)
				 {
					_cityID = value;
					 PropertyHasChanged("CityID");
				 }
			 }
		}

		[DataMember]
		public string  CityCode
		{
			 get { return _cityCode; }
			 set
			 {
				 if (_cityCode != value)
				 {
					_cityCode = value;
					 PropertyHasChanged("CityCode");
				 }
			 }
		}

		[DataMember]
		public string  CityName
		{
			 get { return _cityName; }
			 set
			 {
				 if (_cityName != value)
				 {
					_cityName = value;
					 PropertyHasChanged("CityName");
				 }
			 }
		}

		[DataMember]
		public Guid?  CountryID
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
		public Guid?  StateID
		{
			 get { return _stateID; }
			 set
			 {
				 if (_stateID != value)
				 {
					_stateID = value;
					 PropertyHasChanged("StateID");
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("CityID", "CityID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CityCode", "CityCode",50));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CityName", "CityName",120));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"CityID = {0}~\n"+
			"CityCode = {1}~\n"+
			"CityName = {2}~\n"+
			"CountryID = {3}~\n"+
			"StateID = {4}~\n"+
			"IsActive = {5}~\n",
			CityID,			CityCode,			CityName,			CountryID,			StateID,			IsActive);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class CityKeys
	{

		#region Data Members

		Guid _cityID;

		#endregion

		#region Constructor

		public CityKeys(Guid cityID)
		{
			 _cityID = cityID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  CityID
		{
			 get { return _cityID; }
		}

		#endregion

	}
}
