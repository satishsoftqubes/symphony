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
    public static class RateCardDetailsBLL
    {

        //#region data Members

        //private static RateCardDetailsDAL _dataObject = null;

        //#endregion

        #region Constructor

        static RateCardDetailsBLL()
        {
            //_dataObject = new RateCardDetailsDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new RateCardDetails
        /// </summary>
        /// <param name="businessObject">RateCardDetails object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(RateCardDetails businessObject)
        {
            RateCardDetailsDAL _dataObject = new RateCardDetailsDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.RateCardDetailID = Guid.NewGuid();
                    
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
        /// Update existing RateCardDetails
        /// </summary>
        /// <param name="businessObject">RateCardDetails object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(RateCardDetails businessObject)
        {
            RateCardDetailsDAL _dataObject = new RateCardDetailsDAL();
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
        /// get RateCardDetails by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static RateCardDetails GetByPrimaryKey(Guid keys)
        {
            RateCardDetailsDAL _dataObject = new RateCardDetailsDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all RateCardDetailss
        /// </summary>
        /// <returns>list</returns>
        public static List<RateCardDetails> GetAll(RateCardDetails obj)
        {
            RateCardDetailsDAL _dataObject = new RateCardDetailsDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all RateCardDetailss
        /// </summary>
        /// <returns>list</returns>
        public static List<RateCardDetails> GetAll()
        {
            RateCardDetailsDAL _dataObject = new RateCardDetailsDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of RateCardDetails by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<RateCardDetails> GetAllBy(RateCardDetails.RateCardDetailsFields fieldName, object value)
        {
            RateCardDetailsDAL _dataObject = new RateCardDetailsDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all RateCardDetailss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(RateCardDetails obj)
        {
            RateCardDetailsDAL _dataObject = new RateCardDetailsDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all RateCardDetailss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            RateCardDetailsDAL _dataObject = new RateCardDetailsDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of RateCardDetails by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(RateCardDetails.RateCardDetailsFields fieldName, object value)
        {
            RateCardDetailsDAL _dataObject = new RateCardDetailsDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            RateCardDetailsDAL _dataObject = new RateCardDetailsDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(RateCardDetails obj)
        {
            RateCardDetailsDAL _dataObject = new RateCardDetailsDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete RateCardDetails by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(RateCardDetails.RateCardDetailsFields fieldName, object value)
        {
            RateCardDetailsDAL _dataObject = new RateCardDetailsDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet GetRateCardDetailByRateIDnRoomTypeID(Guid rateID, Guid roomTypeID)
        {
            RateCardDetailsDAL _dataObject = new RateCardDetailsDAL();
            return _dataObject.SelectByRateCardDetailByRateIDnRoomTypeID(rateID, roomTypeID);
        }

        public static DataSet SelectRoomTypeByRateID(Guid? RateID, Guid? PropertyID)
        {
            RateCardDetailsDAL _dataObject = new RateCardDetailsDAL();
            return _dataObject.SelectRoomTypeByRateID(RateID, PropertyID);
        }

        public static DataSet SelectRateCardDetailsForPOS(Guid rateID)
        {
            RateCardDetailsDAL _dataObject = new RateCardDetailsDAL();
            return _dataObject.SelectRateCardDetailsForPOS(rateID);
        }

        #endregion

    }
}
