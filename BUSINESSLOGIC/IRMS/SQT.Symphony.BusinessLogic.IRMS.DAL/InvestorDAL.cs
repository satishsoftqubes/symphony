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
    /// Data access layer class for Investor
    /// </summary>
    public class InvestorDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public InvestorDAL()
            : base()
        {
            // Nothing for now.
        }
        public InvestorDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods

        public DataSet SearchInfo(string FName, string MobileNo, string Email, string InvestorName, string CompanyName, Guid? CompanyID, Guid? RelationShipManagerID, string Location)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.InvestorSearchData)
                    .AddParameter("@FName", FName)
                    .AddParameter("@MobileNo", MobileNo)
                    .AddParameter("@Email", Email)
                    .AddParameter("@InvestorName", InvestorName)
                    .AddParameter("@CompanyName", CompanyName)
                    .AddParameter("@CompanyID", CompanyID)
                    .AddParameter("@RelationShipManagerID", RelationShipManagerID)
                    .AddParameter("@Location", Location)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet NewSearchInfo(string investorName, string location, string firmName, string executiveName, Guid? companyID, string Alphabet)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.InvestorNewSearchData)
                    .AddParameter("@InvestorName", investorName)
                    .AddParameter("@Location", location)
                    .AddParameter("@FirmName", firmName)
                    .AddParameter("@ExecutiveName", executiveName)
                    .AddParameter("@CompanyID", companyID)
                    .AddParameter("@Alphabet", Alphabet)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet rptInvestorList(string FName, string MobileNo, string Email, Guid? OccupationID, string Country, string State, string City, string CompanyName, Guid? RelationShipManagerID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.ReportInvestorList)
                    .AddParameter("@FName", FName)
                    .AddParameter("@MobileNo", MobileNo)
                    .AddParameter("@EMail", Email)
                    .AddParameter("@OccupationTermID", OccupationID)
                    .AddParameter("@CountryID", Country)
                    .AddParameter("@StateID", State)
                    .AddParameter("@CityID", City)
                    .AddParameter("@CompanyName", CompanyName)
                    .AddParameter("@RelationShipManagerID", RelationShipManagerID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        /// <summary>
        /// Get Investor Payment List
        /// </summary>
        /// <param name="InvestorID"></param>
        /// <returns></returns>
        public DataSet InvestorGetPaymentList(Guid? InvestorID, Guid? InvestorRoomID, string PropertyName, string RoomNo)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.InvestorGetPaymentList)
                    .AddParameter("@InvesterID", InvestorID)
                    .AddParameter("@InvestorRoomID", InvestorRoomID)
                    .AddParameter("@PropertyName", PropertyName)
                    .AddParameter("@RoomNo", RoomNo)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        /// <summary>
        /// Get Investor Payment Schedule Detail
        /// </summary>
        /// <param name="InvestorID"></param>
        /// <returns></returns>
        public DataSet InvestorGetPaymentScheduleDetail(Guid? InvestorRoomID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.InvestorGetPaymentScheduleDetail)
                    .AddParameter("@InvestorRoomID", InvestorRoomID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

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
        /// <summary>
        /// Get Search Data Here
        /// </summary>
        /// <param name="FullName"></param>
        /// <returns></returns>
        public string ExecutateQuery(string DisplayName)
        {
            try
            {
                Query(DisplayName)
                            .WithTransaction(dbtr)
                            .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return "a";
        }
        public List<Investor> SelectAll(Investor dtoObject)
        {
            List<Investor> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.InvestorSelectAll)
                                                .AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@RefInverstorID", dtoObject.RefInverstorID)
.AddParameter("@Age", dtoObject.Age)
.AddParameter("@PanNo", dtoObject.PanNo)
.AddParameter("@POAHolder", dtoObject.POAHolder)
.AddParameter("@AgreementAddressID", dtoObject.AgreementAddressID)
.AddParameter("@PostalAddressID", dtoObject.PostalAddressID)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@LandLineNo", dtoObject.LandLineNo)
.AddParameter("@EMail", dtoObject.EMail)
.AddParameter("@BankName", dtoObject.BankName)
.AddParameter("@AccountNo", dtoObject.AccountNo)
.AddParameter("@OccupationTermID", dtoObject.OccupationTermID)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@Designation", dtoObject.Designation)
.AddParameter("@RelationShipManagerID", dtoObject.RelationShipManagerID)
.AddParameter("@ManagerType", dtoObject.ManagerType)
.AddParameter("@NameOfFirm", dtoObject.NameOfFirm)
.AddParameter("@ManagerContactNo", dtoObject.ManagerContactNo)
.AddParameter("@ManagerEmail", dtoObject.ManagerEmail)
.AddParameter("@UniworldPrime", dtoObject.UniworldPrime)
.AddParameter("@PrimeMobileNo", dtoObject.PrimeMobileNo)
.AddParameter("@PrimeEmail", dtoObject.PrimeEmail)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@InvestorTypeID", dtoObject.InvestorTypeID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@RelationsOf", dtoObject.RelationsOf)
.AddParameter("@RelationalName", dtoObject.RelationalName)
.AddParameter("@ContactPersonName", dtoObject.ContactPersonName)
.AddParameter("@ContactPersonEmail", dtoObject.ContactPersonEmail)
.AddParameter("@ContactPersonMobile", dtoObject.ContactPersonMobile)
.AddParameter("@IsEmail", dtoObject.IsEmail)
.AddParameter("@IsSMS", dtoObject.IsSMS)
.AddParameter("@Reference", dtoObject.Reference)
.AddParameter("@RegionTermID", dtoObject.RegionTermID)
.AddParameter("@ReferenceTermID", dtoObject.ReferenceTermID)
.AddParameter("@IFSCCode", dtoObject.IFSCCode)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Investor>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.InvestorSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Investor>();
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

        public List<Investor> SelectAll()
        {
            List<Investor> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.InvestorSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Investor>();
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
        public DataSet SelectAllWithDataSet(Investor dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.InvestorSelectAll)
                                                .AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@RefInverstorID", dtoObject.RefInverstorID)
.AddParameter("@Age", dtoObject.Age)
.AddParameter("@PanNo", dtoObject.PanNo)
.AddParameter("@POAHolder", dtoObject.POAHolder)
.AddParameter("@AgreementAddressID", dtoObject.AgreementAddressID)
.AddParameter("@PostalAddressID", dtoObject.PostalAddressID)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@LandLineNo", dtoObject.LandLineNo)
.AddParameter("@EMail", dtoObject.EMail)
.AddParameter("@BankName", dtoObject.BankName)
.AddParameter("@AccountNo", dtoObject.AccountNo)
.AddParameter("@OccupationTermID", dtoObject.OccupationTermID)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@Designation", dtoObject.Designation)
.AddParameter("@RelationShipManagerID", dtoObject.RelationShipManagerID)
.AddParameter("@ManagerType", dtoObject.ManagerType)
.AddParameter("@NameOfFirm", dtoObject.NameOfFirm)
.AddParameter("@ManagerContactNo", dtoObject.ManagerContactNo)
.AddParameter("@ManagerEmail", dtoObject.ManagerEmail)
.AddParameter("@UniworldPrime", dtoObject.UniworldPrime)
.AddParameter("@PrimeMobileNo", dtoObject.PrimeMobileNo)
.AddParameter("@PrimeEmail", dtoObject.PrimeEmail)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@InvestorTypeID", dtoObject.InvestorTypeID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@RelationsOf", dtoObject.RelationsOf)
.AddParameter("@RelationalName", dtoObject.RelationalName)
.AddParameter("@ContactPersonName", dtoObject.ContactPersonName)
.AddParameter("@ContactPersonEmail", dtoObject.ContactPersonEmail)
.AddParameter("@ContactPersonMobile", dtoObject.ContactPersonMobile)
.AddParameter("@IsEmail", dtoObject.IsEmail)
.AddParameter("@IsSMS", dtoObject.IsSMS)
.AddParameter("@Reference", dtoObject.Reference)
.AddParameter("@RegionTermID", dtoObject.RegionTermID)
.AddParameter("@ReferenceTermID", dtoObject.ReferenceTermID)
.AddParameter("@IFSCCode", dtoObject.IFSCCode)
                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.InvestorSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.InvestorSelectAll)
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
        public bool Insert(Investor dtoObject)
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

                    StoredProcedure(MasterDALConstant.InvestorInsert)
                        .AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@RefInverstorID", dtoObject.RefInverstorID)
