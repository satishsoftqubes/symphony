using SQT.FRAMEWORK.DAL.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SQT.Symphony.BusinessLogic.Configuration.DTO
{
    [DataContract]
    public class Expense : BusinessObjectBase
    {
        #region InnerClass
        public enum PropertyExpense
        {
            ExpenseID,
            PropertyID,
            DateOfExpense,
            ExpenseByAssociationID,
            AssociationTypeTerm,
            ExpenseTypeTerm,
            ExpenseAmount,
            ModeOfPaymentTerm,
            ExpenseDetail,
            UploadDocument,
            VendorID,
            VendorName,
            Category,
            DisplayTerm,
            TermID,
            PropertyExpenseDetailID,
            PurchaseNote,
            TotalAmount,
            TotalPaid,
            TotalDue,
            PurchaseTypeTerm,
            ItemTypeTerm,
        }
        #endregion

        #region Data Members
        Guid _ExpenseID;
        Guid _PropertyID;
        DateTime _DateOfExpense;
        Guid _ExpenseByAssociationID;
        string _AssociationTypeTerm;
        string _ExpenseTypeTerm;
        Decimal _ExpenseAmount;
        string _ModeOfPaymentTerm;
        string _ExpenseDetail;
        Guid _VendorID;
        string _VendorName;
        string _Category;
        string _DisplayTerm;
        Guid _TermID;
        Guid _PropertyExpenseDetailID;
        string _PurchaseNote;
        Decimal _TotalAmount;
        Decimal _TotalPaid;
        Decimal _TotalDue;
        string _PurchaseTypeTerm;
        string _ItemTypeTerm;
        #endregion

        #region Properties

        [DataMember]
        public Guid ExpenseID
        {
            get { return _ExpenseID; }
            set
            {
                if (_ExpenseID != value)
                {
                    _ExpenseID = value;
                    PropertyHasChanged("ExpenseID");
                }
            }
        }
        [DataMember]
        public Guid PropertyID
        {
            get { return _PropertyID; }
            set
            {
                if (_PropertyID != value)
                {
                    _PropertyID = value;
                    PropertyHasChanged("PropertyID");
                }
            }
        }
        [DataMember]
        public DateTime DateOfExpense
        {
            get { return _DateOfExpense; }
            set
            {
                if (_DateOfExpense != value)
                {
                    _DateOfExpense = value;
                    PropertyHasChanged("DateOfExpense");
                }
            }
        }
        [DataMember]
        public Guid ExpenseByAssociationID
        {
            get { return _ExpenseByAssociationID; }
            set
            {
                if (_ExpenseByAssociationID != value)
                {
                    _ExpenseByAssociationID = value;
                    PropertyHasChanged("ExpenseByAssociationID");
                }
            }
        }
        [DataMember]
        public string AssociationTypeTerm
        {
            get { return _AssociationTypeTerm; }
            set
            {
                if (_AssociationTypeTerm != value)
                {
                    _AssociationTypeTerm = value;
                    PropertyHasChanged("AssociationTypeTerm");
                }
            }
        }
        [DataMember]
        public string ExpenseTypeTerm
        {
            get { return _ExpenseTypeTerm; }
            set
            {
                if (_ExpenseTypeTerm != value)
                {
                    _ExpenseTypeTerm = value;
                    PropertyHasChanged("ExpenseTypeTerm");
                }
            }
        }
        [DataMember]
        public Decimal ExpenseAmount
        {
            get { return _ExpenseAmount; }
            set
            {
                if (_ExpenseAmount != value)
                {
                    _ExpenseAmount = value;
                    PropertyHasChanged("ExpenseAmount");
                }
            }
        }
        [DataMember]
        public string ModeOfPaymentTerm
        {
            get { return _ModeOfPaymentTerm; }
            set
            {
                if (_ModeOfPaymentTerm != value)
                {
                    _ModeOfPaymentTerm = value;
                    PropertyHasChanged("ModeOfPaymentTerm");
                }
            }
        }
        [DataMember]
        public string ExpenseDetail
        {
            get { return _ExpenseDetail; }
            set
            {
                if (_ExpenseDetail != value)
                {
                    _ExpenseDetail = value;
                    PropertyHasChanged("ExpenseDetail");
                }
            }
        }
        [DataMember]
        public Guid VendorID
        {
            get { return _VendorID; }
            set
            {
                if (_VendorID != value)
                {
                    _VendorID = value;
                    PropertyHasChanged("VendorID");
                }
            }
        }
        [DataMember]
        public string VendorName
        {
            get { return _VendorName; }
            set
            {
                if (_VendorName != value)
                {
                    _VendorName = value;
                    PropertyHasChanged("VendorName");
                }
            }
        }
        [DataMember]
        public string Category
        {
            get { return _Category; }
            set
            {
                if (_Category != value)
                {
                    _Category = value;
                    PropertyHasChanged("Category");
                }
            }
        }
        [DataMember]
        public string DisplayTerm
        {
            get { return _DisplayTerm; }
            set
            {
                if (_DisplayTerm != value)
                {
                    _DisplayTerm = value;
                    PropertyHasChanged("DisplayTerm");
                }
            }
        }
        [DataMember]
        public Guid TermID
        {
            get { return _TermID; }
            set
            {
                if (_TermID != value)
                {
                    _TermID = value;
                    PropertyHasChanged("TermID");
                }
            }
        }
        [DataMember]
        public Guid PropertyExpenseDetailID
        {
            get { return _PropertyExpenseDetailID; }
            set {
                if (_PropertyExpenseDetailID != value)
                {
                    _PropertyExpenseDetailID = value;
                    PropertyHasChanged("PropertyExpenseDetailID");
                }
            }
        }
        [DataMember]
        public string PurchaseNote {
            get { return _PurchaseNote; }
            set {
                if(_PurchaseNote != value)
                {
                    _PurchaseNote = value;
                    PropertyHasChanged("PurchaseNote");
                }
            }
        }
        [DataMember]
        public Decimal TotalAmount
        {
            get { return _TotalAmount; }
            set
            {
                if (_TotalAmount != value)
                {
                    _TotalAmount = value;
                    PropertyHasChanged("TotalAmount");
                }
            }
        }
        [DataMember]
        public Decimal TotalDue
        {
            get { return _TotalDue; }
            set
            {
                if (_TotalDue != value)
                {
                    _TotalDue = value;
                    PropertyHasChanged("TotalDue");
                }
            }
        }
        [DataMember]
        public string PurchaseTypeTerm
        {
            get { return _PurchaseTypeTerm; }
            set
            {
                if (_PurchaseTypeTerm != value)
                {
                    _PurchaseTypeTerm = value;
                    PropertyHasChanged("PurchaseTypeTerm");
                }
            }
        }
        [DataMember]
        public string ItemTypeTerm
        {
            get { return _ItemTypeTerm; }
            set
            {
                if (_ItemTypeTerm != value)
                {
                    _ItemTypeTerm = value;
                    PropertyHasChanged("ItemTypeTerm");
                }
            }
        }
        
        #endregion
    }
}
