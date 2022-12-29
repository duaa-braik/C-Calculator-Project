
using Price_Calculator_Kata;

public class Program
{
    public static void Main(string[] args)
    {
        IProduct product = new Product
        {
            Name = "The Little Prince",
            ProductType = "Book",
            UPC = 12345,
            Price = 20.25
        };

        Console.WriteLine("Please specify the percentage of tax you want: ");
        string? CustomerTax = Console.ReadLine();

        Console.WriteLine(product);

        IProductRepository ProductRepository = new ProductRepository()
        {
            Product = product
        };

        ProductRepository.SetTax(
            new Tax { TaxPercentage = Int32.Parse(CustomerTax!) }
        );

        ProductRepository.SetTax(
            new Tax { TaxPercentage = 21 }
        );


    }
}