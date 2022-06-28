using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
namespace SQT.Symphony.BusinessLogic.Configuration.DTO
{
    public class CancellationPolicyMaster : BusinessObjectBase
    {

        #region InnerClass
        public enum CancellationPolicyMasterFields
        {
            ResPolicyID,
            CompanyID,
            PropertyID,
            PolicyTitle,
            IsActive,
            IsSynch,
            SynchOn,
            UpdatedOn,
            SeqNo,
            UpdatedBy,
            CreatedBy,
            CreatedOn,
            ResType_TermID,
            PolicyNote
        }
        #endregion

        #region Data Members

        Guid _resPolicyID;
        Guid? _companyID;
        Guid? _propertyID;
        string _policyTitle;
        bool? _isActive;
        bool? _isSynch;
        DateTime? _synchOn;
        DateTime? _updatedOn;
        int _seqNo;
        Guid? _updatedBy;
        Guid? _createdBy;
        DateTime? _createdOn;
        Guid? _resType_TermID;
        string _policyNote;

        #endregion

        #region Properties

        public Guid ResPolicyID
        {
            get { return _resPolicyID; }
            set
            {
                if (_resPolicyID != value)
                {
                    _resPolicyID = value;
                    PropertyHasChanged("ResPolicyID");
                }
            }
        }

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


        public string PolicyNote
        {
            get { return _policyNote; }
            set
            {
                if (_policyNote != value)
                {
                    _policyNote = value;
                    PropertyHasChanged("PolicyNote");
                }
            }
        }

        public string PolicyTitle
        {
            get { return _policyTitle; }
            set
            {
                if (_policyTitle != value)
                {
                    _policyTitle = value;
                    PropertyHasChanged("PolicyTitle");
                }
            }
        }

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

        public DateTime? SynchOn
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

        public DateTime? UpdatedOn
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

        public int SeqNo
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

        public Guid? UpdatedBy
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

        public Guid? CreatedBy
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

        public DateTime? CreatedOn
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

        public Guid? ResType_TermID
        {
            get { return _resType_TermID; }
            set
            {
                if (_resType_TermID != value)
                {
                    _resType_TermID = value;
                    PropertyHasChanged("ResType_TermID");
                }
            }
        }


        #endregion

        #region Validation

        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ResPolicyID", "ResPolicyID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PolicyTitle", "PolicyTitle", 150));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
        }

        public override string ToString()
        {
            string objValue = string.Format(
            "ResPolicyID = {0}\n" +
            "CompanyID = {1}\n" +
            "PropertyID = {2}\n" +
            "PolicyTitle = {3}\n" +
            "IsActive = {4}\n" +
            "IsSynch = {5}\n" +
            "SynchOn = {6}\n" +
            "UpdatedOn = {7}\n" +
            "SeqNo = {8}\n" +
            "UpdatedBy = {9}\n" +
            "CreatedBy = {10}\n" +
            "CreatedOn = {11}\n" +
            "ResType_TermID = {12}\n",
            "PolicyNote={13}\n",
            ResPolicyID, CompanyID, PropertyID, PolicyTitle, IsActive, IsSynch, SynchOn, UpdatedOn, SeqNo, UpdatedBy, CreatedBy, CreatedOn, ResType_TermID, PolicyNote); return objValue;
        }

        #endregion

    }
    public class CancellationPolicyMasterKeys
    {

        #region Data Members

        Guid _resPolicyID;

        #endregion

        #region Constructor

        public CancellationPolicyMasterKeys(Guid resPolicyID)
        {
            _resPolicyID = resPolicyID;
        }

        #endregion

        #region Properties

        public Guid ResPolicyID
        {
            get { return _resPolicyID; }
        }

        #endregion

    }
}
