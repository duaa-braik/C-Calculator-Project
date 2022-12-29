namespace Price_Calculator_Kata
{
    public interface IDiscount
    {
        double DiscountPercentage { get; set; }
        double DiscountAmount { get; set; }
    }
}