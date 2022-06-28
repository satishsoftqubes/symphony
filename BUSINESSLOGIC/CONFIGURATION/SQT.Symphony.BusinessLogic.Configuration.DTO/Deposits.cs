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
	public class Deposits: BusinessObjectBase
	{

		#region InnerClass
		public enum DepositsFields
		{
			DepositID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			DepositName,
			AcctID,
			DepositRate,
			IsFlat
		}
		#endregion

		#region Data Members

			Guid _depositID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			string _depositName;
			Guid? _acctID;
			decimal? _depositRate;
			bool? _isFlat;

		#endregion

		#region Properties

		[DataMember]
		public Guid  DepositID
		{
			 get { return _depositID; }
			 set
			 {
				 if (_depositID != value)
				 {
					_depositID = value;
					 PropertyHasChanged("DepositID");
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
		public string  DepositName
		{
			 get { return _depositName; }
			 set
			 {
				 if (_depositName != value)
				 {
					_depositName = value;
					 PropertyHasChanged("DepositName");
				 }
			 }
		}

		[DataMember]
		public Guid?  AcctID
		{
			 get { return _acctID; }
			 set
			 {
				 if (_acctID != value)
				 {
					_acctID = value;
					 PropertyHasChanged("AcctID");
				 }
			 }
		}

		[DataMember]
		public decimal?  DepositRate
		{
			 get { return _depositRate; }
			 set
			 {
				 if (_depositRate != value)
				 {
					_depositRate = value;
					 PropertyHasChanged("DepositRate");
				 }
			 }
		}

		[DataMember]
		public bool?  IsFlat
		{
			 get { return _isFlat; }
			 set
			 {
				 if (_isFlat != value)
				 {
					_isFlat = value;
					 PropertyHasChanged("IsFlat");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("DepositID", "DepositID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("DepositName", "DepositName",60));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"DepositID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"CompanyID = {2}~\n"+
			"SeqNo = {3}~\n"+
			"IsSynch = {4}~\n"+
			"SynchOn = {5}~\n"+
			"UpdatedOn = {6}~\n"+
			"UpdatedBy = {7}~\n"+
			"IsActive = {8}~\n"+
			"DepositName = {9}~\n"+
			"AcctID = {10}~\n"+
			"DepositRate = {11}~\n"+
			"IsFlat = {12}~\n",
			DepositID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			DepositName,			AcctID,			DepositRate,			IsFlat);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class DepositsKeys
	{

		#region Data Members

		Guid _depositID;

		#endregion

		#region Constructor

		public DepositsKeys(Guid depositID)
		{
			 _depositID = depositID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  DepositID
		{
			 get { return _depositID; }
		}

		#endregion

	}
}
