namespace Price_Calculator_Kata.Currencies
{
    public interface ICurrency
    {
        string CurrencyName { get; }
        double Value { get; set; }
    }
}