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
    public static class ReservationUpdateLogBLL
    {

        //#region data Members

        //private static ReservationUpdateLogDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ReservationUpdateLogBLL()
        {
            //_dataObject = new ReservationUpdateLogDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ReservationUpdateLog
        /// </summary>
        /// <param name="businessObject">ReservationUpdateLog object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ReservationUpdateLog businessObject)
        {
            ReservationUpdateLogDAL _dataObject = new ReservationUpdateLogDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ReservationUpdateLogID = Guid.NewGuid();
                    
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
        /// Update existing ReservationUpdateLog
        /// </summary>
        /// <param name="businessObject">ReservationUpdateLog object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ReservationUpdateLog businessObject)
        {
            ReservationUpdateLogDAL _dataObject = new ReservationUpdateLogDAL();
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
        /// get ReservationUpdateLog by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ReservationUpdateLog GetByPrimaryKey(Guid keys)
        {
            ReservationUpdateLogDAL _dataObject = new ReservationUpdateLogDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ReservationUpdateLogs
        /// </summary>
        /// <returns>list</returns>
        public static List<ReservationUpdateLog> GetAll(ReservationUpdateLog obj)
        {
            ReservationUpdateLogDAL _dataObject = new ReservationUpdateLogDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ReservationUpdateLogs
        /// </summary>
        /// <returns>list</returns>
        public static List<ReservationUpdateLog> GetAll()
        {
            ReservationUpdateLogDAL _dataObject = new ReservationUpdateLogDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ReservationUpdateLog by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ReservationUpdateLog> GetAllBy(ReservationUpdateLog.ReservationUpdateLogFields fieldName, object value)
        {
            ReservationUpdateLogDAL _dataObject = new ReservationUpdateLogDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ReservationUpdateLogs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ReservationUpdateLog obj)
        {
            ReservationUpdateLogDAL _dataObject = new ReservationUpdateLogDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ReservationUpdateLogs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ReservationUpdateLogDAL _dataObject = new ReservationUpdateLogDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ReservationUpdateLog by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ReservationUpdateLog.ReservationUpdateLogFields fieldName, object value)
        {
            ReservationUpdateLogDAL _dataObject = new ReservationUpdateLogDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ReservationUpdateLogDAL _dataObject = new ReservationUpdateLogDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ReservationUpdateLog obj)
        {
            ReservationUpdateLogDAL _dataObject = new ReservationUpdateLogDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ReservationUpdateLog by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ReservationUpdateLog.ReservationUpdateLogFields fieldName, object value)
        {
            ReservationUpdateLogDAL _dataObject = new ReservationUpdateLogDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
