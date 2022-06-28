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
    public static class HousekeepingConfigBLL
    {

        //#region data Members

        //private static HousekeepingConfigDAL _dataObject = null;

        //#endregion

        #region Constructor

        static HousekeepingConfigBLL()
        {
            //_dataObject = new HousekeepingConfigDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new HousekeepingConfig
        /// </summary>
        /// <param name="businessObject">HousekeepingConfig object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(HousekeepingConfig businessObject)
        {
            HousekeepingConfigDAL _dataObject = new HousekeepingConfigDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.HKPConfigID = Guid.NewGuid();
                    
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
        /// Update existing HousekeepingConfig
        /// </summary>
        /// <param name="businessObject">HousekeepingConfig object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(HousekeepingConfig businessObject)
        {
            HousekeepingConfigDAL _dataObject = new HousekeepingConfigDAL();
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
        /// get HousekeepingConfig by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static HousekeepingConfig GetByPrimaryKey(Guid keys)
        {
            HousekeepingConfigDAL _dataObject = new HousekeepingConfigDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all HousekeepingConfigs
        /// </summary>
        /// <returns>list</returns>
        public static List<HousekeepingConfig> GetAll(HousekeepingConfig obj)
        {
            HousekeepingConfigDAL _dataObject = new HousekeepingConfigDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all HousekeepingConfigs
        /// </summary>
        /// <returns>list</returns>
        public static List<HousekeepingConfig> GetAll()
        {
            HousekeepingConfigDAL _dataObject = new HousekeepingConfigDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of HousekeepingConfig by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<HousekeepingConfig> GetAllBy(HousekeepingConfig.HousekeepingConfigFields fieldName, object value)
        {
            HousekeepingConfigDAL _dataObject = new HousekeepingConfigDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all HousekeepingConfigs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(HousekeepingConfig obj)
        {
            HousekeepingConfigDAL _dataObject = new HousekeepingConfigDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all HousekeepingConfigs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            HousekeepingConfigDAL _dataObject = new HousekeepingConfigDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of HousekeepingConfig by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(HousekeepingConfig.HousekeepingConfigFields fieldName, object value)
        {
            HousekeepingConfigDAL _dataObject = new HousekeepingConfigDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            HousekeepingConfigDAL _dataObject = new HousekeepingConfigDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(HousekeepingConfig obj)
        {
            HousekeepingConfigDAL _dataObject = new HousekeepingConfigDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete HousekeepingConfig by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(HousekeepingConfig.HousekeepingConfigFields fieldName, object value)
        {
            HousekeepingConfigDAL _dataObject = new HousekeepingConfigDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
