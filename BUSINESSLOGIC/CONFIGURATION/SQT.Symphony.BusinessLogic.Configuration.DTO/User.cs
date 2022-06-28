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
	public class User: BusinessObjectBase
	{

		#region InnerClass
		public enum UserFields
		{
			UsearID,
			PropertyID,
			CompanyID,
			IsCRSUser,
			UserTypeID,
			UserType,
			IsDefault,
			IsSystemUser,
			IsSymphonyUser,
			UserName,
			Password,
			PasswordKey,
			LastLogingDate,
			CraetedOn,
			CreatedBy,
			IsBlock,
			IsActive,
			UpdateLog,
			IsSynch,
			SynchOn,
			LastPasswordUpdateOn,
			UserDisplayName,
			DisplayAvtar,
			BlockOn,
			BlockBy,
			PhotoLocal,
			SeqNo
		}
		#endregion

		#region Data Members

			Guid _usearID;
			Guid? _propertyID;
			Guid? _companyID;
			bool? _isCRSUser;
			Guid? _userTypeID;
			string _userType;
			bool? _isDefault;
			bool? _isSystemUser;
			bool? _isSymphonyUser;
			string _userName;
			string _password;
			string _passwordKey;
			DateTime? _lastLogingDate;
			DateTime? _craetedOn;
			Guid? _createdBy;
			bool? _isBlock;
			bool? _isActive;
			byte[] _updateLog;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _lastPasswordUpdateOn;
			string _userDisplayName;
			string _displayAvtar;
			DateTime? _blockOn;
			Guid? _blockBy;
			byte[] _photoLocal;
			int? _seqNo;

		#endregion

		#region Properties

		[DataMember]
		public Guid  UsearID
		{
			 get { return _usearID; }
			 set
			 {
				 if (_usearID != value)
				 {
					_usearID = value;
					 PropertyHasChanged("UsearID");
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
		public bool?  IsCRSUser
		{
			 get { return _isCRSUser; }
			 set
			 {
				 if (_isCRSUser != value)
				 {
					_isCRSUser = value;
					 PropertyHasChanged("IsCRSUser");
				 }
			 }
		}

		[DataMember]
		public Guid?  UserTypeID
		{
			 get { return _userTypeID; }
			 set
			 {
				 if (_userTypeID != value)
				 {
					_userTypeID = value;
					 PropertyHasChanged("UserTypeID");
				 }
			 }
		}

		[DataMember]
		public string  UserType
		{
			 get { return _userType; }
			 set
			 {
				 if (_userType != value)
				 {
					_userType = value;
					 PropertyHasChanged("UserType");
				 }
			 }
		}

		[DataMember]
		public bool?  IsDefault
		{
			 get { return _isDefault; }
			 set
			 {
				 if (_isDefault != value)
				 {
					_isDefault = value;
					 PropertyHasChanged("IsDefault");
				 }
			 }
		}

		[DataMember]
		public bool?  IsSystemUser
		{
			 get { return _isSystemUser; }
			 set
			 {
				 if (_isSystemUser != value)
				 {
					_isSystemUser = value;
					 PropertyHasChanged("IsSystemUser");
				 }
			 }
		}

		[DataMember]
		public bool?  IsSymphonyUser
		{
			 get { return _isSymphonyUser; }
			 set
			 {
				 if (_isSymphonyUser != value)
				 {
					_isSymphonyUser = value;
					 PropertyHasChanged("IsSymphonyUser");
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
		public string  PasswordKey
		{
			 get { return _passwordKey; }
			 set
			 {
				 if (_passwordKey != value)
				 {
					_passwordKey = value;
					 PropertyHasChanged("PasswordKey");
				 }
			 }
		}

		[DataMember]
		public DateTime?  LastLogingDate
		{
			 get { return _lastLogingDate; }
			 set
			 {
				 if (_lastLogingDate != value)
				 {
					_lastLogingDate = value;
					 PropertyHasChanged("LastLogingDate");
				 }
			 }
		}

		[DataMember]
		public DateTime?  CraetedOn
		{
			 get { return _craetedOn; }
			 set
			 {
				 if (_craetedOn != value)
				 {
					_craetedOn = value;
					 PropertyHasChanged("CraetedOn");
				 }
			 }
		}

		[DataMember]
		public Guid?  CreatedBy
		{
			 get { return _createdBy; }
			 set
			 {
				 if (_createdBy != value)
				 {
					_createdBy = value;
					 PropertyHasChanged("CreatedBy");
				 }
			 }
		}

		[DataMember]
		public bool?  IsBlock
		{
			 get { return _isBlock; }
			 set
			 {
				 if (_isBlock != value)
				 {
					_isBlock = value;
					 PropertyHasChanged("IsBlock");
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
		public DateTime?  LastPasswordUpdateOn
		{
			 get { return _lastPasswordUpdateOn; }
			 set
			 {
				 if (_lastPasswordUpdateOn != value)
				 {
					_lastPasswordUpdateOn = value;
					 PropertyHasChanged("LastPasswordUpdateOn");
				 }
			 }
		}

		[DataMember]
		public string  UserDisplayName
		{
			 get { return _userDisplayName; }
			 set
			 {
				 if (_userDisplayName != value)
				 {
					_userDisplayName = value;
					 PropertyHasChanged("UserDisplayName");
				 }
			 }
		}

		[DataMember]
		public string  DisplayAvtar
		{
			 get { return _displayAvtar; }
			 set
			 {
				 if (_displayAvtar != value)
				 {
					_displayAvtar = value;
					 PropertyHasChanged("DisplayAvtar");
				 }
			 }
		}

		[DataMember]
		public DateTime?  BlockOn
		{
			 get { return _blockOn; }
			 set
			 {
				 if (_blockOn != value)
				 {
					_blockOn = value;
					 PropertyHasChanged("BlockOn");
				 }
			 }
		}

		[DataMember]
		public Guid?  BlockBy
		{
			 get { return _blockBy; }
			 set
			 {
				 if (_blockBy != value)
				 {
					_blockBy = value;
					 PropertyHasChanged("BlockBy");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("UsearID", "UsearID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("UserType", "UserType",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("UserName", "UserName",180));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Password", "Password",27));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PasswordKey", "PasswordKey",27));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("UserDisplayName", "UserDisplayName",67));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("DisplayAvtar", "DisplayAvtar",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
            "UsearID = {0}~\n" +
            "PropertyID = {1}~\n" +
            "CompanyID = {2}~\n" +
            "IsCRSUser = {3}~\n" +
            "UserTypeID = {4}~\n" +
            "UserType = {5}~\n" +
            "IsDefault = {6}~\n" +
            "IsSystemUser = {7}~\n" +
            "IsSymphonyUser = {8}~\n" +
            "UserName = {9}~\n" +
            "Password = {10}~\n" +
            "PasswordKey = {11}~\n" +
            "LastLogingDate = {12}~\n" +
            "CraetedOn = {13}~\n" +
            "CreatedBy = {14}~\n" +
            "IsBlock = {15}~\n" +
            "IsActive = {16}~\n" +
            "UpdateLog = {17}~\n" +
            "IsSynch = {18}~\n" +
            "SynchOn = {19}~\n" +
            "LastPasswordUpdateOn = {20}~\n" +
            "UserDisplayName = {21}~\n" +
            "DisplayAvtar = {22}~\n" +
            "BlockOn = {23}~\n" +
            "BlockBy = {24}~\n" +
            "PhotoLocal = {25}~\n" +
            "SeqNo = {26}~\n",
			UsearID,			PropertyID,			CompanyID,			IsCRSUser,			UserTypeID,			UserType,			IsDefault,			IsSystemUser,			IsSymphonyUser,			UserName,			Password,			PasswordKey,			LastLogingDate,			CraetedOn,			CreatedBy,			IsBlock,			IsActive,			UpdateLog,			IsSynch,			SynchOn,			LastPasswordUpdateOn,			UserDisplayName,			DisplayAvtar,			BlockOn,			BlockBy,			PhotoLocal,			SeqNo);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class UserKeys
	{

		#region Data Members

		Guid _usearID;

		#endregion

		#region Constructor

		public UserKeys(Guid usearID)
		{
			 _usearID = usearID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  UsearID
		{
			 get { return _usearID; }
		}

		#endregion

	}
}
