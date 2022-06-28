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
	/// Data access layer class for ReservationVoucher
	/// </summary>
	public class ReservationVoucherDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public ReservationVoucherDAL() :  base()
		{
			// Nothing for now.
		}
        public ReservationVoucherDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<ReservationVoucher> SelectAll(ReservationVoucher dtoObject)
        {
            List<ReservationVoucher> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.ReservationVoucherSelectAll)
                                                .AddParameter("@ResVoucherID", dtoObject.ResVoucherID)
.AddParameter("@VoucherNo", dtoObject.VoucherNo)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@CheckInDate", dtoObject.CheckInDate)
.AddParameter("@CheckOutDate", dtoObject.CheckOutDate)
.AddParameter("@TotalNights", dtoObject.TotalNights)
.AddParameter("@GuestName", dtoObject.GuestName)
.AddParameter("@TotalGuest", dtoObject.TotalGuest)
.AddParameter("@Status_Term", dtoObject.Status_Term)
.AddParameter("@CreatedBy_Term", dtoObject.CreatedBy_Term)
.AddParameter("@Adult", dtoObject.Adult)
.AddParameter("@children", dtoObject.Children)
.AddParameter("@NoOfRoom", dtoObject.NoOfRoom)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@ApprovedBy", dtoObject.ApprovedBy)
.AddParameter("@ApprovedOn", dtoObject.ApprovedOn)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@AllocatedRoomID", dtoObject.AllocatedRoomID)
.AddParameter("@InvestorUnitID", dtoObject.InvestorUnitID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UpdateBy", dtoObject.UpdateBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@Phone", dtoObject.Phone)
.AddParameter("@Notes", dtoObject.Notes)

                                                .WithTransaction(dbtr)
                                                .FetchAll<ReservationVoucher>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ReservationVoucherSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<ReservationVoucher>();
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

        public List<ReservationVoucher> SelectAll()
        {
            List<ReservationVoucher> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.ReservationVoucherSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<ReservationVoucher>();
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
        public DataSet SelectAllWithDataSet(ReservationVoucher dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.ReservationVoucherSelectAll)
                                                .AddParameter("@ResVoucherID", dtoObject.ResVoucherID)
.AddParameter("@VoucherNo", dtoObject.VoucherNo)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@CheckInDate", dtoObject.CheckInDate)
.AddParameter("@CheckOutDate", dtoObject.CheckOutDate)
.AddParameter("@TotalNights", dtoObject.TotalNights)
.AddParameter("@GuestName", dtoObject.GuestName)
.AddParameter("@TotalGuest", dtoObject.TotalGuest)
.AddParameter("@Status_Term", dtoObject.Status_Term)
.AddParameter("@CreatedBy_Term", dtoObject.CreatedBy_Term)
.AddParameter("@Adult", dtoObject.Adult)
.AddParameter("@children", dtoObject.Children)
.AddParameter("@NoOfRoom", dtoObject.NoOfRoom)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@ApprovedBy", dtoObject.ApprovedBy)
.AddParameter("@ApprovedOn", dtoObject.ApprovedOn)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@AllocatedRoomID", dtoObject.AllocatedRoomID)
.AddParameter("@InvestorUnitID", dtoObject.InvestorUnitID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UpdateBy", dtoObject.UpdateBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@Phone", dtoObject.Phone)
.AddParameter("@Notes", dtoObject.Notes)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ReservationVoucherSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.ReservationVoucherSelectAll)
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
		public bool Insert(ReservationVoucher dtoObject)
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

                    StoredProcedure(MasterDALConstant.ReservationVoucherInsert)
                        .AddParameter("@ResVoucherID", dtoObject.ResVoucherID)
