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
	/// Data access layer class for Transfer_Deposit_Join
	/// </summary>
	public class Transfer_Deposit_JoinDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public Transfer_Deposit_JoinDAL() :  base()
		{
			// Nothing for now.
		}
        public Transfer_Deposit_JoinDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Transfer_Deposit_Join> SelectAll(Transfer_Deposit_Join dtoObject)
        {
            List<Transfer_Deposit_Join> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.Transfer_Deposit_JoinSelectAll)
                                                .AddParameter("@DepositTransferID", dtoObject.DepositTransferID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@DepositBookID", dtoObject.DepositBookID)
.AddParameter("@Amount", dtoObject.Amount)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@Narration", dtoObject.Narration)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Transfer_Deposit_Join>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.Transfer_Deposit_JoinSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Transfer_Deposit_Join>();
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

        public List<Transfer_Deposit_Join> SelectAll()
        {
            List<Transfer_Deposit_Join> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.Transfer_Deposit_JoinSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Transfer_Deposit_Join>();
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
        public DataSet SelectAllWithDataSet(Transfer_Deposit_Join dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.Transfer_Deposit_JoinSelectAll)
                                                .AddParameter("@DepositTransferID", dtoObject.DepositTransferID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@DepositBookID", dtoObject.DepositBookID)
.AddParameter("@Amount", dtoObject.Amount)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@Narration", dtoObject.Narration)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.Transfer_Deposit_JoinSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.Transfer_Deposit_JoinSelectAll)
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
		public bool Insert(Transfer_Deposit_Join dtoObject)
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

                    StoredProcedure(MasterDALConstant.Transfer_Deposit_JoinInsert)
                        .AddParameter("@DepositTransferID", dtoObject.DepositTransferID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@DepositBookID", dtoObject.DepositBookID)
.AddParameter("@Amount", dtoObject.Amount)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@Narration", dtoObject.Narration)

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
        public bool Update(Transfer_Deposit_Join dtoObject)
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

                    StoredProcedure(MasterDALConstant.Transfer_Deposit_JoinUpdate)
                        .AddParameter("@DepositTransferID", dtoObject.DepositTransferID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@DepositBookID", dtoObject.DepositBookID)
.AddParameter("@Amount", dtoObject.Amount)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@Narration", dtoObject.Narration)

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
                StoredProcedure(MasterDALConstant.Transfer_Deposit_JoinDeleteByPrimaryKey)
                    .AddParameter("@DepositTransferID"
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
        public bool Delete(Transfer_Deposit_Join dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.Transfer_Deposit_JoinDeleteByPrimaryKey)
                    .AddParameter("@DepositTransferID", dtoObject.DepositTransferID)

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

        public Transfer_Deposit_Join SelectByPrimaryKey(Guid Keys)
        {
            Transfer_Deposit_Join obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.Transfer_Deposit_JoinSelectByPrimaryKey)
                            .AddParameter("@DepositTransferID"
,Keys)
                            .Fetch<Transfer_Deposit_Join>();
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
        public List<Transfer_Deposit_Join> SelectByField(string fieldName, object value)
        {
            List<Transfer_Deposit_Join> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.Transfer_Deposit_JoinSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Transfer_Deposit_Join>();

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
                obj = StoredProcedure(MasterDALConstant.Transfer_Deposit_JoinSelectByField) 
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
                StoredProcedure(MasterDALConstant.Transfer_Deposit_JoinDeleteByField) 
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
