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
	/// Data access layer class for Reservation_LaundryDetail
	/// </summary>
	public class Reservation_LaundryDetailDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public Reservation_LaundryDetailDAL() :  base()
		{
			// Nothing for now.
		}
        public Reservation_LaundryDetailDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Reservation_LaundryDetail> SelectAll(Reservation_LaundryDetail dtoObject)
        {
            List<Reservation_LaundryDetail> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.Reservation_LaundryDetailSelectAll)
                                                .AddParameter("@LaundryDetailID", dtoObject.LaundryDetailID)
.AddParameter("@GuestLaundryID", dtoObject.GuestLaundryID)
.AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@TakenQty", dtoObject.TakenQty)
.AddParameter("@Price", dtoObject.Price)
.AddParameter("@ReceivedQty", dtoObject.ReceivedQty)
.AddParameter("@LaundryItemTypeID", dtoObject.LaundryItemTypeID)
.AddParameter("@LaundryServiceID", dtoObject.LaundryServiceID)
.AddParameter("@HotelServiceID", dtoObject.HotelServiceID)
.AddParameter("@Fabric_TermID", dtoObject.Fabric_TermID)
.AddParameter("@Pattern_TermID", dtoObject.Pattern_TermID)
.AddParameter("@Colour_TermID", dtoObject.Colour_TermID)
.AddParameter("@ReturnIn_TermID", dtoObject.ReturnIn_TermID)
.AddParameter("@IsReceived", dtoObject.IsReceived)
.AddParameter("@IsPosted", dtoObject.IsPosted)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@DateOfTaken", dtoObject.DateOfTaken)
.AddParameter("@DateOfReceived", dtoObject.DateOfReceived)
.AddParameter("@LaundryRateID", dtoObject.LaundryRateID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Reservation_LaundryDetail>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.Reservation_LaundryDetailSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Reservation_LaundryDetail>();
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

        public List<Reservation_LaundryDetail> SelectAll()
        {
            List<Reservation_LaundryDetail> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.Reservation_LaundryDetailSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Reservation_LaundryDetail>();
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
        public DataSet SelectAllWithDataSet(Reservation_LaundryDetail dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.Reservation_LaundryDetailSelectAll)
                                                .AddParameter("@LaundryDetailID", dtoObject.LaundryDetailID)
.AddParameter("@GuestLaundryID", dtoObject.GuestLaundryID)
.AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@TakenQty", dtoObject.TakenQty)
.AddParameter("@Price", dtoObject.Price)
.AddParameter("@ReceivedQty", dtoObject.ReceivedQty)
.AddParameter("@LaundryItemTypeID", dtoObject.LaundryItemTypeID)
.AddParameter("@LaundryServiceID", dtoObject.LaundryServiceID)
.AddParameter("@HotelServiceID", dtoObject.HotelServiceID)
.AddParameter("@Fabric_TermID", dtoObject.Fabric_TermID)
.AddParameter("@Pattern_TermID", dtoObject.Pattern_TermID)
.AddParameter("@Colour_TermID", dtoObject.Colour_TermID)
.AddParameter("@ReturnIn_TermID", dtoObject.ReturnIn_TermID)
.AddParameter("@IsReceived", dtoObject.IsReceived)
.AddParameter("@IsPosted", dtoObject.IsPosted)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@DateOfTaken", dtoObject.DateOfTaken)
.AddParameter("@DateOfReceived", dtoObject.DateOfReceived)
.AddParameter("@LaundryRateID", dtoObject.LaundryRateID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.Reservation_LaundryDetailSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.Reservation_LaundryDetailSelectAll)
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
		public bool Insert(Reservation_LaundryDetail dtoObject)
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

                    StoredProcedure(MasterDALConstant.Reservation_LaundryDetailInsert)
                        .AddParameter("@LaundryDetailID", dtoObject.LaundryDetailID)
.AddParameter("@GuestLaundryID", dtoObject.GuestLaundryID)
.AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@TakenQty", dtoObject.TakenQty)
.AddParameter("@Price", dtoObject.Price)
.AddParameter("@ReceivedQty", dtoObject.ReceivedQty)
.AddParameter("@LaundryItemTypeID", dtoObject.LaundryItemTypeID)
.AddParameter("@LaundryServiceID", dtoObject.LaundryServiceID)
.AddParameter("@HotelServiceID", dtoObject.HotelServiceID)
.AddParameter("@Fabric_TermID", dtoObject.Fabric_TermID)
.AddParameter("@Pattern_TermID", dtoObject.Pattern_TermID)
.AddParameter("@Colour_TermID", dtoObject.Colour_TermID)
.AddParameter("@ReturnIn_TermID", dtoObject.ReturnIn_TermID)
.AddParameter("@IsReceived", dtoObject.IsReceived)
.AddParameter("@IsPosted", dtoObject.IsPosted)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@DateOfTaken", dtoObject.DateOfTaken)
.AddParameter("@DateOfReceived", dtoObject.DateOfReceived)
.AddParameter("@LaundryRateID", dtoObject.LaundryRateID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)

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
        public bool Update(Reservation_LaundryDetail dtoObject)
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

                    StoredProcedure(MasterDALConstant.Reservation_LaundryDetailUpdate)
                        .AddParameter("@LaundryDetailID", dtoObject.LaundryDetailID)
.AddParameter("@GuestLaundryID", dtoObject.GuestLaundryID)
.AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@TakenQty", dtoObject.TakenQty)
.AddParameter("@Price", dtoObject.Price)
.AddParameter("@ReceivedQty", dtoObject.ReceivedQty)
.AddParameter("@LaundryItemTypeID", dtoObject.LaundryItemTypeID)
.AddParameter("@LaundryServiceID", dtoObject.LaundryServiceID)
.AddParameter("@HotelServiceID", dtoObject.HotelServiceID)
.AddParameter("@Fabric_TermID", dtoObject.Fabric_TermID)
.AddParameter("@Pattern_TermID", dtoObject.Pattern_TermID)
.AddParameter("@Colour_TermID", dtoObject.Colour_TermID)
.AddParameter("@ReturnIn_TermID", dtoObject.ReturnIn_TermID)
.AddParameter("@IsReceived", dtoObject.IsReceived)
.AddParameter("@IsPosted", dtoObject.IsPosted)
.AddParameter("@BookID", dtoObject.BookID)
.AddParameter("@DateOfTaken", dtoObject.DateOfTaken)
.AddParameter("@DateOfReceived", dtoObject.DateOfReceived)
.AddParameter("@LaundryRateID", dtoObject.LaundryRateID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)

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
                StoredProcedure(MasterDALConstant.Reservation_LaundryDetailDeleteByPrimaryKey)
                    .AddParameter("@LaundryDetailID"
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
        public bool Delete(Reservation_LaundryDetail dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.Reservation_LaundryDetailDeleteByPrimaryKey)
                    .AddParameter("@LaundryDetailID", dtoObject.LaundryDetailID)

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

        public Reservation_LaundryDetail SelectByPrimaryKey(Guid Keys)
        {
            Reservation_LaundryDetail obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.Reservation_LaundryDetailSelectByPrimaryKey)
                            .AddParameter("@LaundryDetailID"
,Keys)
                            .Fetch<Reservation_LaundryDetail>();
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
        public List<Reservation_LaundryDetail> SelectByField(string fieldName, object value)
        {
            List<Reservation_LaundryDetail> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.Reservation_LaundryDetailSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Reservation_LaundryDetail>();

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
                obj = StoredProcedure(MasterDALConstant.Reservation_LaundryDetailSelectByField) 
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
                StoredProcedure(MasterDALConstant.Reservation_LaundryDetailDeleteByField) 
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

        #endregion
	}
}
