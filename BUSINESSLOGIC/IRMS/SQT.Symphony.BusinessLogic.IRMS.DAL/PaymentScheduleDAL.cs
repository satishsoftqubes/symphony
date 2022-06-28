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
	/// Data access layer class for PaymentSchedule
	/// </summary>
	public class PaymentScheduleDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public PaymentScheduleDAL() :  base()
		{
			// Nothing for now.
		}
        public PaymentScheduleDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get Schedule Information
        /// </summary>
        /// <param name="InvestRoomID"></param>
        /// <param name="InvestorID"></param>
        /// <param name="PaymentSlabID"></param>
        /// <returns></returns>
        public DataSet GetScheduleInformation(Guid InvestRoomID, Guid InvestorID, Guid PaymentSlabID)
        {
            DataSet dst = new DataSet();
            try
            {
                dst = StoredProcedure(MasterDALConstant.PaymentScheduleGetSchedule)
                    .AddParameter("@InvestorRoomID", InvestRoomID)
                    .AddParameter("@InvestorID", InvestorID)
                    .AddParameter("@PaymentSlabeID", PaymentSlabID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return dst;
        }
        public List<PaymentSchedule> SelectAll(PaymentSchedule dtoObject)
        {
            List<PaymentSchedule> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.PaymentScheduleSelectAll)
                                                .AddParameter("@PaymentScheduleID", dtoObject.PaymentScheduleID)
.AddParameter("@InvestorRoomID", dtoObject.InvestorRoomID)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@PaymentSlabID", dtoObject.PaymentSlabID)
//.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@ProjectMilestone", dtoObject.ProjectMilestone)
.AddParameter("@AmountPayable", dtoObject.AmountPayable)
.AddParameter("@TotalReceived", dtoObject.TotalReceived)
.AddParameter("@DueDate", dtoObject.DueDate)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsDefaultSchedule", dtoObject.IsDefaultSchedule)
.AddParameter("@ScheduleType", dtoObject.ScheduleType)

                                                .WithTransaction(dbtr)
                                                .FetchAll<PaymentSchedule>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.PaymentScheduleSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<PaymentSchedule>();
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

        public List<PaymentSchedule> SelectAll()
        {
            List<PaymentSchedule> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.PaymentScheduleSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<PaymentSchedule>();
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
        public DataSet SelectAllWithDataSet(PaymentSchedule dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.PaymentScheduleSelectAll)
                                                .AddParameter("@PaymentScheduleID", dtoObject.PaymentScheduleID)
.AddParameter("@InvestorRoomID", dtoObject.InvestorRoomID)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@PaymentSlabID", dtoObject.PaymentSlabID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@ProjectMilestone", dtoObject.ProjectMilestone)
.AddParameter("@AmountPayable", dtoObject.AmountPayable)
.AddParameter("@TotalReceived", dtoObject.TotalReceived)
.AddParameter("@DueDate", dtoObject.DueDate)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsDefaultSchedule", dtoObject.IsDefaultSchedule)
.AddParameter("@ScheduleType", dtoObject.ScheduleType)
                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.PaymentScheduleSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.PaymentScheduleSelectAll)
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
		public bool Insert(PaymentSchedule dtoObject)
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

                    StoredProcedure(MasterDALConstant.PaymentScheduleInsert)
                        .AddParameter("@PaymentScheduleID", dtoObject.PaymentScheduleID)
.AddParameter("@InvestorRoomID", dtoObject.InvestorRoomID)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@PaymentSlabID", dtoObject.PaymentSlabID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@ProjectMilestone", dtoObject.ProjectMilestone)
.AddParameter("@AmountPayable", dtoObject.AmountPayable)
.AddParameter("@TotalReceived", dtoObject.TotalReceived)
.AddParameter("@DueDate", dtoObject.DueDate)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsDefaultSchedule", dtoObject.IsDefaultSchedule)
.AddParameter("@ScheduleType", dtoObject.ScheduleType)
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

        public bool InsertNew(PaymentSchedule dtoObject)
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

                    StoredProcedure(MasterDALConstant.PaymentScheduleInsertNew)
                        .AddParameter("@PaymentScheduleID", dtoObject.PaymentScheduleID)
