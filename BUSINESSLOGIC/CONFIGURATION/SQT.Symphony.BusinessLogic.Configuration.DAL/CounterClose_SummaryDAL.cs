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
	/// Data access layer class for CounterClose_Summary
	/// </summary>
	public class CounterClose_SummaryDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public CounterClose_SummaryDAL() :  base()
		{
			// Nothing for now.
		}
        public CounterClose_SummaryDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<CounterClose_Summary> SelectAll(CounterClose_Summary dtoObject)
        {
            List<CounterClose_Summary> obj = null;
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
                        obj = StoredProcedure(MasterConstant.CounterClose_SummarySelectAll)
                                                .AddParameter("@ID", dtoObject.ID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@CloseID", dtoObject.CloseID)
.AddParameter("@Code", dtoObject.Code)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@NewTransID", dtoObject.NewTransID)
.AddParameter("@OldTransID", dtoObject.OldTransID)
.AddParameter("@PayType", dtoObject.PayType)
.AddParameter("@System_Amount", dtoObject.System_Amount)
.AddParameter("@AdjustedAmount", dtoObject.AdjustedAmount)
.AddParameter("@Net_Amount", dtoObject.Net_Amount)
.AddParameter("@IsReadOnly", dtoObject.IsReadOnly)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)

                                                .WithTransaction(dbtr)
                                                .FetchAll<CounterClose_Summary>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.CounterClose_SummarySelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<CounterClose_Summary>();
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

        public List<CounterClose_Summary> SelectAll()
        {
            List<CounterClose_Summary> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.CounterClose_SummarySelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<CounterClose_Summary>();
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
        public DataSet SelectAllWithDataSet(CounterClose_Summary dtoObject)
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
                        obj = StoredProcedure(MasterConstant.CounterClose_SummarySelectAll)
                                                .AddParameter("@ID", dtoObject.ID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@CloseID", dtoObject.CloseID)
.AddParameter("@Code", dtoObject.Code)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@NewTransID", dtoObject.NewTransID)
.AddParameter("@OldTransID", dtoObject.OldTransID)
.AddParameter("@PayType", dtoObject.PayType)
.AddParameter("@System_Amount", dtoObject.System_Amount)
.AddParameter("@AdjustedAmount", dtoObject.AdjustedAmount)
.AddParameter("@Net_Amount", dtoObject.Net_Amount)
.AddParameter("@IsReadOnly", dtoObject.IsReadOnly)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.CounterClose_SummarySelectAll)
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

                    obj = StoredProcedure(MasterConstant.CounterClose_SummarySelectAll)
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
		public bool Insert(CounterClose_Summary dtoObject)
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

                    StoredProcedure(MasterConstant.CounterClose_SummaryInsert)
                        .AddParameter("@ID", dtoObject.ID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@CloseID", dtoObject.CloseID)
.AddParameter("@Code", dtoObject.Code)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@NewTransID", dtoObject.NewTransID)
.AddParameter("@OldTransID", dtoObject.OldTransID)
.AddParameter("@PayType", dtoObject.PayType)
.AddParameter("@System_Amount", dtoObject.System_Amount)
.AddParameter("@AdjustedAmount", dtoObject.AdjustedAmount)
.AddParameter("@Net_Amount", dtoObject.Net_Amount)
.AddParameter("@IsReadOnly", dtoObject.IsReadOnly)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)

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
        public bool Update(CounterClose_Summary dtoObject)
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

                    StoredProcedure(MasterConstant.CounterClose_SummaryUpdate)
                        .AddParameter("@ID", dtoObject.ID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@CloseID", dtoObject.CloseID)
.AddParameter("@Code", dtoObject.Code)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@NewTransID", dtoObject.NewTransID)
.AddParameter("@OldTransID", dtoObject.OldTransID)
.AddParameter("@PayType", dtoObject.PayType)
.AddParameter("@System_Amount", dtoObject.System_Amount)
.AddParameter("@AdjustedAmount", dtoObject.AdjustedAmount)
.AddParameter("@Net_Amount", dtoObject.Net_Amount)
.AddParameter("@IsReadOnly", dtoObject.IsReadOnly)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)

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
                StoredProcedure(MasterConstant.CounterClose_SummaryDeleteByPrimaryKey)
                    .AddParameter("@ID"
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
        public bool Delete(CounterClose_Summary dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.CounterClose_SummaryDeleteByPrimaryKey)
                    .AddParameter("@ID", dtoObject.ID)

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

        public CounterClose_Summary SelectByPrimaryKey(Guid Keys)
        {
            CounterClose_Summary obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CounterClose_SummarySelectByPrimaryKey)
                            .AddParameter("@ID"
,Keys)
                            .Fetch<CounterClose_Summary>();
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
        public List<CounterClose_Summary> SelectByField(string fieldName, object value)
        {
            List<CounterClose_Summary> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CounterClose_SummarySelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<CounterClose_Summary>();

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
                obj = StoredProcedure(MasterConstant.CounterClose_SummarySelectByField) 
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
                StoredProcedure(MasterConstant.CounterClose_SummaryDeleteByField) 
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
