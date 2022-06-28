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
    public static class RoomTypeDepositBLL
    {

        //#region data Members

        //private static RoomTypeDepositDAL _dataObject = null;

        //#endregion

        #region Constructor

        static RoomTypeDepositBLL()
        {
            //_dataObject = new RoomTypeDepositDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new RoomTypeDeposit
        /// </summary>
        /// <param name="businessObject">RoomTypeDeposit object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(RoomTypeDeposit businessObject)
        {
            RoomTypeDepositDAL _dataObject = new RoomTypeDepositDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.RoomTypeDepositID = Guid.NewGuid();
                    
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
        /// Update existing RoomTypeDeposit
        /// </summary>
        /// <param name="businessObject">RoomTypeDeposit object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(RoomTypeDeposit businessObject)
        {
            RoomTypeDepositDAL _dataObject = new RoomTypeDepositDAL();
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
        /// get RoomTypeDeposit by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static RoomTypeDeposit GetByPrimaryKey(Guid keys)
        {
            RoomTypeDepositDAL _dataObject = new RoomTypeDepositDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all RoomTypeDeposits
        /// </summary>
        /// <returns>list</returns>
        public static List<RoomTypeDeposit> GetAll(RoomTypeDeposit obj)
        {
            RoomTypeDepositDAL _dataObject = new RoomTypeDepositDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all RoomTypeDeposits
        /// </summary>
        /// <returns>list</returns>
        public static List<RoomTypeDeposit> GetAll()
        {
            RoomTypeDepositDAL _dataObject = new RoomTypeDepositDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of RoomTypeDeposit by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<RoomTypeDeposit> GetAllBy(RoomTypeDeposit.RoomTypeDepositFields fieldName, object value)
        {
            RoomTypeDepositDAL _dataObject = new RoomTypeDepositDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all RoomTypeDeposits
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(RoomTypeDeposit obj)
        {
            RoomTypeDepositDAL _dataObject = new RoomTypeDepositDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all RoomTypeDeposits
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            RoomTypeDepositDAL _dataObject = new RoomTypeDepositDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of RoomTypeDeposit by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(RoomTypeDeposit.RoomTypeDepositFields fieldName, object value)
        {
            RoomTypeDepositDAL _dataObject = new RoomTypeDepositDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            RoomTypeDepositDAL _dataObject = new RoomTypeDepositDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(RoomTypeDeposit obj)
        {
            RoomTypeDepositDAL _dataObject = new RoomTypeDepositDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete RoomTypeDeposit by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(RoomTypeDeposit.RoomTypeDepositFields fieldName, object value)
        {
            RoomTypeDepositDAL _dataObject = new RoomTypeDepositDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
