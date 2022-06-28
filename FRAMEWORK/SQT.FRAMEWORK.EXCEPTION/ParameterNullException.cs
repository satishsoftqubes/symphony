using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace SQT.FRAMEWORK.EXCEPTION
{
    /// <summary>
    /// The exception that is thrown when a method recieves null paramter.
    /// </summary>
    [Serializable]
  public class ParameterNullException : IVAPSBaseException 
    {
        #region Private Attributes
        private string _parameterName;
        private string _layer;
        private string _methodBase;
        #endregion

        #region public properties
        /// <summary>
        /// Parameter name which caused the exception.
        /// </summary>
        public string ParameterName
        {
            get
            {
                return _parameterName;
            }
            set
            {
                _parameterName = value;
                if (Data.Contains("ParameterName"))
                    Data["ParameterName"] = value;
                else
                    Data.Add("ParameterName", value);
            }
        }

        /// <summary>
        /// Layer at which the parameter exception occured.
        /// </summary>
        public string Layer
        {
            get
            {
                return _layer;
            }
            set
            {
                _layer = value;
                if (Data.Contains("Layer"))
                    Data["Layer"] = value;
                else
                    Data.Add("Layer", value);
            }
        }

        /// <summary>
        /// Method at which the parameter exception occured.
        /// </summary>
        public string MethodBase
        {
            get
            {
                return _layer;
            }
            set
            {
                _layer = value;
                if (Data.Contains("MethodBase"))
                    Data["MethodBase"] = value;
                else
                    Data.Add("MethodBase", value);
            }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of ParameterNullException class.
        /// </summary>
        public ParameterNullException()
            : base()
        {


        }

        /// <summary>
        /// Initializes a new instance of ParameterNullException class.
        /// </summary>
        /// <param name="message">A message that describes error.</param>
        public ParameterNullException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of ParameterNullException class.
        /// </summary>
        /// <param name="message">A message that describes error.</param>
        /// <param name="parameterName">parameter that caused the exception</param>
        /// <param name="layer">layer in which exception has occured</param>
        /// <param name="methodBase">The method base.</param>
        public ParameterNullException(string message, string parameterName, string layer, System.Reflection.MethodBase methodBase)
            : base(message)
        {
            this._layer = layer;
            this._parameterName = parameterName;
            this._methodBase = methodBase.DeclaringType.FullName.ToString();
        }

        /// <summary>
        /// Initializes a new instance of ParameterNullException class.
        /// </summary>
        /// <param name="message">A message that describes error.</param>
        /// <param name="innerException">The exception that is the cause of current exception.</param>
        public ParameterNullException(string message, System.Exception innerException)
            : base(message, innerException)
        {

        }

        /// <summary>
        /// Initializes a new instance of ParameterNullException class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected ParameterNullException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        #endregion

        /// <summary>
        /// Overriden method to set Serialization info with information about the Exception.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        [SecurityPermissionAttribute(
                   SecurityAction.Demand, SerializationFormatter = true)
                   ]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
