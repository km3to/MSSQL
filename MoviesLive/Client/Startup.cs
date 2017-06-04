namespace Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Models;

    class Startup
    {
        static void Main(string[] args)
        {
            var ctx = new MoviesContext();
            //ctx.Database.Initialize(true);

            //ctx.Movies.Where(m => m.Title == "Contact").FirstOrDefault().Duration = 150;

            //ctx.SaveChanges();

            var vovie = ctx.Movies.Where(m => m.Title == "Contact").FirstOrDefault();

            Console.WriteLine(vovie.Duration);
        }
    }
}
