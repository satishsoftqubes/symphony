using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SQT.FRAMEWORK.DAL.Linq
{
    public static class LinqSql
    {
        #region Stored Procedure Calls

        public static QueryBuilder<StoredProcedure> StoredProcedure(string storedProcName)
        {
            return new QueryBuilder<StoredProcedure>(new StoredProcedure(storedProcName));
        }
        public static QueryBuilder<StoredProcedure> StoredProcedure(string storedProcName, string configName)
        {
            return new QueryBuilder<StoredProcedure>(new StoredProcedure(storedProcName, configName));
        }
        public static QueryBuilder<StoredProcedure> StoredProcedure(string storedProcName, string connectionString, string provider)
        {
            return new QueryBuilder<StoredProcedure>(new StoredProcedure(storedProcName, connectionString, provider));
        }
        #endregion


        #region Inline Query Calls

        public static QueryBuilder<Query> Query(string sqlStatement)
        {
            return new QueryBuilder<Query>(new Query(sqlStatement));
        }

        public static QueryBuilder<Query> Query(string sqlStatement, string configName)
        {
            return new QueryBuilder<Query>(new Query(sqlStatement, configName));
        }

        public static QueryBuilder<Query> Query(string sqlStatement, string connectionString, string provider)
        {
            return new QueryBuilder<Query>(new Query(sqlStatement, connectionString, provider));
        }

        #endregion

        #region Local Transaction Creator

        public static LinqTransaction CreateTransaction()
        {
            return new BaseQuery(String.Empty, false).CreateTransaction();            
        }

        public static LinqTransaction CreateTransaction(string configName)
        {
            return new BaseQuery(String.Empty, configName, false).CreateTransaction();            
        }

        public static LinqTransaction CreateTransaction(string connectionString, string sqlProvider)
        {
            return new BaseQuery(String.Empty, connectionString, sqlProvider, false).CreateTransaction();            
        }       

        #endregion

    } 
}

