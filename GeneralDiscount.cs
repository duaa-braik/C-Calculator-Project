﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata
{
    public class GeneralDiscount : IGeneralDiscount
    {
        double IDiscount.DiscountPercentage { get; set; }
        double IDiscount.DiscountAmount { get; set; }
    }
}
