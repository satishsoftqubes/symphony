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
	public class EmailConfig: BusinessObjectBase
	{

		#region InnerClass
		public enum EmailConfigFields
		{
			EmailConfigID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			SMTPHost,
			POP3InServer,
			POP3OutGoingServer,
			UserName,
			Password,
			PrimoryDomainName,
			PrimoryEmail,
			SMTPPort
		}
		#endregion

		#region Data Members

			Guid _emailConfigID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			string _sMTPHost;
			string _pOP3InServer;
			string _pOP3OutGoingServer;
			string _userName;
			string _password;
			string _primoryDomainName;
			string _primoryEmail;
			string _sMTPPort;

		#endregion

		#region Properties

		[DataMember]
		public Guid  EmailConfigID
		{
			 get { return _emailConfigID; }
			 set
			 {
				 if (_emailConfigID != value)
				 {
					_emailConfigID = value;
					 PropertyHasChanged("EmailConfigID");
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
		public string  SMTPHost
		{
			 get { return _sMTPHost; }
			 set
			 {
				 if (_sMTPHost != value)
				 {
					_sMTPHost = value;
					 PropertyHasChanged("SMTPHost");
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
		public string  SMTPPort
		{
			 get { return _sMTPPort; }
			 set
			 {
				 if (_sMTPPort != value)
				 {
					_sMTPPort = value;
					 PropertyHasChanged("SMTPPort");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("EmailConfigID", "EmailConfigID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("SMTPHost", "SMTPHost",350));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("POP3InServer", "POP3InServer",360));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("POP3OutGoingServer", "POP3OutGoingServer",360));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("UserName", "UserName",360));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Password", "Password",360));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimoryDomainName", "PrimoryDomainName",360));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PrimoryEmail", "PrimoryEmail",360));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("SMTPPort", "SMTPPort",10));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"EmailConfigID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"CompanyID = {2}~\n"+
			"SeqNo = {3}~\n"+
			"IsSynch = {4}~\n"+
			"SynchOn = {5}~\n"+
			"UpdatedOn = {6}~\n"+
			"UpdatedBy = {7}~\n"+
			"IsActive = {8}~\n"+
			"SMTPHost = {9}~\n"+
			"POP3InServer = {10}~\n"+
			"POP3OutGoingServer = {11}~\n"+
			"UserName = {12}~\n"+
			"Password = {13}~\n"+
			"PrimoryDomainName = {14}~\n"+
			"PrimoryEmail = {15}~\n"+
			"SMTPPort = {16}~\n",
			EmailConfigID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			SMTPHost,			POP3InServer,			POP3OutGoingServer,			UserName,			Password,			PrimoryDomainName,			PrimoryEmail,			SMTPPort);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class EmailConfigKeys
	{

		#region Data Members

		Guid _emailConfigID;

		#endregion

		#region Constructor

		public EmailConfigKeys(Guid emailConfigID)
		{
			 _emailConfigID = emailConfigID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  EmailConfigID
		{
			 get { return _emailConfigID; }
		}

		#endregion

	}
}
