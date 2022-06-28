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
	/// Data access layer class for PropertyConfiguration
	/// </summary>
	public class PropertyConfigurationDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public PropertyConfigurationDAL() :  base()
		{
			// Nothing for now.
		}
        public PropertyConfigurationDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<PropertyConfiguration> SelectAll(PropertyConfiguration dtoObject)
        {
            List<PropertyConfiguration> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    if(dtoObject != null)
                        parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                    if(dtoObject != null)  
                    {
                        obj = StoredProcedure(MasterConstant.PropertyConfigurationSelectAll)
                                                .AddParameter("@PropertyConfigurationID", dtoObject.PropertyConfigurationID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@DateFormatID", dtoObject.DateFormatID)
.AddParameter("@TimeFormatID", dtoObject.TimeFormatID)
.AddParameter("@SmtpAddress", dtoObject.SmtpAddress)
.AddParameter("@POP3InServer", dtoObject.POP3InServer)
.AddParameter("@POP3OutGoingServer", dtoObject.POP3OutGoingServer)
.AddParameter("@UserName", dtoObject.UserName)
.AddParameter("@Password", dtoObject.Password)
.AddParameter("@PrimoryDomainName", dtoObject.PrimoryDomainName)
.AddParameter("@PrimoryEmail", dtoObject.PrimoryEmail)
.AddParameter("@IsADPlugIn", dtoObject.IsADPlugIn)
.AddParameter("@DNSName", dtoObject.DNSName)
.AddParameter("@BaseCurrencyCode", dtoObject.BaseCurrencyCode)
.AddParameter("@NoOfCounters", dtoObject.NoOfCounters)
.AddParameter("@IsSkipPostCode", dtoObject.IsSkipPostCode)
.AddParameter("@IsSkipAddress", dtoObject.IsSkipAddress)
.AddParameter("@IsSkipEmail", dtoObject.IsSkipEmail)
.AddParameter("@IsSkipContactNo", dtoObject.IsSkipContactNo)
.AddParameter("@IsIdenticationReg", dtoObject.IsIdenticationReg)
.AddParameter("@Updatelog", dtoObject.Updatelog)
.AddParameter("@RoodDescription", dtoObject.RoodDescription)
.AddParameter("@TubeDescription", dtoObject.TubeDescription)
.AddParameter("@ByAirDescription", dtoObject.ByAirDescription)
.AddParameter("@ByPublicTranspertation", dtoObject.ByPublicTranspertation)
.AddParameter("@MapView", dtoObject.MapView)
.AddParameter("@LastUpdateOn", dtoObject.LastUpdateOn)
.AddParameter("@LastUpdateBy", dtoObject.LastUpdateBy)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@PhotoLocal", dtoObject.PhotoLocal)
.AddParameter("@CompanyID",dtoObject.CompanyID)

                                                .WithTransaction(dbtr)
                                                .FetchAll<PropertyConfiguration>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.PropertyConfigurationSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<PropertyConfiguration>();
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

        public List<PropertyConfiguration> SelectAll()
        {
            List<PropertyConfiguration> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.PropertyConfigurationSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<PropertyConfiguration>();
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
        public DataSet SelectAllWithDataSet(PropertyConfiguration dtoObject)
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
                        obj = StoredProcedure(MasterConstant.PropertyConfigurationSelectAll)
                                                .AddParameter("@PropertyConfigurationID", dtoObject.PropertyConfigurationID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@DateFormatID", dtoObject.DateFormatID)
.AddParameter("@TimeFormatID", dtoObject.TimeFormatID)
.AddParameter("@SmtpAddress", dtoObject.SmtpAddress)
.AddParameter("@POP3InServer", dtoObject.POP3InServer)
.AddParameter("@POP3OutGoingServer", dtoObject.POP3OutGoingServer)
.AddParameter("@UserName", dtoObject.UserName)
.AddParameter("@Password", dtoObject.Password)
.AddParameter("@PrimoryDomainName", dtoObject.PrimoryDomainName)
.AddParameter("@PrimoryEmail", dtoObject.PrimoryEmail)
.AddParameter("@IsADPlugIn", dtoObject.IsADPlugIn)
.AddParameter("@DNSName", dtoObject.DNSName)
.AddParameter("@BaseCurrencyCode", dtoObject.BaseCurrencyCode)
.AddParameter("@NoOfCounters", dtoObject.NoOfCounters)
.AddParameter("@IsSkipPostCode", dtoObject.IsSkipPostCode)
.AddParameter("@IsSkipAddress", dtoObject.IsSkipAddress)
.AddParameter("@IsSkipEmail", dtoObject.IsSkipEmail)
.AddParameter("@IsSkipContactNo", dtoObject.IsSkipContactNo)
.AddParameter("@IsIdenticationReg", dtoObject.IsIdenticationReg)
.AddParameter("@Updatelog", dtoObject.Updatelog)
.AddParameter("@RoodDescription", dtoObject.RoodDescription)
.AddParameter("@TubeDescription", dtoObject.TubeDescription)
.AddParameter("@ByAirDescription", dtoObject.ByAirDescription)
.AddParameter("@ByPublicTranspertation", dtoObject.ByPublicTranspertation)
.AddParameter("@MapView", dtoObject.MapView)
.AddParameter("@LastUpdateOn", dtoObject.LastUpdateOn)
.AddParameter("@LastUpdateBy", dtoObject.LastUpdateBy)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@PhotoLocal", dtoObject.PhotoLocal)
.AddParameter("@CompanyID", dtoObject.CompanyID)
                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.PropertyConfigurationSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
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

        public DataSet SelectAllWithDataSet()
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.PropertyConfigurationSelectAll)
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
		public bool Insert(PropertyConfiguration dtoObject)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    if (dtoObject == null)
                        throw (new ParameterNullException("Object can not be null"));

                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterConstant.PropertyConfigurationInsert)
                        .AddParameter("@PropertyConfigurationID", dtoObject.PropertyConfigurationID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@DateFormatID", dtoObject.DateFormatID)
.AddParameter("@TimeFormatID", dtoObject.TimeFormatID)
.AddParameter("@SmtpAddress", dtoObject.SmtpAddress)
.AddParameter("@POP3InServer", dtoObject.POP3InServer)
.AddParameter("@POP3OutGoingServer", dtoObject.POP3OutGoingServer)
.AddParameter("@UserName", dtoObject.UserName)
.AddParameter("@Password", dtoObject.Password)
.AddParameter("@PrimoryDomainName", dtoObject.PrimoryDomainName)
.AddParameter("@PrimoryEmail", dtoObject.PrimoryEmail)
.AddParameter("@IsADPlugIn", dtoObject.IsADPlugIn)
.AddParameter("@DNSName", dtoObject.DNSName)
.AddParameter("@BaseCurrencyCode", dtoObject.BaseCurrencyCode)
.AddParameter("@NoOfCounters", dtoObject.NoOfCounters)
.AddParameter("@IsSkipPostCode", dtoObject.IsSkipPostCode)
.AddParameter("@IsSkipAddress", dtoObject.IsSkipAddress)
.AddParameter("@IsSkipEmail", dtoObject.IsSkipEmail)
.AddParameter("@IsSkipContactNo", dtoObject.IsSkipContactNo)
.AddParameter("@IsIdenticationReg", dtoObject.IsIdenticationReg)
.AddParameter("@RoodDescription", dtoObject.RoodDescription)
.AddParameter("@TubeDescription", dtoObject.TubeDescription)
.AddParameter("@ByAirDescription", dtoObject.ByAirDescription)
.AddParameter("@ByPublicTranspertation", dtoObject.ByPublicTranspertation)
.AddParameter("@MapView", dtoObject.MapView)
.AddParameter("@LastUpdateOn", dtoObject.LastUpdateOn)
.AddParameter("@LastUpdateBy", dtoObject.LastUpdateBy)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@PhotoLocal", dtoObject.PhotoLocal)
.AddParameter("@CompanyID", dtoObject.CompanyID)
                        .WithTransaction(dbtr)
                        .Execute();
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
            return true;
        }

         /// <summary>
        /// update row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true for successfully updated</returns>
        public bool Update(PropertyConfiguration dtoObject)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    if (dtoObject == null)
                        throw (new ParameterNullException("Object can not be null"));

                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterConstant.PropertyConfigurationUpdate)
                        .AddParameter("@PropertyConfigurationID", dtoObject.PropertyConfigurationID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@DateFormatID", dtoObject.DateFormatID)
.AddParameter("@TimeFormatID", dtoObject.TimeFormatID)
.AddParameter("@SmtpAddress", dtoObject.SmtpAddress)
.AddParameter("@POP3InServer", dtoObject.POP3InServer)
.AddParameter("@POP3OutGoingServer", dtoObject.POP3OutGoingServer)
.AddParameter("@UserName", dtoObject.UserName)
.AddParameter("@Password", dtoObject.Password)
.AddParameter("@PrimoryDomainName", dtoObject.PrimoryDomainName)
.AddParameter("@PrimoryEmail", dtoObject.PrimoryEmail)
.AddParameter("@IsADPlugIn", dtoObject.IsADPlugIn)
.AddParameter("@DNSName", dtoObject.DNSName)
.AddParameter("@BaseCurrencyCode", dtoObject.BaseCurrencyCode)
.AddParameter("@NoOfCounters", dtoObject.NoOfCounters)
.AddParameter("@IsSkipPostCode", dtoObject.IsSkipPostCode)
.AddParameter("@IsSkipAddress", dtoObject.IsSkipAddress)
.AddParameter("@IsSkipEmail", dtoObject.IsSkipEmail)
.AddParameter("@IsSkipContactNo", dtoObject.IsSkipContactNo)
.AddParameter("@IsIdenticationReg", dtoObject.IsIdenticationReg)
.AddParameter("@Updatelog", dtoObject.Updatelog)
.AddParameter("@RoodDescription", dtoObject.RoodDescription)
.AddParameter("@TubeDescription", dtoObject.TubeDescription)
.AddParameter("@ByAirDescription", dtoObject.ByAirDescription)
.AddParameter("@ByPublicTranspertation", dtoObject.ByPublicTranspertation)
.AddParameter("@MapView", dtoObject.MapView)
.AddParameter("@LastUpdateOn", dtoObject.LastUpdateOn)
.AddParameter("@LastUpdateBy", dtoObject.LastUpdateBy)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@PhotoLocal", dtoObject.PhotoLocal)
.AddParameter("@CompanyID", dtoObject.CompanyID)
                        .WithTransaction(dbtr)
                        .Execute();
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
            return true;
        }
        public bool Delete(Guid Keys)
        {
            try
            {
                StoredProcedure(MasterConstant.PropertyConfigurationDeleteByPrimaryKey)
                    .AddParameter("@PropertyConfigurationID"
,Keys)
                    .WithTransaction(dbtr)
                    .Execute();
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
            return true;
        }
        public bool Delete(PropertyConfiguration dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.PropertyConfigurationDeleteByPrimaryKey)
                    .AddParameter("@PropertyConfigurationID", dtoObject.PropertyConfigurationID)

                    .WithTransaction(dbtr)
                    .Execute();
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
            return true;
        }

        public PropertyConfiguration SelectByPrimaryKey(Guid Keys)
        {
            PropertyConfiguration obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.PropertyConfigurationSelectByPrimaryKey)
                            .AddParameter("@PropertyConfigurationID"
,Keys)
                            .Fetch<PropertyConfiguration>();
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
        public List<PropertyConfiguration> SelectByField(string fieldName, object value)
        {
            List<PropertyConfiguration> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.PropertyConfigurationSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<PropertyConfiguration>();

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
        public DataSet SelectByFieldWithDataSet(string fieldName, object value)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.PropertyConfigurationSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchDataSet();

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

        public bool DeleteByField(string fieldName, object value)
        {
            try
            {
                StoredProcedure(MasterConstant.PropertyConfigurationDeleteByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .WithTransaction(dbtr)
                                    .Execute();
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
            return true;
        }

        public PropertyConfiguration SelectByCmpnAndPrpt(Guid? companyID,Guid? propertyID)
        {
            PropertyConfiguration obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.PropertyConfigurationSelectByCmpnAndPrpt)
                            .AddParameter("@CompanyID", companyID)
                            .AddParameter("@PropertyID", propertyID)
                            .Fetch<PropertyConfiguration>();
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
