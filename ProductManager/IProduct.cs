namespace Price_Calculator_Kata.ProductManager
{
    public interface IProduct
    {
        string? Name { get; set; }
        double Price { get; set; }
        string? ProductType { get; set; }
        decimal UPC { get; set; }
        public double PriceAfterTax { get; set; }
        public double PriceAfterDiscount { get; set; }
        bool IsSpecial { get; set; }

        string ToString();
    }
}