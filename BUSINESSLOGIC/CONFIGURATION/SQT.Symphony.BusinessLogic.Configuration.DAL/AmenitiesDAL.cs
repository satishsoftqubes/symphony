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
	/// Data access layer class for Amenities
	/// </summary>
	public class AmenitiesDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public AmenitiesDAL() :  base()
		{
			// Nothing for now.
		}
        public AmenitiesDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Amenities> SelectAll(Amenities dtoObject)
        {
            List<Amenities> obj = null;
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
                        obj = StoredProcedure(MasterConstant.AmenitiesSelectAll)
                                                .AddParameter("@AmenitiesID", dtoObject.AmenitiesID)
.AddParameter("@AmenitiesCode", dtoObject.AmenitiesCode)
.AddParameter("@AmenitiesName", dtoObject.AmenitiesName)
.AddParameter("@AmenitiesDescription", dtoObject.AmenitiesDescription)
.AddParameter("@UploadImage", dtoObject.UploadImage)
.AddParameter("@Thumb", dtoObject.Thumb)
//.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsAvailableORequestOnly", dtoObject.IsAvailableORequestOnly)
.AddParameter("@IsExtraCharge", dtoObject.IsExtraCharge)
.AddParameter("@Charge", dtoObject.Charge)
.AddParameter("@ChargeFrequency_TermID", dtoObject.ChargeFrequency_TermID)
.AddParameter("@IsPerPerson", dtoObject.IsPerPerson)
.AddParameter("@IsForUnit", dtoObject.IsForUnit)
.AddParameter("@AmenitiesTypeTermID", dtoObject.AmenitiesTypeTermID)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Amenities>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.AmenitiesSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Amenities>();
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

        public List<Amenities> SelectAll()
        {
            List<Amenities> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.AmenitiesSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Amenities>();
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
        public DataSet SelectAllWithDataSet(Amenities dtoObject)
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
                        obj = StoredProcedure(MasterConstant.AmenitiesSelectAll)
                                                .AddParameter("@AmenitiesID", dtoObject.AmenitiesID)
.AddParameter("@AmenitiesCode", dtoObject.AmenitiesCode)
.AddParameter("@AmenitiesName", dtoObject.AmenitiesName)
.AddParameter("@AmenitiesDescription", dtoObject.AmenitiesDescription)
.AddParameter("@UploadImage", dtoObject.UploadImage)
.AddParameter("@Thumb", dtoObject.Thumb)
//.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsAvailableORequestOnly", dtoObject.IsAvailableORequestOnly)
.AddParameter("@IsExtraCharge", dtoObject.IsExtraCharge)
.AddParameter("@Charge", dtoObject.Charge)
.AddParameter("@ChargeFrequency_TermID", dtoObject.ChargeFrequency_TermID)
.AddParameter("@IsPerPerson", dtoObject.IsPerPerson)
.AddParameter("@IsForUnit", dtoObject.IsForUnit)
.AddParameter("@AmenitiesTypeTermID", dtoObject.AmenitiesTypeTermID)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterConstant.AmenitiesSelectAll)
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

                    obj = StoredProcedure(MasterConstant.AmenitiesSelectAll)
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
		public bool Insert(Amenities dtoObject)
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

                    StoredProcedure(MasterConstant.AmenitiesInsert)
                        .AddParameter("@AmenitiesID", dtoObject.AmenitiesID)
.AddParameter("@AmenitiesCode", dtoObject.AmenitiesCode)
.AddParameter("@AmenitiesName", dtoObject.AmenitiesName)
.AddParameter("@AmenitiesDescription", dtoObject.AmenitiesDescription)
.AddParameter("@UploadImage", dtoObject.UploadImage)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@IsAvailableORequestOnly", dtoObject.IsAvailableORequestOnly)
.AddParameter("@IsExtraCharge", dtoObject.IsExtraCharge)
.AddParameter("@Charge", dtoObject.Charge)
.AddParameter("@ChargeFrequency_TermID", dtoObject.ChargeFrequency_TermID)
.AddParameter("@IsPerPerson", dtoObject.IsPerPerson)
.AddParameter("@IsForUnit", dtoObject.IsForUnit)
.AddParameter("@AmenitiesTypeTermID", dtoObject.AmenitiesTypeTermID)

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
        public bool Update(Amenities dtoObject)
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

                    StoredProcedure(MasterConstant.AmenitiesUpdate)
                        .AddParameter("@AmenitiesID", dtoObject.AmenitiesID)
.AddParameter("@AmenitiesCode", dtoObject.AmenitiesCode)
.AddParameter("@AmenitiesName", dtoObject.AmenitiesName)
.AddParameter("@AmenitiesDescription", dtoObject.AmenitiesDescription)
.AddParameter("@UploadImage", dtoObject.UploadImage)
.AddParameter("@Thumb", dtoObject.Thumb)
.AddParameter("@SeqNo", dtoObject.SeqNo)
.AddParameter("@IsActive", dtoObject.IsActive)
.AddParameter("@IsSynch", dtoObject.IsSynch)
.AddParameter("@SynchOn", dtoObject.SynchOn)
.AddParameter("@CreatedOn", dtoObject.CreatedOn)
.AddParameter("@CreatedBy", dtoObject.CreatedBy)
.AddParameter("@UpdatedOn", dtoObject.UpdatedOn)
.AddParameter("@UpdatedBy", dtoObject.UpdatedBy)
.AddParameter("@PropertyID", dtoObject.PropertyID)
.AddParameter("@UpdateLog", dtoObject.UpdateLog)
.AddParameter("@IsAvailableORequestOnly", dtoObject.IsAvailableORequestOnly)
.AddParameter("@IsExtraCharge", dtoObject.IsExtraCharge)
.AddParameter("@Charge", dtoObject.Charge)
.AddParameter("@ChargeFrequency_TermID", dtoObject.ChargeFrequency_TermID)
.AddParameter("@IsPerPerson", dtoObject.IsPerPerson)
.AddParameter("@IsForUnit", dtoObject.IsForUnit)
.AddParameter("@AmenitiesTypeTermID", dtoObject.AmenitiesTypeTermID)

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
                StoredProcedure(MasterConstant.AmenitiesDeleteByPrimaryKey)
                    .AddParameter("@AmenitiesID"
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
        public bool Delete(Amenities dtoObject)
        {
            try
            {
                StoredProcedure(MasterConstant.AmenitiesDeleteByPrimaryKey)
                    .AddParameter("@AmenitiesID", dtoObject.AmenitiesID)

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

        public Amenities SelectByPrimaryKey(Guid Keys)
        {
            Amenities obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.AmenitiesSelectByPrimaryKey)
                            .AddParameter("@AmenitiesID"
,Keys)
                            .Fetch<Amenities>();
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
        public List<Amenities> SelectByField(string fieldName, object value)
        {
            List<Amenities> obj = null;
            try
            {
                obj = StoredProcedure(MasterConstant.AmenitiesSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Amenities>();

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
                obj = StoredProcedure(MasterConstant.AmenitiesSelectByField) 
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
                StoredProcedure(MasterConstant.AmenitiesDeleteByField) 
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

        public DataSet SearchAmenitiesData(Guid? AmenitiesID, Guid? PropertyID, string AmenitiesName, Guid? AmenitiesTypeTermID)
        {
            DataSet obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();

                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterConstant.AmenitiesSearchData)
                                            .AddParameter("@AmenitiesID", AmenitiesID)
                                            .AddParameter("@PropertyID", PropertyID)
                                            .AddParameter("@AmenitiesName", AmenitiesName)
                                            .AddParameter("@AmenitiesTypeTermID", AmenitiesTypeTermID)
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

        public DataSet SelectAmenities(string AmenitiesQuery)
        {
            DataSet dst = new DataSet();
            try
            {
                dst = Query(AmenitiesQuery)
                            .WithTransaction(dbtr)
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
