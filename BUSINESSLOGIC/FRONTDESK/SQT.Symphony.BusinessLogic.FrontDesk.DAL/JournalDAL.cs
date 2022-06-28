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
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.COMMON;

namespace SQT.Symphony.BusinessLogic.FrontDesk.DAL
{
	/// <summary>
	/// Data access layer class for Journal
	/// </summary>
	public class JournalDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public JournalDAL() :  base()
		{
			// Nothing for now.
		}
        public JournalDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Journal> SelectAll(Journal dtoObject)
        {
            List<Journal> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.JournalSelectAll)
                                                .AddParameter("@JournalID", dtoObject.JournalID)
.AddParameter("@RefJournalID", dtoObject.RefJournalID)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@Amt", dtoObject.Amt)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@TransType", dtoObject.TransType)
.AddParameter("@IsReverse", dtoObject.IsReverse)
.AddParameter("@MEMO", dtoObject.MEMO)
.AddParameter("@Job_ID", dtoObject.Job_ID)
.AddParameter("@IDType", dtoObject.IDType)
.AddParameter("@Updatelog", dtoObject.Updatelog)
.AddParameter("@Tax", dtoObject.Tax)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@OrderSeqNo", dtoObject.OrderSeqNo)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Journal>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.JournalSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Journal>();
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

        public List<Journal> SelectAll()
        {
            List<Journal> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.JournalSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Journal>();
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
        public DataSet SelectAllWithDataSet(Journal dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.JournalSelectAll)
                                                .AddParameter("@JournalID", dtoObject.JournalID)
.AddParameter("@RefJournalID", dtoObject.RefJournalID)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@Amt", dtoObject.Amt)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@TransType", dtoObject.TransType)
.AddParameter("@IsReverse", dtoObject.IsReverse)
.AddParameter("@MEMO", dtoObject.MEMO)
.AddParameter("@Job_ID", dtoObject.Job_ID)
.AddParameter("@IDType", dtoObject.IDType)
.AddParameter("@Updatelog", dtoObject.Updatelog)
.AddParameter("@Tax", dtoObject.Tax)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@OrderSeqNo", dtoObject.OrderSeqNo)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.JournalSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.JournalSelectAll)
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
		public bool Insert(Journal dtoObject)
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

                    StoredProcedure(MasterDALConstant.JournalInsert)
                        .AddParameter("@JournalID", dtoObject.JournalID)
.AddParameter("@RefJournalID", dtoObject.RefJournalID)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@Amt", dtoObject.Amt)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@TransType", dtoObject.TransType)
.AddParameter("@IsReverse", dtoObject.IsReverse)
.AddParameter("@MEMO", dtoObject.MEMO)
.AddParameter("@Job_ID", dtoObject.Job_ID)
.AddParameter("@IDType", dtoObject.IDType)
.AddParameter("@Tax", dtoObject.Tax)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@OrderSeqNo", dtoObject.OrderSeqNo)

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
        public bool Update(Journal dtoObject)
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

                    StoredProcedure(MasterDALConstant.JournalUpdate)
                        .AddParameter("@JournalID", dtoObject.JournalID)
.AddParameter("@RefJournalID", dtoObject.RefJournalID)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@Amt", dtoObject.Amt)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@TransType", dtoObject.TransType)
.AddParameter("@IsReverse", dtoObject.IsReverse)
.AddParameter("@MEMO", dtoObject.MEMO)
.AddParameter("@Job_ID", dtoObject.Job_ID)
.AddParameter("@IDType", dtoObject.IDType)
.AddParameter("@Updatelog", dtoObject.Updatelog)
.AddParameter("@Tax", dtoObject.Tax)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@OrderSeqNo", dtoObject.OrderSeqNo)

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
                StoredProcedure(MasterDALConstant.JournalDeleteByPrimaryKey)
                    .AddParameter("@JournalID"
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
        public bool Delete(Journal dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.JournalDeleteByPrimaryKey)
                    .AddParameter("@JournalID", dtoObject.JournalID)

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

        public Journal SelectByPrimaryKey(Guid Keys)
        {
            Journal obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.JournalSelectByPrimaryKey)
                            .AddParameter("@JournalID"
,Keys)
                            .Fetch<Journal>();
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
        public List<Journal> SelectByField(string fieldName, object value)
        {
            List<Journal> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.JournalSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Journal>();

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
                obj = StoredProcedure(MasterDALConstant.JournalSelectByField) 
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
                StoredProcedure(MasterDALConstant.JournalDeleteByField) 
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
