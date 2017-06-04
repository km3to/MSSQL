namespace FootballManager
{
    using Models;

    class Startup
    {
        static void Main(string[] args)
        {
            var context = new FMContext();

            context.Teams.Add(new Team() { Name = "Barcelona" });
            context.SaveChanges();        
        }
    }
}
