namespace Price_Calculator_Kata
{
    public interface IDiscountRepository
    {
        IDiscount generalDiscount { get; set; }
        IProduct Product { get; set; }

        void CalculateDiscount();
    }
}