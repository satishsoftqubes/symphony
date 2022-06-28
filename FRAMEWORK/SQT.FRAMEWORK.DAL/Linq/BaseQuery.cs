using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;

using SQT.FRAMEWORK.DAL.Linq.Adapters;
using SQT.FRAMEWORK.DAL.Linq.Exceptions;
using SQT.FRAMEWORK.DAL.Linq.Interfaces;
using SQT.FRAMEWORK.DAL.Linq.Results;

namespace SQT.FRAMEWORK.DAL.Linq
{
    public class BaseQuery : IHideObjectMembers
    {
        #region Constructors
        public BaseQuery()
        {
        }
        public BaseQuery(string sqlStatement, bool isStoredProcedure) : this(sqlStatement, null, isStoredProcedure)
        {
        }
        public BaseQuery(string sqlStatement, bool isStoredProcedure, DbTransaction trans) : this(sqlStatement, null, isStoredProcedure)
        {
            WithTransaction(trans);
        }
        public BaseQuery(string sqlStatement, string connectionName, bool isStoredProcedure)            
        {            
            this.SetConnectionString(connectionName, null, false);            
            this.Database = new DataBaseManager(sqlStatement, this.ConnectionString, this.SqlProvider, isStoredProcedure);
            this.SetData(sqlStatement, isStoredProcedure);
        }
        public BaseQuery(string sqlStatement, string connectionName, bool isStoredProcedure, DbTransaction trans)
        {
            this.SetConnectionString(connectionName, null, false);
            this.Database = new DataBaseManager(sqlStatement, this.ConnectionString, this.SqlProvider, isStoredProcedure);
            this.SetData(sqlStatement, isStoredProcedure);
            WithTransaction(trans);
        }

        public BaseQuery(string sqlStatement, string connectionString, string sqlProvider, bool isStoredProcedure)
        {
            this.SetConnectionString(connectionString, sqlProvider, true);
            this.Database = new DataBaseManager(sqlStatement, this.ConnectionString, this.SqlProvider, isStoredProcedure);
            this.SetData(sqlStatement, isStoredProcedure);
        }
        public BaseQuery(string sqlStatement, string connectionString, string sqlProvider, bool isStoredProcedure, DbTransaction trans)
        {
            this.SetConnectionString(connectionString, sqlProvider, true);
            this.Database = new DataBaseManager(sqlStatement, this.ConnectionString, this.SqlProvider, isStoredProcedure);
            this.SetData(sqlStatement, isStoredProcedure);
            WithTransaction(trans);
        }
        #endregion

        #region Private Methods

        private void SetData(string sqlStatement, bool isStoredProcedure)
        {
            this.Statement = sqlStatement;
            this.IsStoredProc = isStoredProcedure;
        }
        public string GetConnectionString(string ConnectName)
        {
            string connectString = String.Empty;
            string provider = String.Empty;
            try
            {
                if (ConfigurationManager.ConnectionStrings.Count == 0)
                {
                    throw new Exception("No connection strings found in config file");
                }
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[ConnectName];
                return settings.ConnectionString;
            }
            catch (Exception e)
            {
                throw new LinqSqlException("An error occured setting up the connection with supplied connection string: ", e);
            }
        }
        private void SetConnectionString(string connectName, string providerName, bool isExplicitConnection)
        {
            string connectString = String.Empty;
            string provider = String.Empty;
            try
            {
                if (isExplicitConnection)
                {
                    this.ConnectionString = connectName;
                    this.SqlProvider = providerName;
                }
                else
                {
                    if (ConfigurationManager.ConnectionStrings.Count == 0)
                    {
                        throw new Exception("No connection strings found in config file");
                    }
                    ConnectionStringSettings settings = (!String.IsNullOrEmpty(connectName))
                            ? ConfigurationManager.ConnectionStrings[connectName]
                            : ConfigurationManager.ConnectionStrings[0];
                    String name = connectName ?? "First connection string from .config file used";
                    Debug.WriteLine("Connection: " + settings.ConnectionString + " Provider: " + settings.ProviderName + " Name: " + name);
                    this.ConnectionString = settings.ConnectionString;
                    this.SqlProvider = settings.ProviderName;
                }

            }
            catch (Exception e)
            {
                throw new LinqSqlException("An error occured setting up the connection with supplied connection string: ", e);
            }
        }

        // Helper Method For Fetch and FetchAll Public Methods
        private T MapRecordToObject<T>(DbDataReader reader)
        {
            if (recordMappers.Count > 0)
            {
                return (T)recordMappers[0].Invoke(reader);
            }
            else
            {
                return ObjectSqlAdapter.HydrateObject<T>(reader);
            }
        }

