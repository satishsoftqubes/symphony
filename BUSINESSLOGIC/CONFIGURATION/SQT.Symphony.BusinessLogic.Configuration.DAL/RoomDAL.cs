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
	/// Data access layer class for Room
	/// </summary>
	public class RoomDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public RoomDAL() :  base()
		{
			// Nothing for now.
		}
        public RoomDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Select By Property Room Type
        /// </summary>
        /// <param name="PropertyID"></param>
        /// <param name="RoomTypeID"></param>
        /// <returns></returns>
        public DataSet SelectByPropertyRoomType(Guid? PropertyID, Guid? RoomTypeID, Guid? WingID, string RoomNo)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.RoomSelectAllByProperty)
                    .AddParameter("@PropertyID", PropertyID)
                    .AddParameter("@RoomTypeID", RoomTypeID)
                    .AddParameter("@WingID", WingID)
                    .AddParameter("@RoomNo", RoomNo)
                    .FetchDataSet();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Dst;
        }

        public DataSet rptUnitBooking(Guid? WingID, Guid? FloorID, Guid? RoomTypeID, Guid? InvestorID, Guid? RoomID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.ReportBookedUnitList)
                    .AddParameter("@WingID", WingID)
                    .AddParameter("@FloorID", FloorID)
                    .AddParameter("@RoomTypeID", RoomTypeID)
                    .AddParameter("@InvestorID", InvestorID)
                    .AddParameter("@RoomID", RoomID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }
        public DataSet rptUnitBooking(Guid? WingID, Guid? FloorID, Guid? RoomTypeID, Guid? InvestorID, Guid? RoomID, Guid? RelationShipManagerID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.ReportBookedUnitList)
                    .AddParameter("@WingID", WingID)
                    .AddParameter("@FloorID", FloorID)
                    .AddParameter("@RoomTypeID", RoomTypeID)
                    .AddParameter("@InvestorID", InvestorID)
                    .AddParameter("@RoomID", RoomID)
                    .AddParameter("@RelationShipManagerID", RelationShipManagerID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }
        public List<Room> SelectAll(Room dtoObject)
        {
            List<Room> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    if(dtoObject != null)
                        parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);
                    if(dtoObject != null)  
                    {
                        obj = StoredProcedure(MasterConstant.RoomSelectAll)
                                                .AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@WingID", dtoObject.WingID)
.AddParameter("@FloorID", dtoObject.FloorID)
//.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@RoomNo", dtoObject.RoomNo)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@BedTypeID", dtoObject.BedTypeID)
.AddParameter("@SBArea", dtoObject.SBArea)
.AddParameter("@CarpetArea", dtoObject.CarpetArea)
.AddParameter("@IsSold", dtoObject.IsSold)
.AddParameter("@LocationDetail", dtoObject.LocationDetail)
.AddParameter("@Thumb1", dtoObject.Thumb1)
.AddParameter("@Thumb2", dtoObject.Thumb2)
.AddParameter("@OrderSeqNo", dtoObject.OrderSeqNo)
.AddParameter("@KeyNo", dtoObject.KeyNo)
.AddParameter("@ExtentionNo", dtoObject.ExtentionNo)
.AddParameter("@NoOfBeds", dtoObject.NoOfBeds)
.AddParameter("@IsBlocked", dtoObject.IsBlocked)
.AddParameter("@IsAvailableOnIRS", dtoObject.IsAvailableOnIRS)
.AddParameter("@EmergencyExitDesc", dtoObject.EmergencyExitDesc)
.AddParameter("@NoOfAdults", dtoObject.NoOfAdults)
.AddParameter("@NoOfChilds", dtoObject.NoOfChilds)
.AddParameter("@HKPSectionID", dtoObject.HKPSectionID)
.AddParameter("@MinimalHKPdays", dtoObject.MinimalHKPdays)
.AddParameter("@FullHKPDays", dtoObject.FullHKPDays)
.AddParameter("@ConnectingRoomLID", dtoObject.ConnectingRoomLID)
.AddParameter("@ConnectingRoomRID", dtoObject.ConnectingRoomRID)
.AddParameter("@OppositeRoomID", dtoObject.OppositeRoomID)
.AddParameter("@DataNo", dtoObject.DataNo)
.AddParameter("@InvesterID", dtoObject.InvesterID)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@PropertyTaxNo", dtoObject.PropertyTaxNo)
.AddParameter("@PropertyTaxAmt", dtoObject.PropertyTaxAmt)
.AddParameter("@IsPaidPropertyTax", dtoObject.IsPaidPropertyTax)
.AddParameter("@LastDateOfPaid", dtoObject.LastDateOfPaid)
.AddParameter("@SelfPrioritySeqNo", dtoObject.SelfPrioritySeqNo)
.AddParameter("@RoomClassID", dtoObject.RoomClassID)
.AddParameter("@ReleaseDays", dtoObject.ReleaseDays)
.AddParameter("@MinimumStay", dtoObject.MinimumStay)
.AddParameter("@MaximumStay", dtoObject.MaximumStay)
.AddParameter("@IsDiscountApplicable", dtoObject.IsDiscountApplicable)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@ReferenceRoomID", dtoObject.ReferenceRoomID)
.AddParameter("@IsSmokingAllowed", dtoObject.IsSmokingAllowed)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Room>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.RoomSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Room>();
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

        public List<Room> SelectAll()
        {
            List<Room> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.RoomSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Room>();
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
        public DataSet SelectAllWithDataSet(Room dtoObject)
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
                        obj = StoredProcedure(MasterConstant.RoomSelectAll)
                                                .AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@WingID", dtoObject.WingID)
.AddParameter("@FloorID", dtoObject.FloorID)
//.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@RoomNo", dtoObject.RoomNo)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@BedTypeID", dtoObject.BedTypeID)
.AddParameter("@SBArea", dtoObject.SBArea)
.AddParameter("@CarpetArea", dtoObject.CarpetArea)
.AddParameter("@IsSold", dtoObject.IsSold)
.AddParameter("@LocationDetail", dtoObject.LocationDetail)
.AddParameter("@Thumb1", dtoObject.Thumb1)
.AddParameter("@Thumb2", dtoObject.Thumb2)
.AddParameter("@OrderSeqNo", dtoObject.OrderSeqNo)
.AddParameter("@KeyNo", dtoObject.KeyNo)
.AddParameter("@ExtentionNo", dtoObject.ExtentionNo)
.AddParameter("@NoOfBeds", dtoObject.NoOfBeds)
.AddParameter("@IsBlocked", dtoObject.IsBlocked)
.AddParameter("@IsAvailableOnIRS", dtoObject.IsAvailableOnIRS)
.AddParameter("@EmergencyExitDesc", dtoObject.EmergencyExitDesc)
.AddParameter("@NoOfAdults", dtoObject.NoOfAdults)
.AddParameter("@NoOfChilds", dtoObject.NoOfChilds)
.AddParameter("@HKPSectionID", dtoObject.HKPSectionID)
.AddParameter("@MinimalHKPdays", dtoObject.MinimalHKPdays)
.AddParameter("@FullHKPDays", dtoObject.FullHKPDays)
.AddParameter("@ConnectingRoomLID", dtoObject.ConnectingRoomLID)
.AddParameter("@ConnectingRoomRID", dtoObject.ConnectingRoomRID)
.AddParameter("@OppositeRoomID", dtoObject.OppositeRoomID)
.AddParameter("@DataNo", dtoObject.DataNo)
.AddParameter("@InvesterID", dtoObject.InvesterID)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@PropertyTaxNo", dtoObject.PropertyTaxNo)
.AddParameter("@PropertyTaxAmt", dtoObject.PropertyTaxAmt)
.AddParameter("@IsPaidPropertyTax", dtoObject.IsPaidPropertyTax)
.AddParameter("@LastDateOfPaid", dtoObject.LastDateOfPaid)
.AddParameter("@SelfPrioritySeqNo", dtoObject.SelfPrioritySeqNo)
.AddParameter("@RoomClassID", dtoObject.RoomClassID)
.AddParameter("@ReleaseDays", dtoObject.ReleaseDays)
.AddParameter("@MinimumStay", dtoObject.MinimumStay)
.AddParameter("@MaximumStay", dtoObject.MaximumStay)
.AddParameter("@IsDiscountApplicable", dtoObject.IsDiscountApplicable)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@ReferenceRoomID", dtoObject.ReferenceRoomID)
.AddParameter("@IsSmokingAllowed", dtoObject.IsSmokingAllowed)
.AddParameter("@IsExtraBedAllow", dtoObject.IsExtraBedAllow)
.AddParameter("@NoOfExtraBed", dtoObject.NoOfExtraBed)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.RoomSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
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

        public DataSet SelectAllWithDataSet()
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.RoomSelectAll)
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
		public bool Insert(Room dtoObject)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    if (dtoObject == null)
                        throw (new ParameterNullException("Object can not be null"));

                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterConstant.RoomInsert)
                        .AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@WingID", dtoObject.WingID)
