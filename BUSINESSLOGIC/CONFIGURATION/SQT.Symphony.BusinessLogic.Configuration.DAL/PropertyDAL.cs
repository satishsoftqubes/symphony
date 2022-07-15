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
    /// Data access layer class for Property
    /// </summary>
    public class PropertyDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public PropertyDAL()
            : base()
        {
            // Nothing for now.
        }
        public PropertyDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Property> SelectAll(Property dtoObject)
        {
            List<Property> obj = null;
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
                        obj = StoredProcedure(MasterConstant.PropertySelectAll)
                                                .AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@PropertyTypeID", dtoObject.PropertyTypeID)
.AddParameter("@PropertyCode", dtoObject.PropertyCode)
.AddParameter("@PropertyName", dtoObject.PropertyName)
.AddParameter("@AddressID", dtoObject.AddressID)
.AddParameter("@PropManagerName", dtoObject.PropManagerName)
.AddParameter("@PrimaryContactNo", dtoObject.PrimaryContactNo)
.AddParameter("@PrimaryEmail", dtoObject.PrimaryEmail)
.AddParameter("@PrimaryFax", dtoObject.PrimaryFax)
.AddParameter("@PropertyDisplayName", dtoObject.PropertyDisplayName)
.AddParameter("@PropertyRegisteredOn", dtoObject.PropertyRegisteredOn)
.AddParameter("@PropertyRegisteredBy", dtoObject.PropertyRegisteredBy)
.AddParameter("@PropertyCreatedOn", dtoObject.PropertyCreatedOn)
.AddParameter("@IsApproved", dtoObject.IsApproved)
.AddParameter("@ApprovedBy", dtoObject.ApprovedBy)
.AddParameter("@ApprovedOn", dtoObject.ApprovedOn)
.AddParameter("@PropertyRating", dtoObject.PropertyRating)
.AddParameter("@PropertyComments", dtoObject.PropertyComments)
.AddParameter("@LastUpdateOn", dtoObject.LastUpdateOn)
.AddParameter("@LastUpdateBy", dtoObject.LastUpdateBy)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ActivationKey", dtoObject.ActivationKey)
.AddParameter("@ActivationCode", dtoObject.ActivationCode)
.AddParameter("@LicenseNoOfUsers", dtoObject.LicenseNoOfUsers)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@SBArea", dtoObject.SBArea)
.AddParameter("@CarpetArea", dtoObject.CarpetArea)
.AddParameter("@PhotoLocal", dtoObject.PhotoLocal)
.AddParameter("@SBAreaCommercial", dtoObject.SBAreaCommercial)
.AddParameter("@KhataNo", dtoObject.KhataNo)
.AddParameter("@BuldingPlanApprovalNo", dtoObject.BuldingPlanApprovalNo)
.AddParameter("@KPSBNoc", dtoObject.KPSBNoc)
.AddParameter("@SEACNOC", dtoObject.SEACNOC)
.AddParameter("@CertificationNo", dtoObject.CertificationNo)
.AddParameter("@LicenceNo", dtoObject.LicenceNo)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Property>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.PropertySelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Property>();
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

        public List<Property> SelectAll()
        {
            List<Property> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.PropertySelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Property>();
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
        public DataSet SelectAllWithDataSet(Property dtoObject)
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
                        obj = StoredProcedure(MasterConstant.PropertySelectAll)
                                                .AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@PropertyTypeID", dtoObject.PropertyTypeID)
.AddParameter("@PropertyCode", dtoObject.PropertyCode)
.AddParameter("@PropertyName", dtoObject.PropertyName)
.AddParameter("@AddressID", dtoObject.AddressID)
.AddParameter("@PropManagerName", dtoObject.PropManagerName)
.AddParameter("@PrimaryContactNo", dtoObject.PrimaryContactNo)
.AddParameter("@PrimaryEmail", dtoObject.PrimaryEmail)
.AddParameter("@PrimaryFax", dtoObject.PrimaryFax)
.AddParameter("@PropertyDisplayName", dtoObject.PropertyDisplayName)
.AddParameter("@PropertyRegisteredOn", dtoObject.PropertyRegisteredOn)
.AddParameter("@PropertyRegisteredBy", dtoObject.PropertyRegisteredBy)
.AddParameter("@PropertyCreatedOn", dtoObject.PropertyCreatedOn)
.AddParameter("@IsApproved", dtoObject.IsApproved)
.AddParameter("@ApprovedBy", dtoObject.ApprovedBy)
.AddParameter("@ApprovedOn", dtoObject.ApprovedOn)
.AddParameter("@PropertyRating", dtoObject.PropertyRating)
.AddParameter("@PropertyComments", dtoObject.PropertyComments)
.AddParameter("@LastUpdateOn", dtoObject.LastUpdateOn)
.AddParameter("@LastUpdateBy", dtoObject.LastUpdateBy)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ActivationKey", dtoObject.ActivationKey)
.AddParameter("@ActivationCode", dtoObject.ActivationCode)
.AddParameter("@LicenseNoOfUsers", dtoObject.LicenseNoOfUsers)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@SBArea", dtoObject.SBArea)
.AddParameter("@CarpetArea", dtoObject.CarpetArea)
.AddParameter("@PhotoLocal", dtoObject.PhotoLocal)
.AddParameter("@SBAreaCommercial", dtoObject.SBAreaCommercial)
.AddParameter("@KhataNo", dtoObject.KhataNo)
.AddParameter("@BuldingPlanApprovalNo", dtoObject.BuldingPlanApprovalNo)
.AddParameter("@KPSBNoc", dtoObject.KPSBNoc)
.AddParameter("@SEACNOC", dtoObject.SEACNOC)
.AddParameter("@CertificationNo", dtoObject.CertificationNo)
.AddParameter("@LicenceNo", dtoObject.LicenceNo)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.PropertySelectAll)
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

                    obj = StoredProcedure(MasterConstant.PropertySelectAll)
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
        public bool Insert(Property dtoObject)
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

                    StoredProcedure(MasterConstant.PropertyInsert)
                        .AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@PropertyTypeID", dtoObject.PropertyTypeID)
.AddParameter("@PropertyCode", dtoObject.PropertyCode)
.AddParameter("@PropertyName", dtoObject.PropertyName)
.AddParameter("@AddressID", dtoObject.AddressID)
.AddParameter("@PropManagerName", dtoObject.PropManagerName)
.AddParameter("@PrimaryContactNo", dtoObject.PrimaryContactNo)
.AddParameter("@PrimaryEmail", dtoObject.PrimaryEmail)
.AddParameter("@PrimaryFax", dtoObject.PrimaryFax)
.AddParameter("@PropertyDisplayName", dtoObject.PropertyDisplayName)
.AddParameter("@PropertyRegisteredOn", dtoObject.PropertyRegisteredOn)
.AddParameter("@PropertyRegisteredBy", dtoObject.PropertyRegisteredBy)
.AddParameter("@PropertyCreatedOn", dtoObject.PropertyCreatedOn)
.AddParameter("@IsApproved", dtoObject.IsApproved)
.AddParameter("@ApprovedBy", dtoObject.ApprovedBy)
.AddParameter("@ApprovedOn", dtoObject.ApprovedOn)
.AddParameter("@PropertyRating", dtoObject.PropertyRating)
.AddParameter("@PropertyComments", dtoObject.PropertyComments)
.AddParameter("@LastUpdateOn", dtoObject.LastUpdateOn)
.AddParameter("@LastUpdateBy", dtoObject.LastUpdateBy)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ActivationKey", dtoObject.ActivationKey)
.AddParameter("@ActivationCode", dtoObject.ActivationCode)
.AddParameter("@LicenseNoOfUsers", dtoObject.LicenseNoOfUsers)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@SBArea", dtoObject.SBArea)
.AddParameter("@CarpetArea", dtoObject.CarpetArea)
.AddParameter("@PhotoLocal", dtoObject.PhotoLocal)
.AddParameter("@SBAreaCommercial", dtoObject.SBAreaCommercial)
.AddParameter("@KhataNo", dtoObject.KhataNo)
.AddParameter("@BuldingPlanApprovalNo", dtoObject.BuldingPlanApprovalNo)
.AddParameter("@KPSBNoc", dtoObject.KPSBNoc)
.AddParameter("@SEACNOC", dtoObject.SEACNOC)
.AddParameter("@CertificationNo", dtoObject.CertificationNo)
.AddParameter("@LicenceNo", dtoObject.LicenceNo)
.AddParameter("@PurchaseOptionID", dtoObject.PurchaseOptionID)
.AddParameter("@SurveyNo", dtoObject.SurveyNo)
.AddParameter("@PaymentTermID", dtoObject.PaymentTermID)
.AddParameter("@Jantri", dtoObject.Jantri)
.AddParameter("@PropertyStatusID", dtoObject.PropertyStatusID)

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
        public bool Update(Property dtoObject)
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

                    StoredProcedure(MasterConstant.PropertyUpdate)
                        .AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@PropertyTypeID", dtoObject.PropertyTypeID)
.AddParameter("@PropertyCode", dtoObject.PropertyCode)
.AddParameter("@PropertyName", dtoObject.PropertyName)
.AddParameter("@AddressID", dtoObject.AddressID)
.AddParameter("@PropManagerName", dtoObject.PropManagerName)
.AddParameter("@PrimaryContactNo", dtoObject.PrimaryContactNo)
.AddParameter("@PrimaryEmail", dtoObject.PrimaryEmail)
.AddParameter("@PrimaryFax", dtoObject.PrimaryFax)
.AddParameter("@PropertyDisplayName", dtoObject.PropertyDisplayName)
.AddParameter("@PropertyRegisteredOn", dtoObject.PropertyRegisteredOn)
.AddParameter("@PropertyRegisteredBy", dtoObject.PropertyRegisteredBy)
.AddParameter("@PropertyCreatedOn", dtoObject.PropertyCreatedOn)
.AddParameter("@IsApproved", dtoObject.IsApproved)
.AddParameter("@ApprovedBy", dtoObject.ApprovedBy)
.AddParameter("@ApprovedOn", dtoObject.ApprovedOn)
.AddParameter("@PropertyRating", dtoObject.PropertyRating)
.AddParameter("@PropertyComments", dtoObject.PropertyComments)
.AddParameter("@LastUpdateOn", dtoObject.LastUpdateOn)
.AddParameter("@LastUpdateBy", dtoObject.LastUpdateBy)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@ActivationKey", dtoObject.ActivationKey)
.AddParameter("@ActivationCode", dtoObject.ActivationCode)
.AddParameter("@LicenseNoOfUsers", dtoObject.LicenseNoOfUsers)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@SBArea", dtoObject.SBArea)
.AddParameter("@CarpetArea", dtoObject.CarpetArea)
.AddParameter("@PhotoLocal", dtoObject.PhotoLocal)
.AddParameter("@SBAreaCommercial", dtoObject.SBAreaCommercial)
.AddParameter("@KhataNo", dtoObject.KhataNo)
.AddParameter("@BuldingPlanApprovalNo", dtoObject.BuldingPlanApprovalNo)
.AddParameter("@KPSBNoc", dtoObject.KPSBNoc)
.AddParameter("@SEACNOC", dtoObject.SEACNOC)
.AddParameter("@CertificationNo", dtoObject.CertificationNo)
.AddParameter("@LicenceNo", dtoObject.LicenceNo)
.AddParameter("@PurchaseOptionID", dtoObject.PurchaseOptionID)
.AddParameter("@SurveyNo", dtoObject.SurveyNo)
.AddParameter("@PaymentTermID", dtoObject.PaymentTermID)
.AddParameter("@Jantri", dtoObject.Jantri)
.AddParameter("@PropertyStatusID", dtoObject.PropertyStatusID)

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
                StoredProcedure(MasterConstant.PropertyDeleteByPrimaryKey)
                    .AddParameter("@PropertyID"
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
        public bool Delete(Property dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.PropertyDeleteByPrimaryKey)
                    .AddParameter("@PropertyID", dtoObject.PropertyID)

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

        public Property SelectByPrimaryKey(Guid Keys)
        {
            Property obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.PropertySelectByPrimaryKey)
                            .AddParameter("@PropertyID"
, Keys)
                            .Fetch<Property>();
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
        public List<Property> SelectByField(string fieldName, object value)
        {
            List<Property> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.PropertySelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Property>();

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
                obj = StoredProcedure(MasterConstant.PropertySelectByField)
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

        public DataSet SelectAllDataByPrimaryKey(Guid propertyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.PropertySelectByPrimaryKey)
                                    .AddParameter("@PropertyID", propertyID)
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
                StoredProcedure(MasterConstant.PropertyDeleteByField)
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

        public DataSet SelectPropertyData(Guid? PropertyID, Guid? CompanyID, string PropertyName,string location, Guid? propertyType)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.PropertySelectData)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@CompanyID", CompanyID)
                                            .AddParameter("@PropertyName", PropertyName)
                                            .AddParameter("@Location", location)
                                            .AddParameter("@PropertyType", propertyType)
                                            .WithTransaction(dbtr)
                                            .FetchDataSet();

                }
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public DataSet SelectPropertyUnitView(Guid PropertyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.PropertyUnitView)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .WithTransaction(dbtr)
                                            .FetchDataSet();

                }
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public DataSet SelectPropertyRoomTypeView(Guid PropertyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.PropertyRoomTypeView)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .WithTransaction(dbtr)
                                            .FetchDataSet();

                }
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public DataSet SelectPropertyBlockUnitView(Guid PropertyID, Guid WingID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.PropertyBlockUnitView)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@WingID", WingID)
                                            .WithTransaction(dbtr)
                                            .FetchDataSet();

                }
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
                bool rethrow = ExceptionPolicy.HandleException(ex, SQTLogType.DataAccessLayerLog);
                if (rethrow)
                {
                    throw ex;
                }
            }
            return obj;
        }

        public DataSet SelectData(Guid? CompanyID)
        {
            DataSet dst = new DataSet();
            try
            {
                string strQuery = "Select PropertyID, PropertyName, CompanyID From mst_Property Where IsActive = 1" + (CompanyID == null ? null : " And CompanyID = '" + CompanyID + "' order by PropertyName asc");
                
                dst = Query(strQuery)
                            .WithTransaction(dbtr)
                            .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return dst;
        }

        public DataSet SelectIndexDashBoard(Guid CompanyID, Guid? UserID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.IndexDashBoard)
                                            .AddParameter("@CompanyID",CompanyID)
                                            .AddParameter("@UserID", UserID)
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

        public DataSet SelectPropertyAddressInfo(Guid? PropertyID, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.PropertySelectAddressInfo)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@CompanyID", CompanyID)
                                            .WithTransaction(dbtr)
                                            .FetchDataSet();

                }
            }
            catch (Exception ex)
            {
                ////Log exception at DataAccess Layer.
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
