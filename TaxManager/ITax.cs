namespace Price_Calculator_Kata.TaxManager
{
    public interface ITax
    {
        double TaxPercentage { get; set; }
        double TaxAmount { get; set; }
    }
}