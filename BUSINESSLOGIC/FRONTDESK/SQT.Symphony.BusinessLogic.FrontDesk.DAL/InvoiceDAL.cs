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
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.COMMON;

namespace SQT.Symphony.BusinessLogic.FrontDesk.DAL
{
	/// <summary>
	/// Data access layer class for Invoice
	/// </summary>
	public class InvoiceDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public InvoiceDAL() :  base()
		{
			// Nothing for now.
		}
        public InvoiceDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Invoice> SelectAll(Invoice dtoObject)
        {
            List<Invoice> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.InvoiceSelectAll)
                                                .AddParameter("@InvoiceID", dtoObject.InvoiceID)
.AddParameter("@InvoiceNo", dtoObject.InvoiceNo)
.AddParameter("@YearID", dtoObject.YearID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@AgentID", dtoObject.AgentID)
.AddParameter("@InvoiceDate", dtoObject.InvoiceDate)
.AddParameter("@Amt", dtoObject.Amt)
.AddParameter("@IsPaid", dtoObject.IsPaid)
.AddParameter("@PendingAmount", dtoObject.PendingAmount)
.AddParameter("@CustomerID", dtoObject.CustomerID)
.AddParameter("@TransactionOrigin_TermID", dtoObject.TransactionOrigin_TermID)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@IsPrinted", dtoObject.IsPrinted)
.AddParameter("@PrintedOn", dtoObject.PrintedOn)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@AuditID", dtoObject.AuditID)
.AddParameter("@IsLocked", dtoObject.IsLocked)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsVoid", dtoObject.IsVoid)
.AddParameter("@VoidBy", dtoObject.VoidBy)
.AddParameter("@VoidOn", dtoObject.VoidOn)
.AddParameter("@VoidReason", dtoObject.VoidReason)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@IsDiscount", dtoObject.IsDiscount)
.AddParameter("@DiscAmount", dtoObject.DiscAmount)
.AddParameter("@IsDiscInPercentage", dtoObject.IsDiscInPercentage)
.AddParameter("@InvoiceDetail", dtoObject.InvoiceDetail)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Invoice>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.InvoiceSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Invoice>();
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

        public List<Invoice> SelectAll()
        {
            List<Invoice> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.InvoiceSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Invoice>();
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
        public DataSet SelectAllWithDataSet(Invoice dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.InvoiceSelectAll)
                                                .AddParameter("@InvoiceID", dtoObject.InvoiceID)
.AddParameter("@InvoiceNo", dtoObject.InvoiceNo)
.AddParameter("@YearID", dtoObject.YearID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@AgentID", dtoObject.AgentID)
.AddParameter("@InvoiceDate", dtoObject.InvoiceDate)
.AddParameter("@Amt", dtoObject.Amt)
.AddParameter("@IsPaid", dtoObject.IsPaid)
.AddParameter("@PendingAmount", dtoObject.PendingAmount)
.AddParameter("@CustomerID", dtoObject.CustomerID)
.AddParameter("@TransactionOrigin_TermID", dtoObject.TransactionOrigin_TermID)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@IsPrinted", dtoObject.IsPrinted)
.AddParameter("@PrintedOn", dtoObject.PrintedOn)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@AuditID", dtoObject.AuditID)
.AddParameter("@IsLocked", dtoObject.IsLocked)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsVoid", dtoObject.IsVoid)
.AddParameter("@VoidBy", dtoObject.VoidBy)
.AddParameter("@VoidOn", dtoObject.VoidOn)
.AddParameter("@VoidReason", dtoObject.VoidReason)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@IsDiscount", dtoObject.IsDiscount)
.AddParameter("@DiscAmount", dtoObject.DiscAmount)
.AddParameter("@IsDiscInPercentage", dtoObject.IsDiscInPercentage)
.AddParameter("@InvoiceDetail", dtoObject.InvoiceDetail)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.InvoiceSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.InvoiceSelectAll)
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
		public bool Insert(Invoice dtoObject)
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

                    StoredProcedure(MasterDALConstant.InvoiceInsert)
                        .AddParameter("@InvoiceID", dtoObject.InvoiceID)
.AddParameter("@InvoiceNo", dtoObject.InvoiceNo)
.AddParameter("@YearID", dtoObject.YearID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@AgentID", dtoObject.AgentID)
.AddParameter("@InvoiceDate", dtoObject.InvoiceDate)
.AddParameter("@Amt", dtoObject.Amt)
.AddParameter("@IsPaid", dtoObject.IsPaid)
.AddParameter("@PendingAmount", dtoObject.PendingAmount)
.AddParameter("@CustomerID", dtoObject.CustomerID)
.AddParameter("@TransactionOrigin_TermID", dtoObject.TransactionOrigin_TermID)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@IsPrinted", dtoObject.IsPrinted)
.AddParameter("@PrintedOn", dtoObject.PrintedOn)
.AddParameter("@AuditID", dtoObject.AuditID)
.AddParameter("@IsLocked", dtoObject.IsLocked)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsVoid", dtoObject.IsVoid)
.AddParameter("@VoidBy", dtoObject.VoidBy)
.AddParameter("@VoidOn", dtoObject.VoidOn)
.AddParameter("@VoidReason", dtoObject.VoidReason)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@IsDiscount", dtoObject.IsDiscount)
.AddParameter("@DiscAmount", dtoObject.DiscAmount)
.AddParameter("@IsDiscInPercentage", dtoObject.IsDiscInPercentage)
.AddParameter("@InvoiceDetail", dtoObject.InvoiceDetail)

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
        public bool Update(Invoice dtoObject)
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

                    StoredProcedure(MasterDALConstant.InvoiceUpdate)
                        .AddParameter("@InvoiceID", dtoObject.InvoiceID)
.AddParameter("@InvoiceNo", dtoObject.InvoiceNo)
.AddParameter("@YearID", dtoObject.YearID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@AgentID", dtoObject.AgentID)
.AddParameter("@InvoiceDate", dtoObject.InvoiceDate)
.AddParameter("@Amt", dtoObject.Amt)
.AddParameter("@IsPaid", dtoObject.IsPaid)
.AddParameter("@PendingAmount", dtoObject.PendingAmount)
.AddParameter("@CustomerID", dtoObject.CustomerID)
.AddParameter("@TransactionOrigin_TermID", dtoObject.TransactionOrigin_TermID)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@IsPrinted", dtoObject.IsPrinted)
.AddParameter("@PrintedOn", dtoObject.PrintedOn)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@AuditID", dtoObject.AuditID)
.AddParameter("@IsLocked", dtoObject.IsLocked)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsVoid", dtoObject.IsVoid)
.AddParameter("@VoidBy", dtoObject.VoidBy)
.AddParameter("@VoidOn", dtoObject.VoidOn)
.AddParameter("@VoidReason", dtoObject.VoidReason)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@IsDiscount", dtoObject.IsDiscount)
.AddParameter("@DiscAmount", dtoObject.DiscAmount)
.AddParameter("@IsDiscInPercentage", dtoObject.IsDiscInPercentage)
.AddParameter("@InvoiceDetail", dtoObject.InvoiceDetail)

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
                StoredProcedure(MasterDALConstant.InvoiceDeleteByPrimaryKey)
                    .AddParameter("@InvoiceID"
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
        public bool Delete(Invoice dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.InvoiceDeleteByPrimaryKey)
                    .AddParameter("@InvoiceID", dtoObject.InvoiceID)

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

        public Invoice SelectByPrimaryKey(Guid Keys)
        {
            Invoice obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.InvoiceSelectByPrimaryKey)
                            .AddParameter("@InvoiceID"
,Keys)
                            .Fetch<Invoice>();
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
        public List<Invoice> SelectByField(string fieldName, object value)
        {
            List<Invoice> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.InvoiceSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Invoice>();

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
                obj = StoredProcedure(MasterDALConstant.InvoiceSelectByField) 
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

        public DataSet SelectRPTInvoiceReservationDetail(Guid? InvoiceID, Guid? ReservationID, Guid? FolioID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTInvoiceReservationDetail)
                                    .AddParameter("@InvoiceID", InvoiceID)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@FolioID", FolioID)
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

        public DataSet SelectRPTBillFormatSummary(Guid? ReservationID, Guid? FolioID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTBillFormat_Summary)                                    
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@FolioID", FolioID)
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

        public DataSet SelectRPTBillFormatSummary4CompanyInvoice(Guid? ReservationID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTBillFormat_Summary4CompanyInvoice)                                    
                                    .AddParameter("@ReservationID", ReservationID)
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
        
        public DataSet SelectRPTInvoiceBillDetail(Guid? ReservationID, Guid? FolioID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTBillFormat)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@FolioID", FolioID)
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
                StoredProcedure(MasterDALConstant.InvoiceDeleteByField) 
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
        public DataSet SelectAll4RePrintCompanyInvoice(DateTime startDate, DateTime endDate, Guid? AgentID, Guid? PropertyID, Guid? CompanyID, Guid? BillingInstructionID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.SelectAll4RePrint )
                                    .AddParameter("@StartDate", startDate)
                                    .AddParameter("@EndDate", endDate)
                                    .AddParameter("@AgentID", AgentID)
                                    .AddParameter("@BillingInstructionID", BillingInstructionID)
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

        public DataSet SelectInvoicesOfCompany(Guid? InvoiceID, string InvoiceNo, Guid? GuestID, Guid? AgentID, bool IsPaid, Guid? PropertyID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.Invoice_SelectInvoicesOfCompany)
                                    .AddParameter("@InvoiceID", InvoiceID)
                                    .AddParameter("@InvoiceNo", InvoiceNo)
                                    .AddParameter("@GuestID", GuestID)
                                    .AddParameter("@AgentID", AgentID)
                                    .AddParameter("@IsPaid", IsPaid)
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

        public bool AgentReceivePayment(Guid? MOPAcctID, decimal Amt, Guid? AgentID, DateTime ReceiptDate, string Description, Guid? UserID, Guid? CounterID, Guid? PropertyID, string Transaction_Origin, Guid? ResPayID, decimal SettledAmt, Guid? CompanyID, ref Guid Ret_BookID, ref Guid ReceiptID)
        {
            OutputParameterCollection outputCal = null;
            try
            {
                StoredProcedure(MasterDALConstant.Invoice_AgentReceivePayment)
                                    .AddParameter("@MOPAcctID", MOPAcctID)
                                    .AddParameter("@Amt", Amt)
                                    .AddParameter("@AgentID", AgentID)
                                    .AddParameter("@ReceiptDate", ReceiptDate)
                                    .AddParameter("@Description", Description)
                                    .AddParameter("@UserID", UserID)
                                    .AddParameter("@CounterID", CounterID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@Transaction_Origin", Transaction_Origin)
                                    .AddParameter("@ResPayID", ResPayID)
                                    .AddParameter("@SettledAmt", SettledAmt)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddOutParameter("@Ret_BookID", Ret_BookID)
                                    .AddOutParameter("@ReceiptID", ReceiptID)
                                    .WithTransaction(dbtr)
                        //.Execute();

                                    .Execute(out outputCal);

                Ret_BookID = outputCal.GetValue("@Ret_BookID").Fetch<Guid>();
                ReceiptID = outputCal.GetValue("@ReceiptID").Fetch<Guid>();

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
