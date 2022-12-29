namespace Price_Calculator_Kata
{
    public interface ITaxRepository
    {
        IProduct Product { get; set; }
        ITax Tax { get; set; }

        void SetTax();
    }
}