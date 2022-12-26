using Price_Calculator_Kata;
using Price_Calculator_Kata.Currencies;
using Price_Calculator_Kata.DiscountManager;
using Price_Calculator_Kata.ExpensesManager;
using Price_Calculator_Kata.Logging;
using Price_Calculator_Kata.PriceCalculation;
using Price_Calculator_Kata.ProductManager;
using Price_Calculator_Kata.TaxManager;
using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {

        ReadCustomerInputs(out string? CustomerTax, out string? CustomerDiscount, out string? spacialDiscount, out int CustomerChoice);

        IProduct product1 = new Product
        {
            Name = "The Little Prince",
            ProductType = "Book",
            UPC = 12345,
            Price = 20.25,
            IsSpecial = true,
            HasAddtionalExpenses = false,
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

        IList<IProduct> products = new List<IProduct>
        {
            product1,
            product2
        };

        ITax tax = new Tax { TaxPercentage = int.Parse(CustomerTax) };

        IDiscount generalDiscount = new Discount
        {
            DiscountPercentage = int.Parse(CustomerDiscount)
        };


        for (int i = 0; i < 1; i++)
        {
            IDiscountRepository discountRepository = new DiscountRepository(products[i]);

            ITaxRepository taxRepository = new TaxRepository(products[i], tax);
            taxRepository.CalculateTax();

            CalculateDiscount(products[i], discountRepository, generalDiscount, spacialDiscount, CustomerChoice);

            IExpenses transport = new TransportCost();
            IExpenses packaging = new PackagingCost();
            ApplyExpenses(products[i], transport, packaging);

            IPriceCalculations PriceCalculator = new PriceCalculations()
            {
                Price = products[i].Price,
                DiscountAmount = discountRepository.TotalDiscountAmount,
                TaxAmount = tax.TaxAmount,
                Transport = transport.Amount,
                Packaging = packaging.Amount
            };

            double Total = PriceCalculator.CalculateTotal();

            List<double> Prices = new List<double>
            {
                products[i].Price,
                discountRepository.TotalDiscountAmount,
                tax.TaxAmount,
                transport.Amount,
                packaging.Amount,
                Total
            };

            AdjustPrecision(Prices);

            string CurrencyCode =  CurrencyConverter(Prices);

            IReport Report = new Report()
            {
                Price = Prices[0],
                DiscountAmount = Prices[1],
                TaxAmount = Prices[2],
                Transport = Prices[3],
                Packaging = Prices[4],
                Total = Prices[5],
                CurrencyCode = CurrencyCode,
            };
            Report.PrepareReport();

            Logger.Print(products[i]);
            Logger.Print(Report.report);
        }
    }

    private static void AdjustPrecision(List<double> prices)
    {
        for (int i = 0; i < prices.Count; i++)
        {
            prices[i] = Precision.ChangePrecision(prices[i], 2);
        }
    }

    private static void ApplyExpenses(IProduct product, IExpenses transport, IExpenses packaging)
    {
        if (product.HasAddtionalExpenses)
        {
            transport.Amount = 2.2;
            packaging.Amount = 0.2;
        }
    }

    private static string CurrencyConverter(List<double> Prices)
    {
        ICurrency GBP = new Currency { CurrencyName = "USD" };

        if (GBP.CurrencyName == "USD") return "USD";

        CurrencyConverter converter = new(GBP);


        for (int j = 0; j < Prices.Count; j++)
        {
            Prices[j] = converter.Convert(Prices[j]);

        }
        return GBP.CurrencyName;
    }

    private static void CalculateDiscount(IProduct product, IDiscountRepository discountRepository, IDiscount generalDiscount, string spacialDiscount, int choice)
    {
        SpecifyCap(product, out double Cap);

        discountRepository.Cap = Cap;

        IDiscount specialDiscount = new Discount
        {
            DiscountPercentage = int.Parse(spacialDiscount)
        };

        if (product.IsSpecial)
        {
            discountRepository.AddDiscount(specialDiscount);
            DiscountMethod(choice, discountRepository);
        }

        discountRepository.AddDiscount(generalDiscount);
        DiscountMethod(choice, discountRepository);
    }

    private static void SpecifyCap(IProduct product, out double Cap)
    {
        Console.WriteLine("Please Spacify the cap amount, as:");
        Console.WriteLine("1) Amount. 2) Percentage");
        int CapChoice = int.Parse(Console.ReadLine());

        Console.Write("Cap: ");
        Cap = double.Parse(Console.ReadLine()!);

        if (CapChoice == 2)
        {
            Cap = Cap / 100 * product.Price;
        }
    }

    private static void DiscountMethod(int choice, IDiscountRepository discountRepository)
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

    private static void ReadCustomerInputs(out string? CustomerTax, out string? CustomerDiscount, out string? spacialDiscount, out int CustomerChoice)
    {
        Console.Write("Tax Percentage: ");
        CustomerTax = Console.ReadLine();
        Console.Write("Universal Discount Percentage: ");
        CustomerDiscount = Console.ReadLine();
        Console.Write("UPC Discount: ");
        spacialDiscount = Console.ReadLine();
        Console.WriteLine("Choose the way you want to have your discounts calculated");
        Console.WriteLine("1) Additive. 2) Multiplicative");
        CustomerChoice = int.Parse(Console.ReadLine()!);
    }
}