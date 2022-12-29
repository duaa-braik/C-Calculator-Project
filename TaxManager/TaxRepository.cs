using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Price_Calculator_Kata.ProductManager;

namespace Price_Calculator_Kata.TaxManager
{

    public class TaxRepository : ITaxRepository
    {

        public ITax Tax { get; set; }
        public IProduct Product { get; set; }

        public TaxRepository(IProduct product, ITax tax)
        {
            Tax = tax;
            Product = product;
        }

        public void CalculateTax()
        {
            Tax.TaxAmount = Tax!.TaxPercentage / 100 * Product.Price;
        }
    }
}