.AddParameter("@FloorID", dtoObject.FloorID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@RoomNo", dtoObject.RoomNo)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@BedTypeID", dtoObject.BedTypeID)
.AddParameter("@SBArea", dtoObject.SBArea)
.AddParameter("@CarpetArea", dtoObject.CarpetArea)
.AddParameter("@IsSold", dtoObject.IsSold)
.AddParameter("@LocationDetail", dtoObject.LocationDetail)
.AddParameter("@Thumb1", dtoObject.Thumb1)
.AddParameter("@Thumb2", dtoObject.Thumb2)
.AddParameter("@OrderSeqNo", dtoObject.OrderSeqNo)
.AddParameter("@KeyNo", dtoObject.KeyNo)
.AddParameter("@ExtentionNo", dtoObject.ExtentionNo)
.AddParameter("@NoOfBeds", dtoObject.NoOfBeds)
.AddParameter("@IsBlocked", dtoObject.IsBlocked)
.AddParameter("@IsAvailableOnIRS", dtoObject.IsAvailableOnIRS)
.AddParameter("@EmergencyExitDesc", dtoObject.EmergencyExitDesc)
.AddParameter("@NoOfAdults", dtoObject.NoOfAdults)
.AddParameter("@NoOfChilds", dtoObject.NoOfChilds)
.AddParameter("@HKPSectionID", dtoObject.HKPSectionID)
.AddParameter("@MinimalHKPdays", dtoObject.MinimalHKPdays)
.AddParameter("@FullHKPDays", dtoObject.FullHKPDays)
.AddParameter("@ConnectingRoomLID", dtoObject.ConnectingRoomLID)
.AddParameter("@ConnectingRoomRID", dtoObject.ConnectingRoomRID)
.AddParameter("@OppositeRoomID", dtoObject.OppositeRoomID)
.AddParameter("@DataNo", dtoObject.DataNo)
.AddParameter("@InvesterID", dtoObject.InvesterID)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@PropertyTaxNo", dtoObject.PropertyTaxNo)
.AddParameter("@PropertyTaxAmt", dtoObject.PropertyTaxAmt)
.AddParameter("@IsPaidPropertyTax", dtoObject.IsPaidPropertyTax)
.AddParameter("@LastDateOfPaid", dtoObject.LastDateOfPaid)
.AddParameter("@SelfPrioritySeqNo", dtoObject.SelfPrioritySeqNo)
.AddParameter("@RoomClassID", dtoObject.RoomClassID)
.AddParameter("@ReleaseDays", dtoObject.ReleaseDays)
.AddParameter("@MinimumStay", dtoObject.MinimumStay)
.AddParameter("@MaximumStay", dtoObject.MaximumStay)
.AddParameter("@IsDiscountApplicable", dtoObject.IsDiscountApplicable)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@ReferenceRoomID", dtoObject.ReferenceRoomID)
.AddParameter("@IsSmokingAllowed", dtoObject.IsSmokingAllowed)
.AddParameter("@IsExtraBedAllow", dtoObject.IsExtraBedAllow)
.AddParameter("@NoOfExtraBed", dtoObject.NoOfExtraBed)

                        .WithTransaction(dbtr)
                        .Execute();
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
            return true;
        }

         /// <summary>
        /// update row in the table
        /// </summary>
        /// <param name="businessObject">business object</param>
        /// <returns>true for successfully updated</returns>
        public bool Update(Room dtoObject)
        {
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    if (dtoObject == null)
                        throw (new ParameterNullException("Object can not be null"));

                    ////Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    parameterList.Add(dtoObject);
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    StoredProcedure(MasterConstant.RoomUpdate)
                        .AddParameter("@RoomID", dtoObject.RoomID)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@WingID", dtoObject.WingID)
.AddParameter("@FloorID", dtoObject.FloorID)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@RoomNo", dtoObject.RoomNo)
.AddParameter("@RoomTypeID", dtoObject.RoomTypeID)
.AddParameter("@BedTypeID", dtoObject.BedTypeID)
.AddParameter("@SBArea", dtoObject.SBArea)
.AddParameter("@CarpetArea", dtoObject.CarpetArea)
.AddParameter("@IsSold", dtoObject.IsSold)
.AddParameter("@LocationDetail", dtoObject.LocationDetail)
.AddParameter("@Thumb1", dtoObject.Thumb1)
.AddParameter("@Thumb2", dtoObject.Thumb2)
.AddParameter("@OrderSeqNo", dtoObject.OrderSeqNo)
.AddParameter("@KeyNo", dtoObject.KeyNo)
.AddParameter("@ExtentionNo", dtoObject.ExtentionNo)
.AddParameter("@NoOfBeds", dtoObject.NoOfBeds)
.AddParameter("@IsBlocked", dtoObject.IsBlocked)
.AddParameter("@IsAvailableOnIRS", dtoObject.IsAvailableOnIRS)
.AddParameter("@EmergencyExitDesc", dtoObject.EmergencyExitDesc)
.AddParameter("@NoOfAdults", dtoObject.NoOfAdults)
.AddParameter("@NoOfChilds", dtoObject.NoOfChilds)
.AddParameter("@HKPSectionID", dtoObject.HKPSectionID)
.AddParameter("@MinimalHKPdays", dtoObject.MinimalHKPdays)
.AddParameter("@FullHKPDays", dtoObject.FullHKPDays)
.AddParameter("@ConnectingRoomLID", dtoObject.ConnectingRoomLID)
.AddParameter("@ConnectingRoomRID", dtoObject.ConnectingRoomRID)
.AddParameter("@OppositeRoomID", dtoObject.OppositeRoomID)
.AddParameter("@DataNo", dtoObject.DataNo)
.AddParameter("@InvesterID", dtoObject.InvesterID)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@PropertyTaxNo", dtoObject.PropertyTaxNo)
.AddParameter("@PropertyTaxAmt", dtoObject.PropertyTaxAmt)
.AddParameter("@IsPaidPropertyTax", dtoObject.IsPaidPropertyTax)
.AddParameter("@LastDateOfPaid", dtoObject.LastDateOfPaid)
.AddParameter("@SelfPrioritySeqNo", dtoObject.SelfPrioritySeqNo)
.AddParameter("@RoomClassID", dtoObject.RoomClassID)
.AddParameter("@ReleaseDays", dtoObject.ReleaseDays)
.AddParameter("@MinimumStay", dtoObject.MinimumStay)
.AddParameter("@MaximumStay", dtoObject.MaximumStay)
.AddParameter("@IsDiscountApplicable", dtoObject.IsDiscountApplicable)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@ReferenceRoomID", dtoObject.ReferenceRoomID)
.AddParameter("@IsSmokingAllowed", dtoObject.IsSmokingAllowed)
.AddParameter("@IsExtraBedAllow", dtoObject.IsExtraBedAllow)
.AddParameter("@NoOfExtraBed", dtoObject.NoOfExtraBed)

                        .WithTransaction(dbtr)
                        .Execute();
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
            return true;
        }
        public bool Delete(Guid Keys)
        {
            try
            {
                StoredProcedure(MasterConstant.RoomDeleteByPrimaryKey)
                    .AddParameter("@RoomID"
,Keys)
                    .WithTransaction(dbtr)
                    .Execute();
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
            return true;
        }
        public bool Delete(Room dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.RoomDeleteByPrimaryKey)
                    .AddParameter("@RoomID", dtoObject.RoomID)

                    .WithTransaction(dbtr)
                    .Execute();
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
            return true;
        }

        public Room SelectByPrimaryKey(Guid Keys)
        {
            Room obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RoomSelectByPrimaryKey)
                            .AddParameter("@RoomID"
,Keys)
                            .Fetch<Room>();
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
        public List<Room> SelectByField(string fieldName, object value)
        {
            List<Room> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RoomSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Room>();

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
        public DataSet SelectByFieldWithDataSet(string fieldName, object value)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RoomSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchDataSet();

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

        public DataSet RPTVacantRoomList(Guid? PropertyID, Guid? RoomTypeID, DateTime? StartDate, DateTime? EndDate)
        {
            DataSet obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.RoomVacantList)
                                    .AddParameter("@PropertyID", PropertyID)
                                    .AddParameter("@RoomTypeID", RoomTypeID)
                                    .AddParameter("@StartDate", StartDate)
                                    .AddParameter("@EndDate", EndDate)
                                    .FetchDataSet();

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

        public bool DeleteByField(string fieldName, object value)
        {
            try
            {
                StoredProcedure(MasterConstant.RoomDeleteByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .WithTransaction(dbtr)
                                    .Execute();
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
            return true;
        }

        public DataSet SelectUnitNo(string UnitNoQuery)
        {
            DataSet dst = new DataSet();
            try
            {
                dst = Query(UnitNoQuery)
                            .WithTransaction(dbtr)
                            .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return dst;
        }

        public DataSet RoomSearchData(Guid? PropertyID, Guid? RoomTypeID, string RoomNo, Guid? WingID, Guid? FloorID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.RoomSearchData)
                    .AddParameter("@PropertyID", PropertyID)
                    .AddParameter("@RoomTypeID", RoomTypeID)
                    .AddParameter("RoomNo", RoomNo)
                    .AddParameter("@WingID", WingID)
                    .AddParameter("@FloorID", FloorID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet RoomCountBed(Guid? PropertyID, Guid? RoomTypeID, string RoomNo, Guid? WingID, Guid? FloorID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.RoomCountBed)
                    .AddParameter("@PropertyID", PropertyID)
                    .AddParameter("@RoomTypeID", RoomTypeID)
                    .AddParameter("RoomNo", RoomNo)
                    .AddParameter("@WingID", WingID)
                    .AddParameter("@FloorID", FloorID)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }


        public DataSet RoomAndConferenceSelectExtensionNO(Guid? PropertyID,string ExtentionNo)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.Room_Conference_SelectExtensionNo)
                    .AddParameter("@PropertyID", PropertyID)
                    .AddParameter("@ExtentionNo", ExtentionNo)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet RoomCheckDuplicateRoom(Guid? PropertyID, string RoomNo)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.RoomCheckDuplicateRoom)
                    .AddParameter("@PropertyID", PropertyID)
                    .AddParameter("@RoomNo", RoomNo)
                    .FetchDataSet();
            }
            catch
            {
                throw;
            }
            return Dst;
        }

        public DataSet GetAllRoomIDOfRoomByAnyRoomID(Guid RoomID, Guid? PropertyID)
        {
            DataSet Dst = new DataSet();
            try
            {
                Dst = StoredProcedure(MasterConstant.Room_SelectAllRoomIDOfRoomByAnyRoomID)
                    .AddParameter("@RoomID", RoomID)
                    .AddParameter("@PropertyID", PropertyID)
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
