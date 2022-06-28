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
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using SQT.Symphony.BusinessLogic.IRMS.DAL;
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.DAL;

namespace SQT.Symphony.BusinessLogic.IRMS.BLL
{
    public static class PaymentScheduleBLL
    {

        //#region data Members

        //private static PaymentScheduleDAL _dataObject = null;

        //#endregion

        #region Constructor

        static PaymentScheduleBLL()
        {
            //_dataObject = new PaymentScheduleDAL();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Get Schedule Information For Investor Information
        /// </summary>
        /// <param name="InvRoomID"></param>
        /// <param name="InvID"></param>
        /// <param name="SlabID"></param>
        /// <returns></returns>
        public static DataSet GetScheduleInformation(Guid InvRoomID, Guid InvID, Guid SlabID)
        {
            PaymentScheduleDAL _Obj = new PaymentScheduleDAL();
            return _Obj.GetScheduleInformation(InvRoomID, InvID, SlabID);
        }
        /// <summary>
        /// Insert new PaymentSchedule
        /// </summary>
        /// <param name="businessObject">PaymentSchedule object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(PaymentSchedule businessObject)
        {
            PaymentScheduleDAL _dataObject = new PaymentScheduleDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.PaymentScheduleID = Guid.NewGuid();

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

        public static bool SaveNew(List<PaymentSchedule> lstBusinessObject, List<PaymentSchedule> lstOtherCostPaymentSchedule, Guid investorRoomID, InvestorsUnit objInvestorsUnit)
        {
            bool flag = false;
            LinqTransaction lt = LinqSql.CreateTransaction("SQLConStr");

            try
            {
                PaymentScheduleDAL _dataObject = new PaymentScheduleDAL(lt.Transaction);
                InvestorsUnitDAL _investorsUnit = new InvestorsUnitDAL(lt.Transaction);

                if (objInvestorsUnit != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        if (!objInvestorsUnit.IsValid)
                        {
                            throw new InvalidBusinessObjectException(objInvestorsUnit.BrokenRulesList.ToString());
                        }
                        flag = _investorsUnit.Update(objInvestorsUnit);
                    }
                }
                else
                {
                    lt.Rollback();
                    throw new InvalidBusinessObjectException("Object Is NULL");
                }

                _dataObject.DeleteByInvestorRoomID(investorRoomID);

                DateTime? dtOnBooking = new DateTime();
                DateTime? dtOnPossession = new DateTime();

                for (int i = 0; i < lstBusinessObject.Count; i++)
                {
                    if (lstBusinessObject[i] != null)
                    {
                        using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                        {
                            if (!lstBusinessObject[i].IsValid)
                            {
                                throw new InvalidBusinessObjectException(lstBusinessObject[i].BrokenRulesList.ToString());
                            }
                            flag = _dataObject.InsertNew(lstBusinessObject[i]);
                        }

                        if (i == 0)
                        {
                            dtOnBooking = lstBusinessObject[i].DueDate;
                            dtOnPossession = lstBusinessObject[i].DueDate;

                            //// Update OnBooking Schedule Date.
                            //for (int j = 0; j < lstOtherCostPaymentSchedule.Count; j++)
                            //{
                            //    if (lstOtherCostPaymentSchedule[j].ScheduleType.ToUpper() == "ONBOOKING")
                            //    {
                            //        lstOtherCostPaymentSchedule[j].DueDate = lstBusinessObject[i].DueDate;
                            //    }
                            //}
                        }

                        if (lstBusinessObject[i].DueDate < dtOnBooking)
                        {
                            dtOnBooking = lstBusinessObject[i].DueDate;
                        }

                        if (lstBusinessObject[i].DueDate > dtOnPossession)
                        {
                            dtOnPossession = lstBusinessObject[i].DueDate;
                        }

                        for (int j = 0; j < lstOtherCostPaymentSchedule.Count; j++)
                        {
                            if (lstOtherCostPaymentSchedule[j].ScheduleType.ToUpper() == "ONPOSSESSION")
                            {
                                lstOtherCostPaymentSchedule[j].DueDate = dtOnPossession;
                            }
                            else if (lstOtherCostPaymentSchedule[j].ScheduleType.ToUpper() == "ONBOOKING")
                            {
                                lstOtherCostPaymentSchedule[j].DueDate = dtOnBooking;
                            }
                        }

                        //if (i == (lstBusinessObject.Count - 1))
                        //{
                        //    // Update OnBooking Schedule Date.
                        //    for (int j = 0; j < lstOtherCostPaymentSchedule.Count; j++)
                        //    {
                        //        if (lstOtherCostPaymentSchedule[j].ScheduleType.ToUpper() == "ONPOSSESSION")
                        //        {
                        //            lstOtherCostPaymentSchedule[j].DueDate = lstBusinessObject[i].DueDate;
                        //        }
                        //    }
                        //}
                    }
                    else
                    {
                        lt.Rollback();
                        throw new InvalidBusinessObjectException("Object Is NULL");
                    }
                }

                for (int i = 0; i < lstOtherCostPaymentSchedule.Count; i++)
                {
                    if (lstOtherCostPaymentSchedule[i] != null)
                    {
                        using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                        {
                            if (!lstOtherCostPaymentSchedule[i].IsValid)
                            {
                                throw new InvalidBusinessObjectException(lstOtherCostPaymentSchedule[i].BrokenRulesList.ToString());
                            }
                            flag = _dataObject.InsertNew(lstOtherCostPaymentSchedule[i]);
                        }
                    }
                    else
                    {
                        lt.Rollback();
                        throw new InvalidBusinessObjectException("Object Is NULL");
                    }
                }


                    //foreach (PaymentSchedule pmtSchedule in lstBusinessObject)
                    //{
                    //    if (pmtSchedule != null)
                    //    {
                    //        if (pmtSchedule.IsReceiptCreated == false)
                    //        {
                    //            using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //            {
                    //                if (!pmtSchedule.IsValid)
                    //                {
                    //                    throw new InvalidBusinessObjectException(pmtSchedule.BrokenRulesList.ToString());
                    //                }
                    //                flag = _dataObject.InsertNew(pmtSchedule);
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        lt.Rollback();
                    //        throw new InvalidBusinessObjectException("Object Is NULL");
                    //    }
                    //}

                    if (flag)
                    {
                        lt.Commit();
                        return flag;
                    }
                    else
                    {
                        lt.Rollback();
                        return flag;
                    }
            }
            catch
            {
                lt.Rollback();
                throw;
            }
        }

        /// <summary>
        /// Update existing PaymentSchedule
        /// </summary>
        /// <param name="businessObject">PaymentSchedule object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(PaymentSchedule businessObject)
        {
            PaymentScheduleDAL _dataObject = new PaymentScheduleDAL();
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
        /// get PaymentSchedule by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static PaymentSchedule GetByPrimaryKey(Guid keys)
        {
            PaymentScheduleDAL _dataObject = new PaymentScheduleDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all PaymentSchedules
        /// </summary>
        /// <returns>list</returns>
        public static List<PaymentSchedule> GetAll(PaymentSchedule obj)
        {
            PaymentScheduleDAL _dataObject = new PaymentScheduleDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all PaymentSchedules
        /// </summary>
        /// <returns>list</returns>
        public static List<PaymentSchedule> GetAll()
        {
            PaymentScheduleDAL _dataObject = new PaymentScheduleDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of PaymentSchedule by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<PaymentSchedule> GetAllBy(PaymentSchedule.PaymentScheduleFields fieldName, object value)
        {
            PaymentScheduleDAL _dataObject = new PaymentScheduleDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all PaymentSchedules
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(PaymentSchedule obj)
        {
            PaymentScheduleDAL _dataObject = new PaymentScheduleDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all PaymentSchedules
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            PaymentScheduleDAL _dataObject = new PaymentScheduleDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of PaymentSchedule by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(PaymentSchedule.PaymentScheduleFields fieldName, object value)
        {
            PaymentScheduleDAL _dataObject = new PaymentScheduleDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            PaymentScheduleDAL _dataObject = new PaymentScheduleDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(PaymentSchedule obj)
        {
            PaymentScheduleDAL _dataObject = new PaymentScheduleDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete PaymentSchedule by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(PaymentSchedule.PaymentScheduleFields fieldName, object value)
        {
            PaymentScheduleDAL _dataObject = new PaymentScheduleDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet SearchPaymentScheduleData(Guid? PaymentScheduleID, DateTime? DueDate, Guid? CompanyID, Guid? InvestorID, Guid? RoomID, string UnitNumber, bool? IsDefault, Guid? PropertyID)
        {
            PaymentScheduleDAL _dataObject = new PaymentScheduleDAL();
            return _dataObject.SearchPaymentScheduleData(PaymentScheduleID, DueDate, CompanyID, InvestorID, RoomID, UnitNumber, IsDefault, PropertyID);
        }

        public static DataSet SearchPaymentScheduleDataNew(Guid? CompanyID, Guid? InvestorID, string UnitNumber, Guid? PropertyID)
        {
            PaymentScheduleDAL _dataObject = new PaymentScheduleDAL();
            return _dataObject.SearchPaymentScheduleDataNew(CompanyID, InvestorID, UnitNumber, PropertyID);
        }

        public static DataSet PaymentScheduleGetAllByInvestorRoomID(Guid InvestorRoomID)
        {
            PaymentScheduleDAL _dataObject = new PaymentScheduleDAL();
            return _dataObject.PaymentScheduleGetAllByInvestorRoomID(InvestorRoomID);
        }

        public static DataSet GetPaymentScheduleByInvestorRoomID(Guid InvestorRoomID)
        {
            PaymentScheduleDAL _dataObject = new PaymentScheduleDAL();
            return _dataObject.GetPaymentScheduleByInvestorRoomID(InvestorRoomID);
        }

        public static DataSet GetTotalAmountByPaymentSlab(string PaymentQuery)
        {
            PaymentScheduleDAL _dataObject = new PaymentScheduleDAL();
            return _dataObject.SelectTotalAmountByPaymentSlab(PaymentQuery);
        }

        public static DataSet GetPaymentByScheduleID(Guid PaymentScheduleID)
        {
            PaymentScheduleDAL _dataObject = new PaymentScheduleDAL();
            return _dataObject.GetPaymentByScheduleID(PaymentScheduleID);
        }
        public static bool InvestorScheduleLoadStadScheduleAgain(Guid? InvestorID, Guid? RoomID)
        {
            PaymentScheduleDAL _Obj = new PaymentScheduleDAL();
            return _Obj.InvestorScheduleLoadStadScheduleAgain(InvestorID, RoomID);
        }

        public static DataSet PaymentScheduleSelectInvestorPaymentDetails(Guid? InvestorRoomID, Guid? InvestorID, Guid? CompanyID)
        {
            PaymentScheduleDAL _dataObject = new PaymentScheduleDAL();
            return _dataObject.PaymentScheduleSelectInvestorPaymentDetails(InvestorRoomID, InvestorID, CompanyID);
        }

        public static DataSet PaymentScheduleGetLadgerStatement(Guid investorID, Guid propertyID, DateTime? dateFrom, DateTime? dateTo)
        {
            PaymentScheduleDAL _dataObject = new PaymentScheduleDAL();
            return _dataObject.PaymentScheduleGetLadgerStatement(investorID, propertyID,dateFrom,dateTo);
        }

        #endregion

    }
}
