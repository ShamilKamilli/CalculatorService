using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationServiceRest.Core
{
    public class MethodTypeModel
    {
        public string Value { get; set; }

        public MethodTypeEnum MethodType { get; set; }

        public TimeSpan InsertDate { get; set; }
    }
}
