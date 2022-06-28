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
    public static class StayTypeBLL
    {

        //#region data Members

        //private static StayTypeDAL _dataObject = null;

        //#endregion

        #region Constructor

        static StayTypeBLL()
        {
            //_dataObject = new StayTypeDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new StayType
        /// </summary>
        /// <param name="businessObject">StayType object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(StayType businessObject)
        {
            StayTypeDAL _dataObject = new StayTypeDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.StayTypeID = Guid.NewGuid();
                    
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
        /// Update existing StayType
        /// </summary>
        /// <param name="businessObject">StayType object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(StayType businessObject)
        {
            StayTypeDAL _dataObject = new StayTypeDAL();
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
        /// get StayType by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static StayType GetByPrimaryKey(Guid keys)
        {
            StayTypeDAL _dataObject = new StayTypeDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all StayTypes
        /// </summary>
        /// <returns>list</returns>
        public static List<StayType> GetAll(StayType obj)
        {
            StayTypeDAL _dataObject = new StayTypeDAL();
            return _dataObject.SelectAll(obj); 
        }

        public static List<StayType> GetAllForCheckDuplicate(StayType obj)
        {
            StayTypeDAL _dataObject = new StayTypeDAL();
            return _dataObject.SelectAllForCheckDuplicate(obj);
        }

        /// <summary>
        /// get list of all StayTypes
        /// </summary>
        /// <returns>list</returns>
        public static List<StayType> GetAll()
        {
            StayTypeDAL _dataObject = new StayTypeDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of StayType by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<StayType> GetAllBy(StayType.StayTypeFields fieldName, object value)
        {
            StayTypeDAL _dataObject = new StayTypeDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all StayTypes
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(StayType obj)
        {
            StayTypeDAL _dataObject = new StayTypeDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all StayTypes
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            StayTypeDAL _dataObject = new StayTypeDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of StayType by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(StayType.StayTypeFields fieldName, object value)
        {
            StayTypeDAL _dataObject = new StayTypeDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            StayTypeDAL _dataObject = new StayTypeDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(StayType obj)
        {
            StayTypeDAL _dataObject = new StayTypeDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete StayType by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(StayType.StayTypeFields fieldName, object value)
        {
            StayTypeDAL _dataObject = new StayTypeDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
