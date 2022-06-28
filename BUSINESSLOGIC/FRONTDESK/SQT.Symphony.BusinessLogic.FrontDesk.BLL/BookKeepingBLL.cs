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
    public static class BookKeepingBLL
    {

        //#region data Members

        //private static BookKeepingDAL _dataObject = null;

        //#endregion

        #region Constructor

        static BookKeepingBLL()
        {
            //_dataObject = new BookKeepingDAL();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Insert new BookKeeping
        /// </summary>
        /// <param name="businessObject">BookKeeping object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Save(BookKeeping businessObject)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            try
            {
                if(businessObject != null)
                {
                    using (new Tracer((SQTLogType.BusinessLayerTraceLog)))
                    {
                        businessObject.BookID = Guid.NewGuid();
                    
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
        /// Update existing BookKeeping
        /// </summary>
        /// <param name="businessObject">BookKeeping object</param>
        /// <returns>true for successfully saved</returns>
        public static bool Update(BookKeeping businessObject)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
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

        /// <summary>
        /// get BookKeeping by primary key.
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>Student</returns>
        public static BookKeeping GetByPrimaryKey(Guid keys)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectByPrimaryKey(keys); 
        }

        /// <summary>
        /// get list of all BookKeepings
        /// </summary>
        /// <returns>list</returns>
        public static List<BookKeeping> GetAll(BookKeeping obj)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectAll(obj); 
        }
        /// <summary>
        /// get list of all BookKeepings
        /// </summary>
        /// <returns>list</returns>
        public static List<BookKeeping> GetAll()
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectAll(); 
        }

        public static List<BookKeeping> GetDistinctGeneralType()
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectDistinctGeneralType();
        }
        /// <summary>
        /// get list of BookKeeping by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static List<BookKeeping> GetAllBy(BookKeeping.BookKeepingFields fieldName, object value)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectByField(fieldName.ToString(), value);  
        }

        /// <summary>
        /// get list of all BookKeepings
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet(BookKeeping obj)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectAllWithDataSet(obj); 
        }
        /// <summary>
        /// get list of all BookKeepings
        /// </summary>
        /// <returns>list</returns>
        public static DataSet GetAllWithDataSet()
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectAllWithDataSet(); 
        }
        /// <summary>
        /// get list of BookKeeping by field
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>list</returns>
        public static DataSet GetAllByWithDataSet(BookKeeping.BookKeepingFields fieldName, object value)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectByFieldWithDataSet(fieldName.ToString(), value);  
        }

        public static DataSet GetRPTCollectionSummary(Guid? CompanyID, Guid? PropertyID, Guid? FolioID, Guid? CounterID, Guid? PaymentMode, string GeneralIDType_Term, DateTime? StartDate, DateTime? EndDate)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectRPTCollectionSummary(CompanyID, PropertyID, FolioID, CounterID, PaymentMode, GeneralIDType_Term, StartDate, EndDate);
        }

        public static DataSet GetRPTCollectionSummary_OnlySummary(Guid? CompanyID, Guid? PropertyID, Guid? FolioID, Guid? CounterID, Guid? PaymentMode, string GeneralIDType_Term, DateTime? StartDate, DateTime? EndDate)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectRPTCollectionSummaryOnlySummary(CompanyID, PropertyID, FolioID, CounterID, PaymentMode, GeneralIDType_Term, StartDate, EndDate);
        }

        public static DataSet GetRPTRoomDeposit(Guid? CompanyID, Guid? PropertyID, Guid? CounterID, Guid? UserID, DateTime? StartDate, DateTime? EndDate)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectRPTRoomDeposit(CompanyID, PropertyID, CounterID, UserID, StartDate, EndDate);
        }

        public static DataSet GetRPTRoomRentAdvance(Guid? CompanyID, Guid? PropertyID, Guid? CounterID, Guid? UserID, Guid? AcctID, DateTime? StartDate, DateTime? EndDate)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectRPTRoomRentAdvance(CompanyID, PropertyID, CounterID, UserID, AcctID, StartDate, EndDate);
        }

        public static DataSet GetRPTRoomRentAdvance_4Summary(Guid? CompanyID, Guid? PropertyID, Guid? CounterID, Guid? UserID, Guid? AcctID, DateTime? StartDate, DateTime? EndDate)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectRPTRoomRentAdvance_4Summary(CompanyID, PropertyID, CounterID, UserID, AcctID, StartDate, EndDate);
        }

        public static DataSet GetRPTRoomRentAdvance_ClosingBal(Guid? CompanyID, Guid? PropertyID, Guid? CounterID, Guid? UserID, Guid? AcctID, DateTime? StartDate, DateTime? EndDate)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectRPTRoomRentAdvance_ClosingBal(CompanyID, PropertyID, CounterID, UserID, AcctID, StartDate, EndDate);
        }

        public static DataSet GetRPTRevenueDetail(Guid? ReservationID, Guid? FolioID, Guid? CounterID, string GeneralIDType_Term, DateTime? StartDate, DateTime? EndDate)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectRPTRevenueDetail(ReservationID, FolioID, CounterID, GeneralIDType_Term, StartDate, EndDate);
        }

        public static DataSet GetRPTCashReport(Guid? CompanyID, Guid? PropertyID, Guid? FolioID, Guid? CounterID, Guid? UserID, DateTime? StartDate, DateTime? EndDate)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectRPTCashReport(CompanyID, PropertyID, FolioID, CounterID, UserID, StartDate, EndDate);
        }

        public static DataSet GetRPTCancellationCharges(Guid? CompanyID, Guid? PropertyID, Guid? GuestName, DateTime? StartDate, DateTime? EndDate)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectRPTCancellationCharges(CompanyID, PropertyID, GuestName, StartDate, EndDate);
        }

        public static DataSet GetRPTRetentionCharges(Guid? CompanyID, Guid? PropertyID, Guid? GuestName, DateTime? StartDate, DateTime? EndDate)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectRPTRetentionCharges(CompanyID, PropertyID, GuestName, StartDate, EndDate);
        }

        /// <summary>
        /// delete by primary key
        /// </summary>
        /// <param name="keys">primary key</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(Guid keys)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.Delete(keys); 
        }
        /// <summary>
        /// delete by object
        /// </summary>
        /// <param name="keys">object</param>
        /// <returns>true for succesfully deleted</returns>
        public static bool Delete(BookKeeping obj)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.Delete(obj); 
        }
        /// <summary>
        /// delete BookKeeping by field.
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <param name="value">value</param>
        /// <returns>true for successfully deleted</returns>
        public static bool Delete(BookKeeping.BookKeepingFields fieldName, object value)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.DeleteByField(fieldName.ToString(), value); 
        }

        public static Guid ReceivePayment(Guid? MOPAcctID, decimal Amt, Guid? ReservationID, Guid? FolioID, Guid? UserID, Guid? CounterID, Guid? PropertyID, Guid? CompanyID, string EntryOrigin, Guid? ResPayID, bool IsForAgent)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.ReceivePayment(MOPAcctID, Amt, ReservationID, FolioID, UserID, CounterID, PropertyID, CompanyID, EntryOrigin, ResPayID, IsForAgent);
        }

        public static DataSet GetPaymentForCheckInVoucher(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID, string strBookKeepingID)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectPaymentForCheckInVoucher(ReservationID, PropertyID, CompanyID, strBookKeepingID);
        }
        public static DataSet GetPaymentForCheckInVoucherForReprint(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID, string strBookKeepingID)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectPaymentForCheckInVoucherForReprint(ReservationID, PropertyID, CompanyID, strBookKeepingID);
        }
        public static bool VoidTransaction(Guid? BkpID, string VoidReas, Guid? VoidByUserID)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.VoidTransaction(BkpID, VoidReas, VoidByUserID);
        }

        public static bool TransactionDiscount(Guid? BkpID, decimal? DiscountPercentage, Guid? DiscountByUserID, Guid? DiscountCounterID, string DiscountNarration)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.TransactionDiscount(BkpID, DiscountPercentage, DiscountByUserID, DiscountCounterID, DiscountNarration);
        }

        public static DataSet GetAllFolioDiscount(Guid? ReservationID, Guid? FolioID)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectAllFolioDiscount(ReservationID, FolioID);
        }

        public static bool TransactionOverride(Guid? BkpID, decimal? Amount, Guid? OverridCounterID, string OverrideReason, Guid? OverrideByUserID)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.TransactionOverride(BkpID, Amount, OverridCounterID, OverrideReason, OverrideByUserID);
        }

        public static DataSet GetAllFolioAllOverridesTransaction(Guid? ReservationID, Guid? FolioID)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectAllFolioAllOverridesTransaction(ReservationID, FolioID);
        }

        public static DataSet GetRPTCompanyPosting(Guid? CompanyID, Guid? PropertyID, Guid? AgentID, DateTime? StartDate, DateTime? EndDate)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectRPTCompanyPosting(CompanyID, PropertyID, AgentID, StartDate, EndDate);
        }

        public static DataSet GetVoidReport(Guid? CompanyID, Guid? PropertyID, DateTime? StartDate, DateTime? EndDate, string GuestName)
        {
            BookKeepingDAL _dataObject = new BookKeepingDAL();
            return _dataObject.SelectVoidReport(CompanyID, PropertyID, StartDate, EndDate, GuestName);
        }

        #endregion

    }
}
