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
	/// Data access layer class for ControlNumber
	/// </summary>
	public class ControlNumberDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public ControlNumberDAL() :  base()
		{
			// Nothing for now.
		}
        public ControlNumberDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<ControlNumber> SelectAll(ControlNumber dtoObject)
        {
            List<ControlNumber> obj = null;
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
                        obj = StoredProcedure(MasterConstant.ControlNumberSelectAll)
                                                .AddParameter("@ControlNumberID", dtoObject.ControlNumberID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IdentifyName", dtoObject.IdentifyName)
.AddParameter("@Postfix", dtoObject.Postfix)
.AddParameter("@ControlNumbers", dtoObject.ControlNumbers)
.AddParameter("@Prefix", dtoObject.Prefix)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@CompanyID", dtoObject.CompanyID)

                                                .WithTransaction(dbtr)
                                                .FetchAll<ControlNumber>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.ControlNumberSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<ControlNumber>();
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

        public List<ControlNumber> SelectAll()
        {
            List<ControlNumber> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.ControlNumberSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<ControlNumber>();
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
        public DataSet SelectAllWithDataSet(ControlNumber dtoObject)
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
                        obj = StoredProcedure(MasterConstant.ControlNumberSelectAll)
                                                .AddParameter("@ControlNumberID", dtoObject.ControlNumberID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IdentifyName", dtoObject.IdentifyName)
.AddParameter("@Postfix", dtoObject.Postfix)
.AddParameter("@ControlNumbers", dtoObject.ControlNumbers)
.AddParameter("@Prefix", dtoObject.Prefix)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@CompanyID", dtoObject.CompanyID)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.ControlNumberSelectAll)
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

                    obj = StoredProcedure(MasterConstant.ControlNumberSelectAll)
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
		public bool Insert(ControlNumber dtoObject)
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

                    StoredProcedure(MasterConstant.ControlNumberInsert)
                        .AddParameter("@ControlNumberID", dtoObject.ControlNumberID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IdentifyName", dtoObject.IdentifyName)
.AddParameter("@Postfix", dtoObject.Postfix)
.AddParameter("@ControlNumbers", dtoObject.ControlNumbers)
.AddParameter("@Prefix", dtoObject.Prefix)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CompanyID", dtoObject.CompanyID)

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
        public bool Update(ControlNumber dtoObject)
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

                    StoredProcedure(MasterConstant.ControlNumberUpdate)
                        .AddParameter("@ControlNumberID", dtoObject.ControlNumberID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IdentifyName", dtoObject.IdentifyName)
.AddParameter("@Postfix", dtoObject.Postfix)
.AddParameter("@ControlNumbers", dtoObject.ControlNumbers)
.AddParameter("@Prefix", dtoObject.Prefix)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@CompanyID", dtoObject.CompanyID)

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
                StoredProcedure(MasterConstant.ControlNumberDeleteByPrimaryKey)
                    .AddParameter("@ControlNumberID"
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
        public bool Delete(ControlNumber dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.ControlNumberDeleteByPrimaryKey)
                    .AddParameter("@ControlNumberID", dtoObject.ControlNumberID)

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

        public ControlNumber SelectByPrimaryKey(Guid Keys)
        {
            ControlNumber obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ControlNumberSelectByPrimaryKey)
                            .AddParameter("@ControlNumberID"
,Keys)
                            .Fetch<ControlNumber>();
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
        public List<ControlNumber> SelectByField(string fieldName, object value)
        {
            List<ControlNumber> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ControlNumberSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<ControlNumber>();

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
                obj = StoredProcedure(MasterConstant.ControlNumberSelectByField) 
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
                StoredProcedure(MasterConstant.ControlNumberDeleteByField) 
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
