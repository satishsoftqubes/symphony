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
using SQT.Symphony.BusinessLogic.FrontDesk.DTO;
using SQT.Symphony.BusinessLogic.FrontDesk.COMMON;

namespace SQT.Symphony.BusinessLogic.FrontDesk.DAL
{
    /// <summary> 
    /// Data access layer class for Guest
    /// </summary>
    public class GuestDAL : LinqDAL
    {

        DbTransaction dbtr = null;
        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public GuestDAL()
            : base()
        {
            // Nothing for now.
        }
        public GuestDAL(DbTransaction DbTr)
            : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Guest> SelectAll(Guest dtoObject)
        {
            List<Guest> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.GuestSelectAll)
                                                .AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@Guest_TypeID", dtoObject.Guest_TypeID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@GuestFullName", dtoObject.GuestFullName)
.AddParameter("@MName", dtoObject.MName)
.AddParameter("@DOB", dtoObject.DOB)
.AddParameter("@Nationality", dtoObject.Nationality)
.AddParameter("@IDType1_TermID", dtoObject.IDType1_TermID)
.AddParameter("@IDType1", dtoObject.IDType1)
.AddParameter("@IDType2_TermID", dtoObject.IDType2_TermID)
.AddParameter("@IDType2", dtoObject.IDType2)
.AddParameter("@ScanID1", dtoObject.ScanID1)
.AddParameter("@ScanID2", dtoObject.ScanID2)
.AddParameter("@MaritalStatus_TermID", dtoObject.MaritalStatus_TermID)
.AddParameter("@AnniversaryDate", dtoObject.AnniversaryDate)
.AddParameter("@Gender_TermID", dtoObject.Gender_TermID)
.AddParameter("@Occupation_TermID", dtoObject.Occupation_TermID)
.AddParameter("@JobTitle", dtoObject.JobTitle)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@StaffReferenceID", dtoObject.StaffReferenceID)
.AddParameter("@GuestReferenceID", dtoObject.GuestReferenceID)
.AddParameter("@IsByReference", dtoObject.IsByReference)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@Phone1", dtoObject.Phone1)
.AddParameter("@Phone2", dtoObject.Phone2)
.AddParameter("@FavouriteRoomID", dtoObject.FavouriteRoomID)
.AddParameter("@GuestPhoto", dtoObject.GuestPhoto)
.AddParameter("@GuestNotes", dtoObject.GuestNotes)
.AddParameter("@OtherNotes", dtoObject.OtherNotes)
.AddParameter("@IsBlocked", dtoObject.IsBlocked)
.AddParameter("@BlockReason", dtoObject.BlockReason)
.AddParameter("@LastArrivalDate", dtoObject.LastArrivalDate)
.AddParameter("@LastReservationID", dtoObject.LastReservationID)
.AddParameter("@IsMainGuest", dtoObject.IsMainGuest)
.AddParameter("@LastRateID", dtoObject.LastRateID)
.AddParameter("@LastRate", dtoObject.LastRate)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@TotalNight", dtoObject.TotalNight)
.AddParameter("@BlockBy", dtoObject.BlockBy)
.AddParameter("@BlockOn", dtoObject.BlockOn)
.AddParameter("@IsSmoking", dtoObject.IsSmoking)
.AddParameter("@CompanySector", dtoObject.CompanySector)
.AddParameter("@WorkLocation", dtoObject.WorkLocation)
.AddParameter("@WorkTiming", dtoObject.WorkTiming)
.AddParameter("@BloodGroup", dtoObject.BloodGroup)
.AddParameter("@MealPreference", dtoObject.MealPreference)
.AddParameter("@ParentName", dtoObject.ParentName)
.AddParameter("@ParentContactNo", dtoObject.ParentContactNo)
.AddParameter("@RefInvestorID", dtoObject.RefInvestorID)
.AddParameter("@AddressID", dtoObject.AddressID)
.AddParameter("@LocalContactPerson", dtoObject.LocalContactPerson)
.AddParameter("@LocalContactNo", dtoObject.LocalContactNo)
.AddParameter("@EmployeeID", dtoObject.EmployeeID)
.AddParameter("@Department", dtoObject.Department)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Guest>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.GuestSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Guest>();
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

