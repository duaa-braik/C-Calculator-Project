using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.TaxManager
{

    public class Tax : ITax
    {
        private double _tax;

        public double TaxPercentage
        {
            get;
            set;
        }

        private double _taxAmount;

        public double TaxAmount
        {
            get
            {
                return _taxAmount;
            }
            set
            {
                _taxAmount = Precision.ChangePrecision(value);
            }
        }
    }
}
