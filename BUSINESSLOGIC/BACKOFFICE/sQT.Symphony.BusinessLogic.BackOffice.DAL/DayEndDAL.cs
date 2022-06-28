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
using SQT.Symphony.BusinessLogic.BackOffice.DTO;
using SQT.Symphony.BusinessLogic.BackOffice.COMMON;

namespace SQT.Symphony.BusinessLogic.BackOffice.DAL
{
    /// <summary>
    /// Data access layer class for DayEnd
    /// </summary>
    public class DayEndDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public DayEndDAL()
            : base()
        {
            // Nothing for now.
        }
        public DayEndDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<DayEnd> SelectAll(DayEnd dtoObject)
        {
            List<DayEnd> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.DayEndSelectAll)
                                                .AddParameter("@DayEndID", dtoObject.DayEndID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@LastAuditDate", dtoObject.LastAuditDate)
.AddParameter("@AuditDate", dtoObject.AuditDate)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@Notes", dtoObject.Notes)
.AddParameter("@ClosedBusinessDay", dtoObject.ClosedBusinessDay)
.AddParameter("@OpeningBusinessDay", dtoObject.OpeningBusinessDay)
.AddParameter("@IsExpress", dtoObject.IsExpress)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)

                                                .WithTransaction(dbtr)
                                                .FetchAll<DayEnd>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.DayEndSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<DayEnd>();
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

        public List<DayEnd> SelectAll()
        {
            List<DayEnd> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.DayEndSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<DayEnd>();
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
        public DataSet SelectAllWithDataSet(DayEnd dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.DayEndSelectAll)
                                                .AddParameter("@DayEndID", dtoObject.DayEndID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@LastAuditDate", dtoObject.LastAuditDate)
.AddParameter("@AuditDate", dtoObject.AuditDate)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@Notes", dtoObject.Notes)
.AddParameter("@ClosedBusinessDay", dtoObject.ClosedBusinessDay)
.AddParameter("@OpeningBusinessDay", dtoObject.OpeningBusinessDay)
.AddParameter("@IsExpress", dtoObject.IsExpress)
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
                        obj = StoredProcedure(MasterDALConstant.DayEndSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.DayEndSelectAll)
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
        public bool Insert(DayEnd dtoObject)
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

                    StoredProcedure(MasterDALConstant.DayEndInsert)
                        .AddParameter("@DayEndID", dtoObject.DayEndID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@LastAuditDate", dtoObject.LastAuditDate)
.AddParameter("@AuditDate", dtoObject.AuditDate)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@Notes", dtoObject.Notes)
.AddParameter("@ClosedBusinessDay", dtoObject.ClosedBusinessDay)
.AddParameter("@OpeningBusinessDay", dtoObject.OpeningBusinessDay)
.AddParameter("@IsExpress", dtoObject.IsExpress)
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
        public bool Update(DayEnd dtoObject)
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

                    StoredProcedure(MasterDALConstant.DayEndUpdate)
                        .AddParameter("@DayEndID", dtoObject.DayEndID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@LastAuditDate", dtoObject.LastAuditDate)
.AddParameter("@AuditDate", dtoObject.AuditDate)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@Notes", dtoObject.Notes)
.AddParameter("@ClosedBusinessDay", dtoObject.ClosedBusinessDay)
.AddParameter("@OpeningBusinessDay", dtoObject.OpeningBusinessDay)
.AddParameter("@IsExpress", dtoObject.IsExpress)
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
                StoredProcedure(MasterDALConstant.DayEndDeleteByPrimaryKey)
                    .AddParameter("@DayEndID"
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
        public bool Delete(DayEnd dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.DayEndDeleteByPrimaryKey)
                    .AddParameter("@DayEndID", dtoObject.DayEndID)

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

        public DayEnd SelectByPrimaryKey(Guid Keys)
        {
            DayEnd obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.DayEndSelectByPrimaryKey)
                            .AddParameter("@DayEndID"
, Keys)
                            .Fetch<DayEnd>();
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
        public List<DayEnd> SelectByField(string fieldName, object value)
        {
            List<DayEnd> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.DayEndSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<DayEnd>();

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
                obj = StoredProcedure(MasterDALConstant.DayEndSelectByField)
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
                StoredProcedure(MasterDALConstant.DayEndDeleteByField)
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

        public DataSet Select_DayEnd_PreCheckReport(string strCode, Guid propertyID, Guid companyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.DayEnd_PreCheckReport)
                                    .AddParameter("@CODE1", strCode)
                                    .AddParameter("@PropertyID", propertyID)
                                    .AddParameter("@CompanyID", companyID)
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


        public DataSet Select_DayEnd_DetailReport()
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.DayEnd_DetailReport)
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

        public DataSet Select_DayEnd_CounterCloseDetailRport(Guid? DayEndID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.DayEnd_CounterCloseDetailRport)
                                    .AddParameter("@DayEndID", DayEndID)
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

        public DataSet Select_DayEnd_DayendCollectionRport(Guid? DayEndID, DateTime? AuditDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.DayEnd_DayendCollectionRport)
                                    .AddParameter("@DayEndID", DayEndID)
                                    .AddParameter("@AuditDate", AuditDate)
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

        public DataSet Select_DayEnd_BackUp()
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.DayEnd_BackUp)
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

        public bool DayEnd_Save(Guid? UserID, string Remark, Guid? DayEndID, Guid? CompanyID, Guid? PropertyID)
        {
            bool blIsSuccessFull = false;
            OutputParameterCollection outputCal = null;
            DayEndID = Guid.Empty;

            try
            {
                StoredProcedure(MasterDALConstant.DayEnd_Save)
                                    .AddParameter("@UserID", UserID)
                                    .AddParameter("@Remark", Remark)
                                    .AddOutParameter("@DayEndID", DayEndID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddOutParameter("@IsSuccessFull", blIsSuccessFull)
                                    .WithTransaction(dbtr)

                                    .Execute(out outputCal);
                blIsSuccessFull = outputCal.GetValue("@IsSuccessFull").Fetch<bool>();

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
            return blIsSuccessFull;
        }

        public bool Reservation_AutoPostRoomAndServiceCharge(DateTime? ServiceDate, Guid? UserID, Guid? CounterID, Guid? PropertyID, string Transaction_Origin, Guid? CompanyID)
        {
            try
            {
                StoredProcedure(MasterDALConstant.Reservation_AutoPostRoomAndServiceCharge)
                                    .AddParameter("@ServiceDate", ServiceDate)
                                    .AddParameter("@UserID", UserID)
                                    .AddParameter("@CounterID", CounterID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@Transaction_Origin", Transaction_Origin)
                                    .AddParameter("@CompanyID", CompanyID)
                                    
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
