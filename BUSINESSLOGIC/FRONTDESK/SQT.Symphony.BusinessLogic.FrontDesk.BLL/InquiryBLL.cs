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
    public static class InquiryBLL
    {

        //#region data Members

        //private static InquiryDAL _dataObject = null;

        //#endregion

        #region Constructor

        static InquiryBLL()
        {
            //_dataObject = new InquiryDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Inquiry
        /// </summary>
        /// <param name="businessObject">Inquiry object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Inquiry businessObject)
        {
            InquiryDAL _dataObject = new InquiryDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.InqID = Guid.NewGuid();

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
        /// Update existing Inquiry
        /// </summary>
        /// <param name="businessObject">Inquiry object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Inquiry businessObject)
        {
            InquiryDAL _dataObject = new InquiryDAL();
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
        /// get Inquiry by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Inquiry GetByPrimaryKey(Guid keys)
        {
            InquiryDAL _dataObject = new InquiryDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all Inquirys
        /// </summary>
        /// <returns>list</returns>
        public static List<Inquiry> GetAll(Inquiry obj)
        {
            InquiryDAL _dataObject = new InquiryDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all Inquirys
        /// </summary>
        /// <returns>list</returns>
        public static List<Inquiry> GetAll()
        {
            InquiryDAL _dataObject = new InquiryDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of Inquiry by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Inquiry> GetAllBy(Inquiry.InquiryFields fieldName, object value)
        {
            InquiryDAL _dataObject = new InquiryDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all Inquirys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Inquiry obj)
        {
            InquiryDAL _dataObject = new InquiryDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all Inquirys
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            InquiryDAL _dataObject = new InquiryDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of Inquiry by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Inquiry.InquiryFields fieldName, object value)
        {
            InquiryDAL _dataObject = new InquiryDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            InquiryDAL _dataObject = new InquiryDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Inquiry obj)
        {
            InquiryDAL _dataObject = new InquiryDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete Inquiry by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Inquiry.InquiryFields fieldName, object value)
        {
            InquiryDAL _dataObject = new InquiryDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }
        public static DataSet GetInquiryList(Guid companyID, Guid propertyID, string GuestName, string MobileNo, string Email, DateTime? ArrivalDate, DateTime? Departuredate,string InquiryStatus,Guid? InqID)
        {
            InquiryDAL  _dataObject = new InquiryDAL();
            return _dataObject.SelectInquiryList(companyID, propertyID, GuestName, MobileNo, Email, ArrivalDate, Departuredate,InquiryStatus,InqID);
        }
        public static DataSet GetEmailConfigSelectForMarketingEmail()
        {
            InquiryDAL _dataObject = new InquiryDAL();
            return _dataObject.SelectEmailConfigSelectForMarketingEmail();
        }
        #endregion

    }
}
