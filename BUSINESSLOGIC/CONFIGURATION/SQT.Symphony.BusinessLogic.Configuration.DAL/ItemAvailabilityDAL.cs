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
	/// Data access layer class for ItemAvailability
	/// </summary>
	public class ItemAvailabilityDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public ItemAvailabilityDAL() :  base()
		{
			// Nothing for now.
		}
        public ItemAvailabilityDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<ItemAvailability> SelectAll(ItemAvailability dtoObject)
        {
            List<ItemAvailability> obj = null;
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
                        obj = StoredProcedure(MasterConstant.ItemAvailabilitySelectAll)
                                                .AddParameter("@ItemAvailabilityID", dtoObject.ItemAvailabilityID)
.AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@Location_TermID", dtoObject.Location_TermID)
.AddParameter("@POSPointID", dtoObject.POSPointID)
.AddParameter("@QtyOnHand", dtoObject.QtyOnHand)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@ServiceRate", dtoObject.ServiceRate)
.AddParameter("@MarkUpRate", dtoObject.MarkUpRate)
.AddParameter("@IsMarkUpFlat", dtoObject.IsMarkUpFlat)
.AddParameter("@CategoryID", dtoObject.CategoryID)

                                                .WithTransaction(dbtr)
                                                .FetchAll<ItemAvailability>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.ItemAvailabilitySelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<ItemAvailability>();
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

        public List<ItemAvailability> SelectAll()
        {
            List<ItemAvailability> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.ItemAvailabilitySelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<ItemAvailability>();
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
        public DataSet SelectAllWithDataSet(ItemAvailability dtoObject)
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
                        obj = StoredProcedure(MasterConstant.ItemAvailabilitySelectAll)
                                                .AddParameter("@ItemAvailabilityID", dtoObject.ItemAvailabilityID)
.AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@Location_TermID", dtoObject.Location_TermID)
.AddParameter("@POSPointID", dtoObject.POSPointID)
.AddParameter("@QtyOnHand", dtoObject.QtyOnHand)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@ServiceRate", dtoObject.ServiceRate)
.AddParameter("@MarkUpRate", dtoObject.MarkUpRate)
.AddParameter("@IsMarkUpFlat", dtoObject.IsMarkUpFlat)
.AddParameter("@CategoryID", dtoObject.CategoryID)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.ItemAvailabilitySelectAll)
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

                    obj = StoredProcedure(MasterConstant.ItemAvailabilitySelectAll)
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
		public bool Insert(ItemAvailability dtoObject)
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

                    StoredProcedure(MasterConstant.ItemAvailabilityInsert)
                        .AddParameter("@ItemAvailabilityID", dtoObject.ItemAvailabilityID)
.AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@Location_TermID", dtoObject.Location_TermID)
.AddParameter("@POSPointID", dtoObject.POSPointID)
.AddParameter("@QtyOnHand", dtoObject.QtyOnHand)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@ServiceRate", dtoObject.ServiceRate)
.AddParameter("@MarkUpRate", dtoObject.MarkUpRate)
.AddParameter("@IsMarkUpFlat", dtoObject.IsMarkUpFlat)
.AddParameter("@CategoryID", dtoObject.CategoryID)

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
        public bool Update(ItemAvailability dtoObject)
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

                    StoredProcedure(MasterConstant.ItemAvailabilityUpdate)
                        .AddParameter("@ItemAvailabilityID", dtoObject.ItemAvailabilityID)
.AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@Location_TermID", dtoObject.Location_TermID)
.AddParameter("@POSPointID", dtoObject.POSPointID)
.AddParameter("@QtyOnHand", dtoObject.QtyOnHand)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@ServiceRate", dtoObject.ServiceRate)
.AddParameter("@MarkUpRate", dtoObject.MarkUpRate)
.AddParameter("@IsMarkUpFlat", dtoObject.IsMarkUpFlat)
.AddParameter("@CategoryID", dtoObject.CategoryID)

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
                StoredProcedure(MasterConstant.ItemAvailabilityDeleteByPrimaryKey)
                    .AddParameter("@ItemAvailabilityID"
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
        public bool Delete(ItemAvailability dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.ItemAvailabilityDeleteByPrimaryKey)
                    .AddParameter("@ItemAvailabilityID", dtoObject.ItemAvailabilityID)

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

        public ItemAvailability SelectByPrimaryKey(Guid Keys)
        {
            ItemAvailability obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ItemAvailabilitySelectByPrimaryKey)
                            .AddParameter("@ItemAvailabilityID"
,Keys)
                            .Fetch<ItemAvailability>();
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

        public List<ItemAvailability> SelectByField(string fieldName, object value)
        {
            List<ItemAvailability> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ItemAvailabilitySelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<ItemAvailability>();

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
                obj = StoredProcedure(MasterConstant.ItemAvailabilitySelectByField) 
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
                StoredProcedure(MasterConstant.ItemAvailabilityDeleteByField) 
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

        public DataSet SelectDataByPosPointsID(Guid? POSPointID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ItemAvailabilitySelectDataByPosPointsID)
                                    .AddParameter("@POSPointID", POSPointID)                                    
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

        public DataSet SelectItemAvailabilityData(string strItemAvailabilityQuery)
        {
            DataSet dst = new DataSet();
            try
            {
                dst = Query(strItemAvailabilityQuery)
                            .WithTransaction(dbtr)
                            .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return dst;
        }

        public DataSet SelectAllItems(Guid? Location_TermID, Guid? ItemID, Guid? CategoryID, Guid? CompanyID, Guid? PropertyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ItemAvailabilitySelectAllItems)
                                    .AddParameter("@Location_TermID", Location_TermID)
                                    .AddParameter("@ItemID", ItemID)
                                    .AddParameter("@CategoryID", CategoryID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@PropertyID", PropertyID)
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
