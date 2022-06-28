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
    public static class TroubleTicketBLL
    {

        //#region data Members

        //private static TroubleTicketDAL _dataObject = null;

        //#endregion

        #region Constructor

        static TroubleTicketBLL()
        {
            //_dataObject = new TroubleTicketDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new TroubleTicket
        /// </summary>
        /// <param name="businessObject">TroubleTicket object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(TroubleTicket businessObject)
        {
            TroubleTicketDAL _dataObject = new TroubleTicketDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.TicketID = Guid.NewGuid();
                    
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
        /// Update existing TroubleTicket
        /// </summary>
        /// <param name="businessObject">TroubleTicket object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(TroubleTicket businessObject)
        {
            TroubleTicketDAL _dataObject = new TroubleTicketDAL();
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
        /// get TroubleTicket by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static TroubleTicket GetByPrimaryKey(Guid keys)
        {
            TroubleTicketDAL _dataObject = new TroubleTicketDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all TroubleTickets
        /// </summary>
        /// <returns>list</returns>
        public static List<TroubleTicket> GetAll(TroubleTicket obj)
        {
            TroubleTicketDAL _dataObject = new TroubleTicketDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all TroubleTickets
        /// </summary>
        /// <returns>list</returns>
        public static List<TroubleTicket> GetAll()
        {
            TroubleTicketDAL _dataObject = new TroubleTicketDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of TroubleTicket by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<TroubleTicket> GetAllBy(TroubleTicket.TroubleTicketFields fieldName, object value)
        {
            TroubleTicketDAL _dataObject = new TroubleTicketDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all TroubleTickets
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(TroubleTicket obj)
        {
            TroubleTicketDAL _dataObject = new TroubleTicketDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all TroubleTickets
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            TroubleTicketDAL _dataObject = new TroubleTicketDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of TroubleTicket by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(TroubleTicket.TroubleTicketFields fieldName, object value)
        {
            TroubleTicketDAL _dataObject = new TroubleTicketDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            TroubleTicketDAL _dataObject = new TroubleTicketDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(TroubleTicket obj)
        {
            TroubleTicketDAL _dataObject = new TroubleTicketDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete TroubleTicket by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(TroubleTicket.TroubleTicketFields fieldName, object value)
        {
            TroubleTicketDAL _dataObject = new TroubleTicketDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }
        public static DataSet GetTroubleTicketList(Guid companyID, Guid propertyID, Guid? Priority, string Title, bool? IsClosed, string GuestName, Guid? Department, string ReservationNo)
        {
            TroubleTicketDAL _dataObject = new TroubleTicketDAL();
            return _dataObject.SelectTroubleTicketList(companyID,propertyID,Priority,Title,IsClosed,GuestName,Department,ReservationNo);
        }

        #endregion

    }
}
