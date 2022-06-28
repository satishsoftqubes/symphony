
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
                        obj = StoredProcedure(MasterDALConstant.AccountSelectAll)
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
.AddParameter("@TransactionZone_TermID", dtoObject.TransactionZone_TermID)
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
                        obj = StoredProcedure(MasterDALConstant.AccountSelectAll)
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

        public DataSet SelectAllDataSet(Guid? AcctID, Guid? PropertyID, Guid? CompanyID, Guid? AcctGroupID, string AcctNo, string AcctName)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                   
                        obj = StoredProcedure(MasterDALConstant.AccountOnlySearchData)
                                                .AddParameter("@AcctID", AcctID)
.AddParameter("@PropertyID", PropertyID)
.AddParameter("@CompanyID", CompanyID)
.AddParameter("@AcctNo", AcctNo)
.AddParameter("@AcctName", AcctName)
.AddParameter("@AcctGroupID", AcctGroupID)
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

        public DataSet SelectAllInGroup(Guid? AcctGrpID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.

                    obj = StoredProcedure(MasterDALConstant.AccountSelectInGroup)
                                            .AddParameter("@AcctGrpID", AcctGrpID)
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

        public DataSet SelectRPTLedgerStatement(Guid AcctID, Guid? PropertyID, Guid? CompanyID, Guid? UserID, Guid? CounterID, Guid? AuditID, Guid? CloseID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.

                    obj = StoredProcedure(MasterDALConstant.LedgerStatement)
                                            .AddParameter("@AcctID", AcctID)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@CompanyID", CompanyID)
                                            .AddParameter("@UserID", UserID)
                                            .AddParameter("@CounterID", CounterID)
                                            .AddParameter("@AuditID", AuditID)
                                            .AddParameter("@CloseID", CloseID)
                                            .AddParameter("@StartDate", StartDate)
                                            .AddParameter("@EndDate", EndDate)
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

                    obj = StoredProcedure(MasterDALConstant.AccountSelectAll)
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
                        obj = StoredProcedure(MasterDALConstant.AccountSelectAll)
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
.AddParameter("@TransactionZone_TermID", dtoObject.TransactionZone_TermID)
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
                        obj = StoredProcedure(MasterDALConstant.AccountSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.AccountSelectAll)
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

                    StoredProcedure(MasterDALConstant.AccountInsert)
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
.AddParameter("@TransactionZone_TermID", dtoObject.TransactionZone_TermID)
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

                    StoredProcedure(MasterDALConstant.AccountUpdate)
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
.AddParameter("@TransactionZone_TermID", dtoObject.TransactionZone_TermID)
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
                StoredProcedure(MasterDALConstant.AccountDeleteByPrimaryKey)
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
                StoredProcedure(MasterDALConstant.AccountDeleteByPrimaryKey)
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
                obj = StoredProcedure(MasterDALConstant.AccountSelectByPrimaryKey)
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
                obj = StoredProcedure(MasterDALConstant.AccountSelectByField) 
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
                obj = StoredProcedure(MasterDALConstant.AccountSelectByField) 
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
                StoredProcedure(MasterDALConstant.AccountDeleteByField) 
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
