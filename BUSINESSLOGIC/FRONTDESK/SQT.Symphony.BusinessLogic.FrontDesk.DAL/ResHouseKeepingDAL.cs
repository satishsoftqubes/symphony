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
	/// Data access layer class for ResHouseKeeping
	/// </summary>
	public class ResHouseKeepingDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public ResHouseKeepingDAL() :  base()
		{
			// Nothing for now.
		}
        public ResHouseKeepingDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<ResHouseKeeping> SelectAll(ResHouseKeeping dtoObject)
        {
            List<ResHouseKeeping> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.ResHouseKeepingSelectAll)
                                                .AddParameter("@ResHKPID", dtoObject.ResHKPID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@HKDate", dtoObject.HKDate)
.AddParameter("@HKPType_TermID", dtoObject.HKPType_TermID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@ConferenceID", dtoObject.ConferenceID)
.AddParameter("@RoomStatus_TermID", dtoObject.RoomStatus_TermID)
.AddParameter("@CleanType_TermID", dtoObject.CleanType_TermID)
.AddParameter("@IsScheduleData", dtoObject.IsScheduleData)
.AddParameter("@IsOnDemandHK", dtoObject.IsOnDemandHK)
.AddParameter("@RequestedOwnerID", dtoObject.RequestedOwnerID)
.AddParameter("@OwnerType_TermID", dtoObject.OwnerType_TermID)
.AddParameter("@RequestedDate", dtoObject.RequestedDate)
.AddParameter("@HandledDate", dtoObject.HandledDate)
.AddParameter("@Request", dtoObject.Request)
.AddParameter("@HandledBy", dtoObject.HandledBy)
.AddParameter("@HouseKeepingType_TermID", dtoObject.HouseKeepingType_TermID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)

                                                .WithTransaction(dbtr)
                                                .FetchAll<ResHouseKeeping>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ResHouseKeepingSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<ResHouseKeeping>();
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

        public List<ResHouseKeeping> SelectAll()
        {
            List<ResHouseKeeping> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.ResHouseKeepingSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<ResHouseKeeping>();
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
        public DataSet SelectAllWithDataSet(ResHouseKeeping dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.ResHouseKeepingSelectAll)
                                                .AddParameter("@ResHKPID", dtoObject.ResHKPID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@HKDate", dtoObject.HKDate)
.AddParameter("@HKPType_TermID", dtoObject.HKPType_TermID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@ConferenceID", dtoObject.ConferenceID)
.AddParameter("@RoomStatus_TermID", dtoObject.RoomStatus_TermID)
.AddParameter("@CleanType_TermID", dtoObject.CleanType_TermID)
.AddParameter("@IsScheduleData", dtoObject.IsScheduleData)
.AddParameter("@IsOnDemandHK", dtoObject.IsOnDemandHK)
.AddParameter("@RequestedOwnerID", dtoObject.RequestedOwnerID)
.AddParameter("@OwnerType_TermID", dtoObject.OwnerType_TermID)
.AddParameter("@RequestedDate", dtoObject.RequestedDate)
.AddParameter("@HandledDate", dtoObject.HandledDate)
.AddParameter("@Request", dtoObject.Request)
.AddParameter("@HandledBy", dtoObject.HandledBy)
.AddParameter("@HouseKeepingType_TermID", dtoObject.HouseKeepingType_TermID)
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
                        obj = StoredProcedure(MasterDALConstant.ResHouseKeepingSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.ResHouseKeepingSelectAll)
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
		public bool Insert(ResHouseKeeping dtoObject)
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

                    StoredProcedure(MasterDALConstant.ResHouseKeepingInsert)
                        .AddParameter("@ResHKPID", dtoObject.ResHKPID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@HKDate", dtoObject.HKDate)
.AddParameter("@HKPType_TermID", dtoObject.HKPType_TermID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@ConferenceID", dtoObject.ConferenceID)
.AddParameter("@RoomStatus_TermID", dtoObject.RoomStatus_TermID)
.AddParameter("@CleanType_TermID", dtoObject.CleanType_TermID)
.AddParameter("@IsScheduleData", dtoObject.IsScheduleData)
.AddParameter("@IsOnDemandHK", dtoObject.IsOnDemandHK)
.AddParameter("@RequestedOwnerID", dtoObject.RequestedOwnerID)
.AddParameter("@OwnerType_TermID", dtoObject.OwnerType_TermID)
.AddParameter("@RequestedDate", dtoObject.RequestedDate)
.AddParameter("@HandledDate", dtoObject.HandledDate)
.AddParameter("@Request", dtoObject.Request)
.AddParameter("@HandledBy", dtoObject.HandledBy)
.AddParameter("@HouseKeepingType_TermID", dtoObject.HouseKeepingType_TermID)
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
        public bool Update(ResHouseKeeping dtoObject)
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

                    StoredProcedure(MasterDALConstant.ResHouseKeepingUpdate)
                        .AddParameter("@ResHKPID", dtoObject.ResHKPID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@HKDate", dtoObject.HKDate)
.AddParameter("@HKPType_TermID", dtoObject.HKPType_TermID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@ConferenceID", dtoObject.ConferenceID)
.AddParameter("@RoomStatus_TermID", dtoObject.RoomStatus_TermID)
.AddParameter("@CleanType_TermID", dtoObject.CleanType_TermID)
.AddParameter("@IsScheduleData", dtoObject.IsScheduleData)
.AddParameter("@IsOnDemandHK", dtoObject.IsOnDemandHK)
.AddParameter("@RequestedOwnerID", dtoObject.RequestedOwnerID)
.AddParameter("@OwnerType_TermID", dtoObject.OwnerType_TermID)
.AddParameter("@RequestedDate", dtoObject.RequestedDate)
.AddParameter("@HandledDate", dtoObject.HandledDate)
.AddParameter("@Request", dtoObject.Request)
.AddParameter("@HandledBy", dtoObject.HandledBy)
.AddParameter("@HouseKeepingType_TermID", dtoObject.HouseKeepingType_TermID)
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
                StoredProcedure(MasterDALConstant.ResHouseKeepingDeleteByPrimaryKey)
                    .AddParameter("@ResHKPID"
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
        public bool Delete(ResHouseKeeping dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.ResHouseKeepingDeleteByPrimaryKey)
                    .AddParameter("@ResHKPID", dtoObject.ResHKPID)

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

        public ResHouseKeeping SelectByPrimaryKey(Guid Keys)
        {
            ResHouseKeeping obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ResHouseKeepingSelectByPrimaryKey)
                            .AddParameter("@ResHKPID"
,Keys)
                            .Fetch<ResHouseKeeping>();
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
        public List<ResHouseKeeping> SelectByField(string fieldName, object value)
        {
            List<ResHouseKeeping> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ResHouseKeepingSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<ResHouseKeeping>();

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
                obj = StoredProcedure(MasterDALConstant.ResHouseKeepingSelectByField) 
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
                StoredProcedure(MasterDALConstant.ResHouseKeepingDeleteByField) 
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
