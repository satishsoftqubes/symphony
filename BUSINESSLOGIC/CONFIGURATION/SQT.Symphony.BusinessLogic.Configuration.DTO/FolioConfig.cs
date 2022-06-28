using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;
namespace SQT.Symphony.BusinessLogic.Configuration.DTO
{
    [DataContract]
    public class FolioConfig : BusinessObjectBase
    {

        #region InnerClass
        public enum FolioConfigFields
        {
            FolioConfigID,
            PropertyID,
            CompanyID,
            SeqNo,
            IsSynch,
            SynchOn,
            UpdatedOn,
            UpdatedBy,
            IsActive,
            FolioNotes,
            TermnCondition,
            IsReRoutingEnable,
            IsReRoutingInSameReservation,
            IsReRoutingInGroupReservation,
            IsReRoutingInAllReservation,
            IsCreateSubFolioByTransactionZone,
            IsAutoCreateFoliosForAccomodation,
            IsAutoCreateFoliosForRestaurent,
            IsAutoCreateFoliosForPOS,
            IsAutoCreateFoliosForMiscellaneous,
            IsAutoCreateFoliosForCallLogger,
            IsAutoCreateFoliosForLaundry,
            IsAutoCreateFoliosForMiscServices,
            IsTransferBalanceApplicable,
            IsAdvancedChargePostingApplicable,
            IsTransferTransactionApplicable,
            IsBalanceTransferApplicable,
            IsDepositTransferApplicable,
            IsVoidTransactionApplicable,
            IsSplitFolioApplicable,
            IsAutoCheckInFolioWithReservation,
            ReservationPolicyNote
        }
        #endregion

        #region Data Members

        Guid _folioConfigID;
        Guid? _propertyID;
        Guid? _companyID;
        int _seqNo;
        bool? _isSynch;
        DateTime? _synchOn;
        DateTime? _updatedOn;
        Guid? _updatedBy;
        bool? _isActive;
        string _folioNotes;
        string _termnCondition;
        bool? _isReRoutingEnable;
        bool? _isReRoutingInSameReservation;
        bool? _isReRoutingInGroupReservation;
        bool? _isReRoutingInAllReservation;
        bool? _isCreateSubFolioByTransactionZone;
        bool? _isAutoCreateFoliosForAccomodation;
        bool? _isAutoCreateFoliosForRestaurent;
        bool? _isAutoCreateFoliosForPOS;
        bool? _isAutoCreateFoliosForMiscellaneous;
        bool? _isAutoCreateFoliosForCallLogger;
        bool? _isAutoCreateFoliosForLaundry;
        bool? _isAutoCreateFoliosForMiscServices;
        bool? _isTransferBalanceApplicable;
        bool? _isAdvancedChargePostingApplicable;
        bool? _isTransferTransactionApplicable;
        bool? _isBalanceTransferApplicable;
        bool? _isDepositTransferApplicable;
        bool? _isVoidTransactionApplicable;
        bool? _isSplitFolioApplicable;
        bool? _isAutoCheckInFolioWithReservation;
        string _reservationPolicyNote;
        #endregion

        #region Properties

