using CalculationServiceRest.Core.Interfaces;
using NLog;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationServiceRest.Core.ServiceImplementation
{
    public class LoggerDependency : ILoggerDependency
    {
        private readonly ILogger _logger = null;

        public LoggerDependency()
        {
            _logger= NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        }

        public void LogError(Exception exception)
        {
            _logger.Error(exception);
        }

        public void LogInfo(int methodType,TimeSpan time,string value)
        {
            LogEventInfo log = new LogEventInfo();
            log.Level = LogLevel.Info;
            log.Properties["METHOD_TYPE"] = methodType;
            log.Properties["INSERT_DATE"] = time;
            log.Properties["VALUE"] = value;

            _logger.Info(log);
        }
    }
}
