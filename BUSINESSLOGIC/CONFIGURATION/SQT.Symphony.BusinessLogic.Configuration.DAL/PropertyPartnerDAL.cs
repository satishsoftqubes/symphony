using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SQT.FRAMEWORK.DAL.Linq;
using SQT.FRAMEWORK.DAL.Linq.DAL;
using SQT.FRAMEWORK.EXCEPTION;
using SQT.FRAMEWORK.LOGGER;
using SQT.Symphony.BusinessLogic.Configuration.COMMON;
using SQT.Symphony.BusinessLogic.Configuration.DTO;

namespace SQT.Symphony.BusinessLogic.Configuration.DAL
{
    public class PropertyPartnerDAL : LinqDAL
    {
        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public PropertyPartnerDAL()
            : base()
        {
            // Nothing for now.
        }
        public PropertyPartnerDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        public bool Insert(PropertyPartner dtoObject)
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

                    StoredProcedure(MasterConstant.PropertyPartnerInsert)
                        .AddParameter("@PropertyPartnerID", dtoObject.PropertyPartnerID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@PartnerID", dtoObject.PartnerID)
.AddParameter("@AddedOn", dtoObject.AddedOn)
.AddParameter("@PartnershipInPercentage", dtoObject.PartnershipInPercentage)
.AddParameter("@TotalToInvest", dtoObject.TotalToInvest)
.AddParameter("@TotalDue", dtoObject.TotalDue)
.AddParameter("@TotalInvested", dtoObject.TotalInvested)
.AddParameter("@PartnershipDissolveOn", dtoObject.PartnershipDissolveOn)
.AddParameter("@StatusTerm", dtoObject.StatusTerm)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@PartnerLegalName", dtoObject.PartnerLegalName)
.AddParameter("@Description", dtoObject.Description)

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
        public bool Update(PropertyPartner dtoObject)
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

                    StoredProcedure(MasterConstant.PropertyPartnerUpdate)
                        .AddParameter("@PropertyPartnerID", dtoObject.PropertyPartnerID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@PartnerID", dtoObject.PartnerID)
.AddParameter("@AddedOn", dtoObject.AddedOn)
.AddParameter("@PartnershipInPercentage", dtoObject.PartnershipInPercentage)
.AddParameter("@TotalToInvest", dtoObject.TotalToInvest)
.AddParameter("@TotalDue", dtoObject.TotalDue)
.AddParameter("@TotalInvested", dtoObject.TotalInvested)
.AddParameter("@PartnershipDissolveOn", dtoObject.PartnershipDissolveOn)
.AddParameter("@StatusTerm", dtoObject.StatusTerm)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@PartnerLegalName", dtoObject.PartnerLegalName)
.AddParameter("@Description", dtoObject.Description)

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

        public PropertyPartner SelectByPrimaryKey(Guid Keys)
        {
            PropertyPartner obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.PropertyPartnerSelectByPrimaryKey)
                            .AddParameter("@PropertyPartnerID"
, Keys)
                            .Fetch<PropertyPartner>();
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

        public List<PropertyPartner> CheckPropertyPartnerDuplication(Guid? PropertyID, Guid? PartnerID)
        {
            List<PropertyPartner> propertyPartners = new List<PropertyPartner>();

            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    propertyPartners = StoredProcedure(MasterConstant.PropertyPartnerCheckDuplication)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@PartnerID", PartnerID)
                                            .WithTransaction(dbtr)
                                            .FetchAll<PropertyPartner>();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return propertyPartners;
        }

        public DataSet SelectPropertyPartnerData(Guid? PropertyPartnerID, string PropertyName, Guid? CompanyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.PropertyPartnerSelectData)
                                            .AddParameter("@PropertyPartnerID", PropertyPartnerID)
                                            .AddParameter("@PropertyName", PropertyName)
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

        public bool Delete(PropertyPartner dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.PropertyPartnerDeleteByPrimaryKey)
                    .AddParameter("@PropertyPartnerID", dtoObject.PropertyPartnerID)

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
    }
}