.AddParameter("@Age", dtoObject.Age)
.AddParameter("@PanNo", dtoObject.PanNo)
.AddParameter("@POAHolder", dtoObject.POAHolder)
.AddParameter("@AgreementAddressID", dtoObject.AgreementAddressID)
.AddParameter("@PostalAddressID", dtoObject.PostalAddressID)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@LandLineNo", dtoObject.LandLineNo)
.AddParameter("@EMail", dtoObject.EMail)
.AddParameter("@BankName", dtoObject.BankName)
.AddParameter("@AccountNo", dtoObject.AccountNo)
.AddParameter("@OccupationTermID", dtoObject.OccupationTermID)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@Designation", dtoObject.Designation)
.AddParameter("@RelationShipManagerID", dtoObject.RelationShipManagerID)
.AddParameter("@ManagerType", dtoObject.ManagerType)
.AddParameter("@NameOfFirm", dtoObject.NameOfFirm)
.AddParameter("@ManagerContactNo", dtoObject.ManagerContactNo)
.AddParameter("@ManagerEmail", dtoObject.ManagerEmail)
.AddParameter("@UniworldPrime", dtoObject.UniworldPrime)
.AddParameter("@PrimeMobileNo", dtoObject.PrimeMobileNo)
.AddParameter("@PrimeEmail", dtoObject.PrimeEmail)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@InvestorTypeID", dtoObject.InvestorTypeID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@RelationsOf", dtoObject.RelationsOf)
.AddParameter("@RelationalName", dtoObject.RelationalName)
.AddParameter("@ContactPersonName", dtoObject.ContactPersonName)
.AddParameter("@ContactPersonEmail", dtoObject.ContactPersonEmail)
.AddParameter("@ContactPersonMobile", dtoObject.ContactPersonMobile)
.AddParameter("@IsEmail", dtoObject.IsEmail)
.AddParameter("@IsSMS", dtoObject.IsSMS)
.AddParameter("@Reference", dtoObject.Reference)
.AddParameter("@RegionTermID", dtoObject.RegionTermID)
.AddParameter("@ReferenceTermID", dtoObject.ReferenceTermID)
.AddParameter("@IFSCCode", dtoObject.IFSCCode)
.AddParameter("@DateOfBirth", dtoObject.DateOfBirth)
.AddParameter("@CoOrdinatorInvestorID", dtoObject.CoOrdinatorInvestorID)
.AddParameter("@BankAcctName", dtoObject.BankAcctName)
.AddParameter("@BankBranchName", dtoObject.BankBranchName)
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
        public bool Update(Investor dtoObject)
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

                    StoredProcedure(MasterDALConstant.InvestorUpdate)
                        .AddParameter("@InvestorID", dtoObject.InvestorID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@RefInverstorID", dtoObject.RefInverstorID)
.AddParameter("@Age", dtoObject.Age)
.AddParameter("@PanNo", dtoObject.PanNo)
.AddParameter("@POAHolder", dtoObject.POAHolder)
.AddParameter("@AgreementAddressID", dtoObject.AgreementAddressID)
.AddParameter("@PostalAddressID", dtoObject.PostalAddressID)
.AddParameter("@MobileNo", dtoObject.MobileNo)
.AddParameter("@LandLineNo", dtoObject.LandLineNo)
.AddParameter("@EMail", dtoObject.EMail)
.AddParameter("@BankName", dtoObject.BankName)
.AddParameter("@AccountNo", dtoObject.AccountNo)
.AddParameter("@OccupationTermID", dtoObject.OccupationTermID)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@Designation", dtoObject.Designation)
.AddParameter("@RelationShipManagerID", dtoObject.RelationShipManagerID)
.AddParameter("@ManagerType", dtoObject.ManagerType)
.AddParameter("@NameOfFirm", dtoObject.NameOfFirm)
.AddParameter("@ManagerContactNo", dtoObject.ManagerContactNo)
.AddParameter("@ManagerEmail", dtoObject.ManagerEmail)
.AddParameter("@UniworldPrime", dtoObject.UniworldPrime)
.AddParameter("@PrimeMobileNo", dtoObject.PrimeMobileNo)
.AddParameter("@PrimeEmail", dtoObject.PrimeEmail)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@UserID", dtoObject.UserID)
.AddParameter("@InvestorTypeID", dtoObject.InvestorTypeID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@RelationsOf", dtoObject.RelationsOf)
.AddParameter("@RelationalName", dtoObject.RelationalName)
.AddParameter("@ContactPersonName", dtoObject.ContactPersonName)
.AddParameter("@ContactPersonEmail", dtoObject.ContactPersonEmail)
.AddParameter("@ContactPersonMobile", dtoObject.ContactPersonMobile)
.AddParameter("@IsEmail", dtoObject.IsEmail)
.AddParameter("@IsSMS", dtoObject.IsSMS)
.AddParameter("@Reference", dtoObject.Reference)
.AddParameter("@RegionTermID", dtoObject.RegionTermID)
.AddParameter("@ReferenceTermID", dtoObject.ReferenceTermID)
.AddParameter("@IFSCCode", dtoObject.IFSCCode)
.AddParameter("@DateOfBirth", dtoObject.DateOfBirth)
.AddParameter("@CoOrdinatorInvestorID", dtoObject.CoOrdinatorInvestorID)
.AddParameter("@BankAcctName", dtoObject.BankAcctName)
.AddParameter("@BankBranchName", dtoObject.BankBranchName)
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
                StoredProcedure(MasterDALConstant.InvestorDeleteByPrimaryKey)
                    .AddParameter("@InvestorID"
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
        public bool Delete(Investor dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.InvestorDeleteByPrimaryKey)
                    .AddParameter("@InvestorID", dtoObject.InvestorID)

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

        public Investor SelectByPrimaryKey(Guid Keys)
        {
            Investor obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.InvestorSelectByPrimaryKey)
                            .AddParameter("@InvestorID"
, Keys)
                            .Fetch<Investor>();
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
        public List<Investor> SelectByField(string fieldName, object value)
        {
            List<Investor> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.InvestorSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Investor>();

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
                obj = StoredProcedure(MasterDALConstant.InvestorSelectByField)
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
                StoredProcedure(MasterDALConstant.InvestorDeleteByField)
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
        /// Public Get Invesotr For Email Subscriptions
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllInvestorForEmailSubscription()
        {
            DataSet dst = new DataSet();
            try
            {
                dst = StoredProcedure(MasterDALConstant.InvestorGetAllInvestorForEmailSubscription)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return dst;
        }


        public DataSet rptTotalSales(Guid? PropertyID, Guid? ReferenceThrough, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.ReprotTotalSalses)
                    .AddParameter("@PropertyID", PropertyID)
                    .AddParameter("@ReferenceThrough", ReferenceThrough)
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

        public DataSet rptInvestorBankDetail(Guid? InvestorID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.ReportInvestorBankDetail)
                    .AddParameter("@InvestorID", InvestorID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet SelectAllInvestorsForActiveInActive(string investorName, string location, string firmName, string status, Guid? companyID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.InvestorGetAllInvestorForActiveInactive)
                    .AddParameter("@InvestorName", investorName)
                    .AddParameter("@Location", location)
                    .AddParameter("@FirmName", firmName)
                    .AddParameter("@Status", status)
                    .AddParameter("@CompanyID", companyID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet SelectForInvestorUpdateIndication(Guid investorID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.InvestorSelectForInvestorUpdateIndication)
                    .AddParameter("@InvestorID", investorID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet GetCoOrdinators(string OperationType, Guid? investorID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.InvestorSelectGetCoOrdinators)
                    .AddParameter("@OperationType", OperationType)
                    .AddParameter("@InvestorID", investorID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet GetAllInvestorsForFrontDesk(Guid CompanyID, Guid? InvestorID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.InvestorSelectInvestorsForFrontDesk)
                    .AddParameter("@CompanyID", CompanyID)
                    .AddParameter("@InvestorID", InvestorID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }
        public DataSet SelectInvestorEmailAddress(Guid CompanyID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.InvestorSelectInvestorEmailAddress)
                    .AddParameter("@CompanyID", CompanyID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }
        public DataSet SelectInvestorDetailReport(Guid CompanyID, Guid? InvestorID, string BankName)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterDALConstant.InvestorDetailsReportData)
                     .AddParameter("@CompanyID", CompanyID)
                    .AddParameter("@InvestorID", InvestorID)
                    .AddParameter("@BankName", BankName)
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
