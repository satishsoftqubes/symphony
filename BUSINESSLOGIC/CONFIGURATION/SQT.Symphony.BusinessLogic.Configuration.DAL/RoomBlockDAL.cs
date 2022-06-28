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
    /// Data access layer class for RoomBlock
    /// </summary>
    public class RoomBlockDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public RoomBlockDAL()
            : base()
        {
            // Nothing for now.
        }
        public RoomBlockDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<RoomBlock> SelectAll(RoomBlock dtoObject)
        {
            List<RoomBlock> obj = null;
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
                        obj = StoredProcedure(MasterConstant.RoomBlockSelectAll)
                                                .AddParameter("@BlockRoomID", dtoObject.BlockRoomID)
.AddParameter("@StartDate", dtoObject.StartDate)
.AddParameter("@EndDate", dtoObject.EndDate)
.AddParameter("@BlockBy", dtoObject.BlockBy)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@DateOfBlock", dtoObject.DateOfBlock)
.AddParameter("@BlockReason", dtoObject.BlockReason)
.AddParameter("@CauseOfBlock_TermID", dtoObject.CauseOfBlock_TermID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@BlockForTermID", dtoObject.BlockForTermID)

                                                .WithTransaction(dbtr)
                                                .FetchAll<RoomBlock>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.RoomBlockSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<RoomBlock>();
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

        public List<RoomBlock> SelectAll()
        {
            List<RoomBlock> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.RoomBlockSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<RoomBlock>();
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
        public DataSet SelectAllWithDataSet(RoomBlock dtoObject)
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
                        obj = StoredProcedure(MasterConstant.RoomBlockSelectAll)
                                                .AddParameter("@BlockRoomID", dtoObject.BlockRoomID)
.AddParameter("@StartDate", dtoObject.StartDate)
.AddParameter("@EndDate", dtoObject.EndDate)
.AddParameter("@BlockBy", dtoObject.BlockBy)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@DateOfBlock", dtoObject.DateOfBlock)
.AddParameter("@BlockReason", dtoObject.BlockReason)
.AddParameter("@CauseOfBlock_TermID", dtoObject.CauseOfBlock_TermID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@BlockForTermID", dtoObject.BlockForTermID)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.RoomBlockSelectAll)
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

                    obj = StoredProcedure(MasterConstant.RoomBlockSelectAll)
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
        public bool Insert(RoomBlock dtoObject)
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

                    StoredProcedure(MasterConstant.RoomBlockInsert)
                        .AddParameter("@BlockRoomID", dtoObject.BlockRoomID)
.AddParameter("@StartDate", dtoObject.StartDate)
.AddParameter("@EndDate", dtoObject.EndDate)
.AddParameter("@BlockBy", dtoObject.BlockBy)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@DateOfBlock", dtoObject.DateOfBlock)
.AddParameter("@BlockReason", dtoObject.BlockReason)
.AddParameter("@CauseOfBlock_TermID", dtoObject.CauseOfBlock_TermID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@BlockForTermID", dtoObject.BlockForTermID)

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
        public bool Update(RoomBlock dtoObject)
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

                    StoredProcedure(MasterConstant.RoomBlockUpdate)
                        .AddParameter("@BlockRoomID", dtoObject.BlockRoomID)
.AddParameter("@StartDate", dtoObject.StartDate)
.AddParameter("@EndDate", dtoObject.EndDate)
.AddParameter("@BlockBy", dtoObject.BlockBy)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@DateOfBlock", dtoObject.DateOfBlock)
.AddParameter("@BlockReason", dtoObject.BlockReason)
.AddParameter("@CauseOfBlock_TermID", dtoObject.CauseOfBlock_TermID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@BlockForTermID", dtoObject.BlockForTermID)

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
                StoredProcedure(MasterConstant.RoomBlockDeleteByPrimaryKey)
                    .AddParameter("@BlockRoomID"
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
        public bool Delete(RoomBlock dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.RoomBlockDeleteByPrimaryKey)
                    .AddParameter("@BlockRoomID", dtoObject.BlockRoomID)

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

        public RoomBlock SelectByPrimaryKey(Guid Keys)
        {
            RoomBlock obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RoomBlockSelectByPrimaryKey)
                            .AddParameter("@BlockRoomID"
, Keys)
                            .Fetch<RoomBlock>();
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
        public List<RoomBlock> SelectByField(string fieldName, object value)
        {
            List<RoomBlock> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RoomBlockSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<RoomBlock>();

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
                obj = StoredProcedure(MasterConstant.RoomBlockSelectByField)
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
                StoredProcedure(MasterConstant.RoomBlockDeleteByField)
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

        public DataSet RoomBlockSearchData(Guid? BlockRoomID, Guid? PropertyID, DateTime? StartDate, DateTime? EndDate, string BlockBy, Guid? CompanyID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.RoomBlockSearchData)
                    .AddParameter("@BlockRoomID", BlockRoomID)
                    .AddParameter("@PropertyID", PropertyID)
                    .AddParameter("StartDate", StartDate)
                    .AddParameter("@EndDate", EndDate)
                    .AddParameter("@BlockBy", BlockBy)
                    .AddParameter("CompanyID", CompanyID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet RoomBlockSelectAllRoomBlockData(DateTime? StartDate, DateTime? EndDate, string BlockBy, Guid? PropertyID, Guid? CompanyID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.RoomBlockSelectAllRoomBlockData)
                    .AddParameter("@PropertyID", PropertyID)
                    .AddParameter("StartDate", StartDate)
                    .AddParameter("@EndDate", EndDate)
                    .AddParameter("@BlockBy", BlockBy)
                    .AddParameter("CompanyID", CompanyID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public bool DeleteBlockRoomDetailsRoomData(Guid BlockRoomDetailID, Guid BlockRoomD, Guid RoomID)
        {
            try
            {
                StoredProcedure(MasterConstant.RoomBlockDetailsDeleteBlockRoomDetailsRoomData)
                                    .AddParameter("@BlockRoomDetailID", BlockRoomDetailID)
                                    .AddParameter("@BlockRoomID", BlockRoomD)
                                    .AddParameter("@RoomID", RoomID)
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

        public bool InsertForComplementoryReservation(DateTime StartDate, DateTime EndDate, string BlockBy, Guid PropertyID, Guid CompanyID, DateTime DateOfBlock, Guid? CauseOfBlock_TermID, Guid RoomID, Guid RoomTypeID,Guid? ReservationID,bool IsForFullRoomReservation)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {                    
                    StoredProcedure(MasterConstant.RoomBlockInsertForComplementoryReservation)
                        .AddParameter("@StartDate", StartDate)
                        .AddParameter("@EndDate", EndDate)
                        .AddParameter("@BlockBy", BlockBy)
                        .AddParameter("@PropertyID", PropertyID)
                        .AddParameter("@CompanyID", CompanyID)
                        .AddParameter("@DateOfBlock", DateOfBlock)
                        .AddParameter("@CauseOfBlock_TermID", CauseOfBlock_TermID)
                        .AddParameter("@RoomID", RoomID)
                        .AddParameter("@RoomTypeID", RoomTypeID)
                        .AddParameter("@ReservationID", ReservationID)
                        .AddParameter("@IsForFullRoom", IsForFullRoomReservation)
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

        public bool DeleteForComplementoryReservation(DateTime StartDate, DateTime EndDate, Guid PropertyID, Guid CompanyID, Guid RoomTypeID, Guid ReservationID)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    StoredProcedure(MasterConstant.RoomBlockDetailsDeleteBlockRoomDetailsRoomData)
                        .AddParameter("@StartDate", StartDate)
                        .AddParameter("@EndDate", EndDate)
                        .AddParameter("@PropertyID", PropertyID)
                        .AddParameter("@CompanyID", CompanyID)
                        .AddParameter("@RoomTypeID", RoomTypeID)
                        .AddParameter("@ReservationID", ReservationID)
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


        #endregion
    }
}
