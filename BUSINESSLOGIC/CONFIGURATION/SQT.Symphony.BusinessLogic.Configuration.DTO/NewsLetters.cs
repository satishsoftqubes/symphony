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
	public class NewsLetters: BusinessObjectBase
	{

		#region InnerClass
		public enum NewsLettersFields
		{
			NewsLetterID,
			Title,
			Abstract,
			Details,
			PublishedOn,
			IsPublished,
			CreatedBy,
			CreatedOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			IsSynch,
			SynchOn,
			UpdateLog,
			CompanyID,
			NewsLetterFor_TermID,
			SeqNo
		}
		#endregion

		#region Data Members

			Guid _newsLetterID;
			string _title;
			string _abstract;
			string _details;
			DateTime? _publishedOn;
			bool? _isPublished;
			Guid? _createdBy;
			DateTime? _createdOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			bool? _isSynch;
			DateTime? _synchOn;
			byte[] _updateLog;
			Guid? _companyID;
			Guid? _newsLetterFor_TermID;
			int _seqNo;

		#endregion

		#region Properties

		[DataMember]
		public Guid  NewsLetterID
		{
			 get { return _newsLetterID; }
			 set
			 {
				 if (_newsLetterID != value)
				 {
					_newsLetterID = value;
					 PropertyHasChanged("NewsLetterID");
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
		public string  Abstract
		{
			 get { return _abstract; }
			 set
			 {
				 if (_abstract != value)
				 {
					_abstract = value;
					 PropertyHasChanged("Abstract");
				 }
			 }
		}

		[DataMember]
		public string  Details
		{
			 get { return _details; }
			 set
			 {
				 if (_details != value)
				 {
					_details = value;
					 PropertyHasChanged("Details");
				 }
			 }
		}

		[DataMember]
		public DateTime?  PublishedOn
		{
			 get { return _publishedOn; }
			 set
			 {
				 if (_publishedOn != value)
				 {
					_publishedOn = value;
					 PropertyHasChanged("PublishedOn");
				 }
			 }
		}

		[DataMember]
		public bool?  IsPublished
		{
			 get { return _isPublished; }
			 set
			 {
				 if (_isPublished != value)
				 {
					_isPublished = value;
					 PropertyHasChanged("IsPublished");
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
		public Guid?  NewsLetterFor_TermID
		{
			 get { return _newsLetterFor_TermID; }
			 set
			 {
				 if (_newsLetterFor_TermID != value)
				 {
					_newsLetterFor_TermID = value;
					 PropertyHasChanged("NewsLetterFor_TermID");
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


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("NewsLetterID", "NewsLetterID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Title", "Title",320));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Abstract", "Abstract",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Details", "Details",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"NewsLetterID = {0}~\n"+
			"Title = {1}~\n"+
			"Abstract = {2}~\n"+
			"Details = {3}~\n"+
			"PublishedOn = {4}~\n"+
			"IsPublished = {5}~\n"+
			"CreatedBy = {6}~\n"+
			"CreatedOn = {7}~\n"+
			"UpdatedOn = {8}~\n"+
			"UpdatedBy = {9}~\n"+
			"IsActive = {10}~\n"+
			"IsSynch = {11}~\n"+
			"SynchOn = {12}~\n"+
			"UpdateLog = {13}~\n"+
			"CompanyID = {14}~\n"+
			"NewsLetterFor_TermID = {15}~\n"+
			"SeqNo = {16}~\n",
			NewsLetterID,			Title,			Abstract,			Details,			PublishedOn,			IsPublished,			CreatedBy,			CreatedOn,			UpdatedOn,			UpdatedBy,			IsActive,			IsSynch,			SynchOn,			UpdateLog,			CompanyID,			NewsLetterFor_TermID,			SeqNo);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class NewsLettersKeys
	{

		#region Data Members

		Guid _newsLetterID;

		#endregion

		#region Constructor

		public NewsLettersKeys(Guid newsLetterID)
		{
			 _newsLetterID = newsLetterID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  NewsLetterID
		{
			 get { return _newsLetterID; }
		}

		#endregion

	}
}
