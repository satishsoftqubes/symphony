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
	public class RoleRightJoin: BusinessObjectBase
	{

		#region InnerClass
		public enum RoleRightJoinFields
		{
			RoleRightJoinID,
			RoleID,
			RightID,
			IsView,
			IsCreate,
			IsUpdate,
			IsDelete
		}
		#endregion

		#region Data Members

			Guid _roleRightJoinID;
			Guid? _roleID;
			Guid? _rightID;
			bool? _isView;
			bool? _isCreate;
			bool? _isUpdate;
			bool? _isDelete;

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoleRightJoinID
		{
			 get { return _roleRightJoinID; }
			 set
			 {
				 if (_roleRightJoinID != value)
				 {
					_roleRightJoinID = value;
					 PropertyHasChanged("RoleRightJoinID");
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
		public Guid?  RightID
		{
			 get { return _rightID; }
			 set
			 {
				 if (_rightID != value)
				 {
					_rightID = value;
					 PropertyHasChanged("RightID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsView
		{
			 get { return _isView; }
			 set
			 {
				 if (_isView != value)
				 {
					_isView = value;
					 PropertyHasChanged("IsView");
				 }
			 }
		}

		[DataMember]
		public bool?  IsCreate
		{
			 get { return _isCreate; }
			 set
			 {
				 if (_isCreate != value)
				 {
					_isCreate = value;
					 PropertyHasChanged("IsCreate");
				 }
			 }
		}

		[DataMember]
		public bool?  IsUpdate
		{
			 get { return _isUpdate; }
			 set
			 {
				 if (_isUpdate != value)
				 {
					_isUpdate = value;
					 PropertyHasChanged("IsUpdate");
				 }
			 }
		}

		[DataMember]
		public bool?  IsDelete
		{
			 get { return _isDelete; }
			 set
			 {
				 if (_isDelete != value)
				 {
					_isDelete = value;
					 PropertyHasChanged("IsDelete");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("RoleRightJoinID", "RoleRightJoinID"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"RoleRightJoinID = {0}~\n"+
			"RoleID = {1}~\n"+
			"RightID = {2}~\n"+
			"IsView = {3}~\n"+
			"IsCreate = {4}~\n"+
			"IsUpdate = {5}~\n"+
			"IsDelete = {6}~\n",
			RoleRightJoinID,			RoleID,			RightID,			IsView,			IsCreate,			IsUpdate,			IsDelete);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class RoleRightJoinKeys
	{

		#region Data Members

		Guid _roleRightJoinID;

		#endregion

		#region Constructor

		public RoleRightJoinKeys(Guid roleRightJoinID)
		{
			 _roleRightJoinID = roleRightJoinID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  RoleRightJoinID
		{
			 get { return _roleRightJoinID; }
		}

		#endregion

	}
}