        public List<Guest> SelectAll()
        {
            List<Guest> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.GuestSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Guest>();
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
        public DataSet SelectAllWithDataSet(Guest dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.GuestSelectAll)
                                                .AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@Guest_TypeID", dtoObject.Guest_TypeID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@GuestFullName", dtoObject.GuestFullName)
.AddParameter("@MName", dtoObject.MName)
.AddParameter("@DOB", dtoObject.DOB)
.AddParameter("@Nationality", dtoObject.Nationality)
.AddParameter("@IDType1_TermID", dtoObject.IDType1_TermID)
.AddParameter("@IDType1", dtoObject.IDType1)
.AddParameter("@IDType2_TermID", dtoObject.IDType2_TermID)
.AddParameter("@IDType2", dtoObject.IDType2)
.AddParameter("@ScanID1", dtoObject.ScanID1)
.AddParameter("@ScanID2", dtoObject.ScanID2)
.AddParameter("@MaritalStatus_TermID", dtoObject.MaritalStatus_TermID)
.AddParameter("@AnniversaryDate", dtoObject.AnniversaryDate)
.AddParameter("@Gender_TermID", dtoObject.Gender_TermID)
.AddParameter("@Occupation_TermID", dtoObject.Occupation_TermID)
.AddParameter("@JobTitle", dtoObject.JobTitle)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@StaffReferenceID", dtoObject.StaffReferenceID)
.AddParameter("@GuestReferenceID", dtoObject.GuestReferenceID)
.AddParameter("@IsByReference", dtoObject.IsByReference)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@Phone1", dtoObject.Phone1)
.AddParameter("@Phone2", dtoObject.Phone2)
.AddParameter("@FavouriteRoomID", dtoObject.FavouriteRoomID)
.AddParameter("@GuestPhoto", dtoObject.GuestPhoto)
.AddParameter("@GuestNotes", dtoObject.GuestNotes)
.AddParameter("@OtherNotes", dtoObject.OtherNotes)
.AddParameter("@IsBlocked", dtoObject.IsBlocked)
.AddParameter("@BlockReason", dtoObject.BlockReason)
.AddParameter("@LastArrivalDate", dtoObject.LastArrivalDate)
.AddParameter("@LastReservationID", dtoObject.LastReservationID)
.AddParameter("@IsMainGuest", dtoObject.IsMainGuest)
.AddParameter("@LastRateID", dtoObject.LastRateID)
.AddParameter("@LastRate", dtoObject.LastRate)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@TotalNight", dtoObject.TotalNight)
.AddParameter("@BlockBy", dtoObject.BlockBy)
.AddParameter("@BlockOn", dtoObject.BlockOn)
.AddParameter("@IsSmoking", dtoObject.IsSmoking)
.AddParameter("@CompanySector", dtoObject.CompanySector)
.AddParameter("@WorkLocation", dtoObject.WorkLocation)
.AddParameter("@WorkTiming", dtoObject.WorkTiming)
.AddParameter("@BloodGroup", dtoObject.BloodGroup)
.AddParameter("@MealPreference", dtoObject.MealPreference)
.AddParameter("@ParentName", dtoObject.ParentName)
.AddParameter("@ParentContactNo", dtoObject.ParentContactNo)
.AddParameter("@RefInvestorID", dtoObject.RefInvestorID)
.AddParameter("@AddressID", dtoObject.AddressID)
.AddParameter("@LocalContactPerson", dtoObject.LocalContactPerson)
.AddParameter("@LocalContactNo", dtoObject.LocalContactNo)
.AddParameter("@EmployeeID", dtoObject.EmployeeID)
.AddParameter("@Department", dtoObject.Department)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.GuestSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.GuestSelectAll)
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
        public bool Insert(Guest dtoObject)
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

                    StoredProcedure(MasterDALConstant.GuestInsert)
                        .AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@Guest_TypeID", dtoObject.Guest_TypeID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@GuestFullName", dtoObject.GuestFullName)
