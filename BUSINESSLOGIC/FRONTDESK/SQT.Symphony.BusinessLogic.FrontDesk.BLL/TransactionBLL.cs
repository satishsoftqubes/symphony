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
    public static class TransactionBLL
    {

        //#region data Members

        //private static TransactionDAL _dataObject = null;

        //#endregion

        #region Constructor

        static TransactionBLL()
        {
            //_dataObject = new TransactionDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Transaction
        /// </summary>
        /// <param name="businessObject">Transaction object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Transaction businessObject)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.TransID = Guid.NewGuid();

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

        /// <summary>
        /// Update existing Transaction
        /// </summary>
        /// <param name="businessObject">Transaction object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Transaction businessObject)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            try
            {
                if (businessObject != null)
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
        /// get Transaction by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Transaction GetByPrimaryKey(Guid keys)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all Transactions
        /// </summary>
        /// <returns>list</returns>
        public static List<Transaction> GetAll(Transaction obj)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all Transactions
        /// </summary>
        /// <returns>list</returns>
        public static List<Transaction> GetAll()
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of Transaction by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Transaction> GetAllBy(Transaction.TransactionFields fieldName, object value)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all Transactions
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Transaction obj)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all Transactions
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of Transaction by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Transaction.TransactionFields fieldName, object value)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Transaction obj)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete Transaction by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Transaction.TransactionFields fieldName, object value)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static Guid InsertDeposit(int Zone_TermID, decimal Amt, Guid? PaymentAcctID, Guid? DepositAcctID, Guid? ReservationID, Guid? FolioID, Guid? UserID, Guid? CounterID, Guid? PropertyID, string EntryOrigin, Guid? UnitID, string UnitType, Guid? CompanyID, Guid? ResPayID)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.InsertDeposit(Zone_TermID, Amt, PaymentAcctID, DepositAcctID, ReservationID, FolioID, UserID, CounterID, PropertyID, EntryOrigin, UnitID, UnitType, CompanyID, ResPayID);
        }

        public static Guid PostRoomCharge(DateTime BlockDate, Guid ReservationID, Guid UserID, Guid CounterID, Guid PropertyID, string TrascationEntryOrigin, decimal BaseRate, Guid CompanyID)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.PostRoomCharge(BlockDate, ReservationID, UserID, CounterID, PropertyID, TrascationEntryOrigin, BaseRate, CompanyID);
        }

        public static bool TransactionRefundDeposit(Guid? DepositBookID, int? Zone_TermID, decimal? Amt, Guid? PaymentAcctID, Guid? DepositAcctID, Guid? ReservationID, Guid? FolioID, Guid? UserID, Guid? CounterID, Guid? PropertyID, string EntryOrigin, Guid? UnitID, string UnitType, bool? IsApplyCancellationFees, Guid? DefaultCounterID, Guid? CompanyID)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.TransactionRefundDeposit(DepositBookID, Zone_TermID, Amt, PaymentAcctID, DepositAcctID, ReservationID, FolioID, UserID, CounterID, PropertyID, EntryOrigin, UnitID, UnitType, IsApplyCancellationFees, DefaultCounterID, CompanyID);
        }

        public static DataSet TransactionGetAllReservationDepositByReservationID(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.TransactionSelectAllReservationDepositByReservationID(ReservationID, PropertyID, CompanyID);
        }

        public static DataSet GetAllTransaction(Guid? ReservationID, Guid? FolioID, DateTime? StartDate, DateTime? EndDate, Guid? PropertyID, Guid? CompanyID)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.TransactionGetAllTransaction(ReservationID, FolioID, StartDate, EndDate, PropertyID, CompanyID);
        }

        public static DataSet TransactionGetAllDeposit(Guid? ReservationID, bool? IsForSingleInv, Guid? PropertyID, Guid? CompanyID)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.TransactionGetAllDeposit(ReservationID, IsForSingleInv, PropertyID, CompanyID);
        }

        public static Guid TransferDeposit(Guid? DepositBookID, int Zone_TermID, decimal Amt, Guid? DepositAcctID, Guid? ReservationID, Guid? FolioID, Guid? UserID, Guid? CounterID, Guid? PropertyID, string EntryOrigin, Guid? UnitID, string UnitType, Guid? CompanyID)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.TransferDeposit(DepositBookID, Zone_TermID, Amt, DepositAcctID, ReservationID, FolioID, UserID, CounterID, PropertyID, EntryOrigin, UnitID, UnitType, CompanyID);
        }

        public static Guid ItemPosting(Guid? ItemID, decimal? Amt, int? Qty, Guid? ReservationID, Guid? FolioID, Guid? UserID, Guid? CounterID, Guid? PropertyID, string Transaction_Origin, int? TargetLocation_TermID, string RefNo, string TaxIDs, Guid? ResServiceID, Guid? BookID, decimal? BaseRate, Guid? CompanyID)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.ItemPosting(ItemID, Amt, Qty, ReservationID, FolioID, UserID, CounterID, PropertyID, Transaction_Origin, TargetLocation_TermID, RefNo, TaxIDs, ResServiceID, BookID, BaseRate, CompanyID);
        }

        public static bool TransactionRefundPayment(Guid? PaidOutAcctID, decimal? Amt, Guid? ReservationID, Guid? FolioID, Guid? UserID, Guid? CounterID, Guid? PropertyID, string Transaction_Origin, Guid? ResPayID, Guid? RefBookID, Guid? CompanyID)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.TransactionRefundPayment(PaidOutAcctID, Amt, ReservationID, FolioID, UserID, CounterID, PropertyID, Transaction_Origin, ResPayID, RefBookID, CompanyID);
        }

        public static DataSet GenerateLedgerReports(Guid? CounterID, Guid? UserID, bool? IsForOpenCounter, Guid? ReservationID, Guid? FolioID, DateTime? EntryDate, Guid? AcctID, bool? IsMissMatchEntries, Guid? AgentID, Guid? ItemID, DateTime? ToDate, Guid? CloseID, Guid? BookID, string BookNo)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.GenerateLedgerReports(CounterID, UserID, IsForOpenCounter, ReservationID, FolioID, EntryDate, AcctID, IsMissMatchEntries, AgentID, ItemID, ToDate, CloseID, BookID, BookNo);
        }

        public static DataSet SelectGeneralData_ForLedgerReport(Guid? PropertyID, Guid? CompanyID)
        {
            TransactionDAL _dataObject = new TransactionDAL();
            return _dataObject.SelectGeneralData_ForLedgerReport(PropertyID, CompanyID);
        }

        #endregion

    }
}
