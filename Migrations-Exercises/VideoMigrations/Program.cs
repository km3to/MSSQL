using System;
using System.Linq;

namespace VideoMigrations
{
    class Program
    {
        static void Main(string[] args)
        {
            SalesContext context = new SalesContext();

            Console.WriteLine(context.Products.First().Name);
        }
    }
}
