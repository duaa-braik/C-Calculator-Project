using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

namespace Price_Calculator_Kata.Currencies
{
    public class CurrencyConverter
    {
        public ICurrency? To { get; set; }
        public Dictionary<string, double> _currencies;

        public CurrencyConverter(ICurrency to)
        {
            To = to;
            _currencies = CurrenciesData.Currencies;
        }
        public double Convert(double cost) 
        {
            To!.Value = _currencies.Where(currency => currency.Key == To.CurrencyName)
                                  .Select(currency => currency.Value)
                                  .First();
            return To.Value * cost;

        }
    }
}
