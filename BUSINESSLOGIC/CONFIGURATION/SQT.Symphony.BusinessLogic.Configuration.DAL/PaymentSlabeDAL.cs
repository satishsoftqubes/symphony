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
using SQT.Symphony.BusinessLogic.Configuration.DTO;
using SQT.Symphony.BusinessLogic.Configuration.COMMON;

namespace SQT.Symphony.BusinessLogic.Configuration.DAL
{
    /// <summary>
    /// Data access layer class for PaymentSlabe
    /// </summary>
    public class PaymentSlabeDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public PaymentSlabeDAL()
            : base()
        {
            // Nothing for now.
        }
        public PaymentSlabeDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<PaymentSlabe> SelectAll(PaymentSlabe dtoObject)
        {
            List<PaymentSlabe> obj = null;
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
                        obj = StoredProcedure(MasterConstant.PaymentSlabeSelectAll)
                                                .AddParameter("@PaymentSlabeID", dtoObject.PaymentSlabeID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@SlabNo", dtoObject.SlabNo)
.AddParameter("@SlabTitle", dtoObject.SlabTitle)
.AddParameter("@SlabDescription", dtoObject.SlabDescription)
.AddParameter("@RefPaymentSlabID", dtoObject.RefPaymentSlabID)
.AddParameter("@DateOfCompletion", dtoObject.DateOfCompletion)
.AddParameter("@CompletionProjection", dtoObject.CompletionProjection)
.AddParameter("@Installment", dtoObject.Installment)
.AddParameter("@IsFlat", dtoObject.IsFlat)
.AddParameter("@LastUpdateOn", dtoObject.LastUpdateOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@WingID", dtoObject.WingID)

                                                .WithTransaction(dbtr)
                                                .FetchAll<PaymentSlabe>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.PaymentSlabeSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<PaymentSlabe>();
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

        public List<PaymentSlabe> SelectAll()
        {
            List<PaymentSlabe> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.PaymentSlabeSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<PaymentSlabe>();
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
        public DataSet SelectAllWithDataSet(PaymentSlabe dtoObject)
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
                        obj = StoredProcedure(MasterConstant.PaymentSlabeSelectAll)
                                                .AddParameter("@PaymentSlabeID", dtoObject.PaymentSlabeID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@SlabNo", dtoObject.SlabNo)
.AddParameter("@SlabTitle", dtoObject.SlabTitle)
.AddParameter("@SlabDescription", dtoObject.SlabDescription)
.AddParameter("@RefPaymentSlabID", dtoObject.RefPaymentSlabID)
.AddParameter("@DateOfCompletion", dtoObject.DateOfCompletion)
.AddParameter("@CompletionProjection", dtoObject.CompletionProjection)
.AddParameter("@Installment", dtoObject.Installment)
.AddParameter("@IsFlat", dtoObject.IsFlat)
.AddParameter("@LastUpdateOn", dtoObject.LastUpdateOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@WingID", dtoObject.WingID)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.PaymentSlabeSelectAll)
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

                    obj = StoredProcedure(MasterConstant.PaymentSlabeSelectAll)
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
        public bool Insert(PaymentSlabe dtoObject)
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

                    StoredProcedure(MasterConstant.PaymentSlabeInsert)
                        .AddParameter("@PaymentSlabeID", dtoObject.PaymentSlabeID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@SlabNo", dtoObject.SlabNo)
.AddParameter("@SlabTitle", dtoObject.SlabTitle)
.AddParameter("@SlabDescription", dtoObject.SlabDescription)
.AddParameter("@RefPaymentSlabID", dtoObject.RefPaymentSlabID)
.AddParameter("@DateOfCompletion", dtoObject.DateOfCompletion)
.AddParameter("@CompletionProjection", dtoObject.CompletionProjection)
.AddParameter("@Installment", dtoObject.Installment)
.AddParameter("@IsFlat", dtoObject.IsFlat)
.AddParameter("@LastUpdateOn", dtoObject.LastUpdateOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@WingID", dtoObject.WingID)

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
        public bool Update(PaymentSlabe dtoObject)
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

                    StoredProcedure(MasterConstant.PaymentSlabeUpdate)
                        .AddParameter("@PaymentSlabeID", dtoObject.PaymentSlabeID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@SlabNo", dtoObject.SlabNo)
.AddParameter("@SlabTitle", dtoObject.SlabTitle)
.AddParameter("@SlabDescription", dtoObject.SlabDescription)
.AddParameter("@RefPaymentSlabID", dtoObject.RefPaymentSlabID)
.AddParameter("@DateOfCompletion", dtoObject.DateOfCompletion)
.AddParameter("@CompletionProjection", dtoObject.CompletionProjection)
.AddParameter("@Installment", dtoObject.Installment)
.AddParameter("@IsFlat", dtoObject.IsFlat)
.AddParameter("@LastUpdateOn", dtoObject.LastUpdateOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@WingID", dtoObject.WingID)

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
                StoredProcedure(MasterConstant.PaymentSlabeDeleteByPrimaryKey)
                    .AddParameter("@PaymentSlabeID"
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
        public bool Delete(PaymentSlabe dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.PaymentSlabeDeleteByPrimaryKey)
                    .AddParameter("@PaymentSlabeID", dtoObject.PaymentSlabeID)

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

        public PaymentSlabe SelectByPrimaryKey(Guid Keys)
        {
            PaymentSlabe obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.PaymentSlabeSelectByPrimaryKey)
                            .AddParameter("@PaymentSlabeID"
, Keys)
                            .Fetch<PaymentSlabe>();
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
        public List<PaymentSlabe> SelectByField(string fieldName, object value)
        {
            List<PaymentSlabe> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.PaymentSlabeSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<PaymentSlabe>();

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
                obj = StoredProcedure(MasterConstant.PaymentSlabeSelectByField)
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
                StoredProcedure(MasterConstant.PaymentSlabeDeleteByField)
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

        public DataSet SearchData(Guid? PaymentSlabeID, Guid? PropertyID, string SlabTitle, Guid? WingID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.PaymentSlabeSearchData)
                                            .AddParameter("@PaymentSlabeID", PaymentSlabeID)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@SlabTitle", SlabTitle)
                                            .AddParameter("@WingID", WingID)
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

        public DataSet GetBlocksTotalMilestoneByRoomID(Guid roomID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.PaymentSlabeGetBlocksTotalMilestone)
                                            .AddParameter("@RoomID", roomID)
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

        public DataSet SelectPaymentSlab(string PaymentSlabQuery)
        {
            DataSet dst = new DataSet();
            try
            {
                dst = Query(PaymentSlabQuery)
                            .WithTransaction(dbtr)
                            .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return dst;
        }

        #endregion
    }
}
