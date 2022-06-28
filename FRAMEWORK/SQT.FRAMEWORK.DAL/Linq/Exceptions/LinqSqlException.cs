using System;
using System.Runtime.Serialization;
using System.Text;

namespace SQT.FRAMEWORK.DAL.Linq.Exceptions
{
    public class LinqSqlException : ApplicationException
    {
        public LinqSqlException()
            : base()
        {
        }

        public LinqSqlException(string message)
            : base(message)
        {
        }

        public LinqSqlException(string message, Exception exception)
            : base(FormatErrorMessage(message, exception), exception)
        {
        }

        public LinqSqlException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }

        private static String FormatErrorMessage(string message, Exception ex)
        {
            StringBuilder msgBuilder = new StringBuilder(message);
            msgBuilder.AppendFormat("{0}{1}", ex.Message, Environment.NewLine);
            msgBuilder.AppendFormat("Source: {0}{1}", ex.Source, Environment.NewLine);
            msgBuilder.AppendFormat("StackTrace: {0}{1}", ex.StackTrace, Environment.NewLine);
            if (null != ex.InnerException)
            {
                msgBuilder.AppendFormat("Inner Exception: {0}{1}", ex.InnerException.Message, Environment.NewLine);
            }
            return Convert.ToString(msgBuilder);
        }
    }
}