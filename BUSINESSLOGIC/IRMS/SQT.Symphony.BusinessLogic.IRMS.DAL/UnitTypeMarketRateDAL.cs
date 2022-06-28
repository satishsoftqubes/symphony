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
using SQT.Symphony.BusinessLogic.IRMS.DTO;
using SQT.Symphony.BusinessLogic.IRMS.COMMON;

namespace SQT.Symphony.BusinessLogic.IRMS.DAL
{
	/// <summary>
	/// Data access layer class for UnitTypeMarketRate
	/// </summary>
	public class UnitTypeMarketRateDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public UnitTypeMarketRateDAL() :  base()
		{
			// Nothing for now.
		}
        public UnitTypeMarketRateDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<UnitTypeMarketRate> SelectAll(UnitTypeMarketRate dtoObject)
        {
            List<UnitTypeMarketRate> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.UnitTypeMarketRateSelectAll)
                                                .AddParameter("@MarketRateID", dtoObject.MarketRateID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@UnitTypeID", dtoObject.UnitTypeID)
.AddParameter("@Rate", dtoObject.Rate)
.AddParameter("@DateOfRate", dtoObject.DateOfRate)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@IsSynch", dtoObject.IsSynch)

                                                .WithTransaction(dbtr)
                                                .FetchAll<UnitTypeMarketRate>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.UnitTypeMarketRateSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<UnitTypeMarketRate>();
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

        public List<UnitTypeMarketRate> SelectAll()
        {
            List<UnitTypeMarketRate> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.UnitTypeMarketRateSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<UnitTypeMarketRate>();
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
        public DataSet SelectAllWithDataSet(UnitTypeMarketRate dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.UnitTypeMarketRateSelectAll)
                                                .AddParameter("@MarketRateID", dtoObject.MarketRateID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@UnitTypeID", dtoObject.UnitTypeID)
.AddParameter("@Rate", dtoObject.Rate)
.AddParameter("@DateOfRate", dtoObject.DateOfRate)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@IsSynch", dtoObject.IsSynch)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.UnitTypeMarketRateSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.UnitTypeMarketRateSelectAll)
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
		public bool Insert(UnitTypeMarketRate dtoObject)
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

                    StoredProcedure(MasterDALConstant.UnitTypeMarketRateInsert)
                        .AddParameter("@MarketRateID", dtoObject.MarketRateID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@UnitTypeID", dtoObject.UnitTypeID)
.AddParameter("@Rate", dtoObject.Rate)
.AddParameter("@DateOfRate", dtoObject.DateOfRate)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@IsSynch", dtoObject.IsSynch)

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
        public bool Update(UnitTypeMarketRate dtoObject)
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

                    StoredProcedure(MasterDALConstant.UnitTypeMarketRateUpdate)
                        .AddParameter("@MarketRateID", dtoObject.MarketRateID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@UnitTypeID", dtoObject.UnitTypeID)
.AddParameter("@Rate", dtoObject.Rate)
.AddParameter("@DateOfRate", dtoObject.DateOfRate)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@IsSynch", dtoObject.IsSynch)

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
                StoredProcedure(MasterDALConstant.UnitTypeMarketRateDeleteByPrimaryKey)
                    .AddParameter("@MarketRateID"
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
        public bool Delete(UnitTypeMarketRate dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.UnitTypeMarketRateDeleteByPrimaryKey)
                    .AddParameter("@MarketRateID", dtoObject.MarketRateID)

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

        public UnitTypeMarketRate SelectByPrimaryKey(Guid Keys)
        {
            UnitTypeMarketRate obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.UnitTypeMarketRateSelectByPrimaryKey)
                            .AddParameter("@MarketRateID"
,Keys)
                            .Fetch<UnitTypeMarketRate>();
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
        public List<UnitTypeMarketRate> SelectByField(string fieldName, object value)
        {
            List<UnitTypeMarketRate> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.UnitTypeMarketRateSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<UnitTypeMarketRate>();

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
                obj = StoredProcedure(MasterDALConstant.UnitTypeMarketRateSelectByField) 
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
                StoredProcedure(MasterDALConstant.UnitTypeMarketRateDeleteByField) 
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

        public DataSet SelectMarketRateData(Guid? PropertyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.UnitTypeMarketRateSelectMarketRateData)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .FetchDataSet();
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public DataSet SearchMarketRateData(Guid? PropertyID, DateTime? DateOfRate, string strType)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.UnitTypeMarketRateSearchData)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@DateOfRate", DateOfRate)
                                    .AddParameter("@strType", strType)
                                    .FetchDataSet();
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public bool DeleteByID(Guid? PropertyID, Guid? CompanyID, DateTime? DateOfRate)
        {
            try
            {
                StoredProcedure(MasterDALConstant.UnitTypeMarketRateDeleteByID)
                    .AddParameter("@PropertyID", PropertyID)
                    .AddParameter("@CompanyID", CompanyID)
                    .AddParameter("@DateOfRate", DateOfRate)

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

        public DataSet DrawChart(Guid? PropertyID, Guid? CompanyID, Guid? UnitTypeID, DateTime? DateOfRate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.UnitTypeMarketDrawChart)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@UnitTypeID", UnitTypeID)
                                    .AddParameter("@DateOfRate", DateOfRate)
                                    .FetchDataSet();
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public DataSet UnitTypeMarketRateSelectData(Guid? PropertyID, Guid? CompanyID, Guid? UnitTypeID, DateTime? DateOfRate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.UnitTypeMarketSelectData)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@UnitTypeID", UnitTypeID)
                                    .AddParameter("@DateOfRate", DateOfRate)
                                    .FetchDataSet();
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public DataSet SelectUnitTypeMarketGridData(Guid? PropertyID, Guid? CompanyID, DateTime? StartDate, DateTime? EndDate, Guid? InvestorID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.UnitTypeMarketSelectGridData)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@StartDate", StartDate)
                                    .AddParameter("@EndDate", EndDate)
                                    .AddParameter("@InvestorID", InvestorID) 
                                    .FetchDataSet();
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public DataSet SelectUnitTypeMarketDate(Guid? PropertyID, Guid? CompanyID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.UnitTypeMarketSelectDate)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@StartDate", StartDate)
                                    .AddParameter("@EndDate", EndDate)
                                    .FetchDataSet();
            }
            catch (Exception ex)
            {
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
