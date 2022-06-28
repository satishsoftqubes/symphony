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
using SQT.Symphony.BusinessLogic.BackOffice.DTO;
using SQT.Symphony.BusinessLogic.BackOffice.DAL;

namespace SQT.Symphony.BusinessLogic.BackOffice.BLL
{
    public static class AcctTaxJoinBLL
    {

        //#region data Members

        //private static AcctTaxJoinDAL _dataObject = null;

        //#endregion

        #region Constructor

        static AcctTaxJoinBLL()
        {
            //_dataObject = new AcctTaxJoinDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new AcctTaxJoin
        /// </summary>
        /// <param name="businessObject">AcctTaxJoin object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(AcctTaxJoin businessObject)
        {
            AcctTaxJoinDAL _dataObject = new AcctTaxJoinDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.TaxJoinID = Guid.NewGuid();
                    
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
        /// Update existing AcctTaxJoin
        /// </summary>
        /// <param name="businessObject">AcctTaxJoin object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(AcctTaxJoin businessObject)
        {
            AcctTaxJoinDAL _dataObject = new AcctTaxJoinDAL();
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
        /// get AcctTaxJoin by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static AcctTaxJoin GetByPrimaryKey(Guid keys)
        {
            AcctTaxJoinDAL _dataObject = new AcctTaxJoinDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all AcctTaxJoins
        /// </summary>
        /// <returns>list</returns>
        public static List<AcctTaxJoin> GetAll(AcctTaxJoin obj)
        {
            AcctTaxJoinDAL _dataObject = new AcctTaxJoinDAL();
            return _dataObject.SelectAll(obj); 
        }

        public static DataSet GetAllWithDataSet(Guid? TaxJoinID, Guid? AcctID, Guid? AcctTaxID)
        {
            AcctTaxJoinDAL _dataObject = new AcctTaxJoinDAL();
            return _dataObject.SelectAllWithDataSet(TaxJoinID, AcctID, AcctTaxID);
        }

        /// <summary>
        /// get list of all AcctTaxJoins
        /// </summary>
        /// <returns>list</returns>
        public static List<AcctTaxJoin> GetAll()
        {
            AcctTaxJoinDAL _dataObject = new AcctTaxJoinDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of AcctTaxJoin by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<AcctTaxJoin> GetAllBy(AcctTaxJoin.AcctTaxJoinFields fieldName, object value)
        {
            AcctTaxJoinDAL _dataObject = new AcctTaxJoinDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all AcctTaxJoins
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(AcctTaxJoin obj)
        {
            AcctTaxJoinDAL _dataObject = new AcctTaxJoinDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all AcctTaxJoins
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            AcctTaxJoinDAL _dataObject = new AcctTaxJoinDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of AcctTaxJoin by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(AcctTaxJoin.AcctTaxJoinFields fieldName, object value)
        {
            AcctTaxJoinDAL _dataObject = new AcctTaxJoinDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            AcctTaxJoinDAL _dataObject = new AcctTaxJoinDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(AcctTaxJoin obj)
        {
            AcctTaxJoinDAL _dataObject = new AcctTaxJoinDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete AcctTaxJoin by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(AcctTaxJoin.AcctTaxJoinFields fieldName, object value)
        {
            AcctTaxJoinDAL _dataObject = new AcctTaxJoinDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
