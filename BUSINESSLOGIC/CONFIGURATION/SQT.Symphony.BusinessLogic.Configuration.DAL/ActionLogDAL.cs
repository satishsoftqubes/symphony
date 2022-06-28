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
	/// Data access layer class for ActionLog
	/// </summary>
	public class ActionLogDAL : LinqDAL 
	{

        DbTransaction dbtr = null;

        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public ActionLogDAL() :  base()
		{
			// Nothing for now.
		}
        public ActionLogDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<ActionLog> SelectAll(ActionLog dtoObject)
        {
            List<ActionLog> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    if(dtoObject != null)
                        parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                    if(dtoObject != null)  
                    {
                        obj = StoredProcedure(MasterConstant.ActionLogSelectAll)
                                                .AddParameter("@ActionLogID", dtoObject.ActionLogID)
.AddParameter("@ActionPerformedBy", dtoObject.ActionPerformedBy)
.AddParameter("@ActionPerformedOn", dtoObject.ActionPerformedOn)
.AddParameter("@ActionObject", dtoObject.ActionObject)
.AddParameter("@ActionType", dtoObject.ActionType)
.AddParameter("@ObjectOldValue", dtoObject.ObjectOldValue)
.AddParameter("@ObjectNewValue", dtoObject.ObjectNewValue)
.AddParameter("@LogInLogID", dtoObject.LogInLogID)
.AddParameter("@AutherizedBy", dtoObject.AutherizedBy)
.AddParameter("@AutherizerOn", dtoObject.AutherizerOn)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)

                                                .WithTransaction(dbtr)
                                                .FetchAll<ActionLog>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.ActionLogSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<ActionLog>();
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

        public List<ActionLog> SelectAll()
        {
            List<ActionLog> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.ActionLogSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<ActionLog>();
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
        public DataSet SelectAllWithDataSet(ActionLog dtoObject)
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
                        obj = StoredProcedure(MasterConstant.ActionLogSelectAll)
                                                .AddParameter("@ActionLogID", dtoObject.ActionLogID)
.AddParameter("@ActionPerformedBy", dtoObject.ActionPerformedBy)
.AddParameter("@ActionPerformedOn", dtoObject.ActionPerformedOn)
.AddParameter("@ActionObject", dtoObject.ActionObject)
.AddParameter("@ActionType", dtoObject.ActionType)
.AddParameter("@ObjectOldValue", dtoObject.ObjectOldValue)
.AddParameter("@ObjectNewValue", dtoObject.ObjectNewValue)
.AddParameter("@LogInLogID", dtoObject.LogInLogID)
.AddParameter("@AutherizedBy", dtoObject.AutherizedBy)
.AddParameter("@AutherizerOn", dtoObject.AutherizerOn)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.ActionLogSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                }
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
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
                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.ActionLogSelectAll)
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
        public DataSet rptActionLog(string UserDispalayName, DateTime? StartDate, DateTime? EndDate, string ActionType, string ActionObject)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.ReportActionLog)
                    .AddParameter("@UserDisplayName", UserDispalayName)
                    .AddParameter("@StartDate", StartDate)
                    .AddParameter("@EndDate", EndDate)
                    .AddParameter("@ActionType", ActionType)
                    .AddParameter("@ActionObject", ActionObject)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }
        /// <summary>
        /// insert new row in the table
        /// </summary>
		/// <param name="businessObject">business object</param>
		/// <returns>true of successfully insert</returns>
		public bool Insert(ActionLog dtoObject)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    if (dtoObject == null)
                        throw (new ParameterNullException("Object can not be null"));

                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterConstant.ActionLogInsert)
                        .AddParameter("@ActionLogID", dtoObject.ActionLogID)
