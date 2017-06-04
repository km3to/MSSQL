namespace RelationsLive
{
    using Models;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            var ctx = new RelationsLiveContext();
            ctx.Database.Initialize(true);

            var proj = ctx.Employees
                .FirstOrDefault()
                .ProjectEmployees
                .FirstOrDefault()
                .Project;
        }
    }
}
