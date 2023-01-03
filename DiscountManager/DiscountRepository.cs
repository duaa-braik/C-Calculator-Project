using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Price_Calculator_Kata.ProductManager;

namespace Price_Calculator_Kata.DiscountManager
{
    public class DiscountRepository : IDiscountRepository
    {

        public IProduct Product { get; set; }
        public IDiscount Discount { get; set; }
        public double TotalDiscountAmount { get; set; } = 0;
        public double PriceForDiscount { get; set; }
        public double Cap { get; set; }

        public DiscountRepository(IProduct product)
        {
            Product = product;
            PriceForDiscount = Product.Price; // 20.25
        }

        public void AddDiscount(IDiscount discount)
        {
            Discount = discount;
        }

        public void Additive()
        {
            Discount.DiscountAmount = Product.Price * Discount.DiscountPercentage / 100;
            TotalDiscountAmount += Discount.DiscountAmount;
            CompareDiscount();
        }

        public void Multiplicative()
        {
            Discount.DiscountAmount = PriceForDiscount * Discount.DiscountPercentage / 100; // 1.42 // 2.82
            TotalDiscountAmount += Discount.DiscountAmount;
            PriceForDiscount = Product.Price - Discount.DiscountAmount; // 18.83 // 
            CompareDiscount();
        }

        public void CompareDiscount()
        {
            if(TotalDiscountAmount > Cap)
            {
                TotalDiscountAmount = Cap;
            }
        }

    }
}
