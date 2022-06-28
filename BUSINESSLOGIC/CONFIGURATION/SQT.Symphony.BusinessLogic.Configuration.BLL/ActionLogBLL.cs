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
using System.Web;

namespace SQT.Symphony.BusinessLogic.Configuration.BLL
{
    public static class ActionLogBLL
    {

        //#region data Members

        //private static ActionLogDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ActionLogBLL()
        {
            //_dataObject = new ActionLogDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ActionLog
        /// </summary>
        /// <param name="businessObject">ActionLog object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ActionLog businessObject)
        {
            ActionLogDAL _dataObject = new ActionLogDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ActionLogID = Guid.NewGuid();
                    
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
        /// Insert new ActionLog
        /// </summary>
        /// <param name="businessObject">ActionLog object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Guid? UserID, string ActionType, string OldObject, string NewObject, string ActionObject)
        {
            ActionLog businessObject = new ActionLog();
            businessObject.ActionType = ActionType;
            businessObject.ActionObject = ActionObject;
            businessObject.ObjectOldValue = OldObject;
            businessObject.ObjectNewValue = NewObject;
            businessObject.AutherizerOn = DateTime.Now;
            businessObject.ActionPerformedBy = UserID;
            businessObject.ActionPerformedOn = DateTime.Now;            

            ActionLogDAL _dataObject = new ActionLogDAL();
            try
            {
                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    businessObject.ActionLogID = Guid.NewGuid();

                    if (!businessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                    }
                    return _dataObject.Insert(businessObject);
                    //}
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

        public static bool SaveConfigurationActionLog(Guid? UserID, string ActionType, string OldObject, string NewObject, string ActionObject)
        {
            ActionLog businessObject = new ActionLog();
            businessObject.ActionType = ActionType;
            businessObject.ActionObject = ActionObject;
            businessObject.ObjectOldValue = OldObject;
            businessObject.ObjectNewValue = NewObject;
            businessObject.AutherizerOn = DateTime.Now;
            businessObject.ActionPerformedBy = UserID;
            businessObject.ActionPerformedOn = DateTime.Now;
            if (Convert.ToString(HttpContext.Current.Session["CompanyID"]) != string.Empty)
                businessObject.CompanyID = new Guid(HttpContext.Current.Session["CompanyID"].ToString());

            if (Convert.ToString(HttpContext.Current.Session["PropertyID"]) != string.Empty)
                businessObject.PropertyID = new Guid(HttpContext.Current.Session["PropertyID"].ToString());

            ActionLogDAL _dataObject = new ActionLogDAL();
            try
            {
                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    businessObject.ActionLogID = Guid.NewGuid();

                    if (!businessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                    }
                    return _dataObject.Insert(businessObject);
                    //}
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
        /// Update existing ActionLog
        /// </summary>
        /// <param name="businessObject">ActionLog object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ActionLog businessObject)
        {
            ActionLogDAL _dataObject = new ActionLogDAL();
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
        /// get ActionLog by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ActionLog GetByPrimaryKey(Guid keys)
        {
            ActionLogDAL _dataObject = new ActionLogDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ActionLogs
        /// </summary>
        /// <returns>list</returns>
        public static List<ActionLog> GetAll(ActionLog obj)
        {
            ActionLogDAL _dataObject = new ActionLogDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ActionLogs
        /// </summary>
        /// <returns>list</returns>
        public static List<ActionLog> GetAll()
        {
            ActionLogDAL _dataObject = new ActionLogDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ActionLog by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ActionLog> GetAllBy(ActionLog.ActionLogFields fieldName, object value)
        {
            ActionLogDAL _dataObject = new ActionLogDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ActionLogs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ActionLog obj)
        {
            ActionLogDAL _dataObject = new ActionLogDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ActionLogs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ActionLogDAL _dataObject = new ActionLogDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ActionLog by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ActionLog.ActionLogFields fieldName, object value)
        {
            ActionLogDAL _dataObject = new ActionLogDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }
        /// <summary>
        /// Report Action Log
        /// </summary>
        /// <param name="UserDispalayName"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public static DataSet GetRptActionLog(string UserDispalayName, DateTime? StartDate, DateTime? EndDate, string ActionType, string ActionObject)
        {
            ActionLogDAL _dataObject = new ActionLogDAL();
            return _dataObject.rptActionLog(UserDispalayName, StartDate, EndDate, ActionType, ActionObject);
        }
        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ActionLogDAL _dataObject = new ActionLogDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ActionLog obj)
        {
            ActionLogDAL _dataObject = new ActionLogDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ActionLog by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ActionLog.ActionLogFields fieldName, object value)
        {
            ActionLogDAL _dataObject = new ActionLogDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        /// <summary>
        /// Action Log Query
        /// </summary>
        /// <param name="ActionLogQuery"></param>
        /// <returns></returns>
        public static DataSet GetActionLog(string ActionLogQuery)
        {
            ActionLogDAL _dataObject = new ActionLogDAL();
            return _dataObject.SelectActionLog(ActionLogQuery);
        }

        public static DataSet ActionLogSearchData(Guid? ActionLogID, Guid? ActionPerformedBy, DateTime? ActionPerformedOn, string ActionObject, string ActionTypes)
        {
            ActionLogDAL _dataObject = new ActionLogDAL();
            return _dataObject.ActionLogSearchData(ActionLogID, ActionPerformedBy, ActionPerformedOn, ActionObject, ActionTypes);
        }

        public static DataSet ActionLogSymphonySearchData(Guid? ActionLogID, Guid? ActionPerformedBy, DateTime? ActionPerformedOn, string ActionObject, string ActionType, string UserRoleType, Guid CompanyID, Guid PropertyID, Guid UserID)
        {
            ActionLogDAL _dataObject = new ActionLogDAL();
            return _dataObject.ActionLogSymphonySearchData(ActionLogID, ActionPerformedBy, ActionPerformedOn, ActionObject, ActionType, UserRoleType, CompanyID, PropertyID, UserID);
        }

        public static bool SaveFrontdeskActionLog(Guid? UserID, string ActionType, string OldObject, string NewObject, string ActionObject,string Description)
        {
            ActionLog businessObject = new ActionLog();
            businessObject.ActionType = ActionType;
            businessObject.ActionObject = ActionObject;
            businessObject.ObjectOldValue = OldObject;
            businessObject.ObjectNewValue = NewObject;
            businessObject.AutherizerOn = DateTime.Now;
            businessObject.ActionPerformedBy = UserID;
            businessObject.ActionPerformedOn = DateTime.Now;
            businessObject.Description = Description;

            if (Convert.ToString(HttpContext.Current.Session["CompanyID"]) != string.Empty)
                businessObject.CompanyID = new Guid(HttpContext.Current.Session["CompanyID"].ToString());

            if (Convert.ToString(HttpContext.Current.Session["PropertyID"]) != string.Empty)
                businessObject.PropertyID = new Guid(HttpContext.Current.Session["PropertyID"].ToString());

            ActionLogDAL _dataObject = new ActionLogDAL();
            try
            {
                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    businessObject.ActionLogID = Guid.NewGuid();

                    if (!businessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                    }
                    return _dataObject.Insert(businessObject);
                    //}
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
        #endregion

    }
}
