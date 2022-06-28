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
    public static class ExchangeRateBLL
    {

        //#region data Members

        //private static ExchangeRateDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ExchangeRateBLL()
        {
            //_dataObject = new ExchangeRateDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ExchangeRate
        /// </summary>
        /// <param name="businessObject">ExchangeRate object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ExchangeRate businessObject)
        {
            ExchangeRateDAL _dataObject = new ExchangeRateDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ExchangeRateID = Guid.NewGuid();
                    
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
        /// Update existing ExchangeRate
        /// </summary>
        /// <param name="businessObject">ExchangeRate object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ExchangeRate businessObject)
        {
            ExchangeRateDAL _dataObject = new ExchangeRateDAL();
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
        /// get ExchangeRate by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ExchangeRate GetByPrimaryKey(Guid keys)
        {
            ExchangeRateDAL _dataObject = new ExchangeRateDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ExchangeRates
        /// </summary>
        /// <returns>list</returns>
        public static List<ExchangeRate> GetAll(ExchangeRate obj)
        {
            ExchangeRateDAL _dataObject = new ExchangeRateDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ExchangeRates
        /// </summary>
        /// <returns>list</returns>
        public static List<ExchangeRate> GetAll()
        {
            ExchangeRateDAL _dataObject = new ExchangeRateDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ExchangeRate by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ExchangeRate> GetAllBy(ExchangeRate.ExchangeRateFields fieldName, object value)
        {
            ExchangeRateDAL _dataObject = new ExchangeRateDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ExchangeRates
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ExchangeRate obj)
        {
            ExchangeRateDAL _dataObject = new ExchangeRateDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ExchangeRates
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ExchangeRateDAL _dataObject = new ExchangeRateDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ExchangeRate by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ExchangeRate.ExchangeRateFields fieldName, object value)
        {
            ExchangeRateDAL _dataObject = new ExchangeRateDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ExchangeRateDAL _dataObject = new ExchangeRateDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ExchangeRate obj)
        {
            ExchangeRateDAL _dataObject = new ExchangeRateDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ExchangeRate by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ExchangeRate.ExchangeRateFields fieldName, object value)
        {
            ExchangeRateDAL _dataObject = new ExchangeRateDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }
        public static DataSet SearchData(Guid? PropertyID, Guid? CompanyID, Guid? SourceCurrencyID, Guid? DesignationCurrencyID)
        {
            ExchangeRateDAL _Obj = new ExchangeRateDAL();
            return _Obj.SearchData(CompanyID, PropertyID, SourceCurrencyID, DesignationCurrencyID);
        }
        #endregion

    }
}
