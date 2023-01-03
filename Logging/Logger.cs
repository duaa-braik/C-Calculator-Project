using Price_Calculator_Kata.ExpensesManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.Logging
{
    public class Logger
    {
        public double TaxAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double Price { get; set; }
        public IExpenses? Transport { get; set; }
        public IExpenses? Packaging { get; set; }

        public void PrepareReport()
        {
            //StringBuilder sb = new StringBuilder();
            string Report = 
                $"Cost: ${Price}\n" +
                $"Tax: ${TaxAmount:0.##}\n" + 
                $"Discounts: ${DiscountAmount:0.##}\n" +
                $"Packaging: ${Packaging.Amount}\n" + 
                $"Transport: ${Transport.Amount}\n" + 
                $"Total: ${CalculateTotal():0.##}";
            Print(Report);
        }

        public void Print(String s)
        {
            Console.Write(s);
        }

        public double CalculateTotal()
        {
            return Price - DiscountAmount + TaxAmount + Transport.Amount + Packaging.Amount;
        }


    }
}
