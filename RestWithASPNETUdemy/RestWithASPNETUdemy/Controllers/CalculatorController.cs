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
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CalculatorController> _logger;

        // The Web API will only accept tokens 1) for users, and 2) having the "access_as_user" scope for this API
        static readonly string[] scopeRequiredByApi = new string[] { "access_as_user" };

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("operation/{op}/{firstNumber}/{secondNumber}")]
        public ActionResult Get(string op, string firstNumber, string secondNumber)
        {
           if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
           {
                decimal result = 0;
                switch (op)
                {
                    case "sum":
                        result = Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber);
                        break;
                    
                    case "sub":
                        result = Convert.ToDecimal(firstNumber) - Convert.ToDecimal(secondNumber);
                        break;
                   
                    case "mul":
                        result = Convert.ToDecimal(firstNumber) * Convert.ToDecimal(secondNumber);
                        break;
                    
                    case "div":
                        result = Convert.ToDecimal(firstNumber) / Convert.ToDecimal(secondNumber);
                        break;
                   
                    default:
                        break;
                }
               
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
