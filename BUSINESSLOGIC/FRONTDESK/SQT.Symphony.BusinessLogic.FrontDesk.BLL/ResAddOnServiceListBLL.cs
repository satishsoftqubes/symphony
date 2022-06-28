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
    public static class ResAddOnServiceListBLL
    {

        //#region data Member

        //private static ResAddOnServiceListDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ResAddOnServiceListBLL()
        {
            //_dataObject = new ResAddOnServiceListDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ResAddOnServiceList
        /// </summary>
        /// <param name="businessObject">ResAddOnServiceList object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ResAddOnServiceList businessObject)
        {
            ResAddOnServiceListDAL _dataObject = new ResAddOnServiceListDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ResAddOnServiceID = Guid.NewGuid();
                    
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
        /// Update existing ResAddOnServiceList
        /// </summary>
        /// <param name="businessObject">ResAddOnServiceList object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ResAddOnServiceList businessObject)
        {
            ResAddOnServiceListDAL _dataObject = new ResAddOnServiceListDAL();
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
        /// get ResAddOnServiceList by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ResAddOnServiceList GetByPrimaryKey(Guid keys)
        {
            ResAddOnServiceListDAL _dataObject = new ResAddOnServiceListDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ResAddOnServiceLists
        /// </summary>
        /// <returns>list</returns>
        public static List<ResAddOnServiceList> GetAll(ResAddOnServiceList obj)
        {
            ResAddOnServiceListDAL _dataObject = new ResAddOnServiceListDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ResAddOnServiceLists
        /// </summary>
        /// <returns>list</returns>
        public static List<ResAddOnServiceList> GetAll()
        {
            ResAddOnServiceListDAL _dataObject = new ResAddOnServiceListDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ResAddOnServiceList by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ResAddOnServiceList> GetAllBy(ResAddOnServiceList.ResAddOnServiceListFields fieldName, object value)
        {
            ResAddOnServiceListDAL _dataObject = new ResAddOnServiceListDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ResAddOnServiceLists
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ResAddOnServiceList obj)
        {
            ResAddOnServiceListDAL _dataObject = new ResAddOnServiceListDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ResAddOnServiceLists
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ResAddOnServiceListDAL _dataObject = new ResAddOnServiceListDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ResAddOnServiceList by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ResAddOnServiceList.ResAddOnServiceListFields fieldName, object value)
        {
            ResAddOnServiceListDAL _dataObject = new ResAddOnServiceListDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ResAddOnServiceListDAL _dataObject = new ResAddOnServiceListDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ResAddOnServiceList obj)
        {
            ResAddOnServiceListDAL _dataObject = new ResAddOnServiceListDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ResAddOnServiceList by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ResAddOnServiceList.ResAddOnServiceListFields fieldName, object value)
        {
            ResAddOnServiceListDAL _dataObject = new ResAddOnServiceListDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet GetCurrentGuestListDataAddOnServices(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID, string GuestFullName, string MobileNo, string ReservationNo, string RoomNo, Guid? BillingInstructionID, string CashCardNo)
        {
            ResAddOnServiceListDAL _dataObject = new ResAddOnServiceListDAL();
            return _dataObject.SelectCurrentGuestListDataAddOnServices(ReservationID, PropertyID, CompanyID, GuestFullName, MobileNo, ReservationNo, RoomNo, BillingInstructionID,CashCardNo);
        }

        public static DataSet GetResAddOnServiceListItemTypeTermIDServiceName(Guid CompanyID, Guid PropertyID)
        {
            ResAddOnServiceListDAL _dataObject = new ResAddOnServiceListDAL();
            return _dataObject.GetResAddOnServiceListItemTypeTermIDServiceName(CompanyID, PropertyID);
        }

        public static DataSet GetResAddOnServiceListWithServiceName(Guid ReservationID, Guid GuestID, Guid? ItemID, Guid CompanyID, Guid PropertyID)
        {
            ResAddOnServiceListDAL _dataObject = new ResAddOnServiceListDAL();
            return _dataObject.GetResAddOnServiceListWithServiceName(ReservationID, GuestID, ItemID, CompanyID, PropertyID);
        }

        public static DataSet GetResAddOnServiceListSelectAllSearchServices(DateTime? StartDate, DateTime? ExpiryDate, Guid? ItemID, Guid? PropertyID, Guid? CompanyID)
        {
            ResAddOnServiceListDAL _dataObject = new ResAddOnServiceListDAL();
            return _dataObject.RoomBlockSelectAllRoomBlockData(StartDate, ExpiryDate, ItemID, PropertyID, CompanyID);
        }

        #endregion

    }
}
