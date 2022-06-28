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
    public static class GuestCommentsBLL
    {

        //#region data Members

        //private static GuestCommentsDAL _dataObject = null;

        //#endregion

        #region Constructor

        static GuestCommentsBLL()
        {
            //_dataObject = new GuestCommentsDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new GuestComments
        /// </summary>
        /// <param name="businessObject">GuestComments object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(GuestComments businessObject)
        {
            GuestCommentsDAL _dataObject = new GuestCommentsDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.GuestCommentID = Guid.NewGuid();
                    
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
        /// Update existing GuestComments
        /// </summary>
        /// <param name="businessObject">GuestComments object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(GuestComments businessObject)
        {
            GuestCommentsDAL _dataObject = new GuestCommentsDAL();
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
        /// get GuestComments by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static GuestComments GetByPrimaryKey(Guid keys)
        {
            GuestCommentsDAL _dataObject = new GuestCommentsDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all GuestCommentss
        /// </summary>
        /// <returns>list</returns>
        public static List<GuestComments> GetAll(GuestComments obj)
        {
            GuestCommentsDAL _dataObject = new GuestCommentsDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all GuestCommentss
        /// </summary>
        /// <returns>list</returns>
        public static List<GuestComments> GetAll()
        {
            GuestCommentsDAL _dataObject = new GuestCommentsDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of GuestComments by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<GuestComments> GetAllBy(GuestComments.GuestCommentsFields fieldName, object value)
        {
            GuestCommentsDAL _dataObject = new GuestCommentsDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all GuestCommentss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(GuestComments obj)
        {
            GuestCommentsDAL _dataObject = new GuestCommentsDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all GuestCommentss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            GuestCommentsDAL _dataObject = new GuestCommentsDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of GuestComments by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(GuestComments.GuestCommentsFields fieldName, object value)
        {
            GuestCommentsDAL _dataObject = new GuestCommentsDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            GuestCommentsDAL _dataObject = new GuestCommentsDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(GuestComments obj)
        {
            GuestCommentsDAL _dataObject = new GuestCommentsDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete GuestComments by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(GuestComments.GuestCommentsFields fieldName, object value)
        {
            GuestCommentsDAL _dataObject = new GuestCommentsDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet GetAllForCommentsGuestList(Guid PropertyID, Guid CompanyID, Guid GuestID)
        {
            GuestCommentsDAL _dataObject = new GuestCommentsDAL();
            return _dataObject.SelectAllForList(PropertyID, CompanyID, GuestID);
        }

        #endregion

    }
}
