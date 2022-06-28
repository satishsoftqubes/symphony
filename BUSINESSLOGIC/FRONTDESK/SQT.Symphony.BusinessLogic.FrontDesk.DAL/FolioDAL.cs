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
    /// Data access layer class for Folio
    /// </summary>
    public class FolioDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public FolioDAL()
            : base()
        {
            // Nothing for now.
        }
        public FolioDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Folio> SelectAll(Folio dtoObject)
        {
            List<Folio> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.FolioSelectAll)
                                                .AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@AgentID", dtoObject.AgentID)
.AddParameter("@FolioNo", dtoObject.FolioNo)
.AddParameter("@CreationDate", dtoObject.CreationDate)
.AddParameter("@IsSubFolio", dtoObject.IsSubFolio)
.AddParameter("@IsSplitFolio", dtoObject.IsSplitFolio)
.AddParameter("@ParentFolioID", dtoObject.ParentFolioID)
.AddParameter("@FolioStatus_TermID", dtoObject.FolioStatus_TermID)
.AddParameter("@IsLocked", dtoObject.IsLocked)
.AddParameter("@LockedBy", dtoObject.LockedBy)
.AddParameter("@CurrentBalace", dtoObject.CurrentBalace)
.AddParameter("@Charges", dtoObject.Charges)
.AddParameter("@Payment", dtoObject.Payment)
.AddParameter("@Adjustment", dtoObject.Adjustment)
.AddParameter("@IsSourceFolio", dtoObject.IsSourceFolio)
.AddParameter("@IsDestinationFolio", dtoObject.IsDestinationFolio)
.AddParameter("@TransactionZone_TermID", dtoObject.TransactionZone_TermID)
.AddParameter("@IsDirectBill", dtoObject.IsDirectBill)
.AddParameter("@BilledTo", dtoObject.BilledTo)
.AddParameter("@FolioType_TermID", dtoObject.FolioType_TermID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@FolioStatus", dtoObject.FolioStatus)
.AddParameter("@BillingAddress", dtoObject.BillingAddress)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Folio>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.FolioSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Folio>();
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

        public List<Folio> SelectAll()
        {
            List<Folio> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.FolioSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Folio>();
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
        public DataSet SelectAllWithDataSet(Folio dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.FolioSelectAll)
                                                .AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@AgentID", dtoObject.AgentID)
.AddParameter("@FolioNo", dtoObject.FolioNo)
.AddParameter("@CreationDate", dtoObject.CreationDate)
.AddParameter("@IsSubFolio", dtoObject.IsSubFolio)
.AddParameter("@IsSplitFolio", dtoObject.IsSplitFolio)
.AddParameter("@ParentFolioID", dtoObject.ParentFolioID)
.AddParameter("@FolioStatus_TermID", dtoObject.FolioStatus_TermID)
.AddParameter("@IsLocked", dtoObject.IsLocked)
.AddParameter("@LockedBy", dtoObject.LockedBy)
.AddParameter("@CurrentBalace", dtoObject.CurrentBalace)
.AddParameter("@Charges", dtoObject.Charges)
.AddParameter("@Payment", dtoObject.Payment)
.AddParameter("@Adjustment", dtoObject.Adjustment)
.AddParameter("@IsSourceFolio", dtoObject.IsSourceFolio)
.AddParameter("@IsDestinationFolio", dtoObject.IsDestinationFolio)
.AddParameter("@TransactionZone_TermID", dtoObject.TransactionZone_TermID)
.AddParameter("@IsDirectBill", dtoObject.IsDirectBill)
.AddParameter("@BilledTo", dtoObject.BilledTo)
.AddParameter("@FolioType_TermID", dtoObject.FolioType_TermID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@FolioStatus", dtoObject.FolioStatus)
.AddParameter("@BillingAddress", dtoObject.BillingAddress)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.FolioSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.FolioSelectAll)
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
        public bool Insert(Folio dtoObject)
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

                    StoredProcedure(MasterDALConstant.FolioInsert)
                        .AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@AgentID", dtoObject.AgentID)
.AddParameter("@FolioNo", dtoObject.FolioNo)
.AddParameter("@CreationDate", dtoObject.CreationDate)
.AddParameter("@IsSubFolio", dtoObject.IsSubFolio)
.AddParameter("@IsSplitFolio", dtoObject.IsSplitFolio)
.AddParameter("@ParentFolioID", dtoObject.ParentFolioID)
.AddParameter("@FolioStatus_TermID", dtoObject.FolioStatus_TermID)
.AddParameter("@IsLocked", dtoObject.IsLocked)
.AddParameter("@LockedBy", dtoObject.LockedBy)
.AddParameter("@CurrentBalace", dtoObject.CurrentBalace)
.AddParameter("@Charges", dtoObject.Charges)
.AddParameter("@Payment", dtoObject.Payment)
.AddParameter("@Adjustment", dtoObject.Adjustment)
.AddParameter("@IsSourceFolio", dtoObject.IsSourceFolio)
.AddParameter("@IsDestinationFolio", dtoObject.IsDestinationFolio)
.AddParameter("@TransactionZone_TermID", dtoObject.TransactionZone_TermID)
.AddParameter("@IsDirectBill", dtoObject.IsDirectBill)
.AddParameter("@BilledTo", dtoObject.BilledTo)
.AddParameter("@FolioType_TermID", dtoObject.FolioType_TermID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@FolioStatus", dtoObject.FolioStatus)
.AddParameter("@BillingAddress", dtoObject.BillingAddress)

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
        public bool Update(Folio dtoObject)
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

                    StoredProcedure(MasterDALConstant.FolioUpdate)
                        .AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@AgentID", dtoObject.AgentID)
.AddParameter("@FolioNo", dtoObject.FolioNo)
.AddParameter("@CreationDate", dtoObject.CreationDate)
.AddParameter("@IsSubFolio", dtoObject.IsSubFolio)
.AddParameter("@IsSplitFolio", dtoObject.IsSplitFolio)
.AddParameter("@ParentFolioID", dtoObject.ParentFolioID)
.AddParameter("@FolioStatus_TermID", dtoObject.FolioStatus_TermID)
.AddParameter("@IsLocked", dtoObject.IsLocked)
.AddParameter("@LockedBy", dtoObject.LockedBy)
.AddParameter("@CurrentBalace", dtoObject.CurrentBalace)
.AddParameter("@Charges", dtoObject.Charges)
.AddParameter("@Payment", dtoObject.Payment)
.AddParameter("@Adjustment", dtoObject.Adjustment)
.AddParameter("@IsSourceFolio", dtoObject.IsSourceFolio)
.AddParameter("@IsDestinationFolio", dtoObject.IsDestinationFolio)
.AddParameter("@TransactionZone_TermID", dtoObject.TransactionZone_TermID)
.AddParameter("@IsDirectBill", dtoObject.IsDirectBill)
.AddParameter("@BilledTo", dtoObject.BilledTo)
.AddParameter("@FolioType_TermID", dtoObject.FolioType_TermID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@FolioStatus", dtoObject.FolioStatus)
.AddParameter("@BillingAddress", dtoObject.BillingAddress)

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
                StoredProcedure(MasterDALConstant.FolioDeleteByPrimaryKey)
                    .AddParameter("@FolioID"
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
        public bool Delete(Folio dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.FolioDeleteByPrimaryKey)
                    .AddParameter("@FolioID", dtoObject.FolioID)

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

        public Folio SelectByPrimaryKey(Guid Keys)
        {
            Folio obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.FolioSelectByPrimaryKey)
                            .AddParameter("@FolioID"
, Keys)
                            .Fetch<Folio>();
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
        public List<Folio> SelectByField(string fieldName, object value)
        {
            List<Folio> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.FolioSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Folio>();

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
                obj = StoredProcedure(MasterDALConstant.FolioSelectByField)
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
                StoredProcedure(MasterDALConstant.FolioDeleteByField)
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

        public DataSet SelectFolioBalance(Guid? ReservationID, Guid? FolioID, bool? IsMainFolio, Guid? CompanyID, Guid? PropertyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.FolioSelectFolioBalance)
                                            .AddParameter("@ReservationID", ReservationID)
                                            .AddParameter("@FolioID", FolioID)
                                            .AddParameter("@IsMainFolio", IsMainFolio)
                                            .AddParameter("@CompanyID", CompanyID)
                                            .AddParameter("@PropertyID", PropertyID)

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

        public DataSet SelectAllFolio(int? Type, bool? IsWithSubFolio, Guid? CompanyID, Guid? PropertyID, string CompanyName, Guid? RoomTypeID, string GuestFullName, string RoomNo, string FolioNo)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.FolioSelectAllFolio)
                                            .AddParameter("@Type", Type)
                                            .AddParameter("@IsWithSubFolio", IsWithSubFolio)
                                            .AddParameter("@CompanyID", CompanyID)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@CompanyName", CompanyName)
                                            .AddParameter("@RoomTypeID", RoomTypeID)
                                            .AddParameter("@GuestFullName", GuestFullName)
                                            .AddParameter("@RoomNo", RoomNo)
                                            .AddParameter("@FolioNo", FolioNo)

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

        public DataSet SelectAllFolioBalance(bool? IsForOutstanding, DateTime? CheckInDate, DateTime? CheckoutDate, Guid? FolioID, string FolioNo, Guid? GuestID, Guid? AgentID, Guid? ReservationID, Guid? CompanyID, Guid? PropertyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.FolioSelectAllFolioBalance)
                                            .AddParameter("@IsForOutstanding", IsForOutstanding)
                                            .AddParameter("@CheckInDate", CheckInDate)
                                            .AddParameter("@CheckoutDate", CheckoutDate)
                                            .AddParameter("@FolioID", FolioID)
                                            .AddParameter("@FolioNo", FolioNo)
                                            .AddParameter("@GuestID", GuestID)
                                            .AddParameter("@AgentID", AgentID)
                                            .AddParameter("@ReservationID", ReservationID)
                                            .AddParameter("@CompanyID", CompanyID)
                                            .AddParameter("@PropertyID", PropertyID)

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

        public DataSet SelectAllFolios(Guid? FolioID, string FolioNo, Guid? GuestID, Guid? AgentID, Guid? ReservationID, Guid? CompanyID, Guid? PropertyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.FolioSelectAllFolios)
                                            .AddParameter("@FolioID", FolioID)
                                            .AddParameter("@FolioNo", FolioNo)
                                            .AddParameter("@GuestID", GuestID)
                                            .AddParameter("@AgentID", AgentID)
                                            .AddParameter("@ReservationID", ReservationID)
                                            .AddParameter("@CompanyID", CompanyID)
                                            .AddParameter("@PropertyID", PropertyID)

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

        public DataSet GetCheckOutTimeSummary(Guid? ReservationID, Guid? FolioID, Guid? CompanyID, Guid? PropertyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.Folio_GetSummary)
                                            .AddParameter("@ReservationID", ReservationID)
                                            .AddParameter("@FolioID", FolioID)
                                            .AddParameter("@CompanyID", CompanyID)
                                            .AddParameter("@PropertyID", PropertyID)

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
        
        public DataSet SelectAllRecoveryTransaction(Guid? ReservationID, Guid? FolioID, DateTime? StartDate, DateTime? EndDate, Guid? PropertyID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.Folio_GetAllRecoveryTransaction)
                                            .AddParameter("@ReservationID", ReservationID)
                                            .AddParameter("@FolioID", FolioID)
                                            .AddParameter("@StartDate", StartDate)
                                            .AddParameter("@EndDate", EndDate)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@CompanyID", CompanyID)

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
        
        public bool FolioQuickPostInAccount(Guid? ChargeAcctID, Guid? PaymentAcctID, decimal? Amount, int? Transaction_Origin, Guid? ResID, Guid? FolioID, Guid? CounterID, Guid? PropertyID, Guid? UserID, Guid? ResPayID, string RefNo, decimal? BaseRate, Guid? CompanyID)
        {
            Guid returnBookID = Guid.Empty;
            Guid returnPostBookID = Guid.Empty;

            OutputParameterCollection outputCal = null;

            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.Folio_QuickPostInAccount)
                        .AddParameter("@ChargeAcctID", ChargeAcctID)
                        .AddParameter("@PaymentAcctID", PaymentAcctID)
                        .AddParameter("@Amount", Amount)
                        .AddParameter("@Transaction_Origin", Transaction_Origin)
                        .AddParameter("@ResID", ResID)
                        .AddParameter("@FolioID", FolioID)
                        .AddParameter("@CounterID", CounterID)
                        .AddParameter("@PropertyID", PropertyID)
                        .AddParameter("@UserID", UserID)
                        .AddOutParameter("@BookID", returnBookID)
                        .AddParameter("@ResPayID", ResPayID)
                        .AddParameter("@RefNo", RefNo)
                        .AddOutParameter("@PostBookID", returnPostBookID)
                        .AddParameter("@BaseRate", BaseRate)
                        .AddParameter("@CompanyID", CompanyID)

                        .WithTransaction(dbtr)
                        .Execute();

                    //returnBookID = outputCal.GetValue("@BookID_Return").Fetch<Guid>();
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
        
        public Guid FolioQuickPostInAccountNew(Guid? ChargeAcctID, Guid? PaymentAcctID, decimal? Amount, int? Transaction_Origin, Guid? ResID, Guid? FolioID, Guid? CounterID, Guid? PropertyID, Guid? UserID, Guid? ResPayID, string RefNo, decimal? BaseRate, Guid? CompanyID)
        {
            Guid returnBookID = Guid.Empty;
            Guid returnPostBookID = Guid.Empty;

            OutputParameterCollection outputCal = null;

            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.Folio_QuickPostInAccount)
                        .AddParameter("@ChargeAcctID", ChargeAcctID)
                        .AddParameter("@PaymentAcctID", PaymentAcctID)
                        .AddParameter("@Amount", Amount)
                        .AddParameter("@Transaction_Origin", Transaction_Origin)
                        .AddParameter("@ResID", ResID)
                        .AddParameter("@FolioID", FolioID)
                        .AddParameter("@CounterID", CounterID)
                        .AddParameter("@PropertyID", PropertyID)
                        .AddParameter("@UserID", UserID)
                        .AddOutParameter("@BookID", returnBookID)
                        .AddParameter("@ResPayID", ResPayID)
                        .AddParameter("@RefNo", RefNo)
                        .AddOutParameter("@PostBookID", returnPostBookID)
                        .AddParameter("@BaseRate", BaseRate)
                        .AddParameter("@CompanyID", CompanyID)
                          .WithTransaction(dbtr)
                       .Execute(out outputCal);
                    //.WithTransaction(dbtr)
                    //.Execute();

                    returnBookID = outputCal.GetValue("@BookID").Fetch<Guid>();
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
        
        public bool FolioTransferTransactionData(Guid? Source_ResID, Guid? SourceFolioID, Guid? Dest_ResID, Guid? DestnationFolioID, Guid? BookID, bool? IsGrpCheckOut, Guid? TransferByUserID)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.Folio_FolioTransferTransaction)
                                            .AddParameter("@Source_ResID", Source_ResID)
                                            .AddParameter("@SourceFolioID", SourceFolioID)
                                            .AddParameter("@Dest_ResID", Dest_ResID)
                                            .AddParameter("@DestnationFolioID", DestnationFolioID)
                                            .AddParameter("@BookID", BookID)
                                            .AddParameter("@IsGrpCheckOut", IsGrpCheckOut)
                                            .AddParameter("@TransferByUserID", TransferByUserID)

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

        public DataSet SelectRptFolioStatement(Guid? ReservationID, Guid? FolioID, DateTime? StartDate, DateTime? EndDate, bool IsTaxRequired)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.

                    obj = StoredProcedure(MasterDALConstant.RPTFolioStatement)
                                        .AddParameter("@ReservationID", ReservationID)
                                        .AddParameter("@FolioID", FolioID)
                                        .AddParameter("@StartDate", StartDate)
                                        .AddParameter("@EndDate", EndDate)
                                        .AddParameter("@IsTaxRequired", IsTaxRequired)

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

        public DataSet SelectFolioSplitBilling(Guid? PropertyID, Guid? CompanyID, Guid? FolioID, Guid? ReservationID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.

                    obj = StoredProcedure(MasterDALConstant.Folio_SelectAllDataForSplitBilling)
                                        .AddParameter("@PropertyID", PropertyID)
                                        .AddParameter("@CompanyID", CompanyID)
                                        .AddParameter("@FolioID", FolioID)
                                        .AddParameter("@ReservationID", ReservationID)

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

        public DataSet SelectPastFolioList(string FolioNo, string ReservatioNo, string GuestName, DateTime? StartDate, DateTime? EndDate, Guid? CompanyID, Guid? PropertyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.

                    obj = StoredProcedure(MasterDALConstant.Folio_SelectPastFolioList)
                                        .AddParameter("@FolioNo", FolioNo)
                                        .AddParameter("@ReservatioNo", ReservatioNo)
                                        .AddParameter("@GuestName", GuestName)
                                        .AddParameter("@StartDate", StartDate)
                                        .AddParameter("@EndDate", EndDate)
                                        .AddParameter("@CompanyID", CompanyID)
                                        .AddParameter("@PropertyID", PropertyID)
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
        
        public Guid FolioPostCreditInAccount(Guid? ExpenseAcctID, decimal? Amount, int? Transaction_Origin, Guid? ResID, Guid? FolioID, Guid? CounterID, Guid? PropertyID, Guid? UserID, string Notes, Guid? CompanyID)
        {
            Guid returnBookID = Guid.Empty;
            Guid returnPostBookID = Guid.Empty;

            OutputParameterCollection outputCal = null;

            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.Folio_PostCreditInAccount)
                        .AddParameter("@ExpenseAcctID", ExpenseAcctID)
                        .AddParameter("@Amount", Amount)
                        .AddParameter("@Transaction_Origin", Transaction_Origin)
                        .AddParameter("@ResID", ResID)
                        .AddParameter("@FolioID", FolioID)
                        .AddParameter("@CounterID", CounterID)
                        .AddParameter("@PropertyID", PropertyID)
                        .AddParameter("@UserID", UserID)
                        .AddOutParameter("@BookID", returnBookID)
                        .AddParameter("@Notes", Notes)
                        .AddParameter("@CompanyID", CompanyID)
                          .WithTransaction(dbtr)
                       .Execute(out outputCal);


                    returnBookID = outputCal.GetValue("@BookID").Fetch<Guid>();
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

        public DataSet SelectAllCheckOutOpenFolios(string FolioNo, string RoomNo, string GuestName, Guid? CompanyID, Guid? PropertyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.Folio_SelectAll_CheckOutOpenFolios)
                                            .AddParameter("@FolioNo", FolioNo)
                                            .AddParameter("@RoomNo", RoomNo)
                                            .AddParameter("@GuestName", GuestName)
                                            .AddParameter("@CompanyID", CompanyID)
                                            .AddParameter("@PropertyID", PropertyID)

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
        
        #endregion
    }
}
