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
    public static class RoomSellOrderBLL
    {

        //#region data Members

        //private static RoomSellOrderDAL _dataObject = null;

        //#endregion

        #region Constructor

        static RoomSellOrderBLL()
        {
            //_dataObject = new RoomSellOrderDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new RoomSellOrder
        /// </summary>
        /// <param name="businessObject">RoomSellOrder object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(RoomSellOrder businessObject)
        {
            RoomSellOrderDAL _dataObject = new RoomSellOrderDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.RoomSellOrderID = Guid.NewGuid();
                    
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
        /// Update existing RoomSellOrder
        /// </summary>
        /// <param name="businessObject">RoomSellOrder object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(RoomSellOrder businessObject)
        {
            RoomSellOrderDAL _dataObject = new RoomSellOrderDAL();
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
        /// get RoomSellOrder by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static RoomSellOrder GetByPrimaryKey(Guid keys)
        {
            RoomSellOrderDAL _dataObject = new RoomSellOrderDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all RoomSellOrders
        /// </summary>
        /// <returns>list</returns>
        public static List<RoomSellOrder> GetAll(RoomSellOrder obj)
        {
            RoomSellOrderDAL _dataObject = new RoomSellOrderDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all RoomSellOrders
        /// </summary>
        /// <returns>list</returns>
        public static List<RoomSellOrder> GetAll()
        {
            RoomSellOrderDAL _dataObject = new RoomSellOrderDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of RoomSellOrder by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<RoomSellOrder> GetAllBy(RoomSellOrder.RoomSellOrderFields fieldName, object value)
        {
            RoomSellOrderDAL _dataObject = new RoomSellOrderDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all RoomSellOrders
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(RoomSellOrder obj)
        {
            RoomSellOrderDAL _dataObject = new RoomSellOrderDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all RoomSellOrders
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            RoomSellOrderDAL _dataObject = new RoomSellOrderDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of RoomSellOrder by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(RoomSellOrder.RoomSellOrderFields fieldName, object value)
        {
            RoomSellOrderDAL _dataObject = new RoomSellOrderDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            RoomSellOrderDAL _dataObject = new RoomSellOrderDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(RoomSellOrder obj)
        {
            RoomSellOrderDAL _dataObject = new RoomSellOrderDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete RoomSellOrder by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(RoomSellOrder.RoomSellOrderFields fieldName, object value)
        {
            RoomSellOrderDAL _dataObject = new RoomSellOrderDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet RoomSellOrderSelectAllData(Guid? RoomTypeID)
        {
            RoomSellOrderDAL _dataObject = new RoomSellOrderDAL();
            return _dataObject.RoomSellOrderSelectAllData(RoomTypeID);
        }

        public static bool RoomSellOrderSelectAllAfterSwap(Guid? RoomSellOrderID, string SwapDirection, Guid? RoomTypeID)
        {
            RoomSellOrderDAL _dataObject = new RoomSellOrderDAL();
            return _dataObject.RoomSellOrderSelectAllAfterSwap(RoomSellOrderID, SwapDirection, RoomTypeID);
        }
        #endregion

    }
}
