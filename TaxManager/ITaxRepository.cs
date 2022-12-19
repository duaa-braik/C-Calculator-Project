using Price_Calculator_Kata.ProductManager;

namespace Price_Calculator_Kata.TaxManager
{
    public interface ITaxRepository
    {
        IProduct Product { get; set; }
        ITax Tax { get; set; }

        void CalculateTax();
    }
}