namespace Price_Calculator_Kata.DiscountManager
{
    public interface IDiscount
    {
        double DiscountPercentage { get; set; }
        double DiscountAmount { get; set; }
    }
}