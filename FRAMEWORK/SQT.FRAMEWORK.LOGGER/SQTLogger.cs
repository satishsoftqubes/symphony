using log4net;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System.IO;
using System;
using System.Data;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SQT.FRAMEWORK.COMMON.Util;

namespace SQT.FRAMEWORK.LOGGER
{
    public static class SQTLogger
    {
        /// <summary>
        /// Writes the log.
        /// This method will first query logCategoryType to determine if a log message should be logged according to the configuration settings for the passed Category filter type
        /// It will then get the Called Methods name, Parse thru its paramters, extract relevant information and Log.
        /// </summary>
        /// <param name="logMessageType">Type of the Log Message.</param>
        /// <param name="parameterObjects">The Parameter objects.</param>
        /// <param name="logMessage">The Message to be Logged.</param>
        /// <param name="logCategoryType">Type of the Log Category.</param>
        public static void WriteLog(string logMessageType, ArrayList parameterObjects, string logMessage, string logCategoryType)
        {
            string methodName = "";

            try
            {
                LogEntry logEntry = new LogEntry();
                logEntry.Priority = 2;
                logEntry.Categories.Add(logCategoryType);
                //Get Method Name
                MethodBase mb = new StackFrame(1).GetMethod();
                methodName = mb.DeclaringType.FullName.ToString() + "  " + mb.ToString();

                if (Microsoft.Practices.EnterpriseLibrary.Logging.Logger.ShouldLog(logEntry))
                {

                    if (logMessage == null)
                    {
                        logMessage = "";
                    }

                    logMessage = logMessage.Trim();

                    StringBuilder parameters = new StringBuilder();

                    if (parameterObjects != null)
                    {
                        int i = 0;

                        if (logMessageType == LogMessageType.MethodReturn)
                        {
                            ParameterEntity paramsInfo = new ParameterEntity();
                            paramsInfo.Name = parameterObjects[0].ToString();
                            paramsInfo.Type = parameterObjects[1].GetType().ToString();

                            if (typeof(System.Collections.ICollection).IsInstanceOfType(parameterObjects[1]))
                            {
                                ICollection il = (ICollection)parameterObjects[1];
                                paramsInfo.Value = il.Count;
                            }
                            else
                            {
                                paramsInfo.Value = parameterObjects[1].ToString();
                            }

                            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(logMessageType + " " + methodName + ", Return Value info - " + paramsInfo.ToString() + ", " + logMessage.ToString(), logCategoryType);
                        }
                        else
                        {
                            foreach (ParameterInfo pi in mb.GetParameters())
                            {
                                ParameterEntity paramsInfo = new ParameterEntity();
                                paramsInfo.Name = pi.Name;
                                paramsInfo.Type = pi.ParameterType.ToString();

                                if (typeof(System.Collections.ICollection).IsInstanceOfType(parameterObjects[i]))
                                {
                                    ICollection il = (ICollection)parameterObjects[i];
                                    paramsInfo.Value = il.Count;
                                }
                                else
                                {
                                    paramsInfo.Value = parameterObjects[i].ToString();
                                }
                                parameters.AppendLine(paramsInfo.ToString());
                                i++;
                            }
                            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(logMessageType + " " + methodName + " Parameter info - " + parameters.ToString() + ", " + logMessage.ToString(), logCategoryType, 100, 0, TraceEventType.Verbose);
                        }
                    }
                    else
                    {
                        Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(logMessageType + " " + methodName + ", " + logMessage.ToString(), logCategoryType);
                    }
                }
                else
                    Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(logMessageType + " " + methodName + ", " + logMessage.ToString(), LogCategory.BusinessLayerLog);
            }
            catch (Exception logExc)
            {
                Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write("Logger Exception at: " + methodName + ", " + logExc.Message, logCategoryType);
            }
        }
    }
    public class MyLogger
    {
        private const string APPENDER_NAME = "SQTLogger";
        private static log4net.ILog log = null;

        /// <summary>
        /// Writes the stack trace into the Log file for the passed exception.
        /// </summary>
        /// <param name="ex">Exception to be written into Log file</param>
        public static void WriteLog(Exception ex)
        {
            if (ApplicationConfiguration.LoggingEnabled)
            {
                string fileName = GetFileName(FileType.Log);
                FileAppender fileAppender = CreateAppender(fileName);

                CreateLogger(fileAppender, APPENDER_NAME);
                log = LogManager.GetLogger(APPENDER_NAME);

                string stackTrace = GetStackTraceInfo();
                log.Info(stackTrace, ex);
            }
        }

