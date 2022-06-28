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
    /// Data access layer class for RoomType
    /// </summary>
    public class RoomTypeDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public RoomTypeDAL()
            : base()
        {
            // Nothing for now.
        }
        public RoomTypeDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<RoomType> SelectAll(RoomType dtoObject)
        {
            List<RoomType> obj = null;
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
                        obj = StoredProcedure(MasterConstant.RoomTypeSelectAll)
                                                .AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
//.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@RoomTypeCode", dtoObject.RoomTypeCode)
.AddParameter("@RoomTypeName", dtoObject.RoomTypeName)
.AddParameter("@ElevationDrawing", dtoObject.ElevationDrawing)
.AddParameter("@IsBlock", dtoObject.IsBlock)
.AddParameter("@RackRate", dtoObject.RackRate)
.AddParameter("@CreditLimit", dtoObject.CreditLimit)
.AddParameter("@SoftRooms", dtoObject.SoftRooms)
.AddParameter("@MaxWaitingList", dtoObject.MaxWaitingList)
.AddParameter("@Overbooking", dtoObject.Overbooking)
.AddParameter("@ReleaseDays", dtoObject.ReleaseDays)
.AddParameter("@DefaultRateID", dtoObject.DefaultRateID)
.AddParameter("@CoverageCodeID", dtoObject.CoverageCodeID)
.AddParameter("@MinimumStay", dtoObject.MinimumStay)
.AddParameter("@MaximumStay", dtoObject.MaximumStay)
.AddParameter("@IsDiscountApplicable", dtoObject.IsDiscountApplicable)
.AddParameter("@MaximumAdults", dtoObject.MaximumAdults)
.AddParameter("@MaximumChilds", dtoObject.MaximumChilds)
.AddParameter("@IsAvailableOnIRS", dtoObject.IsAvailableOnIRS)
.AddParameter("@RoomTypeImage", dtoObject.RoomTypeImage)
.AddParameter("@AboutRoomType", dtoObject.AboutRoomType)
.AddParameter("@CancellationCharges", dtoObject.CancellationCharges)
.AddParameter("@IsCancellationInPereentege", dtoObject.IsCancellationInPereentege)
.AddParameter("@RetentionCharge", dtoObject.RetentionCharge)
.AddParameter("@IsRetentionInPercentage", dtoObject.IsRetentionInPercentage)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedLog", dtoObject.UpdatedLog)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@ImagePath", dtoObject.ImagePath)
.AddParameter("@IsOBInPercentage", dtoObject.IsOBInPercentage)
.AddParameter("@SBArea", dtoObject.SBArea)
.AddParameter("@CarpetArea", dtoObject.CarpetArea)
.AddParameter("@PerFlat_TermID", dtoObject.PerFlat_TermID)
.AddParameter("@NoOfBeds", dtoObject.NoOfBeds)
.AddParameter("@BedSize", dtoObject.BedSize)
.AddParameter("@IsExtraBedAllow", dtoObject.IsExtraBedAllow)
.AddParameter("@NoOfExtraBed", dtoObject.NoOfExtraBed)

                                                .WithTransaction(dbtr)
                                                .FetchAll<RoomType>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.RoomTypeSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<RoomType>();
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

        public List<RoomType> SelectAll()
        {
            List<RoomType> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.RoomTypeSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<RoomType>();
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
        public DataSet SelectAllWithDataSet(RoomType dtoObject)
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
                        obj = StoredProcedure(MasterConstant.RoomTypeSelectAll)
                                                .AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
//.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@RoomTypeCode", dtoObject.RoomTypeCode)
.AddParameter("@RoomTypeName", dtoObject.RoomTypeName)
.AddParameter("@ElevationDrawing", dtoObject.ElevationDrawing)
.AddParameter("@IsBlock", dtoObject.IsBlock)
.AddParameter("@RackRate", dtoObject.RackRate)
.AddParameter("@CreditLimit", dtoObject.CreditLimit)
.AddParameter("@SoftRooms", dtoObject.SoftRooms)
.AddParameter("@MaxWaitingList", dtoObject.MaxWaitingList)
.AddParameter("@Overbooking", dtoObject.Overbooking)
.AddParameter("@ReleaseDays", dtoObject.ReleaseDays)
.AddParameter("@DefaultRateID", dtoObject.DefaultRateID)
.AddParameter("@CoverageCodeID", dtoObject.CoverageCodeID)
.AddParameter("@MinimumStay", dtoObject.MinimumStay)
.AddParameter("@MaximumStay", dtoObject.MaximumStay)
.AddParameter("@IsDiscountApplicable", dtoObject.IsDiscountApplicable)
.AddParameter("@MaximumAdults", dtoObject.MaximumAdults)
.AddParameter("@MaximumChilds", dtoObject.MaximumChilds)
.AddParameter("@IsAvailableOnIRS", dtoObject.IsAvailableOnIRS)
.AddParameter("@RoomTypeImage", dtoObject.RoomTypeImage)
.AddParameter("@AboutRoomType", dtoObject.AboutRoomType)
.AddParameter("@CancellationCharges", dtoObject.CancellationCharges)
.AddParameter("@IsCancellationInPereentege", dtoObject.IsCancellationInPereentege)
.AddParameter("@RetentionCharge", dtoObject.RetentionCharge)
.AddParameter("@IsRetentionInPercentage", dtoObject.IsRetentionInPercentage)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedLog", dtoObject.UpdatedLog)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@ImagePath", dtoObject.ImagePath)
.AddParameter("@IsOBInPercentage", dtoObject.IsOBInPercentage)
.AddParameter("@SBArea", dtoObject.SBArea)
.AddParameter("@CarpetArea", dtoObject.CarpetArea)
.AddParameter("@PerFlat_TermID", dtoObject.PerFlat_TermID)
.AddParameter("@NoOfBeds", dtoObject.NoOfBeds)
.AddParameter("@BedSize", dtoObject.BedSize)
.AddParameter("@IsExtraBedAllow", dtoObject.IsExtraBedAllow)
.AddParameter("@NoOfExtraBed", dtoObject.NoOfExtraBed)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.RoomTypeSelectAll)
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

                    obj = StoredProcedure(MasterConstant.RoomTypeSelectAll)
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
        public bool Insert(RoomType dtoObject)
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

                    StoredProcedure(MasterConstant.RoomTypeInsert)
                        .AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@RoomTypeCode", dtoObject.RoomTypeCode)
