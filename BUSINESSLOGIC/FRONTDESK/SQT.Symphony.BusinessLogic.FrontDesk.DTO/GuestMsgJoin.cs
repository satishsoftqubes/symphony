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
    public class GuestMsgJoin : BusinessObjectBase
    {

        #region InnerClass
        public enum GuestMsgJoinFields
        {
            GuestMessageID,
            GuestID,
            Message,
            Subject,
            ReservationID,
            Msg_PriorityTermID,
            Msg_DateTime,
            IsInformed,
            MessageOption_TermID,
            MessageFrom,
            CompanyName,
            ContactName,
            PropertyID,
            CompanyID,
            SeqNo,
            IsSynch,
            SynchOn,
            UpdatedOn,
            UpdatedBy,
            IsActive,
            IsRead,
            IsDelete
        }
        #endregion

        #region Data Members

        Guid _guestMessageID;
        Guid? _guestID;
        string _message;
        string _subject;
        Guid? _reservationID;
        Guid? _msg_PriorityTermID;
        DateTime? _msg_DateTime;
        bool? _isInformed;
        Guid? _messageOption_TermID;
        string _messageFrom;
        string _companyName;
        string _contactName;
        Guid? _propertyID;
        Guid? _companyID;
        long _seqNo;
        bool? _isSynch;
        DateTime? _synchOn;
        DateTime? _updatedOn;
        Guid? _updatedBy;
        bool? _isActive;
        bool? _isRead;
        bool? _isDelete;

        #endregion

        #region Properties

        [DataMember]
        public Guid GuestMessageID
        {
            get { return _guestMessageID; }
            set
            {
                if (_guestMessageID != value)
                {
                    _guestMessageID = value;
                    PropertyHasChanged("GuestMessageID");
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
        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    PropertyHasChanged("Message");
                }
            }
        }

        [DataMember]
        public string Subject
        {
            get { return _subject; }
            set
            {
                if (_subject != value)
                {
                    _subject = value;
                    PropertyHasChanged("Subject");
                }
            }
        }

        [DataMember]
        public Guid? ReservationID
        {
            get { return _reservationID; }
            set
            {
                if (_reservationID != value)
                {
                    _reservationID = value;
                    PropertyHasChanged("ReservationID");
                }
            }
        }

        [DataMember]
        public Guid? Msg_PriorityTermID
        {
            get { return _msg_PriorityTermID; }
            set
            {
                if (_msg_PriorityTermID != value)
                {
                    _msg_PriorityTermID = value;
                    PropertyHasChanged("Msg_PriorityTermID");
                }
            }
        }

        [DataMember]
        public DateTime? Msg_DateTime
        {
            get { return _msg_DateTime; }
            set
            {
                if (_msg_DateTime != value)
                {
                    _msg_DateTime = value;
                    PropertyHasChanged("Msg_DateTime");
                }
            }
        }

        [DataMember]
        public bool? IsInformed
        {
            get { return _isInformed; }
            set
            {
                if (_isInformed != value)
                {
                    _isInformed = value;
                    PropertyHasChanged("IsInformed");
                }
            }
        }

        [DataMember]
        public Guid? MessageOption_TermID
        {
            get { return _messageOption_TermID; }
            set
            {
                if (_messageOption_TermID != value)
                {
                    _messageOption_TermID = value;
                    PropertyHasChanged("MessageOption_TermID");
                }
            }
        }

        [DataMember]
        public string MessageFrom
        {
            get { return _messageFrom; }
            set
            {
                if (_messageFrom != value)
                {
                    _messageFrom = value;
                    PropertyHasChanged("MessageFrom");
                }
            }
        }

        [DataMember]
        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                if (_companyName != value)
                {
                    _companyName = value;
                    PropertyHasChanged("CompanyName");
                }
            }
        }

        [DataMember]
        public string ContactName
        {
            get { return _contactName; }
            set
            {
                if (_contactName != value)
                {
                    _contactName = value;
                    PropertyHasChanged("ContactName");
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
        public long SeqNo
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
        public bool? IsRead
        {
            get { return _isRead; }
            set
            {
                if (_isRead != value)
                {
                    _isRead = value;
                    PropertyHasChanged("IsRead");
                }
            }
        }

        [DataMember]
        public bool? IsDelete
        {
            get { return _isDelete; }
            set
            {
                if (_isDelete != value)
                {
                    _isDelete = value;
                    PropertyHasChanged("IsDelete");
                }
            }
        }

        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("GuestMessageID", "GuestMessageID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Message", "Message", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Subject", "Subject", 320));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("MessageFrom", "MessageFrom", 360));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CompanyName", "CompanyName", 360));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ContactName", "ContactName", 160));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "GuestMessageID = {0}\n" +
            "GuestID = {1}\n" +
            "Message = {2}\n" +
            "Subject = {3}\n" +
            "ReservationID = {4}\n" +
            "Msg_PriorityTermID = {5}\n" +
            "Msg_DateTime = {6}\n" +
            "IsInformed = {7}\n" +
            "MessageOption_TermID = {8}\n" +
            "MessageFrom = {9}\n" +
            "CompanyName = {10}\n" +
            "ContactName = {11}\n" +
            "PropertyID = {12}\n" +
            "CompanyID = {13}\n" +
            "SeqNo = {14}\n" +
            "IsSynch = {15}\n" +
            "SynchOn = {16}\n" +
            "UpdatedOn = {17}\n" +
            "UpdatedBy = {18}\n" +
            "IsActive = {19}\n" +
            "IsRead = {20}\n" +
            "IsDelete = {21}\n",
            GuestMessageID, GuestID, Message, Subject, ReservationID, Msg_PriorityTermID, Msg_DateTime, IsInformed, MessageOption_TermID, MessageFrom, CompanyName, ContactName, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, IsRead, IsDelete); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class GuestMsgJoinKeys
    {

        #region Data Members

        Guid _guestMessageID;

        #endregion

        #region Constructor

        public GuestMsgJoinKeys(Guid guestMessageID)
        {
            _guestMessageID = guestMessageID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid GuestMessageID
        {
            get { return _guestMessageID; }
        }

        #endregion

    }
}
