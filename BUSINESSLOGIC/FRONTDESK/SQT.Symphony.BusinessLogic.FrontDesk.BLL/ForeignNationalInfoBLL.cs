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
    public static class ForeignNationalInfoBLL
    {

        //#region data Members

        //private static ForeignNationalInfoDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ForeignNationalInfoBLL()
        {
            //_dataObject = new ForeignNationalInfoDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ForeignNationalInfo
        /// </summary>
        /// <param name="businessObject">ForeignNationalInfo object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ForeignNationalInfo businessObject)
        {
            ForeignNationalInfoDAL _dataObject = new ForeignNationalInfoDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ForeignNationalityID = Guid.NewGuid();

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
        /// Update existing ForeignNationalInfo
        /// </summary>
        /// <param name="businessObject">ForeignNationalInfo object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ForeignNationalInfo businessObject)
        {
            ForeignNationalInfoDAL _dataObject = new ForeignNationalInfoDAL();
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
        /// get ForeignNationalInfo by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ForeignNationalInfo GetByPrimaryKey(Guid keys)
        {
            ForeignNationalInfoDAL _dataObject = new ForeignNationalInfoDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all ForeignNationalInfos
        /// </summary>
        /// <returns>list</returns>
        public static List<ForeignNationalInfo> GetAll(ForeignNationalInfo obj)
        {
            ForeignNationalInfoDAL _dataObject = new ForeignNationalInfoDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all ForeignNationalInfos
        /// </summary>
        /// <returns>list</returns>
        public static List<ForeignNationalInfo> GetAll()
        {
            ForeignNationalInfoDAL _dataObject = new ForeignNationalInfoDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of ForeignNationalInfo by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ForeignNationalInfo> GetAllBy(ForeignNationalInfo.ForeignNationalInfoFields fieldName, object value)
        {
            ForeignNationalInfoDAL _dataObject = new ForeignNationalInfoDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all ForeignNationalInfos
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ForeignNationalInfo obj)
        {
            ForeignNationalInfoDAL _dataObject = new ForeignNationalInfoDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        public static DataSet RPTCFormReport(Guid? CompanyID, Guid? PropertyID, DateTime? StartDate, DateTime? EndDate)
        {
            ForeignNationalInfoDAL _dataObject = new ForeignNationalInfoDAL();
            return _dataObject.RPTCFormReport(CompanyID, PropertyID, StartDate, EndDate);
        }
        /// <summary>
        /// get list of all ForeignNationalInfos
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ForeignNationalInfoDAL _dataObject = new ForeignNationalInfoDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of ForeignNationalInfo by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ForeignNationalInfo.ForeignNationalInfoFields fieldName, object value)
        {
            ForeignNationalInfoDAL _dataObject = new ForeignNationalInfoDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ForeignNationalInfoDAL _dataObject = new ForeignNationalInfoDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ForeignNationalInfo obj)
        {
            ForeignNationalInfoDAL _dataObject = new ForeignNationalInfoDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete ForeignNationalInfo by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ForeignNationalInfo.ForeignNationalInfoFields fieldName, object value)
        {
            ForeignNationalInfoDAL _dataObject = new ForeignNationalInfoDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        #endregion

    }
}
