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
	/// Data access layer class for CheckinTimeLog
	/// </summary>
	public class CheckinTimeLogDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public CheckinTimeLogDAL() :  base()
		{
			// Nothing for now.
		}
        public CheckinTimeLogDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<CheckinTimeLog> SelectAll(CheckinTimeLog dtoObject)
        {
            List<CheckinTimeLog> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.CheckinTimeLogSelectAll)
                                                .AddParameter("@CheckInLogID", dtoObject.CheckInLogID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@ReservationType_TermID", dtoObject.ReservationType_TermID)
.AddParameter("@CheckInStartTime", dtoObject.CheckInStartTime)
.AddParameter("@CheckInEndTime", dtoObject.CheckInEndTime)
.AddParameter("@CheckInBy", dtoObject.CheckInBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)

                                                .WithTransaction(dbtr)
                                                .FetchAll<CheckinTimeLog>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.CheckinTimeLogSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<CheckinTimeLog>();
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

        public List<CheckinTimeLog> SelectAll()
        {
            List<CheckinTimeLog> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.CheckinTimeLogSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<CheckinTimeLog>();
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
        public DataSet SelectAllWithDataSet(CheckinTimeLog dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.CheckinTimeLogSelectAll)
                                                .AddParameter("@CheckInLogID", dtoObject.CheckInLogID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@ReservationType_TermID", dtoObject.ReservationType_TermID)
.AddParameter("@CheckInStartTime", dtoObject.CheckInStartTime)
.AddParameter("@CheckInEndTime", dtoObject.CheckInEndTime)
.AddParameter("@CheckInBy", dtoObject.CheckInBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.CheckinTimeLogSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.CheckinTimeLogSelectAll)
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
		public bool Insert(CheckinTimeLog dtoObject)
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

                    StoredProcedure(MasterDALConstant.CheckinTimeLogInsert)
                        .AddParameter("@CheckInLogID", dtoObject.CheckInLogID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@ReservationType_TermID", dtoObject.ReservationType_TermID)
.AddParameter("@CheckInStartTime", dtoObject.CheckInStartTime)
.AddParameter("@CheckInEndTime", dtoObject.CheckInEndTime)
.AddParameter("@CheckInBy", dtoObject.CheckInBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)

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
        public bool Update(CheckinTimeLog dtoObject)
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

                    StoredProcedure(MasterDALConstant.CheckinTimeLogUpdate)
                        .AddParameter("@CheckInLogID", dtoObject.CheckInLogID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@ReservationType_TermID", dtoObject.ReservationType_TermID)
.AddParameter("@CheckInStartTime", dtoObject.CheckInStartTime)
.AddParameter("@CheckInEndTime", dtoObject.CheckInEndTime)
.AddParameter("@CheckInBy", dtoObject.CheckInBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)

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
                StoredProcedure(MasterDALConstant.CheckinTimeLogDeleteByPrimaryKey)
                    .AddParameter("@CheckInLogID"
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
        public bool Delete(CheckinTimeLog dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.CheckinTimeLogDeleteByPrimaryKey)
                    .AddParameter("@CheckInLogID", dtoObject.CheckInLogID)

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

        public CheckinTimeLog SelectByPrimaryKey(Guid Keys)
        {
            CheckinTimeLog obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.CheckinTimeLogSelectByPrimaryKey)
                            .AddParameter("@CheckInLogID"
,Keys)
                            .Fetch<CheckinTimeLog>();
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
        public List<CheckinTimeLog> SelectByField(string fieldName, object value)
        {
            List<CheckinTimeLog> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.CheckinTimeLogSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<CheckinTimeLog>();

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
                obj = StoredProcedure(MasterDALConstant.CheckinTimeLogSelectByField) 
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
                StoredProcedure(MasterDALConstant.CheckinTimeLogDeleteByField) 
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

        public DataSet SelectCheckInLog(DateTime? fromDate, DateTime? toDate, Guid? CheckInBy, Guid properytID, Guid companyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.CheckinTimeLogSelectCheckInLog)
                                    .AddParameter("@FromDate", fromDate)
                                    .AddParameter("@ToDate", toDate)
                                    .AddParameter("@CheckInBy", CheckInBy)
                                    .AddParameter("@PropertyID", properytID)
                                    .AddParameter("@CompanyID", companyID)
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
