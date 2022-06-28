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
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.DAL;

namespace SQT.Symphony.BusinessLogic.FrontDesk.BLL
{
    public static class ReservationBLL
    {

        //#region data Members

        //private static ReservationDAL _dataObject = null;

        //#endregion

        #region Constructor

        static ReservationBLL()
        {
            //_dataObject = new ReservationDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Reservation
        /// </summary>
        /// <param name="businessObject">Reservation object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Reservation businessObject)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.ReservationID = Guid.NewGuid();

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

        public static bool Save(Reservation objReservation, Guest objGuest, bool isExistingGuest, Address objGuestAddress, ReservationGuest objResGuest, Folio objFolio, Folio objAgentFolio, List<BlockDateRate> lstBlockDateRate, List<ResServiceList> lstResServiceList, ResGuestPaymentInfo objGuestPaymentInfo)
        {
            bool flag = false;
            ReservationDAL _dataObject = null;
            GuestDAL _objGuestDAL = null;
            AddressDAL _objGuestAddress = null;
            ReservationGuestDAL _objReservationGuestDAL = null;
            FolioDAL _objFolioDAL = null;
            BlockDateRateDAL _objBlockDateRateDAL = null;
            ResServiceListDAL _objResServiceListDAL = null;
            ResGuestPaymentInfoDAL _objResGuestPaymentInfoDAL = null;

            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new ReservationDAL(lt.Transaction);
                if (objReservation != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        if (objGuest != null)
                        {
                            _objGuestDAL = new GuestDAL(lt.Transaction);

                            //// if Guest is existing, then, update address.
                            if (isExistingGuest)
                            {
                                if (!objGuest.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(objGuest.BrokenRulesList.ToString());
                                }
                                flag = _objGuestDAL.Update(objGuest);
                            }
                            else
                            {
                                objGuest.GuestID = Guid.NewGuid();

                                if (!objGuest.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(objGuest.BrokenRulesList.ToString());
                                }
                                flag = _objGuestDAL.Insert(objGuest);
                            }
                        }

                        if (objGuestAddress != null)
                        {
                            _objGuestAddress = new AddressDAL(lt.Transaction);

                            //// if Guest is existing, then, update address.
                            if (isExistingGuest)
                            {
                                if (!objGuestAddress.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(objGuestAddress.BrokenRulesList.ToString());
                                }
                                flag = _objGuestAddress.Update(objGuestAddress);
                            }
                            else
                            {
                                objGuestAddress.AddressID = Guid.NewGuid();

                                if (!objGuestAddress.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(objGuestAddress.BrokenRulesList.ToString());
                                }
                                flag = _objGuestAddress.Insert(objGuestAddress);
                                objGuest.AddressID = objGuestAddress.AddressID;
                                flag = _objGuestDAL.Update(objGuest);
                            }
                        }

                        //// FolioID is required in Reservation object, so assign it's id to folio object which is to insert.
                        if (objFolio != null)
                        {
                            objFolio.FolioID = Guid.NewGuid();
                        }

                        if (objReservation != null)
                        {
                            objReservation.ReservationID = Guid.NewGuid();
                            objReservation.GuestID = objGuest.GuestID;
                            objReservation.FolioID = objFolio.FolioID;

                            if (!objReservation.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objReservation.BrokenRulesList.ToString());
                            }
                            flag = _dataObject.Insert(objReservation);
                        }

                        if (objFolio != null)
                        {
                            _objFolioDAL = new FolioDAL(lt.Transaction);

                            objFolio.ReservationID = objReservation.ReservationID;
                            objFolio.GuestID = objGuest.GuestID;

                            if (!objFolio.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objFolio.BrokenRulesList.ToString());
                            }
                            flag = _objFolioDAL.Insert(objFolio);
                        }

                        if (objAgentFolio != null)
                        {
                            _objFolioDAL = new FolioDAL(lt.Transaction);
                            objAgentFolio.FolioID = Guid.NewGuid();
                            objAgentFolio.ParentFolioID = objFolio.FolioID;
                            objAgentFolio.ReservationID = objReservation.ReservationID;
                            objAgentFolio.GuestID = objGuest.GuestID;

                            if (!objAgentFolio.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objAgentFolio.BrokenRulesList.ToString());
                            }
                            flag = _objFolioDAL.Insert(objAgentFolio);
                        }

                        if (objResGuest != null)
                        {
                            objResGuest.ReservationGuestID = Guid.NewGuid();
                            objResGuest.ReservationID = objReservation.ReservationID;
                            objResGuest.GuestID = objGuest.GuestID;
                            objResGuest.FolioID = objFolio.FolioID;
                            objResGuest.Status = "Comming";

                            _objReservationGuestDAL = new ReservationGuestDAL(lt.Transaction);

                            if (!objResGuest.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objResGuest.BrokenRulesList.ToString());
                            }
                            flag = _objReservationGuestDAL.Insert(objResGuest);
                        }

