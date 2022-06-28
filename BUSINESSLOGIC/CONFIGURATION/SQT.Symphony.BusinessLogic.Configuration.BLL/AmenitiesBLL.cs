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
    public static class AmenitiesBLL
    {

        //#region data Members

        //private static AmenitiesDAL _dataObject = null;

        //#endregion

        #region Constructor

        static AmenitiesBLL()
        {
            //_dataObject = new AmenitiesDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Amenities
        /// </summary>
        /// <param name="businessObject">Amenities object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Amenities businessObject)
        {
            AmenitiesDAL _dataObject = new AmenitiesDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.AmenitiesID = Guid.NewGuid();
                    
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
        /// Update existing Amenities
        /// </summary>
        /// <param name="businessObject">Amenities object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Amenities businessObject)
        {
            AmenitiesDAL _dataObject = new AmenitiesDAL();
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
        /// get Amenities by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Amenities GetByPrimaryKey(Guid keys)
        {
            AmenitiesDAL _dataObject = new AmenitiesDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Amenitiess
        /// </summary>
        /// <returns>list</returns>
        public static List<Amenities> GetAll(Amenities obj)
        {
            AmenitiesDAL _dataObject = new AmenitiesDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Amenitiess
        /// </summary>
        /// <returns>list</returns>
        public static List<Amenities> GetAll()
        {
            AmenitiesDAL _dataObject = new AmenitiesDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Amenities by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Amenities> GetAllBy(Amenities.AmenitiesFields fieldName, object value)
        {
            AmenitiesDAL _dataObject = new AmenitiesDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Amenitiess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Amenities obj)
        {
            AmenitiesDAL _dataObject = new AmenitiesDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Amenitiess
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            AmenitiesDAL _dataObject = new AmenitiesDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Amenities by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Amenities.AmenitiesFields fieldName, object value)
        {
            AmenitiesDAL _dataObject = new AmenitiesDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            AmenitiesDAL _dataObject = new AmenitiesDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Amenities obj)
        {
            AmenitiesDAL _dataObject = new AmenitiesDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Amenities by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Amenities.AmenitiesFields fieldName, object value)
        {
            AmenitiesDAL _dataObject = new AmenitiesDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet SearchAmenitiesData(Guid? AmenitiesID, Guid? PropertyID, string AmenitiesName, Guid? AmenitiesTypeTermID)
        {
            AmenitiesDAL _dataObject = new AmenitiesDAL();
            return _dataObject.SearchAmenitiesData(AmenitiesID, PropertyID, AmenitiesName, AmenitiesTypeTermID);
        }

        public static DataSet GetAmenities(string AmenitiesQuery)
        {
            AmenitiesDAL _dataObject = new AmenitiesDAL();
            return _dataObject.SelectAmenities(AmenitiesQuery);
        }

        #endregion

    }
}
