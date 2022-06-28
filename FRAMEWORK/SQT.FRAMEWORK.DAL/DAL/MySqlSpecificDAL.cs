using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Diagnostics;

namespace SQT.FRAMEWORK.DAL
{
    public class MySqlSpecificDAL : IDisposable 
    {
        public static readonly TraceSource TraceSource = new TraceSource("SqlStoredProcedure");
        private static int eventId = 0;
        private string ConnString;
        private SqlConnection con;
        private const string returnValue = "ReturnValue";
        private SqlCommand command;
        private bool connectionOpened = false;

        public MySqlSpecificDAL()
        {
            ConnString = DBConnection.Default.SQL;
            con = new SqlConnection(ConnString);
        }

        public MySqlSpecificDAL(string name, SqlConnection connection)  : this(name, connection, null) 
        {
            
        }


        public MySqlSpecificDAL(string name, SqlConnection connection, SqlTransaction transaction) 
        {
            //if (name.IndexOf('.') == -1) 
            //{
            //    throw new ArithmeticException("In the name the owner of a procedure must be specified, this improves performance");
            //}
            con = connection;
            command = new SqlCommand(name, connection, transaction);
            command.CommandTimeout = 1000;
            command.CommandType = CommandType.StoredProcedure;
            AddReturnValue();
        }

        public void Dispose()
        {
            if (command != null) 
            {
                command.Dispose();
                command = null;
            }
        }

        virtual public string Name 
        {
            get { return command.CommandText; }
            set { command.CommandText = value; }
        }

        virtual public int Timeout 
        {
            get { return command.CommandTimeout; }
            set { command.CommandTimeout = value; }
        }

        virtual public SqlCommand Command 
        {
            get { return command; }
        }

        virtual public SqlConnection Connection 
        {
            get { return command.Connection; }
            set { command.Connection = value; }
        }

        virtual public SqlTransaction Transaction 
        {
            get { return command.Transaction; }
            set { command.Transaction = value; }
        }

        virtual public SqlParameterCollection Parameters 
        {
            get { return command.Parameters; }
        }

        virtual public int ReturnValue 
        {
            get { return (int)command.Parameters[returnValue].Value; }
        }

        virtual public SqlParameter AddParameter(string parameterName,SqlDbType dbType,int size, ParameterDirection direction) 
        {
            SqlParameter p;
            if (size > 0) 
            {
                p = new SqlParameter(parameterName, dbType, size);
            } 
            else 
            {
                p = new SqlParameter(parameterName, dbType);
            }
            p.Direction = direction;
            Parameters.Add(p);
            return p;
        }

        virtual public SqlParameter AddParameterWithValue(string parameterName,SqlDbType dbType, int size, ParameterDirection direction,object value) 
        {
            SqlParameter p = this.AddParameter(parameterName, dbType, size, direction);
            if (value == null) 
                value = DBNull.Value;
            p.Value = value;
            return p;
        }
        virtual public SqlParameter AddParameterWithStringValue(string parameterName,SqlDbType dbType,int size,ParameterDirection direction,string value,bool emptyIsDBNull) 
        {
            SqlParameter p = this.AddParameter(parameterName, dbType, size, direction);
            if (value == null) 
                p.Value = DBNull.Value;
            else 
            {
                value = value.TrimEnd(' ');
                if (emptyIsDBNull && value.Length == 0) 
                    p.Value = DBNull.Value;
                else 
                    p.Value = value;
            }
            return p;
        }
        virtual protected SqlParameter AddReturnValue() 
        {
            SqlParameter p = Parameters.Add(new SqlParameter(returnValue,SqlDbType.Int,4,ParameterDirection.ReturnValue,false,0,0,string.Empty,DataRowVersion.Default,null));
            return p;
        }

        virtual public int ExecuteNonQuery() 
        {
            int rowsAffected = -1;
            try 
            {
                Prepare("ExecuteNonQuery");
                rowsAffected = command.ExecuteNonQuery();
                TraceResult("RowsAffected = " + rowsAffected.ToString());
            } 
            catch (SqlException e) 
            {
                throw TranslateException(e);
            } 
            finally 
            {
                CloseOpenedConnection();
            }
            return rowsAffected;
        }

        virtual public SqlDataReader ExecuteReader() 
        {
            SqlDataReader reader;
            try 
            {
                Prepare("ExecuteReader");
                reader = command.ExecuteReader();
                TraceResult(null);
            } 
            catch (SqlException e) 
            {
                throw TranslateException(e);
            } 
            finally 
            {
                CloseOpenedConnection();
            }
            return reader;
        }

