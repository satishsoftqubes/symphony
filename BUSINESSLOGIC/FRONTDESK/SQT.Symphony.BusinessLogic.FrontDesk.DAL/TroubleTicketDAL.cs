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
	/// Data access layer class for TroubleTicket
	/// </summary>
	public class TroubleTicketDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public TroubleTicketDAL() :  base()
		{
			// Nothing for now.
		}
        public TroubleTicketDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<TroubleTicket> SelectAll(TroubleTicket dtoObject)
        {
            List<TroubleTicket> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.TroubleTicketSelectAll)
                                                .AddParameter("@TicketID", dtoObject.TicketID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@TicketType_TermID", dtoObject.TicketType_TermID)
.AddParameter("@Priority_TermID", dtoObject.Priority_TermID)
.AddParameter("@DepartmentID", dtoObject.DepartmentID)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@CloseDate", dtoObject.CloseDate)
.AddParameter("@CloseBy", dtoObject.CloseBy)
.AddParameter("@CloseRemarks", dtoObject.CloseRemarks)
.AddParameter("@TicketRequestBy", dtoObject.TicketRequestBy)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsClosed", dtoObject.IsClosed)
.AddParameter("@CreatedOn",dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)

                                                .WithTransaction(dbtr)
                                                .FetchAll<TroubleTicket>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.TroubleTicketSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<TroubleTicket>();
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

        public List<TroubleTicket> SelectAll()
        {
            List<TroubleTicket> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.TroubleTicketSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<TroubleTicket>();
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
        public DataSet SelectAllWithDataSet(TroubleTicket dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.TroubleTicketSelectAll)
                                                .AddParameter("@TicketID", dtoObject.TicketID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@TicketType_TermID", dtoObject.TicketType_TermID)
.AddParameter("@Priority_TermID", dtoObject.Priority_TermID)
.AddParameter("@DepartmentID", dtoObject.DepartmentID)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@CloseDate", dtoObject.CloseDate)
.AddParameter("@CloseBy", dtoObject.CloseBy)
.AddParameter("@CloseRemarks", dtoObject.CloseRemarks)
.AddParameter("@TicketRequestBy", dtoObject.TicketRequestBy)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsClosed", dtoObject.IsClosed)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.TroubleTicketSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.TroubleTicketSelectAll)
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
		public bool Insert(TroubleTicket dtoObject)
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

                    StoredProcedure(MasterDALConstant.TroubleTicketInsert)
                        .AddParameter("@TicketID", dtoObject.TicketID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@TicketType_TermID", dtoObject.TicketType_TermID)
.AddParameter("@Priority_TermID", dtoObject.Priority_TermID)
.AddParameter("@DepartmentID", dtoObject.DepartmentID)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@CloseDate", dtoObject.CloseDate)
.AddParameter("@CloseBy", dtoObject.CloseBy)
.AddParameter("@CloseRemarks", dtoObject.CloseRemarks)
.AddParameter("@TicketRequestBy", dtoObject.TicketRequestBy)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsClosed", dtoObject.IsClosed)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)

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
        public bool Update(TroubleTicket dtoObject)
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

                    StoredProcedure(MasterDALConstant.TroubleTicketUpdate)
                        .AddParameter("@TicketID", dtoObject.TicketID)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@TicketType_TermID", dtoObject.TicketType_TermID)
.AddParameter("@Priority_TermID", dtoObject.Priority_TermID)
.AddParameter("@DepartmentID", dtoObject.DepartmentID)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@CloseDate", dtoObject.CloseDate)
.AddParameter("@CloseBy", dtoObject.CloseBy)
.AddParameter("@CloseRemarks", dtoObject.CloseRemarks)
.AddParameter("@TicketRequestBy", dtoObject.TicketRequestBy)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsClosed", dtoObject.IsClosed)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)

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
                StoredProcedure(MasterDALConstant.TroubleTicketDeleteByPrimaryKey)
                    .AddParameter("@TicketID"
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
        public bool Delete(TroubleTicket dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.TroubleTicketDeleteByPrimaryKey)
                    .AddParameter("@TicketID", dtoObject.TicketID)

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

        public TroubleTicket SelectByPrimaryKey(Guid Keys)
        {
            TroubleTicket obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.TroubleTicketSelectByPrimaryKey)
                            .AddParameter("@TicketID"
,Keys)
                            .Fetch<TroubleTicket>();
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
        public List<TroubleTicket> SelectByField(string fieldName, object value)
        {
            List<TroubleTicket> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.TroubleTicketSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<TroubleTicket>();

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
                obj = StoredProcedure(MasterDALConstant.TroubleTicketSelectByField) 
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
                StoredProcedure(MasterDALConstant.TroubleTicketDeleteByField) 
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

        public DataSet SelectTroubleTicketList(Guid companyID, Guid propertyID, Guid? Priority, string Title, bool? IsClosed, string GuestName, Guid? Department, string ReservationNo)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.TroubleTicketSelectList)
                                    .AddParameter("@CompanyID", companyID)
                                    .AddParameter("@PropertyID", propertyID)
                                    .AddParameter("@Priority", Priority)
                                    .AddParameter("@Title", Title)
                                    .AddParameter("@IsClose", IsClosed)
                                    .AddParameter("@GuestFullName", GuestName)
                                    .AddParameter("@Department", Department)
                                    .AddParameter("@ReservationNo", ReservationNo)
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
