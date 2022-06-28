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
    public static class DiscountsBLL
    {

        //#region data Members

        //private static DiscountsDAL _dataObject = null;

        //#endregion

        #region Constructor

        static DiscountsBLL()
        {
            //_dataObject = new DiscountsDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Discounts
        /// </summary>
        /// <param name="businessObject">Discounts object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Discounts businessObject)
        {
            DiscountsDAL _dataObject = new DiscountsDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.DiscountID = Guid.NewGuid();
                    
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
        /// Update existing Discounts
        /// </summary>
        /// <param name="businessObject">Discounts object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Discounts businessObject)
        {
            DiscountsDAL _dataObject = new DiscountsDAL();
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
        /// get Discounts by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Discounts GetByPrimaryKey(Guid keys)
        {
            DiscountsDAL _dataObject = new DiscountsDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Discountss
        /// </summary>
        /// <returns>list</returns>
        public static List<Discounts> GetAll(Discounts obj)
        {
            DiscountsDAL _dataObject = new DiscountsDAL();
            return _dataObject.SelectAll(obj); 
        }

        public static List<Discounts> GetAllForCheckDuplicate(Discounts obj)
        {
            DiscountsDAL _dataObject = new DiscountsDAL();
            return _dataObject.SelectAllForCheckDuplicate(obj);
        }

        /// <summary>
        /// get list of all Discountss
        /// </summary>
        /// <returns>list</returns>
        public static List<Discounts> GetAll()
        {
            DiscountsDAL _dataObject = new DiscountsDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Discounts by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Discounts> GetAllBy(Discounts.DiscountsFields fieldName, object value)
        {
            DiscountsDAL _dataObject = new DiscountsDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Discountss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Discounts obj)
        {
            DiscountsDAL _dataObject = new DiscountsDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Discountss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            DiscountsDAL _dataObject = new DiscountsDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Discounts by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Discounts.DiscountsFields fieldName, object value)
        {
            DiscountsDAL _dataObject = new DiscountsDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            DiscountsDAL _dataObject = new DiscountsDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Discounts obj)
        {
            DiscountsDAL _dataObject = new DiscountsDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Discounts by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Discounts.DiscountsFields fieldName, object value)
        {
            DiscountsDAL _dataObject = new DiscountsDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
