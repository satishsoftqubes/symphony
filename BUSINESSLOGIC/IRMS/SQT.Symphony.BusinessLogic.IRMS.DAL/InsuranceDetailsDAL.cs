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
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using SQT.Symphony.BusinessLogic.IRMS.COMMON;
using System.Data;

namespace SQT.Symphony.BusinessLogic.IRMS.DAL
{
    /// <summary>
    /// Data access layer class for InsuranceDetails
    /// </summary>
    public class InsuranceDetailsDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public InsuranceDetailsDAL()
            : base()
        {
            // Nothing for now.
        }
        public InsuranceDetailsDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<InsuranceDetails> SelectAll(InsuranceDetails dtoObject)
        {
            List<InsuranceDetails> obj = null;
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
                    obj = StoredProcedure(MasterDALConstant.InsuranceDetailsSelectAll)
                                            .AddParameter("@InsuranceID", dtoObject.InsuranceID)
.AddParameter("@FromDate", dtoObject.FromDate)
.AddParameter("@ToDate", dtoObject.ToDate)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@PolicyNo", dtoObject.PolicyNo)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@Description", dtoObject.Description)

                                            .WithTransaction(dbtr)
                                            .FetchAll<InsuranceDetails>();
                }
                else
                {
                    obj = StoredProcedure(MasterDALConstant.InsuranceDetailsSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<InsuranceDetails>();
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

        public List<InsuranceDetails> SelectAll()
        {
            List<InsuranceDetails> obj = null;
            try
            {
                //using (new Tracer((SQTLogType.DataAccessTraceLog)))
                //{
                //Log Method Parameteres.
                ArrayList parameterList = new ArrayList();

                //SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                obj = StoredProcedure(MasterDALConstant.InsuranceDetailsSelectAll)
                                        .WithTransaction(dbtr)
                                        .FetchAll<InsuranceDetails>();
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
        public bool Insert(InsuranceDetails dtoObject)
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

                StoredProcedure(MasterDALConstant.InsuranceDetailsInsert)
                    .AddParameter("@InsuranceID", dtoObject.InsuranceID)
.AddParameter("@FromDate", dtoObject.FromDate)
.AddParameter("@ToDate", dtoObject.ToDate)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@PolicyNo", dtoObject.PolicyNo)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@Description", dtoObject.Description)

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
        public bool Update(InsuranceDetails dtoObject)
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

                StoredProcedure(MasterDALConstant.InsuranceDetailsUpdate)
                    .AddParameter("@InsuranceID", dtoObject.InsuranceID)
.AddParameter("@FromDate", dtoObject.FromDate)
.AddParameter("@ToDate", dtoObject.ToDate)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@PolicyNo", dtoObject.PolicyNo)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@Description", dtoObject.Description)

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
                StoredProcedure(MasterDALConstant.InsuranceDetailsDeleteByPrimaryKey)
                    .AddParameter("@InsuranceID"
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
        public bool Delete(InsuranceDetails dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.InsuranceDetailsDeleteByPrimaryKey)
                    .AddParameter("@InsuranceID", dtoObject.InsuranceID)

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

        public InsuranceDetails SelectByPrimaryKey(Guid Keys)
        {
            InsuranceDetails obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.InsuranceDetailsSelectByPrimaryKey)
                            .AddParameter("@InsuranceID"
, Keys)
                            .Fetch<InsuranceDetails>();
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

        public List<InsuranceDetails> SelectByField(string fieldName, object value)
        {
            List<InsuranceDetails> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.InsuranceDetailsSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<InsuranceDetails>();

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
                StoredProcedure(MasterDALConstant.InsuranceDetailsDeleteByField)
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
        public DataSet SelectinsuranceDetailsData(Guid? InsuranceID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.InsuranceDetailGetData)
                     .AddParameter("@InsuranceID", InsuranceID)
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
