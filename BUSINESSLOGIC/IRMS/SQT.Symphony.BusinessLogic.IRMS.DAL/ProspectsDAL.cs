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
	/// Data access layer class for Prospects
	/// </summary>
	public class ProspectsDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public ProspectsDAL() :  base()
		{
			// Nothing for now.
		}
        public ProspectsDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public DataSet SearchInfo(string FName, string MobileNo, string Email, string CompanyName, string ProspectName, Guid? ProspectStatus, Guid? CompanyID, Guid? ProspectID, Guid? ContactedBy,string Location,string Reference,Guid? RegionID,Guid? ReferenceTermID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.ProspectsSearchData)
                    .AddParameter("@FName", FName)
                    .AddParameter("@MobileNo", MobileNo)
                    .AddParameter("@Email", Email)
                    .AddParameter("@CompanyName", CompanyName)
                    .AddParameter("@ProspectName", ProspectName)
                    .AddParameter("@ProspectStatus", ProspectStatus)
                    .AddParameter("@CompanyID", CompanyID)
                    .AddParameter("@ProspectID", ProspectID)
                    .AddParameter("@ContactedBy", ContactedBy)
                    .AddParameter("@Location", Location)
                    .AddParameter("@Reference", Reference)
                    .AddParameter("@RegionTermID",RegionID)
                    .AddParameter("@ReferenceTermID", ReferenceTermID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet rptProspectsList(string FName, string MobileNo, string Email, Guid? StatusID, string Country, string State, string City)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.ReportProspectsList)
                    .AddParameter("@FName", FName)
                    .AddParameter("@MobileNo", MobileNo)
                    .AddParameter("@Email", Email)
                    .AddParameter("@StatusID", StatusID)
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

        public List<Prospects> SelectAll(Prospects dtoObject)
        {
            List<Prospects> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.ProspectsSelectAll)
                                                .AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@ProspectID", dtoObject.ProspectID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@Reference", dtoObject.Reference)
.AddParameter("@StatusID", dtoObject.StatusID)
.AddParameter("@EMail", dtoObject.EMail)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@LandlineNo", dtoObject.LandlineNo)
.AddParameter("@Location", dtoObject.Location)
.AddParameter("@AddressID", dtoObject.AddressID)
.AddParameter("@OccupationTermID", dtoObject.OccupationTermID)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@ContactedBy", dtoObject.ContactedBy)
.AddParameter("@ContactedPersonType", dtoObject.ContactedPersonType)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsEmail", dtoObject.IsEmail)
.AddParameter("@IsSMS", dtoObject.IsSMS)
.AddParameter("@ManagerType", dtoObject.ManagerType)
.AddParameter("@RelationShipManagerID", dtoObject.RelationShipManagerID)
.AddParameter("@ManagerContactNo", dtoObject.ManagerContactNo)
.AddParameter("@ManagerEmail", dtoObject.ManagerEmail)
.AddParameter("@NameOfFirm", dtoObject.NameOfFirm)
.AddParameter("@RegionTermID", dtoObject.RegionTermID)
.AddParameter("@ReferenceTermID", dtoObject.ReferenceTermID)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Prospects>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ProspectsSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Prospects>();
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

        public List<Prospects> SelectAll()
        {
            List<Prospects> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.ProspectsSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Prospects>();
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
        public DataSet SelectAllWithDataSet(Prospects dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.ProspectsSelectAll)
                                                .AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@ProspectID", dtoObject.ProspectID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@Reference", dtoObject.Reference)
.AddParameter("@StatusID", dtoObject.StatusID)
.AddParameter("@EMail", dtoObject.EMail)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@LandlineNo", dtoObject.LandlineNo)
.AddParameter("@Location", dtoObject.Location)
.AddParameter("@AddressID", dtoObject.AddressID)
.AddParameter("@OccupationTermID", dtoObject.OccupationTermID)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@ContactedBy", dtoObject.ContactedBy)
.AddParameter("@ContactedPersonType", dtoObject.ContactedPersonType)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsEmail", dtoObject.IsEmail)
.AddParameter("@IsSMS", dtoObject.IsSMS)
.AddParameter("@ManagerType", dtoObject.ManagerType)
.AddParameter("@RelationShipManagerID", dtoObject.RelationShipManagerID)
.AddParameter("@ManagerContactNo", dtoObject.ManagerContactNo)
.AddParameter("@ManagerEmail", dtoObject.ManagerEmail)
.AddParameter("@NameOfFirm", dtoObject.NameOfFirm)
.AddParameter("@RegionTermID", dtoObject.RegionTermID)
.AddParameter("@ReferenceTermID", dtoObject.ReferenceTermID)
                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.ProspectsSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.ProspectsSelectAll)
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
		public bool Insert(Prospects dtoObject)
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

                    StoredProcedure(MasterDALConstant.ProspectsInsert)
                        .AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@ProspectID", dtoObject.ProspectID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@Reference", dtoObject.Reference)
