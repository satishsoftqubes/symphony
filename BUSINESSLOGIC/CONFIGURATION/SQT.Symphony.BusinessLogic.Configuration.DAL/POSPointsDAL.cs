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
	/// Data access layer class for POSPoints
	/// </summary>
	public class POSPointsDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public POSPointsDAL() :  base()
		{
			// Nothing for now.
		}
        public POSPointsDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<POSPoints> SelectAll(POSPoints dtoObject)
        {
            List<POSPoints> obj = null;
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
                        obj = StoredProcedure(MasterConstant.POSPointsSelectAll)
                                                .AddParameter("@POSPointID", dtoObject.POSPointID)
.AddParameter("@POSLocation_TermID", dtoObject.POSLocation_TermID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@POSPointName", dtoObject.POSPointName)
.AddParameter("@PointDisplayName", dtoObject.PointDisplayName)
.AddParameter("@UploadImage", dtoObject.UploadImage)
.AddParameter("@IsActivityPOS", dtoObject.IsActivityPOS)
.AddParameter("@IsConsumablePOS", dtoObject.IsConsumablePOS)
.AddParameter("@POSDescription", dtoObject.POSDescription)
.AddParameter("@DefaultCounterID", dtoObject.DefaultCounterID)
.AddParameter("@DefaultUserID", dtoObject.DefaultUserID)
.AddParameter("@IsTouchScreenEnable", dtoObject.IsTouchScreenEnable)
.AddParameter("@VendorID", dtoObject.VendorID)

                                                .WithTransaction(dbtr)
                                                .FetchAll<POSPoints>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.POSPointsSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<POSPoints>();
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

        public List<POSPoints> SelectAll()
        {
            List<POSPoints> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.POSPointsSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<POSPoints>();
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
        public DataSet SelectAllWithDataSet(POSPoints dtoObject)
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
                        obj = StoredProcedure(MasterConstant.POSPointsSelectAll)
                                                .AddParameter("@POSPointID", dtoObject.POSPointID)
.AddParameter("@POSLocation_TermID", dtoObject.POSLocation_TermID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@POSPointName", dtoObject.POSPointName)
.AddParameter("@PointDisplayName", dtoObject.PointDisplayName)
.AddParameter("@UploadImage", dtoObject.UploadImage)
.AddParameter("@IsActivityPOS", dtoObject.IsActivityPOS)
.AddParameter("@IsConsumablePOS", dtoObject.IsConsumablePOS)
.AddParameter("@POSDescription", dtoObject.POSDescription)
.AddParameter("@DefaultCounterID", dtoObject.DefaultCounterID)
.AddParameter("@DefaultUserID", dtoObject.DefaultUserID)
.AddParameter("@IsTouchScreenEnable", dtoObject.IsTouchScreenEnable)
.AddParameter("@VendorID", dtoObject.VendorID)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.POSPointsSelectAll)
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

                    obj = StoredProcedure(MasterConstant.POSPointsSelectAll)
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
		public bool Insert(POSPoints dtoObject)
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

                    StoredProcedure(MasterConstant.POSPointsInsert)
                        .AddParameter("@POSPointID", dtoObject.POSPointID)
.AddParameter("@POSLocation_TermID", dtoObject.POSLocation_TermID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@POSPointName", dtoObject.POSPointName)
.AddParameter("@PointDisplayName", dtoObject.PointDisplayName)
.AddParameter("@UploadImage", dtoObject.UploadImage)
.AddParameter("@IsActivityPOS", dtoObject.IsActivityPOS)
.AddParameter("@IsConsumablePOS", dtoObject.IsConsumablePOS)
.AddParameter("@POSDescription", dtoObject.POSDescription)
.AddParameter("@DefaultCounterID", dtoObject.DefaultCounterID)
.AddParameter("@DefaultUserID", dtoObject.DefaultUserID)
.AddParameter("@IsTouchScreenEnable", dtoObject.IsTouchScreenEnable)
.AddParameter("@VendorID", dtoObject.VendorID)

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
        public bool Update(POSPoints dtoObject)
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

                    StoredProcedure(MasterConstant.POSPointsUpdate)
                        .AddParameter("@POSPointID", dtoObject.POSPointID)
.AddParameter("@POSLocation_TermID", dtoObject.POSLocation_TermID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@POSPointName", dtoObject.POSPointName)
.AddParameter("@PointDisplayName", dtoObject.PointDisplayName)
.AddParameter("@UploadImage", dtoObject.UploadImage)
.AddParameter("@IsActivityPOS", dtoObject.IsActivityPOS)
.AddParameter("@IsConsumablePOS", dtoObject.IsConsumablePOS)
.AddParameter("@POSDescription", dtoObject.POSDescription)
.AddParameter("@DefaultCounterID", dtoObject.DefaultCounterID)
.AddParameter("@DefaultUserID", dtoObject.DefaultUserID)
.AddParameter("@IsTouchScreenEnable", dtoObject.IsTouchScreenEnable)
.AddParameter("@VendorID", dtoObject.VendorID)

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
                StoredProcedure(MasterConstant.POSPointsDeleteByPrimaryKey)
                    .AddParameter("@POSPointID"
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
        public bool Delete(POSPoints dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.POSPointsDeleteByPrimaryKey)
                    .AddParameter("@POSPointID", dtoObject.POSPointID)

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

        public POSPoints SelectByPrimaryKey(Guid Keys)
        {
            POSPoints obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.POSPointsSelectByPrimaryKey)
                            .AddParameter("@POSPointID"
,Keys)
                            .Fetch<POSPoints>();
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
        public List<POSPoints> SelectByField(string fieldName, object value)
        {
            List<POSPoints> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.POSPointsSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<POSPoints>();

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
                obj = StoredProcedure(MasterConstant.POSPointsSelectByField) 
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
                StoredProcedure(MasterConstant.POSPointsDeleteByField) 
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
        /// <summary>
        /// Get Search POS Point Information
        /// </summary>
        /// <param name="CompanyID">CompanyID as Guid</param>
        /// <param name="PropertyID">PropertyID as Guid</param>
        /// <param name="PointName">PointName as string</param>
        /// <param name="PointLocationTermID">PointLocationTermID as Guid</param>
        /// <returns></returns>
        public DataSet SearchPOSPoint(Guid? CompanyID, Guid? PropertyID, string PointName, Guid? PointLocationTermID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.POSPointSearchDate)
                    .AddParameter("@CompanyID", CompanyID)
                    .AddParameter("@PropertyID", PropertyID)
                    .AddParameter("@POSPointName", PointName)
                    .AddParameter("@POSLocation_TermID", PointLocationTermID)
                    .FetchDataSet();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Dst;
        }

        public DataSet POSPointsGetAllForItem(Guid? CompanyID, Guid? PropertyID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.POSPointSelectAllForItem)
                    .AddParameter("@CompanyID", CompanyID)
                    .AddParameter("@PropertyID", PropertyID)
                    .FetchDataSet();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Dst;
        }

        public DataSet SelectPosPoints(string strPosPoints)
        {
            DataSet dst = new DataSet();
            try
            {                
                dst = Query(strPosPoints)
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
