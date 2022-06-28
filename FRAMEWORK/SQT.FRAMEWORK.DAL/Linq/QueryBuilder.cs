using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.Common;
using SQT.FRAMEWORK.DAL.Linq.Results;

namespace SQT.FRAMEWORK.DAL.Linq
{
    public class QueryBuilder<T> where T : BaseQuery
    {
        protected internal T query = default(T);

        public QueryBuilder(T obj)
        {
            query = obj;
        }

        public QueryBuilder<T> Map(Func<DbDataReader, object> objectRecordMapper)
        {
            query.Map(objectRecordMapper);
            return this;
        }


        public QueryBuilder<T> AddParameter(string parameterName, object value, DbType paramType, int paramSize)
        {
            query.AddParameter(parameterName, value, paramType, paramSize);
            return this;
        }

        public QueryBuilder<T> AddParameter(string parameterName, object value, DbType paramType)
        {
            query.AddParameter(parameterName, value, paramType);
            return this;
        }

        public QueryBuilder<T> CommandTimeout(int timeout)
        {
            query.CommandTimeout = timeout;
            return this;
        }

        public QueryBuilder<T> WithTransaction(DbTransaction transaction)
        {
            if (transaction != null)
            {
                query.WithTransaction(transaction);
            }
            return this;
        }

        #region Action Endpoints

        public O Fetch<O>()
        {
            return query.Fetch<O>();
        }

        public List<O> FetchAll<O>()
        {
            return query.FetchAll<O>();
        }

        public void Execute()
        {
            query.Execute();
        }

        public O ExecuteScalar<O>()
        {
            return query.ExecuteScalar<O>();
        }

        public MultiResult FetchMultiple()
        {
            return query.FetchMultiple();
        }

        public DbDataReader FetchReader()
        {
            return query.FetchReader();
        }

        public DataSet FetchDataSet()
        {
            return query.FetchDataSet();
        }
        
        #endregion

    }

    public static class QueryBuilderExtensionMethods
    {
        public static QueryBuilder<StoredProcedure> AddParameter(this QueryBuilder<StoredProcedure> qb, string parameterName, object value)
        {
            ((StoredProcedure)qb.query).AddParameter(parameterName, value);
            return qb;
        }        

        public static QueryBuilder<StoredProcedure> AddOutParameter(this QueryBuilder<StoredProcedure> qb, string parameterName, object value)
        {
            ((StoredProcedure)qb.query).AddOutputParameter(parameterName, value);
            return qb;
        }

        public static QueryBuilder<StoredProcedure> AddOutParameter(this QueryBuilder<StoredProcedure> qb, string parameterName, DbType paramType)
        {
            ((StoredProcedure)qb.query).AddOutputParameter(parameterName, paramType);
            return qb;
        }

        public static QueryBuilder<StoredProcedure> AddOutParameter(this QueryBuilder<StoredProcedure> qb, string parameterName, object value, DbType paramType, int size)
        {
            ((StoredProcedure)qb.query).AddOutputParameter(parameterName, value, paramType, size);
            return qb;
        }

        public static void Execute<T>(this QueryBuilder<StoredProcedure> qb, T obj)
        {
            ((StoredProcedure)qb.query).Execute<T>(obj);            
        }

        public static void Execute<T>(this QueryBuilder<StoredProcedure> qb, T obj, out OutputParameterCollection op)
        {
            ((StoredProcedure)qb.query).Execute<T>(obj, out op);
        }

        public static T Fetch<T>(this QueryBuilder<StoredProcedure> qb, out OutputParameterCollection op)
        {
            return ((StoredProcedure)qb.query).Fetch<T>(out op);
        }

        public static List<T> FetchAll<T>(this QueryBuilder<StoredProcedure> qb, out OutputParameterCollection op)
        {
            return ((StoredProcedure)qb.query).FetchAll<T>(out op);
        }

        public static void Execute(this QueryBuilder<StoredProcedure> qb, out OutputParameterCollection op)
        {
            ((StoredProcedure)qb.query).Execute(out op);
        }

        public static T ExecuteScalar<T>(this QueryBuilder<StoredProcedure> qb, out OutputParameterCollection op)
        {
            return ((StoredProcedure)qb.query).ExecuteScalar<T>(out op);
        }

        public static MultiResult FetchMultiple(this QueryBuilder<StoredProcedure> qb, out OutputParameterCollection op)
        {
            return ((StoredProcedure)qb.query).FetchMultiple(out op);
        }       

    }

}
