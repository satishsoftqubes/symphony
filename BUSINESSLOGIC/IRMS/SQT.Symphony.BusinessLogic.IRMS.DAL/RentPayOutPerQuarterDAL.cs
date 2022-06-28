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
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using SQT.Symphony.BusinessLogic.IRMS.COMMON;

namespace SQT.Symphony.BusinessLogic.IRMS.DAL
{
    /// <summary>
    /// Data access layer class for RentPayOutPerQuarter
    /// </summary>
    public class RentPayOutPerQuarterDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public RentPayOutPerQuarterDAL()
            : base()
        {
            // Nothing for now.
        }
        public RentPayOutPerQuarterDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<RentPayOutPerQuarter> SelectAll(RentPayOutPerQuarter dtoObject)
        {
            List<RentPayOutPerQuarter> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.RentPayOutPerQuarterSelectAll)
                                                .AddParameter("@RentPayoutID", dtoObject.RentPayoutID)
.AddParameter("@QuarterID", dtoObject.QuarterID)
.AddParameter("@TotalAreaOfComplex", dtoObject.TotalAreaOfComplex)
.AddParameter("@SelfOccupiedArea", dtoObject.SelfOccupiedArea)
.AddParameter("@AreaUnderPMS", dtoObject.AreaUnderPMS)
.AddParameter("@RoomRentCollected", dtoObject.RoomRentCollected)
.AddParameter("@InterestOnRoomRent", dtoObject.InterestOnRoomRent)
.AddParameter("@TotalAmountToDistribute", dtoObject.TotalAmountToDistribute)
.AddParameter("@PropertyManagementCharge", dtoObject.PropertyManagementCharge)
.AddParameter("@NetAmountToDistribute", dtoObject.NetAmountToDistribute)
.AddParameter("@RentYieldPerSqft", dtoObject.RentYieldPerSqft)
.AddParameter("@RentYieldPerDay", dtoObject.RentYieldPerDay)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@IsSync", dtoObject.IsSync)
.AddParameter("@SyncOn", dtoObject.SyncOn)

                                                .WithTransaction(dbtr)
                                                .FetchAll<RentPayOutPerQuarter>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.RentPayOutPerQuarterSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<RentPayOutPerQuarter>();
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

        public List<RentPayOutPerQuarter> SelectAll()
        {
            List<RentPayOutPerQuarter> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.RentPayOutPerQuarterSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<RentPayOutPerQuarter>();
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
        public DataSet SelectAllWithDataSet(RentPayOutPerQuarter dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.RentPayOutPerQuarterSelectAll)
                                                .AddParameter("@RentPayoutID", dtoObject.RentPayoutID)
.AddParameter("@QuarterID", dtoObject.QuarterID)
.AddParameter("@TotalAreaOfComplex", dtoObject.TotalAreaOfComplex)
.AddParameter("@SelfOccupiedArea", dtoObject.SelfOccupiedArea)
.AddParameter("@AreaUnderPMS", dtoObject.AreaUnderPMS)
.AddParameter("@RoomRentCollected", dtoObject.RoomRentCollected)
.AddParameter("@InterestOnRoomRent", dtoObject.InterestOnRoomRent)
.AddParameter("@TotalAmountToDistribute", dtoObject.TotalAmountToDistribute)
.AddParameter("@PropertyManagementCharge", dtoObject.PropertyManagementCharge)
.AddParameter("@NetAmountToDistribute", dtoObject.NetAmountToDistribute)
.AddParameter("@RentYieldPerSqft", dtoObject.RentYieldPerSqft)
.AddParameter("@RentYieldPerDay", dtoObject.RentYieldPerDay)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@IsSync", dtoObject.IsSync)
.AddParameter("@SyncOn", dtoObject.SyncOn)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.RentPayOutPerQuarterSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.RentPayOutPerQuarterSelectAll)
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
        public bool Insert(RentPayOutPerQuarter dtoObject)
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

