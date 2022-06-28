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
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SQT.FRAMEWORK.LOGGER;

namespace SQT.Symphony.BusinessLogic.Configuration.DAL
{
    /// <summary>
    /// Data access layer class for Recovery
    /// </summary>
    public class RecoveryDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public RecoveryDAL()
            : base()
        {
            // Nothing for now.
        }
        public RecoveryDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Recovery> SelectAll(Recovery dtoObject)
        {
            List<Recovery> obj = null;
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
                    obj = StoredProcedure(MasterConstant.RecoverySelectAll)
                                            .AddParameter("@RecoveryID", dtoObject.RecoveryID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@Amount", dtoObject.Amount)
.AddParameter("@CategoryID",dtoObject.CategoryID)
.AddParameter("@AcctID",dtoObject.AcctID )
                                            .WithTransaction(dbtr)
                                            .FetchAll<Recovery>();
                }
                else
                {
                    obj = StoredProcedure(MasterConstant.RecoverySelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Recovery>();
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

        public List<Recovery> SelectAll()
        {
            List<Recovery> obj = null;
            try
            {
                //using (new Tracer((SQTLogType.DataAccessTraceLog)))
                //{
                //Log Method Parameteres.
                ArrayList parameterList = new ArrayList();

                //SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                obj = StoredProcedure(MasterConstant.RecoverySelectAll)
                                        .WithTransaction(dbtr)
                                        .FetchAll<Recovery>();
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
        public bool Insert(Recovery dtoObject)
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

                StoredProcedure(MasterConstant.RecoveryInsert)
                    .AddParameter("@RecoveryID", dtoObject.RecoveryID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@Amount", dtoObject.Amount)
.AddParameter("@CategoryID", dtoObject.CategoryID)
.AddParameter("@AcctID",dtoObject.AcctID )
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
        public bool Update(Recovery dtoObject)
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

                StoredProcedure(MasterConstant.RecoveryUpdate)
                    .AddParameter("@RecoveryID", dtoObject.RecoveryID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@Amount", dtoObject.Amount)
.AddParameter("@CategoryID", dtoObject.CategoryID)
.AddParameter("@AcctID",dtoObject.AcctID )
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
                StoredProcedure(MasterConstant.RecoveryDeleteByPrimaryKey)
                    .AddParameter("@RecoveryID"
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
        public bool Delete(Recovery dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.RecoveryDeleteByPrimaryKey)
                    .AddParameter("@RecoveryID", dtoObject.RecoveryID)

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

        public Recovery SelectByPrimaryKey(Guid Keys)
        {
            Recovery obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RecoverySelectByPrimaryKey)
                            .AddParameter("@RecoveryID"
, Keys)
                            .Fetch<Recovery>();
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

        public List<Recovery> SelectByField(string fieldName, object value)
        {
            List<Recovery> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RecoverySelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Recovery>();

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

        public bool DeleteByField(string fieldName, object value)
        {
            try
            {
                StoredProcedure(MasterConstant.RecoveryDeleteByField)
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



        public List<Recovery> SearchRecoveryData(Guid? PropertyID, string Title)
        {
            List<Recovery> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    //if (dtoObject != null)
                    //    parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.RecoverySearchData)
                                            .AddParameter("@Title", Title)
                                            .AddParameter("@PropertyID", PropertyID)

                                            .WithTransaction(dbtr)
                                            .FetchAll<Recovery>();

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

        #endregion
    }
}
