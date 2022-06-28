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
    public static class Agent_PaymentBLL
    {

        //#region data Members

        //private static Agent_PaymentDAL _dataObject = null;

        //#endregion

        #region Constructor

        static Agent_PaymentBLL()
        {
            //_dataObject = new Agent_PaymentDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Agent_Payment
        /// </summary>
        /// <param name="businessObject">Agent_Payment object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Agent_Payment businessObject)
        {
            Agent_PaymentDAL _dataObject = new Agent_PaymentDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.PaymentID = Guid.NewGuid();
                    
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
        /// Update existing Agent_Payment
        /// </summary>
        /// <param name="businessObject">Agent_Payment object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Agent_Payment businessObject)
        {
            Agent_PaymentDAL _dataObject = new Agent_PaymentDAL();
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
        /// get Agent_Payment by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Agent_Payment GetByPrimaryKey(Guid keys)
        {
            Agent_PaymentDAL _dataObject = new Agent_PaymentDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Agent_Payments
        /// </summary>
        /// <returns>list</returns>
        public static List<Agent_Payment> GetAll(Agent_Payment obj)
        {
            Agent_PaymentDAL _dataObject = new Agent_PaymentDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Agent_Payments
        /// </summary>
        /// <returns>list</returns>
        public static List<Agent_Payment> GetAll()
        {
            Agent_PaymentDAL _dataObject = new Agent_PaymentDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Agent_Payment by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Agent_Payment> GetAllBy(Agent_Payment.Agent_PaymentFields fieldName, object value)
        {
            Agent_PaymentDAL _dataObject = new Agent_PaymentDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Agent_Payments
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Agent_Payment obj)
        {
            Agent_PaymentDAL _dataObject = new Agent_PaymentDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Agent_Payments
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            Agent_PaymentDAL _dataObject = new Agent_PaymentDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Agent_Payment by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Agent_Payment.Agent_PaymentFields fieldName, object value)
        {
            Agent_PaymentDAL _dataObject = new Agent_PaymentDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            Agent_PaymentDAL _dataObject = new Agent_PaymentDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Agent_Payment obj)
        {
            Agent_PaymentDAL _dataObject = new Agent_PaymentDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Agent_Payment by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Agent_Payment.Agent_PaymentFields fieldName, object value)
        {
            Agent_PaymentDAL _dataObject = new Agent_PaymentDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
