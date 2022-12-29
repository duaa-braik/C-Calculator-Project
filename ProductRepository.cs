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


        public ProductRepository(IProduct product, IDiscount discount, ITax tax)
        {
            Product = product;
            Discount = discount;
            Tax = tax;
        }

        public ProductRepository(IProduct product, ITax tax)
        {
            Product = product;
            Tax = tax;
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
                Console.WriteLine($"Tax = {Tax.TaxPercentage}%, discount = {Discount.DiscountPercentage}%");
                Console.WriteLine($"Price after discount: ${SetNewPrice()}");
                Console.WriteLine($"Discount Amount: {Discount.DiscountAmount}");
            } else
            {
                Console.WriteLine($"Tax = {Tax.TaxPercentage}%, no discount");
                Console.WriteLine($"Price: ${SetNewPrice()}");
            }

        }
    }
}