                        if (lstBlockDateRate != null && lstBlockDateRate.Count > 0)
                        {
                            _objBlockDateRateDAL = new BlockDateRateDAL(lt.Transaction);

                            foreach (BlockDateRate objBlockDateRate in lstBlockDateRate)
                            {
                                //// It is assigned during creatign list, because it is used in resServiceList
                                //objBlockDateRate.ResBlockDateRateID = Guid.NewGuid();
                                objBlockDateRate.ReservationID = objReservation.ReservationID;
                                objBlockDateRate.ResStatus_TermID = objReservation.RestStatus_TermID;
                                objBlockDateRate.RoomID = objReservation.RoomID;
                                objBlockDateRate.RoomTypeID = objReservation.RoomTypeID;

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
                                objResServiceList.ReservationID = objReservation.ReservationID;
                                objResServiceList.FolioID = objFolio.FolioID;
                                objResServiceList.ServiceStatus_Term = "NotDelivered";

                                if (!objResServiceList.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(objResServiceList.BrokenRulesList.ToString());
                                }

                                flag = _objResServiceListDAL.Insert(objResServiceList);
                            }
                        }

                        if (objGuestPaymentInfo != null)
                        {
                            objGuestPaymentInfo.ResPayID = Guid.NewGuid();
                            objGuestPaymentInfo.ReservationID = objReservation.ReservationID;
                            objGuestPaymentInfo.GuestID = objGuest.GuestID;
                            objGuestPaymentInfo.FolioID = objFolio.FolioID;

                            _objResGuestPaymentInfoDAL = new ResGuestPaymentInfoDAL(lt.Transaction);

                            if (!objGuestPaymentInfo.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objGuestPaymentInfo.BrokenRulesList.ToString());
                            }
                            flag = _objResGuestPaymentInfoDAL.Insert(objGuestPaymentInfo);
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
        /// Update existing Reservation
        /// </summary>
        /// <param name="businessObject">Reservation object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Reservation businessObject)
        {
            ReservationDAL _dataObject = new ReservationDAL();
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

        public static bool Update(Reservation objReservation, Guest objGuest, Address objGuestAddress, CheckinTimeLog objCheckInLog)
        {
            bool flag = false;
            ReservationDAL _dataObject = null;
            GuestDAL _objGuestDAL = null;
            AddressDAL _objGuestAddress = null;
            BlockDateRateDAL _objBlockDateRateDAL = null;
            CheckinTimeLogDAL _objCheckinTimeLogDAL = null;
            //ResServiceListDAL _objResServiceListDAL = null;
            //ResGuestPaymentInfoDAL _objResGuestPaymentInfoDAL = null;

            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new ReservationDAL(lt.Transaction);

                if (objReservation != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        if (objGuest != null)
                        {
                            _objGuestDAL = new GuestDAL(lt.Transaction);

                            if (!objGuest.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objGuest.BrokenRulesList.ToString());
                            }
                            flag = _objGuestDAL.Update(objGuest);

                        }

                        if (objGuestAddress != null)
                        {
                            _objGuestAddress = new AddressDAL(lt.Transaction);

                            //// if Guest is existing, then, update address.
                            if (!objGuestAddress.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objGuestAddress.BrokenRulesList.ToString());
                            }
                            flag = _objGuestAddress.Update(objGuestAddress);
                        }

                        if (objReservation != null)
                        {
                            if (!objReservation.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objReservation.BrokenRulesList.ToString());
                            }
                            flag = _dataObject.Update(objReservation);

                            _objBlockDateRateDAL = new BlockDateRateDAL(lt.Transaction);
                            flag = _objBlockDateRateDAL.UpdateRoomID(objReservation.ReservationID, objReservation.RoomID, objReservation.RoomTypeID, objReservation.PropertyID, objReservation.CompanyID);
                        }

                        if (objCheckInLog != null)
                        {
                            objCheckInLog.CheckInLogID = Guid.NewGuid();
                            objCheckInLog.ReservationID = objReservation.ReservationID;
                            objCheckInLog.ReservationType_TermID = objReservation.ReservationType_TermID;

                            _objCheckinTimeLogDAL = new CheckinTimeLogDAL(lt.Transaction);

                            if (!objCheckInLog.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objCheckInLog.BrokenRulesList.ToString());
                            }
                            flag = _objCheckinTimeLogDAL.Insert(objCheckInLog);
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

