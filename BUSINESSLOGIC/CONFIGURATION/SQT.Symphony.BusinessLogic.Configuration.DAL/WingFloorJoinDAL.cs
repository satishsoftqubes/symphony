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
	/// Data access layer class for WingFloorJoin
	/// </summary>
	public class WingFloorJoinDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public WingFloorJoinDAL() :  base()
		{
			// Nothing for now.
		}
        public WingFloorJoinDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get All Value With Wing And Floor Name
        /// </summary>
        /// <param name="WingID"></param>
        /// <param name="FloorID"></param>
        /// <returns></returns>
        public DataSet SelectAllWithName(Guid? WingID, Guid? FloorID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.WingFlorrJoinSelectAllWithName)
                    .AddParameter("@WingID", WingID)
                    .AddParameter("@FloorID", FloorID)
                    .FetchDataSet();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Dst;
        }
        public List<WingFloorJoin> SelectAll(WingFloorJoin dtoObject)
        {
            List<WingFloorJoin> obj = null;
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
                        obj = StoredProcedure(MasterConstant.WingFloorJoinSelectAll)
                                                .AddParameter("@WingFloorJoinID", dtoObject.WingFloorJoinID)
.AddParameter("@WingID", dtoObject.WingID)
.AddParameter("@FloorID", dtoObject.FloorID)
.AddParameter("@Area", dtoObject.Area)
.AddParameter("@CarpateArea", dtoObject.CarpateArea)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)

                                                .WithTransaction(dbtr)
                                                .FetchAll<WingFloorJoin>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.WingFloorJoinSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<WingFloorJoin>();
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

        public List<WingFloorJoin> SelectAll()
        {
            List<WingFloorJoin> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.WingFloorJoinSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<WingFloorJoin>();
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
        public DataSet SelectAllWithDataSet(WingFloorJoin dtoObject)
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
                        obj = StoredProcedure(MasterConstant.WingFloorJoinSelectAll)
                                                .AddParameter("@WingFloorJoinID", dtoObject.WingFloorJoinID)
.AddParameter("@WingID", dtoObject.WingID)
.AddParameter("@FloorID", dtoObject.FloorID)
.AddParameter("@Area", dtoObject.Area)
.AddParameter("@CarpateArea", dtoObject.CarpateArea)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.WingFloorJoinSelectAll)
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

                    obj = StoredProcedure(MasterConstant.WingFloorJoinSelectAll)
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
		public bool Insert(WingFloorJoin dtoObject)
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

                    StoredProcedure(MasterConstant.WingFloorJoinInsert)
                        .AddParameter("@WingFloorJoinID", dtoObject.WingFloorJoinID)
.AddParameter("@WingID", dtoObject.WingID)
.AddParameter("@FloorID", dtoObject.FloorID)
.AddParameter("@Area", dtoObject.Area)
.AddParameter("@CarpateArea", dtoObject.CarpateArea)
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
        public bool Update(WingFloorJoin dtoObject)
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

                    StoredProcedure(MasterConstant.WingFloorJoinUpdate)
                        .AddParameter("@WingFloorJoinID", dtoObject.WingFloorJoinID)
.AddParameter("@WingID", dtoObject.WingID)
.AddParameter("@FloorID", dtoObject.FloorID)
.AddParameter("@Area", dtoObject.Area)
.AddParameter("@CarpateArea", dtoObject.CarpateArea)
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
                StoredProcedure(MasterConstant.WingFloorJoinDeleteByPrimaryKey)
                    .AddParameter("@WingFloorJoinID"
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
        public bool Delete(WingFloorJoin dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.WingFloorJoinDeleteByPrimaryKey)
                    .AddParameter("@WingFloorJoinID", dtoObject.WingFloorJoinID)

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

        public WingFloorJoin SelectByPrimaryKey(Guid Keys)
        {
            WingFloorJoin obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.WingFloorJoinSelectByPrimaryKey)
                            .AddParameter("@WingFloorJoinID"
,Keys)
                            .Fetch<WingFloorJoin>();
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
        public List<WingFloorJoin> SelectByField(string fieldName, object value)
        {
            List<WingFloorJoin> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.WingFloorJoinSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<WingFloorJoin>();

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
                obj = StoredProcedure(MasterConstant.WingFloorJoinSelectByField) 
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
                StoredProcedure(MasterConstant.WingFloorJoinDeleteByField) 
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

        public bool DeleteByFloorID(Guid? FloorID)
        {
            try
            {
                StoredProcedure(MasterConstant.WingFlorrJoinDeleteByFloorID)
                                    .AddParameter("@FloorID", FloorID)                                    
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

        #endregion
	}
}
