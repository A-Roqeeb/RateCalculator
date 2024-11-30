using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.DTO
{
    public record ExchangeRateDTO(double rate, string fromCurrency, string toCurrency);
}