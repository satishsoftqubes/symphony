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
	/// Data access layer class for ServiceVendorMaster
	/// </summary>
	public class ServiceVendorMasterDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public ServiceVendorMasterDAL() :  base()
		{
			// Nothing for now.
		}
        public ServiceVendorMasterDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<ServiceVendorMaster> SelectAll(ServiceVendorMaster dtoObject)
        {
            List<ServiceVendorMaster> obj = null;
            try
            {
                //using (new Tracer((SQTLogType.DataAccessTraceLog)))
                //{
                //Log Method Parameteres.
                ArrayList parameterList = new ArrayList();
                if (dtoObject != null)
                    parameterList.Add(dtoObject);
                //SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                if (dtoObject != null)
                {
                    obj = StoredProcedure(MasterConstant.ServiceVendorMasterSelectAll)
                                            .AddParameter("@VendorID", dtoObject.VendorID)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@RegistrationNo", dtoObject.RegistrationNo)
.AddParameter("@RegistrationDate", dtoObject.RegistrationDate)
.AddParameter("@VATRegNo", dtoObject.VATRegNo)
.AddParameter("@VATRegistrationDate", dtoObject.VATRegistrationDate)
.AddParameter("@ContactPersonName", dtoObject.ContactPersonName)
.AddParameter("@ContactNo", dtoObject.ContactNo)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@URL", dtoObject.URL)
.AddParameter("@BillingAddress", dtoObject.BillingAddress)
.AddParameter("@POSDetails", dtoObject.POSDetails)
.AddParameter("@CityLedgerAcctID", dtoObject.CityLedgerAcctID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@SynchOn", dtoObject.SynchOn)
//.AddParameter("@SeqNo", dtoObject.SeqNo)

                                            .WithTransaction(dbtr)
                                            .FetchAll<ServiceVendorMaster>();
                }
                else
                {
                    obj = StoredProcedure(MasterConstant.ServiceVendorMasterSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<ServiceVendorMaster>();
                }
                //}
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                //bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                //if (rethrow)
                //{
                throw ex;
                //}
            }
            return obj;
        }

        public List<ServiceVendorMaster> SelectAll()
        {
            List<ServiceVendorMaster> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.ServiceVendorMasterSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<ServiceVendorMaster>();
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
        public DataSet SelectAllWithDataSet(ServiceVendorMaster dtoObject)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    if(dtoObject != null)
                        parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                    if(dtoObject != null)  
                    {
                        obj = StoredProcedure(MasterConstant.ServiceVendorMasterSelectAll)
                                                .AddParameter("@VendorID", dtoObject.VendorID)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@RegistrationNo", dtoObject.RegistrationNo)
.AddParameter("@RegistrationDate", dtoObject.RegistrationDate)
.AddParameter("@VATRegNo", dtoObject.VATRegNo)
.AddParameter("@VATRegistrationDate", dtoObject.VATRegistrationDate)
.AddParameter("@ContactPersonName", dtoObject.ContactPersonName)
.AddParameter("@ContactNo", dtoObject.ContactNo)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@URL", dtoObject.URL)
.AddParameter("@BillingAddress", dtoObject.BillingAddress)
.AddParameter("@POSDetails", dtoObject.POSDetails)
.AddParameter("@CityLedgerAcctID", dtoObject.CityLedgerAcctID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@SynchOn", dtoObject.SynchOn)
//.AddParameter("@SeqNo", dtoObject.SeqNo)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.ServiceVendorMasterSelectAll)
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

                    obj = StoredProcedure(MasterConstant.ServiceVendorMasterSelectAll)
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
	
        public bool Insert(ServiceVendorMaster dtoObject)
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

                StoredProcedure(MasterConstant.ServiceVendorMasterInsert)
                    .AddParameter("@VendorID", dtoObject.VendorID)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@RegistrationNo", dtoObject.RegistrationNo)
.AddParameter("@RegistrationDate", dtoObject.RegistrationDate)
.AddParameter("@VATRegNo", dtoObject.VATRegNo)
.AddParameter("@VATRegistrationDate", dtoObject.VATRegistrationDate)
.AddParameter("@ContactPersonName", dtoObject.ContactPersonName)
.AddParameter("@ContactNo", dtoObject.ContactNo)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@URL", dtoObject.URL)
.AddParameter("@BillingAddress", dtoObject.BillingAddress)
.AddParameter("@POSDetails", dtoObject.POSDetails)
.AddParameter("@CityLedgerAcctID", dtoObject.CityLedgerAcctID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@SeqNo", dtoObject.SeqNo)

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
        public bool Update(ServiceVendorMaster dtoObject)
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

                    StoredProcedure(MasterConstant.ServiceVendorMasterUpdate)
                        .AddParameter("@VendorID", dtoObject.VendorID)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@RegistrationNo", dtoObject.RegistrationNo)
.AddParameter("@RegistrationDate", dtoObject.RegistrationDate)
.AddParameter("@VATRegNo", dtoObject.VATRegNo)
.AddParameter("@VATRegistrationDate", dtoObject.VATRegistrationDate)
.AddParameter("@ContactPersonName", dtoObject.ContactPersonName)
.AddParameter("@ContactNo", dtoObject.ContactNo)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@URL", dtoObject.URL)
.AddParameter("@BillingAddress", dtoObject.BillingAddress)
.AddParameter("@POSDetails", dtoObject.POSDetails)
.AddParameter("@CityLedgerAcctID", dtoObject.CityLedgerAcctID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@SeqNo", dtoObject.SeqNo)
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
                StoredProcedure(MasterConstant.ServiceVendorMasterDeleteByPrimaryKey)
                    .AddParameter("@VendorID"
,Keys)
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
        public bool Delete(ServiceVendorMaster dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.ServiceVendorMasterDeleteByPrimaryKey)
                    .AddParameter("@VendorID", dtoObject.VendorID)

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

        public ServiceVendorMaster SelectByPrimaryKey(Guid Keys)
        {
            ServiceVendorMaster obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ServiceVendorMasterSelectByPrimaryKey)
                            .AddParameter("@VendorID"
,Keys)
                            .Fetch<ServiceVendorMaster>();
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
        public List<ServiceVendorMaster> SelectByField(string fieldName, object value)
        {
            List<ServiceVendorMaster> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ServiceVendorMasterSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<ServiceVendorMaster>();

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
                obj = StoredProcedure(MasterConstant.ServiceVendorMasterSelectByField) 
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
                StoredProcedure(MasterConstant.ServiceVendorMasterDeleteByField) 
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


        public DataSet SearchVendorData(string CompanyName, string ContactPersonName, Guid? CompanyID, Guid? PropertyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ServiceVendorMasterSearchData)
                                    .AddParameter("@CompanyName", CompanyName)
                                    .AddParameter("@ContactPersonName", ContactPersonName)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
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
        #endregion
	}
}