        virtual public SqlDataReader ExecuteReader(CommandBehavior behavior) 
        {
            SqlDataReader reader;
            try 
            {
                Prepare("ExecuteReader");

                reader = command.ExecuteReader(behavior);

                TraceResult(null);
            } 
            catch (SqlException e) 
            {
                throw TranslateException(e);
            } 
            finally 
            {
                CloseOpenedConnection();
            }
            return reader;
        }
        virtual public object ExecuteScalar() 
        {
            object val = null;
            try 
            {
                Prepare("ExecuteScalar");
                val = command.ExecuteScalar();
                TraceResult("Scalar Value = " + Convert.ToString(val));
            } 
            catch (SqlException e) 
            {
                throw TranslateException(e);
            } 
            finally 
            {
                CloseOpenedConnection();
            }
            return val;
        }
        virtual public XmlReader ExecuteXmlReader() 
        {
            XmlReader reader;
            try 
            {
                Prepare("ExecuteXmlReader");
                reader = command.ExecuteXmlReader();
                TraceResult(null);
            } 
            catch (SqlException e) 
            {
                throw TranslateException(e);
            } 
            finally 
            {
                CloseOpenedConnection();
            }
            return reader;
        }
        virtual public DataSet ExecuteDataSet() 
        {
            DataSet dataset = new DataSet();
            this.ExecuteDataSet(dataset);
            return dataset;
        }
        virtual public DataSet ExecuteDataSet(DataSet dataSet) 
        {
            try 
            {
                Prepare("ExecuteDataSet");
                SqlDataAdapter a = new SqlDataAdapter(this.Command);
                a.Fill(dataSet);
                TraceResult("# Tables in DataSet = " + dataSet.Tables.Count);
            } 
            catch (SqlException e) 
            {
                throw TranslateException(e);
            } 
            finally 
            {
                CloseOpenedConnection();
            }
            return dataSet;
        }
        virtual public DataTable ExecuteDataTable() 
        {
            DataTable dt = null;
            try 
            {
                Prepare("ExecuteDataTable");
                SqlDataAdapter a = new SqlDataAdapter(this.Command);
                dt = new DataTable();
                a.Fill(dt);
                TraceResult("# Rows in DataTable = " + dt.Rows.Count);
            } 
            catch (SqlException e) 
            {
                throw TranslateException(e);
            } 
            finally 
            {
                CloseOpenedConnection();
            }
            return dt;
        }

        protected Exception TranslateException(SqlException ex) 
        {
            Exception dalException = null;
            MySqlSpecificDAL.TraceSource.TraceEvent(TraceEventType.Error, eventId, "{0} throwed exception: {1}", this.Name, ex.ToString());
            foreach (SqlError error in ex.Errors) 
            {
                if (error.Number >= 50000) 
                    dalException = new DalException(error.Message, ex);
            }
            if (dalException == null) 
            {
                switch (ex.Number) 
                {
                    case 17:
                    // 	SQL Server does not exist or access denied.
                    case 4060:
                    // Invalid Database
                    case 18456:
                        // Login Failed
                        dalException = new DalLoginException(ex.Message, ex);
                        break;
                    case 547:
                        // ForeignKey Violation
                        dalException = new DalForeignKeyException(ex.Message, ex);
                        break;
                    case 1205:
                        // DeadLock Victim
                        dalException = new DalDeadLockException(ex.Message, ex);
                        break;
                    case 2627:
                    case 2601:
                        // Unique Index/Constriant Violation
                        dalException = new DalUniqueConstraintException(ex.Message, ex);
                        break;
                    default:
                        // throw a general DAL Exception
                        dalException = new DalException(ex.Message, ex);
                        break;
                }
            }
            return dalException;
        }
        protected void Prepare(string executeType) 
        {
            eventId++;
            if (eventId > ushort.MaxValue) 
                eventId = 0;
            MySqlSpecificDAL.TraceSource.TraceEvent(TraceEventType.Information, eventId, "{0}: {1}", executeType, this.Name);
            TraceParameters(true);
            if (command.Connection.State != ConnectionState.Open) 
            {
                command.Connection.Open();
                connectionOpened = true;
            }
        }

        private void TraceParameters(bool input) 
        {
            if (MySqlSpecificDAL.TraceSource.Switch.ShouldTrace(TraceEventType.Verbose) && this.Parameters.Count > 0) 
            {
                foreach (SqlParameter p in this.Parameters) 
                {
                    bool isInput = p.Direction != ParameterDirection.ReturnValue && p.Direction != ParameterDirection.Output;
                    bool isOutput = p.Direction != ParameterDirection.Input;
                    if ((input && isInput) || (!input && isOutput))
                        MySqlSpecificDAL.TraceSource.TraceEvent(TraceEventType.Verbose, eventId, "SqlParamter: Name = {0}, Value = '{1}', Type = {2}, Size = {3}", p.ParameterName, p.Value, p.DbType, p.Size);
                }
            }
        }

        protected void CloseOpenedConnection() 
        {
            if ((command.Connection.State == ConnectionState.Open) & connectionOpened)
                command.Connection.Close();
        }

        protected void TraceResult(string result) 
        {
            if (result != null)
                MySqlSpecificDAL.TraceSource.TraceEvent(TraceEventType.Verbose, eventId, "Result: {0}", result);
            TraceParameters(false);
        }
    }
}
