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
	/// Data access layer class for GuestLaundry
	/// </summary>
	public class GuestLaundryDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public GuestLaundryDAL() :  base()
		{
			// Nothing for now.
		}
        public GuestLaundryDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<GuestLaundry> SelectAll(GuestLaundry dtoObject)
        {
            List<GuestLaundry> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.GuestLaundrySelectAll)
                                                .AddParameter("@GuestLaundryID", dtoObject.GuestLaundryID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@GuestName", dtoObject.GuestName)
.AddParameter("@DateOfReceived", dtoObject.DateOfReceived)
.AddParameter("@DateToReturn", dtoObject.DateToReturn)
.AddParameter("@IsReturned", dtoObject.IsReturned)
.AddParameter("@DocateNo", dtoObject.DocateNo)
.AddParameter("@IsBilled", dtoObject.IsBilled)
.AddParameter("@BilledAmt", dtoObject.BilledAmt)
.AddParameter("@Remarks", dtoObject.Remarks)
.AddParameter("@GeneralBillID", dtoObject.GeneralBillID)
.AddParameter("@IsPaid", dtoObject.IsPaid)
.AddParameter("@IsTransferredToFolio", dtoObject.IsTransferredToFolio)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)

                                                .WithTransaction(dbtr)
                                                .FetchAll<GuestLaundry>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.GuestLaundrySelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<GuestLaundry>();
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

        public List<GuestLaundry> SelectAll()
        {
            List<GuestLaundry> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.GuestLaundrySelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<GuestLaundry>();
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
        public DataSet SelectAllWithDataSet(GuestLaundry dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.GuestLaundrySelectAll)
                                                .AddParameter("@GuestLaundryID", dtoObject.GuestLaundryID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@GuestName", dtoObject.GuestName)
.AddParameter("@DateOfReceived", dtoObject.DateOfReceived)
.AddParameter("@DateToReturn", dtoObject.DateToReturn)
.AddParameter("@IsReturned", dtoObject.IsReturned)
.AddParameter("@DocateNo", dtoObject.DocateNo)
.AddParameter("@IsBilled", dtoObject.IsBilled)
.AddParameter("@BilledAmt", dtoObject.BilledAmt)
.AddParameter("@Remarks", dtoObject.Remarks)
.AddParameter("@GeneralBillID", dtoObject.GeneralBillID)
.AddParameter("@IsPaid", dtoObject.IsPaid)
.AddParameter("@IsTransferredToFolio", dtoObject.IsTransferredToFolio)
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
                        obj = StoredProcedure(MasterDALConstant.GuestLaundrySelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.GuestLaundrySelectAll)
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
		public bool Insert(GuestLaundry dtoObject)
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

                    StoredProcedure(MasterDALConstant.GuestLaundryInsert)
                        .AddParameter("@GuestLaundryID", dtoObject.GuestLaundryID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@GuestName", dtoObject.GuestName)
.AddParameter("@DateOfReceived", dtoObject.DateOfReceived)
.AddParameter("@DateToReturn", dtoObject.DateToReturn)
.AddParameter("@IsReturned", dtoObject.IsReturned)
.AddParameter("@DocateNo", dtoObject.DocateNo)
.AddParameter("@IsBilled", dtoObject.IsBilled)
.AddParameter("@BilledAmt", dtoObject.BilledAmt)
.AddParameter("@Remarks", dtoObject.Remarks)
.AddParameter("@GeneralBillID", dtoObject.GeneralBillID)
.AddParameter("@IsPaid", dtoObject.IsPaid)
.AddParameter("@IsTransferredToFolio", dtoObject.IsTransferredToFolio)
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
        public bool Update(GuestLaundry dtoObject)
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

                    StoredProcedure(MasterDALConstant.GuestLaundryUpdate)
                        .AddParameter("@GuestLaundryID", dtoObject.GuestLaundryID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@GuestName", dtoObject.GuestName)
.AddParameter("@DateOfReceived", dtoObject.DateOfReceived)
.AddParameter("@DateToReturn", dtoObject.DateToReturn)
.AddParameter("@IsReturned", dtoObject.IsReturned)
.AddParameter("@DocateNo", dtoObject.DocateNo)
.AddParameter("@IsBilled", dtoObject.IsBilled)
.AddParameter("@BilledAmt", dtoObject.BilledAmt)
.AddParameter("@Remarks", dtoObject.Remarks)
.AddParameter("@GeneralBillID", dtoObject.GeneralBillID)
.AddParameter("@IsPaid", dtoObject.IsPaid)
.AddParameter("@IsTransferredToFolio", dtoObject.IsTransferredToFolio)
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
                StoredProcedure(MasterDALConstant.GuestLaundryDeleteByPrimaryKey)
                    .AddParameter("@GuestLaundryID"
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
        public bool Delete(GuestLaundry dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.GuestLaundryDeleteByPrimaryKey)
                    .AddParameter("@GuestLaundryID", dtoObject.GuestLaundryID)

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

        public GuestLaundry SelectByPrimaryKey(Guid Keys)
        {
            GuestLaundry obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.GuestLaundrySelectByPrimaryKey)
                            .AddParameter("@GuestLaundryID"
,Keys)
                            .Fetch<GuestLaundry>();
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
        public List<GuestLaundry> SelectByField(string fieldName, object value)
        {
            List<GuestLaundry> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.GuestLaundrySelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<GuestLaundry>();

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
                obj = StoredProcedure(MasterDALConstant.GuestLaundrySelectByField) 
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
                StoredProcedure(MasterDALConstant.GuestLaundryDeleteByField) 
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
