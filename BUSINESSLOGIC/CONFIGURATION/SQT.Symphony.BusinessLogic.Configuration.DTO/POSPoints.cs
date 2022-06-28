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
	public class POSPoints: BusinessObjectBase
	{

		#region InnerClass
		public enum POSPointsFields
		{
			POSPointID,
			POSLocation_TermID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			POSPointName,
			PointDisplayName,
			UploadImage,
			IsActivityPOS,
			IsConsumablePOS,
			POSDescription,
			DefaultCounterID,
			DefaultUserID,
			IsTouchScreenEnable,
            VendorID
		}
		#endregion

		#region Data Members

			Guid _pOSPointID;
			Guid? _pOSLocation_TermID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			string _pOSPointName;
			string _pointDisplayName;
			string _uploadImage;
			bool? _isActivityPOS;
			bool? _isConsumablePOS;
			string _pOSDescription;
			Guid? _defaultCounterID;
			Guid? _defaultUserID;
			bool? _isTouchScreenEnable;
            Guid? _vendorID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  POSPointID
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
		public Guid?  POSLocation_TermID
		{
			 get { return _pOSLocation_TermID; }
			 set
			 {
				 if (_pOSLocation_TermID != value)
				 {
					_pOSLocation_TermID = value;
					 PropertyHasChanged("POSLocation_TermID");
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
		public string  POSPointName
		{
			 get { return _pOSPointName; }
			 set
			 {
				 if (_pOSPointName != value)
				 {
					_pOSPointName = value;
					 PropertyHasChanged("POSPointName");
				 }
			 }
		}

		[DataMember]
		public string  PointDisplayName
		{
			 get { return _pointDisplayName; }
			 set
			 {
				 if (_pointDisplayName != value)
				 {
					_pointDisplayName = value;
					 PropertyHasChanged("PointDisplayName");
				 }
			 }
		}

		[DataMember]
		public string  UploadImage
		{
			 get { return _uploadImage; }
			 set
			 {
				 if (_uploadImage != value)
				 {
					_uploadImage = value;
					 PropertyHasChanged("UploadImage");
				 }
			 }
		}

		[DataMember]
		public bool?  IsActivityPOS
		{
			 get { return _isActivityPOS; }
			 set
			 {
				 if (_isActivityPOS != value)
				 {
					_isActivityPOS = value;
					 PropertyHasChanged("IsActivityPOS");
				 }
			 }
		}

		[DataMember]
		public bool?  IsConsumablePOS
		{
			 get { return _isConsumablePOS; }
			 set
			 {
				 if (_isConsumablePOS != value)
				 {
					_isConsumablePOS = value;
					 PropertyHasChanged("IsConsumablePOS");
				 }
			 }
		}

		[DataMember]
		public string  POSDescription
		{
			 get { return _pOSDescription; }
			 set
			 {
				 if (_pOSDescription != value)
				 {
					_pOSDescription = value;
					 PropertyHasChanged("POSDescription");
				 }
			 }
		}

		[DataMember]
		public Guid?  DefaultCounterID
		{
			 get { return _defaultCounterID; }
			 set
			 {
				 if (_defaultCounterID != value)
				 {
					_defaultCounterID = value;
					 PropertyHasChanged("DefaultCounterID");
				 }
			 }
		}

		[DataMember]
		public Guid?  DefaultUserID
		{
			 get { return _defaultUserID; }
			 set
			 {
				 if (_defaultUserID != value)
				 {
					_defaultUserID = value;
					 PropertyHasChanged("DefaultUserID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsTouchScreenEnable
		{
			 get { return _isTouchScreenEnable; }
			 set
			 {
				 if (_isTouchScreenEnable != value)
				 {
					_isTouchScreenEnable = value;
					 PropertyHasChanged("IsTouchScreenEnable");
				 }
			 }
		}

        [DataMember]
        public Guid? VendorID
        {
            get { return _vendorID; }
            set
            {
                if (_vendorID != value)
                {
                    _vendorID = value;
                    PropertyHasChanged("VendorID");
                }
            }
        }

		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("POSPointID", "POSPointID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("POSPointName", "POSPointName",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PointDisplayName", "PointDisplayName",165));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("UploadImage", "UploadImage",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("POSDescription", "POSDescription",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"POSPointID = {0}~\n"+
			"POSLocation_TermID = {1}~\n"+
			"PropertyID = {2}~\n"+
			"CompanyID = {3}~\n"+
			"SeqNo = {4}~\n"+
			"IsSynch = {5}~\n"+
			"SynchOn = {6}~\n"+
			"UpdatedOn = {7}~\n"+
			"UpdatedBy = {8}~\n"+
			"IsActive = {9}~\n"+
			"POSPointName = {10}~\n"+
			"PointDisplayName = {11}~\n"+
			"UploadImage = {12}~\n"+
			"IsActivityPOS = {13}~\n"+
			"IsConsumablePOS = {14}~\n"+
			"POSDescription = {15}~\n"+
			"DefaultCounterID = {16}~\n"+
			"DefaultUserID = {17}~\n"+
            "IsTouchScreenEnable = {18}~\n" +
            "VendorID = {19}~\n",
            POSPointID, POSLocation_TermID, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, POSPointName, PointDisplayName, UploadImage, IsActivityPOS, IsConsumablePOS, POSDescription, DefaultCounterID, DefaultUserID, IsTouchScreenEnable, VendorID); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class POSPointsKeys
	{

		#region Data Members

		Guid _pOSPointID;

		#endregion

		#region Constructor

		public POSPointsKeys(Guid pOSPointID)
		{
			 _pOSPointID = pOSPointID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  POSPointID
		{
			 get { return _pOSPointID; }
		}

		#endregion

	}
}