.AddParameter("@InvestorRoomID", dtoObject.InvestorRoomID)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@PaymentSlabID", dtoObject.PaymentSlabID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@ProjectMilestone", dtoObject.ProjectMilestone)
.AddParameter("@AmountPayable", dtoObject.AmountPayable)
.AddParameter("@TotalReceived", dtoObject.TotalReceived)
.AddParameter("@DueDate", dtoObject.DueDate)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsDefaultSchedule", dtoObject.IsDefaultSchedule)
.AddParameter("@ScheduleType", dtoObject.ScheduleType)
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

        public bool DeleteByInvestorRoomID(Guid investorRoomID)
        {
            try
            {
                StoredProcedure(MasterDALConstant.PaymentScheduleDeleteByInvestorRoomID)
                    .AddParameter("@InvestorRoomID", investorRoomID)
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

         /// <summary>
        /// update row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true for successfully updated</returns>
        public bool Update(PaymentSchedule dtoObject)
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

                    StoredProcedure(MasterDALConstant.PaymentScheduleUpdate)
                        .AddParameter("@PaymentScheduleID", dtoObject.PaymentScheduleID)
.AddParameter("@InvestorRoomID", dtoObject.InvestorRoomID)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@PaymentSlabID", dtoObject.PaymentSlabID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@ProjectMilestone", dtoObject.ProjectMilestone)
.AddParameter("@AmountPayable", dtoObject.AmountPayable)
.AddParameter("@TotalReceived", dtoObject.TotalReceived)
.AddParameter("@DueDate", dtoObject.DueDate)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsDefaultSchedule", dtoObject.IsDefaultSchedule)
.AddParameter("@ScheduleType", dtoObject.ScheduleType)
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
                StoredProcedure(MasterDALConstant.PaymentScheduleDeleteByPrimaryKey)
                    .AddParameter("@PaymentScheduleID"
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
        public bool Delete(PaymentSchedule dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.PaymentScheduleDeleteByPrimaryKey)
                    .AddParameter("@PaymentScheduleID", dtoObject.PaymentScheduleID)

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

        public PaymentSchedule SelectByPrimaryKey(Guid Keys)
        {
            PaymentSchedule obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.PaymentScheduleSelectByPrimaryKey)
                            .AddParameter("@PaymentScheduleID"
,Keys)
                            .Fetch<PaymentSchedule>();
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
        public List<PaymentSchedule> SelectByField(string fieldName, object value)
        {
            List<PaymentSchedule> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.PaymentScheduleSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<PaymentSchedule>();

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
                obj = StoredProcedure(MasterDALConstant.PaymentScheduleSelectByField) 
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
                StoredProcedure(MasterDALConstant.PaymentScheduleDeleteByField) 
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

        public DataSet SearchPaymentScheduleData(Guid? PaymentScheduleID, DateTime? DueDate, Guid? CompanyID, Guid? InvestorID, Guid? RoomID, string UnitNumber,bool? IsDefault, Guid? PropertyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.PaymentScheduleSearchData)
                                            .AddParameter("@PaymentScheduleID",PaymentScheduleID)
                                            .AddParameter("@DueDate", DueDate)
                                            .AddParameter("@CompanyID", CompanyID)
                                            .AddParameter("@InvestorID", InvestorID)
                                            .AddParameter("@RoomID", RoomID)
                                            .AddParameter("@UnitNo", UnitNumber)
                                            .AddParameter("@IsDefaultSchedule",IsDefault)
                                            .AddParameter("@PropertyID", PropertyID)
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

        public DataSet SearchPaymentScheduleDataNew(Guid? CompanyID, Guid? InvestorID, string UnitNumber, Guid? PropertyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.PaymentScheduleSearchDataNew)
                                            .AddParameter("@CompanyID", CompanyID)
                                            .AddParameter("@InvestorID", InvestorID)
                                            .AddParameter("@UnitNo", UnitNumber)
                                            .AddParameter("@PropertyID", PropertyID)
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

        public DataSet PaymentScheduleGetAllByInvestorRoomID(Guid InvestorRoomID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.PaymentScheduleGetAllByInvestorRoomID)
                                            .AddParameter("@InvestorRoomID", InvestorRoomID)
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

        public DataSet GetPaymentScheduleByInvestorRoomID(Guid InvestorRoomID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.PaymentScheduleGetByInvestorRoomID)
                                            .AddParameter("@InvestorRoomID", InvestorRoomID)
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

        public DataSet SelectTotalAmountByPaymentSlab(string PaymentQuery)
        {
            DataSet dst = new DataSet();
            try
            {
                dst = Query(PaymentQuery)
                            .WithTransaction(dbtr)
                            .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return dst;
        }

        public DataSet GetPaymentByScheduleID(Guid PaymentScheduleID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.PaymentScheduleGetMaxAmount)
                                    .AddParameter("@PaymentScheduleID", PaymentScheduleID)
                                    .FetchDataSet();
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

        public bool InvestorScheduleLoadStadScheduleAgain(Guid? InvestorID, Guid? RoomID)
        {
            try
            {
                StoredProcedure(MasterDALConstant.InvestorScheduleLoadStadScheduleAgain)
.AddParameter("@InvestorID", InvestorID)
.AddParameter("@RoomID", RoomID)
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

        public DataSet PaymentScheduleSelectInvestorPaymentDetails(Guid? InvestorRoomID, Guid? InvestorID, Guid? CompanyID)
        {
            DataSet dsData = new DataSet();

            try
            {
               dsData = StoredProcedure(MasterDALConstant.PaymentScheduleSelectInvestorPaymentDetails)
                .AddParameter("@InvestorRoomID", InvestorRoomID)
                .AddParameter("@InvestorID", InvestorID)
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
            return dsData;
        }

        public DataSet PaymentScheduleGetLadgerStatement(Guid investorID, Guid propertyID, DateTime? dateFrom, DateTime? dateTo)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.PaymentScheduleGetLadgerStatement)
                                            .AddParameter("@InvestorID", investorID)
                                            .AddParameter("@PropertyID", propertyID)
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

        #endregion
	}
}
