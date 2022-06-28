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
    public static class ReservationVoucherBLL
    {

        //#region data Members

        //private static ReservationVoucherDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ReservationVoucherBLL()
        {
            //_dataObject = new ReservationVoucherDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new ReservationVoucher
        /// </summary>
        /// <param name="businessObject">ReservationVoucher object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(ReservationVoucher businessObject)
        {
            ReservationVoucherDAL _dataObject = new ReservationVoucherDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ResVoucherID = Guid.NewGuid();
                    
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
        /// Update existing ReservationVoucher
        /// </summary>
        /// <param name="businessObject">ReservationVoucher object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(ReservationVoucher businessObject)
        {
            ReservationVoucherDAL _dataObject = new ReservationVoucherDAL();
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
        /// get ReservationVoucher by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static ReservationVoucher GetByPrimaryKey(Guid keys)
        {
            ReservationVoucherDAL _dataObject = new ReservationVoucherDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all ReservationVouchers
        /// </summary>
        /// <returns>list</returns>
        public static List<ReservationVoucher> GetAll(ReservationVoucher obj)
        {
            ReservationVoucherDAL _dataObject = new ReservationVoucherDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all ReservationVouchers
        /// </summary>
        /// <returns>list</returns>
        public static List<ReservationVoucher> GetAll()
        {
            ReservationVoucherDAL _dataObject = new ReservationVoucherDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of ReservationVoucher by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<ReservationVoucher> GetAllBy(ReservationVoucher.ReservationVoucherFields fieldName, object value)
        {
            ReservationVoucherDAL _dataObject = new ReservationVoucherDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all ReservationVouchers
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(ReservationVoucher obj)
        {
            ReservationVoucherDAL _dataObject = new ReservationVoucherDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all ReservationVouchers
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ReservationVoucherDAL _dataObject = new ReservationVoucherDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of ReservationVoucher by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(ReservationVoucher.ReservationVoucherFields fieldName, object value)
        {
            ReservationVoucherDAL _dataObject = new ReservationVoucherDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ReservationVoucherDAL _dataObject = new ReservationVoucherDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(ReservationVoucher obj)
        {
            ReservationVoucherDAL _dataObject = new ReservationVoucherDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete ReservationVoucher by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(ReservationVoucher.ReservationVoucherFields fieldName, object value)
        {
            ReservationVoucherDAL _dataObject = new ReservationVoucherDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet GetAll_ForFrontDesk_ByInvestorID(Guid InvestorID)
        {
            ReservationVoucherDAL _dataObject = new ReservationVoucherDAL();
            return _dataObject.SelectAll_ForFrontDesk_ByInvestorID(InvestorID);
        }

        public static bool Update_ReservationAndAllocatedRoomID(Guid ResVoucherID, Guid ReservationID, Guid? AllocatedRoomID, string UpdateMode)
        {
            ReservationVoucherDAL _dataObject = new ReservationVoucherDAL();
            return _dataObject.Update_ReservationAndAllocatedRoomID(ResVoucherID, ReservationID, AllocatedRoomID, UpdateMode);
        }

        public static DataSet GetByPrimaryKeyInDataSet(Guid ResVoucherID)
        {
            ReservationVoucherDAL _dataObject = new ReservationVoucherDAL();
            return _dataObject.SelectByPrimaryKeyInDataSet(ResVoucherID);
        }

        public static DataSet GetAll_ReservationVoucherList(Guid? ResVoucherID, Guid? CompanyID, Guid? PropertyID, Guid? InvestorID, string statusterm)
        {
            ReservationVoucherDAL _dataObject = new ReservationVoucherDAL();
            return _dataObject.SelectAll_ReservationVoucherList(ResVoucherID,CompanyID, PropertyID, InvestorID, statusterm);
        }

        #endregion

    }
}
