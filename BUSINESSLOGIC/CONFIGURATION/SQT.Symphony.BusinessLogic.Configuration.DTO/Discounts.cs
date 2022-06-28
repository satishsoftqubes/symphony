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
	public class Discounts: BusinessObjectBase
	{

		#region InnerClass
		public enum DiscountsFields
		{
			DiscountID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			IsDiscFlat,
			DiscountRate,
			DiscountName,
			DiscountDetails,
			DiscountType_TermID
		}
		#endregion

		#region Data Members

			Guid _discountID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			bool? _isDiscFlat;
			decimal? _discountRate;
			string _discountName;
			string _discountDetails;
			Guid? _discountType_TermID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  DiscountID
		{
			 get { return _discountID; }
			 set
			 {
				 if (_discountID != value)
				 {
					_discountID = value;
					 PropertyHasChanged("DiscountID");
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
		public bool?  IsDiscFlat
		{
			 get { return _isDiscFlat; }
			 set
			 {
				 if (_isDiscFlat != value)
				 {
					_isDiscFlat = value;
					 PropertyHasChanged("IsDiscFlat");
				 }
			 }
		}

		[DataMember]
		public decimal?  DiscountRate
		{
			 get { return _discountRate; }
			 set
			 {
				 if (_discountRate != value)
				 {
					_discountRate = value;
					 PropertyHasChanged("DiscountRate");
				 }
			 }
		}

		[DataMember]
		public string  DiscountName
		{
			 get { return _discountName; }
			 set
			 {
				 if (_discountName != value)
				 {
					_discountName = value;
					 PropertyHasChanged("DiscountName");
				 }
			 }
		}

		[DataMember]
		public string  DiscountDetails
		{
			 get { return _discountDetails; }
			 set
			 {
				 if (_discountDetails != value)
				 {
					_discountDetails = value;
					 PropertyHasChanged("DiscountDetails");
				 }
			 }
		}

		[DataMember]
		public Guid?  DiscountType_TermID
		{
			 get { return _discountType_TermID; }
			 set
			 {
				 if (_discountType_TermID != value)
				 {
					_discountType_TermID = value;
					 PropertyHasChanged("DiscountType_TermID");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("DiscountID", "DiscountID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("DiscountName", "DiscountName",70));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("DiscountDetails", "DiscountDetails",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"DiscountID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"CompanyID = {2}~\n"+
			"SeqNo = {3}~\n"+
			"IsSynch = {4}~\n"+
			"SynchOn = {5}~\n"+
			"UpdatedOn = {6}~\n"+
			"UpdatedBy = {7}~\n"+
			"IsActive = {8}~\n"+
			"IsDiscFlat = {9}~\n"+
			"DiscountRate = {10}~\n"+
			"DiscountName = {11}~\n"+
			"DiscountDetails = {12}~\n"+
			"DiscountType_TermID = {13}~\n",
			DiscountID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			IsDiscFlat,			DiscountRate,			DiscountName,			DiscountDetails,			DiscountType_TermID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class DiscountsKeys
	{

		#region Data Members

		Guid _discountID;

		#endregion

		#region Constructor

		public DiscountsKeys(Guid discountID)
		{
			 _discountID = discountID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  DiscountID
		{
			 get { return _discountID; }
		}

		#endregion

	}
}
