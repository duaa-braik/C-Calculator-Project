using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.ExpensesManager
{
    public class Expenses : IExpenses
    {
        public double Amount { get; set; }
        public double Percentage { get; set; }
    }
}
