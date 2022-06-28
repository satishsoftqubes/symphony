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
	/// Data access layer class for POSChargePerDay
	/// </summary>
	public class POSChargePerDayDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public POSChargePerDayDAL() :  base()
		{
			// Nothing for now.
		}
        public POSChargePerDayDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<POSChargePerDay> SelectAll(POSChargePerDay dtoObject)
        {
            List<POSChargePerDay> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.POSChargePerDaySelectAll)
                                                .AddParameter("@POSChargeID", dtoObject.POSChargeID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@ChargeAmount", dtoObject.ChargeAmount)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)

                                                .WithTransaction(dbtr)
                                                .FetchAll<POSChargePerDay>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.POSChargePerDaySelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<POSChargePerDay>();
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

        public List<POSChargePerDay> SelectAll()
        {
            List<POSChargePerDay> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.POSChargePerDaySelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<POSChargePerDay>();
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
        public DataSet SelectAllWithDataSet(POSChargePerDay dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.POSChargePerDaySelectAll)
                                                .AddParameter("@POSChargeID", dtoObject.POSChargeID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@ChargeAmount", dtoObject.ChargeAmount)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.POSChargePerDaySelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.POSChargePerDaySelectAll)
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
		public bool Insert(POSChargePerDay dtoObject)
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

                    StoredProcedure(MasterDALConstant.POSChargePerDayInsert)
                        .AddParameter("@POSChargeID", dtoObject.POSChargeID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@ChargeAmount", dtoObject.ChargeAmount)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@RateCardID", dtoObject.RateCardID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
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
        public bool Update(POSChargePerDay dtoObject)
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

                    StoredProcedure(MasterDALConstant.POSChargePerDayUpdate)
                        .AddParameter("@POSChargeID", dtoObject.POSChargeID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@ChargeAmount", dtoObject.ChargeAmount)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)

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
                StoredProcedure(MasterDALConstant.POSChargePerDayDeleteByPrimaryKey)
                    .AddParameter("@POSChargeID"
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
        public bool Delete(POSChargePerDay dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.POSChargePerDayDeleteByPrimaryKey)
                    .AddParameter("@POSChargeID", dtoObject.POSChargeID)

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

        public POSChargePerDay SelectByPrimaryKey(Guid Keys)
        {
            POSChargePerDay obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.POSChargePerDaySelectByPrimaryKey)
                            .AddParameter("@POSChargeID"
,Keys)
                            .Fetch<POSChargePerDay>();
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
        public List<POSChargePerDay> SelectByField(string fieldName, object value)
        {
            List<POSChargePerDay> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.POSChargePerDaySelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<POSChargePerDay>();

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
                obj = StoredProcedure(MasterDALConstant.POSChargePerDaySelectByField) 
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
                StoredProcedure(MasterDALConstant.POSChargePerDayDeleteByField) 
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

        public DataSet SelectByRateIDAndRoomTypeID(Guid RateCardID, Guid RoomTypeID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.POSChargePerDaySelectByRateIDAndRoomTypeID)
                                    .AddParameter("@RateCardID", RateCardID)
                                    .AddParameter("@RoomTypeID", RoomTypeID)
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
