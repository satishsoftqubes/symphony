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
    public class PropertyPaymentDAL : LinqDAL
    {
        DbTransaction dbtr = null;

        #region Constructor

        public PropertyPaymentDAL() : base()
        {

        }

        public PropertyPaymentDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }

        #endregion

        #region Public Methods

        public bool Insert(PropertyPayment dtoObject)
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

                    StoredProcedure(MasterConstant.PropertyPaymentInsert)
                            .AddParameter("@PropertyPaymentID", dtoObject.PropertyPaymentID)
                            .AddParameter("@PropertyID", dtoObject.PropertyID)
                            .AddParameter("@PropertyScheduleID", dtoObject.PropertyScheduleID)
                            .AddParameter("@AmountPaid", dtoObject.AmountPaid)
                            .AddParameter("@MOPTerm", dtoObject.MOPTerm)
                            .AddParameter("@DateOfTransaction", dtoObject.DateOfTransaction)
                            .AddParameter("@BankName", dtoObject.BankName)
                            .AddParameter("@ChequeNo", dtoObject.ChequeNo)
                            .AddParameter("@ChequeTo", dtoObject.ChequeTo)
                            .AddParameter("@Description", dtoObject.Description)

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

        public int CheckPropertyPaymentDuplication(Guid? PropertyID, Guid? PropertyScheduleID)
        {
            int propertyPaymentCount = 0;

            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    propertyPaymentCount = StoredProcedure(MasterConstant.PropertyPaymentCheckDuplication)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@PropertyScheduleID", PropertyScheduleID)
                                            .WithTransaction(dbtr)
                                            .ExecuteScalar<int>();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return propertyPaymentCount;
        }
        public DataSet SelectPropertyPaymentData(Guid? PropertyPaymentID, Guid? PropertyID, Guid? PropertyScheduleID, string PropertyName)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.PropertyPaymentSelectData)
                                            .AddParameter("@PropertyPaymentID", PropertyPaymentID)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@PropertyScheduleID", PropertyScheduleID)
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

        public bool Update(PropertyPayment dtoObject)
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

                    StoredProcedure(MasterConstant.PropertyPaymentUpdate)
                        .AddParameter("@PropertyPaymentID", dtoObject.PropertyPaymentID)
                        .AddParameter("@PropertyID", dtoObject.PropertyID)
                        .AddParameter("@PropertyScheduleID", dtoObject.PropertyScheduleID)
                        .AddParameter("@AmountPaid", dtoObject.AmountPaid)
                        .AddParameter("@MOPTerm", dtoObject.MOPTerm)
                        .AddParameter("@DateOfTransaction", dtoObject.DateOfTransaction)
                        .AddParameter("@BankName", dtoObject.BankName)
                        .AddParameter("@ChequeNo", dtoObject.ChequeNo)
                        .AddParameter("@ChequeTo", dtoObject.ChequeTo)
                        .AddParameter("@Description", dtoObject.Description)

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

        public PropertyPayment SelectByPrimaryKey(Guid Keys)
        {
            PropertyPayment obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.PropertyPaymentSelectByPrimaryKey)
                            .AddParameter("@PropertyPaymentID"
, Keys)
                            .Fetch<PropertyPayment>();
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

        public bool Delete(Guid Keys)
        {
            try
            {
                StoredProcedure(MasterConstant.PropertyPaymentDeleteByPrimaryKey)
                    .AddParameter("@PropertyPaymentID"
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

        #endregion
    }
}
