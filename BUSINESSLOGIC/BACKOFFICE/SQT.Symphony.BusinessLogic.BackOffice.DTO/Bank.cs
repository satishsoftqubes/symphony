using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;
namespace SQT.Symphony.BusinessLogic.BackOffice.DTO
{
	[DataContract]
	public class Bank: BusinessObjectBase
	{

		#region InnerClass
		public enum BankFields
		{
			BankID,
			BankName,
			ContactName,
			ContactNO,
			Address,
			Address1,
			City,
			StateID,
			CountyID,
			PostCode,
			AccountNo,
			SortCode,
			AcctID,
			Balance,
			Active,
			UserID
		}
		#endregion

		#region Data Members

			Guid _bankID;
			string _bankName;
			string _contactName;
			string _contactNO;
			string _address;
			string _address1;
			Guid? _city;
			Guid? _stateID;
			Guid? _countyID;
			string _postCode;
			string _accountNo;
			string _sortCode;
			Guid _acctID;
			decimal _balance;
			bool? _active;
			Guid _userID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  BankID
		{
			 get { return _bankID; }
			 set
			 {
				 if (_bankID != value)
				 {
					_bankID = value;
					 PropertyHasChanged("BankID");
				 }
			 }
		}

		[DataMember]
		public string  BankName
		{
			 get { return _bankName; }
			 set
			 {
				 if (_bankName != value)
				 {
					_bankName = value;
					 PropertyHasChanged("BankName");
				 }
			 }
		}

		[DataMember]
		public string  ContactName
		{
			 get { return _contactName; }
			 set
			 {
				 if (_contactName != value)
				 {
					_contactName = value;
					 PropertyHasChanged("ContactName");
				 }
			 }
		}

		[DataMember]
		public string  ContactNO
		{
			 get { return _contactNO; }
			 set
			 {
				 if (_contactNO != value)
				 {
					_contactNO = value;
					 PropertyHasChanged("ContactNO");
				 }
			 }
		}

		[DataMember]
		public string  Address
		{
			 get { return _address; }
			 set
			 {
				 if (_address != value)
				 {
					_address = value;
					 PropertyHasChanged("Address");
				 }
			 }
		}

		[DataMember]
		public string  Address1
		{
			 get { return _address1; }
			 set
			 {
				 if (_address1 != value)
				 {
					_address1 = value;
					 PropertyHasChanged("Address1");
				 }
			 }
		}

		[DataMember]
		public Guid?  City
		{
			 get { return _city; }
			 set
			 {
				 if (_city != value)
				 {
					_city = value;
					 PropertyHasChanged("City");
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
		public Guid?  CountyID
		{
			 get { return _countyID; }
			 set
			 {
				 if (_countyID != value)
				 {
					_countyID = value;
					 PropertyHasChanged("CountyID");
				 }
			 }
		}

		[DataMember]
		public string  PostCode
		{
			 get { return _postCode; }
			 set
			 {
				 if (_postCode != value)
				 {
					_postCode = value;
					 PropertyHasChanged("PostCode");
				 }
			 }
		}

		[DataMember]
		public string  AccountNo
		{
			 get { return _accountNo; }
			 set
			 {
				 if (_accountNo != value)
				 {
					_accountNo = value;
					 PropertyHasChanged("AccountNo");
				 }
			 }
		}

		[DataMember]
		public string  SortCode
		{
			 get { return _sortCode; }
			 set
			 {
				 if (_sortCode != value)
				 {
					_sortCode = value;
					 PropertyHasChanged("SortCode");
				 }
			 }
		}

		[DataMember]
		public Guid  AcctID
		{
			 get { return _acctID; }
			 set
			 {
				 if (_acctID != value)
				 {
					_acctID = value;
					 PropertyHasChanged("AcctID");
				 }
			 }
		}

		[DataMember]
		public decimal  Balance
		{
			 get { return _balance; }
			 set
			 {
				 if (_balance != value)
				 {
					_balance = value;
					 PropertyHasChanged("Balance");
				 }
			 }
		}

		[DataMember]
		public bool?  Active
		{
			 get { return _active; }
			 set
			 {
				 if (_active != value)
				 {
					_active = value;
					 PropertyHasChanged("Active");
				 }
			 }
		}

		[DataMember]
		public Guid  UserID
		{
			 get { return _userID; }
			 set
			 {
				 if (_userID != value)
				 {
					_userID = value;
					 PropertyHasChanged("UserID");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("BankID", "BankID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("BankName", "BankName"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("BankName", "BankName",150));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ContactName", "ContactName",150));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ContactNO", "ContactNO",35));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Address", "Address",200));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Address1", "Address1",200));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PostCode", "PostCode",13));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("AccountNo", "AccountNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("AccountNo", "AccountNo",45));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SortCode", "SortCode"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("SortCode", "SortCode",45));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("AcctID", "AcctID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("Balance", "Balance"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("UserID", "UserID"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"BankID = {0}\n"+
			"BankName = {1}\n"+
			"ContactName = {2}\n"+
			"ContactNO = {3}\n"+
			"Address = {4}\n"+
			"Address1 = {5}\n"+
			"City = {6}\n"+
			"StateID = {7}\n"+
			"CountyID = {8}\n"+
			"PostCode = {9}\n"+
			"AccountNo = {10}\n"+
			"SortCode = {11}\n"+
			"AcctID = {12}\n"+
			"Balance = {13}\n"+
			"Active = {14}\n"+
			"UserID = {15}\n",
			BankID,			BankName,			ContactName,			ContactNO,			Address,			Address1,			City,			StateID,			CountyID,			PostCode,			AccountNo,			SortCode,			AcctID,			Balance,			Active,			UserID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class BankKeys
	{

		#region Data Members

		Guid _bankID;

		#endregion

		#region Constructor

		public BankKeys(Guid bankID)
		{
			 _bankID = bankID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  BankID
		{
			 get { return _bankID; }
		}

		#endregion

	}
}
