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
    public static class UserRoleBLL
    {

        //#region data Members

        //private static UserRoleDAL _dataObject = null;

        //#endregion

        #region Constructor

        static UserRoleBLL()
        {
            //_dataObject = new UserRoleDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new UserRole
        /// </summary>
        /// <param name="businessObject">UserRole object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(UserRole businessObject)
        {
            UserRoleDAL _dataObject = new UserRoleDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.UserRoleID = Guid.NewGuid();
                    
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
        /// Update existing UserRole
        /// </summary>
        /// <param name="businessObject">UserRole object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(UserRole businessObject)
        {
            UserRoleDAL _dataObject = new UserRoleDAL();
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
        /// get UserRole by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static UserRole GetByPrimaryKey(Guid keys)
        {
            UserRoleDAL _dataObject = new UserRoleDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all UserRoles
        /// </summary>
        /// <returns>list</returns>
        public static List<UserRole> GetAll(UserRole obj)
        {
            UserRoleDAL _dataObject = new UserRoleDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all UserRoles
        /// </summary>
        /// <returns>list</returns>
        public static List<UserRole> GetAll()
        {
            UserRoleDAL _dataObject = new UserRoleDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of UserRole by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<UserRole> GetAllBy(UserRole.UserRoleFields fieldName, object value)
        {
            UserRoleDAL _dataObject = new UserRoleDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all UserRoles
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(UserRole obj)
        {
            UserRoleDAL _dataObject = new UserRoleDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all UserRoles Which are Functional
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSetFunctionalRoleOnly(UserRole obj)
        {
            UserRoleDAL _dataObject = new UserRoleDAL();
            return _dataObject.SelectFunctionalRoleOnly (obj);
        }



        /// <summary>
        /// get list of all UserRoles
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            UserRoleDAL _dataObject = new UserRoleDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of UserRole by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(UserRole.UserRoleFields fieldName, object value)
        {
            UserRoleDAL _dataObject = new UserRoleDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            UserRoleDAL _dataObject = new UserRoleDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(UserRole obj)
        {
            UserRoleDAL _dataObject = new UserRoleDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete UserRole by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(UserRole.UserRoleFields fieldName, object value)
        {
            UserRoleDAL _dataObject = new UserRoleDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
