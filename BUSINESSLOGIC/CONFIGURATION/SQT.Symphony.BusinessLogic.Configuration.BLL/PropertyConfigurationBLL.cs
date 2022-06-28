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
    public static class PropertyConfigurationBLL
    {

        //#region data Members

        //private static PropertyConfigurationDAL _dataObject = null;

        //#endregion

        #region Constructor

        static PropertyConfigurationBLL()
        {
            //_dataObject = new PropertyConfigurationDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new PropertyConfiguration
        /// </summary>
        /// <param name="businessObject">PropertyConfiguration object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(PropertyConfiguration businessObject)
        {
            PropertyConfigurationDAL _dataObject = new PropertyConfigurationDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.PropertyConfigurationID = Guid.NewGuid();
                    
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
        /// Update existing PropertyConfiguration
        /// </summary>
        /// <param name="businessObject">PropertyConfiguration object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(PropertyConfiguration businessObject)
        {
            PropertyConfigurationDAL _dataObject = new PropertyConfigurationDAL();
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
        /// get PropertyConfiguration by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static PropertyConfiguration GetByPrimaryKey(Guid keys)
        {
            PropertyConfigurationDAL _dataObject = new PropertyConfigurationDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all PropertyConfigurations
        /// </summary>
        /// <returns>list</returns>
        public static List<PropertyConfiguration> GetAll(PropertyConfiguration obj)
        {
            PropertyConfigurationDAL _dataObject = new PropertyConfigurationDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all PropertyConfigurations
        /// </summary>
        /// <returns>list</returns>
        public static List<PropertyConfiguration> GetAll()
        {
            PropertyConfigurationDAL _dataObject = new PropertyConfigurationDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of PropertyConfiguration by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<PropertyConfiguration> GetAllBy(PropertyConfiguration.PropertyConfigurationFields fieldName, object value)
        {
            PropertyConfigurationDAL _dataObject = new PropertyConfigurationDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all PropertyConfigurations
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(PropertyConfiguration obj)
        {
            PropertyConfigurationDAL _dataObject = new PropertyConfigurationDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all PropertyConfigurations
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            PropertyConfigurationDAL _dataObject = new PropertyConfigurationDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of PropertyConfiguration by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(PropertyConfiguration.PropertyConfigurationFields fieldName, object value)
        {
            PropertyConfigurationDAL _dataObject = new PropertyConfigurationDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            PropertyConfigurationDAL _dataObject = new PropertyConfigurationDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(PropertyConfiguration obj)
        {
            PropertyConfigurationDAL _dataObject = new PropertyConfigurationDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete PropertyConfiguration by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(PropertyConfiguration.PropertyConfigurationFields fieldName, object value)
        {
            PropertyConfigurationDAL _dataObject = new PropertyConfigurationDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static PropertyConfiguration GetByCmpnAndPrpt(Guid? companyID, Guid? propertyID)
        {
            PropertyConfigurationDAL _dataObject = new PropertyConfigurationDAL();
            return _dataObject.SelectByCmpnAndPrpt(companyID,propertyID);
        }
        #endregion

    }
}
