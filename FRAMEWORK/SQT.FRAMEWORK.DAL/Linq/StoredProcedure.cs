using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using SQT.FRAMEWORK.DAL.Linq.Interfaces;

namespace SQT.FRAMEWORK.DAL.Linq
{
    public class StoredProcedure : BaseQuery, IHideObjectMembers
    {
        #region Public Constructors
        public StoredProcedure(string storedProcName)
            : this(storedProcName, null)
        {
        }
        public StoredProcedure(string storedProcName, string connectionConfigName)
            : base(storedProcName, connectionConfigName, true)
        {
        }
        public StoredProcedure(string storedProcName, string connectionConfigName, DbTransaction trans)
            : base(storedProcName, connectionConfigName, true,trans)
        {
        }
        public StoredProcedure(string storedProcName, string connectionString, string sqlProvider)
            : base(storedProcName, connectionString, sqlProvider, true)
        {

        }
        public StoredProcedure(string storedProcName, string connectionString, string sqlProvider, DbTransaction trans)
            : base(storedProcName, connectionString, sqlProvider, true,trans)
        {

        }
        #endregion

        internal void AddOutputParameter(string parameterName, DbType paramType)
        {
            this.Database.AddOutParameter(parameterName, paramType);
        }

        internal void AddOutputParameter(string parameterName, object value)
        {
            this.Database.AddOutParameter(parameterName, value);
        }

        internal void AddOutputParameter(string parameterName, object value, DbType paramType, int size)
        {
            this.Database.AddOutParameter(parameterName, value, paramType, size);
        }

        internal void AddParameter(string parameterName, object value)
        {
            this.Database.AddParameter(parameterName, value);
        }        

    }
}