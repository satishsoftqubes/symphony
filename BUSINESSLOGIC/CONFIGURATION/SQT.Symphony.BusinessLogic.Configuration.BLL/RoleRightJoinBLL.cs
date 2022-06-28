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
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.DAL;

namespace SQT.Symphony.BusinessLogic.Configuration.BLL
{
    public static class RoleRightJoinBLL
    {

        //#region data Members

        //private static RoleRightJoinDAL _dataObject = null;

        //#endregion

        #region Constructor

        static RoleRightJoinBLL()
        {
            //_dataObject = new RoleRightJoinDAL();
        }

        #endregion

        #region Public Methods
        //Get IUDV Access
        public static DataView GetIUDVAccess(string FormName, Guid UserID)
        {
            RoleRightJoinDAL _Obj = new RoleRightJoinDAL();
            return _Obj.GetIUDVAccess(FormName, UserID);
        }
        /// <summary>
        /// Get Access Denide
        /// </summary>
        /// <param name="FormName"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static string GetAccessString(string FormName, Guid UserID)
        {
            RoleRightJoinDAL _Obj = new RoleRightJoinDAL();
            return _Obj.GetAccessString(FormName, UserID);
        }
        /// <summary>
        /// Search By Role
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public static DataSet SearchByRole(Guid RoleID)
        {
            RoleDAL _Obj = new RoleDAL();
            return _Obj.SearchByRole(RoleID);
        }
        /// <summary>
        /// Insert new RoleRightJoin
        /// </summary>
        /// <param name="businessObject">RoleRightJoin object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(RoleRightJoin businessObject)
        {
            RoleRightJoinDAL _dataObject = new RoleRightJoinDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.RoleRightJoinID = Guid.NewGuid();
                    
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
        /// Update existing RoleRightJoin
        /// </summary>
        /// <param name="businessObject">RoleRightJoin object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(RoleRightJoin businessObject)
        {
            RoleRightJoinDAL _dataObject = new RoleRightJoinDAL();
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
        /// get RoleRightJoin by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static RoleRightJoin GetByPrimaryKey(Guid keys)
        {
            RoleRightJoinDAL _dataObject = new RoleRightJoinDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all RoleRightJoins
        /// </summary>
        /// <returns>list</returns>
        public static List<RoleRightJoin> GetAll(RoleRightJoin obj)
        {
            RoleRightJoinDAL _dataObject = new RoleRightJoinDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all RoleRightJoins
        /// </summary>
        /// <returns>list</returns>
        public static List<RoleRightJoin> GetAll()
        {
            RoleRightJoinDAL _dataObject = new RoleRightJoinDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of RoleRightJoin by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<RoleRightJoin> GetAllBy(RoleRightJoin.RoleRightJoinFields fieldName, object value)
        {
            RoleRightJoinDAL _dataObject = new RoleRightJoinDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all RoleRightJoins
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(RoleRightJoin obj)
        {
            RoleRightJoinDAL _dataObject = new RoleRightJoinDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all RoleRightJoins
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            RoleRightJoinDAL _dataObject = new RoleRightJoinDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of RoleRightJoin by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(RoleRightJoin.RoleRightJoinFields fieldName, object value)
        {
            RoleRightJoinDAL _dataObject = new RoleRightJoinDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            RoleRightJoinDAL _dataObject = new RoleRightJoinDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(RoleRightJoin obj)
        {
            RoleRightJoinDAL _dataObject = new RoleRightJoinDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete RoleRightJoin by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(RoleRightJoin.RoleRightJoinFields fieldName, object value)
        {
            RoleRightJoinDAL _dataObject = new RoleRightJoinDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
