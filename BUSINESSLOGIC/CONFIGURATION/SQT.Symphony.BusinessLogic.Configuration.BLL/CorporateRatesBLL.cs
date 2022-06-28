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
    public static class CorporateRatesBLL
    {

        //#region data Members

        //private static CorporateRatesDAL _dataObject = null;

        //#endregion

        #region Constructor

        static CorporateRatesBLL()
        {
            //_dataObject = new CorporateRatesDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new CorporateRates
        /// </summary>
        /// <param name="businessObject">CorporateRates object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(CorporateRates businessObject)
        {
            CorporateRatesDAL _dataObject = new CorporateRatesDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.CorporateRateID = Guid.NewGuid();
                    
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
        /// Update existing CorporateRates
        /// </summary>
        /// <param name="businessObject">CorporateRates object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(CorporateRates businessObject)
        {
            CorporateRatesDAL _dataObject = new CorporateRatesDAL();
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
        /// get CorporateRates by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static CorporateRates GetByPrimaryKey(Guid keys)
        {
            CorporateRatesDAL _dataObject = new CorporateRatesDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all CorporateRatess
        /// </summary>
        /// <returns>list</returns>
        public static List<CorporateRates> GetAll(CorporateRates obj)
        {
            CorporateRatesDAL _dataObject = new CorporateRatesDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all CorporateRatess
        /// </summary>
        /// <returns>list</returns>
        public static List<CorporateRates> GetAll()
        {
            CorporateRatesDAL _dataObject = new CorporateRatesDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of CorporateRates by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<CorporateRates> GetAllBy(CorporateRates.CorporateRatesFields fieldName, object value)
        {
            CorporateRatesDAL _dataObject = new CorporateRatesDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all CorporateRatess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(CorporateRates obj)
        {
            CorporateRatesDAL _dataObject = new CorporateRatesDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all CorporateRatess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            CorporateRatesDAL _dataObject = new CorporateRatesDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of CorporateRates by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(CorporateRates.CorporateRatesFields fieldName, object value)
        {
            CorporateRatesDAL _dataObject = new CorporateRatesDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            CorporateRatesDAL _dataObject = new CorporateRatesDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(CorporateRates obj)
        {
            CorporateRatesDAL _dataObject = new CorporateRatesDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete CorporateRates by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(CorporateRates.CorporateRatesFields fieldName, object value)
        {
            CorporateRatesDAL _dataObject = new CorporateRatesDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
