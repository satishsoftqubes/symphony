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
    public class FrontDeskAlertMaster : BusinessObjectBase
    {

        #region InnerClass
        public enum FrontDeskAlertMasterFields
        {
            FrontDeskAlertMsgID,
            Messege,
            MsgDateTime,
            IsInformed,
            MessageBy,
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
            Msg_ExpDateTime,
            IsRead,
            IsDelete
        }
        #endregion

        #region Data Members

        Guid _frontDeskAlertMsgID;
        string _messege;
        DateTime? _msgDateTime;
        bool? _isInformed;
        Guid? _messageBy;
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
        DateTime? _msg_ExpDateTime;
        bool? _isRead;
        bool? _isDelete;

        #endregion

        #region Properties

        [DataMember]
        public Guid FrontDeskAlertMsgID
        {
            get { return _frontDeskAlertMsgID; }
            set
            {
                if (_frontDeskAlertMsgID != value)
                {
                    _frontDeskAlertMsgID = value;
                    PropertyHasChanged("FrontDeskAlertMsgID");
                }
            }
        }

        [DataMember]
        public string Messege
        {
            get { return _messege; }
            set
            {
                if (_messege != value)
                {
                    _messege = value;
                    PropertyHasChanged("Messege");
                }
            }
        }

        [DataMember]
        public DateTime? MsgDateTime
        {
            get { return _msgDateTime; }
            set
            {
                if (_msgDateTime != value)
                {
                    _msgDateTime = value;
                    PropertyHasChanged("MsgDateTime");
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
        public Guid? MessageBy
        {
            get { return _messageBy; }
            set
            {
                if (_messageBy != value)
                {
                    _messageBy = value;
                    PropertyHasChanged("MessageBy");
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

        [DataMember]
        public DateTime? Msg_ExpDateTime
        {
            get { return _msg_ExpDateTime; }
            set
            {
                if (_msg_ExpDateTime != value)
                {
                    _msg_ExpDateTime = value;
                    PropertyHasChanged("Msg_ExpDateTime");
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
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("FrontDeskAlertMsgID", "FrontDeskAlertMsgID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Messege", "Messege", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "FrontDeskAlertMsgID = {0}\n" +
            "Messege = {1}\n" +
            "MsgDateTime = {2}\n" +
            "IsInformed = {3}\n" +
            "MessageBy = {4}\n" +
            "PropertyID = {5}\n" +
            "CompanyID = {6}\n" +
            "SeqNo = {7}\n" +
            "IsSynch = {8}\n" +
            "SynchOn = {9}\n" +
            "UpdatedOn = {10}\n" +
            "UpdatedBy = {11}\n" +
            "CreatedOn = {12}\n" +
            "CreatedBy = {13}\n" +
            "IsActive = {14}\n" +
            "Msg_ExpDateTime = {15}\n" +
            "IsRead = {16}\n" +
            "IsDelete = {17}\n",
            FrontDeskAlertMsgID, Messege, MsgDateTime, IsInformed, MessageBy, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, CreatedOn, CreatedBy, IsActive, Msg_ExpDateTime, IsRead, IsDelete); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class FrontDeskAlertMasterKeys
    {

        #region Data Members

        Guid _frontDeskAlertMsgID;

        #endregion

        #region Constructor

        public FrontDeskAlertMasterKeys(Guid frontDeskAlertMsgID)
        {
            _frontDeskAlertMsgID = frontDeskAlertMsgID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid FrontDeskAlertMsgID
        {
            get { return _frontDeskAlertMsgID; }
        }

        #endregion

    }
}
