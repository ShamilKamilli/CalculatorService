using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculationServiceRest.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoapServiceReference;

namespace CalculationServiceRest.Controllers
{
    [Route("api/calculate")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService = null;
        private readonly ILoggerDependency _loggerDependency = null;

        public CalculateController(ICalculatorService calculatorService,
            ILoggerDependency loggerDependency)
        {
            _calculatorService = calculatorService;
            _loggerDependency = loggerDependency;
        }

        [Route("")]
        public async Task<IActionResult> Add(int firstNumber,int secondNumber)
        {
            try
            {
                var d = await _calculatorService.AddAsync(firstNumber, secondNumber);
                _loggerDependency.LogInfo(1, DateTime.Now.TimeOfDay, d.ToString());
                return Ok();
            }
            catch (Exception ex)
            {
                _loggerDependency.LogError(ex);
                return Ok();
            }
        }

        [Route("subtract")]
        public async Task<IActionResult> Subtract(int firstNumber, int secondNumber)
        {
            try
            {
                var d = await _calculatorService.SubtractAsync(firstNumber, secondNumber);
                _loggerDependency.LogInfo(2, DateTime.Now.TimeOfDay, d.ToString());
                return Ok();
            }
            catch (Exception ex)
            {
                _loggerDependency.LogError(ex);
                return Ok();
            }
        }

        [Route("multiply")]
        public async Task<IActionResult> Multiply(int firstNumber, int secondNumber)
        {
            try
            {
                var d = await _calculatorService.MultiplyAsync(firstNumber, secondNumber);
                _loggerDependency.LogInfo(3, DateTime.Now.TimeOfDay, d.ToString());
                return Ok();
            }
            catch (Exception ex)
            {
                _loggerDependency.LogError(ex);
                return Ok();
            }
        }

        [Route("divide")]
        public async Task<IActionResult> Divide(int firstNumber, int secondNumber)
        {
            try
            {
                var d = await _calculatorService.DivideAsync(firstNumber, secondNumber);
                _loggerDependency.LogInfo(4, DateTime.Now.TimeOfDay, d.ToString());
                return Ok();
            }
            catch (Exception ex)
            {
                _loggerDependency.LogError(ex);
                return Ok();
            }
        }
    }
}