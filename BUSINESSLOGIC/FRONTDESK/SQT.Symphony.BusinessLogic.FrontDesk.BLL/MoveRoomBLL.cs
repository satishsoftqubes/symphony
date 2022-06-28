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
    public static class MoveRoomBLL
    {

        //#region data Members

        //private static MoveRoomDAL _dataObject = null;

        //#endregion

        #region Constructor

        static MoveRoomBLL()
        {
            //_dataObject = new MoveRoomDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new MoveRoom
        /// </summary>
        /// <param name="businessObject">MoveRoom object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(MoveRoom businessObject)
        {
            MoveRoomDAL _dataObject = new MoveRoomDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.MoveRoomID = Guid.NewGuid();
                    
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
        /// Update existing MoveRoom
        /// </summary>
        /// <param name="businessObject">MoveRoom object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(MoveRoom businessObject)
        {
            MoveRoomDAL _dataObject = new MoveRoomDAL();
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
        /// get MoveRoom by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static MoveRoom GetByPrimaryKey(Guid keys)
        {
            MoveRoomDAL _dataObject = new MoveRoomDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all MoveRooms
        /// </summary>
        /// <returns>list</returns>
        public static List<MoveRoom> GetAll(MoveRoom obj)
        {
            MoveRoomDAL _dataObject = new MoveRoomDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all MoveRooms
        /// </summary>
        /// <returns>list</returns>
        public static List<MoveRoom> GetAll()
        {
            MoveRoomDAL _dataObject = new MoveRoomDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of MoveRoom by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<MoveRoom> GetAllBy(MoveRoom.MoveRoomFields fieldName, object value)
        {
            MoveRoomDAL _dataObject = new MoveRoomDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all MoveRooms
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(MoveRoom obj)
        {
            MoveRoomDAL _dataObject = new MoveRoomDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all MoveRooms
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            MoveRoomDAL _dataObject = new MoveRoomDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of MoveRoom by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(MoveRoom.MoveRoomFields fieldName, object value)
        {
            MoveRoomDAL _dataObject = new MoveRoomDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            MoveRoomDAL _dataObject = new MoveRoomDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(MoveRoom obj)
        {
            MoveRoomDAL _dataObject = new MoveRoomDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete MoveRoom by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(MoveRoom.MoveRoomFields fieldName, object value)
        {
            MoveRoomDAL _dataObject = new MoveRoomDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet GetMoveRoomHistory(Guid? MoveRoomID, Guid? ReservationID, DateTime? StartDate, DateTime? EndDate)
        {
            MoveRoomDAL _dataObject = new MoveRoomDAL();
            return _dataObject.SelectMoveRoomHistory(MoveRoomID, ReservationID, StartDate, EndDate);
        }
        #endregion

    }
}
