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
    /// Data access layer class for RentPayoutQuarterSetup
    /// </summary>
    public class RentPayoutQuarterSetupDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public RentPayoutQuarterSetupDAL()
            : base()
        {
            // Nothing for now.
        }
        public RentPayoutQuarterSetupDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<RentPayoutQuarterSetup> SelectAll(RentPayoutQuarterSetup dtoObject)
        {
            List<RentPayoutQuarterSetup> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.RentPayoutQuarterSetupSelectAll)
                                                .AddParameter("@QuarterID", dtoObject.QuarterID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@StartDate", dtoObject.StartDate)
.AddParameter("@EndDate", dtoObject.EndDate)
.AddParameter("@Note", dtoObject.Note)
.AddParameter("@PropertyManagementCharge", dtoObject.PropertyManagementCharge)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsSync", dtoObject.IsSync)
.AddParameter("@SyncOn", dtoObject.SyncOn)

                                                .WithTransaction(dbtr)
                                                .FetchAll<RentPayoutQuarterSetup>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.RentPayoutQuarterSetupSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<RentPayoutQuarterSetup>();
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

        public List<RentPayoutQuarterSetup> SelectAll()
        {
            List<RentPayoutQuarterSetup> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.RentPayoutQuarterSetupSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<RentPayoutQuarterSetup>();
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
        public DataSet SelectAllWithDataSet(RentPayoutQuarterSetup dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.RentPayoutQuarterSetupSelectAll)
                                                .AddParameter("@QuarterID", dtoObject.QuarterID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@StartDate", dtoObject.StartDate)
.AddParameter("@EndDate", dtoObject.EndDate)
.AddParameter("@Note", dtoObject.Note)
.AddParameter("@PropertyManagementCharge", dtoObject.PropertyManagementCharge)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsSync", dtoObject.IsSync)
.AddParameter("@SyncOn", dtoObject.SyncOn)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.RentPayoutQuarterSetupSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.RentPayoutQuarterSetupSelectAll)
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
        public bool Insert(RentPayoutQuarterSetup dtoObject)
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

                    StoredProcedure(MasterDALConstant.RentPayoutQuarterSetupInsert)
                        .AddParameter("@QuarterID", dtoObject.QuarterID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@StartDate", dtoObject.StartDate)
.AddParameter("@EndDate", dtoObject.EndDate)
.AddParameter("@Note", dtoObject.Note)
.AddParameter("@PropertyManagementCharge", dtoObject.PropertyManagementCharge)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
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

        /// <summary>
        /// update row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true for successfully updated</returns>
        public bool Update(RentPayoutQuarterSetup dtoObject)
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

                    StoredProcedure(MasterDALConstant.RentPayoutQuarterSetupUpdate)
                        .AddParameter("@QuarterID", dtoObject.QuarterID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@StartDate", dtoObject.StartDate)
.AddParameter("@EndDate", dtoObject.EndDate)
.AddParameter("@Note", dtoObject.Note)
.AddParameter("@PropertyManagementCharge", dtoObject.PropertyManagementCharge)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
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
                StoredProcedure(MasterDALConstant.RentPayoutQuarterSetupDeleteByPrimaryKey)
                    .AddParameter("@QuarterID"
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
        public bool Delete(RentPayoutQuarterSetup dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.RentPayoutQuarterSetupDeleteByPrimaryKey)
                    .AddParameter("@QuarterID", dtoObject.QuarterID)

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

        public RentPayoutQuarterSetup SelectByPrimaryKey(Guid Keys)
        {
            RentPayoutQuarterSetup obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RentPayoutQuarterSetupSelectByPrimaryKey)
                            .AddParameter("@QuarterID"
, Keys)
                            .Fetch<RentPayoutQuarterSetup>();
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
        public List<RentPayoutQuarterSetup> SelectByField(string fieldName, object value)
        {
            List<RentPayoutQuarterSetup> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RentPayoutQuarterSetupSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<RentPayoutQuarterSetup>();

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
                obj = StoredProcedure(MasterDALConstant.RentPayoutQuarterSetupSelectByField)
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
                StoredProcedure(MasterDALConstant.RentPayoutQuarterSetupDeleteByField)
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
        public DataSet RentPayoutQuarterSetupCheckDateOverLapping(DateTime startdate,Guid? CompanyID ,Guid? PropertyID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.RentPayoutQuarterSetup_CheckDateOverlap)
                    .AddParameter("@StartDate", startdate )
                    .AddParameter("@CompanyID", CompanyID)
                    .AddParameter("@PropertyID", PropertyID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet RentPayoutQuarterSetupSelectQuarterbyDate(DateTime date, Guid? CompanyID, Guid? PropertyID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.RentPayOutPerQuarterSelectQuarterbyDate)
                    .AddParameter("@Date", date)
                    .AddParameter("@CompanyID", CompanyID)
                    .AddParameter("@PropertyID", PropertyID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet RentPayoutQuarterSetupTop4QuarterWithIncome()
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.RentPayOutPerQuarterSelectTop4QuarterWithIncome)
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
