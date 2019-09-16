using CalculationServiceRest.Core.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationServiceRest.Core.ServiceImplementation
{
    public class LoggerDependency : ILoggerDependency
    {
        private static object Synchronize = new object();

        private List<MethodTypeModel> logs = null;
        private readonly ILogger _logger = null;

        public LoggerDependency(ILogger logger)
        {
            _logger = logger;
            logs = new List<MethodTypeModel>();
        }

        public void LogError(Exception exception)
        {
            _logger.Error(exception);
        }

        public void LogInfo(MethodTypeModel model)
        {
            logs.Add(model);
        }

        public void SaveChanges()
        {
            lock (Synchronize)
            {
                foreach (var item in logs)
                {
                    LogEventInfo info = new LogEventInfo();
                    info.Properties["VALUE"] = item.Value;
                    info.Properties["METHOD_TYPE"] = (int)item.MethodType;
                    info.Properties["INSERT_DATE"] = item.InsertDate;
                    _logger.Info(info);
                }
            }
        }
    }
}
