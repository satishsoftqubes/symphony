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
    public class GuestComments : BusinessObjectBase
    {

        #region InnerClass
        public enum GuestCommentsFields
        {
            GuestCommentID,
            GuestID,
            Comment,
            CommentTermID,
            Rate,
            ReservationID,
            RoomNo,
            RoomType,
            ConferenceName,
            Nights,
            CheckInDate,
            CheckOutDate,
            ReservatioNo,
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
            Department,
            NatureOfComplaint,
            CommentsBy
        }
        #endregion

        #region Data Members

        Guid _guestCommentID;
        Guid? _guestID;
        string _comment;
        Guid? _commentTermID;
        int? _rate;
        Guid? _reservationID;
        string _roomNo;
        string _roomType;
        string _conferenceName;
        int? _nights;
        DateTime? _checkInDate;
        DateTime? _checkOutDate;
        string _reservatioNo;
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
        Guid? _department;
        string _natureOfComplaint;
        string _commentsBy;

        #endregion

        #region Properties

        [DataMember]
        public Guid GuestCommentID
        {
            get { return _guestCommentID; }
            set
            {
                if (_guestCommentID != value)
                {
                    _guestCommentID = value;
                    PropertyHasChanged("GuestCommentID");
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
        public string Comment
        {
            get { return _comment; }
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    PropertyHasChanged("Comment");
                }
            }
        }

        [DataMember]
        public Guid? CommentTermID
        {
            get { return _commentTermID; }
            set
            {
                if (_commentTermID != value)
                {
                    _commentTermID = value;
                    PropertyHasChanged("CommentTermID");
                }
            }
        }

        [DataMember]
        public int? Rate
        {
            get { return _rate; }
            set
            {
                if (_rate != value)
                {
                    _rate = value;
                    PropertyHasChanged("Rate");
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
        public string RoomNo
        {
            get { return _roomNo; }
            set
            {
                if (_roomNo != value)
                {
                    _roomNo = value;
                    PropertyHasChanged("RoomNo");
                }
            }
        }

        [DataMember]
        public string RoomType
        {
            get { return _roomType; }
            set
            {
                if (_roomType != value)
                {
                    _roomType = value;
                    PropertyHasChanged("RoomType");
                }
            }
        }

        [DataMember]
        public string ConferenceName
        {
            get { return _conferenceName; }
            set
            {
                if (_conferenceName != value)
                {
                    _conferenceName = value;
                    PropertyHasChanged("ConferenceName");
                }
            }
        }

        [DataMember]
        public int? Nights
        {
            get { return _nights; }
            set
            {
                if (_nights != value)
                {
                    _nights = value;
                    PropertyHasChanged("Nights");
                }
            }
        }

        [DataMember]
        public DateTime? CheckInDate
        {
            get { return _checkInDate; }
            set
            {
                if (_checkInDate != value)
                {
                    _checkInDate = value;
                    PropertyHasChanged("CheckInDate");
                }
            }
        }

        [DataMember]
        public DateTime? CheckOutDate
        {
            get { return _checkOutDate; }
            set
            {
                if (_checkOutDate != value)
                {
                    _checkOutDate = value;
                    PropertyHasChanged("CheckOutDate");
                }
            }
        }

        [DataMember]
        public string ReservatioNo
        {
            get { return _reservatioNo; }
            set
            {
                if (_reservatioNo != value)
                {
                    _reservatioNo = value;
                    PropertyHasChanged("ReservatioNo");
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
        public string CommentsBy
        {
            get { return _commentsBy; }
            set
            {
                if (_commentsBy != value)
                {
                    _commentsBy = value;
                    PropertyHasChanged("CommentsBy");
                }
            }
        }

        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("GuestCommentID", "GuestCommentID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Comment", "Comment", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("RoomNo", "RoomNo", 120));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("RoomType", "RoomType", 120));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ConferenceName", "ConferenceName", 65));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ReservatioNo", "ReservatioNo", 100));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "GuestCommentID = {0}\n" +
            "GuestID = {1}\n" +
            "Comment = {2}\n" +
            "CommentTermID = {3}\n" +
            "Rate = {4}\n" +
            "ReservationID = {5}\n" +
            "RoomNo = {6}\n" +
            "RoomType = {7}\n" +
            "ConferenceName = {8}\n" +
            "Nights = {9}\n" +
            "CheckInDate = {10}\n" +
            "CheckOutDate = {11}\n" +
            "ReservatioNo = {12}\n" +
            "PropertyID = {13}\n" +
            "CompanyID = {14}\n" +
            "SeqNo = {15}\n" +
            "IsSynch = {16}\n" +
            "SynchOn = {17}\n" +
            "UpdatedOn = {18}\n" +
            "UpdatedBy = {19}\n" +
            "CreatedOn = {20}\n" +
            "CreatedBy = {21}\n" +
            "IsActive = {22}\n" +
            "Department = {23}\n" +
            "NatureOfComplaint = {24}\n"+
            "CommentsBy={25}\n",
            GuestCommentID, GuestID, Comment, CommentTermID, Rate, ReservationID, RoomNo, RoomType, ConferenceName, Nights, CheckInDate, CheckOutDate, ReservatioNo, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, CreatedOn, CreatedBy, IsActive, Department, NatureOfComplaint, CommentsBy); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class GuestCommentsKeys
    {

        #region Data Members

        Guid _guestCommentID;

        #endregion

        #region Constructor

        public GuestCommentsKeys(Guid guestCommentID)
        {
            _guestCommentID = guestCommentID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid GuestCommentID
        {
            get { return _guestCommentID; }
        }

        #endregion

    }
}
