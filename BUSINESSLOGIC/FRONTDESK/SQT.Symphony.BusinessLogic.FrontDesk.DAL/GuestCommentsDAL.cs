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
    /// Data access layer class for GuestComments
    /// </summary>
    public class GuestCommentsDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public GuestCommentsDAL()
            : base()
        {
            // Nothing for now.
        }
        public GuestCommentsDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<GuestComments> SelectAll(GuestComments dtoObject)
        {
            List<GuestComments> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    if (dtoObject != null)
                        parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                    if (dtoObject != null)
                    {
                        obj = StoredProcedure(MasterDALConstant.GuestCommentsSelectAll)
                                                .AddParameter("@GuestCommentID", dtoObject.GuestCommentID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@Comment", dtoObject.Comment)
.AddParameter("@CommentTermID", dtoObject.CommentTermID)
.AddParameter("@Rate", dtoObject.Rate)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@RoomNo", dtoObject.RoomNo)
.AddParameter("@RoomType", dtoObject.RoomType)
.AddParameter("@ConferenceName", dtoObject.ConferenceName)
.AddParameter("@Nights", dtoObject.Nights)
.AddParameter("@CheckInDate", dtoObject.CheckInDate)
.AddParameter("@CheckOutDate", dtoObject.CheckOutDate)
.AddParameter("@ReservatioNo", dtoObject.ReservatioNo)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@Department", dtoObject.Department)
.AddParameter("@NatureOfComplaint", dtoObject.NatureOfComplaint)
.AddParameter("@CommentsBy", dtoObject.CommentsBy)
                                                .WithTransaction(dbtr)
                                                .FetchAll<GuestComments>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.GuestCommentsSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<GuestComments>();
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

        public List<GuestComments> SelectAll()
        {
            List<GuestComments> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.GuestCommentsSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<GuestComments>();
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
        public DataSet SelectAllWithDataSet(GuestComments dtoObject)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    if (dtoObject != null)
                        parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                    if (dtoObject != null)
                    {
                        obj = StoredProcedure(MasterDALConstant.GuestCommentsSelectAll)
                                                .AddParameter("@GuestCommentID", dtoObject.GuestCommentID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@Comment", dtoObject.Comment)
.AddParameter("@CommentTermID", dtoObject.CommentTermID)
.AddParameter("@Rate", dtoObject.Rate)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@RoomNo", dtoObject.RoomNo)
.AddParameter("@RoomType", dtoObject.RoomType)
.AddParameter("@ConferenceName", dtoObject.ConferenceName)
.AddParameter("@Nights", dtoObject.Nights)
.AddParameter("@CheckInDate", dtoObject.CheckInDate)
.AddParameter("@CheckOutDate", dtoObject.CheckOutDate)
.AddParameter("@ReservatioNo", dtoObject.ReservatioNo)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@Department", dtoObject.Department)
.AddParameter("@NatureOfComplaint", dtoObject.NatureOfComplaint)
.AddParameter("@CommentsBy", dtoObject.CommentsBy)
                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.GuestCommentsSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.GuestCommentsSelectAll)
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
        public bool Insert(GuestComments dtoObject)
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

                    StoredProcedure(MasterDALConstant.GuestCommentsInsert)
                        .AddParameter("@GuestCommentID", dtoObject.GuestCommentID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@Comment", dtoObject.Comment)
.AddParameter("@CommentTermID", dtoObject.CommentTermID)
.AddParameter("@Rate", dtoObject.Rate)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@RoomNo", dtoObject.RoomNo)
.AddParameter("@RoomType", dtoObject.RoomType)
.AddParameter("@ConferenceName", dtoObject.ConferenceName)
.AddParameter("@Nights", dtoObject.Nights)
.AddParameter("@CheckInDate", dtoObject.CheckInDate)
.AddParameter("@CheckOutDate", dtoObject.CheckOutDate)
.AddParameter("@ReservatioNo", dtoObject.ReservatioNo)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@Department", dtoObject.Department)
.AddParameter("@NatureOfComplaint", dtoObject.NatureOfComplaint)
.AddParameter("@CommentsBy", dtoObject.CommentsBy)
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
        public bool Update(GuestComments dtoObject)
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

                    StoredProcedure(MasterDALConstant.GuestCommentsUpdate)
                        .AddParameter("@GuestCommentID", dtoObject.GuestCommentID)
.AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@Comment", dtoObject.Comment)
.AddParameter("@CommentTermID", dtoObject.CommentTermID)
.AddParameter("@Rate", dtoObject.Rate)
.AddParameter("@ReservationID", dtoObject.ReservationID)
.AddParameter("@RoomNo", dtoObject.RoomNo)
.AddParameter("@RoomType", dtoObject.RoomType)
.AddParameter("@ConferenceName", dtoObject.ConferenceName)
.AddParameter("@Nights", dtoObject.Nights)
.AddParameter("@CheckInDate", dtoObject.CheckInDate)
.AddParameter("@CheckOutDate", dtoObject.CheckOutDate)
.AddParameter("@ReservatioNo", dtoObject.ReservatioNo)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@Department", dtoObject.Department)
.AddParameter("@NatureOfComplaint", dtoObject.NatureOfComplaint)
.AddParameter("@CommentsBy", dtoObject.CommentsBy)
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
                StoredProcedure(MasterDALConstant.GuestCommentsDeleteByPrimaryKey)
                    .AddParameter("@GuestCommentID"
, Keys)
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
        public bool Delete(GuestComments dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.GuestCommentsDeleteByPrimaryKey)
                    .AddParameter("@GuestCommentID", dtoObject.GuestCommentID)

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

        public GuestComments SelectByPrimaryKey(Guid Keys)
        {
            GuestComments obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.GuestCommentsSelectByPrimaryKey)
                            .AddParameter("@GuestCommentID"
, Keys)
                            .Fetch<GuestComments>();
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
        public List<GuestComments> SelectByField(string fieldName, object value)
        {
            List<GuestComments> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.GuestCommentsSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<GuestComments>();

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
                obj = StoredProcedure(MasterDALConstant.GuestCommentsSelectByField)
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
                StoredProcedure(MasterDALConstant.GuestCommentsDeleteByField)
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
        public DataSet SelectAllForList(Guid PropertyID, Guid CompanyID, Guid GuestID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.GuestCommentsSelectAllForList)
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

        #endregion
    }
}
