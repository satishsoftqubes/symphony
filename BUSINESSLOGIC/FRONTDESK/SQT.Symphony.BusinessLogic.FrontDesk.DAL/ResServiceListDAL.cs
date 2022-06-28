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
    /// Data access layer class for ResServiceList
    /// </summary>
    public class ResServiceListDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public ResServiceListDAL()
            : base()
        {
            // Nothing for now.
        }
        public ResServiceListDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<ResServiceList> SelectAll(ResServiceList dtoObject)
        {
            List<ResServiceList> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.ResServiceListSelectAll)
                                                .AddParameter("@ResServiceID", dtoObject.ResServiceID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@ResBlockDateRateID", dtoObject.ResBlockDateRateID)
.AddParameter("@ServiceStatus_TermID", dtoObject.ServiceStatus_TermID)
.AddParameter("@StatusRemark", dtoObject.StatusRemark)
.AddParameter("@Amount", dtoObject.Amount)
.AddParameter("@Qty", dtoObject.Qty)
.AddParameter("@Total", dtoObject.Total)
.AddParameter("@ServiceDate", dtoObject.ServiceDate)
.AddParameter("@PostingDate", dtoObject.PostingDate)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@Notes", dtoObject.Notes)
.AddParameter("@ReRouteFolioID", dtoObject.ReRouteFolioID)
.AddParameter("@ReRouteCharge", dtoObject.ReRouteCharge)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ServiceStatus_Term", dtoObject.ServiceStatus_Term)

                                                .WithTransaction(dbtr)
                                                .FetchAll<ResServiceList>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ResServiceListSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<ResServiceList>();
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

        public List<ResServiceList> SelectAll()
        {
            List<ResServiceList> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.ResServiceListSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<ResServiceList>();
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
        public DataSet SelectAllWithDataSet(ResServiceList dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.ResServiceListSelectAll)
                                                .AddParameter("@ResServiceID", dtoObject.ResServiceID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@ResBlockDateRateID", dtoObject.ResBlockDateRateID)
.AddParameter("@ServiceStatus_TermID", dtoObject.ServiceStatus_TermID)
.AddParameter("@StatusRemark", dtoObject.StatusRemark)
.AddParameter("@Amount", dtoObject.Amount)
.AddParameter("@Qty", dtoObject.Qty)
.AddParameter("@Total", dtoObject.Total)
.AddParameter("@ServiceDate", dtoObject.ServiceDate)
.AddParameter("@PostingDate", dtoObject.PostingDate)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@Notes", dtoObject.Notes)
.AddParameter("@ReRouteFolioID", dtoObject.ReRouteFolioID)
.AddParameter("@ReRouteCharge", dtoObject.ReRouteCharge)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ServiceStatus_Term", dtoObject.ServiceStatus_Term)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ResServiceListSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.ResServiceListSelectAll)
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
        public bool Insert(ResServiceList dtoObject)
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

                    StoredProcedure(MasterDALConstant.ResServiceListInsert)
                        .AddParameter("@ResServiceID", dtoObject.ResServiceID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@ResBlockDateRateID", dtoObject.ResBlockDateRateID)
.AddParameter("@ServiceStatus_TermID", dtoObject.ServiceStatus_TermID)
.AddParameter("@StatusRemark", dtoObject.StatusRemark)
.AddParameter("@Amount", dtoObject.Amount)
.AddParameter("@Qty", dtoObject.Qty)
.AddParameter("@Total", dtoObject.Total)
.AddParameter("@ServiceDate", dtoObject.ServiceDate)
.AddParameter("@PostingDate", dtoObject.PostingDate)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@Notes", dtoObject.Notes)
.AddParameter("@ReRouteFolioID", dtoObject.ReRouteFolioID)
.AddParameter("@ReRouteCharge", dtoObject.ReRouteCharge)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ServiceStatus_Term", dtoObject.ServiceStatus_Term)

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
        public bool Update(ResServiceList dtoObject)
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

                    StoredProcedure(MasterDALConstant.ResServiceListUpdate)
                        .AddParameter("@ResServiceID", dtoObject.ResServiceID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@ResBlockDateRateID", dtoObject.ResBlockDateRateID)
.AddParameter("@ServiceStatus_TermID", dtoObject.ServiceStatus_TermID)
.AddParameter("@StatusRemark", dtoObject.StatusRemark)
.AddParameter("@Amount", dtoObject.Amount)
.AddParameter("@Qty", dtoObject.Qty)
.AddParameter("@Total", dtoObject.Total)
.AddParameter("@ServiceDate", dtoObject.ServiceDate)
.AddParameter("@PostingDate", dtoObject.PostingDate)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@Notes", dtoObject.Notes)
.AddParameter("@ReRouteFolioID", dtoObject.ReRouteFolioID)
.AddParameter("@ReRouteCharge", dtoObject.ReRouteCharge)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ServiceStatus_Term", dtoObject.ServiceStatus_Term)
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
                StoredProcedure(MasterDALConstant.ResServiceListDeleteByPrimaryKey)
                    .AddParameter("@ResServiceID"
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
        public bool Delete(ResServiceList dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.ResServiceListDeleteByPrimaryKey)
                    .AddParameter("@ResServiceID", dtoObject.ResServiceID)

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

        public ResServiceList SelectByPrimaryKey(Guid Keys)
        {
            ResServiceList obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ResServiceListSelectByPrimaryKey)
                            .AddParameter("@ResServiceID"
, Keys)
                            .Fetch<ResServiceList>();
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
        public List<ResServiceList> SelectByField(string fieldName, object value)
        {
            List<ResServiceList> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ResServiceListSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<ResServiceList>();

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
                obj = StoredProcedure(MasterDALConstant.ResServiceListSelectByField)
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
                StoredProcedure(MasterDALConstant.ResServiceListDeleteByField)
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
