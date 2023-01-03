using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata
{
    public class Precision
    {
        public static double ChangePrecision(double number, int digits)
        {
            return Math.Round(number, digits);
        }
        public static double ChangePrecision(double number)
        {
            return Math.Round(number, 4);
        }
    }
}
