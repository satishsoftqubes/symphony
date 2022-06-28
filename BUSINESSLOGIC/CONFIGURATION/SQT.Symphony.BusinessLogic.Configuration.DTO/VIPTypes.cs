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
	public class VIPTypes: BusinessObjectBase
	{
          
		#region InnerClass
		public enum VIPTypesFields
		{
			VIPTypeID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			TypeCode,
			VIPTypeName
		}
		#endregion

		#region Data Members

			Guid _vIPTypeID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			string _typeCode;
			string _vIPTypeName;

		#endregion
         
		#region Properties

		[DataMember]
		public Guid  VIPTypeID
		{
			 get { return _vIPTypeID; }
			 set
			 {
				 if (_vIPTypeID != value)
				 {
					_vIPTypeID = value;
					 PropertyHasChanged("VIPTypeID");
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
		public string  TypeCode
		{
			 get { return _typeCode; }
			 set
			 {
				 if (_typeCode != value)
				 {
					_typeCode = value;
					 PropertyHasChanged("TypeCode");
				 }
			 }
		}

		[DataMember]
		public string  VIPTypeName
		{
			 get { return _vIPTypeName; }
			 set
			 {
				 if (_vIPTypeName != value)
				 {
					_vIPTypeName = value;
					 PropertyHasChanged("VIPTypeName");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("VIPTypeID", "VIPTypeID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("TypeCode", "TypeCode",7));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("VIPTypeName", "VIPTypeName",65));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
            "VIPTypeID = {0}~\n" +
            "PropertyID = {1}~\n" +
            "CompanyID = {2}~\n" +
            "SeqNo = {3}~\n" +
            "IsSynch = {4}~\n" +
            "SynchOn = {5}~\n" +
            "UpdatedOn = {6}~\n" +
            "UpdatedBy = {7}~\n" +
            "IsActive = {8}~\n" +
            "TypeCode = {9}~\n" +
            "VIPTypeName = {10}~\n",
			VIPTypeID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			TypeCode,			VIPTypeName);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class VIPTypesKeys
	{

		#region Data Members

		Guid _vIPTypeID;

		#endregion

		#region Constructor

		public VIPTypesKeys(Guid vIPTypeID)
		{
			 _vIPTypeID = vIPTypeID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  VIPTypeID
		{
			 get { return _vIPTypeID; }
		}

		#endregion

	}
}
