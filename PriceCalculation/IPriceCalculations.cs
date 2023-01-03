namespace Price_Calculator_Kata.PriceCalculation
{
    public interface IPriceCalculations
    {
        double DiscountAmount { get; set; }
        double Packaging { get; set; }
        double Price { get; set; }
        double TaxAmount { get; set; }
        double Transport { get; set; }

        double CalculateTotal();
    }
}