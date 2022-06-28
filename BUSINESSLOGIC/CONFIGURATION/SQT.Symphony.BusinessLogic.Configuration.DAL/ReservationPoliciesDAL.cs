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
	/// Data access layer class for ReservationPolicies
	/// </summary>
	public class ReservationPoliciesDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public ReservationPoliciesDAL() :  base()
		{
			// Nothing for now.
		}
        public ReservationPoliciesDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<ReservationPolicies> SelectAll(ReservationPolicies dtoObject)
        {
            List<ReservationPolicies> obj = null;
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
                        obj = StoredProcedure(MasterConstant.ReservationPoliciesSelectAll)
                                                .AddParameter("@ResPolicyID", dtoObject.ResPolicyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@BfrCheckInHrs", dtoObject.BfrCheckInHrs)
.AddParameter("@BfrCharges", dtoObject.BfrCharges)
.AddParameter("@IsBfrChargesInPercentage", dtoObject.IsBfrChargesInPercentage)
.AddParameter("@BfrChargePer_TermID", dtoObject.BfrChargePer_TermID)
.AddParameter("@AftCheckInHrs", dtoObject.AftCheckInHrs)
.AddParameter("@AftCharges", dtoObject.AftCharges)
.AddParameter("@IsAftChargesInPercentage", dtoObject.IsAftChargesInPercentage)
.AddParameter("@AftChargePer_TermID", dtoObject.AftChargePer_TermID)
.AddParameter("@IsReasonRequired", dtoObject.IsReasonRequired)
.AddParameter("@DefaultReservationType_TermID", dtoObject.DefaultReservationType_TermID)
.AddParameter("@IsFirstNightChargeCompForCashPayers", dtoObject.IsFirstNightChargeCompForCashPayers)
.AddParameter("@IsAssignRoomToUnConfirmRes", dtoObject.IsAssignRoomToUnConfirmRes)
.AddParameter("@IsAssignRoomOnReservation", dtoObject.IsAssignRoomOnReservation)
.AddParameter("@IsUserCanOverrideRackRate", dtoObject.IsUserCanOverrideRackRate)
.AddParameter("@IsUserCanApplyDiscount", dtoObject.IsUserCanApplyDiscount)
.AddParameter("@IsUserCanSetTaxExempt", dtoObject.IsUserCanSetTaxExempt)

                                                .WithTransaction(dbtr)
                                                .FetchAll<ReservationPolicies>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.ReservationPoliciesSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<ReservationPolicies>();
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

        public List<ReservationPolicies> SelectAll()
        {
            List<ReservationPolicies> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.ReservationPoliciesSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<ReservationPolicies>();
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
        public DataSet SelectAllWithDataSet(ReservationPolicies dtoObject)
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
                        obj = StoredProcedure(MasterConstant.ReservationPoliciesSelectAll)
                                                .AddParameter("@ResPolicyID", dtoObject.ResPolicyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@BfrCheckInHrs", dtoObject.BfrCheckInHrs)
.AddParameter("@BfrCharges", dtoObject.BfrCharges)
.AddParameter("@IsBfrChargesInPercentage", dtoObject.IsBfrChargesInPercentage)
.AddParameter("@BfrChargePer_TermID", dtoObject.BfrChargePer_TermID)
.AddParameter("@AftCheckInHrs", dtoObject.AftCheckInHrs)
.AddParameter("@AftCharges", dtoObject.AftCharges)
.AddParameter("@IsAftChargesInPercentage", dtoObject.IsAftChargesInPercentage)
.AddParameter("@AftChargePer_TermID", dtoObject.AftChargePer_TermID)
.AddParameter("@IsReasonRequired", dtoObject.IsReasonRequired)
.AddParameter("@DefaultReservationType_TermID", dtoObject.DefaultReservationType_TermID)
.AddParameter("@IsFirstNightChargeCompForCashPayers", dtoObject.IsFirstNightChargeCompForCashPayers)
.AddParameter("@IsAssignRoomToUnConfirmRes", dtoObject.IsAssignRoomToUnConfirmRes)
.AddParameter("@IsAssignRoomOnReservation", dtoObject.IsAssignRoomOnReservation)
.AddParameter("@IsUserCanOverrideRackRate", dtoObject.IsUserCanOverrideRackRate)
.AddParameter("@IsUserCanApplyDiscount", dtoObject.IsUserCanApplyDiscount)
.AddParameter("@IsUserCanSetTaxExempt", dtoObject.IsUserCanSetTaxExempt)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.ReservationPoliciesSelectAll)
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

                    obj = StoredProcedure(MasterConstant.ReservationPoliciesSelectAll)
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
		public bool Insert(ReservationPolicies dtoObject)
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

                    StoredProcedure(MasterConstant.ReservationPoliciesInsert)
                        .AddParameter("@ResPolicyID", dtoObject.ResPolicyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@BfrCheckInHrs", dtoObject.BfrCheckInHrs)
.AddParameter("@BfrCharges", dtoObject.BfrCharges)
.AddParameter("@IsBfrChargesInPercentage", dtoObject.IsBfrChargesInPercentage)
.AddParameter("@BfrChargePer_TermID", dtoObject.BfrChargePer_TermID)
.AddParameter("@AftCheckInHrs", dtoObject.AftCheckInHrs)
.AddParameter("@AftCharges", dtoObject.AftCharges)
.AddParameter("@IsAftChargesInPercentage", dtoObject.IsAftChargesInPercentage)
.AddParameter("@AftChargePer_TermID", dtoObject.AftChargePer_TermID)
.AddParameter("@IsReasonRequired", dtoObject.IsReasonRequired)
.AddParameter("@DefaultReservationType_TermID", dtoObject.DefaultReservationType_TermID)
.AddParameter("@IsFirstNightChargeCompForCashPayers", dtoObject.IsFirstNightChargeCompForCashPayers)
.AddParameter("@IsAssignRoomToUnConfirmRes", dtoObject.IsAssignRoomToUnConfirmRes)
.AddParameter("@IsAssignRoomOnReservation", dtoObject.IsAssignRoomOnReservation)
.AddParameter("@IsUserCanOverrideRackRate", dtoObject.IsUserCanOverrideRackRate)
.AddParameter("@IsUserCanApplyDiscount", dtoObject.IsUserCanApplyDiscount)
.AddParameter("@IsUserCanSetTaxExempt", dtoObject.IsUserCanSetTaxExempt)

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
        public bool Update(ReservationPolicies dtoObject)
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

                    StoredProcedure(MasterConstant.ReservationPoliciesUpdate)
                        .AddParameter("@ResPolicyID", dtoObject.ResPolicyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@BfrCheckInHrs", dtoObject.BfrCheckInHrs)
.AddParameter("@BfrCharges", dtoObject.BfrCharges)
.AddParameter("@IsBfrChargesInPercentage", dtoObject.IsBfrChargesInPercentage)
.AddParameter("@BfrChargePer_TermID", dtoObject.BfrChargePer_TermID)
.AddParameter("@AftCheckInHrs", dtoObject.AftCheckInHrs)
.AddParameter("@AftCharges", dtoObject.AftCharges)
.AddParameter("@IsAftChargesInPercentage", dtoObject.IsAftChargesInPercentage)
.AddParameter("@AftChargePer_TermID", dtoObject.AftChargePer_TermID)
.AddParameter("@IsReasonRequired", dtoObject.IsReasonRequired)
.AddParameter("@DefaultReservationType_TermID", dtoObject.DefaultReservationType_TermID)
.AddParameter("@IsFirstNightChargeCompForCashPayers", dtoObject.IsFirstNightChargeCompForCashPayers)
.AddParameter("@IsAssignRoomToUnConfirmRes", dtoObject.IsAssignRoomToUnConfirmRes)
.AddParameter("@IsAssignRoomOnReservation", dtoObject.IsAssignRoomOnReservation)
.AddParameter("@IsUserCanOverrideRackRate", dtoObject.IsUserCanOverrideRackRate)
.AddParameter("@IsUserCanApplyDiscount", dtoObject.IsUserCanApplyDiscount)
.AddParameter("@IsUserCanSetTaxExempt", dtoObject.IsUserCanSetTaxExempt)

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
                StoredProcedure(MasterConstant.ReservationPoliciesDeleteByPrimaryKey)
                    .AddParameter("@ResPolicyID"
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
        public bool Delete(ReservationPolicies dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.ReservationPoliciesDeleteByPrimaryKey)
                    .AddParameter("@ResPolicyID", dtoObject.ResPolicyID)

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

        public ReservationPolicies SelectByPrimaryKey(Guid Keys)
        {
            ReservationPolicies obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ReservationPoliciesSelectByPrimaryKey)
                            .AddParameter("@ResPolicyID"
,Keys)
                            .Fetch<ReservationPolicies>();
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
        public List<ReservationPolicies> SelectByField(string fieldName, object value)
        {
            List<ReservationPolicies> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ReservationPoliciesSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<ReservationPolicies>();

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
                obj = StoredProcedure(MasterConstant.ReservationPoliciesSelectByField) 
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
                StoredProcedure(MasterConstant.ReservationPoliciesDeleteByField) 
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
