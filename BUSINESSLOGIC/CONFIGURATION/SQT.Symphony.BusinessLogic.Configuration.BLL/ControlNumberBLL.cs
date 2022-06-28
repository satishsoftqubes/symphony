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
    public static class ControlNumberBLL
    {

        //#region data Members

        //private static ControlNumberDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ControlNumberBLL()
        {
            //_dataObject = new ControlNumberDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ControlNumber
        /// </summary>
        /// <param name="businessObject">ControlNumber object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ControlNumber businessObject)
        {
            ControlNumberDAL _dataObject = new ControlNumberDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ControlNumberID = Guid.NewGuid();
                    
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
        /// Update existing ControlNumber
        /// </summary>
        /// <param name="businessObject">ControlNumber object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ControlNumber businessObject)
        {
            ControlNumberDAL _dataObject = new ControlNumberDAL();
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
        /// get ControlNumber by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ControlNumber GetByPrimaryKey(Guid keys)
        {
            ControlNumberDAL _dataObject = new ControlNumberDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ControlNumbers
        /// </summary>
        /// <returns>list</returns>
        public static List<ControlNumber> GetAll(ControlNumber obj)
        {
            ControlNumberDAL _dataObject = new ControlNumberDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ControlNumbers
        /// </summary>
        /// <returns>list</returns>
        public static List<ControlNumber> GetAll()
        {
            ControlNumberDAL _dataObject = new ControlNumberDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ControlNumber by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ControlNumber> GetAllBy(ControlNumber.ControlNumberFields fieldName, object value)
        {
            ControlNumberDAL _dataObject = new ControlNumberDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ControlNumbers
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ControlNumber obj)
        {
            ControlNumberDAL _dataObject = new ControlNumberDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ControlNumbers
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ControlNumberDAL _dataObject = new ControlNumberDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ControlNumber by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ControlNumber.ControlNumberFields fieldName, object value)
        {
            ControlNumberDAL _dataObject = new ControlNumberDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ControlNumberDAL _dataObject = new ControlNumberDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ControlNumber obj)
        {
            ControlNumberDAL _dataObject = new ControlNumberDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ControlNumber by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ControlNumber.ControlNumberFields fieldName, object value)
        {
            ControlNumberDAL _dataObject = new ControlNumberDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
