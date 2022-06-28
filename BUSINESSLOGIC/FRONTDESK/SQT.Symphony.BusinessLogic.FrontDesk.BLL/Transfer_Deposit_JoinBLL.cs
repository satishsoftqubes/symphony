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
    public static class Transfer_Deposit_JoinBLL
    {

        //#region data Members

        //private static Transfer_Deposit_JoinDAL _dataObject = null;

        //#endregion

        #region Constructor

        static Transfer_Deposit_JoinBLL()
        {
            //_dataObject = new Transfer_Deposit_JoinDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Transfer_Deposit_Join
        /// </summary>
        /// <param name="businessObject">Transfer_Deposit_Join object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Transfer_Deposit_Join businessObject)
        {
            Transfer_Deposit_JoinDAL _dataObject = new Transfer_Deposit_JoinDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.DepositTransferID = Guid.NewGuid();
                    
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
        /// Update existing Transfer_Deposit_Join
        /// </summary>
        /// <param name="businessObject">Transfer_Deposit_Join object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Transfer_Deposit_Join businessObject)
        {
            Transfer_Deposit_JoinDAL _dataObject = new Transfer_Deposit_JoinDAL();
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
        /// get Transfer_Deposit_Join by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Transfer_Deposit_Join GetByPrimaryKey(Guid keys)
        {
            Transfer_Deposit_JoinDAL _dataObject = new Transfer_Deposit_JoinDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Transfer_Deposit_Joins
        /// </summary>
        /// <returns>list</returns>
        public static List<Transfer_Deposit_Join> GetAll(Transfer_Deposit_Join obj)
        {
            Transfer_Deposit_JoinDAL _dataObject = new Transfer_Deposit_JoinDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Transfer_Deposit_Joins
        /// </summary>
        /// <returns>list</returns>
        public static List<Transfer_Deposit_Join> GetAll()
        {
            Transfer_Deposit_JoinDAL _dataObject = new Transfer_Deposit_JoinDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Transfer_Deposit_Join by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Transfer_Deposit_Join> GetAllBy(Transfer_Deposit_Join.Transfer_Deposit_JoinFields fieldName, object value)
        {
            Transfer_Deposit_JoinDAL _dataObject = new Transfer_Deposit_JoinDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Transfer_Deposit_Joins
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Transfer_Deposit_Join obj)
        {
            Transfer_Deposit_JoinDAL _dataObject = new Transfer_Deposit_JoinDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Transfer_Deposit_Joins
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            Transfer_Deposit_JoinDAL _dataObject = new Transfer_Deposit_JoinDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Transfer_Deposit_Join by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Transfer_Deposit_Join.Transfer_Deposit_JoinFields fieldName, object value)
        {
            Transfer_Deposit_JoinDAL _dataObject = new Transfer_Deposit_JoinDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            Transfer_Deposit_JoinDAL _dataObject = new Transfer_Deposit_JoinDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Transfer_Deposit_Join obj)
        {
            Transfer_Deposit_JoinDAL _dataObject = new Transfer_Deposit_JoinDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Transfer_Deposit_Join by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Transfer_Deposit_Join.Transfer_Deposit_JoinFields fieldName, object value)
        {
            Transfer_Deposit_JoinDAL _dataObject = new Transfer_Deposit_JoinDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
