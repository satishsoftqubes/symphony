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
	public class Role: BusinessObjectBase
	{

		#region InnerClass
		public enum RoleFields
		{
			RoleID,
			CompanyID,
			PropertyID,
			IsDefault,
			RoleCode,
			RoleName,
			AboutRole,
			IsActive,
			CreatedOn,
			CreatedBy,
			UpdateLog,
			IsSynch,
			SynchOn,
			SeqNo,
			IsFunctional,
            RoleType
		}
		#endregion

		#region Data Members

			Guid _roleID;
			Guid? _companyID;
			Guid? _propertyID;
			bool? _isDefault;
			string _roleCode;
			string _roleName;
			string _aboutRole;
			bool? _isActive;
			DateTime? _createdOn;
			Guid? _createdBy;
			byte[] _updateLog;
			bool? _isSynch;
			DateTime? _synchOn;
			int? _seqNo;
			bool? _isFunctional;
            string _roleType;

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoleID
		{
			 get { return _roleID; }
			 set
			 {
				 if (_roleID != value)
				 {
					_roleID = value;
					 PropertyHasChanged("RoleID");
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
		public string  RoleCode
		{
			 get { return _roleCode; }
			 set
			 {
				 if (_roleCode != value)
				 {
					_roleCode = value;
					 PropertyHasChanged("RoleCode");
				 }
			 }
		}
        [DataMember]
        public string RoleType
        {
            get { return _roleType; }
            set
            {
                if (_roleType != value)
                {
                    _roleType = value;
                    PropertyHasChanged("RoleType");
                }
            }
        }
		[DataMember]
		public string  RoleName
		{
			 get { return _roleName; }
			 set
			 {
				 if (_roleName != value)
				 {
					_roleName = value;
					 PropertyHasChanged("RoleName");
				 }
			 }
		}

		[DataMember]
		public string  AboutRole
		{
			 get { return _aboutRole; }
			 set
			 {
				 if (_aboutRole != value)
				 {
					_aboutRole = value;
					 PropertyHasChanged("AboutRole");
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
		public DateTime?  CreatedOn
		{
			 get { return _createdOn; }
			 set
			 {
				 if (_createdOn != value)
				 {
					_createdOn = value;
					 PropertyHasChanged("CreatedOn");
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
		public bool?  IsFunctional
		{
			 get { return _isFunctional; }
			 set
			 {
				 if (_isFunctional != value)
				 {
					_isFunctional = value;
					 PropertyHasChanged("IsFunctional");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("RoleID", "RoleID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("RoleCode", "RoleCode",7));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("RoleName", "RoleName",27));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("RoleType", "RoleType", 27));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("AboutRole", "AboutRole",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"RoleID = {0}~\n"+
			"CompanyID = {1}~\n"+
			"PropertyID = {2}~\n"+
			"IsDefault = {3}~\n"+
			"RoleCode = {4}~\n"+
			"RoleName = {5}~\n"+
			"AboutRole = {6}~\n"+
			"IsActive = {7}~\n"+
			"CreatedOn = {8}~\n"+
			"CreatedBy = {9}~\n"+
			"UpdateLog = {10}~\n"+
			"IsSynch = {11}~\n"+
			"SynchOn = {12}~\n"+
			"SeqNo = {13}~\n"+
			"IsFunctional = {14}~\n"+
            "RoleType = {15}~\n",
            RoleID, CompanyID, PropertyID, IsDefault, RoleCode, RoleName, AboutRole, IsActive, CreatedOn, CreatedBy, UpdateLog, IsSynch, SynchOn, SeqNo, IsFunctional, RoleType); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class RoleKeys
	{

		#region Data Members

		Guid _roleID;

		#endregion

		#region Constructor

		public RoleKeys(Guid roleID)
		{
			 _roleID = roleID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoleID
		{
			 get { return _roleID; }
		}

		#endregion

	}
}
