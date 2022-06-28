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
    public static class PreferenceMasterBLL
    {

        //#region data Members

        //private static PreferenceMasterDAL _dataObject = null;

        //#endregion

        #region Constructor

        static PreferenceMasterBLL()
        {
            //_dataObject = new PreferenceMasterDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new PreferenceMaster
        /// </summary>
        /// <param name="businessObject">PreferenceMaster object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(PreferenceMaster businessObject)
        {
            PreferenceMasterDAL _dataObject = new PreferenceMasterDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.PreferenceID = Guid.NewGuid();

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
        /// Update existing PreferenceMaster
        /// </summary>
        /// <param name="businessObject">PreferenceMaster object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(PreferenceMaster businessObject)
        {
            PreferenceMasterDAL _dataObject = new PreferenceMasterDAL();
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
        /// get PreferenceMaster by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static PreferenceMaster GetByPrimaryKey(Guid keys)
        {
            PreferenceMasterDAL _dataObject = new PreferenceMasterDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all PreferenceMasters
        /// </summary>
        /// <returns>list</returns>
        public static List<PreferenceMaster> GetAll(PreferenceMaster obj)
        {
            PreferenceMasterDAL _dataObject = new PreferenceMasterDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all PreferenceMasters
        /// </summary>
        /// <returns>list</returns>
        public static List<PreferenceMaster> GetAll()
        {
            PreferenceMasterDAL _dataObject = new PreferenceMasterDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of PreferenceMaster by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<PreferenceMaster> GetAllBy(PreferenceMaster.PreferenceMasterFields fieldName, object value)
        {
            PreferenceMasterDAL _dataObject = new PreferenceMasterDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all PreferenceMasters
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(PreferenceMaster obj)
        {
            PreferenceMasterDAL _dataObject = new PreferenceMasterDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all PreferenceMasters
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            PreferenceMasterDAL _dataObject = new PreferenceMasterDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of PreferenceMaster by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(PreferenceMaster.PreferenceMasterFields fieldName, object value)
        {
            PreferenceMasterDAL _dataObject = new PreferenceMasterDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            PreferenceMasterDAL _dataObject = new PreferenceMasterDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(PreferenceMaster obj)
        {
            PreferenceMasterDAL _dataObject = new PreferenceMasterDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete PreferenceMaster by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(PreferenceMaster.PreferenceMasterFields fieldName, object value)
        {
            PreferenceMasterDAL _dataObject = new PreferenceMasterDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }



        public static DataSet GetAllForList(Guid PropertyID, Guid CompanyID)
        {
            PreferenceMasterDAL _dataObject = new PreferenceMasterDAL();
            return _dataObject.SelectAllForList(PropertyID, CompanyID);
        }





        #endregion

    }
}
