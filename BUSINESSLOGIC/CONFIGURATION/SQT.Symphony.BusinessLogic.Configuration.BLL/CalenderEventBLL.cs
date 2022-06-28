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
    public static class CalenderEventBLL
    {

        //#region data Members

        //private static CalenderEventDAL _dataObject = null;

        //#endregion

        #region Constructor

        static CalenderEventBLL()
        {
            //_dataObject = new CalenderEventDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new CalenderEvent
        /// </summary>
        /// <param name="businessObject">CalenderEvent object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(CalenderEvent businessObject)
        {
            CalenderEventDAL _dataObject = new CalenderEventDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.EventID = Guid.NewGuid();
                    
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
        /// Update existing CalenderEvent
        /// </summary>
        /// <param name="businessObject">CalenderEvent object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(CalenderEvent businessObject)
        {
            CalenderEventDAL _dataObject = new CalenderEventDAL();
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
        /// get CalenderEvent by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static CalenderEvent GetByPrimaryKey(Guid keys)
        {
            CalenderEventDAL _dataObject = new CalenderEventDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all CalenderEvents
        /// </summary>
        /// <returns>list</returns>
        public static List<CalenderEvent> GetAll(CalenderEvent obj)
        {
            CalenderEventDAL _dataObject = new CalenderEventDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all CalenderEvents
        /// </summary>
        /// <returns>list</returns>
        public static List<CalenderEvent> GetAll()
        {
            CalenderEventDAL _dataObject = new CalenderEventDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of CalenderEvent by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<CalenderEvent> GetAllBy(CalenderEvent.CalenderEventFields fieldName, object value)
        {
            CalenderEventDAL _dataObject = new CalenderEventDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all CalenderEvents
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(CalenderEvent obj)
        {
            CalenderEventDAL _dataObject = new CalenderEventDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all CalenderEvents
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            CalenderEventDAL _dataObject = new CalenderEventDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of CalenderEvent by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(CalenderEvent.CalenderEventFields fieldName, object value)
        {
            CalenderEventDAL _dataObject = new CalenderEventDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            CalenderEventDAL _dataObject = new CalenderEventDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(CalenderEvent obj)
        {
            CalenderEventDAL _dataObject = new CalenderEventDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete CalenderEvent by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(CalenderEvent.CalenderEventFields fieldName, object value)
        {
            CalenderEventDAL _dataObject = new CalenderEventDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }


        public static bool DeleteDataByRateID(Guid PropertyID, Guid RateID)
        {
            CalenderEventDAL _dataObject = new CalenderEventDAL();
            return _dataObject.DeleteDataByRateID(PropertyID, RateID);
        }

        public static bool DeleteDataByDateAndRateID(Guid PropertyID, Guid RateID, DateTime EventDate)
        {
            CalenderEventDAL _dataObject = new CalenderEventDAL();
            return _dataObject.DeleteDataByDateAndRateID(PropertyID, RateID, EventDate);
        }
        #endregion

    }
}
