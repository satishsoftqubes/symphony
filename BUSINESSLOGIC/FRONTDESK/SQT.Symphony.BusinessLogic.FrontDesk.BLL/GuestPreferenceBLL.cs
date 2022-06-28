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
    public static class GuestPreferenceBLL
    {

        //#region data Members

        //private static GuestPreferenceDAL _dataObject = null;

        //#endregion

        #region Constructor

        static GuestPreferenceBLL()
        {
            //_dataObject = new GuestPreferenceDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new GuestPreference
        /// </summary>
        /// <param name="businessObject">GuestPreference object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(GuestPreference businessObject)
        {
            GuestPreferenceDAL _dataObject = new GuestPreferenceDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.GuestPrefID = Guid.NewGuid();

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
        /// Update existing GuestPreference
        /// </summary>
        /// <param name="businessObject">GuestPreference object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(GuestPreference businessObject)
        {
            GuestPreferenceDAL _dataObject = new GuestPreferenceDAL();
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
        /// get GuestPreference by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static GuestPreference GetByPrimaryKey(Guid keys)
        {
            GuestPreferenceDAL _dataObject = new GuestPreferenceDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all GuestPreferences
        /// </summary>
        /// <returns>list</returns>
        public static List<GuestPreference> GetAll(GuestPreference obj)
        {
            GuestPreferenceDAL _dataObject = new GuestPreferenceDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all GuestPreferences
        /// </summary>
        /// <returns>list</returns>
        public static List<GuestPreference> GetAll()
        {
            GuestPreferenceDAL _dataObject = new GuestPreferenceDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of GuestPreference by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<GuestPreference> GetAllBy(GuestPreference.GuestPreferenceFields fieldName, object value)
        {
            GuestPreferenceDAL _dataObject = new GuestPreferenceDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all GuestPreferences
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(GuestPreference obj)
        {
            GuestPreferenceDAL _dataObject = new GuestPreferenceDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all GuestPreferences
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            GuestPreferenceDAL _dataObject = new GuestPreferenceDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of GuestPreference by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(GuestPreference.GuestPreferenceFields fieldName, object value)
        {
            GuestPreferenceDAL _dataObject = new GuestPreferenceDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            GuestPreferenceDAL _dataObject = new GuestPreferenceDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(GuestPreference obj)
        {
            GuestPreferenceDAL _dataObject = new GuestPreferenceDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete GuestPreference by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(GuestPreference.GuestPreferenceFields fieldName, object value)
        {
            GuestPreferenceDAL _dataObject = new GuestPreferenceDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }



        public static DataSet GetAllForGuestPreferenceList(Guid PropertyID, Guid CompanyID, Guid GuestID)
        {
            GuestPreferenceDAL _dataObject = new GuestPreferenceDAL();
            return _dataObject.SelectAllForList(PropertyID, CompanyID, GuestID);
        }




        #endregion

    }
}
