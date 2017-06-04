using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FromVideo
{
    class Program
    {
        static void Main(string[] args)
        {        
            Product milk = new Product("Prqsno plqko", "Tranpsort OOD", "Mlqko ot krava", 2.00m);
            milk.Quantity = 3;
            milk.Weight = 4;

            Product cheese = new Product("Bqlo sirene", "Sirene i vino", "Sirene ot shtastlivi jivotni", 15);
            cheese.Quantity = 0;
            cheese.Weight = 0;

            Product yellowCheese = new Product("Kashkaval", "Transport ODD", "Kashkaval.....", 25);
            yellowCheese.Quantity = 0;
            yellowCheese.Weight = 0;

            ProductsContext context = new ProductsContext();

            context.Products.Add(milk);
            context.Products.Add(cheese);
            context.Products.Add(yellowCheese);

            context.SaveChanges();
        }
    }
}
