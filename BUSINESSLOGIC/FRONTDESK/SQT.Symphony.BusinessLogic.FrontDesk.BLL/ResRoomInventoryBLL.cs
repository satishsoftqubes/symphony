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
    public static class ResRoomInventoryBLL
    {

        //#region data Members

        //private static ResRoomInventoryDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ResRoomInventoryBLL()
        {
            //_dataObject = new ResRoomInventoryDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ResRoomInventory
        /// </summary>
        /// <param name="businessObject">ResRoomInventory object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ResRoomInventory businessObject)
        {
            ResRoomInventoryDAL _dataObject = new ResRoomInventoryDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ResRoomInventoryID = Guid.NewGuid();
                    
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
        /// Update existing ResRoomInventory
        /// </summary>
        /// <param name="businessObject">ResRoomInventory object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ResRoomInventory businessObject)
        {
            ResRoomInventoryDAL _dataObject = new ResRoomInventoryDAL();
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
        /// get ResRoomInventory by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ResRoomInventory GetByPrimaryKey(Guid keys)
        {
            ResRoomInventoryDAL _dataObject = new ResRoomInventoryDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ResRoomInventorys
        /// </summary>
        /// <returns>list</returns>
        public static List<ResRoomInventory> GetAll(ResRoomInventory obj)
        {
            ResRoomInventoryDAL _dataObject = new ResRoomInventoryDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ResRoomInventorys
        /// </summary>
        /// <returns>list</returns>
        public static List<ResRoomInventory> GetAll()
        {
            ResRoomInventoryDAL _dataObject = new ResRoomInventoryDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ResRoomInventory by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ResRoomInventory> GetAllBy(ResRoomInventory.ResRoomInventoryFields fieldName, object value)
        {
            ResRoomInventoryDAL _dataObject = new ResRoomInventoryDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ResRoomInventorys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ResRoomInventory obj)
        {
            ResRoomInventoryDAL _dataObject = new ResRoomInventoryDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ResRoomInventorys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ResRoomInventoryDAL _dataObject = new ResRoomInventoryDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ResRoomInventory by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ResRoomInventory.ResRoomInventoryFields fieldName, object value)
        {
            ResRoomInventoryDAL _dataObject = new ResRoomInventoryDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ResRoomInventoryDAL _dataObject = new ResRoomInventoryDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ResRoomInventory obj)
        {
            ResRoomInventoryDAL _dataObject = new ResRoomInventoryDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ResRoomInventory by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ResRoomInventory.ResRoomInventoryFields fieldName, object value)
        {
            ResRoomInventoryDAL _dataObject = new ResRoomInventoryDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
