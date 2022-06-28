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
    public class Query : BaseQuery, IHideObjectMembers
    {
        public Query(string sqlStatement) : this(sqlStatement, (string)null)
        {
        }

        public Query(string sqlStatement, string connectionStringName) : base(sqlStatement, connectionStringName, false)
        {
        }

        public Query(string sqlStatement, string connectionString, string sqlProvider) : base(sqlStatement, connectionString, sqlProvider, false)
        {
        }
    }
}
