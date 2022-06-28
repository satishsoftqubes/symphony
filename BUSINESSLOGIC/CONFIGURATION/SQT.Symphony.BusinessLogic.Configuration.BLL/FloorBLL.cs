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
    public static class FloorBLL
    {

        //#region data Members

        //private static FloorDAL _dataObject = null;

        //#endregion

        #region Constructor

        static FloorBLL()
        {
            //_dataObject = new FloorDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Floor
        /// </summary>
        /// <param name="businessObject">Floor object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Floor businessObject)
        {
            FloorDAL _dataObject = new FloorDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.FloorID = Guid.NewGuid();
                    
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

        public static bool Save(Floor objSaveFloor, List<WingFloorJoin> lstWingFloorJoin)
        {
            bool flag = false;
            FloorDAL _dataObject = null;
            WingFloorJoinDAL _objWingFloorJoin = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new FloorDAL(lt.Transaction);

                if (objSaveFloor != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    objSaveFloor.FloorID = Guid.NewGuid();

                    if (!objSaveFloor.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSaveFloor.BrokenRulesList.ToString());
                    }
                    flag = _dataObject.Insert(objSaveFloor);
                    // }

                    if (lstWingFloorJoin.Count != 0)
                    {
                        _objWingFloorJoin = new WingFloorJoinDAL(lt.Transaction);
                        foreach (WingFloorJoin item in lstWingFloorJoin)
                        {
                            item.WingFloorJoinID = Guid.NewGuid();
                            item.FloorID = objSaveFloor.FloorID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objWingFloorJoin.Insert(item);
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
        /// Update existing Floor
        /// </summary>
        /// <param name="businessObject">Floor object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Floor businessObject)
        {
            FloorDAL _dataObject = new FloorDAL();
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

        public static bool Update(Floor objUpdateFloor, List<WingFloorJoin> lstWingFloorJoin)
        {
            bool flag = false;
            FloorDAL _dataObject = null;
            WingFloorJoinDAL _objWingFloorJoin = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new FloorDAL(lt.Transaction);

                if (objUpdateFloor != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    
                    if (!objUpdateFloor.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objUpdateFloor.BrokenRulesList.ToString());
                    }
                    flag = _dataObject.Update(objUpdateFloor);
                    // }

                    _objWingFloorJoin = new WingFloorJoinDAL(lt.Transaction);
                    _objWingFloorJoin.DeleteByFloorID(objUpdateFloor.FloorID);
                    if (lstWingFloorJoin.Count != 0)
                    {   
                        foreach (WingFloorJoin item in lstWingFloorJoin)
                        {
                            item.WingFloorJoinID = Guid.NewGuid();
                            item.FloorID = objUpdateFloor.FloorID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objWingFloorJoin.Insert(item);
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
        /// get Floor by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Floor GetByPrimaryKey(Guid keys)
        {
            FloorDAL _dataObject = new FloorDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all Floors
        /// </summary>
        /// <returns>list</returns>
        public static List<Floor> GetAll(Floor obj)
        {
            FloorDAL _dataObject = new FloorDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all Floors
        /// </summary>
        /// <returns>list</returns>
        public static List<Floor> GetAll()
        {
            FloorDAL _dataObject = new FloorDAL();
            return _dataObject.SelectAll(); 
        }
        /// <summary>
        /// get list of Floor by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Floor> GetAllBy(Floor.FloorFields fieldName, object value)
        {
            FloorDAL _dataObject = new FloorDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all Floors
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Floor obj)
        {
            FloorDAL _dataObject = new FloorDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all Floors
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            FloorDAL _dataObject = new FloorDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of Floor by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Floor.FloorFields fieldName, object value)
        {
            FloorDAL _dataObject = new FloorDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            FloorDAL _dataObject = new FloorDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Floor obj)
        {
            FloorDAL _dataObject = new FloorDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete Floor by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Floor.FloorFields fieldName, object value)
        {
            FloorDAL _dataObject = new FloorDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static DataSet SearchFloorData(Guid? FloorID, Guid? PropertyID, string FloorName)
        {
            FloorDAL _dataObject = new FloorDAL();
            return _dataObject.SearchFloorData(FloorID, PropertyID, FloorName);
        }

        #endregion

    }
}
