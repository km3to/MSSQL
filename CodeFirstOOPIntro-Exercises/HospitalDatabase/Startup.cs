namespace HospitalDatabase
{
    using Models;

    class Startup
    {
        static void Main(string[] args)
        {
            var context = new HospitalDatabaseContext();

            context.Database.Initialize(true);
        }
    }
}
