using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq;
using System.ServiceModel;
namespace SQT.Symphony.BusinessLogic.IRMS.DTO
{
    [DataContract]
    public class InvestorsUnit : BusinessObjectBase
    {

        #region InnerClass
        public enum InvestorsUnitFields
        {
            InvestorRoomID,
            InvestorID,
            RoomID,
            UnitPrice,
            RatePerSqtft,
            AgreementToSellValue,
            StmpDutyOnAgrToSell,
            StmpDutyOnSaleDeed,
            RegistrationCharges,
            OtherCosts,
            ConstructionValue,
            Vat,
            STax,
            OtherConstructionCost,
            DateOfPossession,
            IsInterestApplicable,
            RateOfInterest,
            IsApproved,
            IsActive,
            AgreementToSellDOCId,
            ConstructionAgrDOCId,
            PropertyManagementAgrDOCId,
            AbsoluteSalesDeedDOCId,
            RegistrationDOCId,
            CreatedOn,
            UpdateOn,
            CreatedBy,
            UpdatedBy,
            UpdateLog,
            SeqNo,
            ScheduleType,
            DateOfBooking,
            SellerCompany,
            RegistrationDate,
            FinalPaymentDate,
            SellDate
        }
        #endregion

        #region Data Members

        Guid _investorRoomID;
        Guid? _investorID;
        Guid? _roomID;
        decimal? _unitPrice;
        decimal? _ratePerSqtft;
        decimal? _agreementToSellValue;
        decimal? _stmpDutyOnAgrToSell;
        decimal? _stmpDutyOnSaleDeed;
        decimal? _registrationCharges;
        decimal? _otherCosts;
        decimal? _constructionValue;
        decimal? _vat;
        decimal? _sTax;
        decimal? _otherConstructionCost;
        DateTime? _dateOfPossession;
        bool? _isInterestApplicable;
        decimal? _rateOfInterest;
        bool? _isApproved;
        bool? _isActive;
        Guid? _agreementToSellDOCId;
        Guid? _constructionAgrDOCId;
        Guid? _propertyManagementAgrDOCId;
        Guid? _absoluteSalesDeedDOCId;
        Guid? _registrationDOCId;
        DateTime? _createdOn;
        DateTime? _updateOn;
        Guid? _createdBy;
        Guid? _updatedBy;
        byte[] _updateLog;
        int _seqNo;
        string _scheduleType;
        DateTime? _DateOfBooking;
        string _SellerCompany;
        DateTime? _RegistrationDate;
        DateTime? _FinalPaymentDate;
        DateTime? _SellDate;

        #endregion

        #region Properties

        [DataMember]
        public Guid InvestorRoomID
        {
            get { return _investorRoomID; }
            set
            {
                if (_investorRoomID != value)
                {
                    _investorRoomID = value;
                    PropertyHasChanged("InvestorRoomID");
                }
            }
        }

