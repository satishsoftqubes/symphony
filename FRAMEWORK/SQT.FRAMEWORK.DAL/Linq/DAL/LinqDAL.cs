using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using SQT.FRAMEWORK.DAL.Linq;
using SQT.FRAMEWORK.DAL.Linq.Exceptions;
using SQT.FRAMEWORK.DAL.Linq.Results;
using SQT.FRAMEWORK.DAL.Linq.Attributes;
using SQT.FRAMEWORK.DAL.Linq.Adapters;

namespace SQT.FRAMEWORK.DAL.Linq.DAL
{
    public class LinqDAL
    {
        public LinqDAL() 
        {
            this.ConfigName = "SQLConStr";
        }

        public LinqDAL(string configName)
        {
            this.ConfigName = configName;
        }

        protected String ConfigName { get; set; }


        public QueryBuilder<StoredProcedure> StoredProcedure(string procName)
        {
            if (!String.IsNullOrEmpty(this.ConfigName))
            {
                return LinqSql.StoredProcedure(procName, this.ConfigName);
            }           
            return LinqSql.StoredProcedure(procName);            
        }
        
        public QueryBuilder<Query> Query(string sqlStatement)
        {
            if (!String.IsNullOrEmpty(this.ConfigName))
            {
                return LinqSql.Query(sqlStatement, this.ConfigName);
            }
            return LinqSql.Query(sqlStatement);
        }
        
        public LinqTransaction CreateTransaction()
        {
            if (!String.IsNullOrEmpty(this.ConfigName))
            {
                return LinqSql.CreateTransaction(this.ConfigName);
            }
            return LinqSql.CreateTransaction();
        }


    }
}
