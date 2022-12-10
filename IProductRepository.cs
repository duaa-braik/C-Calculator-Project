namespace Price_Calculator_Kata
{
    public interface IProductRepository
    {
        IProduct Product { get; set; }
        ITax Tax { get; set; }
        IDiscount Discount { get; set; }
        void SetTax(ITax tax);
        void SetDiscount(IDiscount discount);
        public double SetNewPrice();
        void PrintPriceChange();
    }
}