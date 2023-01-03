using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.Currencies
{
    public class Currency : ICurrency
    {
        public string CurrencyName { get; set; }
        public double Value { get; set; }
    }

}
