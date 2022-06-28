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
    public static class DepartmentBLL
    {

        //#region data Members

        //private static DepartmentDAL _dataObject = null;

        //#endregion

        #region Constructor

        static DepartmentBLL()
        {
            //_dataObject = new DepartmentDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Department
        /// </summary>
        /// <param name="businessObject">Department object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Department businessObject)
        {
            DepartmentDAL _dataObject = new DepartmentDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.DepartmentID = Guid.NewGuid();
                    
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
        /// Update existing Department
        /// </summary>
        /// <param name="businessObject">Department object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Department businessObject)
        {
            DepartmentDAL _dataObject = new DepartmentDAL();
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
        /// get Department by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Department GetByPrimaryKey(Guid keys)
        {
            DepartmentDAL _dataObject = new DepartmentDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Departments
        /// </summary>
        /// <returns>list</returns>
        public static List<Department> GetAll(Department obj)
        {
            DepartmentDAL _dataObject = new DepartmentDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Departments
        /// </summary>
        /// <returns>list</returns>
        public static List<Department> GetAll()
        {
            DepartmentDAL _dataObject = new DepartmentDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Department by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Department> GetAllBy(Department.DepartmentFields fieldName, object value)
        {
            DepartmentDAL _dataObject = new DepartmentDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Departments
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Department obj)
        {
            DepartmentDAL _dataObject = new DepartmentDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Departments
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            DepartmentDAL _dataObject = new DepartmentDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Department by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Department.DepartmentFields fieldName, object value)
        {
            DepartmentDAL _dataObject = new DepartmentDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            DepartmentDAL _dataObject = new DepartmentDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Department obj)
        {
            DepartmentDAL _dataObject = new DepartmentDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Department by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Department.DepartmentFields fieldName, object value)
        {
            DepartmentDAL _dataObject = new DepartmentDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet GetSearcahDepartmentData(Guid? PropertyID, Guid? DepartmentID, string DepartmentName, Guid? CompanyID)
        {
            DepartmentDAL _dataObject = new DepartmentDAL();
            DataSet ds = _dataObject.SearchDepartment(PropertyID, DepartmentID, DepartmentName, CompanyID);
            return ds;
        }

        public static DataSet SearchDepartmentData(Guid? DepartmentID, Guid? PropertyID, Guid? CompanyID, string DepartmentName)
        {
            DepartmentDAL _dataObject = new DepartmentDAL();
            return _dataObject.SearchDepartmentData(DepartmentID, PropertyID, CompanyID, DepartmentName);
        }
        #endregion

    }
}
