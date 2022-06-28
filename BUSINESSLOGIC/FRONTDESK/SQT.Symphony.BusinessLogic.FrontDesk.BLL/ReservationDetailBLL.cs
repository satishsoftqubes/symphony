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
    public static class ReservationDetailBLL
    {

        //#region data Members

        //private static ReservationDetailDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ReservationDetailBLL()
        {
            //_dataObject = new ReservationDetailDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ReservationDetail
        /// </summary>
        /// <param name="businessObject">ReservationDetail object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ReservationDetail businessObject)
        {
            ReservationDetailDAL _dataObject = new ReservationDetailDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ResDetailID = Guid.NewGuid();
                    
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
        /// Update existing ReservationDetail
        /// </summary>
        /// <param name="businessObject">ReservationDetail object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ReservationDetail businessObject)
        {
            ReservationDetailDAL _dataObject = new ReservationDetailDAL();
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
        /// get ReservationDetail by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ReservationDetail GetByPrimaryKey(Guid keys)
        {
            ReservationDetailDAL _dataObject = new ReservationDetailDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ReservationDetails
        /// </summary>
        /// <returns>list</returns>
        public static List<ReservationDetail> GetAll(ReservationDetail obj)
        {
            ReservationDetailDAL _dataObject = new ReservationDetailDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ReservationDetails
        /// </summary>
        /// <returns>list</returns>
        public static List<ReservationDetail> GetAll()
        {
            ReservationDetailDAL _dataObject = new ReservationDetailDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ReservationDetail by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ReservationDetail> GetAllBy(ReservationDetail.ReservationDetailFields fieldName, object value)
        {
            ReservationDetailDAL _dataObject = new ReservationDetailDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ReservationDetails
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ReservationDetail obj)
        {
            ReservationDetailDAL _dataObject = new ReservationDetailDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ReservationDetails
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ReservationDetailDAL _dataObject = new ReservationDetailDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ReservationDetail by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ReservationDetail.ReservationDetailFields fieldName, object value)
        {
            ReservationDetailDAL _dataObject = new ReservationDetailDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ReservationDetailDAL _dataObject = new ReservationDetailDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ReservationDetail obj)
        {
            ReservationDetailDAL _dataObject = new ReservationDetailDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ReservationDetail by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ReservationDetail.ReservationDetailFields fieldName, object value)
        {
            ReservationDetailDAL _dataObject = new ReservationDetailDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
