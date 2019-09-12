using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationServiceRest.Core
{
    public static class Constants
    {
        public static Dictionary<string,int> MethodTypes { get; private set; }

        static Constants()
        {
            MethodTypes = new Dictionary<string, int>(4);
            MethodTypes.Add("Add", 1);
            MethodTypes.Add("Subtract", 2);
            MethodTypes.Add("Multiply", 3);
            MethodTypes.Add("Divide", 4);
        }
    }
}