.AddParameter("@RoomTypeName", dtoObject.RoomTypeName)
.AddParameter("@ElevationDrawing", dtoObject.ElevationDrawing)
.AddParameter("@IsBlock", dtoObject.IsBlock)
.AddParameter("@RackRate", dtoObject.RackRate)
.AddParameter("@CreditLimit", dtoObject.CreditLimit)
.AddParameter("@SoftRooms", dtoObject.SoftRooms)
.AddParameter("@MaxWaitingList", dtoObject.MaxWaitingList)
.AddParameter("@Overbooking", dtoObject.Overbooking)
.AddParameter("@ReleaseDays", dtoObject.ReleaseDays)
.AddParameter("@DefaultRateID", dtoObject.DefaultRateID)
.AddParameter("@CoverageCodeID", dtoObject.CoverageCodeID)
.AddParameter("@MinimumStay", dtoObject.MinimumStay)
.AddParameter("@MaximumStay", dtoObject.MaximumStay)
.AddParameter("@IsDiscountApplicable", dtoObject.IsDiscountApplicable)
.AddParameter("@MaximumAdults", dtoObject.MaximumAdults)
.AddParameter("@MaximumChilds", dtoObject.MaximumChilds)
.AddParameter("@IsAvailableOnIRS", dtoObject.IsAvailableOnIRS)
.AddParameter("@RoomTypeImage", dtoObject.RoomTypeImage)
.AddParameter("@AboutRoomType", dtoObject.AboutRoomType)
.AddParameter("@CancellationCharges", dtoObject.CancellationCharges)
.AddParameter("@IsCancellationInPereentege", dtoObject.IsCancellationInPereentege)
.AddParameter("@RetentionCharge", dtoObject.RetentionCharge)
.AddParameter("@IsRetentionInPercentage", dtoObject.IsRetentionInPercentage)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@ImagePath", dtoObject.ImagePath)
.AddParameter("@IsOBInPercentage", dtoObject.IsOBInPercentage)
.AddParameter("@SBArea", dtoObject.SBArea)
.AddParameter("@CarpetArea", dtoObject.CarpetArea)
.AddParameter("@PerFlat_TermID", dtoObject.PerFlat_TermID)
.AddParameter("@NoOfBeds", dtoObject.NoOfBeds)
.AddParameter("@BedSize", dtoObject.BedSize)
.AddParameter("@IsExtraBedAllow", dtoObject.IsExtraBedAllow)
.AddParameter("@NoOfExtraBed", dtoObject.NoOfExtraBed)

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
        public bool Update(RoomType dtoObject)
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

                    StoredProcedure(MasterConstant.RoomTypeUpdate)
                        .AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@RoomTypeCode", dtoObject.RoomTypeCode)
