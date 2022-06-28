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
    public static class PaymentSlabeBLL
    {

        //#region data Members

        //private static PaymentSlabeDAL _dataObject = null;

        //#endregion

        #region Constructor

        static PaymentSlabeBLL()
        {
            //_dataObject = new PaymentSlabeDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new PaymentSlabe
        /// </summary>
        /// <param name="businessObject">PaymentSlabe object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(PaymentSlabe businessObject)
        {
            PaymentSlabeDAL _dataObject = new PaymentSlabeDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.PaymentSlabeID = Guid.NewGuid();

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
        /// Update existing PaymentSlabe
        /// </summary>
        /// <param name="businessObject">PaymentSlabe object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(PaymentSlabe businessObject)
        {
            PaymentSlabeDAL _dataObject = new PaymentSlabeDAL();
            try
            {
                if (businessObject != null)
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
        /// get PaymentSlabe by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static PaymentSlabe GetByPrimaryKey(Guid keys)
        {
            PaymentSlabeDAL _dataObject = new PaymentSlabeDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all PaymentSlabes
        /// </summary>
        /// <returns>list</returns>
        public static List<PaymentSlabe> GetAll(PaymentSlabe obj)
        {
            PaymentSlabeDAL _dataObject = new PaymentSlabeDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all PaymentSlabes
        /// </summary>
        /// <returns>list</returns>
        public static List<PaymentSlabe> GetAll()
        {
            PaymentSlabeDAL _dataObject = new PaymentSlabeDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of PaymentSlabe by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<PaymentSlabe> GetAllBy(PaymentSlabe.PaymentSlabeFields fieldName, object value)
        {
            PaymentSlabeDAL _dataObject = new PaymentSlabeDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all PaymentSlabes
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(PaymentSlabe obj)
        {
            PaymentSlabeDAL _dataObject = new PaymentSlabeDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all PaymentSlabes
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            PaymentSlabeDAL _dataObject = new PaymentSlabeDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of PaymentSlabe by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(PaymentSlabe.PaymentSlabeFields fieldName, object value)
        {
            PaymentSlabeDAL _dataObject = new PaymentSlabeDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            PaymentSlabeDAL _dataObject = new PaymentSlabeDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(PaymentSlabe obj)
        {
            PaymentSlabeDAL _dataObject = new PaymentSlabeDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete PaymentSlabe by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(PaymentSlabe.PaymentSlabeFields fieldName, object value)
        {
            PaymentSlabeDAL _dataObject = new PaymentSlabeDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet SearchData(Guid? PaymentSlabeID, Guid? PropertyID, string SlabTitle, Guid? WingID)
        {
            PaymentSlabeDAL _dataObject = new PaymentSlabeDAL();
            DataSet ds = _dataObject.SearchData(PaymentSlabeID, PropertyID, SlabTitle, WingID);
            return ds;
        }

        public static DataSet GetBlocksTotalMilestoneByRoomID(Guid roomID)
        {
            PaymentSlabeDAL _dataObject = new PaymentSlabeDAL();
            DataSet ds = _dataObject.GetBlocksTotalMilestoneByRoomID(roomID);
            return ds;
        }

        public static DataSet GetPaymentSlab(string PaymentSlabQuery)
        {
            PaymentSlabeDAL _dataObject = new PaymentSlabeDAL();
            return _dataObject.SelectPaymentSlab(PaymentSlabQuery);
        }
        #endregion

    }
}
