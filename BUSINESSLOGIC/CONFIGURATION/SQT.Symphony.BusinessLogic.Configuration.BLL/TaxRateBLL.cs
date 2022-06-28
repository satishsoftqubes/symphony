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
    public static class TaxRateBLL
    {

        //#region data Members

        //private static TaxRateDAL _dataObject = null;

        //#endregion

        #region Constructor

        static TaxRateBLL()
        {
            //_dataObject = new TaxRateDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new TaxRate
        /// </summary>
        /// <param name="businessObject">TaxRate object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(TaxRate businessObject)
        {
            TaxRateDAL _dataObject = new TaxRateDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
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
        /// Update existing TaxRate
        /// </summary>
        /// <param name="businessObject">TaxRate object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(TaxRate businessObject)
        {
            TaxRateDAL _dataObject = new TaxRateDAL();
            try
            {
                if (businessObject != null)
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
        /// get TaxRate by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static TaxRate GetByPrimaryKey(Guid keys)
        {
            TaxRateDAL _dataObject = new TaxRateDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all TaxRates
        /// </summary>
        /// <returns>list</returns>
        public static List<TaxRate> GetAll(TaxRate obj)
        {
            TaxRateDAL _dataObject = new TaxRateDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all TaxRates
        /// </summary>
        /// <returns>list</returns>
        public static List<TaxRate> GetAll()
        {
            TaxRateDAL _dataObject = new TaxRateDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of TaxRate by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<TaxRate> GetAllBy(TaxRate.TaxRateFields fieldName, object value)
        {
            TaxRateDAL _dataObject = new TaxRateDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all TaxRates
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(TaxRate obj)
        {
            TaxRateDAL _dataObject = new TaxRateDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all TaxRates
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            TaxRateDAL _dataObject = new TaxRateDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of TaxRate by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(TaxRate.TaxRateFields fieldName, object value)
        {
            TaxRateDAL _dataObject = new TaxRateDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            TaxRateDAL _dataObject = new TaxRateDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(TaxRate obj)
        {
            TaxRateDAL _dataObject = new TaxRateDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete TaxRate by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(TaxRate.TaxRateFields fieldName, object value)
        {
            TaxRateDAL _dataObject = new TaxRateDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet SelectAllDataByTaxID(Guid? TaxID)
        {
            TaxRateDAL _dataObject = new TaxRateDAL();
            return _dataObject.SelectAllDataByTaxID(TaxID);
        }

        #endregion

    }
}
