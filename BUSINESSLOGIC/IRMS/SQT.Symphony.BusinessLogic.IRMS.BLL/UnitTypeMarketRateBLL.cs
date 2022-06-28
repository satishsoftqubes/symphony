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
    public static class UnitTypeMarketRateBLL
    {

        //#region data Members

        //private static UnitTypeMarketRateDAL _dataObject = null;

        //#endregion

        #region Constructor

        static UnitTypeMarketRateBLL()
        {
            //_dataObject = new UnitTypeMarketRateDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new UnitTypeMarketRate
        /// </summary>
        /// <param name="businessObject">UnitTypeMarketRate object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(UnitTypeMarketRate businessObject)
        {
            UnitTypeMarketRateDAL _dataObject = new UnitTypeMarketRateDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.MarketRateID = Guid.NewGuid();

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

        public static bool Save(List<UnitTypeMarketRate> lstbusinessObject)
        {
            bool flag = false;
            UnitTypeMarketRateDAL _objUnitTypeMarketRate = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");

                if (lstbusinessObject != null && lstbusinessObject.Count != 0)
                {
                    _objUnitTypeMarketRate = new UnitTypeMarketRateDAL(lt.Transaction);
                    foreach (UnitTypeMarketRate item in lstbusinessObject)
                    {
                        item.MarketRateID = Guid.NewGuid();
                        if (!item.IsValid)
                        {
                            throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                        }
                        flag = _objUnitTypeMarketRate.Insert(item);
                    }
                    if (flag)
                    {
                        lt.Commit();
                        return flag;
                    }
                    else
                    {
                        lt.Rollback();
                    }
                }

                else
                {
                    lt.Rollback();
                    throw new InvalidBusinessObjectException("Object Is NULL");
                }
            }
            catch
            {
                lt.Rollback();
                throw;
            }
            return flag;
        }

        /// <summary>
        /// Update existing UnitTypeMarketRate
        /// </summary>
        /// <param name="businessObject">UnitTypeMarketRate object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(UnitTypeMarketRate businessObject)
        {
            UnitTypeMarketRateDAL _dataObject = new UnitTypeMarketRateDAL();
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
        /// get UnitTypeMarketRate by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static UnitTypeMarketRate GetByPrimaryKey(Guid keys)
        {
            UnitTypeMarketRateDAL _dataObject = new UnitTypeMarketRateDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all UnitTypeMarketRates
        /// </summary>
        /// <returns>list</returns>
        public static List<UnitTypeMarketRate> GetAll(UnitTypeMarketRate obj)
        {
            UnitTypeMarketRateDAL _dataObject = new UnitTypeMarketRateDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all UnitTypeMarketRates
        /// </summary>
        /// <returns>list</returns>
        public static List<UnitTypeMarketRate> GetAll()
        {
            UnitTypeMarketRateDAL _dataObject = new UnitTypeMarketRateDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of UnitTypeMarketRate by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<UnitTypeMarketRate> GetAllBy(UnitTypeMarketRate.UnitTypeMarketRateFields fieldName, object value)
        {
            UnitTypeMarketRateDAL _dataObject = new UnitTypeMarketRateDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all UnitTypeMarketRates
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(UnitTypeMarketRate obj)
        {
            UnitTypeMarketRateDAL _dataObject = new UnitTypeMarketRateDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all UnitTypeMarketRates
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            UnitTypeMarketRateDAL _dataObject = new UnitTypeMarketRateDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of UnitTypeMarketRate by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(UnitTypeMarketRate.UnitTypeMarketRateFields fieldName, object value)
        {
            UnitTypeMarketRateDAL _dataObject = new UnitTypeMarketRateDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            UnitTypeMarketRateDAL _dataObject = new UnitTypeMarketRateDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(UnitTypeMarketRate obj)
        {
            UnitTypeMarketRateDAL _dataObject = new UnitTypeMarketRateDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete UnitTypeMarketRate by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(UnitTypeMarketRate.UnitTypeMarketRateFields fieldName, object value)
        {
            UnitTypeMarketRateDAL _dataObject = new UnitTypeMarketRateDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet GetMarketRateData(Guid? PropertyID)
        {
            UnitTypeMarketRateDAL _dataObject = new UnitTypeMarketRateDAL();
            return _dataObject.SelectMarketRateData(PropertyID);
        }
        public static DataSet SearchMarketRateData(Guid? PropertyID, DateTime? DateOfRate, string strType)
        {
            UnitTypeMarketRateDAL _dataObject = new UnitTypeMarketRateDAL();
            return _dataObject.SearchMarketRateData(PropertyID, DateOfRate, strType);
        }

        public static bool DeleteByID(Guid? PropertyID, Guid? CompanyID, DateTime? DateOfRate)
        {
            UnitTypeMarketRateDAL _dataObject = new UnitTypeMarketRateDAL();
            return _dataObject.DeleteByID(PropertyID, CompanyID, DateOfRate);
        }

        public static DataSet DrawChart(Guid? PropertyID, Guid? CompanyID, Guid? UnitTypeID, DateTime? DateOfRate)
        {
            UnitTypeMarketRateDAL _dataObject = new UnitTypeMarketRateDAL();
            return _dataObject.DrawChart(PropertyID, CompanyID, UnitTypeID, DateOfRate);
        }

        public static DataSet SelectData(Guid? PropertyID, Guid? CompanyID, Guid? UnitTypeID, DateTime? DateOfRate)
        {
            UnitTypeMarketRateDAL _dataObject = new UnitTypeMarketRateDAL();
            return _dataObject.UnitTypeMarketRateSelectData(PropertyID, CompanyID, UnitTypeID, DateOfRate);
        }

        public static DataSet SelectUnitTypeMarketGridData(Guid? PropertyID, Guid? CompanyID, DateTime? StartDate, DateTime? EndDate, Guid? InvestorID)
        {
            UnitTypeMarketRateDAL _dataObject = new UnitTypeMarketRateDAL();
            return _dataObject.SelectUnitTypeMarketGridData(PropertyID, CompanyID, StartDate,EndDate, InvestorID);
        }

        public static DataSet SelectUnitTypeMarketDate(Guid? PropertyID, Guid? CompanyID, DateTime? StartDate, DateTime? EndDate)
        {
            UnitTypeMarketRateDAL _dataObject = new UnitTypeMarketRateDAL();
            return _dataObject.SelectUnitTypeMarketDate(PropertyID, CompanyID, StartDate, EndDate);
        }
        #endregion

    }
}
