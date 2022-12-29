using Price_Calculator_Kata.DiscountManager;
using Price_Calculator_Kata.TaxManager;

namespace Price_Calculator_Kata.ProductManager
{
    public interface IProductRepository
    {
        IProduct Product { get; set; }
        public double SetNewPrice();
        void PrintPriceChange();
        void AddSpecialDiscount(IDiscount spacialDiscount);
        void AddGeneralDiscount(IDiscount discount);
        void AddTax(ITax tax);
    }
}