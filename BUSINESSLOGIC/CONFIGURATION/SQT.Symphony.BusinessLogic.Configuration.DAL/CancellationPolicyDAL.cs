using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using SQT.FRAMEWORK.DAL.Linq;
using SQT.FRAMEWORK.DAL.Linq.DAL;
using SQT.FRAMEWORK.DAL.Linq.Exceptions;
using SQT.FRAMEWORK.DAL.Linq.Results;
using SQT.FRAMEWORK.COMMON.Util;
//using SQT.FRAMEWORK.LOGGER;
using SQT.FRAMEWORK.EXCEPTION;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
//using Microsoft.Practices.EnterpriseLibrary.Logging;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.COMMON;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SQT.FRAMEWORK.LOGGER;

namespace SQT.Symphony.BusinessLogic.Configuration.DAL
{
    /// <summary>
    /// Data access layer class for CancellationPolicy
    /// </summary>
    public class CancellationPolicyDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public CancellationPolicyDAL()
            : base()
        {
            // Nothing for now.
        }
        public CancellationPolicyDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<CancellationPolicy> SelectAll(CancellationPolicy dtoObject)
        {
            List<CancellationPolicy> obj = null;
            try
            {
                //using (new Tracer((SQTLogType.DataAccessTraceLog)))
                //{
                //Log Method Parameteres.
                ArrayList parameterList = new ArrayList();
                if (dtoObject != null)
                    parameterList.Add(dtoObject);
                //SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                if (dtoObject != null)
                {
                    obj = StoredProcedure(MasterConstant.CancellationPolicySelectAll)
                                            .AddParameter("@PolicyID", dtoObject.PolicyID)
.AddParameter("@ResPolicyID", dtoObject.ResPolicyID)
.AddParameter("@CancellationCharges", dtoObject.CancellationCharges)
.AddParameter("@IsFlatCharge", dtoObject.IsFlatCharge)
.AddParameter("@MinDays", dtoObject.MinDays)
.AddParameter("@MaxDays", dtoObject.MaxDays)
.AddParameter("@SeqNo", dtoObject.SeqNo)

                                            .WithTransaction(dbtr)
                                            .FetchAll<CancellationPolicy>();
                }
                else
                {
                    obj = StoredProcedure(MasterConstant.CancellationPolicySelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<CancellationPolicy>();
                }
                //}
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                //bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                //if (rethrow)
                //{
                throw ex;
                //}
            }
            return obj;
        }

        public List<CancellationPolicy> SelectAll()
        {
            List<CancellationPolicy> obj = null;
            try
            {
                //using (new Tracer((SQTLogType.DataAccessTraceLog)))
                //{
                //Log Method Parameteres.
                ArrayList parameterList = new ArrayList();

                //SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                obj = StoredProcedure(MasterConstant.CancellationPolicySelectAll)
                                        .WithTransaction(dbtr)
                                        .FetchAll<CancellationPolicy>();
                //}
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                //bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                //if (rethrow)
                //{
                throw ex;
                //}
            }
            return obj;
        }
        /// <summary>
        /// insert new row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true of successfully insert</returns>
        public bool Insert(CancellationPolicy dtoObject)
        {
            try
            {
                //using (new Tracer((SQTLogType.DataAccessTraceLog)))
                //{
                if (dtoObject == null)
                    throw (new ParameterNullException("Object can not be null"));

                //Log Method Parameteres.
                ArrayList parameterList = new ArrayList();
                parameterList.Add(dtoObject);
                //SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                StoredProcedure(MasterConstant.CancellationPolicyInsert)
                    .AddParameter("@PolicyID", dtoObject.PolicyID)
.AddParameter("@ResPolicyID", dtoObject.ResPolicyID)
.AddParameter("@CancellationCharges", dtoObject.CancellationCharges)
.AddParameter("@IsFlatCharge", dtoObject.IsFlatCharge)
.AddParameter("@MinDays", dtoObject.MinDays)
.AddParameter("@MaxDays", dtoObject.MaxDays)
.AddParameter("@SeqNo", dtoObject.SeqNo)

                    .WithTransaction(dbtr)
                    .Execute();
                //}
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                //bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                //if (rethrow)
                //{
                throw ex;
                //}
            }
            return true;
        }

        /// <summary>
        /// update row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true for successfully updated</returns>
        public bool Update(CancellationPolicy dtoObject)
        {
            try
            {
                //using (new Tracer((SQTLogType.DataAccessTraceLog)))
                //{
                if (dtoObject == null)
                    throw (new ParameterNullException("Object can not be null"));

                //Log Method Parameteres.
                ArrayList parameterList = new ArrayList();
                parameterList.Add(dtoObject);
                //SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                StoredProcedure(MasterConstant.CancellationPolicyUpdate)
                    .AddParameter("@PolicyID", dtoObject.PolicyID)
.AddParameter("@ResPolicyID", dtoObject.ResPolicyID)
.AddParameter("@CancellationCharges", dtoObject.CancellationCharges)
.AddParameter("@IsFlatCharge", dtoObject.IsFlatCharge)
.AddParameter("@MinDays", dtoObject.MinDays)
.AddParameter("@MaxDays", dtoObject.MaxDays)
.AddParameter("@SeqNo", dtoObject.SeqNo)

                    .WithTransaction(dbtr)
                    .Execute();
                //}
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                //bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                //if (rethrow)
                //{
                throw ex;
                //}
            }
            return true;
        }
        public bool Delete(Guid Keys)
        {
            try
            {
                StoredProcedure(MasterConstant.CancellationPolicyDeleteByPrimaryKey)
                    .AddParameter("@PolicyID"
, Keys)
                    .WithTransaction(dbtr)
                    .Execute();
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                //bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                //if (rethrow)
                //{
                throw ex;
                //}
            }
            return true;
        }
        public bool Delete(CancellationPolicy dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.CancellationPolicyDeleteByPrimaryKey)
                    .AddParameter("@PolicyID", dtoObject.PolicyID)

                    .WithTransaction(dbtr)
                    .Execute();
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                //bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                //if (rethrow)
                //{
                throw ex;
                //}
            }
            return true;
        }

        public CancellationPolicy SelectByPrimaryKey(Guid Keys)
        {
            CancellationPolicy obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CancellationPolicySelectByPrimaryKey)
                            .AddParameter("@PolicyID"
, Keys)
                            .Fetch<CancellationPolicy>();
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                //bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                //if (rethrow)
                //{
                throw ex;
                //}
            }
            return obj;
        }

        public List<CancellationPolicy> SelectByField(string fieldName, object value)
        {
            List<CancellationPolicy> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CancellationPolicySelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<CancellationPolicy>();

            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                //bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                //if (rethrow)
                //{
                throw ex;
                //}
            }
            return obj;
        }

        public DataSet SelectByFieldWithDataSet(string fieldName, object value)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CancellationPolicySortBySeqNoSelectByField)
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
                StoredProcedure(MasterConstant.CancellationPolicyDeleteByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .WithTransaction(dbtr)
                                    .Execute();
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                //bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                //if (rethrow)
                //{
                throw ex;
                //}
            }
            return true;
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

                    obj = StoredProcedure(MasterConstant.CancellationPolicySelectAll)
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


        public bool DeleteByResPolicyID(Guid Keys)
        {
            try
            {
                StoredProcedure(MasterConstant.CancellationPolicyDeleteByPolicyID)
                    .AddParameter("@ResPolicyID"
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
        #endregion
    }
}
