using Price_Calculator_Kata.ProductManager;

namespace Price_Calculator_Kata.DiscountManager
{
    public interface IDiscountRepository<T> where T : IDiscount
    {
        IDiscount Discount { get; set; }
        double TotalDiscountAmount { get; set; }

        void AddDiscount(T discount);
        void Additive();
        void Multiplicative();
    }
}