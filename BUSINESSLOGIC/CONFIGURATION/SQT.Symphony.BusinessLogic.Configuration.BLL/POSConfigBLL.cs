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
    public static class POSConfigBLL
    {

        //#region data Members

        //private static POSConfigDAL _dataObject = null;

        //#endregion

        #region Constructor

        static POSConfigBLL()
        {
            //_dataObject = new POSConfigDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new POSConfig
        /// </summary>
        /// <param name="businessObject">POSConfig object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(POSConfig businessObject)
        {
            POSConfigDAL _dataObject = new POSConfigDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.POSConfigID = Guid.NewGuid();
                    
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
        /// Update existing POSConfig
        /// </summary>
        /// <param name="businessObject">POSConfig object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(POSConfig businessObject)
        {
            POSConfigDAL _dataObject = new POSConfigDAL();
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
        /// get POSConfig by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static POSConfig GetByPrimaryKey(Guid keys)
        {
            POSConfigDAL _dataObject = new POSConfigDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all POSConfigs
        /// </summary>
        /// <returns>list</returns>
        public static List<POSConfig> GetAll(POSConfig obj)
        {
            POSConfigDAL _dataObject = new POSConfigDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all POSConfigs
        /// </summary>
        /// <returns>list</returns>
        public static List<POSConfig> GetAll()
        {
            POSConfigDAL _dataObject = new POSConfigDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of POSConfig by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<POSConfig> GetAllBy(POSConfig.POSConfigFields fieldName, object value)
        {
            POSConfigDAL _dataObject = new POSConfigDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all POSConfigs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(POSConfig obj)
        {
            POSConfigDAL _dataObject = new POSConfigDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all POSConfigs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            POSConfigDAL _dataObject = new POSConfigDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of POSConfig by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(POSConfig.POSConfigFields fieldName, object value)
        {
            POSConfigDAL _dataObject = new POSConfigDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            POSConfigDAL _dataObject = new POSConfigDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(POSConfig obj)
        {
            POSConfigDAL _dataObject = new POSConfigDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete POSConfig by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(POSConfig.POSConfigFields fieldName, object value)
        {
            POSConfigDAL _dataObject = new POSConfigDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
