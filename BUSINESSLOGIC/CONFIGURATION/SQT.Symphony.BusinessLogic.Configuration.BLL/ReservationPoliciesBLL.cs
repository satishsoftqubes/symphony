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
    public static class ReservationPoliciesBLL
    {

        //#region data Members

        //private static ReservationPoliciesDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ReservationPoliciesBLL()
        {
            //_dataObject = new ReservationPoliciesDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ReservationPolicies
        /// </summary>
        /// <param name="businessObject">ReservationPolicies object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ReservationPolicies businessObject)
        {
            ReservationPoliciesDAL _dataObject = new ReservationPoliciesDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ResPolicyID = Guid.NewGuid();
                    
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
        /// Update existing ReservationPolicies
        /// </summary>
        /// <param name="businessObject">ReservationPolicies object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ReservationPolicies businessObject)
        {
            ReservationPoliciesDAL _dataObject = new ReservationPoliciesDAL();
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
        /// get ReservationPolicies by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ReservationPolicies GetByPrimaryKey(Guid keys)
        {
            ReservationPoliciesDAL _dataObject = new ReservationPoliciesDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ReservationPoliciess
        /// </summary>
        /// <returns>list</returns>
        public static List<ReservationPolicies> GetAll(ReservationPolicies obj)
        {
            ReservationPoliciesDAL _dataObject = new ReservationPoliciesDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ReservationPoliciess
        /// </summary>
        /// <returns>list</returns>
        public static List<ReservationPolicies> GetAll()
        {
            ReservationPoliciesDAL _dataObject = new ReservationPoliciesDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ReservationPolicies by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ReservationPolicies> GetAllBy(ReservationPolicies.ReservationPoliciesFields fieldName, object value)
        {
            ReservationPoliciesDAL _dataObject = new ReservationPoliciesDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ReservationPoliciess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ReservationPolicies obj)
        {
            ReservationPoliciesDAL _dataObject = new ReservationPoliciesDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ReservationPoliciess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ReservationPoliciesDAL _dataObject = new ReservationPoliciesDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ReservationPolicies by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ReservationPolicies.ReservationPoliciesFields fieldName, object value)
        {
            ReservationPoliciesDAL _dataObject = new ReservationPoliciesDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ReservationPoliciesDAL _dataObject = new ReservationPoliciesDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ReservationPolicies obj)
        {
            ReservationPoliciesDAL _dataObject = new ReservationPoliciesDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ReservationPolicies by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ReservationPolicies.ReservationPoliciesFields fieldName, object value)
        {
            ReservationPoliciesDAL _dataObject = new ReservationPoliciesDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
