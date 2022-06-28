using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using SQT.FRAMEWORK.DAL.Linq.Interfaces;
using SQT.FRAMEWORK.DAL.Linq.Exceptions;

namespace SQT.FRAMEWORK.DAL.Linq.Results
{
    public class MultiResult : IHideObjectMembers
    {
        private ArrayList resultList = new ArrayList();       

        public T Fetch<T>(int index)
        {
            try
            {
                if (null == resultList[index]) { return default(T); } //Guard clause
                return (T)resultList[index];
            }
            catch (IndexOutOfRangeException e)
            {
                throw new LinqSqlException("No result found at index" + index.ToString());
            }
            catch (InvalidCastException ex)
            {
                throw new LinqSqlException("The result is not of the type " + typeof(T).ToString());
            }
        }

        public List<T> FetchAll<T>(int index)
        {
            List<T> resultset = new List<T>();
            try
            {
                var results = resultList[index];
                if (null == results) { return default(List<T>); } //Guard clause
                
                if (results is ArrayList)
                {
                    resultset.InsertRange(0, ((ArrayList)results).Cast<T>());
                }
                else
                {
                    resultset.Add((T)results);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                throw new LinqSqlException("No result found at index" + index.ToString());
            }
            catch (InvalidCastException ex)
            {
                throw new LinqSqlException("The result is not of the type " + typeof(T).ToString());
            }
            return resultset;
        }

        internal void AddResult(object result)
        {
            resultList.Add(result);
        }

        public int Count
        {
            get { return resultList.Count; }
        }
    }
}
