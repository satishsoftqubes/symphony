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
    public static class VIPTypesBLL
    {

        //#region data Members

        //private static VIPTypesDAL _dataObject = null;

        //#endregion

        #region Constructor

        static VIPTypesBLL()
        {
            //_dataObject = new VIPTypesDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new VIPTypes
        /// </summary>
        /// <param name="businessObject">VIPTypes object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(VIPTypes businessObject)
        {
            VIPTypesDAL _dataObject = new VIPTypesDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.VIPTypeID = Guid.NewGuid();
                    
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
        /// Update existing VIPTypes
        /// </summary>
        /// <param name="businessObject">VIPTypes object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(VIPTypes businessObject)
        {
            VIPTypesDAL _dataObject = new VIPTypesDAL();
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
        /// get VIPTypes by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static VIPTypes GetByPrimaryKey(Guid keys)
        {
            VIPTypesDAL _dataObject = new VIPTypesDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all VIPTypess
        /// </summary>
        /// <returns>list</returns>
        public static List<VIPTypes> GetAll(VIPTypes obj)
        {
            VIPTypesDAL _dataObject = new VIPTypesDAL();
            return _dataObject.SelectAll(obj); 
        }

        public static List<VIPTypes> GetAllForCheckDuplicate(VIPTypes obj)
        {
            VIPTypesDAL _dataObject = new VIPTypesDAL();
            return _dataObject.SelectAllForCheckDuplicate(obj);
        }

        /// <summary>
        /// get list of all VIPTypess
        /// </summary>
        /// <returns>list</returns>
        public static List<VIPTypes> GetAll()
        {
            VIPTypesDAL _dataObject = new VIPTypesDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of VIPTypes by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<VIPTypes> GetAllBy(VIPTypes.VIPTypesFields fieldName, object value)
        {
            VIPTypesDAL _dataObject = new VIPTypesDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all VIPTypess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(VIPTypes obj)
        {
            VIPTypesDAL _dataObject = new VIPTypesDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all VIPTypess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            VIPTypesDAL _dataObject = new VIPTypesDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of VIPTypes by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(VIPTypes.VIPTypesFields fieldName, object value)
        {
            VIPTypesDAL _dataObject = new VIPTypesDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            VIPTypesDAL _dataObject = new VIPTypesDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(VIPTypes obj)
        {
            VIPTypesDAL _dataObject = new VIPTypesDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete VIPTypes by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(VIPTypes.VIPTypesFields fieldName, object value)
        {
            VIPTypesDAL _dataObject = new VIPTypesDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
