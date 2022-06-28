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
    public static class POSChargePerDayBLL
    {

        //#region data Members

        //private static POSChargePerDayDAL _dataObject = null;

        //#endregion

        #region Constructor

        static POSChargePerDayBLL()
        {
            //_dataObject = new POSChargePerDayDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new POSChargePerDay
        /// </summary>
        /// <param name="businessObject">POSChargePerDay object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(POSChargePerDay businessObject)
        {
            POSChargePerDayDAL _dataObject = new POSChargePerDayDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.POSChargeID = Guid.NewGuid();
                    
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

        public static bool Save(List<POSChargePerDay> lstPOSCharges, Guid RateCardID)
        {
            bool flag = false;
            LinqTransaction lt = LinqSql.CreateTransaction("SQLConStr");

            try
            {
                if (lstPOSCharges != null && lstPOSCharges.Count > 0)
                {
                    POSChargePerDayDAL _dataObject = new POSChargePerDayDAL(lt.Transaction);

                    flag = _dataObject.DeleteByField(POSChargePerDay.POSChargePerDayFields.RateCardID.ToString(), Convert.ToString(RateCardID));

                    for (int i = 0; i < lstPOSCharges.Count; i++)
                    {
                        if (lstPOSCharges[i] != null)
                        {
                            using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                            {
                                lstPOSCharges[i].POSChargeID = Guid.NewGuid();

                                if (!lstPOSCharges[i].IsValid)
                                {
                                    throw new InvalidBusinessObjectException(lstPOSCharges[i].BrokenRulesList.ToString());
                                }

                                flag = _dataObject.Insert(lstPOSCharges[i]);
                            }
                        }
                        else
                        {
                            lt.Rollback();
                            throw new InvalidBusinessObjectException("Object Is NULL");
                        }
                    }
                }

                if (flag)
                {
                    lt.Commit();
                    return flag;
                }
                else
                {
                    lt.Rollback();
                    return flag;
                }
            }
            catch
            {
                lt.Rollback();
                throw;
            }
        }

        /// <summary>
        /// Update existing POSChargePerDay
        /// </summary>
        /// <param name="businessObject">POSChargePerDay object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(POSChargePerDay businessObject)
        {
            POSChargePerDayDAL _dataObject = new POSChargePerDayDAL();
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
        /// get POSChargePerDay by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static POSChargePerDay GetByPrimaryKey(Guid keys)
        {
            POSChargePerDayDAL _dataObject = new POSChargePerDayDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all POSChargePerDays
        /// </summary>
        /// <returns>list</returns>
        public static List<POSChargePerDay> GetAll(POSChargePerDay obj)
        {
            POSChargePerDayDAL _dataObject = new POSChargePerDayDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all POSChargePerDays
        /// </summary>
        /// <returns>list</returns>
        public static List<POSChargePerDay> GetAll()
        {
            POSChargePerDayDAL _dataObject = new POSChargePerDayDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of POSChargePerDay by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<POSChargePerDay> GetAllBy(POSChargePerDay.POSChargePerDayFields fieldName, object value)
        {
            POSChargePerDayDAL _dataObject = new POSChargePerDayDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all POSChargePerDays
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(POSChargePerDay obj)
        {
            POSChargePerDayDAL _dataObject = new POSChargePerDayDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all POSChargePerDays
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            POSChargePerDayDAL _dataObject = new POSChargePerDayDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of POSChargePerDay by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(POSChargePerDay.POSChargePerDayFields fieldName, object value)
        {
            POSChargePerDayDAL _dataObject = new POSChargePerDayDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            POSChargePerDayDAL _dataObject = new POSChargePerDayDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(POSChargePerDay obj)
        {
            POSChargePerDayDAL _dataObject = new POSChargePerDayDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete POSChargePerDay by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(POSChargePerDay.POSChargePerDayFields fieldName, object value)
        {
            POSChargePerDayDAL _dataObject = new POSChargePerDayDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet SelectByRateIDAndRoomTypeID(Guid RateCardID, Guid RoomTypeID)
        {
            POSChargePerDayDAL _dataObject = new POSChargePerDayDAL();
            return _dataObject.SelectByRateIDAndRoomTypeID(RateCardID, RoomTypeID);
        }
        #endregion

    }
}
