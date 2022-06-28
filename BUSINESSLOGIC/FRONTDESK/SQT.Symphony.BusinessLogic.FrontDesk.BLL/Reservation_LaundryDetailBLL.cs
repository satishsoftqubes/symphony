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
    public static class Reservation_LaundryDetailBLL
    {

        //#region data Members

        //private static Reservation_LaundryDetailDAL _dataObject = null;

        //#endregion

        #region Constructor

        static Reservation_LaundryDetailBLL()
        {
            //_dataObject = new Reservation_LaundryDetailDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Reservation_LaundryDetail
        /// </summary>
        /// <param name="businessObject">Reservation_LaundryDetail object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Reservation_LaundryDetail businessObject)
        {
            Reservation_LaundryDetailDAL _dataObject = new Reservation_LaundryDetailDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.LaundryDetailID = Guid.NewGuid();
                    
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
        /// Update existing Reservation_LaundryDetail
        /// </summary>
        /// <param name="businessObject">Reservation_LaundryDetail object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Reservation_LaundryDetail businessObject)
        {
            Reservation_LaundryDetailDAL _dataObject = new Reservation_LaundryDetailDAL();
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
        /// get Reservation_LaundryDetail by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Reservation_LaundryDetail GetByPrimaryKey(Guid keys)
        {
            Reservation_LaundryDetailDAL _dataObject = new Reservation_LaundryDetailDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Reservation_LaundryDetails
        /// </summary>
        /// <returns>list</returns>
        public static List<Reservation_LaundryDetail> GetAll(Reservation_LaundryDetail obj)
        {
            Reservation_LaundryDetailDAL _dataObject = new Reservation_LaundryDetailDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Reservation_LaundryDetails
        /// </summary>
        /// <returns>list</returns>
        public static List<Reservation_LaundryDetail> GetAll()
        {
            Reservation_LaundryDetailDAL _dataObject = new Reservation_LaundryDetailDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Reservation_LaundryDetail by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Reservation_LaundryDetail> GetAllBy(Reservation_LaundryDetail.Reservation_LaundryDetailFields fieldName, object value)
        {
            Reservation_LaundryDetailDAL _dataObject = new Reservation_LaundryDetailDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Reservation_LaundryDetails
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Reservation_LaundryDetail obj)
        {
            Reservation_LaundryDetailDAL _dataObject = new Reservation_LaundryDetailDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Reservation_LaundryDetails
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            Reservation_LaundryDetailDAL _dataObject = new Reservation_LaundryDetailDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Reservation_LaundryDetail by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Reservation_LaundryDetail.Reservation_LaundryDetailFields fieldName, object value)
        {
            Reservation_LaundryDetailDAL _dataObject = new Reservation_LaundryDetailDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            Reservation_LaundryDetailDAL _dataObject = new Reservation_LaundryDetailDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Reservation_LaundryDetail obj)
        {
            Reservation_LaundryDetailDAL _dataObject = new Reservation_LaundryDetailDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Reservation_LaundryDetail by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Reservation_LaundryDetail.Reservation_LaundryDetailFields fieldName, object value)
        {
            Reservation_LaundryDetailDAL _dataObject = new Reservation_LaundryDetailDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
