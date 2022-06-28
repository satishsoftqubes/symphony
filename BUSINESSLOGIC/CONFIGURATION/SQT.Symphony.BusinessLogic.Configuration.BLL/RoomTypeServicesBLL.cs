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
    public static class RoomTypeServicesBLL
    {

        //#region data Members

        //private static RoomTypeServicesDAL _dataObject = null;

        //#endregion

        #region Constructor

        static RoomTypeServicesBLL()
        {
            //_dataObject = new RoomTypeServicesDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new RoomTypeServices
        /// </summary>
        /// <param name="businessObject">RoomTypeServices object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(RoomTypeServices businessObject)
        {
            RoomTypeServicesDAL _dataObject = new RoomTypeServicesDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.RoomTypeServiceID = Guid.NewGuid();
                    
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
        /// Update existing RoomTypeServices
        /// </summary>
        /// <param name="businessObject">RoomTypeServices object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(RoomTypeServices businessObject)
        {
            RoomTypeServicesDAL _dataObject = new RoomTypeServicesDAL();
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
        /// get RoomTypeServices by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static RoomTypeServices GetByPrimaryKey(Guid keys)
        {
            RoomTypeServicesDAL _dataObject = new RoomTypeServicesDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all RoomTypeServicess
        /// </summary>
        /// <returns>list</returns>
        public static List<RoomTypeServices> GetAll(RoomTypeServices obj)
        {
            RoomTypeServicesDAL _dataObject = new RoomTypeServicesDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all RoomTypeServicess
        /// </summary>
        /// <returns>list</returns>
        public static List<RoomTypeServices> GetAll()
        {
            RoomTypeServicesDAL _dataObject = new RoomTypeServicesDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of RoomTypeServices by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<RoomTypeServices> GetAllBy(RoomTypeServices.RoomTypeServicesFields fieldName, object value)
        {
            RoomTypeServicesDAL _dataObject = new RoomTypeServicesDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all RoomTypeServicess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(RoomTypeServices obj)
        {
            RoomTypeServicesDAL _dataObject = new RoomTypeServicesDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all RoomTypeServicess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            RoomTypeServicesDAL _dataObject = new RoomTypeServicesDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of RoomTypeServices by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(RoomTypeServices.RoomTypeServicesFields fieldName, object value)
        {
            RoomTypeServicesDAL _dataObject = new RoomTypeServicesDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            RoomTypeServicesDAL _dataObject = new RoomTypeServicesDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(RoomTypeServices obj)
        {
            RoomTypeServicesDAL _dataObject = new RoomTypeServicesDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete RoomTypeServices by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(RoomTypeServices.RoomTypeServicesFields fieldName, object value)
        {
            RoomTypeServicesDAL _dataObject = new RoomTypeServicesDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
