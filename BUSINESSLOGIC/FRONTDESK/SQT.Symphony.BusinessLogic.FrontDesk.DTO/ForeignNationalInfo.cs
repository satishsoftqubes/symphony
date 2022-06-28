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
    public class ForeignNationalInfo : BusinessObjectBase
    {

        #region InnerClass
        public enum ForeignNationalInfoFields
        {
            ForeignNationalityID,
            ReservationID,
            GuestID,
            Nationality,
            IDType,
            PassportNumber,
            PassportDateOfIssue,
            PassportDateOfExpiry,
            PassportPlaceOfIssue,
            ScannedPassport1,
            ScannedPassport2,
            VisaNumber,
            VisaDateOfIssue,
            VisaDateOfExpiry,
            VisaPlaceOfIssue,
            ScannedVisa,
            VisaType,
            DurationOfStay,
            PurposeOfVisa,
            SeqNo,
            PropertyID,
            CompanyID,
            IsSynch,
            SynchOn,
            UpdatedOn,
            UpdatedBy,
            CreatedOn,
            CreatedBy
        }
        #endregion

        #region Data Members

        Guid _foreignNationalityID;
        Guid? _reservationID;
        Guid? _guestID;
        string _nationality;
        Guid? _iDType;
        string _passportNumber;
        DateTime? _passportDateOfIssue;
        DateTime? _passportDateOfExpiry;
        string _passportPlaceOfIssue;
        string _scannedPassport1;
        string _scannedPassport2;
        string _visaNumber;
        DateTime? _visaDateOfIssue;
        DateTime? _visaDateOfExpiry;
        string _visaPlaceOfIssue;
        string _scannedVisa;
        string _visaType;
        int? _durationOfStay;
        string _purposeOfVisa;
        long _seqNo;
        Guid? _propertyID;
        Guid? _companyID;
        bool? _isSynch;
        DateTime? _synchOn;
        DateTime? _updatedOn;
        Guid? _updatedBy;
        DateTime? _createdOn;
        Guid? _createdBy;

        #endregion

        #region Properties

        [DataMember]
        public Guid ForeignNationalityID
        {
            get { return _foreignNationalityID; }
            set
            {
                if (_foreignNationalityID != value)
                {
                    _foreignNationalityID = value;
                    PropertyHasChanged("ForeignNationalityID");
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
        public string Nationality
        {
            get { return _nationality; }
            set
            {
                if (_nationality != value)
                {
                    _nationality = value;
                    PropertyHasChanged("Nationality");
                }
            }
        }

        [DataMember]
        public Guid? IDType
        {
            get { return _iDType; }
            set
            {
                if (_iDType != value)
                {
                    _iDType = value;
                    PropertyHasChanged("IDType");
                }
            }
        }

        [DataMember]
        public string PassportNumber
        {
            get { return _passportNumber; }
            set
            {
                if (_passportNumber != value)
                {
                    _passportNumber = value;
                    PropertyHasChanged("PassportNumber");
                }
            }
        }

        [DataMember]
        public DateTime? PassportDateOfIssue
        {
            get { return _passportDateOfIssue; }
            set
            {
                if (_passportDateOfIssue != value)
                {
                    _passportDateOfIssue = value;
                    PropertyHasChanged("PassportDateOfIssue");
                }
            }
        }

        [DataMember]
        public DateTime? PassportDateOfExpiry
        {
            get { return _passportDateOfExpiry; }
            set
            {
                if (_passportDateOfExpiry != value)
                {
                    _passportDateOfExpiry = value;
                    PropertyHasChanged("PassportDateOfExpiry");
                }
            }
        }

        [DataMember]
        public string PassportPlaceOfIssue
        {
            get { return _passportPlaceOfIssue; }
            set
            {
                if (_passportPlaceOfIssue != value)
                {
                    _passportPlaceOfIssue = value;
                    PropertyHasChanged("PassportPlaceOfIssue");
                }
            }
        }

        [DataMember]
        public string ScannedPassport1
        {
            get { return _scannedPassport1; }
            set
            {
                if (_scannedPassport1 != value)
                {
                    _scannedPassport1 = value;
                    PropertyHasChanged("ScannedPassport1");
                }
            }
        }

        [DataMember]
        public string ScannedPassport2
        {
            get { return _scannedPassport2; }
            set
            {
                if (_scannedPassport2 != value)
                {
                    _scannedPassport2 = value;
                    PropertyHasChanged("ScannedPassport2");
                }
            }
        }

        [DataMember]
        public string VisaNumber
        {
            get { return _visaNumber; }
            set
            {
                if (_visaNumber != value)
                {
                    _visaNumber = value;
                    PropertyHasChanged("VisaNumber");
                }
            }
        }

        [DataMember]
        public DateTime? VisaDateOfIssue
        {
            get { return _visaDateOfIssue; }
            set
            {
                if (_visaDateOfIssue != value)
                {
                    _visaDateOfIssue = value;
                    PropertyHasChanged("VisaDateOfIssue");
                }
            }
        }

        [DataMember]
        public DateTime? VisaDateOfExpiry
        {
            get { return _visaDateOfExpiry; }
            set
            {
                if (_visaDateOfExpiry != value)
                {
                    _visaDateOfExpiry = value;
                    PropertyHasChanged("VisaDateOfExpiry");
                }
            }
        }

        [DataMember]
        public string VisaPlaceOfIssue
        {
            get { return _visaPlaceOfIssue; }
            set
            {
                if (_visaPlaceOfIssue != value)
                {
                    _visaPlaceOfIssue = value;
                    PropertyHasChanged("VisaPlaceOfIssue");
                }
            }
        }

        [DataMember]
        public string ScannedVisa
        {
            get { return _scannedVisa; }
            set
            {
                if (_scannedVisa != value)
                {
                    _scannedVisa = value;
                    PropertyHasChanged("ScannedVisa");
                }
            }
        }

        [DataMember]
        public string VisaType
        {
            get { return _visaType; }
            set
            {
                if (_visaType != value)
                {
                    _visaType = value;
                    PropertyHasChanged("VisaType");
                }
            }
        }

        [DataMember]
        public int? DurationOfStay
        {
            get { return _durationOfStay; }
            set
            {
                if (_durationOfStay != value)
                {
                    _durationOfStay = value;
                    PropertyHasChanged("DurationOfStay");
                }
            }
        }

        [DataMember]
        public string PurposeOfVisa
        {
            get { return _purposeOfVisa; }
            set
            {
                if (_purposeOfVisa != value)
                {
                    _purposeOfVisa = value;
                    PropertyHasChanged("PurposeOfVisa");
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


        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ForeignNationalityID", "ForeignNationalityID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("Nationality", "Nationality", 150));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PassportNumber", "PassportNumber", 150));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PassportPlaceOfIssue", "PassportPlaceOfIssue", 150));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ScannedPassport1", "ScannedPassport1", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ScannedPassport2", "ScannedPassport2", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("VisaNumber", "VisaNumber", 100));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("VisaPlaceOfIssue", "VisaPlaceOfIssue", 150));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ScannedVisa", "ScannedVisa", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("VisaType", "VisaType", 100));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("PurposeOfVisa", "PurposeOfVisa", 250));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "ForeignNationalityID = {0}\n" +
            "ReservationID = {1}\n" +
            "GuestID = {2}\n" +
            "Nationality = {3}\n" +
            "IDType = {4}\n" +
            "PassportNumber = {5}\n" +
            "PassportDateOfIssue = {6}\n" +
            "PassportDateOfExpiry = {7}\n" +
            "PassportPlaceOfIssue = {8}\n" +
            "ScannedPassport1 = {9}\n" +
            "ScannedPassport2 = {10}\n" +
            "VisaNumber = {11}\n" +
            "VisaDateOfIssue = {12}\n" +
            "VisaDateOfExpiry = {13}\n" +
            "VisaPlaceOfIssue = {14}\n" +
            "ScannedVisa = {15}\n" +
            "VisaType = {16}\n" +
            "DurationOfStay = {17}\n" +
            "PurposeOfVisa = {18}\n" +
            "SeqNo = {19}\n" +
            "PropertyID = {20}\n" +
            "CompanyID = {21}\n" +
            "IsSynch = {22}\n" +
            "SynchOn = {23}\n" +
            "UpdatedOn = {24}\n" +
            "UpdatedBy = {25}\n" +
            "CreatedOn = {26}\n" +
            "CreatedBy = {27}\n",
            ForeignNationalityID, ReservationID, GuestID, Nationality, IDType, PassportNumber, PassportDateOfIssue, PassportDateOfExpiry, PassportPlaceOfIssue, ScannedPassport1, ScannedPassport2, VisaNumber, VisaDateOfIssue, VisaDateOfExpiry, VisaPlaceOfIssue, ScannedVisa, VisaType, DurationOfStay, PurposeOfVisa, SeqNo, PropertyID, CompanyID, IsSynch, SynchOn, UpdatedOn, UpdatedBy, CreatedOn, CreatedBy); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class ForeignNationalInfoKeys
    {

        #region Data Members

        Guid _foreignNationalityID;

        #endregion

        #region Constructor

        public ForeignNationalInfoKeys(Guid foreignNationalityID)
        {
            _foreignNationalityID = foreignNationalityID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid ForeignNationalityID
        {
            get { return _foreignNationalityID; }
        }

        #endregion

    }
}