                    StoredProcedure(MasterDALConstant.RentPayOutPerQuarterInsert)
                        .AddParameter("@RentPayoutID", dtoObject.RentPayoutID)
.AddParameter("@QuarterID", dtoObject.QuarterID)
.AddParameter("@TotalAreaOfComplex", dtoObject.TotalAreaOfComplex)
.AddParameter("@SelfOccupiedArea", dtoObject.SelfOccupiedArea)
.AddParameter("@AreaUnderPMS", dtoObject.AreaUnderPMS)
.AddParameter("@RoomRentCollected", dtoObject.RoomRentCollected)
.AddParameter("@InterestOnRoomRent", dtoObject.InterestOnRoomRent)
.AddParameter("@TotalAmountToDistribute", dtoObject.TotalAmountToDistribute)
.AddParameter("@PropertyManagementCharge", dtoObject.PropertyManagementCharge)
.AddParameter("@NetAmountToDistribute", dtoObject.NetAmountToDistribute)
.AddParameter("@RentYieldPerSqft", dtoObject.RentYieldPerSqft)
.AddParameter("@RentYieldPerDay", dtoObject.RentYieldPerDay)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@IsSync", dtoObject.IsSync)
.AddParameter("@SyncOn", dtoObject.SyncOn)
.AddParameter("@ServiceTax", dtoObject.ServiceTax)
.AddParameter("@BankCharges", dtoObject.BankCharges)
.AddParameter("@TotalAmountToDeduct", dtoObject.TotalAmountToDeduct)
.AddParameter("@RemainingRoomRent", dtoObject.RemainingRoomRent)
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
        public bool Update(RentPayOutPerQuarter dtoObject)
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

                    StoredProcedure(MasterDALConstant.RentPayOutPerQuarterUpdate)
                        .AddParameter("@RentPayoutID", dtoObject.RentPayoutID)
.AddParameter("@QuarterID", dtoObject.QuarterID)
.AddParameter("@TotalAreaOfComplex", dtoObject.TotalAreaOfComplex)
.AddParameter("@SelfOccupiedArea", dtoObject.SelfOccupiedArea)
.AddParameter("@AreaUnderPMS", dtoObject.AreaUnderPMS)
.AddParameter("@RoomRentCollected", dtoObject.RoomRentCollected)
.AddParameter("@InterestOnRoomRent", dtoObject.InterestOnRoomRent)
.AddParameter("@TotalAmountToDistribute", dtoObject.TotalAmountToDistribute)
.AddParameter("@PropertyManagementCharge", dtoObject.PropertyManagementCharge)
.AddParameter("@NetAmountToDistribute", dtoObject.NetAmountToDistribute)
.AddParameter("@RentYieldPerSqft", dtoObject.RentYieldPerSqft)
.AddParameter("@RentYieldPerDay", dtoObject.RentYieldPerDay)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@IsSync", dtoObject.IsSync)
.AddParameter("@SyncOn", dtoObject.SyncOn)

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
                StoredProcedure(MasterDALConstant.RentPayOutPerQuarterDeleteByPrimaryKey)
                    .AddParameter("@RentPayoutID"
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
        public bool Delete(RentPayOutPerQuarter dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.RentPayOutPerQuarterDeleteByPrimaryKey)
                    .AddParameter("@RentPayoutID", dtoObject.RentPayoutID)

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

        public RentPayOutPerQuarter SelectByPrimaryKey(Guid Keys)
        {
            RentPayOutPerQuarter obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RentPayOutPerQuarterSelectByPrimaryKey)
                            .AddParameter("@RentPayoutID"
, Keys)
                            .Fetch<RentPayOutPerQuarter>();
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
        public List<RentPayOutPerQuarter> SelectByField(string fieldName, object value)
        {
            List<RentPayOutPerQuarter> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RentPayOutPerQuarterSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<RentPayOutPerQuarter>();

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
                obj = StoredProcedure(MasterDALConstant.RentPayOutPerQuarterSelectByField)
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
                StoredProcedure(MasterDALConstant.RentPayOutPerQuarterDeleteByField)
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
        public DataSet SelectRentPayoutPerQuarterData(Guid? CompanyID, Guid? InvestorID, Guid QuarterID, bool IsCallForInvestorList, string InvestorName, string CityName, string CPFirm, string CPExecutiveName)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.RentPayoutInvestorRentPayoutPerQuarter)
                     .AddParameter("@CompanyID", CompanyID)
                      .AddParameter("@InvestorID", InvestorID)
                       .AddParameter("@QuarterID", QuarterID)
                       .AddParameter("@IsCallForInvestorList", IsCallForInvestorList)
                       .AddParameter("@InvestorName", InvestorName)
                       .AddParameter("@CityName", CityName)
                       .AddParameter("@CPFirm", CPFirm)
                       .AddParameter("@CPExecutiveName", CPExecutiveName)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        #endregion
    }
}
