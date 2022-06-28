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
    public static class GuestLaundryBLL
    {

        //#region data Members

        //private static GuestLaundryDAL _dataObject = null;

        //#endregion

        #region Constructor

        static GuestLaundryBLL()
        {
            //_dataObject = new GuestLaundryDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new GuestLaundry
        /// </summary>
        /// <param name="businessObject">GuestLaundry object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(GuestLaundry businessObject)
        {
            GuestLaundryDAL _dataObject = new GuestLaundryDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.GuestLaundryID = Guid.NewGuid();
                    
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
        /// Update existing GuestLaundry
        /// </summary>
        /// <param name="businessObject">GuestLaundry object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(GuestLaundry businessObject)
        {
            GuestLaundryDAL _dataObject = new GuestLaundryDAL();
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
        /// get GuestLaundry by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static GuestLaundry GetByPrimaryKey(Guid keys)
        {
            GuestLaundryDAL _dataObject = new GuestLaundryDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all GuestLaundrys
        /// </summary>
        /// <returns>list</returns>
        public static List<GuestLaundry> GetAll(GuestLaundry obj)
        {
            GuestLaundryDAL _dataObject = new GuestLaundryDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all GuestLaundrys
        /// </summary>
        /// <returns>list</returns>
        public static List<GuestLaundry> GetAll()
        {
            GuestLaundryDAL _dataObject = new GuestLaundryDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of GuestLaundry by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<GuestLaundry> GetAllBy(GuestLaundry.GuestLaundryFields fieldName, object value)
        {
            GuestLaundryDAL _dataObject = new GuestLaundryDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all GuestLaundrys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(GuestLaundry obj)
        {
            GuestLaundryDAL _dataObject = new GuestLaundryDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all GuestLaundrys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            GuestLaundryDAL _dataObject = new GuestLaundryDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of GuestLaundry by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(GuestLaundry.GuestLaundryFields fieldName, object value)
        {
            GuestLaundryDAL _dataObject = new GuestLaundryDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            GuestLaundryDAL _dataObject = new GuestLaundryDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(GuestLaundry obj)
        {
            GuestLaundryDAL _dataObject = new GuestLaundryDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete GuestLaundry by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(GuestLaundry.GuestLaundryFields fieldName, object value)
        {
            GuestLaundryDAL _dataObject = new GuestLaundryDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
