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
    public class ProjectTerm : BusinessObjectBase
    {

        #region InnerClass
        public enum ProjectTermFields
        {
            TermID,
            CompanyID,
            Category,
            Term,
            TermCode,
            ForeColor,
            BackColor,
            Thumb,
            SeqNo,
            IsActive,
            LastUpdatedOn,
            LastUpdatedBy,
            IsSynch,
            UpdateLog,
            PropertyID,
            TermValue,
            HardCodeTermID,
            DisplayTerm,
            IsDefault,
            Description,
            SymphonyValue,
        }

        #endregion

        #region Data Members

        Guid _termID;
        Guid? _companyID;
        string _category;
        string _term;
        string _termCode;
        string _foreColor;
        string _backColor;
        string _thumb;
        int? _seqNo;
        bool? _isActive;
        DateTime? _lastUpdatedOn;
        Guid? _lastUpdatedBy;
        bool? _isSynch;
        byte[] _updateLog;
        Guid? _propertyID;
        string _termValue;
        Guid? _hardCodeTermID;
        string _displayTerm;
        bool? _isDefault;
        string _description;
        int? _symphonyValue;
        #endregion

        #region Properties

        [DataMember]
        public Guid TermID
        {
            get { return _termID; }
            set
            {
                if (_termID != value)
                {
                    _termID = value;
                    PropertyHasChanged("TermID");
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

        public string TermValue
        {
            get { return _termValue; }
            set
            {
                if (_termValue != value)
                {
                    _termValue = value;
                    PropertyHasChanged("TermValue");
                }
            }
        }

        [DataMember]
        public Guid? HardCodeTermID
        {
            get { return _hardCodeTermID; }
            set
            {
                if (_hardCodeTermID != value)
                {
                    _hardCodeTermID = value;
                    PropertyHasChanged("HardCodeTermID");
                }
            }
        }

        [DataMember]
        public string DisplayTerm
        {
            get { return _displayTerm; }
            set
            {
                if (_displayTerm != value)
                {
                    _displayTerm = value;
                    PropertyHasChanged("DisplayTerm");
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
        public string Category
        {
            get { return _category; }
            set
            {
                if (_category != value)
                {
                    _category = value;
                    PropertyHasChanged("Category");
                }
            }
        }

        [DataMember]
        public string Term
        {
            get { return _term; }
            set
            {
                if (_term != value)
                {
                    _term = value;
                    PropertyHasChanged("Term");
                }
            }
        }

        [DataMember]
        public string TermCode
        {
            get { return _termCode; }
            set
            {
                if (_termCode != value)
                {
                    _termCode = value;
                    PropertyHasChanged("TermCode");
                }
            }
        }

        [DataMember]
        public string ForeColor
        {
            get { return _foreColor; }
            set
            {
                if (_foreColor != value)
                {
                    _foreColor = value;
                    PropertyHasChanged("ForeColor");
                }
            }
        }

        [DataMember]
        public string BackColor
        {
            get { return _backColor; }
            set
            {
                if (_backColor != value)
                {
                    _backColor = value;
                    PropertyHasChanged("BackColor");
                }
            }
        }

        [DataMember]
        public string Thumb
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
        public DateTime? LastUpdatedOn
        {
            get { return _lastUpdatedOn; }
            set
            {
                if (_lastUpdatedOn != value)
                {
                    _lastUpdatedOn = value;
                    PropertyHasChanged("LastUpdatedOn");
                }
            }
        }

        [DataMember]
        public Guid? LastUpdatedBy
        {
            get { return _lastUpdatedBy; }
            set
            {
                if (_lastUpdatedBy != value)
                {
                    _lastUpdatedBy = value;
                    PropertyHasChanged("LastUpdatedBy");
                }
            }
        }

        [DataMember]
        public bool? IsSynch
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
        public bool? IsDefault
        {
            get { return _isDefault; }
            set
            {
                if (_isDefault != value)
                {
                    _isDefault = value;
                    PropertyHasChanged("IsDefault");
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
        public int? SymphonyValue
        {
            get { return _symphonyValue; }
            set
            {
                if (_symphonyValue != value)
                {
                    _symphonyValue = value;
                    PropertyHasChanged("SymphonyValue");
                }
            }
        }

        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("TermID", "TermID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Category", "Category", 67));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Term", "Term", 137));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("TermCode", "TermCode", 7));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ForeColor", "ForeColor", 180));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("BackColor", "BackColor", 180));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Thumb", "Thumb", 2147483647));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "TermID = {0}~\n" +
            "CompanyID = {1}~\n" +
            "Category = {2}~\n" +
            "Term = {3}~\n" +
            "TermCode = {4}~\n" +
            "ForeColor = {5}~\n" +
            "BackColor = {6}~\n" +
            "Thumb = {7}~\n" +
            "SeqNo = {8}~\n" +
            "IsActive = {9}~\n" +
            "LastUpdatedOn = {10}~\n" +
            "LastUpdatedBy = {11}~\n" +
            "IsSynch = {12}~\n" +
            "UpdateLog = {13}~\n" +
            "DisplayTerm = {14}~\n" +
            "IsDefault ={15}~\n"+
            "Description={16}~\n"+
            "SymphonyValue={17}~\n",
            TermID, CompanyID, Category, Term, TermCode, ForeColor, BackColor, Thumb, SeqNo, IsActive, LastUpdatedOn, LastUpdatedBy, IsSynch, UpdateLog, DisplayTerm, IsDefault, Description,SymphonyValue); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class ProjectTermKeys
    {

        #region Data Members

        Guid _termID;

        #endregion

        #region Constructor

        public ProjectTermKeys(Guid termID)
        {
            _termID = termID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid TermID
        {
            get { return _termID; }
        }

        #endregion

    }
}
