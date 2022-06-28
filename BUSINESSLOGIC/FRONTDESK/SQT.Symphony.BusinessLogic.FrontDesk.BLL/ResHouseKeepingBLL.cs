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
    public static class ResHouseKeepingBLL
    {

        //#region data Members

        //private static ResHouseKeepingDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ResHouseKeepingBLL()
        {
            //_dataObject = new ResHouseKeepingDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ResHouseKeeping
        /// </summary>
        /// <param name="businessObject">ResHouseKeeping object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ResHouseKeeping businessObject)
        {
            ResHouseKeepingDAL _dataObject = new ResHouseKeepingDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ResHKPID = Guid.NewGuid();
                    
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
        /// Update existing ResHouseKeeping
        /// </summary>
        /// <param name="businessObject">ResHouseKeeping object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ResHouseKeeping businessObject)
        {
            ResHouseKeepingDAL _dataObject = new ResHouseKeepingDAL();
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
        /// get ResHouseKeeping by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ResHouseKeeping GetByPrimaryKey(Guid keys)
        {
            ResHouseKeepingDAL _dataObject = new ResHouseKeepingDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ResHouseKeepings
        /// </summary>
        /// <returns>list</returns>
        public static List<ResHouseKeeping> GetAll(ResHouseKeeping obj)
        {
            ResHouseKeepingDAL _dataObject = new ResHouseKeepingDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ResHouseKeepings
        /// </summary>
        /// <returns>list</returns>
        public static List<ResHouseKeeping> GetAll()
        {
            ResHouseKeepingDAL _dataObject = new ResHouseKeepingDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ResHouseKeeping by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ResHouseKeeping> GetAllBy(ResHouseKeeping.ResHouseKeepingFields fieldName, object value)
        {
            ResHouseKeepingDAL _dataObject = new ResHouseKeepingDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ResHouseKeepings
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ResHouseKeeping obj)
        {
            ResHouseKeepingDAL _dataObject = new ResHouseKeepingDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ResHouseKeepings
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ResHouseKeepingDAL _dataObject = new ResHouseKeepingDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ResHouseKeeping by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ResHouseKeeping.ResHouseKeepingFields fieldName, object value)
        {
            ResHouseKeepingDAL _dataObject = new ResHouseKeepingDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ResHouseKeepingDAL _dataObject = new ResHouseKeepingDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ResHouseKeeping obj)
        {
            ResHouseKeepingDAL _dataObject = new ResHouseKeepingDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ResHouseKeeping by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ResHouseKeeping.ResHouseKeepingFields fieldName, object value)
        {
            ResHouseKeepingDAL _dataObject = new ResHouseKeepingDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
