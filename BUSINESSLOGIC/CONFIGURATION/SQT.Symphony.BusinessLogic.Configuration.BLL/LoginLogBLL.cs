using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SQT.FRAMEWORK.DAL.Linq.Exceptions;
using SQT.FRAMEWORK.DAL.Validation;
using SQT.FRAMEWORK.EXCEPTION;
using SQT.FRAMEWORK.LOGGER;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SQT.FRAMEWORK.DAL.Linq;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.DAL;

namespace SQT.Symphony.BusinessLogic.Configuration.BLL
{
    public static class LoginLogBLL
    {

        //#region data Members

        //private static LoginLogDAL _dataObject = null;

        //#endregion

        #region Constructor

        static LoginLogBLL()
        {
            //_dataObject = new LoginLogDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new LoginLog
        /// </summary>
        /// <param name="businessObject">LoginLog object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(LoginLog businessObject)
        {
            LoginLogDAL _dataObject = new LoginLogDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.LogInLogID = Guid.NewGuid();
                    
                        if (!businessObject.IsValid)
                        {
                            throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                        }
                        return _dataObject.Insert(businessObject);
                    }
                }
                else
                {
                    throw new InvalidBusinessObjectException("Object Is NULL");
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update existing LoginLog
        /// </summary>
        /// <param name="businessObject">LoginLog object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(LoginLog businessObject)
        {
            LoginLogDAL _dataObject = new LoginLogDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        if (!businessObject.IsValid)
                        {
                            throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                        }
                        return _dataObject.Update(businessObject);
                    }
                }
                else
                {
                    throw new InvalidBusinessObjectException("Object Is NULL");
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// get LoginLog by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static LoginLog GetByPrimaryKey(Guid keys)
        {
            LoginLogDAL _dataObject = new LoginLogDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all LoginLogs
        /// </summary>
        /// <returns>list</returns>
        public static List<LoginLog> GetAll(LoginLog obj)
        {
            LoginLogDAL _dataObject = new LoginLogDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all LoginLogs
        /// </summary>
        /// <returns>list</returns>
        public static List<LoginLog> GetAll()
        {
            LoginLogDAL _dataObject = new LoginLogDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of LoginLog by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<LoginLog> GetAllBy(LoginLog.LoginLogFields fieldName, object value)
        {
            LoginLogDAL _dataObject = new LoginLogDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all LoginLogs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(LoginLog obj)
        {
            LoginLogDAL _dataObject = new LoginLogDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all LoginLogs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            LoginLogDAL _dataObject = new LoginLogDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of LoginLog by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(LoginLog.LoginLogFields fieldName, object value)
        {
            LoginLogDAL _dataObject = new LoginLogDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }
        /// <summary>
        /// Report LogIn Log
        /// </summary>
        /// <param name="UserDispalayName"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public static DataSet GetRptLogInLog(string UserDispalayName, DateTime? StartDate, DateTime? EndDate, Guid? RoleID)
        {
            LoginLogDAL _dataObject = new LoginLogDAL();
            return _dataObject.rptLogInLog(UserDispalayName, StartDate, EndDate, RoleID);
        }
        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            LoginLogDAL _dataObject = new LoginLogDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(LoginLog obj)
        {
            LoginLogDAL _dataObject = new LoginLogDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete LoginLog by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(LoginLog.LoginLogFields fieldName, object value)
        {
            LoginLogDAL _dataObject = new LoginLogDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet GetLogInLogData(Guid? LogInLogID, Guid? UserID, DateTime? LogIn, Guid? CompanyID, Guid? PropertyID)
        {
            LoginLogDAL _dataObject = new LoginLogDAL();
            return _dataObject.SearchLogInLogData(LogInLogID, UserID, LogIn, CompanyID, PropertyID);
        }

        public static DataSet SearchLogInLogDataForSymphony(Guid? LogInLogID, Guid? UserID, DateTime? LogIn, Guid? CompanyID, Guid? PropertyID, string UserRoleType)
        {
            LoginLogDAL _dataObject = new LoginLogDAL();
            return _dataObject.SearchLogInLogDataForSymphony(LogInLogID, UserID, LogIn, CompanyID, PropertyID, UserRoleType);
        }
        #endregion

    }
}
