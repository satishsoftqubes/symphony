using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
namespace SQT.Symphony.BusinessLogic.IRMS.DTO
{
	public class InsuranceDetails: BusinessObjectBase
	{

		#region InnerClass
		public enum InsuranceDetailsFields
		{
			InsuranceID,
			FromDate,
			ToDate,
			PropertyID,
			IsActive,
			CreatedOn,
			CreatedBy,
			SeqNo,
			CompanyName,
			PolicyNo,
			Title,
			Description
		}
		#endregion

		#region Data Members

			Guid _insuranceID;
			DateTime? _fromDate;
			DateTime? _toDate;
			Guid? _propertyID;
			bool? _isActive;
			DateTime? _createdOn;
			Guid? _createdBy;
			int _seqNo;
			string _companyName;
			string _policyNo;
			string _title;
			string _description;

		#endregion

		#region Properties

		public Guid  InsuranceID
		{
			 get { return _insuranceID; }
			 set
			 {
				 if (_insuranceID != value)
				 {
					_insuranceID = value;
					 PropertyHasChanged("InsuranceID");
				 }
			 }
		}

		public DateTime?  FromDate
		{
			 get { return _fromDate; }
			 set
			 {
				 if (_fromDate != value)
				 {
					_fromDate = value;
					 PropertyHasChanged("FromDate");
				 }
			 }
		}

		public DateTime?  ToDate
		{
			 get { return _toDate; }
			 set
			 {
				 if (_toDate != value)
				 {
					_toDate = value;
					 PropertyHasChanged("ToDate");
				 }
			 }
		}

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

		public string  CompanyName
		{
			 get { return _companyName; }
			 set
			 {
				 if (_companyName != value)
				 {
					_companyName = value;
					 PropertyHasChanged("CompanyName");
				 }
			 }
		}

		public string  PolicyNo
		{
			 get { return _policyNo; }
			 set
			 {
				 if (_policyNo != value)
				 {
					_policyNo = value;
					 PropertyHasChanged("PolicyNo");
				 }
			 }
		}

		public string  Title
		{
			 get { return _title; }
			 set
			 {
				 if (_title != value)
				 {
					_title = value;
					 PropertyHasChanged("Title");
				 }
			 }
		}

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

		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("InsuranceID", "InsuranceID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CompanyName", "CompanyName",500));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PolicyNo", "PolicyNo",500));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Title", "Title",250));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Description", "Description",250));
		}

		public override string ToString()
		{
			string objValue = string.Format(
			"InsuranceID = {0}\n"+
			"FromDate = {1}\n"+
			"ToDate = {2}\n"+
			"PropertyID = {3}\n"+
			"IsActive = {4}\n"+
			"CreatedOn = {5}\n"+
			"CreatedBy = {6}\n"+
			"SeqNo = {7}\n"+
			"CompanyName = {8}\n"+
			"PolicyNo = {9}\n"+
			"Title = {10}\n"+
			"Description = {11}\n",
			InsuranceID,			FromDate,			ToDate,			PropertyID,			IsActive,			CreatedOn,			CreatedBy,			SeqNo,			CompanyName,			PolicyNo,			Title,			Description);			return objValue;
		}

		#endregion

	}
	public class InsuranceDetailsKeys
	{

		#region Data Members

		Guid _insuranceID;

		#endregion

		#region Constructor

		public InsuranceDetailsKeys(Guid insuranceID)
		{
			 _insuranceID = insuranceID; 
		}

		#endregion

		#region Properties

		public Guid  InsuranceID
		{
			 get { return _insuranceID; }
		}

		#endregion

	}
}
