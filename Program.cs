
using Price_Calculator_Kata;

public class Program
{
    public static void Main(string[] args)
    {
        Product product = new Product
        {
            Name = "The Little Prince",
            ProductType = "Book",
            UPC = 12345,
            Price = 20.25
        };

        Console.WriteLine("Please specify the percentage of tax you want: ");
        string? CustomerTax = Console.ReadLine();

        Console.WriteLine(product);

        product.SetTax(new Tax
        {
            TaxPercentage = Int32.Parse(CustomerTax!)
        });

        product.SetTax(new Tax
        {
            TaxPercentage = 21
        });
    }
}