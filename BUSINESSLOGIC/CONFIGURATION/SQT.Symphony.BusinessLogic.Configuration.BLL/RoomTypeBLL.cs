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
    public static class RoomTypeBLL
    {

        //#region data Members

        //private static RoomTypeDAL _dataObject = null;

        //#endregion

        #region Constructor

        static RoomTypeBLL()
        {
            //_dataObject = new RoomTypeDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new RoomType
        /// </summary>
        /// <param name="businessObject">RoomType object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(RoomType businessObject)
        {
            RoomTypeDAL _dataObject = new RoomTypeDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.RoomTypeID = Guid.NewGuid();
                    
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


        public static bool Save(RoomType objSaveRoomType, List<RoomTypeAmenities> lstRoomTypeAmenities)
        {
            bool flag = false;
            RoomTypeDAL _objRoomType = null;
            RoomTypeAmenitiesDAL _objRoomTypeAmenities = null;            
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objRoomType = new RoomTypeDAL(lt.Transaction);

                if (objSaveRoomType != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    objSaveRoomType.RoomTypeID = Guid.NewGuid();

                    if (!objSaveRoomType.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSaveRoomType.BrokenRulesList.ToString());
                    }
                    flag = _objRoomType.Insert(objSaveRoomType);
                    // }

                    if (lstRoomTypeAmenities.Count != 0)
                    {
                        _objRoomTypeAmenities = new RoomTypeAmenitiesDAL(lt.Transaction);
                        foreach (RoomTypeAmenities item in lstRoomTypeAmenities)
                        {
                            item.RoomTypeAmenitiesID = Guid.NewGuid();
                            item.RoomTypeID = objSaveRoomType.RoomTypeID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objRoomTypeAmenities.Insert(item);
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
        /// Update existing RoomType
        /// </summary>
        /// <param name="businessObject">RoomType object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(RoomType businessObject)
        {
            RoomTypeDAL _dataObject = new RoomTypeDAL();
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

        public static bool Update(RoomType objUpdateRoomType, List<RoomTypeAmenities> lstRoomTypeAmenities)
        {
            bool flag = false;
            RoomTypeDAL _objRoomType = null;
            RoomTypeAmenitiesDAL _objRoomTypeAmenities = null;            
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objRoomType = new RoomTypeDAL(lt.Transaction);

                if (objUpdateRoomType != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    
                    if (!objUpdateRoomType.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objUpdateRoomType.BrokenRulesList.ToString());
                    }
                    flag = _objRoomType.Update(objUpdateRoomType);
                    // }

                    _objRoomTypeAmenities = new RoomTypeAmenitiesDAL(lt.Transaction);
                    _objRoomTypeAmenities.DeleteByRoomTypeID(objUpdateRoomType.RoomTypeID);
                    if (lstRoomTypeAmenities.Count != 0)
                    {                        
                        foreach (RoomTypeAmenities item in lstRoomTypeAmenities)
                        {
                            item.RoomTypeAmenitiesID = Guid.NewGuid();
                            item.RoomTypeID = objUpdateRoomType.RoomTypeID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objRoomTypeAmenities.Insert(item);
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
        /// get RoomType by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static RoomType GetByPrimaryKey(Guid keys)
        {
            RoomTypeDAL _dataObject = new RoomTypeDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all RoomTypes
        /// </summary>
        /// <returns>list</returns>
        public static List<RoomType> GetAll(RoomType obj)
        {
            RoomTypeDAL _dataObject = new RoomTypeDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all RoomTypes
        /// </summary>
        /// <returns>list</returns>
        public static List<RoomType> GetAll()
        {
            RoomTypeDAL _dataObject = new RoomTypeDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of RoomType by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<RoomType> GetAllBy(RoomType.RoomTypeFields fieldName, object value)
        {
            RoomTypeDAL _dataObject = new RoomTypeDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all RoomTypes
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(RoomType obj)
        {
            RoomTypeDAL _dataObject = new RoomTypeDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }

        public static DataSet GetAllForRateCard(Guid propertyID, Guid rateID)
        {
            RoomTypeDAL _dataObject = new RoomTypeDAL();
            return _dataObject.SelectAllForRateCard(propertyID,rateID);
        }
        /// <summary>
        /// get list of all RoomTypes
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            RoomTypeDAL _dataObject = new RoomTypeDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of RoomType by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(RoomType.RoomTypeFields fieldName, object value)
        {
            RoomTypeDAL _dataObject = new RoomTypeDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            RoomTypeDAL _dataObject = new RoomTypeDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(RoomType obj)
        {
            RoomTypeDAL _dataObject = new RoomTypeDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete RoomType by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(RoomType.RoomTypeFields fieldName, object value)
        {
            RoomTypeDAL _dataObject = new RoomTypeDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet GetUnitType(string UnitTypeQuery)
        {
            RoomTypeDAL _dataObject = new RoomTypeDAL();
            return _dataObject.SelectUnitType(UnitTypeQuery);
        }

        public static bool Save(RoomType objSaveRoomType, List<RoomTypeAmenities> lstRoomTypeAmenities, List<RoomTypeDeposit> lstRoomTypeDeposits, List<RoomTypeServices> lstRoomTypeServices)
        {
            bool flag = false;
            RoomTypeDAL _objRoomType = null;
            RoomTypeAmenitiesDAL _objRoomTypeAmenities = null;
            RoomTypeDepositDAL _objRoomTypeDeposit = null;
            RoomTypeServicesDAL _objRoomTypeServices = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objRoomType = new RoomTypeDAL(lt.Transaction);

                if (objSaveRoomType != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    objSaveRoomType.RoomTypeID = Guid.NewGuid();

                    if (!objSaveRoomType.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSaveRoomType.BrokenRulesList.ToString());
                    }
                    flag = _objRoomType.Insert(objSaveRoomType);
                    // }

                    if (lstRoomTypeAmenities.Count != 0)
                    {
                        _objRoomTypeAmenities = new RoomTypeAmenitiesDAL(lt.Transaction);
                        foreach (RoomTypeAmenities item in lstRoomTypeAmenities)
                        {
                            item.RoomTypeAmenitiesID = Guid.NewGuid();
                            item.RoomTypeID = objSaveRoomType.RoomTypeID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objRoomTypeAmenities.Insert(item);
                        }
                    }

                    if (lstRoomTypeDeposits.Count != 0)
                    {
                        _objRoomTypeDeposit = new RoomTypeDepositDAL(lt.Transaction);
                        foreach (RoomTypeDeposit item in lstRoomTypeDeposits)
                        {
                            item.RoomTypeDepositID = Guid.NewGuid();
                            item.RoomTypeID = objSaveRoomType.RoomTypeID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objRoomTypeDeposit.Insert(item);
                        }
                    }

                    if (lstRoomTypeServices.Count != 0 && lstRoomTypeServices != null)
                    {
                        _objRoomTypeServices = new RoomTypeServicesDAL(lt.Transaction);
                        foreach (RoomTypeServices item in lstRoomTypeServices)
                        {
                            item.RoomTypeServiceID = Guid.NewGuid();
                            item.RoomTypeID = objSaveRoomType.RoomTypeID;

                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objRoomTypeServices.Insert(item);
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

        public static bool Update(RoomType objUpdateRoomType, List<RoomTypeAmenities> lstRoomTypeAmenities, List<RoomTypeDeposit> lstRoomTypeDeposits, List<RoomTypeServices> lstRoomTypeServices)
        {
            bool flag = false;
            RoomTypeDAL _objRoomType = null;
            RoomTypeAmenitiesDAL _objRoomTypeAmenities = null;
            RoomTypeDepositDAL _objRoomTypeDeposit = null;
            RoomTypeServicesDAL _objRoomTypeServices = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objRoomType = new RoomTypeDAL(lt.Transaction);

                if (objUpdateRoomType != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{                    

                    if (!objUpdateRoomType.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objUpdateRoomType.BrokenRulesList.ToString());
                    }
                    flag = _objRoomType.Update(objUpdateRoomType);
                    // }

                    _objRoomTypeAmenities = new RoomTypeAmenitiesDAL(lt.Transaction);
                    _objRoomTypeAmenities.DeleteByRoomTypeID(objUpdateRoomType.RoomTypeID);

                    if (lstRoomTypeAmenities.Count != 0)
                    {   
                        foreach (RoomTypeAmenities item in lstRoomTypeAmenities)
                        {
                            item.RoomTypeAmenitiesID = Guid.NewGuid();
                            item.RoomTypeID = objUpdateRoomType.RoomTypeID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objRoomTypeAmenities.Insert(item);
                        }
                    }

                    _objRoomTypeDeposit = new RoomTypeDepositDAL(lt.Transaction);
                    _objRoomTypeDeposit.DeleteByRoomTypeID(objUpdateRoomType.RoomTypeID);
                    if (lstRoomTypeDeposits.Count != 0)
                    {                        
                        foreach (RoomTypeDeposit item in lstRoomTypeDeposits)
                        {
                            item.RoomTypeDepositID = Guid.NewGuid();
                            item.RoomTypeID = objUpdateRoomType.RoomTypeID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objRoomTypeDeposit.Insert(item);
                        }
                    }

                    _objRoomTypeServices = new RoomTypeServicesDAL(lt.Transaction);
                    _objRoomTypeServices.DeleteByRoomTypeID(objUpdateRoomType.RoomTypeID);

                    if (lstRoomTypeServices.Count != 0 && lstRoomTypeServices != null)
                    {
                        foreach (RoomTypeServices item in lstRoomTypeServices)
                        {
                            item.RoomTypeServiceID = Guid.NewGuid();
                            item.RoomTypeID = objUpdateRoomType.RoomTypeID;

                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objRoomTypeServices.Insert(item);
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

        public static List<RoomType> SearchRoomTypeData(Guid? RoomTypeID, Guid? PropertyID, Guid? PerFlat_TermID, string RoomTypeCode, string RoomTypeName)
        {
            RoomTypeDAL _dataObject = new RoomTypeDAL();
            return _dataObject.SearchRoomTypeData(RoomTypeID, PropertyID,PerFlat_TermID, RoomTypeCode, RoomTypeName);
        }

        public static DataSet GetDistinctRoomTypeOnRoom(Guid? propertyID)
        {
            RoomTypeDAL _dataObject = new RoomTypeDAL();
            return _dataObject.SelectDistinctRoomTypeOnRoom(propertyID);
        }

        public static DataSet SelectRoomTypeServices(Guid? propertyID, Guid? companyID, Guid? RoomTypeID)
        {
            RoomTypeDAL _dataObject = new RoomTypeDAL();
            return _dataObject.SelectRoomTypeServices(propertyID, companyID, RoomTypeID);
        }
        #endregion

    }
}
