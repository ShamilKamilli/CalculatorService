using CalculationServiceRest.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationServiceRest.Core.Extensions
{
    public static class LoggerExtensions
    {
        public static void AddInfo(this ILoggerDependency logger,TimeSpan time,MethodTypeEnum methodType,string value)
        {
            logger.LogInfo(new MethodTypeModel
            {
                InsertDate = time,
                MethodType = methodType,
                Value = value
            });
        }

    }
}
