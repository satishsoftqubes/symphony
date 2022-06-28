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
    public static class ResourceFilesBLL
    {

        //#region data Members

        //private static ResourceFilesDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ResourceFilesBLL()
        {
            //_dataObject = new ResourceFilesDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ResourceFiles
        /// </summary>
        /// <param name="businessObject">ResourceFiles object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ResourceFiles businessObject)
        {
            ResourceFilesDAL _dataObject = new ResourceFilesDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ResourceFileID = Guid.NewGuid();
                    
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
        /// Update existing ResourceFiles
        /// </summary>
        /// <param name="businessObject">ResourceFiles object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ResourceFiles businessObject)
        {
            ResourceFilesDAL _dataObject = new ResourceFilesDAL();
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
        /// get ResourceFiles by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ResourceFiles GetByPrimaryKey(Guid keys)
        {
            ResourceFilesDAL _dataObject = new ResourceFilesDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ResourceFiless
        /// </summary>
        /// <returns>list</returns>
        public static List<ResourceFiles> GetAll(ResourceFiles obj)
        {
            ResourceFilesDAL _dataObject = new ResourceFilesDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ResourceFiless
        /// </summary>
        /// <returns>list</returns>
        public static List<ResourceFiles> GetAll()
        {
            ResourceFilesDAL _dataObject = new ResourceFilesDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ResourceFiles by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ResourceFiles> GetAllBy(ResourceFiles.ResourceFilesFields fieldName, object value)
        {
            ResourceFilesDAL _dataObject = new ResourceFilesDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ResourceFiless
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ResourceFiles obj)
        {
            ResourceFilesDAL _dataObject = new ResourceFilesDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ResourceFiless
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ResourceFilesDAL _dataObject = new ResourceFilesDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ResourceFiles by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ResourceFiles.ResourceFilesFields fieldName, object value)
        {
            ResourceFilesDAL _dataObject = new ResourceFilesDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ResourceFilesDAL _dataObject = new ResourceFilesDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ResourceFiles obj)
        {
            ResourceFilesDAL _dataObject = new ResourceFilesDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ResourceFiles by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ResourceFiles.ResourceFilesFields fieldName, object value)
        {
            ResourceFilesDAL _dataObject = new ResourceFilesDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
