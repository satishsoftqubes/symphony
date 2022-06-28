using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SQT.FRAMEWORK.DAL.Linq
{
    public class LinqTransaction : IDisposable
    {        
        private DbConnection connection;

        public LinqTransaction(DbTransaction transaction)
        {
            this.connection = transaction.Connection;
            this.Transaction = transaction;
        }

        public DbTransaction Transaction
        {
            get;
            private set;
        }

        public void Commit()
        {
            Transaction.Commit();
            this.connection.Close();
            Transaction = null;
            Debug.WriteLine("Commiting transaction and closing connection");
        }

        public void Rollback()
        {
            Transaction.Rollback();
            this.connection.Close();
            Transaction = null;
            Debug.WriteLine("Rolling back transaction and closing connection");
        }


        public void Dispose()
        {
            Dispose(true);
        }

        
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                Transaction.Dispose();
                connection.Dispose();
                Debug.WriteLine("Transaction and Connection disposed");
            }

        }


    }
}
