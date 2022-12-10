namespace Price_Calculator_Kata
{
    public interface IProductRepository
    {
        IProduct Product { get; set; }
        ITax Tax { get; set; }

        void SetTax(ITax tax);
    }
}