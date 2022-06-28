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
    public static class DenominationBLL
    {

        //#region data Members

        //private static DenominationDAL _dataObject = null;

        //#endregion

        #region Constructor

        static DenominationBLL()
        {
            //_dataObject = new DenominationDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Denomination
        /// </summary>
        /// <param name="businessObject">Denomination object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Denomination businessObject)
        {
            DenominationDAL _dataObject = new DenominationDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.CurDenominationID = Guid.NewGuid();
                    
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
        /// Update existing Denomination
        /// </summary>
        /// <param name="businessObject">Denomination object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Denomination businessObject)
        {
            DenominationDAL _dataObject = new DenominationDAL();
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
        /// get Denomination by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Denomination GetByPrimaryKey(Guid keys)
        {
            DenominationDAL _dataObject = new DenominationDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Denominations
        /// </summary>
        /// <returns>list</returns>
        public static List<Denomination> GetAll(Denomination obj)
        {
            DenominationDAL _dataObject = new DenominationDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Denominations
        /// </summary>
        /// <returns>list</returns>
        public static List<Denomination> GetAll()
        {
            DenominationDAL _dataObject = new DenominationDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Denomination by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Denomination> GetAllBy(Denomination.DenominationFields fieldName, object value)
        {
            DenominationDAL _dataObject = new DenominationDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Denominations
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Denomination obj)
        {
            DenominationDAL _dataObject = new DenominationDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Denominations
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            DenominationDAL _dataObject = new DenominationDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Denomination by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Denomination.DenominationFields fieldName, object value)
        {
            DenominationDAL _dataObject = new DenominationDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            DenominationDAL _dataObject = new DenominationDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Denomination obj)
        {
            DenominationDAL _dataObject = new DenominationDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Denomination by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Denomination.DenominationFields fieldName, object value)
        {
            DenominationDAL _dataObject = new DenominationDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }
        public static DataSet GetDenominationInformation(Guid? CompanyID, Guid? PropertyID, string Name)
        {
            DenominationDAL _obj = new DenominationDAL();
            return _obj.GetDenominationInformation(CompanyID, PropertyID, Name);
        }
        #endregion

    }
}
