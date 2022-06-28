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
	public class EMailTemplates: BusinessObjectBase
	{

		#region InnerClass
		public enum EMailTemplatesFields
		{
			EmailTemplateID,
			EMailConfigID,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
			Title,
			ActionType_TermID,
			Header,
			Footer,
			Body
		}
		#endregion

		#region Data Members

			Guid _emailTemplateID;
			Guid? _eMailConfigID;
			Guid? _propertyID;
			Guid? _companyID;
			int _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
			string _title;
			Guid? _actionType_TermID;
			string _header;
			string _footer;
			string _body;

		#endregion

		#region Properties

		[DataMember]
		public Guid  EmailTemplateID
		{
			 get { return _emailTemplateID; }
			 set
			 {
				 if (_emailTemplateID != value)
				 {
					_emailTemplateID = value;
					 PropertyHasChanged("EmailTemplateID");
				 }
			 }
		}

		[DataMember]
		public Guid?  EMailConfigID
		{
			 get { return _eMailConfigID; }
			 set
			 {
				 if (_eMailConfigID != value)
				 {
					_eMailConfigID = value;
					 PropertyHasChanged("EMailConfigID");
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
		public Guid?  ActionType_TermID
		{
			 get { return _actionType_TermID; }
			 set
			 {
				 if (_actionType_TermID != value)
				 {
					_actionType_TermID = value;
					 PropertyHasChanged("ActionType_TermID");
				 }
			 }
		}

		[DataMember]
		public string  Header
		{
			 get { return _header; }
			 set
			 {
				 if (_header != value)
				 {
					_header = value;
					 PropertyHasChanged("Header");
				 }
			 }
		}

		[DataMember]
		public string  Footer
		{
			 get { return _footer; }
			 set
			 {
				 if (_footer != value)
				 {
					_footer = value;
					 PropertyHasChanged("Footer");
				 }
			 }
		}

		[DataMember]
		public string  Body
		{
			 get { return _body; }
			 set
			 {
				 if (_body != value)
				 {
					_body = value;
					 PropertyHasChanged("Body");
				 }
			 }
		}


		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("EmailTemplateID", "EmailTemplateID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Title", "Title",150));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Header", "Header",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Footer", "Footer",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Body", "Body",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"EmailTemplateID = {0}~\n"+
			"EMailConfigID = {1}~\n"+
			"PropertyID = {2}~\n"+
			"CompanyID = {3}~\n"+
			"SeqNo = {4}~\n"+
			"IsSynch = {5}~\n"+
			"SynchOn = {6}~\n"+
			"UpdatedOn = {7}~\n"+
			"UpdatedBy = {8}~\n"+
			"IsActive = {9}~\n"+
			"Title = {10}~\n"+
			"ActionType_TermID = {11}~\n"+
			"Header = {12}~\n"+
			"Footer = {13}~\n"+
			"Body = {14}~\n",
			EmailTemplateID,			EMailConfigID,			PropertyID,			CompanyID,			SeqNo,			IsSynch,			SynchOn,			UpdatedOn,			UpdatedBy,			IsActive,			Title,			ActionType_TermID,			Header,			Footer,			Body);			return objValue;
		}

		#endregion

	}
	[DataContract]
	public class EMailTemplatesKeys
	{

		#region Data Members

		Guid _emailTemplateID;

		#endregion

		#region Constructor

		public EMailTemplatesKeys(Guid emailTemplateID)
		{
			 _emailTemplateID = emailTemplateID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  EmailTemplateID
		{
			 get { return _emailTemplateID; }
		}

		#endregion

	}
}
