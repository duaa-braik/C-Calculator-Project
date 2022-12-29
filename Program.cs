
using Price_Calculator_Kata;
using Price_Calculator_Kata.DiscountManager;
using Price_Calculator_Kata.ExpensesManager;
using Price_Calculator_Kata.ProductManager;
using Price_Calculator_Kata.TaxManager;
using System.Linq;
using System.Linq.Expressions;

public class Program
{
    public static void Main(string[] args)
    {

        string? CustomerTax, CustomerDiscount;
        ReadTaxDiscount(out CustomerTax, out CustomerDiscount);

        IProduct product1 = new Product
        {
            Name = "The Little Prince",
            ProductType = "Book",
            UPC = 12345,
            Price = 20.25,
            IsSpecial = true,
            HasAddtionalExpenses = true,
        };

        IProduct product2 = new Product
        {
            Name = "Pride and Prejudice",
            ProductType = "Book",
            UPC = 789,
            Price = 20.25,
            IsSpecial = false,
            HasAddtionalExpenses = false,
        };

        List<IProduct> products = new List<IProduct>();

        products.Add(product1);
        products.Add(product2);

        string? spacialDiscount = Console.ReadLine();
        calculatingdiscount(products, CustomerTax, CustomerDiscount, spacialDiscount);
    }

    private static void calculatingdiscount(List<IProduct> products, string CustomerTax, string CustomerDiscount, string spacialDiscount)
    {
        ITax tax = new Tax { TaxPercentage = int.Parse(CustomerTax) };

        IDiscount generalDiscount = new GeneralDiscount();
        generalDiscount.DiscountPercentage = int.Parse(CustomerDiscount);

        IDiscount specialDiscount = new SpecialDiscount();
        specialDiscount.DiscountPercentage = int.Parse(spacialDiscount!);

        IDiscountRepository discountRepository;
        for (int i = 0; i < 1; i++)
        {
            Console.WriteLine(products[i]);

            IProductRepository productRepository = new ProductRepository(products[i]);

            if (products[i].IsSpecial)
            {
                discountRepository = new DiscountRepository(products[i], specialDiscount);
                discountRepository.CalculateDiscount();
                productRepository.AddSpecialDiscount(specialDiscount);
            }

            ITaxRepository taxRepository = new TaxRepository(products[i], tax);
            taxRepository.CalculateTax();

            productRepository.AddTax(tax);

            discountRepository = new DiscountRepository(products[i], generalDiscount);
            discountRepository.CalculateDiscount();

            productRepository.AddGeneralDiscount(generalDiscount);

            productRepository.PrintPriceChange();

            if (products[i].HasAddtionalExpenses)
            {
                IExpenses transport = new TransportCost { Amount = 2.2 };
                IExpenses packaging = new PackagingCost { Percentage = 1 };
                ExpensesRepository expensesRepository = new ExpensesRepository(products[i]);
                expensesRepository.AddCost(packaging);
                expensesRepository.AddCost(transport);
                expensesRepository.PrintExpenses();
            }
        }


    }

    private static void ReadTaxDiscount(out string? CustomerTax, out string? CustomerDiscount)
    {
        Console.WriteLine("Please specify the percentage of tax you want to have:");
        CustomerTax = Console.ReadLine();
        Console.WriteLine("Please specify the percentage of discount you want to have:");
        CustomerDiscount = Console.ReadLine();
    }
}