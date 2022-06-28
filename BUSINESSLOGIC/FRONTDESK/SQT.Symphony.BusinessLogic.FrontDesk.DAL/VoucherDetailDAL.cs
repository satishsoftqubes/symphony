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
	/// Data access layer class for VoucherDetail
	/// </summary>
	public class VoucherDetailDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public VoucherDetailDAL() :  base()
		{
			// Nothing for now.
		}
        public VoucherDetailDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<VoucherDetail> SelectAll(VoucherDetail dtoObject)
        {
            List<VoucherDetail> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.VoucherDetailSelectAll)
                                                .AddParameter("@VoucherDetailID", dtoObject.VoucherDetailID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@VoucherNo", dtoObject.VoucherNo)
.AddParameter("@AgentID", dtoObject.AgentID)
.AddParameter("@IsApplyCommission", dtoObject.IsApplyCommission)
.AddParameter("@Commission_TermID", dtoObject.Commission_TermID)
.AddParameter("@CommissionValue", dtoObject.CommissionValue)
.AddParameter("@IsCommissionFlat", dtoObject.IsCommissionFlat)
.AddParameter("@AgentType_TermID", dtoObject.AgentType_TermID)
.AddParameter("@IsDirectBill", dtoObject.IsDirectBill)
.AddParameter("@AccommodationChargeFolioID", dtoObject.AccommodationChargeFolioID)
.AddParameter("@PayableAccommodationCharge", dtoObject.PayableAccommodationCharge)
.AddParameter("@POSFolioID", dtoObject.POSFolioID)
.AddParameter("@RestaurantFolioID", dtoObject.RestaurantFolioID)
.AddParameter("@CallLoggerFolioID", dtoObject.CallLoggerFolioID)
.AddParameter("@MiscellaneousServiceID", dtoObject.MiscellaneousServiceID)
.AddParameter("@MiscellaneousFolioID", dtoObject.MiscellaneousFolioID)
.AddParameter("@LaundryFolioID", dtoObject.LaundryFolioID)
.AddParameter("@BillingAddressID", dtoObject.BillingAddressID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@VoucherAuthorisedBy", dtoObject.VoucherAuthorisedBy)
.AddParameter("@Validity", dtoObject.Validity)
.AddParameter("@Voucher", dtoObject.Voucher)

                                                .WithTransaction(dbtr)
                                                .FetchAll<VoucherDetail>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.VoucherDetailSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<VoucherDetail>();
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

        public List<VoucherDetail> SelectAll()
        {
            List<VoucherDetail> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.VoucherDetailSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<VoucherDetail>();
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
        public DataSet SelectAllWithDataSet(VoucherDetail dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.VoucherDetailSelectAll)
                                                .AddParameter("@VoucherDetailID", dtoObject.VoucherDetailID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@VoucherNo", dtoObject.VoucherNo)
.AddParameter("@AgentID", dtoObject.AgentID)
.AddParameter("@IsApplyCommission", dtoObject.IsApplyCommission)
.AddParameter("@Commission_TermID", dtoObject.Commission_TermID)
.AddParameter("@CommissionValue", dtoObject.CommissionValue)
.AddParameter("@IsCommissionFlat", dtoObject.IsCommissionFlat)
.AddParameter("@AgentType_TermID", dtoObject.AgentType_TermID)
.AddParameter("@IsDirectBill", dtoObject.IsDirectBill)
.AddParameter("@AccommodationChargeFolioID", dtoObject.AccommodationChargeFolioID)
.AddParameter("@PayableAccommodationCharge", dtoObject.PayableAccommodationCharge)
.AddParameter("@POSFolioID", dtoObject.POSFolioID)
.AddParameter("@RestaurantFolioID", dtoObject.RestaurantFolioID)
.AddParameter("@CallLoggerFolioID", dtoObject.CallLoggerFolioID)
.AddParameter("@MiscellaneousServiceID", dtoObject.MiscellaneousServiceID)
.AddParameter("@MiscellaneousFolioID", dtoObject.MiscellaneousFolioID)
.AddParameter("@LaundryFolioID", dtoObject.LaundryFolioID)
.AddParameter("@BillingAddressID", dtoObject.BillingAddressID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@VoucherAuthorisedBy", dtoObject.VoucherAuthorisedBy)
.AddParameter("@Validity", dtoObject.Validity)
.AddParameter("@Voucher", dtoObject.Voucher)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.VoucherDetailSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.VoucherDetailSelectAll)
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
		public bool Insert(VoucherDetail dtoObject)
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

                    StoredProcedure(MasterDALConstant.VoucherDetailInsert)
                        .AddParameter("@VoucherDetailID", dtoObject.VoucherDetailID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@VoucherNo", dtoObject.VoucherNo)
.AddParameter("@AgentID", dtoObject.AgentID)
.AddParameter("@IsApplyCommission", dtoObject.IsApplyCommission)
.AddParameter("@Commission_TermID", dtoObject.Commission_TermID)
.AddParameter("@CommissionValue", dtoObject.CommissionValue)
.AddParameter("@IsCommissionFlat", dtoObject.IsCommissionFlat)
.AddParameter("@AgentType_TermID", dtoObject.AgentType_TermID)
.AddParameter("@IsDirectBill", dtoObject.IsDirectBill)
.AddParameter("@AccommodationChargeFolioID", dtoObject.AccommodationChargeFolioID)
.AddParameter("@PayableAccommodationCharge", dtoObject.PayableAccommodationCharge)
.AddParameter("@POSFolioID", dtoObject.POSFolioID)
.AddParameter("@RestaurantFolioID", dtoObject.RestaurantFolioID)
.AddParameter("@CallLoggerFolioID", dtoObject.CallLoggerFolioID)
.AddParameter("@MiscellaneousServiceID", dtoObject.MiscellaneousServiceID)
.AddParameter("@MiscellaneousFolioID", dtoObject.MiscellaneousFolioID)
.AddParameter("@LaundryFolioID", dtoObject.LaundryFolioID)
.AddParameter("@BillingAddressID", dtoObject.BillingAddressID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@VoucherAuthorisedBy", dtoObject.VoucherAuthorisedBy)
.AddParameter("@Validity", dtoObject.Validity)
.AddParameter("@Voucher", dtoObject.Voucher)

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
        public bool Update(VoucherDetail dtoObject)
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

                    StoredProcedure(MasterDALConstant.VoucherDetailUpdate)
                        .AddParameter("@VoucherDetailID", dtoObject.VoucherDetailID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@VoucherNo", dtoObject.VoucherNo)
.AddParameter("@AgentID", dtoObject.AgentID)
.AddParameter("@IsApplyCommission", dtoObject.IsApplyCommission)
.AddParameter("@Commission_TermID", dtoObject.Commission_TermID)
.AddParameter("@CommissionValue", dtoObject.CommissionValue)
.AddParameter("@IsCommissionFlat", dtoObject.IsCommissionFlat)
.AddParameter("@AgentType_TermID", dtoObject.AgentType_TermID)
.AddParameter("@IsDirectBill", dtoObject.IsDirectBill)
.AddParameter("@AccommodationChargeFolioID", dtoObject.AccommodationChargeFolioID)
.AddParameter("@PayableAccommodationCharge", dtoObject.PayableAccommodationCharge)
.AddParameter("@POSFolioID", dtoObject.POSFolioID)
.AddParameter("@RestaurantFolioID", dtoObject.RestaurantFolioID)
.AddParameter("@CallLoggerFolioID", dtoObject.CallLoggerFolioID)
.AddParameter("@MiscellaneousServiceID", dtoObject.MiscellaneousServiceID)
.AddParameter("@MiscellaneousFolioID", dtoObject.MiscellaneousFolioID)
.AddParameter("@LaundryFolioID", dtoObject.LaundryFolioID)
.AddParameter("@BillingAddressID", dtoObject.BillingAddressID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@VoucherAuthorisedBy", dtoObject.VoucherAuthorisedBy)
.AddParameter("@Validity", dtoObject.Validity)
.AddParameter("@Voucher", dtoObject.Voucher)

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
                StoredProcedure(MasterDALConstant.VoucherDetailDeleteByPrimaryKey)
                    .AddParameter("@VoucherDetailID"
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
        public bool Delete(VoucherDetail dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.VoucherDetailDeleteByPrimaryKey)
                    .AddParameter("@VoucherDetailID", dtoObject.VoucherDetailID)

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

        public VoucherDetail SelectByPrimaryKey(Guid Keys)
        {
            VoucherDetail obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.VoucherDetailSelectByPrimaryKey)
                            .AddParameter("@VoucherDetailID"
,Keys)
                            .Fetch<VoucherDetail>();
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
        public List<VoucherDetail> SelectByField(string fieldName, object value)
        {
            List<VoucherDetail> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.VoucherDetailSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<VoucherDetail>();

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
                obj = StoredProcedure(MasterDALConstant.VoucherDetailSelectByField) 
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
                StoredProcedure(MasterDALConstant.VoucherDetailDeleteByField) 
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
