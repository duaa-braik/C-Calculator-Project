using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata
{
    public class DiscountRepository : IDiscountRepository
    {

        public IProduct Product { get; set; }
        public IDiscount Discount { get; set; }

        public DiscountRepository(IProduct product, IDiscount discount)
        {
            Product = product;
            Discount = discount;
        }

        public void SetDiscount()
        {
            Discount.DiscountAmount = Product.Price * (Discount.DiscountPercentage / 100);
            Product.PriceAfterDiscount = Product.Price - Discount.DiscountAmount;
        }
    }
}
