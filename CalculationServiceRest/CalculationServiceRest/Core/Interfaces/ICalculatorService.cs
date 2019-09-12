using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationServiceRest.Core.Interfaces
{
    public interface ICalculatorService
    {
        Task<int> AddAsync(int firstNumber, int secondNumber);

        Task<int> SubtractAsync(int firstNumber, int secondNumber);

        Task<int> MultiplyAsync(int firstNumber, int secondNumber);

        Task<int> DivideAsync(int firstNumber, int secondNumber);
    }
}
