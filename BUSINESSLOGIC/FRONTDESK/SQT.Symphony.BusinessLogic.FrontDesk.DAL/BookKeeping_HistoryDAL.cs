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
	/// Data access layer class for BookKeeping_History
	/// </summary>
	public class BookKeeping_HistoryDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public BookKeeping_HistoryDAL() :  base()
		{
			// Nothing for now.
		}
        public BookKeeping_HistoryDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<BookKeeping_History> SelectAll(BookKeeping_History dtoObject)
        {
            List<BookKeeping_History> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.BookKeeping_HistorySelectAll)
                                                .AddParameter("@BookHistoryID", dtoObject.BookHistoryID)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@OperationDate", dtoObject.OperationDate)
.AddParameter("@OperationCode_TermID", dtoObject.OperationCode_TermID)
.AddParameter("@NewBookID", dtoObject.NewBookID)
.AddParameter("@HistoryRemark", dtoObject.HistoryRemark)
.AddParameter("@BKPRecord", dtoObject.BKPRecord)
.AddParameter("@BeforeAmt", dtoObject.BeforeAmt)
.AddParameter("@AfterAmt", dtoObject.AfterAmt)
.AddParameter("@EffectiveAmt", dtoObject.EffectiveAmt)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@AuditID", dtoObject.AuditID)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@OperationCode_Term", dtoObject.OperationCode_Term)

                                                .WithTransaction(dbtr)
                                                .FetchAll<BookKeeping_History>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.BookKeeping_HistorySelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<BookKeeping_History>();
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

        public List<BookKeeping_History> SelectAll()
        {
            List<BookKeeping_History> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.BookKeeping_HistorySelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<BookKeeping_History>();
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
        public DataSet SelectAllWithDataSet(BookKeeping_History dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.BookKeeping_HistorySelectAll)
                                                .AddParameter("@BookHistoryID", dtoObject.BookHistoryID)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@OperationDate", dtoObject.OperationDate)
.AddParameter("@OperationCode_TermID", dtoObject.OperationCode_TermID)
.AddParameter("@NewBookID", dtoObject.NewBookID)
.AddParameter("@HistoryRemark", dtoObject.HistoryRemark)
.AddParameter("@BKPRecord", dtoObject.BKPRecord)
.AddParameter("@BeforeAmt", dtoObject.BeforeAmt)
.AddParameter("@AfterAmt", dtoObject.AfterAmt)
.AddParameter("@EffectiveAmt", dtoObject.EffectiveAmt)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@AuditID", dtoObject.AuditID)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@OperationCode_Term", dtoObject.OperationCode_Term)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.BookKeeping_HistorySelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.BookKeeping_HistorySelectAll)
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
		public bool Insert(BookKeeping_History dtoObject)
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

                    StoredProcedure(MasterDALConstant.BookKeeping_HistoryInsert)
                        .AddParameter("@BookHistoryID", dtoObject.BookHistoryID)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@OperationDate", dtoObject.OperationDate)
.AddParameter("@OperationCode_TermID", dtoObject.OperationCode_TermID)
.AddParameter("@NewBookID", dtoObject.NewBookID)
.AddParameter("@HistoryRemark", dtoObject.HistoryRemark)
.AddParameter("@BKPRecord", dtoObject.BKPRecord)
.AddParameter("@BeforeAmt", dtoObject.BeforeAmt)
.AddParameter("@AfterAmt", dtoObject.AfterAmt)
.AddParameter("@EffectiveAmt", dtoObject.EffectiveAmt)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@AuditID", dtoObject.AuditID)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@OperationCode_Term", dtoObject.OperationCode_Term)

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
        public bool Update(BookKeeping_History dtoObject)
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

                    StoredProcedure(MasterDALConstant.BookKeeping_HistoryUpdate)
                        .AddParameter("@BookHistoryID", dtoObject.BookHistoryID)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@OperationDate", dtoObject.OperationDate)
.AddParameter("@OperationCode_TermID", dtoObject.OperationCode_TermID)
.AddParameter("@NewBookID", dtoObject.NewBookID)
.AddParameter("@HistoryRemark", dtoObject.HistoryRemark)
.AddParameter("@BKPRecord", dtoObject.BKPRecord)
.AddParameter("@BeforeAmt", dtoObject.BeforeAmt)
.AddParameter("@AfterAmt", dtoObject.AfterAmt)
.AddParameter("@EffectiveAmt", dtoObject.EffectiveAmt)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@AuditID", dtoObject.AuditID)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@OperationCode_Term", dtoObject.OperationCode_Term)

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
                StoredProcedure(MasterDALConstant.BookKeeping_HistoryDeleteByPrimaryKey)
                    .AddParameter("@BookHistoryID"
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
        public bool Delete(BookKeeping_History dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.BookKeeping_HistoryDeleteByPrimaryKey)
                    .AddParameter("@BookHistoryID", dtoObject.BookHistoryID)

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

        public BookKeeping_History SelectByPrimaryKey(Guid Keys)
        {
            BookKeeping_History obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.BookKeeping_HistorySelectByPrimaryKey)
                            .AddParameter("@BookHistoryID"
,Keys)
                            .Fetch<BookKeeping_History>();
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
        public List<BookKeeping_History> SelectByField(string fieldName, object value)
        {
            List<BookKeeping_History> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.BookKeeping_HistorySelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<BookKeeping_History>();

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
                obj = StoredProcedure(MasterDALConstant.BookKeeping_HistorySelectByField) 
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
                StoredProcedure(MasterDALConstant.BookKeeping_HistoryDeleteByField) 
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
