﻿using System;
using System.Threading.Tasks;
using CalculationServiceRest.Core;
using CalculationServiceRest.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
                _logger.LogError(new Exception());
                _logger.LogInfo(new MethodTypeModel
                {
                    InsertDate=DateTime.Now.TimeOfDay,
                    MethodType= MethodTypeEnum.Add,
                    Value=$"add method called by firstnumber={firstNumber} and secondNumber={secondNumber}"
                });

                var response = await _calculatorService.AddAsync(firstNumber, secondNumber);
                
                _logger.LogInfo(new MethodTypeModel
                {
                    InsertDate = DateTime.Now.TimeOfDay,
                    MethodType = MethodTypeEnum.Add,
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
                    MethodType = MethodTypeEnum.Subtract,
                    Value = $"Subtract method called by firstnumber={firstNumber} and secondNumber={secondNumber}"
                });

                var response = await _calculatorService.SubtractAsync(firstNumber, secondNumber);

                _logger.LogInfo(new MethodTypeModel
                {
                    InsertDate = DateTime.Now.TimeOfDay,
                    MethodType = MethodTypeEnum.Subtract,
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
                    MethodType = MethodTypeEnum.Multiply,
                    Value = $"Multiply method called by firstnumber={firstNumber} and secondNumber={secondNumber}"
                });

                var response = await _calculatorService.MultiplyAsync(firstNumber, secondNumber);

                _logger.LogInfo(new MethodTypeModel
                {
                    InsertDate = DateTime.Now.TimeOfDay,
                    MethodType = MethodTypeEnum.Multiply,
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
                    MethodType = MethodTypeEnum.Divide,
                    Value = $"Subtract method called by firstnumber={firstNumber} and secondNumber={secondNumber}"
                });

                var response = await _calculatorService.DivideAsync(firstNumber, secondNumber);

                _logger.LogInfo(new MethodTypeModel
                {
                    InsertDate = DateTime.Now.TimeOfDay,
                    MethodType = MethodTypeEnum.Divide,
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