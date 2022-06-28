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
    public static class RoomBlockBLL
    {

        //#region data Members


        //private static RoomBlockDAL _dataObject = null;

        //#endregion

        #region Constructor

        static RoomBlockBLL()
        {
            //_dataObject = new RoomBlockDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new RoomBlock
        /// </summary>
        /// <param name="businessObject">RoomBlock object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(RoomBlock businessObject)
        {
            RoomBlockDAL _dataObject = new RoomBlockDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.BlockRoomID = Guid.NewGuid();

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

        public static bool Save(RoomBlock businessObject, List<RoomBlockDetails> lstRoomBlockDetails)
        {
            bool flag = false;
            RoomBlockDAL _objRoomBlock = null;
            RoomBlockDetailsDAL _objRoomBlockDetails = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objRoomBlock = new RoomBlockDAL(lt.Transaction);

                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    businessObject.BlockRoomID = Guid.NewGuid();

                    if (!businessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                    }
                    flag = _objRoomBlock.Insert(businessObject);
                    // }

                    if (lstRoomBlockDetails.Count != 0)
                    {
                        _objRoomBlockDetails = new RoomBlockDetailsDAL(lt.Transaction);
                        foreach (RoomBlockDetails item in lstRoomBlockDetails)
                        {
                            item.BlockRoomDetailID = Guid.NewGuid();
                            item.BlockRoomID = businessObject.BlockRoomID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objRoomBlockDetails.Insert(item);
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
        /// Update existing RoomBlock
        /// </summary>
        /// <param name="businessObject">RoomBlock object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(RoomBlock businessObject)
        {
            RoomBlockDAL _dataObject = new RoomBlockDAL();
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

        public static bool Update(RoomBlock businessObject, List<RoomBlockDetails> lstRoomBlockDetails)
        {
            bool flag = false;
            RoomBlockDAL _objRoomBlock = null;
            RoomBlockDetailsDAL _objRoomBlockDetails = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _objRoomBlock = new RoomBlockDAL(lt.Transaction);

                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{

                    if (!businessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                    }
                    flag = _objRoomBlock.Update(businessObject);
                    // }

                    _objRoomBlockDetails = new RoomBlockDetailsDAL(lt.Transaction);
                    _objRoomBlockDetails.DeleteByBlockRoomID(businessObject.BlockRoomID);
                    if (lstRoomBlockDetails.Count != 0)
                    {
                        foreach (RoomBlockDetails item in lstRoomBlockDetails)
                        {
                            item.BlockRoomDetailID = Guid.NewGuid();
                            item.BlockRoomID = businessObject.BlockRoomID;
                            if (!item.IsValid)
                            {
                                throw new InvalidBusinessObjectException(item.BrokenRulesList.ToString());
                            }
                            flag = _objRoomBlockDetails.Insert(item);
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
        /// get RoomBlock by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static RoomBlock GetByPrimaryKey(Guid keys)
        {
            RoomBlockDAL _dataObject = new RoomBlockDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all RoomBlocks
        /// </summary>
        /// <returns>list</returns>
        public static List<RoomBlock> GetAll(RoomBlock obj)
        {
            RoomBlockDAL _dataObject = new RoomBlockDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all RoomBlocks
        /// </summary>
        /// <returns>list</returns>
        public static List<RoomBlock> GetAll()
        {
            RoomBlockDAL _dataObject = new RoomBlockDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of RoomBlock by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<RoomBlock> GetAllBy(RoomBlock.RoomBlockFields fieldName, object value)
        {
            RoomBlockDAL _dataObject = new RoomBlockDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all RoomBlocks
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(RoomBlock obj)
        {
            RoomBlockDAL _dataObject = new RoomBlockDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all RoomBlocks
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            RoomBlockDAL _dataObject = new RoomBlockDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of RoomBlock by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(RoomBlock.RoomBlockFields fieldName, object value)
        {
            RoomBlockDAL _dataObject = new RoomBlockDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            RoomBlockDAL _dataObject = new RoomBlockDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(RoomBlock obj)
        {
            RoomBlockDAL _dataObject = new RoomBlockDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete RoomBlock by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(RoomBlock.RoomBlockFields fieldName, object value)
        {
            RoomBlockDAL _dataObject = new RoomBlockDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet RoomBlockSearchData(Guid? BlockRoomID, Guid? PropertyID, DateTime? StartDate, DateTime? EndDate, string BlockBy, Guid? CompanyID)
        {
            RoomBlockDAL _dataObject = new RoomBlockDAL();
            return _dataObject.RoomBlockSearchData(BlockRoomID, PropertyID, StartDate, EndDate, BlockBy, CompanyID);
        }

        public static DataSet RoomBlockSelectAllRoomBlockData(DateTime? StartDate, DateTime? EndDate, string BlockBy, Guid? PropertyID, Guid? CompanyID)
        {
            RoomBlockDAL _dataObject = new RoomBlockDAL();
            return _dataObject.RoomBlockSelectAllRoomBlockData(StartDate, EndDate, BlockBy, PropertyID, CompanyID);
        }

        public static bool DeleteBlockRoomDetailsRoomData(Guid BlockRoomDetailID, Guid BlockRoomD, Guid RoomID)
        {
            RoomBlockDAL _dataObject = new RoomBlockDAL();
            return _dataObject.DeleteBlockRoomDetailsRoomData(BlockRoomDetailID, BlockRoomD, RoomID);
        }

        public static bool InsertForComplementoryReservation(DateTime StartDate, DateTime EndDate, string BlockBy, Guid PropertyID, Guid CompanyID, DateTime DateOfBlock, Guid? CauseOfBlock_TermID, Guid RoomID, Guid RoomTypeID, Guid? ReservationID, bool IsBlockForFullReservation)
        {
            RoomBlockDAL _dataObject = new RoomBlockDAL();
            return _dataObject.InsertForComplementoryReservation(StartDate, EndDate, BlockBy, PropertyID, CompanyID, DateOfBlock, CauseOfBlock_TermID, RoomID, RoomTypeID, ReservationID, IsBlockForFullReservation);
        }
        public static bool DeleteForComplementoryReservation(DateTime StartDate, DateTime EndDate, Guid PropertyID, Guid CompanyID, Guid RoomTypeID, Guid ReservationID)
        {
            RoomBlockDAL _dataObject = new RoomBlockDAL();
            return _dataObject.DeleteForComplementoryReservation(StartDate, EndDate, PropertyID, CompanyID, RoomTypeID, ReservationID);
        }
        public static bool DeleteForOldandInsertForNewRoomBlockDetails(DateTime StartDate, DateTime EndDate, string BlockBy, Guid PropertyID, Guid CompanyID, DateTime DateOfBlock, Guid? CauseOfBlock_TermID, Guid NewRoomID, Guid RoomTypeID, Guid ReservationID, bool IsForBlockIsperRoom)
        {
            bool flag = false;
            RoomBlockDAL objForDeleteRoomBlock = null;
            RoomBlockDAL objForInsertRoomBlock = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                objForDeleteRoomBlock = new RoomBlockDAL(lt.Transaction);


                if (ReservationID != null && ReservationID != Guid.Empty)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        objForInsertRoomBlock = new RoomBlockDAL(lt.Transaction);
                        flag = objForDeleteRoomBlock.DeleteForComplementoryReservation(StartDate, EndDate, PropertyID, CompanyID, RoomTypeID, ReservationID);
                        flag = objForInsertRoomBlock.InsertForComplementoryReservation(StartDate, EndDate, BlockBy, PropertyID, CompanyID, DateOfBlock, CauseOfBlock_TermID, NewRoomID, RoomTypeID, ReservationID, IsForBlockIsperRoom);
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





        #endregion

    }
}
