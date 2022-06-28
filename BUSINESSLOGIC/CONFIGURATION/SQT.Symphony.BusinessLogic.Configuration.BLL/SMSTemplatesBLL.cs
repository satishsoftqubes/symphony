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
    public static class SMSTemplatesBLL
    {

        //#region data Members

        //private static SMSTemplatesDAL _dataObject = null;

        //#endregion

        #region Constructor

        static SMSTemplatesBLL()
        {
            //_dataObject = new SMSTemplatesDAL();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Search Data 
        /// </summary>
        /// <returns></returns>
        public static DataSet SearchData(string Title)
        {
            SMSTemplatesDAL _Obj = new SMSTemplatesDAL();
            return _Obj.SearchData(Title);
        }
        /// <summary>
        /// Insert new SMSTemplates
        /// </summary>
        /// <param name="businessObject">SMSTemplates object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(SMSTemplates businessObject)
        {
            SMSTemplatesDAL _dataObject = new SMSTemplatesDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.SMSTemplateID = Guid.NewGuid();
                    
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
        /// Update existing SMSTemplates
        /// </summary>
        /// <param name="businessObject">SMSTemplates object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(SMSTemplates businessObject)
        {
            SMSTemplatesDAL _dataObject = new SMSTemplatesDAL();
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
        /// get SMSTemplates by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static SMSTemplates GetByPrimaryKey(Guid keys)
        {
            SMSTemplatesDAL _dataObject = new SMSTemplatesDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all SMSTemplatess
        /// </summary>
        /// <returns>list</returns>
        public static List<SMSTemplates> GetAll(SMSTemplates obj)
        {
            SMSTemplatesDAL _dataObject = new SMSTemplatesDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all SMSTemplatess
        /// </summary>
        /// <returns>list</returns>
        public static List<SMSTemplates> GetAll()
        {
            SMSTemplatesDAL _dataObject = new SMSTemplatesDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of SMSTemplates by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<SMSTemplates> GetAllBy(SMSTemplates.SMSTemplatesFields fieldName, object value)
        {
            SMSTemplatesDAL _dataObject = new SMSTemplatesDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all SMSTemplatess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(SMSTemplates obj)
        {
            SMSTemplatesDAL _dataObject = new SMSTemplatesDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all SMSTemplatess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            SMSTemplatesDAL _dataObject = new SMSTemplatesDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of SMSTemplates by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(SMSTemplates.SMSTemplatesFields fieldName, object value)
        {
            SMSTemplatesDAL _dataObject = new SMSTemplatesDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            SMSTemplatesDAL _dataObject = new SMSTemplatesDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(SMSTemplates obj)
        {
            SMSTemplatesDAL _dataObject = new SMSTemplatesDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete SMSTemplates by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(SMSTemplates.SMSTemplatesFields fieldName, object value)
        {
            SMSTemplatesDAL _dataObject = new SMSTemplatesDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
