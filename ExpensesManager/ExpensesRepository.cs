using Price_Calculator_Kata.ProductManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata.ExpensesManager
{
    public  class ExpensesRepository
    {
        public IExpenses TransportCost { get; set; }
        public IExpenses PackagingCost { get; set; }

        public IProduct Product { get; set; }

        public ExpensesRepository(IProduct product)
        {
            Product = product;
        }

        public void AddCost(IExpenses additionalCost) {

            if(additionalCost.GetType() == typeof(TransportCost))
            {
                TransportCost = additionalCost;
            }
            if(additionalCost.GetType() == typeof(PackagingCost))
            {
                PackagingCost = additionalCost;
                PackagingCost.Amount = PackagingCost.Percentage / 100 * Product.Price;
            }
        }

    }
}
