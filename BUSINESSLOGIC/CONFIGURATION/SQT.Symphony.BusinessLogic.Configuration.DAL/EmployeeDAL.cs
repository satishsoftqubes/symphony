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
    /// Data access layer class for Employee
    /// </summary>
    public class EmployeeDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public EmployeeDAL()
            : base()
        {
            // Nothing for now.
        }
        public EmployeeDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods

        public List<Employee> SelectAll(Employee dtoObject)
        {
            List<Employee> obj = null;
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
                        obj = StoredProcedure(MasterConstant.EmployeeSelectAll)
                                                .AddParameter("@EmployeeID", dtoObject.EmployeeID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@DepartmentID", dtoObject.DepartmentID)
.AddParameter("@EmployeeNo", dtoObject.EmployeeNo)
.AddParameter("@Photo", dtoObject.Photo)
.AddParameter("@Surname", dtoObject.Surname)
.AddParameter("@FirstName", dtoObject.FirstName)
.AddParameter("@LastName", dtoObject.LastName)
.AddParameter("@MiddleName", dtoObject.MiddleName)
.AddParameter("@MaidenName", dtoObject.MaidenName)
.AddParameter("@FullName", dtoObject.FullName)
.AddParameter("@BirthDate", dtoObject.BirthDate)
.AddParameter("@BirthPlace", dtoObject.BirthPlace)
.AddParameter("@Age", dtoObject.Age)
.AddParameter("@NationalityAtBirth", dtoObject.NationalityAtBirth)
.AddParameter("@CurrentNationality", dtoObject.CurrentNationality)
.AddParameter("@Gender", dtoObject.Gender)
.AddParameter("@Height", dtoObject.Height)
.AddParameter("@Weight", dtoObject.Weight)
.AddParameter("@IdentificationMark", dtoObject.IdentificationMark)
.AddParameter("@MaritalStatus", dtoObject.MaritalStatus)
.AddParameter("@PAddressID", dtoObject.PAddressID)
.AddParameter("@CAddressID", dtoObject.CAddressID)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@MotherTongue", dtoObject.MotherTongue)
.AddParameter("@DOJ", dtoObject.DOJ)
.AddParameter("@DOC", dtoObject.DOC)
.AddParameter("@StatusID", dtoObject.StatusID)
.AddParameter("@CandidateID", dtoObject.CandidateID)
.AddParameter("@IsLocked", dtoObject.IsLocked)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@Synch", dtoObject.Synch)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@PhotoLocal", dtoObject.PhotoLocal)
.AddParameter("@Thumb", dtoObject.Thumb)
                            //.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@LandlineNo", dtoObject.LandlineNo)
.AddParameter("@IsSales", dtoObject.IsSales)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Employee>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.EmployeeSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Employee>();
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

        public List<Employee> SelectAll()
        {
            List<Employee> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.EmployeeSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Employee>();
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
        public DataSet SelectAllWithDataSet(Employee dtoObject)
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
                        obj = StoredProcedure(MasterConstant.EmployeeSelectAll)
                                                .AddParameter("@EmployeeID", dtoObject.EmployeeID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@DepartmentID", dtoObject.DepartmentID)
.AddParameter("@EmployeeNo", dtoObject.EmployeeNo)
.AddParameter("@Photo", dtoObject.Photo)
.AddParameter("@Surname", dtoObject.Surname)
.AddParameter("@FirstName", dtoObject.FirstName)
.AddParameter("@LastName", dtoObject.LastName)
.AddParameter("@MiddleName", dtoObject.MiddleName)
.AddParameter("@MaidenName", dtoObject.MaidenName)
.AddParameter("@FullName", dtoObject.FullName)
.AddParameter("@BirthDate", dtoObject.BirthDate)
.AddParameter("@BirthPlace", dtoObject.BirthPlace)
.AddParameter("@Age", dtoObject.Age)
.AddParameter("@NationalityAtBirth", dtoObject.NationalityAtBirth)
.AddParameter("@CurrentNationality", dtoObject.CurrentNationality)
.AddParameter("@Gender", dtoObject.Gender)
.AddParameter("@Height", dtoObject.Height)
.AddParameter("@Weight", dtoObject.Weight)
.AddParameter("@IdentificationMark", dtoObject.IdentificationMark)
.AddParameter("@MaritalStatus", dtoObject.MaritalStatus)
.AddParameter("@PAddressID", dtoObject.PAddressID)
.AddParameter("@CAddressID", dtoObject.CAddressID)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@MotherTongue", dtoObject.MotherTongue)
.AddParameter("@DOJ", dtoObject.DOJ)
.AddParameter("@DOC", dtoObject.DOC)
.AddParameter("@StatusID", dtoObject.StatusID)
.AddParameter("@CandidateID", dtoObject.CandidateID)
.AddParameter("@IsLocked", dtoObject.IsLocked)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@Synch", dtoObject.Synch)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@PhotoLocal", dtoObject.PhotoLocal)
.AddParameter("@Thumb", dtoObject.Thumb)
                            //.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@LandlineNo", dtoObject.LandlineNo)
.AddParameter("@IsSales", dtoObject.IsSales)
                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.EmployeeSelectAll)
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

                    obj = StoredProcedure(MasterConstant.EmployeeSelectAll)
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
        public bool Insert(Employee dtoObject)
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

                    StoredProcedure(MasterConstant.EmployeeInsert)
                        .AddParameter("@EmployeeID", dtoObject.EmployeeID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@DepartmentID", dtoObject.DepartmentID)
.AddParameter("@EmployeeNo", dtoObject.EmployeeNo)
.AddParameter("@Photo", dtoObject.Photo)
.AddParameter("@Surname", dtoObject.Surname)
.AddParameter("@FirstName", dtoObject.FirstName)
.AddParameter("@LastName", dtoObject.LastName)
.AddParameter("@MiddleName", dtoObject.MiddleName)
.AddParameter("@MaidenName", dtoObject.MaidenName)
.AddParameter("@FullName", dtoObject.FullName)
.AddParameter("@BirthDate", dtoObject.BirthDate)
.AddParameter("@BirthPlace", dtoObject.BirthPlace)
.AddParameter("@Age", dtoObject.Age)
.AddParameter("@NationalityAtBirth", dtoObject.NationalityAtBirth)
.AddParameter("@CurrentNationality", dtoObject.CurrentNationality)
.AddParameter("@Gender", dtoObject.Gender)
.AddParameter("@Height", dtoObject.Height)
.AddParameter("@Weight", dtoObject.Weight)
.AddParameter("@IdentificationMark", dtoObject.IdentificationMark)
.AddParameter("@MaritalStatus", dtoObject.MaritalStatus)
.AddParameter("@PAddressID", dtoObject.PAddressID)
.AddParameter("@CAddressID", dtoObject.CAddressID)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@MotherTongue", dtoObject.MotherTongue)
.AddParameter("@DOJ", dtoObject.DOJ)
.AddParameter("@DOC", dtoObject.DOC)
.AddParameter("@StatusID", dtoObject.StatusID)
.AddParameter("@CandidateID", dtoObject.CandidateID)
.AddParameter("@IsLocked", dtoObject.IsLocked)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@Synch", dtoObject.Synch)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@PhotoLocal", dtoObject.PhotoLocal)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@LandlineNo", dtoObject.LandlineNo)
.AddParameter("@IsSales", dtoObject.IsSales)
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
        public bool Update(Employee dtoObject)
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

                    StoredProcedure(MasterConstant.EmployeeUpdate)
                        .AddParameter("@EmployeeID", dtoObject.EmployeeID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@DepartmentID", dtoObject.DepartmentID)
.AddParameter("@EmployeeNo", dtoObject.EmployeeNo)
.AddParameter("@Photo", dtoObject.Photo)
.AddParameter("@Surname", dtoObject.Surname)
.AddParameter("@FirstName", dtoObject.FirstName)
.AddParameter("@LastName", dtoObject.LastName)
.AddParameter("@MiddleName", dtoObject.MiddleName)
.AddParameter("@MaidenName", dtoObject.MaidenName)
.AddParameter("@FullName", dtoObject.FullName)
.AddParameter("@BirthDate", dtoObject.BirthDate)
.AddParameter("@BirthPlace", dtoObject.BirthPlace)
.AddParameter("@Age", dtoObject.Age)
.AddParameter("@NationalityAtBirth", dtoObject.NationalityAtBirth)
.AddParameter("@CurrentNationality", dtoObject.CurrentNationality)
.AddParameter("@Gender", dtoObject.Gender)
.AddParameter("@Height", dtoObject.Height)
.AddParameter("@Weight", dtoObject.Weight)
.AddParameter("@IdentificationMark", dtoObject.IdentificationMark)
.AddParameter("@MaritalStatus", dtoObject.MaritalStatus)
.AddParameter("@PAddressID", dtoObject.PAddressID)
.AddParameter("@CAddressID", dtoObject.CAddressID)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@MotherTongue", dtoObject.MotherTongue)
.AddParameter("@DOJ", dtoObject.DOJ)
.AddParameter("@DOC", dtoObject.DOC)
.AddParameter("@StatusID", dtoObject.StatusID)
.AddParameter("@CandidateID", dtoObject.CandidateID)
.AddParameter("@IsLocked", dtoObject.IsLocked)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@Synch", dtoObject.Synch)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@PhotoLocal", dtoObject.PhotoLocal)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@LandlineNo", dtoObject.LandlineNo)
.AddParameter("@IsSales", dtoObject.IsSales)
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
                StoredProcedure(MasterConstant.EmployeeDeleteByPrimaryKey)
                    .AddParameter("@EmployeeID"
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
        public bool Delete(Employee dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.EmployeeDeleteByPrimaryKey)
                    .AddParameter("@EmployeeID", dtoObject.EmployeeID)

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

        public Employee SelectByPrimaryKey(Guid Keys)
        {
            Employee obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.EmployeeSelectByPrimaryKey)
                            .AddParameter("@EmployeeID"
, Keys)
                            .Fetch<Employee>();
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
        public List<Employee> SelectByField(string fieldName, object value)
        {
            List<Employee> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.EmployeeSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Employee>();

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
                obj = StoredProcedure(MasterConstant.EmployeeSelectByField)
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
                StoredProcedure(MasterConstant.EmployeeDeleteByField)
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

        public DataSet SelectAllSearch(Guid? EmployeeID, Guid? PropertyID, Guid? CompanyID, Guid? DepartmentID, string EmployeeNo, string FullName, string CityName)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.EmployeeSelectAllSearch)
                                            .AddParameter("@EmployeeID", EmployeeID)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@CompanyID", CompanyID)
                                            .AddParameter("@DepartmentID", DepartmentID)
                                            .AddParameter("@EmployeeNo", EmployeeNo)
                                            .AddParameter("@FullName", FullName)
                                            .AddParameter("@CityName", CityName)

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

        public DataSet SelectEmployeeForUser(Guid? PropertyID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.EmployeeSelectEmployeeForUser)                                            
                                            .AddParameter("@PropertyID", PropertyID)
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

        public DataSet SelectAllEmployeeForEmailSubscription()
        {
            DataSet dst = new DataSet();
            try
            {
                dst = StoredProcedure(MasterConstant.EmployeeSelectAllEmployeeForEmailSubscription)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return dst;
        }
        #endregion
    }
}
