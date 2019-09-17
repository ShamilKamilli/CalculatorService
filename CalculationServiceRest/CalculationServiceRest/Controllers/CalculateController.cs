using System;
using System.Net;
using System.Threading.Tasks;
using CalculationServiceRest.Core;
using CalculationServiceRest.Core.Extensions;
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

        [Route("Add")]
        public async Task<IActionResult> Add(CulculatorModel model)
        {
            if (!ModelState.IsValid)
                return new StatusCodeResult((int)HttpStatusCode.NotAcceptable);
            try
            {

                _logger.AddInfo(DateTime.Now.TimeOfDay, MethodTypeEnum.Add,$"add method called by firstnumber={model.FirstNumber} and secondNumber={model.SecondNumber}");

                var response = await _calculatorService.AddAsync(model.FirstNumber, model.SecondNumber);

                _logger.AddInfo(DateTime.Now.TimeOfDay, MethodTypeEnum.Add, $"soap service response is {response}");

                _logger.SaveChanges();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        [Route("subtract")]
        public async Task<IActionResult> Subtract(CulculatorModel model)
        {
            if (!ModelState.IsValid)
                return new StatusCodeResult((int)HttpStatusCode.NotAcceptable);

            try
            {
                _logger.AddInfo(DateTime.Now.TimeOfDay, MethodTypeEnum.Subtract, $"Subtract method called by firstnumber={model.FirstNumber} and secondNumber={model.SecondNumber}");

                var response = await _calculatorService.SubtractAsync(model.FirstNumber, model.SecondNumber);

                _logger.AddInfo(DateTime.Now.TimeOfDay, MethodTypeEnum.Add, $"soap service response is {response}");

                _logger.SaveChanges();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        [Route("multiply")]
        public async Task<IActionResult> Multiply(CulculatorModel model)
        {
            if (!ModelState.IsValid)
                return new StatusCodeResult((int)HttpStatusCode.NotAcceptable);

            try
            {
                _logger.AddInfo(DateTime.Now.TimeOfDay, MethodTypeEnum.Multiply, $"Multiply method called by firstnumber={model.FirstNumber} and secondNumber={model.SecondNumber}");

                var response = await _calculatorService.MultiplyAsync(model.FirstNumber, model.SecondNumber);

                _logger.AddInfo(DateTime.Now.TimeOfDay, MethodTypeEnum.Add, $"soap service response is {response}");

                _logger.SaveChanges();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        [Route("divide")]
        public async Task<IActionResult> Divide(CulculatorModel model)
        {
            if (!ModelState.IsValid)
                return new StatusCodeResult((int)HttpStatusCode.NotAcceptable);

            try
            {
                _logger.AddInfo(DateTime.Now.TimeOfDay, MethodTypeEnum.Divide, $"Divide method called by firstnumber={model.FirstNumber} and secondNumber={model.SecondNumber}");

                var response = await _calculatorService.DivideAsync(model.FirstNumber, model.SecondNumber);

                _logger.AddInfo(DateTime.Now.TimeOfDay, MethodTypeEnum.Add, $"soap service response is {response}");

                _logger.SaveChanges();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}