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
	/// Data access layer class for RoleRightJoin
	/// </summary>
	public class RoleRightJoinDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public RoleRightJoinDAL() :  base()
		{
			// Nothing for now.
		}
        public RoleRightJoinDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get Access Denied Roles 
        /// </summary>
        /// <param name="FormName"></param>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public string GetAccessString(string FormName, Guid UserID)
        {
            DataSet Dst = new DataSet();
            DataView Dv ;
            try
            {
                Dst = StoredProcedure(MasterConstant.RoleRightGetAccess)
                    .AddParameter("@FormName", FormName)
                    .AddParameter("@UserID", UserID)
                    .FetchDataSet();
                Dv = new DataView(Dst.Tables[0]);
            }
            catch
            {
                throw;
            }
            return Dv[0]["Result"].ToString();
        }

        /// <summary>
        /// Get Access Denied Roles 
        /// </summary>
        /// <param name="FormName"></param>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public DataView GetIUDVAccess(string FormName, Guid UserID)
        {
            DataSet Dst = new DataSet();
            DataView Dv;
            try
            {
                Dst = StoredProcedure(MasterConstant.RoleRightGetIUDVAccess)
                    .AddParameter("@FormName", FormName)
                    .AddParameter("@UserID", UserID)
                    .FetchDataSet();
                Dv = new DataView(Dst.Tables[0]);
            }
            catch
            {
                throw;
            }
            return Dv;
        }
        public List<RoleRightJoin> SelectAll(RoleRightJoin dtoObject)
        {
            List<RoleRightJoin> obj = null;
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
                        obj = StoredProcedure(MasterConstant.RoleRightJoinSelectAll)
                                                .AddParameter("@RoleRightJoinID", dtoObject.RoleRightJoinID)
.AddParameter("@RoleID", dtoObject.RoleID)
.AddParameter("@RightID", dtoObject.RightID)
.AddParameter("@IsView", dtoObject.IsView)
.AddParameter("@IsCreate", dtoObject.IsCreate)
.AddParameter("@IsUpdate", dtoObject.IsUpdate)
.AddParameter("@IsDelete", dtoObject.IsDelete)

                                                .WithTransaction(dbtr)
                                                .FetchAll<RoleRightJoin>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.RoleRightJoinSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<RoleRightJoin>();
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

        public List<RoleRightJoin> SelectAll()
        {
            List<RoleRightJoin> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.RoleRightJoinSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<RoleRightJoin>();
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
        public DataSet SelectAllWithDataSet(RoleRightJoin dtoObject)
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
                        obj = StoredProcedure(MasterConstant.RoleRightJoinSelectAll)
                                                .AddParameter("@RoleRightJoinID", dtoObject.RoleRightJoinID)
.AddParameter("@RoleID", dtoObject.RoleID)
.AddParameter("@RightID", dtoObject.RightID)
.AddParameter("@IsView", dtoObject.IsView)
.AddParameter("@IsCreate", dtoObject.IsCreate)
.AddParameter("@IsUpdate", dtoObject.IsUpdate)
.AddParameter("@IsDelete", dtoObject.IsDelete)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.RoleRightJoinSelectAll)
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

                    obj = StoredProcedure(MasterConstant.RoleRightJoinSelectAll)
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
		public bool Insert(RoleRightJoin dtoObject)
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

                    StoredProcedure(MasterConstant.RoleRightJoinInsert)
                        .AddParameter("@RoleRightJoinID", dtoObject.RoleRightJoinID)
.AddParameter("@RoleID", dtoObject.RoleID)
.AddParameter("@RightID", dtoObject.RightID)
.AddParameter("@IsView", dtoObject.IsView)
.AddParameter("@IsCreate", dtoObject.IsCreate)
.AddParameter("@IsUpdate", dtoObject.IsUpdate)
.AddParameter("@IsDelete", dtoObject.IsDelete)

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
        public bool Update(RoleRightJoin dtoObject)
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

                    StoredProcedure(MasterConstant.RoleRightJoinUpdate)
                        .AddParameter("@RoleRightJoinID", dtoObject.RoleRightJoinID)
.AddParameter("@RoleID", dtoObject.RoleID)
.AddParameter("@RightID", dtoObject.RightID)
.AddParameter("@IsView", dtoObject.IsView)
.AddParameter("@IsCreate", dtoObject.IsCreate)
.AddParameter("@IsUpdate", dtoObject.IsUpdate)
.AddParameter("@IsDelete", dtoObject.IsDelete)

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
                StoredProcedure(MasterConstant.RoleRightJoinDeleteByPrimaryKey)
                    .AddParameter("@RoleRightJoinID"
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
        public bool Delete(RoleRightJoin dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.RoleRightJoinDeleteByPrimaryKey)
                    .AddParameter("@RoleRightJoinID", dtoObject.RoleRightJoinID)

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

        public RoleRightJoin SelectByPrimaryKey(Guid Keys)
        {
            RoleRightJoin obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RoleRightJoinSelectByPrimaryKey)
                            .AddParameter("@RoleRightJoinID"
,Keys)
                            .Fetch<RoleRightJoin>();
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
        public List<RoleRightJoin> SelectByField(string fieldName, object value)
        {
            List<RoleRightJoin> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RoleRightJoinSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<RoleRightJoin>();

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
                obj = StoredProcedure(MasterConstant.RoleRightJoinSelectByField) 
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
                StoredProcedure(MasterConstant.RoleRightJoinDeleteByField) 
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

        public bool DeleteByRoleID(Guid? Keys)
        {
            try
            {
                StoredProcedure(MasterConstant.RoleRightJoinDeleteByRoleID)
                    .AddParameter("@RoleID"
, Keys)
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
