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
	public class Right: BusinessObjectBase
	{

		#region InnerClass
		public enum RightFields
		{
			RightID,
			CompanyID,
			PropertyID,
			ReportID,
			FormName,
			FullName,
			MenuName,
			ParentID,
			MenuParentOrderID,
			MenuChileOrderID,
			IsMenuOption,
			MenuIcon,
			IsBlock,
			Description,
			IsSynch,
			SynchOn
		}
		#endregion

		#region Data Members

			Guid _rightID;
			Guid? _companyID;
			Guid? _propertyID;
			Guid? _reportID;
			string _formName;
			string _fullName;
			string _menuName;
			Guid? _parentID;
			Guid? _menuParentOrderID;
			Guid? _menuChileOrderID;
			bool? _isMenuOption;
			string _menuIcon;
			bool? _isBlock;
			string _description;
			bool? _isSynch;
			DateTime? _synchOn;

		#endregion

		#region Properties

		[DataMember]
		public Guid  RightID
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
		public Guid?  ReportID
		{
			 get { return _reportID; }
			 set
			 {
				 if (_reportID != value)
				 {
					_reportID = value;
					 PropertyHasChanged("ReportID");
				 }
			 }
		}

		[DataMember]
		public string  FormName
		{
			 get { return _formName; }
			 set
			 {
				 if (_formName != value)
				 {
					_formName = value;
					 PropertyHasChanged("FormName");
				 }
			 }
		}

		[DataMember]
		public string  FullName
		{
			 get { return _fullName; }
			 set
			 {
				 if (_fullName != value)
				 {
					_fullName = value;
					 PropertyHasChanged("FullName");
				 }
			 }
		}

		[DataMember]
		public string  MenuName
		{
			 get { return _menuName; }
			 set
			 {
				 if (_menuName != value)
				 {
					_menuName = value;
					 PropertyHasChanged("MenuName");
				 }
			 }
		}

		[DataMember]
		public Guid?  ParentID
		{
			 get { return _parentID; }
			 set
			 {
				 if (_parentID != value)
				 {
					_parentID = value;
					 PropertyHasChanged("ParentID");
				 }
			 }
		}

		[DataMember]
		public Guid?  MenuParentOrderID
		{
			 get { return _menuParentOrderID; }
			 set
			 {
				 if (_menuParentOrderID != value)
				 {
					_menuParentOrderID = value;
					 PropertyHasChanged("MenuParentOrderID");
				 }
			 }
		}

		[DataMember]
		public Guid?  MenuChileOrderID
		{
			 get { return _menuChileOrderID; }
			 set
			 {
				 if (_menuChileOrderID != value)
				 {
					_menuChileOrderID = value;
					 PropertyHasChanged("MenuChileOrderID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsMenuOption
		{
			 get { return _isMenuOption; }
			 set
			 {
				 if (_isMenuOption != value)
				 {
					_isMenuOption = value;
					 PropertyHasChanged("IsMenuOption");
				 }
			 }
		}

		[DataMember]
		public string  MenuIcon
		{
			 get { return _menuIcon; }
			 set
			 {
				 if (_menuIcon != value)
				 {
					_menuIcon = value;
					 PropertyHasChanged("MenuIcon");
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("RightID", "RightID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("FormName", "FormName",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("FullName", "FullName",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("MenuName", "MenuName",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("MenuIcon", "MenuIcon",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Description", "Description",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"RightID = {0}~\n"+
			"CompanyID = {1}~\n"+
			"PropertyID = {2}~\n"+
			"ReportID = {3}~\n"+
			"FormName = {4}~\n"+
			"FullName = {5}~\n"+
			"MenuName = {6}~\n"+
			"ParentID = {7}~\n"+
			"MenuParentOrderID = {8}~\n"+
			"MenuChileOrderID = {9}~\n"+
			"IsMenuOption = {10}~\n"+
			"MenuIcon = {11}~\n"+
			"IsBlock = {12}~\n"+
			"Description = {13}~\n"+
			"IsSynch = {14}~\n"+
			"SynchOn = {15}~\n",
			RightID,			CompanyID,			PropertyID,			ReportID,			FormName,			FullName,			MenuName,			ParentID,			MenuParentOrderID,			MenuChileOrderID,			IsMenuOption,			MenuIcon,			IsBlock,			Description,			IsSynch,			SynchOn);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class RightKeys
	{

		#region Data Members

		Guid _rightID;

		#endregion

		#region Constructor

		public RightKeys(Guid rightID)
		{
			 _rightID = rightID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  RightID
		{
			 get { return _rightID; }
		}

		#endregion

	}
}
