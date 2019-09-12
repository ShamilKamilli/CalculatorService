using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalculationService.TESTs.Core
{
    public interface IRequestSender
    {
        Task<string> GetAsync(string url);
    }
}
