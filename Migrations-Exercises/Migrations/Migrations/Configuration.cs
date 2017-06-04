namespace Migrations.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SalesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SalesContext context)
        {
            context.Products.AddOrUpdate(new Product() { Name = "Car", Description = "Vehicle" });
        }
    }
}
