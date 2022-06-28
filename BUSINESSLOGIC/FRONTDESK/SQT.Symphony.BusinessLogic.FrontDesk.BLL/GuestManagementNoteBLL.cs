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
    public static class GuestManagementNoteBLL
    {

        //#region data Members

        //private static GuestManagementNoteDAL _dataObject = null;

        //#endregion

        #region Constructor

        static GuestManagementNoteBLL()
        {
            //_dataObject = new GuestManagementNoteDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new GuestManagementNote
        /// </summary>
        /// <param name="businessObject">GuestManagementNote object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(GuestManagementNote businessObject)
        {
            GuestManagementNoteDAL _dataObject = new GuestManagementNoteDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.NoteID = Guid.NewGuid();

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
        /// Update existing GuestManagementNote
        /// </summary>
        /// <param name="businessObject">GuestManagementNote object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(GuestManagementNote businessObject)
        {
            GuestManagementNoteDAL _dataObject = new GuestManagementNoteDAL();
            try
            {
                if (businessObject != null)
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
        /// get GuestManagementNote by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static GuestManagementNote GetByPrimaryKey(Guid keys)
        {
            GuestManagementNoteDAL _dataObject = new GuestManagementNoteDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all GuestManagementNotes
        /// </summary>
        /// <returns>list</returns>
        public static List<GuestManagementNote> GetAll(GuestManagementNote obj)
        {
            GuestManagementNoteDAL _dataObject = new GuestManagementNoteDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all GuestManagementNotes
        /// </summary>
        /// <returns>list</returns>
        public static List<GuestManagementNote> GetAll()
        {
            GuestManagementNoteDAL _dataObject = new GuestManagementNoteDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of GuestManagementNote by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<GuestManagementNote> GetAllBy(GuestManagementNote.GuestManagementNoteFields fieldName, object value)
        {
            GuestManagementNoteDAL _dataObject = new GuestManagementNoteDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all GuestManagementNotes
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(GuestManagementNote obj)
        {
            GuestManagementNoteDAL _dataObject = new GuestManagementNoteDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all GuestManagementNotes
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            GuestManagementNoteDAL _dataObject = new GuestManagementNoteDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of GuestManagementNote by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(GuestManagementNote.GuestManagementNoteFields fieldName, object value)
        {
            GuestManagementNoteDAL _dataObject = new GuestManagementNoteDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            GuestManagementNoteDAL _dataObject = new GuestManagementNoteDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(GuestManagementNote obj)
        {
            GuestManagementNoteDAL _dataObject = new GuestManagementNoteDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete GuestManagementNote by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(GuestManagementNote.GuestManagementNoteFields fieldName, object value)
        {
            GuestManagementNoteDAL _dataObject = new GuestManagementNoteDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }






        //public static List<GuestManagementNote> GetAllForList(Guid PropertyID, Guid CompanyID)
        //{
        //    GuestManagementNoteDAL _dataObject = new GuestManagementNoteDAL();
        //    return _dataObject.SelectAllForList(PropertyID, CompanyID);
        //}


        public static DataSet GetAllForGuestManagementNoteList(Guid PropertyID, Guid CompanyID, Guid GuestID)
        {
            GuestManagementNoteDAL _dataObject = new GuestManagementNoteDAL();
            return _dataObject.SelectAllForList(PropertyID, CompanyID, GuestID);
        }



        #endregion

    }
}
