using System;
using System.Configuration;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Text;
//using System.Windows.Forms;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.IO;

namespace SQT.FRAMEWORK.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public enum DataProvider
    {
        SqlClient, Oracle, SqlServer, OleDb, Odbc
    }
    /// <summary>
    /// 
    /// </summary>
    public sealed class DBManagerFactory
    {
        private DBManagerFactory()
        { }
        public static string GetConnectionString(DataProvider providerType)
        {
            string cs = string.Empty;
            switch (providerType)
            {
                case DataProvider.SqlClient:
                    cs = ConfigurationSettings.AppSettings["SQLConnection"].ToString();
                    break;
                case DataProvider.SqlServer:
                    cs = ConfigurationSettings.AppSettings["SQLConnection"].ToString();
                    break;
                case DataProvider.OleDb:
                    cs = ConfigurationSettings.AppSettings["OleDbConnection"].ToString();
                    break;
                case DataProvider.Odbc:
                    cs = ConfigurationSettings.AppSettings["OdbcConnection"].ToString();
                    break;
                case DataProvider.Oracle:
                    cs = ConfigurationSettings.AppSettings["OracleConnection"].ToString();
                    break;
                default:
                    return null;
            }
            return cs;
        }
        public static IDbConnection GetConnection(DataProvider providerType)
        {
            IDbConnection iDbConnection = null;
            switch (providerType)
            {
                case DataProvider.SqlClient:
                    iDbConnection = new SqlConnection();
                    break;
                case DataProvider.SqlServer:
                    iDbConnection = new SqlConnection();
                    break;
                case DataProvider.OleDb:
                    iDbConnection = new OleDbConnection();
                    break;
                case DataProvider.Odbc:
                    iDbConnection = new OdbcConnection();
                    break;
                case DataProvider.Oracle:
                    iDbConnection = new OracleConnection();
                    break;
                default:
                    return null;
            }
            return iDbConnection;
        }
        public static IDbCommand GetCommand(DataProvider providerType)
        {
            switch (providerType)
            {
                case DataProvider.SqlClient:
                    return new SqlCommand();
                case DataProvider.SqlServer:
                    return new SqlCommand();
                case DataProvider.OleDb:
                    return new OleDbCommand();
                case DataProvider.Odbc:
                    return new OdbcCommand();
                case DataProvider.Oracle:
                    return new OracleCommand();
                default:
                    return null;
            }
        }
        public static IDbDataAdapter GetDataAdapter(DataProvider providerType)
        {
            switch (providerType)
            {
                case DataProvider.SqlClient:
                    return new SqlDataAdapter();
                case DataProvider.SqlServer:
                    return new SqlDataAdapter();
                case DataProvider.OleDb:
                    return new OleDbDataAdapter();
                case DataProvider.Odbc:
                    return new OdbcDataAdapter();
                case DataProvider.Oracle:
                    return new OracleDataAdapter();
                default:
                    return null;
            }
        }
        public static IDbTransaction GetTransaction(IDbConnection objIDbConnection)
        {
            IDbConnection iDbConnection = objIDbConnection;
            IDbTransaction iDbTransaction = iDbConnection.BeginTransaction(IsolationLevel.ReadUncommitted );
            return iDbTransaction;
        }
        public static IDataParameter GetParameter(DataProvider providerType)
        {
            IDataParameter iDataParameter = null;
            switch (providerType)
            {
                case DataProvider.SqlClient:
                    iDataParameter = new SqlParameter();
                    break;
                case DataProvider.SqlServer:
                    iDataParameter = new SqlParameter();
                    break;
                case DataProvider.OleDb:
                    iDataParameter = new OleDbParameter();
                    break;
                case DataProvider.Odbc:
                    iDataParameter = new OdbcParameter();
                    break;
                case DataProvider.Oracle:
                    iDataParameter = new OracleParameter();
                    break;
            }
            return iDataParameter;
        }
        public static IDbDataParameter[] GetParameters(DataProvider providerType, int paramsCount)
        {
            IDbDataParameter[] idbParams = new IDbDataParameter[paramsCount];
            switch (providerType)
            {
                case DataProvider.SqlClient:
                    for (int i = 0; i < paramsCount; ++i)
                    {
                        idbParams[i] = new SqlParameter();
                    }
                    break;
                case DataProvider.SqlServer:
                    for (int i = 0; i < paramsCount; ++i)
                    {
                        idbParams[i] = new SqlParameter();
                    }
                    break;
                case DataProvider.OleDb:
                    for (int i = 0; i < paramsCount; ++i)
                    {
                        idbParams[i] = new OleDbParameter();
                    }
                    break;
                case DataProvider.Odbc:
                    for (int i = 0; i < paramsCount; ++i)
                    {
                        idbParams[i] = new OdbcParameter();
                    }
                    break;
                case DataProvider.Oracle:
                    for (int i = 0; i < paramsCount; ++i)
                    {
                        idbParams[i] = new OracleParameter();
                    }
                    break;
                default:
                    idbParams = null;
                    break;
            }
            return idbParams;
        }
        public static IDbDataAdapter GetDataAdapter(DataProvider providerType, string strAnsiSQL, string strConn)
        {
            IDbDataAdapter DataAdapter = null;
            switch (providerType)
            {
                case DataProvider.SqlClient:
                    DataAdapter = new SqlDataAdapter(strAnsiSQL, strConn);
                    break;
                case DataProvider.SqlServer:
                    DataAdapter = new SqlDataAdapter(strAnsiSQL, strConn);
                    break;
                case DataProvider.OleDb:
                    DataAdapter = new OleDbDataAdapter(strAnsiSQL, strConn);
                    break;
                case DataProvider.Odbc:
                    DataAdapter = new OdbcDataAdapter(strAnsiSQL, strConn);
                    break;
                case DataProvider.Oracle:
                    DataAdapter = new OracleDataAdapter(strAnsiSQL, strConn);
                    break;
            }
            return DataAdapter;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    //public class DBManager : MarshalByRefObject, IDisposable
    public class DBManager
    {
        #region Private Variable Declaration
        private IDbConnection idbConnection;
        private IDataReader idataReader;
        private IDbCommand idbCommand;
        private DataProvider providerType;
        private IDbTransaction idbTransaction = null;
        private IDbDataParameter[] idbParameters = null;
        private IDataParameter iParameter = null;
        private IDbDataAdapter dataAdapter;
        private string strConnection;
        private string strDataSource;
        private string strInitialCatalog;
        private string strUserName;
        private string strPassword;
        private int intTimeOut = 180;

        #endregion Private Variable Declaration

        #region Public Variable Declaration
        /// <summary>
        /// 
        /// </summary>
        public string DataSource { get { return this.strDataSource; } set { this.strDataSource = value; } }
        /// <summary>
        /// 
        /// </summary>
        public string InitialCatalog { get { return this.strInitialCatalog; } set { this.strInitialCatalog = value; } }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get { return this.strUserName; } set { this.strUserName = value; } }
        /// <summary>
        /// 
        /// </summary>
        public string Password { get { return this.strPassword; } set { this.strPassword = value; } }
        /// <summary>
        /// 
        /// </summary>
        public int TimeOut { get { return this.intTimeOut; } set { this.intTimeOut = value; } }
        /// <summary>
        /// 
        /// </summary>
        public IDbConnection Connection { get { return idbConnection; } set { this.idbConnection = value; } }
        /// <summary>
        /// 
        /// </summary>
        public IDataReader DataReader { get { return idataReader; } set { idataReader = value; } }
        /// <summary>
        /// 
        /// </summary>
        public DataProvider ProviderType { get { return providerType; } set { providerType = value; } }
        /// <summary>
        /// 
        /// </summary>
        public string ConnectionString { get { return strConnection; } set { strConnection = value; } }
        /// <summary>
        /// 
        /// </summary>
        public IDbCommand Command { get { return idbCommand; } set { this.idbCommand = value; } }
        /// <summary>
        /// 
        /// </summary>
        public IDbTransaction Transaction { get { return idbTransaction; } set { this.idbTransaction = value; } }
        /// <summary>
        /// 
        /// </summary>
        public IDbDataParameter[] Parameters { get { return idbParameters; } }
        /// <summary>
        /// 
        /// </summary>
        public IDataParameter Parameter { get { return iParameter; } }
        /// <summary>
        /// 
        /// </summary>
        public DataView dv;
        /// <summary>
        /// 
        /// </summary>
        public DataSet dst;
        /// <summary>
        /// 
        /// </summary>
        public SqlCommandBuilder autogenSQL;
        /// <summary>
        /// 
        /// </summary>
        public OracleCommandBuilder autogenOracle;
        /// <summary>
        /// 
        /// </summary>
        public OleDbCommandBuilder autogenOleDb;
        /// <summary>
        /// 
        /// </summary>
        private ArrayList arlReturnValues;
        public SqlDataAdapter sqlDA;
        public SqlCommandBuilder autogenSQLCommand;
        public OracleCommandBuilder autogenOracleCommand;
        public OracleDataAdapter oraDA;
        public OleDbCommandBuilder autogenOleDbCommand;
        public OleDbDataAdapter oledbDA;
        public OdbcCommandBuilder autogenOdbcCommand;
        public OdbcDataAdapter odbcDA;
        #endregion Public Variable Declaration

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public DBManager()
        {
            this.providerType = DataProvider.SqlClient;
            //this.ConnectionString = DBConnection.Default.SQL;
            this.ConnectionString = DBManagerFactory.GetConnectionString(this.providerType);
        }
        /// <summary>
        /// Constructor for Initializing the Connection String
        /// </summary>
        /// <param name="CS">Set the Connection String</param>
        public DBManager(string CS)
        {
            this.providerType = DataProvider.SqlClient;
            this.ConnectionString = CS;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerType"></param>
        public DBManager(DataProvider providerType)
        {
            this.providerType = providerType;
            this.ConnectionString = DBManagerFactory.GetConnectionString(this.providerType);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbm"></param>
        public DBManager(DBManager dbm)
        {
            this.providerType = dbm.providerType;
            this.ConnectionString = dbm.ConnectionString;
            this.Connection = dbm.Connection;
            this.Transaction = dbm.Transaction;
            this.Command = dbm.Command;
        }
        #endregion Constructor

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        private void Open()
        {
            try
            {
                idbConnection = DBManagerFactory.GetConnection(this.providerType);
                idbConnection.ConnectionString = this.ConnectionString;
                if (idbConnection.State != ConnectionState.Open)
                    idbConnection.Open();
                this.idbCommand = DBManagerFactory.GetCommand(this.ProviderType);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public string GetConnectionString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Data Source=" + strDataSource);
            sb.Append(";Initial Catalog=" + strInitialCatalog);
            sb.Append(";User ID=" + strUserName);
            sb.Append(";Password=" + strPassword);
            sb.Append(";Timeout=" + intTimeOut.ToString());
            return sb.ToString();
        }
        public void SetConnectionObject()
        {
            string[] splitCS = this.ConnectionString.Split(new char[] { '=' });
            if (splitCS.Length == 6)
            {
                intTimeOut = Convert.ToInt32(splitCS[5]);
                for (int i = 0; i < splitCS.Length; i++)
                {
                    if (i == 0 || i == 5)
                        continue;
                    string[] sptemp = splitCS[i].Split(new char[] { ';' });
                    for (int j = 0; j < sptemp.Length; j++)
                    {
                        switch (i)
                        {
                            case 1:
                                strDataSource = sptemp[0];
                                break;
                            case 2:
                                strInitialCatalog = sptemp[0];
                                break;
                            case 3:
                                strUserName = sptemp[0];
                                break;
                            case 4:
                                strPassword = sptemp[0];
                                break;
                        }
                    }
                }
                LoadConnectionString();
            }
        }
        public void LoadConnectionString()
        {
            this.ConnectionString = GetConnectionString();
        }
        /// <summary>
        /// 
        /// </summary>
        private void Close()
        {
            if (idbConnection.State != ConnectionState.Closed)
                idbConnection.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Close();
            this.idbCommand = null;
            this.idbTransaction = null;
            this.idbConnection = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramsCount"></param>
        public void CreateParameters(int paramsCount)
        {
            idbParameters = DBManagerFactory.GetParameters(this.ProviderType, paramsCount);
            arlReturnValues = new ArrayList(paramsCount);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="paramName"></param>
        /// <param name="objValue"></param>
        public void AddParameters(int index, string paramName, object objValue)
        {
            if (index < idbParameters.Length)
            {
                idbParameters[index].ParameterName = paramName;
                idbParameters[index].Value = objValue;
                arlReturnValues.Add(objValue);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="paramName"></param>
        /// <param name="objValue"></param>
        /// <param name="isReturn"></param>
        public void AddParameters(int index, string paramName, object objValue, bool isReturn)
        {
            if (!isReturn)
            {
                if (index < idbParameters.Length)
                {
                    idbParameters[index].ParameterName = paramName;
                    idbParameters[index].Value = objValue;
                    arlReturnValues.Add(objValue);
                }
            }
            else
            {
                if (index < idbParameters.Length)
                {
                    idbParameters[index].ParameterName = paramName;
                    idbParameters[index].Value = objValue;
                    idbParameters[index].Direction = ParameterDirection.ReturnValue;
                    arlReturnValues.Add(objValue);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="paramName"></param>
        /// <param name="objValue"></param>
        /// <param name="pd"></param>
        /// <param name="size"></param>
        public void AddParameters(int index, string paramName, object objValue, ParameterDirection pd, int size)
        {
            if (index < idbParameters.Length)
            {
                idbParameters[index].ParameterName = paramName;
                idbParameters[index].Value = objValue;
                idbParameters[index].Direction = pd;
                idbParameters[index].Size = size;
                arlReturnValues.Add(objValue);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void BeginTransaction()
        {
            Open();
            if (this.idbTransaction == null)
                idbTransaction = DBManagerFactory.GetTransaction(this.idbConnection);
            this.idbCommand.Transaction = idbTransaction;
        }
        /// <summary>
        /// 
        /// </summary>
        public void CommitTransaction()
        {
            if (this.idbTransaction != null)
                this.idbTransaction.Commit();
            idbTransaction = null;
            Close();
        }
        /// <summary>
        /// 
        /// </summary>
        public void RollBackTransaction()
        {
            if (this.idbTransaction != null)
                this.idbTransaction.Rollback();
            idbTransaction = null;
            Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="cb"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(CommandType commandType, string commandText, CommandBehavior cb)
        {
            this.idbCommand = DBManagerFactory.GetCommand(this.ProviderType);
            if (this.idbConnection != null)
            {
                if (this.idbConnection.State != ConnectionState.Open && this.idbTransaction == null)
                    Open();
            }
            else
                Open();
            idbCommand.Connection = this.Connection;
            PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.Parameters);
            this.DataReader = idbCommand.ExecuteReader(cb);
            idbCommand.Parameters.Clear();
            return this.DataReader;
        }
        /// <summary>
        /// 
        /// </summary>
        public void CloseReader()
        {
            if (this.DataReader != null)
                this.DataReader.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="commandParameters"></param>
        private void AttachParameters(IDbCommand command, IDbDataParameter[] commandParameters)
        {
            foreach (IDbDataParameter idbParameter in commandParameters)
            {
                if ((idbParameter.Direction == ParameterDirection.InputOutput) && (idbParameter.Value == null))
                {
                    idbParameter.Value = DBNull.Value;
                }
                command.Parameters.Add(idbParameter);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        private void PrepareCommand(IDbCommand command, IDbConnection connection, IDbTransaction transaction, CommandType commandType, string commandText, IDbDataParameter[] commandParameters)
        {
            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = commandType;
            if (transaction != null)
                command.Transaction = transaction;
            if (commandParameters != null)
                AttachParameters(command, commandParameters);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            int returnValue = 0;
            this.idbCommand = DBManagerFactory.GetCommand(this.ProviderType);
            if (this.idbConnection != null)
            {
                if (this.idbConnection.State != ConnectionState.Open && this.idbTransaction == null)
                    Open();
            }
            else
                Open();
            PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.Parameters);
            returnValue = idbCommand.ExecuteNonQuery();
            SetReturnValues();
            if (this.idbConnection.State != ConnectionState.Closed && this.idbTransaction == null)
                Close();
            idbCommand.Parameters.Clear();
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        public void BeginExecuteNonQuery(CommandType commandType, string commandText)
        {
            this.idbCommand = DBManagerFactory.GetCommand(this.ProviderType);
            if (this.idbConnection != null)
            {
                if (this.idbConnection.State != ConnectionState.Open && this.idbTransaction == null)
                    Open();
            }
            else
                Open();
            PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.Parameters);
            SqlCommand scmd = (SqlCommand)idbCommand;
            scmd.BeginExecuteNonQuery(new AsyncCallback(ExecuteThread), scmd);
            if (this.idbConnection.State != ConnectionState.Closed)
                Close();
            idbCommand.Parameters.Clear();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ar"></param>
        static void ExecuteThread(IAsyncResult ar)
        {
            SqlCommand originalCommand = (SqlCommand)ar.AsyncState;
            originalCommand.EndExecuteNonQuery(ar);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public object ExecuteScalar(CommandType commandType, string commandText)
        {
            this.idbCommand = DBManagerFactory.GetCommand(this.ProviderType);
            if (this.idbConnection != null)
            {
                if (this.idbConnection.State != ConnectionState.Open && this.idbTransaction == null)
                    Open();
            }
            else
                Open();
            PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.Parameters);
            object returnValue = idbCommand.ExecuteScalar();
            if (this.idbConnection.State != ConnectionState.Closed && this.idbTransaction == null)
                Close();
            idbCommand.Parameters.Clear();
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(CommandType commandType, string commandText)
        {
            this.idbCommand = DBManagerFactory.GetCommand(this.ProviderType);
            if (this.idbConnection != null)
            {
                if (this.idbConnection.State != ConnectionState.Open && this.idbTransaction == null)
                    Open();
            }
            else
                Open();
            PrepareCommand(idbCommand, this.Connection, this.Transaction, commandType, commandText, this.Parameters);
            dataAdapter = DBManagerFactory.GetDataAdapter(this.ProviderType);
            idbCommand.Connection = idbConnection;
            dataAdapter.SelectCommand = idbCommand;
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            if (this.idbConnection.State != ConnectionState.Closed && this.idbTransaction == null)
                Close();
            idbCommand.Parameters.Clear();
            return dataSet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DBManager GetRunningDBManager()
        {
            DBManager dbm = new DBManager();
            dbm.providerType=this.providerType;
            dbm.ConnectionString=this.ConnectionString;
            dbm.Connection = this.Connection;
            dbm.Transaction = this.Transaction;
            dbm.Command = this.Command;
            return dbm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbm"></param>
        public void LoadRunningDBManager(DBManager dbm)
        {
            this.providerType = dbm.providerType;
            this.ConnectionString = dbm.ConnectionString;
            this.Connection = dbm.Connection;
            this.Transaction = dbm.Transaction;
            this.Command = dbm.Command;
        }

        /// <summary>
        /// Check for Connectivity with Database
        /// </summary>
        /// <returns>Return True or False for Connection is available or not...</returns>
        public static bool CheckDBConnectivity()
        {
            try
            {
                IDbConnection con = DBManagerFactory.GetConnection(DataProvider.SqlClient);
                con.ConnectionString = DBConnection.Default.SQL;
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public static bool CheckDBConnectivity(string ConsString)
        {
            try
            {
                IDbConnection con = DBManagerFactory.GetConnection(DataProvider.SqlClient);
                con.ConnectionString = ConsString;
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// Get the Current Date & Time from  the server..."
        /// </summary>
        /// <returns>Return Current DateTime of the DB Server</returns>
        public static DateTime GetServerDateTime()
        {
            DBManager db  = new DBManager();
            DateTime currentDateTime = Convert.ToDateTime(db.ExecuteScalar(CommandType.Text, "Select getdate()"));
            return currentDateTime;
        }

        /// <summary>
        /// The DataAdapter is the class at the core of ADO .NET's disconnected data access.
        /// It is essentially the middleman facilitating all communication between the database and a DataSet.
        /// The DataAdapter is used either to fill a DataTable or DataSet with data from the database with it's Fill method.
        /// After the memory-resident data has been manipulated,
        /// the DataAdapter can commit the changes to the database by calling the Update method. 
        /// The DataAdapter provides four properties that represent database commands: 
        /// 		SelectCommand
        /// 		InsertCommand
        /// 		DeleteCommand
        /// 		UpdateCommand 
        /// When the Update method is called,
        /// changes in the DataSet are copied back to the database and the 
        /// appropriate InsertCommand, DeleteCommand, or UpdateCommand is executed.
        /// </summary>
        /// <param name="ProviderType">ProviderType which specify for which provider you have to use</param>
        /// <param name="TableName">Name of the Table on which we have to fatch the data</param>
        public void AutoGenerateCommand(DataProvider ProviderType, string TableName)
        {
            dst = new DataSet();
            string strQuery = "Select * from " + TableName;
            Open();
            switch (ProviderType)
            {
                case DataProvider.SqlServer:
                    sqlDA = new SqlDataAdapter(strQuery, (SqlConnection)Connection);
                    SqlCommandBuilder autogenSQL1 = new SqlCommandBuilder(sqlDA);
                    sqlDA.Fill(dst, TableName);
                    break;
                case DataProvider.SqlClient:
                    sqlDA = new SqlDataAdapter(strQuery, (SqlConnection)Connection);
                    autogenSQLCommand = new SqlCommandBuilder(sqlDA);
                    sqlDA.Fill(dst, TableName);
                    break;
                case DataProvider.Oracle:
                    oraDA = new OracleDataAdapter(strQuery, (OracleConnection)Connection);
                    autogenOracleCommand = new OracleCommandBuilder(oraDA);
                    oraDA.Fill(dst, TableName);
                    break;
                case DataProvider.OleDb:
                    oledbDA = new OleDbDataAdapter(strQuery, (OleDbConnection)Connection);
                    autogenOleDbCommand = new OleDbCommandBuilder(oledbDA);
                    oledbDA.Fill(dst, TableName);
                    break;
                case DataProvider.Odbc:
                    odbcDA = new OdbcDataAdapter(strQuery, (OdbcConnection)Connection);
                    autogenOdbcCommand = new OdbcCommandBuilder(odbcDA);
                    odbcDA.Fill(dst, TableName);
                    break;
                default:
                    break;
            }
            Close();
            dv = new DataView(dst.Tables[TableName]);
        }

        /// <summary>
        /// 
        /// </summary>
        protected void SetReturnValues()
        {
            if (idbParameters != null)
            {
                for (int i = 0; i < idbParameters.Length; i++)
                {
                    if (idbParameters[i].Direction == ParameterDirection.Output)
                        arlReturnValues[i] = idbParameters[i].Value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public object GetReturnValue(int Index)
        {
            return arlReturnValues[Index];
        }
        #endregion Methods
    }
}
