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
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.COMMON;

namespace SQT.Symphony.BusinessLogic.Configuration.DAL
{
    /// <summary>
    /// Data access layer class for Counters
    /// </summary>
    public class CountersDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public CountersDAL()
            : base()
        {
            // Nothing for now.
        }
        public CountersDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Counters> SelectAll(Counters dtoObject)
        {
            List<Counters> obj = null;
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
                        obj = StoredProcedure(MasterConstant.CountersSelectAll)
                                                .AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
                            //.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CounterNo", dtoObject.CounterNo)
.AddParameter("@Location_TermID", dtoObject.Location_TermID)
.AddParameter("@POSPointID", dtoObject.POSPointID)
.AddParameter("@IsDefault", dtoObject.IsDefault)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Counters>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.CountersSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Counters>();
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

        public List<Counters> SelectAll()
        {
            List<Counters> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.CountersSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Counters>();
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
        public DataSet SelectAllWithDataSet(Counters dtoObject)
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
                        obj = StoredProcedure(MasterConstant.CountersSelectAll)
                                                .AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
                            //.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CounterNo", dtoObject.CounterNo)
.AddParameter("@Location_TermID", dtoObject.Location_TermID)
.AddParameter("@POSPointID", dtoObject.POSPointID)
.AddParameter("@IsDefault", dtoObject.IsDefault)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.CountersSelectAll)
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

                    obj = StoredProcedure(MasterConstant.CountersSelectAll)
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
        public bool Insert(Counters dtoObject)
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

                    StoredProcedure(MasterConstant.CountersInsert)
                        .AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CounterNo", dtoObject.CounterNo)
.AddParameter("@Location_TermID", dtoObject.Location_TermID)
.AddParameter("@POSPointID", dtoObject.POSPointID)
.AddParameter("@IsDefault", dtoObject.IsDefault)

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
        public bool Update(Counters dtoObject)
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

                    StoredProcedure(MasterConstant.CountersUpdate)
                        .AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CounterNo", dtoObject.CounterNo)
.AddParameter("@Location_TermID", dtoObject.Location_TermID)
.AddParameter("@POSPointID", dtoObject.POSPointID)
.AddParameter("@IsDefault", dtoObject.IsDefault)

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
                StoredProcedure(MasterConstant.CountersDeleteByPrimaryKey)
                    .AddParameter("@CounterID"
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
        public bool Delete(Counters dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.CountersDeleteByPrimaryKey)
                    .AddParameter("@CounterID", dtoObject.CounterID)

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

        public Counters SelectByPrimaryKey(Guid Keys)
        {
            Counters obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CountersSelectByPrimaryKey)
                            .AddParameter("@CounterID"
, Keys)
                            .Fetch<Counters>();
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
        public List<Counters> SelectByField(string fieldName, object value)
        {
            List<Counters> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CountersSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Counters>();

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
                obj = StoredProcedure(MasterConstant.CountersSelectByField)
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
                StoredProcedure(MasterConstant.CountersDeleteByField)
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

        public DataSet SearchCounterData(Guid? CounterID, Guid? PropertyID, Guid? CompanyID, string strCounterNo)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CountersSearchCounterData)
                                    .AddParameter("@CounterID", CounterID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@CounterNo", strCounterNo)
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


        public DataSet SelectLogoutCountrList(Guid? PropertyID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CountersSelectLogoutCounter)

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


        public DataSet SelectCounterCloseReport(Guid? UserID, Guid? CounterID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ReservationSelectCounterCloseRport)
                                    .AddParameter("@UserID", UserID)
                                    .AddParameter("@CounterID", CounterID)
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


        public bool SaveCounterCloseData(Guid? CounterID, Guid? UserID, Guid? LogInfoID, Guid? CounterLoginID, decimal? BeignningAmount, decimal? SuggestedAmount, decimal? AmountDropped, decimal? NewDrawerAmount, bool? isShort, string Reason, decimal? Short_Amount, bool? isClosedAtDayEnd, ref bool returnIsSuccessFull, ref Guid? returncloseid)
        {
            try
            {
                OutputParameterCollection outputCal = null;
                returnIsSuccessFull = true;                
                returncloseid = Guid.Empty;
                
                StoredProcedure(MasterConstant.ReservationSaveCounterCloseData)
                                    .AddParameter("@CounterID", CounterID)
                                    .AddParameter("@UserID", UserID)
                                    .AddParameter("@LogInfoID", LogInfoID)
                                    .AddOutParameter("@IsSuccessFull", returnIsSuccessFull)
                                    .AddParameter("@CounterLoginID", CounterLoginID)
                                    .AddOutParameter("@CloseID", returncloseid)
                                    .AddParameter("@BeignningAmount", BeignningAmount)
                                    .AddParameter("@SuggestedAmount", SuggestedAmount)
                                    .AddParameter("@AmountDropped", AmountDropped)
                                    .AddParameter("@NewDrawerAmount", NewDrawerAmount)
                                    .AddParameter("@isShort", isShort)
                                    .AddParameter("@Reason", Reason)
                                    .AddParameter("@Short_Amount", Short_Amount)
                                    .AddParameter("@isClosedAtDayEnd", isClosedAtDayEnd)

                                    .WithTransaction(dbtr)
                                    .Execute(out outputCal);

                returncloseid = outputCal.GetValue("@CloseID").Fetch<Guid>();
                returnIsSuccessFull = outputCal.GetValue("@IsSuccessFull").Fetch<bool>();


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
        
        public bool CounterAdjustment(Guid? AcctID, string TransType, decimal? Amt, Guid? AdjustmentAcctID, bool? IsShort, Guid? UserID, Guid? CounterID, Guid? PropertyID, string Transaction_Origin, string Notes, Guid? CompanyID)
        {
            try
            {
                Guid BookID_Return = Guid.Empty;

                StoredProcedure(MasterConstant.ReservationCounterAdjustment)
                                    .AddParameter("@AcctID", AcctID)
                                    .AddParameter("@TransType", TransType)
                                    .AddParameter("@Amt", Amt)
                                    .AddParameter("@AdjustmentAcctID", AdjustmentAcctID)
                                    .AddParameter("@IsShort", IsShort)
                                    .AddParameter("@UserID", UserID)
                                    .AddParameter("@CounterID", CounterID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@Transaction_Origin", Transaction_Origin)
                                    .AddParameter("@Notes", Notes)
                                    .AddOutParameter("@BookID_Return", BookID_Return)
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

        public DataSet SelectBeginingAmount(Guid? CounterID, Guid? CloseID, bool? ForReport)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ReservationCounterSelectBeginingAmount)
                                    .AddParameter("@CounterID", CounterID)
                                    .AddParameter("@CloseID", CloseID)
                                    .AddParameter("@ForReport", ForReport)
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

        public DataSet SelectCounterCloseDetailRport(Guid? UserID, Guid? CounterID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.Counter_CounterCloseDetailRport)
                                    .AddParameter("@UserID", UserID)
                                    .AddParameter("@CounterID", CounterID)
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


        public DataSet SelectGenerateLedgerReports(Guid? CounterID, Guid? UserID, bool? IsForOpenCounter, Guid? ReservationID, Guid? FolioID, DateTime? EntryDate, Guid? AcctID, bool? IsMissMatchEntries, Guid? AgentID, Guid? ItemID, DateTime? ToDate, Guid? CloseID, Guid? BookID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.Counter_GenerateLedgerReports)
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

        public DataSet SelectCounterCloseSummaryData(int? PreviousCounterClose, Guid? CounterID, Guid? CloseID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CounterClose_SelectCounterCloseSummary)
                                    .AddParameter("@PreviousCounterClose", PreviousCounterClose)
                                    .AddParameter("@CounterID", CounterID)
                                    .AddParameter("@CloseID", CloseID)                                    
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
