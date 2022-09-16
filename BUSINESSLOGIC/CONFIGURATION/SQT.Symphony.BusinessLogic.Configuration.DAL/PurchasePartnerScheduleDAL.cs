using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SQT.FRAMEWORK.EXCEPTION;
using SQT.FRAMEWORK.LOGGER;
using SQT.FRAMEWORK.DAL.Linq;
using SQT.FRAMEWORK.DAL.Linq.DAL;
using SQT.Symphony.BusinessLogic.Configuration.COMMON;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.BusinessLogic.Configuration.DAL
{
    public class PurchasePartnerScheduleDAL : LinqDAL
    {
        DbTransaction dbtr = null;

        public PurchasePartnerScheduleDAL() : base()
        {

        }

        public PurchasePartnerScheduleDAL(DbTransaction DbTr)
           : base()
        {
            dbtr = DbTr;
        }

        public bool Insert(PurchasePartnerSchedule dtoObject)
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

                    StoredProcedure(MasterConstant.PurchasePartnerScheduleInsert)
                            .AddParameter("@PurchasePartnerScheduleID", dtoObject.PurchasePartnerScheduleID)
                            .AddParameter("@PropertyID", dtoObject.PropertyID)
                            .AddParameter("@PartnerID", dtoObject.PartnerID)
                            .AddParameter("@PurchaseScheduleID", dtoObject.PurchaseScheduleID)
                            .AddParameter("@InstallmentTypeTerm", dtoObject.InstallmentTypeTerm)
                            .AddParameter("@InstallmentAmount", dtoObject.InstallmentAmount)
                            .AddParameter("@InstallmentInPercentage", dtoObject.InstallmentInPercentage)
                            .AddParameter("@StatusTerm", dtoObject.StatusTerm)
                            .AddParameter("@MOPTerm", dtoObject.MOPTerm)
                            .AddParameter("@ActualPaymentDate", dtoObject.ActualPaymentDate)
                            .AddParameter("@TotalToInvest", dtoObject.TotalToInvest)
                            .AddParameter("@TotalPaid", dtoObject.TotalPaid)
                            .AddParameter("@TotalDue", dtoObject.TotalDue)
                            .AddParameter("@IsActive", dtoObject.IsActive)
                            .AddParameter("@Date",dtoObject.Date)
                            .AddParameter("@Installment", dtoObject.Installment)

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
    }
}
