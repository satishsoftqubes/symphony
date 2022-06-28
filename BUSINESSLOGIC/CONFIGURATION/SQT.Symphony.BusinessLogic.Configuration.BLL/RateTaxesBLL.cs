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
    public static class RateTaxesBLL
    {

        //#region data Members

        //private static RateTaxesDAL _dataObject = null;

        //#endregion

        #region Constructor

        static RateTaxesBLL()
        {
            //_dataObject = new RateTaxesDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new RateTaxes
        /// </summary>
        /// <param name="businessObject">RateTaxes object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(RateTaxes businessObject)
        {
            RateTaxesDAL _dataObject = new RateTaxesDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.RateTaxID = Guid.NewGuid();
                    
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
        /// Update existing RateTaxes
        /// </summary>
        /// <param name="businessObject">RateTaxes object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(RateTaxes businessObject)
        {
            RateTaxesDAL _dataObject = new RateTaxesDAL();
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
        /// get RateTaxes by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static RateTaxes GetByPrimaryKey(Guid keys)
        {
            RateTaxesDAL _dataObject = new RateTaxesDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all RateTaxess
        /// </summary>
        /// <returns>list</returns>
        public static List<RateTaxes> GetAll(RateTaxes obj)
        {
            RateTaxesDAL _dataObject = new RateTaxesDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all RateTaxess
        /// </summary>
        /// <returns>list</returns>
        public static List<RateTaxes> GetAll()
        {
            RateTaxesDAL _dataObject = new RateTaxesDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of RateTaxes by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<RateTaxes> GetAllBy(RateTaxes.RateTaxesFields fieldName, object value)
        {
            RateTaxesDAL _dataObject = new RateTaxesDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all RateTaxess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(RateTaxes obj)
        {
            RateTaxesDAL _dataObject = new RateTaxesDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all RateTaxess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            RateTaxesDAL _dataObject = new RateTaxesDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of RateTaxes by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(RateTaxes.RateTaxesFields fieldName, object value)
        {
            RateTaxesDAL _dataObject = new RateTaxesDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            RateTaxesDAL _dataObject = new RateTaxesDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(RateTaxes obj)
        {
            RateTaxesDAL _dataObject = new RateTaxesDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete RateTaxes by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(RateTaxes.RateTaxesFields fieldName, object value)
        {
            RateTaxesDAL _dataObject = new RateTaxesDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
