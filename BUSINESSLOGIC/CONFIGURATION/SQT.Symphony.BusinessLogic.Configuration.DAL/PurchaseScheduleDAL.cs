using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SQT.FRAMEWORK.DAL.Linq;
using SQT.FRAMEWORK.DAL.Linq.DAL;
using SQT.FRAMEWORK.EXCEPTION;
using SQT.FRAMEWORK.LOGGER;
using SQT.Symphony.BusinessLogic.Configuration.COMMON;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.BusinessLogic.Configuration.DAL
{
    public class PurchaseScheduleDAL : LinqDAL
    {
        DbTransaction dbtr = null;

        #region Constructor

        public PurchaseScheduleDAL() : base()
        {

        }

        public PurchaseScheduleDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }

        #endregion

        #region Public Methods

        public bool Insert(PurchaseSchedule dtoObject)
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

                    StoredProcedure(MasterConstant.PurchaseScheduleInsert)
                            .AddParameter("@PurchaseScheduleID", dtoObject.PurchaseScheduleID)
                            .AddParameter("@PurchasePartnerScheduleID", dtoObject.PurchasePartnerScheduleID)
                            .AddParameter("@PropertyID", dtoObject.PropertyID)
                            .AddParameter("@PartnerID", dtoObject.PartnerID)
                            .AddParameter("@InstallmentTypeTerm", dtoObject.InstallmentTypeTerm)
                            .AddParameter("@InstallmentAmount", dtoObject.InstallmentAmount)
                            .AddParameter("@InstallmentInPercentage", dtoObject.InstallmentInPercentage)
                            .AddParameter("@StatusTerm", dtoObject.StatusTerm)
                            .AddParameter("@MOPTerm", dtoObject.MOPTerm)
                            .AddParameter("@ActualPaymentDate", dtoObject.ActualPaymentDate)
                            .AddParameter("@TotalPaid", dtoObject.TotalPaid)
                            .AddParameter("@TotalDue", dtoObject.TotalDue)
                            .AddParameter("@IsActive", dtoObject.IsActive)
                            .AddParameter("@Date",dtoObject.Date)
                            

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

        public bool Update(PurchaseSchedule dtoObject)
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

                    StoredProcedure(MasterConstant.PurchaseScheduleUpdate)
                            .AddParameter("@PurchaseScheduleID", dtoObject.PurchaseScheduleID)
                            .AddParameter("@PropertyID", dtoObject.PropertyID)
                            .AddParameter("@InstallmentTypeTerm", dtoObject.InstallmentTypeTerm)
                            .AddParameter("@InstallmentAmount", dtoObject.InstallmentAmount)
                            .AddParameter("@InstallmentInPercentage", dtoObject.InstallmentInPercentage)
                            .AddParameter("@StatusTerm", dtoObject.StatusTerm)
                            .AddParameter("@MOPTerm", dtoObject.MOPTerm)
                            .AddParameter("@Date",dtoObject.Date)

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
                StoredProcedure(MasterConstant.PurchaseScheduleDeleteByPrimaryKey)
                    .AddParameter("@PropertyID"
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

        public DataSet GetPropertyListForPurchaseSchedule(Guid? PropertyID, Guid? CompanyID, string PropertyName)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.PropertyListForPurchaseSchedule)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@CompanyID", CompanyID)
                                            .AddParameter("@PropertyName", PropertyName)
                                            .WithTransaction(dbtr)
                                            .FetchDataSet();
                }
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public DataSet SelectPurchaseScheduleData(Guid? PropertyID, Guid? CompanyID, string PropertyName)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.PurchaseScheduleSelectData)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@CompanyID", CompanyID)
                                            .AddParameter("@PropertyName", PropertyName)
                                            .WithTransaction(dbtr)
                                            .FetchDataSet();
                }
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public DataSet SelectPurchaseSchedulePropertyInstallmentData(Guid? PropertyID, Guid? CompanyID, string PropertyName)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.PurchaseschedulePropertyInstallmentGrid_SelectData)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@CompanyID", CompanyID)
                                            .AddParameter("@PropertyName", PropertyName)
                                            .WithTransaction(dbtr)
                                            .FetchDataSet();
                }
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
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
