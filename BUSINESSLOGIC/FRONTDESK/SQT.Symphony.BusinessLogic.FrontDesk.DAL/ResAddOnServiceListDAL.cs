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
	/// Data access layer class for ResAddOnServiceList
	/// </summary>
	public class ResAddOnServiceListDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public ResAddOnServiceListDAL() :  base()
		{
			// Nothing for now.
		}
        public ResAddOnServiceListDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<ResAddOnServiceList> SelectAll(ResAddOnServiceList dtoObject)
        {
            List<ResAddOnServiceList> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.ResAddOnServiceListSelectAll)
                                                .AddParameter("@ResAddOnServiceID", dtoObject.ResAddOnServiceID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@StatusRemark", dtoObject.StatusRemark)
.AddParameter("@Amount", dtoObject.Amount)
.AddParameter("@Qty", dtoObject.Qty)
.AddParameter("@Total", dtoObject.Total)
.AddParameter("@ServiceDate", dtoObject.ServiceDate)
.AddParameter("@StartDate", dtoObject.StartDate)
.AddParameter("@ExpiryDate", dtoObject.ExpiryDate)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@Notes", dtoObject.Notes)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ServiceStatus_Term", dtoObject.ServiceStatus_Term)
.AddParameter("@IsDelete", dtoObject.IsDelete)

                                                .WithTransaction(dbtr)
                                                .FetchAll<ResAddOnServiceList>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ResAddOnServiceListSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<ResAddOnServiceList>();
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

        public List<ResAddOnServiceList> SelectAll()
        {
            List<ResAddOnServiceList> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.ResAddOnServiceListSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<ResAddOnServiceList>();
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
        public DataSet SelectAllWithDataSet(ResAddOnServiceList dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.ResAddOnServiceListSelectAll)
                                                .AddParameter("@ResAddOnServiceID", dtoObject.ResAddOnServiceID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@StatusRemark", dtoObject.StatusRemark)
.AddParameter("@Amount", dtoObject.Amount)
.AddParameter("@Qty", dtoObject.Qty)
.AddParameter("@Total", dtoObject.Total)
.AddParameter("@ServiceDate", dtoObject.ServiceDate)
.AddParameter("@StartDate", dtoObject.StartDate)
.AddParameter("@ExpiryDate", dtoObject.ExpiryDate)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@Notes", dtoObject.Notes)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ServiceStatus_Term", dtoObject.ServiceStatus_Term)
.AddParameter("@IsDelete", dtoObject.IsDelete)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ResAddOnServiceListSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.ResAddOnServiceListSelectAll)
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
		public bool Insert(ResAddOnServiceList dtoObject)
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

                    StoredProcedure(MasterDALConstant.ResAddOnServiceListInsert)
                        .AddParameter("@ResAddOnServiceID", dtoObject.ResAddOnServiceID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@StatusRemark", dtoObject.StatusRemark)
.AddParameter("@Amount", dtoObject.Amount)
.AddParameter("@Qty", dtoObject.Qty)
.AddParameter("@Total", dtoObject.Total)
.AddParameter("@ServiceDate", dtoObject.ServiceDate)
.AddParameter("@StartDate", dtoObject.StartDate)
.AddParameter("@ExpiryDate", dtoObject.ExpiryDate)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@Notes", dtoObject.Notes)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ServiceStatus_Term", dtoObject.ServiceStatus_Term)
.AddParameter("@IsDelete", dtoObject.IsDelete)

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
        public bool Update(ResAddOnServiceList dtoObject)
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

                    StoredProcedure(MasterDALConstant.ResAddOnServiceListUpdate)
                        .AddParameter("@ResAddOnServiceID", dtoObject.ResAddOnServiceID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@StatusRemark", dtoObject.StatusRemark)
.AddParameter("@Amount", dtoObject.Amount)
.AddParameter("@Qty", dtoObject.Qty)
.AddParameter("@Total", dtoObject.Total)
.AddParameter("@ServiceDate", dtoObject.ServiceDate)
.AddParameter("@StartDate", dtoObject.StartDate)
.AddParameter("@ExpiryDate", dtoObject.ExpiryDate)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@Notes", dtoObject.Notes)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ServiceStatus_Term", dtoObject.ServiceStatus_Term)
.AddParameter("@IsDelete", dtoObject.IsDelete)

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
                StoredProcedure(MasterDALConstant.ResAddOnServiceListDeleteByPrimaryKey)
                    .AddParameter("@ResAddOnServiceID"
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
        public bool Delete(ResAddOnServiceList dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.ResAddOnServiceListDeleteByPrimaryKey)
                    .AddParameter("@ResAddOnServiceID", dtoObject.ResAddOnServiceID)

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

        public ResAddOnServiceList SelectByPrimaryKey(Guid Keys)
        {
            ResAddOnServiceList obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ResAddOnServiceListSelectByPrimaryKey)
                            .AddParameter("@ResAddOnServiceID"
,Keys)
                            .Fetch<ResAddOnServiceList>();
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
        public List<ResAddOnServiceList> SelectByField(string fieldName, object value)
        {
            List<ResAddOnServiceList> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ResAddOnServiceListSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<ResAddOnServiceList>();

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
                obj = StoredProcedure(MasterDALConstant.ResAddOnServiceListSelectByField) 
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
                StoredProcedure(MasterDALConstant.ResAddOnServiceListDeleteByField) 
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

        public DataSet SelectCurrentGuestListDataAddOnServices(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID, string GuestFullName, string MobileNo, string ReservationNo, string RoomNo, Guid? BillingInstructionID,string CashCardNo)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.GuestSelectCurrentGuestListAddOnServices)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@GuestFullName", GuestFullName)
                                    .AddParameter("@MobileNo", MobileNo)
                                    .AddParameter("@ReservationNo", ReservationNo)
                                    .AddParameter("@RoomNo", RoomNo)
                                    .AddParameter("@BillingInstructionID", BillingInstructionID)
                                    .AddParameter("@CashCardNo",CashCardNo)
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

        public DataSet GetResAddOnServiceListItemTypeTermIDServiceName(Guid CompanyID, Guid PropertyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ResAddOnServiceListItemTypeTermIDServiceName)
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

        public DataSet GetResAddOnServiceListWithServiceName(Guid ReservationID, Guid GuestID, Guid? ItemID, Guid CompanyID, Guid PropertyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ResAddOnServiceListSelectAllWithServiceName)
                    .AddParameter("@ReservationID", ReservationID)
                    .AddParameter("@GuestID", GuestID)
                    .AddParameter("@ItemID", ItemID)
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

        public DataSet RoomBlockSelectAllRoomBlockData(DateTime? StartDate, DateTime? ExpiryDate, Guid? ItemID, Guid? PropertyID, Guid? CompanyID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.ResAddOnServiceListSelectAllSelectAllSearchServices)
                    .AddParameter("@StartDate", StartDate)
                    .AddParameter("@ExpiryDate", ExpiryDate)
                    .AddParameter("@ItemID", ItemID)
                    .AddParameter("@PropertyID", PropertyID)
                    .AddParameter("@CompanyID", CompanyID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }
        
        #endregion
	}
}
