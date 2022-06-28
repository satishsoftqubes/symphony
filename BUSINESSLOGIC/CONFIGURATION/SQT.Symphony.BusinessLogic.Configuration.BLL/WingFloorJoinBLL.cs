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
    public static class WingFloorJoinBLL
    {

        //#region data Members

        //private static WingFloorJoinDAL _dataObject = null;

        //#endregion

        #region Constructor

        static WingFloorJoinBLL()
        {
            //_dataObject = new WingFloorJoinDAL();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// GetAll With Name
        /// </summary>
        /// <param name="WingID"></param>
        /// <param name="FloorID"></param>
        /// <returns></returns>
        public static DataSet GetAllWithName(Guid? WingID, Guid? FloorID)
        {
            WingFloorJoinDAL _obj = new WingFloorJoinDAL();
            return _obj.SelectAllWithName(WingID, FloorID);
        }
        /// <summary>
        /// Insert new WingFloorJoin
        /// </summary>
        /// <param name="businessObject">WingFloorJoin object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(WingFloorJoin businessObject)
        {
            WingFloorJoinDAL _dataObject = new WingFloorJoinDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.WingFloorJoinID = Guid.NewGuid();
                    
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
        /// Update existing WingFloorJoin
        /// </summary>
        /// <param name="businessObject">WingFloorJoin object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(WingFloorJoin businessObject)
        {
            WingFloorJoinDAL _dataObject = new WingFloorJoinDAL();
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
        /// get WingFloorJoin by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static WingFloorJoin GetByPrimaryKey(Guid keys)
        {
            WingFloorJoinDAL _dataObject = new WingFloorJoinDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all WingFloorJoins
        /// </summary>
        /// <returns>list</returns>
        public static List<WingFloorJoin> GetAll(WingFloorJoin obj)
        {
            WingFloorJoinDAL _dataObject = new WingFloorJoinDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all WingFloorJoins
        /// </summary>
        /// <returns>list</returns>
        public static List<WingFloorJoin> GetAll()
        {
            WingFloorJoinDAL _dataObject = new WingFloorJoinDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of WingFloorJoin by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<WingFloorJoin> GetAllBy(WingFloorJoin.WingFloorJoinFields fieldName, object value)
        {
            WingFloorJoinDAL _dataObject = new WingFloorJoinDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all WingFloorJoins
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(WingFloorJoin obj)
        {
            WingFloorJoinDAL _dataObject = new WingFloorJoinDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all WingFloorJoins
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            WingFloorJoinDAL _dataObject = new WingFloorJoinDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of WingFloorJoin by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(WingFloorJoin.WingFloorJoinFields fieldName, object value)
        {
            WingFloorJoinDAL _dataObject = new WingFloorJoinDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            WingFloorJoinDAL _dataObject = new WingFloorJoinDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(WingFloorJoin obj)
        {
            WingFloorJoinDAL _dataObject = new WingFloorJoinDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete WingFloorJoin by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(WingFloorJoin.WingFloorJoinFields fieldName, object value)
        {
            WingFloorJoinDAL _dataObject = new WingFloorJoinDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
