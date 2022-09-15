using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using SQT.FRAMEWORK.DAL.Linq;

namespace SQT.Symphony.BusinessLogic.Configuration.DTO
{
    [DataContract]
    public class PropertyPayment : BusinessObjectBase
    {
        #region InnerClass
        public enum PropertyFields
        {
            PropertyPaymentID,
            PropertyID,
            PropertyScheduleID,
            AmountPaid,
            MOPTerm,
            DateOfTransaction,
            BankName,
            ChequeNo,
            CheckTo,
            OrderNo,
            UserID,
            Description
        }

        #endregion

        #region Data Members

        Guid _propertyPaymentID;
        Guid _propertyID;
        Guid _propertyScheduleID;
        decimal? _amountPaid;
        string _mopTerm;
        DateTime? _dateOfTransaction;
        string _bankName;
        string _chequeNo;
        string _chequeTo;
        int? _orderNo;
        Guid? _userID;
        string _description;

        #endregion

        #region Properties

        [DataMember]
        public Guid PropertyPaymentID
        {
            get { return _propertyPaymentID; }
            set
            {
                if (_propertyPaymentID != value)
                {
                    _propertyPaymentID = value;
                    PropertyHasChanged("PropertyPaymentID");
                }
            }
        }

        [DataMember]
        public Guid PropertyID
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
        public Guid PropertyScheduleID
        {
            get { return _propertyScheduleID; }
            set
            {
                if (_propertyScheduleID != value)
                {
                    _propertyScheduleID = value;
                    PropertyHasChanged("PropertyScheduleID");
                }
            }
        }

        [DataMember]
        public decimal? AmountPaid
        {
            get { return _amountPaid; }
            set
            {
                if (_amountPaid != value)
                {
                    _amountPaid = value;
                    PropertyHasChanged("AmountPaid");
                }
            }
        }

        [DataMember]
        public string MOPTerm
        {
            get { return _mopTerm; }
            set
            {
                if (_mopTerm != value)
                {
                    _mopTerm = value;
                    PropertyHasChanged("MOPTerm");
                }
            }
        }

        [DataMember]
        public DateTime? DateOfTransaction
        {
            get { return _dateOfTransaction; }
            set
            {
                if (_dateOfTransaction != value)
                {
                    _dateOfTransaction = value;
                    PropertyHasChanged("DateOfTransaction");
                }
            }
        }

        [DataMember]
        public string BankName
        {
            get { return _bankName; }
            set
            {
                if (_bankName != value)
                {
                    _bankName = value;
                    PropertyHasChanged("BankName");
                }
            }
        }

        [DataMember]
        public string ChequeNo
        {
            get { return _chequeNo; }
            set
            {
                if (_chequeNo != value)
                {
                    _chequeNo = value;
                    PropertyHasChanged("ChequeNo");
                }
            }
        }

        [DataMember]
        public string ChequeTo
        {
            get { return _chequeTo; }
            set
            {
                if (_chequeTo != value)
                {
                    _chequeTo = value;
                    PropertyHasChanged("ChequeTo");
                }
            }
        }

        [DataMember]
        public int? OrderNo
        {
            get { return _orderNo; }
            set
            {
                if (_orderNo != value)
                {
                    _orderNo = value;
                    PropertyHasChanged("OrderNo");
                }
            }
        }

        public Guid? UserID
        {
            get { return _userID; }
            set
            {
                if (_userID != value)
                {
                    _userID = value;
                    PropertyHasChanged("UserID");
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

        #endregion
    }
}
