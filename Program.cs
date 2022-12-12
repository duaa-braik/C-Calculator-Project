
using Price_Calculator_Kata;
using System.Linq.Expressions;

public class Program
{
    public static void Main(string[] args)
    {

        string? CustomerTax, CustomerDiscount;
        ReadTaxDiscount(out CustomerTax, out CustomerDiscount);

        IProduct product = new Product
        {
            Name = "The Little Prince",
            ProductType = "Book",
            UPC = 12345,
            Price = 20.25
        };

        Console.WriteLine(product);

        IDiscount discount = new Discount { DiscountPercentage = int.Parse(CustomerDiscount) };

        ITax tax = new Tax { TaxPercentage = int.Parse(CustomerTax) };

        //IDiscountRepository discountRepository = new DiscountRepository(product, discount);

        //discountRepository.SetDiscount();

        ITaxRepository taxRepository = new TaxRepository(product, tax);

        taxRepository.SetTax();

        IProductRepository productRepository = new ProductRepository(product, tax);

        productRepository.PrintPriceChange();

    }

    private static void ReadTaxDiscount(out string? CustomerTax, out string? CustomerDiscount)
    {
        Console.WriteLine("Please specify the percentage of tax you want to have:");
        CustomerTax = Console.ReadLine();
        Console.WriteLine("Please specify the percentage of discount you want to have:");
        CustomerDiscount = Console.ReadLine();
    }
}