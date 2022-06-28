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
    public static class CheckinTimeLogBLL
    {

        //#region data Members

        //private static CheckinTimeLogDAL _dataObject = null;

        //#endregion

        #region Constructor

        static CheckinTimeLogBLL()
        {
            //_dataObject = new CheckinTimeLogDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new CheckinTimeLog
        /// </summary>
        /// <param name="businessObject">CheckinTimeLog object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(CheckinTimeLog businessObject)
        {
            CheckinTimeLogDAL _dataObject = new CheckinTimeLogDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.CheckInLogID = Guid.NewGuid();
                    
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
        /// Update existing CheckinTimeLog
        /// </summary>
        /// <param name="businessObject">CheckinTimeLog object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(CheckinTimeLog businessObject)
        {
            CheckinTimeLogDAL _dataObject = new CheckinTimeLogDAL();
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
        /// get CheckinTimeLog by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static CheckinTimeLog GetByPrimaryKey(Guid keys)
        {
            CheckinTimeLogDAL _dataObject = new CheckinTimeLogDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all CheckinTimeLogs
        /// </summary>
        /// <returns>list</returns>
        public static List<CheckinTimeLog> GetAll(CheckinTimeLog obj)
        {
            CheckinTimeLogDAL _dataObject = new CheckinTimeLogDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all CheckinTimeLogs
        /// </summary>
        /// <returns>list</returns>
        public static List<CheckinTimeLog> GetAll()
        {
            CheckinTimeLogDAL _dataObject = new CheckinTimeLogDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of CheckinTimeLog by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<CheckinTimeLog> GetAllBy(CheckinTimeLog.CheckinTimeLogFields fieldName, object value)
        {
            CheckinTimeLogDAL _dataObject = new CheckinTimeLogDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all CheckinTimeLogs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(CheckinTimeLog obj)
        {
            CheckinTimeLogDAL _dataObject = new CheckinTimeLogDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all CheckinTimeLogs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            CheckinTimeLogDAL _dataObject = new CheckinTimeLogDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of CheckinTimeLog by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(CheckinTimeLog.CheckinTimeLogFields fieldName, object value)
        {
            CheckinTimeLogDAL _dataObject = new CheckinTimeLogDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            CheckinTimeLogDAL _dataObject = new CheckinTimeLogDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(CheckinTimeLog obj)
        {
            CheckinTimeLogDAL _dataObject = new CheckinTimeLogDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete CheckinTimeLog by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(CheckinTimeLog.CheckinTimeLogFields fieldName, object value)
        {
            CheckinTimeLogDAL _dataObject = new CheckinTimeLogDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet SelectCheckInLog(DateTime? fromDate, DateTime? toDate, Guid? CheckInBy, Guid properytID, Guid companyID)
        {
            CheckinTimeLogDAL _dataObject = new CheckinTimeLogDAL();
            return _dataObject.SelectCheckInLog(fromDate, toDate, CheckInBy, properytID,companyID);
        }
        #endregion

    }
}
