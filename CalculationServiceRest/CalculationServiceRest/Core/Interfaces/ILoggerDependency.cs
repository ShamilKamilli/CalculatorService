using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationServiceRest.Core.Interfaces
{
    public interface ILoggerDependency
    {
        void LogInfo(MethodTypeModel model);

        void LogError(Exception exception);

        void SaveChanges();
    }
}
