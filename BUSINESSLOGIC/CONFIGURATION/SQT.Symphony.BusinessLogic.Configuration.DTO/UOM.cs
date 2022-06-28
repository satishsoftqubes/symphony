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
	public class UOM: BusinessObjectBase
	{

		#region InnerClass
		public enum UOMFields
		{
			UOMID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			UOMName,
			UOMCode
		}
		#endregion

		#region Data Members

			Guid _uOMID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			string _uOMName;
			string _uOMCode;

		#endregion

		#region Properties

		[DataMember]
		public Guid  UOMID
		{
			 get { return _uOMID; }
			 set
			 {
				 if (_uOMID != value)
				 {
					_uOMID = value;
					 PropertyHasChanged("UOMID");
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
		public string  UOMName
		{
			 get { return _uOMName; }
			 set
			 {
				 if (_uOMName != value)
				 {
					_uOMName = value;
					 PropertyHasChanged("UOMName");
				 }
			 }
		}

		[DataMember]
		public string  UOMCode
		{
			 get { return _uOMCode; }
			 set
			 {
				 if (_uOMCode != value)
				 {
					_uOMCode = value;
					 PropertyHasChanged("UOMCode");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("UOMID", "UOMID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("UOMName", "UOMName",50));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("UOMCode", "UOMCode",4));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
            "UOMID = {0}~\n" +
            "PropertyID = {1}~\n" +
            "CompanyID = {2}~\n" +
            "SeqNo = {3}~\n" +
            "IsSynch = {4}~\n" +
            "SynchOn = {5}~\n" +
            "UpdatedOn = {6}~\n" +
            "UpdatedBy = {7}~\n" +
            "IsActive = {8}~\n" +
            "UOMName = {9}~\n" +
            "UOMCode = {10}~\n",
			UOMID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			UOMName,			UOMCode);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class UOMKeys
	{

		#region Data Members

		Guid _uOMID;

		#endregion

		#region Constructor

		public UOMKeys(Guid uOMID)
		{
			 _uOMID = uOMID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  UOMID
		{
			 get { return _uOMID; }
		}

		#endregion

	}
}
