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
	public class AddOns: BusinessObjectBase
	{

		#region InnerClass
		public enum AddOnsFields
		{
			AddOnID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			AddOnTitle,
			AddOnImage,
			AddOnDetail,
			PostingAcctID,
			AvailablePOSPointID,
			BasePrice,
			Chargeper_TermID,
			PostingFreq_TermID,
			IsAvailableOnIRS
		}
		#endregion

		#region Data Members

			Guid _addOnID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			string _addOnTitle;
			string _addOnImage;
			string _addOnDetail;
			Guid? _postingAcctID;
			Guid? _availablePOSPointID;
			decimal? _basePrice;
			Guid? _chargeper_TermID;
			Guid? _postingFreq_TermID;
			bool? _isAvailableOnIRS;

		#endregion

		#region Properties

		[DataMember]
		public Guid  AddOnID
		{
			 get { return _addOnID; }
			 set
			 {
				 if (_addOnID != value)
				 {
					_addOnID = value;
					 PropertyHasChanged("AddOnID");
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
		public string  AddOnTitle
		{
			 get { return _addOnTitle; }
			 set
			 {
				 if (_addOnTitle != value)
				 {
					_addOnTitle = value;
					 PropertyHasChanged("AddOnTitle");
				 }
			 }
		}

		[DataMember]
		public string  AddOnImage
		{
			 get { return _addOnImage; }
			 set
			 {
				 if (_addOnImage != value)
				 {
					_addOnImage = value;
					 PropertyHasChanged("AddOnImage");
				 }
			 }
		}

		[DataMember]
		public string  AddOnDetail
		{
			 get { return _addOnDetail; }
			 set
			 {
				 if (_addOnDetail != value)
				 {
					_addOnDetail = value;
					 PropertyHasChanged("AddOnDetail");
				 }
			 }
		}

		[DataMember]
		public Guid?  PostingAcctID
		{
			 get { return _postingAcctID; }
			 set
			 {
				 if (_postingAcctID != value)
				 {
					_postingAcctID = value;
					 PropertyHasChanged("PostingAcctID");
				 }
			 }
		}

		[DataMember]
		public Guid?  AvailablePOSPointID
		{
			 get { return _availablePOSPointID; }
			 set
			 {
				 if (_availablePOSPointID != value)
				 {
					_availablePOSPointID = value;
					 PropertyHasChanged("AvailablePOSPointID");
				 }
			 }
		}

		[DataMember]
		public decimal?  BasePrice
		{
			 get { return _basePrice; }
			 set
			 {
				 if (_basePrice != value)
				 {
					_basePrice = value;
					 PropertyHasChanged("BasePrice");
				 }
			 }
		}

		[DataMember]
		public Guid?  Chargeper_TermID
		{
			 get { return _chargeper_TermID; }
			 set
			 {
				 if (_chargeper_TermID != value)
				 {
					_chargeper_TermID = value;
					 PropertyHasChanged("Chargeper_TermID");
				 }
			 }
		}

		[DataMember]
		public Guid?  PostingFreq_TermID
		{
			 get { return _postingFreq_TermID; }
			 set
			 {
				 if (_postingFreq_TermID != value)
				 {
					_postingFreq_TermID = value;
					 PropertyHasChanged("PostingFreq_TermID");
				 }
			 }
		}

		[DataMember]
		public bool?  IsAvailableOnIRS
		{
			 get { return _isAvailableOnIRS; }
			 set
			 {
				 if (_isAvailableOnIRS != value)
				 {
					_isAvailableOnIRS = value;
					 PropertyHasChanged("IsAvailableOnIRS");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("AddOnID", "AddOnID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("AddOnTitle", "AddOnTitle",120));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("AddOnImage", "AddOnImage",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("AddOnDetail", "AddOnDetail",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"AddOnID = {0}~\n"+
			"PropertyID = {1}~\n"+
			"CompanyID = {2}~\n"+
			"SeqNo = {3}~\n"+
			"IsSynch = {4}~\n"+
			"SynchOn = {5}~\n"+
			"UpdatedOn = {6}~\n"+
			"UpdatedBy = {7}~\n"+
			"IsActive = {8}~\n"+
			"AddOnTitle = {9}~\n"+
			"AddOnImage = {10}~\n"+
			"AddOnDetail = {11}~\n"+
			"PostingAcctID = {12}~\n"+
			"AvailablePOSPointID = {13}~\n"+
			"BasePrice = {14}~\n"+
			"Chargeper_TermID = {15}~\n"+
			"PostingFreq_TermID = {16}~\n"+
			"IsAvailableOnIRS = {17}~\n",
			AddOnID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			AddOnTitle,			AddOnImage,			AddOnDetail,			PostingAcctID,			AvailablePOSPointID,			BasePrice,			Chargeper_TermID,			PostingFreq_TermID,			IsAvailableOnIRS);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class AddOnsKeys
	{

		#region Data Members

		Guid _addOnID;

		#endregion

		#region Constructor

		public AddOnsKeys(Guid addOnID)
		{
			 _addOnID = addOnID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  AddOnID
		{
			 get { return _addOnID; }
		}

		#endregion

	}
}
