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
	public class ResGuestPaymentInfo: BusinessObjectBase
	{

		#region InnerClass
		public enum ResGuestPaymentInfoFields
		{
			ResPayID,
			ReservationID,
			FolioID,
			GuestID,
			MOP_TermID,
			CardName,
			CardNo,
			CardHolderName,
			DateOfExpiry,
			LastUsage,
			LastUsageAmt,
			BankName,
			CardType_TermID,
			ChequeNo,
			RefNo,
			PropertyID,
			CompanyID,
			SeqNo,
			IsSynch,
			SynchOn,
			UpdatedOn,
			UpdatedBy,
			IsActive,
            CVVNo,
            IsCreditCardCharged
		}
		#endregion

		#region Data Members

			Guid _resPayID;
			Guid? _reservationID;
			Guid? _folioID;
			Guid? _guestID;
			Guid? _mOP_TermID;
			string _cardName;
			string _cardNo;
			string _cardHolderName;
			DateTime? _dateOfExpiry;
			DateTime? _lastUsage;
			decimal? _lastUsageAmt;
			string _bankName;
			Guid? _cardType_TermID;
			string _chequeNo;
			string _refNo;
			Guid? _propertyID;
			Guid? _companyID;
			long _seqNo;
			bool? _isSynch;
			DateTime? _synchOn;
			DateTime? _updatedOn;
			Guid? _updatedBy;
			bool? _isActive;
            string _cVVNo;
            bool? _isCreditCardCharged;

		#endregion

		#region Properties

		[DataMember]
		public Guid  ResPayID
		{
			 get { return _resPayID; }
			 set
			 {
				 if (_resPayID != value)
				 {
					_resPayID = value;
					 PropertyHasChanged("ResPayID");
				 }
			 }
		}

		[DataMember]
		public Guid?  ReservationID
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
		public Guid?  FolioID
		{
			 get { return _folioID; }
			 set
			 {
				 if (_folioID != value)
				 {
					_folioID = value;
					 PropertyHasChanged("FolioID");
				 }
			 }
		}

		[DataMember]
		public Guid?  GuestID
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
		public Guid?  MOP_TermID
		{
			 get { return _mOP_TermID; }
			 set
			 {
				 if (_mOP_TermID != value)
				 {
					_mOP_TermID = value;
					 PropertyHasChanged("MOP_TermID");
				 }
			 }
		}

		[DataMember]
		public string  CardName
		{
			 get { return _cardName; }
			 set
			 {
				 if (_cardName != value)
				 {
					_cardName = value;
					 PropertyHasChanged("CardName");
				 }
			 }
		}

		[DataMember]
		public string  CardNo
		{
			 get { return _cardNo; }
			 set
			 {
				 if (_cardNo != value)
				 {
					_cardNo = value;
					 PropertyHasChanged("CardNo");
				 }
			 }
		}

		[DataMember]
		public string  CardHolderName
		{
			 get { return _cardHolderName; }
			 set
			 {
				 if (_cardHolderName != value)
				 {
					_cardHolderName = value;
					 PropertyHasChanged("CardHolderName");
				 }
			 }
		}

		[DataMember]
		public DateTime?  DateOfExpiry
		{
			 get { return _dateOfExpiry; }
			 set
			 {
				 if (_dateOfExpiry != value)
				 {
					_dateOfExpiry = value;
					 PropertyHasChanged("DateOfExpiry");
				 }
			 }
		}

		[DataMember]
		public DateTime?  LastUsage
		{
			 get { return _lastUsage; }
			 set
			 {
				 if (_lastUsage != value)
				 {
					_lastUsage = value;
					 PropertyHasChanged("LastUsage");
				 }
			 }
		}

		[DataMember]
		public decimal?  LastUsageAmt
		{
			 get { return _lastUsageAmt; }
			 set
			 {
				 if (_lastUsageAmt != value)
				 {
					_lastUsageAmt = value;
					 PropertyHasChanged("LastUsageAmt");
				 }
			 }
		}

		[DataMember]
		public string  BankName
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
		public Guid?  CardType_TermID
		{
			 get { return _cardType_TermID; }
			 set
			 {
				 if (_cardType_TermID != value)
				 {
					_cardType_TermID = value;
					 PropertyHasChanged("CardType_TermID");
				 }
			 }
		}

		[DataMember]
		public string  ChequeNo
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
		public string  RefNo
		{
			 get { return _refNo; }
			 set
			 {
				 if (_refNo != value)
				 {
					_refNo = value;
					 PropertyHasChanged("RefNo");
				 }
			 }
		}

		[DataMember]
		public Guid?  PropertyID
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
		public Guid?  CompanyID
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
		public long  SeqNo
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
		public bool?  IsSynch
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
		public DateTime?  SynchOn
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
		public DateTime?  UpdatedOn
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
		public Guid?  UpdatedBy
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
		public bool?  IsActive
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
        public string CVVNo
        {
            get { return _cVVNo; }
            set
            {
                if (_cVVNo != value)
                {
                    _cVVNo= value;
                    PropertyHasChanged("CVVNo");
                }
            }
        }

        [DataMember]
        public bool? IsCreditCardCharged
		{
            get { return _isCreditCardCharged; }
			 set
			 {
                 if (_isCreditCardCharged != value)
				 {
                     _isCreditCardCharged = value;
                     PropertyHasChanged("IsCreditCardCharged");
				 }
			 }
		}

		#endregion

		#region Validation

		[OperationContract]
		protected override void AddValidationRules()
		{
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ResPayID", "ResPayID"));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CardName", "CardName",165));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CardNo", "CardNo",36));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("CardHolderName", "CardHolderName",320));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("BankName", "BankName",360));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ChequeNo", "ChequeNo",10));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("RefNo", "RefNo",60));
			ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
		}

		[OperationContract]
		public override string ToString()
		{
			string objValue = string.Format(
			"ResPayID = {0}\n"+
			"ReservationID = {1}\n"+
			"FolioID = {2}\n"+
			"GuestID = {3}\n"+
			"MOP_TermID = {4}\n"+
			"CardName = {5}\n"+
			"CardNo = {6}\n"+
			"CardHolderName = {7}\n"+
			"DateOfExpiry = {8}\n"+
			"LastUsage = {9}\n"+
			"LastUsageAmt = {10}\n"+
			"BankName = {11}\n"+
			"CardType_TermID = {12}\n"+
			"ChequeNo = {13}\n"+
			"RefNo = {14}\n"+
			"PropertyID = {15}\n"+
			"CompanyID = {16}\n"+
			"SeqNo = {17}\n"+
			"IsSynch = {18}\n"+
			"SynchOn = {19}\n"+
			"UpdatedOn = {20}\n"+
			"UpdatedBy = {21}\n"+
			"IsActive = {22}\n"+
            "CVVNo = {23}\n" +
            "IsCreditCardCharged = {24}\n",

            ResPayID, ReservationID, FolioID, GuestID, MOP_TermID, CardName, CardNo, CardHolderName, DateOfExpiry, LastUsage, LastUsageAmt, BankName, CardType_TermID, ChequeNo, RefNo, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, CVVNo, IsCreditCardCharged); return objValue;
		}

		#endregion

	}
	[DataContract]
	public class ResGuestPaymentInfoKeys
	{

		#region Data Members

		Guid _resPayID;

		#endregion

		#region Constructor

		public ResGuestPaymentInfoKeys(Guid resPayID)
		{
			 _resPayID = resPayID; 
		}

		#endregion

		#region Properties

		[DataMember]
		public Guid  ResPayID
		{
			 get { return _resPayID; }
		}

		#endregion

	}
}
