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
    public static class CountryBLL
    {

        //#region data Members

        //private static CountryDAL _dataObject = null;

        //#endregion

        #region Constructor

        static CountryBLL()
        {
            //_dataObject = new CountryDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Country
        /// </summary>
        /// <param name="businessObject">Country object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Country businessObject)
        {
            CountryDAL _dataObject = new CountryDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.CountryID = Guid.NewGuid();
                    
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
        /// Update existing Country
        /// </summary>
        /// <param name="businessObject">Country object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Country businessObject)
        {
            CountryDAL _dataObject = new CountryDAL();
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
        /// get Country by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Country GetByPrimaryKey(Guid keys)
        {
            CountryDAL _dataObject = new CountryDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Countrys
        /// </summary>
        /// <returns>list</returns>
        public static List<Country> GetAll(Country obj)
        {
            CountryDAL _dataObject = new CountryDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Countrys
        /// </summary>
        /// <returns>list</returns>
        public static List<Country> GetAll()
        {
            CountryDAL _dataObject = new CountryDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Country by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Country> GetAllBy(Country.CountryFields fieldName, object value)
        {
            CountryDAL _dataObject = new CountryDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Countrys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Country obj)
        {
            CountryDAL _dataObject = new CountryDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Countrys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            CountryDAL _dataObject = new CountryDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Country by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Country.CountryFields fieldName, object value)
        {
            CountryDAL _dataObject = new CountryDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            CountryDAL _dataObject = new CountryDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Country obj)
        {
            CountryDAL _dataObject = new CountryDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Country by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Country.CountryFields fieldName, object value)
        {
            CountryDAL _dataObject = new CountryDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}