        //This method handles the messy details when dealing with Multiple Resultsets
        private Object ProcessResult(DbDataReader reader, Func<DbDataReader, Object> mapperDelegate)
        {
            ArrayList recordSet = new ArrayList();
            while (reader.Read())
            {
                recordSet.Add(mapperDelegate.Invoke(reader));
            }
            if (recordSet.Count == 0) { return null; }
            if (recordSet.Count > 1)
            {
                return recordSet; //return ArrayList since there are many items in the ArrayList
            }
            else
            {
                return recordSet[0]; //return a single result
            }
        }

        //This method pulls out any output parameters
        private OutputParameterCollection PullOutputParameters()
        {
            OutputParameterCollection outputs = null;
            //Required to close connection to access output parameters
            this.Database.CloseConnection();
            outputs = this.Database.GetHydratedOutputParameters();
            return outputs;
        }        

        #endregion

        #region Private Fields

        private List<Func<DbDataReader, object>> recordMappers = new List<Func<DbDataReader, object>>();
        private OutputParameterCollection outputParameters = null; 

        #endregion

        #region Protected Properties

        protected List<Func<DbDataReader, object>> RecordMappers
        {
            get { return recordMappers; }
        }                    

        /// <summary>
        /// 
        /// </summary>
        /// 
        protected DataBaseManager Database { get; private set; }

