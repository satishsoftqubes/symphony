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
    public static class RoomBlockDetailsBLL
    {

        //#region data Members

        //private static RoomBlockDetailsDAL _dataObject = null;

        //#endregion

        #region Constructor

        static RoomBlockDetailsBLL()
        {
            //_dataObject = new RoomBlockDetailsDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new RoomBlockDetails
        /// </summary>
        /// <param name="businessObject">RoomBlockDetails object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(RoomBlockDetails businessObject)
        {
            RoomBlockDetailsDAL _dataObject = new RoomBlockDetailsDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.BlockRoomDetailID = Guid.NewGuid();
                    
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
        /// Update existing RoomBlockDetails
        /// </summary>
        /// <param name="businessObject">RoomBlockDetails object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(RoomBlockDetails businessObject)
        {
            RoomBlockDetailsDAL _dataObject = new RoomBlockDetailsDAL();
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
        /// get RoomBlockDetails by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static RoomBlockDetails GetByPrimaryKey(Guid keys)
        {
            RoomBlockDetailsDAL _dataObject = new RoomBlockDetailsDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all RoomBlockDetailss
        /// </summary>
        /// <returns>list</returns>
        public static List<RoomBlockDetails> GetAll(RoomBlockDetails obj)
        {
            RoomBlockDetailsDAL _dataObject = new RoomBlockDetailsDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all RoomBlockDetailss
        /// </summary>
        /// <returns>list</returns>
        public static List<RoomBlockDetails> GetAll()
        {
            RoomBlockDetailsDAL _dataObject = new RoomBlockDetailsDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of RoomBlockDetails by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<RoomBlockDetails> GetAllBy(RoomBlockDetails.RoomBlockDetailsFields fieldName, object value)
        {
            RoomBlockDetailsDAL _dataObject = new RoomBlockDetailsDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all RoomBlockDetailss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(RoomBlockDetails obj)
        {
            RoomBlockDetailsDAL _dataObject = new RoomBlockDetailsDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all RoomBlockDetailss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            RoomBlockDetailsDAL _dataObject = new RoomBlockDetailsDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of RoomBlockDetails by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(RoomBlockDetails.RoomBlockDetailsFields fieldName, object value)
        {
            RoomBlockDetailsDAL _dataObject = new RoomBlockDetailsDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            RoomBlockDetailsDAL _dataObject = new RoomBlockDetailsDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(RoomBlockDetails obj)
        {
            RoomBlockDetailsDAL _dataObject = new RoomBlockDetailsDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete RoomBlockDetails by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(RoomBlockDetails.RoomBlockDetailsFields fieldName, object value)
        {
            RoomBlockDetailsDAL _dataObject = new RoomBlockDetailsDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
