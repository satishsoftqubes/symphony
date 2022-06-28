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
	public class ResourceFiles: BusinessObjectBase
	{

		#region InnerClass
		public enum ResourceFilesFields
		{
			ResourceFileID,
			Name,
			DisplayName,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			IsToDisplayAdmin
		}
		#endregion

		#region Data Members

			Guid _resourceFileID;
			string _name;
			string _displayName;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			bool? _isToDisplayAdmin;

		#endregion

		#region Properties

		[DataMember]
		public Guid  ResourceFileID
		{
			 get { return _resourceFileID; }
			 set
			 {
				 if (_resourceFileID != value)
				 {
					_resourceFileID = value;
					 PropertyHasChanged("ResourceFileID");
				 }
			 }
		}

		[DataMember]
		public string  Name
		{
			 get { return _name; }
			 set
			 {
				 if (_name != value)
				 {
					_name = value;
					 PropertyHasChanged("Name");
				 }
			 }
		}

		[DataMember]
		public string  DisplayName
		{
			 get { return _displayName; }
			 set
			 {
				 if (_displayName != value)
				 {
					_displayName = value;
					 PropertyHasChanged("DisplayName");
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
		public bool?  IsToDisplayAdmin
		{
			 get { return _isToDisplayAdmin; }
			 set
			 {
				 if (_isToDisplayAdmin != value)
				 {
					_isToDisplayAdmin = value;
					 PropertyHasChanged("IsToDisplayAdmin");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ResourceFileID", "ResourceFileID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Name", "Name",150));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("DisplayName", "DisplayName",150));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ResourceFileID = {0}~\n"+
			"Name = {1}~\n"+
			"DisplayName = {2}~\n"+
			"UpdatedOn = {3}~\n"+
			"UpdatedBy = {4}~\n"+
			"IsActive = {5}~\n"+
			"IsToDisplayAdmin = {6}~\n",
			ResourceFileID,			Name,			DisplayName,			UpdatedOn,			UpdatedBy,			IsActive,			IsToDisplayAdmin);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ResourceFilesKeys
	{

		#region Data Members

		Guid _resourceFileID;

		#endregion

		#region Constructor

		public ResourceFilesKeys(Guid resourceFileID)
		{
			 _resourceFileID = resourceFileID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ResourceFileID
		{
			 get { return _resourceFileID; }
		}

		#endregion

	}
}
