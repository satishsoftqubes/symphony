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
    public static class ResCancellationPolicyBLL
    {

        //#region data Members

        //private static ResCancellationPolicyDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ResCancellationPolicyBLL()
        {
            //_dataObject = new ResCancellationPolicyDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ResCancellationPolicy
        /// </summary>
        /// <param name="businessObject">ResCancellationPolicy object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ResCancellationPolicy businessObject)
        {
            ResCancellationPolicyDAL _dataObject = new ResCancellationPolicyDAL();
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
        /// Update existing ResCancellationPolicy
        /// </summary>
        /// <param name="businessObject">ResCancellationPolicy object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ResCancellationPolicy businessObject)
        {
            ResCancellationPolicyDAL _dataObject = new ResCancellationPolicyDAL();
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
        /// get ResCancellationPolicy by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ResCancellationPolicy GetByPrimaryKey(Guid keys)
        {
            ResCancellationPolicyDAL _dataObject = new ResCancellationPolicyDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ResCancellationPolicys
        /// </summary>
        /// <returns>list</returns>
        public static List<ResCancellationPolicy> GetAll(ResCancellationPolicy obj)
        {
            ResCancellationPolicyDAL _dataObject = new ResCancellationPolicyDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ResCancellationPolicys
        /// </summary>
        /// <returns>list</returns>
        public static List<ResCancellationPolicy> GetAll()
        {
            ResCancellationPolicyDAL _dataObject = new ResCancellationPolicyDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ResCancellationPolicy by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ResCancellationPolicy> GetAllBy(ResCancellationPolicy.ResCancellationPolicyFields fieldName, object value)
        {
            ResCancellationPolicyDAL _dataObject = new ResCancellationPolicyDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ResCancellationPolicys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ResCancellationPolicy obj)
        {
            ResCancellationPolicyDAL _dataObject = new ResCancellationPolicyDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ResCancellationPolicys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ResCancellationPolicyDAL _dataObject = new ResCancellationPolicyDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ResCancellationPolicy by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ResCancellationPolicy.ResCancellationPolicyFields fieldName, object value)
        {
            ResCancellationPolicyDAL _dataObject = new ResCancellationPolicyDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ResCancellationPolicyDAL _dataObject = new ResCancellationPolicyDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ResCancellationPolicy obj)
        {
            ResCancellationPolicyDAL _dataObject = new ResCancellationPolicyDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ResCancellationPolicy by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ResCancellationPolicy.ResCancellationPolicyFields fieldName, object value)
        {
            ResCancellationPolicyDAL _dataObject = new ResCancellationPolicyDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet SearchCancellationPoliycData(Guid? CompanyID, Guid? PropertyID, Guid? ResType_TermID, Guid? ChargesApply_TermID)
        {
            ResCancellationPolicyDAL _Obj = new ResCancellationPolicyDAL();
            return _Obj.SearchCancellationPoliycData(CompanyID, PropertyID, ResType_TermID, ChargesApply_TermID);
        }

        #endregion

    }
}
