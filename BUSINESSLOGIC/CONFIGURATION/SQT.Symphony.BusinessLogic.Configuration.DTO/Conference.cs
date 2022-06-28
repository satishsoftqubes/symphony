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
	public class Conference: BusinessObjectBase
	{

		#region InnerClass
		public enum ConferenceFields
		{
			ConferenceID,
			ConferenceCode,
			ConferenceName,
			RackRate,
			CreditLimit,
			Height,
			Width,
			Length,
			ConferenceImage,
			KeyNo,
			ExtensioNo,
			ConferenceDetails,
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

			Guid _conferenceID;
			string _conferenceCode;
			string _conferenceName;
			decimal? _rackRate;
			decimal? _creditLimit;
			decimal? _height;
			decimal? _width;
			decimal? _length;
			string _conferenceImage;
			string _keyNo;
			string _extensioNo;
			string _conferenceDetails;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;

		#endregion

		#region Properties

		[DataMember]
		public Guid  ConferenceID
		{
			 get { return _conferenceID; }
			 set
			 {
				 if (_conferenceID != value)
				 {
					_conferenceID = value;
					 PropertyHasChanged("ConferenceID");
				 }
			 }
		}

		[DataMember]
		public string  ConferenceCode
		{
			 get { return _conferenceCode; }
			 set
			 {
				 if (_conferenceCode != value)
				 {
					_conferenceCode = value;
					 PropertyHasChanged("ConferenceCode");
				 }
			 }
		}

		[DataMember]
		public string  ConferenceName
		{
			 get { return _conferenceName; }
			 set
			 {
				 if (_conferenceName != value)
				 {
					_conferenceName = value;
					 PropertyHasChanged("ConferenceName");
				 }
			 }
		}

		[DataMember]
		public decimal?  RackRate
		{
			 get { return _rackRate; }
			 set
			 {
				 if (_rackRate != value)
				 {
					_rackRate = value;
					 PropertyHasChanged("RackRate");
				 }
			 }
		}

		[DataMember]
		public decimal?  CreditLimit
		{
			 get { return _creditLimit; }
			 set
			 {
				 if (_creditLimit != value)
				 {
					_creditLimit = value;
					 PropertyHasChanged("CreditLimit");
				 }
			 }
		}

		[DataMember]
		public decimal?  Height
		{
			 get { return _height; }
			 set
			 {
				 if (_height != value)
				 {
					_height = value;
					 PropertyHasChanged("Height");
				 }
			 }
		}

		[DataMember]
		public decimal?  Width
		{
			 get { return _width; }
			 set
			 {
				 if (_width != value)
				 {
					_width = value;
					 PropertyHasChanged("Width");
				 }
			 }
		}

		[DataMember]
		public decimal?  Length
		{
			 get { return _length; }
			 set
			 {
				 if (_length != value)
				 {
					_length = value;
					 PropertyHasChanged("Length");
				 }
			 }
		}

		[DataMember]
		public string  ConferenceImage
		{
			 get { return _conferenceImage; }
			 set
			 {
				 if (_conferenceImage != value)
				 {
					_conferenceImage = value;
					 PropertyHasChanged("ConferenceImage");
				 }
			 }
		}

		[DataMember]
		public string  KeyNo
		{
			 get { return _keyNo; }
			 set
			 {
				 if (_keyNo != value)
				 {
					_keyNo = value;
					 PropertyHasChanged("KeyNo");
				 }
			 }
		}

		[DataMember]
		public string  ExtensioNo
		{
			 get { return _extensioNo; }
			 set
			 {
				 if (_extensioNo != value)
				 {
					_extensioNo = value;
					 PropertyHasChanged("ExtensioNo");
				 }
			 }
		}

		[DataMember]
		public string  ConferenceDetails
		{
			 get { return _conferenceDetails; }
			 set
			 {
				 if (_conferenceDetails != value)
				 {
					_conferenceDetails = value;
					 PropertyHasChanged("ConferenceDetails");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ConferenceID", "ConferenceID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ConferenceCode", "ConferenceCode",5));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ConferenceName", "ConferenceName",120));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ConferenceImage", "ConferenceImage",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("KeyNo", "KeyNo",10));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ExtensioNo", "ExtensioNo",10));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ConferenceDetails", "ConferenceDetails",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ConferenceID = {0}~\n"+
			"ConferenceCode = {1}~\n"+
			"ConferenceName = {2}~\n"+
			"RackRate = {3}~\n"+
			"CreditLimit = {4}~\n"+
			"Height = {5}~\n"+
			"Width = {6}~\n"+
			"Length = {7}~\n"+
			"ConferenceImage = {8}~\n"+
			"KeyNo = {9}~\n"+
			"ExtensioNo = {10}~\n"+
			"ConferenceDetails = {11}~\n"+
			"PropertyID = {12}~\n"+
			"CompanyID = {13}~\n"+
			"SeqNo = {14}~\n"+
			"IsSynch = {15}~\n"+
			"SynchOn = {16}~\n"+
			"UpdatedOn = {17}~\n"+
			"UpdatedBy = {18}~\n"+
			"IsActive = {19}~\n",
			ConferenceID,			ConferenceCode,			ConferenceName,			RackRate,			CreditLimit,			Height,			Width,			Length,			ConferenceImage,			KeyNo,			ExtensioNo,			ConferenceDetails,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ConferenceKeys
	{

		#region Data Members

		Guid _conferenceID;

		#endregion

		#region Constructor

		public ConferenceKeys(Guid conferenceID)
		{
			 _conferenceID = conferenceID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ConferenceID
		{
			 get { return _conferenceID; }
		}

		#endregion

	}
}
