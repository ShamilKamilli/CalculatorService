using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculationServiceRest.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculationServiceRest.Controllers
{
    [Route("api/calculator")]
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
    }
}