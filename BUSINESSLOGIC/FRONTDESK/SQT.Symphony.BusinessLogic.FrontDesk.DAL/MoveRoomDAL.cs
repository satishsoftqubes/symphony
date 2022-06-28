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
	/// Data access layer class for MoveRoom
	/// </summary>
	public class MoveRoomDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public MoveRoomDAL() :  base()
		{
			// Nothing for now.
		}
        public MoveRoomDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<MoveRoom> SelectAll(MoveRoom dtoObject)
        {
            List<MoveRoom> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.MoveRoomSelectAll)
                                                .AddParameter("@MoveRoomID", dtoObject.MoveRoomID)
.AddParameter("@RefMoveRoomID", dtoObject.RefMoveRoomID)
.AddParameter("@MoveType_TermID", dtoObject.MoveType_TermID)
.AddParameter("@Reasom", dtoObject.Reasom)
.AddParameter("@OldRoomID", dtoObject.OldRoomID)
.AddParameter("@NewRoomID", dtoObject.NewRoomID)
.AddParameter("@ConfirmedBy", dtoObject.ConfirmedBy)
.AddParameter("@DateOfMove", dtoObject.DateOfMove)
.AddParameter("@IsByExtraCost", dtoObject.IsByExtraCost)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@DateUpTo", dtoObject.DateUpTo)

                                                .WithTransaction(dbtr)
                                                .FetchAll<MoveRoom>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.MoveRoomSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<MoveRoom>();
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

        public List<MoveRoom> SelectAll()
        {
            List<MoveRoom> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.MoveRoomSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<MoveRoom>();
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
        public DataSet SelectAllWithDataSet(MoveRoom dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.MoveRoomSelectAll)
                                                .AddParameter("@MoveRoomID", dtoObject.MoveRoomID)
.AddParameter("@RefMoveRoomID", dtoObject.RefMoveRoomID)
.AddParameter("@MoveType_TermID", dtoObject.MoveType_TermID)
.AddParameter("@Reasom", dtoObject.Reasom)
.AddParameter("@OldRoomID", dtoObject.OldRoomID)
.AddParameter("@NewRoomID", dtoObject.NewRoomID)
.AddParameter("@ConfirmedBy", dtoObject.ConfirmedBy)
.AddParameter("@DateOfMove", dtoObject.DateOfMove)
.AddParameter("@IsByExtraCost", dtoObject.IsByExtraCost)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@DateUpTo", dtoObject.DateUpTo)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.MoveRoomSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.MoveRoomSelectAll)
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
		public bool Insert(MoveRoom dtoObject)
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

                    StoredProcedure(MasterDALConstant.MoveRoomInsert)
                        .AddParameter("@MoveRoomID", dtoObject.MoveRoomID)
.AddParameter("@RefMoveRoomID", dtoObject.RefMoveRoomID)
.AddParameter("@MoveType_TermID", dtoObject.MoveType_TermID)
.AddParameter("@Reasom", dtoObject.Reasom)
.AddParameter("@OldRoomID", dtoObject.OldRoomID)
.AddParameter("@NewRoomID", dtoObject.NewRoomID)
.AddParameter("@ConfirmedBy", dtoObject.ConfirmedBy)
.AddParameter("@DateOfMove", dtoObject.DateOfMove)
.AddParameter("@IsByExtraCost", dtoObject.IsByExtraCost)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@DateUpTo", dtoObject.DateUpTo)

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
        public bool Update(MoveRoom dtoObject)
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

                    StoredProcedure(MasterDALConstant.MoveRoomUpdate)
                        .AddParameter("@MoveRoomID", dtoObject.MoveRoomID)
.AddParameter("@RefMoveRoomID", dtoObject.RefMoveRoomID)
.AddParameter("@MoveType_TermID", dtoObject.MoveType_TermID)
.AddParameter("@Reasom", dtoObject.Reasom)
.AddParameter("@OldRoomID", dtoObject.OldRoomID)
.AddParameter("@NewRoomID", dtoObject.NewRoomID)
.AddParameter("@ConfirmedBy", dtoObject.ConfirmedBy)
.AddParameter("@DateOfMove", dtoObject.DateOfMove)
.AddParameter("@IsByExtraCost", dtoObject.IsByExtraCost)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@DateUpTo", dtoObject.DateUpTo)

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
                StoredProcedure(MasterDALConstant.MoveRoomDeleteByPrimaryKey)
                    .AddParameter("@MoveRoomID"
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
        public bool Delete(MoveRoom dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.MoveRoomDeleteByPrimaryKey)
                    .AddParameter("@MoveRoomID", dtoObject.MoveRoomID)

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

        public MoveRoom SelectByPrimaryKey(Guid Keys)
        {
            MoveRoom obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.MoveRoomSelectByPrimaryKey)
                            .AddParameter("@MoveRoomID"
,Keys)
                            .Fetch<MoveRoom>();
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
        public List<MoveRoom> SelectByField(string fieldName, object value)
        {
            List<MoveRoom> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.MoveRoomSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<MoveRoom>();

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
                obj = StoredProcedure(MasterDALConstant.MoveRoomSelectByField) 
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
                StoredProcedure(MasterDALConstant.MoveRoomDeleteByField) 
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

        public DataSet SelectMoveRoomHistory(Guid? MoveRoomID, Guid? ReservationID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.MoveRoom_SelectMoveRoomHistory)
                                    .AddParameter("@MoveRoomID", MoveRoomID)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@StartDate", StartDate)
                                    .AddParameter("@EndDate", EndDate)
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
