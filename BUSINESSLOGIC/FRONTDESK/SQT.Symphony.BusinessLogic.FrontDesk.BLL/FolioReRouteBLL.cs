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
    public static class FolioReRouteBLL
    {

        //#region data Members

        //private static FolioReRouteDAL _dataObject = null;

        //#endregion

        #region Constructor

        static FolioReRouteBLL()
        {
            //_dataObject = new FolioReRouteDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new FolioReRoute
        /// </summary>
        /// <param name="businessObject">FolioReRoute object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(FolioReRoute businessObject)
        {
            FolioReRouteDAL _dataObject = new FolioReRouteDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.FolioReRouteID = Guid.NewGuid();
                    
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
        /// Update existing FolioReRoute
        /// </summary>
        /// <param name="businessObject">FolioReRoute object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(FolioReRoute businessObject)
        {
            FolioReRouteDAL _dataObject = new FolioReRouteDAL();
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
        /// get FolioReRoute by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static FolioReRoute GetByPrimaryKey(Guid keys)
        {
            FolioReRouteDAL _dataObject = new FolioReRouteDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all FolioReRoutes
        /// </summary>
        /// <returns>list</returns>
        public static List<FolioReRoute> GetAll(FolioReRoute obj)
        {
            FolioReRouteDAL _dataObject = new FolioReRouteDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all FolioReRoutes
        /// </summary>
        /// <returns>list</returns>
        public static List<FolioReRoute> GetAll()
        {
            FolioReRouteDAL _dataObject = new FolioReRouteDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of FolioReRoute by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<FolioReRoute> GetAllBy(FolioReRoute.FolioReRouteFields fieldName, object value)
        {
            FolioReRouteDAL _dataObject = new FolioReRouteDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all FolioReRoutes
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(FolioReRoute obj)
        {
            FolioReRouteDAL _dataObject = new FolioReRouteDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all FolioReRoutes
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            FolioReRouteDAL _dataObject = new FolioReRouteDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of FolioReRoute by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(FolioReRoute.FolioReRouteFields fieldName, object value)
        {
            FolioReRouteDAL _dataObject = new FolioReRouteDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            FolioReRouteDAL _dataObject = new FolioReRouteDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(FolioReRoute obj)
        {
            FolioReRouteDAL _dataObject = new FolioReRouteDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete FolioReRoute by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(FolioReRoute.FolioReRouteFields fieldName, object value)
        {
            FolioReRouteDAL _dataObject = new FolioReRouteDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static bool DeleteBySourceAndDestinationFolioID(Guid? SourceFolioID, Guid? DestinationFolioID)
        {
            FolioReRouteDAL _dataObject = new FolioReRouteDAL();
            return _dataObject.DeleteBySourceAndDestinationFolioID(SourceFolioID, DestinationFolioID);
        }
        #endregion

    }
}
