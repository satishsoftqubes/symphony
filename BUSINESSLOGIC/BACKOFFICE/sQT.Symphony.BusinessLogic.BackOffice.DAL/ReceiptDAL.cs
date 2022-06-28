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
	/// Data access layer class for Receipt
	/// </summary>
	public class ReceiptDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public ReceiptDAL() :  base()
		{
			// Nothing for now.
		}
        public ReceiptDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Receipt> SelectAll(Receipt dtoObject)
        {
            List<Receipt> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.ReceiptSelectAll)
                                                .AddParameter("@ReceiptID", dtoObject.ReceiptID)
.AddParameter("@ReceiptNo", dtoObject.ReceiptNo)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@Amt", dtoObject.Amt)
.AddParameter("@GeneralID", dtoObject.GeneralID)
.AddParameter("@GeneralIDType", dtoObject.GeneralIDType)
.AddParameter("@Narration", dtoObject.Narration)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@OrderSeqNo", dtoObject.OrderSeqNo)
.AddParameter("@GuestID", dtoObject.GuestID)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Receipt>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ReceiptSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Receipt>();
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

        public List<Receipt> SelectAll()
        {
            List<Receipt> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.ReceiptSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Receipt>();
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
        public DataSet SelectAllWithDataSet(Receipt dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.ReceiptSelectAll)
                                                .AddParameter("@ReceiptID", dtoObject.ReceiptID)
.AddParameter("@ReceiptNo", dtoObject.ReceiptNo)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@Amt", dtoObject.Amt)
.AddParameter("@GeneralID", dtoObject.GeneralID)
.AddParameter("@GeneralIDType", dtoObject.GeneralIDType)
.AddParameter("@Narration", dtoObject.Narration)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@OrderSeqNo", dtoObject.OrderSeqNo)
.AddParameter("@GuestID", dtoObject.GuestID)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ReceiptSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.ReceiptSelectAll)
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
		public bool Insert(Receipt dtoObject)
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

                    StoredProcedure(MasterDALConstant.ReceiptInsert)
                        .AddParameter("@ReceiptID", dtoObject.ReceiptID)
.AddParameter("@ReceiptNo", dtoObject.ReceiptNo)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@Amt", dtoObject.Amt)
.AddParameter("@GeneralID", dtoObject.GeneralID)
.AddParameter("@GeneralIDType", dtoObject.GeneralIDType)
.AddParameter("@Narration", dtoObject.Narration)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@OrderSeqNo", dtoObject.OrderSeqNo)
.AddParameter("@GuestID", dtoObject.GuestID)

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
        public bool Update(Receipt dtoObject)
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

                    StoredProcedure(MasterDALConstant.ReceiptUpdate)
                        .AddParameter("@ReceiptID", dtoObject.ReceiptID)
.AddParameter("@ReceiptNo", dtoObject.ReceiptNo)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@Amt", dtoObject.Amt)
.AddParameter("@GeneralID", dtoObject.GeneralID)
.AddParameter("@GeneralIDType", dtoObject.GeneralIDType)
.AddParameter("@Narration", dtoObject.Narration)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@OrderSeqNo", dtoObject.OrderSeqNo)
.AddParameter("@GuestID", dtoObject.GuestID)

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
                StoredProcedure(MasterDALConstant.ReceiptDeleteByPrimaryKey)
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
        public bool Delete(Receipt dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.ReceiptDeleteByPrimaryKey)
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

        public Receipt SelectByPrimaryKey(Guid Keys)
        {
            Receipt obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReceiptSelectByPrimaryKey)
                            .AddParameter("@ReceiptID"
,Keys)
                            .Fetch<Receipt>();
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
        public List<Receipt> SelectByField(string fieldName, object value)
        {
            List<Receipt> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReceiptSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Receipt>();

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
                obj = StoredProcedure(MasterDALConstant.ReceiptSelectByField) 
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
                StoredProcedure(MasterDALConstant.ReceiptDeleteByField) 
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
