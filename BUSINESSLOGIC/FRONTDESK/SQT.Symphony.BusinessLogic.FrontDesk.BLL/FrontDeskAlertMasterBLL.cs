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
    public static class FrontDeskAlertMasterBLL
    {

        //#region data Members

        //private static FrontDeskAlertMasterDAL _dataObject = null;

        //#endregion

        #region Constructor

        static FrontDeskAlertMasterBLL()
        {
            //_dataObject = new FrontDeskAlertMasterDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new FrontDeskAlertMaster
        /// </summary>
        /// <param name="businessObject">FrontDeskAlertMaster object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(FrontDeskAlertMaster businessObject)
        {
            FrontDeskAlertMasterDAL _dataObject = new FrontDeskAlertMasterDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.FrontDeskAlertMsgID = Guid.NewGuid();
                    
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
        /// Update existing FrontDeskAlertMaster
        /// </summary>
        /// <param name="businessObject">FrontDeskAlertMaster object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(FrontDeskAlertMaster businessObject)
        {
            FrontDeskAlertMasterDAL _dataObject = new FrontDeskAlertMasterDAL();
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
        /// get FrontDeskAlertMaster by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static FrontDeskAlertMaster GetByPrimaryKey(Guid keys)
        {
            FrontDeskAlertMasterDAL _dataObject = new FrontDeskAlertMasterDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all FrontDeskAlertMasters
        /// </summary>
        /// <returns>list</returns>
        public static List<FrontDeskAlertMaster> GetAll(FrontDeskAlertMaster obj)
        {
            FrontDeskAlertMasterDAL _dataObject = new FrontDeskAlertMasterDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all FrontDeskAlertMasters
        /// </summary>
        /// <returns>list</returns>
        public static List<FrontDeskAlertMaster> GetAll()
        {
            FrontDeskAlertMasterDAL _dataObject = new FrontDeskAlertMasterDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of FrontDeskAlertMaster by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<FrontDeskAlertMaster> GetAllBy(FrontDeskAlertMaster.FrontDeskAlertMasterFields fieldName, object value)
        {
            FrontDeskAlertMasterDAL _dataObject = new FrontDeskAlertMasterDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all FrontDeskAlertMasters
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(FrontDeskAlertMaster obj)
        {
            FrontDeskAlertMasterDAL _dataObject = new FrontDeskAlertMasterDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all FrontDeskAlertMasters
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            FrontDeskAlertMasterDAL _dataObject = new FrontDeskAlertMasterDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of FrontDeskAlertMaster by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(FrontDeskAlertMaster.FrontDeskAlertMasterFields fieldName, object value)
        {
            FrontDeskAlertMasterDAL _dataObject = new FrontDeskAlertMasterDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            FrontDeskAlertMasterDAL _dataObject = new FrontDeskAlertMasterDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(FrontDeskAlertMaster obj)
        {
            FrontDeskAlertMasterDAL _dataObject = new FrontDeskAlertMasterDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete FrontDeskAlertMaster by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(FrontDeskAlertMaster.FrontDeskAlertMasterFields fieldName, object value)
        {
            FrontDeskAlertMasterDAL _dataObject = new FrontDeskAlertMasterDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }
        public static DataSet GetFrontDeskAlertList(Guid? PropertyID, Guid? CompanyID, Guid? UserID, string  MessageBy, DateTime? MessageDateTime)
        {
            FrontDeskAlertMasterDAL _dataObject = new FrontDeskAlertMasterDAL();
            return _dataObject.SelectFrontDeskAlertList(PropertyID, CompanyID, UserID,MessageBy,MessageDateTime );
        }
        #endregion

    }
}
