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
    /// Data access layer class for BookKeeping
    /// </summary>
    public class BookKeepingDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public BookKeepingDAL()
            : base()
        {
            // Nothing for now.
        }
        public BookKeepingDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods 
        public List<BookKeeping> SelectAll(BookKeeping dtoObject)
        {
            List<BookKeeping> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.BookKeepingSelectAll)
                                                .AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@BookNo", dtoObject.BookNo)
.AddParameter("@RefBookID", dtoObject.RefBookID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@TransactionZone_TermID", dtoObject.TransactionZone_TermID)
.AddParameter("@AuditDate", dtoObject.AuditDate)
.AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@CloseID", dtoObject.CloseID)
.AddParameter("@IsLocked", dtoObject.IsLocked)
.AddParameter("@AuditID", dtoObject.AuditID)
.AddParameter("@Amount", dtoObject.Amount)
.AddParameter("@Narration", dtoObject.Narration)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@EntryOrigin_TermID", dtoObject.EntryOrigin_TermID)
.AddParameter("@POS_PointID", dtoObject.POS_PointID)
.AddParameter("@IsCharge", dtoObject.IsCharge)
.AddParameter("@TransactionType_TermID", dtoObject.TransactionType_TermID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@UnitID", dtoObject.UnitID)
.AddParameter("@UnitType_Term", dtoObject.UnitType_Term)
.AddParameter("@IsPosted", dtoObject.IsPosted)
.AddParameter("@GeneralBillID", dtoObject.GeneralBillID)
.AddParameter("@InvoiceID", dtoObject.InvoiceID)
.AddParameter("@IsOverride", dtoObject.IsOverride)
.AddParameter("@OverrideReason", dtoObject.OverrideReason)
.AddParameter("@OverrideBy", dtoObject.OverrideBy)
.AddParameter("@ConferenceID", dtoObject.ConferenceID)
.AddParameter("@IsVoid", dtoObject.IsVoid)
.AddParameter("@VoidReason", dtoObject.VoidReason)
.AddParameter("@VoidBy", dtoObject.VoidBy)
.AddParameter("@SourceFolioID", dtoObject.SourceFolioID)
.AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@ItemQty", dtoObject.ItemQty)
.AddParameter("@ItemRate", dtoObject.ItemRate)
.AddParameter("@IsCreditNote", dtoObject.IsCreditNote)
.AddParameter("@IsVoucher", dtoObject.IsVoucher)
.AddParameter("@VoucherNo", dtoObject.VoucherNo)
.AddParameter("@EntryByUserID", dtoObject.EntryByUserID)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@ResPayID", dtoObject.ResPayID)
.AddParameter("@AppliedTax", dtoObject.AppliedTax)
.AddParameter("@CR_Ledger", dtoObject.CR_Ledger)
.AddParameter("@DB_Ledger", dtoObject.DB_Ledger)
.AddParameter("@CR_Amt", dtoObject.CR_Amt)
.AddParameter("@DB_Amt", dtoObject.DB_Amt)
.AddParameter("@YearID", dtoObject.YearID)
.AddParameter("@OriginalBookID", dtoObject.OriginalBookID)
.AddParameter("@IsCredit", dtoObject.IsCredit)
.AddParameter("@AccountGroup_TermID", dtoObject.AccountGroup_TermID)
.AddParameter("@ReconcileID", dtoObject.ReconcileID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@TransactionZone_TermID", dtoObject.TransactionZone_TermID)
.AddParameter("@GeneralID", dtoObject.GeneralID)
.AddParameter("@GeneralIDType_Term", dtoObject.GeneralIDType_Term)

                                                .WithTransaction(dbtr)
                                                .FetchAll<BookKeeping>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.BookKeepingSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<BookKeeping>();
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

        public List<BookKeeping> SelectAll()
        {
            List<BookKeeping> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.BookKeepingSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<BookKeeping>();
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

        public List<BookKeeping> SelectDistinctGeneralType()
        {
            List<BookKeeping> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.BookKeepingDistinctGeneralType)
                                            .WithTransaction(dbtr)
                                            .FetchAll<BookKeeping>();
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

        public DataSet SelectAllWithDataSet(BookKeeping dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.BookKeepingSelectAll)
                                                .AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@BookNo", dtoObject.BookNo)
.AddParameter("@RefBookID", dtoObject.RefBookID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@TransactionZone_TermID", dtoObject.TransactionZone_TermID)
.AddParameter("@AuditDate", dtoObject.AuditDate)
.AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@CloseID", dtoObject.CloseID)
.AddParameter("@IsLocked", dtoObject.IsLocked)
.AddParameter("@AuditID", dtoObject.AuditID)
.AddParameter("@Amount", dtoObject.Amount)
.AddParameter("@Narration", dtoObject.Narration)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@EntryOrigin_TermID", dtoObject.EntryOrigin_TermID)
.AddParameter("@POS_PointID", dtoObject.POS_PointID)
.AddParameter("@IsCharge", dtoObject.IsCharge)
.AddParameter("@TransactionType_TermID", dtoObject.TransactionType_TermID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@UnitID", dtoObject.UnitID)
.AddParameter("@UnitType_Term", dtoObject.UnitType_Term)
.AddParameter("@IsPosted", dtoObject.IsPosted)
.AddParameter("@GeneralBillID", dtoObject.GeneralBillID)
.AddParameter("@InvoiceID", dtoObject.InvoiceID)
.AddParameter("@IsOverride", dtoObject.IsOverride)
.AddParameter("@OverrideReason", dtoObject.OverrideReason)
.AddParameter("@OverrideBy", dtoObject.OverrideBy)
.AddParameter("@ConferenceID", dtoObject.ConferenceID)
.AddParameter("@IsVoid", dtoObject.IsVoid)
.AddParameter("@VoidReason", dtoObject.VoidReason)
.AddParameter("@VoidBy", dtoObject.VoidBy)
.AddParameter("@SourceFolioID", dtoObject.SourceFolioID)
.AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@ItemQty", dtoObject.ItemQty)
.AddParameter("@ItemRate", dtoObject.ItemRate)
.AddParameter("@IsCreditNote", dtoObject.IsCreditNote)
.AddParameter("@IsVoucher", dtoObject.IsVoucher)
.AddParameter("@VoucherNo", dtoObject.VoucherNo)
.AddParameter("@EntryByUserID", dtoObject.EntryByUserID)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@ResPayID", dtoObject.ResPayID)
.AddParameter("@AppliedTax", dtoObject.AppliedTax)
.AddParameter("@CR_Ledger", dtoObject.CR_Ledger)
.AddParameter("@DB_Ledger", dtoObject.DB_Ledger)
.AddParameter("@CR_Amt", dtoObject.CR_Amt)
.AddParameter("@DB_Amt", dtoObject.DB_Amt)
.AddParameter("@YearID", dtoObject.YearID)
.AddParameter("@OriginalBookID", dtoObject.OriginalBookID)
.AddParameter("@IsCredit", dtoObject.IsCredit)
.AddParameter("@AccountGroup_TermID", dtoObject.AccountGroup_TermID)
.AddParameter("@ReconcileID", dtoObject.ReconcileID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@TransactionZone_TermID", dtoObject.TransactionZone_TermID)
.AddParameter("@GeneralID", dtoObject.GeneralID)
.AddParameter("@GeneralIDType_Term", dtoObject.GeneralIDType_Term)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.BookKeepingSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.BookKeepingSelectAll)
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
        public bool Insert(BookKeeping dtoObject)
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

                    StoredProcedure(MasterDALConstant.BookKeepingInsert)
                        .AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@BookNo", dtoObject.BookNo)
.AddParameter("@RefBookID", dtoObject.RefBookID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@TransactionZone_TermID", dtoObject.TransactionZone_TermID)
.AddParameter("@AuditDate", dtoObject.AuditDate)
.AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@CloseID", dtoObject.CloseID)
.AddParameter("@IsLocked", dtoObject.IsLocked)
.AddParameter("@AuditID", dtoObject.AuditID)
.AddParameter("@Amount", dtoObject.Amount)
.AddParameter("@Narration", dtoObject.Narration)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@EntryOrigin_TermID", dtoObject.EntryOrigin_TermID)
.AddParameter("@POS_PointID", dtoObject.POS_PointID)
.AddParameter("@IsCharge", dtoObject.IsCharge)
.AddParameter("@TransactionType_TermID", dtoObject.TransactionType_TermID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@UnitID", dtoObject.UnitID)
.AddParameter("@UnitType_Term", dtoObject.UnitType_Term)
.AddParameter("@IsPosted", dtoObject.IsPosted)
.AddParameter("@GeneralBillID", dtoObject.GeneralBillID)
.AddParameter("@InvoiceID", dtoObject.InvoiceID)
.AddParameter("@IsOverride", dtoObject.IsOverride)
.AddParameter("@OverrideReason", dtoObject.OverrideReason)
.AddParameter("@OverrideBy", dtoObject.OverrideBy)
.AddParameter("@ConferenceID", dtoObject.ConferenceID)
.AddParameter("@IsVoid", dtoObject.IsVoid)
.AddParameter("@VoidReason", dtoObject.VoidReason)
.AddParameter("@VoidBy", dtoObject.VoidBy)
.AddParameter("@SourceFolioID", dtoObject.SourceFolioID)
.AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@ItemQty", dtoObject.ItemQty)
.AddParameter("@ItemRate", dtoObject.ItemRate)
.AddParameter("@IsCreditNote", dtoObject.IsCreditNote)
.AddParameter("@IsVoucher", dtoObject.IsVoucher)
.AddParameter("@VoucherNo", dtoObject.VoucherNo)
.AddParameter("@EntryByUserID", dtoObject.EntryByUserID)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@ResPayID", dtoObject.ResPayID)
.AddParameter("@AppliedTax", dtoObject.AppliedTax)
.AddParameter("@CR_Ledger", dtoObject.CR_Ledger)
.AddParameter("@DB_Ledger", dtoObject.DB_Ledger)
.AddParameter("@CR_Amt", dtoObject.CR_Amt)
.AddParameter("@DB_Amt", dtoObject.DB_Amt)
.AddParameter("@YearID", dtoObject.YearID)
.AddParameter("@OriginalBookID", dtoObject.OriginalBookID)
.AddParameter("@IsCredit", dtoObject.IsCredit)
.AddParameter("@AccountGroup_TermID", dtoObject.AccountGroup_TermID)
.AddParameter("@ReconcileID", dtoObject.ReconcileID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@TransactionZone_TermID", dtoObject.TransactionZone_TermID)
.AddParameter("@GeneralID", dtoObject.GeneralID)
.AddParameter("@GeneralIDType_Term", dtoObject.GeneralIDType_Term)

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
        public bool Update(BookKeeping dtoObject)
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

                    StoredProcedure(MasterDALConstant.BookKeepingUpdate)
                        .AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@BookNo", dtoObject.BookNo)
.AddParameter("@RefBookID", dtoObject.RefBookID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@EntryDate", dtoObject.EntryDate)
.AddParameter("@TransactionZone_TermID", dtoObject.TransactionZone_TermID)
.AddParameter("@AuditDate", dtoObject.AuditDate)
.AddParameter("@CounterID", dtoObject.CounterID)
.AddParameter("@CloseID", dtoObject.CloseID)
.AddParameter("@IsLocked", dtoObject.IsLocked)
.AddParameter("@AuditID", dtoObject.AuditID)
.AddParameter("@Amount", dtoObject.Amount)
.AddParameter("@Narration", dtoObject.Narration)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@EntryOrigin_TermID", dtoObject.EntryOrigin_TermID)
.AddParameter("@POS_PointID", dtoObject.POS_PointID)
.AddParameter("@IsCharge", dtoObject.IsCharge)
.AddParameter("@TransactionType_TermID", dtoObject.TransactionType_TermID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@UnitID", dtoObject.UnitID)
.AddParameter("@UnitType_Term", dtoObject.UnitType_Term)
.AddParameter("@IsPosted", dtoObject.IsPosted)
.AddParameter("@GeneralBillID", dtoObject.GeneralBillID)
.AddParameter("@InvoiceID", dtoObject.InvoiceID)
.AddParameter("@IsOverride", dtoObject.IsOverride)
.AddParameter("@OverrideReason", dtoObject.OverrideReason)
.AddParameter("@OverrideBy", dtoObject.OverrideBy)
.AddParameter("@ConferenceID", dtoObject.ConferenceID)
.AddParameter("@IsVoid", dtoObject.IsVoid)
.AddParameter("@VoidReason", dtoObject.VoidReason)
.AddParameter("@VoidBy", dtoObject.VoidBy)
.AddParameter("@SourceFolioID", dtoObject.SourceFolioID)
.AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@ItemQty", dtoObject.ItemQty)
.AddParameter("@ItemRate", dtoObject.ItemRate)
.AddParameter("@IsCreditNote", dtoObject.IsCreditNote)
.AddParameter("@IsVoucher", dtoObject.IsVoucher)
.AddParameter("@VoucherNo", dtoObject.VoucherNo)
.AddParameter("@EntryByUserID", dtoObject.EntryByUserID)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@ResPayID", dtoObject.ResPayID)
.AddParameter("@AppliedTax", dtoObject.AppliedTax)
.AddParameter("@CR_Ledger", dtoObject.CR_Ledger)
.AddParameter("@DB_Ledger", dtoObject.DB_Ledger)
.AddParameter("@CR_Amt", dtoObject.CR_Amt)
.AddParameter("@DB_Amt", dtoObject.DB_Amt)
.AddParameter("@YearID", dtoObject.YearID)
.AddParameter("@OriginalBookID", dtoObject.OriginalBookID)
.AddParameter("@IsCredit", dtoObject.IsCredit)
.AddParameter("@AccountGroup_TermID", dtoObject.AccountGroup_TermID)
.AddParameter("@ReconcileID", dtoObject.ReconcileID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@TransactionZone_TermID", dtoObject.TransactionZone_TermID)
.AddParameter("@GeneralID", dtoObject.GeneralID)
.AddParameter("@GeneralIDType_Term", dtoObject.GeneralIDType_Term)

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
                StoredProcedure(MasterDALConstant.BookKeepingDeleteByPrimaryKey)
                    .AddParameter("@BookID"
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
        public bool Delete(BookKeeping dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.BookKeepingDeleteByPrimaryKey)
                    .AddParameter("@BookID", dtoObject.BookID)

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

        public BookKeeping SelectByPrimaryKey(Guid Keys)
        {
            BookKeeping obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.BookKeepingSelectByPrimaryKey)
                            .AddParameter("@BookID"
, Keys)
                            .Fetch<BookKeeping>();
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
        public List<BookKeeping> SelectByField(string fieldName, object value)
        {
            List<BookKeeping> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.BookKeepingSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<BookKeeping>();

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
                obj = StoredProcedure(MasterDALConstant.BookKeepingSelectByField)
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

        public DataSet SelectRPTCollectionSummary(Guid? CompanyID, Guid? PropertyID, Guid? FolioID, Guid? CounterID, Guid? PaymentMode, string GeneralIDType_Term, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTCollectionSummary)
                                    .AddParameter("@CompanyID",CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@FolioID", FolioID)
                                    .AddParameter("@CounterID", CounterID)
                                    .AddParameter("@PaymentMode", PaymentMode)
                                    .AddParameter("@GeneralIDType_Term", GeneralIDType_Term)
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

        public DataSet SelectRPTCollectionSummaryOnlySummary(Guid? CompanyID, Guid? PropertyID, Guid? FolioID, Guid? CounterID, Guid? PaymentMode, string GeneralIDType_Term, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTCollectionSummary_Summary)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@FolioID", FolioID)
                                    .AddParameter("@CounterID", CounterID)
                                    .AddParameter("@PaymentMode", PaymentMode)
                                    .AddParameter("@GeneralIDType_Term", GeneralIDType_Term)
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

        public DataSet SelectRPTRevenueDetail(Guid? ReservationID, Guid? FolioID, Guid? CounterID, string GeneralIDType_Term, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTRevenueDetail)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@FolioID", FolioID)
                                    .AddParameter("@CounterID", CounterID)
                                    .AddParameter("@GeneralIDType_Term", GeneralIDType_Term)
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

        public DataSet SelectRPTRoomDeposit(Guid? CompanyID, Guid? PropertyID, Guid? CounterID, Guid? UserID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTRoomDeposit)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CounterID", CounterID)
                                    .AddParameter("@UserID", UserID)
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

        public DataSet SelectRPTRoomRentAdvance(Guid? CompanyID, Guid? PropertyID, Guid? CounterID, Guid? UserID,Guid? AcctID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTRoomRentAdvance)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CounterID", CounterID)
                                    .AddParameter("@UserID", UserID)
                                    .AddParameter("@AcctID", AcctID)
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

        public DataSet SelectRPTRoomRentAdvance_4Summary(Guid? CompanyID, Guid? PropertyID, Guid? CounterID, Guid? UserID, Guid? AcctID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTRoomRentAdvance_Summary)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CounterID", CounterID)
                                    .AddParameter("@UserID", UserID)
                                    .AddParameter("@AcctID", AcctID)
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

        public DataSet SelectRPTRoomRentAdvance_ClosingBal(Guid? CompanyID, Guid? PropertyID, Guid? CounterID, Guid? UserID, Guid? AcctID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTRoomRentAdvance_ClosingBal)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CounterID", CounterID)
                                    .AddParameter("@UserID", UserID)
                                    .AddParameter("@AcctID", AcctID)
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

        public DataSet SelectRPTCashReport(Guid? CompanyID, Guid? PropertyID, Guid? FolioID, Guid? CounterID, Guid? UserID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTCashReport)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@FolioID", FolioID)
                                    .AddParameter("@CounterID", CounterID)
                                    .AddParameter("@UserID", UserID)
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

        public DataSet SelectRPTRetentionCharges(Guid? CompanyID, Guid? PropertyID, Guid? GuestName, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTRetentionCharges)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@GuestName", GuestName)
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

        public DataSet SelectRPTCancellationCharges(Guid? CompanyID, Guid? PropertyID, Guid? GuestName, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTCancellationCharges)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@GuestName", GuestName)
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
                StoredProcedure(MasterDALConstant.BookKeepingDeleteByField)
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

        //public Guid InsertDeposit(int Zone_TermID, decimal Amt, Guid? PaymentAcctID, Guid? DepositAcctID, Guid? ReservationID, Guid? FolioID, Guid? UserID, Guid? CounterID, Guid? PropertyID, string EntryOrigin, Guid? UnitID, string UnitType, Guid? CompanyID, Guid? ResPayID)
        public Guid ReceivePayment(Guid? MOPAcctID, decimal Amt, Guid? ReservationID, Guid? FolioID, Guid? UserID, Guid? CounterID, Guid? PropertyID, Guid? CompanyID, string EntryOrigin, Guid? ResPayID, bool IsForAgent)
        {
            Guid retBookID = Guid.Empty;
            
            OutputParameterCollection outputCal = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.BookKeepingReceivePayment)
                       .AddParameter("@MOPAcctID", MOPAcctID)
                       .AddParameter("@Amt", Amt)
                       .AddParameter("@ResID", ReservationID)
                       .AddParameter("@SelFolioID", FolioID)
                       .AddParameter("@UserID", UserID)
                       .AddParameter("@CounterID", CounterID)
                       .AddParameter("@PropertyID", PropertyID)
                       .AddParameter("@CompanyID", CompanyID)
                       .AddParameter("@Transaction_Origin", EntryOrigin)
                       .AddParameter("@ResPayID", ResPayID)
                       .AddParameter("@IsForAgent", IsForAgent)
                       .AddOutParameter("@Ret_BookID", retBookID)
                        //.AddParameter("@Zone_TermID", Zone_TermID)
                        //.AddParameter("@DepositAcctID", DepositAcctID)
                        //.AddParameter("@UnitID", UnitID)
                        //.AddParameter("@UnitType", UnitType)

                       .WithTransaction(dbtr)
                       .Execute(out outputCal);

                    retBookID = outputCal.GetValue("@Ret_BookID").Fetch<Guid>();

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
            return retBookID;
        }

        public DataSet SelectPaymentForCheckInVoucher(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID, string strBookKeepingID)
        {
            DataSet ds = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    ds = StoredProcedure(MasterDALConstant.BookKeepingSelectPaymentForCheckInVoucher)
                           .AddParameter("@ReservationID", ReservationID)
                           .AddParameter("@PropertyID", PropertyID)
                           .AddParameter("@CompanyID", CompanyID)
                           .AddParameter("@BookKeepingID", strBookKeepingID)
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

            return ds;
        }

        public DataSet SelectPaymentForCheckInVoucherForReprint(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID, string strBookKeepingID)
        {
            DataSet ds = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    ds = StoredProcedure(MasterDALConstant.BookKeepingSelectPaymentForCheckInVoucherForReprint)
                           .AddParameter("@ReservationID", ReservationID)
                           .AddParameter("@PropertyID", PropertyID)
                           .AddParameter("@CompanyID", CompanyID)
                           .AddParameter("@BookKeepingID", strBookKeepingID)
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

            return ds;
        }

        public bool VoidTransaction(Guid? BkpID, string VoidReas, Guid? VoidByUserID)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.BookKeepingTransactionVoid)
                        .AddParameter("@BkpID", BkpID)
                        .AddParameter("@VoidReas", VoidReas)
                        .AddParameter("@VoidByUserID", VoidByUserID)                        

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

        public bool TransactionDiscount(Guid? BkpID, decimal? DiscountPercentage, Guid? DiscountByUserID, Guid? DiscountCounterID, string DiscountNarration)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.BookKeepingTransactionDiscount_GiveDiscount)
                        .AddParameter("@BkpID", BkpID)
                        .AddParameter("@DiscountPercentage", DiscountPercentage)
                        .AddParameter("@DiscountByUserID", DiscountByUserID)
                        .AddParameter("@DiscountCounterID", DiscountCounterID)
                        .AddParameter("@DiscountNarration", DiscountNarration)
                        
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


        public DataSet SelectAllFolioDiscount(Guid? ReservationID, Guid? FolioID)
        {
            DataSet ds = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    ds = StoredProcedure(MasterDALConstant.BookKeepingTransactionDiscount_GetAllDicounts)
                           .AddParameter("@ReservationID", ReservationID)
                           .AddParameter("@FolioID", FolioID)                           
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

            return ds;
        }


        public bool TransactionOverride(Guid? BkpID, decimal? Amount, Guid? OverridCounterID, string OverrideReason, Guid? OverrideByUserID)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.BookKeepingTransaction_TransactionOverride)
                        .AddParameter("@BkID", BkpID)
                        .AddParameter("@Amount", Amount)
                        .AddParameter("@OverridCounterID", OverridCounterID)
                        .AddParameter("@OverrideReason", OverrideReason)
                        .AddParameter("@OverrideByUserID", OverrideByUserID)

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

        public DataSet SelectAllFolioAllOverridesTransaction(Guid? ReservationID, Guid? FolioID)
        {
            DataSet ds = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    ds = StoredProcedure(MasterDALConstant.Folio_GetAllOverridesTransaction)
                           .AddParameter("@ReservationID", ReservationID)
                           .AddParameter("@FolioID", FolioID)
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

            return ds;
        }

        public DataSet SelectRPTCompanyPosting(Guid? CompanyID, Guid? PropertyID, Guid? AgentID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTCompanyPosting)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@AgentID", AgentID)
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

        public bool UpdateByInvoiceID(Guid ReservationID, Guid FolioID, DateTime FromDate, DateTime ToDate, Guid InvoiceID)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    StoredProcedure(MasterDALConstant.BookKeepingUpdateInvoiceID)
                        .AddParameter("@ReservationID", ReservationID)
                        .AddParameter("@FolioID", FolioID)
                        .AddParameter("@FromDate", FromDate)
                        .AddParameter("@ToDate", ToDate)
                        .AddParameter("@InvoiceID", InvoiceID)

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

        public DataSet SelectVoidReport(Guid? CompanyID, Guid? PropertyID, DateTime? StartDate, DateTime? EndDate, string GuestName)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.rpt_VoidReport)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@StartDate", StartDate)
                                    .AddParameter("@EndDate", EndDate)
                                    .AddParameter("@GuestName", GuestName)
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
