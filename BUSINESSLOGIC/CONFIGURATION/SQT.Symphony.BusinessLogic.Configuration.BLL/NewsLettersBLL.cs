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
    public static class NewsLettersBLL
    {

        //#region data Members

        //private static NewsLettersDAL _dataObject = null;

        //#endregion

        #region Constructor

        static NewsLettersBLL()
        {
            //_dataObject = new NewsLettersDAL();
        }

        #endregion

        #region Public Methods
        public static DataSet SearchData(string Title)
        {
            NewsLettersDAL _Obj = new NewsLettersDAL();
            return _Obj.SearchData(Title);
        }
        /// <summary>
        /// Insert new NewsLetters
        /// </summary>
        /// <param name="businessObject">NewsLetters object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(NewsLetters businessObject)
        {
            NewsLettersDAL _dataObject = new NewsLettersDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.NewsLetterID = Guid.NewGuid();
                    
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
        /// Update existing NewsLetters
        /// </summary>
        /// <param name="businessObject">NewsLetters object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(NewsLetters businessObject)
        {
            NewsLettersDAL _dataObject = new NewsLettersDAL();
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
        /// get NewsLetters by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static NewsLetters GetByPrimaryKey(Guid keys)
        {
            NewsLettersDAL _dataObject = new NewsLettersDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all NewsLetterss
        /// </summary>
        /// <returns>list</returns>
        public static List<NewsLetters> GetAll(NewsLetters obj)
        {
            NewsLettersDAL _dataObject = new NewsLettersDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all NewsLetterss
        /// </summary>
        /// <returns>list</returns>
        public static List<NewsLetters> GetAll()
        {
            NewsLettersDAL _dataObject = new NewsLettersDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of NewsLetters by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<NewsLetters> GetAllBy(NewsLetters.NewsLettersFields fieldName, object value)
        {
            NewsLettersDAL _dataObject = new NewsLettersDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all NewsLetterss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(NewsLetters obj)
        {
            NewsLettersDAL _dataObject = new NewsLettersDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all NewsLetterss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            NewsLettersDAL _dataObject = new NewsLettersDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of NewsLetters by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(NewsLetters.NewsLettersFields fieldName, object value)
        {
            NewsLettersDAL _dataObject = new NewsLettersDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            NewsLettersDAL _dataObject = new NewsLettersDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(NewsLetters obj)
        {
            NewsLettersDAL _dataObject = new NewsLettersDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete NewsLetters by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(NewsLetters.NewsLettersFields fieldName, object value)
        {
            NewsLettersDAL _dataObject = new NewsLettersDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
