using System;
using System.Collections.Generic;
using System.Text;

namespace SQT.FRAMEWORK.LOGGER
{
   /// <summary>
   /// Defines Log Categories.
   /// </summary>
    public  struct SQTLogType
    {
        /// <summary>
        /// gets the general category string.
        /// </summary>
        public const string General = "General";
        
        /// <summary>
        /// gets the exception category string.
        /// </summary>        
        public const string ExceptionLog = "ExceptionLog";
        
        /// <summary>
        /// gets the tracing category string.
        /// </summary>
        public const string TraceLog = "TraceLog";
        
        /// <summary>
        /// Gets the Business Layer tracing category string.
        /// </summary>
        public const string BusinessLayerTraceLog = "BL Tracer";
        
        /// <summary>
        /// Gets the Business Object tracing category string.
        /// </summary>
        public const string BusinessObjectTraceLog = "BO Tracer";
        
        /// <summary>
        /// Gets the Data Access tracing category string.
        /// </summary>
        public const string DataAccessTraceLog = "DAL Tracer";
        
        /// <summary>
        /// Gets the User Interface tracing category string.
        /// </summary>
        public const string UserInterfaceTraceLog = "UI Tracer";

        /// <summary>
        /// Gets the Business Layer logging category string.    
        /// </summary>
        public const string BusinessLayerLog = "BL Logger";

        /// <summary>
        /// Gets the Business Object logging category string.    
        /// </summary>
        public const string BusinessObjectLog = "BO Logger";

        /// <summary>
        /// Gets the Data Access logging category string.
        /// </summary>
        public const string DataAccessLayerLog = "DAL Logger";
    }
}
