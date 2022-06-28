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
	public class Transcript: BusinessObjectBase
	{

		#region InnerClass
		public enum TranscriptFields
		{
			TranscriptID,
			Title,
			Description,
			TranscriptType,
			ModulName,
			CreatedBy,
			CreatedOn,
			UpdatedBy,
			UpdatedOn,
			IsActive,
			IsSynch,
			SynchOn,
			SeqNo,
			PropertyID,
			CompanyID
		}
		#endregion

		#region Data Members

			Guid _transcriptID;
			string _title;
			string _description;
			string _transcriptType;
			string _modulName;
			Guid? _createdBy;
			DateTime? _createdOn;
			Guid? _updatedBy;
			DateTime? _updatedOn;
			bool? _isActive;
			bool? _isSynch;
			DateTime? _synchOn;
			int? _seqNo;
			Guid? _propertyID;
			Guid? _companyID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  TranscriptID
		{
			 get { return _transcriptID; }
			 set
			 {
				 if (_transcriptID != value)
				 {
					_transcriptID = value;
					 PropertyHasChanged("TranscriptID");
				 }
			 }
		}

		[DataMember]
		public string  Title
		{
			 get { return _title; }
			 set
			 {
				 if (_title != value)
				 {
					_title = value;
					 PropertyHasChanged("Title");
				 }
			 }
		}

		[DataMember]
		public string  Description
		{
			 get { return _description; }
			 set
			 {
				 if (_description != value)
				 {
					_description = value;
					 PropertyHasChanged("Description");
				 }
			 }
		}

		[DataMember]
		public string  TranscriptType
		{
			 get { return _transcriptType; }
			 set
			 {
				 if (_transcriptType != value)
				 {
					_transcriptType = value;
					 PropertyHasChanged("TranscriptType");
				 }
			 }
		}

		[DataMember]
		public string  ModulName
		{
			 get { return _modulName; }
			 set
			 {
				 if (_modulName != value)
				 {
					_modulName = value;
					 PropertyHasChanged("ModulName");
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
		public int?  SeqNo
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("TranscriptID", "TranscriptID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Title", "Title",50));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Description", "Description",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("TranscriptType", "TranscriptType",50));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ModulName", "ModulName",50));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"TranscriptID = {0}\n"+
			"Title = {1}\n"+
			"Description = {2}\n"+
			"TranscriptType = {3}\n"+
			"ModulName = {4}\n"+
			"CreatedBy = {5}\n"+
			"CreatedOn = {6}\n"+
			"UpdatedBy = {7}\n"+
			"UpdatedOn = {8}\n"+
			"IsActive = {9}\n"+
			"IsSynch = {10}\n"+
			"SynchOn = {11}\n"+
			"SeqNo = {12}\n"+
			"PropertyID = {13}\n"+
			"CompanyID = {14}\n",
			TranscriptID,			Title,			Description,			TranscriptType,			ModulName,			CreatedBy,			CreatedOn,			UpdatedBy,			UpdatedOn,			IsActive,			IsSynch,			SynchOn,			SeqNo,			PropertyID,			CompanyID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class TranscriptKeys
	{

		#region Data Members

		Guid _transcriptID;

		#endregion

		#region Constructor

		public TranscriptKeys(Guid transcriptID)
		{
			 _transcriptID = transcriptID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  TranscriptID
		{
			 get { return _transcriptID; }
		}

		#endregion

	}
}
