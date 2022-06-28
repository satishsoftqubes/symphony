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
    /// Data access layer class for Item
    /// </summary>
    public class ItemDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public ItemDAL()
            : base()
        {
            // Nothing for now.
        }
        public ItemDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Item> SelectAll(Item dtoObject)
        {
            List<Item> obj = null;
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
                        obj = StoredProcedure(MasterConstant.ItemSelectAll)
                                                .AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ItemCode", dtoObject.ItemCode)
.AddParameter("@ItemName", dtoObject.ItemName)
.AddParameter("@ItemType_TermID", dtoObject.ItemType_TermID)
.AddParameter("@ItemStatus_TermID", dtoObject.ItemStatus_TermID)
.AddParameter("@PostingAcctID", dtoObject.PostingAcctID)
.AddParameter("@COGSAcctID", dtoObject.COGSAcctID)
.AddParameter("@AssetAcctID", dtoObject.AssetAcctID)
.AddParameter("@PreferredSupplierID", dtoObject.PreferredSupplierID)
.AddParameter("@MinStock", dtoObject.MinStock)
.AddParameter("@MaxStock", dtoObject.MaxStock)
.AddParameter("@StockInHand", dtoObject.StockInHand)
.AddParameter("@UOMID", dtoObject.UOMID)
.AddParameter("@DefPurPrice", dtoObject.DefPurPrice)
.AddParameter("@DefSalesPrice", dtoObject.DefSalesPrice)
.AddParameter("@ReOrderLevel", dtoObject.ReOrderLevel)
.AddParameter("@ItemImage", dtoObject.ItemImage)
.AddParameter("@ItemDetails", dtoObject.ItemDetails)
.AddParameter("@ItemCategoryID", dtoObject.ItemCategoryID)
.AddParameter("@BarcodeText", dtoObject.BarcodeText)
.AddParameter("@IsStockPart", dtoObject.IsStockPart)
.AddParameter("@IsConsumable", dtoObject.IsConsumable)
.AddParameter("@IsRoomService", dtoObject.IsRoomService)
.AddParameter("@SymphonyItemType", dtoObject.SymphonyItemType)
.AddParameter("@IsDelete", dtoObject.IsDelete)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Item>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.ItemSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Item>();
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

        public List<Item> SelectAll()
        {
            List<Item> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.ItemSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Item>();
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
        public DataSet SelectAllWithDataSet(Item dtoObject)
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
                        obj = StoredProcedure(MasterConstant.ItemSelectAll)
                                                .AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ItemCode", dtoObject.ItemCode)
.AddParameter("@ItemName", dtoObject.ItemName)
.AddParameter("@ItemType_TermID", dtoObject.ItemType_TermID)
.AddParameter("@ItemStatus_TermID", dtoObject.ItemStatus_TermID)
.AddParameter("@PostingAcctID", dtoObject.PostingAcctID)
.AddParameter("@COGSAcctID", dtoObject.COGSAcctID)
.AddParameter("@AssetAcctID", dtoObject.AssetAcctID)
.AddParameter("@PreferredSupplierID", dtoObject.PreferredSupplierID)
.AddParameter("@MinStock", dtoObject.MinStock)
.AddParameter("@MaxStock", dtoObject.MaxStock)
.AddParameter("@StockInHand", dtoObject.StockInHand)
.AddParameter("@UOMID", dtoObject.UOMID)
.AddParameter("@DefPurPrice", dtoObject.DefPurPrice)
.AddParameter("@DefSalesPrice", dtoObject.DefSalesPrice)
.AddParameter("@ReOrderLevel", dtoObject.ReOrderLevel)
.AddParameter("@ItemImage", dtoObject.ItemImage)
.AddParameter("@ItemDetails", dtoObject.ItemDetails)
.AddParameter("@ItemCategoryID", dtoObject.ItemCategoryID)
.AddParameter("@BarcodeText", dtoObject.BarcodeText)
.AddParameter("@IsStockPart", dtoObject.IsStockPart)
.AddParameter("@IsConsumable", dtoObject.IsConsumable)
.AddParameter("@IsRoomService", dtoObject.IsRoomService)
.AddParameter("@SymphonyItemType", dtoObject.SymphonyItemType)
.AddParameter("@IsDelete", dtoObject.IsDelete)
                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.ItemSelectAll)
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

                    obj = StoredProcedure(MasterConstant.ItemSelectAll)
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
        public bool Insert(Item dtoObject)
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

                    StoredProcedure(MasterConstant.ItemInsert)
                        .AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ItemCode", dtoObject.ItemCode)
.AddParameter("@ItemName", dtoObject.ItemName)
.AddParameter("@ItemType_TermID", dtoObject.ItemType_TermID)
.AddParameter("@ItemStatus_TermID", dtoObject.ItemStatus_TermID)
.AddParameter("@PostingAcctID", dtoObject.PostingAcctID)
.AddParameter("@COGSAcctID", dtoObject.COGSAcctID)
.AddParameter("@AssetAcctID", dtoObject.AssetAcctID)
.AddParameter("@PreferredSupplierID", dtoObject.PreferredSupplierID)
.AddParameter("@MinStock", dtoObject.MinStock)
.AddParameter("@MaxStock", dtoObject.MaxStock)
.AddParameter("@StockInHand", dtoObject.StockInHand)
.AddParameter("@UOMID", dtoObject.UOMID)
.AddParameter("@DefPurPrice", dtoObject.DefPurPrice)
.AddParameter("@DefSalesPrice", dtoObject.DefSalesPrice)
.AddParameter("@ReOrderLevel", dtoObject.ReOrderLevel)
.AddParameter("@ItemImage", dtoObject.ItemImage)
.AddParameter("@ItemDetails", dtoObject.ItemDetails)
.AddParameter("@ItemCategoryID", dtoObject.ItemCategoryID)
.AddParameter("@BarcodeText", dtoObject.BarcodeText)
.AddParameter("@IsStockPart", dtoObject.IsStockPart)
.AddParameter("@IsConsumable", dtoObject.IsConsumable)
.AddParameter("@IsRoomService", dtoObject.IsRoomService)
.AddParameter("@SymphonyItemType", dtoObject.SymphonyItemType)
.AddParameter("@IsDelete", dtoObject.IsDelete)
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
        public bool Update(Item dtoObject)
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

                    StoredProcedure(MasterConstant.ItemUpdate)
                        .AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ItemCode", dtoObject.ItemCode)
.AddParameter("@ItemName", dtoObject.ItemName)
.AddParameter("@ItemType_TermID", dtoObject.ItemType_TermID)
.AddParameter("@ItemStatus_TermID", dtoObject.ItemStatus_TermID)
.AddParameter("@PostingAcctID", dtoObject.PostingAcctID)
.AddParameter("@COGSAcctID", dtoObject.COGSAcctID)
.AddParameter("@AssetAcctID", dtoObject.AssetAcctID)
.AddParameter("@PreferredSupplierID", dtoObject.PreferredSupplierID)
.AddParameter("@MinStock", dtoObject.MinStock)
.AddParameter("@MaxStock", dtoObject.MaxStock)
.AddParameter("@StockInHand", dtoObject.StockInHand)
.AddParameter("@UOMID", dtoObject.UOMID)
.AddParameter("@DefPurPrice", dtoObject.DefPurPrice)
.AddParameter("@DefSalesPrice", dtoObject.DefSalesPrice)
.AddParameter("@ReOrderLevel", dtoObject.ReOrderLevel)
.AddParameter("@ItemImage", dtoObject.ItemImage)
.AddParameter("@ItemDetails", dtoObject.ItemDetails)
.AddParameter("@ItemCategoryID", dtoObject.ItemCategoryID)
.AddParameter("@BarcodeText", dtoObject.BarcodeText)
.AddParameter("@IsStockPart", dtoObject.IsStockPart)
.AddParameter("@IsConsumable", dtoObject.IsConsumable)
.AddParameter("@IsRoomService", dtoObject.IsRoomService)
.AddParameter("@SymphonyItemType", dtoObject.SymphonyItemType)
.AddParameter("@IsDelete", dtoObject.IsDelete)
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
                StoredProcedure(MasterConstant.ItemDeleteByPrimaryKey)
                    .AddParameter("@ItemID"
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
        public bool Delete(Item dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.ItemDeleteByPrimaryKey)
                    .AddParameter("@ItemID", dtoObject.ItemID)

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

        public Item SelectByPrimaryKey(Guid Keys)
        {
            Item obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ItemSelectByPrimaryKey)
                            .AddParameter("@ItemID"
, Keys)
                            .Fetch<Item>();
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
        public List<Item> SelectByField(string fieldName, object value)
        {
            List<Item> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ItemSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Item>();

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
                obj = StoredProcedure(MasterConstant.ItemSelectByField)
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
                StoredProcedure(MasterConstant.ItemDeleteByField)
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

        public DataSet SelectAllForAddOns(Guid companyID, Guid propertyID, Guid addOnID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.ItemSelectAllForAddOns)
                            .AddParameter("@PropertyID", propertyID)
                            .AddParameter("@CompanyID", companyID)
                            .AddParameter("@AddOnID", addOnID)
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

        public DataSet SelectAllWithRelatedData(Item dtoObject)
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
                        obj = StoredProcedure(MasterConstant.ItemSelectAllWithData)
                                                .AddParameter("@ItemID", dtoObject.ItemID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ItemCode", dtoObject.ItemCode)
.AddParameter("@ItemName", dtoObject.ItemName)
.AddParameter("@ItemType_TermID", dtoObject.ItemType_TermID)
.AddParameter("@ItemStatus_TermID", dtoObject.ItemStatus_TermID)
.AddParameter("@PostingAcctID", dtoObject.PostingAcctID)
.AddParameter("@COGSAcctID", dtoObject.COGSAcctID)
.AddParameter("@AssetAcctID", dtoObject.AssetAcctID)
.AddParameter("@PreferredSupplierID", dtoObject.PreferredSupplierID)
.AddParameter("@MinStock", dtoObject.MinStock)
.AddParameter("@MaxStock", dtoObject.MaxStock)
.AddParameter("@StockInHand", dtoObject.StockInHand)
.AddParameter("@UOMID", dtoObject.UOMID)
.AddParameter("@DefPurPrice", dtoObject.DefPurPrice)
.AddParameter("@DefSalesPrice", dtoObject.DefSalesPrice)
.AddParameter("@ReOrderLevel", dtoObject.ReOrderLevel)
.AddParameter("@ItemImage", dtoObject.ItemImage)
.AddParameter("@ItemDetails", dtoObject.ItemDetails)
.AddParameter("@ItemCategoryID", dtoObject.ItemCategoryID)
.AddParameter("@BarcodeText", dtoObject.BarcodeText)
.AddParameter("@IsStockPart", dtoObject.IsStockPart)
.AddParameter("@IsConsumable", dtoObject.IsConsumable)
.AddParameter("@IsRoomService", dtoObject.IsRoomService)
.AddParameter("@IsDelete", dtoObject.IsDelete)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.ItemSelectAll)
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

        public DataSet SelectItemDataByPrimaryKey(Guid itemID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.ItemSelectItemDataByPrimaryKey)
                                    .AddParameter("@ItemID", itemID)
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

        public DataSet SelectAllForRateCard(Guid companyID, Guid propertyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.ItemSelectItemsForRateCard)
                            .AddParameter("@PropertyID", propertyID)
                            .AddParameter("@CompanyID", companyID)
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

        public DataSet SelectItemAvailabilityDataByItemIDAndCategoryIDs(Guid? ItemID, string strCategoryID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.ItemSelectItemAvailabilityDataByItemAndCategoryIDs)
                            .AddParameter("@ItemID", ItemID)
                            .AddParameter("@CategoryIDs", strCategoryID)
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


        public List<Item> SearchDataForRoomService(Guid? PropertyID, Guid? CompanyID, string Title)
        {
            List<Item> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    //if (dtoObject != null)
                    //    parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.SearchDataForRoomService)
                                            .AddParameter("@ItemName", Title)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@CompanyID", CompanyID)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Item>();

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


        #endregion
    }
}
