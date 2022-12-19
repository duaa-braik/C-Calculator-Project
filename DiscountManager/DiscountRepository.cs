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
        public IDiscount generalDiscount { get; set; }
        public IDiscount specialDiscount { get; set; }

        public DiscountRepository(IProduct product, IDiscount discount)
        {
            if (discount.GetType() == typeof(GeneralDiscount))
            {
                Product = product;
                generalDiscount = discount;
            }
            else if (discount.GetType() == typeof(SpecialDiscount))
            {
                Product = product;
                specialDiscount = discount;
            }

        }

        public void CalculateDiscount()
        {
            if (generalDiscount != null)
            {
                generalDiscount.DiscountAmount = Product.Price * (generalDiscount.DiscountPercentage / 100);
            }
            else if (specialDiscount != null)
            {
                specialDiscount.DiscountAmount = Product.Price * (specialDiscount.DiscountPercentage / 100);
                Product.Price = Product.Price - specialDiscount.DiscountAmount;
            }
        }
    }
}
