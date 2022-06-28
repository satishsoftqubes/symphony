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
    /// Data access layer class for Reservation
    /// </summary>
    public class ReservationDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public ReservationDAL()
            : base()
        {
            // Nothing for now.
        }
        public ReservationDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Reservation> SelectAll(Reservation dtoObject)
        {
            List<Reservation> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    if (dtoObject != null)
                        parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                    if (dtoObject != null)
                    {
                        obj = StoredProcedure(MasterDALConstant.ReservationSelectAll)
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
.AddParameter("@RestStatus_TermID", dtoObject.RestStatus_TermID)
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
.AddParameter("@ExpectedCheckOutDate", dtoObject.ExpectedCheckOutDate)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Reservation>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ReservationSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Reservation>();
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

        public List<Reservation> SelectAll()
        {
            List<Reservation> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.ReservationSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Reservation>();
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
        public DataSet SelectAllWithDataSet(Reservation dtoObject)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    if (dtoObject != null)
                        parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                    if (dtoObject != null)
                    {
                        obj = StoredProcedure(MasterDALConstant.ReservationSelectAll)
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
.AddParameter("@RestStatus_TermID", dtoObject.RestStatus_TermID)
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
.AddParameter("@ExpectedCheckOutDate", dtoObject.ExpectedCheckOutDate)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ReservationSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.ReservationSelectAll)
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
        public bool Insert(Reservation dtoObject)
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

                    StoredProcedure(MasterDALConstant.ReservationInsert)
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
.AddParameter("@RestStatus_TermID", dtoObject.RestStatus_TermID)
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
.AddParameter("@ExpectedCheckOutDate", dtoObject.ExpectedCheckOutDate)

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
        public bool Update(Reservation dtoObject)
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

                    StoredProcedure(MasterDALConstant.ReservationUpdate)
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
.AddParameter("@RestStatus_TermID", dtoObject.RestStatus_TermID)
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
.AddParameter("@UpdateMode", dtoObject.UpdateMode)
.AddParameter("@ExpectedCheckOutDate", dtoObject.ExpectedCheckOutDate)

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
                StoredProcedure(MasterDALConstant.ReservationDeleteByPrimaryKey)
                    .AddParameter("@ReservationID"
, Keys)
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
        public bool Delete(Reservation dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.ReservationDeleteByPrimaryKey)
                    .AddParameter("@ReservationID", dtoObject.ReservationID)

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

        public Reservation SelectByPrimaryKey(Guid Keys)
        {
            Reservation obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectByPrimaryKey)
                            .AddParameter("@ReservationID"
, Keys)
                            .Fetch<Reservation>();
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
        public List<Reservation> SelectByField(string fieldName, object value)
        {
            List<Reservation> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Reservation>();

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
                obj = StoredProcedure(MasterDALConstant.ReservationSelectByField)
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
                StoredProcedure(MasterDALConstant.ReservationDeleteByField)
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

        public DataSet SelectRoomResrvationChartData(DateTime? StartDate, DateTime? EndDate, Guid? RoomTypeID, Guid? PropertyID, Guid? CompanyID, int Hrs)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationDrawReservationChart)
                                    .AddParameter("@StartDate", StartDate)
                                    .AddParameter("@EndDate", EndDate)
                                    .AddParameter("@RoomTypeID", RoomTypeID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@Hrs", Hrs)
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

        public DataSet SelectReservation_GetRoomStatus(DateTime? StartDate, Guid? RoomTypeID, Guid? PropertyID, Guid? CompanyID, Guid? FloorID, Guid? WingID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.Reservation_GetRoomStatus)
                                    .AddParameter("@StartDate", StartDate)
                                    .AddParameter("@RoomTypeID", RoomTypeID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                     .AddParameter("@FloorID", FloorID)
                                      .AddParameter("@WingID", WingID)
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

        public DataSet SelectReservation_GetRoomStatusNew(DateTime? StartDate, Guid? RoomTypeID, Guid? PropertyID, Guid? CompanyID, Guid? FloorID, Guid? WingID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.Reservation_GetRoomStatusNew)
                                    .AddParameter("@StatusDate", StartDate)
                                    .AddParameter("@RoomTypeID", RoomTypeID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                     .AddParameter("@FloorID", FloorID)
                                      .AddParameter("@WingID", WingID)
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

        public DataSet SelectReservation_GetRoomStatusCount(DateTime? StartDate, Guid? RoomTypeID, Guid? PropertyID, Guid? CompanyID, Guid? FloorID, Guid? WingID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationRoomStatusCount)
                                    .AddParameter("@StatusDate", StartDate)
                                    .AddParameter("@RoomTypeID", RoomTypeID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                     .AddParameter("@FloorID", FloorID)
                                      .AddParameter("@WingID", WingID)
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

        public DataSet SelectResrvationList(Guid? ReservationID, Guid? RoomTypeID, string GuestFullName, string MobileNo, string ReservationNo, Guid? PropertyID, Guid? CompanyID, string strCompanyName, int? status, Guid? BillingInstructionID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectReservationList)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@RoomTypeID", RoomTypeID)
                                    .AddParameter("@GuestFullName", GuestFullName)
                                    .AddParameter("@MobileNo", MobileNo)
                                    .AddParameter("@ReservationNo", ReservationNo)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@CompanyName", strCompanyName)
                                    .AddParameter("@Status", status)
                                     .AddParameter("@BillingInstructionID", BillingInstructionID)
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

        public DataSet SelectResrvationViewData(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID, string strMode, string GuestFullName, string MobileNo, string ReservationNo)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectReservationViewData)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@Mode", strMode)
                                    .AddParameter("@GuestFullName", GuestFullName)
                                    .AddParameter("@MobileNo", MobileNo)
                                    .AddParameter("@ReservationNo", ReservationNo)
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

        public DataSet GetAllVacantRoom(DateTime? CheckInDate, DateTime? CheckOutDate, Guid? RoomTypeID, bool IsForTotal, string ResIds, Guid? PropertyID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                int OutTypePara = 0;
                obj = StoredProcedure(MasterDALConstant.ReservationGetAllVacantRoom)
                                    .AddParameter("@CheckInDate", CheckInDate)
                                    .AddParameter("@CheckOutDate", CheckOutDate)
                                    .AddParameter("@RoomTypeID", RoomTypeID)
                                    .AddParameter("@IsForTotal", IsForTotal)
                                    .AddParameter("@ResIds", ResIds)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddOutParameter("@Total_Vacant", OutTypePara)
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

        public DataSet SelectArrivalListData(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID, string GuestFullName, string MobileNo, string ReservationNo, DateTime? StartDate, DateTime? EndDate, string strMode, string strSymphonyValue)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectArrivalListData)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@GuestFullName", GuestFullName)
                                    .AddParameter("@MobileNo", MobileNo)
                                    .AddParameter("@ReservationNo", ReservationNo)
                                    .AddParameter("@StartDate", StartDate)
                                    .AddParameter("@EndDate", EndDate)
                                    .AddParameter("@Mode", strMode)
                                    .AddParameter("@SymphonyValue", strSymphonyValue)
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

        public DataSet GetAllIsAvailableRoom(DateTime? CheckInDate, DateTime? CheckOutDate, Guid? RoomTypeID, Guid? ReservationID, Guid? PropertyID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationIsRoomAvailable)
                                    .AddParameter("@CheckInDate", CheckInDate)
                                    .AddParameter("@CheckOutDate", CheckOutDate)
                                    .AddParameter("@RoomTypeID", RoomTypeID)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
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

        public DataSet SelectReservationVoucherData(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectReservationVoucherData)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
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

        public DataSet SelectReservationProjectTermData(Guid? PropertyID, Guid? CompanyID, string CategoryGuestType, string CategorySourceofBusiness, string CategoryTitle, string CategoryBillingInstruction, string CategoryModeofPayment)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectReservationProjectTermData)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@CategoryGuestType", CategoryGuestType)
                                    .AddParameter("@CategorySourceofBusiness", CategorySourceofBusiness)
                                    .AddParameter("@CategoryTitle", CategoryTitle)
                                    .AddParameter("@CategoryBillingInstruction", CategoryBillingInstruction)
                                    .AddParameter("@CategoryModeofPayment", CategoryModeofPayment)
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

        public DataSet SelectReservationPaymentInfo(Guid? PropertyID, Guid? CompanyID, Guid? ReservationID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectReservationPaymentInfo)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@ReservationID", ReservationID)
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
        public DataSet SelectReservationPaymentInfoForReprint(Guid? PropertyID, Guid? CompanyID, Guid? ReservationID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectReservationPaymentInfoForReprint)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@ReservationID", ReservationID)
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
        public DataSet SelectCancelReservationData(Guid? PropertyID, Guid? CompanyID, Guid? ReservationID, string GuestFullName, string MobileNo, string ReservationNo)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectCancelReservationData)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@GuestFullName", GuestFullName)
                                    .AddParameter("@MobileNo", MobileNo)
                                    .AddParameter("@ReservationNo", ReservationNo)
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

        public DataSet SelectCancellationPolicyAndGuestPayment(Guid? PropertyID, Guid? CompanyID, Guid? ReservationID, Guid? ResPolicyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectCancellationPolicyAndGuestPayment)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@ResPolicyID", ResPolicyID)
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

        public DataSet SelectDepatureListData(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID, string GuestFullName, string MobileNo, string ReservationNo, DateTime? StartDate, DateTime? EndDate, string RoomNo)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectDepatureListData)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@GuestFullName", GuestFullName)
                                    .AddParameter("@MobileNo", MobileNo)
                                    .AddParameter("@ReservationNo", ReservationNo)
                                    .AddParameter("@StartDate", StartDate)
                                    .AddParameter("@EndDate", EndDate)
                                    .AddParameter("@RoomNo", RoomNo)
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

        public DataSet ReservationSelectRoomsToSell(Guid? RoomTypeID, DateTime? EntryDate, DateTime? SecondDate, bool? IsForOB, string ResIds, Guid? PropertyID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectRoomsToSell)
                                    .AddParameter("@RoomTypeID", RoomTypeID)
                                    .AddParameter("@EntryDate", EntryDate)
                                    .AddParameter("@SecondDate", SecondDate)
                                    .AddParameter("@IsForOB", IsForOB)
                                    .AddParameter("@ResIds", ResIds)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
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

        public DataSet ReservationGetAllVacantRoom(DateTime? CheckInDate, DateTime? CheckOutDate, Guid? RoomTypeID, bool? IsForTotal, int? Total_Vacant, string ResIds, Guid? CompanyID, Guid? PropertyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectGetAllVacantRoom)
                                    .AddParameter("@CheckInDate", CheckInDate)
                                    .AddParameter("@CheckOutDate", CheckOutDate)
                                    .AddParameter("@RoomTypeID", RoomTypeID)
                                    .AddParameter("@IsForTotal", IsForTotal)
                                    .AddParameter("@Total_Vacant", Total_Vacant)
                                    .AddParameter("@ResIds", ResIds)
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

        public DataSet ReservationGetReservations(string ResNo, string FName, string LName, DateTime? CheckInDate, DateTime? CheckOutDate, Guid? RoomTypeID, Guid? RoomID, Guid? ConferenceTypeID, Guid? ConferenceID, int? Status_TermID, Guid? AgentID, DateTime? DateValue, DateTime? Todays, string RoomNo, DateTime? Upto, int? FilterID, Guid? CompanyID, Guid? PropertyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectGetReservations)
                                    .AddParameter("@ResNo", ResNo)
                                    .AddParameter("@FName", FName)
                                    .AddParameter("@LName", LName)
                                    .AddParameter("@CheckInDate", CheckInDate)
                                    .AddParameter("@CheckOutDate", CheckOutDate)
                                    .AddParameter("@RoomTypeID", RoomTypeID)
                                    .AddParameter("@RoomID", RoomID)
                                    .AddParameter("@ConferenceTypeID", ConferenceTypeID)
                                    .AddParameter("@ConferenceID", ConferenceID)
                                    .AddParameter("@Status_TermID", Status_TermID)
                                    .AddParameter("@AgentID", AgentID)
                                    .AddParameter("@DateValue", DateValue)
                                    .AddParameter("@Todays", Todays)
                                    .AddParameter("@RoomNo", RoomNo)
                                    .AddParameter("@Upto", Upto)
                                    .AddParameter("@FilterID", FilterID)
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

        public DataSet RoomBlockSelectAllBlockRooms(DateTime? StartDate, DateTime? EndDate, Guid? RoomTypeID, DateTime? SelDate, Guid? PropertyID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RoomBlockSelectAllBlockRoomsForReservation)
                                    .AddParameter("@StartDate", StartDate)
                                    .AddParameter("@EndDate", EndDate)
                                    .AddParameter("@RoomTypeID", RoomTypeID)
                                    .AddParameter("@SelDate", SelDate)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
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

        public DataSet ReservationTodaysAvailabilityChart(Guid? RoomTypeID, DateTime? EntryDate, DateTime? SecondDate, bool? IsForOB, string ResIds, Guid? PropertyID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationTodaysAvailabilityChart)
                                    .AddParameter("@RoomTypeID", RoomTypeID)
                                    .AddParameter("@EntryDate", EntryDate)
                                    .AddParameter("@SecondDate", SecondDate)
                                    .AddParameter("@IsForOB", IsForOB)
                                    .AddParameter("@ResIds", ResIds)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
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

        public DataSet SelectCheckInVoucherData(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectCheckInVoucherData)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
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

        public DataSet SelectReservationDetailByReservationNo(string ReservationNo, string GuestName)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectReservationDetailByReservationNo)
                    .AddParameter("@ReservationNo", ReservationNo)
                    .AddParameter("@GuestFullName", GuestName)
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

        public DataSet SelectDetailForFeedback(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectDetailForFeedback)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)

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

        public bool DeleteBlockDateRateAndResServiceListDataByReservationID(Guid? ReservationID)
        {
            try
            {
                StoredProcedure(MasterDALConstant.ReservationDeleteBlockDateRateAndResServiceListData)
                                    .AddParameter("@ReservationID", ReservationID)
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

        public DataSet SelectAmendReservationListData(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID, string Mode, string GuestFullName, string MobileNo, string ReservationNo, DateTime? CheckInDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectAmendReservationListData)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@Mode", Mode)
                                    .AddParameter("@GuestFullName", GuestFullName)
                                    .AddParameter("@MobileNo", MobileNo)
                                    .AddParameter("@ReservationNo", ReservationNo)
                                    .AddParameter("@CheckInDate", CheckInDate)

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

        public DataSet GetAllUnpostedCharges(Guid? ReservationID, Guid? SendFolioID, bool? IsForSingleInv)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationGetAllUnpostedCharges)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@SendFolioID", SendFolioID)
                                    .AddParameter("@ForSingleInv", IsForSingleInv)
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

        public DataSet SelectSwapRoomList(Guid? PropertyID, Guid? CompanyID, string GuestFullName, string ReservationNo, string RoomNo, Guid? RoomTypeID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectSwapRoomList)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@GuestFullName", GuestFullName)
                                    .AddParameter("@ReservationNo", ReservationNo)
                                    .AddParameter("@RoomNo", RoomNo)
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

        public DataSet SelectRPTRoomHistory(Guid? CompanyID, Guid? PropertyID, Guid? RoomID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTRoomHistory)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@RoomID", RoomID)
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

        public DataSet SelectCheckOutVoucherData(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectCheckOutVoucherData)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
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

        public DataSet SelectCheckInRoomNoAndReservationNo(Guid? PropertyID, Guid? CompanyID, string ReservationNo)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectCheckInRoomNoAndReservationNo)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@ReservationNo", ReservationNo)
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

        public DataSet Reservation_SymphonySelectReservation(Guid? ReservationID, string ReservationNo, Guid? AgentID, DateTime? CheckInDate, DateTime? CheckOutDate, Guid? ConferenceID, Guid? ConferenceTypeID, Guid? GroupID, Guid? GuestID, Guid? RefReservationID, DateTime? ReservationDate, Guid? RoomID, Guid? RoomTypeID, bool? IsForChart, int? Status_TermID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.Reservation_SymphonySelectReservation)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@ReservationNo", ReservationNo)
                                    .AddParameter("@AgentID", AgentID)
                                    .AddParameter("@CheckInDate", CheckInDate)
                                    .AddParameter("@CheckOutDate", CheckOutDate)
                                    .AddParameter("@ConferenceID", ConferenceID)
                                    .AddParameter("@ConferenceTypeID", ConferenceTypeID)
                                    .AddParameter("@GroupID", GroupID)
                                    .AddParameter("@GuestID", GuestID)
                                    .AddParameter("@RefReservationID", RefReservationID)
                                    .AddParameter("@ReservationDate", ReservationDate)
                                    .AddParameter("@RoomID", RoomID)
                                    .AddParameter("@RoomTypeID", RoomTypeID)
                                    .AddParameter("@IsForChart", IsForChart)
                                    .AddParameter("@Status_TermID", Status_TermID)
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

        public bool UpdateAgentID(Guid ReservationID, Guid AgentID, Guid PropertyID, Guid CompanyID, DateTime UpdatedOn, Guid UpdatedBy)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.Reservation_Update_AgentID)
                        .AddParameter("@ReservationID", ReservationID)
                        .AddParameter("@AgentID", AgentID)
                        .AddParameter("@PropertyID", PropertyID)
                        .AddParameter("@CompanyID", CompanyID)
                        .AddParameter("@UpdatedOn", UpdatedOn)
                        .AddParameter("@UpdatedBy", UpdatedBy)
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

        public DataSet SelectReservationsForExtendStay(DateTime? CheckInDate, DateTime? CheckOutDate, Guid? RoomTypeID, Guid? RoomID, int? Status_TermID, Guid? CompanyID, Guid? PropertyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.Reservation_SelectReservationsForExtendStay)
                                    .AddParameter("@CheckInDate", CheckInDate)
                                    .AddParameter("@CheckOutDate", CheckOutDate)
                                    .AddParameter("@RoomTypeID", RoomTypeID)
                                    .AddParameter("@RoomID", RoomID)
                                    .AddParameter("@Status_TermID", Status_TermID)
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

        public DataSet SelectReservationPaymentInfo4ExtendStay(Guid? PropertyID, Guid? CompanyID, Guid? ReservationID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectReservationPaymentInfo4ExtendStay)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@ReservationID", ReservationID)
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

        public DataSet SelectReservationAmendHistoryData(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID, string Mode, string GuestFullName, string MobileNo, string ReservationNo, DateTime? CheckInDate, string AmendmentBy, DateTime? AmendmentDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationAmendHistoryData)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@Mode", Mode)
                                    .AddParameter("@GuestFullName", GuestFullName)
                                    .AddParameter("@MobileNo", MobileNo)
                                    .AddParameter("@ReservationNo", ReservationNo)
                                    .AddParameter("@CheckInDate", CheckInDate)
                                    .AddParameter("@AmendmentBy", AmendmentBy)
                                    .AddParameter("@AmendmentDate", AmendmentDate)
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

        public DataSet SelectReservation4CompanyInvoice(DateTime startDate, DateTime endDate, Guid? ReservationID, Guid? AgentID, Guid? PropertyID, Guid? CompanyID, Guid? BillingInstructionID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectAll4CompanyInvoice)
                                    .AddParameter("@StartDate", startDate)
                                    .AddParameter("@EndDate", endDate)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@AgentID", AgentID)
                                    .AddParameter("@BillingInstructionID", BillingInstructionID)
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

        public DataSet SelectReservationInfo4CompanyInvoice(Guid ReservationID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectReservationInfo4CompanyInvoice)
                                    .AddParameter("@ReservationID", ReservationID)
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

        public DataSet SelectBillingInstructionTermStatus(Guid ReservationID, Guid CompanyID, Guid PropertyID, bool IsFullBillToGuest)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationSelectBillingInstructionTermStatus)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@IsFullBillToGuest", IsFullBillToGuest)
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

        public DataSet SearchRoomAndKey(Guid PropertyID, string SearchType, string SearchText)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RoomSearchRoomAndKey)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@SearchType", SearchType)
                                    .AddParameter("@SearchText", SearchText)
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

        public DataSet SelectNoOfRoomAndOccupiedRoom(Guid CompanyID, Guid PropertyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.res_GetNoOfOccupiedAndNoOfBeds)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
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
        public DataSet SelectCreditCardWiseCollection(Guid CompanyID, Guid PropertyID, Guid? FolioID, DateTime? StartDate, DateTime? EndDate, bool IsDetailReport, DateTime? TranscationDateForDetail, string GuestNameForDR, Guid? AcctIDForDR, string GuestFullName, string CardNo)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.CreditCardWiseCollectionReport)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@FolioID", FolioID)
                                    .AddParameter("@StartDate", StartDate)
                                    .AddParameter("@EndDate", EndDate)
                                    .AddParameter("@IsDetailReport", IsDetailReport)
                                    .AddParameter("@TranscationDateForDetail", TranscationDateForDetail)
                                    .AddParameter("@GuestNameForDR", GuestNameForDR)
                                    .AddParameter("@AcctIDForDR", AcctIDForDR)
                                    .AddParameter("@GuestName", GuestFullName)
                                    .AddParameter("@CardNo", CardNo)
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
        public DataSet SelectCompanyPostingReportData(DateTime? StartDate,DateTime? EndDate,Guid? CorporateID,Guid CompanyID, Guid PropertyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReportCompanyPosting)
                                    .AddParameter("@StartDate", StartDate)
                                    .AddParameter("@EndDate", EndDate)
                                    .AddParameter("@CorporateID", CorporateID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
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

        public DataSet SelectRetentionChargePercent(Guid ReservationID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationGetRetentionChargePercent)
                                    .AddParameter("@ReservationID", ReservationID)
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

        public DataSet GetNoOfRoomNights(DateTime startDate, DateTime endDate, string roomNightStatus, Guid? RatecardID, string ResStatus)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationGetNoOfRoomNights)
                                    .AddParameter("@startDate", startDate)
                                    .AddParameter("@endDate", endDate)
                                    .AddParameter("@roomNightStatus", roomNightStatus)
                                    .AddParameter("@RatecardID", RatecardID)
                                    .AddParameter("@ResStatus", ResStatus)
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

        public DataSet GetTotalNumOfOverstayDays(Guid ReservationID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.Reservation_GetTotalNumOfOverstayDays)
                                    .AddParameter("@ReservationID", ReservationID)
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

        public DataSet GetGuestEmail4OverstayNotification()
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.Reservation_Get4OverstayNotification)
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

        public DataSet GetTotalNumOfOverstayCharge(Guid ReservationID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.Reservation_GetTotalNumOfOverstayCharge)
                                    .AddParameter("@ReservationID", ReservationID)
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

        public bool UpdateOverStayStatusAfterPayment(Guid ReservationID)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.Reservation_Update_OverStayStatusAfterPayment)
                        .AddParameter("@ReservationID", ReservationID)
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

        public bool UpdateWronglyAssignedRoomNo(Guid ReservationID, Guid RoomID)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.Reservation_UpdateWronglyAssignedRoomNo)
                        .AddParameter("@ReservationID", ReservationID)
                        .AddParameter("@RoomID", RoomID)
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

        public DataSet GetInfraServiceChargeReport(Guid CompanyID, Guid PropertyID, DateTime? StartDate, DateTime? EndDate,string ReportType)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTInfraServiceCharges)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@StartDate", StartDate)
                                    .AddParameter("@EndDate", EndDate)
                                    .AddParameter("@ReportType", ReportType)
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

        public DataSet SearchRoomByRoomNo(string strRoomNo, Guid ReservationID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.Room_SearchRoomByRoomNo)
                                    .AddParameter("@RoomNo", strRoomNo)
                                    .AddParameter("@ReservationID", ReservationID)
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
