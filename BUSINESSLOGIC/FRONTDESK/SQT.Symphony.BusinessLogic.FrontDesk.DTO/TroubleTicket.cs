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
    public class TroubleTicket : BusinessObjectBase
    {

        #region InnerClass
        public enum TroubleTicketFields
        {
            TicketID,
            ReservationID,
            RoomID,
            Title,
            TicketType_TermID,
            Priority_TermID,
            DepartmentID,
            Description,
            CloseDate,
            CloseBy,
            CloseRemarks,
            TicketRequestBy,
            CompanyID,
            PropertyID,
            IsSynch,
            SynchOn,
            SeqNo,
            IsClosed,
            CreatedBy,
            CreatedOn
        }
        #endregion

        #region Data Members

        Guid _ticketID;
        Guid? _reservationID;
        Guid? _roomID;
        string _title;
        Guid? _ticketType_TermID;
        Guid? _priority_TermID;
        Guid? _departmentID;
        string _description;
        DateTime? _closeDate;
        Guid? _closeBy;
        string _closeRemarks;
        string _ticketRequestBy;
        Guid? _companyID;
        Guid? _propertyID;
        bool? _isSynch;
        DateTime? _synchOn;
        long _seqNo;
        bool? _isClosed;
        Guid? _createdBy;
        DateTime? _createdOn;

        #endregion

        #region Properties

        [DataMember]
        public Guid TicketID
        {
            get { return _ticketID; }
            set
            {
                if (_ticketID != value)
                {
                    _ticketID = value;
                    PropertyHasChanged("TicketID");
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
        public Guid? RoomID
        {
            get { return _roomID; }
            set
            {
                if (_roomID != value)
                {
                    _roomID = value;
                    PropertyHasChanged("RoomID");
                }
            }
        }

        [DataMember]
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

        [DataMember]
        public Guid? TicketType_TermID
        {
            get { return _ticketType_TermID; }
            set
            {
                if (_ticketType_TermID != value)
                {
                    _ticketType_TermID = value;
                    PropertyHasChanged("TicketType_TermID");
                }
            }
        }

        [DataMember]
        public Guid? Priority_TermID
        {
            get { return _priority_TermID; }
            set
            {
                if (_priority_TermID != value)
                {
                    _priority_TermID = value;
                    PropertyHasChanged("Priority_TermID");
                }
            }
        }

        [DataMember]
        public Guid? DepartmentID
        {
            get { return _departmentID; }
            set
            {
                if (_departmentID != value)
                {
                    _departmentID = value;
                    PropertyHasChanged("DepartmentID");
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

        [DataMember]
        public DateTime? CloseDate
        {
            get { return _closeDate; }
            set
            {
                if (_closeDate != value)
                {
                    _closeDate = value;
                    PropertyHasChanged("CloseDate");
                }
            }
        }

        [DataMember]
        public Guid? CloseBy
        {
            get { return _closeBy; }
            set
            {
                if (_closeBy != value)
                {
                    _closeBy = value;
                    PropertyHasChanged("CloseBy");
                }
            }
        }

        [DataMember]
        public string CloseRemarks
        {
            get { return _closeRemarks; }
            set
            {
                if (_closeRemarks != value)
                {
                    _closeRemarks = value;
                    PropertyHasChanged("CloseRemarks");
                }
            }
        }

        [DataMember]
        public string TicketRequestBy
        {
            get { return _ticketRequestBy; }
            set
            {
                if (_ticketRequestBy != value)
                {
                    _ticketRequestBy = value;
                    PropertyHasChanged("TicketRequestBy");
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
        public bool? IsClosed
        {
            get { return _isClosed; }
            set
            {
                if (_isClosed != value)
                {
                    _isClosed = value;
                    PropertyHasChanged("IsClosed");
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


        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("TicketID", "TicketID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Title", "Title", 250));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Description", "Description", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CloseRemarks", "CloseRemarks", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("TicketRequestBy", "TicketRequestBy", 100));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "TicketID = {0}\n" +
            "ReservationID = {1}\n" +
            "RoomID = {2}\n" +
            "Title = {3}\n" +
            "TicketType_TermID = {4}\n" +
            "Priority_TermID = {5}\n" +
            "DepartmentID = {6}\n" +
            "Description = {7}\n" +
            "CloseDate = {8}\n" +
            "CloseBy = {9}\n" +
            "CloseRemarks = {10}\n" +
            "TicketRequestBy = {11}\n" +
            "CompanyID = {12}\n" +
            "PropertyID = {13}\n" +
            "IsSynch = {14}\n" +
            "SynchOn = {15}\n" +
            "SeqNo = {16}\n" +
            "IsClosed = {17}\n" +
            "CreatedOn = {18}\n" +
            "CreatedBy = {19}\n",
            TicketID, ReservationID, RoomID, Title, TicketType_TermID, Priority_TermID, DepartmentID, Description, CloseDate, CloseBy, CloseRemarks, TicketRequestBy, CompanyID, PropertyID, IsSynch, SynchOn, SeqNo, IsClosed, CreatedOn, CreatedBy); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class TroubleTicketKeys
    {

        #region Data Members

        Guid _ticketID;

        #endregion

        #region Constructor

        public TroubleTicketKeys(Guid ticketID)
        {
            _ticketID = ticketID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid TicketID
        {
            get { return _ticketID; }
        }

        #endregion

    }
}
