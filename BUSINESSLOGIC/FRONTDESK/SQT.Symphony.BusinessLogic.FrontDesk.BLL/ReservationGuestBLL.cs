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
    public static class ReservationGuestBLL
    {

        //#region data Members

        //private static ReservationGuestDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ReservationGuestBLL()
        {
            //_dataObject = new ReservationGuestDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ReservationGuest
        /// </summary>
        /// <param name="businessObject">ReservationGuest object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ReservationGuest businessObject)
        {
            ReservationGuestDAL _dataObject = new ReservationGuestDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ReservationGuestID = Guid.NewGuid();

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
        /// Update existing ReservationGuest
        /// </summary>
        /// <param name="businessObject">ReservationGuest object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ReservationGuest businessObject)
        {
            ReservationGuestDAL _dataObject = new ReservationGuestDAL();
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
        /// get ReservationGuest by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ReservationGuest GetByPrimaryKey(Guid keys)
        {
            ReservationGuestDAL _dataObject = new ReservationGuestDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all ReservationGuests
        /// </summary>
        /// <returns>list</returns>
        public static List<ReservationGuest> GetAll(ReservationGuest obj)
        {
            ReservationGuestDAL _dataObject = new ReservationGuestDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all ReservationGuests
        /// </summary>
        /// <returns>list</returns>
        public static List<ReservationGuest> GetAll()
        {
            ReservationGuestDAL _dataObject = new ReservationGuestDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of ReservationGuest by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ReservationGuest> GetAllBy(ReservationGuest.ReservationGuestFields fieldName, object value)
        {
            ReservationGuestDAL _dataObject = new ReservationGuestDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all ReservationGuests
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ReservationGuest obj)
        {
            ReservationGuestDAL _dataObject = new ReservationGuestDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all ReservationGuests
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ReservationGuestDAL _dataObject = new ReservationGuestDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of ReservationGuest by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ReservationGuest.ReservationGuestFields fieldName, object value)
        {
            ReservationGuestDAL _dataObject = new ReservationGuestDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ReservationGuestDAL _dataObject = new ReservationGuestDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ReservationGuest obj)
        {
            ReservationGuestDAL _dataObject = new ReservationGuestDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete ReservationGuest by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ReservationGuest.ReservationGuestFields fieldName, object value)
        {
            ReservationGuestDAL _dataObject = new ReservationGuestDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet GetAllGuestStayHistory(Guid PropertyID, Guid CompanyID, Guid GuestID)
        {
            ReservationGuestDAL _dataObject = new ReservationGuestDAL();
            return _dataObject.SelectAllGuestStayHistory(PropertyID, CompanyID, GuestID);
        }

        public static bool Update_CashcardNumber(Guid ReservationID, Guid GuestID, string Cashcard_Number, Guid PropertyID, Guid CompanyID, Guid UpdatedBy)
        {
            ReservationGuestDAL _dataObject = new ReservationGuestDAL();
            return _dataObject.Update_CashcardNumber(ReservationID, GuestID, Cashcard_Number, PropertyID, CompanyID, UpdatedBy);
        }
        #endregion

    }
}
