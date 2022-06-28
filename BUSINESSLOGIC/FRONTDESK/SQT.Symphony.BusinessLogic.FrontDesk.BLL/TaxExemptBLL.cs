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
    public static class TaxExemptBLL
    {

        //#region data Members

        //private static TaxExemptDAL _dataObject = null;

        //#endregion

        #region Constructor

        static TaxExemptBLL()
        {
            //_dataObject = new TaxExemptDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new TaxExempt
        /// </summary>
        /// <param name="businessObject">TaxExempt object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(TaxExempt businessObject)
        {
            TaxExemptDAL _dataObject = new TaxExemptDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.TaxExemptID = Guid.NewGuid();
                    
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
        /// Update existing TaxExempt
        /// </summary>
        /// <param name="businessObject">TaxExempt object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(TaxExempt businessObject)
        {
            TaxExemptDAL _dataObject = new TaxExemptDAL();
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
        /// get TaxExempt by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static TaxExempt GetByPrimaryKey(Guid keys)
        {
            TaxExemptDAL _dataObject = new TaxExemptDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all TaxExempts
        /// </summary>
        /// <returns>list</returns>
        public static List<TaxExempt> GetAll(TaxExempt obj)
        {
            TaxExemptDAL _dataObject = new TaxExemptDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all TaxExempts
        /// </summary>
        /// <returns>list</returns>
        public static List<TaxExempt> GetAll()
        {
            TaxExemptDAL _dataObject = new TaxExemptDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of TaxExempt by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<TaxExempt> GetAllBy(TaxExempt.TaxExemptFields fieldName, object value)
        {
            TaxExemptDAL _dataObject = new TaxExemptDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all TaxExempts
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(TaxExempt obj)
        {
            TaxExemptDAL _dataObject = new TaxExemptDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all TaxExempts
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            TaxExemptDAL _dataObject = new TaxExemptDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of TaxExempt by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(TaxExempt.TaxExemptFields fieldName, object value)
        {
            TaxExemptDAL _dataObject = new TaxExemptDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            TaxExemptDAL _dataObject = new TaxExemptDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(TaxExempt obj)
        {
            TaxExemptDAL _dataObject = new TaxExemptDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete TaxExempt by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(TaxExempt.TaxExemptFields fieldName, object value)
        {
            TaxExemptDAL _dataObject = new TaxExemptDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
