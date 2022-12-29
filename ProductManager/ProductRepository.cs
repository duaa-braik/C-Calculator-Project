using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Price_Calculator_Kata.TaxManager;
using Price_Calculator_Kata.DiscountManager;

namespace Price_Calculator_Kata.ProductManager
{
    public class ProductRepository : IProductRepository
    {
        public IProduct? Product { get; set; }
        public ITax? Tax { get; set; }
        public IDiscount Discount { get; set; }
        public IDiscount SpecialDiscount { get; set; }


        public ProductRepository(IProduct product)
        {
            Product = product;
        }

        public void AddGeneralDiscount(IDiscount discount)
        {
            Discount = discount;
        }

        public void AddTax(ITax tax)
        {
            Tax = tax;
        }

        public void AddSpecialDiscount(IDiscount spacialDiscount)
        {
            SpecialDiscount = spacialDiscount;
        }

        public double SetNewPrice()
        {

            Product.Price = Product.Price + Tax.TaxAmount;

            if (Discount != null)
            {
                Product.Price = Product.Price - Discount.DiscountAmount;
            }
            if(SpecialDiscount != null)
            {
                Product.Price = Product.Price - SpecialDiscount.DiscountAmount;
            }
            return Product.Price;
        }

        public void PrintPriceChange()
        {
            double totalDiscountAmount = 0;
            if (Discount != null)
            {
                Console.WriteLine($"Tax = {Tax.TaxPercentage}%, discount = {Discount.DiscountPercentage}%");
                Console.WriteLine($"Price after discount: ${SetNewPrice():0.##}");
                totalDiscountAmount = Discount.DiscountAmount;
            }
            else
            {
                Console.WriteLine($"Tax = {Tax.TaxPercentage}%, no discount");
                Console.WriteLine($"Price: ${SetNewPrice()}");
            }
            if (SpecialDiscount != null)
            {
                totalDiscountAmount += SpecialDiscount.DiscountAmount;
            }
            Console.WriteLine($"Discount Amount: ${totalDiscountAmount:0.##}");

        }
    }
}
