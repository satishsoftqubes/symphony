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
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.DAL;

namespace SQT.Symphony.BusinessLogic.FrontDesk.BLL
{
    public static class ResAuditLogBLL
    {

        //#region data Members

        //private static ResAuditLogDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ResAuditLogBLL()
        {
            //_dataObject = new ResAuditLogDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ResAuditLog
        /// </summary>
        /// <param name="businessObject">ResAuditLog object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ResAuditLog businessObject)
        {
            ResAuditLogDAL _dataObject = new ResAuditLogDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.AuditLogID = Guid.NewGuid();
                    
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
        /// Update existing ResAuditLog
        /// </summary>
        /// <param name="businessObject">ResAuditLog object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ResAuditLog businessObject)
        {
            ResAuditLogDAL _dataObject = new ResAuditLogDAL();
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
        /// get ResAuditLog by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ResAuditLog GetByPrimaryKey(Guid keys)
        {
            ResAuditLogDAL _dataObject = new ResAuditLogDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ResAuditLogs
        /// </summary>
        /// <returns>list</returns>
        public static List<ResAuditLog> GetAll(ResAuditLog obj)
        {
            ResAuditLogDAL _dataObject = new ResAuditLogDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ResAuditLogs
        /// </summary>
        /// <returns>list</returns>
        public static List<ResAuditLog> GetAll()
        {
            ResAuditLogDAL _dataObject = new ResAuditLogDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ResAuditLog by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ResAuditLog> GetAllBy(ResAuditLog.ResAuditLogFields fieldName, object value)
        {
            ResAuditLogDAL _dataObject = new ResAuditLogDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ResAuditLogs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ResAuditLog obj)
        {
            ResAuditLogDAL _dataObject = new ResAuditLogDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ResAuditLogs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ResAuditLogDAL _dataObject = new ResAuditLogDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ResAuditLog by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ResAuditLog.ResAuditLogFields fieldName, object value)
        {
            ResAuditLogDAL _dataObject = new ResAuditLogDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ResAuditLogDAL _dataObject = new ResAuditLogDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ResAuditLog obj)
        {
            ResAuditLogDAL _dataObject = new ResAuditLogDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ResAuditLog by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ResAuditLog.ResAuditLogFields fieldName, object value)
        {
            ResAuditLogDAL _dataObject = new ResAuditLogDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
