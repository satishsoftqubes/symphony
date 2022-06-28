using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;
namespace SQT.Symphony.BusinessLogic.FrontDesk.DTO
{
    [DataContract]
    public class GuestComplaint : BusinessObjectBase
    {

        #region InnerClass
        public enum GuestComplaintFields
        {
            GuestComplaintID,
            GuestID,
            Department,
            NatureOfComplaint,
            ComplaintDescription,
            DateOfComplain,
            CompainTime,
            PropertyID,
            CompanyID,
            SeqNo,
            IsSynch,
            SynchOn,
            UpdatedOn,
            UpdatedBy,
            CreatedOn,
            CreatedBy,
            IsActive,
            ComplaintBy
        }
        #endregion

        #region Data Members

        Guid _guestComplaintID;
        Guid? _guestID;
        Guid? _department;
        string _natureOfComplaint;
        string _complaintDescription;
        DateTime? _dateOfComplain;
        TimeSpan? _compainTime;
        Guid? _propertyID;
        Guid? _companyID;
        int _seqNo;
        bool? _isSynch;
        DateTime? _synchOn;
        DateTime? _updatedOn;
        Guid? _updatedBy;
        DateTime? _createdOn;
        Guid? _createdBy;
        bool? _isActive;
        string _complaintBy;

        #endregion

        #region Properties

        [DataMember]
        public Guid GuestComplaintID
        {
            get { return _guestComplaintID; }
            set
            {
                if (_guestComplaintID != value)
                {
                    _guestComplaintID = value;
                    PropertyHasChanged("GuestComplaintID");
                }
            }
        }

        [DataMember]
        public Guid? GuestID
        {
            get { return _guestID; }
            set
            {
                if (_guestID != value)
                {
                    _guestID = value;
                    PropertyHasChanged("GuestID");
                }
            }
        }

        [DataMember]
        public Guid? Department
        {
            get { return _department; }
            set
            {
                if (_department != value)
                {
                    _department = value;
                    PropertyHasChanged("Department");
                }
            }
        }

        [DataMember]
        public string NatureOfComplaint
        {
            get { return _natureOfComplaint; }
            set
            {
                if (_natureOfComplaint != value)
                {
                    _natureOfComplaint = value;
                    PropertyHasChanged("NatureOfComplaint");
                }
            }
        }

        [DataMember]
        public string ComplaintBy
        {
            get { return _complaintBy; }
            set
            {
                if (_complaintBy != value)
                {
                    _complaintBy = value;
                    PropertyHasChanged("ComplaintBy");
                }
            }
        }

        [DataMember]
        public string ComplaintDescription
        {
            get { return _complaintDescription; }
            set
            {
                if (_complaintDescription != value)
                {
                    _complaintDescription = value;
                    PropertyHasChanged("ComplaintDescription");
                }
            }
        }

        [DataMember]
        public DateTime? DateOfComplain
        {
            get { return _dateOfComplain; }
            set
            {
                if (_dateOfComplain != value)
                {
                    _dateOfComplain = value;
                    PropertyHasChanged("DateOfComplain");
                }
            }
        }

        [DataMember]
        public TimeSpan? CompainTime
        {
            get { return _compainTime; }
            set
            {
                if (_compainTime != value)
                {
                    _compainTime = value;
                    PropertyHasChanged("CompainTime");
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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


        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("GuestComplaintID", "GuestComplaintID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("NatureOfComplaint", "NatureOfComplaint", 120));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ComplaintDescription", "ComplaintDescription", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "GuestComplaintID = {0}\n" +
            "GuestID = {1}\n" +
            "Department = {2}\n" +
            "NatureOfComplaint = {3}\n" +
            "ComplaintDescription = {4}\n" +
            "DateOfComplain = {5}\n" +
            "CompainTime = {6}\n" +
            "PropertyID = {7}\n" +
            "CompanyID = {8}\n" +
            "SeqNo = {9}\n" +
            "IsSynch = {10}\n" +
            "SynchOn = {11}\n" +
            "UpdatedOn = {12}\n" +
            "UpdatedBy = {13}\n" +
            "CreatedOn = {14}\n" +
            "CreatedBy = {15}\n" +
            "IsActive = {16}\n"+
            "ComplaintBy={17}\n",
            GuestComplaintID, GuestID, Department, NatureOfComplaint, ComplaintDescription, DateOfComplain, CompainTime, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, CreatedOn, CreatedBy, IsActive, ComplaintBy); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class GuestComplaintKeys
    {

        #region Data Members

        Guid _guestComplaintID;

        #endregion

        #region Constructor

        public GuestComplaintKeys(Guid guestComplaintID)
        {
            _guestComplaintID = guestComplaintID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid GuestComplaintID
        {
            get { return _guestComplaintID; }
        }

        #endregion

    }
}
