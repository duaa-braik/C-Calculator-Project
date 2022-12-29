using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata
{
    public class Discount : IDiscount
    {
        private double _dicount;
        public double DiscountPercentage
        {
            get { return _dicount; }
            set
            {
                _dicount = value / 100;
            }
        }

        private double _discountAmount;

        public double DiscountAmount {
            get { return _discountAmount; } 
            set
            {
                _discountAmount = Math.Round(value, 2);
            } 
        }
    }
}
