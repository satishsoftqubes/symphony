using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SQT.FRAMEWORK.EXCEPTION
{
    /// <summary>
    /// The type of exception that is thrown when data access layer error occurs.
    /// </summary>
    [Serializable]
    public class IDDALException : IVAPSBaseException
    {
         #region Constructors

        /// <summary>
        /// Initializes a new instance of IDDALException class.
        /// </summary>
        public IDDALException()
            : base()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of IDDALException class.
        /// </summary>
        /// <param name="message">A message that describes error.</param>
        public IDDALException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of IDDALException class.
        /// </summary>
        /// <param name="message">A message that describes error.</param>
        /// <param name="innerException">The exception that is the cause of current exception.</param>
        public IDDALException(string message, System.Exception innerException)
            : base(message, innerException)
        {

        }

        /// <summary>
        /// Initializes a new instance of IDDALException class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected IDDALException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        #endregion
    }
}
