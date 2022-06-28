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
	public class FrontDeskAlert: BusinessObjectBase
	{

		#region InnerClass
		public enum FrontDeskAlertFields
		{
			FrontDeskAlertID,
			FrontDeskAlertMsgID,
			MsgFor,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			UpdatedOn,
			UpdatedBy,
			CreatedOn,
			CreatedBy,
			IsActive,
			AsReceive
		}
		#endregion

		#region Data Members

			Guid _frontDeskAlertID;
			Guid? _frontDeskAlertMsgID;
			Guid? _msgFor;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			DateTime? _createdOn;
			Guid? _createdBy;
			bool? _isActive;
			bool? _asReceive;

		#endregion

		#region Properties

		[DataMember]
		public Guid  FrontDeskAlertID
		{
			 get { return _frontDeskAlertID; }
			 set
			 {
				 if (_frontDeskAlertID != value)
				 {
					_frontDeskAlertID = value;
					 PropertyHasChanged("FrontDeskAlertID");
				 }
			 }
		}

		[DataMember]
		public Guid?  FrontDeskAlertMsgID
		{
			 get { return _frontDeskAlertMsgID; }
			 set
			 {
				 if (_frontDeskAlertMsgID != value)
				 {
					_frontDeskAlertMsgID = value;
					 PropertyHasChanged("FrontDeskAlertMsgID");
				 }
			 }
		}

		[DataMember]
		public Guid?  MsgFor
		{
			 get { return _msgFor; }
			 set
			 {
				 if (_msgFor != value)
				 {
					_msgFor = value;
					 PropertyHasChanged("MsgFor");
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

		[DataMember]
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
		public bool?  AsReceive
		{
			 get { return _asReceive; }
			 set
			 {
				 if (_asReceive != value)
				 {
					_asReceive = value;
					 PropertyHasChanged("AsReceive");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("FrontDeskAlertID", "FrontDeskAlertID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"FrontDeskAlertID = {0}\n"+
			"FrontDeskAlertMsgID = {1}\n"+
			"MsgFor = {2}\n"+
			"PropertyID = {3}\n"+
			"CompanyID = {4}\n"+
			"SeqNo = {5}\n"+
			"IsSynch = {6}\n"+
			"UpdatedOn = {7}\n"+
			"UpdatedBy = {8}\n"+
			"CreatedOn = {9}\n"+
			"CreatedBy = {10}\n"+
			"IsActive = {11}\n"+
			"AsReceive = {12}\n",
			FrontDeskAlertID,			FrontDeskAlertMsgID,			MsgFor,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			UpdatedOn,			UpdatedBy,			CreatedOn,			CreatedBy,			IsActive,			AsReceive);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class FrontDeskAlertKeys
	{

		#region Data Members

		Guid _frontDeskAlertID;

		#endregion

		#region Constructor

		public FrontDeskAlertKeys(Guid frontDeskAlertID)
		{
			 _frontDeskAlertID = frontDeskAlertID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  FrontDeskAlertID
		{
			 get { return _frontDeskAlertID; }
		}

		#endregion

	}
}
