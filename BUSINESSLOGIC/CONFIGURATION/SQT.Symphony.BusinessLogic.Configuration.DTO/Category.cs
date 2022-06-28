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
	public class Category: BusinessObjectBase
	{

		#region InnerClass
		public enum CategoryFields
		{
			CategoryID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			CategoryCode,
			CategoryName,
			Details,
			RefCategoryID
		}
		#endregion

		#region Data Members

			Guid _categoryID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			string _categoryCode;
			string _categoryName;
			string _details;
			Guid? _refCategoryID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  CategoryID
		{
			 get { return _categoryID; }
			 set
			 {
				 if (_categoryID != value)
				 {
					_categoryID = value;
					 PropertyHasChanged("CategoryID");
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
		public string  CategoryCode
		{
			 get { return _categoryCode; }
			 set
			 {
				 if (_categoryCode != value)
				 {
					_categoryCode = value;
					 PropertyHasChanged("CategoryCode");
				 }
			 }
		}

		[DataMember]
		public string  CategoryName
		{
			 get { return _categoryName; }
			 set
			 {
				 if (_categoryName != value)
				 {
					_categoryName = value;
					 PropertyHasChanged("CategoryName");
				 }
			 }
		}

		[DataMember]
		public string  Details
		{
			 get { return _details; }
			 set
			 {
				 if (_details != value)
				 {
					_details = value;
					 PropertyHasChanged("Details");
				 }
			 }
		}

		[DataMember]
		public Guid?  RefCategoryID
		{
			 get { return _refCategoryID; }
			 set
			 {
				 if (_refCategoryID != value)
				 {
					_refCategoryID = value;
					 PropertyHasChanged("RefCategoryID");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("CategoryID", "CategoryID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CategoryCode", "CategoryCode",7));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CategoryName", "CategoryName",150));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Details", "Details",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"CategoryID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"CompanyID = {2}~\n"+
			"SeqNo = {3}~\n"+
			"IsSynch = {4}~\n"+
			"SynchOn = {5}~\n"+
			"UpdatedOn = {6}~\n"+
			"UpdatedBy = {7}~\n"+
			"IsActive = {8}~\n"+
			"CategoryCode = {9}~\n"+
			"CategoryName = {10}~\n"+
			"Details = {11}~\n"+
			"RefCategoryID = {12}~\n",
			CategoryID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			CategoryCode,			CategoryName,			Details,			RefCategoryID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class CategoryKeys
	{

		#region Data Members

		Guid _categoryID;

		#endregion

		#region Constructor

		public CategoryKeys(Guid categoryID)
		{
			 _categoryID = categoryID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  CategoryID
		{
			 get { return _categoryID; }
		}

		#endregion

	}
}
