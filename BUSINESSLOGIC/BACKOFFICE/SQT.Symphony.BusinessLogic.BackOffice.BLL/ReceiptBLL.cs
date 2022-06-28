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
    public static class ReceiptBLL
    {

        //#region data Members

        //private static ReceiptDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ReceiptBLL()
        {
            //_dataObject = new ReceiptDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Receipt
        /// </summary>
        /// <param name="businessObject">Receipt object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Receipt businessObject)
        {
            ReceiptDAL _dataObject = new ReceiptDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ReceiptID = Guid.NewGuid();
                    
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
        /// Update existing Receipt
        /// </summary>
        /// <param name="businessObject">Receipt object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Receipt businessObject)
        {
            ReceiptDAL _dataObject = new ReceiptDAL();
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
        /// get Receipt by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Receipt GetByPrimaryKey(Guid keys)
        {
            ReceiptDAL _dataObject = new ReceiptDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Receipts
        /// </summary>
        /// <returns>list</returns>
        public static List<Receipt> GetAll(Receipt obj)
        {
            ReceiptDAL _dataObject = new ReceiptDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Receipts
        /// </summary>
        /// <returns>list</returns>
        public static List<Receipt> GetAll()
        {
            ReceiptDAL _dataObject = new ReceiptDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Receipt by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Receipt> GetAllBy(Receipt.ReceiptFields fieldName, object value)
        {
            ReceiptDAL _dataObject = new ReceiptDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Receipts
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Receipt obj)
        {
            ReceiptDAL _dataObject = new ReceiptDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Receipts
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ReceiptDAL _dataObject = new ReceiptDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Receipt by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Receipt.ReceiptFields fieldName, object value)
        {
            ReceiptDAL _dataObject = new ReceiptDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ReceiptDAL _dataObject = new ReceiptDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Receipt obj)
        {
            ReceiptDAL _dataObject = new ReceiptDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Receipt by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Receipt.ReceiptFields fieldName, object value)
        {
            ReceiptDAL _dataObject = new ReceiptDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
