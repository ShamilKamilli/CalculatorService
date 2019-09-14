using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CalculationServiceRest.Core;
using CalculationServiceRest.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Targets;
using SoapServiceReference;

namespace CalculationServiceRest.Controllers
{
    [Route("api/calculate")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService = null;
        private readonly ILoggerDependency _logger = null;

        public CalculateController(ICalculatorService calculatorService,
            ILoggerDependency logger)
        {
            _calculatorService = calculatorService;
            _logger = logger;
        }

        [Route("")]
        public async Task<IActionResult> Add(int firstNumber,int secondNumber)
        {
            try
            {
                _logger.LogInfo(new MethodTypeModel
                {
                    InsertDate=DateTime.Now.TimeOfDay,
                    MethodType=1,
                    Value=$"add method called by firstnumber={firstNumber} and secondNumber={secondNumber}"
                });

                var response = await _calculatorService.AddAsync(firstNumber, secondNumber);
                
                _logger.LogInfo(new MethodTypeModel
                {
                    InsertDate = DateTime.Now.TimeOfDay,
                    MethodType = 1,
                    Value = $"soap service response is {response}"
                });
                _logger.SaveChanges();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return new StatusCodeResult(500);
            }
        }

        [Route("subtract")]
        public async Task<IActionResult> Subtract(int firstNumber, int secondNumber)
        {
            try
            {
                _logger.LogInfo(new MethodTypeModel
                {
                    InsertDate = DateTime.Now.TimeOfDay,
                    MethodType = 2,
                    Value = $"Subtract method called by firstnumber={firstNumber} and secondNumber={secondNumber}"
                });

                var response = await _calculatorService.SubtractAsync(firstNumber, secondNumber);

                _logger.LogInfo(new MethodTypeModel
                {
                    InsertDate = DateTime.Now.TimeOfDay,
                    MethodType = 2,
                    Value = $"soap service response is {response}"
                });
                _logger.SaveChanges();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return new StatusCodeResult(500);
            }
        }

        [Route("multiply")]
        public async Task<IActionResult> Multiply(int firstNumber, int secondNumber)
        {
            try
            {
                _logger.LogInfo(new MethodTypeModel
                {
                    InsertDate = DateTime.Now.TimeOfDay,
                    MethodType = 3,
                    Value = $"Multiply method called by firstnumber={firstNumber} and secondNumber={secondNumber}"
                });

                var response = await _calculatorService.MultiplyAsync(firstNumber, secondNumber);

                _logger.LogInfo(new MethodTypeModel
                {
                    InsertDate = DateTime.Now.TimeOfDay,
                    MethodType = 3,
                    Value = $"soap service response is {response}"
                });
                _logger.SaveChanges();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return new StatusCodeResult(500);
            }
        }

        [Route("divide")]
        public async Task<IActionResult> Divide(int firstNumber, int secondNumber)
        {
            try
            {
                _logger.LogInfo(new MethodTypeModel
                {
                    InsertDate = DateTime.Now.TimeOfDay,
                    MethodType = 4,
                    Value = $"Subtract method called by firstnumber={firstNumber} and secondNumber={secondNumber}"
                });

                var response = await _calculatorService.DivideAsync(firstNumber, secondNumber);

                _logger.LogInfo(new MethodTypeModel
                {
                    InsertDate = DateTime.Now.TimeOfDay,
                    MethodType = 4,
                    Value = $"soap service response is {response}"
                });
                _logger.SaveChanges();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return new StatusCodeResult(500);
            }
        }
    }
}