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
    /// Data access layer class for ForeignNationalInfo
    /// </summary>
    public class ForeignNationalInfoDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public ForeignNationalInfoDAL()
            : base()
        {
            // Nothing for now.
        }
        public ForeignNationalInfoDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<ForeignNationalInfo> SelectAll(ForeignNationalInfo dtoObject)
        {
            List<ForeignNationalInfo> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.ForeignNationalInfoSelectAll)
                                                .AddParameter("@ForeignNationalityID", dtoObject.ForeignNationalityID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@Nationality", dtoObject.Nationality)
.AddParameter("@IDType", dtoObject.IDType)
.AddParameter("@PassportNumber", dtoObject.PassportNumber)
.AddParameter("@PassportDateOfIssue", dtoObject.PassportDateOfIssue)
.AddParameter("@PassportDateOfExpiry", dtoObject.PassportDateOfExpiry)
.AddParameter("@PassportPlaceOfIssue", dtoObject.PassportPlaceOfIssue)
.AddParameter("@ScannedPassport1", dtoObject.ScannedPassport1)
.AddParameter("@ScannedPassport2", dtoObject.ScannedPassport2)
.AddParameter("@VisaNumber", dtoObject.VisaNumber)
.AddParameter("@VisaDateOfIssue", dtoObject.VisaDateOfIssue)
.AddParameter("@VisaDateOfExpiry", dtoObject.VisaDateOfExpiry)
.AddParameter("@VisaPlaceOfIssue", dtoObject.VisaPlaceOfIssue)
.AddParameter("@ScannedVisa", dtoObject.ScannedVisa)
.AddParameter("@VisaType", dtoObject.VisaType)
.AddParameter("@DurationOfStay", dtoObject.DurationOfStay)
.AddParameter("@PurposeOfVisa", dtoObject.PurposeOfVisa)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)

                                                .WithTransaction(dbtr)
                                                .FetchAll<ForeignNationalInfo>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ForeignNationalInfoSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<ForeignNationalInfo>();
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

        public List<ForeignNationalInfo> SelectAll()
        {
            List<ForeignNationalInfo> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.ForeignNationalInfoSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<ForeignNationalInfo>();
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
        public DataSet SelectAllWithDataSet(ForeignNationalInfo dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.ForeignNationalInfoSelectAll)
                                                .AddParameter("@ForeignNationalityID", dtoObject.ForeignNationalityID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@Nationality", dtoObject.Nationality)
.AddParameter("@IDType", dtoObject.IDType)
.AddParameter("@PassportNumber", dtoObject.PassportNumber)
.AddParameter("@PassportDateOfIssue", dtoObject.PassportDateOfIssue)
.AddParameter("@PassportDateOfExpiry", dtoObject.PassportDateOfExpiry)
.AddParameter("@PassportPlaceOfIssue", dtoObject.PassportPlaceOfIssue)
.AddParameter("@ScannedPassport1", dtoObject.ScannedPassport1)
.AddParameter("@ScannedPassport2", dtoObject.ScannedPassport2)
.AddParameter("@VisaNumber", dtoObject.VisaNumber)
.AddParameter("@VisaDateOfIssue", dtoObject.VisaDateOfIssue)
.AddParameter("@VisaDateOfExpiry", dtoObject.VisaDateOfExpiry)
.AddParameter("@VisaPlaceOfIssue", dtoObject.VisaPlaceOfIssue)
.AddParameter("@ScannedVisa", dtoObject.ScannedVisa)
.AddParameter("@VisaType", dtoObject.VisaType)
.AddParameter("@DurationOfStay", dtoObject.DurationOfStay)
.AddParameter("@PurposeOfVisa", dtoObject.PurposeOfVisa)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ForeignNationalInfoSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.ForeignNationalInfoSelectAll)
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
        public bool Insert(ForeignNationalInfo dtoObject)
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

                    StoredProcedure(MasterDALConstant.ForeignNationalInfoInsert)
                        .AddParameter("@ForeignNationalityID", dtoObject.ForeignNationalityID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@Nationality", dtoObject.Nationality)
.AddParameter("@IDType", dtoObject.IDType)
.AddParameter("@PassportNumber", dtoObject.PassportNumber)
.AddParameter("@PassportDateOfIssue", dtoObject.PassportDateOfIssue)
.AddParameter("@PassportDateOfExpiry", dtoObject.PassportDateOfExpiry)
.AddParameter("@PassportPlaceOfIssue", dtoObject.PassportPlaceOfIssue)
.AddParameter("@ScannedPassport1", dtoObject.ScannedPassport1)
.AddParameter("@ScannedPassport2", dtoObject.ScannedPassport2)
.AddParameter("@VisaNumber", dtoObject.VisaNumber)
.AddParameter("@VisaDateOfIssue", dtoObject.VisaDateOfIssue)
.AddParameter("@VisaDateOfExpiry", dtoObject.VisaDateOfExpiry)
.AddParameter("@VisaPlaceOfIssue", dtoObject.VisaPlaceOfIssue)
.AddParameter("@ScannedVisa", dtoObject.ScannedVisa)
.AddParameter("@VisaType", dtoObject.VisaType)
.AddParameter("@DurationOfStay", dtoObject.DurationOfStay)
.AddParameter("@PurposeOfVisa", dtoObject.PurposeOfVisa)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)

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
        public bool Update(ForeignNationalInfo dtoObject)
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

                    StoredProcedure(MasterDALConstant.ForeignNationalInfoUpdate)
                        .AddParameter("@ForeignNationalityID", dtoObject.ForeignNationalityID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@Nationality", dtoObject.Nationality)
.AddParameter("@IDType", dtoObject.IDType)
.AddParameter("@PassportNumber", dtoObject.PassportNumber)
.AddParameter("@PassportDateOfIssue", dtoObject.PassportDateOfIssue)
.AddParameter("@PassportDateOfExpiry", dtoObject.PassportDateOfExpiry)
.AddParameter("@PassportPlaceOfIssue", dtoObject.PassportPlaceOfIssue)
.AddParameter("@ScannedPassport1", dtoObject.ScannedPassport1)
.AddParameter("@ScannedPassport2", dtoObject.ScannedPassport2)
.AddParameter("@VisaNumber", dtoObject.VisaNumber)
.AddParameter("@VisaDateOfIssue", dtoObject.VisaDateOfIssue)
.AddParameter("@VisaDateOfExpiry", dtoObject.VisaDateOfExpiry)
.AddParameter("@VisaPlaceOfIssue", dtoObject.VisaPlaceOfIssue)
.AddParameter("@ScannedVisa", dtoObject.ScannedVisa)
.AddParameter("@VisaType", dtoObject.VisaType)
.AddParameter("@DurationOfStay", dtoObject.DurationOfStay)
.AddParameter("@PurposeOfVisa", dtoObject.PurposeOfVisa)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)

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
                StoredProcedure(MasterDALConstant.ForeignNationalInfoDeleteByPrimaryKey)
                    .AddParameter("@ForeignNationalityID"
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
        public bool Delete(ForeignNationalInfo dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.ForeignNationalInfoDeleteByPrimaryKey)
                    .AddParameter("@ForeignNationalityID", dtoObject.ForeignNationalityID)

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

        public ForeignNationalInfo SelectByPrimaryKey(Guid Keys)
        {
            ForeignNationalInfo obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ForeignNationalInfoSelectByPrimaryKey)
                            .AddParameter("@ForeignNationalityID"
, Keys)
                            .Fetch<ForeignNationalInfo>();
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
        public List<ForeignNationalInfo> SelectByField(string fieldName, object value)
        {
            List<ForeignNationalInfo> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ForeignNationalInfoSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<ForeignNationalInfo>();

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
                obj = StoredProcedure(MasterDALConstant.ForeignNationalInfoSelectByField)
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

        public DataSet RPTCFormReport(Guid? CompanyID, Guid? PropertyID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.RPTCFormReport)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
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
                StoredProcedure(MasterDALConstant.ForeignNationalInfoDeleteByField)
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
