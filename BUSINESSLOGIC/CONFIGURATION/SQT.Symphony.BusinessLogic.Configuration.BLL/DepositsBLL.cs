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
    public static class DepositsBLL
    {

        //#region data Members

        //private static DepositsDAL _dataObject = null;

        //#endregion

        #region Constructor

        static DepositsBLL()
        {
            //_dataObject = new DepositsDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Deposits
        /// </summary>
        /// <param name="businessObject">Deposits object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Deposits businessObject)
        {
            DepositsDAL _dataObject = new DepositsDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.DepositID = Guid.NewGuid();
                    
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
        /// Update existing Deposits
        /// </summary>
        /// <param name="businessObject">Deposits object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Deposits businessObject)
        {
            DepositsDAL _dataObject = new DepositsDAL();
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
        /// get Deposits by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Deposits GetByPrimaryKey(Guid keys)
        {
            DepositsDAL _dataObject = new DepositsDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Depositss
        /// </summary>
        /// <returns>list</returns>
        public static List<Deposits> GetAll(Deposits obj)
        {
            DepositsDAL _dataObject = new DepositsDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Depositss
        /// </summary>
        /// <returns>list</returns>
        public static List<Deposits> GetAll()
        {
            DepositsDAL _dataObject = new DepositsDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Deposits by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Deposits> GetAllBy(Deposits.DepositsFields fieldName, object value)
        {
            DepositsDAL _dataObject = new DepositsDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Depositss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Deposits obj)
        {
            DepositsDAL _dataObject = new DepositsDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Depositss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            DepositsDAL _dataObject = new DepositsDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Deposits by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Deposits.DepositsFields fieldName, object value)
        {
            DepositsDAL _dataObject = new DepositsDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            DepositsDAL _dataObject = new DepositsDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Deposits obj)
        {
            DepositsDAL _dataObject = new DepositsDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Deposits by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Deposits.DepositsFields fieldName, object value)
        {
            DepositsDAL _dataObject = new DepositsDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static List<Deposits> GetAllSearchData(Deposits obj)
        {
            DepositsDAL _dataObject = new DepositsDAL();
            return _dataObject.SelectAllSearchData(obj);
        }

        #endregion

    }
}