.AddParameter("@MName", dtoObject.MName)
.AddParameter("@DOB", dtoObject.DOB)
.AddParameter("@Nationality", dtoObject.Nationality)
.AddParameter("@IDType1_TermID", dtoObject.IDType1_TermID)
.AddParameter("@IDType1", dtoObject.IDType1)
.AddParameter("@IDType2_TermID", dtoObject.IDType2_TermID)
.AddParameter("@IDType2", dtoObject.IDType2)
.AddParameter("@ScanID1", dtoObject.ScanID1)
.AddParameter("@ScanID2", dtoObject.ScanID2)
.AddParameter("@MaritalStatus_TermID", dtoObject.MaritalStatus_TermID)
.AddParameter("@AnniversaryDate", dtoObject.AnniversaryDate)
.AddParameter("@Gender_TermID", dtoObject.Gender_TermID)
.AddParameter("@Occupation_TermID", dtoObject.Occupation_TermID)
.AddParameter("@JobTitle", dtoObject.JobTitle)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@StaffReferenceID", dtoObject.StaffReferenceID)
.AddParameter("@GuestReferenceID", dtoObject.GuestReferenceID)
.AddParameter("@IsByReference", dtoObject.IsByReference)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@Phone1", dtoObject.Phone1)
.AddParameter("@Phone2", dtoObject.Phone2)
.AddParameter("@FavouriteRoomID", dtoObject.FavouriteRoomID)
.AddParameter("@GuestPhoto", dtoObject.GuestPhoto)
.AddParameter("@GuestNotes", dtoObject.GuestNotes)
.AddParameter("@OtherNotes", dtoObject.OtherNotes)
.AddParameter("@IsBlocked", dtoObject.IsBlocked)
.AddParameter("@BlockReason", dtoObject.BlockReason)
.AddParameter("@LastArrivalDate", dtoObject.LastArrivalDate)
.AddParameter("@LastReservationID", dtoObject.LastReservationID)
.AddParameter("@IsMainGuest", dtoObject.IsMainGuest)
.AddParameter("@LastRateID", dtoObject.LastRateID)
.AddParameter("@LastRate", dtoObject.LastRate)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@TotalNight", dtoObject.TotalNight)
.AddParameter("@BlockBy", dtoObject.BlockBy)
.AddParameter("@BlockOn", dtoObject.BlockOn)
.AddParameter("@IsSmoking", dtoObject.IsSmoking)
.AddParameter("@CompanySector", dtoObject.CompanySector)
.AddParameter("@WorkLocation", dtoObject.WorkLocation)
.AddParameter("@WorkTiming", dtoObject.WorkTiming)
.AddParameter("@BloodGroup", dtoObject.BloodGroup)
.AddParameter("@MealPreference", dtoObject.MealPreference)
.AddParameter("@ParentName", dtoObject.ParentName)
.AddParameter("@ParentContactNo", dtoObject.ParentContactNo)
.AddParameter("@RefInvestorID", dtoObject.RefInvestorID)
.AddParameter("@AddressID", dtoObject.AddressID)
.AddParameter("@LocalContactPerson", dtoObject.LocalContactPerson)
.AddParameter("@LocalContactNo", dtoObject.LocalContactNo)
.AddParameter("@EmployeeID", dtoObject.EmployeeID)
.AddParameter("@Department", dtoObject.Department)

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
        public bool Update(Guest dtoObject)
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

                    StoredProcedure(MasterDALConstant.GuestUpdate)
                        .AddParameter("@GuestID", dtoObject.GuestID)
