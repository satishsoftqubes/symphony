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
    public static class RoomLayoutPlaneDetailBLL
    {

        //#region data Members

        //private static RoomLayoutPlaneDetailDAL _dataObject = null;

        //#endregion

        #region Constructor

        static RoomLayoutPlaneDetailBLL()
        {
            //_dataObject = new RoomLayoutPlaneDetailDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new RoomLayoutPlaneDetail
        /// </summary>
        /// <param name="businessObject">RoomLayoutPlaneDetail object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(RoomLayoutPlaneDetail businessObject)
        {
            RoomLayoutPlaneDetailDAL _dataObject = new RoomLayoutPlaneDetailDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.RoomLayoutID = Guid.NewGuid();
                    
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
        /// Update existing RoomLayoutPlaneDetail
        /// </summary>
        /// <param name="businessObject">RoomLayoutPlaneDetail object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(RoomLayoutPlaneDetail businessObject)
        {
            RoomLayoutPlaneDetailDAL _dataObject = new RoomLayoutPlaneDetailDAL();
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
        /// get RoomLayoutPlaneDetail by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static RoomLayoutPlaneDetail GetByPrimaryKey(Guid keys)
        {
            RoomLayoutPlaneDetailDAL _dataObject = new RoomLayoutPlaneDetailDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all RoomLayoutPlaneDetails
        /// </summary>
        /// <returns>list</returns>
        public static List<RoomLayoutPlaneDetail> GetAll(RoomLayoutPlaneDetail obj)
        {
            RoomLayoutPlaneDetailDAL _dataObject = new RoomLayoutPlaneDetailDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all RoomLayoutPlaneDetails
        /// </summary>
        /// <returns>list</returns>
        public static List<RoomLayoutPlaneDetail> GetAll()
        {
            RoomLayoutPlaneDetailDAL _dataObject = new RoomLayoutPlaneDetailDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of RoomLayoutPlaneDetail by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<RoomLayoutPlaneDetail> GetAllBy(RoomLayoutPlaneDetail.RoomLayoutPlaneDetailFields fieldName, object value)
        {
            RoomLayoutPlaneDetailDAL _dataObject = new RoomLayoutPlaneDetailDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all RoomLayoutPlaneDetails
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(RoomLayoutPlaneDetail obj)
        {
            RoomLayoutPlaneDetailDAL _dataObject = new RoomLayoutPlaneDetailDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all RoomLayoutPlaneDetails
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            RoomLayoutPlaneDetailDAL _dataObject = new RoomLayoutPlaneDetailDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of RoomLayoutPlaneDetail by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(RoomLayoutPlaneDetail.RoomLayoutPlaneDetailFields fieldName, object value)
        {
            RoomLayoutPlaneDetailDAL _dataObject = new RoomLayoutPlaneDetailDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            RoomLayoutPlaneDetailDAL _dataObject = new RoomLayoutPlaneDetailDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(RoomLayoutPlaneDetail obj)
        {
            RoomLayoutPlaneDetailDAL _dataObject = new RoomLayoutPlaneDetailDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete RoomLayoutPlaneDetail by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(RoomLayoutPlaneDetail.RoomLayoutPlaneDetailFields fieldName, object value)
        {
            RoomLayoutPlaneDetailDAL _dataObject = new RoomLayoutPlaneDetailDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
