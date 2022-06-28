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
	public class State: BusinessObjectBase
	{

		#region InnerClass
		public enum StateFields
		{
			StateID,
			StateCode,
			StateName,
			CountryID,
			IsActive,
			CompanyID
		}
		#endregion

		#region Data Members

			Guid _stateID;
			string _stateCode;
			string _stateName;
			Guid? _countryID;
			bool? _isActive;
			Guid? _companyID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  StateID
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
		public string  StateCode
		{
			 get { return _stateCode; }
			 set
			 {
				 if (_stateCode != value)
				 {
					_stateCode = value;
					 PropertyHasChanged("StateCode");
				 }
			 }
		}

		[DataMember]
		public string  StateName
		{
			 get { return _stateName; }
			 set
			 {
				 if (_stateName != value)
				 {
					_stateName = value;
					 PropertyHasChanged("StateName");
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("StateID", "StateID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("StateCode", "StateCode",5));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("StateName", "StateName",120));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
            "StateID = {0}~\n" +
            "StateCode = {1}~\n" +
            "StateName = {2}~\n" +
            "CountryID = {3}~\n" +
            "IsActive = {4}~\n" +
            "CompanyID = {5}~\n",
			StateID,			StateCode,			StateName,			CountryID,			IsActive,			CompanyID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class StateKeys
	{

		#region Data Members

		Guid _stateID;

		#endregion

		#region Constructor

		public StateKeys(Guid stateID)
		{
			 _stateID = stateID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  StateID
		{
			 get { return _stateID; }
		}

		#endregion

	}
}
