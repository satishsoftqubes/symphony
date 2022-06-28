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
    public static class WingBLL
    {

        //#region data Members

        //private static WingDAL _dataObject = null;

        //#endregion

        #region Constructor

        static WingBLL()
        {
            //_dataObject = new WingDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Wing
        /// </summary>
        /// <param name="businessObject">Wing object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Wing businessObject)
        {
            WingDAL _dataObject = new WingDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.WingID = Guid.NewGuid();
                    
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
        /// Update existing Wing
        /// </summary>
        /// <param name="businessObject">Wing object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Wing businessObject)
        {
            WingDAL _dataObject = new WingDAL();
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
        /// get Wing by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Wing GetByPrimaryKey(Guid keys)
        {
            WingDAL _dataObject = new WingDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Wings
        /// </summary>
        /// <returns>list</returns>
        public static List<Wing> GetAll(Wing obj)
        {
            WingDAL _dataObject = new WingDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Wings
        /// </summary>
        /// <returns>list</returns>
        public static List<Wing> GetAll()
        {
            WingDAL _dataObject = new WingDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Wing by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Wing> GetAllBy(Wing.WingFields fieldName, object value)
        {
            WingDAL _dataObject = new WingDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Wings
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Wing obj)
        {
            WingDAL _dataObject = new WingDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Wings
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            WingDAL _dataObject = new WingDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Wing by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Wing.WingFields fieldName, object value)
        {
            WingDAL _dataObject = new WingDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            WingDAL _dataObject = new WingDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Wing obj)
        {
            WingDAL _dataObject = new WingDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Wing by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Wing.WingFields fieldName, object value)
        {
            WingDAL _dataObject = new WingDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet SearchWingData(Guid? WingID, Guid? PropertyID, string WingName)
        {
            WingDAL _dataObject = new WingDAL();
            return _dataObject.SearchWingData(WingID, PropertyID, WingName);
        }

        public static DataSet GetDistinctWingOnRoom(Guid? propertyID)
        {
            WingDAL _dataObject = new WingDAL();
            return _dataObject.SelectDistinctWingOnRoom(propertyID);
        }

        public static DataSet GetDistinctWingAndRate(Guid? propertyID, Guid? CompanyID)
        {
            WingDAL _dataObject = new WingDAL();
            return _dataObject.SelectDistinctWingAndRate(propertyID, CompanyID);
        }
        
        public static DataSet GetWing(string WingQuery)
        {
            WingDAL _dataObject = new WingDAL();
            return _dataObject.SelectWing(WingQuery);
        }
        #endregion

    }
}
