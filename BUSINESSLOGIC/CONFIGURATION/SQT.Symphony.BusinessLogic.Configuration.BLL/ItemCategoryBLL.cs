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
    public static class ItemCategoryBLL
    {

        //#region data Members

        //private static ItemCategoryDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ItemCategoryBLL()
        {
            //_dataObject = new ItemCategoryDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ItemCategory
        /// </summary>
        /// <param name="businessObject">ItemCategory object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ItemCategory businessObject)
        {
            ItemCategoryDAL _dataObject = new ItemCategoryDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ItemCategoryID = Guid.NewGuid();
                    
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
        /// Update existing ItemCategory
        /// </summary>
        /// <param name="businessObject">ItemCategory object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ItemCategory businessObject)
        {
            ItemCategoryDAL _dataObject = new ItemCategoryDAL();
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
        /// get ItemCategory by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ItemCategory GetByPrimaryKey(Guid keys)
        {
            ItemCategoryDAL _dataObject = new ItemCategoryDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ItemCategorys
        /// </summary>
        /// <returns>list</returns>
        public static List<ItemCategory> GetAll(ItemCategory obj)
        {
            ItemCategoryDAL _dataObject = new ItemCategoryDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ItemCategorys
        /// </summary>
        /// <returns>list</returns>
        public static List<ItemCategory> GetAll()
        {
            ItemCategoryDAL _dataObject = new ItemCategoryDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ItemCategory by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ItemCategory> GetAllBy(ItemCategory.ItemCategoryFields fieldName, object value)
        {
            ItemCategoryDAL _dataObject = new ItemCategoryDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ItemCategorys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ItemCategory obj)
        {
            ItemCategoryDAL _dataObject = new ItemCategoryDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ItemCategorys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ItemCategoryDAL _dataObject = new ItemCategoryDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ItemCategory by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ItemCategory.ItemCategoryFields fieldName, object value)
        {
            ItemCategoryDAL _dataObject = new ItemCategoryDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ItemCategoryDAL _dataObject = new ItemCategoryDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ItemCategory obj)
        {
            ItemCategoryDAL _dataObject = new ItemCategoryDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ItemCategory by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ItemCategory.ItemCategoryFields fieldName, object value)
        {
            ItemCategoryDAL _dataObject = new ItemCategoryDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet SelectItemAndRateFromItemAvailability(Guid? PropertyID, Guid? CompanyID, Guid? POSPointID, Guid? ItemID, string CategoryID)
        {
            ItemCategoryDAL _dataObject = new ItemCategoryDAL();
            return _dataObject.SelectItemAndRateFromItemAvailability(PropertyID, CompanyID, POSPointID, ItemID, CategoryID);
        }

        public static DataSet GetItemByCategoryID(Guid? PropertyID, Guid? CompanyID, Guid? CategoryID)
        {
            ItemCategoryDAL _dataObject = new ItemCategoryDAL();
            return _dataObject.SelectItemByCategoryID(PropertyID, CompanyID, CategoryID);
        }

        #endregion

    }
}
