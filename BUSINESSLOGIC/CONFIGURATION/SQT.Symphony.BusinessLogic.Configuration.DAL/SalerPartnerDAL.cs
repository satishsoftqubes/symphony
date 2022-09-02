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
    public class SalerPartnerDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        public SalerPartnerDAL() : base()
        {
            // Nothing for now.
        }
        public SalerPartnerDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        public bool Insert(SalerPartner objSP)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    if (objSP == null)
                        throw (new ParameterNullException("Object can not be null"));

                    //Log Method Parameteres.
                    //ArrayList parameterList = new ArrayList();
                    //parameterList.Add(objSP);
                    //SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterConstant.SalerPartnerInsert)

                    .AddParameter("@PartnerID", objSP.PartnerID)
                    .AddParameter("@FirstName", objSP.FirstName)
                    .AddParameter("@MiddleName", objSP.MiddleName)
                    .AddParameter("@LastName", objSP.LastName)
                    .AddParameter("@MobileNo", objSP.MobileNo)
                    .AddParameter("@Email", objSP.Email)
                    .AddParameter("@Address", objSP.Address)
                    .AddParameter("@TotalProperties", objSP.TotalProperties)
                    .AddParameter("@TotalInvestment", objSP.TotalInvestment)
                    .AddParameter("@CreatedBy",objSP.CreatedBy)
                    .WithTransaction(dbtr)
                    .Execute();
                }
            }
            catch (Exception ex)
            {
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
                StoredProcedure(MasterConstant.SalerDelete_IdWise)
                    .AddParameter("@PartnerID", Keys)
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

        public bool Update(SalerPartner objSP)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    if (objSP == null)
                        throw (new ParameterNullException("Object can not be null"));
                    
                    StoredProcedure(MasterConstant.SalerPartnerUpdate)
                        .AddParameter("@PartnerID", objSP.PartnerID)
                        .AddParameter("@FirstName", objSP.FirstName)
                        .AddParameter("@MiddleName", objSP.MiddleName)
                        .AddParameter("@LastName", objSP.LastName)
                        .AddParameter("@MobileNo",objSP.MobileNo)
                        .AddParameter("@Email", objSP.Email)
                        .AddParameter("@Address", objSP.Address)
                        .AddParameter("@TotalProperties", objSP.TotalProperties)
                        .AddParameter("@TotalInvestment", objSP.TotalInvestment)
                        .AddParameter("@UpdatedBy",objSP.UpdatedBy)
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

        public DataSet GetByIdWise_SalePartnerData(Guid PartnerID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    obj = StoredProcedure(MasterConstant.GetByIdWise_SalePartnerData)
                        .AddParameter("@PartnerID", PartnerID)
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
        public List<SalerPartner> SelectAll(SalerPartner _dataObject)
        {
            List<SalerPartner> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {

                    if (_dataObject != null)
                    {
                        obj = StoredProcedure(MasterConstant.SalerPartnerGetAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<SalerPartner>();

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
        public DataSet GetSalerPartnerData(string FirstName,string MobileNo)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    obj = StoredProcedure(MasterConstant.SalerPartnerGetAll)
                        .AddParameter("@FirstName",FirstName)
                        .AddParameter("@MobileNo",MobileNo)
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
    }
}
