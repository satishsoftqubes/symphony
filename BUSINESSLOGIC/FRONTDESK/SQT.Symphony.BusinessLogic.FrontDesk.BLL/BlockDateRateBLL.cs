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
    public static class BlockDateRateBLL
    {

        //#region data Members

        //private static BlockDateRateDAL _dataObject = null;

        //#endregion

        #region Constructor

        static BlockDateRateBLL()
        {
            //_dataObject = new BlockDateRateDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new BlockDateRate
        /// </summary>
        /// <param name="businessObject">BlockDateRate object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(BlockDateRate businessObject)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ResBlockDateRateID = Guid.NewGuid();

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
        /// Update existing BlockDateRate
        /// </summary>
        /// <param name="businessObject">BlockDateRate object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(BlockDateRate businessObject)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
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
        /// get BlockDateRate by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static BlockDateRate GetByPrimaryKey(Guid keys)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all BlockDateRates
        /// </summary>
        /// <returns>list</returns>
        public static List<BlockDateRate> GetAll(BlockDateRate obj)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all BlockDateRates
        /// </summary>
        /// <returns>list</returns>
        public static List<BlockDateRate> GetAll()
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of BlockDateRate by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<BlockDateRate> GetAllBy(BlockDateRate.BlockDateRateFields fieldName, object value)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all BlockDateRates
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(BlockDateRate obj)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all BlockDateRates
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of BlockDateRate by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(BlockDateRate.BlockDateRateFields fieldName, object value)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        public static DataSet GetRPTRoomRentRevenue(Guid? CompanyID, Guid? PropertyID, Guid? FolioID, Guid? RoomTypeID, DateTime? StartDate, DateTime? EndDate)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.SelectRPTRoomRentDetail(CompanyID, PropertyID, FolioID, RoomTypeID, StartDate, EndDate);
        }

        public static DataSet GetRPTOccupancyChartByBlockAndRoomType(Guid? CompanyID, Guid? PropertyID, Guid? RoomTypeID, DateTime? StartDate, DateTime? EndDate)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.SelectRPTOccupancyChartByBlockAndRoomType(CompanyID, PropertyID, RoomTypeID, StartDate, EndDate);
        }

        public static DataSet GetRPTOccupancyChartByBlockAndRateCard(Guid? CompanyID, Guid? PropertyID, Guid? RoomTypeID, DateTime? StartDate, DateTime? EndDate)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.SelectRPTOccupancyChartByBlockAndRateCard(CompanyID, PropertyID, RoomTypeID, StartDate, EndDate);
        }

        public static DataSet GetRPTOccupancyChartByBlockType(Guid? CompanyID, Guid? PropertyID, DateTime? StartDate, DateTime? EndDate)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.SelectRPTOccupancyChartByBlockType(CompanyID, PropertyID, StartDate, EndDate);
        }

        public static DataSet GetRPTYieldCalculation(Guid? CompanyID, Guid? PropertyID, DateTime? StartDate, DateTime? EndDate)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.SelectRPTYieldCalculation(CompanyID, PropertyID, StartDate, EndDate);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(BlockDateRate obj)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete BlockDateRate by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(BlockDateRate.BlockDateRateFields fieldName, object value)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static bool UpdateRoomID(Guid ReservationID, Guid RoomID, Guid RoomTypeID, Guid PropertyID, Guid CompanyID)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.UpdateRoomID(ReservationID, RoomID, RoomTypeID, PropertyID, CompanyID);
        }

        public static bool DeleteByReservationID(Guid ReservationID)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.DeleteByReservationID(ReservationID);
        }

        public static bool SaveBlockDateEntry(List<BlockDateRate> lstBlockDateRate, List<ResServiceList> lstResServiceList, Guid reservationid, Guid roomid, Guid roomtypeid, int? restStatusTermID, Guid folioid)
        {
            bool flag = false;
            BlockDateRateDAL _objBlockDateRateDAL = null;
            ResServiceListDAL _objResServiceListDAL = null;

            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");

                using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                {
                    if (lstBlockDateRate != null && lstBlockDateRate.Count > 0)
                    {
                        _objBlockDateRateDAL = new BlockDateRateDAL(lt.Transaction);

                        foreach (BlockDateRate objBlockDateRate in lstBlockDateRate)
                        {
                            //// It is assigned during creatign list, because it is used in resServiceList
                            //objBlockDateRate.ResBlockDateRateID = Guid.NewGuid();
                            objBlockDateRate.ReservationID = reservationid;
                            objBlockDateRate.ResStatus_TermID = restStatusTermID;
                            objBlockDateRate.RoomID = roomid;
                            objBlockDateRate.RoomTypeID = roomtypeid;

                            if (!objBlockDateRate.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objBlockDateRate.BrokenRulesList.ToString());
                            }

                            flag = _objBlockDateRateDAL.Insert(objBlockDateRate);
                        }
                    }

                    if (lstResServiceList != null && lstResServiceList.Count > 0)
                    {
                        _objResServiceListDAL = new ResServiceListDAL(lt.Transaction);

                        foreach (ResServiceList objResServiceList in lstResServiceList)
                        {
                            //// It is assigned during creatign list
                            //objResServiceList.ResServiceID = Guid.NewGuid(); 
                            objResServiceList.ReservationID = reservationid;
                            objResServiceList.FolioID = folioid;
                            objResServiceList.ServiceStatus_Term = "NotDelivered";

                            if (!objResServiceList.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objResServiceList.BrokenRulesList.ToString());
                            }

                            flag = _objResServiceListDAL.Insert(objResServiceList);
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
                        throw new InvalidBusinessObjectException("Object Is NULL");
                    }
                }
            }
            catch
            {
                lt.Rollback();
                throw;
            }
            return flag;
        }

        public static bool DeleteUnPostedTransByReservationID(Guid reservationID)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.DeleteUnPostedTransByReservationID(reservationID);
        }

        public static bool BillingToCompany(DateTime? dtStartDate, DateTime? dtEndDate, decimal? dcDiscountRate, string strDiscountType, Guid? ReservationID, string strBillingInstruction)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.BillingToCompany(dtStartDate, dtEndDate, dcDiscountRate, strDiscountType, ReservationID, strBillingInstruction);
        }

        public static decimal CalculateTax(Guid? AcctID, decimal? Amount, string TransType, Guid? UnitID, Guid? ResID, int? TaxFrom, int? Qty, string TaxIDs, Guid? PropertyID, Guid? CompanyID)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.CalculateTax(AcctID, Amount, TransType, UnitID,  ResID, TaxFrom, Qty, TaxIDs, PropertyID, CompanyID);
        }

        public static DataSet GetTotalRoomRateByDatePeriod(Guid? ReservationID, DateTime? StartDate, DateTime? EndDate, Guid? PropertyID, Guid? CompanyID)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.SelectTotalRoomRateByDatePeriod(ReservationID,StartDate, EndDate,PropertyID, CompanyID);
        }

        public static DataSet GetData4UpgradeDowngrade(Guid? ReservationID,Guid? NewRoomTypeID)
        {
            BlockDateRateDAL _dataObject = new BlockDateRateDAL();
            return _dataObject.SelectData4UpgradeDowngrade(ReservationID, NewRoomTypeID);
        }
        #endregion

    }
}
