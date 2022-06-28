using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQT.FRAMEWORK.EXCEPTION
{
    /// <summary>
    /// defines exception categories.
    /// </summary>
   public struct IDExceptionCategory
    {
        /// <summary>
        ///  gets data access exception category.
        /// </summary>
        public const string DataAccess = "DAL Policy";
        /// <summary>
        ///  gets business layer exception category.
        /// </summary>
        public const string BusinessLayer = "BL Policy";         
    }
}
