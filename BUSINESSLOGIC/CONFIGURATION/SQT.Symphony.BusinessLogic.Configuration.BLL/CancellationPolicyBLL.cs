using System;
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
using System.Data;

namespace SQT.Symphony.BusinessLogic.Configuration.BLL
{
    public static class CancellationPolicyBLL
    {

        //#region data Members

        //private static CancellationPolicyDAL _dataObject = null;

        //#endregion

        #region Constructor

        static CancellationPolicyBLL()
        {
            //_dataObject = new CancellationPolicyDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new CancellationPolicy
        /// </summary>
        /// <param name="businessObject">CancellationPolicy object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(CancellationPolicy businessObject)
        {
            CancellationPolicyDAL _dataObject = new CancellationPolicyDAL();
            try
            {
                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    businessObject.PolicyID = Guid.NewGuid();

                    if (!businessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                    }
                    return _dataObject.Insert(businessObject);
                    //}
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
        /// Update existing CancellationPolicy
        /// </summary>
        /// <param name="businessObject">CancellationPolicy object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(CancellationPolicy businessObject)
        {
            CancellationPolicyDAL _dataObject = new CancellationPolicyDAL();
            try
            {
                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    if (!businessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                    }
                    return _dataObject.Update(businessObject);
                    //}
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
        /// get CancellationPolicy by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static CancellationPolicy GetByPrimaryKey(Guid keys)
        {
            CancellationPolicyDAL _dataObject = new CancellationPolicyDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all CancellationPolicys
        /// </summary>
        /// <returns>list</returns>
        public static List<CancellationPolicy> GetAll(CancellationPolicy obj)
        {
            CancellationPolicyDAL _dataObject = new CancellationPolicyDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all CancellationPolicys
        /// </summary>
        /// <returns>list</returns>
        public static List<CancellationPolicy> GetAll()
        {
            CancellationPolicyDAL _dataObject = new CancellationPolicyDAL();
            return _dataObject.SelectAll();
        }



        public static DataSet GetAllWithDataSet()
        {
            CancellationPolicyDAL _dataObject = new CancellationPolicyDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of CancellationPolicy by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<CancellationPolicy> GetAllBy(CancellationPolicy.CancellationPolicyFields fieldName, object value)
        {
            CancellationPolicyDAL _dataObject = new CancellationPolicyDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        public static DataSet GetAllByWithDataSet(CancellationPolicy.CancellationPolicyFields fieldName, object value)
        {
            CancellationPolicyDAL _dataObject = new CancellationPolicyDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            CancellationPolicyDAL _dataObject = new CancellationPolicyDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(CancellationPolicy obj)
        {
            CancellationPolicyDAL _dataObject = new CancellationPolicyDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete CancellationPolicy by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(CancellationPolicy.CancellationPolicyFields fieldName, object value)
        {
            CancellationPolicyDAL _dataObject = new CancellationPolicyDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }




        #endregion

    }
}
