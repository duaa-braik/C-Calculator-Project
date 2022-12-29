namespace Price_Calculator_Kata
{
    public interface IProductRepository
    {
        IProduct Product { get; set; }
        public double SetNewPrice();
        void PrintPriceChange();
    }
}