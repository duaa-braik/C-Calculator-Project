using Price_Calculator_Kata.ProductManager;

namespace Price_Calculator_Kata.DiscountManager
{
    public interface IDiscountRepository
    {
        IDiscount Discount { get; set; }
        double TotalDiscountAmount { get; set; }
        double Cap { get; set; }

        void AddDiscount(IDiscount discount);
        void Additive();
        void Multiplicative();
    }
}