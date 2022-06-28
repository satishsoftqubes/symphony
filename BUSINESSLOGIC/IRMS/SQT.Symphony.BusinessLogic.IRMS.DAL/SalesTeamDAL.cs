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
	/// Data access layer class for SalesTeam
	/// </summary>
	public class SalesTeamDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public SalesTeamDAL() :  base()
		{
			// Nothing for now.
		}
        public SalesTeamDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get Search Data Here
        /// </summary>
        /// <param name="FullName"></param>
        /// <returns></returns>
        public DataSet GetSearchData(string DisplayName)
        {
            DataSet dst = new DataSet();
            try
            {
                dst = Query(DisplayName)
                            .WithTransaction(dbtr)
                            .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return dst;
        }
        public DataSet rptSalesList(Guid? SalesTeamID, string FName, string MobileNo, string Email, string DisplayName, string Country, string State, string City)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.ReportSalesList)
                    .AddParameter("@SalesTeamID", SalesTeamID)
                    .AddParameter("@FName", FName)
                    .AddParameter("@MobileNo", MobileNo)
                    .AddParameter("@Email", Email)
                    .AddParameter("@DisplayName", DisplayName)
                    .AddParameter("@CountryID", Country)
                    .AddParameter("@StateID", State)
                    .AddParameter("@CityID", City)                    
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }
    
        public List<SalesTeam> SelectAll(SalesTeam dtoObject)
        {
            List<SalesTeam> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.SalesTeamSelectAll)
                                                .AddParameter("@SalesTeamID", dtoObject.SalesTeamID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@DisplayName", dtoObject.DisplayName)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@LandLineNo", dtoObject.LandLineNo)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@AddressID", dtoObject.AddressID)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@CompanyID", dtoObject.CompanyID)

                                                .WithTransaction(dbtr)
                                                .FetchAll<SalesTeam>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.SalesTeamSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<SalesTeam>();
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

        public List<SalesTeam> SelectAll()
        {
            List<SalesTeam> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.SalesTeamSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<SalesTeam>();
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
        public DataSet SelectAllWithDataSet(SalesTeam dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.SalesTeamSelectAll)
                                                .AddParameter("@SalesTeamID", dtoObject.SalesTeamID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@DisplayName", dtoObject.DisplayName)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@LandLineNo", dtoObject.LandLineNo)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@AddressID", dtoObject.AddressID)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@CompanyID", dtoObject.CompanyID)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.SalesTeamSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.SalesTeamSelectAll)
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
		public bool Insert(SalesTeam dtoObject)
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

                    StoredProcedure(MasterDALConstant.SalesTeamInsert)
                        .AddParameter("@SalesTeamID", dtoObject.SalesTeamID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@DisplayName", dtoObject.DisplayName)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@LandLineNo", dtoObject.LandLineNo)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@AddressID", dtoObject.AddressID)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@CompanyID", dtoObject.CompanyID)

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
        public bool Update(SalesTeam dtoObject)
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

                    StoredProcedure(MasterDALConstant.SalesTeamUpdate)
                        .AddParameter("@SalesTeamID", dtoObject.SalesTeamID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@DisplayName", dtoObject.DisplayName)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@LandLineNo", dtoObject.LandLineNo)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@AddressID", dtoObject.AddressID)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@CompanyID", dtoObject.CompanyID)

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
                StoredProcedure(MasterDALConstant.SalesTeamDeleteByPrimaryKey)
                    .AddParameter("@SalesTeamID"
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
        public bool Delete(SalesTeam dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.SalesTeamDeleteByPrimaryKey)
                    .AddParameter("@SalesTeamID", dtoObject.SalesTeamID)

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

        public SalesTeam SelectByPrimaryKey(Guid Keys)
        {
            SalesTeam obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.SalesTeamSelectByPrimaryKey)
                            .AddParameter("@SalesTeamID"
,Keys)
                            .Fetch<SalesTeam>();
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
        public List<SalesTeam> SelectByField(string fieldName, object value)
        {
            List<SalesTeam> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.SalesTeamSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<SalesTeam>();

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
                obj = StoredProcedure(MasterDALConstant.SalesTeamSelectByField) 
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
                StoredProcedure(MasterDALConstant.SalesTeamDeleteByField) 
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

        public DataSet GetAllSalesTeamForEmailSubscription()
        {
            DataSet dst = new DataSet();
            try
            {
                dst = StoredProcedure(MasterDALConstant.SalesTeamGetAllSalesForEmailSubscription)
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