        [DataMember]
        public Guid FolioConfigID
        {
            get { return _folioConfigID; }
            set
            {
                if (_folioConfigID != value)
                {
                    _folioConfigID = value;
                    PropertyHasChanged("FolioConfigID");
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
        public string FolioNotes
        {
            get { return _folioNotes; }
            set
            {
                if (_folioNotes != value)
                {
                    _folioNotes = value;
                    PropertyHasChanged("FolioNotes");
                }
            }
        }

        [DataMember]
        public string TermnCondition
        {
            get { return _termnCondition; }
            set
            {
                if (_termnCondition != value)
                {
                    _termnCondition = value;
                    PropertyHasChanged("TermnCondition");
                }
            }
        }






        [DataMember]
        public string ReservationPolicyNote
        {
            get { return _reservationPolicyNote; }
            set
            {
                if (_reservationPolicyNote != value)
                {
                    _reservationPolicyNote = value;
                    PropertyHasChanged("ReservationPolicyNote");
                }
            }
        }




        [DataMember]
        public bool? IsReRoutingEnable
        {
            get { return _isReRoutingEnable; }
            set
            {
                if (_isReRoutingEnable != value)
                {
                    _isReRoutingEnable = value;
                    PropertyHasChanged("IsReRoutingEnable");
                }
            }
        }

        [DataMember]
        public bool? IsReRoutingInSameReservation
        {
            get { return _isReRoutingInSameReservation; }
            set
            {
                if (_isReRoutingInSameReservation != value)
                {
                    _isReRoutingInSameReservation = value;
                    PropertyHasChanged("IsReRoutingInSameReservation");
                }
            }
        }

        [DataMember]
        public bool? IsReRoutingInGroupReservation
        {
            get { return _isReRoutingInGroupReservation; }
            set
            {
                if (_isReRoutingInGroupReservation != value)
                {
                    _isReRoutingInGroupReservation = value;
                    PropertyHasChanged("IsReRoutingInGroupReservation");
                }
            }
        }

        [DataMember]
        public bool? IsReRoutingInAllReservation
        {
            get { return _isReRoutingInAllReservation; }
            set
            {
                if (_isReRoutingInAllReservation != value)
                {
                    _isReRoutingInAllReservation = value;
                    PropertyHasChanged("IsReRoutingInAllReservation");
                }
            }
        }

        [DataMember]
        public bool? IsCreateSubFolioByTransactionZone
        {
            get { return _isCreateSubFolioByTransactionZone; }
            set
            {
                if (_isCreateSubFolioByTransactionZone != value)
                {
                    _isCreateSubFolioByTransactionZone = value;
                    PropertyHasChanged("IsCreateSubFolioByTransactionZone");
                }
            }
        }

        [DataMember]
        public bool? IsAutoCreateFoliosForAccomodation
        {
            get { return _isAutoCreateFoliosForAccomodation; }
            set
            {
                if (_isAutoCreateFoliosForAccomodation != value)
                {
                    _isAutoCreateFoliosForAccomodation = value;
                    PropertyHasChanged("IsAutoCreateFoliosForAccomodation");
                }
            }
        }

        [DataMember]
        public bool? IsAutoCreateFoliosForRestaurent
        {
            get { return _isAutoCreateFoliosForRestaurent; }
            set
            {
                if (_isAutoCreateFoliosForRestaurent != value)
                {
                    _isAutoCreateFoliosForRestaurent = value;
                    PropertyHasChanged("IsAutoCreateFoliosForRestaurent");
                }
            }
        }

        [DataMember]
        public bool? IsAutoCreateFoliosForPOS
        {
            get { return _isAutoCreateFoliosForPOS; }
            set
            {
                if (_isAutoCreateFoliosForPOS != value)
                {
                    _isAutoCreateFoliosForPOS = value;
                    PropertyHasChanged("IsAutoCreateFoliosForPOS");
                }
            }
        }

        [DataMember]
        public bool? IsAutoCreateFoliosForMiscellaneous
        {
            get { return _isAutoCreateFoliosForMiscellaneous; }
            set
            {
                if (_isAutoCreateFoliosForMiscellaneous != value)
                {
                    _isAutoCreateFoliosForMiscellaneous = value;
                    PropertyHasChanged("IsAutoCreateFoliosForMiscellaneous");
                }
            }
        }

        [DataMember]
        public bool? IsAutoCreateFoliosForCallLogger
        {
            get { return _isAutoCreateFoliosForCallLogger; }
            set
            {
                if (_isAutoCreateFoliosForCallLogger != value)
                {
                    _isAutoCreateFoliosForCallLogger = value;
                    PropertyHasChanged("IsAutoCreateFoliosForCallLogger");
                }
            }
        }

        [DataMember]
        public bool? IsAutoCreateFoliosForLaundry
        {
            get { return _isAutoCreateFoliosForLaundry; }
            set
            {
                if (_isAutoCreateFoliosForLaundry != value)
                {
                    _isAutoCreateFoliosForLaundry = value;
                    PropertyHasChanged("IsAutoCreateFoliosForLaundry");
                }
            }
        }

        [DataMember]
        public bool? IsAutoCreateFoliosForMiscServices
        {
            get { return _isAutoCreateFoliosForMiscServices; }
            set
            {
                if (_isAutoCreateFoliosForMiscServices != value)
                {
                    _isAutoCreateFoliosForMiscServices = value;
                    PropertyHasChanged("IsAutoCreateFoliosForMiscServices");
                }
            }
        }

        [DataMember]
        public bool? IsTransferBalanceApplicable
        {
            get { return _isTransferBalanceApplicable; }
            set
            {
                if (_isTransferBalanceApplicable != value)
                {
                    _isTransferBalanceApplicable = value;
                    PropertyHasChanged("IsTransferBalanceApplicable");
                }
            }
        }

        [DataMember]
        public bool? IsAdvancedChargePostingApplicable
        {
            get { return _isAdvancedChargePostingApplicable; }
            set
            {
                if (_isAdvancedChargePostingApplicable != value)
                {
                    _isAdvancedChargePostingApplicable = value;
                    PropertyHasChanged("IsAdvancedChargePostingApplicable");
                }
            }
        }

        [DataMember]
        public bool? IsTransferTransactionApplicable
        {
            get { return _isTransferTransactionApplicable; }
            set
            {
                if (_isTransferTransactionApplicable != value)
                {
                    _isTransferTransactionApplicable = value;
                    PropertyHasChanged("IsTransferTransactionApplicable");
                }
            }
        }

        [DataMember]
        public bool? IsBalanceTransferApplicable
        {
            get { return _isBalanceTransferApplicable; }
            set
            {
                if (_isBalanceTransferApplicable != value)
                {
                    _isBalanceTransferApplicable = value;
                    PropertyHasChanged("IsBalanceTransferApplicable");
                }
            }
        }

        [DataMember]
        public bool? IsDepositTransferApplicable
        {
            get { return _isDepositTransferApplicable; }
            set
            {
                if (_isDepositTransferApplicable != value)
                {
                    _isDepositTransferApplicable = value;
                    PropertyHasChanged("IsDepositTransferApplicable");
                }
            }
        }

        [DataMember]
        public bool? IsVoidTransactionApplicable
        {
            get { return _isVoidTransactionApplicable; }
            set
            {
                if (_isVoidTransactionApplicable != value)
                {
                    _isVoidTransactionApplicable = value;
                    PropertyHasChanged("IsVoidTransactionApplicable");
                }
            }
        }

        [DataMember]
        public bool? IsSplitFolioApplicable
        {
            get { return _isSplitFolioApplicable; }
            set
            {
                if (_isSplitFolioApplicable != value)
                {
                    _isSplitFolioApplicable = value;
                    PropertyHasChanged("IsSplitFolioApplicable");
                }
            }
        }

        [DataMember]
        public bool? IsAutoCheckInFolioWithReservation
        {
            get { return _isAutoCheckInFolioWithReservation; }
            set
            {
                if (_isAutoCheckInFolioWithReservation != value)
                {
                    _isAutoCheckInFolioWithReservation = value;
                    PropertyHasChanged("IsAutoCheckInFolioWithReservation");
                }
            }
        }


        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("FolioConfigID", "FolioConfigID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("FolioNotes", "FolioNotes", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("TermnCondition", "TermnCondition", 2147483647));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "FolioConfigID = {0}~\n" +
            "PropertyID = {1}~\n" +
            "CompanyID = {2}~\n" +
            "SeqNo = {3}~\n" +
            "IsSynch = {4}~\n" +
            "SynchOn = {5}~\n" +
            "UpdatedOn = {6}~\n" +
            "UpdatedBy = {7}~\n" +
            "IsActive = {8}~\n" +
            "FolioNotes = {9}~\n" +
            "TermnCondition = {10}~\n" +
            "IsReRoutingEnable = {11}~\n" +
            "IsReRoutingInSameReservation = {12}~\n" +
            "IsReRoutingInGroupReservation = {13}~\n" +
            "IsReRoutingInAllReservation = {14}~\n" +
            "IsCreateSubFolioByTransactionZone = {15}~\n" +
            "IsAutoCreateFoliosForAccomodation = {16}~\n" +
            "IsAutoCreateFoliosForRestaurent = {17}~\n" +
            "IsAutoCreateFoliosForPOS = {18}~\n" +
            "IsAutoCreateFoliosForMiscellaneous = {19}~\n" +
            "IsAutoCreateFoliosForCallLogger = {20}~\n" +
            "IsAutoCreateFoliosForLaundry = {21}~\n" +
            "IsAutoCreateFoliosForMiscServices = {22}~\n" +
            "IsTransferBalanceApplicable = {23}~\n" +
            "IsAdvancedChargePostingApplicable = {24}~\n" +
            "IsTransferTransactionApplicable = {25}~\n" +
            "IsBalanceTransferApplicable = {26}~\n" +
            "IsDepositTransferApplicable = {27}~\n" +
            "IsVoidTransactionApplicable = {28}~\n" +
            "IsSplitFolioApplicable = {29}~\n" +
            "IsAutoCheckInFolioWithReservation = {30}~\n" +
            "ReservationPolicyNote={31}~\n",
            FolioConfigID, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, FolioNotes, TermnCondition, IsReRoutingEnable, IsReRoutingInSameReservation, IsReRoutingInGroupReservation, IsReRoutingInAllReservation, IsCreateSubFolioByTransactionZone, IsAutoCreateFoliosForAccomodation, IsAutoCreateFoliosForRestaurent, IsAutoCreateFoliosForPOS, IsAutoCreateFoliosForMiscellaneous, IsAutoCreateFoliosForCallLogger, IsAutoCreateFoliosForLaundry, IsAutoCreateFoliosForMiscServices, IsTransferBalanceApplicable, IsAdvancedChargePostingApplicable, IsTransferTransactionApplicable, IsBalanceTransferApplicable, IsDepositTransferApplicable, IsVoidTransactionApplicable, IsSplitFolioApplicable, IsAutoCheckInFolioWithReservation, ReservationPolicyNote); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class FolioConfigKeys
    {

        #region Data Members

        Guid _folioConfigID;

        #endregion

        #region Constructor

        public FolioConfigKeys(Guid folioConfigID)
        {
            _folioConfigID = folioConfigID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid FolioConfigID
        {
            get { return _folioConfigID; }
        }

        #endregion

    }
}
