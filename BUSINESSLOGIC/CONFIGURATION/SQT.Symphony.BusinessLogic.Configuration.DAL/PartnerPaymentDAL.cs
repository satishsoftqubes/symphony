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
    public class PartnerPaymentDAL : LinqDAL
    {
        DbTransaction dbtr = null;

        #region Constructor

        public PartnerPaymentDAL() : base()
        {

        }

        public PartnerPaymentDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }

        #endregion

        #region Public Methods

        public bool Insert(PartnerPayment dtoObject)
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

                    StoredProcedure(MasterConstant.PartnerPaymentInsert)
                            .AddParameter("@PartnerPaymentID", dtoObject.PartnerPaymentID)
                            .AddParameter("@PartnerID", dtoObject.PartnerID)
                            .AddParameter("@PropertyID", dtoObject.PropertyID)
                            .AddParameter("@PropertyPurchaseScheduleID", dtoObject.PropertyPurchaseScheduleID)
                            .AddParameter("@PaymentAmount", dtoObject.PaymentAmount)
                            .AddParameter("@MOPTerm", dtoObject.MOPTerm)
                            .AddParameter("@BankName", dtoObject.BankName)
                            .AddParameter("@ChequeNo", dtoObject.ChequeNo)
                            .AddParameter("@TransactionDate", dtoObject.TransactionDate)
                            .AddParameter("@ReceivedBy", dtoObject.ReceivedBy)
                            .AddParameter("@IsActive", dtoObject.IsActive)
                            .AddParameter("@UploadDocument", dtoObject.UploadDocument)
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

        //public bool Update(PurchaseSchedule dtoObject)
        //{
        //    try
        //    {
        //        using (new Tracer((SQTLogType.DataAccessTraceLog)))
        //        {
        //            if (dtoObject == null)
        //                throw (new ParameterNullException("Object can not be null"));

        //            //Log Method Parameteres.
        //            ArrayList parameterList = new ArrayList();
        //            parameterList.Add(dtoObject);
        //            SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

        //            StoredProcedure(MasterConstant.PurchaseScheduleUpdate)
        //                    .AddParameter("@PurchaseScheduleID", dtoObject.PurchaseScheduleID)
        //                    .AddParameter("@PropertyID", dtoObject.PropertyID)
        //                    .AddParameter("@InstallmentTypeTerm", dtoObject.InstallmentTypeTerm)
        //                    .AddParameter("@InstallmentAmount", dtoObject.InstallmentAmount)
        //                    .AddParameter("@InstallmentInPercentage", dtoObject.InstallmentInPercentage)
        //                    .AddParameter("@StatusTerm", dtoObject.StatusTerm)
        //                    .AddParameter("@MOPTerm", dtoObject.MOPTerm)

        //                .WithTransaction(dbtr)
        //                .Execute();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log exception at DataAccess Layer.
        //        bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
        //        if (rethrow)
        //        {
        //            throw ex;
        //        }
        //    }
        //    return true;
        //}

        //        public bool Delete(Guid Keys)
        //        {
        //            try
        //            {
        //                StoredProcedure(MasterConstant.PurchaseScheduleDeleteByPrimaryKey)
        //                    .AddParameter("@PropertyID"
        //, Keys)
        //                    .WithTransaction(dbtr)
        //                    .Execute();
        //            }
        //            catch (Exception ex)
        //            {
        //                //Log exception at DataAccess Layer.
        //                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
        //                if (rethrow)
        //                {
        //                    throw ex;
        //                }
        //            }
        //            return true;
        //        }

        public DataSet SelectPartnerPaymentData(Guid? PropertyID, Guid? PartnerID, Guid? PropertyPurchaseScheduleID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.PartnerPaymentSelectData)
                                            .AddParameter("@PartnerID", PartnerID)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@PropertyPurchaseScheduleID", PropertyPurchaseScheduleID)
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
