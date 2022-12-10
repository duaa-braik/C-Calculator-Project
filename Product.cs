using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata
{
    public class Product : IProduct
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

        public double PriceAfterDiscount { get; set; }

        public override string ToString()
        {
            return $"Sample product: {ProductType} with name = \"{Name}\", UPC = {UPC}, price = ${Price}.";
        }

        
    }
}
