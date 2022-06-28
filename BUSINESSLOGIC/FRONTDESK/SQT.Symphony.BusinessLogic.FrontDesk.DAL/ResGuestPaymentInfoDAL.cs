using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using SQT.FRAMEWORK.DAL.Linq;
using SQT.FRAMEWORK.DAL.Linq.DAL;
using SQT.FRAMEWORK.DAL.Linq.Exceptions;
using SQT.FRAMEWORK.DAL.Linq.Results;
using SQT.FRAMEWORK.COMMON.Util;
using SQT.FRAMEWORK.LOGGER;
using SQT.FRAMEWORK.EXCEPTION;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.COMMON;

namespace SQT.Symphony.BusinessLogic.FrontDesk.DAL
{
	/// <summary>
	/// Data access layer class for ResGuestPaymentInfo
	/// </summary>
	public class ResGuestPaymentInfoDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public ResGuestPaymentInfoDAL() :  base()
		{
			// Nothing for now.
		}
        public ResGuestPaymentInfoDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<ResGuestPaymentInfo> SelectAll(ResGuestPaymentInfo dtoObject)
        {
            List<ResGuestPaymentInfo> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    if(dtoObject != null)
                        parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                    if(dtoObject != null)  
                    {
                        obj = StoredProcedure(MasterDALConstant.ResGuestPaymentInfoSelectAll)
                                                .AddParameter("@ResPayID", dtoObject.ResPayID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@CardName", dtoObject.CardName)
.AddParameter("@CardNo", dtoObject.CardNo)
.AddParameter("@CardHolderName", dtoObject.CardHolderName)
.AddParameter("@DateOfExpiry", dtoObject.DateOfExpiry)
.AddParameter("@LastUsage", dtoObject.LastUsage)
.AddParameter("@LastUsageAmt", dtoObject.LastUsageAmt)
.AddParameter("@BankName", dtoObject.BankName)
.AddParameter("@CardType_TermID", dtoObject.CardType_TermID)
.AddParameter("@ChequeNo", dtoObject.ChequeNo)
.AddParameter("@RefNo", dtoObject.RefNo)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CVVNo", dtoObject.CVVNo)
.AddParameter("@IsCreditCardCharged", dtoObject.IsCreditCardCharged)
                                                .WithTransaction(dbtr)
                                                .FetchAll<ResGuestPaymentInfo>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ResGuestPaymentInfoSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<ResGuestPaymentInfo>();
                    }
                }
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public List<ResGuestPaymentInfo> SelectAll()
        {
            List<ResGuestPaymentInfo> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.ResGuestPaymentInfoSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<ResGuestPaymentInfo>();
                }
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }
        public DataSet SelectAllWithDataSet(ResGuestPaymentInfo dtoObject)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    if(dtoObject != null)
                        parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                    if(dtoObject != null)  
                    {
                        obj = StoredProcedure(MasterDALConstant.ResGuestPaymentInfoSelectAll)
                                                .AddParameter("@ResPayID", dtoObject.ResPayID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@CardName", dtoObject.CardName)
.AddParameter("@CardNo", dtoObject.CardNo)
.AddParameter("@CardHolderName", dtoObject.CardHolderName)
.AddParameter("@DateOfExpiry", dtoObject.DateOfExpiry)
.AddParameter("@LastUsage", dtoObject.LastUsage)
.AddParameter("@LastUsageAmt", dtoObject.LastUsageAmt)
.AddParameter("@BankName", dtoObject.BankName)
.AddParameter("@CardType_TermID", dtoObject.CardType_TermID)
.AddParameter("@ChequeNo", dtoObject.ChequeNo)
.AddParameter("@RefNo", dtoObject.RefNo)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CVVNo", dtoObject.CVVNo)
.AddParameter("@IsCreditCardCharged", dtoObject.IsCreditCardCharged)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ResGuestPaymentInfoSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                }
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public DataSet SelectAllWithDataSet()
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.ResGuestPaymentInfoSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchDataSet();
                }
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }
        /// <summary>
        /// insert new row in the table
        /// </summary>
		/// <param name="businessObject">business object</param>
		/// <returns>true of successfully insert</returns>
		public bool Insert(ResGuestPaymentInfo dtoObject)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    if (dtoObject == null)
                        throw (new ParameterNullException("Object can not be null"));

                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.ResGuestPaymentInfoInsert)
                        .AddParameter("@ResPayID", dtoObject.ResPayID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@CardName", dtoObject.CardName)
.AddParameter("@CardNo", dtoObject.CardNo)
.AddParameter("@CardHolderName", dtoObject.CardHolderName)
.AddParameter("@DateOfExpiry", dtoObject.DateOfExpiry)
.AddParameter("@LastUsage", dtoObject.LastUsage)
.AddParameter("@LastUsageAmt", dtoObject.LastUsageAmt)
.AddParameter("@BankName", dtoObject.BankName)
.AddParameter("@CardType_TermID", dtoObject.CardType_TermID)
.AddParameter("@ChequeNo", dtoObject.ChequeNo)
.AddParameter("@RefNo", dtoObject.RefNo)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CVVNo", dtoObject.CVVNo)
.AddParameter("@IsCreditCardCharged", dtoObject.IsCreditCardCharged)

                        .WithTransaction(dbtr)
                        .Execute();
                }
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return true;
        }

         /// <summary>
        /// update row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true for successfully updated</returns>
        public bool Update(ResGuestPaymentInfo dtoObject)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    if (dtoObject == null)
                        throw (new ParameterNullException("Object can not be null"));

                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.ResGuestPaymentInfoUpdate)
                        .AddParameter("@ResPayID", dtoObject.ResPayID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@MOP_TermID", dtoObject.MOP_TermID)
.AddParameter("@CardName", dtoObject.CardName)
.AddParameter("@CardNo", dtoObject.CardNo)
.AddParameter("@CardHolderName", dtoObject.CardHolderName)
.AddParameter("@DateOfExpiry", dtoObject.DateOfExpiry)
.AddParameter("@LastUsage", dtoObject.LastUsage)
.AddParameter("@LastUsageAmt", dtoObject.LastUsageAmt)
.AddParameter("@BankName", dtoObject.BankName)
.AddParameter("@CardType_TermID", dtoObject.CardType_TermID)
.AddParameter("@ChequeNo", dtoObject.ChequeNo)
.AddParameter("@RefNo", dtoObject.RefNo)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CVVNo", dtoObject.CVVNo)
.AddParameter("@IsCreditCardCharged", dtoObject.IsCreditCardCharged)

                        .WithTransaction(dbtr)
                        .Execute();
                }
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return true;
        }
        public bool Delete(Guid Keys)
        {
            try
            {
                StoredProcedure(MasterDALConstant.ResGuestPaymentInfoDeleteByPrimaryKey)
                    .AddParameter("@ResPayID"
,Keys)
                    .WithTransaction(dbtr)
                    .Execute();
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return true;
        }
        public bool Delete(ResGuestPaymentInfo dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.ResGuestPaymentInfoDeleteByPrimaryKey)
                    .AddParameter("@ResPayID", dtoObject.ResPayID)

                    .WithTransaction(dbtr)
                    .Execute();
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return true;
        }

        public ResGuestPaymentInfo SelectByPrimaryKey(Guid Keys)
        {
            ResGuestPaymentInfo obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ResGuestPaymentInfoSelectByPrimaryKey)
                            .AddParameter("@ResPayID"
,Keys)
                            .Fetch<ResGuestPaymentInfo>();
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }
        public List<ResGuestPaymentInfo> SelectByField(string fieldName, object value)
        {
            List<ResGuestPaymentInfo> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ResGuestPaymentInfoSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<ResGuestPaymentInfo>();

            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }
        public DataSet SelectByFieldWithDataSet(string fieldName, object value)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ResGuestPaymentInfoSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchDataSet();

            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public bool DeleteByField(string fieldName, object value)
        {
            try
            {
                StoredProcedure(MasterDALConstant.ResGuestPaymentInfoDeleteByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .WithTransaction(dbtr)
                                    .Execute();
            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return true;
        }

        public DataSet SelectCreditCardListData(Guid? GuestID, Guid? PropertyID, Guid? CompanyID, string Category)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ResGuestPaymentSelectCreditCardList)
                                    .AddParameter("@GuestID", GuestID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@Category", Category)
                                    .FetchDataSet();

            }
            catch (Exception ex)
            {
                //Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        #endregion
	}
}