.AddParameter("@Guest_TypeID", dtoObject.Guest_TypeID)
.AddParameter("@Title", dtoObject.Title)
.AddParameter("@FName", dtoObject.FName)
.AddParameter("@LName", dtoObject.LName)
.AddParameter("@GuestFullName", dtoObject.GuestFullName)
.AddParameter("@MName", dtoObject.MName)
.AddParameter("@DOB", dtoObject.DOB)
.AddParameter("@Nationality", dtoObject.Nationality)
.AddParameter("@IDType1_TermID", dtoObject.IDType1_TermID)
.AddParameter("@IDType1", dtoObject.IDType1)
.AddParameter("@IDType2_TermID", dtoObject.IDType2_TermID)
.AddParameter("@IDType2", dtoObject.IDType2)
.AddParameter("@ScanID1", dtoObject.ScanID1)
.AddParameter("@ScanID2", dtoObject.ScanID2)
.AddParameter("@MaritalStatus_TermID", dtoObject.MaritalStatus_TermID)
.AddParameter("@AnniversaryDate", dtoObject.AnniversaryDate)
.AddParameter("@Gender_TermID", dtoObject.Gender_TermID)
.AddParameter("@Occupation_TermID", dtoObject.Occupation_TermID)
.AddParameter("@JobTitle", dtoObject.JobTitle)
.AddParameter("@CompanyName", dtoObject.CompanyName)
.AddParameter("@StaffReferenceID", dtoObject.StaffReferenceID)
.AddParameter("@GuestReferenceID", dtoObject.GuestReferenceID)
.AddParameter("@IsByReference", dtoObject.IsByReference)
.AddParameter("@Email", dtoObject.Email)
.AddParameter("@Phone1", dtoObject.Phone1)
.AddParameter("@Phone2", dtoObject.Phone2)
.AddParameter("@FavouriteRoomID", dtoObject.FavouriteRoomID)
.AddParameter("@GuestPhoto", dtoObject.GuestPhoto)
.AddParameter("@GuestNotes", dtoObject.GuestNotes)
.AddParameter("@OtherNotes", dtoObject.OtherNotes)
.AddParameter("@IsBlocked", dtoObject.IsBlocked)
.AddParameter("@BlockReason", dtoObject.BlockReason)
.AddParameter("@LastArrivalDate", dtoObject.LastArrivalDate)
.AddParameter("@LastReservationID", dtoObject.LastReservationID)
.AddParameter("@IsMainGuest", dtoObject.IsMainGuest)
.AddParameter("@LastRateID", dtoObject.LastRateID)
.AddParameter("@LastRate", dtoObject.LastRate)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@CompanyID", dtoObject.CompanyID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@TotalNight", dtoObject.TotalNight)
.AddParameter("@BlockBy", dtoObject.BlockBy)
.AddParameter("@BlockOn", dtoObject.BlockOn)
.AddParameter("@IsSmoking", dtoObject.IsSmoking)
.AddParameter("@CompanySector", dtoObject.CompanySector)
.AddParameter("@WorkLocation", dtoObject.WorkLocation)
.AddParameter("@WorkTiming", dtoObject.WorkTiming)
.AddParameter("@BloodGroup", dtoObject.BloodGroup)
.AddParameter("@MealPreference", dtoObject.MealPreference)
.AddParameter("@ParentName", dtoObject.ParentName)
.AddParameter("@ParentContactNo", dtoObject.ParentContactNo)
.AddParameter("@RefInvestorID", dtoObject.RefInvestorID)
.AddParameter("@AddressID", dtoObject.AddressID)
.AddParameter("@LocalContactPerson", dtoObject.LocalContactPerson)
.AddParameter("@LocalContactNo", dtoObject.LocalContactNo)
.AddParameter("@EmployeeID", dtoObject.EmployeeID)
.AddParameter("@Department", dtoObject.Department)

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

        public bool UpdateGuestEmail(Guid guestID, string email)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterDALConstant.GuestUpdateEmail)
                        .AddParameter("@GuestID", guestID)
                        .AddParameter("@Email", email)

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
                StoredProcedure(MasterDALConstant.GuestDeleteByPrimaryKey)
                    .AddParameter("@GuestID"
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

        public bool Delete(Guest dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.GuestDeleteByPrimaryKey)
                    .AddParameter("@GuestID", dtoObject.GuestID)

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

        public Guest SelectByPrimaryKey(Guid Keys)
        {
            Guest obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.GuestSelectByPrimaryKey)
                            .AddParameter("@GuestID"
, Keys)
                            .Fetch<Guest>();
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

        public List<Guest> SelectByField(string fieldName, object value)
        {
            List<Guest> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.GuestSelectByField)
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Guest>();

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
                obj = StoredProcedure(MasterDALConstant.GuestSelectByField)
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
                StoredProcedure(MasterDALConstant.GuestDeleteByField)
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

        public DataSet GetExistingGuest(string guestName, string mobileNo, Guid propertyID, Guid companyID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.GuestSelectExistingGuest)
                                    .AddParameter("@GuestFullName", guestName)
                                    .AddParameter("@Phone1", mobileNo)
                                    .AddParameter("@PropertyID", propertyID)
                                    .AddParameter("@CompanyID", companyID)
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

        public DataSet GetGuestInfoByGuestID(Guid guestID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.GuestSelectGuestInfoByGuestID)
                                    .AddParameter("@GuestID", guestID)
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

        public DataSet SelectCurrentGuestListData(Guid? ReservationID, Guid? PropertyID, Guid? CompanyID, string GuestFullName, string MobileNo, string ReservationNo, string RoomNo, Guid? BillingInstructionID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.GuestSelectCurrentGuestList)
                                    .AddParameter("@ReservationID", ReservationID)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@GuestFullName", GuestFullName)
                                    .AddParameter("@MobileNo", MobileNo)
                                    .AddParameter("@ReservationNo", ReservationNo)
                                    .AddParameter("@RoomNo", RoomNo)
                                      .AddParameter("@BillingInstructionID", BillingInstructionID)
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

        public DataSet SelectPastGuestListData(DateTime? FromDate,DateTime? ToDate, Guid? PropertyID, Guid? CompanyID, string GuestFullName, string MobileNo, string ReservationNo, string RoomNo, Guid? BillingInstructionID)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.GuestSelectPastGuestList)
                                    .AddParameter("@FromDate", FromDate)
                                    .AddParameter("@ToDate", ToDate)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@GuestFullName", GuestFullName)
                                    .AddParameter("@MobileNo", MobileNo)
                                    .AddParameter("@ReservationNo", ReservationNo)
                                    .AddParameter("@RoomNo", RoomNo)
                                    .AddParameter("@BillingInstructionID", BillingInstructionID)
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

        public DataSet SelectGuestAndReserForGuestMsglist(Guid? PropertyID, Guid? CompanyID, string GuestFullName, string RoomNo)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.GuestSelectGuestAndReserForGuestMsglist)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@GuestFullName", GuestFullName)
                                    .AddParameter("@RoomNo", RoomNo)
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

        public DataSet SelectGuestAndReserForTroubleTicket(Guid? PropertyID, Guid? CompanyID, string GuestFullName, string RoomNo)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.GuestSelectGuestAndReserForTroubleTicket)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@GuestFullName", GuestFullName)
                                    .AddParameter("@RoomNo", RoomNo)
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

        public DataSet SelectAllForGuestHistory(string guestFullName, string nationality, string companyName, string email, string phone, Guid propertyID, Guid companyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.GuestSelectAllForGuestHistory)
                            .AddParameter("@GuestFullName", guestFullName)
                            .AddParameter("@Nationality", nationality)
                            .AddParameter("@CompanyName", companyName)
                            .AddParameter("@Email", email)
                            .AddParameter("@Phone1", phone)
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

        public DataSet POS_SelectCheckInGuestList(Guid propertyID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.POS_SelectCheckInGuestList)
                            .AddParameter("@PropertyID", propertyID)
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

        public DataSet SelectGuestBirthDayReport(Guid? PropertyID, Guid? CompanyID, int? dtFromDate, int? dtToDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.GuestSelectGuestBirthDayReport)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@CompanyID", CompanyID)
                                    .AddParameter("@FromDate", dtFromDate)
                                    .AddParameter("@ToDate", dtToDate)
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
        public DataSet selectOccupancyReportData(Guid? CompanyID, Guid? PropertyID, DateTime? dtStartDate, DateTime? dtEndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.Report_res_OccupancyReprtByType)
                                     .AddParameter("@CompanyID", CompanyID)
                                     .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@StartDate", dtStartDate)
                                    .AddParameter("@EndDate", dtEndDate)
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
        public DataSet selectGuestEmailAddressForSendEmail(Guid? CompanyID, Guid? PropertyID, string InquiryStatusForEmailDB, string InquiryStatusForwaitlist, string InquiryStatusForInquiry, bool IsToTakeCheckInGuestOnly, bool IsToTakeCheckOutGuestOnly, bool IsToTakeAllGuest)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.mst_GuestGetEmailAddressOfGuestForSendMail)
                                     .AddParameter("@CompanyID", CompanyID)
                                     .AddParameter("@PropertyID", PropertyID)
                                     .AddParameter("@InquiryStatusForEmailDB", InquiryStatusForEmailDB)
                                     .AddParameter("@InquiryStatusForwaitlist", InquiryStatusForwaitlist)
                                     .AddParameter("@InquiryStatusForInquiry", InquiryStatusForInquiry)
                                     .AddParameter("@IsToTakeCheckInGuestOnly", IsToTakeCheckInGuestOnly)
                                     .AddParameter("@IsToTakeCheckOutGuestOnly", IsToTakeCheckOutGuestOnly)
                                     .AddParameter("@IsToTakeAllGuest", IsToTakeAllGuest)
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
