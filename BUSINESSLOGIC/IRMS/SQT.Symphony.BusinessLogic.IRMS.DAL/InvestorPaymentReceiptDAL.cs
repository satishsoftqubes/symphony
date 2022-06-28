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
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using SQT.Symphony.BusinessLogic.IRMS.COMMON;

namespace SQT.Symphony.BusinessLogic.IRMS.DAL
{
    /// <summary>
    /// Data access layer class for InvestorPaymentReceipt
    /// </summary>
    public class InvestorPaymentReceiptDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public InvestorPaymentReceiptDAL()
            : base()
        {
            // Nothing for now.
        }
        public InvestorPaymentReceiptDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<InvestorPaymentReceipt> SelectAll(InvestorPaymentReceipt dtoObject)
        {
            List<InvestorPaymentReceipt> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.InvestorPaymentReceiptSelectAll)
                                                .AddParameter("@InvestorPaymentReceiptID", dtoObject.InvestorPaymentReceiptID)
.AddParameter("@PaymentScheduleID", dtoObject.PaymentScheduleID)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@PaidAmount", dtoObject.PaidAmount)
.AddParameter("@DateToPay", dtoObject.DateToPay)
.AddParameter("@PayRefNo", dtoObject.PayRefNo)
.AddParameter("@Note", dtoObject.Note)
.AddParameter("@ModeOfPaymentTermID", dtoObject.ModeOfPaymentTermID)
.AddParameter("@BankName", dtoObject.BankName)
.AddParameter("@ReceiptNo", dtoObject.ReceiptNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@IsReconciled", dtoObject.IsReconciled)
.AddParameter("@ReconciledOn", dtoObject.ReconciledOn)
.AddParameter("@ReconcileBy", dtoObject.ReconcileBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@DepositToBank", dtoObject.DepositToBank)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@ReconcileID", dtoObject.ReconcileID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@ReceiptType_TermID", dtoObject.ReceiptType_TermID)
.AddParameter("@YearToPay", dtoObject.YearToPay)
.AddParameter("@RefPayReceiptNo", dtoObject.RefPayReceiptNo)
.AddParameter("@UnitID", dtoObject.UnitID)
.AddParameter("@InsuranceVendor", dtoObject.InsuranceVendor)
.AddParameter("@FromDate", dtoObject.FromDate)
.AddParameter("@ToDate", dtoObject.ToDate)
.AddParameter("@PropertyID", dtoObject.PropertyID)

                                                .WithTransaction(dbtr)
                                                .FetchAll<InvestorPaymentReceipt>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.InvestorPaymentReceiptSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<InvestorPaymentReceipt>();
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

        public List<InvestorPaymentReceipt> SelectAll()
        {
            List<InvestorPaymentReceipt> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.InvestorPaymentReceiptSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<InvestorPaymentReceipt>();
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
        public DataSet SelectAllWithDataSet(InvestorPaymentReceipt dtoObject)
        {
            DataSet obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.InvestorPaymentReceiptSelectAll)
                                                .AddParameter("@InvestorPaymentReceiptID", dtoObject.InvestorPaymentReceiptID)
.AddParameter("@PaymentScheduleID", dtoObject.PaymentScheduleID)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@PaidAmount", dtoObject.PaidAmount)
.AddParameter("@DateToPay", dtoObject.DateToPay)
.AddParameter("@PayRefNo", dtoObject.PayRefNo)
.AddParameter("@Note", dtoObject.Note)
.AddParameter("@ModeOfPaymentTermID", dtoObject.ModeOfPaymentTermID)
.AddParameter("@BankName", dtoObject.BankName)
.AddParameter("@ReceiptNo", dtoObject.ReceiptNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@IsReconciled", dtoObject.IsReconciled)
.AddParameter("@ReconciledOn", dtoObject.ReconciledOn)
.AddParameter("@ReconcileBy", dtoObject.ReconcileBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@DepositToBank", dtoObject.DepositToBank)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@ReconcileID", dtoObject.ReconcileID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@ReceiptType_TermID", dtoObject.ReceiptType_TermID)
.AddParameter("@YearToPay", dtoObject.YearToPay)
.AddParameter("@RefPayReceiptNo", dtoObject.RefPayReceiptNo)
.AddParameter("@UnitID", dtoObject.UnitID)
.AddParameter("@InsuranceVendor", dtoObject.InsuranceVendor)
.AddParameter("@FromDate", dtoObject.FromDate)
.AddParameter("@ToDate", dtoObject.ToDate)
.AddParameter("@PropertyID", dtoObject.PropertyID)
                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.InvestorPaymentReceiptSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.InvestorPaymentReceiptSelectAll)
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
        public bool Insert(InvestorPaymentReceipt dtoObject)
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

                    StoredProcedure(MasterDALConstant.InvestorPaymentReceiptInsert)
                        .AddParameter("@InvestorPaymentReceiptID", dtoObject.InvestorPaymentReceiptID)
.AddParameter("@PaymentScheduleID", dtoObject.PaymentScheduleID)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@PaidAmount", dtoObject.PaidAmount)
.AddParameter("@DateToPay", dtoObject.DateToPay)
.AddParameter("@PayRefNo", dtoObject.PayRefNo)
.AddParameter("@Note", dtoObject.Note)
.AddParameter("@ModeOfPaymentTermID", dtoObject.ModeOfPaymentTermID)
.AddParameter("@BankName", dtoObject.BankName)
.AddParameter("@ReceiptNo", dtoObject.ReceiptNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@IsReconciled", dtoObject.IsReconciled)
.AddParameter("@ReconciledOn", dtoObject.ReconciledOn)
.AddParameter("@ReconcileBy", dtoObject.ReconcileBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@DepositToBank", dtoObject.DepositToBank)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@ReconcileID", dtoObject.ReconcileID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@ReceiptType_TermID", dtoObject.ReceiptType_TermID)
.AddParameter("@YearToPay", dtoObject.YearToPay)
.AddParameter("@RefPayReceiptNo", dtoObject.RefPayReceiptNo)
.AddParameter("@UnitID", dtoObject.UnitID)
.AddParameter("@InsuranceVendor", dtoObject.InsuranceVendor)
.AddParameter("@FromDate", dtoObject.FromDate)
.AddParameter("@ToDate", dtoObject.ToDate)
.AddParameter("@PropertyID", dtoObject.PropertyID)

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
        public bool Update(InvestorPaymentReceipt dtoObject)
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

                    StoredProcedure(MasterDALConstant.InvestorPaymentReceiptUpdate)
                        .AddParameter("@InvestorPaymentReceiptID", dtoObject.InvestorPaymentReceiptID)
.AddParameter("@PaymentScheduleID", dtoObject.PaymentScheduleID)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@PaidAmount", dtoObject.PaidAmount)
.AddParameter("@DateToPay", dtoObject.DateToPay)
.AddParameter("@PayRefNo", dtoObject.PayRefNo)
.AddParameter("@Note", dtoObject.Note)
.AddParameter("@ModeOfPaymentTermID", dtoObject.ModeOfPaymentTermID)
.AddParameter("@BankName", dtoObject.BankName)
.AddParameter("@ReceiptNo", dtoObject.ReceiptNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@IsReconciled", dtoObject.IsReconciled)
.AddParameter("@ReconciledOn", dtoObject.ReconciledOn)
.AddParameter("@ReconcileBy", dtoObject.ReconcileBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@DepositToBank", dtoObject.DepositToBank)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@ReconcileID", dtoObject.ReconcileID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@ReceiptType_TermID", dtoObject.ReceiptType_TermID)
.AddParameter("@YearToPay", dtoObject.YearToPay)
.AddParameter("@RefPayReceiptNo", dtoObject.RefPayReceiptNo)
.AddParameter("@UnitID", dtoObject.UnitID)
.AddParameter("@InsuranceVendor", dtoObject.InsuranceVendor)
.AddParameter("@FromDate", dtoObject.FromDate)
.AddParameter("@ToDate", dtoObject.ToDate)
.AddParameter("@PropertyID", dtoObject.PropertyID)

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
                StoredProcedure(MasterDALConstant.InvestorPaymentReceiptDeleteByPrimaryKey)
                    .AddParameter("@InvestorPaymentReceiptID"
, Keys)
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
        public bool Delete(InvestorPaymentReceipt dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.InvestorPaymentReceiptDeleteByPrimaryKey)
                    .AddParameter("@InvestorPaymentReceiptID", dtoObject.InvestorPaymentReceiptID)

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

        public InvestorPaymentReceipt SelectByPrimaryKey(Guid Keys)
        {
            InvestorPaymentReceipt obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.InvestorPaymentReceiptSelectByPrimaryKey)
                            .AddParameter("@InvestorPaymentReceiptID"
, Keys)
                            .Fetch<InvestorPaymentReceipt>();
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
        public List<InvestorPaymentReceipt> SelectByField(string fieldName, object value)
        {
            List<InvestorPaymentReceipt> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.InvestorPaymentReceiptSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<InvestorPaymentReceipt>();

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
                obj = StoredProcedure(MasterDALConstant.InvestorPaymentReceiptSelectByField)
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
                StoredProcedure(MasterDALConstant.InvestorPaymentReceiptDeleteByField)
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
        public DataSet SelectAllWithSearchDataSet(Guid? InvestorPaymentReceiptID, Guid? InvestorID, string InvestorName, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.InvestorPaymentReceiptSearchDataSet)
                                            .AddParameter("@InvestorPaymentReceiptID", InvestorPaymentReceiptID)
                                            .AddParameter("@InvestorID", InvestorID)
                                            .AddParameter("@InvestorName", InvestorName)
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
        public DataSet SelectAllWithSearchDataSetForTax(Guid? InvestorPaymentReceiptID, Guid? InvestorID, string InvestorName, Guid? CompanyID, Guid? ReceiptTypeTermID, Guid? CreatedBy, string PayYear, string UnitNo, DateTime? dateFrom, DateTime? dateTo)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.InvestorPaymentReceiptSearchDataSetForTax)
                                            .AddParameter("@InvestorID", InvestorID)
                                            .AddParameter("@InvestorName", InvestorName)
                                            .AddParameter("@CompanyID", CompanyID)
                                            .AddParameter("@ReceiptType_TermID", ReceiptTypeTermID)
                                            .AddParameter("@CreatedBy", CreatedBy)
                                            .AddParameter("@YearToPay", PayYear)
                                            .AddParameter("@UnitNo", UnitNo)
                                            .AddParameter("@DateFrom", dateFrom)
                                            .AddParameter("@DateTo", dateTo)
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
        public DataSet rptPaymentReceipt(Guid? InvestorID, DateTime? StartDate, DateTime? EndDate, Guid? RoomID, Guid? PropertyID, Guid? RelationShipManagerID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.ReportPaymentReceipt)
                    .AddParameter("@InvestorID", InvestorID)
                    .AddParameter("@StartDate", StartDate)
                    .AddParameter("@EndDate", EndDate)
                    .AddParameter("@RoomID", RoomID)
                    .AddParameter("@PropertyID", PropertyID)
                    .AddParameter("@RelationShipManagerID", RelationShipManagerID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet rptPaymentAlerts(Guid? InvestorID, DateTime? StartDate, DateTime? EndDate, Guid? RoomID, Guid? PropertyID, Guid? RelationShipManagerID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.ReportPaymentAlerts)
                    .AddParameter("@InvestorID", InvestorID)
                    .AddParameter("@StartDate", StartDate)
                    .AddParameter("@EndDate", EndDate)
                    .AddParameter("@RoomID", RoomID)
                    .AddParameter("@PropertyID", PropertyID)
                    .AddParameter("@RelationShipManagerID", RelationShipManagerID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }
        public DataSet SelectTotalAmount(string AmountQuery)
        {
            DataSet dst = new DataSet();
            try
            {
                dst = Query(AmountQuery)
                            .WithTransaction(dbtr)
                            .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return dst;
        }
        /// <summary>
        /// Get Tax And Insurance Receipt Information
        /// </summary>
        /// <param name="InvestorID"></param>
        /// <returns></returns>
        public DataSet GetReceiptForTaxAndInsurance(Guid? InvestorID, string PropertyName, string UnitNo)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.InvestorTaxAndInsuranceReceiptList)
                    .AddParameter("@InvestorID", InvestorID)
                    .AddParameter("@PropertyName", PropertyName)
                    .AddParameter("@UnitNo", UnitNo)
                            .WithTransaction(dbtr)
                            .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet SelectInvestorPropertyName(Guid? InvestorRoomID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.InvestorTaxGetPropertyName)
                                    .AddParameter("@InvestorRoomID", InvestorRoomID)
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

        public DataSet SelectTaxAndInsuranceData(Guid? InvestorID, string PropertyName, string UnitNo, DateTime? FromDate, DateTime? ToDate)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.InvestorPaymentReceiptSelectTaxAndInsuranceData)
                    .AddParameter("@InvestorID", InvestorID)
                    .AddParameter("@PropertyName", PropertyName)
                    .AddParameter("@UnitNo", UnitNo)
                    .AddParameter("@FromDate", FromDate)
                    .AddParameter("@ToDate", ToDate)
                            .WithTransaction(dbtr)
                            .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet SelectPaymentReceiptData(Guid? InvestorRoomID, Guid? InvestorID, Guid? CompanyID, Guid? PaymentScheduleID)
        {
            DataSet dsData = new DataSet();

            try
            {
                dsData = StoredProcedure(MasterDALConstant.InvestorPaymentReceiptSelectReceiptDetails)
                 .AddParameter("@InvestorRoomID", InvestorRoomID)
                 .AddParameter("@InvestorID", InvestorID)
                 .AddParameter("@CompanyID", CompanyID)
                 .AddParameter("@PaymentScheduleID", PaymentScheduleID)

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
            return dsData;
        }

        public DataSet SearchPaymentReceiptData(Guid? InvestorID, string InvestorName, Guid? CompanyID, Guid? ReceiptType_TermID, Guid? CreatedBy, Guid? PropertyID)
        {
            DataSet dsData = new DataSet();

            try
            {
                dsData = StoredProcedure(MasterDALConstant.InvestorPaymentReceiptSearchPaymentReceiptData)
                 .AddParameter("@InvestorID", InvestorID)
                 .AddParameter("@InvestorName", InvestorName)
                 .AddParameter("@CompanyID", CompanyID)
                 .AddParameter("@ReceiptType_TermID", ReceiptType_TermID)
                 .AddParameter("@CreatedBy", CreatedBy)
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
            return dsData;
        }



        public DataSet SelectPaymentReceipt(Guid? InvestorID,Guid? PropertyID)
        {
            DataSet dsData = new DataSet();

            try
            {
                dsData = StoredProcedure(MasterDALConstant.InvestorPaymentReceiptSelectPaymentReceipt)
                 .AddParameter("@investorID", InvestorID)
                 .AddParameter("@propertyID", PropertyID)

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
            return dsData;
        }
        #endregion
    }
}
