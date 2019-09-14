using CalculationService.TESTs.Core;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CalculationService.TESTs.Tests
{
    public class CalculationServiceTest
    {
        private readonly RequestSender _requestSender = null;

        public CalculationServiceTest()
        {
            _requestSender = new RequestSender();
        }

        [Fact]
        public void Add()
        {
            var response = await _requestSender.GetAsync("http://localhost:44386/api/calculate?firstNumber=5&secondNumber=4");
            Assert.Equal("9", response);
        }

        [Fact]
        public async Task Substract()
        {
            var response = await _requestSender.GetAsync("http://localhost:44386/api/calculate/subtract?firstNumber=9&secondNumber=4");
            Assert.Equal("5", response);
        }

        [Fact]
        public async Task Multiply()
        {
            var response = await _requestSender.GetAsync("http://localhost:44386/api/calculate/Multiply?firstNumber=7&secondNumber=8");
            Assert.Equal("56", response);
        }

        [Fact]
        public async Task Divide()
        {
            var response = await _requestSender.GetAsync("http://localhost:44386/api/calculate/Divide?firstNumber=16&secondNumber=8");
            Assert.Equal("2", response);
        }
    }
}