        public static bool UpdateReservationRoomID(Reservation objReservation)
        {
            bool flag = false;
            ReservationDAL _dataObject = null;
            BlockDateRateDAL _objBlockDateRateDAL = null;

            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new ReservationDAL(lt.Transaction);

                if (objReservation != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        if (objReservation != null)
                        {
                            if (!objReservation.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objReservation.BrokenRulesList.ToString());
                            }
                            flag = _dataObject.Update(objReservation);

                            _objBlockDateRateDAL = new BlockDateRateDAL(lt.Transaction);
                            flag = _objBlockDateRateDAL.UpdateRoomID(objReservation.ReservationID, objReservation.RoomID, objReservation.RoomTypeID, objReservation.PropertyID, objReservation.CompanyID);
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

        public static bool EditReservation(Reservation objReservation, Guest objGuest, Address objGuestAddress)
        {
            bool flag = false;
            ReservationDAL _dataObject = null;
            GuestDAL _objGuestDAL = null;
            AddressDAL _objGuestAddress = null;

            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new ReservationDAL(lt.Transaction);

                if (objReservation != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        if (objGuest != null)
                        {
                            _objGuestDAL = new GuestDAL(lt.Transaction);

                            if (!objGuest.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objGuest.BrokenRulesList.ToString());
                            }
                            flag = _objGuestDAL.Update(objGuest);

                        }

                        if (objGuestAddress != null)
                        {
                            _objGuestAddress = new AddressDAL(lt.Transaction);

                            //// if Guest is existing, then, update address.
                            if (!objGuestAddress.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objGuestAddress.BrokenRulesList.ToString());
                            }
                            flag = _objGuestAddress.Update(objGuestAddress);
                        }

                        if (objReservation != null)
                        {
                            if (!objReservation.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objReservation.BrokenRulesList.ToString());
                            }
                            flag = _dataObject.Update(objReservation);
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
        /// get Reservation by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Reservation GetByPrimaryKey(Guid keys)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all Reservations
        /// </summary>
        /// <returns>list</returns>
        public static List<Reservation> GetAll(Reservation obj)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all Reservations
        /// </summary>
        /// <returns>list</returns>
        public static List<Reservation> GetAll()
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of Reservation by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Reservation> GetAllBy(Reservation.ReservationFields fieldName, object value)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all Reservations
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Reservation obj)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all Reservations
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of Reservation by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Reservation.ReservationFields fieldName, object value)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Reservation obj)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete Reservation by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Reservation.ReservationFields fieldName, object value)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet GetRoomResrvationChartData(DateTime? StartDate, DateTime? EndDate, Guid? RoomTypeID, Guid? PropertyID, Guid? CompanyID, int Hrs)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectRoomResrvationChartData(StartDate, EndDate, RoomTypeID, PropertyID, CompanyID, Hrs);
        }

        public static DataSet GetReservation_GetRoomStatus(DateTime? StartDate, Guid? RoomTypeID, Guid? PropertyID, Guid? CompanyID, Guid? FloorID, Guid? WingID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectReservation_GetRoomStatus(StartDate, RoomTypeID, PropertyID, CompanyID, FloorID, WingID);
        }

        public static DataSet GetReservation_GetRoomStatusNew(DateTime? StartDate, Guid? RoomTypeID, Guid? PropertyID, Guid? CompanyID, Guid? FloorID, Guid? WingID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectReservation_GetRoomStatusNew(StartDate, RoomTypeID, PropertyID, CompanyID, FloorID, WingID);
        }

        public static DataSet GetReservation_GetRoomStatusCount(DateTime? StartDate, Guid? RoomTypeID, Guid? PropertyID, Guid? CompanyID, Guid? FloorID, Guid? WingID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectReservation_GetRoomStatusCount(StartDate, RoomTypeID, PropertyID, CompanyID, FloorID, WingID);
        }

        public static DataSet GetResrvationList(Guid? ReservationID, Guid? RoomTypeID, string GuestFullName, string MobileNo, string ReservationNo, Guid? PropertyID, Guid? CompanyID, string strCompanyName, int? status, Guid? BillingInstructionID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectResrvationList(ReservationID, RoomTypeID, GuestFullName, MobileNo, ReservationNo, PropertyID, CompanyID, strCompanyName, status, BillingInstructionID);
        }

        public static DataSet GetResrvationViewData(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID, string strMode, string GuestFullName, string MobileNo, string ReservationNo)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectResrvationViewData(ReservationID, PropertyID, CompanyID, strMode, GuestFullName, MobileNo, ReservationNo);
        }

        public static bool UpdateWithReservationHistory(Reservation objUpdateReservation, ReservationHistory objReservationHistory, DataTable dt)
        {
            bool flag = false;
            ReservationDAL _dataObject = null;
            ReservationHistoryDAL _objReservationHistoryDAL = null;
            TransactionDAL _objTransactionDAL = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new ReservationDAL(lt.Transaction);
                if (objUpdateReservation != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        if (objUpdateReservation != null)
                        {
                            if (!objUpdateReservation.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objUpdateReservation.BrokenRulesList.ToString());
                            }
                            flag = _dataObject.Update(objUpdateReservation);
                        }

                        if (objReservationHistory != null)
                        {
                            _objReservationHistoryDAL = new ReservationHistoryDAL(lt.Transaction);
                            objReservationHistory.ResHistoryID = Guid.NewGuid();

                            if (!objReservationHistory.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objReservationHistory.BrokenRulesList.ToString());
                            }
                            flag = _objReservationHistoryDAL.Insert(objReservationHistory);
                        }

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            _objTransactionDAL = new TransactionDAL(lt.Transaction);

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                DataRow dr = dt.Rows[i];

                                Guid? RoomID;
                                if (Convert.ToString(dr["UnitID"]) != "" && Convert.ToString(dr["UnitID"]) != null)
                                    RoomID = new Guid(Convert.ToString(dr["UnitID"]));
                                else
                                    RoomID = null;

                                flag = _objTransactionDAL.TransactionRefundDeposit(new Guid(Convert.ToString(dr["DepositBookID"])), Convert.ToInt32(Convert.ToString(dr["Zone_TermID"])), Convert.ToDecimal(Convert.ToString(dr["Amt"])), new Guid(Convert.ToString(dr["PaymentAcctID"])), new Guid(Convert.ToString(dr["DepositAcctID"])), new Guid(Convert.ToString(dr["ReservationID"])), new Guid(Convert.ToString(dr["FolioID"])), new Guid(Convert.ToString(dr["UserID"])), new Guid(Convert.ToString(dr["CounterID"])), new Guid(Convert.ToString(dr["PropertyID"])), "FRONT DESK", RoomID, null, Convert.ToBoolean(Convert.ToString(dr["IsApplyCancellationFees"])), null, new Guid(Convert.ToString(dr["CompanyID"])));

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

        public static DataSet GetAllVacantRoom(DateTime? CheckInDate, DateTime? CheckOutDate, Guid? RoomTypeID, bool IsForTotal, string ResIds, Guid? PropertyID, Guid? CompanyID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.GetAllVacantRoom(CheckInDate, CheckOutDate, RoomTypeID, IsForTotal, ResIds, PropertyID, CompanyID);
        }

        public static DataSet GetArrivalListData(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID, string GuestFullName, string MobileNo, string ReservationNo, DateTime? StartDate, DateTime? EndDate, string strMode, string strSymphonyValue)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectArrivalListData(ReservationID, PropertyID, CompanyID, GuestFullName, MobileNo, ReservationNo, StartDate, EndDate, strMode, strSymphonyValue);
        }

        public static DataSet GetAllIsAvailableRoom(DateTime? CheckInDate, DateTime? CheckOutDate, Guid? RoomTypeID, Guid? ReservationID, Guid? PropertyID, Guid? CompanyID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.GetAllIsAvailableRoom(CheckInDate, CheckOutDate, RoomTypeID, ReservationID, PropertyID, CompanyID);
        }

        public static DataSet GetReservationVoucherData(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectReservationVoucherData(ReservationID, PropertyID, CompanyID);
        }

        public static DataSet GetReservationProjectTermData(Guid? PropertyID, Guid? CompanyID, string CategoryGuestType, string CategorySourceofBusiness, string CategoryTitle, string CategoryBillingInstruction, string CategoryModeofPayment)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectReservationProjectTermData(PropertyID, CompanyID, CategoryGuestType, CategorySourceofBusiness, CategoryTitle, CategoryBillingInstruction, CategoryModeofPayment);
        }

        public static DataSet GetReservationPaymentInfo(Guid? PropertyID, Guid? CompanyID, Guid? ReservationID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectReservationPaymentInfo(PropertyID, CompanyID, ReservationID);
        }
        public static DataSet GetReservationPaymentInfoForReprint(Guid? PropertyID, Guid? CompanyID, Guid? ReservationID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectReservationPaymentInfoForReprint(PropertyID, CompanyID, ReservationID);
        }
        public static DataSet GetCancelReservationData(Guid? PropertyID, Guid? CompanyID, Guid? ReservationID, string GuestFullName, string MobileNo, string ReservationNo)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectCancelReservationData(PropertyID, CompanyID, ReservationID, GuestFullName, MobileNo, ReservationNo);
        }

        public static DataSet GetCancellationPolicyAndGuestPayment(Guid? PropertyID, Guid? CompanyID, Guid? ReservationID, Guid? ResPolicyID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectCancellationPolicyAndGuestPayment(PropertyID, CompanyID, ReservationID, ResPolicyID);
        }

        public static DataSet SelectDepatureListData(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID, string GuestFullName, string MobileNo, string ReservationNo, DateTime? StartDate, DateTime? EndDate, string RoomNo)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectDepatureListData(ReservationID, PropertyID, CompanyID, GuestFullName, MobileNo, ReservationNo, StartDate, EndDate, RoomNo);
        }

        public static DataSet ReservationSelectRoomsToSell(Guid? RoomTypeID, DateTime? EntryDate, DateTime? SecondDate, bool? IsForOB, string ResIds, Guid? PropertyID, Guid? CompanyID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.ReservationSelectRoomsToSell(RoomTypeID, EntryDate, SecondDate, IsForOB, ResIds, PropertyID, CompanyID);
        }

        public static DataSet ReservationGetAllVacantRoom(DateTime? CheckInDate, DateTime? CheckOutDate, Guid? RoomTypeID, bool? IsForTotal, int? Total_Vacant, string ResIds, Guid? CompanyID, Guid? PropertyID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.ReservationGetAllVacantRoom(CheckInDate, CheckOutDate, RoomTypeID, IsForTotal, Total_Vacant, ResIds, CompanyID, PropertyID);
        }

        public static DataSet ReservationGetReservations(string ResNo, string FName, string LName, DateTime? CheckInDate, DateTime? CheckOutDate, Guid? RoomTypeID, Guid? RoomID, Guid? ConferenceTypeID, Guid? ConferenceID, int? Status_TermID, Guid? AgentID, DateTime? DateValue, DateTime? Todays, string RoomNo, DateTime? Upto, int? FilterID, Guid? CompanyID, Guid? PropertyID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.ReservationGetReservations(ResNo, FName, LName, CheckInDate, CheckOutDate, RoomTypeID, RoomID, ConferenceTypeID, ConferenceID, Status_TermID, AgentID, DateValue, Todays, RoomNo, Upto, FilterID, CompanyID, PropertyID);
        }

        public static DataSet RoomBlockSelectAllBlockRooms(DateTime? StartDate, DateTime? EndDate, Guid? RoomTypeID, DateTime? SelDate, Guid? PropertyID, Guid? CompanyID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.RoomBlockSelectAllBlockRooms(StartDate, EndDate, RoomTypeID, SelDate, PropertyID, CompanyID);
        }

        public static DataSet ReservationTodaysAvailabilityChart(Guid? RoomTypeID, DateTime? EntryDate, DateTime? SecondDate, bool? IsForOB, string ResIds, Guid? PropertyID, Guid? CompanyID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.ReservationTodaysAvailabilityChart(RoomTypeID, EntryDate, SecondDate, IsForOB, ResIds, PropertyID, CompanyID);
        }

        public static DataSet GetCheckInVoucherData(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectCheckInVoucherData(ReservationID, PropertyID, CompanyID);
        }

        public static DataSet SelectReservationDetailByReservationNo(string ReservationNo, string GuestName)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectReservationDetailByReservationNo(ReservationNo, GuestName);
        }

        public static DataSet GetDetailForFeedback(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectDetailForFeedback(ReservationID, PropertyID, CompanyID);
        }

        public static bool DeleteBlockDateRateAndResServiceListDataByReservationID(Guid? ReservationID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.DeleteBlockDateRateAndResServiceListDataByReservationID(ReservationID);
        }

        public static bool AmendReservation(Reservation objReservation, Guest objGuest, bool isExistingGuest, Address objGuestAddress, ReservationGuest objResGuest, List<BlockDateRate> lstBlockDateRate, List<ResServiceList> lstResServiceList, ResGuestPaymentInfo objGuestPaymentInfo, Folio objFolio, Folio objAgentFolio, int folioagentcount)
        {
            bool flag = false;
            ReservationDAL _dataObject = null;
            GuestDAL _objGuestDAL = null;
            AddressDAL _objGuestAddress = null;
            ReservationGuestDAL _objReservationGuestDAL = null;
            BlockDateRateDAL _objBlockDateRateDAL = null;
            ResServiceListDAL _objResServiceListDAL = null;
            ResGuestPaymentInfoDAL _objResGuestPaymentInfoDAL = null;
            FolioDAL _objFolioDAL = null;

            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new ReservationDAL(lt.Transaction);
                if (objReservation != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        if (objGuest != null)
                        {
                            _objGuestDAL = new GuestDAL(lt.Transaction);

                            if (!objGuest.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objGuest.BrokenRulesList.ToString());
                            }
                            flag = _objGuestDAL.Update(objGuest);
                        }

                        if (objGuestAddress != null)
                        {
                            _objGuestAddress = new AddressDAL(lt.Transaction);

                            if (!objGuestAddress.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objGuestAddress.BrokenRulesList.ToString());
                            }
                            flag = _objGuestAddress.Update(objGuestAddress);
                        }

                        if (objReservation != null)
                        {
                            if (!objReservation.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objReservation.BrokenRulesList.ToString());
                            }
                            objReservation.GuestID = objGuest.GuestID;
                            objReservation.UpdateMode = "AMEND";
                            flag = _dataObject.Update(objReservation);
                        }

                        if (objResGuest != null)
                        {
                            _objReservationGuestDAL = new ReservationGuestDAL(lt.Transaction);

                            if (!objResGuest.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objResGuest.BrokenRulesList.ToString());
                            }
                            flag = _objReservationGuestDAL.Update(objResGuest);
                        }

                        //To Delete BlockDateRate and ServiceList
                        flag = _dataObject.DeleteBlockDateRateAndResServiceListDataByReservationID(objReservation.ReservationID);


                        if (lstBlockDateRate != null && lstBlockDateRate.Count > 0)
                        {
                            _objBlockDateRateDAL = new BlockDateRateDAL(lt.Transaction);

                            foreach (BlockDateRate objBlockDateRate in lstBlockDateRate)
                            {
                                //// It is assigned during creatign list, because it is used in resServiceList
                                //objBlockDateRate.ResBlockDateRateID = Guid.NewGuid();
                                objBlockDateRate.ReservationID = objReservation.ReservationID;
                                objBlockDateRate.ResStatus_TermID = objReservation.RestStatus_TermID;
                                objBlockDateRate.RoomID = objReservation.RoomID;
                                objBlockDateRate.RoomTypeID = objReservation.RoomTypeID;

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
                                objResServiceList.ReservationID = objReservation.ReservationID;
                                objResServiceList.FolioID = objReservation.FolioID;

                                if (!objResServiceList.IsValid)
                                {
                                    throw new InvalidBusinessObjectException(objResServiceList.BrokenRulesList.ToString());
                                }

                                flag = _objResServiceListDAL.Insert(objResServiceList);
                            }
                        }

                        if (objFolio != null)
                        {
                            _objFolioDAL = new FolioDAL(lt.Transaction);

                            objFolio.ReservationID = objReservation.ReservationID;
                            objFolio.GuestID = objGuest.GuestID;

                            if (!objFolio.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objFolio.BrokenRulesList.ToString());
                            }
                            flag = _objFolioDAL.Update(objFolio);
                        }

                        if (objAgentFolio != null)
                        {
                            _objFolioDAL = new FolioDAL(lt.Transaction);

                            if (!objAgentFolio.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objAgentFolio.BrokenRulesList.ToString());
                            }

                            if (folioagentcount == 0)
                            {
                                objAgentFolio.FolioID = Guid.NewGuid();
                                objAgentFolio.ParentFolioID = objFolio.FolioID;
                                objAgentFolio.ReservationID = objReservation.ReservationID;
                                objAgentFolio.GuestID = objGuest.GuestID;

                                flag = _objFolioDAL.Insert(objAgentFolio);
                            }
                            else if (folioagentcount == 1)
                            {
                                objAgentFolio.GuestID = objGuest.GuestID;
                                flag = _objFolioDAL.Update(objAgentFolio);
                            }
                            else if (folioagentcount == 2)
                            {
                                flag = _objFolioDAL.Delete(objAgentFolio.FolioID);
                            }
                        }

                        if (objGuestPaymentInfo != null)
                        {
                            objGuestPaymentInfo.ResPayID = Guid.NewGuid();
                            objGuestPaymentInfo.ReservationID = objReservation.ReservationID;
                            objGuestPaymentInfo.GuestID = objGuest.GuestID;
                            objGuestPaymentInfo.FolioID = objReservation.FolioID;

                            _objResGuestPaymentInfoDAL = new ResGuestPaymentInfoDAL(lt.Transaction);

                            if (!objGuestPaymentInfo.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objGuestPaymentInfo.BrokenRulesList.ToString());
                            }
                            flag = _objResGuestPaymentInfoDAL.Insert(objGuestPaymentInfo);
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

        public static DataSet GetAmendReservationListData(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID, string Mode, string GuestFullName, string MobileNo, string ReservationNo, DateTime? CheckInDate)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectAmendReservationListData(ReservationID, PropertyID, CompanyID, Mode, GuestFullName, MobileNo, ReservationNo, CheckInDate);
        }
        public static DataSet GetReservationAmendHistoryData(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID, string Mode, string GuestFullName, string MobileNo, string ReservationNo, DateTime? CheckInDate, string AmendmentBy, DateTime? AmendmentDate)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectReservationAmendHistoryData(ReservationID, PropertyID, CompanyID, Mode, GuestFullName, MobileNo, ReservationNo, CheckInDate, AmendmentBy, AmendmentDate);
        }
        public static DataSet GetAllUnpostedCharges(Guid? ReservationID, Guid? SendFolioID, bool? IsForSingleInv)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.GetAllUnpostedCharges(ReservationID, SendFolioID, IsForSingleInv);
        }

        public static DataSet GetSwapRoomList(Guid? PropertyID, Guid? CompanyID, string GuestFullName, string ReservationNo, string RoomNo, Guid? RoomTypeID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectSwapRoomList(PropertyID, CompanyID, GuestFullName, ReservationNo, RoomNo, RoomTypeID);
        }

        public static DataSet GetRPTRoomHistory(Guid? CompanyID, Guid? PropertyID, Guid? RoomID, DateTime? StartDate, DateTime? EndDate)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectRPTRoomHistory(CompanyID, PropertyID, RoomID, StartDate, EndDate);
        }

        public static DataSet GetCheckOutVoucherData(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectCheckOutVoucherData(ReservationID, PropertyID, CompanyID);
        }

        public static DataSet GetCheckInRoomNoAndReservationNo(Guid? PropertyID, Guid? CompanyID, string ReservationNo)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectCheckInRoomNoAndReservationNo(PropertyID, CompanyID, ReservationNo);
        }

        public static DataSet Reservation_SymphonySelectReservation(Guid? ReservationID, string ReservationNo, Guid? AgentID, DateTime? CheckInDate, DateTime? CheckOutDate, Guid? ConferenceID, Guid? ConferenceTypeID, Guid? GroupID, Guid? GuestID, Guid? RefReservationID, DateTime? ReservationDate, Guid? RoomID, Guid? RoomTypeID, bool? IsForChart, int? Status_TermID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.Reservation_SymphonySelectReservation(ReservationID, ReservationNo, AgentID, CheckInDate, CheckOutDate, ConferenceID, ConferenceTypeID, GroupID, GuestID, RefReservationID, ReservationDate, RoomID, RoomTypeID, IsForChart, Status_TermID);
        }

        public static bool UpdateAgentID(Guid ReservationID, Guid AgentID, Guid PropertyID, Guid CompanyID, DateTime UpdatedOn, Guid UpdatedBy)
        {
            try
            {
                ReservationDAL _dataObject = new ReservationDAL();
                return _dataObject.UpdateAgentID(ReservationID, AgentID, PropertyID, CompanyID, UpdatedOn, UpdatedBy);
            }
            catch
            {
                throw;
            }
        }

        public static DataSet GetReservationsForExtendStay(DateTime? CheckInDate, DateTime? CheckOutDate, Guid? RoomTypeID, Guid? RoomID, int? Status_TermID, Guid? CompanyID, Guid? PropertyID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectReservationsForExtendStay(CheckInDate, CheckOutDate, RoomTypeID, RoomID, Status_TermID, CompanyID, PropertyID);
        }

        public static bool UpdateReservationWithBlockDateRateAndHistory(Reservation objUpdateReservation, ReservationHistory objReservationHistory, Guid? reservationID)
        {
            bool flag = false;
            ReservationDAL _dataObject = null;
            ReservationHistoryDAL _objReservationHistoryDAL = null;
            BlockDateRateDAL _objBlockDateRateDAL = null;
            LinqTransaction lt = null;

            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new ReservationDAL(lt.Transaction);
                if (objUpdateReservation != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        if (objUpdateReservation != null)
                        {
                            if (!objUpdateReservation.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objUpdateReservation.BrokenRulesList.ToString());
                            }
                            flag = _dataObject.Update(objUpdateReservation);
                        }

                        if (objReservationHistory != null)
                        {
                            _objReservationHistoryDAL = new ReservationHistoryDAL(lt.Transaction);
                            objReservationHistory.ResHistoryID = Guid.NewGuid();

                            if (!objReservationHistory.IsValid)
                            {
                                throw new InvalidBusinessObjectException(objReservationHistory.BrokenRulesList.ToString());
                            }
                            flag = _objReservationHistoryDAL.Insert(objReservationHistory);
                        }

                        if (reservationID != null)
                        {
                            _objBlockDateRateDAL = new BlockDateRateDAL(lt.Transaction);
                            flag = _objBlockDateRateDAL.UpdateRoomID(reservationID, objUpdateReservation.RoomID, objUpdateReservation.RoomTypeID, objUpdateReservation.PropertyID, objUpdateReservation.CompanyID);
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

        public static DataSet GetReservationPaymentInfo4ExtendStay(Guid? PropertyID, Guid? CompanyID, Guid? ReservationID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectReservationPaymentInfo4ExtendStay(PropertyID, CompanyID, ReservationID);
        }

        public static DataSet GetReservation4CompanyInvoice(DateTime startDate, DateTime endDate, Guid? ReservationID, Guid? AgentID, Guid? PropertyID, Guid? CompanyID, Guid? BillingInstructionID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectReservation4CompanyInvoice(startDate, endDate, ReservationID, AgentID, PropertyID, CompanyID, BillingInstructionID);
        }

        public static DataSet SelectReservationInfo4CompanyInvoice(Guid ReservationID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectReservationInfo4CompanyInvoice(ReservationID);
        }
        public static DataSet GetBillingInstructionTermStatus(Guid ReservationID, Guid CompanyID, Guid PropertyID, bool IsFullBillToGuest)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectBillingInstructionTermStatus(ReservationID, CompanyID, PropertyID, IsFullBillToGuest);
        }

        public static DataSet SearchKeyAndRoomData(Guid PropertyID, string SearchType, string SearchText)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SearchRoomAndKey(PropertyID, SearchType, SearchText);
        }
        public static DataSet GetOccupiedRoomAndTotalNoOfRoom(Guid CompanyID, Guid PropertyID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectNoOfRoomAndOccupiedRoom(CompanyID, PropertyID);
        }
        public static DataSet GetCreditCardWiseCollection(Guid CompanyID, Guid PropertyID, Guid? FolioID, DateTime? StartDate, DateTime? EndDate, bool IsDetailReport, DateTime? TranscationDateForDetail, string GuestNameForDR, Guid? AcctIDForDR, string GuestFullName, string CardNo)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectCreditCardWiseCollection(CompanyID, PropertyID, FolioID, StartDate, EndDate, IsDetailReport, TranscationDateForDetail, GuestNameForDR, AcctIDForDR, GuestFullName, CardNo);
        }
        public static DataSet GetCompanyPostingReportData(DateTime? StartDate, DateTime? EndDate, Guid? CorporateID, Guid CompanyID, Guid PropertyID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectCompanyPostingReportData(StartDate, EndDate, CorporateID, CompanyID, PropertyID);
        }

        public static DataSet SelectRetentionChargePercent(Guid ReservationID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SelectRetentionChargePercent(ReservationID);
        }

        public static DataSet GetNoOfRoomNights(DateTime startDate, DateTime endDate, string roomNightStatus, Guid? RatecardID, string ResStatus)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.GetNoOfRoomNights(startDate, endDate, roomNightStatus, RatecardID, ResStatus);
        }

        public static DataSet GetTotalNumOfOverstayDays(Guid ReservationID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.GetTotalNumOfOverstayDays(ReservationID);
        }

        public static DataSet GetGuestEmail4OverstayNotification()
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.GetGuestEmail4OverstayNotification();
        }

        public static DataSet GetTotalNumOfOverstayCharges(Guid ReservationID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.GetTotalNumOfOverstayCharge(ReservationID);
        }

        public static bool UpdateOverStayStatusAfterPayment(Guid ReservationID)
        {
            try
            {
                ReservationDAL _dataObject = new ReservationDAL();
                return _dataObject.UpdateOverStayStatusAfterPayment(ReservationID);
            }
            catch
            {
                throw;
            }
        }

        public static DataSet GetInfraServiceChargeReport(Guid CompanyID, Guid PropertyID, DateTime? StartDate, DateTime? EndDate, string ReportType)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.GetInfraServiceChargeReport(CompanyID, PropertyID, StartDate, EndDate, ReportType);
        }

        public static DataSet SearchRoomByRoomNo(string strRoomNo, Guid ReservationID)
        {
            ReservationDAL _dataObject = new ReservationDAL();
            return _dataObject.SearchRoomByRoomNo(strRoomNo,ReservationID);
        }

        public static bool UpdateWronglyAssignedRoomNo(Guid ReservationID, Guid RoomID)
        {
            try
            {
                ReservationDAL _dataObject = new ReservationDAL();
                return _dataObject.UpdateWronglyAssignedRoomNo(ReservationID, RoomID);
            }
            catch
            {
                throw;
            }
        }
        #endregion

    }
}