        /// <summary>
        /// This property holds the name of the stored proc or inline SQL statement
        /// </summary>
        /// 
        protected string Statement { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// 
        protected string ConnectionString { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// 
        protected string SqlProvider { get; private set; }

        /// <summary>
        /// Determines if the call is to a stored proc or an inline SQL statement
        /// </summary>
        /// 
        protected Boolean IsStoredProc { get; private set; }

        #endregion

        #region Public Input Methods
        
        public void Map(Func<DbDataReader, object> objectRecordMapper)
        {
            recordMappers.Add(objectRecordMapper);
        }

        public void WithTransaction(DbTransaction transaction)
        {
            this.Database.Transaction = transaction;
        }

        public int CommandTimeout
        {
            set
            {
                this.Database.CommandTimeout = value;
            }
        }

        public int ConnectionTimeout
        {
            get
            {
               return (this.Database.ConnectionTimeout);
            }            
        }


        public void AddParameter(string parameterName, object value, DbType paramType, int paramSize)
        {
            this.Database.AddParameter(parameterName, value, paramType, paramSize);
        }


        public void AddParameter(string parameterName, object value, DbType paramType)
        {
            this.Database.AddParameter(parameterName, value, paramType, 0);
        }


        #endregion

        #region Internal Properties and Methods

        internal LinqTransaction CreateTransaction()
        {
            DbTransaction tran = null;
            try
            {
                tran = this.Database.CreateTransaction();
            }
            catch (Exception ex)
            {
                this.Database.DbConnection.Close();
                throw new LinqSqlException("A LinqSql Transaction Creation Error Ocurred: ", ex);
            }           
            return (new LinqTransaction(tran));
        }        

        #endregion

        #region Action Methods      

        public void Execute()
        {
            try
            {
                OutputParameterCollection pc;
                this.Execute(out pc);
            }
            #pragma warning disable
            catch (Exception ex)
            {
                throw;
            }
            #pragma warning restore
        }

        public void Execute<T>(T obj)
        {
            try
            {
                OutputParameterCollection pc;
                this.Execute<T>(obj, out pc);
            }
            #pragma warning disable
            catch (Exception ex)
            {
                throw;
            }
            #pragma warning restore
        }


        public T ExecuteScalar<T>()
        {
            T scalarVal = default(T);
            try
            {
                OutputParameterCollection pc;
                scalarVal = this.ExecuteScalar<T>(out pc);
            }
            #pragma warning disable //I'm just doing this to get rid of the pesky warning about not using the variable sse
            catch (Exception ex)
            {
                throw;
            }
            #pragma warning restore
            return (T)scalarVal;
            
        }


        public T Fetch<T>()
        {
            T obj = default(T);
            try
            {
                OutputParameterCollection pc;
                obj = this.Fetch<T>(out pc);
            }
            #pragma warning disable
            catch (Exception ex)
            {
                throw;
            }
            #pragma warning restore
            return obj;
        }        

        public List<T> FetchAll<T>()
        {
            List<T> objectList = new List<T>();
            try
            {
                OutputParameterCollection pc;
                objectList = FetchAll<T>(out pc);
            }
            #pragma warning disable
            catch (Exception ex)
            {
                throw;
            }
            #pragma warning restore
            return objectList;
        }        

        public MultiResult FetchMultiple()
        {            
            MultiResult resultSet = new MultiResult();
            
            try
            {
                OutputParameterCollection pc;
                resultSet = this.FetchMultiple(out pc);
            }
            #pragma warning disable
            catch (Exception ex)
            {
                throw;
            }
            #pragma warning restore
            return resultSet;
        }
     

        public DbDataReader FetchReader()
        {
            DbDataReader reader = null;
            try
            {
                reader = this.Database.FetchReader();
            }
            catch (Exception ex)
            {
                this.Database.Close();
                throw new LinqSqlException("A LinqSql FetchReader Exception Ocurred: ", ex);
            }
           return (reader);
        }

        public DataSet FetchDataSet()
        {
            DataSet ds = null;
            try
            {
                ds = this.Database.FetchDataSet();
            }
            catch (Exception ex)
            {
                this.Database.Close();
                throw new LinqSqlException("A LinqSql FetchDataSet Exception Ocurred: ", ex);
            }
            return ds;
        }

        #endregion


        #region Action Methods With Output Parameters
        
        public void Execute(out OutputParameterCollection parameterCollection)
        {
            try
            {
                this.Database.Save(out parameterCollection);
            }
            catch (Exception ex)
            {
                throw new LinqSqlException("A LinqSql Save Exception Ocurred: ", ex);
            }                
        }


        public void Execute<T>(T obj, out OutputParameterCollection parameterCollection)
        {
            try
            {
                this.Database.Save<T>(ObjectSqlAdapter.DeHydrateObject<T>(obj), out parameterCollection);
            }
            catch (Exception ex)
            {
                throw new LinqSqlException("A LinqSql Save Exception Ocurred: ", ex);
            }            
        }


        public T ExecuteScalar<T>(out OutputParameterCollection parameterCollection)
        {
            T scalarVal = default(T);
            try
            {
                scalarVal = this.Database.ExecuteScalar<T>(out parameterCollection);
            }
            catch (Exception ex)
            {
                throw new LinqSqlException("A LinqSql ExecuteScalar Exception Ocurred: ", ex);
            }            
            return (T)scalarVal;            
        }


        public T Fetch<T>(out OutputParameterCollection parameterCollection)
        {
            T obj = default(T);

            try
            {
                DbDataReader reader = this.Database.FetchReader();
                while (reader.Read())
                {
                    obj = MapRecordToObject<T>(reader);
                    break;
                }
                parameterCollection = PullOutputParameters();
            }
            catch (Exception ex)
            {
                throw new LinqSqlException("A LinqSql Fetch Exception Ocurred: ", ex);
            }
            finally
            {
                this.Database.Close();
            }
            
            return obj;
        }
        public DbDataReader Fetch(out OutputParameterCollection parameterCollection)
        {
            DbDataReader reader = null;
            try
            {
                reader = this.Database.FetchReader();
                while (reader.Read()) { }
                parameterCollection = PullOutputParameters();
            }
            catch (Exception ex)
            {
                throw new LinqSqlException("A LinqSql Fetch Exception Ocurred: ", ex);
            }
            finally
            {
                this.Database.Close();
            }

            return reader;
        }
        public List<T> FetchAll<T>(out OutputParameterCollection parameterCollection)
        {
            List<T> objectList = new List<T>();
            try
            {
                DbDataReader reader = this.Database.FetchReader();
                while (reader.Read())
                {                    
                    objectList.Add(MapRecordToObject<T>(reader));
                }
                parameterCollection = PullOutputParameters();
            }
            catch (Exception ex)
            {
                throw new LinqSqlException("A LinqSql FetchAll Exception Ocurred: ", ex);
            }
            finally
            {
                this.Database.Close();
            }
            
            return objectList;
        }
        //Added by Hari on 20th-Sept-2010
        public List<DbDataReader> FetchAll(out OutputParameterCollection parameterCollection)
        {
            List<DbDataReader> objectList = new List<DbDataReader>();
            try
            {
                DbDataReader reader = this.Database.FetchReader();
                while (reader.Read())
                {
                    objectList.Add(reader);
                }
                parameterCollection = PullOutputParameters();
            }
            catch (Exception ex)
            {
                throw new LinqSqlException("A LinqSql FetchAll Exception Ocurred: ", ex);
            }
            finally
            {
                this.Database.Close();
            }

            return objectList;
        }
        public MultiResult FetchMultiple(out OutputParameterCollection parameterCollection)
        {
            DbDataReader reader = this.Database.FetchReader();
            MultiResult resultSet = new MultiResult();

            try
            {
                int index = 0;
                do
                {
                    if (index >= recordMappers.Count()) { break; } //Guard clause to keep from invoking non-existant delegate
                    resultSet.AddResult(ProcessResult(reader, recordMappers[index]));
                    index++;

                } while (reader.NextResult());

                parameterCollection = PullOutputParameters();
            }
            catch (Exception ex)
            {
                throw new LinqSqlException("A LinqSql FetchMultiple Exception Ocurred: ", ex);
            }
            finally
            {
                this.Database.Close();
            }

            return resultSet;
        }

        #endregion        

    }
}
