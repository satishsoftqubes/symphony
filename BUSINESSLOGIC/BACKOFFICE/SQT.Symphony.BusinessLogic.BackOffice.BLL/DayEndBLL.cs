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
using SQT.Symphony.BusinessLogic.BackOffice.DTO;
using SQT.Symphony.BusinessLogic.BackOffice.DAL;

namespace SQT.Symphony.BusinessLogic.BackOffice.BLL
{
    public static class DayEndBLL
    {

        //#region data Members

        //private static DayEndDAL _dataObject = null;

        //#endregion

        #region Constructor

        static DayEndBLL()
        {
            //_dataObject = new DayEndDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new DayEnd
        /// </summary>
        /// <param name="businessObject">DayEnd object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(DayEnd businessObject)
        {
            DayEndDAL _dataObject = new DayEndDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.DayEndID = Guid.NewGuid();

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
        /// Update existing DayEnd
        /// </summary>
        /// <param name="businessObject">DayEnd object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(DayEnd businessObject)
        {
            DayEndDAL _dataObject = new DayEndDAL();
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
        /// get DayEnd by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static DayEnd GetByPrimaryKey(Guid keys)
        {
            DayEndDAL _dataObject = new DayEndDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all DayEnds
        /// </summary>
        /// <returns>list</returns>
        public static List<DayEnd> GetAll(DayEnd obj)
        {
            DayEndDAL _dataObject = new DayEndDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all DayEnds
        /// </summary>
        /// <returns>list</returns>
        public static List<DayEnd> GetAll()
        {
            DayEndDAL _dataObject = new DayEndDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of DayEnd by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<DayEnd> GetAllBy(DayEnd.DayEndFields fieldName, object value)
        {
            DayEndDAL _dataObject = new DayEndDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all DayEnds
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(DayEnd obj)
        {
            DayEndDAL _dataObject = new DayEndDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all DayEnds
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            DayEndDAL _dataObject = new DayEndDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of DayEnd by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(DayEnd.DayEndFields fieldName, object value)
        {
            DayEndDAL _dataObject = new DayEndDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            DayEndDAL _dataObject = new DayEndDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(DayEnd obj)
        {
            DayEndDAL _dataObject = new DayEndDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete DayEnd by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(DayEnd.DayEndFields fieldName, object value)
        {
            DayEndDAL _dataObject = new DayEndDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet Get_DayEnd_PreCheckReport(string strCode, Guid propertyID, Guid companyID)
        {
            DayEndDAL _dataObject = new DayEndDAL();
            return _dataObject.Select_DayEnd_PreCheckReport(strCode, propertyID, companyID);
        }

        public static DataSet Get_DayEnd_DetailReport()
        {
            DayEndDAL _dataObject = new DayEndDAL();
            return _dataObject.Select_DayEnd_DetailReport();
        }

        public static DataSet Get_DayEnd_CounterCloseDetailRport(Guid? DayEndID)
        {
            DayEndDAL _dataObject = new DayEndDAL();
            return _dataObject.Select_DayEnd_CounterCloseDetailRport(DayEndID);
        }

        public static DataSet Get_DayEnd_DayendCollectionRport(Guid? DayEndID, DateTime? AuditDate)
        {
            DayEndDAL _dataObject = new DayEndDAL();
            return _dataObject.Select_DayEnd_DayendCollectionRport(DayEndID, AuditDate);
        }

        public static DataSet Get_DayEnd_BackUp()
        {
            DayEndDAL _dataObject = new DayEndDAL();
            return _dataObject.Select_DayEnd_BackUp();
        }

        public static bool DayEnd_Save(Guid? UserID, string Remark, Guid? DayEndID, Guid? CompanyID, Guid? PropertyID)
        {
            DayEndDAL _dataObject = new DayEndDAL();
            return _dataObject.DayEnd_Save(UserID, Remark, DayEndID, CompanyID, PropertyID);
        }

        public static bool Reservation_AutoPostRoomAndServiceCharge(DateTime? ServiceDate, Guid? UserID, Guid? CounterID, Guid? PropertyID, string Transaction_Origin, Guid? CompanyID)
        {
            DayEndDAL _dataObject = new DayEndDAL();
            return _dataObject.Reservation_AutoPostRoomAndServiceCharge(ServiceDate,  UserID,  CounterID,  PropertyID,  Transaction_Origin, CompanyID);
        }

        #endregion

    }
}
