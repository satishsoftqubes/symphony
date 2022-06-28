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
    public static class RateServiceJoinBLL
    {

        //#region data Members

        //private static RateServiceJoinDAL _dataObject = null;

        //#endregion

        #region Constructor

        static RateServiceJoinBLL()
        {
            //_dataObject = new RateServiceJoinDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new RateServiceJoin
        /// </summary>
        /// <param name="businessObject">RateServiceJoin object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(RateServiceJoin businessObject)
        {
            RateServiceJoinDAL _dataObject = new RateServiceJoinDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.RateServiceID = Guid.NewGuid();
                    
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
        /// Update existing RateServiceJoin
        /// </summary>
        /// <param name="businessObject">RateServiceJoin object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(RateServiceJoin businessObject)
        {
            RateServiceJoinDAL _dataObject = new RateServiceJoinDAL();
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
        /// get RateServiceJoin by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static RateServiceJoin GetByPrimaryKey(Guid keys)
        {
            RateServiceJoinDAL _dataObject = new RateServiceJoinDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all RateServiceJoins
        /// </summary>
        /// <returns>list</returns>
        public static List<RateServiceJoin> GetAll(RateServiceJoin obj)
        {
            RateServiceJoinDAL _dataObject = new RateServiceJoinDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all RateServiceJoins
        /// </summary>
        /// <returns>list</returns>
        public static List<RateServiceJoin> GetAll()
        {
            RateServiceJoinDAL _dataObject = new RateServiceJoinDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of RateServiceJoin by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<RateServiceJoin> GetAllBy(RateServiceJoin.RateServiceJoinFields fieldName, object value)
        {
            RateServiceJoinDAL _dataObject = new RateServiceJoinDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all RateServiceJoins
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(RateServiceJoin obj)
        {
            RateServiceJoinDAL _dataObject = new RateServiceJoinDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all RateServiceJoins
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            RateServiceJoinDAL _dataObject = new RateServiceJoinDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of RateServiceJoin by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(RateServiceJoin.RateServiceJoinFields fieldName, object value)
        {
            RateServiceJoinDAL _dataObject = new RateServiceJoinDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            RateServiceJoinDAL _dataObject = new RateServiceJoinDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(RateServiceJoin obj)
        {
            RateServiceJoinDAL _dataObject = new RateServiceJoinDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete RateServiceJoin by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(RateServiceJoin.RateServiceJoinFields fieldName, object value)
        {
            RateServiceJoinDAL _dataObject = new RateServiceJoinDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet SelectAllDataByRateID(Guid RateID)
        {
            RateServiceJoinDAL _dataObject = new RateServiceJoinDAL();
            return _dataObject.SelectAllDataByRateID(RateID);
        }

        public static DataSet SelectAllDataByRateIDnRoomTypeID(Guid RateID, Guid RoomTypeID)
        {
            RateServiceJoinDAL _dataObject = new RateServiceJoinDAL();
            return _dataObject.SelectAllDataByRateIDnRoomTypeID(RateID, RoomTypeID);
        }
        #endregion

    }
}
