using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace DotnetCal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArithmeticController : ControllerBase
    {

        [HttpGet("add")]
        [Authorize]
        public ActionResult <Decimal> Addition([FromQuery(Name = "num1")]Decimal num1, [FromQuery(Name = "num2")]Decimal num2)
        {
            return num1 + num2;
        }

        [HttpGet("sub")]
        [Authorize]
        public ActionResult <Decimal> Subtraction([FromQuery(Name = "num1")]Decimal num1, [FromQuery(Name = "num2")]Decimal num2)
        {
            return num1 - num2;
        }

        [HttpGet("multiply")]
        [Authorize]
        public ActionResult <Decimal> Multiply([FromQuery(Name = "num1")]Decimal num1, [FromQuery(Name = "num2")]Decimal num2)
        {
            return num1 * num2;
        }

        [HttpGet("divide")]
        [Authorize]
        public ActionResult <Decimal> Divide([FromQuery(Name = "num1")]Decimal num1, [FromQuery(Name = "num2")]Decimal num2)
        {
            return num1 / num2;
        }
    }
}