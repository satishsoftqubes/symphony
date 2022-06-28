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
    /// Data access layer class for RateCard
    /// </summary>
    public class RateCardDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public RateCardDAL()
            : base()
        {
            // Nothing for now.
        }
        public RateCardDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<RateCard> SelectAll(RateCard dtoObject)
        {
            List<RateCard> obj = null;
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
                        obj = StoredProcedure(MasterConstant.RateCardSelectAll)
                                                .AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@StayTypeID", dtoObject.StayTypeID)
.AddParameter("@RateType_TermID", dtoObject.RateType_TermID)
.AddParameter("@Code", dtoObject.Code)
.AddParameter("@RateCardName", dtoObject.RateCardName)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@StartDate", dtoObject.StartDate)
.AddParameter("@EndDate", dtoObject.EndDate)
.AddParameter("@PostingFreq_TermID", dtoObject.PostingFreq_TermID)
.AddParameter("@NonRevenueChildren", dtoObject.NonRevenueChildren)
.AddParameter("@PkgNoOfNight", dtoObject.PkgNoOfNight)
.AddParameter("@PkgNoOfAdult", dtoObject.PkgNoOfAdult)
.AddParameter("@DepositID", dtoObject.DepositID)
.AddParameter("@IsCheckInSunday", dtoObject.IsCheckInSunday)
.AddParameter("@IsCheckInMonday", dtoObject.IsCheckInMonday)
.AddParameter("@IsCheckInTuesday", dtoObject.IsCheckInTuesday)
.AddParameter("@IsCheckInWednesday", dtoObject.IsCheckInWednesday)
.AddParameter("@IsCheckInThursday", dtoObject.IsCheckInThursday)
.AddParameter("@IsCheckInFriday", dtoObject.IsCheckInFriday)
.AddParameter("@IsCheckInSaturday", dtoObject.IsCheckInSaturday)
.AddParameter("@RateCardDetails", dtoObject.RateCardDetails)
.AddParameter("@TermsAndCondition", dtoObject.TermsAndCondition)
.AddParameter("@IsEnable", dtoObject.IsEnable)
.AddParameter("@IsYieldEnable", dtoObject.IsYieldEnable)
.AddParameter("@IsEventChargeEnable", dtoObject.IsEventChargeEnable)
.AddParameter("@IsRateInclService", dtoObject.IsRateInclService)
.AddParameter("@IsDefault", dtoObject.IsDefault)
.AddParameter("@IsStandard", dtoObject.IsStandard)
.AddParameter("@MinimumDaysRequired", dtoObject.MinimumDaysRequired)
.AddParameter("@CancellationPolicyID", dtoObject.CancellationPolicyID)
.AddParameter("@IsPerRoom", dtoObject.IsPerRoom)
.AddParameter("@RateCardDispName", dtoObject.RateCardDispName)

                                                .WithTransaction(dbtr)
                                                .FetchAll<RateCard>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.RateCardSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<RateCard>();
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

        public List<RateCard> SelectAll()
        {
            List<RateCard> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.RateCardSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<RateCard>();
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
        public DataSet SelectAllWithDataSet(RateCard dtoObject)
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
                        obj = StoredProcedure(MasterConstant.RateCardSelectAll)
                                                .AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@StayTypeID", dtoObject.StayTypeID)
.AddParameter("@RateType_TermID", dtoObject.RateType_TermID)
.AddParameter("@Code", dtoObject.Code)
.AddParameter("@RateCardName", dtoObject.RateCardName)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@StartDate", dtoObject.StartDate)
.AddParameter("@EndDate", dtoObject.EndDate)
.AddParameter("@PostingFreq_TermID", dtoObject.PostingFreq_TermID)
.AddParameter("@NonRevenueChildren", dtoObject.NonRevenueChildren)
.AddParameter("@PkgNoOfNight", dtoObject.PkgNoOfNight)
.AddParameter("@PkgNoOfAdult", dtoObject.PkgNoOfAdult)
.AddParameter("@DepositID", dtoObject.DepositID)
.AddParameter("@IsCheckInSunday", dtoObject.IsCheckInSunday)
.AddParameter("@IsCheckInMonday", dtoObject.IsCheckInMonday)
.AddParameter("@IsCheckInTuesday", dtoObject.IsCheckInTuesday)
.AddParameter("@IsCheckInWednesday", dtoObject.IsCheckInWednesday)
.AddParameter("@IsCheckInThursday", dtoObject.IsCheckInThursday)
.AddParameter("@IsCheckInFriday", dtoObject.IsCheckInFriday)
.AddParameter("@IsCheckInSaturday", dtoObject.IsCheckInSaturday)
.AddParameter("@RateCardDetails", dtoObject.RateCardDetails)
.AddParameter("@TermsAndCondition", dtoObject.TermsAndCondition)
.AddParameter("@IsEnable", dtoObject.IsEnable)
.AddParameter("@IsYieldEnable", dtoObject.IsYieldEnable)
.AddParameter("@IsEventChargeEnable", dtoObject.IsEventChargeEnable)
.AddParameter("@IsRateInclService", dtoObject.IsRateInclService)
.AddParameter("@IsDefault", dtoObject.IsDefault)
.AddParameter("@IsStandard", dtoObject.IsStandard)
.AddParameter("@MinimumDaysRequired", dtoObject.MinimumDaysRequired)
.AddParameter("@CancellationPolicyID", dtoObject.CancellationPolicyID)
.AddParameter("@IsPerRoom", dtoObject.IsPerRoom)
.AddParameter("@RateCardDispName", dtoObject.RateCardDispName)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.RateCardSelectAll)
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

                    obj = StoredProcedure(MasterConstant.RateCardSelectAll)
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
        public bool Insert(RateCard dtoObject)
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

                    StoredProcedure(MasterConstant.RateCardInsert)
                        .AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@StayTypeID", dtoObject.StayTypeID)
.AddParameter("@RateType_TermID", dtoObject.RateType_TermID)
.AddParameter("@Code", dtoObject.Code)
.AddParameter("@RateCardName", dtoObject.RateCardName)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@StartDate", dtoObject.StartDate)
.AddParameter("@EndDate", dtoObject.EndDate)
.AddParameter("@PostingFreq_TermID", dtoObject.PostingFreq_TermID)
.AddParameter("@NonRevenueChildren", dtoObject.NonRevenueChildren)
.AddParameter("@PkgNoOfNight", dtoObject.PkgNoOfNight)
.AddParameter("@PkgNoOfAdult", dtoObject.PkgNoOfAdult)
.AddParameter("@DepositID", dtoObject.DepositID)
.AddParameter("@IsCheckInSunday", dtoObject.IsCheckInSunday)
.AddParameter("@IsCheckInMonday", dtoObject.IsCheckInMonday)
.AddParameter("@IsCheckInTuesday", dtoObject.IsCheckInTuesday)
.AddParameter("@IsCheckInWednesday", dtoObject.IsCheckInWednesday)
.AddParameter("@IsCheckInThursday", dtoObject.IsCheckInThursday)
.AddParameter("@IsCheckInFriday", dtoObject.IsCheckInFriday)
.AddParameter("@IsCheckInSaturday", dtoObject.IsCheckInSaturday)
.AddParameter("@RateCardDetails", dtoObject.RateCardDetails)
.AddParameter("@TermsAndCondition", dtoObject.TermsAndCondition)
.AddParameter("@IsEnable", dtoObject.IsEnable)
.AddParameter("@IsYieldEnable", dtoObject.IsYieldEnable)
.AddParameter("@IsEventChargeEnable", dtoObject.IsEventChargeEnable)
.AddParameter("@IsRateInclService", dtoObject.IsRateInclService)
.AddParameter("@IsDefault", dtoObject.IsDefault)
.AddParameter("@RateTypeName", dtoObject.RateTypeName)
.AddParameter("@IsStandard", dtoObject.IsStandard)
.AddParameter("@MinimumDaysRequired", dtoObject.MinimumDaysRequired)
.AddParameter("@CancellationPolicyID", dtoObject.CancellationPolicyID)
.AddParameter("@IsPerRoom", dtoObject.IsPerRoom)
.AddParameter("@RateCardDispName", dtoObject.RateCardDispName)
.AddParameter("@RetentionChargePercent", dtoObject.RetentionChargePercent)
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
        public bool Update(RateCard dtoObject)
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

                    StoredProcedure(MasterConstant.RateCardUpdate)
                        .AddParameter("@RateID", dtoObject.RateID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@StayTypeID", dtoObject.StayTypeID)
.AddParameter("@RateType_TermID", dtoObject.RateType_TermID)
.AddParameter("@Code", dtoObject.Code)
.AddParameter("@RateCardName", dtoObject.RateCardName)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@StartDate", dtoObject.StartDate)
.AddParameter("@EndDate", dtoObject.EndDate)
.AddParameter("@PostingFreq_TermID", dtoObject.PostingFreq_TermID)
.AddParameter("@NonRevenueChildren", dtoObject.NonRevenueChildren)
.AddParameter("@PkgNoOfNight", dtoObject.PkgNoOfNight)
.AddParameter("@PkgNoOfAdult", dtoObject.PkgNoOfAdult)
.AddParameter("@DepositID", dtoObject.DepositID)
.AddParameter("@IsCheckInSunday", dtoObject.IsCheckInSunday)
.AddParameter("@IsCheckInMonday", dtoObject.IsCheckInMonday)
.AddParameter("@IsCheckInTuesday", dtoObject.IsCheckInTuesday)
.AddParameter("@IsCheckInWednesday", dtoObject.IsCheckInWednesday)
.AddParameter("@IsCheckInThursday", dtoObject.IsCheckInThursday)
.AddParameter("@IsCheckInFriday", dtoObject.IsCheckInFriday)
.AddParameter("@IsCheckInSaturday", dtoObject.IsCheckInSaturday)
.AddParameter("@RateCardDetails", dtoObject.RateCardDetails)
.AddParameter("@TermsAndCondition", dtoObject.TermsAndCondition)
.AddParameter("@IsEnable", dtoObject.IsEnable)
.AddParameter("@IsYieldEnable", dtoObject.IsYieldEnable)
.AddParameter("@IsEventChargeEnable", dtoObject.IsEventChargeEnable)
.AddParameter("@IsRateInclService", dtoObject.IsRateInclService)
.AddParameter("@IsDefault", dtoObject.IsDefault)
.AddParameter("@IsStandard", dtoObject.IsStandard)
.AddParameter("@MinimumDaysRequired", dtoObject.MinimumDaysRequired)
.AddParameter("@CancellationPolicyID", dtoObject.CancellationPolicyID)
.AddParameter("@IsPerRoom", dtoObject.IsPerRoom)
.AddParameter("@RateCardDispName", dtoObject.RateCardDispName)
.AddParameter("@RetentionChargePercent", dtoObject.RetentionChargePercent)
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
                StoredProcedure(MasterConstant.RateCardDeleteByPrimaryKey)
                    .AddParameter("@RateID"
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
        public bool Delete(RateCard dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.RateCardDeleteByPrimaryKey)
                    .AddParameter("@RateID", dtoObject.RateID)

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

        public RateCard SelectByPrimaryKey(Guid Keys)
        {
            RateCard obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RateCardSelectByPrimaryKey)
                            .AddParameter("@RateID"
, Keys)
                            .Fetch<RateCard>();
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
        public List<RateCard> SelectByField(string fieldName, object value)
        {
            List<RateCard> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RateCardSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<RateCard>();

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
                obj = StoredProcedure(MasterConstant.RateCardSelectByField)
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

        public DataSet SelectAllByProperty(Guid? PropertyID, Guid? CompanyID, Guid? StayTypeID, Guid? RateType_TermID, string Code, string RateCardName, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RateCardSelectAllByProperty)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@StayTypeID", StayTypeID)
                                    .AddParameter("@RateType_TermID", RateType_TermID)
                                    .AddParameter("@Code", Code)
                                    .AddParameter("@RateCardName", RateCardName)
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

        public DataSet SelectDataByPrimaryKey(Guid rateCardID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RateCardSelectDataByPrimaryKey)
                            .AddParameter("@RateID", rateCardID)
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

        public DataSet SelectAllByRateCardType(Guid propertyID, Guid companyID, string rateCardType)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RateCardSelectAllByRateCardType)
                            .AddParameter("@PropertyID", propertyID)
                            .AddParameter("@CompanyID", companyID)
                            .AddParameter("@RateCardType", rateCardType)
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

        public DataSet SelectAllForCorporate(Guid propertyID, Guid companyID, Guid corporateID, string rateCardType)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RateCardSelectAllForCorporate)
                            .AddParameter("@PropertyID", propertyID)
                            .AddParameter("@CompanyID", companyID)
                            .AddParameter("@CorporateID", corporateID)
                            .AddParameter("@RateCardType", rateCardType)
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
                StoredProcedure(MasterConstant.RateCardDeleteByField)
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

        public DataSet SelectAllAvailableRateCards(DateTime? startDate, DateTime? endDate, Guid? roomTypeID, Guid? companyAgentID, Guid? travelAgentID, Guid? conferenceID, Guid propertyID, Guid companyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RateCardGetAllAvailableRateCards)
                            .AddParameter("@PropertyID", propertyID)
                            .AddParameter("@CompanyID", companyID)
                            .AddParameter("@StartDate", startDate)
                            .AddParameter("@EndDate", endDate)
                            .AddParameter("@RoomTypeID", roomTypeID)
                            .AddParameter("@Company_AgentID", companyAgentID)
                            .AddParameter("@Travel_AgentID", travelAgentID)
                            .AddParameter("@ConferenceID", conferenceID)
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
        public DataSet SelectOverStayRateCard(DateTime? startDate, DateTime? endDate,Guid propertyID, Guid companyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RateCardForOverStay)
                            .AddParameter("@StartDate", startDate)
                            .AddParameter("@EndDate", endDate)
                            .AddParameter("@CompanyID", companyID)
                            .AddParameter("@PropertyID", propertyID)
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
        public DataSet SelectDashboardRatecardData(Guid propertyID, Guid companyID, Guid? RateID,bool IsPerRoom)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RateCardSelectDashboardRatecardData)
                            .AddParameter("@PropertyID", propertyID)
                            .AddParameter("@CompanyID", companyID)
                            .AddParameter("@RateID", RateID)
                            .AddParameter("@IsPerRoom", IsPerRoom)
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

        public DataSet SelectDashboardServicesData(Guid? RateID, Guid? RoomTypeID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RateCardSelectDashboardServicesData)
                            .AddParameter("@RateID", RateID)
                            .AddParameter("@RoomTypeID", RoomTypeID)
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

        public DataSet SelectForRoomRateCardResStatus(Guid propertyID, Guid companyID, Guid? RateID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RateCardSelectForRoomRateCardResStatus)
                            .AddParameter("@PropertyID", propertyID)
                            .AddParameter("@CompanyID", companyID)
                            .AddParameter("@RateCardID", RateID)
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

        public DataSet SelectRateCardsReqMinDaysByRateCardIDs(string RateCardIDs)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RateCardSelectRateCardsReqMinDaysByRateCardIDs)
                            .AddParameter("@strRateCardIDs", RateCardIDs)
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
