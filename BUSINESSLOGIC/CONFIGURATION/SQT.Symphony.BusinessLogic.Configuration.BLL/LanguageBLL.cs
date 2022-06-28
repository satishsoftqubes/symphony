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
    public static class LanguageBLL
    {

        //#region data Members

        //private static LanguageDAL _dataObject = null;

        //#endregion

        #region Constructor

        static LanguageBLL()
        {
            //_dataObject = new LanguageDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Language
        /// </summary>
        /// <param name="businessObject">Language object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Language businessObject)
        {
            LanguageDAL _dataObject = new LanguageDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.LanguageID = Guid.NewGuid();
                    
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
        /// Update existing Language
        /// </summary>
        /// <param name="businessObject">Language object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Language businessObject)
        {
            LanguageDAL _dataObject = new LanguageDAL();
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
        /// get Language by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Language GetByPrimaryKey(Guid keys)
        {
            LanguageDAL _dataObject = new LanguageDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Languages
        /// </summary>
        /// <returns>list</returns>
        public static List<Language> GetAll(Language obj)
        {
            LanguageDAL _dataObject = new LanguageDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Languages
        /// </summary>
        /// <returns>list</returns>
        public static List<Language> GetAll()
        {
            LanguageDAL _dataObject = new LanguageDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Language by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Language> GetAllBy(Language.LanguageFields fieldName, object value)
        {
            LanguageDAL _dataObject = new LanguageDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Languages
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Language obj)
        {
            LanguageDAL _dataObject = new LanguageDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Languages
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            LanguageDAL _dataObject = new LanguageDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Language by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Language.LanguageFields fieldName, object value)
        {
            LanguageDAL _dataObject = new LanguageDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            LanguageDAL _dataObject = new LanguageDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Language obj)
        {
            LanguageDAL _dataObject = new LanguageDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Language by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Language.LanguageFields fieldName, object value)
        {
            LanguageDAL _dataObject = new LanguageDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
