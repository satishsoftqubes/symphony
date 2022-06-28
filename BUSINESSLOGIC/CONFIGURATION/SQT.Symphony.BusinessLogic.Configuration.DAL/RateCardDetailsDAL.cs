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
	/// Data access layer class for RateCardDetails
	/// </summary>
	public class RateCardDetailsDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public RateCardDetailsDAL() :  base()
		{
			// Nothing for now.
		}
        public RateCardDetailsDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<RateCardDetails> SelectAll(RateCardDetails dtoObject)
        {
            List<RateCardDetails> obj = null;
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
                        obj = StoredProcedure(MasterConstant.RateCardDetailsSelectAll)
                                                .AddParameter("@RateCardDetailID", dtoObject.RateCardDetailID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@OccupencyLevelID", dtoObject.OccupencyLevelID)
.AddParameter("@RackRate", dtoObject.RackRate)
.AddParameter("@ExtraAdultRate", dtoObject.ExtraAdultRate)
.AddParameter("@ChildRate", dtoObject.ChildRate)
.AddParameter("@MondayRate", dtoObject.MondayRate)
.AddParameter("@TuesdayRate", dtoObject.TuesdayRate)
.AddParameter("@WednesdayRate", dtoObject.WednesdayRate)
.AddParameter("@ThursdayRate", dtoObject.ThursdayRate)
.AddParameter("@FridayRate", dtoObject.FridayRate)
.AddParameter("@SaturdayRate", dtoObject.SaturdayRate)
.AddParameter("@SundayRate", dtoObject.SundayRate)
.AddParameter("@ConferenceID", dtoObject.ConferenceID)
.AddParameter("@DepositAmount", dtoObject.DepositAmount)
.AddParameter("@ExtarbedCharge", dtoObject.ExtarbedCharge)
.AddParameter("@TotalRackRate", dtoObject.TotalRackRate)

                                                .WithTransaction(dbtr)
                                                .FetchAll<RateCardDetails>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.RateCardDetailsSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<RateCardDetails>();
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

        public List<RateCardDetails> SelectAll()
        {
            List<RateCardDetails> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.RateCardDetailsSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<RateCardDetails>();
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
        public DataSet SelectAllWithDataSet(RateCardDetails dtoObject)
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
                        obj = StoredProcedure(MasterConstant.RateCardDetailsSelectAll)
                                                .AddParameter("@RateCardDetailID", dtoObject.RateCardDetailID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@OccupencyLevelID", dtoObject.OccupencyLevelID)
.AddParameter("@RackRate", dtoObject.RackRate)
.AddParameter("@ExtraAdultRate", dtoObject.ExtraAdultRate)
.AddParameter("@ChildRate", dtoObject.ChildRate)
.AddParameter("@MondayRate", dtoObject.MondayRate)
.AddParameter("@TuesdayRate", dtoObject.TuesdayRate)
.AddParameter("@WednesdayRate", dtoObject.WednesdayRate)
.AddParameter("@ThursdayRate", dtoObject.ThursdayRate)
.AddParameter("@FridayRate", dtoObject.FridayRate)
.AddParameter("@SaturdayRate", dtoObject.SaturdayRate)
.AddParameter("@SundayRate", dtoObject.SundayRate)
.AddParameter("@ConferenceID", dtoObject.ConferenceID)
.AddParameter("@DepositAmount", dtoObject.DepositAmount)
.AddParameter("@ExtarbedCharge", dtoObject.ExtarbedCharge)
.AddParameter("@TotalRackRate", dtoObject.TotalRackRate)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.RateCardDetailsSelectAll)
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

                    obj = StoredProcedure(MasterConstant.RateCardDetailsSelectAll)
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
		public bool Insert(RateCardDetails dtoObject)
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

                    StoredProcedure(MasterConstant.RateCardDetailsInsert)
                        .AddParameter("@RateCardDetailID", dtoObject.RateCardDetailID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@OccupencyLevelID", dtoObject.OccupencyLevelID)
.AddParameter("@RackRate", dtoObject.RackRate)
.AddParameter("@ExtraAdultRate", dtoObject.ExtraAdultRate)
.AddParameter("@ChildRate", dtoObject.ChildRate)
.AddParameter("@MondayRate", dtoObject.MondayRate)
.AddParameter("@TuesdayRate", dtoObject.TuesdayRate)
.AddParameter("@WednesdayRate", dtoObject.WednesdayRate)
.AddParameter("@ThursdayRate", dtoObject.ThursdayRate)
.AddParameter("@FridayRate", dtoObject.FridayRate)
.AddParameter("@SaturdayRate", dtoObject.SaturdayRate)
.AddParameter("@SundayRate", dtoObject.SundayRate)
.AddParameter("@ConferenceID", dtoObject.ConferenceID)
.AddParameter("@DepositAmount", dtoObject.DepositAmount)
.AddParameter("@ExtarbedCharge", dtoObject.ExtarbedCharge)
.AddParameter("@TotalRackRate", dtoObject.TotalRackRate)

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
        public bool Update(RateCardDetails dtoObject)
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

                    StoredProcedure(MasterConstant.RateCardDetailsUpdate)
                        .AddParameter("@RateCardDetailID", dtoObject.RateCardDetailID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@OccupencyLevelID", dtoObject.OccupencyLevelID)
.AddParameter("@RackRate", dtoObject.RackRate)
.AddParameter("@ExtraAdultRate", dtoObject.ExtraAdultRate)
.AddParameter("@ChildRate", dtoObject.ChildRate)
.AddParameter("@MondayRate", dtoObject.MondayRate)
.AddParameter("@TuesdayRate", dtoObject.TuesdayRate)
.AddParameter("@WednesdayRate", dtoObject.WednesdayRate)
.AddParameter("@ThursdayRate", dtoObject.ThursdayRate)
.AddParameter("@FridayRate", dtoObject.FridayRate)
.AddParameter("@SaturdayRate", dtoObject.SaturdayRate)
.AddParameter("@SundayRate", dtoObject.SundayRate)
.AddParameter("@ConferenceID", dtoObject.ConferenceID)
.AddParameter("@DepositAmount", dtoObject.DepositAmount)
.AddParameter("@ExtarbedCharge", dtoObject.ExtarbedCharge)
.AddParameter("@TotalRackRate", dtoObject.TotalRackRate)

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
                StoredProcedure(MasterConstant.RateCardDetailsDeleteByPrimaryKey)
                    .AddParameter("@RateCardDetailID"
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
        public bool Delete(RateCardDetails dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.RateCardDetailsDeleteByPrimaryKey)
                    .AddParameter("@RateCardDetailID", dtoObject.RateCardDetailID)

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

        public RateCardDetails SelectByPrimaryKey(Guid Keys)
        {
            RateCardDetails obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RateCardDetailsSelectByPrimaryKey)
                            .AddParameter("@RateCardDetailID"
,Keys)
                            .Fetch<RateCardDetails>();
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
        public List<RateCardDetails> SelectByField(string fieldName, object value)
        {
            List<RateCardDetails> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RateCardDetailsSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<RateCardDetails>();

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
                obj = StoredProcedure(MasterConstant.RateCardDetailsSelectByField) 
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

        public DataSet SelectByRateCardDetailByRateIDnRoomTypeID(Guid rateID, Guid roomTypeID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RateCardDetailsGetByRateIDnRoomTypeID)
                                    .AddParameter("@RateID", rateID)
                                    .AddParameter("@RoomTypeID", roomTypeID)
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
                StoredProcedure(MasterConstant.RateCardDetailsDeleteByField) 
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

        public DataSet SelectRoomTypeByRateID(Guid? RateID, Guid? PropertyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RateCardDetailsSelectRoomTypeByRateID)
                                    .AddParameter("@RateID", RateID)
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

        public DataSet SelectRateCardDetailsForPOS(Guid rateID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RateCardDetailsSelectForPOSCharge)
                                    .AddParameter("@RateID", rateID)
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