        [DataMember]
        public Guid? InvestorID
        {
            get { return _investorID; }
            set
            {
                if (_investorID != value)
                {
                    _investorID = value;
                    PropertyHasChanged("InvestorID");
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
        public decimal? UnitPrice
        {
            get { return _unitPrice; }
            set
            {
                if (_unitPrice != value)
                {
                    _unitPrice = value;
                    PropertyHasChanged("UnitPrice");
                }
            }
        }

        [DataMember]
        public decimal? RatePerSqtft
        {
            get { return _ratePerSqtft; }
            set
            {
                if (_ratePerSqtft != value)
                {
                    _ratePerSqtft = value;
                    PropertyHasChanged("RatePerSqtft");
                }
            }
        }

        [DataMember]
        public decimal? AgreementToSellValue
        {
            get { return _agreementToSellValue; }
            set
            {
                if (_agreementToSellValue != value)
                {
                    _agreementToSellValue = value;
                    PropertyHasChanged("AgreementToSellValue");
                }
            }
        }

        [DataMember]
        public decimal? StmpDutyOnAgrToSell
        {
            get { return _stmpDutyOnAgrToSell; }
            set
            {
                if (_stmpDutyOnAgrToSell != value)
                {
                    _stmpDutyOnAgrToSell = value;
                    PropertyHasChanged("StmpDutyOnAgrToSell");
                }
            }
        }

        [DataMember]
        public decimal? StmpDutyOnSaleDeed
        {
            get { return _stmpDutyOnSaleDeed; }
            set
            {
                if (_stmpDutyOnSaleDeed != value)
                {
                    _stmpDutyOnSaleDeed = value;
                    PropertyHasChanged("StmpDutyOnSaleDeed");
                }
            }
        }

        [DataMember]
        public decimal? RegistrationCharges
        {
            get { return _registrationCharges; }
            set
            {
                if (_registrationCharges != value)
                {
                    _registrationCharges = value;
                    PropertyHasChanged("RegistrationCharges");
                }
            }
        }

        [DataMember]
        public decimal? OtherCosts
        {
            get { return _otherCosts; }
            set
            {
                if (_otherCosts != value)
                {
                    _otherCosts = value;
                    PropertyHasChanged("OtherCosts");
                }
            }
        }

        [DataMember]
        public decimal? ConstructionValue
        {
            get { return _constructionValue; }
            set
            {
                if (_constructionValue != value)
                {
                    _constructionValue = value;
                    PropertyHasChanged("ConstructionValue");
                }
            }
        }

        [DataMember]
        public decimal? Vat
        {
            get { return _vat; }
            set
            {
                if (_vat != value)
                {
                    _vat = value;
                    PropertyHasChanged("Vat");
                }
            }
        }

        [DataMember]
        public decimal? STax
        {
            get { return _sTax; }
            set
            {
                if (_sTax != value)
                {
                    _sTax = value;
                    PropertyHasChanged("STax");
                }
            }
        }

        [DataMember]
        public decimal? OtherConstructionCost
        {
            get { return _otherConstructionCost; }
            set
            {
                if (_otherConstructionCost != value)
                {
                    _otherConstructionCost = value;
                    PropertyHasChanged("OtherConstructionCost");
                }
            }
        }

        [DataMember]
        public DateTime? DateOfPossession
        {
            get { return _dateOfPossession; }
            set
            {
                if (_dateOfPossession != value)
                {
                    _dateOfPossession = value;
                    PropertyHasChanged("DateOfPossession");
                }
            }
        }

        [DataMember]
        public bool? IsInterestApplicable
        {
            get { return _isInterestApplicable; }
            set
            {
                if (_isInterestApplicable != value)
                {
                    _isInterestApplicable = value;
                    PropertyHasChanged("IsInterestApplicable");
                }
            }
        }

        [DataMember]
        public decimal? RateOfInterest
        {
            get { return _rateOfInterest; }
            set
            {
                if (_rateOfInterest != value)
                {
                    _rateOfInterest = value;
                    PropertyHasChanged("RateOfInterest");
                }
            }
        }

        [DataMember]
        public bool? IsApproved
        {
            get { return _isApproved; }
            set
            {
                if (_isApproved != value)
                {
                    _isApproved = value;
                    PropertyHasChanged("IsApproved");
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
        public Guid? AgreementToSellDOCId
        {
            get { return _agreementToSellDOCId; }
            set
            {
                if (_agreementToSellDOCId != value)
                {
                    _agreementToSellDOCId = value;
                    PropertyHasChanged("AgreementToSellDOCId");
                }
            }
        }

        [DataMember]
        public Guid? ConstructionAgrDOCId
        {
            get { return _constructionAgrDOCId; }
            set
            {
                if (_constructionAgrDOCId != value)
                {
                    _constructionAgrDOCId = value;
                    PropertyHasChanged("ConstructionAgrDOCId");
                }
            }
        }

        [DataMember]
        public Guid? PropertyManagementAgrDOCId
        {
            get { return _propertyManagementAgrDOCId; }
            set
            {
                if (_propertyManagementAgrDOCId != value)
                {
                    _propertyManagementAgrDOCId = value;
                    PropertyHasChanged("PropertyManagementAgrDOCId");
                }
            }
        }

        [DataMember]
        public Guid? AbsoluteSalesDeedDOCId
        {
            get { return _absoluteSalesDeedDOCId; }
            set
            {
                if (_absoluteSalesDeedDOCId != value)
                {
                    _absoluteSalesDeedDOCId = value;
                    PropertyHasChanged("AbsoluteSalesDeedDOCId");
                }
            }
        }

        [DataMember]
        public Guid? RegistrationDOCId
        {
            get { return _registrationDOCId; }
            set
            {
                if (_registrationDOCId != value)
                {
                    _registrationDOCId = value;
                    PropertyHasChanged("RegistrationDOCId");
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
        public DateTime? UpdateOn
        {
            get { return _updateOn; }
            set
            {
                if (_updateOn != value)
                {
                    _updateOn = value;
                    PropertyHasChanged("UpdateOn");
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
        public string ScheduleType
        {
            get { return _scheduleType; }
            set
            {
                if (_scheduleType != value)
                {
                    _scheduleType = value;
                    PropertyHasChanged("ScheduleType");
                }
            }
        }

        [DataMember]
        public DateTime? DateOfBooking
        {
            get { return _DateOfBooking; }
            set
            {
                if (_DateOfBooking != value)
                {
                    _DateOfBooking = value;
                    PropertyHasChanged("DateOfBooking");
                }
            }
        }

        [DataMember]
        public string SellerCompany
        {
            get { return _SellerCompany; }
            set
            {
                if (_SellerCompany != value)
                {
                    _SellerCompany = value;
                    PropertyHasChanged("SellerCompany");
                }
            }
        }
        [DataMember]
        public DateTime? RegistrationDate
        {
            get { return _RegistrationDate; }
            set
            {
                if (_RegistrationDate != value)
                {
                    _RegistrationDate = value;
                    PropertyHasChanged("RegistrationDate");
                }
            }
        }
        [DataMember]
        public DateTime? FinalPaymentDate
        {
            get { return _FinalPaymentDate; }
            set
            {
                if (_FinalPaymentDate != value)
                {
                    _FinalPaymentDate = value;
                    PropertyHasChanged("FinalPaymentDate");
                }
            }
        }
        [DataMember]
        public DateTime? SellDate
        {
            get { return _SellDate; }
            set
            {
                if (_SellDate != value)
                {
                    _SellDate = value;
                    PropertyHasChanged("SellDate");
                }
            }
        }

        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("InvestorRoomID", "InvestorRoomID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "InvestorRoomID = {0}\n" +
            "InvestorID = {1}\n" +
            "RoomID = {2}\n" +
            "UnitPrice = {3}\n" +
            "RatePerSqtft = {4}\n" +
            "AgreementToSellValue = {5}\n" +
            "StmpDutyOnAgrToSell = {6}\n" +
            "StmpDutyOnSaleDeed = {7}\n" +
            "RegistrationCharges = {8}\n" +
            "OtherCosts = {9}\n" +
            "ConstructionValue = {10}\n" +
            "Vat = {11}\n" +
            "STax = {12}\n" +
            "OtherConstructionCost = {13}\n" +
            "DateOfPossession = {14}\n" +
            "IsInterestApplicable = {15}\n" +
            "RateOfInterest = {16}\n" +
            "IsApproved = {17}\n" +
            "IsActive = {18}\n" +
            "AgreementToSellDOCId = {19}\n" +
            "ConstructionAgrDOCId = {20}\n" +
            "PropertyManagementAgrDOCId = {21}\n" +
            "AbsoluteSalesDeedDOCId = {22}\n" +
            "RegistrationDOCId = {23}\n" +
            "CreatedOn = {24}\n" +
            "UpdateOn = {25}\n" +
            "CreatedBy = {26}\n" +
            "UpdatedBy = {27}\n" +
            "UpdateLog = {28}\n" +
            "SeqNo = {29}\n" +
            "ScheduleType = {30}\n",
            InvestorRoomID, InvestorID, RoomID, UnitPrice, RatePerSqtft, AgreementToSellValue, StmpDutyOnAgrToSell, StmpDutyOnSaleDeed, RegistrationCharges, OtherCosts, ConstructionValue, Vat, STax, OtherConstructionCost, DateOfPossession, IsInterestApplicable, RateOfInterest, IsApproved, IsActive, AgreementToSellDOCId, ConstructionAgrDOCId, PropertyManagementAgrDOCId, AbsoluteSalesDeedDOCId, RegistrationDOCId, CreatedOn, UpdateOn, CreatedBy, UpdatedBy, UpdateLog, SeqNo, ScheduleType); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class InvestorsUnitKeys
    {

        #region Data Members

        Guid _investorRoomID;

        #endregion

        #region Constructor

        public InvestorsUnitKeys(Guid investorRoomID)
        {
            _investorRoomID = investorRoomID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid InvestorRoomID
        {
            get { return _investorRoomID; }
        }

        #endregion

    }
}
