using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SQT.FRAMEWORK.DAL.Linq;
using SQT.FRAMEWORK.DAL.Linq.DAL;
using SQT.FRAMEWORK.EXCEPTION;
using SQT.FRAMEWORK.LOGGER;
using SQT.Symphony.BusinessLogic.Configuration.COMMON;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SQT.Symphony.BusinessLogic.Configuration.DAL
{
    public class ExpenseDAL : LinqDAL
    {
        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public ExpenseDAL() : base()
        {
            // Nothing for now.
        }
        public ExpenseDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        
        #endregion
        public List<Expense> SelectAll(Expense objExpense)
        {
            List<Expense> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                  obj = StoredProcedure(MasterConstant.ProjectTermSelectAll)
                  .AddParameter("Category",objExpense.Category)
                  .WithTransaction(dbtr)
                  .FetchAll<Expense>();
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
        public List<Expense> SelectAllPropertyName(Expense objExpense)
        {
            List<Expense> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    obj = StoredProcedure(MasterConstant.GetPropertyName)
                    .WithTransaction(dbtr)
                    .FetchAll<Expense>();
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

        public bool Insert(Expense objExpense)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    if (objExpense == null)
                        throw (new ParameterNullException("Object can not be null"));

                    
                    StoredProcedure(MasterConstant.ExpenseInsert)
                        .AddParameter("@ExpenseID", objExpense.ExpenseID)
                        .AddParameter("@PropertyID",objExpense.PropertyID)
                        .AddParameter("@DateOfExpense",objExpense.DateOfExpense)
                        .AddParameter("@AssociationTypeTerm",objExpense.AssociationTypeTerm)
                        .AddParameter("@ExpenseTypeTerm",objExpense.ExpenseTypeTerm)
                        .AddParameter("@ExpenseAmount",objExpense.ExpenseAmount)
                        .AddParameter("@ModeOfPaymentTerm",objExpense.ModeOfPaymentTerm)
                        .AddParameter("@ExpenseDetail",objExpense.ExpenseDetail)
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

        public bool MultiPleExpense_Insert(Expense exDetail)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    if (exDetail == null)
                        throw (new ParameterNullException("Object can not be null"));

                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    parameterList.Add(exDetail);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterConstant.Multiple_ExpenseInsert)
                         .AddParameter("@PropertyExpenseDetailID", exDetail.PropertyExpenseDetailID)
                        .AddParameter("@PropertyID", exDetail.PropertyID)
                        .AddParameter("@VendorID", exDetail.VendorID)
                        .AddParameter("@PurchaseNote",exDetail.PurchaseNote)
                        .AddParameter("@TotalAmount",exDetail.TotalAmount)
                        .AddParameter("@PurchaseTypeTerm",exDetail.PurchaseTypeTerm)
                        .AddParameter("@ItemTypeTerm",exDetail.ItemTypeTerm)
                        .AddParameter("@ExpenseID",exDetail.ExpenseID)
                        
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

        public DataSet IdWiseExpenseData(Guid ExpenseID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.GetByIdWise_ExpenseData)
                                            .AddParameter("@ExpenseID", ExpenseID)
                                            .WithTransaction(dbtr)
                                            .FetchDataSet();

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

        public bool Update(Expense objExpense)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    if (objExpense == null)
                        throw (new ParameterNullException("Object can not be null"));


                    StoredProcedure(MasterConstant.ExpenseUpdate)
                        .AddParameter("@ExpenseID", objExpense.ExpenseID)
                        .AddParameter("@PropertyID", objExpense.PropertyID)
                        .AddParameter("@DateOfExpense", objExpense.DateOfExpense)
                        .AddParameter("@AssociationTypeTerm", objExpense.AssociationTypeTerm)
                        .AddParameter("@ExpenseTypeTerm", objExpense.ExpenseTypeTerm)
                        .AddParameter("@ExpenseAmount", objExpense.ExpenseAmount)
                        .AddParameter("@ModeOfPaymentTerm", objExpense.ModeOfPaymentTerm)
                        .AddParameter("@ExpenseDetail", objExpense.ExpenseDetail)
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

        public bool MultiPleExpense_Update(Expense exDetail)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    if (exDetail == null)
                        throw (new ParameterNullException("Object can not be null"));

                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    parameterList.Add(exDetail);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterConstant.Multiple_ExpenseUpdate)
                        .AddParameter("@PropertyExpenseDetailID", exDetail.PropertyExpenseDetailID)
                        .AddParameter("@PropertyID", exDetail.PropertyID)
                        .AddParameter("@VendorID", exDetail.VendorID)
                        .AddParameter("@PurchaseNote", exDetail.PurchaseNote)
                        .AddParameter("@TotalAmount", exDetail.TotalAmount)
                        .AddParameter("@PurchaseTypeTerm", exDetail.PurchaseTypeTerm)
                        .AddParameter("@ItemTypeTerm", exDetail.ItemTypeTerm)
                        .AddParameter("@ExpenseID", exDetail.ExpenseID)

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
                StoredProcedure(MasterConstant.ExpenseDelete_IdWise)
                    .AddParameter("@ExpenseID", Keys)
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

        public DataSet GetExpenseData(string PropertyName)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    obj = StoredProcedure(MasterConstant.ExpenseGetAll)
                        .AddParameter("@PropertyName", PropertyName)
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

        public List<Expense> SelectAllVendorName(Expense objExpense)
        {
            List<Expense> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    obj = StoredProcedure(MasterConstant.GetVendorName)
                    .WithTransaction(dbtr)
                    .FetchAll<Expense>();
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
