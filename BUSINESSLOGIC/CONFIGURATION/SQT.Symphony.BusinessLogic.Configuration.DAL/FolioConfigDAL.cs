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
	/// Data access layer class for FolioConfig
	/// </summary>
	public class FolioConfigDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public FolioConfigDAL() :  base()
		{
			// Nothing for now.
		}
        public FolioConfigDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<FolioConfig> SelectAll(FolioConfig dtoObject)
        {
            List<FolioConfig> obj = null;
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
                        obj = StoredProcedure(MasterConstant.FolioConfigSelectAll)
                                                .AddParameter("@FolioConfigID", dtoObject.FolioConfigID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@FolioNotes", dtoObject.FolioNotes)
.AddParameter("@TermnCondition", dtoObject.TermnCondition)
.AddParameter("@IsReRoutingEnable", dtoObject.IsReRoutingEnable)
.AddParameter("@IsReRoutingInSameReservation", dtoObject.IsReRoutingInSameReservation)
.AddParameter("@IsReRoutingInGroupReservation", dtoObject.IsReRoutingInGroupReservation)
.AddParameter("@IsReRoutingInAllReservation", dtoObject.IsReRoutingInAllReservation)
.AddParameter("@IsCreateSubFolioByTransactionZone", dtoObject.IsCreateSubFolioByTransactionZone)
.AddParameter("@IsAutoCreateFoliosForAccomodation", dtoObject.IsAutoCreateFoliosForAccomodation)
.AddParameter("@IsAutoCreateFoliosForRestaurent", dtoObject.IsAutoCreateFoliosForRestaurent)
.AddParameter("@IsAutoCreateFoliosForPOS", dtoObject.IsAutoCreateFoliosForPOS)
.AddParameter("@IsAutoCreateFoliosForMiscellaneous", dtoObject.IsAutoCreateFoliosForMiscellaneous)
.AddParameter("@IsAutoCreateFoliosForCallLogger", dtoObject.IsAutoCreateFoliosForCallLogger)
.AddParameter("@IsAutoCreateFoliosForLaundry", dtoObject.IsAutoCreateFoliosForLaundry)
.AddParameter("@IsAutoCreateFoliosForMiscServices", dtoObject.IsAutoCreateFoliosForMiscServices)
.AddParameter("@IsTransferBalanceApplicable", dtoObject.IsTransferBalanceApplicable)
.AddParameter("@IsAdvancedChargePostingApplicable", dtoObject.IsAdvancedChargePostingApplicable)
.AddParameter("@IsTransferTransactionApplicable", dtoObject.IsTransferTransactionApplicable)
.AddParameter("@IsBalanceTransferApplicable", dtoObject.IsBalanceTransferApplicable)
.AddParameter("@IsDepositTransferApplicable", dtoObject.IsDepositTransferApplicable)
.AddParameter("@IsVoidTransactionApplicable", dtoObject.IsVoidTransactionApplicable)
.AddParameter("@IsSplitFolioApplicable", dtoObject.IsSplitFolioApplicable)
.AddParameter("@IsAutoCheckInFolioWithReservation", dtoObject.IsAutoCheckInFolioWithReservation)
.AddParameter("@ReservationPolicyNote", dtoObject.ReservationPolicyNote)



                                                .WithTransaction(dbtr)
                                                .FetchAll<FolioConfig>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.FolioConfigSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<FolioConfig>();
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

        public List<FolioConfig> SelectAll()
        {
            List<FolioConfig> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.FolioConfigSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<FolioConfig>();
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
        public DataSet SelectAllWithDataSet(FolioConfig dtoObject)
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
                        obj = StoredProcedure(MasterConstant.FolioConfigSelectAll)
                                                .AddParameter("@FolioConfigID", dtoObject.FolioConfigID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@FolioNotes", dtoObject.FolioNotes)
.AddParameter("@TermnCondition", dtoObject.TermnCondition)
.AddParameter("@IsReRoutingEnable", dtoObject.IsReRoutingEnable)
.AddParameter("@IsReRoutingInSameReservation", dtoObject.IsReRoutingInSameReservation)
.AddParameter("@IsReRoutingInGroupReservation", dtoObject.IsReRoutingInGroupReservation)
.AddParameter("@IsReRoutingInAllReservation", dtoObject.IsReRoutingInAllReservation)
.AddParameter("@IsCreateSubFolioByTransactionZone", dtoObject.IsCreateSubFolioByTransactionZone)
.AddParameter("@IsAutoCreateFoliosForAccomodation", dtoObject.IsAutoCreateFoliosForAccomodation)
.AddParameter("@IsAutoCreateFoliosForRestaurent", dtoObject.IsAutoCreateFoliosForRestaurent)
.AddParameter("@IsAutoCreateFoliosForPOS", dtoObject.IsAutoCreateFoliosForPOS)
.AddParameter("@IsAutoCreateFoliosForMiscellaneous", dtoObject.IsAutoCreateFoliosForMiscellaneous)
.AddParameter("@IsAutoCreateFoliosForCallLogger", dtoObject.IsAutoCreateFoliosForCallLogger)
.AddParameter("@IsAutoCreateFoliosForLaundry", dtoObject.IsAutoCreateFoliosForLaundry)
.AddParameter("@IsAutoCreateFoliosForMiscServices", dtoObject.IsAutoCreateFoliosForMiscServices)
.AddParameter("@IsTransferBalanceApplicable", dtoObject.IsTransferBalanceApplicable)
.AddParameter("@IsAdvancedChargePostingApplicable", dtoObject.IsAdvancedChargePostingApplicable)
.AddParameter("@IsTransferTransactionApplicable", dtoObject.IsTransferTransactionApplicable)
.AddParameter("@IsBalanceTransferApplicable", dtoObject.IsBalanceTransferApplicable)
.AddParameter("@IsDepositTransferApplicable", dtoObject.IsDepositTransferApplicable)
.AddParameter("@IsVoidTransactionApplicable", dtoObject.IsVoidTransactionApplicable)
.AddParameter("@IsSplitFolioApplicable", dtoObject.IsSplitFolioApplicable)
.AddParameter("@IsAutoCheckInFolioWithReservation", dtoObject.IsAutoCheckInFolioWithReservation)
.AddParameter("@ReservationPolicyNote", dtoObject.ReservationPolicyNote)


                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.FolioConfigSelectAll)
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

                    obj = StoredProcedure(MasterConstant.FolioConfigSelectAll)
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
		public bool Insert(FolioConfig dtoObject)
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

                    StoredProcedure(MasterConstant.FolioConfigInsert)
                        .AddParameter("@FolioConfigID", dtoObject.FolioConfigID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@FolioNotes", dtoObject.FolioNotes)
.AddParameter("@TermnCondition", dtoObject.TermnCondition)
.AddParameter("@IsReRoutingEnable", dtoObject.IsReRoutingEnable)
.AddParameter("@IsReRoutingInSameReservation", dtoObject.IsReRoutingInSameReservation)
.AddParameter("@IsReRoutingInGroupReservation", dtoObject.IsReRoutingInGroupReservation)
.AddParameter("@IsReRoutingInAllReservation", dtoObject.IsReRoutingInAllReservation)
.AddParameter("@IsCreateSubFolioByTransactionZone", dtoObject.IsCreateSubFolioByTransactionZone)
.AddParameter("@IsAutoCreateFoliosForAccomodation", dtoObject.IsAutoCreateFoliosForAccomodation)
.AddParameter("@IsAutoCreateFoliosForRestaurent", dtoObject.IsAutoCreateFoliosForRestaurent)
.AddParameter("@IsAutoCreateFoliosForPOS", dtoObject.IsAutoCreateFoliosForPOS)
.AddParameter("@IsAutoCreateFoliosForMiscellaneous", dtoObject.IsAutoCreateFoliosForMiscellaneous)
.AddParameter("@IsAutoCreateFoliosForCallLogger", dtoObject.IsAutoCreateFoliosForCallLogger)
.AddParameter("@IsAutoCreateFoliosForLaundry", dtoObject.IsAutoCreateFoliosForLaundry)
.AddParameter("@IsAutoCreateFoliosForMiscServices", dtoObject.IsAutoCreateFoliosForMiscServices)
.AddParameter("@IsTransferBalanceApplicable", dtoObject.IsTransferBalanceApplicable)
.AddParameter("@IsAdvancedChargePostingApplicable", dtoObject.IsAdvancedChargePostingApplicable)
.AddParameter("@IsTransferTransactionApplicable", dtoObject.IsTransferTransactionApplicable)
.AddParameter("@IsBalanceTransferApplicable", dtoObject.IsBalanceTransferApplicable)
.AddParameter("@IsDepositTransferApplicable", dtoObject.IsDepositTransferApplicable)
.AddParameter("@IsVoidTransactionApplicable", dtoObject.IsVoidTransactionApplicable)
.AddParameter("@IsSplitFolioApplicable", dtoObject.IsSplitFolioApplicable)
.AddParameter("@IsAutoCheckInFolioWithReservation", dtoObject.IsAutoCheckInFolioWithReservation)
.AddParameter("@ReservationPolicyNote", dtoObject.ReservationPolicyNote)


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
        public bool Update(FolioConfig dtoObject)
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

                    StoredProcedure(MasterConstant.FolioConfigUpdate)
                        .AddParameter("@FolioConfigID", dtoObject.FolioConfigID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@FolioNotes", dtoObject.FolioNotes)
.AddParameter("@TermnCondition", dtoObject.TermnCondition)
.AddParameter("@IsReRoutingEnable", dtoObject.IsReRoutingEnable)
.AddParameter("@IsReRoutingInSameReservation", dtoObject.IsReRoutingInSameReservation)
.AddParameter("@IsReRoutingInGroupReservation", dtoObject.IsReRoutingInGroupReservation)
.AddParameter("@IsReRoutingInAllReservation", dtoObject.IsReRoutingInAllReservation)
.AddParameter("@IsCreateSubFolioByTransactionZone", dtoObject.IsCreateSubFolioByTransactionZone)
.AddParameter("@IsAutoCreateFoliosForAccomodation", dtoObject.IsAutoCreateFoliosForAccomodation)
.AddParameter("@IsAutoCreateFoliosForRestaurent", dtoObject.IsAutoCreateFoliosForRestaurent)
.AddParameter("@IsAutoCreateFoliosForPOS", dtoObject.IsAutoCreateFoliosForPOS)
.AddParameter("@IsAutoCreateFoliosForMiscellaneous", dtoObject.IsAutoCreateFoliosForMiscellaneous)
.AddParameter("@IsAutoCreateFoliosForCallLogger", dtoObject.IsAutoCreateFoliosForCallLogger)
.AddParameter("@IsAutoCreateFoliosForLaundry", dtoObject.IsAutoCreateFoliosForLaundry)
.AddParameter("@IsAutoCreateFoliosForMiscServices", dtoObject.IsAutoCreateFoliosForMiscServices)
.AddParameter("@IsTransferBalanceApplicable", dtoObject.IsTransferBalanceApplicable)
.AddParameter("@IsAdvancedChargePostingApplicable", dtoObject.IsAdvancedChargePostingApplicable)
.AddParameter("@IsTransferTransactionApplicable", dtoObject.IsTransferTransactionApplicable)
.AddParameter("@IsBalanceTransferApplicable", dtoObject.IsBalanceTransferApplicable)
.AddParameter("@IsDepositTransferApplicable", dtoObject.IsDepositTransferApplicable)
.AddParameter("@IsVoidTransactionApplicable", dtoObject.IsVoidTransactionApplicable)
.AddParameter("@IsSplitFolioApplicable", dtoObject.IsSplitFolioApplicable)
.AddParameter("@IsAutoCheckInFolioWithReservation", dtoObject.IsAutoCheckInFolioWithReservation)
.AddParameter("@ReservationPolicyNote", dtoObject.ReservationPolicyNote)


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
                StoredProcedure(MasterConstant.FolioConfigDeleteByPrimaryKey)
                    .AddParameter("@FolioConfigID"
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
        public bool Delete(FolioConfig dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.FolioConfigDeleteByPrimaryKey)
                    .AddParameter("@FolioConfigID", dtoObject.FolioConfigID)

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

        public FolioConfig SelectByPrimaryKey(Guid Keys)
        {
            FolioConfig obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.FolioConfigSelectByPrimaryKey)
                            .AddParameter("@FolioConfigID"
,Keys)
                            .Fetch<FolioConfig>();
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
        public List<FolioConfig> SelectByField(string fieldName, object value)
        {
            List<FolioConfig> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.FolioConfigSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<FolioConfig>();

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
                obj = StoredProcedure(MasterConstant.FolioConfigSelectByField) 
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
                StoredProcedure(MasterConstant.FolioConfigDeleteByField) 
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
