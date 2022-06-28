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
    /// Data access layer class for InvestorsUnit
    /// </summary>
    public class InvestorsUnitDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public InvestorsUnitDAL()
            : base()
        {
            // Nothing for now.
        }
        public InvestorsUnitDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<InvestorsUnit> SelectAll(InvestorsUnit dtoObject)
        {
            List<InvestorsUnit> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.InvestorsUnitSelectAll)
                                                .AddParameter("@InvestorRoomID", dtoObject.InvestorRoomID)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@UnitPrice", dtoObject.UnitPrice)
.AddParameter("@RatePerSqtft", dtoObject.RatePerSqtft)
.AddParameter("@AgreementToSellValue", dtoObject.AgreementToSellValue)
.AddParameter("@StmpDutyOnAgrToSell", dtoObject.StmpDutyOnAgrToSell)
.AddParameter("@StmpDutyOnSaleDeed", dtoObject.StmpDutyOnSaleDeed)
.AddParameter("@RegistrationCharges", dtoObject.RegistrationCharges)
.AddParameter("@OtherCosts", dtoObject.OtherCosts)
.AddParameter("@ConstructionValue", dtoObject.ConstructionValue)
.AddParameter("@Vat", dtoObject.Vat)
.AddParameter("@STax", dtoObject.STax)
.AddParameter("@OtherConstructionCost", dtoObject.OtherConstructionCost)
.AddParameter("@DateOfPossession", dtoObject.DateOfPossession)
.AddParameter("@IsInterestApplicable", dtoObject.IsInterestApplicable)
.AddParameter("@RateOfInterest", dtoObject.RateOfInterest)
.AddParameter("@IsApproved", dtoObject.IsApproved)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@AgreementToSellDOCId", dtoObject.AgreementToSellDOCId)
.AddParameter("@ConstructionAgrDOCId", dtoObject.ConstructionAgrDOCId)
.AddParameter("@PropertyManagementAgrDOCId", dtoObject.PropertyManagementAgrDOCId)
.AddParameter("@AbsoluteSalesDeedDOCId", dtoObject.AbsoluteSalesDeedDOCId)
.AddParameter("@RegistrationDOCId", dtoObject.RegistrationDOCId)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdateOn", dtoObject.UpdateOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@DateOfBooking", dtoObject.DateOfBooking)
.AddParameter("@SellerCompany", dtoObject.SellerCompany)
.AddParameter("@RegistrationDate", dtoObject.RegistrationDate)
.AddParameter("@FinalPaymentDate", dtoObject.FinalPaymentDate)
.AddParameter("@SellDate", dtoObject.SellDate)

                                                .WithTransaction(dbtr)
                                                .FetchAll<InvestorsUnit>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.InvestorsUnitSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<InvestorsUnit>();
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

        public List<InvestorsUnit> SelectAll()
        {
            List<InvestorsUnit> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.InvestorsUnitSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<InvestorsUnit>();
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
        public DataSet SelectAllWithDataSet(InvestorsUnit dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.InvestorsUnitSelectAll)
                                                .AddParameter("@InvestorRoomID", dtoObject.InvestorRoomID)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@UnitPrice", dtoObject.UnitPrice)
.AddParameter("@RatePerSqtft", dtoObject.RatePerSqtft)
.AddParameter("@AgreementToSellValue", dtoObject.AgreementToSellValue)
.AddParameter("@StmpDutyOnAgrToSell", dtoObject.StmpDutyOnAgrToSell)
.AddParameter("@StmpDutyOnSaleDeed", dtoObject.StmpDutyOnSaleDeed)
.AddParameter("@RegistrationCharges", dtoObject.RegistrationCharges)
.AddParameter("@OtherCosts", dtoObject.OtherCosts)
.AddParameter("@ConstructionValue", dtoObject.ConstructionValue)
.AddParameter("@Vat", dtoObject.Vat)
.AddParameter("@STax", dtoObject.STax)
.AddParameter("@OtherConstructionCost", dtoObject.OtherConstructionCost)
.AddParameter("@DateOfPossession", dtoObject.DateOfPossession)
.AddParameter("@IsInterestApplicable", dtoObject.IsInterestApplicable)
.AddParameter("@RateOfInterest", dtoObject.RateOfInterest)
.AddParameter("@IsApproved", dtoObject.IsApproved)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@AgreementToSellDOCId", dtoObject.AgreementToSellDOCId)
.AddParameter("@ConstructionAgrDOCId", dtoObject.ConstructionAgrDOCId)
.AddParameter("@PropertyManagementAgrDOCId", dtoObject.PropertyManagementAgrDOCId)
.AddParameter("@AbsoluteSalesDeedDOCId", dtoObject.AbsoluteSalesDeedDOCId)
.AddParameter("@RegistrationDOCId", dtoObject.RegistrationDOCId)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdateOn", dtoObject.UpdateOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@DateOfBooking", dtoObject.DateOfBooking)
.AddParameter("@SellerCompany", dtoObject.SellerCompany)
.AddParameter("@RegistrationDate", dtoObject.RegistrationDate)
.AddParameter("@FinalPaymentDate", dtoObject.FinalPaymentDate)
.AddParameter("@SellDate", dtoObject.SellDate)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.InvestorsUnitSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.InvestorsUnitSelectAll)
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
        public bool Insert(InvestorsUnit dtoObject)
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

                    StoredProcedure(MasterDALConstant.InvestorsUnitInsert)
                        .AddParameter("@InvestorRoomID", dtoObject.InvestorRoomID)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@UnitPrice", dtoObject.UnitPrice)
