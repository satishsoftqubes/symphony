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
    public static class TaxSlabeBLL
    {

        //#region data Members

        //private static TaxSlabeDAL _dataObject = null;

        //#endregion

        #region Constructor

        static TaxSlabeBLL()
        {
            //_dataObject = new TaxSlabeDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new TaxSlabe
        /// </summary>
        /// <param name="businessObject">TaxSlabe object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(TaxSlabe businessObject)
        {
            TaxSlabeDAL _dataObject = new TaxSlabeDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.TaxSlabID = Guid.NewGuid();
                    
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
        /// Update existing TaxSlabe
        /// </summary>
        /// <param name="businessObject">TaxSlabe object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(TaxSlabe businessObject)
        {
            TaxSlabeDAL _dataObject = new TaxSlabeDAL();
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
        /// get TaxSlabe by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static TaxSlabe GetByPrimaryKey(Guid keys)
        {
            TaxSlabeDAL _dataObject = new TaxSlabeDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all TaxSlabes
        /// </summary>
        /// <returns>list</returns>
        public static List<TaxSlabe> GetAll(TaxSlabe obj)
        {
            TaxSlabeDAL _dataObject = new TaxSlabeDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all TaxSlabes
        /// </summary>
        /// <returns>list</returns>
        public static List<TaxSlabe> GetAll()
        {
            TaxSlabeDAL _dataObject = new TaxSlabeDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of TaxSlabe by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<TaxSlabe> GetAllBy(TaxSlabe.TaxSlabeFields fieldName, object value)
        {
            TaxSlabeDAL _dataObject = new TaxSlabeDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all TaxSlabes
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(TaxSlabe obj)
        {
            TaxSlabeDAL _dataObject = new TaxSlabeDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all TaxSlabes
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            TaxSlabeDAL _dataObject = new TaxSlabeDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of TaxSlabe by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(TaxSlabe.TaxSlabeFields fieldName, object value)
        {
            TaxSlabeDAL _dataObject = new TaxSlabeDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            TaxSlabeDAL _dataObject = new TaxSlabeDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(TaxSlabe obj)
        {
            TaxSlabeDAL _dataObject = new TaxSlabeDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete TaxSlabe by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(TaxSlabe.TaxSlabeFields fieldName, object value)
        {
            TaxSlabeDAL _dataObject = new TaxSlabeDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
