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
    public static class ResServiceListBLL
    {

        //#region data Members

        //private static ResServiceListDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ResServiceListBLL()
        {
            //_dataObject = new ResServiceListDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ResServiceList
        /// </summary>
        /// <param name="businessObject">ResServiceList object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ResServiceList businessObject)
        {
            ResServiceListDAL _dataObject = new ResServiceListDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ResServiceID = Guid.NewGuid();
                    
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
        /// Update existing ResServiceList
        /// </summary>
        /// <param name="businessObject">ResServiceList object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ResServiceList businessObject)
        {
            ResServiceListDAL _dataObject = new ResServiceListDAL();
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
        /// get ResServiceList by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ResServiceList GetByPrimaryKey(Guid keys)
        {
            ResServiceListDAL _dataObject = new ResServiceListDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ResServiceLists
        /// </summary>
        /// <returns>list</returns>
        public static List<ResServiceList> GetAll(ResServiceList obj)
        {
            ResServiceListDAL _dataObject = new ResServiceListDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ResServiceLists
        /// </summary>
        /// <returns>list</returns>
        public static List<ResServiceList> GetAll()
        {
            ResServiceListDAL _dataObject = new ResServiceListDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ResServiceList by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ResServiceList> GetAllBy(ResServiceList.ResServiceListFields fieldName, object value)
        {
            ResServiceListDAL _dataObject = new ResServiceListDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ResServiceLists
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ResServiceList obj)
        {
            ResServiceListDAL _dataObject = new ResServiceListDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ResServiceLists
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ResServiceListDAL _dataObject = new ResServiceListDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ResServiceList by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ResServiceList.ResServiceListFields fieldName, object value)
        {
            ResServiceListDAL _dataObject = new ResServiceListDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ResServiceListDAL _dataObject = new ResServiceListDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ResServiceList obj)
        {
            ResServiceListDAL _dataObject = new ResServiceListDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ResServiceList by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ResServiceList.ResServiceListFields fieldName, object value)
        {
            ResServiceListDAL _dataObject = new ResServiceListDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
