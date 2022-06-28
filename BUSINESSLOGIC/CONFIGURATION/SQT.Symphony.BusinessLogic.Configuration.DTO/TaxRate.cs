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
    public class TaxRate : BusinessObjectBase
    {

        #region InnerClass
        public enum TaxRateFields
        {
            TaxRateID,
            TaxID,
            TaxRateAmount,
            IsTaxFlat,
            StartDate,
            EndDate,
            SlabeName
        }
        #endregion

        #region Data Members

        Guid _taxRateID;
        Guid? _taxID;
        decimal? _taxRateAmount;
        bool? _isTaxFlat;
        DateTime? _startDate;
        DateTime? _endDate;
        string _slabename;

        #endregion

        #region Properties

        [DataMember]
        public Guid TaxRateID
        {
            get { return _taxRateID; }
            set
            {
                if (_taxRateID != value)
                {
                    _taxRateID = value;
                    PropertyHasChanged("TaxRateID");
                }
            }
        }
        [DataMember]
        public string SlabeName
        {
            get { return _slabename ; }
            set
            {
                if (_slabename  != value)
                {
                    _slabename  = value;
                    PropertyHasChanged("SlabeName");
                }
            }
        }

        [DataMember]
        public Guid? TaxID
        {
            get { return _taxID; }
            set
            {
                if (_taxID != value)
                {
                    _taxID = value;
                    PropertyHasChanged("TaxID");
                }
            }
        }

        [DataMember]
        public decimal? TaxRateAmount
        {
            get { return _taxRateAmount; }
            set
            {
                if (_taxRateAmount != value)
                {
                    _taxRateAmount = value;
                    PropertyHasChanged("TaxRateAmount");
                }
            }
        }

        [DataMember]
        public bool? IsTaxFlat
        {
            get { return _isTaxFlat; }
            set
            {
                if (_isTaxFlat != value)
                {
                    _isTaxFlat = value;
                    PropertyHasChanged("IsTaxFlat");
                }
            }
        }

        [DataMember]
        public DateTime? StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    PropertyHasChanged("StartDate");
                }
            }
        }

        [DataMember]
        public DateTime? EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    PropertyHasChanged("EndDate");
                }
            }
        }


        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("TaxRateID", "TaxRateID"));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "TaxRateID = {0}\n" +
            "TaxID = {1}\n" +
            "TaxRateAmount = {2}\n" +
            "IsTaxFlat = {3}\n" +
            "StartDate = {4}\n" +
            "EndDate = {5}\n" +
            "SlabeName = {6}\n",
            TaxRateID, TaxID, TaxRateAmount, IsTaxFlat, StartDate, EndDate, SlabeName); return objValue;
        }

        #endregion

    }
    [DataContract]
    public class TaxRateKeys
    {

        #region Data Members

        Guid _taxRateID;

        #endregion

        #region Constructor

        public TaxRateKeys(Guid taxRateID)
        {
            _taxRateID = taxRateID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid TaxRateID
        {
            get { return _taxRateID; }
        }

        #endregion

    }
}
