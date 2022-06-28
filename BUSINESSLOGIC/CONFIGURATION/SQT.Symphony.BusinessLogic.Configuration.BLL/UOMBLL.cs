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
    public static class UOMBLL
    {

        //#region data Members

        //private static UOMDAL _dataObject = null;

        //#endregion

        #region Constructor

        static UOMBLL()
        {
            //_dataObject = new UOMDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new UOM
        /// </summary>
        /// <param name="businessObject">UOM object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(UOM businessObject)
        {
            UOMDAL _dataObject = new UOMDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.UOMID = Guid.NewGuid();
                    
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
        /// Update existing UOM
        /// </summary>
        /// <param name="businessObject">UOM object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(UOM businessObject)
        {
            UOMDAL _dataObject = new UOMDAL();
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
        /// get UOM by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static UOM GetByPrimaryKey(Guid keys)
        {
            UOMDAL _dataObject = new UOMDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all UOMs
        /// </summary>
        /// <returns>list</returns>
        public static List<UOM> GetAll(UOM obj)
        {
            UOMDAL _dataObject = new UOMDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all UOMs
        /// </summary>
        /// <returns>list</returns>
        public static List<UOM> GetAll()
        {
            UOMDAL _dataObject = new UOMDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of UOM by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<UOM> GetAllBy(UOM.UOMFields fieldName, object value)
        {
            UOMDAL _dataObject = new UOMDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all UOMs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(UOM obj)
        {
            UOMDAL _dataObject = new UOMDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all UOMs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            UOMDAL _dataObject = new UOMDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of UOM by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(UOM.UOMFields fieldName, object value)
        {
            UOMDAL _dataObject = new UOMDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            UOMDAL _dataObject = new UOMDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(UOM obj)
        {
            UOMDAL _dataObject = new UOMDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete UOM by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(UOM.UOMFields fieldName, object value)
        {
            UOMDAL _dataObject = new UOMDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