.AddParameter("@StatusID", dtoObject.StatusID)
.AddParameter("@EMail", dtoObject.EMail)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@LandlineNo", dtoObject.LandlineNo)
.AddParameter("@Location", dtoObject.Location)
.AddParameter("@AddressID", dtoObject.AddressID)
.AddParameter("@OccupationTermID", dtoObject.OccupationTermID)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@ContactedBy", dtoObject.ContactedBy)
.AddParameter("@ContactedPersonType", dtoObject.ContactedPersonType)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@IsEmail", dtoObject.IsEmail)
.AddParameter("@IsSMS", dtoObject.IsSMS)
.AddParameter("@ManagerType", dtoObject.ManagerType)
.AddParameter("@RelationShipManagerID", dtoObject.RelationShipManagerID)
.AddParameter("@ManagerContactNo", dtoObject.ManagerContactNo)
.AddParameter("@ManagerEmail", dtoObject.ManagerEmail)
.AddParameter("@NameOfFirm", dtoObject.NameOfFirm)
.AddParameter("@RegionTermID", dtoObject.RegionTermID)
.AddParameter("@ReferenceTermID", dtoObject.ReferenceTermID)
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
        public bool Update(Prospects dtoObject)
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

                    StoredProcedure(MasterDALConstant.ProspectsUpdate)
                        .AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@ProspectID", dtoObject.ProspectID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@Reference", dtoObject.Reference)
.AddParameter("@StatusID", dtoObject.StatusID)
.AddParameter("@EMail", dtoObject.EMail)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@LandlineNo", dtoObject.LandlineNo)
.AddParameter("@Location", dtoObject.Location)
.AddParameter("@AddressID", dtoObject.AddressID)
.AddParameter("@OccupationTermID", dtoObject.OccupationTermID)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@ContactedBy", dtoObject.ContactedBy)
.AddParameter("@ContactedPersonType", dtoObject.ContactedPersonType)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsEmail", dtoObject.IsEmail)
.AddParameter("@IsSMS", dtoObject.IsSMS)
.AddParameter("@ManagerType", dtoObject.ManagerType)
.AddParameter("@RelationShipManagerID", dtoObject.RelationShipManagerID)
.AddParameter("@ManagerContactNo", dtoObject.ManagerContactNo)
.AddParameter("@ManagerEmail", dtoObject.ManagerEmail)
.AddParameter("@NameOfFirm", dtoObject.NameOfFirm)
.AddParameter("@RegionTermID", dtoObject.RegionTermID)
.AddParameter("@ReferenceTermID", dtoObject.ReferenceTermID)
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
                StoredProcedure(MasterDALConstant.ProspectsDeleteByPrimaryKey)
                    .AddParameter("@ProspectID"
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
        public bool Delete(Prospects dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.ProspectsDeleteByPrimaryKey)
                    .AddParameter("@ProspectID", dtoObject.ProspectID)

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

        public Prospects SelectByPrimaryKey(Guid Keys)
        {
            Prospects obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ProspectsSelectByPrimaryKey)
                            .AddParameter("@ProspectID"
,Keys)
                            .Fetch<Prospects>();
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
        public List<Prospects> SelectByField(string fieldName, object value)
        {
            List<Prospects> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.ProspectsSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Prospects>();

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
                obj = StoredProcedure(MasterDALConstant.ProspectsSelectByField) 
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
                StoredProcedure(MasterDALConstant.ProspectsDeleteByField) 
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
        public DataSet GetAllProspectsForEmailSubscription()
        {
            DataSet dst = new DataSet();
            try
            {
                dst = StoredProcedure(MasterDALConstant.ProspectsGetAllProspectsForEmailSubscription)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return dst;
        }

        public DataSet rptConversionExecutive(string ChannelParnerFirm, string ExecutiveName, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.ReportConversionExecutive)
                    .AddParameter("@ChannelPartnerFirm", ChannelParnerFirm)
                    .AddParameter("@ExecutiveName", ExecutiveName)
                    .AddParameter("@StartDate", StartDate)
                    .AddParameter("@EndDate", EndDate)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet rptConversionExecutive_CP(string ChannelParnerFirm, Guid? ChannelPartnerID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.ReportConversionExecutive_CP)
                    .AddParameter("@ChannelPartnerFirm", ChannelParnerFirm)
                    .AddParameter("@ChannelPartnerID", ChannelPartnerID)
                    .AddParameter("@StartDate", StartDate)
                    .AddParameter("@EndDate", EndDate)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet rptConversionExecutive_RefThrough(Guid? ReferenceThrough, string ReferenceName, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.ReportConversionExecutive_RefThrough)
                    .AddParameter("@ReferenceThrough", ReferenceThrough)
                    .AddParameter("@Reference", ReferenceName)
                    .AddParameter("@StartDate", StartDate)
                    .AddParameter("@EndDate", EndDate)
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
