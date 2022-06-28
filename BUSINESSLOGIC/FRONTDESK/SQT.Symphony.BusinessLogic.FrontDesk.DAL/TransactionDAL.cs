using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using SQT.FRAMEWORK.DAL.Linq;
using SQT.FRAMEWORK.DAL.Linq.DAL;
using SQT.FRAMEWORK.DAL.Linq.Exceptions;
using SQT.FRAMEWORK.DAL.Linq.Results;
using SQT.FRAMEWORK.COMMON.Util;
using SQT.FRAMEWORK.LOGGER;
using SQT.FRAMEWORK.EXCEPTION;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.COMMON;

namespace SQT.Symphony.BusinessLogic.FrontDesk.DAL
{
    /// <summary>
    /// Data access layer class for Transaction
    /// </summary>
    public class TransactionDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public TransactionDAL()
            : base()
        {
            // Nothing for now.
        }
        public TransactionDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Transaction> SelectAll(Transaction dtoObject)
        {
            List<Transaction> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    if (dtoObject != null)
                        parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                    if (dtoObject != null)
                    {
                        obj = StoredProcedure(MasterDALConstant.TransactionSelectAll)
                                                .AddParameter("@TransID", dtoObject.TransID)
.AddParameter("@RefTransID", dtoObject.RefTransID)
.AddParameter("@JournalID", dtoObject.JournalID)
.AddParameter("@Amt", dtoObject.Amt)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@AcctNo", dtoObject.AcctNo)
.AddParameter("@AcctName", dtoObject.AcctName)
.AddParameter("@TransType", dtoObject.TransType)
.AddParameter("@IsTax", dtoObject.IsTax)
.AddParameter("@CurBal", dtoObject.CurBal)
.AddParameter("@Updatelog", dtoObject.Updatelog)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@OrderSeqNo", dtoObject.OrderSeqNo)
.AddParameter("@AcctTaxRate", dtoObject.AcctTaxRate)
.AddParameter("@IsAcctTaxFlat", dtoObject.IsAcctTaxFlat)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Transaction>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.TransactionSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Transaction>();
                    }
                }
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public List<Transaction> SelectAll()
        {
            List<Transaction> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.TransactionSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Transaction>();
                }
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }
        public DataSet SelectAllWithDataSet(Transaction dtoObject)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    if (dtoObject != null)
                        parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                    if (dtoObject != null)
                    {
                        obj = StoredProcedure(MasterDALConstant.TransactionSelectAll)
                                                .AddParameter("@TransID", dtoObject.TransID)
.AddParameter("@RefTransID", dtoObject.RefTransID)
.AddParameter("@JournalID", dtoObject.JournalID)
.AddParameter("@Amt", dtoObject.Amt)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@AcctNo", dtoObject.AcctNo)
.AddParameter("@AcctName", dtoObject.AcctName)
.AddParameter("@TransType", dtoObject.TransType)
.AddParameter("@IsTax", dtoObject.IsTax)
.AddParameter("@CurBal", dtoObject.CurBal)
.AddParameter("@Updatelog", dtoObject.Updatelog)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@OrderSeqNo", dtoObject.OrderSeqNo)
.AddParameter("@AcctTaxRate", dtoObject.AcctTaxRate)
.AddParameter("@IsAcctTaxFlat", dtoObject.IsAcctTaxFlat)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.TransactionSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                }
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public DataSet SelectAllWithDataSet()
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.TransactionSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchDataSet();
                }
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }
        /// <summary>
        /// insert new row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true of successfully insert</returns>
        public bool Insert(Transaction dtoObject)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    if (dtoObject == null)
                        throw (new ParameterNullException("Object can not be null"));

                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.TransactionInsert)
                        .AddParameter("@TransID", dtoObject.TransID)
.AddParameter("@RefTransID", dtoObject.RefTransID)
.AddParameter("@JournalID", dtoObject.JournalID)
.AddParameter("@Amt", dtoObject.Amt)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@AcctNo", dtoObject.AcctNo)
.AddParameter("@AcctName", dtoObject.AcctName)
.AddParameter("@TransType", dtoObject.TransType)
.AddParameter("@IsTax", dtoObject.IsTax)
.AddParameter("@CurBal", dtoObject.CurBal)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@OrderSeqNo", dtoObject.OrderSeqNo)
.AddParameter("@AcctTaxRate", dtoObject.AcctTaxRate)
.AddParameter("@IsAcctTaxFlat", dtoObject.IsAcctTaxFlat)

                        .WithTransaction(dbtr)
                        .Execute();
                }
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return true;
        }

        /// <summary>
        /// update row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true for successfully updated</returns>
        public bool Update(Transaction dtoObject)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    if (dtoObject == null)
                        throw (new ParameterNullException("Object can not be null"));

                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.TransactionUpdate)
                        .AddParameter("@TransID", dtoObject.TransID)
