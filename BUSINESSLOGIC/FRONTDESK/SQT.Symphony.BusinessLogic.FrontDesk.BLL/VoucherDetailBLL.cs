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
    public static class VoucherDetailBLL
    {

        //#region data Members

        //private static VoucherDetailDAL _dataObject = null;

        //#endregion

        #region Constructor

        static VoucherDetailBLL()
        {
            //_dataObject = new VoucherDetailDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new VoucherDetail
        /// </summary>
        /// <param name="businessObject">VoucherDetail object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(VoucherDetail businessObject)
        {
            VoucherDetailDAL _dataObject = new VoucherDetailDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.VoucherDetailID = Guid.NewGuid();
                    
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
        /// Update existing VoucherDetail
        /// </summary>
        /// <param name="businessObject">VoucherDetail object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(VoucherDetail businessObject)
        {
            VoucherDetailDAL _dataObject = new VoucherDetailDAL();
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
        /// get VoucherDetail by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static VoucherDetail GetByPrimaryKey(Guid keys)
        {
            VoucherDetailDAL _dataObject = new VoucherDetailDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all VoucherDetails
        /// </summary>
        /// <returns>list</returns>
        public static List<VoucherDetail> GetAll(VoucherDetail obj)
        {
            VoucherDetailDAL _dataObject = new VoucherDetailDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all VoucherDetails
        /// </summary>
        /// <returns>list</returns>
        public static List<VoucherDetail> GetAll()
        {
            VoucherDetailDAL _dataObject = new VoucherDetailDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of VoucherDetail by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<VoucherDetail> GetAllBy(VoucherDetail.VoucherDetailFields fieldName, object value)
        {
            VoucherDetailDAL _dataObject = new VoucherDetailDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all VoucherDetails
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(VoucherDetail obj)
        {
            VoucherDetailDAL _dataObject = new VoucherDetailDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all VoucherDetails
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            VoucherDetailDAL _dataObject = new VoucherDetailDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of VoucherDetail by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(VoucherDetail.VoucherDetailFields fieldName, object value)
        {
            VoucherDetailDAL _dataObject = new VoucherDetailDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            VoucherDetailDAL _dataObject = new VoucherDetailDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(VoucherDetail obj)
        {
            VoucherDetailDAL _dataObject = new VoucherDetailDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete VoucherDetail by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(VoucherDetail.VoucherDetailFields fieldName, object value)
        {
            VoucherDetailDAL _dataObject = new VoucherDetailDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