.AddParameter("@VoucherNo", dtoObject.VoucherNo)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@CheckInDate", dtoObject.CheckInDate)
.AddParameter("@CheckOutDate", dtoObject.CheckOutDate)
.AddParameter("@TotalNights", dtoObject.TotalNights)
.AddParameter("@GuestName", dtoObject.GuestName)
.AddParameter("@TotalGuest", dtoObject.TotalGuest)
.AddParameter("@Status_Term", dtoObject.Status_Term)
.AddParameter("@CreatedBy_Term", dtoObject.CreatedBy_Term)
.AddParameter("@Adult", dtoObject.Adult)
.AddParameter("@children", dtoObject.Children)
.AddParameter("@NoOfRoom", dtoObject.NoOfRoom)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@ApprovedBy", dtoObject.ApprovedBy)
.AddParameter("@ApprovedOn", dtoObject.ApprovedOn)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@AllocatedRoomID", dtoObject.AllocatedRoomID)
.AddParameter("@InvestorUnitID", dtoObject.InvestorUnitID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UpdateBy", dtoObject.UpdateBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@Phone", dtoObject.Phone)
.AddParameter("@Notes", dtoObject.Notes)

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
        public bool Update(ReservationVoucher dtoObject)
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

                    StoredProcedure(MasterDALConstant.ReservationVoucherUpdate)
                        .AddParameter("@ResVoucherID", dtoObject.ResVoucherID)
.AddParameter("@VoucherNo", dtoObject.VoucherNo)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@CheckInDate", dtoObject.CheckInDate)
.AddParameter("@CheckOutDate", dtoObject.CheckOutDate)
.AddParameter("@TotalNights", dtoObject.TotalNights)
.AddParameter("@GuestName", dtoObject.GuestName)
.AddParameter("@TotalGuest", dtoObject.TotalGuest)
.AddParameter("@Status_Term", dtoObject.Status_Term)
.AddParameter("@CreatedBy_Term", dtoObject.CreatedBy_Term)
.AddParameter("@Adult", dtoObject.Adult)
.AddParameter("@children", dtoObject.Children)
.AddParameter("@NoOfRoom", dtoObject.NoOfRoom)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@ApprovedBy", dtoObject.ApprovedBy)
.AddParameter("@ApprovedOn", dtoObject.ApprovedOn)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@AllocatedRoomID", dtoObject.AllocatedRoomID)
.AddParameter("@InvestorUnitID", dtoObject.InvestorUnitID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UpdateBy", dtoObject.UpdateBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@Phone", dtoObject.Phone)
.AddParameter("@IsToAddDaysBack", dtoObject.IsToAddDaysBack)
.AddParameter("@Notes", dtoObject.Notes)

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
                StoredProcedure(MasterDALConstant.ReservationVoucherDeleteByPrimaryKey)
                    .AddParameter("@ResVoucherID"
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
        public bool Delete(ReservationVoucher dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.ReservationVoucherDeleteByPrimaryKey)
                    .AddParameter("@ResVoucherID", dtoObject.ResVoucherID)

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

        public ReservationVoucher SelectByPrimaryKey(Guid Keys)
        {
            ReservationVoucher obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationVoucherSelectByPrimaryKey)
                            .AddParameter("@ResVoucherID"
,Keys)
                            .Fetch<ReservationVoucher>();
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
        public List<ReservationVoucher> SelectByField(string fieldName, object value)
        {
            List<ReservationVoucher> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationVoucherSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<ReservationVoucher>();

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
                obj = StoredProcedure(MasterDALConstant.ReservationVoucherSelectByField) 
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
                StoredProcedure(MasterDALConstant.ReservationVoucherDeleteByField) 
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

        public bool Update_ReservationAndAllocatedRoomID(Guid ResVoucherID, Guid ReservationID, Guid? AllocatedRoomID, string UpdateMode)
        {
            try
            {
                StoredProcedure(MasterDALConstant.ReservationVoucherUpdate_ReservationAndAllocatedRoomID)
                                    .AddParameter("@ResVoucherID", ResVoucherID)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@AllocatedRoomID", AllocatedRoomID)
                                    .AddParameter("@UpdateMode", UpdateMode)
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

        public DataSet SelectAll_ForFrontDesk_ByInvestorID(Guid InvestorID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationVoucherSelectAll_ForFrontDesk_ByInvestorID)
                                    .AddParameter("@InvestorID", InvestorID)
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

        public DataSet SelectByPrimaryKeyInDataSet(Guid ResVoucherID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationVoucherSelectByPrimaryKey)
                                    .AddParameter("@ResVoucherID", ResVoucherID)
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
        public DataSet SelectAll_ReservationVoucherList(Guid? ResVoucherID, Guid? CompanyID, Guid? PropertyID, Guid? InvestorID, string statusterm)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationVoucher_VoucherList)
                                    .AddParameter("@ResVoucherID", ResVoucherID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@InvestorID", InvestorID)
                                     .AddParameter("@Status", statusterm)
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
