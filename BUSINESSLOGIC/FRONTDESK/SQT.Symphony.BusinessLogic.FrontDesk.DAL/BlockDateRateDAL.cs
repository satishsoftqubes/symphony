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
    /// Data access layer class for BlockDateRate
    /// </summary>
    public class BlockDateRateDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public BlockDateRateDAL()
            : base()
        {
            // Nothing for now.
        }
        public BlockDateRateDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<BlockDateRate> SelectAll(BlockDateRate dtoObject)
        {
            List<BlockDateRate> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.BlockDateRateSelectAll)
                                                .AddParameter("@ResBlockDateRateID", dtoObject.ResBlockDateRateID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@BlockDate", dtoObject.BlockDate)
.AddParameter("@StartDate", dtoObject.StartDate)
.AddParameter("@EndDate", dtoObject.EndDate)
.AddParameter("@PostingDate", dtoObject.PostingDate)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@RoomRate", dtoObject.RoomRate)
.AddParameter("@DiscountAmt", dtoObject.DiscountAmt)
.AddParameter("@IsFerEarly", dtoObject.IsFerEarly)
.AddParameter("@IsFerLate", dtoObject.IsFerLate)
.AddParameter("@ReRouteFolioID", dtoObject.ReRouteFolioID)
.AddParameter("@ReRouteCharge", dtoObject.ReRouteCharge)
.AddParameter("@RateCardRate", dtoObject.RateCardRate)
.AddParameter("@DiscountID", dtoObject.DiscountID)
.AddParameter("@AppliedTax", dtoObject.AppliedTax)
.AddParameter("@ConferenceID", dtoObject.ConferenceID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@ResStatus_TermID", dtoObject.ResStatus_TermID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsOverBook", dtoObject.IsOverBook)
                                                .WithTransaction(dbtr)
                                                .FetchAll<BlockDateRate>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.BlockDateRateSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<BlockDateRate>();
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

        public List<BlockDateRate> SelectAll()
        {
            List<BlockDateRate> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.BlockDateRateSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<BlockDateRate>();
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
        public DataSet SelectAllWithDataSet(BlockDateRate dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.BlockDateRateSelectAll)
                                                .AddParameter("@ResBlockDateRateID", dtoObject.ResBlockDateRateID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@BlockDate", dtoObject.BlockDate)
.AddParameter("@StartDate", dtoObject.StartDate)
.AddParameter("@EndDate", dtoObject.EndDate)
.AddParameter("@PostingDate", dtoObject.PostingDate)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@RoomRate", dtoObject.RoomRate)
.AddParameter("@DiscountAmt", dtoObject.DiscountAmt)
.AddParameter("@IsFerEarly", dtoObject.IsFerEarly)
.AddParameter("@IsFerLate", dtoObject.IsFerLate)
.AddParameter("@ReRouteFolioID", dtoObject.ReRouteFolioID)
.AddParameter("@ReRouteCharge", dtoObject.ReRouteCharge)
.AddParameter("@RateCardRate", dtoObject.RateCardRate)
.AddParameter("@DiscountID", dtoObject.DiscountID)
.AddParameter("@AppliedTax", dtoObject.AppliedTax)
.AddParameter("@ConferenceID", dtoObject.ConferenceID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@ResStatus_TermID", dtoObject.ResStatus_TermID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsOverBook", dtoObject.IsOverBook)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.BlockDateRateSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.BlockDateRateSelectAll)
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
        public bool Insert(BlockDateRate dtoObject)
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

                    StoredProcedure(MasterDALConstant.BlockDateRateInsert)
                        .AddParameter("@ResBlockDateRateID", dtoObject.ResBlockDateRateID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@BlockDate", dtoObject.BlockDate)
.AddParameter("@StartDate", dtoObject.StartDate)
.AddParameter("@EndDate", dtoObject.EndDate)
.AddParameter("@PostingDate", dtoObject.PostingDate)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@RoomRate", dtoObject.RoomRate)
.AddParameter("@DiscountAmt", dtoObject.DiscountAmt)
.AddParameter("@IsFerEarly", dtoObject.IsFerEarly)
.AddParameter("@IsFerLate", dtoObject.IsFerLate)
.AddParameter("@ReRouteFolioID", dtoObject.ReRouteFolioID)
.AddParameter("@ReRouteCharge", dtoObject.ReRouteCharge)
.AddParameter("@RateCardRate", dtoObject.RateCardRate)
.AddParameter("@DiscountID", dtoObject.DiscountID)
.AddParameter("@AppliedTax", dtoObject.AppliedTax)
.AddParameter("@ConferenceID", dtoObject.ConferenceID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@ResStatus_TermID", dtoObject.ResStatus_TermID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsOverBook", dtoObject.IsOverBook)
.AddParameter("@IsOverStay", dtoObject.IsOverStay)
.AddParameter("@InfraServiceCharge", dtoObject.InfraServiceCharge)
.AddParameter("@FoodCharge", dtoObject.FoodCharge)
.AddParameter("@ElectricityCharge", dtoObject.ElectricityCharge)
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
        public bool Update(BlockDateRate dtoObject)
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

                    StoredProcedure(MasterDALConstant.BlockDateRateUpdate)
                        .AddParameter("@ResBlockDateRateID", dtoObject.ResBlockDateRateID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@BlockDate", dtoObject.BlockDate)
.AddParameter("@StartDate", dtoObject.StartDate)
.AddParameter("@EndDate", dtoObject.EndDate)
.AddParameter("@PostingDate", dtoObject.PostingDate)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@RoomRate", dtoObject.RoomRate)
.AddParameter("@DiscountAmt", dtoObject.DiscountAmt)
.AddParameter("@IsFerEarly", dtoObject.IsFerEarly)
.AddParameter("@IsFerLate", dtoObject.IsFerLate)
.AddParameter("@ReRouteFolioID", dtoObject.ReRouteFolioID)
.AddParameter("@ReRouteCharge", dtoObject.ReRouteCharge)
.AddParameter("@RateCardRate", dtoObject.RateCardRate)
.AddParameter("@DiscountID", dtoObject.DiscountID)
.AddParameter("@AppliedTax", dtoObject.AppliedTax)
.AddParameter("@ConferenceID", dtoObject.ConferenceID)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@ResStatus_TermID", dtoObject.ResStatus_TermID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsOverBook", dtoObject.IsOverBook)
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
                StoredProcedure(MasterDALConstant.BlockDateRateDeleteByPrimaryKey)
                    .AddParameter("@ResBlockDateRateID"
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
        public bool Delete(BlockDateRate dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.BlockDateRateDeleteByPrimaryKey)
                    .AddParameter("@ResBlockDateRateID", dtoObject.ResBlockDateRateID)

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

        public BlockDateRate SelectByPrimaryKey(Guid Keys)
        {
            BlockDateRate obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.BlockDateRateSelectByPrimaryKey)
                            .AddParameter("@ResBlockDateRateID"
, Keys)
                            .Fetch<BlockDateRate>();
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
        public List<BlockDateRate> SelectByField(string fieldName, object value)
        {
            List<BlockDateRate> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.BlockDateRateSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<BlockDateRate>();

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
                obj = StoredProcedure(MasterDALConstant.BlockDateRateSelectByField)
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
                StoredProcedure(MasterDALConstant.BlockDateRateDeleteByField)
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

        public DataSet SelectRPTRoomRentDetail(Guid? CompanyID, Guid? PropertyID, Guid? FolioID, Guid? RoomTypeID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTRoomRentRevenueDetail)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@FolioID", FolioID)
                                    .AddParameter("@RoomTypeID", RoomTypeID)
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

        public DataSet SelectRPTOccupancyChartByBlockAndRoomType(Guid? CompanyID, Guid? PropertyID, Guid? RoomTypeID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTOccupancyChartByBlockAndRoomType)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@RoomTypeID", RoomTypeID)
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

        public DataSet SelectRPTOccupancyChartByBlockAndRateCard(Guid? CompanyID, Guid? PropertyID, Guid? RoomTypeID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTOccupancyChartByBlockAndRateCard)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@RoomTypeID", RoomTypeID)
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

        public DataSet SelectRPTOccupancyChartByBlockType(Guid? CompanyID, Guid? PropertyID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTOccupancyChartByBlockType)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
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

        public DataSet SelectRPTYieldCalculation(Guid? CompanyID, Guid? PropertyID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTYieldCalculation)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
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

        public bool UpdateRoomID(Guid? ReservationID, Guid? RoomID, Guid? RoomTypeID, Guid? PropertyID, Guid? CompanyID)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.BlockDateRateUpdateRoomID)
                        .AddParameter("@ReservationID", ReservationID)
                        .AddParameter("@RoomID", RoomID)
                        .AddParameter("@RoomTypeID", RoomTypeID)
                        .AddParameter("@PropertyID", PropertyID)
                        .AddParameter("@CompanyID", CompanyID)
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

        public bool DeleteByReservationID(Guid ReservationID)
        {
            try
            {
                StoredProcedure(MasterDALConstant.BlockDateRateDeleteByReservationID)
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

        public bool DeleteUnPostedTransByReservationID(Guid reservationID)
        {
            try
            {
                StoredProcedure(MasterDALConstant.BlockDateRateDeleteUnPostedTransByReservationID)
                    .AddParameter("@ReservationID", reservationID)
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


        public bool BillingToCompany(DateTime? dtStartDate, DateTime? dtEndDate, decimal? dcDiscountRate, string strDiscountType, Guid? ReservationID, string strBillingInstruction)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {

                    StoredProcedure(MasterDALConstant.res_BlockDateRate_BillingToCompany)
                        .AddParameter("@StartDate", dtStartDate)
                        .AddParameter("@EndDate", dtEndDate)
                        .AddParameter("@DiscountRate", dcDiscountRate)
                        .AddParameter("@DiscountType", strDiscountType)
                        .AddParameter("@ReservationID", ReservationID)
                        .AddParameter("@BillingInstruction", strBillingInstruction)

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

        public decimal CalculateTax(Guid? AcctID, decimal? Amount, string TransType, Guid? UnitID, Guid? ResID, int? TaxFrom, int? Qty, string TaxIDs, Guid? PropertyID, Guid? CompanyID)
        {
            decimal dcmlReturnTaxValue = Convert.ToDecimal("0.00");
            OutputParameterCollection outputCal = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {

                    StoredProcedure(MasterDALConstant.TaxCalculator)
                        .AddParameter("@AcctID", AcctID)
                        .AddParameter("@Amount", Amount)
                        .AddParameter("@TransType", TransType)
                        .AddParameter("@UnitID", UnitID)
                        .AddParameter("@ResID", ResID)
                        .AddParameter("@TaxFrom", TaxFrom)
                        .AddParameter("@Qty", Qty)
                        .AddParameter("@TaxIDs", TaxIDs)
                        .AddParameter("@PropertyID", PropertyID)
                        .AddParameter("@CompanyID", CompanyID)
                        .AddOutParameter("@Final_Tax_Amount", dcmlReturnTaxValue)

                        .WithTransaction(dbtr)
                        .Execute(out outputCal);

                    dcmlReturnTaxValue = outputCal.GetValue("@Final_Tax_Amount").Fetch<decimal>();
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
            return dcmlReturnTaxValue;
        }

        public DataSet SelectTotalRoomRateByDatePeriod(Guid? ReservationID,DateTime? StartDate, DateTime? EndDate,Guid? PropertyID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.BlockDateRateSelectTotalRoomRateByDatePeriod)
                    .AddParameter("@ReservationID", ReservationID)
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


        public DataSet SelectData4UpgradeDowngrade(Guid? ReservationID, Guid? NewRoomTypeID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.BlockDateRateSelectData4UpgradeDowngrade )
                    .AddParameter("@ReservationID", ReservationID)
                    .AddParameter("@NewRoomTypeID", NewRoomTypeID)
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
