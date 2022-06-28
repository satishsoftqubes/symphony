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
    public static class ReservationConfigBLL
    {

        //#region data Members

        //private static ReservationConfigDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ReservationConfigBLL()
        {
            //_dataObject = new ReservationConfigDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ReservationConfig
        /// </summary>
        /// <param name="businessObject">ReservationConfig object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ReservationConfig businessObject)
        {
            ReservationConfigDAL _dataObject = new ReservationConfigDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ResConfigID = Guid.NewGuid();
                    
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
        /// Update existing ReservationConfig
        /// </summary>
        /// <param name="businessObject">ReservationConfig object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ReservationConfig businessObject)
        {
            ReservationConfigDAL _dataObject = new ReservationConfigDAL();
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
        /// get ReservationConfig by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ReservationConfig GetByPrimaryKey(Guid keys)
        {
            ReservationConfigDAL _dataObject = new ReservationConfigDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ReservationConfigs
        /// </summary>
        /// <returns>list</returns>
        public static List<ReservationConfig> GetAll(ReservationConfig obj)
        {
            ReservationConfigDAL _dataObject = new ReservationConfigDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ReservationConfigs
        /// </summary>
        /// <returns>list</returns>
        public static List<ReservationConfig> GetAll()
        {
            ReservationConfigDAL _dataObject = new ReservationConfigDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ReservationConfig by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ReservationConfig> GetAllBy(ReservationConfig.ReservationConfigFields fieldName, object value)
        {
            ReservationConfigDAL _dataObject = new ReservationConfigDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ReservationConfigs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ReservationConfig obj)
        {
            ReservationConfigDAL _dataObject = new ReservationConfigDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ReservationConfigs
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ReservationConfigDAL _dataObject = new ReservationConfigDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ReservationConfig by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ReservationConfig.ReservationConfigFields fieldName, object value)
        {
            ReservationConfigDAL _dataObject = new ReservationConfigDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ReservationConfigDAL _dataObject = new ReservationConfigDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ReservationConfig obj)
        {
            ReservationConfigDAL _dataObject = new ReservationConfigDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ReservationConfig by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ReservationConfig.ReservationConfigFields fieldName, object value)
        {
            ReservationConfigDAL _dataObject = new ReservationConfigDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet SelectRetentionAccountID(Guid? propertyID)
        {
            ReservationConfigDAL _dataObject = new ReservationConfigDAL();
            return _dataObject.SelectRetentionAccountID(propertyID);
        }
        public static DataSet GetMaxCashLimitForRefund(Guid? CompanyID, Guid? propertyID)
        {
            ReservationConfigDAL _dataObject = new ReservationConfigDAL();
            return _dataObject.SelectMaxCashLimitForRefund(CompanyID ,propertyID);
        }
        #endregion

    }
}
