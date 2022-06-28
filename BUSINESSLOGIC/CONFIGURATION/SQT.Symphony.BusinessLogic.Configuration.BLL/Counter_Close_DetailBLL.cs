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
    public static class Counter_Close_DetailBLL
    {

        //#region data Members

        //private static Counter_Close_DetailDAL _dataObject = null;

        //#endregion

        #region Constructor

        static Counter_Close_DetailBLL()
        {
            //_dataObject = new Counter_Close_DetailDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Counter_Close_Detail
        /// </summary>
        /// <param name="businessObject">Counter_Close_Detail object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Counter_Close_Detail businessObject)
        {
            Counter_Close_DetailDAL _dataObject = new Counter_Close_DetailDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.CloseDetailID = Guid.NewGuid();
                    
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
        /// Update existing Counter_Close_Detail
        /// </summary>
        /// <param name="businessObject">Counter_Close_Detail object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Counter_Close_Detail businessObject)
        {
            Counter_Close_DetailDAL _dataObject = new Counter_Close_DetailDAL();
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
        /// get Counter_Close_Detail by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Counter_Close_Detail GetByPrimaryKey(Guid keys)
        {
            Counter_Close_DetailDAL _dataObject = new Counter_Close_DetailDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Counter_Close_Details
        /// </summary>
        /// <returns>list</returns>
        public static List<Counter_Close_Detail> GetAll(Counter_Close_Detail obj)
        {
            Counter_Close_DetailDAL _dataObject = new Counter_Close_DetailDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Counter_Close_Details
        /// </summary>
        /// <returns>list</returns>
        public static List<Counter_Close_Detail> GetAll()
        {
            Counter_Close_DetailDAL _dataObject = new Counter_Close_DetailDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Counter_Close_Detail by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Counter_Close_Detail> GetAllBy(Counter_Close_Detail.Counter_Close_DetailFields fieldName, object value)
        {
            Counter_Close_DetailDAL _dataObject = new Counter_Close_DetailDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Counter_Close_Details
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Counter_Close_Detail obj)
        {
            Counter_Close_DetailDAL _dataObject = new Counter_Close_DetailDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Counter_Close_Details
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            Counter_Close_DetailDAL _dataObject = new Counter_Close_DetailDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }

        public static DataSet GetCloseCounter_Denomination(Guid? PropertyID, Guid? CloseID)
        {
            Counter_Close_DetailDAL _dataObject = new Counter_Close_DetailDAL();
            return _dataObject.SelectCouterClose_Denomination(PropertyID, CloseID);
        }

        public static DataSet GetCloseCounter_GeneralInformatiom(Guid? CloseID)
        {
            Counter_Close_DetailDAL _dataObject = new Counter_Close_DetailDAL();
            return _dataObject.SelectCouterClose_GeneralInformation(CloseID);
        }

        /// <summary>
        /// get list of Counter_Close_Detail by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Counter_Close_Detail.Counter_Close_DetailFields fieldName, object value)
        {
            Counter_Close_DetailDAL _dataObject = new Counter_Close_DetailDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            Counter_Close_DetailDAL _dataObject = new Counter_Close_DetailDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Counter_Close_Detail obj)
        {
            Counter_Close_DetailDAL _dataObject = new Counter_Close_DetailDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Counter_Close_Detail by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Counter_Close_Detail.Counter_Close_DetailFields fieldName, object value)
        {
            Counter_Close_DetailDAL _dataObject = new Counter_Close_DetailDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
