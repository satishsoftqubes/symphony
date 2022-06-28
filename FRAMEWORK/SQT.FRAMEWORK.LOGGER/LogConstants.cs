using System;
using System.Collections.Generic;
using System.Text;

namespace SQT.FRAMEWORK.LOGGER
{
   /// <summary>
   /// Defines Log Categories.
   /// </summary>
	public struct LogCategory
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
        public const string BusinessLayerTraceLog = "BLL Tracer";
        
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
        /// Gets the Business Layer logging category string.    
        /// </summary>
        public const string BusinessLayerVerboseLog = "BL Verbose Logger";

        /// <summary>
        /// Gets the Business Object logging category string.    
        /// </summary>
        public const string BusinessObjectLog = "BO Logger";

        /// <summary>
        /// Gets the Data Access logging category string.
        /// </summary>
        public const string DataAccessLog = "DAL Logger";
        
        /// <summary>
        /// Gets the Data Access logging category string.
        /// </summary>
        public const string BulkUploadLog = "Bulk Upload Verbose Logger";
    }

	/// <summary>
	/// Defines Log Message Types
	/// </summary>
	public struct LogMessageType
	{
		/// <summary>
		/// Gets the Log Message Type for an Exception.
		/// </summary>
		public const string Exception = "Exception in: ";

		/// <summary>
		/// Gets the Log Message Type for Information logging.
		/// </summary>
		public const string Information = "Information: ";

		/// <summary>
		/// Gets a None Log Message Type.
		/// </summary>
		public const string None = "";

		/// <summary>
		/// Gets a Method Start Message Type.
		/// </summary>
		public const string MethodStart = "Method Start: ";

		/// <summary>
		/// Gets a Method Return Message Type.
		/// </summary>
		public const string MethodReturn = "Method Return: ";

		/// <summary>
		/// Gets a In Process Message Type.
		/// </summary>
		public const string InProcess = "Processing: ";
	}
}
