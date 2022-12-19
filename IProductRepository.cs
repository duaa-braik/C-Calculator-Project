namespace Price_Calculator_Kata
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