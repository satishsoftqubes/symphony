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
	/// Data access layer class for Company
	/// </summary>
	public class CompanyDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public CompanyDAL() :  base()
		{
			// Nothing for now.
		}
        public CompanyDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Company> SelectAll(Company dtoObject)
        {
            List<Company> obj = null;
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
                        obj = StoredProcedure(MasterConstant.CompanySelectAll)
                                                .AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@DisplayName", dtoObject.DisplayName)
.AddParameter("@CompanyCode", dtoObject.CompanyCode)
.AddParameter("@PrimaryContactName", dtoObject.PrimaryContactName)
.AddParameter("@PrimoryEmailAddress", dtoObject.PrimoryEmailAddress)
.AddParameter("@PrimoryContactNo", dtoObject.PrimoryContactNo)
.AddParameter("@OrganizationType", dtoObject.OrganizationType)
.AddParameter("@BusinessDomain", dtoObject.BusinessDomain)
.AddParameter("@DateOfRegistration", dtoObject.DateOfRegistration)
.AddParameter("@ApplicableRegNo", dtoObject.ApplicableRegNo)
.AddParameter("@TaxationIdentification", dtoObject.TaxationIdentification)
.AddParameter("@RegistrationCompany", dtoObject.RegistrationCompany)
.AddParameter("@YearbyTurnover", dtoObject.YearbyTurnover)
.AddParameter("@Updatelog", dtoObject.Updatelog)
.AddParameter("@CompanyRegistrationDate", dtoObject.CompanyRegistrationDate)
.AddParameter("@RegistrationStatus", dtoObject.RegistrationStatus)
.AddParameter("@HaveMultipleProperties", dtoObject.HaveMultipleProperties)
.AddParameter("@IsApproved", dtoObject.IsApproved)
.AddParameter("@ApprovedOn", dtoObject.ApprovedOn)
.AddParameter("@ApprovedBy", dtoObject.ApprovedBy)
.AddParameter("@DateofExpiry", dtoObject.DateofExpiry)
.AddParameter("@PaymentTerms", dtoObject.PaymentTerms)
.AddParameter("@PackageID", dtoObject.PackageID)
.AddParameter("@CreditLimit", dtoObject.CreditLimit)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@PrimaryAddID", dtoObject.PrimaryAddID)
.AddParameter("@PrimaryAdd1", dtoObject.PrimaryAdd1)
.AddParameter("@PrimaryAdd2", dtoObject.PrimaryAdd2)
.AddParameter("@PrimaryCity", dtoObject.PrimaryCity)
.AddParameter("@PrimaryZipCode", dtoObject.PrimaryZipCode)
.AddParameter("@PrimaryState", dtoObject.PrimaryState)
.AddParameter("@PrimaryCountry", dtoObject.PrimaryCountry)
.AddParameter("@PrimaryPhone", dtoObject.PrimaryPhone)
.AddParameter("@PrimaryEmail", dtoObject.PrimaryEmail)
.AddParameter("@PrimaryFax", dtoObject.PrimaryFax)
.AddParameter("@PrimaryUrl", dtoObject.PrimaryUrl)
.AddParameter("@PhotoLocal", dtoObject.PhotoLocal)
.AddParameter("@InCorporatonNo", dtoObject.InCorporatonNo)
.AddParameter("@PanNo", dtoObject.PanNo)
.AddParameter("@TanNo", dtoObject.TanNo)
.AddParameter("@TinNo", dtoObject.TinNo)
.AddParameter("@ServiceTaxNo", dtoObject.ServiceTaxNo)
.AddParameter("@CompanyType", dtoObject.CompanyType)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Company>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.CompanySelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Company>();
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

        public List<Company> SelectAll()
        {
            List<Company> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.CompanySelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Company>();
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
        public DataSet SelectAllWithDataSet(Company dtoObject)
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
                        obj = StoredProcedure(MasterConstant.CompanySelectAll)
                                                .AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@DisplayName", dtoObject.DisplayName)
.AddParameter("@CompanyCode", dtoObject.CompanyCode)
.AddParameter("@PrimaryContactName", dtoObject.PrimaryContactName)
.AddParameter("@PrimoryEmailAddress", dtoObject.PrimoryEmailAddress)
.AddParameter("@PrimoryContactNo", dtoObject.PrimoryContactNo)
.AddParameter("@OrganizationType", dtoObject.OrganizationType)
.AddParameter("@BusinessDomain", dtoObject.BusinessDomain)
.AddParameter("@DateOfRegistration", dtoObject.DateOfRegistration)
.AddParameter("@ApplicableRegNo", dtoObject.ApplicableRegNo)
.AddParameter("@TaxationIdentification", dtoObject.TaxationIdentification)
.AddParameter("@RegistrationCompany", dtoObject.RegistrationCompany)
.AddParameter("@YearbyTurnover", dtoObject.YearbyTurnover)
.AddParameter("@Updatelog", dtoObject.Updatelog)
.AddParameter("@CompanyRegistrationDate", dtoObject.CompanyRegistrationDate)
.AddParameter("@RegistrationStatus", dtoObject.RegistrationStatus)
.AddParameter("@HaveMultipleProperties", dtoObject.HaveMultipleProperties)
.AddParameter("@IsApproved", dtoObject.IsApproved)
.AddParameter("@ApprovedOn", dtoObject.ApprovedOn)
.AddParameter("@ApprovedBy", dtoObject.ApprovedBy)
.AddParameter("@DateofExpiry", dtoObject.DateofExpiry)
.AddParameter("@PaymentTerms", dtoObject.PaymentTerms)
.AddParameter("@PackageID", dtoObject.PackageID)
.AddParameter("@CreditLimit", dtoObject.CreditLimit)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@PrimaryAddID", dtoObject.PrimaryAddID)
.AddParameter("@PrimaryAdd1", dtoObject.PrimaryAdd1)
.AddParameter("@PrimaryAdd2", dtoObject.PrimaryAdd2)
.AddParameter("@PrimaryCity", dtoObject.PrimaryCity)
.AddParameter("@PrimaryZipCode", dtoObject.PrimaryZipCode)
.AddParameter("@PrimaryState", dtoObject.PrimaryState)
.AddParameter("@PrimaryCountry", dtoObject.PrimaryCountry)
.AddParameter("@PrimaryPhone", dtoObject.PrimaryPhone)
.AddParameter("@PrimaryEmail", dtoObject.PrimaryEmail)
.AddParameter("@PrimaryFax", dtoObject.PrimaryFax)
.AddParameter("@PrimaryUrl", dtoObject.PrimaryUrl)
.AddParameter("@PhotoLocal", dtoObject.PhotoLocal)
.AddParameter("@InCorporatonNo", dtoObject.InCorporatonNo)
.AddParameter("@PanNo", dtoObject.PanNo)
.AddParameter("@TanNo", dtoObject.TanNo)
.AddParameter("@TinNo", dtoObject.TinNo)
.AddParameter("@ServiceTaxNo", dtoObject.ServiceTaxNo)
.AddParameter("@CompanyType", dtoObject.CompanyType)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.CompanySelectAll)
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

                    obj = StoredProcedure(MasterConstant.CompanySelectAll)
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
		public bool Insert(Company dtoObject)
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

                    StoredProcedure(MasterConstant.CompanyInsert)
                        .AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@DisplayName", dtoObject.DisplayName)
.AddParameter("@CompanyCode", dtoObject.CompanyCode)
.AddParameter("@PrimaryContactName", dtoObject.PrimaryContactName)
.AddParameter("@PrimoryEmailAddress", dtoObject.PrimoryEmailAddress)
.AddParameter("@PrimoryContactNo", dtoObject.PrimoryContactNo)
.AddParameter("@OrganizationType", dtoObject.OrganizationType)
.AddParameter("@BusinessDomain", dtoObject.BusinessDomain)
.AddParameter("@DateOfRegistration", dtoObject.DateOfRegistration)
.AddParameter("@ApplicableRegNo", dtoObject.ApplicableRegNo)
.AddParameter("@TaxationIdentification", dtoObject.TaxationIdentification)
.AddParameter("@RegistrationCompany", dtoObject.RegistrationCompany)
.AddParameter("@YearbyTurnover", dtoObject.YearbyTurnover)
.AddParameter("@CompanyRegistrationDate", dtoObject.CompanyRegistrationDate)
.AddParameter("@RegistrationStatus", dtoObject.RegistrationStatus)
.AddParameter("@HaveMultipleProperties", dtoObject.HaveMultipleProperties)
.AddParameter("@IsApproved", dtoObject.IsApproved)
.AddParameter("@ApprovedOn", dtoObject.ApprovedOn)
.AddParameter("@ApprovedBy", dtoObject.ApprovedBy)
.AddParameter("@DateofExpiry", dtoObject.DateofExpiry)
.AddParameter("@PaymentTerms", dtoObject.PaymentTerms)
.AddParameter("@PackageID", dtoObject.PackageID)
.AddParameter("@CreditLimit", dtoObject.CreditLimit)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@PrimaryAddID", dtoObject.PrimaryAddID)
.AddParameter("@PrimaryAdd1", dtoObject.PrimaryAdd1)
.AddParameter("@PrimaryAdd2", dtoObject.PrimaryAdd2)
.AddParameter("@PrimaryCity", dtoObject.PrimaryCity)
.AddParameter("@PrimaryZipCode", dtoObject.PrimaryZipCode)
.AddParameter("@PrimaryState", dtoObject.PrimaryState)
.AddParameter("@PrimaryCountry", dtoObject.PrimaryCountry)
.AddParameter("@PrimaryPhone", dtoObject.PrimaryPhone)
.AddParameter("@PrimaryEmail", dtoObject.PrimaryEmail)
.AddParameter("@PrimaryFax", dtoObject.PrimaryFax)
.AddParameter("@PrimaryUrl", dtoObject.PrimaryUrl)
.AddParameter("@PhotoLocal", dtoObject.PhotoLocal)
.AddParameter("@InCorporatonNo", dtoObject.InCorporatonNo)
.AddParameter("@PanNo", dtoObject.PanNo)
.AddParameter("@TanNo", dtoObject.TanNo)
.AddParameter("@TinNo", dtoObject.TinNo)
.AddParameter("@ServiceTaxNo", dtoObject.ServiceTaxNo)
.AddParameter("@CompanyType", dtoObject.CompanyType)

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
        public bool Update(Company dtoObject)
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

                    StoredProcedure(MasterConstant.CompanyUpdate)
                        .AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@DisplayName", dtoObject.DisplayName)
.AddParameter("@CompanyCode", dtoObject.CompanyCode)
.AddParameter("@PrimaryContactName", dtoObject.PrimaryContactName)
.AddParameter("@PrimoryEmailAddress", dtoObject.PrimoryEmailAddress)
.AddParameter("@PrimoryContactNo", dtoObject.PrimoryContactNo)
.AddParameter("@OrganizationType", dtoObject.OrganizationType)
.AddParameter("@BusinessDomain", dtoObject.BusinessDomain)
.AddParameter("@DateOfRegistration", dtoObject.DateOfRegistration)
.AddParameter("@ApplicableRegNo", dtoObject.ApplicableRegNo)
.AddParameter("@TaxationIdentification", dtoObject.TaxationIdentification)
.AddParameter("@RegistrationCompany", dtoObject.RegistrationCompany)
.AddParameter("@YearbyTurnover", dtoObject.YearbyTurnover)
.AddParameter("@Updatelog", dtoObject.Updatelog)
.AddParameter("@CompanyRegistrationDate", dtoObject.CompanyRegistrationDate)
.AddParameter("@RegistrationStatus", dtoObject.RegistrationStatus)
.AddParameter("@HaveMultipleProperties", dtoObject.HaveMultipleProperties)
.AddParameter("@IsApproved", dtoObject.IsApproved)
.AddParameter("@ApprovedOn", dtoObject.ApprovedOn)
.AddParameter("@ApprovedBy", dtoObject.ApprovedBy)
.AddParameter("@DateofExpiry", dtoObject.DateofExpiry)
.AddParameter("@PaymentTerms", dtoObject.PaymentTerms)
.AddParameter("@PackageID", dtoObject.PackageID)
.AddParameter("@CreditLimit", dtoObject.CreditLimit)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@PrimaryAddID", dtoObject.PrimaryAddID)
.AddParameter("@PrimaryAdd1", dtoObject.PrimaryAdd1)
.AddParameter("@PrimaryAdd2", dtoObject.PrimaryAdd2)
.AddParameter("@PrimaryCity", dtoObject.PrimaryCity)
.AddParameter("@PrimaryZipCode", dtoObject.PrimaryZipCode)
.AddParameter("@PrimaryState", dtoObject.PrimaryState)
.AddParameter("@PrimaryCountry", dtoObject.PrimaryCountry)
.AddParameter("@PrimaryPhone", dtoObject.PrimaryPhone)
.AddParameter("@PrimaryEmail", dtoObject.PrimaryEmail)
.AddParameter("@PrimaryFax", dtoObject.PrimaryFax)
.AddParameter("@PrimaryUrl", dtoObject.PrimaryUrl)
.AddParameter("@PhotoLocal", dtoObject.PhotoLocal)
.AddParameter("@InCorporatonNo", dtoObject.InCorporatonNo)
.AddParameter("@PanNo", dtoObject.PanNo)
.AddParameter("@TanNo", dtoObject.TanNo)
.AddParameter("@TinNo", dtoObject.TinNo)
.AddParameter("@ServiceTaxNo", dtoObject.ServiceTaxNo)
.AddParameter("@CompanyType", dtoObject.CompanyType)

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
                StoredProcedure(MasterConstant.CompanyDeleteByPrimaryKey)
                    .AddParameter("@CompanyID"
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
        public bool Delete(Company dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.CompanyDeleteByPrimaryKey)
                    .AddParameter("@CompanyID", dtoObject.CompanyID)

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

        public Company SelectByPrimaryKey(Guid Keys)
        {
            Company obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CompanySelectByPrimaryKey)
                            .AddParameter("@CompanyID"
,Keys)
                            .Fetch<Company>();
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
        public List<Company> SelectByField(string fieldName, object value)
        {
            List<Company> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CompanySelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Company>();

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
                obj = StoredProcedure(MasterConstant.CompanySelectByField) 
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
                StoredProcedure(MasterConstant.CompanyDeleteByField) 
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

        public DataSet SelectCompanyData(Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.CompanySelectData)
                                            .AddParameter("@CompanyID", CompanyID)
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

        public DataSet SelectAllCompanyData(Guid? CompanyID, string CompanyName, string DisplayName, string CompanyCode, Guid? CompanyType)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.CompanySelectAllCompanyData)
                                            .AddParameter("@CompanyID", CompanyID)
                                            .AddParameter("@CompanyName", CompanyName)
                                            .AddParameter("@DisplayName", DisplayName)
                                            .AddParameter("@CompanyCode", CompanyCode)
                                            .AddParameter("@CompanyType", CompanyType)
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

        #endregion
	}
}
