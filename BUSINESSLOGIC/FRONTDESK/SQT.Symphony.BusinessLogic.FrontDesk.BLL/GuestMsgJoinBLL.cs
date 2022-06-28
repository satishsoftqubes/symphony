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
    public static class GuestMsgJoinBLL
    {

        //#region data Members

        //private static GuestMsgJoinDAL _dataObject = null;

        //#endregion

        #region Constructor

        static GuestMsgJoinBLL()
        {
            //_dataObject = new GuestMsgJoinDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new GuestMsgJoin
        /// </summary>
        /// <param name="businessObject">GuestMsgJoin object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(GuestMsgJoin businessObject)
        {
            GuestMsgJoinDAL _dataObject = new GuestMsgJoinDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.GuestMessageID = Guid.NewGuid();

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
        /// Update existing GuestMsgJoin
        /// </summary>
        /// <param name="businessObject">GuestMsgJoin object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(GuestMsgJoin businessObject)
        {
            GuestMsgJoinDAL _dataObject = new GuestMsgJoinDAL();
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
        /// get GuestMsgJoin by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static GuestMsgJoin GetByPrimaryKey(Guid keys)
        {
            GuestMsgJoinDAL _dataObject = new GuestMsgJoinDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all GuestMsgJoins
        /// </summary>
        /// <returns>list</returns>
        public static List<GuestMsgJoin> GetAll(GuestMsgJoin obj)
        {
            GuestMsgJoinDAL _dataObject = new GuestMsgJoinDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all GuestMsgJoins
        /// </summary>
        /// <returns>list</returns>
        public static List<GuestMsgJoin> GetAll()
        {
            GuestMsgJoinDAL _dataObject = new GuestMsgJoinDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of GuestMsgJoin by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<GuestMsgJoin> GetAllBy(GuestMsgJoin.GuestMsgJoinFields fieldName, object value)
        {
            GuestMsgJoinDAL _dataObject = new GuestMsgJoinDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all GuestMsgJoins
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(GuestMsgJoin obj)
        {
            GuestMsgJoinDAL _dataObject = new GuestMsgJoinDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all GuestMsgJoins
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            GuestMsgJoinDAL _dataObject = new GuestMsgJoinDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of GuestMsgJoin by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(GuestMsgJoin.GuestMsgJoinFields fieldName, object value)
        {
            GuestMsgJoinDAL _dataObject = new GuestMsgJoinDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            GuestMsgJoinDAL _dataObject = new GuestMsgJoinDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(GuestMsgJoin obj)
        {
            GuestMsgJoinDAL _dataObject = new GuestMsgJoinDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete GuestMsgJoin by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(GuestMsgJoin.GuestMsgJoinFields fieldName, object value)
        {
            GuestMsgJoinDAL _dataObject = new GuestMsgJoinDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet GetGuestMsgJoinSelectForList(Guid? PropertyID, Guid? CompanyID, Guid? GuestID)
        {
            GuestMsgJoinDAL _dataObject = new GuestMsgJoinDAL();
            return _dataObject.SelectGuestMsgJoinSelectForList(PropertyID, CompanyID, GuestID);
        }

        public static DataSet GetGuestMsgJoinSelectUnreadMsgList(Guid? PropertyID, Guid? CompanyID,string MsgFrom)
        {
            GuestMsgJoinDAL _dataObject = new GuestMsgJoinDAL();
            return _dataObject.SelectUnreadMsgList(PropertyID, CompanyID, MsgFrom);
        }
        #endregion

    }
}
