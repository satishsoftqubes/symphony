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
	/// Data access layer class for Account
	/// </summary>
	public class AccountDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public AccountDAL() :  base()
		{
			// Nothing for now.
		}
        public AccountDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Account> SelectAll(Account dtoObject)
        {
            List<Account> obj = null;
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
                        obj = StoredProcedure(MasterConstant.AccountSelectAll)
                                                .AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@RefAcctID", dtoObject.RefAcctID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@HardCodeAcctID", dtoObject.HardCodeAcctID)
.AddParameter("@AcctNo", dtoObject.AcctNo)
.AddParameter("@AcctName", dtoObject.AcctName)
.AddParameter("@AcctGroupID", dtoObject.AcctGroupID)
.AddParameter("@DefaultAmt", dtoObject.DefaultAmt)
.AddParameter("@IsDefaultAccount", dtoObject.IsDefaultAccount)
.AddParameter("@IsServiceAccount", dtoObject.IsServiceAccount)
.AddParameter("@IsItemAccount", dtoObject.IsItemAccount)
.AddParameter("@IsMOPAccount", dtoObject.IsMOPAccount)
.AddParameter("@IsRoomRevenueAccount", dtoObject.IsRoomRevenueAccount)
.AddParameter("@TransactionZone_TermID", dtoObject.TransactionZone_TermID)
.AddParameter("@IsEnable", dtoObject.IsEnable)
.AddParameter("@OpeningBalance", dtoObject.OpeningBalance)
.AddParameter("@BalanceType_TermID", dtoObject.BalanceType_TermID)
.AddParameter("@CurrentBalance", dtoObject.CurrentBalance)
.AddParameter("@IsTaxAcct", dtoObject.IsTaxAcct)
.AddParameter("@IsTaxFlat", dtoObject.IsTaxFlat)
.AddParameter("@TaxRate", dtoObject.TaxRate)
.AddParameter("@IsRefundable", dtoObject.IsRefundable)
.AddParameter("@MinValue", dtoObject.MinValue)
.AddParameter("@MaxValue", dtoObject.MaxValue)
.AddParameter("@TaxTypeID", dtoObject.TaxTypeID)
.AddParameter("@BalancyType_Term", dtoObject.BalancyType_Term)
.AddParameter("@SymphonyAcctGroupID", dtoObject.SymphonyAcctGroupID)
.AddParameter("@SymphonyAcctID", dtoObject.SymphonyAcctID)
.AddParameter("@IsPaidOut", dtoObject.IsPaidOut)
.AddParameter("@IsOverride", dtoObject.IsOverride)
.AddParameter("@IsShowInStatement", dtoObject.IsShowInStatement)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Account>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.AccountSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Account>();
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

        public List<Account> SelectAll()
        {
            List<Account> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.AccountSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Account>();
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
        public DataSet SelectAllWithDataSet(Account dtoObject)
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
                        obj = StoredProcedure(MasterConstant.AccountSelectAll)
                                                .AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@RefAcctID", dtoObject.RefAcctID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@HardCodeAcctID", dtoObject.HardCodeAcctID)
