using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace RestAspNetCoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
       

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString("F2", CultureInfo.InvariantCulture));
            }

            return BadRequest("Ivalid Input");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sum.ToString("F2", CultureInfo.InvariantCulture));
            }

            return BadRequest("Ivalid Input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(sum.ToString("F2", CultureInfo.InvariantCulture));
            }

            return BadRequest("Ivalid Input");
        }

        [HttpGet("square/{firstNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {
            if (IsNumeric(firstNumber) )
            {

                var sum = (double)ConvertToDecimal(firstNumber);
                if (sum >= 0)
                {
                    sum = Math.Sqrt(sum);
                    return Ok(sum.ToString("F2", CultureInfo.InvariantCulture));
                }
                else
                    return BadRequest("Invalid Number for SQRT");
                    
            }

            return BadRequest("Ivalid Input");
        }

        // Isto vai ser uma calculadora de serviços
        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {

                var first = (double)ConvertToDecimal(firstNumber);
                var second = (double)ConvertToDecimal(secondNumber);
                if (second != 0.0)
                {
                    var sum = first/second;
                    return Ok(sum.ToString("F2", CultureInfo.InvariantCulture));
                }
                else
                    return BadRequest("Division for Zero");

            }

            return BadRequest("Ivalid Input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;

            throw new NotImplementedException();
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
    }
}