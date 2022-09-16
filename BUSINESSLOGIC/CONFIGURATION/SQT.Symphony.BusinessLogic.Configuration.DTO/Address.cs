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
	public class Address: BusinessObjectBase
	{

		#region InnerClass
		public enum AddressFields
		{
			AddressID,
			CompanyID,
			Add1,
			Add2,
			Add3,
			CityID,
			ZipCode,
			StateID,
			CountryID,
			City,
			AddressTypeTermID,
			RetAddressID,
			IsActive,
			UpdateLog,
			IsSynch,
			SynchOn,
			SeqNo,
            Village,
		}
		#endregion

		#region Data Members

			Guid _addressID;
			Guid? _companyID;
			string _add1;
			string _add2;
			string _add3;
			Guid? _cityID;
			string _zipCode;
			Guid? _stateID;
			Guid? _countryID;
			string _city;
			Guid? _addressTypeTermID;
			Guid? _retAddressID;
			bool? _isActive;
			byte[] _updateLog;
			bool? _isSynch;
			DateTime? _synchOn;
			int? _seqNo;
           string _Village;

		#endregion

		#region Properties

		[DataMember]
		public Guid  AddressID
		{
			 get { return _addressID; }
			 set
			 {
				 if (_addressID != value)
				 {
					_addressID = value;
					 PropertyHasChanged("AddressID");
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
		public string  Add1
		{
			 get { return _add1; }
			 set
			 {
				 if (_add1 != value)
				 {
					_add1 = value;
					 PropertyHasChanged("Add1");
				 }
			 }
		}

		[DataMember]
		public string  Add2
		{
			 get { return _add2; }
			 set
			 {
				 if (_add2 != value)
				 {
					_add2 = value;
					 PropertyHasChanged("Add2");
				 }
			 }
		}

		[DataMember]
		public string  Add3
		{
			 get { return _add3; }
			 set
			 {
				 if (_add3 != value)
				 {
					_add3 = value;
					 PropertyHasChanged("Add3");
				 }
			 }
		}

		[DataMember]
		public Guid?  CityID
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
		public string  ZipCode
		{
			 get { return _zipCode; }
			 set
			 {
				 if (_zipCode != value)
				 {
					_zipCode = value;
					 PropertyHasChanged("ZipCode");
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
		public string  City
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
		public Guid?  AddressTypeTermID
		{
			 get { return _addressTypeTermID; }
			 set
			 {
				 if (_addressTypeTermID != value)
				 {
					_addressTypeTermID = value;
					 PropertyHasChanged("AddressTypeTermID");
				 }
			 }
		}

		[DataMember]
		public Guid?  RetAddressID
		{
			 get { return _retAddressID; }
			 set
			 {
				 if (_retAddressID != value)
				 {
					_retAddressID = value;
					 PropertyHasChanged("RetAddressID");
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
		public byte[]  UpdateLog
		{
			 get { return _updateLog; }
			 set
			 {
				 if (_updateLog != value)
				 {
					_updateLog = value;
					 PropertyHasChanged("UpdateLog");
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
		public int?  SeqNo
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
        public string Village
        {
            get { return _Village; }
            set
            {
                if (_Village != value)
                {
                    _Village = value;
                    PropertyHasChanged("Village");
                }
            }
        }


        #endregion

        #region Validation

        [OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("AddressID", "AddressID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Add1", "Add1",380));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Add2", "Add2",380));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Add3", "Add3",220));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ZipCode", "ZipCode",13));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("City", "City",78));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Village", "Village", 78));
        }

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"AddressID = {0}~\n"+
			"CompanyID = {1}~\n"+
			"Add1 = {2}~\n"+
			"Add2 = {3}~\n"+
			"Add3 = {4}~\n"+
			"CityID = {5}~\n"+
			"ZipCode = {6}~\n"+
			"StateID = {7}~\n"+
			"CountryID = {8}~\n"+
			"City = {9}~\n"+
			"AddressTypeTermID = {10}~\n"+
			"RetAddressID = {11}~\n"+
			"IsActive = {12}~\n"+
			"UpdateLog = {13}~\n"+
			"IsSynch = {14}~\n"+
			"SynchOn = {15}~\n"+
			"SeqNo = {16}~\n"+
            "Village = {17}~\n",
            AddressID,			CompanyID,			Add1,			Add2,			Add3,			CityID,			ZipCode,			StateID,			CountryID,			City,			AddressTypeTermID,			RetAddressID,			IsActive,			UpdateLog,			IsSynch,			SynchOn,			SeqNo,         Village);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class AddressKeys
	{

		#region Data Members

		Guid _addressID;

		#endregion

		#region Constructor

		public AddressKeys(Guid addressID)
		{
			 _addressID = addressID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  AddressID
		{
			 get { return _addressID; }
		}

		#endregion

	}
}
