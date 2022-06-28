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
    public static class CounterLoginLogBLL
    {

        //#region data Members

        //private static CounterLoginLogDAL _dataObject = null;

        //#endregion

        #region Constructor

        static CounterLoginLogBLL()
        {
            //_dataObject = new CounterLoginLogDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new CounterLoginLog
        /// </summary>
        /// <param name="businessObject">CounterLoginLog object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(CounterLoginLog businessObject)
        {
            CounterLoginLogDAL _dataObject = new CounterLoginLogDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.CounterLoginLogID = Guid.NewGuid();

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
        /// Update existing CounterLoginLog
        /// </summary>
        /// <param name="businessObject">CounterLoginLog object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(CounterLoginLog businessObject)
        {
            CounterLoginLogDAL _dataObject = new CounterLoginLogDAL();
            try
            {
                if (businessObject != null)
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
        /// get CounterLoginLog by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static CounterLoginLog GetByPrimaryKey(Guid keys)
        {
            CounterLoginLogDAL _dataObject = new CounterLoginLogDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all CounterLoginLogs
        /// </summary>
        /// <returns>list</returns>
        public static List<CounterLoginLog> GetAll(CounterLoginLog obj)
        {
            CounterLoginLogDAL _dataObject = new CounterLoginLogDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all CounterLoginLogs
        /// </summary>
        /// <returns>list</returns>
        public static List<CounterLoginLog> GetAll()
        {
            CounterLoginLogDAL _dataObject = new CounterLoginLogDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of CounterLoginLog by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<CounterLoginLog> GetAllBy(CounterLoginLog.CounterLoginLogFields fieldName, object value)
        {
            CounterLoginLogDAL _dataObject = new CounterLoginLogDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all CounterLoginLogs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(CounterLoginLog obj)
        {
            CounterLoginLogDAL _dataObject = new CounterLoginLogDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all CounterLoginLogs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            CounterLoginLogDAL _dataObject = new CounterLoginLogDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of CounterLoginLog by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(CounterLoginLog.CounterLoginLogFields fieldName, object value)
        {
            CounterLoginLogDAL _dataObject = new CounterLoginLogDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            CounterLoginLogDAL _dataObject = new CounterLoginLogDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(CounterLoginLog obj)
        {
            CounterLoginLogDAL _dataObject = new CounterLoginLogDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete CounterLoginLog by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(CounterLoginLog.CounterLoginLogFields fieldName, object value)
        {
            CounterLoginLogDAL _dataObject = new CounterLoginLogDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet GetCounterDetailsWithDataSet(Guid UserID, Guid PropertyID, Guid CompanyID)
        {
            CounterLoginLogDAL _dataObject = new CounterLoginLogDAL();
            return _dataObject.CounterLoginLogSelectDetails(UserID, PropertyID, CompanyID);
        }

        #endregion

    }
}
