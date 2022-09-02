using System;
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

    public class VendorDAL : LinqDAL
    {
        DbTransaction dbtr = null;
        public VendorDAL() : base()
        {
            // Nothing for now.
        }
        public VendorDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        public bool Insert(Vendor objVender)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    if (objVender == null)
                        throw (new ParameterNullException("Object can not be null"));
                    
                    StoredProcedure(MasterConstant.VendorInsert)

                    .AddParameter("@VendorID", objVender.VendorID)
                    .AddParameter("@CompanyID",objVender.CompanyID)
                    .AddParameter("@VendorName", objVender.VendorName)
                    .AddParameter("@ContactName", objVender.ContactName)
                    .AddParameter("@Email", objVender.Emaill)
                    .AddParameter("@MobileNo", objVender.MobileNo)
                    .AddParameter("@VendorDetail", objVender.VendorDetail)
                    .AddParameter("@CreatedBy", objVender.CreatedBy)
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
                StoredProcedure(MasterConstant.VendorDelete_IdWise)
                    .AddParameter("@VendorID", Keys)
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

        public bool Update(Vendor objVender)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    if (objVender == null)
                        throw (new ParameterNullException("Object can not be null"));

                    StoredProcedure(MasterConstant.VendorUpdate)
                   .AddParameter("@VendorID", objVender.VendorID)
                   .AddParameter("@CompanyID", objVender.CompanyID)
                   .AddParameter("@VendorName", objVender.VendorName)
                   .AddParameter("@ContactName", objVender.ContactName)
                   .AddParameter("@Email", objVender.Emaill)
                   .AddParameter("@MobileNo", objVender.MobileNo)
                   .AddParameter("@VendorDetail", objVender.VendorDetail)
                   .AddParameter("@UpdatedBy", objVender.UpdatedBy)
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

        public DataSet GetByIdWise_VendorData(Guid VendorID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    obj = StoredProcedure(MasterConstant.GetByIdWise_VendorData)
                        .AddParameter("@VendorID", VendorID)
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
        public DataSet GetVendorData(string VendorName, string MobileNo)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    obj = StoredProcedure(MasterConstant.VendorGetAll)
                        .AddParameter("@VendorName", VendorName)
                        .AddParameter("@MobileNo", MobileNo)
                        .WithTransaction(dbtr)
                        .FetchDataSet();
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
            return obj;
        }
    }
}
