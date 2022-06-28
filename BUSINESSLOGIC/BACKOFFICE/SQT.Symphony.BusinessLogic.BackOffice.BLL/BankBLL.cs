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
using SQT.Symphony.BusinessLogic.BackOffice.DTO;
using SQT.Symphony.BusinessLogic.BackOffice.DAL;

namespace SQT.Symphony.BusinessLogic.BackOffice.BLL
{
    public static class BankBLL
    {

        //#region data Members

        //private static BankDAL _dataObject = null;

        //#endregion

        #region Constructor

        static BankBLL()
        {
            //_dataObject = new BankDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Bank
        /// </summary>
        /// <param name="businessObject">Bank object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Bank businessObject)
        {
            BankDAL _dataObject = new BankDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.BankID = Guid.NewGuid();
                    
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
        /// Update existing Bank
        /// </summary>
        /// <param name="businessObject">Bank object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Bank businessObject)
        {
            BankDAL _dataObject = new BankDAL();
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
        /// get Bank by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Bank GetByPrimaryKey(Guid keys)
        {
            BankDAL _dataObject = new BankDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Banks
        /// </summary>
        /// <returns>list</returns>
        public static List<Bank> GetAll(Bank obj)
        {
            BankDAL _dataObject = new BankDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Banks
        /// </summary>
        /// <returns>list</returns>
        public static List<Bank> GetAll()
        {
            BankDAL _dataObject = new BankDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Bank by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Bank> GetAllBy(Bank.BankFields fieldName, object value)
        {
            BankDAL _dataObject = new BankDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Banks
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Bank obj)
        {
            BankDAL _dataObject = new BankDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Banks
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            BankDAL _dataObject = new BankDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Bank by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Bank.BankFields fieldName, object value)
        {
            BankDAL _dataObject = new BankDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            BankDAL _dataObject = new BankDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Bank obj)
        {
            BankDAL _dataObject = new BankDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Bank by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Bank.BankFields fieldName, object value)
        {
            BankDAL _dataObject = new BankDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
