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
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.DAL;

namespace SQT.Symphony.BusinessLogic.FrontDesk.BLL
{
    public static class TaxExemptValueBLL
    {

        //#region data Members

        //private static TaxExemptValueDAL _dataObject = null;

        //#endregion

        #region Constructor

        static TaxExemptValueBLL()
        {
            //_dataObject = new TaxExemptValueDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new TaxExemptValue
        /// </summary>
        /// <param name="businessObject">TaxExemptValue object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(TaxExemptValue businessObject)
        {
            TaxExemptValueDAL _dataObject = new TaxExemptValueDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.TaxExemptValueID = Guid.NewGuid();
                    
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
        /// Update existing TaxExemptValue
        /// </summary>
        /// <param name="businessObject">TaxExemptValue object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(TaxExemptValue businessObject)
        {
            TaxExemptValueDAL _dataObject = new TaxExemptValueDAL();
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
        /// get TaxExemptValue by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static TaxExemptValue GetByPrimaryKey(Guid keys)
        {
            TaxExemptValueDAL _dataObject = new TaxExemptValueDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all TaxExemptValues
        /// </summary>
        /// <returns>list</returns>
        public static List<TaxExemptValue> GetAll(TaxExemptValue obj)
        {
            TaxExemptValueDAL _dataObject = new TaxExemptValueDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all TaxExemptValues
        /// </summary>
        /// <returns>list</returns>
        public static List<TaxExemptValue> GetAll()
        {
            TaxExemptValueDAL _dataObject = new TaxExemptValueDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of TaxExemptValue by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<TaxExemptValue> GetAllBy(TaxExemptValue.TaxExemptValueFields fieldName, object value)
        {
            TaxExemptValueDAL _dataObject = new TaxExemptValueDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all TaxExemptValues
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(TaxExemptValue obj)
        {
            TaxExemptValueDAL _dataObject = new TaxExemptValueDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all TaxExemptValues
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            TaxExemptValueDAL _dataObject = new TaxExemptValueDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of TaxExemptValue by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(TaxExemptValue.TaxExemptValueFields fieldName, object value)
        {
            TaxExemptValueDAL _dataObject = new TaxExemptValueDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            TaxExemptValueDAL _dataObject = new TaxExemptValueDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(TaxExemptValue obj)
        {
            TaxExemptValueDAL _dataObject = new TaxExemptValueDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete TaxExemptValue by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(TaxExemptValue.TaxExemptValueFields fieldName, object value)
        {
            TaxExemptValueDAL _dataObject = new TaxExemptValueDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
