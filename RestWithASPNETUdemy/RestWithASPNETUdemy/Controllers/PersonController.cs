using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNETUdemy.Controllers
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

        [HttpGet("square-root/{number}")]
        public IActionResult Get(string number)
        {
            if (IsNumeric(number))
            {
               var result = Math.Sqrt(Convert.ToDouble(number));
                return Ok(result.ToString());
            }

            return BadRequest("Entrada inválida");
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber);

                return Ok(result.ToString());
            }

            return BadRequest("Entrada inválida");
        }


        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult GetSub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = Convert.ToDecimal(firstNumber) - Convert.ToDecimal(secondNumber);

                return Ok(result.ToString());
            }

            return BadRequest("Entrada inválida");
        }

        [HttpGet("mul/{firstNumber}/{secondNumber}")]
        public IActionResult GetMul(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = Convert.ToDecimal(firstNumber) * Convert.ToDecimal(secondNumber);

                return Ok(result.ToString());
            }

            return BadRequest("Entrada inválida");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult GetDiv(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = Convert.ToDecimal(firstNumber) / Convert.ToDecimal(secondNumber);

                return Ok(result.ToString());
            }

            return BadRequest("Entrada inválida");
        }
           

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse
                (strNumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);
            
            return isNumber;
        }
    }
}
