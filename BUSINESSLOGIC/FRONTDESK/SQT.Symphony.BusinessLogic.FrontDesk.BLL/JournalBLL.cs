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
    public static class JournalBLL
    {

        //#region data Members

        //private static JournalDAL _dataObject = null;

        //#endregion

        #region Constructor

        static JournalBLL()
        {
            //_dataObject = new JournalDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Journal
        /// </summary>
        /// <param name="businessObject">Journal object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Journal businessObject)
        {
            JournalDAL _dataObject = new JournalDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.JournalID = Guid.NewGuid();
                    
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
        /// Update existing Journal
        /// </summary>
        /// <param name="businessObject">Journal object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Journal businessObject)
        {
            JournalDAL _dataObject = new JournalDAL();
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
        /// get Journal by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Journal GetByPrimaryKey(Guid keys)
        {
            JournalDAL _dataObject = new JournalDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Journals
        /// </summary>
        /// <returns>list</returns>
        public static List<Journal> GetAll(Journal obj)
        {
            JournalDAL _dataObject = new JournalDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Journals
        /// </summary>
        /// <returns>list</returns>
        public static List<Journal> GetAll()
        {
            JournalDAL _dataObject = new JournalDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Journal by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Journal> GetAllBy(Journal.JournalFields fieldName, object value)
        {
            JournalDAL _dataObject = new JournalDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Journals
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Journal obj)
        {
            JournalDAL _dataObject = new JournalDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Journals
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            JournalDAL _dataObject = new JournalDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Journal by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Journal.JournalFields fieldName, object value)
        {
            JournalDAL _dataObject = new JournalDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            JournalDAL _dataObject = new JournalDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Journal obj)
        {
            JournalDAL _dataObject = new JournalDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Journal by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Journal.JournalFields fieldName, object value)
        {
            JournalDAL _dataObject = new JournalDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
