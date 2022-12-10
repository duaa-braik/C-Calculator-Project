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
            Tax.TaxAmount = (Tax!.TaxPercentage / 100) * Product.Price;
            Product!.PriceAfterTax = Tax.TaxAmount + Product.Price;
        }

        public void SetDiscount(IDiscount discount)
        {
            Discount = discount;
            Discount.DiscountAmount = Product.Price * (Discount.DiscountPercentage / 100);
            Product.PriceAfterDiscount = Product.Price - Discount.DiscountAmount;
        }

        public double SetNewPrice()
        {
            Product.Price = Product.Price + Tax.TaxAmount;
            if (Discount != null)
            {
                Product.Price = Product.Price - Discount.DiscountAmount;
            }
            
            return Product.Price;
        }

        public void PrintPriceChange()
        {
            if(Discount != null)
            {
                //Console.WriteLine($"Tax = {Tax!.TaxPercentage * 100}%, discount = {Discount.DiscountPercentage * 100}%. " +
                //$"Tax amount  = {Tax.TaxAmount}, Discount amount = {Discount.DiscountAmount}");
                Console.WriteLine($"Tax = {Tax.TaxPercentage}%, discount = {Discount.DiscountPercentage}%");
                Console.WriteLine($"Price after discount: ${SetNewPrice()}");
                Console.WriteLine($"Discount Amount: {Discount.DiscountAmount}");


                //Console.WriteLine($"Price Before: {Product.Price}, Price After: {SetNewPrice()}");
            } else
            {
                Console.WriteLine($"Tax = {Tax.TaxPercentage}%, no discount");
                Console.WriteLine($"Price: ${SetNewPrice()}");
            }
            

        }
    }
}