.AddParameter("@RefTransID", dtoObject.RefTransID)
.AddParameter("@JournalID", dtoObject.JournalID)
.AddParameter("@Amt", dtoObject.Amt)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@AcctNo", dtoObject.AcctNo)
.AddParameter("@AcctName", dtoObject.AcctName)
.AddParameter("@TransType", dtoObject.TransType)
.AddParameter("@IsTax", dtoObject.IsTax)
.AddParameter("@CurBal", dtoObject.CurBal)
.AddParameter("@Updatelog", dtoObject.Updatelog)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@OrderSeqNo", dtoObject.OrderSeqNo)
.AddParameter("@AcctTaxRate", dtoObject.AcctTaxRate)
.AddParameter("@IsAcctTaxFlat", dtoObject.IsAcctTaxFlat)

                        .WithTransaction(dbtr)
                        .Execute();
                }
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return true;
        }
        public bool Delete(Guid Keys)
        {
            try
            {
                StoredProcedure(MasterDALConstant.TransactionDeleteByPrimaryKey)
                    .AddParameter("@TransID"
, Keys)
                    .WithTransaction(dbtr)
                    .Execute();
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return true;
        }
        public bool Delete(Transaction dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.TransactionDeleteByPrimaryKey)
                    .AddParameter("@TransID", dtoObject.TransID)

                    .WithTransaction(dbtr)
                    .Execute();
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return true;
        }

        public Transaction SelectByPrimaryKey(Guid Keys)
        {
            Transaction obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.TransactionSelectByPrimaryKey)
                            .AddParameter("@TransID"
, Keys)
                            .Fetch<Transaction>();
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }
        public List<Transaction> SelectByField(string fieldName, object value)
        {
            List<Transaction> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.TransactionSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Transaction>();

            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }
        public DataSet SelectByFieldWithDataSet(string fieldName, object value)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.TransactionSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchDataSet();

            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public bool DeleteByField(string fieldName, object value)
        {
            try
            {
                StoredProcedure(MasterDALConstant.TransactionDeleteByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .WithTransaction(dbtr)
                                    .Execute();
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return true;
        }

        public Guid InsertDeposit(int Zone_TermID, decimal Amt, Guid? PaymentAcctID, Guid? DepositAcctID, Guid? ReservationID, Guid? FolioID, Guid? UserID, Guid? CounterID, Guid? PropertyID, string EntryOrigin, Guid? UnitID, string UnitType, Guid? CompanyID, Guid? ResPayID)
        {
            Guid bookID = Guid.Empty;

            OutputParameterCollection outputCal = null;

            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.TransactionInsertDeposit)
                        .AddParameter("@Zone_TermID", Zone_TermID)
                        .AddParameter("@Amt", Amt)
                        .AddParameter("@PaymentAcctID", PaymentAcctID)
                        .AddParameter("@DepositAcctID", DepositAcctID)
                        .AddParameter("@ReservationID", ReservationID)
                        .AddParameter("@FolioID", FolioID)
                        .AddParameter("@UserID", UserID)
                        .AddParameter("@CounterID", CounterID)
                        .AddParameter("@PropertyID", PropertyID)
                        .AddParameter("@EntryOrigin", EntryOrigin)
                        .AddParameter("@UnitID", UnitID)
                        .AddParameter("@UnitType", UnitType)
                        .AddParameter("@CompanyID", CompanyID)
                        .AddParameter("@ResPayID", ResPayID)
                        .AddOutParameter("@BookID", bookID)
                        .WithTransaction(dbtr)

                        .Execute(out outputCal);

                    bookID = outputCal.GetValue("@BookID").Fetch<Guid>();
                }
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return bookID;
        }

        public Guid PostRoomCharge(DateTime BlockDate, Guid ReservationID, Guid UserID, Guid CounterID, Guid PropertyID, string TrascationEntryOrigin, decimal BaseRate, Guid CompanyID)
        {
            Guid retBookID = Guid.Empty;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.TransactionPostRoomCharge)
                        .AddParameter("@BlockDate", BlockDate)
                        .AddParameter("@ResID", ReservationID)
                        .AddParameter("@UserID", UserID)
                        .AddParameter("@CounterID", CounterID)
                        .AddParameter("@PropertyID", PropertyID)
                        .AddParameter("@Transaction_Origin", TrascationEntryOrigin)
                        .AddParameter("@BaseRate", BaseRate)
                        .AddParameter("@CompanyID", CompanyID)
                        .AddOutParameter("@ReturnBookID", retBookID)

                        .WithTransaction(dbtr)
                        .Execute();
                }
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return retBookID;
        }

        public bool TransactionRefundDeposit(Guid? DepositBookID, int? Zone_TermID, decimal? Amt, Guid? PaymentAcctID, Guid? DepositAcctID, Guid? ReservationID, Guid? FolioID, Guid? UserID, Guid? CounterID, Guid? PropertyID, string EntryOrigin, Guid? UnitID, string UnitType, bool? IsApplyCancellationFees, Guid? DefaultCounterID, Guid? CompanyID)
        {
            Guid returnID = Guid.Empty;

            try
            {
                StoredProcedure(MasterDALConstant.TransactionRefundDeposit)
                                    .AddOutParameter("@BookID", returnID)
                                    .AddParameter("@DepositBookID", DepositBookID)
                                    .AddParameter("@Zone_TermID", Zone_TermID)
                                    .AddParameter("@Amt", Amt)
                                    .AddParameter("@PaymentAcctID", PaymentAcctID)
                                    .AddParameter("@DepositAcctID", DepositAcctID)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@FolioID", FolioID)
                                    .AddParameter("@UserID", UserID)
                                    .AddParameter("@CounterID", CounterID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@EntryOrigin", EntryOrigin)
                                    .AddParameter("@UnitID", UnitID)
                                    .AddParameter("@UnitType", UnitType)
                                    .AddParameter("@IsApplyCancellationFees", IsApplyCancellationFees)
                                    .AddParameter("@DefaultCounterID", DefaultCounterID)
                                    .AddParameter("@CompanyID", CompanyID)

                                    .WithTransaction(dbtr)
                                   .Execute();


            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return true;
        }

        public DataSet TransactionSelectAllReservationDepositByReservationID(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.TransactionSelectAllReservationDepositByReservationID)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .FetchDataSet();

            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public DataSet TransactionGetAllTransaction(Guid? ReservationID, Guid? FolioID, DateTime? StartDate, DateTime? EndDate,  Guid? PropertyID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.TransactionGetAllTransaction)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@FolioID", FolioID)
                                    .AddParameter("@StartDate", StartDate)
                                    .AddParameter("@EndDate", EndDate)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .FetchDataSet();

            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public DataSet TransactionGetAllDeposit(Guid? ReservationID, bool? IsForSingleInv, Guid? PropertyID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.TransactionGetAllDeposit)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@ForSingleInv", IsForSingleInv)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .FetchDataSet();

            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public Guid TransferDeposit(Guid? DepositBookID, int Zone_TermID, decimal Amt, Guid? DepositAcctID, Guid? ReservationID, Guid? FolioID, Guid? UserID, Guid? CounterID, Guid? PropertyID, string EntryOrigin, Guid? UnitID, string UnitType, Guid? CompanyID)
        {
            Guid bookID = Guid.Empty;

            OutputParameterCollection outputCal = null;

            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.TransactionTransferDeposit)
                        .AddParameter("@DepositBookID", DepositBookID)
                        .AddParameter("@Zone_TermID", Zone_TermID)
                        .AddParameter("@Amt", Amt)
                        .AddParameter("@DepositAcctID", DepositAcctID)
                        .AddParameter("@ReservationID", ReservationID)
                        .AddParameter("@FolioID", FolioID)
                        .AddParameter("@UserID", UserID)
                        .AddParameter("@CounterID", CounterID)
                        .AddParameter("@PropertyID", PropertyID)
                        .AddParameter("@EntryOrigin", EntryOrigin)
                        .AddParameter("@UnitID", UnitID)
                        .AddParameter("@UnitType", UnitType)
                        .AddParameter("@CompanyID", CompanyID)
                        .AddOutParameter("@BookID", bookID)
                        .WithTransaction(dbtr)

                        .Execute(out outputCal);

                    bookID = outputCal.GetValue("@BookID").Fetch<Guid>();
                }
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return bookID;
        }

        public Guid ItemPosting(Guid? ItemID, decimal? Amt, int? Qty, Guid? ReservationID, Guid? FolioID, Guid? UserID, Guid? CounterID, Guid? PropertyID, string Transaction_Origin, int? TargetLocation_TermID, string RefNo, string TaxIDs, Guid? ResServiceID, Guid? BookID, decimal? BaseRate, Guid? CompanyID)
        {
            Guid returnBookID = Guid.Empty;

            OutputParameterCollection outputCal = null;

            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.Transaction_ItemPosting)
                        .AddParameter("@ItemID", ItemID)
                        .AddParameter("@Amt", Amt)
                        .AddParameter("@Qty", Qty)
                        .AddParameter("@ResID", ReservationID)
                        .AddParameter("@FolioID", FolioID)
                        .AddParameter("@UserID", UserID)
                        .AddParameter("@CounterID", CounterID)
                        .AddParameter("@PropertyID", PropertyID)
                        .AddParameter("@Transaction_Origin", Transaction_Origin)
                        .AddParameter("@TargetLocation_TermID", TargetLocation_TermID)
                        .AddParameter("@RefNo", RefNo)
                        .AddParameter("@TaxIDs", TaxIDs)
                        .AddParameter("@ResServiceID", ResServiceID)
                        .AddParameter("@BookID", BookID)
                        .AddParameter("@BaseRate", BaseRate)
                        .AddParameter("@CompanyID", CompanyID)
                        .AddOutParameter("@BookID_Return", returnBookID)

                        .WithTransaction(dbtr)

                        .Execute(out outputCal);

                    returnBookID = outputCal.GetValue("@BookID_Return").Fetch<Guid>();
                }
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return returnBookID;
        }

        public bool TransactionRefundPayment(Guid? PaidOutAcctID, decimal? Amt, Guid? ReservationID, Guid? FolioID, Guid? UserID, Guid? CounterID, Guid? PropertyID, string Transaction_Origin, Guid? ResPayID, Guid? RefBookID, Guid? CompanyID)
        {
            Guid returnID = Guid.Empty;

            try
            {
                StoredProcedure(MasterDALConstant.Transaction_RefundPayment)
                                    .AddParameter("@PaidOutAcctID", PaidOutAcctID)
                                    .AddParameter("@Amt", Amt)
                                    .AddParameter("@ResID", ReservationID)
                                    .AddParameter("@FolioID", FolioID)
                                    .AddParameter("@UserID", UserID)
                                    .AddParameter("@CounterID", CounterID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@Transaction_Origin", Transaction_Origin)
                                    .AddParameter("@ResPayID", ResPayID)
                                    .AddParameter("@RefBookID", RefBookID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddOutParameter("@RetBookID", returnID)
                                    

                                    .WithTransaction(dbtr)
                                   .Execute();


            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return true;
        }

        public DataSet GenerateLedgerReports(Guid? CounterID, Guid? UserID, bool? IsForOpenCounter, Guid? ReservationID, Guid? FolioID, DateTime? EntryDate, Guid? AcctID, bool? IsMissMatchEntries, Guid? AgentID, Guid? ItemID, DateTime? ToDate, Guid? CloseID, Guid? BookID, string BookNo)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.GenerateLedgerReports)
                                    .AddParameter("@CounterID", CounterID)
                                    .AddParameter("@UserID", UserID)
                                    .AddParameter("@IsForOpenCounter", IsForOpenCounter)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@FolioID", FolioID)
                                    .AddParameter("@EntryDate", EntryDate)
                                    .AddParameter("@AcctID", AcctID)
                                    .AddParameter("@IsMissMatchEntries", IsMissMatchEntries)
                                    .AddParameter("@AgentID", AgentID)
                                    .AddParameter("@ItemID", ItemID)
                                    .AddParameter("@ToDate", ToDate)
                                    .AddParameter("@CloseID", CloseID)
                                    .AddParameter("@BookID", BookID)
                                    .AddParameter("@BookNo", BookNo)
                                    .FetchDataSet();

            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public DataSet SelectGeneralData_ForLedgerReport(Guid? PropertyID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.SelectGeneralData_ForLedgerReport)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)                                    
                                    .FetchDataSet();

            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }
        #endregion
    }
}
