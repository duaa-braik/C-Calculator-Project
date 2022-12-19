using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.DiscountManager
{
    public class SpecialDiscount : ISpecialDiscount
    {
        double IDiscount.DiscountPercentage { get; set; }
        double IDiscount.DiscountAmount { get; set; }
    }
}
