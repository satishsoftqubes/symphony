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
    public class Item : BusinessObjectBase
    {

        #region InnerClass
        public enum ItemFields
        {
            ItemID,
            PropertyID,
            CompanyID,
            SeqNo,
            IsSynch,
            SynchOn,
            UpdatedOn,
            UpdatedBy,
            IsActive,
            ItemCode,
            ItemName,
            ItemType_TermID,
            ItemStatus_TermID,
            PostingAcctID,
            COGSAcctID,
            AssetAcctID,
            PreferredSupplierID,
            MinStock,
            MaxStock,
            StockInHand,
            UOMID,
            DefPurPrice,
            DefSalesPrice,
            ReOrderLevel,
            ItemImage,
            ItemDetails,
            ItemCategoryID,
            BarcodeText,
            IsStockPart,
            IsConsumable,
            IsRoomService,
            SymphonyItemType,
            IsDelete
        }
        #endregion

        #region Data Members

        Guid _itemID;
        Guid? _propertyID;
        Guid? _companyID;
        int _seqNo;
        bool? _isSynch;
        DateTime? _synchOn;
        DateTime? _updatedOn;
        Guid? _updatedBy;
        bool? _isActive;
        string _itemCode;
        string _itemName;
        Guid? _itemType_TermID;
        Guid? _itemStatus_TermID;
        Guid? _postingAcctID;
        Guid? _cOGSAcctID;
        Guid? _assetAcctID;
        Guid? _preferredSupplierID;
        decimal? _minStock;
        decimal? _maxStock;
        decimal? _stockInHand;
        Guid? _uOMID;
        decimal? _defPurPrice;
        decimal? _defSalesPrice;
        decimal? _reOrderLevel;
        string _itemImage;
        string _itemDetails;
        Guid? _itemCategoryID;
        string _barcodeText;
        bool? _isStockPart;
        bool? _isConsumable;
        bool? _isRoomService;
        int? _symphonyItemType;
        bool? _IsDelete;

        #endregion

        #region Properties

        [DataMember]
        public Guid ItemID
        {
            get { return _itemID; }
            set
            {
                if (_itemID != value)
                {
                    _itemID = value;
                    PropertyHasChanged("ItemID");
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
        public bool? IsRoomService
        {
            get { return _isRoomService; }
            set
            {
                if (_isRoomService != value)
                {
                    _isRoomService = value;
                    PropertyHasChanged("IsRoomService");
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
        public string ItemCode
        {
            get { return _itemCode; }
            set
            {
                if (_itemCode != value)
                {
                    _itemCode = value;
                    PropertyHasChanged("ItemCode");
                }
            }
        }

        [DataMember]
        public string ItemName
        {
            get { return _itemName; }
            set
            {
                if (_itemName != value)
                {
                    _itemName = value;
                    PropertyHasChanged("ItemName");
                }
            }
        }

        [DataMember]
        public Guid? ItemType_TermID
        {
            get { return _itemType_TermID; }
            set
            {
                if (_itemType_TermID != value)
                {
                    _itemType_TermID = value;
                    PropertyHasChanged("ItemType_TermID");
                }
            }
        }

        [DataMember]
        public Guid? ItemStatus_TermID
        {
            get { return _itemStatus_TermID; }
            set
            {
                if (_itemStatus_TermID != value)
                {
                    _itemStatus_TermID = value;
                    PropertyHasChanged("ItemStatus_TermID");
                }
            }
        }

        [DataMember]
        public Guid? PostingAcctID
        {
            get { return _postingAcctID; }
            set
            {
                if (_postingAcctID != value)
                {
                    _postingAcctID = value;
                    PropertyHasChanged("PostingAcctID");
                }
            }
        }

        [DataMember]
        public Guid? COGSAcctID
        {
            get { return _cOGSAcctID; }
            set
            {
                if (_cOGSAcctID != value)
                {
                    _cOGSAcctID = value;
                    PropertyHasChanged("COGSAcctID");
                }
            }
        }

        [DataMember]
        public Guid? AssetAcctID
        {
            get { return _assetAcctID; }
            set
            {
                if (_assetAcctID != value)
                {
                    _assetAcctID = value;
                    PropertyHasChanged("AssetAcctID");
                }
            }
        }

        [DataMember]
        public Guid? PreferredSupplierID
        {
            get { return _preferredSupplierID; }
            set
            {
                if (_preferredSupplierID != value)
                {
                    _preferredSupplierID = value;
                    PropertyHasChanged("PreferredSupplierID");
                }
            }
        }

        [DataMember]
        public decimal? MinStock
        {
            get { return _minStock; }
            set
            {
                if (_minStock != value)
                {
                    _minStock = value;
                    PropertyHasChanged("MinStock");
                }
            }
        }

        [DataMember]
        public decimal? MaxStock
        {
            get { return _maxStock; }
            set
            {
                if (_maxStock != value)
                {
                    _maxStock = value;
                    PropertyHasChanged("MaxStock");
                }
            }
        }

        [DataMember]
        public decimal? StockInHand
        {
            get { return _stockInHand; }
            set
            {
                if (_stockInHand != value)
                {
                    _stockInHand = value;
                    PropertyHasChanged("StockInHand");
                }
            }
        }

        [DataMember]
        public Guid? UOMID
        {
            get { return _uOMID; }
            set
            {
                if (_uOMID != value)
                {
                    _uOMID = value;
                    PropertyHasChanged("UOMID");
                }
            }
        }

        [DataMember]
        public decimal? DefPurPrice
        {
            get { return _defPurPrice; }
            set
            {
                if (_defPurPrice != value)
                {
                    _defPurPrice = value;
                    PropertyHasChanged("DefPurPrice");
                }
            }
        }

        [DataMember]
        public decimal? DefSalesPrice
        {
            get { return _defSalesPrice; }
            set
            {
                if (_defSalesPrice != value)
                {
                    _defSalesPrice = value;
                    PropertyHasChanged("DefSalesPrice");
                }
            }
        }

        [DataMember]
        public decimal? ReOrderLevel
        {
            get { return _reOrderLevel; }
            set
            {
                if (_reOrderLevel != value)
                {
                    _reOrderLevel = value;
                    PropertyHasChanged("ReOrderLevel");
                }
            }
        }

        [DataMember]
        public string ItemImage
        {
            get { return _itemImage; }
            set
            {
                if (_itemImage != value)
                {
                    _itemImage = value;
                    PropertyHasChanged("ItemImage");
                }
            }
        }

        [DataMember]
        public string ItemDetails
        {
            get { return _itemDetails; }
            set
            {
                if (_itemDetails != value)
                {
                    _itemDetails = value;
                    PropertyHasChanged("ItemDetails");
                }
            }
        }

        [DataMember]
        public Guid? ItemCategoryID
        {
            get { return _itemCategoryID; }
            set
            {
                if (_itemCategoryID != value)
                {
                    _itemCategoryID = value;
                    PropertyHasChanged("ItemCategoryID");
                }
            }
        }

        [DataMember]
        public string BarcodeText
        {
            get { return _barcodeText; }
            set
            {
                if (_barcodeText != value)
                {
                    _barcodeText = value;
                    PropertyHasChanged("BarcodeText");
                }
            }
        }

        [DataMember]
        public bool? IsStockPart
        {
            get { return _isStockPart; }
            set
            {
                if (_isStockPart != value)
                {
                    _isStockPart = value;
                    PropertyHasChanged("IsStockPart");
                }
            }
        }

        [DataMember]
        public bool? IsConsumable
        {
            get { return _isConsumable; }
            set
            {
                if (_isConsumable != value)
                {
                    _isConsumable = value;
                    PropertyHasChanged("IsConsumable");
                }
            }
        }

        [DataMember]
        public int? SymphonyItemType
        {
            get { return _symphonyItemType; }
            set
            {
                if (_symphonyItemType != value)
                {
                    _symphonyItemType = value;
                    PropertyHasChanged("SymphonyItemType");
                }
            }
        }

        [DataMember]
        public bool? IsDelete
        {
            get { return _IsDelete; }
            set
            {
                if (_IsDelete != value)
                {
                    _IsDelete = value;
                    PropertyHasChanged("IsDelete");
                }
            }
        }

        #endregion

        #region Validation

        [OperationContract]
        protected override void AddValidationRules()
        {
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("ItemID", "ItemID"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleNotNull("SeqNo", "SeqNo"));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ItemCode", "ItemCode", 7));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ItemName", "ItemName", 67));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ItemImage", "ItemImage", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("ItemDetails", "ItemDetails", 2147483647));
            ValidationRules.AddRules(new SQT.FRAMEWORK.DAL.Validation.ValidateRuleStringMaxLength("BarcodeText", "BarcodeText", 64));
        }

        [OperationContract]
        public override string ToString()
        {
            string objValue = string.Format(
            "ItemID = {0}~\n" +
            "PropertyID = {1}~\n" +
            "CompanyID = {2}~\n" +
            "SeqNo = {3}~\n" +
            "IsSynch = {4}~\n" +
            "SynchOn = {5}~\n" +
            "UpdatedOn = {6}~\n" +
            "UpdatedBy = {7}~\n" +
            "IsActive = {8}~\n" +
            "ItemCode = {9}~\n" +
            "ItemName = {10}~\n" +
            "ItemType_TermID = {11}~\n" +
            "ItemStatus_TermID = {12}~\n" +
            "PostingAcctID = {13}~\n" +
            "COGSAcctID = {14}~\n" +
            "AssetAcctID = {15}~\n" +
            "PreferredSupplierID = {16}~\n" +
            "MinStock = {17}~\n" +
            "MaxStock = {18}~\n" +
            "StockInHand = {19}~\n" +
            "UOMID = {20}~\n" +
            "DefPurPrice = {21}~\n" +
            "DefSalesPrice = {22}~\n" +
            "ReOrderLevel = {23}~\n" +
            "ItemImage = {24}~\n" +
            "ItemDetails = {25}~\n" +
            "ItemCategoryID = {26}~\n" +
            "BarcodeText = {27}~\n" +
            "IsStockPart = {28}~\n" +
            "IsConsumable = {29}~\n",
            "IsRoomService ={30}~\n",
            "IsDelete = {31}~\n",
            ItemID, PropertyID, CompanyID, SeqNo, IsSynch, SynchOn, UpdatedOn, UpdatedBy, IsActive, ItemCode, ItemName, ItemType_TermID, ItemStatus_TermID, PostingAcctID, COGSAcctID, AssetAcctID, PreferredSupplierID, MinStock, MaxStock, StockInHand, UOMID, DefPurPrice, DefSalesPrice, ReOrderLevel, ItemImage, ItemDetails, ItemCategoryID, BarcodeText, IsStockPart, IsConsumable, IsRoomService, IsDelete); return objValue;
        }

        #endregion

    }

    [DataContract]
    public class ItemKeys
    {

        #region Data Members

        Guid _itemID;

        #endregion

        #region Constructor

        public ItemKeys(Guid itemID)
        {
            _itemID = itemID;
        }

        #endregion

        #region Properties

        [DataMember]
        public Guid ItemID
        {
            get { return _itemID; }
        }

        #endregion

    }
}
