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
    public class GuestManagementNote : BusinessObjectBase
    {

        #region InnerClass
        public enum GuestManagementNoteFields
        {
            NoteID,
            Notes,
            NoteOn,
            NoteBy,
            UpdatedOn,
            UpdatedBy,
            SeqNo,
            IsActive,
            PropertyID,
            CompanyID,
            IsSynch,
            SynchOn,
            GuestID
        }
        #endregion

        #region Data Members

        Guid _noteID;
        string _notes;
        DateTime? _noteOn;
        Guid? _noteBy;
        DateTime? _updatedOn;
        Guid? _updatedBy;
        int _seqNo;
        bool? _isActive;
        Guid? _propertyID;
        Guid? _companyID;
        bool? _isSynch;
        DateTime? _synchOn;
        Guid? _guestID;
        #endregion

        #region Properties

        [DataMember]
        public Guid NoteID
        {
            get { return _noteID; }
            set
            {
                if (_noteID != value)
                {
                    _noteID = value;
                    PropertyHasChanged("NoteID");
                }
            }
        }

        [DataMember]
        public string Notes
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
        public DateTime? NoteOn
        {
            get { return _noteOn; }
            set
            {
                if (_noteOn != value)
                {
                    _noteOn = value;
                    PropertyHasChanged("NoteOn");
                }
            }
        }

        [DataMember]
        public Guid? NoteBy
        {
            get { return _noteBy; }
            set
            {
                if (_noteBy != value)
                {
                    _noteBy = value;
                    PropertyHasChanged("NoteBy");
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

        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("NoteID", "NoteID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Notes", "Notes", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "NoteID = {0}\n" +
            "Notes = {1}\n" +
            "NoteOn = {2}\n" +
            "NoteBy = {3}\n" +
            "UpdatedOn = {4}\n" +
            "UpdatedBy = {5}\n" +
            "SeqNo = {6}\n" +
            "IsActive = {7}\n" +
            "PropertyID = {8}\n" +
            "CompanyID = {9}\n" +
            "IsSynch = {10}\n" +
            "SynchOn = {11}\n"+
            "GuestID={12}\n",
            NoteID, Notes, NoteOn, NoteBy, UpdatedOn, UpdatedBy, SeqNo, IsActive, PropertyID, CompanyID, IsSynch, SynchOn, GuestID); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class GuestManagementNoteKeys
    {

        #region Data Members

        Guid _noteID;

        #endregion

        #region Constructor

        public GuestManagementNoteKeys(Guid noteID)
        {
            _noteID = noteID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid NoteID
        {
            get { return _noteID; }
        }

        #endregion

    }
}
