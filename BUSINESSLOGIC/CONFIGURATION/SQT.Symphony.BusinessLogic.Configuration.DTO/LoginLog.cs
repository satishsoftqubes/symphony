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
	public class LoginLog: BusinessObjectBase
	{

		#region InnerClass
		public enum LoginLogFields
		{
			LogInLogID,
			CompanyID,
			PropertyID,
			UserID,
			LogIn,
			Logout,
			IsWithCounter,
			CounterID,
			SessionID,
			Token,
			ActorTypeTermID,
			SeqNo,
			IsSynch,
			SynchOn
		}
		#endregion

		#region Data Members

			Guid _logInLogID;
			Guid? _companyID;
			Guid? _propertyID;
			Guid? _userID;
			DateTime? _logIn;
			DateTime? _logout;
			bool? _isWithCounter;
			Guid? _counterID;
			string _sessionID;
			string _token;
			string _actorTypeTermID;
			int? _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;

		#endregion

		#region Properties

		[DataMember]
		public Guid  LogInLogID
		{
			 get { return _logInLogID; }
			 set
			 {
				 if (_logInLogID != value)
				 {
					_logInLogID = value;
					 PropertyHasChanged("LogInLogID");
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
		public Guid?  UserID
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

		[DataMember]
		public DateTime?  LogIn
		{
			 get { return _logIn; }
			 set
			 {
				 if (_logIn != value)
				 {
					_logIn = value;
					 PropertyHasChanged("LogIn");
				 }
			 }
		}

		[DataMember]
		public DateTime?  Logout
		{
			 get { return _logout; }
			 set
			 {
				 if (_logout != value)
				 {
					_logout = value;
					 PropertyHasChanged("Logout");
				 }
			 }
		}

		[DataMember]
		public bool?  IsWithCounter
		{
			 get { return _isWithCounter; }
			 set
			 {
				 if (_isWithCounter != value)
				 {
					_isWithCounter = value;
					 PropertyHasChanged("IsWithCounter");
				 }
			 }
		}

		[DataMember]
		public Guid?  CounterID
		{
			 get { return _counterID; }
			 set
			 {
				 if (_counterID != value)
				 {
					_counterID = value;
					 PropertyHasChanged("CounterID");
				 }
			 }
		}

		[DataMember]
		public string  SessionID
		{
			 get { return _sessionID; }
			 set
			 {
				 if (_sessionID != value)
				 {
					_sessionID = value;
					 PropertyHasChanged("SessionID");
				 }
			 }
		}

		[DataMember]
		public string  Token
		{
			 get { return _token; }
			 set
			 {
				 if (_token != value)
				 {
					_token = value;
					 PropertyHasChanged("Token");
				 }
			 }
		}

		[DataMember]
		public string  ActorTypeTermID
		{
			 get { return _actorTypeTermID; }
			 set
			 {
				 if (_actorTypeTermID != value)
				 {
					_actorTypeTermID = value;
					 PropertyHasChanged("ActorTypeTermID");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("LogInLogID", "LogInLogID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("SessionID", "SessionID",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Token", "Token",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ActorTypeTermID", "ActorTypeTermID",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"LogInLogID = {0}~\n"+
			"CompanyID = {1}~\n"+
			"PropertyID = {2}~\n"+
			"UserID = {3}~\n"+
			"LogIn = {4}~\n"+
			"Logout = {5}~\n"+
			"IsWithCounter = {6}~\n"+
			"CounterID = {7}~\n"+
			"SessionID = {8}~\n"+
			"Token = {9}~\n"+
			"ActorTypeTermID = {10}~\n"+
			"SeqNo = {11}~\n"+
			"IsSynch = {12}~\n"+
			"SynchOn = {13}~\n",
			LogInLogID,			CompanyID,			PropertyID,			UserID,			LogIn,			Logout,			IsWithCounter,			CounterID,			SessionID,			Token,			ActorTypeTermID,			SeqNo,			IsSynch,			SynchOn);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class LoginLogKeys
	{

		#region Data Members

		Guid _logInLogID;

		#endregion

		#region Constructor

		public LoginLogKeys(Guid logInLogID)
		{
			 _logInLogID = logInLogID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  LogInLogID
		{
			 get { return _logInLogID; }
		}

		#endregion

	}
}