        /// <summary>
        /// Write traceInfo to the trace file.
        /// </summary>
        /// <param name="traceInfo">Information needs to be traced</param>
        public static void WriteTrace(string traceInfo)
        {
            if (ApplicationConfiguration.TracingEnabled)
            {
                string fileName = GetFileName(FileType.Trace);
                FileAppender fileAppender = CreateAppender(fileName);

                CreateLogger(fileAppender, APPENDER_NAME);
                log = LogManager.GetLogger(APPENDER_NAME);
                log.Info(traceInfo + Environment.NewLine);
            }
        }

        /// <summary>
        /// Writes the information(s) to the trace file.
        /// </summary>
        /// <param name="formName">Screen name</param>
        /// <param name="traceInfo">Trace Information to be written into trace file</param>
        public static void WriteTrace(string formName, string traceInfo)
        {
            if (ApplicationConfiguration.TracingEnabled)
            {
                string fileName = GetFileName(FileType.Trace);
                FileAppender fileAppender = CreateAppender(fileName);

                CreateLogger(fileAppender, APPENDER_NAME);
                log = LogManager.GetLogger(APPENDER_NAME);

                string stackTrace = Environment.NewLine + "Screen/Form Name : " + formName + Environment.NewLine;
                stackTrace += "Method/ Action/ Routine Invoked : " + traceInfo + Environment.NewLine;
                stackTrace += "Start Time : " + DateTime.Now.ToString() + Environment.NewLine;
                stackTrace += "Username : " + SessionParameters.UserName + Environment.NewLine;
                log.Info(stackTrace);
            }
        }


        private static string GetStackTraceInfo()
        {
            string stackTraceInfo = Environment.NewLine;

            stackTraceInfo += "************************************************************" + Environment.NewLine;
            stackTraceInfo = (stackTraceInfo + "Username : ") + SessionParameters.UserName + Environment.NewLine;
            stackTraceInfo = (stackTraceInfo + "Date & Time : ") + DateTime.Now.ToString() + Environment.NewLine;
            stackTraceInfo += "************************************************************" + Environment.NewLine;

            return stackTraceInfo;
        }


        private enum FileType
        {
            Log,
            Trace
        }

        private static string GetFileName(FileType fileType)
        {
            string dirName = (fileType == MyLogger.FileType.Log ? Environment.CurrentDirectory + @"\Diagnostics\Log" : Environment.CurrentDirectory + @"\Diagnostics\Trace");

            if (!Directory.Exists(dirName))
                Directory.CreateDirectory(dirName);

            string fileName = ApplicationConfiguration.LogTraceSetting == ApplicationConfiguration.LogTraceType.DateWise ? DateTime.Now.ToString("dd-MMM-yyyy") + ".txt" : (fileType == FileType.Log ? "Log.txt" : "Trace.txt");
            return (dirName + "\\") + fileName;

        }


        private static FileAppender CreateAppender(string fileName)
        {
            RollingFileAppender rollingFileAppender = new RollingFileAppender();
            FileAppender fileAppender = new FileAppender();
            PatternLayout patternLayOut = new PatternLayout();

            patternLayOut.ConversionPattern = "%d %m%n";
            patternLayOut.ActivateOptions();
            fileAppender.Layout = patternLayOut;
            fileAppender.AppendToFile = true;
            fileAppender.File = fileName;
            fileAppender.Name = APPENDER_NAME;
            fileAppender.ActivateOptions();

            return fileAppender;
        }

        private static void CreateLogger(FileAppender fileAppender, string loggerName)
        {
            log4net.Repository.Hierarchy.Hierarchy hierarchy = (log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetLoggerRepository();
            log4net.Repository.Hierarchy.Logger logger = (log4net.Repository.Hierarchy.Logger)hierarchy.GetLogger(APPENDER_NAME);
            logger.RemoveAllAppenders();
            logger.AddAppender(fileAppender);
            hierarchy.Configured = true;
        }

    }

    public static class SessionParameters
    {

        private static int _userId = 0;
        /// <summary>
        /// Gets or Sets UserId
        /// </summary>
        public static int UserID
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }

        private static Comon.UserRole _userRole;

        /// <summary>
        /// Gets or Sets UserRole
        /// </summary>
        public static Comon.UserRole UserRole
        {
            get
            {
                return _userRole;
            }
            set
            {
                _userRole = value;
            }
        }


        private static string _userName = String.Empty;

        /// <summary>
        /// Gets or Sets UserName
        /// </summary>
        public static string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        }
    }
    public static class Comon
    {
        /// <summary>
        /// Background color for the screen
        /// </summary>
        public static Color BGColor
        {
            get
            {
                return Color.FromArgb(122, 150, 223);
            }
        }

        /// <summary>
        /// User roles supported by system
        /// </summary>
        public enum UserRole
        {
            Administrator, SuperAdmin
        }
    }
}