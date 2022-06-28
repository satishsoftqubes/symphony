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
    public static class AccountBLL
    {

        //#region data Members

        //private static AccountDAL _dataObject = null;

        //#endregion

        #region Constructor

        static AccountBLL()
        {
            //_dataObject = new AccountDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Account
        /// </summary>
        /// <param name="businessObject">Account object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Account businessObject)
        {
            AccountDAL _dataObject = new AccountDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.AcctID = Guid.NewGuid();
                    
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
        /// Update existing Account
        /// </summary>
        /// <param name="businessObject">Account object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Account businessObject)
        {
            AccountDAL _dataObject = new AccountDAL();
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
        /// get Account by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Account GetByPrimaryKey(Guid keys)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Accounts
        /// </summary>
        /// <returns>list</returns>
        public static List<Account> GetAll(Account obj)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SelectAll(obj); 
        }

        public static DataSet GetAllDataSet(Guid? AcctID, Guid? PropertyID, Guid? CompanyID, Guid? AcctGroupID, string AcctNo, string AcctName)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SelectAllDataSet(AcctID, PropertyID, CompanyID, AcctGroupID, AcctNo, AcctName);
        }

        public static DataSet GetRPTLedgerStatement(Guid AcctID, Guid? PropertyID, Guid? CompanyID, Guid? UserID, Guid? CounterID, Guid? AuditID, Guid? CloseID, DateTime? StartDate, DateTime? EndDate)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SelectRPTLedgerStatement(AcctID, PropertyID, CompanyID, UserID, CounterID, AuditID, CloseID, StartDate, EndDate);
        }

        public static DataSet GetAllAccountsInGroup(Guid? AcctGrpID)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SelectAllInGroup(AcctGrpID);
        }
        /// <summary>
        /// get list of all Accounts
        /// </summary>
        /// <returns>list</returns>
        public static List<Account> GetAll()
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Account by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Account> GetAllBy(Account.AccountFields fieldName, object value)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Accounts
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Account obj)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Accounts
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Account by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Account.AccountFields fieldName, object value)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Account obj)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Account by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Account.AccountFields fieldName, object value)
        {
            AccountDAL _dataObject = new AccountDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
