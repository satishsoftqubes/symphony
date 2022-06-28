using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQT.FRAMEWORK.DAL.Linq.Interfaces;
using SQT.FRAMEWORK.DAL.Linq.Exceptions;

namespace SQT.FRAMEWORK.DAL.Linq.Results
{
    public class OutputParameter : IHideObjectMembers
    {
        public OutputParameter(string name, object value)
        {
            this.Name = name;
            this.Value = value;
        }

        internal Object Value
        {
            get;
            set;
        }

        public String Name
        {
            get;
            private set;
        }

        public T Fetch<T>()
        {
            try
            {
                return (T)Convert.ChangeType(Value, typeof(T));
            }
            catch (InvalidCastException e)
            {
                throw new LinqSqlException("A LinqSql OutputParameter Cast Exception ocurred: ", e);
            }
            catch (Exception ex)
            {
                throw new LinqSqlException("A LinqSql OutputParameter Exception ocurred: ", ex);
            }
        }

    }
}
