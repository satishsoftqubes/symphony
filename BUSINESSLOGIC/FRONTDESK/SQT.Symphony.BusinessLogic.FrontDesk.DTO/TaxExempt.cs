using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;
namespace SQT.Symphony.BusinessLogic.FrontDesk.DTO
{
	[DataContract]
	public class TaxExempt: BusinessObjectBase
	{

		#region InnerClass
		public enum TaxExemptFields
		{
			TaxExemptID,
			ReservationID,
			TaxID,
			ReasonForExempt,
			ProofOfDocumentScan,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive
		}
		#endregion

		#region Data Members

			Guid _taxExemptID;
			Guid? _reservationID;
			Guid? _taxID;
			string _reasonForExempt;
			string _proofOfDocumentScan;
			Guid? _propertyID;
			Guid? _companyID;
			long _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;

		#endregion

		#region Properties

		[DataMember]
		public Guid  TaxExemptID
		{
			 get { return _taxExemptID; }
			 set
			 {
				 if (_taxExemptID != value)
				 {
					_taxExemptID = value;
					 PropertyHasChanged("TaxExemptID");
				 }
			 }
		}

		[DataMember]
		public Guid?  ReservationID
		{
			 get { return _reservationID; }
			 set
			 {
				 if (_reservationID != value)
				 {
					_reservationID = value;
					 PropertyHasChanged("ReservationID");
				 }
			 }
		}

		[DataMember]
		public Guid?  TaxID
		{
			 get { return _taxID; }
			 set
			 {
				 if (_taxID != value)
				 {
					_taxID = value;
					 PropertyHasChanged("TaxID");
				 }
			 }
		}

		[DataMember]
		public string  ReasonForExempt
		{
			 get { return _reasonForExempt; }
			 set
			 {
				 if (_reasonForExempt != value)
				 {
					_reasonForExempt = value;
					 PropertyHasChanged("ReasonForExempt");
				 }
			 }
		}

		[DataMember]
		public string  ProofOfDocumentScan
		{
			 get { return _proofOfDocumentScan; }
			 set
			 {
				 if (_proofOfDocumentScan != value)
				 {
					_proofOfDocumentScan = value;
					 PropertyHasChanged("ProofOfDocumentScan");
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
		public long  SeqNo
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("TaxExemptID", "TaxExemptID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ReasonForExempt", "ReasonForExempt",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ProofOfDocumentScan", "ProofOfDocumentScan",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"TaxExemptID = {0}\n"+
			"ReservationID = {1}\n"+
			"TaxID = {2}\n"+
			"ReasonForExempt = {3}\n"+
			"ProofOfDocumentScan = {4}\n"+
			"PropertyID = {5}\n"+
			"CompanyID = {6}\n"+
			"SeqNo = {7}\n"+
			"IsSynch = {8}\n"+
			"SynchOn = {9}\n"+
			"UpdatedOn = {10}\n"+
			"UpdatedBy = {11}\n"+
			"IsActive = {12}\n",
			TaxExemptID,			ReservationID,			TaxID,			ReasonForExempt,			ProofOfDocumentScan,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class TaxExemptKeys
	{

		#region Data Members

		Guid _taxExemptID;

		#endregion

		#region Constructor

		public TaxExemptKeys(Guid taxExemptID)
		{
			 _taxExemptID = taxExemptID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  TaxExemptID
		{
			 get { return _taxExemptID; }
		}

		#endregion

	}
}
