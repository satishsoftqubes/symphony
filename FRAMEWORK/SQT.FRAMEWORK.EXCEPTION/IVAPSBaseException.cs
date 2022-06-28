using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SQT.FRAMEWORK.EXCEPTION
{
    /// <summary>
    /// 
    /// </summary>
    public class IVAPSBaseException : ApplicationException, ISerializable
    {
          private bool _IsMessage=false;
        
        /// <summary>
        /// Specifies if the exception details is to be shown to user as a message.
        /// </summary>
        public bool IsMessage
        {
            get { return _IsMessage; }
            set { _IsMessage = value; }
        }
      
        #region Constructors

        /// <summary>
        /// Initializes a new instance of IDBaseException class.
        /// </summary>
        public IVAPSBaseException()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of IDBaseException class.
        /// </summary>
        /// <param name="message">A message that describes error.</param>
        public IVAPSBaseException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of IDBaseException class.
        /// </summary>
        /// <param name="message">A message that describes error.</param>
        /// <param name="innerException">The exception that is the cause of current exception.</param>
        public IVAPSBaseException(string message, System.Exception innerException)
            : base(message, innerException)
        {

        }

        /// <summary>
        /// Initializes a new instance of IDBaseException class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected IVAPSBaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        #endregion
    }
}
