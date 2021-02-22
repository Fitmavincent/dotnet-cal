using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotnetCal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArithmeticController : ControllerBase
    {

        [HttpGet("add")]
        public ActionResult <Decimal> Addition([FromQuery(Name = "num1")]Decimal num1, [FromQuery(Name = "num2")]Decimal num2)
        {
            return num1 + num2;
        }

        [HttpGet("sub")]
        public ActionResult <Decimal> Subtraction([FromQuery(Name = "num1")]Decimal num1, [FromQuery(Name = "num2")]Decimal num2)
        {
            return num1 - num2;
        }

        [HttpGet("multiply")]
        public ActionResult <Decimal> Multiply([FromQuery(Name = "num1")]Decimal num1, [FromQuery(Name = "num2")]Decimal num2)
        {
            return num1 * num2;
        }

        [HttpGet("divide")]
        public ActionResult <Decimal> Divide([FromQuery(Name = "num1")]Decimal num1, [FromQuery(Name = "num2")]Decimal num2)
        {
            return num1 / num2;
        }
    }
}