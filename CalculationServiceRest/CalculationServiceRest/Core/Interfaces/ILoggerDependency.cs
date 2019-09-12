using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationServiceRest.Core.Interfaces
{
    public interface ILoggerDependency
    {
        void LogInfo(int methodType, TimeSpan time, string value);

        void LogError(Exception exception);
    }
}
