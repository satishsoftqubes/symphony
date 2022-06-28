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
	/// Data access layer class for Wing
	/// </summary>
	public class WingDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public WingDAL() :  base()
		{
			// Nothing for now.
		}
        public WingDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Wing> SelectAll(Wing dtoObject)
        {
            List<Wing> obj = null;
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
                        obj = StoredProcedure(MasterConstant.WingSelectAll)
                                                .AddParameter("@WingID", dtoObject.WingID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
//.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@SBArea", dtoObject.SBArea)
.AddParameter("@CarpetArea", dtoObject.CarpetArea)
.AddParameter("@WingCode", dtoObject.WingCode)
.AddParameter("@WingName", dtoObject.WingName)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@LastUpdateOn", dtoObject.LastUpdateOn)
.AddParameter("@LastUpdatedBy", dtoObject.LastUpdatedBy)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Wing>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.WingSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Wing>();
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

        public List<Wing> SelectAll()
        {
            List<Wing> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.WingSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Wing>();
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
        public DataSet SelectAllWithDataSet(Wing dtoObject)
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
                        obj = StoredProcedure(MasterConstant.WingSelectAll)
                                                .AddParameter("@WingID", dtoObject.WingID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@SBArea", dtoObject.SBArea)
.AddParameter("@CarpetArea", dtoObject.CarpetArea)
.AddParameter("@WingCode", dtoObject.WingCode)
.AddParameter("@WingName", dtoObject.WingName)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@LastUpdateOn", dtoObject.LastUpdateOn)
.AddParameter("@LastUpdatedBy", dtoObject.LastUpdatedBy)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.WingSelectAll)
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

                    obj = StoredProcedure(MasterConstant.WingSelectAll)
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
		public bool Insert(Wing dtoObject)
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

                    StoredProcedure(MasterConstant.WingInsert)
                        .AddParameter("@WingID", dtoObject.WingID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@SBArea", dtoObject.SBArea)
.AddParameter("@CarpetArea", dtoObject.CarpetArea)
.AddParameter("@WingCode", dtoObject.WingCode)
.AddParameter("@WingName", dtoObject.WingName)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@LastUpdateOn", dtoObject.LastUpdateOn)
.AddParameter("@LastUpdatedBy", dtoObject.LastUpdatedBy)
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

         /// <summary>
        /// update row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true for successfully updated</returns>
        public bool Update(Wing dtoObject)
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

                    StoredProcedure(MasterConstant.WingUpdate)
                        .AddParameter("@WingID", dtoObject.WingID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@SBArea", dtoObject.SBArea)
.AddParameter("@CarpetArea", dtoObject.CarpetArea)
.AddParameter("@WingCode", dtoObject.WingCode)
.AddParameter("@WingName", dtoObject.WingName)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@LastUpdateOn", dtoObject.LastUpdateOn)
.AddParameter("@LastUpdatedBy", dtoObject.LastUpdatedBy)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
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
                StoredProcedure(MasterConstant.WingDeleteByPrimaryKey)
                    .AddParameter("@WingID"
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
        public bool Delete(Wing dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.WingDeleteByPrimaryKey)
                    .AddParameter("@WingID", dtoObject.WingID)

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

        public Wing SelectByPrimaryKey(Guid Keys)
        {
            Wing obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.WingSelectByPrimaryKey)
                            .AddParameter("@WingID"
,Keys)
                            .Fetch<Wing>();
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
        public List<Wing> SelectByField(string fieldName, object value)
        {
            List<Wing> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.WingSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Wing>();

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
                obj = StoredProcedure(MasterConstant.WingSelectByField) 
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
                StoredProcedure(MasterConstant.WingDeleteByField) 
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

        public DataSet SearchWingData(Guid? WingID, Guid? PropertyID, string WingName)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.WingSearchWingData)
                                            .AddParameter("@WingID",WingID)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@WingName", WingName)
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

        public DataSet SelectDistinctWingOnRoom(Guid? propertyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.WingSelectDistinctWingOnRoom)
                            .AddParameter("@PropertyID", propertyID)
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

        public DataSet SelectDistinctWingAndRate(Guid? propertyID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.WingSelectDistinctWingAndRate)
                            .AddParameter("@PropertyID", propertyID)
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

        public DataSet SelectWing(string WingQuery)
        {
            DataSet dst = new DataSet();
            try
            {
                dst = Query(WingQuery)
                            .WithTransaction(dbtr)
                            .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return dst;
        }
        #endregion
	}
}
