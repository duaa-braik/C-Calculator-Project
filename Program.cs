
using Price_Calculator_Kata;
using Price_Calculator_Kata.DiscountManager;
using Price_Calculator_Kata.ExpensesManager;
using Price_Calculator_Kata.Logging;
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

        Console.WriteLine("Choose the way you want to have your discounts to be calculated");
        Console.WriteLine("1) Additive. 2) Multiplicative");
        int CustomerChoice = int.Parse(Console.ReadLine());

        ITax tax = new Tax { TaxPercentage = int.Parse(CustomerTax) };

        IDiscount generalDiscount = new GeneralDiscount();
        generalDiscount.DiscountPercentage = int.Parse(CustomerDiscount);


        for (int i = 0; i < 1; i++)
        {
            IDiscountRepository<IDiscount> discountRepository = new DiscountRepository<IDiscount>(products[i]);
            calculatingdiscount(products[i], discountRepository, tax, generalDiscount, spacialDiscount, CustomerChoice);

            IExpenses transport = new TransportCost();
            IExpenses packaging = new PackagingCost();
            if (products[i].HasAddtionalExpenses)
            {
                transport.Amount = 2.2;
                packaging.Amount = 0.2;
            }

            Logger logger = new Logger
            {
                Price = products[i].Price,
                DiscountAmount = discountRepository.TotalDiscountAmount,
                TaxAmount = tax.TaxAmount,
                Transport = transport,
                Packaging = packaging
            };
            logger.PrepareReport();
        }
    }

    private static void calculatingdiscount(IProduct product, IDiscountRepository<IDiscount> discountRepository, ITax tax, IDiscount generalDiscount, string spacialDiscount, int choice)
    {

        Console.WriteLine("Please Spacify the cap amount, as:");
        Console.WriteLine("1) Amount. 2) Percentage");
        int CapChoice = int.Parse(Console.ReadLine());

        Console.Write("Cap: ");
        double Cap = double.Parse(Console.ReadLine()!);

        if(CapChoice == 2)
        {
            Cap = Cap / 100 * product.Price;
        }

        discountRepository.Cap = Cap;

        IDiscount specialDiscount = new SpecialDiscount();
        specialDiscount.DiscountPercentage = int.Parse(spacialDiscount);

        Console.WriteLine(product);

        IProductRepository productRepository = new ProductRepository(product);

        if (product.IsSpecial)
        {
            discountRepository.AddDiscount(specialDiscount);
            DiscountMethod(choice, discountRepository);
            productRepository.AddSpecialDiscount(specialDiscount);
        }

        discountRepository.AddDiscount(generalDiscount);
        DiscountMethod(choice, discountRepository);
        productRepository.AddGeneralDiscount(generalDiscount);


        ITaxRepository taxRepository = new TaxRepository(product, tax);
        taxRepository.CalculateTax();
        productRepository.AddTax(tax);
    }

    private static void DiscountMethod(int choice, IDiscountRepository<IDiscount> discountRepository)
    {
        if (choice == 1)
        {
            discountRepository.Additive();
        }
        else if (choice == 2)
        {
            discountRepository.Multiplicative();
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