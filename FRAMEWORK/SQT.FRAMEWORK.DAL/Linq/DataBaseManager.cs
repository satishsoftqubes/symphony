using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Data.SqlClient;

using SQT.FRAMEWORK.DAL.Linq.Exceptions;
using SQT.FRAMEWORK.DAL.Linq.Results;
using System.Globalization;

namespace SQT.FRAMEWORK.DAL.Linq
{
    public class DataBaseManager : IDisposable
    {
        #region Private Fields

        private DbProviderFactory providerFactory;
        private Dictionary<string, DbParameter> parameterCache = new Dictionary<string, DbParameter>();
        private OutputParameterCollection outputParameters = null;
        const string sqlProvider = "System.Data.SqlClient";
        private int commandTimeout = 300; //Default time out        

        #endregion

        #region Public Constructor(s)

        public DataBaseManager(string sqlStatement, string connectionString, string sqlProvider, bool isStoredProcedure)
        {            
            this.SetProviderType(sqlProvider);
            this.providerFactory = DbProviderFactories.GetFactory(sqlProvider);
            this.CreateCommand(sqlStatement, isStoredProcedure);
            this.CreateConnection(connectionString);
            this.outputParameters = new OutputParameterCollection();
        }

        #endregion

        #region Internal Properties

        internal Boolean IsStoredProcedure { get; private set; }

        internal DbConnection DbConnection { get; private set; }

        internal DbCommand DbCommand { get; private set; }

        internal DbParameter[] SqlParameters { get; set; }

        internal String SqlStatement { get; private set; }

        internal OutputParameterCollection OutputParameters
        {
            get { return outputParameters; }
            set { outputParameters = value; }
        }

        internal DbTransaction Transaction
        {            
            set
            {
                if (null != value)
                {
                    Debug.WriteLine("Setting an active transaction");
                }
                this.DbConnection = value.Connection;
                this.DbCommand.Transaction = value;
            }
        }       
    
        internal String ConnectionString { get; private set; }

        internal String SqlProviderType { get; private set; }  

        internal Int32 ConnectionTimeout
        {
            get { return this.DbConnection.ConnectionTimeout; }            
        }

        internal Int32 CommandTimeout
        {
            get { return commandTimeout; }
            set { commandTimeout = value; }
        }

        #endregion

        #region Internal Methods 

        internal DbTransaction CreateTransaction()
        {
            this.DbConnection.Open();
            return this.DbConnection.BeginTransaction();
        }   

        #endregion

        #region Private Methods

        private void AddToOutParameterCollection(string parameterName)
        {
            this.outputParameters.Add(parameterName, new OutputParameter(parameterName, null));
        }

        private void SetProviderType(string providerType)
        {
            this.SqlProviderType = providerType;
        }

        private void CreateCommand(string sqlStatement, bool isStoredProcedure)
        {
            this.DbCommand = this.providerFactory.CreateCommand();
            this.DbCommand.CommandType = (isStoredProcedure) ? CommandType.StoredProcedure : CommandType.Text;
            this.DbCommand.CommandText = sqlStatement;
            this.IsStoredProcedure = isStoredProcedure;
            this.SqlStatement = sqlStatement;
        }
        private void CreateCommand(string sqlStatement, bool isStoredProcedure, DbTransaction tran)
        {
            this.DbCommand = this.providerFactory.CreateCommand();
            this.DbCommand.CommandType = (isStoredProcedure) ? CommandType.StoredProcedure : CommandType.Text;
            this.DbCommand.CommandText = sqlStatement;
            this.Transaction = tran;
            this.IsStoredProcedure = isStoredProcedure;
            this.SqlStatement = sqlStatement;
        }

        private void CreateConnection(string connectionString)
        {
            this.DbConnection = this.providerFactory.CreateConnection();
            this.DbConnection.ConnectionString = connectionString;
            this.ConnectionString = connectionString;
        }

        private String StripParamPrefix(string paramName)
        {
            return (paramName.Replace("@","").Replace(":","").Replace("?",""));
        }        

        private void SetParameterValue(DbParameter param, object value)
        {
            param.Value = DBNull.Value;
            if (null != value && !isEmptyGuid(param.DbType, value) &&
                (param.Direction == ParameterDirection.Input ||
                    param.Direction == ParameterDirection.InputOutput))
            {
                param.Value = value;
            }
            else if (!isEmptyGuid(param.DbType, value) && param.Direction == ParameterDirection.InputOutput)
            {
                param.Value = "0";
            }
        }

