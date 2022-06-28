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
    public static class EMailTemplatesBLL
    {

        //#region data Members

        //private static EMailTemplatesDAL _dataObject = null;

        //#endregion

        #region Constructor

        static EMailTemplatesBLL()
        {
            //_dataObject = new EMailTemplatesDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new EMailTemplates
        /// </summary>
        /// <param name="businessObject">EMailTemplates object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(EMailTemplates businessObject)
        {
            EMailTemplatesDAL _dataObject = new EMailTemplatesDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.EmailTemplateID = Guid.NewGuid();
                    
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
        /// Update existing EMailTemplates
        /// </summary>
        /// <param name="businessObject">EMailTemplates object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(EMailTemplates businessObject)
        {
            EMailTemplatesDAL _dataObject = new EMailTemplatesDAL();
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
        /// get EMailTemplates by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static EMailTemplates GetByPrimaryKey(Guid keys)
        {
            EMailTemplatesDAL _dataObject = new EMailTemplatesDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all EMailTemplatess
        /// </summary>
        /// <returns>list</returns>
        public static List<EMailTemplates> GetAll(EMailTemplates obj)
        {
            EMailTemplatesDAL _dataObject = new EMailTemplatesDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all EMailTemplatess
        /// </summary>
        /// <returns>list</returns>
        public static List<EMailTemplates> GetAll()
        {
            EMailTemplatesDAL _dataObject = new EMailTemplatesDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of EMailTemplates by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<EMailTemplates> GetAllBy(EMailTemplates.EMailTemplatesFields fieldName, object value)
        {
            EMailTemplatesDAL _dataObject = new EMailTemplatesDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all EMailTemplatess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(EMailTemplates obj)
        {
            EMailTemplatesDAL _dataObject = new EMailTemplatesDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all EMailTemplatess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            EMailTemplatesDAL _dataObject = new EMailTemplatesDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of EMailTemplates by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(EMailTemplates.EMailTemplatesFields fieldName, object value)
        {
            EMailTemplatesDAL _dataObject = new EMailTemplatesDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            EMailTemplatesDAL _dataObject = new EMailTemplatesDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(EMailTemplates obj)
        {
            EMailTemplatesDAL _dataObject = new EMailTemplatesDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete EMailTemplates by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(EMailTemplates.EMailTemplatesFields fieldName, object value)
        {
            EMailTemplatesDAL _dataObject = new EMailTemplatesDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }
        /// <summary>
        /// get list of all EMailTemplatess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet SearchData(EMailTemplates obj)
        {
            EMailTemplatesDAL _dataObject = new EMailTemplatesDAL();
            return _dataObject.SearchData(obj);
        }

        public static DataSet GetDataByProperty(Guid? PropertyID, Guid? CompanyID, string Header)
        {
            EMailTemplatesDAL _dataObject = new EMailTemplatesDAL();
            return _dataObject.GetDataByProperty(PropertyID, CompanyID, Header);
        }

        #endregion

    }
}
