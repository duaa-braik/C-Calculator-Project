using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata
{
    public class Product
    {
        public string? Name { get; set; }

        public string? ProductType { get; set; }

        public decimal UPC { get; set; }

        public ITax? Tax { get; set; }

        public double Price { get; set; }

        private double afterTax;

        public double PriceAfterTax { 

            get { return afterTax; } 
            set
            {
                afterTax = Math.Round(value, 2);
            }
        }

        public override string ToString()
        {
            return $"Sample product: {ProductType} with name = \"{Name}\", UPC = {UPC}, price = ${Price}.";
        }

        public void SetTax(ITax tax)
        {
            Tax = tax;
            PriceAfterTax = Tax.TaxPercentage * Price + Price;
            PrintPriceChange();
        }
        private void PrintPriceChange()
        {
            Console.WriteLine(
                $"Product price reported as ${Price} before tax and ${PriceAfterTax} after {Tax.TaxPercentage * 100}% tax"
            );
        }
    }
}
