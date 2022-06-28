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
    public static class ServiceVendorMasterBLL
    {

        //#region data Members

        //private static ServiceVendorMasterDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ServiceVendorMasterBLL()
        {
            //_dataObject = new ServiceVendorMasterDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ServiceVendorMaster
        /// </summary>
        /// <param name="businessObject">ServiceVendorMaster object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ServiceVendorMaster businessObject)
        {
            ServiceVendorMasterDAL _dataObject = new ServiceVendorMasterDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.VendorID = Guid.NewGuid();
                    
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
        /// Update existing ServiceVendorMaster
        /// </summary>
        /// <param name="businessObject">ServiceVendorMaster object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ServiceVendorMaster businessObject)
        {
            ServiceVendorMasterDAL _dataObject = new ServiceVendorMasterDAL();
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
        /// get ServiceVendorMaster by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ServiceVendorMaster GetByPrimaryKey(Guid keys)
        {
            ServiceVendorMasterDAL _dataObject = new ServiceVendorMasterDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ServiceVendorMasters
        /// </summary>
        /// <returns>list</returns>
        public static List<ServiceVendorMaster> GetAll(ServiceVendorMaster obj)
        {
            ServiceVendorMasterDAL _dataObject = new ServiceVendorMasterDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ServiceVendorMasters
        /// </summary>
        /// <returns>list</returns>
        public static List<ServiceVendorMaster> GetAll()
        {
            ServiceVendorMasterDAL _dataObject = new ServiceVendorMasterDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ServiceVendorMaster by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ServiceVendorMaster> GetAllBy(ServiceVendorMaster.ServiceVendorMasterFields fieldName, object value)
        {
            ServiceVendorMasterDAL _dataObject = new ServiceVendorMasterDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ServiceVendorMasters
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ServiceVendorMaster obj)
        {
            ServiceVendorMasterDAL _dataObject = new ServiceVendorMasterDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ServiceVendorMasters
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ServiceVendorMasterDAL _dataObject = new ServiceVendorMasterDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ServiceVendorMaster by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ServiceVendorMaster.ServiceVendorMasterFields fieldName, object value)
        {
            ServiceVendorMasterDAL _dataObject = new ServiceVendorMasterDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ServiceVendorMasterDAL _dataObject = new ServiceVendorMasterDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ServiceVendorMaster obj)
        {
            ServiceVendorMasterDAL _dataObject = new ServiceVendorMasterDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ServiceVendorMaster by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ServiceVendorMaster.ServiceVendorMasterFields fieldName, object value)
        {
            ServiceVendorMasterDAL _dataObject = new ServiceVendorMasterDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet SearchVendorData(string CompanyName, string ContactPersonName, Guid? CompanyID, Guid? PropertyID)
        {
            ServiceVendorMasterDAL _dataObject = new ServiceVendorMasterDAL();
            return _dataObject.SearchVendorData(CompanyName, ContactPersonName, CompanyID, PropertyID);
        }
        #endregion

    }
}
