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
    public static class AccountGroupBLL
    {

        //#region data Members

        //private static AccountGroupDAL _dataObject = null;

        //#endregion

        #region Constructor

        static AccountGroupBLL()
        {
            //_dataObject = new AccountGroupDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new AccountGroup
        /// </summary>
        /// <param name="businessObject">AccountGroup object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(AccountGroup businessObject)
        {
            AccountGroupDAL _dataObject = new AccountGroupDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.AcctGrpID = Guid.NewGuid();
                    
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
        /// Update existing AccountGroup
        /// </summary>
        /// <param name="businessObject">AccountGroup object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(AccountGroup businessObject)
        {
            AccountGroupDAL _dataObject = new AccountGroupDAL();
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
        /// get AccountGroup by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static AccountGroup GetByPrimaryKey(Guid keys)
        {
            AccountGroupDAL _dataObject = new AccountGroupDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all AccountGroups
        /// </summary>
        /// <returns>list</returns>
        public static List<AccountGroup> GetAll(AccountGroup obj)
        {
            AccountGroupDAL _dataObject = new AccountGroupDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all AccountGroups
        /// </summary>
        /// <returns>list</returns>
        public static List<AccountGroup> GetAll()
        {
            AccountGroupDAL _dataObject = new AccountGroupDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of AccountGroup by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<AccountGroup> GetAllBy(AccountGroup.AccountGroupFields fieldName, object value)
        {
            AccountGroupDAL _dataObject = new AccountGroupDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all AccountGroups
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(AccountGroup obj)
        {
            AccountGroupDAL _dataObject = new AccountGroupDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all AccountGroups
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            AccountGroupDAL _dataObject = new AccountGroupDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of AccountGroup by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(AccountGroup.AccountGroupFields fieldName, object value)
        {
            AccountGroupDAL _dataObject = new AccountGroupDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            AccountGroupDAL _dataObject = new AccountGroupDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(AccountGroup obj)
        {
            AccountGroupDAL _dataObject = new AccountGroupDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete AccountGroup by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(AccountGroup.AccountGroupFields fieldName, object value)
        {
            AccountGroupDAL _dataObject = new AccountGroupDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
