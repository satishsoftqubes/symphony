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
    public static class GuestBLL
    {

        //#region data Members

        //private static GuestDAL _dataObject = null;

        //#endregion

        #region Constructor

        static GuestBLL()
        {
            //_dataObject = new GuestDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Guest
        /// </summary>
        /// <param name="businessObject">Guest object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Guest businessObject)
        {
            GuestDAL _dataObject = new GuestDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.GuestID = Guid.NewGuid();

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
        /// Update existing Guest
        /// </summary>
        /// <param name="businessObject">Guest object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Guest businessObject)
        {
            GuestDAL _dataObject = new GuestDAL();
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

        public static bool UpdateGuestEmail(Guid guestID, string email)
        {
            GuestDAL _dataObject = new GuestDAL();
            try
            {
                using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                {
                    return _dataObject.UpdateGuestEmail(guestID, email);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// get Guest by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Guest GetByPrimaryKey(Guid keys)
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all Guests
        /// </summary>
        /// <returns>list</returns>
        public static List<Guest> GetAll(Guest obj)
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all Guests
        /// </summary>
        /// <returns>list</returns>
        public static List<Guest> GetAll()
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of Guest by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Guest> GetAllBy(Guest.GuestFields fieldName, object value)
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all Guests
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Guest obj)
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all Guests
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of Guest by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Guest.GuestFields fieldName, object value)
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guest obj)
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete Guest by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Guest.GuestFields fieldName, object value)
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet GetExistingGuest(string guestName, string mobileNo, Guid propertyID, Guid companyID)
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.GetExistingGuest(guestName, mobileNo, propertyID, companyID);
        }
        public static DataSet GetGuestInfoByGuestID(Guid guestID)
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.GetGuestInfoByGuestID(guestID);
        }

        public static DataSet GetCurrentGuestListData(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID, string GuestFullName, string MobileNo, string ReservationNo, string RoomNo, Guid? BillingInstructionID)
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.SelectCurrentGuestListData(ReservationID, PropertyID, CompanyID, GuestFullName, MobileNo, ReservationNo, RoomNo, BillingInstructionID);
        }

        public static DataSet GetPastGuestListData(DateTime? FromDate, DateTime? ToDate, Guid? PropertyID, Guid? CompanyID, string GuestFullName, string MobileNo, string ReservationNo, string RoomNo, Guid? BillingInstructionID)
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.SelectPastGuestListData(FromDate,ToDate, PropertyID, CompanyID, GuestFullName, MobileNo, ReservationNo, RoomNo, BillingInstructionID);
        }

        public static DataSet GetGuestAndReserForGuestMsglist(Guid? PropertyID, Guid? CompanyID, string GuestFullName, string RoomNo)
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.SelectGuestAndReserForGuestMsglist(PropertyID, CompanyID, GuestFullName, RoomNo);
        }
        public static DataSet GetGuestAndReserForTroubleTicket(Guid? PropertyID, Guid? CompanyID, string GuestFullName, string RoomNo)
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.SelectGuestAndReserForTroubleTicket(PropertyID, CompanyID, GuestFullName, RoomNo);
        }

        public static DataSet GetAllForGuestHistory(string guestFullName, string nationality, string companyName, string email, string phone, Guid propertyID, Guid companyID)
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.SelectAllForGuestHistory(guestFullName, nationality, companyName, email, phone, propertyID, companyID);
        }

        public static DataSet POS_SelectCheckInGuestList(Guid propertyID)
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.POS_SelectCheckInGuestList(propertyID);
        }
        public static DataSet GettGuestBirthDayReport(Guid? PropertyID, Guid? CompanyID, int? dtFromDate, int? dtToDate)
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.SelectGuestBirthDayReport(PropertyID, CompanyID, dtFromDate, dtToDate);
        }
        public static DataSet GetOccupancyReportData(Guid? CompanyID, Guid? PropertyID, DateTime? dtStartDate, DateTime? dtEndDate)
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.selectOccupancyReportData(CompanyID, PropertyID, dtStartDate, dtEndDate);
        }
        public static DataSet GetGuestEmailAddressForSendEmail(Guid? CompanyID, Guid? PropertyID, string InquiryStatusForEmailDB, string InquiryStatusForwaitlist, string InquiryStatusForInquiry, bool IsToTakeCheckInGuestOnly, bool IsToTakeCheckOutGuestOnly, bool IsToTakeAllGuest)
        {
            GuestDAL _dataObject = new GuestDAL();
            return _dataObject.selectGuestEmailAddressForSendEmail(CompanyID, PropertyID,InquiryStatusForEmailDB ,InquiryStatusForwaitlist ,InquiryStatusForInquiry,IsToTakeCheckInGuestOnly ,IsToTakeCheckOutGuestOnly ,IsToTakeAllGuest);
        }
        #endregion

    }
}
