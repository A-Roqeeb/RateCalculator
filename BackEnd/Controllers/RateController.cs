using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.DTO;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RateController : ControllerBase
    {
        private static ExchangeRate exchangeRate = new ExchangeRate(0, "GBP", "NGN");
    
        [HttpGet("get-rate")]
        public IActionResult GetRate() 
        {
            var rateToReturn = exchangeRate.GetRate();
            return Ok(rateToReturn);
        }

        [HttpPost("set-rate")]
        public IActionResult SetRate([FromBody] ExchangeRateDTO exchangeRateDTO) 
        {
            if(exchangeRateDTO.fromCurrency.ToLower() != "gbp") {
                return BadRequest("From currenct not supported, only GBP is supported");
            }
            if(exchangeRateDTO.toCurrency.ToLower() != "ngn") {
                return BadRequest("From currenct not supported, only NGN is supported");
            }

            exchangeRate.ChangeRate(exchangeRateDTO.rate);
            return Ok(new {
                Message = "Rate Changed Successfully"
            });
        }

    }    
}