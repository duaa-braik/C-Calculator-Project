using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.ExpensesManager
{
    public class PackagingCost : IPackagingCost
    {
        private double _amount = 0;
        public double Amount {
            get { 
                return _amount; 
            } 
            set
            {
                _amount = Precision.ChangePrecision(value);
            }
        } 
        public double Percentage { get; set; } = 0;
    }
}
