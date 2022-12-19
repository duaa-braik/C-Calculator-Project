using Price_Calculator_Kata.ProductManager;

namespace Price_Calculator_Kata.DiscountManager
{
    public interface IDiscountRepository
    {
        IDiscount generalDiscount { get; set; }
        IProduct Product { get; set; }

        void CalculateDiscount();
    }
}