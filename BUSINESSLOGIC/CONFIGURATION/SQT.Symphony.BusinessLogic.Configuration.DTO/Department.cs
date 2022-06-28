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
	public class Department: BusinessObjectBase
	{

		#region InnerClass
		public enum DepartmentFields
		{
			DepartmentID,
			PropertyID,
			CompanyID,
			DepartmentCode,
			DepartmentName,
			IsDefault,
			IsActive,
			Updatelog,
			SeqNo,
			CreatedOn,
			CraetedBy,
			IsSynch,
			SynchOn,
			Description
		}
		#endregion

		#region Data Members

			Guid _departmentID;
			Guid? _propertyID;
			Guid? _companyID;
			string _departmentCode;
			string _departmentName;
			bool? _isDefault;
			bool? _isActive;
			byte[] _updatelog;
			int? _seqNo;
			DateTime? _createdOn;
			Guid? _craetedBy;
			bool? _isSynch;
			DateTime? _synchOn;
			string _description;

		#endregion

		#region Properties

		[DataMember]
		public Guid  DepartmentID
		{
			 get { return _departmentID; }
			 set
			 {
				 if (_departmentID != value)
				 {
					_departmentID = value;
					 PropertyHasChanged("DepartmentID");
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
		public string  DepartmentCode
		{
			 get { return _departmentCode; }
			 set
			 {
				 if (_departmentCode != value)
				 {
					_departmentCode = value;
					 PropertyHasChanged("DepartmentCode");
				 }
			 }
		}

		[DataMember]
		public string  DepartmentName
		{
			 get { return _departmentName; }
			 set
			 {
				 if (_departmentName != value)
				 {
					_departmentName = value;
					 PropertyHasChanged("DepartmentName");
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
		public Guid?  CraetedBy
		{
			 get { return _craetedBy; }
			 set
			 {
				 if (_craetedBy != value)
				 {
					_craetedBy = value;
					 PropertyHasChanged("CraetedBy");
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
		public string  Description
		{
			 get { return _description; }
			 set
			 {
				 if (_description != value)
				 {
					_description = value;
					 PropertyHasChanged("Description");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("DepartmentID", "DepartmentID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("DepartmentCode", "DepartmentCode",5));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("DepartmentName", "DepartmentName",23));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Description", "Description",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"DepartmentID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"CompanyID = {2}~\n"+
            "DepartmentCode = {3}~\n" +
            "DepartmentName = {4}~\n" +
            "IsDefault = {5}~\n" +
            "IsActive = {6}~\n" +
            "Updatelog = {7}~\n" +
            "SeqNo = {8}~\n" +
            "CreatedOn = {9}~\n" +
            "CraetedBy = {10}~\n" +
            "IsSynch = {11}~\n" +
            "SynchOn = {12}~\n" +
            "Description = {13}~\n",
			DepartmentID,			PropertyID,			CompanyID,			DepartmentCode,			DepartmentName,			IsDefault,			IsActive,			Updatelog,			SeqNo,			CreatedOn,			CraetedBy,			IsSynch,			SynchOn,			Description);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class DepartmentKeys
	{

		#region Data Members

		Guid _departmentID;

		#endregion

		#region Constructor

		public DepartmentKeys(Guid departmentID)
		{
			 _departmentID = departmentID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  DepartmentID
		{
			 get { return _departmentID; }
		}

		#endregion

	}
}
