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
    public class ControlNumber : BusinessObjectBase
    {

        #region InnerClass
        public enum ControlNumberFields
        {
            ControlNumberID,
            PropertyID,
            SeqNo,
            IdentifyName,
            Postfix,
            ControlNumbers,
            Prefix,
            IsActive,
            UpdateLog,
            CompanyID
        }
        #endregion

        #region Data Members

        Guid _controlNumberID;
        Guid? _propertyID;
        int? _seqNo;
        string _identifyName;
        string _postfix;
        string _controlNumbers;
        string _prefix;
        bool? _isActive;
        byte[] _updateLog;
        Guid? _companyID;

        #endregion

        #region Properties

        [DataMember]
        public Guid ControlNumberID
        {
            get { return _controlNumberID; }
            set
            {
                if (_controlNumberID != value)
                {
                    _controlNumberID = value;
                    PropertyHasChanged("ControlNumberID");
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
        public int? SeqNo
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
        public string IdentifyName
        {
            get { return _identifyName; }
            set
            {
                if (_identifyName != value)
                {
                    _identifyName = value;
                    PropertyHasChanged("IdentifyName");
                }
            }
        }

        [DataMember]
        public string Postfix
        {
            get { return _postfix; }
            set
            {
                if (_postfix != value)
                {
                    _postfix = value;
                    PropertyHasChanged("Postfix");
                }
            }
        }

        [DataMember]
        public string ControlNumbers
        {
            get { return _controlNumbers; }
            set
            {
                if (_controlNumbers != value)
                {
                    _controlNumbers = value;
                    PropertyHasChanged("ControlNumbers");
                }
            }
        }

        [DataMember]
        public string Prefix
        {
            get { return _prefix; }
            set
            {
                if (_prefix != value)
                {
                    _prefix = value;
                    PropertyHasChanged("Prefix");
                }
            }
        }

        [DataMember]
        public bool? IsActive
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
        public byte[] UpdateLog
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


        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ControlNumberID", "ControlNumberID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("IdentifyName", "IdentifyName", 35));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Postfix", "Postfix", 5));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ControlNumbers", "ControlNumbers", 25));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Prefix", "Prefix", 15));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "ControlNumberID = {0}~\n" +
            "PropertyID = {1}~\n" +
            "SeqNo = {2}~\n" +
            "IdentifyName = {3}~\n" +
            "Postfix = {4}~\n" +
            "ControlNumbers = {5}~\n" +
            "Prefix = {6}~\n" +
            "IsActive = {7}~\n" +
            "UpdateLog = {8}~\n" +
            "CompanyID = {9}~\n",
            ControlNumberID, PropertyID, SeqNo, IdentifyName, Postfix, ControlNumbers, Prefix, IsActive, UpdateLog, CompanyID); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class ControlNumberKeys
    {

        #region Data Members

        Guid _controlNumberID;

        #endregion

        #region Constructor

        public ControlNumberKeys(Guid controlNumberID)
        {
            _controlNumberID = controlNumberID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid ControlNumberID
        {
            get { return _controlNumberID; }
        }

        #endregion

    }
}
