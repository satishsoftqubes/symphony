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
    /// Data access layer class for ProjectTerm
    /// </summary>
    public class ProjectTermDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public ProjectTermDAL()
            : base()
        {
            // Nothing for now.
        }
        public ProjectTermDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<ProjectTerm> SelectAll(ProjectTerm dtoObject)
        {
            List<ProjectTerm> obj = null;
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
                        obj = StoredProcedure(MasterConstant.ProjectTermSelectAll)
                                                .AddParameter("@TermID", dtoObject.TermID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@Category", dtoObject.Category)
.AddParameter("@Term", dtoObject.Term)
.AddParameter("@TermCode", dtoObject.TermCode)
.AddParameter("@ForeColor", dtoObject.ForeColor)
.AddParameter("@BackColor", dtoObject.BackColor)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@LastUpdatedOn", dtoObject.LastUpdatedOn)
.AddParameter("@LastUpdatedBy", dtoObject.LastUpdatedBy)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@TermValue", dtoObject.TermValue)
.AddParameter("@HardCodeTermID", dtoObject.HardCodeTermID)
.AddParameter("@DisplayTerm", dtoObject.DisplayTerm)
.AddParameter("@IsDefault", dtoObject.IsDefault)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@SymphonyValue", dtoObject.SymphonyValue)

                                                .WithTransaction(dbtr)
                                                .FetchAll<ProjectTerm>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.ProjectTermSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<ProjectTerm>();
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

        public List<ProjectTerm> SelectAllByCategory(Guid companyID, Guid propertyID, string termCategory)
        {
            List<ProjectTerm> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                    obj = StoredProcedure(MasterConstant.ProjectTermSelectAllByCategory)
                        .AddParameter("@CompanyID", companyID)
                        .AddParameter("@PropertyID", propertyID)
                        .AddParameter("@Category", termCategory)
                                                .WithTransaction(dbtr)
                                                .FetchAll<ProjectTerm>();
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

        public List<ProjectTerm> SelectAll()
        {
            List<ProjectTerm> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.ProjectTermSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<ProjectTerm>();
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
        public DataSet SelectAllWithDataSet(ProjectTerm dtoObject)
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
                        obj = StoredProcedure(MasterConstant.ProjectTermSelectAll)
                                                .AddParameter("@TermID", dtoObject.TermID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@Category", dtoObject.Category)
.AddParameter("@Term", dtoObject.Term)
.AddParameter("@TermCode", dtoObject.TermCode)
.AddParameter("@ForeColor", dtoObject.ForeColor)
.AddParameter("@BackColor", dtoObject.BackColor)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@LastUpdatedOn", dtoObject.LastUpdatedOn)
.AddParameter("@LastUpdatedBy", dtoObject.LastUpdatedBy)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@TermValue", dtoObject.TermValue)
.AddParameter("@HardCodeTermID", dtoObject.HardCodeTermID)
.AddParameter("@DisplayTerm", dtoObject.DisplayTerm)
.AddParameter("@IsDefault", dtoObject.IsDefault)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@SymphonyValue", dtoObject.SymphonyValue)
                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.ProjectTermSelectAll)
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

                    obj = StoredProcedure(MasterConstant.ProjectTermSelectAll)
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
        public bool Insert(ProjectTerm dtoObject)
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

                    StoredProcedure(MasterConstant.ProjectTermInsert)
                        .AddParameter("@TermID", dtoObject.TermID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@Category", dtoObject.Category)
.AddParameter("@Term", dtoObject.Term)
.AddParameter("@TermCode", dtoObject.TermCode)
.AddParameter("@ForeColor", dtoObject.ForeColor)
.AddParameter("@BackColor", dtoObject.BackColor)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@LastUpdatedOn", dtoObject.LastUpdatedOn)
.AddParameter("@LastUpdatedBy", dtoObject.LastUpdatedBy)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@TermValue", dtoObject.TermValue)
.AddParameter("@HardCodeTermID", dtoObject.HardCodeTermID)
.AddParameter("@DisplayTerm", dtoObject.DisplayTerm)
.AddParameter("@IsDefault", dtoObject.IsDefault)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@SymphonyValue", dtoObject.SymphonyValue)
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
        public bool Update(ProjectTerm dtoObject)
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

                    StoredProcedure(MasterConstant.ProjectTermUpdate)
                        .AddParameter("@TermID", dtoObject.TermID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@Category", dtoObject.Category)
.AddParameter("@Term", dtoObject.Term)
.AddParameter("@TermCode", dtoObject.TermCode)
.AddParameter("@ForeColor", dtoObject.ForeColor)
.AddParameter("@BackColor", dtoObject.BackColor)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@LastUpdatedOn", dtoObject.LastUpdatedOn)
.AddParameter("@LastUpdatedBy", dtoObject.LastUpdatedBy)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@TermValue", dtoObject.TermValue)
.AddParameter("@HardCodeTermID", dtoObject.HardCodeTermID)
.AddParameter("@DisplayTerm", dtoObject.DisplayTerm)
.AddParameter("@IsDefault", dtoObject.IsDefault)
.AddParameter("@Description", dtoObject.Description)
.AddParameter("@SymphonyValue", dtoObject.SymphonyValue)
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
                StoredProcedure(MasterConstant.ProjectTermDeleteByPrimaryKey)
                    .AddParameter("@TermID"
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
        public bool Delete(ProjectTerm dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.ProjectTermDeleteByPrimaryKey)
                    .AddParameter("@TermID", dtoObject.TermID)

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

        public ProjectTerm SelectByPrimaryKey(Guid Keys)
        {
            ProjectTerm obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ProjectTermSelectByPrimaryKey)
                            .AddParameter("@TermID"
, Keys)
                            .Fetch<ProjectTerm>();
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
        public List<ProjectTerm> SelectByField(string fieldName, object value)
        {
            List<ProjectTerm> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ProjectTermSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<ProjectTerm>();

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
                obj = StoredProcedure(MasterConstant.ProjectTermSelectByField)
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
                StoredProcedure(MasterConstant.ProjectTermDeleteByField)
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

        public DataSet SelectDistinctCategory(Guid? CompanyID)
        {
            DataSet obj1 = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj1 = StoredProcedure(MasterConstant.ProjectTermSelectDistinctCategory)
                                            .AddParameter("@CompanyID", CompanyID)
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
            return obj1;
        }
        /// <summary>
        /// Get Distinct Categeoy By Properyt And Company
        /// </summary>
        /// <param name="CompanyID">CompanyID as Guid</param>
        /// <param name="PropertyID">PropertyID as Guid</param>
        /// <returns></returns>
        public DataSet SelectDistinctCategory(Guid? CompanyID, Guid? PropertyID)
        {
            DataSet obj1 = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj1 = StoredProcedure(MasterConstant.ProjectTermSelectDistinctCategory)
                                            .AddParameter("@CompanyID", CompanyID)
                                            .AddParameter("@PropertyID", PropertyID)
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
            return obj1;
        }
        public DataSet SelectData(string ProjectTermQuery)
        {
            DataSet dst = new DataSet();
            try
            {
                dst = Query(ProjectTermQuery)
                            .WithTransaction(dbtr)
                            .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return dst;
        }
        public bool UpdateSeqNo(Guid TermID, string UpDown)
        {
            try
            {
                StoredProcedure(MasterConstant.ProjectTermUpdateSeqNo)
                    .AddParameter("@TermID", TermID)
                    .AddParameter("@UpDown", UpDown)
                    .Execute();
            }
            catch
            {
                throw;
            }
            return true;
        }

        public List<ProjectTerm> SelectAllByCategoryAndTerm(Guid companyID, Guid propertyID, string termCategory,string term)
        {
            List<ProjectTerm> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                    obj = StoredProcedure(MasterConstant.ProjectTermSelectAllByCategoryAndTerm)
                        .AddParameter("@CompanyID", companyID)
                        .AddParameter("@PropertyID", propertyID)
                        .AddParameter("@Category", termCategory)
                        .AddParameter("@Term", term)
                                                .WithTransaction(dbtr)
                                                .FetchAll<ProjectTerm>();
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

        public DataSet SelectAllResStatusByPageType(string PageType, Guid? CompanyID, Guid? PropertyID)
        {
            DataSet obj1 = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj1 = StoredProcedure(MasterConstant.ProjectTermSelectAllResStatusByPageType)
                        .AddParameter("@PageType", PageType)                    
                        .AddParameter("@CompanyID", CompanyID)
                        .AddParameter("@PropertyID", PropertyID)
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
            return obj1;
        }

        public DataSet SelectTitleCSWTGT(Guid? CompanyID, Guid? PropertyID, string CategoryTitle, string CategoryCompanySector, string CategoryWorkingTime, string CategoryGuestType, string CategoryIDDocument, string CategoryBloodGroup, string CategoryMealPreference, string CategoryModeofPayment)
        {
            DataSet obj1 = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj1 = StoredProcedure(MasterConstant.ProjectTermSelectTitleCSWTGT)                        
                        .AddParameter("@CompanyID", CompanyID)
                        .AddParameter("@PropertyID", PropertyID)
                        .AddParameter("@CategoryTitle", CategoryTitle)
                        .AddParameter("@CategoryCompanySector", CategoryCompanySector)
                        .AddParameter("@CategoryWorkingTime", CategoryWorkingTime)
                        .AddParameter("@CategoryGuestType", CategoryGuestType)
                        .AddParameter("@CategoryIDDocument", CategoryIDDocument)
                        .AddParameter("@CategoryBloodGroup", CategoryBloodGroup)
                        .AddParameter("@CategoryMealPreference", CategoryMealPreference)
                        .AddParameter("@CategoryModeofPayment", CategoryModeofPayment)

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
            return obj1;
        }

        public DataSet SelectTranzactionZoneIDByTransZone(string TransactionZone, Guid? CompanyID, Guid? PropertyID)
        {
            DataSet obj1 = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj1 = StoredProcedure(MasterConstant.ProjectTermSelectTranzactionZoneIDByTransZone)
                        .AddParameter("@TransactionZone", TransactionZone)
                        .AddParameter("@CompanyID", CompanyID)
                        .AddParameter("@PropertyID", PropertyID)
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
            return obj1;
        }

        public DataSet SelectReservationTypeTermID(string ReservationType, Guid? CompanyID, Guid? PropertyID)
        {
            DataSet obj1 = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj1 = StoredProcedure(MasterConstant.ProjectTermSelectReservationTypeTermID)
                        .AddParameter("@ReservationType", ReservationType)
                        .AddParameter("@CompanyID", CompanyID)
                        .AddParameter("@PropertyID", PropertyID)
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
            return obj1;
        }

        public DataSet SelectPaymentAcctIDByMOP(string ModeOfPayment, Guid? CompanyID, Guid? PropertyID)
        {
            DataSet obj1 = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj1 = StoredProcedure(MasterConstant.ProjectTermSelectPaymentAcctIDByMOP)
                        .AddParameter("@ModeOfPayment", ModeOfPayment)
                        .AddParameter("@CompanyID", CompanyID)
                        .AddParameter("@PropertyID", PropertyID)
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
            return obj1;
        }

        #endregion
    }
}
