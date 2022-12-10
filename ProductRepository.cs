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
        public IDiscount Discount { get; set; }

        public void SetTax(ITax tax)
        {
            Tax = tax;
            Tax.TaxAmount = Tax!.TaxPercentage * Product.Price;
            Product!.PriceAfterTax = Tax.TaxAmount + Product.Price;
        }

        public void SetDiscount(IDiscount discount)
        {
            Discount = discount;
            Discount.DiscountAmount = Product.Price * Discount.DiscountPercentage;
            Product.PriceAfterDiscount = Product.Price - Discount.DiscountAmount;
            PrintPriceChange();
        }

        private void PrintPriceChange()
        {
            Console.WriteLine($"Tax = {Tax!.TaxPercentage * 100}%, discount = {Discount.DiscountPercentage * 100}%. " +
                $"Tax amount  = {Tax.TaxAmount}, Discount amount = {Discount.DiscountAmount}");

        }
    }
}
