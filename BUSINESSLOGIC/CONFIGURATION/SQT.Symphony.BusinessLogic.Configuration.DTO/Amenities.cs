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
	public class Amenities: BusinessObjectBase
	{

		#region InnerClass
		public enum AmenitiesFields
		{
			AmenitiesID,
			AmenitiesCode,
			AmenitiesName,
			AmenitiesDescription,
			UploadImage,
			Thumb,
			SeqNo,
			IsActive,
			IsSynch,
			SynchOn,
			CreatedOn,
			CreatedBy,
			UpdatedOn,
			UpdatedBy,
			PropertyID,
			UpdateLog,
			IsAvailableORequestOnly,
			IsExtraCharge,
			Charge,
			ChargeFrequency_TermID,
			IsPerPerson,
            IsForUnit,
            AmenitiesTypeTermID
		}
		#endregion

		#region Data Members

			Guid _amenitiesID;
			string _amenitiesCode;
			string _amenitiesName;
			string _amenitiesDescription;
			byte[] _uploadImage;
			string _thumb;
			int _seqNo;
			bool? _isActive;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _createdOn;
			Guid? _createdBy;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			Guid? _propertyID;
			byte[] _updateLog;
			bool? _isAvailableORequestOnly;
			bool? _isExtraCharge;
			decimal? _charge;
			Guid? _chargeFrequency_TermID;
			bool? _isPerPerson;
            bool? _isForUnit;
            Guid? _amenitiesTypeTermID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  AmenitiesID
		{
			 get { return _amenitiesID; }
			 set
			 {
				 if (_amenitiesID != value)
				 {
					_amenitiesID = value;
					 PropertyHasChanged("AmenitiesID");
				 }
			 }
		}

		[DataMember]
		public string  AmenitiesCode
		{
			 get { return _amenitiesCode; }
			 set
			 {
				 if (_amenitiesCode != value)
				 {
					_amenitiesCode = value;
					 PropertyHasChanged("AmenitiesCode");
				 }
			 }
		}

		[DataMember]
		public string  AmenitiesName
		{
			 get { return _amenitiesName; }
			 set
			 {
				 if (_amenitiesName != value)
				 {
					_amenitiesName = value;
					 PropertyHasChanged("AmenitiesName");
				 }
			 }
		}

		[DataMember]
		public string  AmenitiesDescription
		{
			 get { return _amenitiesDescription; }
			 set
			 {
				 if (_amenitiesDescription != value)
				 {
					_amenitiesDescription = value;
					 PropertyHasChanged("AmenitiesDescription");
				 }
			 }
		}

		[DataMember]
		public byte[]  UploadImage
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
		public string  Thumb
		{
			 get { return _thumb; }
			 set
			 {
				 if (_thumb != value)
				 {
					_thumb = value;
					 PropertyHasChanged("Thumb");
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
		public byte[]  UpdateLog
		{
			 get { return _updateLog; }
			 set
			 {
				 if (_updateLog != value)
				 {
					_updateLog = value;
					 PropertyHasChanged("UpdateLog");
				 }
			 }
		}

		[DataMember]
		public bool?  IsAvailableORequestOnly
		{
			 get { return _isAvailableORequestOnly; }
			 set
			 {
				 if (_isAvailableORequestOnly != value)
				 {
					_isAvailableORequestOnly = value;
					 PropertyHasChanged("IsAvailableORequestOnly");
				 }
			 }
		}

		[DataMember]
		public bool?  IsExtraCharge
		{
			 get { return _isExtraCharge; }
			 set
			 {
				 if (_isExtraCharge != value)
				 {
					_isExtraCharge = value;
					 PropertyHasChanged("IsExtraCharge");
				 }
			 }
		}

		[DataMember]
		public decimal?  Charge
		{
			 get { return _charge; }
			 set
			 {
				 if (_charge != value)
				 {
					_charge = value;
					 PropertyHasChanged("Charge");
				 }
			 }
		}

		[DataMember]
		public Guid?  ChargeFrequency_TermID
		{
			 get { return _chargeFrequency_TermID; }
			 set
			 {
				 if (_chargeFrequency_TermID != value)
				 {
					_chargeFrequency_TermID = value;
					 PropertyHasChanged("ChargeFrequency_TermID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsPerPerson
		{
			 get { return _isPerPerson; }
			 set
			 {
				 if (_isPerPerson != value)
				 {
					_isPerPerson = value;
					 PropertyHasChanged("IsPerPerson");
				 }
			 }
		}
        [DataMember]
        public bool? IsForUnit
        {
            get { return _isForUnit; }
            set
            {
                if (_isForUnit != value)
                {
                    _isForUnit = value;
                    PropertyHasChanged("IsForUnit");
                }
            }
        }

        [DataMember]
        public Guid? AmenitiesTypeTermID
        {
            get { return _amenitiesTypeTermID; }
            set
            {
                if (_amenitiesTypeTermID != value)
                {
                    _amenitiesTypeTermID = value;
                    PropertyHasChanged("AmenitiesTypeTermID");
                }
            }
        }
		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("AmenitiesID", "AmenitiesID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("AmenitiesCode", "AmenitiesCode",7));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("AmenitiesName", "AmenitiesName",150));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("AmenitiesDescription", "AmenitiesDescription",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Thumb", "Thumb",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"AmenitiesID = {0}~\n"+
			"AmenitiesCode = {1}~\n"+
			"AmenitiesName = {2}~\n"+
			"AmenitiesDescription = {3}~\n"+
			"UploadImage = {4}~\n"+
			"Thumb = {5}~\n"+
			"SeqNo = {6}~\n"+
			"IsActive = {7}~\n"+
			"IsSynch = {8}~\n"+
			"SynchOn = {9}~\n"+
			"CreatedOn = {10}~\n"+
			"CreatedBy = {11}~\n"+
			"UpdatedOn = {12}~\n"+
			"UpdatedBy = {13}~\n"+
			"PropertyID = {14}~\n"+
			"UpdateLog = {15}~\n"+
			"IsAvailableORequestOnly = {16}~\n"+
			"IsExtraCharge = {17}~\n"+
			"Charge = {18}~\n"+
			"ChargeFrequency_TermID = {19}~\n"+
			"IsPerPerson = {20}~\n"+
            "IsForUnit = {21}~\n" +
            "AmenitiesTypeTermID={22}~\n",
            AmenitiesID, AmenitiesCode, AmenitiesName, AmenitiesDescription, UploadImage, Thumb, SeqNo, IsActive, IsSynch, SynchOn, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, PropertyID, UpdateLog, IsAvailableORequestOnly, IsExtraCharge, Charge, ChargeFrequency_TermID, IsPerPerson, IsForUnit, AmenitiesTypeTermID); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class AmenitiesKeys
	{

		#region Data Members

		Guid _amenitiesID;

		#endregion

		#region Constructor

		public AmenitiesKeys(Guid amenitiesID)
		{
			 _amenitiesID = amenitiesID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  AmenitiesID
		{
			 get { return _amenitiesID; }
		}

		#endregion

	}
}
