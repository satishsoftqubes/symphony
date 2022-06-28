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
    public static class ItemAvailabilityBLL
    {

        //#region data Members

        //private static ItemAvailabilityDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ItemAvailabilityBLL()
        {
            //_dataObject = new ItemAvailabilityDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ItemAvailability
        /// </summary>
        /// <param name="businessObject">ItemAvailability object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ItemAvailability businessObject)
        {
            ItemAvailabilityDAL _dataObject = new ItemAvailabilityDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ItemAvailabilityID = Guid.NewGuid();
                    
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
        /// Update existing ItemAvailability
        /// </summary>
        /// <param name="businessObject">ItemAvailability object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ItemAvailability businessObject)
        {
            ItemAvailabilityDAL _dataObject = new ItemAvailabilityDAL();
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
        /// get ItemAvailability by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ItemAvailability GetByPrimaryKey(Guid keys)
        {
            ItemAvailabilityDAL _dataObject = new ItemAvailabilityDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ItemAvailabilitys
        /// </summary>
        /// <returns>list</returns>
        public static List<ItemAvailability> GetAll(ItemAvailability obj)
        {
            ItemAvailabilityDAL _dataObject = new ItemAvailabilityDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ItemAvailabilitys
        /// </summary>
        /// <returns>list</returns>
        public static List<ItemAvailability> GetAll()
        {
            ItemAvailabilityDAL _dataObject = new ItemAvailabilityDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ItemAvailability by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ItemAvailability> GetAllBy(ItemAvailability.ItemAvailabilityFields fieldName, object value)
        {
            ItemAvailabilityDAL _dataObject = new ItemAvailabilityDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ItemAvailabilitys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ItemAvailability obj)
        {
            ItemAvailabilityDAL _dataObject = new ItemAvailabilityDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ItemAvailabilitys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ItemAvailabilityDAL _dataObject = new ItemAvailabilityDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ItemAvailability by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ItemAvailability.ItemAvailabilityFields fieldName, object value)
        {
            ItemAvailabilityDAL _dataObject = new ItemAvailabilityDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ItemAvailabilityDAL _dataObject = new ItemAvailabilityDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ItemAvailability obj)
        {
            ItemAvailabilityDAL _dataObject = new ItemAvailabilityDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ItemAvailability by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ItemAvailability.ItemAvailabilityFields fieldName, object value)
        {
            ItemAvailabilityDAL _dataObject = new ItemAvailabilityDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet SelectDataByPosPointsID(Guid? POSPointID)
        {
            ItemAvailabilityDAL _dataObject = new ItemAvailabilityDAL();
            return _dataObject.SelectDataByPosPointsID(POSPointID);
        }

        public static DataSet SelectItemAvailabilityData(string strItemAvailabilityQuery)
        {
            ItemAvailabilityDAL _dataObject = new ItemAvailabilityDAL();
            return _dataObject.SelectItemAvailabilityData(strItemAvailabilityQuery);
        }

        public static DataSet GetAllItems(Guid? Location_TermID, Guid? ItemID, Guid? CategoryID, Guid? CompanyID, Guid? PropertyID)
        {
            ItemAvailabilityDAL _dataObject = new ItemAvailabilityDAL();
            return _dataObject.SelectAllItems(Location_TermID, ItemID, CategoryID, CompanyID, PropertyID);
        }
        #endregion

    }
}
