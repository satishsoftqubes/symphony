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
    /// Data access layer class for GuestMsgJoin
    /// </summary>
    public class GuestMsgJoinDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public GuestMsgJoinDAL()
            : base()
        {
            // Nothing for now.
        }
        public GuestMsgJoinDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<GuestMsgJoin> SelectAll(GuestMsgJoin dtoObject)
        {
            List<GuestMsgJoin> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.GuestMsgJoinSelectAll)
                                                .AddParameter("@GuestMessageID", dtoObject.GuestMessageID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@Message", dtoObject.Message)
.AddParameter("@Subject", dtoObject.Subject)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@Msg_PriorityTermID", dtoObject.Msg_PriorityTermID)
.AddParameter("@Msg_DateTime", dtoObject.Msg_DateTime)
.AddParameter("@IsInformed", dtoObject.IsInformed)
.AddParameter("@MessageOption_TermID", dtoObject.MessageOption_TermID)
.AddParameter("@MessageFrom", dtoObject.MessageFrom)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@ContactName", dtoObject.ContactName)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)

                                                .WithTransaction(dbtr)
                                                .FetchAll<GuestMsgJoin>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.GuestMsgJoinSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<GuestMsgJoin>();
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

        public List<GuestMsgJoin> SelectAll()
        {
            List<GuestMsgJoin> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.GuestMsgJoinSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<GuestMsgJoin>();
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
        public DataSet SelectAllWithDataSet(GuestMsgJoin dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.GuestMsgJoinSelectAll)
                                                .AddParameter("@GuestMessageID", dtoObject.GuestMessageID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@Message", dtoObject.Message)
.AddParameter("@Subject", dtoObject.Subject)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@Msg_PriorityTermID", dtoObject.Msg_PriorityTermID)
.AddParameter("@Msg_DateTime", dtoObject.Msg_DateTime)
.AddParameter("@IsInformed", dtoObject.IsInformed)
.AddParameter("@MessageOption_TermID", dtoObject.MessageOption_TermID)
.AddParameter("@MessageFrom", dtoObject.MessageFrom)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@ContactName", dtoObject.ContactName)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.GuestMsgJoinSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.GuestMsgJoinSelectAll)
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
        public bool Insert(GuestMsgJoin dtoObject)
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

                    StoredProcedure(MasterDALConstant.GuestMsgJoinInsert)
                        .AddParameter("@GuestMessageID", dtoObject.GuestMessageID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@Message", dtoObject.Message)
.AddParameter("@Subject", dtoObject.Subject)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@Msg_PriorityTermID", dtoObject.Msg_PriorityTermID)
.AddParameter("@Msg_DateTime", dtoObject.Msg_DateTime)
.AddParameter("@IsInformed", dtoObject.IsInformed)
.AddParameter("@MessageOption_TermID", dtoObject.MessageOption_TermID)
.AddParameter("@MessageFrom", dtoObject.MessageFrom)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@ContactName", dtoObject.ContactName)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsRead", dtoObject.IsRead)
.AddParameter("@IsDelete",dtoObject.IsDelete)

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
        public bool Update(GuestMsgJoin dtoObject)
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

                    StoredProcedure(MasterDALConstant.GuestMsgJoinUpdate)
                        .AddParameter("@GuestMessageID", dtoObject.GuestMessageID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@Message", dtoObject.Message)
.AddParameter("@Subject", dtoObject.Subject)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@Msg_PriorityTermID", dtoObject.Msg_PriorityTermID)
.AddParameter("@Msg_DateTime", dtoObject.Msg_DateTime)
.AddParameter("@IsInformed", dtoObject.IsInformed)
.AddParameter("@MessageOption_TermID", dtoObject.MessageOption_TermID)
.AddParameter("@MessageFrom", dtoObject.MessageFrom)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@ContactName", dtoObject.ContactName)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsRead", dtoObject.IsRead)
.AddParameter("@IsDelete", dtoObject.IsDelete)

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
                StoredProcedure(MasterDALConstant.GuestMsgJoinDeleteByPrimaryKey)
                    .AddParameter("@GuestMessageID"
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
        public bool Delete(GuestMsgJoin dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.GuestMsgJoinDeleteByPrimaryKey)
                    .AddParameter("@GuestMessageID", dtoObject.GuestMessageID)

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

        public GuestMsgJoin SelectByPrimaryKey(Guid Keys)
        {
            GuestMsgJoin obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.GuestMsgJoinSelectByPrimaryKey)
                            .AddParameter("@GuestMessageID"
, Keys)
                            .Fetch<GuestMsgJoin>();
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
        public List<GuestMsgJoin> SelectByField(string fieldName, object value)
        {
            List<GuestMsgJoin> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.GuestMsgJoinSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<GuestMsgJoin>();

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
                obj = StoredProcedure(MasterDALConstant.GuestMsgJoinSelectByField)
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
                StoredProcedure(MasterDALConstant.GuestMsgJoinDeleteByField)
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


        public DataSet SelectGuestMsgJoinSelectForList(Guid? PropertyID, Guid? CompanyID, Guid? GuestID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.GuestMsgJoinSelectForList)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@GuestID", GuestID)

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



        public DataSet SelectUnreadMsgList(Guid? PropertyID, Guid? CompanyID, string MsgFrom)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.GuestMsgJoinSelectUnreadMsgList)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@MessageFrom", MsgFrom)
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