        private Boolean isEmptyGuid(DbType dbType, object value)
        {
            return (dbType == DbType.Guid && value is Guid && (Guid)value == Guid.Empty);
        }

        private void SetParameterSize(DbParameter param, int size)
        {
            if (size == 0) { return; }
            if (
                param.DbType == DbType.String ||
                param.DbType == DbType.AnsiString ||
                param.DbType == DbType.StringFixedLength ||
                param.DbType == DbType.AnsiStringFixedLength
                )
            {
                param.Size = size;
            }
        }        

        private void AddParameters()
        {
            Debug.WriteLine("Is this a Stored Procedure? " + this.IsStoredProcedure.ToString());

            if (this.DbConnection is SqlConnection && this.IsStoredProcedure)
            {
                DeriveParameters();
                MapDerivedParameters(null);
            }
            else
            {
                if (parameterCache.Count() > 0)
                {
                    foreach (KeyValuePair<string, DbParameter> kvp in parameterCache)
                    {
                        this.DbCommand.Parameters.Add(kvp.Value);                        
                    }
                }
            }
            
        }

        private void MapDerivedParameters(DbParameter[] parameters)
        {
            DbParameter[] paramArray = (null == parameters) ? this.SqlParameters : parameters;
            foreach (DbParameter param in paramArray)
            {
                KeyValuePair<string, DbParameter> kvp = parameterCache.FirstOrDefault(p =>
                {
                    if (p.Key == param.ParameterName)
                    {
                        DbParameter thisParam = p.Value;

                        Debug.WriteLine(String.Concat("Param Name: ", param.ParameterName, ", Value: ", p.Value.Value));
                        if (thisParam.Direction == ParameterDirection.Input ||
                        thisParam.Direction == ParameterDirection.InputOutput)
                        {
                            this.DbCommand.Parameters[param.ParameterName].Value = p.Value.Value;
                        }
                        else
                        {
                            p.Value.Direction = ParameterDirection.Output;
                            this.DbCommand.Parameters[param.ParameterName].Value = (null == p.Value.Value) ? "0" : p.Value.Value;
                        }
                        return true;

                    }
                    return false;
                });
            }
        }

        private void DeriveParameters()
        {
            SqlCommandBuilder.DeriveParameters((SqlCommand)this.DbCommand);
            if (this.DbCommand.Parameters.Count > 0)
            {
                this.SqlParameters = new DbParameter[this.DbCommand.Parameters.Count];
                this.DbCommand.Parameters.CopyTo(SqlParameters, 0);
            }
        }

        #endregion

        #region Public Methods

        public void AddOutParameter(string parameterName, object value, DbType paramType, int size)
        {
            AddParameter(parameterName, value, paramType, size, ParameterDirection.Output);
        }

        public void AddOutParameter(string parameterName, object value)
        {
            AddParameter(parameterName, value, null, 0, ParameterDirection.Output);
        }

        public void AddOutParameter(string parameterName, DbType paramType)
        {
            AddParameter(parameterName, null, paramType, 0, ParameterDirection.Output);
        }

        public void AddParameter(string SqlServerParameterName, object SqlServerValue)
        {
            if (!(this.DbConnection is SqlConnection)) { throw new LinqSqlException("Your database must be SQL Server to use this Add Parameter Version (AddParameter(string SqlServerParameterName, object SqlServerValue))"); }
            if (null == SqlServerValue)
            { SqlServerValue = DBNull.Value; }
            //{ throw new LinqSqlException("The parameter value cannot be null!"); }

            string paramName = (SqlServerParameterName.StartsWith("@"))
                                    ? SqlServerParameterName
                                    : String.Concat("@", SqlServerParameterName);
            if (!parameterCache.ContainsKey(paramName))
            {
                DbParameter p = this.DbCommand.CreateParameter();
                p.ParameterName = paramName;
                p.Value = SqlServerValue;
                parameterCache.Add(paramName, p);
            }

        }        

