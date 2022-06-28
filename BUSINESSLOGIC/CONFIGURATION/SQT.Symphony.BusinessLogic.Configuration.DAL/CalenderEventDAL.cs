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
	/// Data access layer class for CalenderEvent
	/// </summary>
	public class CalenderEventDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public CalenderEventDAL() :  base()
		{
			// Nothing for now.
		}
        public CalenderEventDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<CalenderEvent> SelectAll(CalenderEvent dtoObject)
        {
            List<CalenderEvent> obj = null;
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
                        obj = StoredProcedure(MasterConstant.CalenderEventSelectAll)
                                                .AddParameter("@EventID", dtoObject.EventID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@EventDate", dtoObject.EventDate)
.AddParameter("@EventName", dtoObject.EventName)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@Rate", dtoObject.Rate)
.AddParameter("@IsFlat", dtoObject.IsFlat)
.AddParameter("@GroupEventID", dtoObject.GroupEventID)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)

                                                .WithTransaction(dbtr)
                                                .FetchAll<CalenderEvent>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.CalenderEventSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<CalenderEvent>();
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

        public List<CalenderEvent> SelectAll()
        {
            List<CalenderEvent> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.CalenderEventSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<CalenderEvent>();
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
        public DataSet SelectAllWithDataSet(CalenderEvent dtoObject)
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
                        obj = StoredProcedure(MasterConstant.CalenderEventSelectAll)
                                                .AddParameter("@EventID", dtoObject.EventID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@EventDate", dtoObject.EventDate)
.AddParameter("@EventName", dtoObject.EventName)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@Rate", dtoObject.Rate)
.AddParameter("@IsFlat", dtoObject.IsFlat)
.AddParameter("@GroupEventID", dtoObject.GroupEventID)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.CalenderEventSelectAll)
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

                    obj = StoredProcedure(MasterConstant.CalenderEventSelectAll)
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
		public bool Insert(CalenderEvent dtoObject)
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

                    StoredProcedure(MasterConstant.CalenderEventInsert)
                        .AddParameter("@EventID", dtoObject.EventID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@EventDate", dtoObject.EventDate)
.AddParameter("@EventName", dtoObject.EventName)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@Rate", dtoObject.Rate)
.AddParameter("@IsFlat", dtoObject.IsFlat)
.AddParameter("@GroupEventID", dtoObject.GroupEventID)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)

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
        public bool Update(CalenderEvent dtoObject)
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

                    StoredProcedure(MasterConstant.CalenderEventUpdate)
                        .AddParameter("@EventID", dtoObject.EventID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@EventDate", dtoObject.EventDate)
.AddParameter("@EventName", dtoObject.EventName)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@Rate", dtoObject.Rate)
.AddParameter("@IsFlat", dtoObject.IsFlat)
.AddParameter("@GroupEventID", dtoObject.GroupEventID)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)

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
                StoredProcedure(MasterConstant.CalenderEventDeleteByPrimaryKey)
                    .AddParameter("@EventID"
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
        public bool Delete(CalenderEvent dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.CalenderEventDeleteByPrimaryKey)
                    .AddParameter("@EventID", dtoObject.EventID)

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

        public CalenderEvent SelectByPrimaryKey(Guid Keys)
        {
            CalenderEvent obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CalenderEventSelectByPrimaryKey)
                            .AddParameter("@EventID"
,Keys)
                            .Fetch<CalenderEvent>();
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
        public List<CalenderEvent> SelectByField(string fieldName, object value)
        {
            List<CalenderEvent> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CalenderEventSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<CalenderEvent>();

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
                obj = StoredProcedure(MasterConstant.CalenderEventSelectByField) 
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
                StoredProcedure(MasterConstant.CalenderEventDeleteByField) 
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

        public bool DeleteDataByRateID(Guid PropertyID, Guid RateID)
        {
            try
            {
                StoredProcedure(MasterConstant.CalenderEventDeleteDataByRateID)
                    .AddParameter("@PropertyID", PropertyID)
                    .AddParameter("@RateID", RateID)
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

        public bool DeleteDataByDateAndRateID(Guid PropertyID, Guid RateID, DateTime EventDate)
        {
            try
            {
                StoredProcedure(MasterConstant.CalenderEventDeleteDataByDateAndRateID)
                    .AddParameter("@PropertyID", PropertyID)
                    .AddParameter("@RateID", RateID)
                    .AddParameter("@EventDate", EventDate)
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
