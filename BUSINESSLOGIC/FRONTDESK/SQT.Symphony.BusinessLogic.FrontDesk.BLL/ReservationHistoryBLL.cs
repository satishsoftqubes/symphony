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
    public static class ReservationHistoryBLL
    {

        //#region data Members

        //private static ReservationHistoryDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ReservationHistoryBLL()
        {
            //_dataObject = new ReservationHistoryDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ReservationHistory
        /// </summary>
        /// <param name="businessObject">ReservationHistory object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ReservationHistory businessObject)
        {
            ReservationHistoryDAL _dataObject = new ReservationHistoryDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ResHistoryID = Guid.NewGuid();
                    
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
        /// Update existing ReservationHistory
        /// </summary>
        /// <param name="businessObject">ReservationHistory object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ReservationHistory businessObject)
        {
            ReservationHistoryDAL _dataObject = new ReservationHistoryDAL();
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
        /// get ReservationHistory by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ReservationHistory GetByPrimaryKey(Guid keys)
        {
            ReservationHistoryDAL _dataObject = new ReservationHistoryDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ReservationHistorys
        /// </summary>
        /// <returns>list</returns>
        public static List<ReservationHistory> GetAll(ReservationHistory obj)
        {
            ReservationHistoryDAL _dataObject = new ReservationHistoryDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ReservationHistorys
        /// </summary>
        /// <returns>list</returns>
        public static List<ReservationHistory> GetAll()
        {
            ReservationHistoryDAL _dataObject = new ReservationHistoryDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ReservationHistory by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ReservationHistory> GetAllBy(ReservationHistory.ReservationHistoryFields fieldName, object value)
        {
            ReservationHistoryDAL _dataObject = new ReservationHistoryDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ReservationHistorys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ReservationHistory obj)
        {
            ReservationHistoryDAL _dataObject = new ReservationHistoryDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ReservationHistorys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ReservationHistoryDAL _dataObject = new ReservationHistoryDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ReservationHistory by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ReservationHistory.ReservationHistoryFields fieldName, object value)
        {
            ReservationHistoryDAL _dataObject = new ReservationHistoryDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ReservationHistoryDAL _dataObject = new ReservationHistoryDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ReservationHistory obj)
        {
            ReservationHistoryDAL _dataObject = new ReservationHistoryDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ReservationHistory by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ReservationHistory.ReservationHistoryFields fieldName, object value)
        {
            ReservationHistoryDAL _dataObject = new ReservationHistoryDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
