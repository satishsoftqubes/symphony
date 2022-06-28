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
	/// Data access layer class for Counter_Close_Detail
	/// </summary>
	public class Counter_Close_DetailDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public Counter_Close_DetailDAL() :  base()
		{
			// Nothing for now.
		}
        public Counter_Close_DetailDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Counter_Close_Detail> SelectAll(Counter_Close_Detail dtoObject)
        {
            List<Counter_Close_Detail> obj = null;
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
                        obj = StoredProcedure(MasterConstant.Counter_Close_DetailSelectAll)
                                                .AddParameter("@CloseDetailID", dtoObject.CloseDetailID)
.AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CloseID", dtoObject.CloseID)
.AddParameter("@CurrencyCode", dtoObject.CurrencyCode)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@Field_Name", dtoObject.Field_Name)
.AddParameter("@TotalCount", dtoObject.TotalCount)
.AddParameter("@TotalAmount", dtoObject.TotalAmount)
.AddParameter("@OriginalAmount", dtoObject.OriginalAmount)
.AddParameter("@LastUpdateOn", dtoObject.LastUpdateOn)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Counter_Close_Detail>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.Counter_Close_DetailSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Counter_Close_Detail>();
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

        public List<Counter_Close_Detail> SelectAll()
        {
            List<Counter_Close_Detail> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.Counter_Close_DetailSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Counter_Close_Detail>();
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
        public DataSet SelectAllWithDataSet(Counter_Close_Detail dtoObject)
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
                        obj = StoredProcedure(MasterConstant.Counter_Close_DetailSelectAll)
                                                .AddParameter("@CloseDetailID", dtoObject.CloseDetailID)
.AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CloseID", dtoObject.CloseID)
.AddParameter("@CurrencyCode", dtoObject.CurrencyCode)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@Field_Name", dtoObject.Field_Name)
.AddParameter("@TotalCount", dtoObject.TotalCount)
.AddParameter("@TotalAmount", dtoObject.TotalAmount)
.AddParameter("@OriginalAmount", dtoObject.OriginalAmount)
.AddParameter("@LastUpdateOn", dtoObject.LastUpdateOn)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.Counter_Close_DetailSelectAll)
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

        public DataSet SelectCouterClose_Denomination (Guid? PropertyID, Guid? CloseID)
        {
            DataSet obj = null;
            try
            {
               
                    //Log Method Parameteres.                 
                        obj = StoredProcedure(MasterConstant.Counter_Close_DetailDenomination)
                                                .AddParameter("@PropertyID",PropertyID)
                                .AddParameter("@CloseID", CloseID)

                                                .WithTransaction(dbtr)
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

        public DataSet SelectCouterClose_GeneralInformation(Guid? CloseID)
        {
            DataSet obj = null;
            try
            {

                //Log Method Parameteres.                 
                obj = StoredProcedure(MasterConstant.Counter_Close_GeneralInformation)                                      
                        .AddParameter("@CloseID", CloseID)

                                        .WithTransaction(dbtr)
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

                    obj = StoredProcedure(MasterConstant.Counter_Close_DetailSelectAll)
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
		public bool Insert(Counter_Close_Detail dtoObject)
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

                    StoredProcedure(MasterConstant.Counter_Close_DetailInsert)
                        .AddParameter("@CloseDetailID", dtoObject.CloseDetailID)
.AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CloseID", dtoObject.CloseID)
.AddParameter("@CurrencyCode", dtoObject.CurrencyCode)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@Field_Name", dtoObject.Field_Name)
.AddParameter("@TotalCount", dtoObject.TotalCount)
.AddParameter("@TotalAmount", dtoObject.TotalAmount)
.AddParameter("@OriginalAmount", dtoObject.OriginalAmount)

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
        public bool Update(Counter_Close_Detail dtoObject)
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

                    StoredProcedure(MasterConstant.Counter_Close_DetailUpdate)
                        .AddParameter("@CloseDetailID", dtoObject.CloseDetailID)
.AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CloseID", dtoObject.CloseID)
.AddParameter("@CurrencyCode", dtoObject.CurrencyCode)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@Field_Name", dtoObject.Field_Name)
.AddParameter("@TotalCount", dtoObject.TotalCount)
.AddParameter("@TotalAmount", dtoObject.TotalAmount)
.AddParameter("@OriginalAmount", dtoObject.OriginalAmount)
.AddParameter("@LastUpdateOn", dtoObject.LastUpdateOn)

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
                StoredProcedure(MasterConstant.Counter_Close_DetailDeleteByPrimaryKey)
                    .AddParameter("@CloseDetailID"
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
        public bool Delete(Counter_Close_Detail dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.Counter_Close_DetailDeleteByPrimaryKey)
                    .AddParameter("@CloseDetailID", dtoObject.CloseDetailID)

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

        public Counter_Close_Detail SelectByPrimaryKey(Guid Keys)
        {
            Counter_Close_Detail obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.Counter_Close_DetailSelectByPrimaryKey)
                            .AddParameter("@CloseDetailID"
,Keys)
                            .Fetch<Counter_Close_Detail>();
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
        public List<Counter_Close_Detail> SelectByField(string fieldName, object value)
        {
            List<Counter_Close_Detail> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.Counter_Close_DetailSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Counter_Close_Detail>();

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
                obj = StoredProcedure(MasterConstant.Counter_Close_DetailSelectByField) 
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
                StoredProcedure(MasterConstant.Counter_Close_DetailDeleteByField) 
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
