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
	public class Counters: BusinessObjectBase
	{

		#region InnerClass
		public enum CountersFields
		{
			CounterID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			CounterNo,
			Location_TermID,
			POSPointID,
			IsDefault
		}
		#endregion

		#region Data Members

			Guid _counterID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			string _counterNo;
			Guid? _location_TermID;
			Guid? _pOSPointID;
			bool? _isDefault;

		#endregion

		#region Properties

		[DataMember]
		public Guid  CounterID
		{
			 get { return _counterID; }
			 set
			 {
				 if (_counterID != value)
				 {
					_counterID = value;
					 PropertyHasChanged("CounterID");
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
		public string  CounterNo
		{
			 get { return _counterNo; }
			 set
			 {
				 if (_counterNo != value)
				 {
					_counterNo = value;
					 PropertyHasChanged("CounterNo");
				 }
			 }
		}

		[DataMember]
		public Guid?  Location_TermID
		{
			 get { return _location_TermID; }
			 set
			 {
				 if (_location_TermID != value)
				 {
					_location_TermID = value;
					 PropertyHasChanged("Location_TermID");
				 }
			 }
		}

		[DataMember]
		public Guid?  POSPointID
		{
			 get { return _pOSPointID; }
			 set
			 {
				 if (_pOSPointID != value)
				 {
					_pOSPointID = value;
					 PropertyHasChanged("POSPointID");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("CounterID", "CounterID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CounterNo", "CounterNo",3));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"CounterID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"CompanyID = {2}~\n"+
			"SeqNo = {3}~\n"+
			"IsSynch = {4}~\n"+
			"SynchOn = {5}~\n"+
			"UpdatedOn = {6}~\n"+
			"UpdatedBy = {7}~\n"+
			"IsActive = {8}~\n"+
			"CounterNo = {9}~\n"+
			"Location_TermID = {10}~\n"+
			"POSPointID = {11}~\n"+
			"IsDefault = {12}~\n",
			CounterID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			CounterNo,			Location_TermID,			POSPointID,			IsDefault);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class CountersKeys
	{

		#region Data Members

		Guid _counterID;

		#endregion

		#region Constructor

		public CountersKeys(Guid counterID)
		{
			 _counterID = counterID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  CounterID
		{
			 get { return _counterID; }
		}

		#endregion

	}
}
