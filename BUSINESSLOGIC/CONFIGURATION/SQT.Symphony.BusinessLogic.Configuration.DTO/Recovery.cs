using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
namespace SQT.Symphony.BusinessLogic.Configuration.DTO
{
    public class Recovery : BusinessObjectBase
    {

        #region InnerClass
        public enum RecoveryFields
        {
            RecoveryID,
            Title,
            Description,
            CreatedBy,
            CreatedOn,
            UpdatedBy,
            UpdatedOn,
            IsActive,
            IsSynch,
            SynchOn,
            SeqNo,
            PropertyID,
            CompanyID,
            Amount,
            CategotyID,
            AcctID
        }
        #endregion

        #region Data Members

        Guid _recoveryID;
        string _title;
        string _description;
        Guid? _createdBy;
        DateTime? _createdOn;
        Guid? _updatedBy;
        DateTime? _updatedOn;
        bool? _isActive;
        bool? _isSynch;
        DateTime? _synchOn;
        int _seqNo;
        Guid? _propertyID;
        Guid? _companyID;
        decimal? _amount;
        Guid? _categoryID;
        Guid? _AcctID;
        #endregion

        #region Properties

        public Guid RecoveryID
        {
            get { return _recoveryID; }
            set
            {
                if (_recoveryID != value)
                {
                    _recoveryID = value;
                    PropertyHasChanged("RecoveryID");
                }
            }
        }

        public string Title
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

        public Guid? CategoryID
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
        public Guid? AcctID
        {
            get { return _AcctID; }
            set
            {
                if (_AcctID != value)
                {
                    _AcctID= value;
                    PropertyHasChanged("AcctID");
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

        public decimal? Amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    PropertyHasChanged("Amount");
                }
            }
        }


        #endregion

        #region Validation

        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("RecoveryID", "RecoveryID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Title", "Title", 250));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Description", "Description", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
        }

        public override string ToString()
        {
            string objValue = string.Format(
            "RecoveryID = {0}\n" +
            "Title = {1}\n" +
            "Description = {2}\n" +
            "CreatedBy = {3}\n" +
            "CreatedOn = {4}\n" +
            "UpdatedBy = {5}\n" +
            "UpdatedOn = {6}\n" +
            "IsActive = {7}\n" +
            "IsSynch = {8}\n" +
            "SynchOn = {9}\n" +
            "SeqNo = {10}\n" +
            "PropertyID = {11}\n" +
            "CompanyID = {12}\n" +
            "Amount = {13}\n"+
            "CategoryID={14}\n"+
            "AcctID={14}\n",

            RecoveryID, Title, Description, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, IsActive, IsSynch, SynchOn, SeqNo, PropertyID, CompanyID, Amount, CategoryID, AcctID ); return objValue;
        }

        #endregion

    }
    public class RecoveryKeys
    {

        #region Data Members

        Guid _recoveryID;

        #endregion

        #region Constructor

        public RecoveryKeys(Guid recoveryID)
        {
            _recoveryID = recoveryID;
        }

        #endregion

        #region Properties

        public Guid RecoveryID
        {
            get { return _recoveryID; }
        }

        #endregion

    }
}
