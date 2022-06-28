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
	/// Data access layer class for SMSTemplates
	/// </summary>
	public class SMSTemplatesDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public SMSTemplatesDAL() :  base()
		{
			// Nothing for now.
		}
        public SMSTemplatesDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Search Data
        /// </summary>
        /// <param name="Title"></param>
        /// <returns></returns>
        public DataSet SearchData(string Title)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.SMSTemplateSearchDate)
                    .AddParameter("@Title",Title)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }
        public List<SMSTemplates> SelectAll(SMSTemplates dtoObject)
        {
            List<SMSTemplates> obj = null;
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
                        obj = StoredProcedure(MasterConstant.SMSTemplatesSelectAll)
                                                .AddParameter("@SMSTemplateID", dtoObject.SMSTemplateID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@SMSDetails", dtoObject.SMSDetails)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsOnUnitBooking", dtoObject.IsOnUnitBooking)
.AddParameter("@IsOnInvestorCreation", dtoObject.IsOnInvestorCreation)
.AddParameter("@IsOnUnitPaymentReceived", dtoObject.IsOnUnitPaymentReceived)
.AddParameter("@IsOnUnitTaxReceived", dtoObject.IsOnUnitTaxReceived)
.AddParameter("@IsOnUnitInsuranceReceived", dtoObject.IsOnUnitInsuranceReceived)
.AddParameter("@IsOther", dtoObject.IsOther)

                                                .WithTransaction(dbtr)
                                                .FetchAll<SMSTemplates>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.SMSTemplatesSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<SMSTemplates>();
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

        public List<SMSTemplates> SelectAll()
        {
            List<SMSTemplates> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.SMSTemplatesSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<SMSTemplates>();
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
        public DataSet SelectAllWithDataSet(SMSTemplates dtoObject)
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
                        obj = StoredProcedure(MasterConstant.SMSTemplatesSelectAll)
                                                .AddParameter("@SMSTemplateID", dtoObject.SMSTemplateID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@SMSDetails", dtoObject.SMSDetails)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsOnUnitBooking", dtoObject.IsOnUnitBooking)
.AddParameter("@IsOnInvestorCreation", dtoObject.IsOnInvestorCreation)
.AddParameter("@IsOnUnitPaymentReceived", dtoObject.IsOnUnitPaymentReceived)
.AddParameter("@IsOnUnitTaxReceived", dtoObject.IsOnUnitTaxReceived)
.AddParameter("@IsOnUnitInsuranceReceived", dtoObject.IsOnUnitInsuranceReceived)
.AddParameter("@IsOther", dtoObject.IsOther)
                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.SMSTemplatesSelectAll)
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

                    obj = StoredProcedure(MasterConstant.SMSTemplatesSelectAll)
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
		public bool Insert(SMSTemplates dtoObject)
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

                    StoredProcedure(MasterConstant.SMSTemplatesInsert)
                        .AddParameter("@SMSTemplateID", dtoObject.SMSTemplateID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@SMSDetails", dtoObject.SMSDetails)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsOnUnitBooking", dtoObject.IsOnUnitBooking)
.AddParameter("@IsOnInvestorCreation", dtoObject.IsOnInvestorCreation)
.AddParameter("@IsOnUnitPaymentReceived", dtoObject.IsOnUnitPaymentReceived)
.AddParameter("@IsOnUnitTaxReceived", dtoObject.IsOnUnitTaxReceived)
.AddParameter("@IsOnUnitInsuranceReceived", dtoObject.IsOnUnitInsuranceReceived)
.AddParameter("@IsOther", dtoObject.IsOther)
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
        public bool Update(SMSTemplates dtoObject)
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

                    StoredProcedure(MasterConstant.SMSTemplatesUpdate)
                        .AddParameter("@SMSTemplateID", dtoObject.SMSTemplateID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@SMSDetails", dtoObject.SMSDetails)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsOnUnitBooking", dtoObject.IsOnUnitBooking)
.AddParameter("@IsOnInvestorCreation", dtoObject.IsOnInvestorCreation)
.AddParameter("@IsOnUnitPaymentReceived", dtoObject.IsOnUnitPaymentReceived)
.AddParameter("@IsOnUnitTaxReceived", dtoObject.IsOnUnitTaxReceived)
.AddParameter("@IsOnUnitInsuranceReceived", dtoObject.IsOnUnitInsuranceReceived)
.AddParameter("@IsOther", dtoObject.IsOther)
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
                StoredProcedure(MasterConstant.SMSTemplatesDeleteByPrimaryKey)
                    .AddParameter("@SMSTemplateID"
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
        public bool Delete(SMSTemplates dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.SMSTemplatesDeleteByPrimaryKey)
                    .AddParameter("@SMSTemplateID", dtoObject.SMSTemplateID)

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

        public SMSTemplates SelectByPrimaryKey(Guid Keys)
        {
            SMSTemplates obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.SMSTemplatesSelectByPrimaryKey)
                            .AddParameter("@SMSTemplateID"
,Keys)
                            .Fetch<SMSTemplates>();
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
        public List<SMSTemplates> SelectByField(string fieldName, object value)
        {
            List<SMSTemplates> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.SMSTemplatesSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<SMSTemplates>();

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
                obj = StoredProcedure(MasterConstant.SMSTemplatesSelectByField) 
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
                StoredProcedure(MasterConstant.SMSTemplatesDeleteByField) 
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
