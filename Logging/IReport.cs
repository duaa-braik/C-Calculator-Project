namespace Price_Calculator_Kata.Logging
{
    public interface IReport
    {
        double DiscountAmount { get; set; }
        double Packaging { get; set; }
        double Price { get; set; }
        string report { get; set; }
        double TaxAmount { get; set; }
        double Total { get; set; }
        double Transport { get; set; }

        void PrepareReport();
    }
}