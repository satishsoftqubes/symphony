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
    /// Data access layer class for ReservationConfig
    /// </summary>
    public class ReservationConfigDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public ReservationConfigDAL()
            : base()
        {
            // Nothing for now.
        }
        public ReservationConfigDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<ReservationConfig> SelectAll(ReservationConfig dtoObject)
        {
            List<ReservationConfig> obj = null;
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
                        obj = StoredProcedure(MasterConstant.ReservationConfigSelectAll)
                                                .AddParameter("@ResConfigID", dtoObject.ResConfigID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsShowDepositAlertOnCheckIn", dtoObject.IsShowDepositAlertOnCheckIn)
.AddParameter("@IsShowDirtyRoomAlertOnCheckIn", dtoObject.IsShowDirtyRoomAlertOnCheckIn)
.AddParameter("@IsAutoPostFirstNightChargeAtCheckIn", dtoObject.IsAutoPostFirstNightChargeAtCheckIn)
.AddParameter("@IsGuestEMailCompulsory", dtoObject.IsGuestEMailCompulsory)
.AddParameter("@IsGuestIdentityCompulsory", dtoObject.IsGuestIdentityCompulsory)
.AddParameter("@UnConfirmedReservationRemindBeforeDays", dtoObject.UnConfirmedReservationRemindBeforeDays)
.AddParameter("@RoomReservationConfirmBeforeDays", dtoObject.RoomReservationConfirmBeforeDays)
.AddParameter("@ConferenceReservationConfirmBeforeDays", dtoObject.ConferenceReservationConfirmBeforeDays)
.AddParameter("@GroupReservationConfirmBeforeDays", dtoObject.GroupReservationConfirmBeforeDays)
.AddParameter("@IsRateInclusiveService", dtoObject.IsRateInclusiveService)
.AddParameter("@CheckInSettlementMins", dtoObject.CheckInSettlementMins)
.AddParameter("@CheckOutSettlementMins", dtoObject.CheckOutSettlementMins)
.AddParameter("@IsEnableAutoAssignRooms", dtoObject.IsEnableAutoAssignRooms)
.AddParameter("@HighWeekDays", dtoObject.HighWeekDays)
.AddParameter("@Is24HrsCheckIn", dtoObject.Is24HrsCheckIn)
.AddParameter("@CheckInTime", dtoObject.CheckInTime)
.AddParameter("@CheckOutTime", dtoObject.CheckOutTime)
.AddParameter("@ChildAgeLimit", dtoObject.ChildAgeLimit)
.AddParameter("@InfantAgeLimit", dtoObject.InfantAgeLimit)
.AddParameter("@GeneralTravelAgentComission", dtoObject.GeneralTravelAgentComission)
.AddParameter("@GeneralCorporateDiscount", dtoObject.GeneralCorporateDiscount)
.AddParameter("@ProvisionalReservationDayLimit", dtoObject.ProvisionalReservationDayLimit)
.AddParameter("@NoShowHours", dtoObject.NoShowHours)
.AddParameter("@IsCardInformationRequired", dtoObject.IsCardInformationRequired)
.AddParameter("@IsWarnOnOverBooking", dtoObject.IsWarnOnOverBooking)
.AddParameter("@IsShowDinomination", dtoObject.IsShowDinomination)
.AddParameter("@DefaultHoldType_TermID", dtoObject.DefaultHoldType_TermID)
.AddParameter("@IsApplyYield", dtoObject.IsApplyYield)
.AddParameter("@IsYieldFlat", dtoObject.IsYieldFlat)
.AddParameter("@IsTravelAgentCommissionFlat", dtoObject.IsTravelAgentCommissionFlat)
.AddParameter("@IsCorporateDiscountFlat", dtoObject.IsCorporateDiscountFlat)
.AddParameter("@CancellationPolicy", dtoObject.CancellationPolicy)
.AddParameter("@NoOfAmendmentCriteria", dtoObject.NoOfAmendmentCriteria)
.AddParameter("@MinDaysForLongstay", dtoObject.MinDaysForLongstay)
.AddParameter("@ReservationPolicy", dtoObject.ReservationPolicy)
.AddParameter("@DefaultDepositAcctID", dtoObject.DefaultDepositAcctID)
.AddParameter("@MaxCashLimitForRefund", dtoObject.MaxCashLimitForRefund)
                                                .WithTransaction(dbtr)
                                                .FetchAll<ReservationConfig>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.ReservationConfigSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<ReservationConfig>();
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

        public List<ReservationConfig> SelectAll()
        {
            List<ReservationConfig> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.ReservationConfigSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<ReservationConfig>();
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
        public DataSet SelectAllWithDataSet(ReservationConfig dtoObject)
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
                        obj = StoredProcedure(MasterConstant.ReservationConfigSelectAll)
                                                .AddParameter("@ResConfigID", dtoObject.ResConfigID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsShowDepositAlertOnCheckIn", dtoObject.IsShowDepositAlertOnCheckIn)
.AddParameter("@IsShowDirtyRoomAlertOnCheckIn", dtoObject.IsShowDirtyRoomAlertOnCheckIn)
.AddParameter("@IsAutoPostFirstNightChargeAtCheckIn", dtoObject.IsAutoPostFirstNightChargeAtCheckIn)
.AddParameter("@IsGuestEMailCompulsory", dtoObject.IsGuestEMailCompulsory)
.AddParameter("@IsGuestIdentityCompulsory", dtoObject.IsGuestIdentityCompulsory)
.AddParameter("@UnConfirmedReservationRemindBeforeDays", dtoObject.UnConfirmedReservationRemindBeforeDays)
.AddParameter("@RoomReservationConfirmBeforeDays", dtoObject.RoomReservationConfirmBeforeDays)
.AddParameter("@ConferenceReservationConfirmBeforeDays", dtoObject.ConferenceReservationConfirmBeforeDays)
.AddParameter("@GroupReservationConfirmBeforeDays", dtoObject.GroupReservationConfirmBeforeDays)
.AddParameter("@IsRateInclusiveService", dtoObject.IsRateInclusiveService)
.AddParameter("@CheckInSettlementMins", dtoObject.CheckInSettlementMins)
.AddParameter("@CheckOutSettlementMins", dtoObject.CheckOutSettlementMins)
.AddParameter("@IsEnableAutoAssignRooms", dtoObject.IsEnableAutoAssignRooms)
.AddParameter("@HighWeekDays", dtoObject.HighWeekDays)
.AddParameter("@Is24HrsCheckIn", dtoObject.Is24HrsCheckIn)
.AddParameter("@CheckInTime", dtoObject.CheckInTime)
.AddParameter("@CheckOutTime", dtoObject.CheckOutTime)
.AddParameter("@ChildAgeLimit", dtoObject.ChildAgeLimit)
.AddParameter("@InfantAgeLimit", dtoObject.InfantAgeLimit)
.AddParameter("@GeneralTravelAgentComission", dtoObject.GeneralTravelAgentComission)
.AddParameter("@GeneralCorporateDiscount", dtoObject.GeneralCorporateDiscount)
.AddParameter("@ProvisionalReservationDayLimit", dtoObject.ProvisionalReservationDayLimit)
.AddParameter("@NoShowHours", dtoObject.NoShowHours)
.AddParameter("@IsCardInformationRequired", dtoObject.IsCardInformationRequired)
.AddParameter("@IsWarnOnOverBooking", dtoObject.IsWarnOnOverBooking)
.AddParameter("@IsShowDinomination", dtoObject.IsShowDinomination)
.AddParameter("@DefaultHoldType_TermID", dtoObject.DefaultHoldType_TermID)
.AddParameter("@IsApplyYield", dtoObject.IsApplyYield)
.AddParameter("@IsYieldFlat", dtoObject.IsYieldFlat)
.AddParameter("@IsTravelAgentCommissionFlat", dtoObject.IsTravelAgentCommissionFlat)
.AddParameter("@IsCorporateDiscountFlat", dtoObject.IsCorporateDiscountFlat)
.AddParameter("@CancellationPolicy", dtoObject.CancellationPolicy)
.AddParameter("@NoOfAmendmentCriteria", dtoObject.NoOfAmendmentCriteria)
.AddParameter("@MinDaysForLongstay", dtoObject.MinDaysForLongstay)
.AddParameter("@ReservationPolicy", dtoObject.ReservationPolicy)
.AddParameter("@DefaultDepositAcctID", dtoObject.DefaultDepositAcctID)
.AddParameter("@MaxCashLimitForRefund", dtoObject.MaxCashLimitForRefund)
                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.ReservationConfigSelectAll)
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

                    obj = StoredProcedure(MasterConstant.ReservationConfigSelectAll)
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
        public bool Insert(ReservationConfig dtoObject)
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

                    StoredProcedure(MasterConstant.ReservationConfigInsert)
                        .AddParameter("@ResConfigID", dtoObject.ResConfigID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsShowDepositAlertOnCheckIn", dtoObject.IsShowDepositAlertOnCheckIn)
.AddParameter("@IsShowDirtyRoomAlertOnCheckIn", dtoObject.IsShowDirtyRoomAlertOnCheckIn)
.AddParameter("@IsAutoPostFirstNightChargeAtCheckIn", dtoObject.IsAutoPostFirstNightChargeAtCheckIn)
.AddParameter("@IsGuestEMailCompulsory", dtoObject.IsGuestEMailCompulsory)
.AddParameter("@IsGuestIdentityCompulsory", dtoObject.IsGuestIdentityCompulsory)
.AddParameter("@UnConfirmedReservationRemindBeforeDays", dtoObject.UnConfirmedReservationRemindBeforeDays)
.AddParameter("@RoomReservationConfirmBeforeDays", dtoObject.RoomReservationConfirmBeforeDays)
.AddParameter("@ConferenceReservationConfirmBeforeDays", dtoObject.ConferenceReservationConfirmBeforeDays)
.AddParameter("@GroupReservationConfirmBeforeDays", dtoObject.GroupReservationConfirmBeforeDays)
.AddParameter("@IsRateInclusiveService", dtoObject.IsRateInclusiveService)
.AddParameter("@CheckInSettlementMins", dtoObject.CheckInSettlementMins)
.AddParameter("@CheckOutSettlementMins", dtoObject.CheckOutSettlementMins)
.AddParameter("@IsEnableAutoAssignRooms", dtoObject.IsEnableAutoAssignRooms)
.AddParameter("@HighWeekDays", dtoObject.HighWeekDays)
.AddParameter("@Is24HrsCheckIn", dtoObject.Is24HrsCheckIn)
.AddParameter("@CheckInTime", dtoObject.CheckInTime)
.AddParameter("@CheckOutTime", dtoObject.CheckOutTime)
.AddParameter("@ChildAgeLimit", dtoObject.ChildAgeLimit)
.AddParameter("@InfantAgeLimit", dtoObject.InfantAgeLimit)
.AddParameter("@GeneralTravelAgentComission", dtoObject.GeneralTravelAgentComission)
.AddParameter("@GeneralCorporateDiscount", dtoObject.GeneralCorporateDiscount)
.AddParameter("@ProvisionalReservationDayLimit", dtoObject.ProvisionalReservationDayLimit)
.AddParameter("@NoShowHours", dtoObject.NoShowHours)
.AddParameter("@IsCardInformationRequired", dtoObject.IsCardInformationRequired)
.AddParameter("@IsWarnOnOverBooking", dtoObject.IsWarnOnOverBooking)
.AddParameter("@IsShowDinomination", dtoObject.IsShowDinomination)
.AddParameter("@DefaultHoldType_TermID", dtoObject.DefaultHoldType_TermID)
.AddParameter("@IsApplyYield", dtoObject.IsApplyYield)
.AddParameter("@IsYieldFlat", dtoObject.IsYieldFlat)
.AddParameter("@IsTravelAgentCommissionFlat", dtoObject.IsTravelAgentCommissionFlat)
.AddParameter("@IsCorporateDiscountFlat", dtoObject.IsCorporateDiscountFlat)
.AddParameter("@LongStayDays", dtoObject.LongStayDays)
.AddParameter("@CancellationPolicy", dtoObject.CancellationPolicy)
.AddParameter("@NoOfAmendmentCriteria", dtoObject.NoOfAmendmentCriteria)
.AddParameter("@MinDaysForLongstay", dtoObject.MinDaysForLongstay)
.AddParameter("@ReservationPolicy", dtoObject.ReservationPolicy)
.AddParameter("@DefaultDepositAcctID", dtoObject.DefaultDepositAcctID)
.AddParameter("@RetentionCharge", dtoObject.RetentionCharge)
.AddParameter("@MaxCashLimitForRefund", dtoObject.MaxCashLimitForRefund)
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
        public bool Update(ReservationConfig dtoObject)
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

                    StoredProcedure(MasterConstant.ReservationConfigUpdate)
                        .AddParameter("@ResConfigID", dtoObject.ResConfigID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsShowDepositAlertOnCheckIn", dtoObject.IsShowDepositAlertOnCheckIn)
.AddParameter("@IsShowDirtyRoomAlertOnCheckIn", dtoObject.IsShowDirtyRoomAlertOnCheckIn)
.AddParameter("@IsAutoPostFirstNightChargeAtCheckIn", dtoObject.IsAutoPostFirstNightChargeAtCheckIn)
.AddParameter("@IsGuestEMailCompulsory", dtoObject.IsGuestEMailCompulsory)
.AddParameter("@IsGuestIdentityCompulsory", dtoObject.IsGuestIdentityCompulsory)
.AddParameter("@UnConfirmedReservationRemindBeforeDays", dtoObject.UnConfirmedReservationRemindBeforeDays)
.AddParameter("@RoomReservationConfirmBeforeDays", dtoObject.RoomReservationConfirmBeforeDays)
.AddParameter("@ConferenceReservationConfirmBeforeDays", dtoObject.ConferenceReservationConfirmBeforeDays)
.AddParameter("@GroupReservationConfirmBeforeDays", dtoObject.GroupReservationConfirmBeforeDays)
.AddParameter("@IsRateInclusiveService", dtoObject.IsRateInclusiveService)
.AddParameter("@CheckInSettlementMins", dtoObject.CheckInSettlementMins)
.AddParameter("@CheckOutSettlementMins", dtoObject.CheckOutSettlementMins)
.AddParameter("@IsEnableAutoAssignRooms", dtoObject.IsEnableAutoAssignRooms)
.AddParameter("@HighWeekDays", dtoObject.HighWeekDays)
.AddParameter("@Is24HrsCheckIn", dtoObject.Is24HrsCheckIn)
.AddParameter("@CheckInTime", dtoObject.CheckInTime)
.AddParameter("@CheckOutTime", dtoObject.CheckOutTime)
.AddParameter("@ChildAgeLimit", dtoObject.ChildAgeLimit)
.AddParameter("@InfantAgeLimit", dtoObject.InfantAgeLimit)
.AddParameter("@GeneralTravelAgentComission", dtoObject.GeneralTravelAgentComission)
.AddParameter("@GeneralCorporateDiscount", dtoObject.GeneralCorporateDiscount)
.AddParameter("@ProvisionalReservationDayLimit", dtoObject.ProvisionalReservationDayLimit)
.AddParameter("@NoShowHours", dtoObject.NoShowHours)
.AddParameter("@IsCardInformationRequired", dtoObject.IsCardInformationRequired)
.AddParameter("@IsWarnOnOverBooking", dtoObject.IsWarnOnOverBooking)
.AddParameter("@IsShowDinomination", dtoObject.IsShowDinomination)
.AddParameter("@DefaultHoldType_TermID", dtoObject.DefaultHoldType_TermID)
.AddParameter("@IsApplyYield", dtoObject.IsApplyYield)
.AddParameter("@IsYieldFlat", dtoObject.IsYieldFlat)
.AddParameter("@IsTravelAgentCommissionFlat", dtoObject.IsTravelAgentCommissionFlat)
.AddParameter("@IsCorporateDiscountFlat", dtoObject.IsCorporateDiscountFlat)
.AddParameter("@LongStayDays", dtoObject.LongStayDays)
.AddParameter("@CancellationPolicy", dtoObject.CancellationPolicy)
.AddParameter("@NoOfAmendmentCriteria", dtoObject.NoOfAmendmentCriteria)
.AddParameter("@MinDaysForLongstay", dtoObject.MinDaysForLongstay)
.AddParameter("@ReservationPolicy", dtoObject.ReservationPolicy)
.AddParameter("@DefaultDepositAcctID", dtoObject.DefaultDepositAcctID)
.AddParameter("@RetentionCharge", dtoObject.RetentionCharge)
.AddParameter("@MaxCashLimitForRefund", dtoObject.MaxCashLimitForRefund)
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
                StoredProcedure(MasterConstant.ReservationConfigDeleteByPrimaryKey)
                    .AddParameter("@ResConfigID"
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
        public bool Delete(ReservationConfig dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.ReservationConfigDeleteByPrimaryKey)
                    .AddParameter("@ResConfigID", dtoObject.ResConfigID)

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

        public ReservationConfig SelectByPrimaryKey(Guid Keys)
        {
            ReservationConfig obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ReservationConfigSelectByPrimaryKey)
                            .AddParameter("@ResConfigID"
, Keys)
                            .Fetch<ReservationConfig>();
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
        public List<ReservationConfig> SelectByField(string fieldName, object value)
        {
            List<ReservationConfig> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ReservationConfigSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<ReservationConfig>();

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
                obj = StoredProcedure(MasterConstant.ReservationConfigSelectByField)
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
                StoredProcedure(MasterConstant.ReservationConfigDeleteByField)
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

        public DataSet SelectRetentionAccountID(Guid? propertyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ReservationConfigSelectRetentionAccountID)
                                    .AddParameter("@PropertyID", propertyID)
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
        public DataSet SelectMaxCashLimitForRefund(Guid? CompanyID, Guid? propertyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ReservationConfigSelectMaxCashLimitForRefund)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", propertyID)
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
