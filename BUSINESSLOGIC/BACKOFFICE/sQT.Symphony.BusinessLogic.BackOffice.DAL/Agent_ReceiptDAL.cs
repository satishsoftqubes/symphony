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
using SQT.Symphony.BusinessLogic.BackOffice.DTO;
using SQT.Symphony.BusinessLogic.BackOffice.COMMON;

namespace SQT.Symphony.BusinessLogic.BackOffice.DAL
{
	/// <summary>
	/// Data access layer class for Agent_Receipt
	/// </summary>
	public class Agent_ReceiptDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public Agent_ReceiptDAL() :  base()
		{
			// Nothing for now.
		}
        public Agent_ReceiptDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Agent_Receipt> SelectAll(Agent_Receipt dtoObject)
        {
            List<Agent_Receipt> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.Agent_ReceiptSelectAll)
                                                .AddParameter("@ReceiptID", dtoObject.ReceiptID)
.AddParameter("@ReceiptNo", dtoObject.ReceiptNo)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@AgentID", dtoObject.AgentID)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@ReceiptDate", dtoObject.ReceiptDate)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@Amt", dtoObject.Amt)
.AddParameter("@PayType", dtoObject.PayType)
.AddParameter("@IsAllocated", dtoObject.IsAllocated)
.AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@PropertyID", dtoObject.PropertyID)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Agent_Receipt>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.Agent_ReceiptSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Agent_Receipt>();
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

        public List<Agent_Receipt> SelectAll()
        {
            List<Agent_Receipt> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.Agent_ReceiptSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Agent_Receipt>();
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
        public DataSet SelectAllWithDataSet(Agent_Receipt dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.Agent_ReceiptSelectAll)
                                                .AddParameter("@ReceiptID", dtoObject.ReceiptID)
.AddParameter("@ReceiptNo", dtoObject.ReceiptNo)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@AgentID", dtoObject.AgentID)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@ReceiptDate", dtoObject.ReceiptDate)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@Amt", dtoObject.Amt)
.AddParameter("@PayType", dtoObject.PayType)
.AddParameter("@IsAllocated", dtoObject.IsAllocated)
.AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@PropertyID", dtoObject.PropertyID)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.Agent_ReceiptSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.Agent_ReceiptSelectAll)
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
		public bool Insert(Agent_Receipt dtoObject)
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

                    StoredProcedure(MasterDALConstant.Agent_ReceiptInsert)
                        .AddParameter("@ReceiptID", dtoObject.ReceiptID)
.AddParameter("@ReceiptNo", dtoObject.ReceiptNo)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@AgentID", dtoObject.AgentID)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@ReceiptDate", dtoObject.ReceiptDate)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@Amt", dtoObject.Amt)
.AddParameter("@PayType", dtoObject.PayType)
.AddParameter("@IsAllocated", dtoObject.IsAllocated)
.AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)

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
        public bool Update(Agent_Receipt dtoObject)
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

                    StoredProcedure(MasterDALConstant.Agent_ReceiptUpdate)
                        .AddParameter("@ReceiptID", dtoObject.ReceiptID)
.AddParameter("@ReceiptNo", dtoObject.ReceiptNo)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@AgentID", dtoObject.AgentID)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@ReceiptDate", dtoObject.ReceiptDate)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@Amt", dtoObject.Amt)
.AddParameter("@PayType", dtoObject.PayType)
.AddParameter("@IsAllocated", dtoObject.IsAllocated)
.AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@PropertyID", dtoObject.PropertyID)

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
                StoredProcedure(MasterDALConstant.Agent_ReceiptDeleteByPrimaryKey)
                    .AddParameter("@ReceiptID"
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
        public bool Delete(Agent_Receipt dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.Agent_ReceiptDeleteByPrimaryKey)
                    .AddParameter("@ReceiptID", dtoObject.ReceiptID)

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

        public Agent_Receipt SelectByPrimaryKey(Guid Keys)
        {
            Agent_Receipt obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.Agent_ReceiptSelectByPrimaryKey)
                            .AddParameter("@ReceiptID"
,Keys)
                            .Fetch<Agent_Receipt>();
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
        public List<Agent_Receipt> SelectByField(string fieldName, object value)
        {
            List<Agent_Receipt> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.Agent_ReceiptSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Agent_Receipt>();

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
                obj = StoredProcedure(MasterDALConstant.Agent_ReceiptSelectByField) 
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
                StoredProcedure(MasterDALConstant.Agent_ReceiptDeleteByField) 
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
