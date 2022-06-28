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
	/// Data access layer class for Corporate
	/// </summary>
	public class CorporateDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public CorporateDAL() :  base()
		{
			// Nothing for now.
		}
        public CorporateDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Corporate> SelectAll(Corporate dtoObject)
        {
            List<Corporate> obj = null;
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
                        obj = StoredProcedure(MasterConstant.CorporateSelectAll)
                                                .AddParameter("@CorporateID", dtoObject.CorporateID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@Code", dtoObject.Code)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@DisplayName", dtoObject.DisplayName)
.AddParameter("@CorporateType_TermID", dtoObject.CorporateType_TermID)
.AddParameter("@DBAcctID", dtoObject.DBAcctID)
.AddParameter("@ComissionAcctID", dtoObject.ComissionAcctID)
.AddParameter("@IsDirectBill", dtoObject.IsDirectBill)
.AddParameter("@IsComission", dtoObject.IsComission)
.AddParameter("@IsComissionFlat", dtoObject.IsComissionFlat)
.AddParameter("@ComissionValue", dtoObject.ComissionValue)
.AddParameter("@ComissionFlag_TermID", dtoObject.ComissionFlag_TermID)
.AddParameter("@Notes", dtoObject.Notes)
.AddParameter("@DefaultResStatus_TermID", dtoObject.DefaultResStatus_TermID)
.AddParameter("@IsBlock", dtoObject.IsBlock)
.AddParameter("@BlockReason", dtoObject.BlockReason)
.AddParameter("@ApplicationUserID", dtoObject.ApplicationUserID)
.AddParameter("@Turnover", dtoObject.Turnover)
.AddParameter("@DefaultRateID", dtoObject.DefaultRateID)
.AddParameter("@VoucherTitle", dtoObject.VoucherTitle)
.AddParameter("@VoucherImage", dtoObject.VoucherImage)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@Department", dtoObject.Department)
.AddParameter("@Designation", dtoObject.Designation)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Corporate>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.CorporateSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Corporate>();
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

        public List<Corporate> SelectAllWithSearchData(Corporate dtoObject)
        {
            List<Corporate> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    if (dtoObject != null)
                        parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                    if (dtoObject != null)
                    {
                        obj = StoredProcedure(MasterConstant.CorporateSelectAllSearchData)
                                                .AddParameter("@CorporateID", dtoObject.CorporateID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@Code", dtoObject.Code)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@DisplayName", dtoObject.DisplayName)
.AddParameter("@CorporateType_TermID", dtoObject.CorporateType_TermID)
.AddParameter("@DBAcctID", dtoObject.DBAcctID)
.AddParameter("@ComissionAcctID", dtoObject.ComissionAcctID)
.AddParameter("@IsDirectBill", dtoObject.IsDirectBill)
.AddParameter("@IsComission", dtoObject.IsComission)
.AddParameter("@IsComissionFlat", dtoObject.IsComissionFlat)
.AddParameter("@ComissionValue", dtoObject.ComissionValue)
.AddParameter("@ComissionFlag_TermID", dtoObject.ComissionFlag_TermID)
.AddParameter("@Notes", dtoObject.Notes)
.AddParameter("@DefaultResStatus_TermID", dtoObject.DefaultResStatus_TermID)
.AddParameter("@IsBlock", dtoObject.IsBlock)
.AddParameter("@BlockReason", dtoObject.BlockReason)
.AddParameter("@ApplicationUserID", dtoObject.ApplicationUserID)
.AddParameter("@Turnover", dtoObject.Turnover)
.AddParameter("@DefaultRateID", dtoObject.DefaultRateID)
.AddParameter("@VoucherTitle", dtoObject.VoucherTitle)
.AddParameter("@VoucherImage", dtoObject.VoucherImage)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@Department", dtoObject.Department)
.AddParameter("@Designation", dtoObject.Designation)
.AddParameter("@AddressID", dtoObject.AddressID)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Corporate>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.CorporateSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Corporate>();
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

        public List<Corporate> SelectAll()
        {
            List<Corporate> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.CorporateSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Corporate>();
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

        public DataSet SelectAllWithDataSet(Corporate dtoObject)
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
                        obj = StoredProcedure(MasterConstant.CorporateSelectAll)
                                                .AddParameter("@CorporateID", dtoObject.CorporateID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@Code", dtoObject.Code)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@DisplayName", dtoObject.DisplayName)
.AddParameter("@CorporateType_TermID", dtoObject.CorporateType_TermID)
.AddParameter("@DBAcctID", dtoObject.DBAcctID)
.AddParameter("@ComissionAcctID", dtoObject.ComissionAcctID)
.AddParameter("@IsDirectBill", dtoObject.IsDirectBill)
.AddParameter("@IsComission", dtoObject.IsComission)
.AddParameter("@IsComissionFlat", dtoObject.IsComissionFlat)
.AddParameter("@ComissionValue", dtoObject.ComissionValue)
.AddParameter("@ComissionFlag_TermID", dtoObject.ComissionFlag_TermID)
.AddParameter("@Notes", dtoObject.Notes)
.AddParameter("@DefaultResStatus_TermID", dtoObject.DefaultResStatus_TermID)
.AddParameter("@IsBlock", dtoObject.IsBlock)
.AddParameter("@BlockReason", dtoObject.BlockReason)
.AddParameter("@ApplicationUserID", dtoObject.ApplicationUserID)
.AddParameter("@Turnover", dtoObject.Turnover)
.AddParameter("@DefaultRateID", dtoObject.DefaultRateID)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@ContactNo", dtoObject.ContactNo)
.AddParameter("@Fax", dtoObject.Fax)
.AddParameter("@VoucherTitle", dtoObject.VoucherTitle)
.AddParameter("@VoucherImage", dtoObject.VoucherImage)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@Department", dtoObject.Department)
.AddParameter("@Designation", dtoObject.Designation)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.CorporateSelectAll)
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

                    obj = StoredProcedure(MasterConstant.CorporateSelectAll)
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
		public bool Insert(Corporate dtoObject)
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

                    StoredProcedure(MasterConstant.CorporateInsert)
                        .AddParameter("@CorporateID", dtoObject.CorporateID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@Code", dtoObject.Code)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@DisplayName", dtoObject.DisplayName)
.AddParameter("@CorporateType_TermID", dtoObject.CorporateType_TermID)
.AddParameter("@DBAcctID", dtoObject.DBAcctID)
.AddParameter("@ComissionAcctID", dtoObject.ComissionAcctID)
.AddParameter("@IsDirectBill", dtoObject.IsDirectBill)
.AddParameter("@IsComission", dtoObject.IsComission)
.AddParameter("@IsComissionFlat", dtoObject.IsComissionFlat)
.AddParameter("@ComissionValue", dtoObject.ComissionValue)
.AddParameter("@ComissionFlag_TermID", dtoObject.ComissionFlag_TermID)
.AddParameter("@Notes", dtoObject.Notes)
.AddParameter("@DefaultResStatus_TermID", dtoObject.DefaultResStatus_TermID)
.AddParameter("@IsBlock", dtoObject.IsBlock)
.AddParameter("@BlockReason", dtoObject.BlockReason)
.AddParameter("@ApplicationUserID", dtoObject.ApplicationUserID)
.AddParameter("@Turnover", dtoObject.Turnover)
.AddParameter("@DefaultRateID", dtoObject.DefaultRateID)
.AddParameter("@AddressID", dtoObject.AddressID)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@ContactNo", dtoObject.ContactNo)
.AddParameter("@Fax", dtoObject.Fax)
.AddParameter("@VoucherTitle", dtoObject.VoucherTitle)
.AddParameter("@VoucherImage", dtoObject.VoucherImage)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@Department", dtoObject.Department)
.AddParameter("@Designation", dtoObject.Designation)

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
        public bool Update(Corporate dtoObject)
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

                    StoredProcedure(MasterConstant.CorporateUpdate)
                        .AddParameter("@CorporateID", dtoObject.CorporateID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@Code", dtoObject.Code)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@DisplayName", dtoObject.DisplayName)
.AddParameter("@CorporateType_TermID", dtoObject.CorporateType_TermID)
.AddParameter("@DBAcctID", dtoObject.DBAcctID)
.AddParameter("@ComissionAcctID", dtoObject.ComissionAcctID)
.AddParameter("@IsDirectBill", dtoObject.IsDirectBill)
.AddParameter("@IsComission", dtoObject.IsComission)
.AddParameter("@IsComissionFlat", dtoObject.IsComissionFlat)
.AddParameter("@ComissionValue", dtoObject.ComissionValue)
.AddParameter("@ComissionFlag_TermID", dtoObject.ComissionFlag_TermID)
.AddParameter("@Notes", dtoObject.Notes)
.AddParameter("@DefaultResStatus_TermID", dtoObject.DefaultResStatus_TermID)
.AddParameter("@IsBlock", dtoObject.IsBlock)
.AddParameter("@BlockReason", dtoObject.BlockReason)
.AddParameter("@ApplicationUserID", dtoObject.ApplicationUserID)
.AddParameter("@Turnover", dtoObject.Turnover)
.AddParameter("@DefaultRateID", dtoObject.DefaultRateID)
.AddParameter("@AddressID", dtoObject.AddressID)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@ContactNo", dtoObject.ContactNo)
.AddParameter("@Fax", dtoObject.Fax)
.AddParameter("@VoucherTitle", dtoObject.VoucherTitle)
.AddParameter("@VoucherImage", dtoObject.VoucherImage)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@Department", dtoObject.Department)
.AddParameter("@Designation", dtoObject.Designation)

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
                StoredProcedure(MasterConstant.CorporateDeleteByPrimaryKey)
                    .AddParameter("@CorporateID"
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
        public bool Delete(Corporate dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.CorporateDeleteByPrimaryKey)
                    .AddParameter("@CorporateID", dtoObject.CorporateID)

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

        public Corporate SelectByPrimaryKey(Guid Keys)
        {
            Corporate obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CorporateSelectByPrimaryKey)
                            .AddParameter("@CorporateID"
,Keys)
                            .Fetch<Corporate>();
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

        public DataSet SelectDataSetByPrimaryKey(Guid Keys)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CorporateSelectByPrimaryKey)
                            .AddParameter("@CorporateID", Keys)
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

        public List<Corporate> SelectByField(string fieldName, object value)
        {
            List<Corporate> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CorporateSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Corporate>();

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
                obj = StoredProcedure(MasterConstant.CorporateSelectByField) 
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

        public DataSet SelectAllForRateCard(Guid companyID, Guid propertyID, Guid rateCardID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CorporateSelectAllForRateCard)
                                    .AddParameter("@CompanyID", companyID)
                                    .AddParameter("@PropertyID", propertyID)
                                    .AddParameter("@RateID", rateCardID)
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

        public bool UpdateDefaultRateID(string updateMode, Guid? corporateID, Guid? defaultRateID)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterConstant.CorporateUpdateDefaultRateID)
                        .AddParameter("@UpdateMode", updateMode)
                        .AddParameter("@CorporateID", corporateID)
                        .AddParameter("@DefaultRateID", defaultRateID)

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

        public bool DeleteByField(string fieldName, object value)
        {
            try
            {
                StoredProcedure(MasterConstant.CorporateDeleteByField) 
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

        public bool UpdateVoucherImage(Guid? CompanyID, Guid? PropertyID, Guid? CorporateID, string VoucherImage)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    StoredProcedure(MasterConstant.CorporateUpdateVoucherImage)
                        .AddParameter("@CorporateID", CorporateID)
                        .AddParameter("@PropertyID", PropertyID)
                        .AddParameter("@CompanyID", CompanyID)
                        .AddParameter("@VoucherImage", VoucherImage)                        
                        
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

        public DataSet SearchAgentData(Guid? PropertyID, Guid? CompanyID, string Name, string CompanyName, bool? IsDirectBill)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CorporateSearchAgentData)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@Name", Name)
                                    .AddParameter("@CompanyName", CompanyName)
                                    .AddParameter("@IsDirectBill", IsDirectBill)
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

        public DataSet SelectCompanyData(Guid? CompanyID, Guid? PropertyID, bool? IsDirectBill)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.CorporateSelectCompanyList)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@IsDirectBill", IsDirectBill)
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
        public DataSet SelectAgentWithReceipt(Guid? CompanyID, Guid? PropertyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.AgentSelectAgentWithReceipt)
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
