
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

        string? CustomerTax, CustomerDiscount;
        ReadTaxDiscount(out CustomerTax, out CustomerDiscount);

        Console.WriteLine(product);

        IProductRepository ProductRepository = new ProductRepository()
        {
            Product = product
        };

        ProductRepository.SetTax(
            new Tax { TaxPercentage = int.Parse(CustomerTax!) }
        );

        //ProductRepository.SetDiscount(
        //    new Discount { DiscountPercentage = int.Parse(CustomerDiscount!) }
        //);

        ProductRepository.PrintPriceChange();




    }

    private static void ReadTaxDiscount(out string? CustomerTax, out string? CustomerDiscount)
    {
        Console.WriteLine("Please specify the percentage of tax you want to have:");
        CustomerTax = Console.ReadLine();
        Console.WriteLine("Please specify the percentage of discount you want to have:");
        CustomerDiscount = Console.ReadLine();
    }
}