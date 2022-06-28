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
    public static class RoomAmenitiesBLL
    {

        //#region data Members

        //private static RoomAmenitiesDAL _dataObject = null;

        //#endregion

        #region Constructor

        static RoomAmenitiesBLL()
        {
            //_dataObject = new RoomAmenitiesDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new RoomAmenities
        /// </summary>
        /// <param name="businessObject">RoomAmenities object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(RoomAmenities businessObject)
        {
            RoomAmenitiesDAL _dataObject = new RoomAmenitiesDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.RoomAmenitiesID = Guid.NewGuid();
                    
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
        /// Update existing RoomAmenities
        /// </summary>
        /// <param name="businessObject">RoomAmenities object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(RoomAmenities businessObject)
        {
            RoomAmenitiesDAL _dataObject = new RoomAmenitiesDAL();
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
        /// get RoomAmenities by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static RoomAmenities GetByPrimaryKey(Guid keys)
        {
            RoomAmenitiesDAL _dataObject = new RoomAmenitiesDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all RoomAmenitiess
        /// </summary>
        /// <returns>list</returns>
        public static List<RoomAmenities> GetAll(RoomAmenities obj)
        {
            RoomAmenitiesDAL _dataObject = new RoomAmenitiesDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all RoomAmenitiess
        /// </summary>
        /// <returns>list</returns>
        public static List<RoomAmenities> GetAll()
        {
            RoomAmenitiesDAL _dataObject = new RoomAmenitiesDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of RoomAmenities by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<RoomAmenities> GetAllBy(RoomAmenities.RoomAmenitiesFields fieldName, object value)
        {
            RoomAmenitiesDAL _dataObject = new RoomAmenitiesDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all RoomAmenitiess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(RoomAmenities obj)
        {
            RoomAmenitiesDAL _dataObject = new RoomAmenitiesDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all RoomAmenitiess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            RoomAmenitiesDAL _dataObject = new RoomAmenitiesDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of RoomAmenities by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(RoomAmenities.RoomAmenitiesFields fieldName, object value)
        {
            RoomAmenitiesDAL _dataObject = new RoomAmenitiesDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            RoomAmenitiesDAL _dataObject = new RoomAmenitiesDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(RoomAmenities obj)
        {
            RoomAmenitiesDAL _dataObject = new RoomAmenitiesDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete RoomAmenities by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(RoomAmenities.RoomAmenitiesFields fieldName, object value)
        {
            RoomAmenitiesDAL _dataObject = new RoomAmenitiesDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        #endregion

    }
}
