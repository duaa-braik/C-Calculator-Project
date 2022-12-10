namespace Price_Calculator_Kata
{
    public interface IProduct
    {
        string? Name { get; set; }
        double Price { get; set; }
        string? ProductType { get; set; }
        ITax? Tax { get; set; }
        decimal UPC { get; set; }
        public double PriceAfterTax { get; set; }
        string ToString();
    }
}