        public void OpenConnection()
        {
            this.DbCommand.CommandTimeout = this.commandTimeout;
            this.DbCommand.Connection = this.DbConnection;
            Debug.WriteLine("ConnectionName: " + this.DbConnection.ConnectionString);
            if (null != this.DbConnection)
            {
                Debug.WriteLine("Connection State: " + DbConnection.State.ToString());
            }
            if (null != this.DbConnection &&
                this.DbConnection.State == ConnectionState.Closed)
            {
                this.DbConnection.Open();
            }            
        }

        public void AddParameter(string parameterName, object value, DbType paramType, int paramSize)
        {
            AddParameter(parameterName, value, paramType, paramSize, ParameterDirection.Input);
        }

        public void AddParameter(string parameterName, object value, DbType? paramType, int paramSize, ParameterDirection direction)
        {
            if (direction == ParameterDirection.Output ||
                direction == ParameterDirection.InputOutput)
            {
                AddToOutParameterCollection(parameterName);
            }
            DbParameter param = this.providerFactory.CreateParameter();
            param.ParameterName = parameterName;
            if (paramType.HasValue)
            {
                param.DbType = paramType.Value;
            }
            param.Direction = direction;
            SetParameterSize(param, paramSize);
            SetParameterValue(param, value);
            parameterCache.Add(parameterName, param);
        }

        #endregion

        #region Action Methods

        public void Save()
        {
            OutputParameterCollection outParam; //dummy out param catcher
            Save(out outParam);            
        }             

        public void Save<T>(Action<DbCommand> procParameterMapper)
        {
            OutputParameterCollection outParam;
            Save<T>(procParameterMapper, out outParam);
        }

        public T ExecuteScalar<T>()
        {
            OutputParameterCollection outParam;
            return (T)this.ExecuteScalar<T>(out outParam);
        }

        public DbDataReader FetchReader()
        {
            OpenConnection();
            AddParameters();
            DbDataReader reader = this.DbCommand.ExecuteReader(CommandBehavior.CloseConnection);            
            return reader;
        }

        public DataSet FetchDataSet()
        {
            OpenConnection();
            AddParameters();
            DataSet ds = new DataSet() { Locale = CultureInfo.InvariantCulture };
            DbDataAdapter da = this.providerFactory.CreateDataAdapter();
            da.SelectCommand = this.DbCommand;            
            da.Fill(ds);
            this.Close();
            return ds;
        }

        public void Close()
        {           
            CloseConnection();         
            CloseCommand();            
        }        

        public void CloseConnection()
        {
            if (null != this.DbConnection &&
                this.DbConnection.State == ConnectionState.Open &&
                null == this.DbCommand.Transaction)
            {
                this.DbConnection.Close();
            }
        }

        public void CloseCommand()
        {
            this.DbCommand.Dispose();
        }


        #endregion

        #region Action Methods With Output Parameters
        
        public T ExecuteScalar<T>(out OutputParameterCollection outputParameters)
        {
            T scalarNum = default(T);
            try
            {
                OpenConnection();
                AddParameters();
                scalarNum = (T)this.DbCommand.ExecuteScalar();
                outputParameters = GetHydratedOutputParameters();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Close();
            }
            
            return scalarNum;
        }

        public void Save<T>(Action<DbCommand> procParameterMapper, out OutputParameterCollection outputParameters)
        {
            OpenConnection();
            this.DeriveParameters();
            procParameterMapper.Invoke(this.DbCommand);
            this.DbCommand.ExecuteNonQuery();            
            outputParameters = GetHydratedOutputParameters();
            this.Close();
        }

        public void Save(out OutputParameterCollection outputParameters)
        {
            try
            {
                OpenConnection();
                AddParameters();
                this.DbCommand.CommandTimeout =0;
                this.DbCommand.ExecuteNonQuery();
                outputParameters = GetHydratedOutputParameters();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {                                    
               this.Close();                
            }
        }        

        internal OutputParameterCollection GetHydratedOutputParameters()
        {            
            if (this.OutputParameters.Count > 0)
            {
                this.CloseConnection(); //Have to close the connection before I can retrieve output parameters
                for (int i = 0; i < this.OutputParameters.Count; i++)
                {
                    OutputParameter oParam = this.OutputParameters.GetValue(i);
                    if (null != oParam)
                    {
                        this.OutputParameters.SetValue(oParam.Name, this.DbCommand.Parameters[oParam.Name].Value);
                    }
                }
                return this.OutputParameters;
            }
            return null;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
