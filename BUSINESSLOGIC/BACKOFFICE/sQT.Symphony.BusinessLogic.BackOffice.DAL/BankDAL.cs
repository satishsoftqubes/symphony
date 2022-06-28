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
using SQT.Symphony.BusinessLogic.BackOffice.DTO;
using SQT.Symphony.BusinessLogic.BackOffice.COMMON;

namespace SQT.Symphony.BusinessLogic.BackOffice.DAL
{
	/// <summary>
	/// Data access layer class for Bank
	/// </summary>
	public class BankDAL : LinqDAL 
	{

        DbTransaction dbtr = null;
        #region Constructor

		/// <summary>
		/// Class constructor
		/// </summary>
		public BankDAL() :  base()
		{
			// Nothing for now.
		}
        public BankDAL(DbTransaction DbTr) : base()
        {
            dbtr = DbTr;
        }
        #endregion

        #region Public Methods
        public List<Bank> SelectAll(Bank dtoObject)
        {
            List<Bank> obj = null;
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
                        obj = StoredProcedure(MasterDALConstant.BankSelectAll)
                                                .AddParameter("@BankID", dtoObject.BankID)
.AddParameter("@BankName", dtoObject.BankName)
.AddParameter("@ContactName", dtoObject.ContactName)
.AddParameter("@ContactNO", dtoObject.ContactNO)
.AddParameter("@Address", dtoObject.Address)
.AddParameter("@Address1", dtoObject.Address1)
.AddParameter("@City", dtoObject.City)
.AddParameter("@StateID", dtoObject.StateID)
.AddParameter("@CountyID", dtoObject.CountyID)
.AddParameter("@PostCode", dtoObject.PostCode)
.AddParameter("@AccountNo", dtoObject.AccountNo)
.AddParameter("@SortCode", dtoObject.SortCode)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@Balance", dtoObject.Balance)
.AddParameter("@Active", dtoObject.Active)
.AddParameter("@UserID", dtoObject.UserID)

                                                .WithTransaction(dbtr)
                                                .FetchAll<Bank>();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.BankSelectAll)
                                                .WithTransaction(dbtr)
                                                .FetchAll<Bank>();
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

        public List<Bank> SelectAll()
        {
            List<Bank> obj = null;
            try
            {
                using (new Tracer((SQTLogType.DataAccessTraceLog)))
                {
                    //Log Method Parameteres.
                    ArrayList parameterList = new ArrayList();
                    
                    SQTLogger.WriteLog(LogMessageType.MethodStart, parameterList, Common.GetMethodName, SQTLogType.DataAccessTraceLog);

                    obj = StoredProcedure(MasterDALConstant.BankSelectAll)
                                            .WithTransaction(dbtr)
                                            .FetchAll<Bank>();
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
        public DataSet SelectAllWithDataSet(Bank dtoObject)
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
                        obj = StoredProcedure(MasterDALConstant.BankSelectAll)
                                                .AddParameter("@BankID", dtoObject.BankID)
.AddParameter("@BankName", dtoObject.BankName)
.AddParameter("@ContactName", dtoObject.ContactName)
.AddParameter("@ContactNO", dtoObject.ContactNO)
.AddParameter("@Address", dtoObject.Address)
.AddParameter("@Address1", dtoObject.Address1)
.AddParameter("@City", dtoObject.City)
.AddParameter("@StateID", dtoObject.StateID)
.AddParameter("@CountyID", dtoObject.CountyID)
.AddParameter("@PostCode", dtoObject.PostCode)
.AddParameter("@AccountNo", dtoObject.AccountNo)
.AddParameter("@SortCode", dtoObject.SortCode)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@Balance", dtoObject.Balance)
.AddParameter("@Active", dtoObject.Active)
.AddParameter("@UserID", dtoObject.UserID)

                                                .WithTransaction(dbtr)
                                                .FetchDataSet();
                    }
                    else
                    {
                        obj = StoredProcedure(MasterDALConstant.BankSelectAll)
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

                    obj = StoredProcedure(MasterDALConstant.BankSelectAll)
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
		public bool Insert(Bank dtoObject)
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

                    StoredProcedure(MasterDALConstant.BankInsert)
                        .AddParameter("@BankID", dtoObject.BankID)
.AddParameter("@BankName", dtoObject.BankName)
.AddParameter("@ContactName", dtoObject.ContactName)
.AddParameter("@ContactNO", dtoObject.ContactNO)
.AddParameter("@Address", dtoObject.Address)
.AddParameter("@Address1", dtoObject.Address1)
.AddParameter("@City", dtoObject.City)
.AddParameter("@StateID", dtoObject.StateID)
.AddParameter("@CountyID", dtoObject.CountyID)
.AddParameter("@PostCode", dtoObject.PostCode)
.AddParameter("@AccountNo", dtoObject.AccountNo)
.AddParameter("@SortCode", dtoObject.SortCode)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@Balance", dtoObject.Balance)
.AddParameter("@Active", dtoObject.Active)
.AddParameter("@UserID", dtoObject.UserID)

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
        public bool Update(Bank dtoObject)
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

                    StoredProcedure(MasterDALConstant.BankUpdate)
                        .AddParameter("@BankID", dtoObject.BankID)
.AddParameter("@BankName", dtoObject.BankName)
.AddParameter("@ContactName", dtoObject.ContactName)
.AddParameter("@ContactNO", dtoObject.ContactNO)
.AddParameter("@Address", dtoObject.Address)
.AddParameter("@Address1", dtoObject.Address1)
.AddParameter("@City", dtoObject.City)
.AddParameter("@StateID", dtoObject.StateID)
.AddParameter("@CountyID", dtoObject.CountyID)
.AddParameter("@PostCode", dtoObject.PostCode)
.AddParameter("@AccountNo", dtoObject.AccountNo)
.AddParameter("@SortCode", dtoObject.SortCode)
.AddParameter("@AcctID", dtoObject.AcctID)
.AddParameter("@Balance", dtoObject.Balance)
.AddParameter("@Active", dtoObject.Active)
.AddParameter("@UserID", dtoObject.UserID)

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
                StoredProcedure(MasterDALConstant.BankDeleteByPrimaryKey)
                    .AddParameter("@BankID"
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
        public bool Delete(Bank dtoObject)
        {
            try
            {
                StoredProcedure(MasterDALConstant.BankDeleteByPrimaryKey)
                    .AddParameter("@BankID", dtoObject.BankID)

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

        public Bank SelectByPrimaryKey(Guid Keys)
        {
            Bank obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.BankSelectByPrimaryKey)
                            .AddParameter("@BankID"
,Keys)
                            .Fetch<Bank>();
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
        public List<Bank> SelectByField(string fieldName, object value)
        {
            List<Bank> obj = null;
            try
            {
                obj = StoredProcedure(MasterDALConstant.BankSelectByField) 
                                    .AddParameter("@FieldName", fieldName)
                                    .AddParameter("@Value", value)
                                    .FetchAll<Bank>();

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
                obj = StoredProcedure(MasterDALConstant.BankSelectByField) 
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
                StoredProcedure(MasterDALConstant.BankDeleteByField) 
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

        #endregion
	}
}
