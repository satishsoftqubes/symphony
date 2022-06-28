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
	public class CorporateRates: BusinessObjectBase
	{

		#region InnerClass
		public enum CorporateRatesFields
		{
			CorporateRateID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			RateID,
			CorporateID,
            IsDefaultThis
		}
		#endregion

		#region Data Members

			Guid _corporateRateID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			Guid? _rateID;
			Guid? _corporateID;
            bool? _isDefaultThis;

		#endregion

		#region Properties

		[DataMember]
		public Guid  CorporateRateID
		{
			 get { return _corporateRateID; }
			 set
			 {
				 if (_corporateRateID != value)
				 {
					_corporateRateID = value;
					 PropertyHasChanged("CorporateRateID");
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
		public Guid?  RateID
		{
			 get { return _rateID; }
			 set
			 {
				 if (_rateID != value)
				 {
					_rateID = value;
					 PropertyHasChanged("RateID");
				 }
			 }
		}

		[DataMember]
		public Guid?  CorporateID
		{
			 get { return _corporateID; }
			 set
			 {
				 if (_corporateID != value)
				 {
					_corporateID = value;
					 PropertyHasChanged("CorporateID");
				 }
			 }
		}

        [DataMember]
        public bool? IsDefaultThis
		{
			 get { return _isDefaultThis; }
			 set
			 {
                 if (_isDefaultThis != value)
				 {
                     _isDefaultThis = value;
                    PropertyHasChanged("IsDefaultThis");
				 }
			 }
		}

		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("CorporateRateID", "CorporateRateID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"CorporateRateID = {0}~\n"+
			"SeqNo = {1}~\n"+
			"IsSynch = {2}~\n"+
			"SynchOn = {3}~\n"+
			"UpdatedOn = {4}~\n"+
			"UpdatedBy = {5}~\n"+
			"IsActive = {6}~\n"+
			"RateID = {7}~\n"+
			"CorporateID = {8}~\n",
			CorporateRateID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			RateID,			CorporateID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class CorporateRatesKeys
	{

		#region Data Members

		Guid _corporateRateID;

		#endregion

		#region Constructor

		public CorporateRatesKeys(Guid corporateRateID)
		{
			 _corporateRateID = corporateRateID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  CorporateRateID
		{
			 get { return _corporateRateID; }
		}

		#endregion

	}
}