.AddParameter("@ActionPerformedBy", dtoObject.ActionPerformedBy)
.AddParameter("@ActionPerformedOn", dtoObject.ActionPerformedOn)
.AddParameter("@ActionObject", dtoObject.ActionObject)
.AddParameter("@ActionType", dtoObject.ActionType)
.AddParameter("@ObjectOldValue", dtoObject.ObjectOldValue)
.AddParameter("@ObjectNewValue", dtoObject.ObjectNewValue)
.AddParameter("@LogInLogID", dtoObject.LogInLogID)
.AddParameter("@AutherizedBy", dtoObject.AutherizedBy)
.AddParameter("@AutherizerOn", dtoObject.AutherizerOn)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@Description", dtoObject.Description)

                        .WithTransaction(dbtr)
                        .Execute();
                }
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
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
        public bool Update(ActionLog dtoObject)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    if (dtoObject == null)
                        throw (new ParameterNullException("Object can not be null"));

                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterConstant.ActionLogUpdate)
                        .AddParameter("@ActionLogID", dtoObject.ActionLogID)
.AddParameter("@ActionPerformedBy", dtoObject.ActionPerformedBy)
.AddParameter("@ActionPerformedOn", dtoObject.ActionPerformedOn)
.AddParameter("@ActionObject", dtoObject.ActionObject)
.AddParameter("@ActionType", dtoObject.ActionType)
.AddParameter("@ObjectOldValue", dtoObject.ObjectOldValue)
.AddParameter("@ObjectNewValue", dtoObject.ObjectNewValue)
.AddParameter("@LogInLogID", dtoObject.LogInLogID)
.AddParameter("@AutherizedBy", dtoObject.AutherizedBy)
.AddParameter("@AutherizerOn", dtoObject.AutherizerOn)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)

                        .WithTransaction(dbtr)
                        .Execute();
                }
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
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
                StoredProcedure(MasterConstant.ActionLogDeleteByPrimaryKey)
                    .AddParameter("@ActionLogID"
,Keys)
                    .WithTransaction(dbtr)
                    .Execute();
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return true;
        }
        public bool Delete(ActionLog dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.ActionLogDeleteByPrimaryKey)
                    .AddParameter("@ActionLogID", dtoObject.ActionLogID)

                    .WithTransaction(dbtr)
                    .Execute();
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return true;
        }

        public ActionLog SelectByPrimaryKey(Guid Keys)
        {
            ActionLog obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ActionLogSelectByPrimaryKey)
                            .AddParameter("@ActionLogID"
,Keys)
                            .Fetch<ActionLog>();
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }
        public List<ActionLog> SelectByField(string fieldName, object value)
        {
            List<ActionLog> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ActionLogSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<ActionLog>();

            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
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
                obj = StoredProcedure(MasterConstant.ActionLogSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchDataSet();

            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
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
                StoredProcedure(MasterConstant.ActionLogDeleteByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .WithTransaction(dbtr)
                                    .Execute();
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return true;
        }

        public DataSet SelectActionLog(string ActionLogQuery)
        {
            DataSet dst = new DataSet();
            try
            {
                dst = Query(ActionLogQuery)
                            .WithTransaction(dbtr)
                            .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return dst;
        }

        public DataSet ActionLogSearchData(Guid? ActionLogID, Guid? ActionPerformedBy, DateTime? ActionPerformedOn, string ActionObject, string ActionType)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.ActionLogSearchData)
                    .AddParameter("@ActionLogID", ActionLogID)
                    .AddParameter("@ActionPerformedBy", ActionPerformedBy)
                    .AddParameter("@ActionPerformedOn", ActionPerformedOn)
                    .AddParameter("@ActionObject", ActionObject)
                    .AddParameter("@ActionType", ActionType)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet ActionLogSymphonySearchData(Guid? ActionLogID, Guid? ActionPerformedBy, DateTime? ActionPerformedOn, string ActionObject, string ActionType, string UserRoleType, Guid CompanyID, Guid PropertyID, Guid UserID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.ActionLogSymphonySearchData)
                    .AddParameter("@ActionLogID", ActionLogID)
                    .AddParameter("@ActionPerformedBy", ActionPerformedBy)
                    .AddParameter("@ActionPerformedOn", ActionPerformedOn)
                    .AddParameter("@ActionObject", ActionObject)
                    .AddParameter("@ActionType", ActionType)
                    .AddParameter("@UserRoleType", UserRoleType)
                    .AddParameter("@CompanyID", CompanyID)
                    .AddParameter("@PropertyID", PropertyID)
                    .AddParameter("@UserID", UserID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        #endregion
	}
}
