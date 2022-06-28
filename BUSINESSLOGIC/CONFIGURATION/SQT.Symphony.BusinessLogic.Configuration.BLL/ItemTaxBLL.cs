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
    public static class ItemTaxBLL
    {

        //#region data Members

        //private static ItemTaxDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ItemTaxBLL()
        {
            //_dataObject = new ItemTaxDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ItemTax
        /// </summary>
        /// <param name="businessObject">ItemTax object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ItemTax businessObject)
        {
            ItemTaxDAL _dataObject = new ItemTaxDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ItemTaxID = Guid.NewGuid();
                    
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
        /// Update existing ItemTax
        /// </summary>
        /// <param name="businessObject">ItemTax object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ItemTax businessObject)
        {
            ItemTaxDAL _dataObject = new ItemTaxDAL();
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
        /// get ItemTax by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ItemTax GetByPrimaryKey(Guid keys)
        {
            ItemTaxDAL _dataObject = new ItemTaxDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ItemTaxs
        /// </summary>
        /// <returns>list</returns>
        public static List<ItemTax> GetAll(ItemTax obj)
        {
            ItemTaxDAL _dataObject = new ItemTaxDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ItemTaxs
        /// </summary>
        /// <returns>list</returns>
        public static List<ItemTax> GetAll()
        {
            ItemTaxDAL _dataObject = new ItemTaxDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ItemTax by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ItemTax> GetAllBy(ItemTax.ItemTaxFields fieldName, object value)
        {
            ItemTaxDAL _dataObject = new ItemTaxDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ItemTaxs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ItemTax obj)
        {
            ItemTaxDAL _dataObject = new ItemTaxDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ItemTaxs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ItemTaxDAL _dataObject = new ItemTaxDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ItemTax by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ItemTax.ItemTaxFields fieldName, object value)
        {
            ItemTaxDAL _dataObject = new ItemTaxDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ItemTaxDAL _dataObject = new ItemTaxDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ItemTax obj)
        {
            ItemTaxDAL _dataObject = new ItemTaxDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ItemTax by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ItemTax.ItemTaxFields fieldName, object value)
        {
            ItemTaxDAL _dataObject = new ItemTaxDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
