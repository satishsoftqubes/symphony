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
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using SQT.Symphony.BusinessLogic.IRMS.DAL;
using System.Data;

namespace SQT.Symphony.BusinessLogic.IRMS.BLL
{
    public static class InsuranceDetailsBLL
    {

        //#region data Members

        //private static InsuranceDetailsDAL _dataObject = null;

        //#endregion

        #region Constructor

        static InsuranceDetailsBLL()
        {
            //_dataObject = new InsuranceDetailsDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new InsuranceDetails
        /// </summary>
        /// <param name="businessObject">InsuranceDetails object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(InsuranceDetails businessObject)
        {
            InsuranceDetailsDAL _dataObject = new InsuranceDetailsDAL();
            try
            {
                if(businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                        businessObject.InsuranceID = Guid.NewGuid();
                    
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
        /// Update existing InsuranceDetails
        /// </summary>
        /// <param name="businessObject">InsuranceDetails object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(InsuranceDetails businessObject)
        {
            InsuranceDetailsDAL _dataObject = new InsuranceDetailsDAL();
            try
            {
                if(businessObject != null)
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
        /// get InsuranceDetails by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static InsuranceDetails GetByPrimaryKey(Guid keys)
        {
            InsuranceDetailsDAL _dataObject = new InsuranceDetailsDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all InsuranceDetailss
        /// </summary>
        /// <returns>list</returns>
        public static List<InsuranceDetails> GetAll(InsuranceDetails obj)
        {
            InsuranceDetailsDAL _dataObject = new InsuranceDetailsDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all InsuranceDetailss
        /// </summary>
        /// <returns>list</returns>
        public static List<InsuranceDetails> GetAll()
        {
            InsuranceDetailsDAL _dataObject = new InsuranceDetailsDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of InsuranceDetails by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<InsuranceDetails> GetAllBy(InsuranceDetails.InsuranceDetailsFields fieldName, object value)
        {
            InsuranceDetailsDAL _dataObject = new InsuranceDetailsDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            InsuranceDetailsDAL _dataObject = new InsuranceDetailsDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(InsuranceDetails obj)
        {
            InsuranceDetailsDAL _dataObject = new InsuranceDetailsDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete InsuranceDetails by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(InsuranceDetails.InsuranceDetailsFields fieldName, object value)
        {
            InsuranceDetailsDAL _dataObject = new InsuranceDetailsDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }
        public static DataSet GetInsuranceDetailsData(Guid? InsuranceID)
        {
            InsuranceDetailsDAL _Obj = new InsuranceDetailsDAL();
            return _Obj.SelectinsuranceDetailsData(InsuranceID);
        }
        #endregion

    }
}
