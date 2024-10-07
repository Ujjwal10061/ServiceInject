using CalculatorAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService<double> _calculatorService;

        public CalculatorController(ICalculatorService<double> calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet("add")]
        public ActionResult<double> Add(double a, double b) => _calculatorService.Add(a, b);

        [HttpGet("subtract")]
        public ActionResult<double> Subtract(double a, double b) => _calculatorService.Subtract(a, b);

        [HttpGet("multiply")]
        public ActionResult<double> Multiply(double a, double b) => _calculatorService.Multiply(a, b);

        [HttpGet("divide")]
        public ActionResult<double> Divide(double a, double b)
        {
            try
            {
                return _calculatorService.Divide(a, b);
            }
            catch (DivideByZeroException)
            {
                return BadRequest("Cannot divide by zero.");
            }
        }
    }
}
