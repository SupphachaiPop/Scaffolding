using System;
using NLog;
using NLog.Config;
using System.Reflection;

namespace Scaffolding.Common
{
    public interface INLogCommon
    {
        string Category { set; }

        void Debug(string format, params object[] args);
        void Debug(Exception exception, string format, params object[] args);
        void Debug(Exception exception);

        void Trace(string format, params object[] args);
        void Trace(Exception exception, string format, params object[] args);
        void Trace(Exception exception);

        void Info(string format, params object[] args);
        void Info(Exception exception, string format, params object[] args);
        void Info(Exception exception);

        void Warning(string format, params object[] args);
        void Warning(Exception exception, string format, params object[] args);
        void Warning(Exception exception);

        void Error(string format, params object[] args);
        void Error(Exception exception, string format, params object[] args);
        void Error(Exception exception);
        void Error(Exception exception, MethodBase method);

        void Fatal(string format, params object[] args);
        void Fatal(Exception exception, string format, params object[] args);
        void Fatal(Exception exception);
    }

    public class NLogCommon : INLogCommon
    {
        #region [Private Members]

        private readonly Logger _logger;
        private const string _loggerName = "NLogLogger";

        #endregion

        #region [Properties]

        public string Category
        {
            set
            {
                LogManager.Configuration.Variables["category"] = value;
            }
        }

        #endregion [Properties]

        #region [Constructor]

        public NLogCommon()
        {
            this._logger = LogManager.GetLogger("NLogLogger");
        }

        #endregion [Constructor]

        #region [Public Methods]

        #region [Debug]

        public void Debug(string format, params object[] args)
        {
            this._logger.Debug(format, args);
        }

        public void Debug(Exception exception)
        {
            this.Debug(exception, string.Empty);
        }

        public void Debug(Exception exception, string format, params object[] args)
        {
            var logEvent = this.GetLogEvent(_loggerName, LogLevel.Debug, exception, format, args);
            this._logger.Log(typeof(NLogCommon), logEvent);
        }

        #endregion [Debug]

        #region [Trace]

        public void Trace(string format, params object[] args)
        {
            this._logger.Trace(format, args);
        }

        public void Trace(Exception exception)
        {
            this.Trace(exception, string.Empty);
        }

        public void Trace(Exception exception, string format, params object[] args)
        {
            var logEvent = this.GetLogEvent(_loggerName, LogLevel.Trace, exception, format, args);
            this._logger.Log(typeof(NLogCommon), logEvent);
        }

        #endregion [Trace]

        #region [Info]

        public void Info(string format, params object[] args)
        {
            this._logger.Info(format, args);
        }

        public void Info(Exception exception)
        {
            this.Info(exception, string.Empty);
        }

        public void Info(Exception exception, string format, params object[] args)
        {
            var logEvent = this.GetLogEvent(_loggerName, LogLevel.Info, exception, format, args);
            this._logger.Log(typeof(NLogCommon), logEvent);
        }

        #endregion [Info]

        #region [Warning]

        public void Warning(string format, params object[] args)
        {
            this._logger.Warn(format, args);
        }

        public void Warning(Exception exception)
        {
            this.Warning(exception, string.Empty);
        }

        public void Warning(Exception exception, string format, params object[] args)
        {
            var logEvent = this.GetLogEvent(_loggerName, LogLevel.Warn, exception, format, args);
            this._logger.Log(typeof(NLogCommon), logEvent);
        }

        #endregion [Warning]

        #region [Error]

        public void Error(string format, params object[] args)
        {
            this._logger.Error(format, args);
        }

        public void Error(Exception exception)
        {
            this.Error(exception, string.Empty);
        }

        public void Error(Exception exception, string format, params object[] args)
        {
            var logEvent = this.GetLogEvent(_loggerName, LogLevel.Error, exception, format, args);
            this._logger.Log(typeof(NLogCommon), logEvent);
        }

        public void Error(Exception exception, MethodBase method)
        {
            this.Error(exception, string.Format(
                 "{0}.{1}.{2}()",
                 method.ReflectedType.Namespace,
                 method.ReflectedType.Name,
                 method.Name));
        }

        #endregion [Error]

        #region [Fatal]

        public void Fatal(string format, params object[] args)
        {
            this._logger.Fatal(format, args);
        }

        public void Fatal(Exception exception)
        {
            this.Fatal(exception, string.Empty);
        }

        public void Fatal(Exception exception, string format, params object[] args)
        {
            var logEvent = this.GetLogEvent(_loggerName, LogLevel.Fatal, exception, format, args);
            this._logger.Log(typeof(NLogCommon), logEvent);
        }

        #endregion [Fatal]

        #endregion

        #region [Private Methods]

        private LogEventInfo GetLogEvent(string loggerName, LogLevel level, Exception exception, string format, object[] args)
        {
            string assemblyProp = string.Empty;
            string classProp = string.Empty;
            string methodProp = string.Empty;
            string messageProp = string.Empty;
            string innerMessageProp = string.Empty;

            var logEvent = new LogEventInfo(
                level, loggerName, string.Format(format, args));

            if (exception != null)
            {
                assemblyProp = exception.Source;
                if (exception.TargetSite != null)
                {
                    if (exception.TargetSite.DeclaringType != null)
                    {
                        classProp = exception.TargetSite.DeclaringType.FullName;
                    }

                    methodProp = exception.TargetSite.Name;
                }

                messageProp = exception.Message;

                if (exception.InnerException != null)
                {
                    innerMessageProp = exception.GetBaseException().Message;
                }
            }


            logEvent.Properties["error-source"] = assemblyProp;
            logEvent.Properties["error-class"] = classProp;
            logEvent.Properties["error-method"] = methodProp;
            logEvent.Properties["error-message"] = messageProp;
            logEvent.Properties["inner-error-message"] = innerMessageProp;

            return logEvent;
        }

        #endregion
    }
}
