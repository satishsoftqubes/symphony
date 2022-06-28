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
using SQT.Symphony.BusinessLogic.BackOffice.DTO;
using SQT.Symphony.BusinessLogic.BackOffice.COMMON;

namespace SQT.Symphony.BusinessLogic.BackOffice.DAL
{
	/// <summary>
	/// Data access layer class for AccountConfig
	/// </summary>
	public class AccountConfigDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public AccountConfigDAL() :  base()
		{
			// Nothing for now.
		}
        public AccountConfigDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<AccountConfig> SelectAll(AccountConfig dtoObject)
        {
            List<AccountConfig> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.AccountConfigSelectAll)
                                                .AddParameter("@AcctConfigID", dtoObject.AcctConfigID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@AccountingMethod_TermID", dtoObject.AccountingMethod_TermID)
.AddParameter("@IsStockInHandCompulsoryBeforeSold", dtoObject.IsStockInHandCompulsoryBeforeSold)
.AddParameter("@IsBillRequiredBeforePayment", dtoObject.IsBillRequiredBeforePayment)
.AddParameter("@IsUpdateStockOnReceiveGoods", dtoObject.IsUpdateStockOnReceiveGoods)
.AddParameter("@IsUpdateStockOnDeliveryChallan", dtoObject.IsUpdateStockOnDeliveryChallan)
.AddParameter("@IsPartialPaymentAllowed", dtoObject.IsPartialPaymentAllowed)
.AddParameter("@IsPostingDoneAutomatically", dtoObject.IsPostingDoneAutomatically)
.AddParameter("@IsPostingRemainderAtNightAudit", dtoObject.IsPostingRemainderAtNightAudit)
.AddParameter("@IsAutoGenAcctCode", dtoObject.IsAutoGenAcctCode)
.AddParameter("@IsAutoGenItemCode", dtoObject.IsAutoGenItemCode)
.AddParameter("@IsAutoGenAgentCode", dtoObject.IsAutoGenAgentCode)
.AddParameter("@IsAutoGenCustomerCode", dtoObject.IsAutoGenCustomerCode)
.AddParameter("@IsAutoGenGuestCode", dtoObject.IsAutoGenGuestCode)
.AddParameter("@IsAutoGenVendorCode", dtoObject.IsAutoGenVendorCode)
.AddParameter("@CurrentFinancialYearID", dtoObject.CurrentFinancialYearID)
.AddParameter("@DefaultCurrencyID", dtoObject.DefaultCurrencyID)
.AddParameter("@CurrencyConversionRate", dtoObject.CurrencyConversionRate)
.AddParameter("@IsAutoConversion", dtoObject.IsAutoConversion)
.AddParameter("@IsTaxBreakUpInInvoice", dtoObject.IsTaxBreakUpInInvoice)
.AddParameter("@IsAdjustmentAllowed", dtoObject.IsAdjustmentAllowed)
.AddParameter("@DecimalPlaces", dtoObject.DecimalPlaces)
.AddParameter("@AccountFolioDate_TermID", dtoObject.AccountFolioDate_TermID)
.AddParameter("@IsCounterCompulsoryOnPosting", dtoObject.IsCounterCompulsoryOnPosting)
.AddParameter("@IsCounterLoginCoumpOnDayEnd", dtoObject.IsCounterLoginCoumpOnDayEnd)
.AddParameter("@IsInclusiveTax", dtoObject.IsInclusiveTax)

                                                .WithTransaction(dbtr)
                                                .FetchAll<AccountConfig>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.AccountConfigSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<AccountConfig>();
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

        public List<AccountConfig> SelectAll()
        {
            List<AccountConfig> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.AccountConfigSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<AccountConfig>();
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
        public DataSet SelectAllWithDataSet(AccountConfig dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.AccountConfigSelectAll)
                                                .AddParameter("@AcctConfigID", dtoObject.AcctConfigID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@AccountingMethod_TermID", dtoObject.AccountingMethod_TermID)
.AddParameter("@IsStockInHandCompulsoryBeforeSold", dtoObject.IsStockInHandCompulsoryBeforeSold)
.AddParameter("@IsBillRequiredBeforePayment", dtoObject.IsBillRequiredBeforePayment)
.AddParameter("@IsUpdateStockOnReceiveGoods", dtoObject.IsUpdateStockOnReceiveGoods)
.AddParameter("@IsUpdateStockOnDeliveryChallan", dtoObject.IsUpdateStockOnDeliveryChallan)
.AddParameter("@IsPartialPaymentAllowed", dtoObject.IsPartialPaymentAllowed)
.AddParameter("@IsPostingDoneAutomatically", dtoObject.IsPostingDoneAutomatically)
.AddParameter("@IsPostingRemainderAtNightAudit", dtoObject.IsPostingRemainderAtNightAudit)
.AddParameter("@IsAutoGenAcctCode", dtoObject.IsAutoGenAcctCode)
.AddParameter("@IsAutoGenItemCode", dtoObject.IsAutoGenItemCode)
.AddParameter("@IsAutoGenAgentCode", dtoObject.IsAutoGenAgentCode)
.AddParameter("@IsAutoGenCustomerCode", dtoObject.IsAutoGenCustomerCode)
.AddParameter("@IsAutoGenGuestCode", dtoObject.IsAutoGenGuestCode)
.AddParameter("@IsAutoGenVendorCode", dtoObject.IsAutoGenVendorCode)
.AddParameter("@CurrentFinancialYearID", dtoObject.CurrentFinancialYearID)
.AddParameter("@DefaultCurrencyID", dtoObject.DefaultCurrencyID)
.AddParameter("@CurrencyConversionRate", dtoObject.CurrencyConversionRate)
.AddParameter("@IsAutoConversion", dtoObject.IsAutoConversion)
.AddParameter("@IsTaxBreakUpInInvoice", dtoObject.IsTaxBreakUpInInvoice)
.AddParameter("@IsAdjustmentAllowed", dtoObject.IsAdjustmentAllowed)
.AddParameter("@DecimalPlaces", dtoObject.DecimalPlaces)
.AddParameter("@AccountFolioDate_TermID", dtoObject.AccountFolioDate_TermID)
.AddParameter("@IsCounterCompulsoryOnPosting", dtoObject.IsCounterCompulsoryOnPosting)
.AddParameter("@IsCounterLoginCoumpOnDayEnd", dtoObject.IsCounterLoginCoumpOnDayEnd)
.AddParameter("@IsInclusiveTax", dtoObject.IsInclusiveTax)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.AccountConfigSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.AccountConfigSelectAll)
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
		public bool Insert(AccountConfig dtoObject)
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

                    StoredProcedure(MasterDALConstant.AccountConfigInsert)
                        .AddParameter("@AcctConfigID", dtoObject.AcctConfigID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@AccountingMethod_TermID", dtoObject.AccountingMethod_TermID)
.AddParameter("@IsStockInHandCompulsoryBeforeSold", dtoObject.IsStockInHandCompulsoryBeforeSold)
.AddParameter("@IsBillRequiredBeforePayment", dtoObject.IsBillRequiredBeforePayment)
.AddParameter("@IsUpdateStockOnReceiveGoods", dtoObject.IsUpdateStockOnReceiveGoods)
.AddParameter("@IsUpdateStockOnDeliveryChallan", dtoObject.IsUpdateStockOnDeliveryChallan)
.AddParameter("@IsPartialPaymentAllowed", dtoObject.IsPartialPaymentAllowed)
.AddParameter("@IsPostingDoneAutomatically", dtoObject.IsPostingDoneAutomatically)
.AddParameter("@IsPostingRemainderAtNightAudit", dtoObject.IsPostingRemainderAtNightAudit)
.AddParameter("@IsAutoGenAcctCode", dtoObject.IsAutoGenAcctCode)
.AddParameter("@IsAutoGenItemCode", dtoObject.IsAutoGenItemCode)
.AddParameter("@IsAutoGenAgentCode", dtoObject.IsAutoGenAgentCode)
.AddParameter("@IsAutoGenCustomerCode", dtoObject.IsAutoGenCustomerCode)
.AddParameter("@IsAutoGenGuestCode", dtoObject.IsAutoGenGuestCode)
.AddParameter("@IsAutoGenVendorCode", dtoObject.IsAutoGenVendorCode)
.AddParameter("@CurrentFinancialYearID", dtoObject.CurrentFinancialYearID)
.AddParameter("@DefaultCurrencyID", dtoObject.DefaultCurrencyID)
.AddParameter("@CurrencyConversionRate", dtoObject.CurrencyConversionRate)
.AddParameter("@IsAutoConversion", dtoObject.IsAutoConversion)
.AddParameter("@IsTaxBreakUpInInvoice", dtoObject.IsTaxBreakUpInInvoice)
.AddParameter("@IsAdjustmentAllowed", dtoObject.IsAdjustmentAllowed)
.AddParameter("@DecimalPlaces", dtoObject.DecimalPlaces)
.AddParameter("@AccountFolioDate_TermID", dtoObject.AccountFolioDate_TermID)
.AddParameter("@IsCounterCompulsoryOnPosting", dtoObject.IsCounterCompulsoryOnPosting)
.AddParameter("@IsCounterLoginCoumpOnDayEnd", dtoObject.IsCounterLoginCoumpOnDayEnd)
.AddParameter("@IsInclusiveTax", dtoObject.IsInclusiveTax)

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
        public bool Update(AccountConfig dtoObject)
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

                    StoredProcedure(MasterDALConstant.AccountConfigUpdate)
                        .AddParameter("@AcctConfigID", dtoObject.AcctConfigID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@AccountingMethod_TermID", dtoObject.AccountingMethod_TermID)
.AddParameter("@IsStockInHandCompulsoryBeforeSold", dtoObject.IsStockInHandCompulsoryBeforeSold)
.AddParameter("@IsBillRequiredBeforePayment", dtoObject.IsBillRequiredBeforePayment)
.AddParameter("@IsUpdateStockOnReceiveGoods", dtoObject.IsUpdateStockOnReceiveGoods)
.AddParameter("@IsUpdateStockOnDeliveryChallan", dtoObject.IsUpdateStockOnDeliveryChallan)
.AddParameter("@IsPartialPaymentAllowed", dtoObject.IsPartialPaymentAllowed)
.AddParameter("@IsPostingDoneAutomatically", dtoObject.IsPostingDoneAutomatically)
.AddParameter("@IsPostingRemainderAtNightAudit", dtoObject.IsPostingRemainderAtNightAudit)
.AddParameter("@IsAutoGenAcctCode", dtoObject.IsAutoGenAcctCode)
.AddParameter("@IsAutoGenItemCode", dtoObject.IsAutoGenItemCode)
.AddParameter("@IsAutoGenAgentCode", dtoObject.IsAutoGenAgentCode)
.AddParameter("@IsAutoGenCustomerCode", dtoObject.IsAutoGenCustomerCode)
.AddParameter("@IsAutoGenGuestCode", dtoObject.IsAutoGenGuestCode)
.AddParameter("@IsAutoGenVendorCode", dtoObject.IsAutoGenVendorCode)
.AddParameter("@CurrentFinancialYearID", dtoObject.CurrentFinancialYearID)
.AddParameter("@DefaultCurrencyID", dtoObject.DefaultCurrencyID)
.AddParameter("@CurrencyConversionRate", dtoObject.CurrencyConversionRate)
.AddParameter("@IsAutoConversion", dtoObject.IsAutoConversion)
.AddParameter("@IsTaxBreakUpInInvoice", dtoObject.IsTaxBreakUpInInvoice)
.AddParameter("@IsAdjustmentAllowed", dtoObject.IsAdjustmentAllowed)
.AddParameter("@DecimalPlaces", dtoObject.DecimalPlaces)
.AddParameter("@AccountFolioDate_TermID", dtoObject.AccountFolioDate_TermID)
.AddParameter("@IsCounterCompulsoryOnPosting", dtoObject.IsCounterCompulsoryOnPosting)
.AddParameter("@IsCounterLoginCoumpOnDayEnd", dtoObject.IsCounterLoginCoumpOnDayEnd)
.AddParameter("@IsInclusiveTax", dtoObject.IsInclusiveTax)

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
                StoredProcedure(MasterDALConstant.AccountConfigDeleteByPrimaryKey)
                    .AddParameter("@AcctConfigID"
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
        public bool Delete(AccountConfig dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.AccountConfigDeleteByPrimaryKey)
                    .AddParameter("@AcctConfigID", dtoObject.AcctConfigID)

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

        public AccountConfig SelectByPrimaryKey(Guid Keys)
        {
            AccountConfig obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.AccountConfigSelectByPrimaryKey)
                            .AddParameter("@AcctConfigID"
,Keys)
                            .Fetch<AccountConfig>();
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
        public List<AccountConfig> SelectByField(string fieldName, object value)
        {
            List<AccountConfig> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.AccountConfigSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<AccountConfig>();

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
                obj = StoredProcedure(MasterDALConstant.AccountConfigSelectByField) 
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
                StoredProcedure(MasterDALConstant.AccountConfigDeleteByField) 
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
