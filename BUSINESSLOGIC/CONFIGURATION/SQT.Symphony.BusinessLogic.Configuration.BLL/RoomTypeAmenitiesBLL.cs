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
    public static class RoomTypeAmenitiesBLL
    {

        //#region data Members

        //private static RoomTypeAmenitiesDAL _dataObject = null;

        //#endregion

        #region Constructor

        static RoomTypeAmenitiesBLL()
        {
            //_dataObject = new RoomTypeAmenitiesDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new RoomTypeAmenities
        /// </summary>
        /// <param name="businessObject">RoomTypeAmenities object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(RoomTypeAmenities businessObject)
        {
            RoomTypeAmenitiesDAL _dataObject = new RoomTypeAmenitiesDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.RoomTypeAmenitiesID = Guid.NewGuid();
                    
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
        /// Update existing RoomTypeAmenities
        /// </summary>
        /// <param name="businessObject">RoomTypeAmenities object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(RoomTypeAmenities businessObject)
        {
            RoomTypeAmenitiesDAL _dataObject = new RoomTypeAmenitiesDAL();
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
        /// get RoomTypeAmenities by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static RoomTypeAmenities GetByPrimaryKey(Guid keys)
        {
            RoomTypeAmenitiesDAL _dataObject = new RoomTypeAmenitiesDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all RoomTypeAmenitiess
        /// </summary>
        /// <returns>list</returns>
        public static List<RoomTypeAmenities> GetAll(RoomTypeAmenities obj)
        {
            RoomTypeAmenitiesDAL _dataObject = new RoomTypeAmenitiesDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all RoomTypeAmenitiess
        /// </summary>
        /// <returns>list</returns>
        public static List<RoomTypeAmenities> GetAll()
        {
            RoomTypeAmenitiesDAL _dataObject = new RoomTypeAmenitiesDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of RoomTypeAmenities by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<RoomTypeAmenities> GetAllBy(RoomTypeAmenities.RoomTypeAmenitiesFields fieldName, object value)
        {
            RoomTypeAmenitiesDAL _dataObject = new RoomTypeAmenitiesDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all RoomTypeAmenitiess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(RoomTypeAmenities obj)
        {
            RoomTypeAmenitiesDAL _dataObject = new RoomTypeAmenitiesDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all RoomTypeAmenitiess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            RoomTypeAmenitiesDAL _dataObject = new RoomTypeAmenitiesDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of RoomTypeAmenities by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(RoomTypeAmenities.RoomTypeAmenitiesFields fieldName, object value)
        {
            RoomTypeAmenitiesDAL _dataObject = new RoomTypeAmenitiesDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            RoomTypeAmenitiesDAL _dataObject = new RoomTypeAmenitiesDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(RoomTypeAmenities obj)
        {
            RoomTypeAmenitiesDAL _dataObject = new RoomTypeAmenitiesDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete RoomTypeAmenities by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(RoomTypeAmenities.RoomTypeAmenitiesFields fieldName, object value)
        {
            RoomTypeAmenitiesDAL _dataObject = new RoomTypeAmenitiesDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet GetAmenitiesByRoomTypeID(Guid? RoomTypeID, Guid? PropertyID, Guid? CompanyID)
        {
            RoomTypeAmenitiesDAL _dataObject = new RoomTypeAmenitiesDAL();
            return _dataObject.SelectAmenitiesByRoomTypeID(RoomTypeID, PropertyID, CompanyID);
        }
        #endregion

    }
}
