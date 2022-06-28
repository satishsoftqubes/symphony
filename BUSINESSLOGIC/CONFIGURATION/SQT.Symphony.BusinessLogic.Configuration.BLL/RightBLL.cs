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
    public static class RightBLL
    {

        //#region data Members

        //private static RightDAL _dataObject = null;

        //#endregion

        #region Constructor

        static RightBLL()
        {
            //_dataObject = new RightDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Right
        /// </summary>
        /// <param name="businessObject">Right object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Right businessObject)
        {
            RightDAL _dataObject = new RightDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.RightID = Guid.NewGuid();
                    
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
        /// Update existing Right
        /// </summary>
        /// <param name="businessObject">Right object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Right businessObject)
        {
            RightDAL _dataObject = new RightDAL();
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
        /// get Right by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Right GetByPrimaryKey(Guid keys)
        {
            RightDAL _dataObject = new RightDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Rights
        /// </summary>
        /// <returns>list</returns>
        public static List<Right> GetAll(Right obj)
        {
            RightDAL _dataObject = new RightDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Rights
        /// </summary>
        /// <returns>list</returns>
        public static List<Right> GetAll()
        {
            RightDAL _dataObject = new RightDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Right by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Right> GetAllBy(Right.RightFields fieldName, object value)
        {
            RightDAL _dataObject = new RightDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Rights
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Right obj)
        {
            RightDAL _dataObject = new RightDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Rights
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            RightDAL _dataObject = new RightDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Right by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Right.RightFields fieldName, object value)
        {
            RightDAL _dataObject = new RightDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            RightDAL _dataObject = new RightDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Right obj)
        {
            RightDAL _dataObject = new RightDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Right by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Right.RightFields fieldName, object value)
        {
            RightDAL _dataObject = new RightDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
