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
    public static class Agent_ReceiptBLL
    {

        //#region data Members

        //private static Agent_ReceiptDAL _dataObject = null;

        //#endregion

        #region Constructor

        static Agent_ReceiptBLL()
        {
            //_dataObject = new Agent_ReceiptDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Agent_Receipt
        /// </summary>
        /// <param name="businessObject">Agent_Receipt object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Agent_Receipt businessObject)
        {
            Agent_ReceiptDAL _dataObject = new Agent_ReceiptDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ReceiptID = Guid.NewGuid();
                    
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
        /// Update existing Agent_Receipt
        /// </summary>
        /// <param name="businessObject">Agent_Receipt object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Agent_Receipt businessObject)
        {
            Agent_ReceiptDAL _dataObject = new Agent_ReceiptDAL();
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
        /// get Agent_Receipt by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Agent_Receipt GetByPrimaryKey(Guid keys)
        {
            Agent_ReceiptDAL _dataObject = new Agent_ReceiptDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Agent_Receipts
        /// </summary>
        /// <returns>list</returns>
        public static List<Agent_Receipt> GetAll(Agent_Receipt obj)
        {
            Agent_ReceiptDAL _dataObject = new Agent_ReceiptDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Agent_Receipts
        /// </summary>
        /// <returns>list</returns>
        public static List<Agent_Receipt> GetAll()
        {
            Agent_ReceiptDAL _dataObject = new Agent_ReceiptDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Agent_Receipt by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Agent_Receipt> GetAllBy(Agent_Receipt.Agent_ReceiptFields fieldName, object value)
        {
            Agent_ReceiptDAL _dataObject = new Agent_ReceiptDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Agent_Receipts
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Agent_Receipt obj)
        {
            Agent_ReceiptDAL _dataObject = new Agent_ReceiptDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Agent_Receipts
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            Agent_ReceiptDAL _dataObject = new Agent_ReceiptDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Agent_Receipt by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Agent_Receipt.Agent_ReceiptFields fieldName, object value)
        {
            Agent_ReceiptDAL _dataObject = new Agent_ReceiptDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            Agent_ReceiptDAL _dataObject = new Agent_ReceiptDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Agent_Receipt obj)
        {
            Agent_ReceiptDAL _dataObject = new Agent_ReceiptDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Agent_Receipt by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Agent_Receipt.Agent_ReceiptFields fieldName, object value)
        {
            Agent_ReceiptDAL _dataObject = new Agent_ReceiptDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
