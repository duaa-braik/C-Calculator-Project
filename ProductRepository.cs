using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata
{
    public class ProductRepository : IProductRepository
    {
        public IProduct? Product { get; set; }
        public ITax? Tax { get; set; }


        public void SetTax(ITax tax)
        {
            Tax = tax;
            //Product = product;
            Product!.PriceAfterTax = Tax!.TaxPercentage * Product.Price + Product.Price;
            PrintPriceChange();
        }

        private void PrintPriceChange()
        {
            //Console.WriteLine($"Tax = {Tax!.TaxPercentage * 100}, discount = {Discount.DiscountPercentage * 100}." +
            //    $"Tax amount  = {Tax!.TaxPercentage * Product.Price}, Discount Amount = {Product.Price * Discount.DiscountPercentage}");

            Console.WriteLine($"Product price reported as ${Product!.Price} before tax and ${Product.PriceAfterTax} " +
                                $"after {Tax!.TaxPercentage * 100}% tax");
        }
    }
}
