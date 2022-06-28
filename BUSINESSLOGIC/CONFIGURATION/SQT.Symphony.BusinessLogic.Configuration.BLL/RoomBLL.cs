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
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using SQT.Symphony.BusinessLogic.IRMS.DAL;

namespace SQT.Symphony.BusinessLogic.Configuration.BLL
{
    public static class RoomBLL
    {

        //#region data Members

        //private static RoomDAL _dataObject = null;

        //#endregion

        #region Constructor

        static RoomBLL()
        {
            //_dataObject = new RoomDAL();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Select By PropertyID and RoomTypeID
        /// </summary>
        /// <param name="PropertyID"></param>
        /// <param name="RoomTypeID"></param>
        /// <returns></returns>
        public static DataSet SelectByPropertyRoomType(Guid? PropertyID, Guid? RoomTypeID, Guid? WingID, string RoomNo)
        {
            RoomDAL _Obj = new RoomDAL();
            return _Obj.SelectByPropertyRoomType(PropertyID, RoomTypeID, WingID, RoomNo);
        }
        /// <summary>
        /// Report Unit Booking
        /// </summary>
        /// <param name="WingID"></param>
        /// <param name="FloorID"></param>
        /// <param name="RoomTypeID"></param>
        /// <param name="InvestorID"></param>
        /// <param name="RoomID"></param>
        /// <returns></returns>
        public static DataSet GetRptUnitBooking(Guid? WingID, Guid? FloorID, Guid? RoomTypeID, Guid? InvestorID, Guid? RoomID, Guid? RelationShipManagerID)
        {
            RoomDAL _Obj = new RoomDAL();
            return _Obj.rptUnitBooking(WingID, FloorID, RoomTypeID, InvestorID, RoomID, RelationShipManagerID);
        }
        /// <summary>
        /// Insert new Room
        /// </summary>
        /// <param name="businessObject">Room object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Room businessObject)
        {
            RoomDAL _dataObject = new RoomDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.RoomID = Guid.NewGuid();

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

        public static bool Save(Room objSaveRoom, List<RoomAmenities> lstSaveRoomAmenities)
        {
            bool flag = false;
            RoomDAL _objRoom = null;
            RoomAmenitiesDAL _objRoomAmenities = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objRoom = new RoomDAL(lt.Transaction);

                if (objSaveRoom != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    objSaveRoom.RoomID = Guid.NewGuid();

                    if (!objSaveRoom.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSaveRoom.BrokenRulesList.ToString());
                    }
                    flag = _objRoom.Insert(objSaveRoom);
                    // }

                    if (lstSaveRoomAmenities.Count != 0 && lstSaveRoomAmenities != null)
                    {
                        _objRoomAmenities = new RoomAmenitiesDAL(lt.Transaction);
                        foreach (RoomAmenities item in lstSaveRoomAmenities)
                        {
                            item.RoomAmenitiesID = Guid.NewGuid();
                            item.RoomID = objSaveRoom.RoomID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objRoomAmenities.Insert(item);
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

        public static bool RoomSaveWithID(Room objSaveRoom, List<RoomAmenities> lstSaveRoomAmenities)
        {
            bool flag = false;
            RoomDAL _objRoom = null;
            RoomAmenitiesDAL _objRoomAmenities = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objRoom = new RoomDAL(lt.Transaction);

                if (objSaveRoom != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    if (!objSaveRoom.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objSaveRoom.BrokenRulesList.ToString());
                    }
                    flag = _objRoom.Insert(objSaveRoom);
                    // }

                    if (lstSaveRoomAmenities.Count != 0)
                    {
                        _objRoomAmenities = new RoomAmenitiesDAL(lt.Transaction);
                        foreach (RoomAmenities item in lstSaveRoomAmenities)
                        {
                            item.RoomAmenitiesID = Guid.NewGuid();
                            item.RoomID = objSaveRoom.RoomID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objRoomAmenities.Insert(item);
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
        /// Update existing Room
        /// </summary>
        /// <param name="businessObject">Room object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Room businessObject)
        {
            RoomDAL _dataObject = new RoomDAL();
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

        public static bool Update(Room objUpdateRoom, List<RoomAmenities> lstUpdateRoomAmenities)
        {
            bool flag = false;
            RoomDAL _objRoom = null;
            RoomAmenitiesDAL _objRoomAmenities = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objRoom = new RoomDAL(lt.Transaction);

                if (objUpdateRoom != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{

                    if (!objUpdateRoom.IsValid)
                    {
                        throw new InvalidBusinessObjectException(objUpdateRoom.BrokenRulesList.ToString());
                    }
                    flag = _objRoom.Update(objUpdateRoom);
                    // }

                    _objRoomAmenities = new RoomAmenitiesDAL(lt.Transaction);
                    _objRoomAmenities.DeleteByRoomID(objUpdateRoom.RoomID);
                    if (lstUpdateRoomAmenities.Count != 0 && lstUpdateRoomAmenities != null)
                    {
                        foreach (RoomAmenities item in lstUpdateRoomAmenities)
                        {
                            item.RoomAmenitiesID = Guid.NewGuid();
                            item.RoomID = objUpdateRoom.RoomID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objRoomAmenities.Insert(item);
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
        /// get Room by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Room GetByPrimaryKey(Guid keys)
        {
            RoomDAL _dataObject = new RoomDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all Rooms
        /// </summary>
        /// <returns>list</returns>
        public static List<Room> GetAll(Room obj)
        {
            RoomDAL _dataObject = new RoomDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all Rooms
        /// </summary>
        /// <returns>list</returns>
        public static List<Room> GetAll()
        {
            RoomDAL _dataObject = new RoomDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of Room by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Room> GetAllBy(Room.RoomFields fieldName, object value)
        {
            RoomDAL _dataObject = new RoomDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all Rooms
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Room obj)
        {
            RoomDAL _dataObject = new RoomDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        public static DataSet RPTVacantRoomList(Guid? PropertyID, Guid? RoomTypeID, DateTime? StartDate, DateTime? EndDate)
        {
            RoomDAL _dataObject = new RoomDAL();
            return _dataObject.RPTVacantRoomList(PropertyID, RoomTypeID, StartDate, EndDate);
        }
        /// <summary>
        /// get list of all Rooms
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            RoomDAL _dataObject = new RoomDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of Room by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Room.RoomFields fieldName, object value)
        {
            RoomDAL _dataObject = new RoomDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            RoomDAL _dataObject = new RoomDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Room obj)
        {
            RoomDAL _dataObject = new RoomDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete Room by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Room.RoomFields fieldName, object value)
        {
            RoomDAL _dataObject = new RoomDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet GetUnitNo(string UnitNoQuery)
        {
            RoomDAL _dataObject = new RoomDAL();
            return _dataObject.SelectUnitNo(UnitNoQuery);
        }

        public static DataSet RoomSearchData(Guid? PropertyID, Guid? RoomTypeID, string RoomNo, Guid? WingID, Guid? FloorID)
        {
            RoomDAL _Obj = new RoomDAL();
            return _Obj.RoomSearchData(PropertyID, RoomTypeID, RoomNo, WingID, FloorID);
        }


        public static DataSet RoomCountBed(Guid? PropertyID, Guid? RoomTypeID, string RoomNo, Guid? WingID, Guid? FloorID)
        {
            RoomDAL _Obj = new RoomDAL();
            return _Obj.RoomCountBed(PropertyID, RoomTypeID, RoomNo, WingID, FloorID);
        }

        public static bool SaveRoomPhoto(List<Documents> lstDocuments)
        {
            bool flag = false;
            DocumentsDAL _objDocuments = new DocumentsDAL();
            try
            {
                if (lstDocuments.Count != 0)
                {
                    foreach (Documents item in lstDocuments)
                    {
                        item.DocumentID = Guid.NewGuid();

                        if (!item.IsValid)
                        {
                            throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                        }
                        flag = _objDocuments.Insert(item);
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
            return flag;
        }

        public static DataSet RoomAndConferenceSelectExtensionNO(Guid? PropertyID, string ExtentionNo)
        {
            RoomDAL _Obj = new RoomDAL();
            return _Obj.RoomAndConferenceSelectExtensionNO(PropertyID, ExtentionNo);
        }

        public static DataSet RoomCheckDuplicateRoom(Guid? PropertyID, string RoomNo)
        {
            RoomDAL _Obj = new RoomDAL();
            return _Obj.RoomCheckDuplicateRoom(PropertyID, RoomNo);
        }

        public static DataSet GetAllRoomIDOfRoomByAnyRoomID(Guid RoomID, Guid? PropertyID)
        {
            RoomDAL _Obj = new RoomDAL();
            return _Obj.GetAllRoomIDOfRoomByAnyRoomID(RoomID, PropertyID);
        }

        #endregion

    }
}
