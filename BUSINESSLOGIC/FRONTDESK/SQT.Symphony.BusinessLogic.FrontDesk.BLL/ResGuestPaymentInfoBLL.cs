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
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.DAL;

namespace SQT.Symphony.BusinessLogic.FrontDesk.BLL
{
    public static class ResGuestPaymentInfoBLL
    {

        //#region data Members

        //private static ResGuestPaymentInfoDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ResGuestPaymentInfoBLL()
        {
            //_dataObject = new ResGuestPaymentInfoDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ResGuestPaymentInfo
        /// </summary>
        /// <param name="businessObject">ResGuestPaymentInfo object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ResGuestPaymentInfo businessObject)
        {
            ResGuestPaymentInfoDAL _dataObject = new ResGuestPaymentInfoDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ResPayID = Guid.NewGuid();

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
        /// Update existing ResGuestPaymentInfo
        /// </summary>
        /// <param name="businessObject">ResGuestPaymentInfo object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ResGuestPaymentInfo businessObject)
        {
            ResGuestPaymentInfoDAL _dataObject = new ResGuestPaymentInfoDAL();
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
        /// get ResGuestPaymentInfo by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ResGuestPaymentInfo GetByPrimaryKey(Guid keys)
        {
            ResGuestPaymentInfoDAL _dataObject = new ResGuestPaymentInfoDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all ResGuestPaymentInfos
        /// </summary>
        /// <returns>list</returns>
        public static List<ResGuestPaymentInfo> GetAll(ResGuestPaymentInfo obj)
        {
            ResGuestPaymentInfoDAL _dataObject = new ResGuestPaymentInfoDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all ResGuestPaymentInfos
        /// </summary>
        /// <returns>list</returns>
        public static List<ResGuestPaymentInfo> GetAll()
        {
            ResGuestPaymentInfoDAL _dataObject = new ResGuestPaymentInfoDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of ResGuestPaymentInfo by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ResGuestPaymentInfo> GetAllBy(ResGuestPaymentInfo.ResGuestPaymentInfoFields fieldName, object value)
        {
            ResGuestPaymentInfoDAL _dataObject = new ResGuestPaymentInfoDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all ResGuestPaymentInfos
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ResGuestPaymentInfo obj)
        {
            ResGuestPaymentInfoDAL _dataObject = new ResGuestPaymentInfoDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all ResGuestPaymentInfos
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ResGuestPaymentInfoDAL _dataObject = new ResGuestPaymentInfoDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of ResGuestPaymentInfo by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ResGuestPaymentInfo.ResGuestPaymentInfoFields fieldName, object value)
        {
            ResGuestPaymentInfoDAL _dataObject = new ResGuestPaymentInfoDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ResGuestPaymentInfoDAL _dataObject = new ResGuestPaymentInfoDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ResGuestPaymentInfo obj)
        {
            ResGuestPaymentInfoDAL _dataObject = new ResGuestPaymentInfoDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete ResGuestPaymentInfo by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ResGuestPaymentInfo.ResGuestPaymentInfoFields fieldName, object value)
        {
            ResGuestPaymentInfoDAL _dataObject = new ResGuestPaymentInfoDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet GetCreditCardListData(Guid? GuestID, Guid? PropertyID, Guid? CompanyID, string Category)
        {
            ResGuestPaymentInfoDAL _dataObject = new ResGuestPaymentInfoDAL();
            return _dataObject.SelectCreditCardListData(GuestID, PropertyID, CompanyID, Category);
        }

        #endregion

    }
}