.AddParameter("@RatePerSqtft", dtoObject.RatePerSqtft)
.AddParameter("@AgreementToSellValue", dtoObject.AgreementToSellValue)
.AddParameter("@StmpDutyOnAgrToSell", dtoObject.StmpDutyOnAgrToSell)
.AddParameter("@StmpDutyOnSaleDeed", dtoObject.StmpDutyOnSaleDeed)
.AddParameter("@RegistrationCharges", dtoObject.RegistrationCharges)
.AddParameter("@OtherCosts", dtoObject.OtherCosts)
.AddParameter("@ConstructionValue", dtoObject.ConstructionValue)
.AddParameter("@Vat", dtoObject.Vat)
.AddParameter("@STax", dtoObject.STax)
.AddParameter("@OtherConstructionCost", dtoObject.OtherConstructionCost)
.AddParameter("@DateOfPossession", dtoObject.DateOfPossession)
.AddParameter("@IsInterestApplicable", dtoObject.IsInterestApplicable)
.AddParameter("@RateOfInterest", dtoObject.RateOfInterest)
.AddParameter("@IsApproved", dtoObject.IsApproved)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@AgreementToSellDOCId", dtoObject.AgreementToSellDOCId)
.AddParameter("@ConstructionAgrDOCId", dtoObject.ConstructionAgrDOCId)
.AddParameter("@PropertyManagementAgrDOCId", dtoObject.PropertyManagementAgrDOCId)
.AddParameter("@AbsoluteSalesDeedDOCId", dtoObject.AbsoluteSalesDeedDOCId)
.AddParameter("@RegistrationDOCId", dtoObject.RegistrationDOCId)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdateOn", dtoObject.UpdateOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@ScheduleType", dtoObject.ScheduleType)
.AddParameter("@DateOfBooking", dtoObject.DateOfBooking)
.AddParameter("@SellerCompany", dtoObject.SellerCompany)
.AddParameter("@RegistrationDate", dtoObject.RegistrationDate)
.AddParameter("@FinalPaymentDate", dtoObject.FinalPaymentDate)
.AddParameter("@SellDate", dtoObject.SellDate)
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
        public bool Update(InvestorsUnit dtoObject)
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

                    StoredProcedure(MasterDALConstant.InvestorsUnitUpdate)
                        .AddParameter("@InvestorRoomID", dtoObject.InvestorRoomID)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@UnitPrice", dtoObject.UnitPrice)
