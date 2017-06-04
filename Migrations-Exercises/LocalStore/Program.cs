using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStore
{
    class Program
    {
        static void Main(string[] args)
        {      
            var context = new ProductsContext();

            context.Products.Remove(context.Products.Find(1));

            context.SaveChanges();
        }
    }
}
