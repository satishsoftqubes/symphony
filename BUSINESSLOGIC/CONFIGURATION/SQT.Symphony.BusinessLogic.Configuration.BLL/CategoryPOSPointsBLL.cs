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
    public static class CategoryPOSPointsBLL
    {

        //#region data Members

        //private static CategoryPOSPointsDAL _dataObject = null;

        //#endregion

        #region Constructor

        static CategoryPOSPointsBLL()
        {
            //_dataObject = new CategoryPOSPointsDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new CategoryPOSPoints
        /// </summary>
        /// <param name="businessObject">CategoryPOSPoints object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(CategoryPOSPoints businessObject)
        {
            CategoryPOSPointsDAL _dataObject = new CategoryPOSPointsDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.CategoryPOSPointID = Guid.NewGuid();
                    
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
        /// Update existing CategoryPOSPoints
        /// </summary>
        /// <param name="businessObject">CategoryPOSPoints object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(CategoryPOSPoints businessObject)
        {
            CategoryPOSPointsDAL _dataObject = new CategoryPOSPointsDAL();
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
        /// get CategoryPOSPoints by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static CategoryPOSPoints GetByPrimaryKey(Guid keys)
        {
            CategoryPOSPointsDAL _dataObject = new CategoryPOSPointsDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all CategoryPOSPointss
        /// </summary>
        /// <returns>list</returns>
        public static List<CategoryPOSPoints> GetAll(CategoryPOSPoints obj)
        {
            CategoryPOSPointsDAL _dataObject = new CategoryPOSPointsDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all CategoryPOSPointss
        /// </summary>
        /// <returns>list</returns>
        public static List<CategoryPOSPoints> GetAll()
        {
            CategoryPOSPointsDAL _dataObject = new CategoryPOSPointsDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of CategoryPOSPoints by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<CategoryPOSPoints> GetAllBy(CategoryPOSPoints.CategoryPOSPointsFields fieldName, object value)
        {
            CategoryPOSPointsDAL _dataObject = new CategoryPOSPointsDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all CategoryPOSPointss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(CategoryPOSPoints obj)
        {
            CategoryPOSPointsDAL _dataObject = new CategoryPOSPointsDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all CategoryPOSPointss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            CategoryPOSPointsDAL _dataObject = new CategoryPOSPointsDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of CategoryPOSPoints by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(CategoryPOSPoints.CategoryPOSPointsFields fieldName, object value)
        {
            CategoryPOSPointsDAL _dataObject = new CategoryPOSPointsDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            CategoryPOSPointsDAL _dataObject = new CategoryPOSPointsDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(CategoryPOSPoints obj)
        {
            CategoryPOSPointsDAL _dataObject = new CategoryPOSPointsDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete CategoryPOSPoints by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(CategoryPOSPoints.CategoryPOSPointsFields fieldName, object value)
        {
            CategoryPOSPointsDAL _dataObject = new CategoryPOSPointsDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
