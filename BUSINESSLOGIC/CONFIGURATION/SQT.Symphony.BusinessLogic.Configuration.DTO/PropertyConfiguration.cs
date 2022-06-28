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
	public class PropertyConfiguration: BusinessObjectBase
	{

		#region InnerClass
		public enum PropertyConfigurationFields
		{
			PropertyConfigurationID,
			PropertyID,
			SeqNo,
			DateFormatID,
			TimeFormatID,
			SmtpAddress,
			POP3InServer,
			POP3OutGoingServer,
			UserName,
			Password,
			PrimoryDomainName,
			PrimoryEmail,
			IsADPlugIn,
			DNSName,
			BaseCurrencyCode,
			NoOfCounters,
			IsSkipPostCode,
			IsSkipAddress,
			IsSkipEmail,
			IsSkipContactNo,
			IsIdenticationReg,
			Updatelog,
			RoodDescription,
			TubeDescription,
			ByAirDescription,
			ByPublicTranspertation,
			MapView,
			LastUpdateOn,
			LastUpdateBy,
			IsSynch,
			SynchOn,
			IsActive,
			PhotoLocal,
            CompanyID
		}
		#endregion

		#region Data Members

			Guid _propertyConfigurationID;
			Guid? _propertyID;
			int? _seqNo;
			Guid? _dateFormatID;
			Guid? _timeFormatID;
			string _smtpAddress;
			string _pOP3InServer;
			string _pOP3OutGoingServer;
			string _userName;
			string _password;
			string _primoryDomainName;
			string _primoryEmail;
			bool? _isADPlugIn;
			string _dNSName;
			string _baseCurrencyCode;
			bool? _noOfCounters;
			bool? _isSkipPostCode;
			bool? _isSkipAddress;
			bool? _isSkipEmail;
			bool? _isSkipContactNo;
			bool? _isIdenticationReg;
			byte[] _updatelog;
			string _roodDescription;
			string _tubeDescription;
			string _byAirDescription;
			string _byPublicTranspertation;
			string _mapView;
			DateTime? _lastUpdateOn;
			Guid? _lastUpdateBy;
			bool? _isSynch;
			DateTime? _synchOn;
			bool? _isActive;
			byte[] _photoLocal;
            Guid? _companyID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  PropertyConfigurationID
		{
			 get { return _propertyConfigurationID; }
			 set
			 {
				 if (_propertyConfigurationID != value)
				 {
					_propertyConfigurationID = value;
					 PropertyHasChanged("PropertyConfigurationID");
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
        public Guid? CompanyID
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
		public Guid?  DateFormatID
		{
			 get { return _dateFormatID; }
			 set
			 {
				 if (_dateFormatID != value)
				 {
					_dateFormatID = value;
					 PropertyHasChanged("DateFormatID");
				 }
			 }
		}

		[DataMember]
		public Guid?  TimeFormatID
		{
			 get { return _timeFormatID; }
			 set
			 {
				 if (_timeFormatID != value)
				 {
					_timeFormatID = value;
					 PropertyHasChanged("TimeFormatID");
				 }
			 }
		}

		[DataMember]
		public string  SmtpAddress
		{
			 get { return _smtpAddress; }
			 set
			 {
				 if (_smtpAddress != value)
				 {
					_smtpAddress = value;
					 PropertyHasChanged("SmtpAddress");
				 }
			 }
		}

		[DataMember]
		public string  POP3InServer
		{
			 get { return _pOP3InServer; }
			 set
			 {
				 if (_pOP3InServer != value)
				 {
					_pOP3InServer = value;
					 PropertyHasChanged("POP3InServer");
				 }
			 }
		}

		[DataMember]
		public string  POP3OutGoingServer
		{
			 get { return _pOP3OutGoingServer; }
			 set
			 {
				 if (_pOP3OutGoingServer != value)
				 {
					_pOP3OutGoingServer = value;
					 PropertyHasChanged("POP3OutGoingServer");
				 }
			 }
		}

		[DataMember]
		public string  UserName
		{
			 get { return _userName; }
			 set
			 {
				 if (_userName != value)
				 {
					_userName = value;
					 PropertyHasChanged("UserName");
				 }
			 }
		}

		[DataMember]
		public string  Password
		{
			 get { return _password; }
			 set
			 {
				 if (_password != value)
				 {
					_password = value;
					 PropertyHasChanged("Password");
				 }
			 }
		}

		[DataMember]
		public string  PrimoryDomainName
		{
			 get { return _primoryDomainName; }
			 set
			 {
				 if (_primoryDomainName != value)
				 {
					_primoryDomainName = value;
					 PropertyHasChanged("PrimoryDomainName");
				 }
			 }
		}

		[DataMember]
		public string  PrimoryEmail
		{
			 get { return _primoryEmail; }
			 set
			 {
				 if (_primoryEmail != value)
				 {
					_primoryEmail = value;
					 PropertyHasChanged("PrimoryEmail");
				 }
			 }
		}

		[DataMember]
		public bool?  IsADPlugIn
		{
			 get { return _isADPlugIn; }
			 set
			 {
				 if (_isADPlugIn != value)
				 {
					_isADPlugIn = value;
					 PropertyHasChanged("IsADPlugIn");
				 }
			 }
		}

		[DataMember]
		public string  DNSName
		{
			 get { return _dNSName; }
			 set
			 {
				 if (_dNSName != value)
				 {
					_dNSName = value;
					 PropertyHasChanged("DNSName");
				 }
			 }
		}

		[DataMember]
		public string  BaseCurrencyCode
		{
			 get { return _baseCurrencyCode; }
			 set
			 {
				 if (_baseCurrencyCode != value)
				 {
					_baseCurrencyCode = value;
					 PropertyHasChanged("BaseCurrencyCode");
				 }
			 }
		}

		[DataMember]
		public bool?  NoOfCounters
		{
			 get { return _noOfCounters; }
			 set
			 {
				 if (_noOfCounters != value)
				 {
					_noOfCounters = value;
					 PropertyHasChanged("NoOfCounters");
				 }
			 }
		}

		[DataMember]
		public bool?  IsSkipPostCode
		{
			 get { return _isSkipPostCode; }
			 set
			 {
				 if (_isSkipPostCode != value)
				 {
					_isSkipPostCode = value;
					 PropertyHasChanged("IsSkipPostCode");
				 }
			 }
		}

		[DataMember]
		public bool?  IsSkipAddress
		{
			 get { return _isSkipAddress; }
			 set
			 {
				 if (_isSkipAddress != value)
				 {
					_isSkipAddress = value;
					 PropertyHasChanged("IsSkipAddress");
				 }
			 }
		}

		[DataMember]
		public bool?  IsSkipEmail
		{
			 get { return _isSkipEmail; }
			 set
			 {
				 if (_isSkipEmail != value)
				 {
					_isSkipEmail = value;
					 PropertyHasChanged("IsSkipEmail");
				 }
			 }
		}

		[DataMember]
		public bool?  IsSkipContactNo
		{
			 get { return _isSkipContactNo; }
			 set
			 {
				 if (_isSkipContactNo != value)
				 {
					_isSkipContactNo = value;
					 PropertyHasChanged("IsSkipContactNo");
				 }
			 }
		}

		[DataMember]
		public bool?  IsIdenticationReg
		{
			 get { return _isIdenticationReg; }
			 set
			 {
				 if (_isIdenticationReg != value)
				 {
					_isIdenticationReg = value;
					 PropertyHasChanged("IsIdenticationReg");
				 }
			 }
		}

		[DataMember]
		public byte[]  Updatelog
		{
			 get { return _updatelog; }
			 set
			 {
				 if (_updatelog != value)
				 {
					_updatelog = value;
					 PropertyHasChanged("Updatelog");
				 }
			 }
		}

		[DataMember]
		public string  RoodDescription
		{
			 get { return _roodDescription; }
			 set
			 {
				 if (_roodDescription != value)
				 {
					_roodDescription = value;
					 PropertyHasChanged("RoodDescription");
				 }
			 }
		}

		[DataMember]
		public string  TubeDescription
		{
			 get { return _tubeDescription; }
			 set
			 {
				 if (_tubeDescription != value)
				 {
					_tubeDescription = value;
					 PropertyHasChanged("TubeDescription");
				 }
			 }
		}

		[DataMember]
		public string  ByAirDescription
		{
			 get { return _byAirDescription; }
			 set
			 {
				 if (_byAirDescription != value)
				 {
					_byAirDescription = value;
					 PropertyHasChanged("ByAirDescription");
				 }
			 }
		}

		[DataMember]
		public string  ByPublicTranspertation
		{
			 get { return _byPublicTranspertation; }
			 set
			 {
				 if (_byPublicTranspertation != value)
				 {
					_byPublicTranspertation = value;
					 PropertyHasChanged("ByPublicTranspertation");
				 }
			 }
		}

		[DataMember]
		public string  MapView
		{
			 get { return _mapView; }
			 set
			 {
				 if (_mapView != value)
				 {
					_mapView = value;
					 PropertyHasChanged("MapView");
				 }
			 }
		}

		[DataMember]
		public DateTime?  LastUpdateOn
		{
			 get { return _lastUpdateOn; }
			 set
			 {
				 if (_lastUpdateOn != value)
				 {
					_lastUpdateOn = value;
					 PropertyHasChanged("LastUpdateOn");
				 }
			 }
		}

		[DataMember]
		public Guid?  LastUpdateBy
		{
			 get { return _lastUpdateBy; }
			 set
			 {
				 if (_lastUpdateBy != value)
				 {
					_lastUpdateBy = value;
					 PropertyHasChanged("LastUpdateBy");
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
		public byte[]  PhotoLocal
		{
			 get { return _photoLocal; }
			 set
			 {
				 if (_photoLocal != value)
				 {
					_photoLocal = value;
					 PropertyHasChanged("PhotoLocal");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("PropertyConfigurationID", "PropertyConfigurationID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("SmtpAddress", "SmtpAddress",360));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("POP3InServer", "POP3InServer",360));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("POP3OutGoingServer", "POP3OutGoingServer",360));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("UserName", "UserName",360));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Password", "Password",360));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimoryDomainName", "PrimoryDomainName",360));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimoryEmail", "PrimoryEmail",360));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("DNSName", "DNSName",360));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("BaseCurrencyCode", "BaseCurrencyCode",50));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("RoodDescription", "RoodDescription",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("TubeDescription", "TubeDescription",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ByAirDescription", "ByAirDescription",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ByPublicTranspertation", "ByPublicTranspertation",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("MapView", "MapView",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"PropertyConfigurationID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"SeqNo = {2}~\n"+
			"DateFormatID = {3}~\n"+
			"TimeFormatID = {4}~\n"+
			"SmtpAddress = {5}~\n"+
			"POP3InServer = {6}~\n"+
			"POP3OutGoingServer = {7}~\n"+
			"UserName = {8}~\n"+
			"Password = {9}~\n"+
			"PrimoryDomainName = {10}~\n"+
			"PrimoryEmail = {11}~\n"+
			"IsADPlugIn = {12}~\n"+
			"DNSName = {13}~\n"+
			"BaseCurrencyCode = {14}~\n"+
			"NoOfCounters = {15}~\n"+
			"IsSkipPostCode = {16}~\n"+
			"IsSkipAddress = {17}~\n"+
			"IsSkipEmail = {18}~\n"+
			"IsSkipContactNo = {19}~\n"+
			"IsIdenticationReg = {20}~\n"+
			"Updatelog = {21}~\n"+
			"RoodDescription = {22}~\n"+
			"TubeDescription = {23}~\n"+
			"ByAirDescription = {24}~\n"+
			"ByPublicTranspertation = {25}~\n"+
			"MapView = {26}~\n"+
			"LastUpdateOn = {27}~\n"+
			"LastUpdateBy = {28}~\n"+
			"IsSynch = {29}~\n"+
			"SynchOn = {30}~\n"+
			"IsActive = {31}~\n"+
			"PhotoLocal = {32}~\n"+
            "CompanyID={33}~\n",
            PropertyConfigurationID, PropertyID, SeqNo, DateFormatID, TimeFormatID, SmtpAddress, POP3InServer, POP3OutGoingServer, UserName, Password, PrimoryDomainName, PrimoryEmail, IsADPlugIn, DNSName, BaseCurrencyCode, NoOfCounters, IsSkipPostCode, IsSkipAddress, IsSkipEmail, IsSkipContactNo, IsIdenticationReg, Updatelog, RoodDescription, TubeDescription, ByAirDescription, ByPublicTranspertation, MapView, LastUpdateOn, LastUpdateBy, IsSynch, SynchOn, IsActive, PhotoLocal, CompanyID); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class PropertyConfigurationKeys
	{

		#region Data Members

		Guid _propertyConfigurationID;

		#endregion

		#region Constructor

		public PropertyConfigurationKeys(Guid propertyConfigurationID)
		{
			 _propertyConfigurationID = propertyConfigurationID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  PropertyConfigurationID
		{
			 get { return _propertyConfigurationID; }
		}

		#endregion

	}
}
