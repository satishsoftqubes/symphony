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
    public static class GuestComplaintBLL
    {

        //#region data Members

        //private static GuestComplaintDAL _dataObject = null;

        //#endregion

        #region Constructor

        static GuestComplaintBLL()
        {
            //_dataObject = new GuestComplaintDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new GuestComplaint
        /// </summary>
        /// <param name="businessObject">GuestComplaint object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(GuestComplaint businessObject)
        {
            GuestComplaintDAL _dataObject = new GuestComplaintDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.GuestComplaintID = Guid.NewGuid();
                    
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
        /// Update existing GuestComplaint
        /// </summary>
        /// <param name="businessObject">GuestComplaint object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(GuestComplaint businessObject)
        {
            GuestComplaintDAL _dataObject = new GuestComplaintDAL();
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
        /// get GuestComplaint by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static GuestComplaint GetByPrimaryKey(Guid keys)
        {
            GuestComplaintDAL _dataObject = new GuestComplaintDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all GuestComplaints
        /// </summary>
        /// <returns>list</returns>
        public static List<GuestComplaint> GetAll(GuestComplaint obj)
        {
            GuestComplaintDAL _dataObject = new GuestComplaintDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all GuestComplaints
        /// </summary>
        /// <returns>list</returns>
        public static List<GuestComplaint> GetAll()
        {
            GuestComplaintDAL _dataObject = new GuestComplaintDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of GuestComplaint by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<GuestComplaint> GetAllBy(GuestComplaint.GuestComplaintFields fieldName, object value)
        {
            GuestComplaintDAL _dataObject = new GuestComplaintDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all GuestComplaints
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(GuestComplaint obj)
        {
            GuestComplaintDAL _dataObject = new GuestComplaintDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all GuestComplaints
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            GuestComplaintDAL _dataObject = new GuestComplaintDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of GuestComplaint by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(GuestComplaint.GuestComplaintFields fieldName, object value)
        {
            GuestComplaintDAL _dataObject = new GuestComplaintDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            GuestComplaintDAL _dataObject = new GuestComplaintDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(GuestComplaint obj)
        {
            GuestComplaintDAL _dataObject = new GuestComplaintDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete GuestComplaint by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(GuestComplaint.GuestComplaintFields fieldName, object value)
        {
            GuestComplaintDAL _dataObject = new GuestComplaintDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet GetAllForComplaintGuestList(Guid PropertyID, Guid CompanyID, Guid GuestID)
        {
            GuestComplaintDAL _dataObject = new GuestComplaintDAL();
            return _dataObject.SelectAllForList(PropertyID, CompanyID, GuestID);
        }
        #endregion

    }
}