.AddParameter("@AcctNo", dtoObject.AcctNo)
.AddParameter("@AcctName", dtoObject.AcctName)
.AddParameter("@AcctGroupID", dtoObject.AcctGroupID)
.AddParameter("@DefaultAmt", dtoObject.DefaultAmt)
.AddParameter("@IsDefaultAccount", dtoObject.IsDefaultAccount)
.AddParameter("@IsServiceAccount", dtoObject.IsServiceAccount)
.AddParameter("@IsItemAccount", dtoObject.IsItemAccount)
.AddParameter("@IsMOPAccount", dtoObject.IsMOPAccount)
.AddParameter("@IsRoomRevenueAccount", dtoObject.IsRoomRevenueAccount)
.AddParameter("@TransactionZone_TermID", dtoObject.TransactionZone_TermID)
.AddParameter("@IsEnable", dtoObject.IsEnable)
.AddParameter("@OpeningBalance", dtoObject.OpeningBalance)
.AddParameter("@BalanceType_TermID", dtoObject.BalanceType_TermID)
.AddParameter("@CurrentBalance", dtoObject.CurrentBalance)
.AddParameter("@IsTaxAcct", dtoObject.IsTaxAcct)
.AddParameter("@IsTaxFlat", dtoObject.IsTaxFlat)
.AddParameter("@TaxRate", dtoObject.TaxRate)
.AddParameter("@IsRefundable", dtoObject.IsRefundable)
.AddParameter("@MinValue", dtoObject.MinValue)
.AddParameter("@MaxValue", dtoObject.MaxValue)
.AddParameter("@TaxTypeID", dtoObject.TaxTypeID)
.AddParameter("@BalancyType_Term", dtoObject.BalancyType_Term)
.AddParameter("@SymphonyAcctGroupID", dtoObject.SymphonyAcctGroupID)
.AddParameter("@SymphonyAcctID", dtoObject.SymphonyAcctID)
.AddParameter("@IsPaidOut", dtoObject.IsPaidOut)
.AddParameter("@IsOverride", dtoObject.IsOverride)
.AddParameter("@IsShowInStatement", dtoObject.IsShowInStatement)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)


                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.AccountSelectAll)
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

                    obj = StoredProcedure(MasterConstant.AccountSelectAll)
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
		public bool Insert(Account dtoObject)
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

                    StoredProcedure(MasterConstant.AccountInsert)
                        .AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@RefAcctID", dtoObject.RefAcctID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@HardCodeAcctID", dtoObject.HardCodeAcctID)
.AddParameter("@AcctNo", dtoObject.AcctNo)
.AddParameter("@AcctName", dtoObject.AcctName)
.AddParameter("@AcctGroupID", dtoObject.AcctGroupID)
.AddParameter("@DefaultAmt", dtoObject.DefaultAmt)
.AddParameter("@IsDefaultAccount", dtoObject.IsDefaultAccount)
.AddParameter("@IsServiceAccount", dtoObject.IsServiceAccount)
.AddParameter("@IsItemAccount", dtoObject.IsItemAccount)
.AddParameter("@IsMOPAccount", dtoObject.IsMOPAccount)
.AddParameter("@IsRoomRevenueAccount", dtoObject.IsRoomRevenueAccount)
.AddParameter("@TransactionZone_TermID", dtoObject.TransactionZone_TermID)
.AddParameter("@IsEnable", dtoObject.IsEnable)
.AddParameter("@OpeningBalance", dtoObject.OpeningBalance)
.AddParameter("@BalanceType_TermID", dtoObject.BalanceType_TermID)
.AddParameter("@CurrentBalance", dtoObject.CurrentBalance)
.AddParameter("@IsTaxAcct", dtoObject.IsTaxAcct)
.AddParameter("@IsTaxFlat", dtoObject.IsTaxFlat)
.AddParameter("@TaxRate", dtoObject.TaxRate)
.AddParameter("@IsRefundable", dtoObject.IsRefundable)
.AddParameter("@MinValue", dtoObject.MinValue)
.AddParameter("@MaxValue", dtoObject.MaxValue)
.AddParameter("@TaxTypeID", dtoObject.TaxTypeID)
.AddParameter("@BalancyType_Term", dtoObject.BalancyType_Term)
.AddParameter("@SymphonyAcctGroupID", dtoObject.SymphonyAcctGroupID)
.AddParameter("@SymphonyAcctID", dtoObject.SymphonyAcctID)
.AddParameter("@IsPaidOut", dtoObject.IsPaidOut)
.AddParameter("@IsOverride", dtoObject.IsOverride)
.AddParameter("@IsShowInStatement", dtoObject.IsShowInStatement)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)


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
        public bool Update(Account dtoObject)
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

                    StoredProcedure(MasterConstant.AccountUpdate)
                        .AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@RefAcctID", dtoObject.RefAcctID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@HardCodeAcctID", dtoObject.HardCodeAcctID)
