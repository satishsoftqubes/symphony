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
	/// Data access layer class for ChannelPartner
	/// </summary>
	public class ChannelPartnerDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public ChannelPartnerDAL() :  base()
		{
			// Nothing for now.
		}
        public ChannelPartnerDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public DataSet SearchInfo(string FName, string MobileNo, string Email, string CompanyName, string Name, Guid? CompanyID, Guid? CreatedBy, string Location)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.ChannelPartnerSearchData)
                    .AddParameter("@DisplayName", FName)
                    .AddParameter("@MobileNo", MobileNo)
                    .AddParameter("@Email", Email)
                    .AddParameter("@CompanyName", CompanyName)
                    .AddParameter("@Name", Name)
                    .AddParameter("@CompanyID", CompanyID)
                    .AddParameter("@CreatedBy", CreatedBy)
                    .AddParameter("@Location", Location)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet SelectAllForUserStatus(string FName, string MobileNo, string Email, string CompanyName, string Name, Guid? CompanyID, Guid? CreatedBy, string Location, string Status)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.ChannelPartnerSelectAllForUserStatus)
                    .AddParameter("@DisplayName", FName)
                    .AddParameter("@MobileNo", MobileNo)
                    .AddParameter("@Email", Email)
                    .AddParameter("@CompanyName", CompanyName)
                    .AddParameter("@Name", Name)
                    .AddParameter("@CompanyID", CompanyID)
                    .AddParameter("@CreatedBy", CreatedBy)
                    .AddParameter("@Location", Location)
                    .AddParameter("@Status", Status)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet rptChannelPartnerList(string FName, string MobileNo, string Email, string CompanyName, string Country, string State, string City, Guid? CreatedBy)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.ReportChannelPartnerList)
                    .AddParameter("@FName", FName)
                    .AddParameter("@MobileNo", MobileNo)
                    .AddParameter("@Email", Email)
                    .AddParameter("@CompanyName", CompanyName)
                    .AddParameter("@CountryID", Country)
                    .AddParameter("@StateID", State)
                    .AddParameter("@CityID", City)           
                    .AddParameter("@CreatedBy", CreatedBy)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public List<ChannelPartner> SelectAll(ChannelPartner dtoObject)
        {
            List<ChannelPartner> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.ChannelPartnerSelectAll)
                                                .AddParameter("@ChannelPartnerID", dtoObject.ChannelPartnerID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@DisplayName", dtoObject.DisplayName)
.AddParameter("@CompanyName", dtoObject.CompanyName)
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
.AddParameter("@DisplayNameOfFirm", dtoObject.DisplayNameOfFirm)

                                                .WithTransaction(dbtr)
                                                .FetchAll<ChannelPartner>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ChannelPartnerSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<ChannelPartner>();
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

        public List<ChannelPartner> SelectAll()
        {
            List<ChannelPartner> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.ChannelPartnerSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<ChannelPartner>();
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
        public DataSet SelectAllWithDataSet(ChannelPartner dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.ChannelPartnerSelectAll)
                                                .AddParameter("@ChannelPartnerID", dtoObject.ChannelPartnerID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@DisplayName", dtoObject.DisplayName)
.AddParameter("@CompanyName", dtoObject.CompanyName)
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
.AddParameter("@DisplayNameOfFirm", dtoObject.DisplayNameOfFirm)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ChannelPartnerSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.ChannelPartnerSelectAll)
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
		public bool Insert(ChannelPartner dtoObject)
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

                    StoredProcedure(MasterDALConstant.ChannelPartnerInsert)
                        .AddParameter("@ChannelPartnerID", dtoObject.ChannelPartnerID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@DisplayName", dtoObject.DisplayName)
.AddParameter("@CompanyName", dtoObject.CompanyName)
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
.AddParameter("@DisplayNameOfFirm", dtoObject.DisplayNameOfFirm)

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
        public bool Update(ChannelPartner dtoObject)
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

                    StoredProcedure(MasterDALConstant.ChannelPartnerUpdate)
                        .AddParameter("@ChannelPartnerID", dtoObject.ChannelPartnerID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@DisplayName", dtoObject.DisplayName)
.AddParameter("@CompanyName", dtoObject.CompanyName)
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
.AddParameter("@DisplayNameOfFirm", dtoObject.DisplayNameOfFirm)

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
                StoredProcedure(MasterDALConstant.ChannelPartnerDeleteByPrimaryKey)
                    .AddParameter("@ChannelPartnerID"
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
        public bool Delete(ChannelPartner dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.ChannelPartnerDeleteByPrimaryKey)
                    .AddParameter("@ChannelPartnerID", dtoObject.ChannelPartnerID)

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

        public ChannelPartner SelectByPrimaryKey(Guid Keys)
        {
            ChannelPartner obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ChannelPartnerSelectByPrimaryKey)
                            .AddParameter("@ChannelPartnerID"
,Keys)
                            .Fetch<ChannelPartner>();
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
        public List<ChannelPartner> SelectByField(string fieldName, object value)
        {
            List<ChannelPartner> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ChannelPartnerSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<ChannelPartner>();

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
                obj = StoredProcedure(MasterDALConstant.ChannelPartnerSelectByField) 
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
                StoredProcedure(MasterDALConstant.ChannelPartnerDeleteByField) 
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

        public DataSet GetAllChannelPartnerForEmailSubscription()
        {
            DataSet dst = new DataSet();
            try
            {
                dst = StoredProcedure(MasterDALConstant.ChannelPartnerGetAllChannelPartnerForEmailSubscription)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return dst;
        }

        public DataSet SelectDeletePermission(Guid? UserID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.ChannelPartnerSelectDeletePermission)
                    .AddParameter("@UserID", UserID)                    
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        #endregion
	}
}
