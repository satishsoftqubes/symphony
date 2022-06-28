using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace SQT.FRAMEWORK.COMMON.Util
{
    public static class ApplicationConfiguration
    {
        const string DEFAULT_CONNECTION_KEY = "defaultConnection";
        const string LOGGING_ENABLED_KEY = "logging";
        const string TRACING_ENABLED_KEY = "tracing";
        const string DATE_WISE_LOG_TRACE_KEY = "dateWiseLogTrace";
        const string EXPENSE_CCY_KEY = "expenseCCY";
        const string SUPPORT_MAIL_KEY = "supportMail";
        const string SUPPORT_URL_KEY = "supportURL";

        /// <summary>
        /// Gets default connection being used.
        /// </summary>
        public static string DefaultConnection
        {
            get
            {
                return ConfigurationManager.AppSettings[DEFAULT_CONNECTION_KEY];
            }
        }

        /// <summary>
        /// Gets DB provider from app.config file
        /// </summary>
        public static string DBProvider
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[DefaultConnection].ProviderName;
            }
        }

        /// <summary>
        /// Gets connection string from app.config file
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[DefaultConnection].ConnectionString;
            }
        }

        /// <summary>
        /// Gets whether logging is enabled or not
        /// </summary>
        public static bool LoggingEnabled
        {
            get
            {
                return DataFormat.GetBoolean(ConfigurationManager.AppSettings[LOGGING_ENABLED_KEY]);
            }
        }

        /// <summary>
        /// Gets whether tracing is enabled or not
        /// </summary>
        public static bool TracingEnabled
        {
            get
            {
                return DataFormat.GetBoolean(ConfigurationManager.AppSettings[TRACING_ENABLED_KEY]);
            }
        }

        /// <summary>
        /// Type of Logging/ Tracing
        /// </summary>
        public enum LogTraceType
        {
            SingleFile,
            DateWise
        }

        /// <summary>
        /// Gets Type of Log/ Trace i.e. Separate file of one file for each date
        /// </summary>
        public static LogTraceType LogTraceSetting
        {
            get
            {
                return DataFormat.GetBoolean(ConfigurationManager.AppSettings[DATE_WISE_LOG_TRACE_KEY]) ? LogTraceType.DateWise : LogTraceType.SingleFile;
            }
        }

        /// <summary>
        /// Gets Expense Currency from app.config
        /// </summary>
        public static string ExpenseCCY
        {
            get
            {
                return DataFormat.GetString(ConfigurationManager.AppSettings[EXPENSE_CCY_KEY]);
            }
        }

        /// <summary>
        /// Gets support mail from app.config
        /// </summary>
        public static string SupportMail
        {
            get
            {
                return DataFormat.GetString(ConfigurationManager.AppSettings[SUPPORT_MAIL_KEY]);
            }
        }


        /// <summary>
        /// Gets support URL
        /// </summary>
        public static string SupportURL
        {
            get
            {
                return DataFormat.GetString(ConfigurationManager.AppSettings[SUPPORT_URL_KEY]);
            }
        }


    }

    public static class DataFormat
    {
        public static string DateToDB(string date)
        {
            DateTime dt = Convert.ToDateTime(date);
            return dt.ToString("MMddyyyy");
        }

        public static string GetDBDate(string date)
        {
            return GetDateTime(date).ToShortDateString();
        }

        public static string GetDBDate(object date)
        {
            return GetDateTime(date).ToShortDateString();
        }

        public static string GetDBDate(DateTime date)
        {
            return date.ToShortDateString();
        }

        public static string GetCurrentDate()
        {
            DateTime dt = System.DateTime.Now;
            return dt.ToString("MMddyyyy");
        }

        public static string DateToDisp(string date)
        {
            string[] dateString = new string[3];
            DateTime dt = Convert.ToDateTime(date);
            dateString = dt.ToString("dd MMM yyyy").Split(Convert.ToChar(" "));
            return dateString[0] + " " + dateString[1] + ", " + dateString[2];
        }

        public static string GetDateFromDBDate(string date)
        {
            string dateReturn = string.Empty;
            if (date.Trim().Length < 8)
                date = "0" + date.Trim();

            string month = date.Substring(0, 2);
            string date1 = date.Substring(2, 2);
            string year = date.Substring(4);
            dateReturn = month + "/" + date1 + "/" + year;

            dateReturn = DateToDisp(dateReturn);
            return dateReturn;
        }

        public static string GetMonth(string date)
        {
            string dateToDB = DateToDB(date);
            return dateToDB.Substring(0, 2);
        }

        public static string GetYear(string date)
        {
            string dateToDB = DateToDB(date);
            return dateToDB.Substring(4, 4);
        }

        public static string GetDate(string date)
        {
            string dateToDB = DateToDB(date);
            return dateToDB.Substring(2, 2);
        }

        #region Core Formatting Metods
        public static bool IsValidDate(string date)
        {
            bool retValue = false;
            DateTime result = new DateTime();
            if (DateTime.TryParse(date, out result))
                retValue = true;

            return retValue;
        }

        public static bool IsValidDate(object date)
        {
            bool retValue = false;
            DateTime result = new DateTime();

            if (date != null)
            {
                if (DateTime.TryParse(date.ToString(), out result))
                    retValue = true;
            }

            return retValue;
        }

        public static DateTime GetDateTime(string date)
        {
            DateTime retValue = new DateTime();
            if (IsValidDate(date))
                retValue = Convert.ToDateTime(date);

            return retValue;
        }

        public static DateTime GetDateTime(object date)
        {
            DateTime retValue = new DateTime();
            if (IsValidDate(date))
                retValue = Convert.ToDateTime(date);

            return retValue;
        }


        public static bool IsNumeric(object value)
        {
            bool retValue = false;

            if (value != null)
                retValue = IsNumeric(value.ToString());

            return retValue;
        }

        public static bool IsNumeric(string value)
        {
            bool retValue = false;
            double result = 0;
            if (value != null)
                retValue = double.TryParse(value, out result);

            return retValue;
        }


        public static bool IsInteger(object value)
        {
            bool retValue = false;

            if (value != null)
                retValue = IsInteger(value.ToString());

            return retValue;
        }

        public static bool IsInteger(string value)
        {
            bool retValue = false;
            int result = 0;
            if (value != null)
                retValue = int.TryParse(value, out result);

            return retValue;
        }

        public static bool IsBoolean(string value)
        {
            bool retValue = false;
            bool result = false;
            if (value != null)
                retValue = Boolean.TryParse(value, out result);

            return retValue;
        }


        public static bool IsBoolean(object value)
        {
            bool retValue = false;

            if (value != null)
                retValue = IsBoolean(value.ToString());

            return retValue;
        }

        public static string GetString(object value)
        {
            string retValue = string.Empty;
            if (value != null)
                retValue = value.ToString();

            return retValue;
        }


        public static int GetInteger(object value)
        {
            int retValue = 0;

            if (IsInteger(value))
                retValue = Convert.ToInt16(value);

            return retValue;
        }


        public static int GetInteger(string value)
        {
            int retValue = 0;

            if (IsInteger(value))
                retValue = Convert.ToInt16(value);

            return retValue;
        }

        public static double GetDouble(object value)
        {
            double retValue = 0;

            if (IsNumeric(value))
                retValue = Convert.ToDouble(value);

            return retValue;
        }


        public static double GetDouble(string value)
        {
            double retValue = 0;

            if (IsNumeric(value))
                retValue = Convert.ToDouble(value);

            return retValue;
        }

        public static bool GetBoolean(object value)
        {
            bool retValue = false;

            if (IsBoolean(value))
                retValue = Convert.ToBoolean(value);

            return retValue;
        }


        public static bool GetBoolean(string value)
        {
            bool retValue = false;

            if (IsBoolean(value))
                retValue = Convert.ToBoolean(value);

            return retValue;
        }


        #endregion

    }
}
