using Price_Calculator_Kata.ProductManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.PriceCalculation
{
    public class PriceCalculations : IPriceCalculations
    {
        public double TaxAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double Price { get; set; }
        public double Transport { get; set; }
        public double Packaging { get; set; }

        public double CalculateTotal()
        {
            return Price - DiscountAmount + TaxAmount + Transport + Packaging;
        }

    }
}
