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
	public class UserRole: BusinessObjectBase
	{

		#region InnerClass
		public enum UserRoleFields
		{
			UserRoleID,
			UserID,
			RoleID,
			RoleLevel,
			AssignedOn,
			AssignedBy,
			IsSynch,
			SynchOn
		}
		#endregion

		#region Data Members

			Guid _userRoleID;
			Guid? _userID;
			Guid? _roleID;
			string _roleLevel;
			DateTime? _assignedOn;
			Guid? _assignedBy;
			bool? _isSynch;
			DateTime? _synchOn;

		#endregion

		#region Properties

		[DataMember]
		public Guid  UserRoleID
		{
			 get { return _userRoleID; }
			 set
			 {
				 if (_userRoleID != value)
				 {
					_userRoleID = value;
					 PropertyHasChanged("UserRoleID");
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
		public Guid?  RoleID
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
		public string  RoleLevel
		{
			 get { return _roleLevel; }
			 set
			 {
				 if (_roleLevel != value)
				 {
					_roleLevel = value;
					 PropertyHasChanged("RoleLevel");
				 }
			 }
		}

		[DataMember]
		public DateTime?  AssignedOn
		{
			 get { return _assignedOn; }
			 set
			 {
				 if (_assignedOn != value)
				 {
					_assignedOn = value;
					 PropertyHasChanged("AssignedOn");
				 }
			 }
		}

		[DataMember]
		public Guid?  AssignedBy
		{
			 get { return _assignedBy; }
			 set
			 {
				 if (_assignedBy != value)
				 {
					_assignedBy = value;
					 PropertyHasChanged("AssignedBy");
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("UserRoleID", "UserRoleID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("RoleLevel", "RoleLevel",10));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
            "UserRoleID = {0}~\n" +
            "UserID = {1}~\n" +
            "RoleID = {2}~\n" +
            "RoleLevel = {3}~\n" +
            "AssignedOn = {4}~\n" +
            "AssignedBy = {5}~\n" +
            "IsSynch = {6}~\n" +
            "SynchOn = {7}~\n",
			UserRoleID,			UserID,			RoleID,			RoleLevel,			AssignedOn,			AssignedBy,			IsSynch,			SynchOn);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class UserRoleKeys
	{

		#region Data Members

		Guid _userRoleID;

		#endregion

		#region Constructor

		public UserRoleKeys(Guid userRoleID)
		{
			 _userRoleID = userRoleID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  UserRoleID
		{
			 get { return _userRoleID; }
		}

		#endregion

	}
}
