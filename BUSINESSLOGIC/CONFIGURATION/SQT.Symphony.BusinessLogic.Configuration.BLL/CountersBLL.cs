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
    public static class CountersBLL
    {

        //#region data Members

        //private static CountersDAL _dataObject = null;

        //#endregion

        #region Constructor

        static CountersBLL()
        {
            //_dataObject = new CountersDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Counters
        /// </summary>
        /// <param name="businessObject">Counters object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Counters businessObject)
        {
            CountersDAL _dataObject = new CountersDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.CounterID = Guid.NewGuid();

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
        /// Update existing Counters
        /// </summary>
        /// <param name="businessObject">Counters object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Counters businessObject)
        {
            CountersDAL _dataObject = new CountersDAL();
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
        /// get Counters by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Counters GetByPrimaryKey(Guid keys)
        {
            CountersDAL _dataObject = new CountersDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all Counterss
        /// </summary>
        /// <returns>list</returns>
        public static List<Counters> GetAll(Counters obj)
        {
            CountersDAL _dataObject = new CountersDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all Counterss
        /// </summary>
        /// <returns>list</returns>
        public static List<Counters> GetAll()
        {
            CountersDAL _dataObject = new CountersDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of Counters by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Counters> GetAllBy(Counters.CountersFields fieldName, object value)
        {
            CountersDAL _dataObject = new CountersDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all Counterss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Counters obj)
        {
            CountersDAL _dataObject = new CountersDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all Counterss
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            CountersDAL _dataObject = new CountersDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of Counters by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Counters.CountersFields fieldName, object value)
        {
            CountersDAL _dataObject = new CountersDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            CountersDAL _dataObject = new CountersDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Counters obj)
        {
            CountersDAL _dataObject = new CountersDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete Counters by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Counters.CountersFields fieldName, object value)
        {
            CountersDAL _dataObject = new CountersDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }

        public static DataSet SearchCounterData(Guid? CounterID, Guid? PropertyID, Guid? CompanyID, string strCounterNo)
        {
            CountersDAL _dataObject = new CountersDAL();
            return _dataObject.SearchCounterData(CounterID, PropertyID, CompanyID, strCounterNo);
        }

        public static DataSet GetLogoutCounterList(Guid? PropertyID, Guid? CompanyID)
        {
            CountersDAL _dataObject = new CountersDAL();
            return _dataObject.SelectLogoutCountrList(PropertyID, CompanyID);
        }


        public static DataSet SelectCounterCloseReport(Guid? UserID, Guid? CounterID)
        {
            CountersDAL _dataObject = new CountersDAL();
            return _dataObject.SelectCounterCloseReport(UserID, CounterID);
        }


        public static bool SaveCounterCloseData(Guid? CounterID, Guid? UserID, Guid? LogInfoID, Guid? CounterLoginID, decimal? BeignningAmount, decimal? SuggestedAmount, decimal? AmountDropped, decimal? NewDrawerAmount, bool? isShort, string Reason, decimal? Short_Amount, bool? isClosedAtDayEnd, ref bool returnIsSuccessFull, ref Guid? returncloseid)
        {
            CountersDAL _dataObject = new CountersDAL();
            return _dataObject.SaveCounterCloseData(CounterID, UserID, LogInfoID, CounterLoginID, BeignningAmount, SuggestedAmount, AmountDropped, NewDrawerAmount, isShort, Reason, Short_Amount, isClosedAtDayEnd, ref returnIsSuccessFull, ref returncloseid);
        }

        public static bool CounterAdjustment(Guid? AcctID, string TransType, decimal? Amt, Guid? AdjustmentAcctID, bool? IsShort, Guid? UserID, Guid? CounterID, Guid? PropertyID, string Transaction_Origin, string Notes, Guid? CompanyID)
        {
            CountersDAL _dataObject = new CountersDAL();
            return _dataObject.CounterAdjustment(AcctID, TransType, Amt, AdjustmentAcctID, IsShort, UserID, CounterID, PropertyID, Transaction_Origin, Notes, CompanyID);
        }

        public static DataSet SelectBeginingAmount(Guid? CounterID, Guid? CloseID, bool? ForReport)
        {
            CountersDAL _dataObject = new CountersDAL();
            return _dataObject.SelectBeginingAmount(CounterID, CloseID, ForReport);
        }

        public static DataSet GetCounterCloseDetailRport(Guid? UserID, Guid? CounterID)
        {
            CountersDAL _dataObject = new CountersDAL();
            return _dataObject.SelectCounterCloseDetailRport(UserID, CounterID);
        }

        public static DataSet GetGenerateLedgerReports(Guid? CounterID, Guid? UserID, bool? IsForOpenCounter, Guid? ReservationID, Guid? FolioID, DateTime? EntryDate, Guid? AcctID, bool? IsMissMatchEntries, Guid? AgentID, Guid? ItemID, DateTime? ToDate, Guid? CloseID, Guid? BookID)
        {
            CountersDAL _dataObject = new CountersDAL();
            return _dataObject.SelectGenerateLedgerReports(CounterID, UserID, IsForOpenCounter, ReservationID, FolioID,  EntryDate,  AcctID, IsMissMatchEntries, AgentID,  ItemID, ToDate,  CloseID,  BookID);
        }

        public static DataSet GetCounterCloseSummaryData(int? PreviousCounterClose, Guid? CounterID, Guid? CloseID)
        {
            CountersDAL _dataObject = new CountersDAL();
            return _dataObject.SelectCounterCloseSummaryData(PreviousCounterClose, CounterID,CloseID);
        }

        #endregion

    }
}