.AddParameter("@RatePerSqtft", dtoObject.RatePerSqtft)
.AddParameter("@AgreementToSellValue", dtoObject.AgreementToSellValue)
.AddParameter("@StmpDutyOnAgrToSell", dtoObject.StmpDutyOnAgrToSell)
.AddParameter("@StmpDutyOnSaleDeed", dtoObject.StmpDutyOnSaleDeed)
.AddParameter("@RegistrationCharges", dtoObject.RegistrationCharges)
.AddParameter("@OtherCosts", dtoObject.OtherCosts)
.AddParameter("@ConstructionValue", dtoObject.ConstructionValue)
.AddParameter("@Vat", dtoObject.Vat)
.AddParameter("@STax", dtoObject.STax)
.AddParameter("@OtherConstructionCost", dtoObject.OtherConstructionCost)
.AddParameter("@DateOfPossession", dtoObject.DateOfPossession)
.AddParameter("@IsInterestApplicable", dtoObject.IsInterestApplicable)
.AddParameter("@RateOfInterest", dtoObject.RateOfInterest)
.AddParameter("@IsApproved", dtoObject.IsApproved)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@AgreementToSellDOCId", dtoObject.AgreementToSellDOCId)
.AddParameter("@ConstructionAgrDOCId", dtoObject.ConstructionAgrDOCId)
.AddParameter("@PropertyManagementAgrDOCId", dtoObject.PropertyManagementAgrDOCId)
.AddParameter("@AbsoluteSalesDeedDOCId", dtoObject.AbsoluteSalesDeedDOCId)
.AddParameter("@RegistrationDOCId", dtoObject.RegistrationDOCId)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdateOn", dtoObject.UpdateOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@ScheduleType", dtoObject.ScheduleType)
.AddParameter("@DateOfBooking", dtoObject.DateOfBooking)
.AddParameter("@SellerCompany", dtoObject.SellerCompany)
.AddParameter("@RegistrationDate", dtoObject.RegistrationDate)
.AddParameter("@FinalPaymentDate", dtoObject.FinalPaymentDate)
.AddParameter("@SellDate", dtoObject.SellDate)
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
                StoredProcedure(MasterDALConstant.InvestorsUnitDeleteByPrimaryKey)
                    .AddParameter("@InvestorRoomID"
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
        public bool Delete(InvestorsUnit dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.InvestorsUnitDeleteByPrimaryKey)
                    .AddParameter("@InvestorRoomID", dtoObject.InvestorRoomID)

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

        public InvestorsUnit SelectByPrimaryKey(Guid Keys)
        {
            InvestorsUnit obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.InvestorsUnitSelectByPrimaryKey)
                            .AddParameter("@InvestorRoomID"
, Keys)
                            .Fetch<InvestorsUnit>();
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
        public List<InvestorsUnit> SelectByField(string fieldName, object value)
        {
            List<InvestorsUnit> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.InvestorsUnitSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<InvestorsUnit>();

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
                obj = StoredProcedure(MasterDALConstant.InvestorsUnitSelectByField)
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
                StoredProcedure(MasterDALConstant.InvestorsUnitDeleteByField)
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

        public DataSet SelectInvestorData(string InvestorQuery)
        {
            DataSet dst = new DataSet();
            try
            {
                dst = Query(InvestorQuery)
                            .WithTransaction(dbtr)
                            .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return dst;
        }

        public DataSet SearchInvestorsUnitData(Guid? InvestorRoomID, string RoomNo, Guid? InvesterID, Guid? PropertyID, Guid? RoomTypeID, string RoomTypeName)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.InvestorsUnitSearchData)
                                            .AddParameter("@InvestorRoomID", InvestorRoomID)
                                            .AddParameter("@RoomNo", RoomNo)
                                            .AddParameter("@InvesterID", InvesterID)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@RoomTypeID", RoomTypeID)
                                            .AddParameter("@RoomTypeName", RoomTypeName)
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

        public DataSet CheckDuplicateInInvestorUnit(Guid? InvestorID, Guid? RoomID, Guid? RoomTypeID, Guid? PropertyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.InvestorsUnitCheckDuplicate)
                                            .AddParameter("@InvestorID", InvestorID)
                                            .AddParameter("@RoomID", RoomID)
                                            .AddParameter("@RoomTypeID", RoomTypeID)
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
        /// <summary>
        /// Get Investor Unit Informatation
        /// </summary>
        /// <param name="InvestorID"></param>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public DataSet GetInvestorUnitInfo(Guid? InvestorID, Guid? CompanyID)
        {
            DataSet _Obj = new DataSet();
            try
            {
                using (new Tracer((SQTLogType.DataAccessLayerLog)))
                {
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                    _Obj = StoredProcedure(MasterDALConstant.InvestorUnitInformation)
                        .AddParameter("@InvestorID", InvestorID)
                        .AddParameter("@CompanyID", CompanyID)
                        .WithTransaction(dbtr)
                        .FetchDataSet();
                }
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return _Obj;
        }

        public DataSet SelectInvestorUnitDetails(Guid? InvestorRoomID, Guid? InvestorID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.InvestorsUnitSelectUnitDetails)
                                            .AddParameter("@InvestorRoomID", InvestorRoomID)
                                            .AddParameter("@InvestorID", InvestorID)
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

        public bool CreateStandardSchedule(Guid investorRoomID, Guid createdBy)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //if (dtoObject == null)
                    //    throw (new ParameterNullException("Object can not be null"));

                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    //parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.InvestorsUnitCreateStandardSchedule)
                        .AddParameter("@InvestorRoomID", investorRoomID)
                        .AddParameter("@CreatedBy", createdBy)
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

        public DataSet SelectPropertyName(Guid? InvestorID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.InvestorsUnitSelectPropertyName)
                                            .AddParameter("@InvestorID", InvestorID)
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
        #endregion

        public DataSet PaymentDueReport(Guid? InvestorID, Guid? PropertyID, Guid? RelationshipManagerID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.ReprotPaymentDue)
                                            .AddParameter("@InvestorID", InvestorID)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@RelationShipManagerID", RelationshipManagerID)
                                            .AddParameter("@StartDate", StartDate)
                                            .AddParameter("@EndDate", EndDate)
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

        public DataSet ReportInvestorTerm(Guid? InvestorID, Guid? UnitTypeID, Guid? UnitID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.ReportInvestorTerm)
                                            .AddParameter("@InvestorID", InvestorID)
                                            .AddParameter("@UnitType", UnitTypeID)
                                            .AddParameter("@RoomID", UnitID)
                                            .AddParameter("@StartDate", StartDate)
                                            .AddParameter("@EndDate", EndDate)
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

        public DataSet ReportInvestorDocumentation(Guid? InvestorID, Guid? UnitTypeID, Guid? UnitID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.ReportInvestorDocumentation)
                                            .AddParameter("@InvestorID", InvestorID)
                                            .AddParameter("@UnitType", UnitTypeID)
                                            .AddParameter("@RoomID", UnitID)
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

        public DataSet ReportLocationAnalysis(Guid? PropertyID, Guid? CountryID, Guid? RegionID, Guid? CityID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.ReportLocationAnalysis)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@Country", CountryID)
                                            .AddParameter("@Region", RegionID)
                                            .AddParameter("@City", CityID)
                                            .AddParameter("@StartDate", StartDate)
                                            .AddParameter("@EndDate", EndDate)
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

        public DataSet ReportLocationAnalysis(Guid? PropertyID, string LocationType, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.ReportLocationAnalysis)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@LocationType", LocationType)
                                            .AddParameter("@StartDate", StartDate)
                                            .AddParameter("@EndDate", EndDate)
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

        public DataSet SelectInvestorsUnitForResell(Guid investorID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.InvestorsUnitSelectInvestorsUnitForResell)
                        .AddParameter("@InvestorID", investorID)
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

        public bool Insert4Resell(string SellToMode, Guid InvestorRoomID, Guid? BuyerInvestorID, DateTime UpdateOn, Guid UpdatedBy, DateTime SellDate)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //if (dtoObject == null)
                    //    throw (new ParameterNullException("Object can not be null"));

                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    //parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.InvestorsUnitInsertReSell)
                        .AddParameter("@SellToMode", SellToMode)
                        .AddParameter("@InvestorRoomID", InvestorRoomID)
                        .AddParameter("@BuyerInvestorID", BuyerInvestorID)
                        .AddParameter("@UpdateOn", UpdateOn)
                        .AddParameter("@UpdatedBy", UpdatedBy)
                        .AddParameter("@SellDate", SellDate)
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
    }
}
