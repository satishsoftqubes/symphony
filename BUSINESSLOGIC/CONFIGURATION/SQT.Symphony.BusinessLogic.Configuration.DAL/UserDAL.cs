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
	/// Data access layer class for User
	/// </summary>
	public class UserDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public UserDAL() :  base()
		{
			// Nothing for now.
		}
        public UserDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get User Access
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public DataSet UserCredential(string UserName, string Password)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.UserCredential)
                    .AddParameter("@UserName", UserName)
                    .AddParameter("@Password", Password)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }


        public List<User> SelectAll(User dtoObject)
        {
            List<User> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    if(dtoObject != null)
                        parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                    if(dtoObject != null)  
                    {
                        obj = StoredProcedure(MasterConstant.UserSelectAll)
                                                .AddParameter("@UsearID", dtoObject.UsearID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsCRSUser", dtoObject.IsCRSUser)
.AddParameter("@UserTypeID", dtoObject.UserTypeID)
.AddParameter("@UserType", dtoObject.UserType)
.AddParameter("@IsDefault", dtoObject.IsDefault)
.AddParameter("@IsSystemUser", dtoObject.IsSystemUser)
.AddParameter("@IsSymphonyUser", dtoObject.IsSymphonyUser)
.AddParameter("@UserName", dtoObject.UserName)
.AddParameter("@Password", dtoObject.Password)
.AddParameter("@PasswordKey", dtoObject.PasswordKey)
.AddParameter("@LastLogingDate", dtoObject.LastLogingDate)
.AddParameter("@CraetedOn", dtoObject.CraetedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@IsBlock", dtoObject.IsBlock)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@LastPasswordUpdateOn", dtoObject.LastPasswordUpdateOn)
.AddParameter("@UserDisplayName", dtoObject.UserDisplayName)
.AddParameter("@DisplayAvtar", dtoObject.DisplayAvtar)
.AddParameter("@BlockOn", dtoObject.BlockOn)
.AddParameter("@BlockBy", dtoObject.BlockBy)
.AddParameter("@PhotoLocal", dtoObject.PhotoLocal)
.AddParameter("@SeqNo", dtoObject.SeqNo)

                                                .WithTransaction(dbtr)
                                                .FetchAll<User>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.UserSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<User>();
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

        public List<User> SelectAll()
        {
            List<User> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.UserSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<User>();
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
        public DataSet SelectAllWithDataSet(User dtoObject)
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
                        obj = StoredProcedure(MasterConstant.UserSelectAll)
                                                .AddParameter("@UsearID", dtoObject.UsearID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsCRSUser", dtoObject.IsCRSUser)
.AddParameter("@UserTypeID", dtoObject.UserTypeID)
.AddParameter("@UserType", dtoObject.UserType)
.AddParameter("@IsDefault", dtoObject.IsDefault)
.AddParameter("@IsSystemUser", dtoObject.IsSystemUser)
.AddParameter("@IsSymphonyUser", dtoObject.IsSymphonyUser)
.AddParameter("@UserName", dtoObject.UserName)
.AddParameter("@Password", dtoObject.Password)
.AddParameter("@PasswordKey", dtoObject.PasswordKey)
.AddParameter("@LastLogingDate", dtoObject.LastLogingDate)
.AddParameter("@CraetedOn", dtoObject.CraetedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@IsBlock", dtoObject.IsBlock)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@LastPasswordUpdateOn", dtoObject.LastPasswordUpdateOn)
.AddParameter("@UserDisplayName", dtoObject.UserDisplayName)
.AddParameter("@DisplayAvtar", dtoObject.DisplayAvtar)
.AddParameter("@BlockOn", dtoObject.BlockOn)
.AddParameter("@BlockBy", dtoObject.BlockBy)
.AddParameter("@PhotoLocal", dtoObject.PhotoLocal)
.AddParameter("@SeqNo", dtoObject.SeqNo)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.UserSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                }
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
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
                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.UserSelectAll)
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
		public bool Insert(User dtoObject)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    if (dtoObject == null)
                        throw (new ParameterNullException("Object can not be null"));

                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterConstant.UserInsert)
                        .AddParameter("@UsearID", dtoObject.UsearID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsCRSUser", dtoObject.IsCRSUser)
.AddParameter("@UserTypeID", dtoObject.UserTypeID)
.AddParameter("@UserType", dtoObject.UserType)
.AddParameter("@IsDefault", dtoObject.IsDefault)
.AddParameter("@IsSystemUser", dtoObject.IsSystemUser)
.AddParameter("@IsSymphonyUser", dtoObject.IsSymphonyUser)
.AddParameter("@UserName", dtoObject.UserName)
.AddParameter("@Password", dtoObject.Password)
.AddParameter("@PasswordKey", dtoObject.PasswordKey)
.AddParameter("@LastLogingDate", dtoObject.LastLogingDate)
.AddParameter("@CraetedOn", dtoObject.CraetedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@IsBlock", dtoObject.IsBlock)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@LastPasswordUpdateOn", dtoObject.LastPasswordUpdateOn)
.AddParameter("@UserDisplayName", dtoObject.UserDisplayName)
.AddParameter("@DisplayAvtar", dtoObject.DisplayAvtar)
.AddParameter("@BlockOn", dtoObject.BlockOn)
.AddParameter("@BlockBy", dtoObject.BlockBy)
.AddParameter("@PhotoLocal", dtoObject.PhotoLocal)
.AddParameter("@SeqNo", dtoObject.SeqNo)

                        .WithTransaction(dbtr)
                        .Execute();
                }
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
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
        public bool Update(User dtoObject)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    if (dtoObject == null)
                        throw (new ParameterNullException("Object can not be null"));

                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterConstant.UserUpdate)
                        .AddParameter("@UsearID", dtoObject.UsearID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@IsCRSUser", dtoObject.IsCRSUser)
.AddParameter("@UserTypeID", dtoObject.UserTypeID)
.AddParameter("@UserType", dtoObject.UserType)
.AddParameter("@IsDefault", dtoObject.IsDefault)
.AddParameter("@IsSystemUser", dtoObject.IsSystemUser)
.AddParameter("@IsSymphonyUser", dtoObject.IsSymphonyUser)
.AddParameter("@UserName", dtoObject.UserName)
.AddParameter("@Password", dtoObject.Password)
.AddParameter("@PasswordKey", dtoObject.PasswordKey)
.AddParameter("@LastLogingDate", dtoObject.LastLogingDate)
.AddParameter("@CraetedOn", dtoObject.CraetedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@IsBlock", dtoObject.IsBlock)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@LastPasswordUpdateOn", dtoObject.LastPasswordUpdateOn)
.AddParameter("@UserDisplayName", dtoObject.UserDisplayName)
.AddParameter("@DisplayAvtar", dtoObject.DisplayAvtar)
.AddParameter("@BlockOn", dtoObject.BlockOn)
.AddParameter("@BlockBy", dtoObject.BlockBy)
.AddParameter("@PhotoLocal", dtoObject.PhotoLocal)
.AddParameter("@SeqNo", dtoObject.SeqNo)

                        .WithTransaction(dbtr)
                        .Execute();
                }
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
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
                StoredProcedure(MasterConstant.UserDeleteByPrimaryKey)
                    .AddParameter("@UsearID"
,Keys)
                    .WithTransaction(dbtr)
                    .Execute();
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return true;
        }
        public bool Delete(User dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.UserDeleteByPrimaryKey)
                    .AddParameter("@UsearID", dtoObject.UsearID)

                    .WithTransaction(dbtr)
                    .Execute();
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return true;
        }

        public User SelectByPrimaryKey(Guid Keys)
        {
            User obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.UserSelectByPrimaryKey)
                            .AddParameter("@UsearID"
,Keys)
                            .Fetch<User>();
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }
        public List<User> SelectByField(string fieldName, object value)
        {
            List<User> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.UserSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<User>();

            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
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
                obj = StoredProcedure(MasterConstant.UserSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchDataSet();

            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
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
                StoredProcedure(MasterConstant.UserDeleteByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .WithTransaction(dbtr)
                                    .Execute();
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return true;
        }

        public DataSet SearchData(Guid? UsearID, Guid? PropertyID, Guid? CompanyID, string UserName, Guid? DepartmentID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.UserSearchData)
                                            .AddParameter("@UsearID", UsearID)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@CompanyID", CompanyID)
                                            .AddParameter("@UserName", UserName)
                                            .AddParameter("@DepartmentID", DepartmentID)
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

        public DataSet SelectUserName(string UserNameQuery)
        {
            DataSet dst = new DataSet();
            try
            {
                dst = Query(UserNameQuery)
                            .WithTransaction(dbtr)
                            .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return dst;
        }

        public DataSet UserAuthentication(string userName, string password)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.UserAuthentication)
                    .AddParameter("@UserName", userName)
                    .AddParameter("@Password", password)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet GetUserAuthorization(Guid userID, string formName)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.UserAuthorization)
                    .AddParameter("@UserID", userID)
                    .AddParameter("@FromName", formName)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }


        public DataSet GetUserAllAuthorization(Guid userID, string RoleType, Guid? PropertyID, Guid? CompanyID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.UserAllAuthorization)
                    .AddParameter("@UserID", userID)
                    .AddParameter("@RoleType", RoleType)
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

        public DataSet UserGetAllByRoleTypeHierarchy(string userRoleType, Guid companyID, Guid propertyID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.UserSelectAllByRoleTypeHierarchy)
                    .AddParameter("@UserRoleType", userRoleType)
                    .AddParameter("@CompanyID", companyID)
                    .AddParameter("@PropertyID", propertyID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }


        public DataSet UserSelectModule(Guid? UserID, Guid? PropertyID, Guid? CompanyID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.UserSelectModule)
                    .AddParameter("@UserID", UserID)
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
