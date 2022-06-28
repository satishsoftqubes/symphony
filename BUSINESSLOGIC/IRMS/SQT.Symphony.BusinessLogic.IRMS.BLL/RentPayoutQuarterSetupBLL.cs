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
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using SQT.Symphony.BusinessLogic.IRMS.DAL;

namespace SQT.Symphony.BusinessLogic.IRMS.BLL
{
    public static class RentPayoutQuarterSetupBLL
    {

        //#region data Members

        //private static RentPayoutQuarterSetupDAL _dataObject = null;

        //#endregion

        #region Constructor

        static RentPayoutQuarterSetupBLL()
        {
            //_dataObject = new RentPayoutQuarterSetupDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new RentPayoutQuarterSetup
        /// </summary>
        /// <param name="businessObject">RentPayoutQuarterSetup object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(RentPayoutQuarterSetup businessObject)
        {
            RentPayoutQuarterSetupDAL _dataObject = new RentPayoutQuarterSetupDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.QuarterID = Guid.NewGuid();
                    
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
        /// Update existing RentPayoutQuarterSetup
        /// </summary>
        /// <param name="businessObject">RentPayoutQuarterSetup object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(RentPayoutQuarterSetup businessObject)
        {
            RentPayoutQuarterSetupDAL _dataObject = new RentPayoutQuarterSetupDAL();
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
        /// get RentPayoutQuarterSetup by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static RentPayoutQuarterSetup GetByPrimaryKey(Guid keys)
        {
            RentPayoutQuarterSetupDAL _dataObject = new RentPayoutQuarterSetupDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all RentPayoutQuarterSetups
        /// </summary>
        /// <returns>list</returns>
        public static List<RentPayoutQuarterSetup> GetAll(RentPayoutQuarterSetup obj)
        {
            RentPayoutQuarterSetupDAL _dataObject = new RentPayoutQuarterSetupDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all RentPayoutQuarterSetups
        /// </summary>
        /// <returns>list</returns>
        public static List<RentPayoutQuarterSetup> GetAll()
        {
            RentPayoutQuarterSetupDAL _dataObject = new RentPayoutQuarterSetupDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of RentPayoutQuarterSetup by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<RentPayoutQuarterSetup> GetAllBy(RentPayoutQuarterSetup.RentPayoutQuarterSetupFields fieldName, object value)
        {
            RentPayoutQuarterSetupDAL _dataObject = new RentPayoutQuarterSetupDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all RentPayoutQuarterSetups
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(RentPayoutQuarterSetup obj)
        {
            RentPayoutQuarterSetupDAL _dataObject = new RentPayoutQuarterSetupDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all RentPayoutQuarterSetups
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            RentPayoutQuarterSetupDAL _dataObject = new RentPayoutQuarterSetupDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of RentPayoutQuarterSetup by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(RentPayoutQuarterSetup.RentPayoutQuarterSetupFields fieldName, object value)
        {
            RentPayoutQuarterSetupDAL _dataObject = new RentPayoutQuarterSetupDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            RentPayoutQuarterSetupDAL _dataObject = new RentPayoutQuarterSetupDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(RentPayoutQuarterSetup obj)
        {
            RentPayoutQuarterSetupDAL _dataObject = new RentPayoutQuarterSetupDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete RentPayoutQuarterSetup by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(RentPayoutQuarterSetup.RentPayoutQuarterSetupFields fieldName, object value)
        {
            RentPayoutQuarterSetupDAL _dataObject = new RentPayoutQuarterSetupDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }
        public static DataSet RentPayoutQuarterSetupCheckDateOverLappingBLL(DateTime startdate, Guid? CompanyID, Guid? PropertyID)
        {
            RentPayoutQuarterSetupDAL _dataObject = new RentPayoutQuarterSetupDAL();
            return _dataObject.RentPayoutQuarterSetupCheckDateOverLapping(startdate,CompanyID,PropertyID); 
        }

        public static DataSet RentPayoutQuarterSetupSelectQuarterbyDate(DateTime date, Guid? CompanyID, Guid? PropertyID)
        {
            RentPayoutQuarterSetupDAL _dataObject = new RentPayoutQuarterSetupDAL();
            return _dataObject.RentPayoutQuarterSetupSelectQuarterbyDate(date, CompanyID, PropertyID);
        }

        public static DataSet RentPayoutQuarterSetupTop4QuarterWithIncome()
        {
            RentPayoutQuarterSetupDAL _dataObject = new RentPayoutQuarterSetupDAL();
            return _dataObject.RentPayoutQuarterSetupTop4QuarterWithIncome();
        }

        #endregion

    }
}
