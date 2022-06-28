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
    public static class AddOnItemsBLL
    {

        //#region data Members

        //private static AddOnItemsDAL _dataObject = null;

        //#endregion

        #region Constructor

        static AddOnItemsBLL()
        {
            //_dataObject = new AddOnItemsDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new AddOnItems
        /// </summary>
        /// <param name="businessObject">AddOnItems object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(AddOnItems businessObject)
        {
            AddOnItemsDAL _dataObject = new AddOnItemsDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.AddOnItemID = Guid.NewGuid();
                    
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
        /// Update existing AddOnItems
        /// </summary>
        /// <param name="businessObject">AddOnItems object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(AddOnItems businessObject)
        {
            AddOnItemsDAL _dataObject = new AddOnItemsDAL();
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
        /// get AddOnItems by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static AddOnItems GetByPrimaryKey(Guid keys)
        {
            AddOnItemsDAL _dataObject = new AddOnItemsDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all AddOnItemss
        /// </summary>
        /// <returns>list</returns>
        public static List<AddOnItems> GetAll(AddOnItems obj)
        {
            AddOnItemsDAL _dataObject = new AddOnItemsDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all AddOnItemss
        /// </summary>
        /// <returns>list</returns>
        public static List<AddOnItems> GetAll()
        {
            AddOnItemsDAL _dataObject = new AddOnItemsDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of AddOnItems by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<AddOnItems> GetAllBy(AddOnItems.AddOnItemsFields fieldName, object value)
        {
            AddOnItemsDAL _dataObject = new AddOnItemsDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all AddOnItemss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(AddOnItems obj)
        {
            AddOnItemsDAL _dataObject = new AddOnItemsDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all AddOnItemss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            AddOnItemsDAL _dataObject = new AddOnItemsDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of AddOnItems by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(AddOnItems.AddOnItemsFields fieldName, object value)
        {
            AddOnItemsDAL _dataObject = new AddOnItemsDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            AddOnItemsDAL _dataObject = new AddOnItemsDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(AddOnItems obj)
        {
            AddOnItemsDAL _dataObject = new AddOnItemsDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete AddOnItems by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(AddOnItems.AddOnItemsFields fieldName, object value)
        {
            AddOnItemsDAL _dataObject = new AddOnItemsDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
