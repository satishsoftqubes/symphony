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
    public static class ConfConferenceTypeBLL
    {

        //#region data Members

        //private static ConfConferenceTypeDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ConfConferenceTypeBLL()
        {
            //_dataObject = new ConfConferenceTypeDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ConfConferenceType
        /// </summary>
        /// <param name="businessObject">ConfConferenceType object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ConfConferenceType businessObject)
        {
            ConfConferenceTypeDAL _dataObject = new ConfConferenceTypeDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ConfConferenceTypeID = Guid.NewGuid();
                    
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
        /// Update existing ConfConferenceType
        /// </summary>
        /// <param name="businessObject">ConfConferenceType object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ConfConferenceType businessObject)
        {
            ConfConferenceTypeDAL _dataObject = new ConfConferenceTypeDAL();
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
        /// get ConfConferenceType by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ConfConferenceType GetByPrimaryKey(Guid keys)
        {
            ConfConferenceTypeDAL _dataObject = new ConfConferenceTypeDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ConfConferenceTypes
        /// </summary>
        /// <returns>list</returns>
        public static List<ConfConferenceType> GetAll(ConfConferenceType obj)
        {
            ConfConferenceTypeDAL _dataObject = new ConfConferenceTypeDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ConfConferenceTypes
        /// </summary>
        /// <returns>list</returns>
        public static List<ConfConferenceType> GetAll()
        {
            ConfConferenceTypeDAL _dataObject = new ConfConferenceTypeDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ConfConferenceType by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ConfConferenceType> GetAllBy(ConfConferenceType.ConfConferenceTypeFields fieldName, object value)
        {
            ConfConferenceTypeDAL _dataObject = new ConfConferenceTypeDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ConfConferenceTypes
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ConfConferenceType obj)
        {
            ConfConferenceTypeDAL _dataObject = new ConfConferenceTypeDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ConfConferenceTypes
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ConfConferenceTypeDAL _dataObject = new ConfConferenceTypeDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ConfConferenceType by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ConfConferenceType.ConfConferenceTypeFields fieldName, object value)
        {
            ConfConferenceTypeDAL _dataObject = new ConfConferenceTypeDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ConfConferenceTypeDAL _dataObject = new ConfConferenceTypeDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ConfConferenceType obj)
        {
            ConfConferenceTypeDAL _dataObject = new ConfConferenceTypeDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ConfConferenceType by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ConfConferenceType.ConfConferenceTypeFields fieldName, object value)
        {
            ConfConferenceTypeDAL _dataObject = new ConfConferenceTypeDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
