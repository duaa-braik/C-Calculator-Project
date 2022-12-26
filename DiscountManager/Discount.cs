using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.DiscountManager
{
    public class Discount : IDiscount
    {
        public double DiscountPercentage { get; set; }

        private double _discountAmount = 0;

        public double DiscountAmount
        {
            get { return _discountAmount; }
            set
            {
                _discountAmount = Precision.ChangePrecision(value);
            }
        }
    }
}
