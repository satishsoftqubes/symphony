using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using SQT.FRAMEWORK.DAL.Linq;

namespace SQT.Symphony.BusinessLogic.Configuration.DTO
{
    [DataContract]
    public class PartnerPayment : BusinessObjectBase
    {
        #region InnerClass
        public enum PropertyFields
        {
            PartnerPaymentID,
            PartnerID,
            PropertyID,
            PropertyPurchaseScheduleID,
            PaymentAmount,
            MOPTerm,
            BankName,
            ChequeNo,
            TransactionDate,
            ReceivedBy,
            SeqNo,
            IsActive,
            UpdateLog,
            UploadDocument,
            Description
        }

        #endregion

        #region Data Members

        Guid _partnerPaymentID;
        Guid _partnerID;
        Guid _propertyID;
        Guid _propertyPurchaseScheduleID;
        decimal? _paymentAmount;
        string _mopTerm;
        string _bankName;
        string _chequeNo;
        DateTime? _transactionDate;
        Guid? _receivedBy;
        int? _seqNo;
        bool? _isActive;
        byte[] _updateLog;
        string _uploadDocument;
        string _description;
        string _installment;

        #endregion

        #region Properties

        [DataMember]
        public Guid PartnerPaymentID
        {
            get { return _partnerPaymentID; }
            set
            {
                if (_partnerPaymentID != value)
                {
                    _partnerPaymentID = value;
                    PropertyHasChanged("PartnerPaymentID");
                }
            }
        }

        [DataMember]
        public Guid PartnerID
        {
            get { return _partnerID; }
            set
            {
                if (_partnerID != value)
                {
                    _partnerID = value;
                    PropertyHasChanged("PartnerID");
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
        public Guid PropertyPurchaseScheduleID
        {
            get { return _propertyPurchaseScheduleID; }
            set
            {
                if (_propertyPurchaseScheduleID != value)
                {
                    _propertyPurchaseScheduleID = value;
                    PropertyHasChanged("PropertyPurchaseScheduleID");
                }
            }
        }

        [DataMember]
        public decimal? PaymentAmount
        {
            get { return _paymentAmount; }
            set
            {
                if (_paymentAmount != value)
                {
                    _paymentAmount = value;
                    PropertyHasChanged("PaymentAmount");
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
        public DateTime? TransactionDate
        {
            get { return _transactionDate; }
            set
            {
                if (_transactionDate != value)
                {
                    _transactionDate = value;
                    PropertyHasChanged("TransactionDate");
                }
            }
        }

        [DataMember]
        public Guid? ReceivedBy
        {
            get { return _receivedBy; }
            set
            {
                if (_receivedBy != value)
                {
                    _receivedBy = value;
                    PropertyHasChanged("ReceivedBy");
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
        public string UploadDocument
        {
            get { return _uploadDocument; }
            set
            {
                if (_uploadDocument != value)
                {
                    _uploadDocument = value;
                    PropertyHasChanged("UploadDocument");
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
        public string Installment
        {
            get { return _installment; }
            set
            {
                if (_installment != value)
                {
                    _installment = value;
                    PropertyHasChanged("Installment");
                }
            }
        }

        #endregion
    }
}
