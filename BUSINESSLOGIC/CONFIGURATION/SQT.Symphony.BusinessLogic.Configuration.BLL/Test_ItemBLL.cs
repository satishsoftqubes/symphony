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
    public static class Test_ItemBLL
    {

        //#region data Members

        //private static Test_ItemDAL _dataObject = null;

        //#endregion

        #region Constructor

        static Test_ItemBLL()
        {
            //_dataObject = new Test_ItemDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Test_Item
        /// </summary>
        /// <param name="businessObject">Test_Item object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Test_Item businessObject)
        {
            Test_ItemDAL _dataObject = new Test_ItemDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        //businessObject.ItemID = Guid.NewGuid();
                    
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
        /// Update existing Test_Item
        /// </summary>
        /// <param name="businessObject">Test_Item object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Test_Item businessObject)
        {
            Test_ItemDAL _dataObject = new Test_ItemDAL();
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
        /// get Test_Item by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Test_Item GetByPrimaryKey(Guid keys)
        {
            Test_ItemDAL _dataObject = new Test_ItemDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Test_Items
        /// </summary>
        /// <returns>list</returns>
        public static List<Test_Item> GetAll(Test_Item obj)
        {
            Test_ItemDAL _dataObject = new Test_ItemDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Test_Items
        /// </summary>
        /// <returns>list</returns>
        public static List<Test_Item> GetAll()
        {
            Test_ItemDAL _dataObject = new Test_ItemDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Test_Item by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Test_Item> GetAllBy(Test_Item.Test_ItemFields fieldName, object value)
        {
            Test_ItemDAL _dataObject = new Test_ItemDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Test_Items
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Test_Item obj)
        {
            Test_ItemDAL _dataObject = new Test_ItemDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Test_Items
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            Test_ItemDAL _dataObject = new Test_ItemDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Test_Item by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Test_Item.Test_ItemFields fieldName, object value)
        {
            Test_ItemDAL _dataObject = new Test_ItemDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            Test_ItemDAL _dataObject = new Test_ItemDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Test_Item obj)
        {
            Test_ItemDAL _dataObject = new Test_ItemDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Test_Item by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Test_Item.Test_ItemFields fieldName, object value)
        {
            Test_ItemDAL _dataObject = new Test_ItemDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
