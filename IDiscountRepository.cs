namespace Price_Calculator_Kata
{
    public interface IDiscountRepository
    {
        IDiscount Discount { get; set; }
        IProduct Product { get; set; }

        void SetDiscount();
    }
}