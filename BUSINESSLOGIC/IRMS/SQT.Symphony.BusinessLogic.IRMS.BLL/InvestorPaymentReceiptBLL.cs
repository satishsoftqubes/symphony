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
    public static class InvestorPaymentReceiptBLL
    {

        //#region data Members

        //private static InvestorPaymentReceiptDAL _dataObject = null;

        //#endregion

        #region Constructor

        static InvestorPaymentReceiptBLL()
        {
            //_dataObject = new InvestorPaymentReceiptDAL();
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// Insert new InvestorPaymentReceipt
        /// </summary>
        /// <param name="businessObject">InvestorPaymentReceipt object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(InvestorPaymentReceipt businessObject)
        {
            InvestorPaymentReceiptDAL _dataObject = new InvestorPaymentReceiptDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.InvestorPaymentReceiptID = Guid.NewGuid();

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
        /// Update existing InvestorPaymentReceipt
        /// </summary>
        /// <param name="businessObject">InvestorPaymentReceipt object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(InvestorPaymentReceipt businessObject)
        {
            InvestorPaymentReceiptDAL _dataObject = new InvestorPaymentReceiptDAL();
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
        /// get InvestorPaymentReceipt by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static InvestorPaymentReceipt GetByPrimaryKey(Guid keys)
        {
            InvestorPaymentReceiptDAL _dataObject = new InvestorPaymentReceiptDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all InvestorPaymentReceipts
        /// </summary>
        /// <returns>list</returns>
        public static List<InvestorPaymentReceipt> GetAll(InvestorPaymentReceipt obj)
        {
            InvestorPaymentReceiptDAL _dataObject = new InvestorPaymentReceiptDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all InvestorPaymentReceipts
        /// </summary>
        /// <returns>list</returns>
        public static List<InvestorPaymentReceipt> GetAll()
        {
            InvestorPaymentReceiptDAL _dataObject = new InvestorPaymentReceiptDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of InvestorPaymentReceipt by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<InvestorPaymentReceipt> GetAllBy(InvestorPaymentReceipt.InvestorPaymentReceiptFields fieldName, object value)
        {
            InvestorPaymentReceiptDAL _dataObject = new InvestorPaymentReceiptDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all InvestorPaymentReceipts
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(InvestorPaymentReceipt obj)
        {
            InvestorPaymentReceiptDAL _dataObject = new InvestorPaymentReceiptDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all InvestorPaymentReceipts
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            InvestorPaymentReceiptDAL _dataObject = new InvestorPaymentReceiptDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of InvestorPaymentReceipt by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(InvestorPaymentReceipt.InvestorPaymentReceiptFields fieldName, object value)
        {
            InvestorPaymentReceiptDAL _dataObject = new InvestorPaymentReceiptDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            InvestorPaymentReceiptDAL _dataObject = new InvestorPaymentReceiptDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(InvestorPaymentReceipt obj)
        {
            InvestorPaymentReceiptDAL _dataObject = new InvestorPaymentReceiptDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete InvestorPaymentReceipt by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(InvestorPaymentReceipt.InvestorPaymentReceiptFields fieldName, object value)
        {
            InvestorPaymentReceiptDAL _dataObject = new InvestorPaymentReceiptDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }


        /// <summary>
        /// Insert new InvestorPaymentReceipt
        /// </summary>
        /// <param name="businessObject">InvestorPaymentReceipt object</param>
        /// <param name="objPS">PaymentSchedule object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(InvestorPaymentReceipt businessObject, PaymentSchedule objPS)
        {
            bool flag = false;
            InvestorPaymentReceiptDAL _dataObject = new InvestorPaymentReceiptDAL();
            PaymentScheduleDAL _objPS = null;
            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new InvestorPaymentReceiptDAL(lt.Transaction);
                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    //This is set in front page.
                    //businessObject.InvestorPaymentReceiptID = Guid.NewGuid();

                    if (!businessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                    }
                    flag = _dataObject.Insert(businessObject);
                    //}
                    if (objPS != null)
                    {
                        _objPS = new PaymentScheduleDAL(lt.Transaction);
                        if (!objPS.IsValid)
                        {
                            throw new InvalidBusinessObjectException(objPS.BrokenRulesList.ToString());
                        }
                        flag = _objPS.Update(objPS);
                    }
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
                else
                {
                    lt.Rollback();
                    throw new InvalidBusinessObjectException("Object Is NULL");
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
        /// Update existing InvestorPaymentReceipt
        /// </summary>
        /// <param name="businessObject">InvestorPaymentReceipt object</param>
        /// <param name="objPS">PaymentSchedule object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(InvestorPaymentReceipt businessObject, PaymentSchedule objPS)
        {
            bool flag = false;
            InvestorPaymentReceiptDAL _dataObject = new InvestorPaymentReceiptDAL();
            PaymentScheduleDAL _objPS = null;
            LinqTransaction lt = null;
            try
            {
                lt = LinqSql.CreateTransaction("SQLConStr");
                _dataObject = new InvestorPaymentReceiptDAL(lt.Transaction);
                if (businessObject != null)
                {
                    //using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    //{
                    if (!businessObject.IsValid)
                    {
                        throw new InvalidBusinessObjectException(businessObject.BrokenRulesList.ToString());
                    }
                    flag = _dataObject.Update(businessObject);
                    //}
                    if (objPS != null)
                    {
                        _objPS = new PaymentScheduleDAL(lt.Transaction);
                        if (!objPS.IsValid)
                        {
                            throw new InvalidBusinessObjectException(objPS.BrokenRulesList.ToString());
                        }
                        flag = _objPS.Update(objPS);
                    }
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
        }

        public static DataSet GetAllWithSearchDataSet(Guid? InvestorPaymentReceiptID, Guid? InvestorID, string InvestorName, Guid? CompanyID)
        {
            InvestorPaymentReceiptDAL _dataObject = new InvestorPaymentReceiptDAL();
            return _dataObject.SelectAllWithSearchDataSet(InvestorPaymentReceiptID, InvestorID, InvestorName, CompanyID);
        }

        public static DataSet SelectAllWithSearchDataSetForTax(Guid? InvestorPaymentReceiptID, Guid? InvestorID, string InvestorName, Guid? CompanyID, Guid ReceiptTypeTermID, Guid? CreatedBy, string PayYear, string UnitNo, DateTime? dateFrom, DateTime? dateTo)
        {
            InvestorPaymentReceiptDAL _dataObject = new InvestorPaymentReceiptDAL();
            return _dataObject.SelectAllWithSearchDataSetForTax(InvestorPaymentReceiptID, InvestorID, InvestorName, CompanyID, ReceiptTypeTermID, CreatedBy, PayYear, UnitNo, dateFrom, dateTo);
        }


        public static DataSet GetTotalAmount(string AmountQuery)
        {
            InvestorPaymentReceiptDAL _dataObject = new InvestorPaymentReceiptDAL();
            return _dataObject.SelectTotalAmount(AmountQuery);
        }

        public static DataSet GetRptPaymentAlerts(Guid? InvestorID, DateTime? StartDate, DateTime? EndDate, Guid? RoomID, Guid? PropertyID, Guid? RelationShipManagerID)
        {
            InvestorPaymentReceiptDAL _dataObject = new InvestorPaymentReceiptDAL();
            return _dataObject.rptPaymentAlerts(InvestorID, StartDate, EndDate, RoomID, PropertyID, RelationShipManagerID);
        }

        public static DataSet GetRptPaymentReceipt(Guid? InvestorID, DateTime? StartDate, DateTime? EndDate, Guid? RoomID, Guid? PropertyID, Guid? RelationShipManagerID)
        {
            InvestorPaymentReceiptDAL _dataObject = new InvestorPaymentReceiptDAL();
            return _dataObject.rptPaymentReceipt(InvestorID, StartDate, EndDate, RoomID, PropertyID, RelationShipManagerID);
        }
        public static DataSet PrintTaxAndInsuranceReceipt(Guid? InvestorID, string PropertyName, string UnitNo)
        {
            InvestorPaymentReceiptDAL _Obj = new InvestorPaymentReceiptDAL();
            return _Obj.GetReceiptForTaxAndInsurance(InvestorID, PropertyName, UnitNo);
        }

        public static DataSet SelectInvestorPropertyName(Guid? InvestorRoomID)
        {
            InvestorPaymentReceiptDAL _Obj = new InvestorPaymentReceiptDAL();
            return _Obj.SelectInvestorPropertyName(InvestorRoomID);
        }

        public static DataSet GetTaxAndInsuranceData(Guid? InvestorID, string PropertyName, string UnitNo, DateTime? FromDate, DateTime? ToDate)
        {
            InvestorPaymentReceiptDAL _Obj = new InvestorPaymentReceiptDAL();
            return _Obj.SelectTaxAndInsuranceData(InvestorID, PropertyName, UnitNo, FromDate, ToDate);
        }

        public static DataSet SelectPaymentReceiptData(Guid? InvestorRoomID, Guid? InvestorID, Guid? CompanyID, Guid? PaymentScheduleID)
        {
            InvestorPaymentReceiptDAL _Obj = new InvestorPaymentReceiptDAL();
            return _Obj.SelectPaymentReceiptData(InvestorRoomID, InvestorID, CompanyID, PaymentScheduleID);
        }

        public static DataSet SearchPaymentReceiptData(Guid? InvestorID, string InvestorName, Guid? CompanyID, Guid? ReceiptType_TermID, Guid? CreatedBy, Guid? PropertyID)
        {
            InvestorPaymentReceiptDAL _Obj = new InvestorPaymentReceiptDAL();
            return _Obj.SearchPaymentReceiptData(InvestorID, InvestorName, CompanyID, ReceiptType_TermID, CreatedBy, PropertyID);
        }

        public static DataSet SelectPaymentReceipt(Guid? InvestorID,Guid? PropertyID)
        {
            InvestorPaymentReceiptDAL _Obj = new InvestorPaymentReceiptDAL();
            return _Obj.SelectPaymentReceipt(InvestorID, PropertyID);
        }

        #endregion

    }
}
