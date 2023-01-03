using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.Logging
{
    public class Report : IReport
    {
        public double TaxAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double Price { get; set; }
        public double Transport { get; set; }
        public double Packaging { get; set; }
        public double Total { get; set; }

        public string report { get; set; }

        public void PrepareReport()
        {
            //StringBuilder sb = new StringBuilder();
            string Report =
                $"Cost: {Price:0.##}\n" +
                $"Tax: {TaxAmount:0.##}\n" +
                $"Discounts: {DiscountAmount:0.##}\n" +
                $"Packaging: {Packaging:0.##}\n" +
                $"Transport: {Transport:0.##}\n" +
                $"Total: {Total:0.##}\n";
            report = Report;
        }
    }
}
