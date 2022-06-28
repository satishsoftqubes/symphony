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
    public static class ConferenceTypeBLL
    {

        //#region data Members

        //private static ConferenceTypeDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ConferenceTypeBLL()
        {
            //_dataObject = new ConferenceTypeDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ConferenceType
        /// </summary>
        /// <param name="businessObject">ConferenceType object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ConferenceType businessObject)
        {
            ConferenceTypeDAL _dataObject = new ConferenceTypeDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ConferenceTypeID = Guid.NewGuid();
                    
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
        /// Update existing ConferenceType
        /// </summary>
        /// <param name="businessObject">ConferenceType object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ConferenceType businessObject)
        {
            ConferenceTypeDAL _dataObject = new ConferenceTypeDAL();
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
        /// get ConferenceType by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ConferenceType GetByPrimaryKey(Guid keys)
        {
            ConferenceTypeDAL _dataObject = new ConferenceTypeDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ConferenceTypes
        /// </summary>
        /// <returns>list</returns>
        public static List<ConferenceType> GetAll(ConferenceType obj)
        {
            ConferenceTypeDAL _dataObject = new ConferenceTypeDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ConferenceTypes
        /// </summary>
        /// <returns>list</returns>
        public static List<ConferenceType> GetAll()
        {
            ConferenceTypeDAL _dataObject = new ConferenceTypeDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ConferenceType by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ConferenceType> GetAllBy(ConferenceType.ConferenceTypeFields fieldName, object value)
        {
            ConferenceTypeDAL _dataObject = new ConferenceTypeDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ConferenceTypes
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ConferenceType obj)
        {
            ConferenceTypeDAL _dataObject = new ConferenceTypeDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ConferenceTypes
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ConferenceTypeDAL _dataObject = new ConferenceTypeDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ConferenceType by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ConferenceType.ConferenceTypeFields fieldName, object value)
        {
            ConferenceTypeDAL _dataObject = new ConferenceTypeDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ConferenceTypeDAL _dataObject = new ConferenceTypeDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ConferenceType obj)
        {
            ConferenceTypeDAL _dataObject = new ConferenceTypeDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ConferenceType by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ConferenceType.ConferenceTypeFields fieldName, object value)
        {
            ConferenceTypeDAL _dataObject = new ConferenceTypeDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet GetDataByConferenceID(Guid? ConferenceID, Guid? PropertyID, Guid? CompanyID)
        {
            ConferenceTypeDAL _dataObject = new ConferenceTypeDAL();
            return _dataObject.SelectDataByConferenceID(ConferenceID, PropertyID, CompanyID);
        }

        public static DataSet SearchConferenceTypeData(Guid? ConferenceTypeID, Guid? PropertyID, Guid? CompanyID, string ConferenceTypeName)
        {
            ConferenceTypeDAL _dataObject = new ConferenceTypeDAL();
            return _dataObject.SearchConferenceTypeData(ConferenceTypeID, PropertyID, CompanyID, ConferenceTypeName);
        }

        #endregion

    }
}
