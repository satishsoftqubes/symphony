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
	/// Data access layer class for ReservationUpdateLog
	/// </summary>
	public class ReservationUpdateLogDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public ReservationUpdateLogDAL() :  base()
		{
			// Nothing for now.
		}
        public ReservationUpdateLogDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<ReservationUpdateLog> SelectAll(ReservationUpdateLog dtoObject)
        {
            List<ReservationUpdateLog> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.ReservationUpdateLogSelectAll)
                                                .AddParameter("@ReservationUpdateLogID", dtoObject.ReservationUpdateLogID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@RefReservationID", dtoObject.RefReservationID)
.AddParameter("@ReservationType_TermID", dtoObject.ReservationType_TermID)
.AddParameter("@GroupReservationID", dtoObject.GroupReservationID)
.AddParameter("@GroupID", dtoObject.GroupID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@RefRoomID", dtoObject.RefRoomID)
.AddParameter("@ConferenceID", dtoObject.ConferenceID)
.AddParameter("@GRNo", dtoObject.GRNo)
.AddParameter("@ConferenceTypeID", dtoObject.ConferenceTypeID)
.AddParameter("@CheckInDate", dtoObject.CheckInDate)
.AddParameter("@CheckOutDate", dtoObject.CheckOutDate)
.AddParameter("@IsOpenToShareRoom", dtoObject.IsOpenToShareRoom)
.AddParameter("@ActualCheckInDate", dtoObject.ActualCheckInDate)
.AddParameter("@ActualCheckOutDate", dtoObject.ActualCheckOutDate)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@Gender_TermID", dtoObject.Gender_TermID)
.AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@ReservationNo", dtoObject.ReservationNo)
.AddParameter("@ReservationDate", dtoObject.ReservationDate)
.AddParameter("@AgentID", dtoObject.AgentID)
.AddParameter("@Adults", dtoObject.Adults)
.AddParameter("@Children", dtoObject.Children)
.AddParameter("@Infant", dtoObject.Infant)
.AddParameter("@DiscountID", dtoObject.DiscountID)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@IsLockRates", dtoObject.IsLockRates)
.AddParameter("@IsLocked", dtoObject.IsLocked)
.AddParameter("@LockedBy", dtoObject.LockedBy)
.AddParameter("@IsMoveRoomAllowed", dtoObject.IsMoveRoomAllowed)
.AddParameter("@IsDateAdjustable", dtoObject.IsDateAdjustable)
.AddParameter("@IsOverbooked", dtoObject.IsOverbooked)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@SourceOfBusiness_TermID", dtoObject.SourceOfBusiness_TermID)
.AddParameter("@RefInvestorID", dtoObject.RefInvestorID)
.AddParameter("@IsToPickup", dtoObject.IsToPickup)
.AddParameter("@SpecificNote", dtoObject.SpecificNote)
.AddParameter("@BookedBy", dtoObject.BookedBy)
.AddParameter("@IsComplimentoryReservation", dtoObject.IsComplimentoryReservation)
.AddParameter("@ComplimentoryReferenceBy", dtoObject.ComplimentoryReferenceBy)
.AddParameter("@BillingInstruction_TermID", dtoObject.BillingInstruction_TermID)
.AddParameter("@BookingRefAgentID", dtoObject.BookingRefAgentID)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@RestStatus_TermID", dtoObject.RestStatus_TermID)

                                                .WithTransaction(dbtr)
                                                .FetchAll<ReservationUpdateLog>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ReservationUpdateLogSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<ReservationUpdateLog>();
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

        public List<ReservationUpdateLog> SelectAll()
        {
            List<ReservationUpdateLog> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.ReservationUpdateLogSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<ReservationUpdateLog>();
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
        public DataSet SelectAllWithDataSet(ReservationUpdateLog dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.ReservationUpdateLogSelectAll)
                                                .AddParameter("@ReservationUpdateLogID", dtoObject.ReservationUpdateLogID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@RefReservationID", dtoObject.RefReservationID)
.AddParameter("@ReservationType_TermID", dtoObject.ReservationType_TermID)
.AddParameter("@GroupReservationID", dtoObject.GroupReservationID)
.AddParameter("@GroupID", dtoObject.GroupID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@RefRoomID", dtoObject.RefRoomID)
.AddParameter("@ConferenceID", dtoObject.ConferenceID)
.AddParameter("@GRNo", dtoObject.GRNo)
.AddParameter("@ConferenceTypeID", dtoObject.ConferenceTypeID)
.AddParameter("@CheckInDate", dtoObject.CheckInDate)
.AddParameter("@CheckOutDate", dtoObject.CheckOutDate)
.AddParameter("@IsOpenToShareRoom", dtoObject.IsOpenToShareRoom)
.AddParameter("@ActualCheckInDate", dtoObject.ActualCheckInDate)
.AddParameter("@ActualCheckOutDate", dtoObject.ActualCheckOutDate)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@Gender_TermID", dtoObject.Gender_TermID)
.AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@ReservationNo", dtoObject.ReservationNo)
.AddParameter("@ReservationDate", dtoObject.ReservationDate)
.AddParameter("@AgentID", dtoObject.AgentID)
.AddParameter("@Adults", dtoObject.Adults)
.AddParameter("@Children", dtoObject.Children)
.AddParameter("@Infant", dtoObject.Infant)
.AddParameter("@DiscountID", dtoObject.DiscountID)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@IsLockRates", dtoObject.IsLockRates)
.AddParameter("@IsLocked", dtoObject.IsLocked)
.AddParameter("@LockedBy", dtoObject.LockedBy)
.AddParameter("@IsMoveRoomAllowed", dtoObject.IsMoveRoomAllowed)
.AddParameter("@IsDateAdjustable", dtoObject.IsDateAdjustable)
.AddParameter("@IsOverbooked", dtoObject.IsOverbooked)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@SourceOfBusiness_TermID", dtoObject.SourceOfBusiness_TermID)
.AddParameter("@RefInvestorID", dtoObject.RefInvestorID)
.AddParameter("@IsToPickup", dtoObject.IsToPickup)
.AddParameter("@SpecificNote", dtoObject.SpecificNote)
.AddParameter("@BookedBy", dtoObject.BookedBy)
.AddParameter("@IsComplimentoryReservation", dtoObject.IsComplimentoryReservation)
.AddParameter("@ComplimentoryReferenceBy", dtoObject.ComplimentoryReferenceBy)
.AddParameter("@BillingInstruction_TermID", dtoObject.BillingInstruction_TermID)
.AddParameter("@BookingRefAgentID", dtoObject.BookingRefAgentID)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@RestStatus_TermID", dtoObject.RestStatus_TermID)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ReservationUpdateLogSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.ReservationUpdateLogSelectAll)
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
		public bool Insert(ReservationUpdateLog dtoObject)
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

                    StoredProcedure(MasterDALConstant.ReservationUpdateLogInsert)
                        .AddParameter("@ReservationUpdateLogID", dtoObject.ReservationUpdateLogID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@RefReservationID", dtoObject.RefReservationID)
.AddParameter("@ReservationType_TermID", dtoObject.ReservationType_TermID)
.AddParameter("@GroupReservationID", dtoObject.GroupReservationID)
.AddParameter("@GroupID", dtoObject.GroupID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@RefRoomID", dtoObject.RefRoomID)
.AddParameter("@ConferenceID", dtoObject.ConferenceID)
.AddParameter("@GRNo", dtoObject.GRNo)
.AddParameter("@ConferenceTypeID", dtoObject.ConferenceTypeID)
.AddParameter("@CheckInDate", dtoObject.CheckInDate)
.AddParameter("@CheckOutDate", dtoObject.CheckOutDate)
.AddParameter("@IsOpenToShareRoom", dtoObject.IsOpenToShareRoom)
.AddParameter("@ActualCheckInDate", dtoObject.ActualCheckInDate)
.AddParameter("@ActualCheckOutDate", dtoObject.ActualCheckOutDate)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@Gender_TermID", dtoObject.Gender_TermID)
.AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@ReservationNo", dtoObject.ReservationNo)
.AddParameter("@ReservationDate", dtoObject.ReservationDate)
.AddParameter("@AgentID", dtoObject.AgentID)
.AddParameter("@Adults", dtoObject.Adults)
.AddParameter("@Children", dtoObject.Children)
.AddParameter("@Infant", dtoObject.Infant)
.AddParameter("@DiscountID", dtoObject.DiscountID)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@IsLockRates", dtoObject.IsLockRates)
.AddParameter("@IsLocked", dtoObject.IsLocked)
.AddParameter("@LockedBy", dtoObject.LockedBy)
.AddParameter("@IsMoveRoomAllowed", dtoObject.IsMoveRoomAllowed)
.AddParameter("@IsDateAdjustable", dtoObject.IsDateAdjustable)
.AddParameter("@IsOverbooked", dtoObject.IsOverbooked)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@SourceOfBusiness_TermID", dtoObject.SourceOfBusiness_TermID)
.AddParameter("@RefInvestorID", dtoObject.RefInvestorID)
.AddParameter("@IsToPickup", dtoObject.IsToPickup)
.AddParameter("@SpecificNote", dtoObject.SpecificNote)
.AddParameter("@BookedBy", dtoObject.BookedBy)
.AddParameter("@IsComplimentoryReservation", dtoObject.IsComplimentoryReservation)
.AddParameter("@ComplimentoryReferenceBy", dtoObject.ComplimentoryReferenceBy)
.AddParameter("@BillingInstruction_TermID", dtoObject.BillingInstruction_TermID)
.AddParameter("@BookingRefAgentID", dtoObject.BookingRefAgentID)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@RestStatus_TermID", dtoObject.RestStatus_TermID)

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
        public bool Update(ReservationUpdateLog dtoObject)
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

                    StoredProcedure(MasterDALConstant.ReservationUpdateLogUpdate)
                        .AddParameter("@ReservationUpdateLogID", dtoObject.ReservationUpdateLogID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@RefReservationID", dtoObject.RefReservationID)
.AddParameter("@ReservationType_TermID", dtoObject.ReservationType_TermID)
.AddParameter("@GroupReservationID", dtoObject.GroupReservationID)
.AddParameter("@GroupID", dtoObject.GroupID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@RefRoomID", dtoObject.RefRoomID)
.AddParameter("@ConferenceID", dtoObject.ConferenceID)
.AddParameter("@GRNo", dtoObject.GRNo)
.AddParameter("@ConferenceTypeID", dtoObject.ConferenceTypeID)
.AddParameter("@CheckInDate", dtoObject.CheckInDate)
.AddParameter("@CheckOutDate", dtoObject.CheckOutDate)
.AddParameter("@IsOpenToShareRoom", dtoObject.IsOpenToShareRoom)
.AddParameter("@ActualCheckInDate", dtoObject.ActualCheckInDate)
.AddParameter("@ActualCheckOutDate", dtoObject.ActualCheckOutDate)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@Gender_TermID", dtoObject.Gender_TermID)
.AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@ReservationNo", dtoObject.ReservationNo)
.AddParameter("@ReservationDate", dtoObject.ReservationDate)
.AddParameter("@AgentID", dtoObject.AgentID)
.AddParameter("@Adults", dtoObject.Adults)
.AddParameter("@Children", dtoObject.Children)
.AddParameter("@Infant", dtoObject.Infant)
.AddParameter("@DiscountID", dtoObject.DiscountID)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@IsLockRates", dtoObject.IsLockRates)
.AddParameter("@IsLocked", dtoObject.IsLocked)
.AddParameter("@LockedBy", dtoObject.LockedBy)
.AddParameter("@IsMoveRoomAllowed", dtoObject.IsMoveRoomAllowed)
.AddParameter("@IsDateAdjustable", dtoObject.IsDateAdjustable)
.AddParameter("@IsOverbooked", dtoObject.IsOverbooked)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@SourceOfBusiness_TermID", dtoObject.SourceOfBusiness_TermID)
.AddParameter("@RefInvestorID", dtoObject.RefInvestorID)
.AddParameter("@IsToPickup", dtoObject.IsToPickup)
.AddParameter("@SpecificNote", dtoObject.SpecificNote)
.AddParameter("@BookedBy", dtoObject.BookedBy)
.AddParameter("@IsComplimentoryReservation", dtoObject.IsComplimentoryReservation)
.AddParameter("@ComplimentoryReferenceBy", dtoObject.ComplimentoryReferenceBy)
.AddParameter("@BillingInstruction_TermID", dtoObject.BillingInstruction_TermID)
.AddParameter("@BookingRefAgentID", dtoObject.BookingRefAgentID)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@RestStatus_TermID", dtoObject.RestStatus_TermID)

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
                StoredProcedure(MasterDALConstant.ReservationUpdateLogDeleteByPrimaryKey)
                    .AddParameter("@ReservationUpdateLogID"
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
        public bool Delete(ReservationUpdateLog dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.ReservationUpdateLogDeleteByPrimaryKey)
                    .AddParameter("@ReservationUpdateLogID", dtoObject.ReservationUpdateLogID)

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

        public ReservationUpdateLog SelectByPrimaryKey(Guid Keys)
        {
            ReservationUpdateLog obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationUpdateLogSelectByPrimaryKey)
                            .AddParameter("@ReservationUpdateLogID"
,Keys)
                            .Fetch<ReservationUpdateLog>();
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
        public List<ReservationUpdateLog> SelectByField(string fieldName, object value)
        {
            List<ReservationUpdateLog> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationUpdateLogSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<ReservationUpdateLog>();

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
                obj = StoredProcedure(MasterDALConstant.ReservationUpdateLogSelectByField) 
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
                StoredProcedure(MasterDALConstant.ReservationUpdateLogDeleteByField) 
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
