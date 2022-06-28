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
    /// Data access layer class for Inquiry
    /// </summary>
    public class InquiryDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public InquiryDAL()
            : base()
        {
            // Nothing for now.
        }
        public InquiryDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Inquiry> SelectAll(Inquiry dtoObject)
        {
            List<Inquiry> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.InquirySelectAll)
                                                .AddParameter("@InqID", dtoObject.InqID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@GuestFullName", dtoObject.GuestFullName)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@Phone", dtoObject.Phone)
.AddParameter("@Company_Name", dtoObject.Company_Name)
.AddParameter("@ArrivalDate", dtoObject.ArrivalDate)
.AddParameter("@DepartureDate", dtoObject.DepartureDate)
.AddParameter("@Inq_StatusTerm", dtoObject.Inq_StatusTerm)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@GenderTermID", dtoObject.GenderTermID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@EmailDatabase_TermID", dtoObject.EmailDatabase_TermID)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Inquiry>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.InquirySelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Inquiry>();
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

        public List<Inquiry> SelectAll()
        {
            List<Inquiry> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.InquirySelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Inquiry>();
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
        public DataSet SelectAllWithDataSet(Inquiry dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.InquirySelectAll)
                                                .AddParameter("@InqID", dtoObject.InqID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@GuestFullName", dtoObject.GuestFullName)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@Phone", dtoObject.Phone)
.AddParameter("@Company_Name", dtoObject.Company_Name)
.AddParameter("@ArrivalDate", dtoObject.ArrivalDate)
.AddParameter("@DepartureDate", dtoObject.DepartureDate)
.AddParameter("@Inq_StatusTerm", dtoObject.Inq_StatusTerm)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@GenderTermID", dtoObject.GenderTermID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@EmailDatabase_TermID", dtoObject.EmailDatabase_TermID)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.InquirySelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.InquirySelectAll)
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
        public bool Insert(Inquiry dtoObject)
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

                    StoredProcedure(MasterDALConstant.InquiryInsert)
                        .AddParameter("@InqID", dtoObject.InqID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@GuestFullName", dtoObject.GuestFullName)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@Phone", dtoObject.Phone)
.AddParameter("@Company_Name", dtoObject.Company_Name)
.AddParameter("@ArrivalDate", dtoObject.ArrivalDate)
.AddParameter("@DepartureDate", dtoObject.DepartureDate)
.AddParameter("@Inq_StatusTerm", dtoObject.Inq_StatusTerm)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@GenderTermID", dtoObject.GenderTermID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@EmailDatabase_TermID", dtoObject.EmailDatabase_TermID)

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
        public bool Update(Inquiry dtoObject)
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

                    StoredProcedure(MasterDALConstant.InquiryUpdate)
                        .AddParameter("@InqID", dtoObject.InqID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@GuestFullName", dtoObject.GuestFullName)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@Phone", dtoObject.Phone)
.AddParameter("@Company_Name", dtoObject.Company_Name)
.AddParameter("@ArrivalDate", dtoObject.ArrivalDate)
.AddParameter("@DepartureDate", dtoObject.DepartureDate)
.AddParameter("@Inq_StatusTerm", dtoObject.Inq_StatusTerm)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@GenderTermID", dtoObject.GenderTermID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@EmailDatabase_TermID", dtoObject.EmailDatabase_TermID)

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
                StoredProcedure(MasterDALConstant.InquiryDeleteByPrimaryKey)
                    .AddParameter("@InqID"
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
        public bool Delete(Inquiry dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.InquiryDeleteByPrimaryKey)
                    .AddParameter("@InqID", dtoObject.InqID)

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

        public Inquiry SelectByPrimaryKey(Guid Keys)
        {
            Inquiry obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.InquirySelectByPrimaryKey)
                            .AddParameter("@InqID"
, Keys)
                            .Fetch<Inquiry>();
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
        public List<Inquiry> SelectByField(string fieldName, object value)
        {
            List<Inquiry> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.InquirySelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Inquiry>();

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
                obj = StoredProcedure(MasterDALConstant.InquirySelectByField)
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
                StoredProcedure(MasterDALConstant.InquiryDeleteByField)
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
        public DataSet SelectInquiryList(Guid companyID, Guid propertyID, string GuestName, string MobileNo, string Email, DateTime? ArrivalDate, DateTime? Departuredate, string InquiryStatus, Guid? InqID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.Inquiryres_InquiryList)
                                    .AddParameter("@CompanyID", companyID)
                                    .AddParameter("@PropertyID", propertyID)
                                    .AddParameter("@GuestFullName", GuestName)
                                    .AddParameter("@MobileNo", MobileNo)
                                    .AddParameter("@Email", Email)
                                    .AddParameter("@ArrivalDate", ArrivalDate)
                                    .AddParameter("@DepartureDate", Departuredate)
                                    .AddParameter("@InquiryStatus", InquiryStatus)
                                    .AddParameter("@InqID", InqID)
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
        public DataSet SelectEmailConfigSelectForMarketingEmail()
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.EmailConfigSelectForMarketingEmail)
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
