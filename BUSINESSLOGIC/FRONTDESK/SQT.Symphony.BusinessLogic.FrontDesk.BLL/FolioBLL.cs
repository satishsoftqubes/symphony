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
    public static class FolioBLL
    {
        //#region data Members

        //private static FolioDAL _dataObject = null;

        //#endregion

        #region Constructor

        static FolioBLL()
        {
            //_dataObject = new FolioDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new Folio
        /// </summary>
        /// <param name="businessObject">Folio object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(Folio businessObject)
        {
            FolioDAL _dataObject = new FolioDAL();
            try
            {
                if (businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.FolioID = Guid.NewGuid();

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
        /// Update existing Folio
        /// </summary>
        /// <param name="businessObject">Folio object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(Folio businessObject)
        {
            FolioDAL _dataObject = new FolioDAL();
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
        /// get Folio by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static Folio GetByPrimaryKey(Guid keys)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.SelectByPrimaryKey(keys);
        }

        /// <summary>
        /// get list of all Folios
        /// </summary>
        /// <returns>list</returns>
        public static List<Folio> GetAll(Folio obj)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.SelectAll(obj);
        }
        /// <summary>
        /// get list of all Folios
        /// </summary>
        /// <returns>list</returns>
        public static List<Folio> GetAll()
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.SelectAll();
        }
        /// <summary>
        /// get list of Folio by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<Folio> GetAllBy(Folio.FolioFields fieldName, object value)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);
        }

        /// <summary>
        /// get list of all Folios
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(Folio obj)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.SelectAllWithDataSet(obj);
        }
        /// <summary>
        /// get list of all Folios
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.SelectAllWithDataSet();
        }
        /// <summary>
        /// get list of Folio by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(Folio.FolioFields fieldName, object value)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.Delete(keys);
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Folio obj)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.Delete(obj);
        }
        /// <summary>
        /// delete Folio by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(Folio.FolioFields fieldName, object value)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value);
        }


        public static DataSet GetFolioBalance(Guid? ReservationID, Guid? FolioID, bool? IsMainFolio, Guid? CompanyID, Guid? PropertyID)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.SelectFolioBalance(ReservationID, FolioID, IsMainFolio, CompanyID, PropertyID);
        }

        public static DataSet GetAllFolio(int? Type, bool? IsWithSubFolio, Guid? CompanyID, Guid? PropertyID, string CompanyName, Guid? RoomTypeID, string GuestFullName, string RoomNo, string FolioNo)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.SelectAllFolio(Type, IsWithSubFolio, CompanyID, PropertyID, CompanyName, RoomTypeID, GuestFullName, RoomNo, FolioNo);
        }

        public static DataSet GetAllFolioBalance(bool? IsForOutstanding, DateTime? CheckInDate, DateTime? CheckoutDate, Guid? FolioID, string FolioNo, Guid? GuestID, Guid? AgentID, Guid? ReservationID, Guid? CompanyID, Guid? PropertyID)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.SelectAllFolioBalance(IsForOutstanding, CheckInDate, CheckoutDate, FolioID, FolioNo, GuestID, AgentID, ReservationID, CompanyID, PropertyID);
        }

        public static DataSet GetAllFolios(Guid? FolioID, string FolioNo, Guid? GuestID, Guid? AgentID, Guid? ReservationID, Guid? CompanyID, Guid? PropertyID)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.SelectAllFolios(FolioID, FolioNo, GuestID, AgentID, ReservationID, CompanyID, PropertyID);
        }

        public static DataSet GetCheckOutTimeSummary(Guid? ReservationID, Guid? FolioID, Guid? CompanyID, Guid? PropertyID)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.GetCheckOutTimeSummary(ReservationID, FolioID, CompanyID, PropertyID);
        }

        public static bool FolioQuickPostInAccount(Guid? ChargeAcctID, Guid? PaymentAcctID, decimal? Amount, int? Transaction_Origin, Guid? ResID, Guid? FolioID, Guid? CounterID, Guid? PropertyID, Guid? UserID, Guid? ResPayID, string RefNo, decimal? BaseRate, Guid? CompanyID)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.FolioQuickPostInAccount(ChargeAcctID, PaymentAcctID, Amount, Transaction_Origin, ResID, FolioID, CounterID, PropertyID, UserID, ResPayID, RefNo, BaseRate, CompanyID);
        }
        public static Guid FolioQuickPostInAccountNew(Guid? ChargeAcctID, Guid? PaymentAcctID, decimal? Amount, int? Transaction_Origin, Guid? ResID, Guid? FolioID, Guid? CounterID, Guid? PropertyID, Guid? UserID, Guid? ResPayID, string RefNo, decimal? BaseRate, Guid? CompanyID)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.FolioQuickPostInAccountNew(ChargeAcctID, PaymentAcctID, Amount, Transaction_Origin, ResID, FolioID, CounterID, PropertyID, UserID, ResPayID, RefNo, BaseRate, CompanyID);
        }
        public static bool FolioTransferTransactionData(Guid? Source_ResID, Guid? SourceFolioID, Guid? Dest_ResID, Guid? DestnationFolioID, Guid? BookID, bool? IsGrpCheckOut, Guid? TransferByUserID)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.FolioTransferTransactionData(Source_ResID, SourceFolioID, Dest_ResID, DestnationFolioID, BookID, IsGrpCheckOut, TransferByUserID);
        }
        public static DataSet GetAllRecoveryTransaction(Guid? ReservationID, Guid? FolioID, DateTime? StartDate, DateTime? EndDate, Guid? PropertyID, Guid? CompanyID)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.SelectAllRecoveryTransaction(ReservationID, FolioID, StartDate, EndDate, PropertyID, CompanyID);
        }

        public static DataSet GetRptFolioStatement(Guid? ReservationID, Guid? FolioID, DateTime? StartDate, DateTime? EndDate, bool IsTaxRequired)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.SelectRptFolioStatement(ReservationID, FolioID, StartDate, EndDate, IsTaxRequired);
        }

        public static DataSet GetFolioSplitBilling(Guid? PropertyID, Guid? CompanyID, Guid? FolioID, Guid? ReservationID)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.SelectFolioSplitBilling(PropertyID, CompanyID, FolioID, ReservationID);
        }

        public static DataSet GetPastFolioList(string FolioNo, string ReservatioNo, string GuestName, DateTime? StartDate, DateTime? EndDate, Guid? CompanyID, Guid? PropertyID)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.SelectPastFolioList(FolioNo, ReservatioNo, GuestName, StartDate, EndDate, CompanyID, PropertyID);
        }

        public static Guid FolioPostCreditInAccount(Guid? ExpenseAcctID, decimal? Amount, int? Transaction_Origin, Guid? ResID, Guid? FolioID, Guid? CounterID, Guid? PropertyID, Guid? UserID, string Notes, Guid? CompanyID)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.FolioPostCreditInAccount(ExpenseAcctID,  Amount,  Transaction_Origin,  ResID, FolioID, CounterID,  PropertyID,  UserID,  Notes, CompanyID);
        }

        public static DataSet SelectAllCheckOutOpenFolios(string FolioNo, string RoomNo, string GuestName, Guid? CompanyID, Guid? PropertyID)
        {
            FolioDAL _dataObject = new FolioDAL();
            return _dataObject.SelectAllCheckOutOpenFolios(FolioNo, RoomNo, GuestName, CompanyID, PropertyID);
        }

        #endregion

    }
}
