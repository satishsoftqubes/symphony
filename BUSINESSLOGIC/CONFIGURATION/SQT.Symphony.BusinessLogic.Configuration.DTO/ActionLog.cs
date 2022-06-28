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
	public class ActionLog: BusinessObjectBase
	{

		#region InnerClass
		public enum ActionLogFields
		{
			ActionLogID,
			ActionPerformedBy,
			ActionPerformedOn,
			ActionObject,
			ActionType,
			ObjectOldValue,
			ObjectNewValue,
			LogInLogID,
			AutherizedBy,
			AutherizerOn,
			IsSynch,
			SynchOn,
            CompanyID,
            PropertyID,
            Description
		}
		#endregion

		#region Data Members

			Guid _actionLogID;
			Guid? _actionPerformedBy;
			DateTime? _actionPerformedOn;
			string _actionObject;
			string _actionType;
			string _objectOldValue;
			string _objectNewValue;
			Guid? _logInLogID;
			Guid? _autherizedBy;
			DateTime? _autherizerOn;
			bool? _isSynch;
			DateTime? _synchOn;
            Guid? _companyID;
            Guid? _propertyID;
            string _description;

		#endregion

		#region Properties

		[DataMember]
		public Guid  ActionLogID
		{
			 get { return _actionLogID; }
			 set
			 {
				 if (_actionLogID != value)
				 {
					_actionLogID = value;
					 PropertyHasChanged("ActionLogID");
				 }
			 }
		}

		[DataMember]
		public Guid?  ActionPerformedBy
		{
			 get { return _actionPerformedBy; }
			 set
			 {
				 if (_actionPerformedBy != value)
				 {
					_actionPerformedBy = value;
					 PropertyHasChanged("ActionPerformedBy");
				 }
			 }
		}

		[DataMember]
		public DateTime?  ActionPerformedOn
		{
			 get { return _actionPerformedOn; }
			 set
			 {
				 if (_actionPerformedOn != value)
				 {
					_actionPerformedOn = value;
					 PropertyHasChanged("ActionPerformedOn");
				 }
			 }
		}

		[DataMember]
		public string  ActionObject
		{
			 get { return _actionObject; }
			 set
			 {
				 if (_actionObject != value)
				 {
					_actionObject = value;
					 PropertyHasChanged("ActionObject");
				 }
			 }
		}

		[DataMember]
		public string  ActionType
		{
			 get { return _actionType; }
			 set
			 {
				 if (_actionType != value)
				 {
					_actionType = value;
					 PropertyHasChanged("ActionType");
				 }
			 }
		}

		[DataMember]
		public string  ObjectOldValue
		{
			 get { return _objectOldValue; }
			 set
			 {
				 if (_objectOldValue != value)
				 {
					_objectOldValue = value;
					 PropertyHasChanged("ObjectOldValue");
				 }
			 }
		}

		[DataMember]
		public string  ObjectNewValue
		{
			 get { return _objectNewValue; }
			 set
			 {
				 if (_objectNewValue != value)
				 {
					_objectNewValue = value;
					 PropertyHasChanged("ObjectNewValue");
				 }
			 }
		}

		[DataMember]
		public Guid?  LogInLogID
		{
			 get { return _logInLogID; }
			 set
			 {
				 if (_logInLogID != value)
				 {
					_logInLogID = value;
					 PropertyHasChanged("LogInLogID");
				 }
			 }
		}

		[DataMember]
		public Guid?  AutherizedBy
		{
			 get { return _autherizedBy; }
			 set
			 {
				 if (_autherizedBy != value)
				 {
					_autherizedBy = value;
					 PropertyHasChanged("AutherizedBy");
				 }
			 }
		}

		[DataMember]
		public DateTime?  AutherizerOn
		{
			 get { return _autherizerOn; }
			 set
			 {
				 if (_autherizerOn != value)
				 {
					_autherizerOn = value;
					 PropertyHasChanged("AutherizerOn");
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
		public Guid? CompanyID
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
		public Guid? PropertyID
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
        public string Description
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

		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ActionLogID", "ActionLogID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ActionObject", "ActionObject",103));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ActionType", "ActionType",65));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ObjectOldValue", "ObjectOldValue",2147483647));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ObjectNewValue", "ObjectNewValue",2147483647));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ActionLogID = {0}~\n"+
			"ActionPerformedBy = {1}~\n"+
			"ActionPerformedOn = {2}~\n"+
			"ActionObject = {3}~\n"+
			"ActionType = {4}~\n"+
			"ObjectOldValue = {5}~\n"+
			"ObjectNewValue = {6}~\n"+
			"LogInLogID = {7}~\n"+
			"AutherizedBy = {8}~\n"+
			"AutherizerOn = {9}~\n"+
			"IsSynch = {10}~\n"+
			"SynchOn = {11}~\n"+
            "CompanyID = {12}~\n"+
            "PropertyID = {13}~\n" +
            "Description = {14}~\n",
            ActionLogID, ActionPerformedBy, ActionPerformedOn, ActionObject, ActionType, ObjectOldValue, ObjectNewValue, LogInLogID, AutherizedBy, AutherizerOn, IsSynch, SynchOn, CompanyID, PropertyID, Description); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ActionLogKeys
	{

		#region Data Members

		Guid _actionLogID;

		#endregion

		#region Constructor

		public ActionLogKeys(Guid actionLogID)
		{
			 _actionLogID = actionLogID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ActionLogID
		{
			 get { return _actionLogID; }
		}

		#endregion

	}
}