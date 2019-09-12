using CalculationServiceRest.Core.Interfaces;
using SoapServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationServiceRest.Core.ServiceImplementation
{
    public sealed class CalculatorServiceImplementation : ICalculatorService
    {
        private readonly CalculatorSoap _calculatorSoap = null;

        public CalculatorServiceImplementation(CalculatorSoap calculatorSoap)
        {
            _calculatorSoap = calculatorSoap;
        }

        public async Task<int> AddAsync(int firstNumber, int secondNumber)
        {
          return await _calculatorSoap.AddAsync(firstNumber, secondNumber);
        }

        public async Task<int> DivideAsync(int firstNumber, int secondNumber)
        {
            return await _calculatorSoap.DivideAsync(firstNumber, secondNumber);
        }

        public async Task<int> MultiplyAsync(int firstNumber, int secondNumber)
        {
            return await _calculatorSoap.MultiplyAsync(firstNumber, secondNumber);
        }

        public async Task<int> SubtractAsync(int firstNumber, int secondNumber)
        {
            return await _calculatorSoap.SubtractAsync(firstNumber, secondNumber);
        }
    }
}