.AddParameter("@AcctNo", dtoObject.AcctNo)
.AddParameter("@AcctName", dtoObject.AcctName)
.AddParameter("@AcctGroupID", dtoObject.AcctGroupID)
.AddParameter("@DefaultAmt", dtoObject.DefaultAmt)
.AddParameter("@IsDefaultAccount", dtoObject.IsDefaultAccount)
.AddParameter("@IsServiceAccount", dtoObject.IsServiceAccount)
.AddParameter("@IsItemAccount", dtoObject.IsItemAccount)
.AddParameter("@IsMOPAccount", dtoObject.IsMOPAccount)
.AddParameter("@IsRoomRevenueAccount", dtoObject.IsRoomRevenueAccount)
.AddParameter("@TransactionZone_TermID", dtoObject.TransactionZone_TermID)
.AddParameter("@IsEnable", dtoObject.IsEnable)
.AddParameter("@OpeningBalance", dtoObject.OpeningBalance)
.AddParameter("@BalanceType_TermID", dtoObject.BalanceType_TermID)
.AddParameter("@CurrentBalance", dtoObject.CurrentBalance)
.AddParameter("@IsTaxAcct", dtoObject.IsTaxAcct)
.AddParameter("@IsTaxFlat", dtoObject.IsTaxFlat)
.AddParameter("@TaxRate", dtoObject.TaxRate)
.AddParameter("@IsRefundable", dtoObject.IsRefundable)
.AddParameter("@MinValue", dtoObject.MinValue)
.AddParameter("@MaxValue", dtoObject.MaxValue)
.AddParameter("@TaxTypeID", dtoObject.TaxTypeID)
.AddParameter("@BalancyType_Term", dtoObject.BalancyType_Term)
.AddParameter("@SymphonyAcctGroupID", dtoObject.SymphonyAcctGroupID)
.AddParameter("@SymphonyAcctID", dtoObject.SymphonyAcctID)
.AddParameter("@IsPaidOut", dtoObject.IsPaidOut)
.AddParameter("@IsOverride", dtoObject.IsOverride)
.AddParameter("@IsShowInStatement", dtoObject.IsShowInStatement)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)

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
                StoredProcedure(MasterConstant.AccountDeleteByPrimaryKey)
                    .AddParameter("@AcctID"
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
        public bool Delete(Account dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.AccountDeleteByPrimaryKey)
                    .AddParameter("@AcctID", dtoObject.AcctID)

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

        public Account SelectByPrimaryKey(Guid Keys)
        {
            Account obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.AccountSelectByPrimaryKey)
                            .AddParameter("@AcctID"
,Keys)
                            .Fetch<Account>();
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
        public List<Account> SelectByField(string fieldName, object value)
        {
            List<Account> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.AccountSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Account>();

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
                obj = StoredProcedure(MasterConstant.AccountSelectByField) 
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

        public DataSet SelectRPTAccountRevenue(Guid? CompanyID, Guid? PropertyID, int? AcctGrpID, Guid? AcctID, string Frequency, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RPTAccountRevenueDetail)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@TAcctGrpID", AcctGrpID)
                                    .AddParameter("@AcctID", AcctID)
                                    .AddParameter("@Frequency", Frequency)
                                    .AddParameter("@StartDate", StartDate)
                                    .AddParameter("@EndDate", EndDate)
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
                StoredProcedure(MasterConstant.AccountDeleteByField) 
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

        public DataSet SearchAccountData(Guid? AcctID, Guid? PropertyID, Guid? CompanyID, string AcctNo, string AcctName)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.AccountSearchAccountData)
                                    .AddParameter("@AcctID", AcctID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@AcctNo", AcctNo)
                                    .AddParameter("@AcctName", AcctName)                                    
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

        public DataSet SelectAllTaxesForRateCard(Guid PropertyID, Guid CompanyID, Guid RateCardID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.AccountSelectAllTaxesForRateCard)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@RateID", RateCardID)
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

        public DataSet SelectTaxData(Guid PropertyID, Guid CompanyID, DateTime? Date)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.AccountSelectTaxData)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@Date", Date)
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

        public DataSet GetPaymentAcctsByMOPTermID(Guid MOP_ProjectTermID, Guid PropertyID, Guid CompanyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.AccountGetPaymentAcctsByMOPTermID)
                    .AddParameter("@MOP_TermID", MOP_ProjectTermID)
                    .AddParameter("@PropertyID", PropertyID)
                    .AddParameter("@CompanyID", CompanyID)
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
