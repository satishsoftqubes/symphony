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

namespace SQT.Symphony.BusinessLogic.Configuration.DAL
{
	/// <summary>
	/// Data access layer class for CancellationPolicyMaster
	/// </summary>
	public class CancellationPolicyMasterDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public CancellationPolicyMasterDAL() :  base()
		{
			// Nothing for now.
		}
        public CancellationPolicyMasterDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<CancellationPolicyMaster> SelectAll(CancellationPolicyMaster dtoObject)
        {
            List<CancellationPolicyMaster> obj = null;
            try
            {
                //using (new Tracer((SQTLogType.DataAccessTraceLog)))
                //{
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    if(dtoObject != null)
                        parameterList.Add(dtoObject);
                    //SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                    if(dtoObject != null)  
                    {
                        obj = StoredProcedure(MasterConstant.CancellationPolicyMasterSelectAll)
                                                .AddParameter("@ResPolicyID", dtoObject.ResPolicyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@PolicyTitle", dtoObject.PolicyTitle)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@ResType_TermID", dtoObject.ResType_TermID)
.AddParameter("@PolicyNote", dtoObject.PolicyNote)

                                                .WithTransaction(dbtr)
                                                .FetchAll<CancellationPolicyMaster>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.CancellationPolicyMasterSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<CancellationPolicyMaster>();
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

        public List<CancellationPolicyMaster> SelectAll()
        {
            List<CancellationPolicyMaster> obj = null;
            try
            {
                //using (new Tracer((SQTLogType.DataAccessTraceLog)))
                //{
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    //SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.CancellationPolicyMasterSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<CancellationPolicyMaster>();
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
		public bool Insert(CancellationPolicyMaster dtoObject)
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

                    StoredProcedure(MasterConstant.CancellationPolicyMasterInsert)
                        .AddParameter("@ResPolicyID", dtoObject.ResPolicyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@PolicyTitle", dtoObject.PolicyTitle)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@ResType_TermID", dtoObject.ResType_TermID)
.AddParameter("@PolicyNote", dtoObject.PolicyNote)
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
        public bool Update(CancellationPolicyMaster dtoObject)
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

                    StoredProcedure(MasterConstant.CancellationPolicyMasterUpdate)
                        .AddParameter("@ResPolicyID", dtoObject.ResPolicyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@PolicyTitle", dtoObject.PolicyTitle)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@ResType_TermID", dtoObject.ResType_TermID)
.AddParameter("@PolicyNote", dtoObject.PolicyNote)
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
                StoredProcedure(MasterConstant.CancellationPolicyMasterDeleteByPrimaryKey)
                    .AddParameter("@ResPolicyID"
,Keys)
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
        public bool Delete(CancellationPolicyMaster dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.CancellationPolicyMasterDeleteByPrimaryKey)
                    .AddParameter("@ResPolicyID", dtoObject.ResPolicyID)

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

        public CancellationPolicyMaster SelectByPrimaryKey(Guid Keys)
        {
            CancellationPolicyMaster obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CancellationPolicyMasterSelectByPrimaryKey)
                            .AddParameter("@ResPolicyID"
,Keys)
                            .Fetch<CancellationPolicyMaster>();
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

        public List<CancellationPolicyMaster> SelectByField(string fieldName, object value)
        {
            List<CancellationPolicyMaster> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CancellationPolicyMasterSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<CancellationPolicyMaster>();

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
                StoredProcedure(MasterConstant.CancellationPolicyMasterDeleteByField) 
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

        #endregion
	}
}
