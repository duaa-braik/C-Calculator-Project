using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.ExpensesManager
{
    public class PackagingCost : IPackagingCost
    {
        public double Amount { get; set; } = 0; 
        public double Percentage { get; set; } = 0;
    }
}