.AddParameter("@RoomTypeName", dtoObject.RoomTypeName)
.AddParameter("@ElevationDrawing", dtoObject.ElevationDrawing)
.AddParameter("@IsBlock", dtoObject.IsBlock)
.AddParameter("@RackRate", dtoObject.RackRate)
.AddParameter("@CreditLimit", dtoObject.CreditLimit)
.AddParameter("@SoftRooms", dtoObject.SoftRooms)
.AddParameter("@MaxWaitingList", dtoObject.MaxWaitingList)
.AddParameter("@Overbooking", dtoObject.Overbooking)
.AddParameter("@ReleaseDays", dtoObject.ReleaseDays)
.AddParameter("@DefaultRateID", dtoObject.DefaultRateID)
.AddParameter("@CoverageCodeID", dtoObject.CoverageCodeID)
.AddParameter("@MinimumStay", dtoObject.MinimumStay)
.AddParameter("@MaximumStay", dtoObject.MaximumStay)
.AddParameter("@IsDiscountApplicable", dtoObject.IsDiscountApplicable)
.AddParameter("@MaximumAdults", dtoObject.MaximumAdults)
.AddParameter("@MaximumChilds", dtoObject.MaximumChilds)
.AddParameter("@IsAvailableOnIRS", dtoObject.IsAvailableOnIRS)
.AddParameter("@RoomTypeImage", dtoObject.RoomTypeImage)
.AddParameter("@AboutRoomType", dtoObject.AboutRoomType)
.AddParameter("@CancellationCharges", dtoObject.CancellationCharges)
.AddParameter("@IsCancellationInPereentege", dtoObject.IsCancellationInPereentege)
.AddParameter("@RetentionCharge", dtoObject.RetentionCharge)
.AddParameter("@IsRetentionInPercentage", dtoObject.IsRetentionInPercentage)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedLog", dtoObject.UpdatedLog)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@ImagePath", dtoObject.ImagePath)
.AddParameter("@IsOBInPercentage", dtoObject.IsOBInPercentage)
.AddParameter("@SBArea", dtoObject.SBArea)
.AddParameter("@CarpetArea", dtoObject.CarpetArea)
.AddParameter("@PerFlat_TermID", dtoObject.PerFlat_TermID)
.AddParameter("@NoOfBeds", dtoObject.NoOfBeds)
.AddParameter("@BedSize", dtoObject.BedSize)
.AddParameter("@IsExtraBedAllow", dtoObject.IsExtraBedAllow)
.AddParameter("@NoOfExtraBed", dtoObject.NoOfExtraBed)

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
                StoredProcedure(MasterConstant.RoomTypeDeleteByPrimaryKey)
                    .AddParameter("@RoomTypeID"
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
        public bool Delete(RoomType dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.RoomTypeDeleteByPrimaryKey)
                    .AddParameter("@RoomTypeID", dtoObject.RoomTypeID)

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

        public RoomType SelectByPrimaryKey(Guid Keys)
        {
            RoomType obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RoomTypeSelectByPrimaryKey)
                            .AddParameter("@RoomTypeID"
, Keys)
                            .Fetch<RoomType>();
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
        public List<RoomType> SelectByField(string fieldName, object value)
        {
            List<RoomType> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RoomTypeSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<RoomType>();

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
                obj = StoredProcedure(MasterConstant.RoomTypeSelectByField)
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
                StoredProcedure(MasterConstant.RoomTypeDeleteByField)
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

        public DataSet SelectUnitType(string UnitTypeQuery)
        {
            DataSet dst = new DataSet();
            try
            {
                dst = Query(UnitTypeQuery)
                            .WithTransaction(dbtr)
                            .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return dst;
        }

        public DataSet SelectAllForRateCard(Guid propertyID, Guid rateID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.RoomTypeSelectAllForRateCard)
                            .AddParameter("@PropertyID", propertyID)
                            .AddParameter("@RateID", rateID)

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

        public List<RoomType> SearchRoomTypeData(Guid? RoomTypeID, Guid? PropertyID, Guid? PerFlat_TermID, string RoomTypeCode, string RoomTypeName)
        {
            List<RoomType> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    //if (dtoObject != null)
                    //    parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.RoomTypeSearchData)
                                            .AddParameter("@RoomTypeID", RoomTypeID)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@RoomTypeCode", RoomTypeCode)
                                            .AddParameter("@RoomTypeName", RoomTypeName)
                                            .AddParameter("@PerFlat_TermID", PerFlat_TermID)

                                            .WithTransaction(dbtr)
                                            .FetchAll<RoomType>();
                    
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

        public DataSet SelectDistinctRoomTypeOnRoom(Guid? propertyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.RoomTypeSelectDistinctRoomTypeOnRoom)
                            .AddParameter("@PropertyID", propertyID)
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

        public DataSet SelectRoomTypeServices(Guid? propertyID, Guid? companyID, Guid? RoomTypeID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.RoomTypeSelectRoomTypeServices)
                            .AddParameter("@PropertyID", propertyID)
                            .AddParameter("@CompanyID", companyID)
                            .AddParameter("@RoomTypeID", RoomTypeID)
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
        #endregion
    }
}
