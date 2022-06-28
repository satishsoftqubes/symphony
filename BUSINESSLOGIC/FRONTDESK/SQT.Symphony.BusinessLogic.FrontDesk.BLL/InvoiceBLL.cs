using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SQT.FRAMEWORK.DAL.Linq.Exceptions;
using SQT.FRAMEWORK.DAL.Validation;
using SQT.FRAMEWORK.EXCEPTION;
using SQT.FRAMEWORK.LOGGER;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SQT.FRAMEWORK.DAL.Linq;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.DAL;

namespace SQT.Symphony.BusinessLogic.FrontDesk.BLL
{
    public static class InvoiceBLL
    { 

        //#region data Members

        //private static InvoiceDAL _dataObject = null;

        //#endregion

        #region Constructor

        static InvoiceBLL()
        {
            //_dataObject = new InvoiceDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Invoice
        /// </summary>
        /// <param name="businessObject">Invoice object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Invoice businessObject)
        {
            InvoiceDAL _dataObject = new InvoiceDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.InvoiceID = Guid.NewGuid();
                    
                        if (!businessObject.IsValid)
                        {
                            throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                        }
                        return _dataObject.Insert(businessObject);
                    }
                }
                else
                {
                    throw new InvalidBusinessObjectException("Object Is NULL");
                }
            }
            catch
            {
                throw;
            }
        }

        public static bool Save(Invoice businessObject, DateTime FromDate, DateTime ToDate)
        {
            bool flag = false;
            InvoiceDAL _dataObject = null;
            BookKeepingDAL _bkpDAL = null;

            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new InvoiceDAL(lt.Transaction);

                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.InvoiceID = Guid.NewGuid();

                        if (!businessObject.IsValid)
                        {
                            throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                        }
                        flag = _dataObject.Insert(businessObject);
                    }

                    _bkpDAL = new BookKeepingDAL(lt.Transaction); 
                    flag = _bkpDAL.UpdateByInvoiceID((Guid)businessObject.ReservationID, (Guid)businessObject.FolioID, FromDate, ToDate, businessObject.InvoiceID);

                    if (flag)
                    {
                        lt.Commit();
                        return flag;
                    }
                    else
                    {
                        lt.Rollback();
                    }
                }
                else
                {
                    lt.Rollback();
                    throw new InvalidBusinessObjectException("Object Is NULL");
                }
            }
            catch
            {
                lt.Rollback();
                throw;
            }
            return flag;
        }

        /// <summary>
        /// Update existing Invoice
        /// </summary>
        /// <param name="businessObject">Invoice object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Invoice businessObject)
        {
            InvoiceDAL _dataObject = new InvoiceDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        if (!businessObject.IsValid)
                        {
                            throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                        }
                        return _dataObject.Update(businessObject);
                    }
                }
                else
                {
                    throw new InvalidBusinessObjectException("Object Is NULL");
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// get Invoice by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Invoice GetByPrimaryKey(Guid keys)
        {
            InvoiceDAL _dataObject = new InvoiceDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Invoices
        /// </summary>
        /// <returns>list</returns>
        public static List<Invoice> GetAll(Invoice obj)
        {
            InvoiceDAL _dataObject = new InvoiceDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Invoices
        /// </summary>
        /// <returns>list</returns>
        public static List<Invoice> GetAll()
        {
            InvoiceDAL _dataObject = new InvoiceDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Invoice by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Invoice> GetAllBy(Invoice.InvoiceFields fieldName, object value)
        {
            InvoiceDAL _dataObject = new InvoiceDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Invoices
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Invoice obj)
        {
            InvoiceDAL _dataObject = new InvoiceDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Invoices
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            InvoiceDAL _dataObject = new InvoiceDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Invoice by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Invoice.InvoiceFields fieldName, object value)
        {
            InvoiceDAL _dataObject = new InvoiceDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        public static DataSet GetRPTInvoiceReservationDetail(Guid? InvoiceID, Guid? ReservationID, Guid? FolioID)
        {
            InvoiceDAL _dataObject = new InvoiceDAL();
            return _dataObject.SelectRPTInvoiceReservationDetail(InvoiceID, ReservationID, FolioID);
        }

        public static DataSet GetRPTInvoiceBillSummary(Guid? ReservationID, Guid? FolioID)
        {
            InvoiceDAL _dataObject = new InvoiceDAL();
            return _dataObject.SelectRPTBillFormatSummary(ReservationID, FolioID);
        }

        public static DataSet GetRPTInvoiceBillSummary4CompanyInvoice(Guid? ReservationID)
        {
            InvoiceDAL _dataObject = new InvoiceDAL();
            return _dataObject.SelectRPTBillFormatSummary4CompanyInvoice(ReservationID);
        }

        public static DataSet GetRPTInvoiceBillDetail(Guid? ReservationID, Guid? FolioID)
        {
            InvoiceDAL _dataObject = new InvoiceDAL();
            return _dataObject.SelectRPTInvoiceBillDetail(ReservationID, FolioID);
        }
        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            InvoiceDAL _dataObject = new InvoiceDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Invoice obj)
        {
            InvoiceDAL _dataObject = new InvoiceDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Invoice by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Invoice.InvoiceFields fieldName, object value)
        {
            InvoiceDAL _dataObject = new InvoiceDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet GetAll4RePrintCompanyInvoice(DateTime startDate, DateTime endDate, Guid? AgentID, Guid? PropertyID, Guid? CompanyID, Guid? BillingInstructionID)
        {
            InvoiceDAL _dataObject = new InvoiceDAL();
            return _dataObject.SelectAll4RePrintCompanyInvoice(startDate,endDate, AgentID, PropertyID, CompanyID, BillingInstructionID);
        }

        public static DataSet SelectInvoicesOfCompany(Guid? InvoiceID, string InvoiceNo, Guid? GuestID, Guid? AgentID, bool IsPaid, Guid? PropertyID, Guid? CompanyID)
        {
            InvoiceDAL _dataObject = new InvoiceDAL();
            return _dataObject.SelectInvoicesOfCompany(InvoiceID, InvoiceNo, GuestID, AgentID, IsPaid, PropertyID, CompanyID);
        }

        public static bool AgentReceivePayment(Guid? MOPAcctID, decimal Amt, Guid? AgentID, DateTime ReceiptDate, string Description, Guid? UserID, Guid? CounterID, Guid? PropertyID, string Transaction_Origin, Guid? ResPayID, decimal SettledAmt, Guid? CompanyID, ref Guid Ret_BookID, ref Guid ReceiptID)
        {
            InvoiceDAL _dataObject = new InvoiceDAL();
            return _dataObject.AgentReceivePayment(MOPAcctID, Amt, AgentID, ReceiptDate, Description, UserID, CounterID, PropertyID, Transaction_Origin, ResPayID, SettledAmt, CompanyID, ref Ret_BookID,ref ReceiptID);
        }

        #endregion

    }
}
