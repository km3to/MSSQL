namespace Migrations
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
            var context = new SalesContext();

            
            context.Database.Initialize(true);            
        }
    }
}
