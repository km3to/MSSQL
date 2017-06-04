namespace Bakery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main(string[] args)
        {
            var ctx = new BakeryContext();

            var products = ctx.Products
                .Where(CheckDistributor)
                .ToList();

            products.ForEach(p => Console.WriteLine(p.Name));
        }

        static bool CheckDistributor(Product p)
        {
            var distributorId = p.Ingredients
                .FirstOrDefault()
                .DistributorId;

            return p.Ingredients.All(i => i.DistributorId == distributorId);
        }
    }
}
