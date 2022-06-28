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
	/// Data access layer class for ReservationGuest
	/// </summary>
	public class ReservationGuestDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public ReservationGuestDAL() :  base()
		{
			// Nothing for now.
		}
        public ReservationGuestDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<ReservationGuest> SelectAll(ReservationGuest dtoObject)
        {
            List<ReservationGuest> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.ReservationGuestSelectAll)
                                                .AddParameter("@ReservationGuestID", dtoObject.ReservationGuestID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@RelationToParentGuest_TermID", dtoObject.RelationToParentGuest_TermID)
.AddParameter("@CheckInDate", dtoObject.CheckInDate)
.AddParameter("@CheckOutDate", dtoObject.CheckOutDate)
.AddParameter("@GuestNotes", dtoObject.GuestNotes)
.AddParameter("@Status_TermID", dtoObject.Status_TermID)
.AddParameter("@IsBilledToCustomer", dtoObject.IsBilledToCustomer)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@Status",dtoObject.Status)

                                                .WithTransaction(dbtr)
                                                .FetchAll<ReservationGuest>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ReservationGuestSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<ReservationGuest>();
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

        public List<ReservationGuest> SelectAll()
        {
            List<ReservationGuest> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.ReservationGuestSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<ReservationGuest>();
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
        public DataSet SelectAllWithDataSet(ReservationGuest dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.ReservationGuestSelectAll)
                                                .AddParameter("@ReservationGuestID", dtoObject.ReservationGuestID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@RelationToParentGuest_TermID", dtoObject.RelationToParentGuest_TermID)
.AddParameter("@CheckInDate", dtoObject.CheckInDate)
.AddParameter("@CheckOutDate", dtoObject.CheckOutDate)
.AddParameter("@GuestNotes", dtoObject.GuestNotes)
.AddParameter("@Status_TermID", dtoObject.Status_TermID)
.AddParameter("@IsBilledToCustomer", dtoObject.IsBilledToCustomer)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@Status",dtoObject.Status)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ReservationGuestSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.ReservationGuestSelectAll)
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
		public bool Insert(ReservationGuest dtoObject)
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

                    StoredProcedure(MasterDALConstant.ReservationGuestInsert)
                        .AddParameter("@ReservationGuestID", dtoObject.ReservationGuestID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@RelationToParentGuest_TermID", dtoObject.RelationToParentGuest_TermID)
.AddParameter("@CheckInDate", dtoObject.CheckInDate)
.AddParameter("@CheckOutDate", dtoObject.CheckOutDate)
.AddParameter("@GuestNotes", dtoObject.GuestNotes)
.AddParameter("@Status_TermID", dtoObject.Status_TermID)
.AddParameter("@IsBilledToCustomer", dtoObject.IsBilledToCustomer)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@Status","Comming") //dtoObject.Status)
.AddParameter("@CheckOutNote", dtoObject.CheckOutNote)

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
        public bool Update(ReservationGuest dtoObject)
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

                    StoredProcedure(MasterDALConstant.ReservationGuestUpdate)
                        .AddParameter("@ReservationGuestID", dtoObject.ReservationGuestID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@RelationToParentGuest_TermID", dtoObject.RelationToParentGuest_TermID)
.AddParameter("@CheckInDate", dtoObject.CheckInDate)
.AddParameter("@CheckOutDate", dtoObject.CheckOutDate)
.AddParameter("@GuestNotes", dtoObject.GuestNotes)
.AddParameter("@Status_TermID", dtoObject.Status_TermID)
.AddParameter("@IsBilledToCustomer", dtoObject.IsBilledToCustomer)
.AddParameter("@FolioID", dtoObject.FolioID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@Status",dtoObject.Status)
.AddParameter("@CheckOutNote", dtoObject.CheckOutNote)
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
                StoredProcedure(MasterDALConstant.ReservationGuestDeleteByPrimaryKey)
                    .AddParameter("@ReservationGuestID"
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
        public bool Delete(ReservationGuest dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.ReservationGuestDeleteByPrimaryKey)
                    .AddParameter("@ReservationGuestID", dtoObject.ReservationGuestID)

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

        public ReservationGuest SelectByPrimaryKey(Guid Keys)
        {
            ReservationGuest obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationGuestSelectByPrimaryKey)
                            .AddParameter("@ReservationGuestID"
,Keys)
                            .Fetch<ReservationGuest>();
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
        public List<ReservationGuest> SelectByField(string fieldName, object value)
        {
            List<ReservationGuest> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationGuestSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<ReservationGuest>();

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
                obj = StoredProcedure(MasterDALConstant.ReservationGuestSelectByField) 
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
                StoredProcedure(MasterDALConstant.ReservationGuestDeleteByField) 
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

        public DataSet SelectAllGuestStayHistory(Guid PropertyID, Guid CompanyID, Guid GuestID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ReservationGuestSelectForGuestStayHistory)
                                     .AddParameter("@PropertyID"
, PropertyID)
 .AddParameter("@CompanyID"
, CompanyID)
.AddParameter("@GuestID"
, GuestID)
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

        public bool Update_CashcardNumber(Guid ReservationID, Guid GuestID, string Cashcard_Number, Guid PropertyID, Guid CompanyID, Guid UpdatedBy)
        {
            try
            {
                StoredProcedure(MasterDALConstant.ReservationGuest_Update_CashcardNumber)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@GuestID", GuestID)
                                    .AddParameter("@Cashcard_Number", Cashcard_Number)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@UpdatedBy", UpdatedBy)
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
