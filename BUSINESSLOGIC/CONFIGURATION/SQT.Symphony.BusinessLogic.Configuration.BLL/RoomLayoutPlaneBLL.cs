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
    public static class RoomLayoutPlaneBLL
    {

        //#region data Members

        //private static RoomLayoutPlaneDAL _dataObject = null;

        //#endregion

        #region Constructor

        static RoomLayoutPlaneBLL()
        {
            //_dataObject = new RoomLayoutPlaneDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new RoomLayoutPlane
        /// </summary>
        /// <param name="businessObject">RoomLayoutPlane object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(RoomLayoutPlane businessObject)
        {
            RoomLayoutPlaneDAL _dataObject = new RoomLayoutPlaneDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.RoomLayoutPlanID = Guid.NewGuid();
                    
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
        /// Update existing RoomLayoutPlane
        /// </summary>
        /// <param name="businessObject">RoomLayoutPlane object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(RoomLayoutPlane businessObject)
        {
            RoomLayoutPlaneDAL _dataObject = new RoomLayoutPlaneDAL();
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
        /// get RoomLayoutPlane by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static RoomLayoutPlane GetByPrimaryKey(Guid keys)
        {
            RoomLayoutPlaneDAL _dataObject = new RoomLayoutPlaneDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all RoomLayoutPlanes
        /// </summary>
        /// <returns>list</returns>
        public static List<RoomLayoutPlane> GetAll(RoomLayoutPlane obj)
        {
            RoomLayoutPlaneDAL _dataObject = new RoomLayoutPlaneDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all RoomLayoutPlanes
        /// </summary>
        /// <returns>list</returns>
        public static List<RoomLayoutPlane> GetAll()
        {
            RoomLayoutPlaneDAL _dataObject = new RoomLayoutPlaneDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of RoomLayoutPlane by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<RoomLayoutPlane> GetAllBy(RoomLayoutPlane.RoomLayoutPlaneFields fieldName, object value)
        {
            RoomLayoutPlaneDAL _dataObject = new RoomLayoutPlaneDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all RoomLayoutPlanes
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(RoomLayoutPlane obj)
        {
            RoomLayoutPlaneDAL _dataObject = new RoomLayoutPlaneDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all RoomLayoutPlanes
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            RoomLayoutPlaneDAL _dataObject = new RoomLayoutPlaneDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of RoomLayoutPlane by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(RoomLayoutPlane.RoomLayoutPlaneFields fieldName, object value)
        {
            RoomLayoutPlaneDAL _dataObject = new RoomLayoutPlaneDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            RoomLayoutPlaneDAL _dataObject = new RoomLayoutPlaneDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(RoomLayoutPlane obj)
        {
            RoomLayoutPlaneDAL _dataObject = new RoomLayoutPlaneDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete RoomLayoutPlane by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(RoomLayoutPlane.RoomLayoutPlaneFields fieldName, object value)
        {
            RoomLayoutPlaneDAL _dataObject = new RoomLayoutPlaneDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
