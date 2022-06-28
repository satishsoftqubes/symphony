using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;
namespace SQT.Symphony.BusinessLogic.IRMS.DTO
{
	[DataContract]
	public class Documents: BusinessObjectBase
	{

		#region InnerClass
		public enum DocumentsFields
		{
			DocumentID,
			CategoryID,
			TypeID,
			StatusTermID,
			DocumentName,
			Notes,
			DocumentPath,
			Extension,
			DateOfSubmission,
			AssociationID,
			AssociationType,
			CreatedOn,
			UpdatedOn,
			CreatedBy,
			UpdatedBy,
			IsActive,
			UpdateLog,
			IsSynch,
			SynchOn,
			SeqNo,
			PropertyID,
			CompanyID
		}
		#endregion

		#region Data Members

			Guid _documentID;
			Guid? _categoryID;
			Guid? _typeID;
			Guid? _statusTermID;
			string _documentName;
			string _notes;
			string _documentPath;
			string _extension;
			DateTime? _dateOfSubmission;
			Guid? _associationID;
			string _associationType;
			DateTime? _createdOn;
			DateTime? _updatedOn;
			Guid? _createdBy;
			Guid? _updatedBy;
			bool? _isActive;
			byte[] _updateLog;
			bool? _isSynch;
			DateTime? _synchOn;
			int _seqNo;
			Guid? _propertyID;
			Guid? _companyID;

		#endregion

		#region Properties

		[DataMember]
		public Guid  DocumentID
		{
			 get { return _documentID; }
			 set
			 {
				 if (_documentID != value)
				 {
					_documentID = value;
					 PropertyHasChanged("DocumentID");
				 }
			 }
		}

		[DataMember]
		public Guid?  CategoryID
		{
			 get { return _categoryID; }
			 set
			 {
				 if (_categoryID != value)
				 {
					_categoryID = value;
					 PropertyHasChanged("CategoryID");
				 }
			 }
		}

		[DataMember]
		public Guid?  TypeID
		{
			 get { return _typeID; }
			 set
			 {
				 if (_typeID != value)
				 {
					_typeID = value;
					 PropertyHasChanged("TypeID");
				 }
			 }
		}

		[DataMember]
		public Guid?  StatusTermID
		{
			 get { return _statusTermID; }
			 set
			 {
				 if (_statusTermID != value)
				 {
					_statusTermID = value;
					 PropertyHasChanged("StatusTermID");
				 }
			 }
		}

		[DataMember]
		public string  DocumentName
		{
			 get { return _documentName; }
			 set
			 {
				 if (_documentName != value)
				 {
					_documentName = value;
					 PropertyHasChanged("DocumentName");
				 }
			 }
		}

		[DataMember]
		public string  Notes
		{
			 get { return _notes; }
			 set
			 {
				 if (_notes != value)
				 {
					_notes = value;
					 PropertyHasChanged("Notes");
				 }
			 }
		}

		[DataMember]
		public string  DocumentPath
		{
			 get { return _documentPath; }
			 set
			 {
				 if (_documentPath != value)
				 {
					_documentPath = value;
					 PropertyHasChanged("DocumentPath");
				 }
			 }
		}

		[DataMember]
		public string  Extension
		{
			 get { return _extension; }
			 set
			 {
				 if (_extension != value)
				 {
					_extension = value;
					 PropertyHasChanged("Extension");
				 }
			 }
		}

		[DataMember]
		public DateTime?  DateOfSubmission
		{
			 get { return _dateOfSubmission; }
			 set
			 {
				 if (_dateOfSubmission != value)
				 {
					_dateOfSubmission = value;
					 PropertyHasChanged("DateOfSubmission");
				 }
			 }
		}

		[DataMember]
		public Guid?  AssociationID
		{
			 get { return _associationID; }
			 set
			 {
				 if (_associationID != value)
				 {
					_associationID = value;
					 PropertyHasChanged("AssociationID");
				 }
			 }
		}

		[DataMember]
		public string  AssociationType
		{
			 get { return _associationType; }
			 set
			 {
				 if (_associationType != value)
				 {
					_associationType = value;
					 PropertyHasChanged("AssociationType");
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
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("DocumentID", "DocumentID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("DocumentName", "DocumentName",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Notes", "Notes",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("DocumentPath", "DocumentPath",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Extension", "Extension",6));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("AssociationType", "AssociationType",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"DocumentID = {0}\n"+
			"CategoryID = {1}\n"+
			"TypeID = {2}\n"+
			"StatusTermID = {3}\n"+
			"DocumentName = {4}\n"+
			"Notes = {5}\n"+
			"DocumentPath = {6}\n"+
			"Extension = {7}\n"+
			"DateOfSubmission = {8}\n"+
			"AssociationID = {9}\n"+
			"AssociationType = {10}\n"+
			"CreatedOn = {11}\n"+
			"UpdatedOn = {12}\n"+
			"CreatedBy = {13}\n"+
			"UpdatedBy = {14}\n"+
			"IsActive = {15}\n"+
			"UpdateLog = {16}\n"+
			"IsSynch = {17}\n"+
			"SynchOn = {18}\n"+
			"SeqNo = {19}\n"+
			"PropertyID = {20}\n"+
			"CompanyID = {21}\n",
			DocumentID,			CategoryID,			TypeID,			StatusTermID,			DocumentName,			Notes,			DocumentPath,			Extension,			DateOfSubmission,			AssociationID,			AssociationType,			CreatedOn,			UpdatedOn,			CreatedBy,			UpdatedBy,			IsActive,			UpdateLog,			IsSynch,			SynchOn,			SeqNo,			PropertyID,			CompanyID);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class DocumentsKeys
	{

		#region Data Members

		Guid _documentID;

		#endregion

		#region Constructor

		public DocumentsKeys(Guid documentID)
		{
			 _documentID = documentID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  DocumentID
		{
			 get { return _documentID; }
		}

		#endregion

	}
}
