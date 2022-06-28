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
	/// Data access layer class for Collection
	/// </summary>
	public class CollectionDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public CollectionDAL() :  base()
		{
			// Nothing for now.
		}
        public CollectionDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Collection> SelectAll(Collection dtoObject)
        {
            List<Collection> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.CollectionSelectAll)
                                                .AddParameter("@CollectionID", dtoObject.CollectionID)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@CR", dtoObject.CR)
.AddParameter("@DB", dtoObject.DB)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@MOP_AcctID", dtoObject.MOP_AcctID)
.AddParameter("@Narration", dtoObject.Narration)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@InvoiceID", dtoObject.InvoiceID)
.AddParameter("@GeneralBillID", dtoObject.GeneralBillID)
.AddParameter("@AuditID", dtoObject.AuditID)
.AddParameter("@CloseID", dtoObject.CloseID)
.AddParameter("@ReconcileID", dtoObject.ReconcileID)
.AddParameter("@GeneralID", dtoObject.GeneralID)
//.AddParameter("@GeneralIDType_TermID", dtoObject.GeneralIDType_TermID)
.AddParameter("@IsDeposit", dtoObject.IsDeposit)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Collection>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.CollectionSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Collection>();
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

        public List<Collection> SelectAll()
        {
            List<Collection> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.CollectionSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Collection>();
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
        public DataSet SelectAllWithDataSet(Collection dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.CollectionSelectAll)
                                                .AddParameter("@CollectionID", dtoObject.CollectionID)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@CR", dtoObject.CR)
.AddParameter("@DB", dtoObject.DB)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@MOP_AcctID", dtoObject.MOP_AcctID)
.AddParameter("@Narration", dtoObject.Narration)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@InvoiceID", dtoObject.InvoiceID)
.AddParameter("@GeneralBillID", dtoObject.GeneralBillID)
.AddParameter("@AuditID", dtoObject.AuditID)
.AddParameter("@CloseID", dtoObject.CloseID)
.AddParameter("@ReconcileID", dtoObject.ReconcileID)
.AddParameter("@GeneralID", dtoObject.GeneralID)
//.AddParameter("@GeneralIDType_TermID", dtoObject.GeneralIDType_TermID)
.AddParameter("@IsDeposit", dtoObject.IsDeposit)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
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
                        obj = StoredProcedure(MasterDALConstant.CollectionSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.CollectionSelectAll)
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
		public bool Insert(Collection dtoObject)
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

                    StoredProcedure(MasterDALConstant.CollectionInsert)
                        .AddParameter("@CollectionID", dtoObject.CollectionID)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@CR", dtoObject.CR)
.AddParameter("@DB", dtoObject.DB)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@MOP_AcctID", dtoObject.MOP_AcctID)
.AddParameter("@Narration", dtoObject.Narration)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@InvoiceID", dtoObject.InvoiceID)
.AddParameter("@GeneralBillID", dtoObject.GeneralBillID)
.AddParameter("@AuditID", dtoObject.AuditID)
.AddParameter("@CloseID", dtoObject.CloseID)
.AddParameter("@ReconcileID", dtoObject.ReconcileID)
.AddParameter("@GeneralID", dtoObject.GeneralID)
//.AddParameter("@GeneralIDType_TermID", dtoObject.GeneralIDType_TermID)
.AddParameter("@IsDeposit", dtoObject.IsDeposit)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
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
        public bool Update(Collection dtoObject)
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

                    StoredProcedure(MasterDALConstant.CollectionUpdate)
                        .AddParameter("@CollectionID", dtoObject.CollectionID)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@CR", dtoObject.CR)
.AddParameter("@DB", dtoObject.DB)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@MOP_AcctID", dtoObject.MOP_AcctID)
.AddParameter("@Narration", dtoObject.Narration)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@InvoiceID", dtoObject.InvoiceID)
.AddParameter("@GeneralBillID", dtoObject.GeneralBillID)
.AddParameter("@AuditID", dtoObject.AuditID)
.AddParameter("@CloseID", dtoObject.CloseID)
.AddParameter("@ReconcileID", dtoObject.ReconcileID)
.AddParameter("@GeneralID", dtoObject.GeneralID)
//.AddParameter("@GeneralIDType_TermID", dtoObject.GeneralIDType_TermID)
.AddParameter("@IsDeposit", dtoObject.IsDeposit)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
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
                StoredProcedure(MasterDALConstant.CollectionDeleteByPrimaryKey)
                    .AddParameter("@CollectionID"
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
        public bool Delete(Collection dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.CollectionDeleteByPrimaryKey)
                    .AddParameter("@CollectionID", dtoObject.CollectionID)

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

        public Collection SelectByPrimaryKey(Guid Keys)
        {
            Collection obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.CollectionSelectByPrimaryKey)
                            .AddParameter("@CollectionID"
,Keys)
                            .Fetch<Collection>();
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
        public List<Collection> SelectByField(string fieldName, object value)
        {
            List<Collection> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.CollectionSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Collection>();

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
                obj = StoredProcedure(MasterDALConstant.CollectionSelectByField) 
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
                StoredProcedure(MasterDALConstant.CollectionDeleteByField) 
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

        public DataSet GetTotalRevenueForQuarterForIR(DateTime StartDate, DateTime EndDate, Guid CompanyID, Guid PropertyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.CollectionTotalRevenueForQuarterForIR)
                                    .AddParameter("@StartDate", StartDate)
                                    .AddParameter("@EndDate", EndDate)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
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

        #endregion
	}
}
