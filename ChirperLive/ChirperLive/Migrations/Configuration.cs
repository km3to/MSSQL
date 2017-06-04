namespace ChirperLive.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ChirperLive.ChirperContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ChirperLive.ChirperContext";
        }

        protected override void Seed(ChirperLive.ChirperContext context)
        {
            var cmt = new User()
            {
                Alias = "Pesho"
            };
            context.Users.AddOrUpdate(u => u.Alias, cmt);

            context.SaveChanges();
        }
    }
}
