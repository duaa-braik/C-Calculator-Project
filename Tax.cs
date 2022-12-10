using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata
{

    public class Tax : ITax
    {
        private double _tax;

        public double TaxPercentage
        {
            get { return _tax; }
            set
            {
                _tax = value / 100;
            }
        }

    }
}
