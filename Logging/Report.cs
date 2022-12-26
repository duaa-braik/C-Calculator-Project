using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.Logging
{
    public class Report : IReport
    {
        private double _total;

        public double TaxAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double Price { get; set; }
        public double Transport { get; set; }
        public double Packaging { get; set; }
        public double Total { get; set; }
        public string CurrencyCode { get; set; }

        public string report { get; set; }

        public void PrepareReport()
        {
            //StringBuilder sb = new StringBuilder();
            string Report =
                $"Cost: {Price} {CurrencyCode}\n" +
                $"Tax: {TaxAmount} {CurrencyCode}\n" +
                $"Discounts: {DiscountAmount} {CurrencyCode} \n" +
                $"Packaging: {Packaging} {CurrencyCode} \n" +
                $"Transport: {Transport} {CurrencyCode}  \n" +
                $"Total: {Total} {CurrencyCode}  \n";
            report = Report;
        }
    }
}
