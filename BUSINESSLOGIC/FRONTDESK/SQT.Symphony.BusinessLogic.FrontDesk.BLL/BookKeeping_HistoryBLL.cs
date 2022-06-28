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
    public static class BookKeeping_HistoryBLL
    {

        //#region data Members

        //private static BookKeeping_HistoryDAL _dataObject = null;

        //#endregion

        #region Constructor

        static BookKeeping_HistoryBLL()
        {
            //_dataObject = new BookKeeping_HistoryDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new BookKeeping_History
        /// </summary>
        /// <param name="businessObject">BookKeeping_History object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(BookKeeping_History businessObject)
        {
            BookKeeping_HistoryDAL _dataObject = new BookKeeping_HistoryDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.BookHistoryID = Guid.NewGuid();
                    
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
        /// Update existing BookKeeping_History
        /// </summary>
        /// <param name="businessObject">BookKeeping_History object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(BookKeeping_History businessObject)
        {
            BookKeeping_HistoryDAL _dataObject = new BookKeeping_HistoryDAL();
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
        /// get BookKeeping_History by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static BookKeeping_History GetByPrimaryKey(Guid keys)
        {
            BookKeeping_HistoryDAL _dataObject = new BookKeeping_HistoryDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all BookKeeping_Historys
        /// </summary>
        /// <returns>list</returns>
        public static List<BookKeeping_History> GetAll(BookKeeping_History obj)
        {
            BookKeeping_HistoryDAL _dataObject = new BookKeeping_HistoryDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all BookKeeping_Historys
        /// </summary>
        /// <returns>list</returns>
        public static List<BookKeeping_History> GetAll()
        {
            BookKeeping_HistoryDAL _dataObject = new BookKeeping_HistoryDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of BookKeeping_History by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<BookKeeping_History> GetAllBy(BookKeeping_History.BookKeeping_HistoryFields fieldName, object value)
        {
            BookKeeping_HistoryDAL _dataObject = new BookKeeping_HistoryDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all BookKeeping_Historys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(BookKeeping_History obj)
        {
            BookKeeping_HistoryDAL _dataObject = new BookKeeping_HistoryDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all BookKeeping_Historys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            BookKeeping_HistoryDAL _dataObject = new BookKeeping_HistoryDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of BookKeeping_History by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(BookKeeping_History.BookKeeping_HistoryFields fieldName, object value)
        {
            BookKeeping_HistoryDAL _dataObject = new BookKeeping_HistoryDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            BookKeeping_HistoryDAL _dataObject = new BookKeeping_HistoryDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(BookKeeping_History obj)
        {
            BookKeeping_HistoryDAL _dataObject = new BookKeeping_HistoryDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete BookKeeping_History by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(BookKeeping_History.BookKeeping_HistoryFields fieldName, object value)
        {
            BookKeeping_HistoryDAL _dataObject = new BookKeeping_HistoryDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
