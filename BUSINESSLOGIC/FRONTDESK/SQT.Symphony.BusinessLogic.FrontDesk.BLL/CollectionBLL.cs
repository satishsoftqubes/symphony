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
    public static class CollectionBLL
    {

        //#region data Members

        //private static CollectionDAL _dataObject = null;

        //#endregion

        #region Constructor

        static CollectionBLL()
        {
            //_dataObject = new CollectionDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Collection
        /// </summary>
        /// <param name="businessObject">Collection object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Collection businessObject)
        {
            CollectionDAL _dataObject = new CollectionDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.CollectionID = Guid.NewGuid();
                    
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
        /// Update existing Collection
        /// </summary>
        /// <param name="businessObject">Collection object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Collection businessObject)
        {
            CollectionDAL _dataObject = new CollectionDAL();
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
        /// get Collection by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Collection GetByPrimaryKey(Guid keys)
        {
            CollectionDAL _dataObject = new CollectionDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Collections
        /// </summary>
        /// <returns>list</returns>
        public static List<Collection> GetAll(Collection obj)
        {
            CollectionDAL _dataObject = new CollectionDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Collections
        /// </summary>
        /// <returns>list</returns>
        public static List<Collection> GetAll()
        {
            CollectionDAL _dataObject = new CollectionDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Collection by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Collection> GetAllBy(Collection.CollectionFields fieldName, object value)
        {
            CollectionDAL _dataObject = new CollectionDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Collections
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Collection obj)
        {
            CollectionDAL _dataObject = new CollectionDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Collections
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            CollectionDAL _dataObject = new CollectionDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Collection by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Collection.CollectionFields fieldName, object value)
        {
            CollectionDAL _dataObject = new CollectionDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            CollectionDAL _dataObject = new CollectionDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Collection obj)
        {
            CollectionDAL _dataObject = new CollectionDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Collection by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Collection.CollectionFields fieldName, object value)
        {
            CollectionDAL _dataObject = new CollectionDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet GetTotalRevenueForQuarterForIR(DateTime StartDate, DateTime EndDate, Guid CompanyID, Guid PropertyID)
        {
            CollectionDAL _dataObject = new CollectionDAL();
            return _dataObject.GetTotalRevenueForQuarterForIR(StartDate, EndDate, CompanyID, PropertyID);
        }

        #endregion

    }
}
