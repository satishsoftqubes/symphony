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
	/// Data access layer class for ReservationHistory
	/// </summary>
	public class ReservationHistoryDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public ReservationHistoryDAL() :  base()
		{
			// Nothing for now.
		}
        public ReservationHistoryDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<ReservationHistory> SelectAll(ReservationHistory dtoObject)
        {
            List<ReservationHistory> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    if(dtoObject != null)
                        parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                    if(dtoObject != null)  
                    {
                        obj = StoredProcedure(MasterDALConstant.ReservationHistorySelectAll)
                                                .AddParameter("@ResHistoryID", dtoObject.ResHistoryID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@Operation", dtoObject.Operation)
.AddParameter("@OperationDate", dtoObject.OperationDate)
.AddParameter("@OperationBy", dtoObject.OperationBy)
.AddParameter("@AuthorizedBy", dtoObject.AuthorizedBy)
.AddParameter("@Reason", dtoObject.Reason)
.AddParameter("@ReasonByGuest", dtoObject.ReasonByGuest)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UserName", dtoObject.UserName)
.AddParameter("@OldStatus_TermID", dtoObject.OldStatus_TermID)
.AddParameter("@NewStatus_TermID", dtoObject.NewStatus_TermID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@OldRecord", dtoObject.OldRecord)
.AddParameter("@OperationRequestBy", dtoObject.OperationRequestBy)
.AddParameter("@OperationRequestMode_TermID", dtoObject.OperationRequestMode_TermID)

                                                .WithTransaction(dbtr)
                                                .FetchAll<ReservationHistory>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ReservationHistorySelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<ReservationHistory>();
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

        public List<ReservationHistory> SelectAll()
        {
            List<ReservationHistory> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.ReservationHistorySelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<ReservationHistory>();
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
        public DataSet SelectAllWithDataSet(ReservationHistory dtoObject)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    if(dtoObject != null)
                        parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                    if(dtoObject != null)  
                    {
                        obj = StoredProcedure(MasterDALConstant.ReservationHistorySelectAll)
                                                .AddParameter("@ResHistoryID", dtoObject.ResHistoryID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@Operation", dtoObject.Operation)
.AddParameter("@OperationDate", dtoObject.OperationDate)
.AddParameter("@OperationBy", dtoObject.OperationBy)
.AddParameter("@AuthorizedBy", dtoObject.AuthorizedBy)
.AddParameter("@Reason", dtoObject.Reason)
.AddParameter("@ReasonByGuest", dtoObject.ReasonByGuest)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UserName", dtoObject.UserName)
.AddParameter("@OldStatus_TermID", dtoObject.OldStatus_TermID)
.AddParameter("@NewStatus_TermID", dtoObject.NewStatus_TermID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@OldRecord", dtoObject.OldRecord)
.AddParameter("@OperationRequestBy", dtoObject.OperationRequestBy)
.AddParameter("@OperationRequestMode_TermID", dtoObject.OperationRequestMode_TermID)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ReservationHistorySelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.ReservationHistorySelectAll)
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
		public bool Insert(ReservationHistory dtoObject)
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

                    StoredProcedure(MasterDALConstant.ReservationHistoryInsert)
                        .AddParameter("@ResHistoryID", dtoObject.ResHistoryID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@Operation", dtoObject.Operation)
.AddParameter("@OperationDate", dtoObject.OperationDate)
.AddParameter("@OperationBy", dtoObject.OperationBy)
.AddParameter("@AuthorizedBy", dtoObject.AuthorizedBy)
.AddParameter("@Reason", dtoObject.Reason)
.AddParameter("@ReasonByGuest", dtoObject.ReasonByGuest)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UserName", dtoObject.UserName)
.AddParameter("@OldStatus_TermID", dtoObject.OldStatus_TermID)
.AddParameter("@NewStatus_TermID", dtoObject.NewStatus_TermID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@OldRecord", dtoObject.OldRecord)
.AddParameter("@OperationRequestBy", dtoObject.OperationRequestBy)
.AddParameter("@OperationRequestMode_TermID", dtoObject.OperationRequestMode_TermID)

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
        public bool Update(ReservationHistory dtoObject)
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

                    StoredProcedure(MasterDALConstant.ReservationHistoryUpdate)
                        .AddParameter("@ResHistoryID", dtoObject.ResHistoryID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@Operation", dtoObject.Operation)
.AddParameter("@OperationDate", dtoObject.OperationDate)
.AddParameter("@OperationBy", dtoObject.OperationBy)
.AddParameter("@AuthorizedBy", dtoObject.AuthorizedBy)
.AddParameter("@Reason", dtoObject.Reason)
.AddParameter("@ReasonByGuest", dtoObject.ReasonByGuest)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UserName", dtoObject.UserName)
.AddParameter("@OldStatus_TermID", dtoObject.OldStatus_TermID)
.AddParameter("@NewStatus_TermID", dtoObject.NewStatus_TermID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@OldRecord", dtoObject.OldRecord)
.AddParameter("@OperationRequestBy", dtoObject.OperationRequestBy)
.AddParameter("@OperationRequestMode_TermID", dtoObject.OperationRequestMode_TermID)

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
                StoredProcedure(MasterDALConstant.ReservationHistoryDeleteByPrimaryKey)
                    .AddParameter("@ResHistoryID"
,Keys)
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
        public bool Delete(ReservationHistory dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.ReservationHistoryDeleteByPrimaryKey)
                    .AddParameter("@ResHistoryID", dtoObject.ResHistoryID)

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

        public ReservationHistory SelectByPrimaryKey(Guid Keys)
        {
            ReservationHistory obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationHistorySelectByPrimaryKey)
                            .AddParameter("@ResHistoryID"
,Keys)
                            .Fetch<ReservationHistory>();
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
        public List<ReservationHistory> SelectByField(string fieldName, object value)
        {
            List<ReservationHistory> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationHistorySelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<ReservationHistory>();

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
                obj = StoredProcedure(MasterDALConstant.ReservationHistorySelectByField) 
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
                StoredProcedure(MasterDALConstant.ReservationHistoryDeleteByField) 
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

        #endregion
	}
}
